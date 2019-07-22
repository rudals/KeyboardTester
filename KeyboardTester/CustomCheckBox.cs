using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardTester
{
    public partial class CustomCheckBox : CheckBox
    {
        public CustomCheckBox()
        {

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                return;
            }

            base.OnKeyDown(e);
        }
    }
}
