using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardTester.Keyboards
{
    class _60Layout1
    {
        public Size _1uKey = new Size(54, 54);

        public List<SKey> KeyLayout = new List<SKey>()
        {
            // ROW 1
            new SKey() { CurrentKey = Keys.Oemtilde, KeyLocation = new Point(10, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D1, KeyLocation = new Point(64, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D2, KeyLocation = new Point(118, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D3, KeyLocation = new Point(172, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D4, KeyLocation = new Point(226, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D5, KeyLocation = new Point(280, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D6, KeyLocation = new Point(334, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D7, KeyLocation = new Point(388, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D8, KeyLocation = new Point(442, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D9, KeyLocation = new Point(496, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D0, KeyLocation = new Point(550, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.OemMinus, KeyLocation = new Point(604, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.Oemplus, KeyLocation = new Point(658, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.Back, KeyLocation = new Point(712, 10), KeySize = 2, },

            // ROW 2
            new SKey() { CurrentKey = Keys.Tab, KeyLocation = new Point(10, 64), KeySize = 1.50, },
            new SKey() { CurrentKey = Keys.Q, KeyLocation = new Point(91, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.W, KeyLocation = new Point(145, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.E, KeyLocation = new Point(199, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.R, KeyLocation = new Point(253, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.T, KeyLocation = new Point(307, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.Y, KeyLocation = new Point(361, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.U, KeyLocation = new Point(415, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.I, KeyLocation = new Point(469, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.O, KeyLocation = new Point(523, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.P, KeyLocation = new Point(577, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.OemOpenBrackets, KeyLocation = new Point(631, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.OemCloseBrackets, KeyLocation = new Point(685, 64), KeySize = 1, },
            new SKey() { CurrentKey = Keys.OemPipe, KeyLocation = new Point(739, 64), KeySize = 1.50, },

            // ROW 3
            new SKey() { CurrentKey = Keys.CapsLock, KeyLocation = new Point(10, 119), KeySize = 1.75, },
            new SKey() { CurrentKey = Keys.A, KeyLocation = new Point(105, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.S, KeyLocation = new Point(159, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.D, KeyLocation = new Point(213, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.F, KeyLocation = new Point(267, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.G, KeyLocation = new Point(321, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.H, KeyLocation = new Point(375, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.J, KeyLocation = new Point(429, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.K, KeyLocation = new Point(483, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.L, KeyLocation = new Point(537, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.OemSemicolon, KeyLocation = new Point(591, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.OemQuotes, KeyLocation = new Point(645, 119), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.Enter, KeyLocation = new Point(699, 119), KeySize = 2.25, },

            // ROW 4
            //new SKey() { CurrentKey = Keys.Shift, KeyLocation = new Point(10, 173), KeySize = 2.0, },
            new SKey() { CurrentKey = Keys.Z, KeyLocation = new Point(130, 173), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.X, KeyLocation = new Point(184, 173), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.C, KeyLocation = new Point(238, 173), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.V, KeyLocation = new Point(292, 173), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.B, KeyLocation = new Point(346, 173), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.N, KeyLocation = new Point(400, 173), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.M, KeyLocation = new Point(454, 173), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.Oemcomma, KeyLocation = new Point(508, 173), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.OemPeriod, KeyLocation = new Point(562, 173), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.OemQuestion, KeyLocation = new Point(616, 173), KeySize = 1.0, },
            //new SKey() { CurrentKey = Keys.RShiftKey, KeyLocation = new Point(724, 173), KeySize = 2.25, },

        };
    }

}
