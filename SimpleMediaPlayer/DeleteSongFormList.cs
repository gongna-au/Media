using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace SimpleMediaPlayer
{
    public partial class DeleteSongFormList : Form
    {
        public bool ReturnIsDelete { get; protected set; }
        private string filePath;

        public DeleteSongFormList(string path)
        {
            InitializeComponent();
            filePath = path;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ReturnIsDelete = true;
            if(cbIsDeleteLocalFile.Checked == true)
            {
                //删除本地文件
                DeleteLocalFile();
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnIsDelete = false;
            DialogResult = DialogResult.Cancel;
        }

        private void DeleteLocalFile()
        {
            try
            {
                if(File.Exists(filePath))
                {
                    FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
                else
                {
                    MessageBox.Show("文件不存在");
                }
            }
            catch(Exception) { }
        }
    }
}
