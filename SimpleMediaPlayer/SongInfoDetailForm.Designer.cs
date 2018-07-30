namespace SimpleMediaPlayer
{
    partial class SongInfoDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSongName = new System.Windows.Forms.TextBox();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtByteRate = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "曲名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "歌手：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "专辑：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "发行日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "时长：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "比特率：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "文件位置：";
            // 
            // txtSongName
            // 
            this.txtSongName.Location = new System.Drawing.Point(12, 33);
            this.txtSongName.Name = "txtSongName";
            this.txtSongName.ReadOnly = true;
            this.txtSongName.Size = new System.Drawing.Size(201, 21);
            this.txtSongName.TabIndex = 1;
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(248, 33);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.ReadOnly = true;
            this.txtArtist.Size = new System.Drawing.Size(194, 21);
            this.txtArtist.TabIndex = 1;
            // 
            // txtAlbum
            // 
            this.txtAlbum.Location = new System.Drawing.Point(12, 91);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.ReadOnly = true;
            this.txtAlbum.Size = new System.Drawing.Size(201, 21);
            this.txtAlbum.TabIndex = 1;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(14, 152);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(199, 21);
            this.txtYear.TabIndex = 1;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(248, 91);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(194, 21);
            this.txtDuration.TabIndex = 1;
            // 
            // txtByteRate
            // 
            this.txtByteRate.Location = new System.Drawing.Point(248, 152);
            this.txtByteRate.Name = "txtByteRate";
            this.txtByteRate.ReadOnly = true;
            this.txtByteRate.Size = new System.Drawing.Size(194, 21);
            this.txtByteRate.TabIndex = 1;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(11, 210);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(431, 21);
            this.txtFilePath.TabIndex = 1;
            // 
            // SongInfoDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 260);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtByteRate);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtAlbum);
            this.Controls.Add(this.txtSongName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SongInfoDetailForm";
            this.Text = "属性";
            this.Load += new System.EventHandler(this.SongInfoDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSongName;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtByteRate;
        private System.Windows.Forms.TextBox txtFilePath;
    }
}