using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMediaPlayer
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainForm());
            //}
            //catch(Exception ex)
            //{
            //    string message = "您的系统可能尚未安装Windwos Media Player，现在是否进行安装？";
            //    string caption = "错误提示";
            //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            //    DialogResult result;
            //    result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question,
            //                                MessageBoxDefaultButton.Button1);

            //    if(result==DialogResult.Yes)
            //    {
            //        //安装控件
            //        InstallWMP();
            //    }
            //}
            
        }

        //获取系统版本
        private static string GetOSEdition()
        {
            //OperationSystem类处理操作系统相关信息
            System.OperatingSystem mos = System.Environment.OSVersion;
            string mosName = "";

            //Platform为操作系统的ID值
            switch (mos.Platform)
            {
                //Win95或更高版本
                case System.PlatformID.Win32Windows:
                {
                    mosName = "win9.x";
                    break;
                }
                //WinNT或更高版本
                case System.PlatformID.Win32NT:
                {
                    //Major为版本号
                    switch(mos.Version.Major)
                    {
                        case 3:
                            mosName = "win9.x";
                            break;
                        case 4:
                            mosName = "win9.x";
                            break;
                        case 5:
                        {
                            if (mos.Version.Minor == 0)
                            {
                                mosName = "win9.x";
                            }
                            else if(mos.Version.Minor == 1)
                            {
                                mosName = "Windows XP";
                            }
                            else if (mos.Version.Minor == 2)
                            {
                                mosName = "Windows Server 2003";
                            }
                            break;
                        }
                        case 6:
                        {
                            if(mos.Version.Minor==0)
                            {
                                mosName = "Windows Vista";
                            }
                            else if(mos.Version.Minor==1)
                            {
                                mosName = "Windows7";
                            }
                            else
                            {
                                mosName = "Longhorn";
                            }
                            break;
                        }
                    }
                }
                break;
            }
            return mosName;
        }

        public static void ExecuteFile(string fileName)
        {
            try
            {
                Process pro = new Process();
                pro.StartInfo.UseShellExecute = false;

                //要执行的exe文件名
                pro.StartInfo.FileName = fileName;
                pro.StartInfo.CreateNoWindow = true;
                pro.Start();
            }
            catch(System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //安装WMP
        public static void InstallWMP()
        {
            string mosName = GetOSEdition();
            string fileName = "";
            switch (mosName)
            {
                case "win9.x":
                    fileName = "mpsetup9x.exe";
                    break;
                case "Windows XP":
                    fileName = "mpsetupXP.exe";
                    break;
                case "Windows Server 2003":
                    fileName = "mpsetupXP.exe";
                    break;
            }

            if(fileName!="")
            {
                ExecuteFile(fileName);
            }
            else
            {
                MessageBox.Show("对不起！获取安装文件失败请你手动安装。", "安装提示");
            }
        }
    }
}
