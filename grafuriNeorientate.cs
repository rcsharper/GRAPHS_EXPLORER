using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class grafuriNeorientate : Form
    {
        Graphics g;
        int nr = 0;
        public grafuriNeorientate()
        {
            InitializeComponent();
        }

        private void grafuriNeorientate_Load(object sender, EventArgs e)
        {
            titluLabel.Visible = true;
            label6.Visible = true;
            label1.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            button1.Visible = false;

            panel1.Visible = false;
            panel2.Visible = false;

            label7.Visible = false;

            this.Size = new Size(1210, 715);

            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
        }

        private void grafuriNeorientate_Click(object sender, EventArgs e)
        {
            nr++;
            if (nr == 1)
            {
                this.Size = new Size(1350, 715);
                titluLabel.Visible = false;
                label6.Visible = false;
                label1.Visible = true;

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                button1.Visible = true;

                panel1.Visible = true;
                panel2.Visible = true;

                label7.Visible = true;

                afis1(1);
            }
            if(nr == 2)
            {
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;

                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
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
            g.DrawEllipse(p, 150, 100, 50, 50);//1
            g.DrawEllipse(p, 200, 300, 50, 50);//2
            g.DrawEllipse(p, 100, 250, 50, 50);//3
            g.DrawEllipse(p, 300, 150, 50, 50);//4
            g.DrawEllipse(p, 450, 100, 50, 50);//5
            g.DrawEllipse(p, 550, 200, 50, 50);//6
            g.DrawEllipse(p, 350, 350, 50, 50);//7

            g.DrawLine(p, 180, 150, 215, 300);//1 2
            g.DrawLine(p, 215, 300, 145, 285);//2 3
            g.DrawLine(p, 215, 300, 308, 192);//2 4
            g.DrawLine(p, 145, 258, 300, 185);//3 4

            g.DrawLine(p, 345, 160, 450, 130);//4 5
            g.DrawLine(p, 330, 200, 360, 350);//4 7
            g.DrawLine(p, 495, 138, 555, 205);//5 6
            g.DrawLine(p, 555, 235, 395, 360);//6 7


            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 113.0F;
            float x2 = 213.0F; float y2 = 313.0F;
            float x3 = 113.0F; float y3 = 263.0F;
            float x4 = 313.0F; float y4 = 163.0F;
            float x5 = 463.0F; float y5 = 113.0F;
            float x6 = 563.0F; float y6 = 213.0F;
            float x7 = 363.0F; float y7 = 363.0F;

            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            //Thread.Sleep(1000);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            grafuriNeorientateCalculGrad f2 = new grafuriNeorientateCalculGrad();
            f2.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
