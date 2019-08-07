using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTester
{
    /// <summary>
    /// The main shared class.
    /// </summary>
    public class Main
    {
        /// <summary>
        /// Version major
        /// </summary>
        public const double VERSION = 1.0;

        /// <summary>
        /// Version minor
        /// </summary>
        public const int REVISION = 0004;

        /// <summary>
        /// Title
        /// </summary>
        public const string TITLE = "KeyTester";

        /// <summary>
        /// Are we running debug version?
        /// </summary>
        public const bool DEBUG = false;

        /// <summary>
        /// Display coords for the keyboard layout maker.
        /// </summary>
        public static bool LAYOUT_MODE = false;

        /// <summary>
        /// Keep the keys that have been pressed as GREEN
        /// </summary>
        public static bool MONITOR = true;

        /// <summary>
        /// Gets the .exe path.
        /// </summary>
        public static string ExecutablePath = Environment.GetCommandLineArgs()[0];

        /// <summary>
        /// Gets our .exe path only.
        /// </summary>
        public static string ExecutablePathOnly = System.IO.Path.GetDirectoryName(ExecutablePath);

        public static void Initialize()
        {
            
        }

        public static void DeInitialize()
        {

        }

    }

}
