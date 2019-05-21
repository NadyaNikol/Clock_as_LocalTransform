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
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics1 = e.Graphics;
            Graphics graphics2 = e.Graphics;
            Graphics graphics3 = e.Graphics;


            Pen penBlack = new Pen(Brushes.Black, 5);
            Rectangle rect = new Rectangle(50, 50, 200, 200);


            graphics1.DrawEllipse(penBlack, rect);

            graphics1.DrawLine(penBlack, 150, 50, 150, 70);
            graphics1.DrawLine(penBlack, 150, 230, 150, 250);
            graphics1.DrawLine(penBlack, 50, 150, 70, 150);
            graphics1.DrawLine(penBlack, 230, 150, 250, 150);

            graphics1.DrawLine(penBlack, 100, 65, 110, 80);
            graphics1.DrawLine(penBlack, 60, 110, 75, 120);


            penBlack.StartCap = LineCap.SquareAnchor;
            penBlack.EndCap = LineCap.ArrowAnchor;
            graphics2.DrawLine(penBlack, 150, 150, 150, 100); // маленькая стрелка
            graphics3.DrawLine(penBlack, 150, 150, 150, 80); // большая стрелка


            Matrix matrix = new Matrix();
           

            for (int i = 0; i < 36; i++)
            {
                matrix.Reset();
                matrix.RotateAt(i*10, new PointF(150, 150));
                graphics2.Transform = matrix;
                graphics2.DrawLine(penBlack, 150, 150, 150, 80);

                System.Threading.Thread.Sleep(1000);
                
            }



            //graphics2.Transform = matrix;


            penBlack?.Dispose();
            graphics1?.Dispose();
           graphics2?.Dispose();
           // graphics3?.Dispose();

                //Invalidate();

        }
    }
}
