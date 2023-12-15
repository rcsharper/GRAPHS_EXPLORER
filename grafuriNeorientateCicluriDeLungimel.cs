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
    public partial class grafuriNeorientateCicluriDeLungimel : Form
    {
        int[] X = new int[20];
        int[] P = new int[20];
        int i, j, n, l;
        Graphics g;
        public grafuriNeorientateCicluriDeLungimel()
        {
            InitializeComponent();
        }

        private void grfauriNeorientateCicluriDeLungimel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            l = int.Parse(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            back(1);
        }
        void back(int k)
        {
            for (int i = 1; i <= n; i++)
                if (P[i] != 1)
                {
                    X[k] = i;
                    P[i] = 1;
                    if (k == l) afisare();
                    else back(k + 1);
                    P[i] = 0;
                }
        }
       
            
        
        void afisare()
        {
            for (int i = 1; i <= l; i++)
                richTextBox1.AppendText(X[i].ToString() + " ");
            richTextBox1.AppendText(X[1] + "\n");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateCicluriDeLungimel f2 = new codGrafuriNeorientateCicluriDeLungimel();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grafuriNeorientateGrafulEulerian f2 = new grafuriNeorientateGrafulEulerian();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
    }
}
