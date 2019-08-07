using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace KeyboardTester
{
    public partial class Form1 : Form
    {
        #region CONST Defs.

        private const uint MAPVK_VK_TO_VSC = 0;

        private const int RIDEV_INPUTSINK = 0x00000100;
        private const int RID_INPUT = 0x10000003;

        private const int FAPPCOMMAND_MASK = 0xF000;
        private const int FAPPCOMMAND_MOUSE = 0x8000;
        private const int FAPPCOMMAND_OEM = 0x1000;

        private const int RIM_TYPEMOUSE = 0;
        private const int RIM_TYPEKEYBOARD = 1;
        private const int RIM_TYPEHID = 2;

        private const int RIDI_DEVICENAME = 0x20000007;

        private const int WM_INPUT = 0x00FF;
        private const int WH_KEYBOARD_LL = 13;
        private const int WH_KEYBOARD = 2;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;

        private const int VK_OEM_CLEAR = 0xFE;
        private const int VK_LAST_KEY = VK_OEM_CLEAR;
        private const byte VK_SHIFT = 0x10;
        private const byte VK_CAPITAL = 0x14;
        private const byte VK_NUMLOCK = 0x90;
        private const byte VK_CONTROL = 0x11;
        private const byte VK_ALT = 0x12;

        private const int STD_OUTPUT_HANDLE = -11;

        private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
        private const uint DISABLE_NEWLINE_AUTO_RETURN = 0x0008;

        #endregion

        #region Dll Imports

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "MapVirtualKey", SetLastError = true, ThrowOnUnmappableChar = false)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        #endregion


        /// <summary>
        /// 
        /// </summary>
        private LowLevelKeyboardProc _proc = null;

        /// <summary>
        /// 
        /// </summary>
        private static IntPtr _hookID = IntPtr.Zero;

        /// <summary>
        /// Layout
        /// </summary>
        //Keyboards._60Layout1 layout = new Keyboards._60Layout1();
        Keyboards._100Layout1 layout = new Keyboards._100Layout1();

        /// <summary>
        /// Holds our key timer
        /// </summary>
        System.Diagnostics.Stopwatch _keytimer = null;

        public Form1()
        {
            _proc = HookCallback;
            _hookID = SetHook(_proc);
            
            InitializeComponent();
            KeyboardLoader();
        }

        ~Form1()
        {
            UnhookWindowsHookEx(_hookID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // Key Down Event
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {

                _keytimer = System.Diagnostics.Stopwatch.StartNew();

                int vkCode = Marshal.ReadInt32(lParam);
                Keys k = (Keys)vkCode;

                uint uCode = (uint)vkCode;
                uint scanCode = MapVirtualKey(uCode, MAPVK_VK_TO_VSC);

                _keytimer = System.Diagnostics.Stopwatch.StartNew();

                for (int x = 0; x < layout.KeyLayout.Count; x++)
                {
                    if ((Keys)vkCode == layout.KeyLayout[x].CurrentKey)
                    {
                        layout.KeyLayout[x].Activate();
                    }
                }

                txtLastKey.Text = k.ToString();
                txtCode.Text = "0x" + vkCode.ToString("X2");
                txtScanCode.Text = "0x" + scanCode.ToString("X2");

                if (Main.DEBUG) Console.WriteLine("KEY-DOWN - vkCode: 0x{0}\tScan Code: 0x{2}\tKey: {1}", vkCode.ToString("X2"), (Keys)vkCode, scanCode.ToString("X2"));

                lbKeyOutput.Items.Add(string.Format("KEY-DOWN\tvkCode: 0x{0}\tScan Code: 0x{2}\tKey: {1}", vkCode.ToString("X2"), (Keys)vkCode, scanCode.ToString("X2")));
                autoScrollListBox();
            }

            // Key Up Event
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                _keytimer.Stop();
                txtPressedTime.Text = _keytimer.ElapsedMilliseconds.ToString() + " ms";

                int vkCode = Marshal.ReadInt32(lParam);

                uint uCode = (uint)vkCode;
                uint scanCode = MapVirtualKey(uCode, MAPVK_VK_TO_VSC);

                for (int x = 0; x < layout.KeyLayout.Count; x++)
                {
                    if ((Keys)vkCode == layout.KeyLayout[x].CurrentKey)
                    {
                        layout.KeyLayout[x].DeActivate();
                    }
                }

                if (Main.DEBUG) Console.WriteLine("KEY-UP   - vkCode: 0x{0}\tScan Code: 0x{3}\tKey: {1} in {2}ms", vkCode.ToString("X2"), (Keys)vkCode, 0, scanCode.ToString("X2"));

                lbKeyOutput.Items.Add(string.Format("KEY-UP:\t\tvkCode: 0x{0}\tScan Code: 0x{3}\tKey: {1} in {2}ms", vkCode.ToString("X2"), (Keys)vkCode, _keytimer.ElapsedMilliseconds, scanCode.ToString("X2")));
                autoScrollListBox();
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        /// <summary>
        /// Loads in a specific keyboard layout.
        /// </summary>
        private void KeyboardLoader()
        {
            foreach (Keyboards.SKey k in layout.KeyLayout)
            {
                if (Main.DEBUG) Console.WriteLine("Loading key: {0} @ POS {1} - SIZE: {2}", k.CurrentKey, k.KeyLocation.ToString(), k.KeySize);

                // make the box for the key
                k.PBKey = new PictureBox();
                k.PBKey.Parent = pictureBox1;
                k.PBKey.BackColor = Color.Transparent;
                k.PBKey.Location = k.KeyLocation;
                double KeyWidth = layout._1uKey.Width * k.KeySize;
                k.PBKey.Size = new Size((int)KeyWidth, layout._1uKey.Height);
            }
        }

        /// <summary>
        /// If we should be monitoring all keys that have been pressed or not.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMonitorKeys_CheckedChanged(object sender, EventArgs e)
        {
            Main.MONITOR = cbMonitorKeys.Checked;

            if (!cbMonitorKeys.Checked)
            {
                if (MessageBox.Show("Would you like to clearn currently marked keys?", "Clear Keys?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Keyboards.SKey k in layout.KeyLayout)
                        k.DeActivate();
                }
            }
        }

        /// <summary>
        /// The route out!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void autoScrollListBox()
        {
            lbKeyOutput.SelectedIndex = lbKeyOutput.Items.Count - 1;
            lbKeyOutput.SelectedIndex = -1;
        }
    }
}
