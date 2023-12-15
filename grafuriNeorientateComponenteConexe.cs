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
    public partial class grafuriNeorientateComponenteConexe : Form
    {
        int[,] a = new int[20, 20];
        int[] x = new int[20];
        int[] p = new int[20];
        int n, m, i, j;
        Graphics g;
        public grafuriNeorientateComponenteConexe()
        {
            InitializeComponent();
        }

        private void grafuriNeorientateComponenteConexe_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileCompConexe.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n + "\n" + m + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    a[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    a[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                    //d[int.Parse(v[0].Trim().ToString())]++;
                    //d[int.Parse(v[0].Trim().ToString())]++;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void bf(int k)
        {
            int i, s, d;
            x[1] = k;
            p[k] = 1;
            s = d = 1;
            while (s <= d)
            {
                for (i = 1; i <= n; i++)
                    if (a[x[s], i] == 1 && p[i] != 1)
                    {
                        d++;
                        x[d] = i;
                        p[i] = 1;
                    }
                s++;
            }
            for (i = 1; i <= d; i++)
                richTextBox1.AppendText(x[i].ToString() + " ");
            richTextBox1.AppendText("\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            int i;
            for (i = 1; i <= n; i++)
                if (p[i] != 1)
                    bf(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriNeorientateComponentaConexaMaxima f2 = new grafuriNeorientateComponentaConexaMaxima();
            f2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
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
            g.DrawEllipse(p, 300, 200, 50, 50);//1
            g.DrawEllipse(p, 300, 450, 50, 50);//2
            g.DrawEllipse(p, 450, 350, 50, 50);//3
            g.DrawEllipse(p, 550, 200, 50, 50);//4
            g.DrawEllipse(p, 700, 250, 50, 50);//5
            g.DrawEllipse(p, 600, 400, 50, 50);//6
            g.DrawEllipse(p, 700, 500, 50, 50);//7
            g.DrawEllipse(p, 750, 400, 50, 50);//8

            g.DrawLine(p, 325, 250, 325, 450);//1 2
            g.DrawLine(p, 350, 225, 550, 225);//1 4
            g.DrawLine(p, 342, 455, 452, 385);//2 3
            g.DrawLine(p, 490, 355, 560, 245);//3 4
            g.DrawLine(p, 645, 440, 705, 510);//6 7
            g.DrawLine(p, 730, 500, 765, 445);//7 8

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 313.0F; float y1 = 213.0F;
            float x2 = 313.0F; float y2 = 463.0F;
            float x3 = 463.0F; float y3 = 363.0F;
            float x4 = 563.0F; float y4 = 213.0F;
            float x5 = 713.0F; float y5 = 263.0F;
            float x6 = 613.0F; float y6 = 413.0F;
            float x7 = 713.0F; float y7 = 513.0F;
            float x8 = 763.0F; float y8 = 413.0F;
            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);
            //Thread.Sleep(1000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateComponenteConexe f2 = new codGrafuriNeorientateComponenteConexe();
            f2.Show();
        }
    }
}
