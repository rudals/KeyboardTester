using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardTester.Keyboards
{
    class _100Layout1
    {
        public Size _1uKey = new Size(54, 54);

        public List<SKey> KeyLayout = new List<SKey>()
        {
            // ROW
            new SKey() { CurrentKey = Keys.Escape, KeyLocation = new Point(10, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F1, KeyLocation = new Point(118, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F2, KeyLocation = new Point(172, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F3, KeyLocation = new Point(226, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F4, KeyLocation = new Point(280, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F5, KeyLocation = new Point(360, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F6, KeyLocation = new Point(414, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F7, KeyLocation = new Point(468, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F8, KeyLocation = new Point(522, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F9, KeyLocation = new Point(605, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F10, KeyLocation = new Point(659, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F11, KeyLocation = new Point(713, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.F12, KeyLocation = new Point(767, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.PrintScreen, KeyLocation = new Point(834, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.Scroll, KeyLocation = new Point(888, 10), KeySize = 1, },
            new SKey() { CurrentKey = Keys.Pause, KeyLocation = new Point(942, 10), KeySize = 1, },

            // ROW
            new SKey() { CurrentKey = Keys.Oemtilde, KeyLocation = new Point(10, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D1, KeyLocation = new Point(64, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D2, KeyLocation = new Point(118, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D3, KeyLocation = new Point(172, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D4, KeyLocation = new Point(226, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D5, KeyLocation = new Point(280, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D6, KeyLocation = new Point(334, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D7, KeyLocation = new Point(388, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D8, KeyLocation = new Point(442, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D9, KeyLocation = new Point(496, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.D0, KeyLocation = new Point(550, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.OemMinus, KeyLocation = new Point(604, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.Oemplus, KeyLocation = new Point(658, 90), KeySize = 1, },
            new SKey() { CurrentKey = Keys.Back, KeyLocation = new Point(712, 90), KeySize = 2, },
            
            // ROW
            new SKey() { CurrentKey = Keys.Tab, KeyLocation = new Point(10, 144), KeySize = 1.50, },
            new SKey() { CurrentKey = Keys.Q, KeyLocation = new Point(91, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.W, KeyLocation = new Point(145, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.E, KeyLocation = new Point(199, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.R, KeyLocation = new Point(253, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.T, KeyLocation = new Point(307, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.Y, KeyLocation = new Point(361, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.U, KeyLocation = new Point(415, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.I, KeyLocation = new Point(469, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.O, KeyLocation = new Point(523, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.P, KeyLocation = new Point(577, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.OemOpenBrackets, KeyLocation = new Point(631, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.OemCloseBrackets, KeyLocation = new Point(685, 144), KeySize = 1, },
            new SKey() { CurrentKey = Keys.OemPipe, KeyLocation = new Point(739, 144), KeySize = 1.50, },

            // ROW
            new SKey() { CurrentKey = Keys.CapsLock, KeyLocation = new Point(10, 198), KeySize = 1.75, },
            new SKey() { CurrentKey = Keys.A, KeyLocation = new Point(105, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.S, KeyLocation = new Point(159, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.D, KeyLocation = new Point(213, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.F, KeyLocation = new Point(267, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.G, KeyLocation = new Point(321, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.H, KeyLocation = new Point(375, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.J, KeyLocation = new Point(429, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.K, KeyLocation = new Point(483, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.L, KeyLocation = new Point(537, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.OemSemicolon, KeyLocation = new Point(591, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.OemQuotes, KeyLocation = new Point(645, 198), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.Enter, KeyLocation = new Point(699, 198), KeySize = 2.25, },

            // ROW
            new SKey() { CurrentKey = Keys.LShiftKey, KeyLocation = new Point(10, 252), KeySize = 2.25, },
            new SKey() { CurrentKey = Keys.Z, KeyLocation = new Point(130, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.X, KeyLocation = new Point(184, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.C, KeyLocation = new Point(238, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.V, KeyLocation = new Point(292, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.B, KeyLocation = new Point(346, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.N, KeyLocation = new Point(400, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.M, KeyLocation = new Point(454, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.Oemcomma, KeyLocation = new Point(508, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.OemPeriod, KeyLocation = new Point(562, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.OemQuestion, KeyLocation = new Point(616, 252), KeySize = 1.0, },
            new SKey() { CurrentKey = Keys.RShiftKey, KeyLocation = new Point(670, 252), KeySize = 2.75, },

            // ROW
            new SKey() { CurrentKey = Keys.LControlKey, KeyLocation = new Point(10, 306), KeySize = 1.25, },
            new SKey() { CurrentKey = Keys.LWin, KeyLocation = new Point(77, 306), KeySize = 1.25, },
            new SKey() { CurrentKey = Keys.LMenu, KeyLocation = new Point(144, 306), KeySize = 1.25, },
            new SKey() { CurrentKey = Keys.Space, KeyLocation = new Point(211, 306), KeySize = 6.25, },
            new SKey() { CurrentKey = Keys.RMenu, KeyLocation = new Point(550, 306), KeySize = 1.25, },

            // ARROW KEYS
            new SKey() { CurrentKey = Keys.Up, KeyLocation = new Point(888, 252), KeySize = 1.0 },
            new SKey() { CurrentKey = Keys.Left, KeyLocation = new Point(834, 306), KeySize = 1.0 },
            new SKey() { CurrentKey = Keys.Down, KeyLocation = new Point(888, 306), KeySize = 1.0 },
            new SKey() { CurrentKey = Keys.Right, KeyLocation = new Point(942, 306), KeySize = 1.0 },

            // OTHERS
            new SKey() { CurrentKey = Keys.Insert, KeyLocation = new Point(834, 90), KeySize = 1.0 },
            new SKey() { CurrentKey = Keys.Home, KeyLocation = new Point(888, 90), KeySize = 1.0 },
            new SKey() { CurrentKey = Keys.PageUp, KeyLocation = new Point(942, 90), KeySize = 1.0 },
            new SKey() { CurrentKey = Keys.Delete, KeyLocation = new Point(834, 144), KeySize = 1.0 },
            new SKey() { CurrentKey = Keys.End, KeyLocation = new Point(888, 144), KeySize = 1.0 },
            new SKey() { CurrentKey = Keys.PageDown, KeyLocation = new Point(942, 144), KeySize = 1.0 },

        };
    }
}
