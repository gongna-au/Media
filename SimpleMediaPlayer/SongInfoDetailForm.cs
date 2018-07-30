using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMediaPlayer
{
    public partial class SongInfoDetailForm : Form
    {
        private SongsInfo currentSongInfo;
        public SongInfoDetailForm(SongsInfo sInfo)
        {
            InitializeComponent();
            currentSongInfo = sInfo;
        }

        private void SongInfoDetailForm_Load(object sender, EventArgs e)
        {
            txtSongName.Text = currentSongInfo.FileName;
            txtArtist.Text = currentSongInfo.Artist;
            txtAlbum.Text = currentSongInfo.Album;
            txtYear.Text = currentSongInfo.Year;
            txtDuration.Text = currentSongInfo.Duration;
            txtByteRate.Text = currentSongInfo.ByteRate;
            txtFilePath.Text = currentSongInfo.FilePath;
        }
    }
}
