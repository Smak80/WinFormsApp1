using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Painter p;
        private bool buttonPressed = false;

        public Form1()
        {
            InitializeComponent();
            p = new Painter(panel1.Size);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            buttonPressed = true;
            p.StartPoint = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (buttonPressed)
            {
                p.EndPoint = e.Location;
                p.Preview(panel1.CreateGraphics());
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            buttonPressed = false;
            p.EndPoint = e.Location;
            p.Paint();
            panel1.Update();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            p.Show(panel1.CreateGraphics());
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            p.ImageSize = panel1.Size;
        }
    }
}
