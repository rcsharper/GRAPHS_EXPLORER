using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class arbori : Form
    {

        int nr = 0;
        Graphics g;
        public arbori()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            arboriVectorTati f2 = new arboriVectorTati();
            f2.Show();
        }

        private void arbori_Load(object sender, EventArgs e)
        {
            titluLabel.Visible = true;
            this.Size = new Size(869, 726);

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            panel1.Visible = false;
            panel2.Visible = false;

            label2.Visible = false;

            button1.Visible = false;


        }

        private void arbori_Click(object sender, EventArgs e)
        {
            nr++;
            if (nr == 1)
            {
                this.Size = new Size(1211, 726);
                titluLabel.Visible = false;

                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;

                panel1.Visible = true;
                panel2.Visible = true;

                label2.Visible = true;

                button1.Visible = true;
            }
            if(nr==2)
            {
                afis1(1);
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
            g.DrawEllipse(p, 350, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 250, 50, 50);//2
            g.DrawEllipse(p, 150, 350, 50, 50);//3
            g.DrawEllipse(p, 250, 350, 50, 50);//4
            g.DrawEllipse(p, 450, 250, 50, 50);//5
            g.DrawEllipse(p, 450, 350, 50, 50);//6

            g.DrawLine(p, 356, 191, 292, 255);//1 2
            g.DrawLine(p, 395, 190, 455, 258);//1 5
            g.DrawLine(p, 475, 300, 475, 350);//5 6
            g.DrawLine(p, 258, 292, 188, 352);//2 3
            g.DrawLine(p, 275, 300, 275, 350);//2 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 263.0F;
            float x3 = 163.0F; float y3 = 363.0F;
            float x4 = 263.0F; float y4 = 363.0F;
            float x5 = 463.0F; float y5 = 263.0F;
            float x6 = 463.0F; float y6 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
