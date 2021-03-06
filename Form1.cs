﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MouseMover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Tvůrce aplikace nenese žádnou odpovědnost za její použití.");
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

        private void Button1_Click(object sender, EventArgs e)
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
  
        private void Timer1_Tick(object sender, EventArgs e)
        {
            MoveCursorLeft();
            DoMouseClick();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            MoveCursorRight();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!darkModeOn)
            {
                button2.Text = "LightMode";
                BackColor = Color.Black;
                button1.BackColor = Color.DarkGray;
                button1.ForeColor = Color.Yellow;
                button2.BackColor = Color.DarkGray;
                button2.ForeColor = Color.Yellow;
                button3.BackColor = Color.DarkGray;
                button3.ForeColor = Color.Yellow;
                button4.BackColor = Color.DarkGray;
                button4.ForeColor = Color.Yellow;
                darkModeOn = true;
            }
            else
            {
                button2.Text = "DarkMode";
                BackColor = Color.LightBlue;
                button1.BackColor = Color.AliceBlue;
                button1.ForeColor = Color.Black;
                button2.BackColor = Color.AliceBlue;
                button2.ForeColor = Color.Black;
                button3.BackColor = Color.AliceBlue;
                button3.ForeColor = Color.Black;
                button4.BackColor = Color.AliceBlue;
                button4.ForeColor = Color.Black;
                darkModeOn = false;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBox1.ToString().Contains("12345"))
            {
                MessageBox.Show("Voucher je správný. DarkMode odemčen!");
                button2.Enabled = true;
                button4.Enabled = false;
                textBox1.Enabled = false;
                textBox1.Clear();
            }
            else if (textBox1.ToString().Contains("67890"))
            {
                MessageBox.Show("Voucher je správný. DarkMode odemčen!");
                button2.Enabled = true;
                button4.Enabled = false;
                textBox1.Enabled = false;
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Nedobrá zpráva, špatný voucher.");
                textBox1.Clear();
            }
        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
