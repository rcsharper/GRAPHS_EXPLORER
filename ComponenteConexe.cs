using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class ComponenteConexe : Form
    {
        int i, j, n=8, m=10;
        Graphics g;
        public ComponenteConexe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//desenare
            afis1(1);
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
            g.DrawEllipse(p, 200, 200, 50, 50);
            g.DrawEllipse(p, 350, 200, 50, 50);
            g.DrawEllipse(p, 200, 350, 50, 50);
            g.DrawEllipse(p, 350, 350, 50, 50);

            g.DrawEllipse(p, 500, 200, 50, 50);
            g.DrawEllipse(p, 650, 200, 50, 50);
            g.DrawEllipse(p, 500, 350, 50, 50);
            g.DrawEllipse(p, 650, 350, 50, 50);

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            //g.DrawLine(p, );

            //g.DrawLine(p, );//1 3 sau 3 1
            /*
            float startAngle = 0.0F;
            float sweepAngle = 270.0F;
            Rectangle rect = new Rectangle(225, 250, 50, 200);
            // Draw arc to screen.
            g.DrawArc(p, rect, startAngle, sweepAngle);
           */

            g.DrawLine(p, 250, 225, 350, 225);//1 2
            g.DrawLine(p, 375, 350, 375, 250);//4 2
            g.DrawLine(p, 355, 360, 245, 235);//4 1
            g.DrawLine(p, 250, 375, 350, 375);//3 4
            g.DrawLine(p, 250, 230, 250, 370);//3 1
            g.DrawLine(p, 200, 370, 200, 230);//1 3
            g.DrawLine(p, 400, 225, 500, 225);//2 5
            g.DrawLine(p, 650, 225, 550, 225);//6 5
            g.DrawLine(p, 525, 250, 525, 350);//5 7
            g.DrawLine(p, 550, 375, 650, 375);//7 8
            g.DrawLine(p, 675, 350, 675, 250);//8 6

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x1 = 213.0F; float y1 = 213.0F;
            float x2 = 363.0F; float y2 = 213.0F;
            float x3 = 213.0F; float y3 = 363.0F;
            float x4 = 363.0F; float y4 = 363.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 663.0F; float y6 = 213.0F;
            float x7 = 513.0F; float y7 = 363.0F;
            float x8 = 663.0F; float y8 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);

        }
        private void button2_Click(object sender, EventArgs e)
        {//parcurgere
            i = 1;
            afis2(1);
        }
        void afis2(int i)
        {
            if (i <= n + m)
            {
                desen2(i);
                afis2(i + 1);
            }
        }
        void desen2(int i)
        {
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Red, 2);
            Pen p2 = new Pen(Color.MediumPurple, 2);
            Pen p3 = new Pen(Color.RoyalBlue, 2);
            SolidBrush s1 = new SolidBrush(Color.LightYellow);
            SolidBrush s2 = new SolidBrush(Color.LightCoral);
            SolidBrush s3 = new SolidBrush(Color.LightSkyBlue);
            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 213.0F; float y1 = 213.0F;
            float x2 = 363.0F; float y2 = 213.0F;
            float x3 = 213.0F; float y3 = 363.0F;
            float x4 = 363.0F; float y4 = 363.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 663.0F; float y6 = 213.0F;
            float x7 = 513.0F; float y7 = 363.0F;
            float x8 = 663.0F; float y8 = 363.0F;
            AdjustableArrowCap bigArrow1 = new AdjustableArrowCap(7, 7);
            p1.CustomEndCap = bigArrow1;
            AdjustableArrowCap bigArrow2 = new AdjustableArrowCap(7, 7);
            p2.CustomEndCap = bigArrow2;
            AdjustableArrowCap bigArrow3 = new AdjustableArrowCap(7, 7);
            p3.CustomEndCap = bigArrow3;

            if (i <= n + m)
            {
                if (i == 1)
                    g.FillEllipse(s1, 200, 200, 50, 50);
                if (i == 2)
                    g.DrawLine(p1, 250, 230, 250, 370);//3 1
                if (i == 3)
                    g.FillEllipse(s1, 200, 350, 50, 50);
                if (i == 4)
                    g.DrawLine(p1, 200, 370, 200, 230);//1 3
                if (i == 5)
                    g.DrawLine(p1, 250, 375, 350, 375);//3 4
                if (i == 6)
                    g.FillEllipse(s1, 350, 350, 50, 50);
                if (i == 7)
                    g.DrawLine(p1, 355, 360, 245, 235);//4 1
                if (i == 8)
                    g.DrawLine(p2, 250, 225, 350, 225);//1 2 
                if (i == 9)
                    g.FillEllipse(s2, 350, 200, 50, 50);
                if (i == 10)
                    g.DrawLine(p2, 400, 225, 500, 225);//2 5
                if (i == 11)
                    g.FillEllipse(s3, 500, 200, 50, 50);
                if (i == 12)
                    g.DrawLine(p3, 525, 250, 525, 350);//5 7
                if (i == 13)
                    g.FillEllipse(s3, 500, 350, 50, 50);
                if (i == 14)
                    g.DrawLine(p3, 550, 375, 650, 375);//7 8
                if (i == 15)
                    g.FillEllipse(s3, 650, 350, 50, 50);
                if (i == 16)
                    g.DrawLine(p3, 675, 350, 675, 250);//8 6
                if (i == 17)
                    g.FillEllipse(s3, 650, 200, 50, 50);
                if (i == 18)
                    g.DrawLine(p3, 650, 225, 550, 225);//6 5
            }

            //g.DrawLine(p, 375, 350, 375, 250);//4 2
            g.DrawEllipse(p, 200, 200, 50, 50);
            g.DrawEllipse(p, 350, 200, 50, 50);
            g.DrawEllipse(p, 200, 350, 50, 50);
            g.DrawEllipse(p, 350, 350, 50, 50);

            g.DrawEllipse(p, 500, 200, 50, 50);
            g.DrawEllipse(p, 650, 200, 50, 50);
            g.DrawEllipse(p, 500, 350, 50, 50);
            g.DrawEllipse(p, 650, 350, 50, 50);

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);
            Thread.Sleep(1000);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            grafuriOrientateComponenteConexe f2 = new grafuriOrientateComponenteConexe();
            f2.Show();
        }

        private void ComponenteConexe_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
