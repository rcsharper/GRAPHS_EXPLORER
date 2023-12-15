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

namespace Graphs_Explorer
{
    public partial class grafuriOrientateMatriceaDrumurilor : Form
    {
        int[,] a = new int[20, 20];
        int[] L = new int[20];
        int n, i, j, m;
        Graphics g;
        public grafuriOrientateMatriceaDrumurilor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("MatriceaDrumurilor.txt"))
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

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            rw();
            afis();
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
            g.DrawEllipse(p, 150, 150, 50, 50);//1
            g.DrawEllipse(p, 150, 350, 50, 50);//2
            g.DrawEllipse(p, 450, 150, 50, 50);//3
            g.DrawEllipse(p, 450, 450, 50, 50);//4
            g.DrawEllipse(p, 550, 350, 50, 50);//5

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 175, 200, 175, 350);//1 2
            g.DrawLine(p, 195, 360, 455, 190);//2 3
            g.DrawLine(p, 475, 200, 475, 450);//3 4

            g.DrawLine(p, 454, 460, 200, 380);//4 2
            g.DrawLine(p, 200, 375, 550, 375);//2 5
            g.DrawLine(p, 555, 360, 200, 178);//5 1

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 163.0F;
            float x2 = 163.0F; float y2 = 363.0F;
            float x3 = 463.0F; float y3 = 163.0F;
            float x4 = 463.0F; float y4 = 463.0F;
            float x5 = 563.0F; float y5 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateMatriceaDrumurilor f2 = new codGrafuriOrientateMatriceaDrumurilor();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateCicluriCareIncepCuk f2 = new grafuriOrientateCicluriCareIncepCuk();
            f2.Show();
        }

        private void grafuriOrientateMatriceaDrumurilor_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();

        }
    }
}
