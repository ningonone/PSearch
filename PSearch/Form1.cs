using System.Diagnostics;

namespace PSearch
{
    public partial class Form1 : Form
    {
        string selectedFolderPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = folderBrowserDialog.SelectedPath;
                }
                selectFolder.Text = "��ǰ����Ŀ¼��" + selectedFolderPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedFolderPath) && !string.IsNullOrEmpty(txtKeyword.Text))
            {
                string[] files = Directory.GetFiles(selectedFolderPath, "*" + txtKeyword.Text + "*", SearchOption.AllDirectories);

                lstSearchResults.Items.Clear();

                foreach (string file in files)
                {
                    lstSearchResults.Items.Add(file);
                }
            }

        }

        private void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSearchResults.SelectedItem != null)
            {
                string selectedFilePath = lstSearchResults.SelectedItem.ToString();
                string selectedFolderPath = Path.GetDirectoryName(selectedFilePath);

                try
                {
                    Process.Start("explorer.exe", selectedFolderPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�޷����ļ��У�" + ex.Message);
                }
            }
        }

        private void lstSearchResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstSearchResults.SelectedItem != null)
            {
                string selectedFilePath = lstSearchResults.SelectedItem.ToString();
                string selectedFolderPath = Path.GetDirectoryName(selectedFilePath);

                try
                {
                    Process.Start("explorer.exe", selectedFolderPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�޷����ļ��У�" + ex.Message);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ʹ�÷���:\n" +
                            "1.ѡ�����δ�ŵ��ļ���\n" +
                            "2.������������or�ؼ��֣��������\n" +
                            "3.�б���ʾ�ù�������ε��ļ��У�˫�����ɴ�");
        }

        
    }
}