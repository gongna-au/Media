namespace SimpleMediaPlayer
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.tkbMove = new System.Windows.Forms.TrackBar();
            this.ntiContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenForm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.odlgFile = new System.Windows.Forms.OpenFileDialog();
            this.tkbVol = new System.Windows.Forms.TrackBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsSongListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveSongFromList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlayMode = new System.Windows.Forms.Button();
            this.pbAlbumImage = new System.Windows.Forms.PictureBox();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.controlBarPanel = new System.Windows.Forms.Panel();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.lbcurrTime = new System.Windows.Forms.Label();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbVolume = new System.Windows.Forms.PictureBox();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.pbPlay = new System.Windows.Forms.PictureBox();
            this.AxWmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.lbMenu = new System.Windows.Forms.ListBox();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.pbMinForm = new System.Windows.Forms.PictureBox();
            this.pbMaxForm = new System.Windows.Forms.PictureBox();
            this.pbCloseForm = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.smallAlbumPanel = new System.Windows.Forms.Panel();
            this.lbSmallAlbumSingerName = new System.Windows.Forms.Label();
            this.lbSmallAlbumSongName = new System.Windows.Forms.Label();
            this.pbSmallAlbum = new System.Windows.Forms.PictureBox();
            this.lbMusicName = new System.Windows.Forms.Label();
            this.mainWindowPanel = new System.Windows.Forms.Panel();
            this.WindowPanel = new System.Windows.Forms.Panel();
            this.lvSongList = new System.Windows.Forms.ListView();
            this.colNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSinger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlbum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbNoResults = new System.Windows.Forms.Label();
            this.windowTitlePanel = new System.Windows.Forms.Panel();
            this.pbAddSong = new System.Windows.Forms.PictureBox();
            this.txtSreachSongName = new System.Windows.Forms.TextBox();
            this.lbSongCount = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tkbMove)).BeginInit();
            this.ntiContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbVol)).BeginInit();
            this.cmsSongListMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumImage)).BeginInit();
            this.controlBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxWmp)).BeginInit();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaxForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseForm)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.smallAlbumPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSmallAlbum)).BeginInit();
            this.mainWindowPanel.SuspendLayout();
            this.WindowPanel.SuspendLayout();
            this.windowTitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddSong)).BeginInit();
            this.SuspendLayout();
            // 
            // tkbMove
            // 
            this.tkbMove.AutoSize = false;
            this.tkbMove.Location = new System.Drawing.Point(264, 17);
            this.tkbMove.Margin = new System.Windows.Forms.Padding(4);
            this.tkbMove.Maximum = 100;
            this.tkbMove.Name = "tkbMove";
            this.tkbMove.Size = new System.Drawing.Size(540, 30);
            this.tkbMove.TabIndex = 1;
            this.tkbMove.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbMove.Scroll += new System.EventHandler(this.tkbMove_Scroll);
            // 
            // ntiContextMenu
            // 
            this.ntiContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ntiContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenForm,
            this.tsmiQuit});
            this.ntiContextMenu.Name = "contextMenu";
            this.ntiContextMenu.Size = new System.Drawing.Size(176, 52);
            // 
            // tsmiOpenForm
            // 
            this.tsmiOpenForm.Name = "tsmiOpenForm";
            this.tsmiOpenForm.Size = new System.Drawing.Size(175, 24);
            this.tsmiOpenForm.Text = "显示主界面(&O)";
            this.tsmiOpenForm.Click += new System.EventHandler(this.tsmiOpenForm_Click);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(175, 24);
            this.tsmiQuit.Text = "退出(&Q)";
            this.tsmiQuit.Click += new System.EventHandler(this.tsmiQuit_Click);
            // 
            // timerPlay
            // 
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // odlgFile
            // 
            this.odlgFile.FileName = "openFileDialog1";
            // 
            // tkbVol
            // 
            this.tkbVol.AutoSize = false;
            this.tkbVol.Location = new System.Drawing.Point(911, 17);
            this.tkbVol.Margin = new System.Windows.Forms.Padding(4);
            this.tkbVol.Maximum = 100;
            this.tkbVol.Name = "tkbVol";
            this.tkbVol.Size = new System.Drawing.Size(132, 30);
            this.tkbVol.TabIndex = 8;
            this.tkbVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkbVol.Value = 10;
            this.tkbVol.ValueChanged += new System.EventHandler(this.tkbVol_ValueChanged);
            this.tkbVol.MouseLeave += new System.EventHandler(this.tkbVol_MouseLeave);
            this.tkbVol.MouseHover += new System.EventHandler(this.tkbVol_MouseHover);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.ntiContextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // cmsSongListMenu
            // 
            this.cmsSongListMenu.BackColor = System.Drawing.Color.White;
            this.cmsSongListMenu.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmsSongListMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsSongListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFavorite,
            this.tsmiRemoveSongFromList,
            this.tsmiOpenFilePath});
            this.cmsSongListMenu.Name = "cmsSongListMenu";
            this.cmsSongListMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsSongListMenu.Size = new System.Drawing.Size(212, 88);
            // 
            // tsmiFavorite
            // 
            this.tsmiFavorite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(50)))));
            this.tsmiFavorite.ForeColor = System.Drawing.Color.White;
            this.tsmiFavorite.Image = global::SimpleMediaPlayer.Properties.Resources.喜欢;
            this.tsmiFavorite.Name = "tsmiFavorite";
            this.tsmiFavorite.Size = new System.Drawing.Size(211, 28);
            this.tsmiFavorite.Text = "收藏到歌单(&I)";
            this.tsmiFavorite.Click += new System.EventHandler(this.tsmiFavorite_Click);
            // 
            // tsmiRemoveSongFromList
            // 
            this.tsmiRemoveSongFromList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(50)))));
            this.tsmiRemoveSongFromList.ForeColor = System.Drawing.Color.White;
            this.tsmiRemoveSongFromList.Image = ((System.Drawing.Image)(resources.GetObject("tsmiRemoveSongFromList.Image")));
            this.tsmiRemoveSongFromList.Name = "tsmiRemoveSongFromList";
            this.tsmiRemoveSongFromList.Size = new System.Drawing.Size(211, 28);
            this.tsmiRemoveSongFromList.Text = "从列表中删除(&D)";
            this.tsmiRemoveSongFromList.Click += new System.EventHandler(this.tsmiRemoveSongFromList_Click);
            // 
            // tsmiOpenFilePath
            // 
            this.tsmiOpenFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(50)))));
            this.tsmiOpenFilePath.ForeColor = System.Drawing.Color.White;
            this.tsmiOpenFilePath.Image = ((System.Drawing.Image)(resources.GetObject("tsmiOpenFilePath.Image")));
            this.tsmiOpenFilePath.Name = "tsmiOpenFilePath";
            this.tsmiOpenFilePath.Size = new System.Drawing.Size(211, 28);
            this.tsmiOpenFilePath.Text = "打开文件位置(&F)";
            this.tsmiOpenFilePath.Click += new System.EventHandler(this.tsmiOpenFilePath_Click);
            // 
            // btnPlayMode
            // 
            this.btnPlayMode.BackgroundImage = global::SimpleMediaPlayer.Properties.Resources.随机播放;
            this.btnPlayMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlayMode.FlatAppearance.BorderSize = 0;
            this.btnPlayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayMode.Location = new System.Drawing.Point(1062, 13);
            this.btnPlayMode.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlayMode.Name = "btnPlayMode";
            this.btnPlayMode.Size = new System.Drawing.Size(36, 36);
            this.btnPlayMode.TabIndex = 10;
            this.btnPlayMode.UseVisualStyleBackColor = true;
            this.btnPlayMode.Click += new System.EventHandler(this.btnPlayMode_Click);
            // 
            // pbAlbumImage
            // 
            this.pbAlbumImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            this.pbAlbumImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAlbumImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbAlbumImage.Location = new System.Drawing.Point(0, 0);
            this.pbAlbumImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbAlbumImage.Name = "pbAlbumImage";
            this.pbAlbumImage.Size = new System.Drawing.Size(877, 528);
            this.pbAlbumImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAlbumImage.TabIndex = 11;
            this.pbAlbumImage.TabStop = false;
            // 
            // controlBarPanel
            // 
            this.controlBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            this.controlBarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlBarPanel.Controls.Add(this.lbEndTime);
            this.controlBarPanel.Controls.Add(this.lbcurrTime);
            this.controlBarPanel.Controls.Add(this.pbNext);
            this.controlBarPanel.Controls.Add(this.pbVolume);
            this.controlBarPanel.Controls.Add(this.pbBack);
            this.controlBarPanel.Controls.Add(this.pbPlay);
            this.controlBarPanel.Controls.Add(this.btnPlayMode);
            this.controlBarPanel.Controls.Add(this.tkbVol);
            this.controlBarPanel.Controls.Add(this.tkbMove);
            this.controlBarPanel.Location = new System.Drawing.Point(-3, 626);
            this.controlBarPanel.Name = "controlBarPanel";
            this.controlBarPanel.Size = new System.Drawing.Size(1130, 67);
            this.controlBarPanel.TabIndex = 15;
            // 
            // lbEndTime
            // 
            this.lbEndTime.BackColor = System.Drawing.Color.Transparent;
            this.lbEndTime.ForeColor = System.Drawing.Color.White;
            this.lbEndTime.Location = new System.Drawing.Point(813, 22);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(47, 15);
            this.lbEndTime.TabIndex = 16;
            this.lbEndTime.Text = "00:00";
            // 
            // lbcurrTime
            // 
            this.lbcurrTime.BackColor = System.Drawing.Color.Transparent;
            this.lbcurrTime.ForeColor = System.Drawing.Color.White;
            this.lbcurrTime.Location = new System.Drawing.Point(210, 22);
            this.lbcurrTime.Name = "lbcurrTime";
            this.lbcurrTime.Size = new System.Drawing.Size(47, 15);
            this.lbcurrTime.TabIndex = 15;
            this.lbcurrTime.Text = "00:00";
            // 
            // pbNext
            // 
            this.pbNext.BackgroundImage = global::SimpleMediaPlayer.Properties.Resources.下一首;
            this.pbNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNext.Location = new System.Drawing.Point(134, 7);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(48, 48);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 14;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.btnNext_Click);
            this.pbNext.MouseEnter += new System.EventHandler(this.MoveEnter_ChangeIconToHooverStyle);
            this.pbNext.MouseLeave += new System.EventHandler(this.MoveLeave_ChangeIconToNormalStyle);
            // 
            // pbVolume
            // 
            this.pbVolume.Image = ((System.Drawing.Image)(resources.GetObject("pbVolume.Image")));
            this.pbVolume.Location = new System.Drawing.Point(884, 17);
            this.pbVolume.Name = "pbVolume";
            this.pbVolume.Size = new System.Drawing.Size(24, 24);
            this.pbVolume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVolume.TabIndex = 11;
            this.pbVolume.TabStop = false;
            // 
            // pbBack
            // 
            this.pbBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbBack.BackgroundImage")));
            this.pbBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Location = new System.Drawing.Point(25, 7);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(48, 48);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 13;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.btnBack_Click);
            this.pbBack.MouseEnter += new System.EventHandler(this.MoveEnter_ChangeIconToHooverStyle);
            this.pbBack.MouseLeave += new System.EventHandler(this.MoveLeave_ChangeIconToNormalStyle);
            // 
            // pbPlay
            // 
            this.pbPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPlay.BackgroundImage")));
            this.pbPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlay.Location = new System.Drawing.Point(80, 7);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.Size = new System.Drawing.Size(48, 48);
            this.pbPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlay.TabIndex = 12;
            this.pbPlay.TabStop = false;
            this.pbPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.pbPlay.MouseEnter += new System.EventHandler(this.MoveEnter_ChangeIconToHooverStyle);
            this.pbPlay.MouseLeave += new System.EventHandler(this.MoveLeave_ChangeIconToNormalStyle);
            // 
            // AxWmp
            // 
            this.AxWmp.Enabled = true;
            this.AxWmp.Location = new System.Drawing.Point(873, 141);
            this.AxWmp.Name = "AxWmp";
            this.AxWmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxWmp.OcxState")));
            this.AxWmp.Size = new System.Drawing.Size(115, 86);
            this.AxWmp.TabIndex = 16;
            this.AxWmp.Visible = false;
            this.AxWmp.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.AxWmp_PlayStateChange);
            // 
            // lbMenu
            // 
            this.lbMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            this.lbMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbMenu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lbMenu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbMenu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbMenu.ForeColor = System.Drawing.Color.White;
            this.lbMenu.FormattingEnabled = true;
            this.lbMenu.ItemHeight = 15;
            this.lbMenu.Location = new System.Drawing.Point(3, 49);
            this.lbMenu.Margin = new System.Windows.Forms.Padding(0);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(245, 460);
            this.lbMenu.TabIndex = 17;
            this.lbMenu.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbMenu_DrawItem);
            this.lbMenu.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbMenu_MeasureItem);
            this.lbMenu.SelectedIndexChanged += new System.EventHandler(this.lbMenu_SelectedIndexChanged);
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            this.titlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titlePanel.Controls.Add(this.pbMinForm);
            this.titlePanel.Controls.Add(this.pbMaxForm);
            this.titlePanel.Controls.Add(this.pbCloseForm);
            this.titlePanel.Controls.Add(this.lbTitle);
            this.titlePanel.Location = new System.Drawing.Point(-1, -1);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(1136, 41);
            this.titlePanel.TabIndex = 19;
            // 
            // pbMinForm
            // 
            this.pbMinForm.Image = global::SimpleMediaPlayer.Properties.Resources.最小化;
            this.pbMinForm.Location = new System.Drawing.Point(1018, 1);
            this.pbMinForm.Name = "pbMinForm";
            this.pbMinForm.Padding = new System.Windows.Forms.Padding(6);
            this.pbMinForm.Size = new System.Drawing.Size(36, 36);
            this.pbMinForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMinForm.TabIndex = 13;
            this.pbMinForm.TabStop = false;
            this.pbMinForm.Click += new System.EventHandler(this.FormControlButton_Click);
            this.pbMinForm.MouseEnter += new System.EventHandler(this.MoveEnter_ChangeIconToHooverStyle);
            this.pbMinForm.MouseLeave += new System.EventHandler(this.MoveLeave_ChangeIconToNormalStyle);
            // 
            // pbMaxForm
            // 
            this.pbMaxForm.Image = global::SimpleMediaPlayer.Properties.Resources.最大化;
            this.pbMaxForm.Location = new System.Drawing.Point(1050, 1);
            this.pbMaxForm.Name = "pbMaxForm";
            this.pbMaxForm.Padding = new System.Windows.Forms.Padding(6);
            this.pbMaxForm.Size = new System.Drawing.Size(36, 36);
            this.pbMaxForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMaxForm.TabIndex = 13;
            this.pbMaxForm.TabStop = false;
            this.pbMaxForm.Click += new System.EventHandler(this.FormControlButton_Click);
            this.pbMaxForm.MouseEnter += new System.EventHandler(this.MoveEnter_ChangeIconToHooverStyle);
            this.pbMaxForm.MouseLeave += new System.EventHandler(this.MoveLeave_ChangeIconToNormalStyle);
            // 
            // pbCloseForm
            // 
            this.pbCloseForm.Image = global::SimpleMediaPlayer.Properties.Resources.关闭;
            this.pbCloseForm.Location = new System.Drawing.Point(1086, 1);
            this.pbCloseForm.Name = "pbCloseForm";
            this.pbCloseForm.Padding = new System.Windows.Forms.Padding(8);
            this.pbCloseForm.Size = new System.Drawing.Size(36, 36);
            this.pbCloseForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCloseForm.TabIndex = 13;
            this.pbCloseForm.TabStop = false;
            this.pbCloseForm.Click += new System.EventHandler(this.FormControlButton_Click);
            this.pbCloseForm.MouseEnter += new System.EventHandler(this.MoveEnter_ChangeIconToHooverStyle);
            this.pbCloseForm.MouseLeave += new System.EventHandler(this.MoveLeave_ChangeIconToNormalStyle);
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.Gray;
            this.lbTitle.Location = new System.Drawing.Point(-1, -1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1123, 36);
            this.lbTitle.TabIndex = 14;
            this.lbTitle.Text = "SimpleMediaPlayer";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbTitle_MouseDown);
            this.lbTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbTitle_MouseMove);
            this.lbTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbTitle_MouseUp);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Controls.Add(this.smallAlbumPanel);
            this.menuPanel.Controls.Add(this.lbMenu);
            this.menuPanel.Location = new System.Drawing.Point(-6, 32);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(250, 595);
            this.menuPanel.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "列表";
            // 
            // smallAlbumPanel
            // 
            this.smallAlbumPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.smallAlbumPanel.Controls.Add(this.lbSmallAlbumSingerName);
            this.smallAlbumPanel.Controls.Add(this.lbSmallAlbumSongName);
            this.smallAlbumPanel.Controls.Add(this.pbSmallAlbum);
            this.smallAlbumPanel.Location = new System.Drawing.Point(5, 520);
            this.smallAlbumPanel.Name = "smallAlbumPanel";
            this.smallAlbumPanel.Size = new System.Drawing.Size(248, 74);
            this.smallAlbumPanel.TabIndex = 19;
            // 
            // lbSmallAlbumSingerName
            // 
            this.lbSmallAlbumSingerName.AutoSize = true;
            this.lbSmallAlbumSingerName.BackColor = System.Drawing.Color.Transparent;
            this.lbSmallAlbumSingerName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSmallAlbumSingerName.ForeColor = System.Drawing.Color.Gray;
            this.lbSmallAlbumSingerName.Location = new System.Drawing.Point(71, 40);
            this.lbSmallAlbumSingerName.Name = "lbSmallAlbumSingerName";
            this.lbSmallAlbumSingerName.Size = new System.Drawing.Size(50, 20);
            this.lbSmallAlbumSingerName.TabIndex = 20;
            this.lbSmallAlbumSingerName.Text = "Rhine";
            // 
            // lbSmallAlbumSongName
            // 
            this.lbSmallAlbumSongName.AutoSize = true;
            this.lbSmallAlbumSongName.BackColor = System.Drawing.Color.Transparent;
            this.lbSmallAlbumSongName.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSmallAlbumSongName.ForeColor = System.Drawing.Color.White;
            this.lbSmallAlbumSongName.Location = new System.Drawing.Point(71, 11);
            this.lbSmallAlbumSongName.Name = "lbSmallAlbumSongName";
            this.lbSmallAlbumSongName.Size = new System.Drawing.Size(108, 23);
            this.lbSmallAlbumSongName.TabIndex = 19;
            this.lbSmallAlbumSongName.Text = "Enjoy Music";
            // 
            // pbSmallAlbum
            // 
            this.pbSmallAlbum.BackgroundImage = global::SimpleMediaPlayer.Properties.Resources.defaultSmallAblum;
            this.pbSmallAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSmallAlbum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSmallAlbum.Location = new System.Drawing.Point(3, 4);
            this.pbSmallAlbum.Name = "pbSmallAlbum";
            this.pbSmallAlbum.Size = new System.Drawing.Size(64, 64);
            this.pbSmallAlbum.TabIndex = 18;
            this.pbSmallAlbum.TabStop = false;
            this.pbSmallAlbum.Click += new System.EventHandler(this.pbSmallAlbum_Click);
            this.pbSmallAlbum.MouseEnter += new System.EventHandler(this.MoveEnter_ChangeIconToHooverStyle);
            this.pbSmallAlbum.MouseLeave += new System.EventHandler(this.MoveLeave_ChangeIconToNormalStyle);
            // 
            // lbMusicName
            // 
            this.lbMusicName.BackColor = System.Drawing.Color.Transparent;
            this.lbMusicName.Font = new System.Drawing.Font("Franklin Gothic Heavy", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMusicName.ForeColor = System.Drawing.Color.White;
            this.lbMusicName.Location = new System.Drawing.Point(63, 6);
            this.lbMusicName.Name = "lbMusicName";
            this.lbMusicName.Size = new System.Drawing.Size(552, 32);
            this.lbMusicName.TabIndex = 17;
            this.lbMusicName.Text = "MUSIXMATCH";
            // 
            // mainWindowPanel
            // 
            this.mainWindowPanel.Controls.Add(this.WindowPanel);
            this.mainWindowPanel.Controls.Add(this.windowTitlePanel);
            this.mainWindowPanel.Location = new System.Drawing.Point(249, 46);
            this.mainWindowPanel.Name = "mainWindowPanel";
            this.mainWindowPanel.Size = new System.Drawing.Size(877, 574);
            this.mainWindowPanel.TabIndex = 21;
            // 
            // WindowPanel
            // 
            this.WindowPanel.Controls.Add(this.lvSongList);
            this.WindowPanel.Controls.Add(this.pbAlbumImage);
            this.WindowPanel.Controls.Add(this.lbNoResults);
            this.WindowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowPanel.Location = new System.Drawing.Point(0, 46);
            this.WindowPanel.Name = "WindowPanel";
            this.WindowPanel.Size = new System.Drawing.Size(877, 528);
            this.WindowPanel.TabIndex = 19;
            // 
            // lvSongList
            // 
            this.lvSongList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.lvSongList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSongList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNum,
            this.colName,
            this.colSinger,
            this.colAlbum,
            this.colDuration,
            this.colSize});
            this.lvSongList.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvSongList.ForeColor = System.Drawing.Color.White;
            this.lvSongList.FullRowSelect = true;
            this.lvSongList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSongList.Location = new System.Drawing.Point(0, 0);
            this.lvSongList.MultiSelect = false;
            this.lvSongList.Name = "lvSongList";
            this.lvSongList.OwnerDraw = true;
            this.lvSongList.Scrollable = false;
            this.lvSongList.Size = new System.Drawing.Size(877, 530);
            this.lvSongList.TabIndex = 12;
            this.lvSongList.UseCompatibleStateImageBehavior = false;
            this.lvSongList.View = System.Windows.Forms.View.Details;
            this.lvSongList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvSongList_DrawColumnHeader);
            this.lvSongList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvSongList_DrawSubItem);
            this.lvSongList.DoubleClick += new System.EventHandler(this.lvSongList_DoubleClick);
            this.lvSongList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvSongList_MouseDown);
            // 
            // colNum
            // 
            this.colNum.Text = " ";
            // 
            // colName
            // 
            this.colName.Text = "音乐标题";
            this.colName.Width = 300;
            // 
            // colSinger
            // 
            this.colSinger.Text = "歌手";
            this.colSinger.Width = 200;
            // 
            // colAlbum
            // 
            this.colAlbum.Text = "专辑";
            this.colAlbum.Width = 150;
            // 
            // colDuration
            // 
            this.colDuration.Text = "时长";
            this.colDuration.Width = 92;
            // 
            // colSize
            // 
            this.colSize.Text = "大小";
            this.colSize.Width = 90;
            // 
            // lbNoResults
            // 
            this.lbNoResults.BackColor = System.Drawing.Color.Transparent;
            this.lbNoResults.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNoResults.ForeColor = System.Drawing.Color.White;
            this.lbNoResults.Location = new System.Drawing.Point(382, 233);
            this.lbNoResults.Name = "lbNoResults";
            this.lbNoResults.Size = new System.Drawing.Size(115, 32);
            this.lbNoResults.TabIndex = 19;
            this.lbNoResults.Text = "没有相关搜索结果";
            this.lbNoResults.Visible = false;
            // 
            // windowTitlePanel
            // 
            this.windowTitlePanel.Controls.Add(this.pbAddSong);
            this.windowTitlePanel.Controls.Add(this.txtSreachSongName);
            this.windowTitlePanel.Controls.Add(this.lbSongCount);
            this.windowTitlePanel.Controls.Add(this.lbCategory);
            this.windowTitlePanel.Controls.Add(this.lbMusicName);
            this.windowTitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.windowTitlePanel.Name = "windowTitlePanel";
            this.windowTitlePanel.Size = new System.Drawing.Size(877, 46);
            this.windowTitlePanel.TabIndex = 18;
            // 
            // pbAddSong
            // 
            this.pbAddSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddSong.Image = ((System.Drawing.Image)(resources.GetObject("pbAddSong.Image")));
            this.pbAddSong.Location = new System.Drawing.Point(265, 11);
            this.pbAddSong.Name = "pbAddSong";
            this.pbAddSong.Size = new System.Drawing.Size(96, 24);
            this.pbAddSong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddSong.TabIndex = 19;
            this.pbAddSong.TabStop = false;
            this.pbAddSong.Click += new System.EventHandler(this.tsmiOpenFile_Click);
            this.pbAddSong.MouseEnter += new System.EventHandler(this.MoveEnter_ChangeIconToHooverStyle);
            this.pbAddSong.MouseLeave += new System.EventHandler(this.MoveLeave_ChangeIconToNormalStyle);
            // 
            // txtSreachSongName
            // 
            this.txtSreachSongName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(24)))));
            this.txtSreachSongName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSreachSongName.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSreachSongName.ForeColor = System.Drawing.Color.Gray;
            this.txtSreachSongName.Location = new System.Drawing.Point(652, 9);
            this.txtSreachSongName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSreachSongName.Name = "txtSreachSongName";
            this.txtSreachSongName.Size = new System.Drawing.Size(209, 30);
            this.txtSreachSongName.TabIndex = 15;
            this.txtSreachSongName.Text = "输入要搜索的歌曲名";
            this.txtSreachSongName.TextChanged += new System.EventHandler(this.txtSreachSongName_TextChanged);
            this.txtSreachSongName.Enter += new System.EventHandler(this.txtSreachSongName_Enter);
            this.txtSreachSongName.Leave += new System.EventHandler(this.txtSreachSongName_Leave);
            // 
            // lbSongCount
            // 
            this.lbSongCount.AutoSize = true;
            this.lbSongCount.BackColor = System.Drawing.Color.Transparent;
            this.lbSongCount.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSongCount.ForeColor = System.Drawing.Color.Gray;
            this.lbSongCount.Location = new System.Drawing.Point(178, 17);
            this.lbSongCount.Name = "lbSongCount";
            this.lbSongCount.Size = new System.Drawing.Size(81, 23);
            this.lbSongCount.TabIndex = 18;
            this.lbSongCount.Text = "10首音乐";
            this.lbSongCount.Visible = false;
            // 
            // lbCategory
            // 
            this.lbCategory.BackColor = System.Drawing.Color.Transparent;
            this.lbCategory.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategory.ForeColor = System.Drawing.Color.White;
            this.lbCategory.Location = new System.Drawing.Point(63, 6);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(115, 32);
            this.lbCategory.TabIndex = 18;
            this.lbCategory.Text = "本地音乐";
            this.lbCategory.Visible = false;
            // 
            // mainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1123, 690);
            this.Controls.Add(this.controlBarPanel);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.mainWindowPanel);
            this.Controls.Add(this.AxWmp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainForm";
            this.Text = "Windows Media Player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tkbMove)).EndInit();
            this.ntiContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tkbVol)).EndInit();
            this.cmsSongListMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumImage)).EndInit();
            this.controlBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxWmp)).EndInit();
            this.titlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMinForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaxForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseForm)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.smallAlbumPanel.ResumeLayout(false);
            this.smallAlbumPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSmallAlbum)).EndInit();
            this.mainWindowPanel.ResumeLayout(false);
            this.WindowPanel.ResumeLayout(false);
            this.windowTitlePanel.ResumeLayout(false);
            this.windowTitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddSong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.TrackBar tkbMove;
        private System.Windows.Forms.ContextMenuStrip ntiContextMenu;
        private System.Windows.Forms.Timer timerPlay;
        private System.Windows.Forms.OpenFileDialog odlgFile;
        private System.Windows.Forms.TrackBar tkbVol;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenForm;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ContextMenuStrip cmsSongListMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFavorite;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFilePath;
        private System.Windows.Forms.Button btnPlayMode;
        private System.Windows.Forms.PictureBox pbAlbumImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveSongFromList;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Panel controlBarPanel;
        private System.Windows.Forms.PictureBox pbVolume;
        private AxWMPLib.AxWindowsMediaPlayer AxWmp;
        private System.Windows.Forms.PictureBox pbPlay;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.PictureBox pbNext;
        public System.Windows.Forms.ListBox lbMenu;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.Label lbcurrTime;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label lbMusicName;
        private System.Windows.Forms.PictureBox pbCloseForm;
        private System.Windows.Forms.PictureBox pbMaxForm;
        private System.Windows.Forms.PictureBox pbMinForm;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel mainWindowPanel;
        private System.Windows.Forms.Panel WindowPanel;
        private System.Windows.Forms.Panel windowTitlePanel;
        private System.Windows.Forms.ListView lvSongList;
        private System.Windows.Forms.ColumnHeader colNum;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSinger;
        private System.Windows.Forms.ColumnHeader colAlbum;
        private System.Windows.Forms.ColumnHeader colDuration;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.Label lbSongCount;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.Panel smallAlbumPanel;
        private System.Windows.Forms.Label lbSmallAlbumSingerName;
        private System.Windows.Forms.Label lbSmallAlbumSongName;
        private System.Windows.Forms.PictureBox pbSmallAlbum;
        private System.Windows.Forms.TextBox txtSreachSongName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbAddSong;
        private System.Windows.Forms.Label lbNoResults;
    }
}

