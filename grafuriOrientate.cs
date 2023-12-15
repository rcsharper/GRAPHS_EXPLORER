using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class grafuriOrientate : Form
    {
        Graphics g;
        int nr = 0;
        public grafuriOrientate()
        {
            InitializeComponent();
        }

        private void grafuriOrientate_Load(object sender, EventArgs e)
        {
            titluLabel.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            label1.Visible = false;
            label2.Visible = true;
            label7.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            this.Size = new Size(1108, 722);
        }

        private void grafuriOrientate_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            nr++;
            if (nr == 1)
            {
                this.Size = new Size(1467, 722);
                titluLabel.Dispose(); titluLabel = null;
                panel1.Visible = true;
                panel2.Visible = true;
                label2.Dispose(); label2 = null;
                label7.Visible = false;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label1.Location = new Point(1101, 9);
                afis1(1);
            }
            if (nr == 2)
            {
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = true;
            }
        }
        void afis1(int i)
        {
            if (i <= 10)
            {
                desen1(i);
                afis1(i + 1);
            }
        }

        void desen1(int i)
        {
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);
            g.DrawEllipse(p, 350, 150, 50, 50);
            g.DrawEllipse(p, 500, 300, 50, 50);
            g.DrawEllipse(p, 600, 400, 50, 50);
            g.DrawEllipse(p, 400, 500, 50, 50);
            g.DrawEllipse(p, 250, 450, 50, 50);
            g.DrawEllipse(p, 200, 300, 50, 50);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;
            g.DrawLine(p, 375, 200, 250, 325);//1 6
            g.DrawLine(p, 500, 325, 375, 200);//2 1
            g.DrawLine(p, 525, 350, 425, 500);//2 4
            g.DrawLine(p, 625, 400, 525, 350);//3 2
            //g.DrawLine(p, );//3 3
            float startAngle = 270.0F;
            float sweepAngle = 270.0F;
            Rectangle rect = new Rectangle(625, 425, 50, 50);
            // Draw arc to screen.
            g.DrawArc(p, rect, startAngle, sweepAngle);
            g.DrawLine(p, 425, 500, 525, 350);//4 2
            g.DrawLine(p, 300, 475, 425, 500);//5 4
            g.DrawLine(p, 250, 325, 375, 200);//6 1
            g.DrawLine(p, 250, 325, 500, 325);//6 2
            g.DrawLine(p, 250, 325, 425, 500);//6 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 513.0F; float y2 = 313.0F;
            float x3 = 613.0F; float y3 = 413.0F;
            float x4 = 413.0F; float y4 = 513.0F;
            float x5 = 263.0F; float y5 = 463.0F;
            float x6 = 213.0F; float y6 = 313.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            grafuriOrientateCitireSiAfisare f2 = new grafuriOrientateCitireSiAfisare();
            f2.Show();
        }
    }
}
