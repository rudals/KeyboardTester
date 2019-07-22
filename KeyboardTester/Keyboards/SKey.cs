using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardTester.Keyboards
{
    public class SKey
    {
        /// <summary>
        /// The Key
        /// </summary>
        public Keys CurrentKey { get; set; }

        /// <summary>
        /// Key location on keyboard as x,y point
        /// 0, 0 being top left
        /// </summary>
        public Point KeyLocation { get; set; }

        /// <summary>
        /// The size of the key in 1u untis
        /// </summary>
        public double KeySize { get; set; }

        public PictureBox PBKey { get; set; }

        public void Activate()
        {
            //this.PBKey.Image = Properties.Resources.green;
            this.PBKey.BackgroundImage = Properties.Resources.green;
        }

        public void DeActivate()
        {
            if (!Main.MONITOR) this.PBKey.Image = null;
            if (!Main.MONITOR) this.PBKey.BackgroundImage = null;
        }
    }
}
