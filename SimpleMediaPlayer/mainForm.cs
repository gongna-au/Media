using AxWMPLib;
using SimpleMediaPlayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace SimpleMediaPlayer
{
    public partial class mainForm : Form
    {
        AxWindowsMediaPlayer testAWM = new AxWMPLib.AxWindowsMediaPlayer();
        SongsInfo currPlaySong = new SongsInfo(null);
        SongsInfo currSelectedSong = new SongsInfo(null);       //用于查看详情

        private string defaultSongsFilePath = @"C:\Users\Rhine\Music";
        private string localSongsFilePath = Application.StartupPath + "\\songListHistory.txt";
        private string favoriteSongsFilePath = Application.StartupPath + "\\favoriteSongsHistory.txt";
        private List<SongsInfo> oringinListSong;                //用于搜索功能
        private List<SongsInfo> localSongsList = new List<SongsInfo>();                 //本地音乐List
        private List<SongsInfo> favoriteSongsList = new List<SongsInfo>();              //收藏音乐List
        //随机0，单曲循环1，列表循环2
        public enum PlayMode { Shuffle = 0, SingleLoop, ListLoop };
        public PlayMode currPlayMode = PlayMode.Shuffle;
        private int[] randomList;           //随机播放序列
        private int randomListIndex = 0;    //序列索引
        private int jumpSongIndex;          //手动选中需要在随机过程中跳过的歌曲

        private ThumbnailToolbarButton ttbbtnPlayPause;
        private ThumbnailToolbarButton ttbbtnPre;
        private ThumbnailToolbarButton ttbbtnNext;
        List<MenuItem> menuItemList;

        public mainForm()
        {
            InitializeComponent();
            //检测MediaPlayer控件是否有安装
            //if (testAWM == null)
            //{
            //    throw new Exception();
            //}
            //else
            //{
            //    testAWM.Dispose();
            //}
            testAWM.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(AxWmp_PlayStateChange);

            MenuItem item1 = new MenuItem(Resources.list, "List");
            MenuItem item2 = new MenuItem(Resources.favorite, "Favorite");
            MenuItem item3 = new MenuItem(Resources.user, "User");
            MenuItem item4 = new MenuItem(Resources.album, "Album");
            MenuItem item5 = new MenuItem(Resources.ranking, "Rank");
            MenuItem item6 = new MenuItem(Resources.star, "Function");
            MenuItem item7 = new MenuItem(Resources.musicLibrary, "Music library");
            MenuItem item8 = new MenuItem(Resources.message, "Message");
            this.menuItemList = new List<MenuItem>();
            menuItemList.Add(item1);
            menuItemList.Add(item2);
            menuItemList.Add(item3);
            menuItemList.Add(item4);
            menuItemList.Add(item5);
            menuItemList.Add(item6);
            menuItemList.Add(item7);
            menuItemList.Add(item8);

            lbMenu.Items.Add("List");
            lbMenu.Items.Add("Favorite");
            lbMenu.Items.Add("Music library");
            lbMenu.Items.Add("User");
            lbMenu.Items.Add("Album");
            lbMenu.Items.Add("Rank");
            lbMenu.Items.Add("Function");
            lbMenu.Items.Add("Message");


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);    //分别是宽和高
            lvSongList.SmallImageList = imgList;

            MyColorTable myColorTable = new MyColorTable();
            cmsSongListMenu.Renderer = new ToolStripProfessionalRenderer(myColorTable);
            cmsSongListMenu.ForeColor = Color.White;
            cmsSongListMenu.BackColor = Color.FromArgb(48,47,51);

            pbAddSong.Visible = false;
        }

        #region 窗体Load、Shown、Closed事件
        /*
         * 设置各种初始状态
         */ 
        private void Form1_Load(object sender, EventArgs e)
        {
            //设置文件打开窗口（添加音乐）可多选
            this.odlgFile.Multiselect = true;
            //重置播放器状态信息
            ReloadStatus();
            //读取播放器列表历史记录
            localSongsList = ReadHistorySongsList(localSongsFilePath);
            favoriteSongsList = ReadHistorySongsList(favoriteSongsFilePath);
            //设置专辑图片控件到顶部页面（z-index)
            pbAlbumImage.BringToFront();
            //设置开机自启
            StarUp("0");
        }

        /*
         * 设置任务栏缩略图的属性与绑定事件 
         */
        private void Form1_Shown(object sender, EventArgs e)
        {
            //暂停按钮
            ttbbtnPlayPause = new ThumbnailToolbarButton(Properties.Resources.播放icon, "播放");
            ttbbtnPlayPause.Enabled = true;
            ttbbtnPlayPause.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(btnPlay_Click);

            //上一首按钮
            ttbbtnPre = new ThumbnailToolbarButton(Properties.Resources.上一首icon, "上一首");
            ttbbtnPre.Enabled = true;
            ttbbtnPre.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(btnBack_Click);

            //下一首按钮
            ttbbtnNext = new ThumbnailToolbarButton(Properties.Resources.下一首icon, "下一首");
            ttbbtnNext.Enabled = true;
            ttbbtnNext.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(btnNext_Click);
            TaskbarManager.Instance.ThumbnailToolbars.AddButtons(this.Handle, ttbbtnPre, ttbbtnPlayPause, ttbbtnNext);

            //裁剪显示略缩图
            //坐标值为多个父容器相对的位置坐标累加所得
            Point p = new Point(4, 558);    
            TaskbarManager.Instance.TabbedThumbnail.SetThumbnailClip(this.Handle, new Rectangle(p, pbSmallAlbum.Size));
        }

        /*
         * 窗体关闭事件 
         */
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            this.Dispose();
        }
        #endregion

        #region 公共模块

        #region 播放核心
        /*
         * 播放指定的歌曲
         * index：播放列表中，歌曲的序号
         */
        private void Play(int index)
        {
            //设置被播放音乐项的状态
            lvSongList.Items[index].Focused = true;
            lvSongList.Items[index].EnsureVisible();
            lvSongList.Items[index].Selected = true;

            //Console.WriteLine(lvSongList.Items[index].SubItems[6].Text);
            if (AxWmp.playState.ToString() == "wmppsPlaying")       //播放->其他状态
            {
                AxWmp.Ctlcontrols.pause();
                pbPlay.BackgroundImage = Resources.播放hoover;
                ttbbtnPlayPause.Icon = Resources.播放icon;
                return;
            }
            else if (AxWmp.playState.ToString() != "wmppsPaused")      //更改播放路径并播放
            {
                //生成随机序列
                BuildRandomList(lvSongList.Items.Count);
                jumpSongIndex = index;
                currPlaySong = new SongsInfo(lvSongList.SelectedItems[0].SubItems[6].Text);
                AxWmp.URL = currPlaySong.FilePath;
                AxWmp.Ctlcontrols.play();
                return;
            }
            else                            //暂停->播放
                AxWmp.Ctlcontrols.play();

            pbPlay.BackgroundImage = Resources.暂停hoover;
            ttbbtnPlayPause.Icon = Resources.暂停icon;
            ttbbtnPlayPause.Tooltip = "暂停";
        }

        /*
         * 计时器函数
         */
        private void timerPlay_Tick(object sender, EventArgs e)
        {
            //设置当前播放时间
            lbcurrTime.Text = AxWmp.Ctlcontrols.currentPositionString;
            lbEndTime.Text = currPlaySong.Duration.Remove(0, 3);

            //设置滑动条值
            tkbMove.Value = (int)AxWmp.Ctlcontrols.currentPosition;
        }

        /*
         * 播放器控件状态改变事件
         */
        private void AxWmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch (e.newState)
            {
                case 0:    // Stopped 未知状态
                    break;

                case 1:    // Stopped 停止
                    timerPlay.Stop();
                    ReloadStatus();
                    break;

                case 2:    // Paused 暂停
                    timerPlay.Stop();
                    break;

                case 3:    // Playing 正在播放
                    timerPlay.Start();
                    //显示专辑图片
                    pbAlbumImage.Image = currPlaySong.AlbumImage;
                    pbSmallAlbum.BackgroundImage = currPlaySong.SmallAblum;
                    lbSmallAlbumSingerName.Text = currPlaySong.Artist;

                    //显示歌曲标题名字
                    lbMusicName.Text = currPlaySong.FileName;
                    if (currPlaySong.FileName.Length > 18)
                        lbSmallAlbumSongName.Text = currPlaySong.FileName.Substring(0, 18) + "...";
                    else
                        lbSmallAlbumSongName.Text = currPlaySong.FileName;
                    
                    tkbMove.Maximum = (int)AxWmp.currentMedia.duration;

                    int currIndex = lvSongList.SelectedItems[0].Index;
                    lvSongList.SelectedItems.Clear();
                    lvSongList.Items[currIndex].Selected = true;    //设定选中            
                    lvSongList.Items[currIndex].EnsureVisible();    //保证可见
                    lvSongList.Items[currIndex].Focused = true;
                    lvSongList.Select();
                    break;

                case 4:    // ScanForward
                    //tsslCurrentPlayState.Text = "ScanForward";
                    break;

                case 5:    // ScanReverse
                    //tsslCurrentPlayState.Text = "ScanReverse";
                    break;
                case 6:    // Buffering
                    //tsslCurrentPlayState.Text = "正在缓冲";
                    break;

                case 7:    // Waiting
                    //tsslCurrentPlayState.Text = "Waiting";
                    break;

                case 8:    // MediaEnded
                    //tsslCurrentPlayState.Text = "MediaEnded";
                    break;

                case 9:    // Transitioning
                    //tsslCurrentPlayState.Text = "正在连接";
                    break;

                case 10:   // Ready
                    //tsslCurrentPlayState.Text = "准备就绪";
                    break;

                case 11:   // Reconnecting
                    //tsslCurrentPlayState.Text = "Reconnecting";
                    break;

                case 12:   // Last
                    //tsslCurrentPlayState.Text = "Last";
                    break;
                default:
                    //tsslCurrentPlayState.Text = ("Unknown State: " + e.newState.ToString());
                    break;
            }

            if (AxWmp.playState.ToString() == "wmppsMediaEnded")
            {
                //Console.WriteLine(lvSongList.SelectedItems[0].Index + ":播放完毕");
                //获取音乐播放文件路径，并添加到播放控件
                string path = GetPath();
                WMPLib.IWMPMedia media = AxWmp.newMedia(path);
                AxWmp.currentPlaylist.appendItem(media);
            }
        }

        /*
         * 重置播放器状态信息
         */
        private void ReloadStatus()
        {
            //设置专辑封面为默认
            pbAlbumImage.Image = Properties.Resources.defaultAlbum;
            lbMusicName.Text = "SimpleMediaPlayer";
            lbcurrTime.Text = "00:00";
            lbEndTime.Text = "00:00";
            tkbVol.Value = tkbVol.Maximum / 2;
            tkbMove.Value = 0;
            if (lvSongList.Items.Count > 0 && lvSongList.SelectedItems.Count == 0)
            {
                lvSongList.Items[0].Selected = true;//设定选中            
                lvSongList.Items[0].EnsureVisible();//保证可见
                lvSongList.Items[0].Focused = true;
            }
        }
        #endregion

        #region 播放模式
        /*
         * 详见博客：https://blog.csdn.net/qq_34802416/article/details/77220654
         */
        private string GetPath()
        {
            int currIndex = lvSongList.SelectedItems[0].Index;
            switch (currPlayMode)
            {
                case PlayMode.ListLoop:
                    if (currIndex != lvSongList.Items.Count - 1)
                        currIndex += 1;
                    else
                        currIndex = 0;

                    break;
                case PlayMode.SingleLoop:
                    Console.WriteLine("SingleLoop");
                    //do nothing
                    break;
                case PlayMode.Shuffle:
                    //当局结束
                    if (randomListIndex > randomList.Length - 1)
                        StarNewRound();

                    //匹配到需要跳过的歌曲
                    if (randomList[randomListIndex] == jumpSongIndex)
                        if (randomListIndex == randomList.Length - 1)   //当局结束
                            StarNewRound();
                        else
                            randomListIndex++;

                    currIndex = randomList[randomListIndex++];

                    break;
            }

            lvSongList.Items[currIndex].Selected = true;//设定选中            
            lvSongList.Items[currIndex].EnsureVisible();//保证可见
            lvSongList.Items[currIndex].Focused = true;
            currPlaySong = new SongsInfo(lvSongList.SelectedItems[0].SubItems[6].Text);

            return currPlaySong.FilePath;
        }

        private void StarNewRound()
        {
            //重新生成随机序列
            BuildRandomList(lvSongList.Items.Count);
            //第二轮开始 播放所有歌曲 不跳过
            jumpSongIndex = -1;
        }

        private void BuildRandomList(int songListCount)
        {
            randomListIndex = 0;
            randomList = new int[songListCount];

            //初始化序列
            for (int i = 0; i < songListCount; i++)
            {
                randomList[i] = i;
            }

            //随机序列
            for (int i = songListCount - 1; i >= 0; i--)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int j = r.Next(0, songListCount - 1);
                swap(randomList, i, j);
            }

            //输出序列
            //for (int i = 0; i < songListCount; i++)
            //{
            //    Console.Write(randomList[i] + " ");
            //}
            //Console.WriteLine(" ");
        }

        private void swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
        #endregion

        #region 开机自启
        private void StarUp(string flag)
        {
            string path = Application.StartupPath;
            string keyName = path.Substring(path.LastIndexOf("//") + 1);
            Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (flag.Equals("1"))
            {
                if (Rkey == null)
                {
                    Rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Rkey.SetValue(keyName, path + @"\SimpleMediaPlayer.exe");
            }
            else
            {
                if (Rkey != null)
                {
                    Rkey.DeleteValue(keyName, false);
                }
            }
        }
        #endregion

        #region 系统托盘
        /*
         * 窗体大小改变事件
         */
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon1.Visible = true;
            }
        }

        /*
         * 系统托盘双击事件
         */
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        /*
         * 系统托盘菜单——打开
         */
        private void tsmiOpenForm_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        /*
         * 系统托盘菜单——退出
         */
        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            this.Close();
        }
        #endregion

        #region 读写播放列表历史记录
        /*
         * 保存历史记录到本地文件
         */
        private void SaveSongsListHistory(string savePath, List<SongsInfo> songsList)
        {
            string saveString = "";
            for (int i = 0; i < songsList.Count; i++)
            {
                saveString += songsList[i].FilePath + "};{";
            }
            File.WriteAllText(savePath, saveString);
        }

        /*
         * 读取历史记录到本地文件
         */
        private List<SongsInfo> ReadHistorySongsList(string filePath)
        {
            List<SongsInfo> resSongList = new List<SongsInfo>();
            string readString = "";
            if (File.Exists(filePath))
            {
                readString = File.ReadAllText(filePath);
                if (readString != "")
                {
                    string[] arr = readString.Split(new string[] { "};{" }, StringSplitOptions.None);
                    foreach (string path in arr)
                    {
                        if (path != null && path != "" && File.Exists(path))
                        {
                            resSongList.Add(new SongsInfo(path));
                        }
                    }
                }
            }
            else
                File.Create(filePath);

            return resSongList;
        }
        #endregion

        #region 按钮交互体验
        /*
         * 鼠标移入事件集合
         *     鼠标移入改变按钮图标
         */
        private void MoveEnter_ChangeIconToHooverStyle(object sender, EventArgs e)
        {
            PictureBox currPicBox = (PictureBox)sender;
            if (currPicBox.Name == "pbPlay")
            {
                if (AxWmp.playState.ToString() == "wmppsPlaying")       //播放->其他状态
                {
                    pbPlay.BackgroundImage = Resources.暂停hoover;
                }
                else
                {
                    pbPlay.BackgroundImage = Resources.播放hoover;
                }
            }
            else if (currPicBox.Name == "pbBack")
            {
                pbBack.BackgroundImage = Resources.上一首hoover;
            }
            else if (currPicBox.Name == "pbNext")
            {
                pbNext.BackgroundImage = Resources.下一首hoover;
            }
            else if (currPicBox.Name == "pbCloseForm")
            {
                currPicBox.Image = Resources.关闭hoover;
            }
            else if (currPicBox.Name == "pbMaxForm")
            {
                currPicBox.Image = Resources.最大化hoover;
            }
            else if (currPicBox.Name == "pbMinForm")
            {
                currPicBox.Image = Resources.最小化hoover;
            }
            else if (currPicBox.Name == "pbSmallAlbum")
            {
                currPicBox.Image = Resources.展开;
            }
            else if (currPicBox.Name == "pbAddSong")
            {
                currPicBox.Image = Resources.添加hoover;
            }
        }

        /*
         * 鼠标移出事件集合
         *     鼠标移入改变按钮图标
         */
        private void MoveLeave_ChangeIconToNormalStyle(object sender, EventArgs e)
        {
            PictureBox currPicBox = (PictureBox)sender;
            if (currPicBox.Name == "pbPlay")
            {
                if (AxWmp.playState.ToString() == "wmppsPlaying")       //播放->其他状态
                {
                    pbPlay.BackgroundImage = Resources.暂停;
                }
                else
                {
                    pbPlay.BackgroundImage = Resources.播放;
                }
            }
            else if (currPicBox.Name == "pbBack")
            {
                pbBack.BackgroundImage = Resources.上一首;
            }
            else if (currPicBox.Name == "pbNext")
            {
                pbNext.BackgroundImage = Resources.下一首;
            }
            else if (currPicBox.Name == "pbCloseForm")
            {
                currPicBox.Image = Resources.关闭;
            }
            else if (currPicBox.Name == "pbMaxForm")
            {
                currPicBox.Image = Resources.最大化;
            }
            else if (currPicBox.Name == "pbMinForm")
            {
                currPicBox.Image = Resources.最小化;
            }
            else if (currPicBox.Name == "pbSmallAlbum")
            {
                currPicBox.Image = null;
            }
            else if (currPicBox.Name == "pbAddSong")
            {
                currPicBox.Image = Resources.添加音乐;
            }
        }
        #endregion

        #endregion

        #region 窗体顶部
        /*
         * 拖动窗口，标题文字拖动变色（默认gray、拖动white）
         */
        Point downPoint;
        private void lbTitle_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = new Point(e.X, e.Y);
            lbTitle.ForeColor = Color.White;
        }
        private void lbTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - downPoint.X, this.Location.Y + e.Y - downPoint.Y);
            }
        }
        private void lbTitle_MouseUp(object sender, MouseEventArgs e)
        {
            lbTitle.ForeColor = Color.Gray;
        }

        /*
         * 关闭、最大化、最小化按钮点击事件
         */
        private void FormControlButton_Click(object sender, EventArgs e)
        {
            PictureBox currPicBox = (PictureBox)sender;
            if (currPicBox.Name == "pbCloseForm")
            {
                this.Close();
            }
            else if (currPicBox.Name == "pbMaxForm")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (currPicBox.Name == "pbMinForm")
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
        #endregion

        #region 窗体左部菜单
        /*
         * 绘制单元项
         */
        private void lbMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            Bitmap bitmap = new Bitmap(e.Bounds.Width, e.Bounds.Height);

            int index = e.Index;                                //获取当前要进行绘制的行的序号，从0开始。
            Graphics g = e.Graphics;                            //获取Graphics对象。

            Graphics tempG = Graphics.FromImage(bitmap);

            tempG.SmoothingMode = SmoothingMode.AntiAlias;          //使绘图质量最高，即消除锯齿
            tempG.InterpolationMode = InterpolationMode.HighQualityBicubic;
            tempG.CompositingQuality = CompositingQuality.HighQuality;

            Rectangle bound = e.Bounds;                         //获取当前要绘制的行的一个矩形范围。
            string text = this.menuItemList[index].Text.ToString();     //获取当前要绘制的行的显示文本。

            //绘制选中时的背景，要注意绘制的顺序，后面的会覆盖前面的
            //绘制底色
            Color backgroundColor = Color.FromArgb(34, 35, 39);             //背景色
            Color guideTagColor = Color.FromArgb(183, 218, 114);            //高亮指示色
            Color selectedBackgroundColor = Color.FromArgb(46, 47, 51);     //选中背景色
            Color fontColor = Color.Gray;                                   //字体颜色
            Color selectedFontColor = Color.White;                          //选中字体颜色
            Font textFont = new Font("微软雅黑", 9, FontStyle.Bold);        //文字
            //图标
            Image itmeImage = this.menuItemList[index].Img;

            //矩形大小
            Rectangle backgroundRect = new Rectangle(0, 0, bound.Width, bound.Height);
            Rectangle guideRect = new Rectangle(0, 4, 5, bound.Height - 8);
            Rectangle textRect = new Rectangle(55, 0, bound.Width, bound.Height);
            Rectangle imgRect = new Rectangle(20, 4, 22, bound.Height - 8);

            //当前选中行
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = selectedBackgroundColor;
                fontColor = selectedFontColor;
            }
            else
            {
                guideTagColor = backgroundColor;
            }
            //绘制背景色
            tempG.FillRectangle(new SolidBrush(backgroundColor), backgroundRect);
            //绘制左前高亮指示
            tempG.FillRectangle(new SolidBrush(guideTagColor), guideRect);
            //绘制显示文本
            TextRenderer.DrawText(tempG, text, textFont, textRect, fontColor,
                                  TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            //绘制图标
            tempG.DrawImage(itmeImage, imgRect);

            g.DrawImage(bitmap, bound.X, bound.Y, bitmap.Width, bitmap.Height);
            tempG.Dispose();
        }

        /*
         * 设置行高
         */
        private void lbMenu_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        /*
         * 菜单按钮选中事件
         */
        private void lbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lbMenu.SelectedIndex)
            {
                case 0:     //选中的是本地列表
                    lvSongList.Items.Clear();
                    AddSongsToListView(localSongsList);

                    lvSongList.BringToFront();
                    tsmiFavorite.Visible = true;
                    pbAddSong.Visible = true;
                    lbMusicName.Visible = false;
                    lbCategory.Text = "本地音乐";
                    lbCategory.Visible = true;
                    lbSongCount.Visible = true;

                    break;
                case 1:     //选中的是收藏音乐
                    lvSongList.Items.Clear();
                    AddSongsToListView(favoriteSongsList);

                    lvSongList.BringToFront();
                    tsmiFavorite.Visible = false;
                    pbAddSong.Visible = false;
                    lbMusicName.Visible = false;
                    lbCategory.Text = "收藏音乐";
                    lbCategory.Visible = true;
                    lbSongCount.Visible = true;

                    break;
            }

            int songsCount = lvSongList.Items.Count;
            lbSongCount.Text = songsCount + "首音乐";
        }


        /*
         * 专辑小图标点击事件
         */
        private void pbSmallAlbum_Click(object sender, EventArgs e)
        {
            pbAlbumImage.BringToFront();
            pbAddSong.Visible = false;
            lbSongCount.Visible = false;
            lbCategory.Visible = false;
            lbMusicName.Visible = true;
        }
        #endregion

        #region 窗体右部
        #region 播放列表
        /*
         * 播放列表重绘
         */
        private void lvSongList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            int index = e.ColumnIndex;

            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(27, 27, 25)), e.Bounds);
            TextRenderer.DrawText(e.Graphics, lvSongList.Columns[index].Text, new Font("微软雅黑", 9, FontStyle.Regular), e.Bounds, Color.Gray, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            Pen pen = new Pen(Color.FromArgb(34, 35, 39), 2);
            Point p = new Point(e.Bounds.Left - 1, e.Bounds.Top + 1);
            Size s = new Size(e.Bounds.Width, e.Bounds.Height - 2);
            Rectangle r = new Rectangle(p, s);
            e.Graphics.DrawRectangle(pen, r);
        }
        private void lvSongList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Console.WriteLine("selectedCount:" + lvSongList.SelectedItems.Count);
            if (e.ItemIndex == -1)
            {
                return;
            }

            if (e.ItemIndex % 2 == 0)
            {
                e.SubItem.BackColor = Color.FromArgb(27, 29, 32);
                e.DrawBackground();
            }

            if (e.ColumnIndex == 1)
            {
                e.SubItem.ForeColor = Color.White;
            }
            else
            {
                e.SubItem.ForeColor = Color.Gray;
            }

            if ((e.ItemState & ListViewItemStates.Selected) == ListViewItemStates.Selected)
            {
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 47, 51)), e.Bounds);
                }
            }

            if (!string.IsNullOrEmpty(e.SubItem.Text))
            {
                this.DrawText(e, e.Graphics, e.Bounds, 2);
            }
        }
        private void DrawText(DrawListViewSubItemEventArgs e, Graphics g, Rectangle r, int paddingLeft)
        {
            TextFormatFlags flags = GetFormatFlags(e.Header.TextAlign);

            r.X += 1 + paddingLeft;//重绘图标时，文本右移
            TextRenderer.DrawText(
                g,
                e.SubItem.Text,
                e.SubItem.Font,
                r,
                e.SubItem.ForeColor,
                flags);
        }
        private TextFormatFlags GetFormatFlags(HorizontalAlignment align)
        {
            TextFormatFlags flags =
                    TextFormatFlags.EndEllipsis |
                    TextFormatFlags.VerticalCenter;

            switch (align)
            {
                case HorizontalAlignment.Center:
                    flags |= TextFormatFlags.HorizontalCenter;
                    break;
                case HorizontalAlignment.Right:
                    flags |= TextFormatFlags.Right;
                    break;
                case HorizontalAlignment.Left:
                    flags |= TextFormatFlags.Left;
                    break;
            }

            return flags;
        }

        /*
         * 播放列表双击事件
         */
        private void lvSongList_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine(lvSongList.SelectedItems[0].Index);

            int currIndex = lvSongList.SelectedItems[0].Index;
            string songFilePath = lvSongList.Items[currIndex].SubItems[6].Text;
            if (currPlaySong.FilePath == songFilePath)
            {
                //选中歌曲为正在播放的歌曲
                if (AxWmp.playState.ToString() == "wmppsPlaying")
                {
                    AxWmp.Ctlcontrols.pause();
                    pbPlay.BackgroundImage = Resources.播放;
                    ttbbtnPlayPause.Icon = Resources.播放icon;
                }
                else if (AxWmp.playState.ToString() == "wmppsPaused")
                {
                    AxWmp.Ctlcontrols.play();
                    pbPlay.BackgroundImage = Resources.暂停;
                    ttbbtnPlayPause.Icon = Resources.暂停icon;
                }
            }
            else
            {
                //选中的为其他歌曲
                BuildRandomList(lvSongList.Items.Count);
                jumpSongIndex = currIndex;
                currPlaySong = new SongsInfo(songFilePath);
                AxWmp.URL = songFilePath;
                AxWmp.Ctlcontrols.play();
                pbPlay.BackgroundImage = Resources.暂停;
                ttbbtnPlayPause.Icon = Resources.暂停icon;
            }
            lvSongList.Items[currIndex].Focused = true;
        }

        private void lvSongList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = lvSongList.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    cmsSongListMenu.Visible = true;
                    currSelectedSong = new SongsInfo(lvi.SubItems[6].Text);
                    cmsSongListMenu.Show(Cursor.Position);
                }
                else
                    cmsSongListMenu.Close();
            }
        }

        #region 播放列表右键菜单(收藏音乐、删除音乐、打开文件位置)
        /*
         * 菜单——收藏音乐
         */
        private void tsmiFavorite_Click(object sender, EventArgs e)
        {
            foreach (SongsInfo song in favoriteSongsList)
            {
                if (currSelectedSong.FilePath == song.FilePath)
                    return;
            }

            favoriteSongsList.Add(new SongsInfo(currSelectedSong.FilePath));
            SaveSongsListHistory(favoriteSongsFilePath, favoriteSongsList);
        }

        /*
         * 菜单——删除音乐
         */
        private void tsmiRemoveSongFromList_Click(object sender, EventArgs e)
        {
            DeleteSongFormList deleteSongFormList = new DeleteSongFormList(currSelectedSong.FilePath);
            if (deleteSongFormList.ShowDialog() == DialogResult.OK)
            {
                int removeIndex = lvSongList.SelectedItems[0].Index;
                if (lbMenu.SelectedIndex == 0)
                {
                    localSongsList.RemoveAt(removeIndex);
                    SaveSongsListHistory(localSongsFilePath, localSongsList);
                    AddSongsToListView(localSongsList);
                }
                else if (lbMenu.SelectedIndex == 1)
                {
                    favoriteSongsList.RemoveAt(removeIndex);
                    SaveSongsListHistory(favoriteSongsFilePath, favoriteSongsList);
                    AddSongsToListView(favoriteSongsList);
                }

                UpdataOringinSongList();
            }
        }

        /*
         * 菜单——打开文件位置
         */
        private void tsmiOpenFilePath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Explorer.exe", "/select,\"" + currSelectedSong.FilePath + "\"");
        }
        #endregion
        #endregion

        #region 添加音乐
        private void tsmiOpenFile_Click(object sender, EventArgs e)
        {
            this.odlgFile.InitialDirectory = defaultSongsFilePath;
            this.odlgFile.Filter = "媒体文件|*.mp3;*.wav;*.wma;*.avi;*.mpg;*.asf;*.wmv";
            if (odlgFile.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < odlgFile.FileNames.Length; i++)
                {
                    string path = odlgFile.FileNames[i];
                    if (!IsExistInList(path))
                        localSongsList.Add(new SongsInfo(path));
                }
            }

            AddSongsToListView(localSongsList);
            SaveSongsListHistory(localSongsFilePath, localSongsList);

            UpdataOringinSongList();
        }

        private bool IsExistInList(string path)
        {
            for (int i = 0; i < localSongsList.Count; i++)
            {
                if (path == localSongsList[i].FilePath)
                    return true;
            }
            return false;
        }

        private void AddSongsToListView(List<SongsInfo> songList)
        {
            lvSongList.BeginUpdate();
            lvSongList.Items.Clear();
            foreach (SongsInfo song in songList)
            {
                string[] songAry = new string[6];
                int currCount = lvSongList.Items.Count + 1;
                if (currCount < 10)
                    songAry[0] = "0" + currCount;
                else
                    songAry[0] = "" + currCount;

                songAry[1] = song.FileName;
                songAry[2] = song.Artist;
                songAry[3] = song.Album;
                songAry[4] = song.Duration;
                songAry[5] = song.Filesize;


                ListViewItem lvItem = new ListViewItem(songAry);
                lvItem.SubItems.Add(song.FilePath);
                lvSongList.Items.Add(lvItem);

                WMPLib.IWMPMedia media = AxWmp.newMedia(song.FilePath);
                AxWmp.currentPlaylist.appendItem(media);
            }
            lvSongList.EndUpdate();
        }

        #endregion

        #region 列表搜索
        private void txtSreachSongName_Enter(object sender, EventArgs e)
        {
            if (txtSreachSongName.Text == "输入要搜索的歌曲名")
                txtSreachSongName.Text = "";
        }

        private void txtSreachSongName_Leave(object sender, EventArgs e)
        {
            if (txtSreachSongName.Text == "")
                txtSreachSongName.Text = "输入要搜索的歌曲名";
        }

        private void txtSreachSongName_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(txtSreachSongName.Text);
            lbNoResults.SendToBack();
            //初始化
            if (txtSreachSongName.Text == "")
            {
                switch (lbMenu.SelectedIndex)
                {
                    case 0:
                        AddSongsToListView(localSongsList);
                        break;
                    case 1:
                        AddSongsToListView(favoriteSongsList);
                        break;
                }
                return;
            }
            else
            {
                List<SongsInfo> resultList = new List<SongsInfo>();

                Dictionary<string, SongsInfo> resultDic = new Dictionary<string, SongsInfo>();
                string strSreach = txtSreachSongName.Text;
                Regex r = new Regex(Regex.Escape(strSreach), RegexOptions.IgnoreCase);

                for (int i = 0; i < localSongsList.Count; i++)
                {
                    Match m = r.Match(localSongsList[i].FileName);
                    if (m.Success)
                    {
                        resultDic.Add(localSongsList[i].FilePath, localSongsList[i]);
                    }
                }

                for (int i = 0; i < favoriteSongsList.Count; i++)
                {
                    Match m = r.Match(favoriteSongsList[i].FileName);
                    if (m.Success && !resultDic.ContainsKey(localSongsList[i].FilePath))
                    {
                        resultDic.Add(localSongsList[i].FilePath, localSongsList[i]);
                    }
                }


                if (resultDic.Count > 0)
                {
                    List<SongsInfo> resList = new List<SongsInfo>();
                    foreach (SongsInfo song in resultDic.Values)
                    {
                        resList.Add(song);
                    }
                    AddSongsToListView(resList);
                }
                else
                {
                    lvSongList.Items.Clear();
                    //没有搜索结果
                    lbNoResults.BringToFront();
                }
            }
        }

        private void UpdataOringinSongList()
        {
            oringinListSong = new List<SongsInfo>();
            for (int i = 0; i < lvSongList.Items.Count; i++)
            {
                oringinListSong.Add(new SongsInfo(lvSongList.Items[i].SubItems[6].Text));
            }
        }
        #endregion
        #endregion

        #region 窗体底部
        #region 控制按钮单击事件
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (AxWmp.playState.ToString() == "wmppsPlaying")       //播放->暂停
            {
                AxWmp.Ctlcontrols.pause();
                pbPlay.BackgroundImage = Resources.播放hoover;
                ttbbtnPlayPause.Icon = Resources.播放icon;
                return;
            }
            else if (AxWmp.playState.ToString() == "wmppsPaused")    //暂停->播放
            {
                AxWmp.Ctlcontrols.play();
                pbPlay.BackgroundImage = Resources.暂停hoover;
                ttbbtnPlayPause.Icon = Resources.暂停icon;
                return;
            }

            if (lvSongList.SelectedItems.Count > 0)         //双击播放列表控制
            {
                Play(lvSongList.SelectedItems[0].Index);
            }
            else
                MessageBox.Show("请选择要播放的曲目");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lvSongList.Items.Count == 0)
            {
                MessageBox.Show("请先添加曲目至目录");
                return;
            }

            int currIndex = lvSongList.SelectedItems[0].Index;
            if (currIndex > 0)
            {
                AxWmp.Ctlcontrols.stop();
                currIndex -= 1;
            }
            else
            {
                AxWmp.Ctlcontrols.stop();
                currIndex = lvSongList.Items.Count - 1;
            }

            lvSongList.Items[currIndex].Focused = true;
            lvSongList.Items[currIndex].EnsureVisible();
            lvSongList.Items[currIndex].Selected = true;

            Play(currIndex);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lvSongList.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先添加曲目至目录");
                return;
            }

            int currIndex = lvSongList.SelectedItems[0].Index;
            if (currIndex < lvSongList.Items.Count - 1)
            {
                AxWmp.Ctlcontrols.stop();
                currIndex += 1;
            }
            else
            {
                AxWmp.Ctlcontrols.stop();
                currIndex = 0;
            }

            Play(currIndex);
        }

        private void btnPlayMode_Click(object sender, EventArgs e)
        {
            if (currPlayMode == PlayMode.ListLoop)
                currPlayMode = PlayMode.Shuffle;
            else
                currPlayMode += 1;

            if (currPlayMode == PlayMode.SingleLoop)
                btnPlayMode.BackgroundImage = Properties.Resources.单曲循环;
            else if (currPlayMode == PlayMode.ListLoop)
                btnPlayMode.BackgroundImage = Properties.Resources.列表循环;
            else
                btnPlayMode.BackgroundImage = Properties.Resources.随机播放;
        }
        #endregion

        #region 音量与进度条事件
        private void tkbVol_ValueChanged(object sender, EventArgs e)
        {
            AxWmp.settings.volume = tkbVol.Value;
            //lbVolumeVal.Text = tkbVol.Value.ToString() + "%";
        }

        private void tkbVol_MouseHover(object sender, EventArgs e)
        {
            //lbVolumeVal.Text = tkbVol.Value.ToString() + "%";
        }

        private void tkbVol_MouseLeave(object sender, EventArgs e)
        {
            //lbVolumeVal.Text = "音量：";
        }

        private void tkbMove_Scroll(object sender, EventArgs e)
        {
            AxWmp.Ctlcontrols.currentPosition = (double)this.tkbMove.Value;
        }
        #endregion
        #endregion
    }
}
