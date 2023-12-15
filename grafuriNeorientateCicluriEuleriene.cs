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
    public partial class grafuriNeorientateCicluriEuleriene : Form
    {
        int[,] a = new int[20, 20];
        int[] L = new int[20];
        int n, i, j, m;
        Graphics g;
        public grafuriNeorientateCicluriEuleriene()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileGrafulEulerian.txt"))
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
                }
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
            richTextBox1.AppendText("Matricea drumurilor acestui graf este : " + "\n" + "\n");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                    richTextBox1.AppendText(a[i, j].ToString() + " ");
                richTextBox1.AppendText("\n");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateCicluriEuleriene f2 = new codGrafuriNeorientateCicluriEuleriene();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriNeorientateGrafulHamiltonian f2 = new grafuriNeorientateGrafulHamiltonian();
            f2.Show();
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
            g.DrawEllipse(p, 150, 125, 50, 50);
            g.DrawEllipse(p, 300, 50, 50, 50);
            g.DrawEllipse(p, 300, 200, 50, 50);
            g.DrawEllipse(p, 500, 50, 50, 50);
            g.DrawEllipse(p, 500, 200, 50, 50);
            g.DrawEllipse(p, 400, 300, 50, 50);
            //AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            //p.CustomEndCap = bigArrow;
            g.DrawLine(p, 200, 150, 300, 75);
            g.DrawLine(p, 350, 75, 500, 75);
            g.DrawLine(p, 525, 100, 525, 200);
            g.DrawLine(p, 500, 225, 350, 225);
            g.DrawLine(p, 350, 225, 425, 300);
            g.DrawLine(p, 425, 300, 500, 225);
            g.DrawLine(p, 525, 200, 350, 75);
            g.DrawLine(p, 325, 100, 325, 200);
            g.DrawLine(p, 325, 200, 200, 150);
            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 138.0F;
            float x2 = 313.0F; float y2 = 63.0F;
            float x3 = 313.0F; float y3 = 213.0F;
            float x4 = 513.0F; float y4 = 63.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 413.0F; float y6 = 313.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            //Thread.Sleep(1000);
        }
    
        private void grafuriNeorientateCicluriEuleriene_Load(object sender, EventArgs e)
        {

        }
    }
}
