using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace KeyTest
{
    class Program
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

        #endregion const definitions

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

        // As odd as this is Windows command prompt does not
        // seem to deal with ANSII escape sequences... why? I have no idea.
        // Anyways after some digging around apparently Windows 10 ver ~ 1151 (correct me if I have this wrong)
        // they did start adding support for this, but it's not enabled by default, so we have to enable it
        // the following chunks of import / code do this.

        [DllImport("kernel32.dll")]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        #endregion DllImports


        /// <summary>
        /// 
        /// </summary>
        private static LowLevelKeyboardProc _proc = HookCallback;

        /// <summary>
        /// 
        /// </summary>
        private static IntPtr _hookID = IntPtr.Zero;

        /// <summary>
        /// 
        /// </summary>
        private static Stopwatch _keytimer = null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // setup
            var iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            if (!GetConsoleMode(iStdOut, out uint outConsoleMode))
            {
                Console.WriteLine("failed to get output console mode");
                Console.ReadKey();
                return;
            }

            outConsoleMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING | DISABLE_NEWLINE_AUTO_RETURN;
            if (!SetConsoleMode(iStdOut, outConsoleMode))
            {
                Console.WriteLine($"failed to set output console mode, error code: {GetLastError()}");
                Console.ReadKey();
                return;
            }

            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
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
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // Key Down Event
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                _keytimer = Stopwatch.StartNew();
                int vkCode = Marshal.ReadInt32(lParam);

                uint uCode = (uint)vkCode;
                uint scanCode = MapVirtualKey(uCode, MAPVK_VK_TO_VSC);

                Console.WriteLine("KEY-DOWN - vkCode: \u001b[33;1m0x{0}\u001b[0m\tScan Code: \u001b[33;1m0x{2}\u001b[0m\tKey: \u001b[33;1m{1}\u001b[0m", vkCode.ToString("X2"), (Keys)vkCode, scanCode.ToString("X2"));
            }

            // Key Up Event
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                _keytimer.Stop(); 
                int vkCode = Marshal.ReadInt32(lParam);

                uint uCode = (uint)vkCode;
                uint scanCode = MapVirtualKey(uCode, MAPVK_VK_TO_VSC);

                Console.WriteLine("KEY-UP   - vkCode: \u001b[33;1m0x{0}\u001b[0m\tScan Code: \u001b[33;1m0x{3}\u001b[0m\tKey: \u001b[33;1m{1}\u001b[0m in \u001b[32;1m{2}\u001b[0mms", vkCode.ToString("X2"), (Keys)vkCode, _keytimer.ElapsedMilliseconds, scanCode.ToString("X2"));
                Console.WriteLine();
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

    }
}
