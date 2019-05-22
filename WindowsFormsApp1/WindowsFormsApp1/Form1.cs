using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public float degree = DateTime.Now.Second*6;
        public float degree2 = DateTime.Now.Minute*6;
        Graphics graphics1 = null;
        Timer timer = new Timer();
        Timer timer2 = new Timer();

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            timer.Interval = 1000;
            timer2.Interval = 360000;
            timer.Tick += Timer_Tick;
            timer.Start();
            graphics1 = this.CreateGraphics();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            degree += 6;
            Invalidate();

            if (degree%360 == 0)
            {
                degree2 += 6;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            graphics1 = e.Graphics;
            graphics1.SmoothingMode = SmoothingMode.HighQuality;

            Pen penBlack = new Pen(Brushes.Black, 5);
            Rectangle rect = new Rectangle(50, 50, 200, 200);


            graphics1.DrawEllipse(penBlack, rect);

            graphics1.DrawLine(penBlack, 150, 50, 150, 70);
            graphics1.DrawLine(penBlack, 150, 230, 150, 250);
            graphics1.DrawLine(penBlack, 50, 150, 70, 150);
            graphics1.DrawLine(penBlack, 230, 150, 250, 150);


            penBlack.StartCap = LineCap.SquareAnchor;
            penBlack.EndCap = LineCap.ArrowAnchor;

            Matrix matrix = new Matrix();
            matrix.RotateAt(degree, new Point(150, 150));
            graphics1.Transform = matrix;
            graphics1.DrawLine(penBlack, 150, 150, 150, 80); // маленькая стрелка
            matrix.Reset();
            matrix.RotateAt(degree2, new Point(150, 150));
            graphics1.Transform = matrix;
            graphics1.DrawLine(penBlack, 150, 150, 150, 100); // большая стрелка

        }
    }
}
