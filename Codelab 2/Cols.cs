using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codelab_2
{
    public class Cols : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(248, 169, 51); }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(248, 169, 51); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(248, 169, 51); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(248, 169, 51); }
        }

        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.FromArgb(248, 169, 51); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(248, 169, 51); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(74, 101, 114); }
        }
       
    }
}
