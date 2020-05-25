using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        // private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        // private const int MOUSEEVENTF_RIGHTUP = 0x10;
        bool darkModeOn = false;

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 5sec timer
            timer1.Enabled = true;
            // 1sec timer
            timer2.Enabled = true;
        }

        private void MoveCursorLeft()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }
        private void MoveCursorRight()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }
  
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveCursorLeft();
            DoMouseClick();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MoveCursorRight();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (darkModeOn == false)
            {
                BackColor = Color.Black;
                darkModeOn = true;
            }
            else
            {
                BackColor = Color.White;
                darkModeOn = false;
            }
            
        }
    }
}
