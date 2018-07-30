using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SimpleMediaPlayer
{
    public class MyColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(59,58,61); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(59, 58, 61); }
        }

        public override Color MenuBorder
        {
            get { return Color.FromArgb(59, 58, 61); }
        }
    }
}
