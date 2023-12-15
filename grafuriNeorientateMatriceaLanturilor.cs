using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class grafuriNeorientateMatriceaLanturilor : Form
    {
        int[,] a = new int[10, 10];
        int[] x = new int[10];
        int[] smax = new int[10];
        int[] p = new int[10];
        int i, f, n, m, k, lmax;
        Graphics g;
        public grafuriNeorientateMatriceaLanturilor()
        {
            InitializeComponent();
        }

        private void grafuriNeorientateMatriceaLanturilor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("MatriceaLanturilor.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n.ToString() + "\n" + m.ToString() + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    a[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    a[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                }
                richTextBox2.AppendText("\n");
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void rw()
        {
            int i, j, k;
            for (k = 1; k <= n; k++)
                for (i = 1; i <= n; i++)
                    for (j = 1; j <= n; j++)
                        if (i != j)
                            if (a[i, j] == 0)
                                a[i, j] = a[i, k] * a[k, j];
        }
        void afis()
        {
            for (int i = 1; i <= n; i++)
            {
                richTextBox1.AppendText("\n");
                for (int
                j = 1; j <= n; j++)
                    richTextBox1.AppendText(a[i, j].ToString() + " ");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            rw();
            afis();
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
            g.DrawEllipse(p, 450, 200, 50, 50);//1
            g.DrawEllipse(p, 300, 300, 50, 50);//2
            g.DrawEllipse(p, 450, 400, 50, 50);//3
            g.DrawEllipse(p, 550, 300, 50, 50);//4
            g.DrawEllipse(p, 650, 200, 50, 50);//5
            g.DrawEllipse(p, 650, 400, 50, 50);//6
            g.DrawEllipse(p, 850, 400, 50, 50);//7
            g.DrawEllipse(p, 850, 200, 50, 50);//8
            g.DrawEllipse(p, 1000, 300, 50, 50);//9

            g.DrawLine(p, 457, 235, 345, 305);//1 2
            g.DrawLine(p, 475, 250, 475, 400);//1 3
            g.DrawLine(p, 500, 225, 650, 225);//1 5

            g.DrawLine(p, 340, 345, 450, 412);//2 3
            g.DrawLine(p, 491, 405, 558, 345);//3 4
            g.DrawLine(p, 500, 425, 650, 425);//3 6

            g.DrawLine(p, 590, 304, 655, 242);//4 5
            g.DrawLine(p, 700, 225, 850, 225);//5 8
            g.DrawLine(p, 700, 425, 850, 425);//6 7
            g.DrawLine(p, 875, 400, 875, 250);//7 8

            g.DrawLine(p, 896, 411, 1006, 341);//7 9
            g.DrawLine(p, 896, 237, 1003, 311);//8 9

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 463.0F; float y1 = 213.0F;
            float x2 = 313.0F; float y2 = 313.0F;
            float x3 = 463.0F; float y3 = 413.0F;
            float x4 = 563.0F; float y4 = 313.0F;
            float x5 = 663.0F; float y5 = 213.0F;
            float x6 = 663.0F; float y6 = 413.0F;
            float x7 = 863.0F; float y7 = 413.0F;
            float x8 = 863.0F; float y8 = 213.0F;
            float x9 = 1013.0F; float y9 = 313.0F;
            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);
            g.DrawString("9", drawFont, drawBrush, x9, y9);
            //Thread.Sleep(1000);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateMatriceaLanturilor f2 = new codGrafuriNeorientateMatriceaLanturilor();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grafuriNeorientateCicluriDeLungimel f2 = new grafuriNeorientateCicluriDeLungimel();
            f2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
    }
}
