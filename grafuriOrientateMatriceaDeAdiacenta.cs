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
    public partial class grafuriOrientateMatriceaDeAdiacenta : Form
    {
        int[,] A = new int[10, 10];
        int i, j, n, m;
        Graphics g;
        public grafuriOrientateMatriceaDeAdiacenta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileArce.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n.ToString() + "\n" + m.ToString() + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    A[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    //a[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                    //ge[int.Parse(v[0].Trim().ToString())]++;
                    //gi[int.Parse(v[0].Trim().ToString())]++;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            richTextBox1.AppendText("Matricea de adiacenta este:" + "\n" + "\n");
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    richTextBox1.AppendText(A[i, j].ToString() + " ");

                }
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
            g.DrawEllipse(p, 250, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 350, 50, 50);//2
            g.DrawEllipse(p, 400, 500, 50, 50);//3
            g.DrawEllipse(p, 600, 350, 50, 50);//4
            g.DrawEllipse(p, 450, 150, 50, 50);//5
            g.DrawEllipse(p, 350, 250, 50, 50);//6

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 275, 200, 275, 350);//1 2
            g.DrawLine(p, 290, 393, 406, 507);//2 3
            g.DrawLine(p, 443, 505, 605, 390);//3 4
            g.DrawLine(p, 420, 500, 375, 300);//3 6
            g.DrawLine(p, 295, 190, 360, 255);//1 6

            g.DrawLine(p, 600, 365, 400, 280);//4 6
            g.DrawLine(p, 610, 355, 490, 195);//4 5
            g.DrawLine(p, 450, 167, 300, 167);//5 1

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 263.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 363.0F;
            float x3 = 413.0F; float y3 = 513.0F;
            float x4 = 613.0F; float y4 = 363.0F;
            float x5 = 463.0F; float y5 = 163.0F;
            float x6 = 363.0F; float y6 = 263.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateMatriceaDeAdiacenta f2 = new codGrafuriOrientateMatriceaDeAdiacenta();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateMatriceaDrumurilor f2 = new grafuriOrientateMatriceaDrumurilor();
            f2.Show();
        }

        private void grafuriOrientateMatriceaDeAdiacenta_Load(object sender, EventArgs e)
        {

        }
    }
}
