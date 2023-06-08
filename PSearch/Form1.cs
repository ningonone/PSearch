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
                selectFolder.Text = "当前搜索目录：" + selectedFolderPath;
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
                    MessageBox.Show("无法打开文件夹：" + ex.Message);
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
                    MessageBox.Show("无法打开文件夹：" + ex.Message);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("使用方法:\n" +
                            "1.选择屏参存放的文件夹\n" +
                            "2.输入规格书名称or关键字，点击搜索\n" +
                            "3.列表显示该规格书屏参的文件夹，双击即可打开");
        }

        
    }
}