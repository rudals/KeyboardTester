using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceTester
{
    public partial class Form1 : Form
    {
        InputDevice id;
        int NumberOfKeyboards;

        public Form1()
        {
            InitializeComponent();

            // Create a new InputDevice object, get the number of
            // keyboards, and register the method which will handle the 
            // InputDevice KeyPressed event
            id = new InputDevice(Handle);
            NumberOfKeyboards = id.EnumerateDevices();
            id.KeyPressed += new InputDevice.DeviceEventHandler(m_KeyPressed);
        }

        // The WndProc is overridden to allow InputDevice to intercept
        // messages to the window and thus catch WM_INPUT messages
        protected override void WndProc(ref Message message)
        {
            if (id != null)
            {
                id.ProcessMessage(message);
            }
            base.WndProc(ref message);
        }

        private void m_KeyPressed(object sender, InputDevice.KeyControlEventArgs e)
        {
            //Replace() is just a cosmetic fix to stop ampersands turning into underlines
            //lbHandle.Text = e.Keyboard.deviceHandle.ToString();
            //lbType.Text = e.Keyboard.deviceType;
            //lbName.Text = e.Keyboard.deviceName.Replace("&", "&&");
            //lbDescription.Text = e.Keyboard.Name;

            lblKeyCode.Text = e.Keyboard.key.ToString();
            lblVirtualKey.Text = e.Keyboard.vKey;

            //lbNumKeyboards.Text = NumberOfKeyboards.ToString();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
