using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class grafuriNeorientateGrafulEulerian : Form
    {
        int[,] A = new int[20, 20];
        int[] G = new int[20];
        int[] P = new int[20];
        int n, m, i, j;
        SolidBrush br = new SolidBrush(Color.SkyBlue);
        Graphics g;
        public grafuriNeorientateGrafulEulerian()
        {
            InitializeComponent();
        }

        private void grafuriNeorientateGrafulEulerian_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileGrafulEulerian.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n + "\n" + m + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    A[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    A[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                   
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
            //richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
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
        void afis2(int i)
        {
            if (i <= 10)
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
            g.DrawEllipse(p, 150, 125, 50, 50);
            g.DrawEllipse(p, 300, 50, 50, 50);
            g.DrawEllipse(p, 300, 200, 50, 50);
            g.DrawEllipse(p, 500, 50, 50, 50);
            g.DrawEllipse(p, 500, 200, 50, 50);
            g.DrawEllipse(p, 400, 300, 50, 50);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p1.CustomEndCap = bigArrow;
            if (i <= 10)
            {
                if (i == 1)
                    g.DrawLine(p1, 200, 150, 300, 75);
                if (i == 2)
                    g.DrawLine(p1, 350, 75, 500, 75);
                if (i == 3)
                    g.DrawLine(p1, 525, 100, 525, 200);
                if (i == 4)
                    g.DrawLine(p1, 500, 225, 350, 225);
                if (i == 5)
                    g.DrawLine(p1, 350, 225, 425, 300);
                if (i == 6)
                    g.DrawLine(p1, 425, 300, 500, 225);
                if (i == 7)
                    g.DrawLine(p1, 525, 200, 350, 75);
                if (i == 8)
                    g.DrawLine(p1, 325, 100, 325, 200);
                if (i == 9)
                    g.DrawLine(p1, 325, 200, 200, 150);
            }
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
            Thread.Sleep(1000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = 1;
            afis2(1);
        }
        int grad(int k)//calculeaza gradul varfului k
        {
            int s = 0;
            for (int i = 1; i <= n; i++)
                if (A[k, i] == 1) s++;
            return s;
        }

        void DF(int s)//parcurge graful din varful s si marcheaza varfurile accesibile
        {
            P[s] = 1;
            for (int i = 1; i <= n; i++)
                if (A[s, i] == 1 && P[i] == 0)
                    DF(i);
        }

        int conex()//conexitatea grafului
        {
            DF(1);
            for (int i = 1; i <= n; i++)
                if (P[i] == 0) return 0;
            return 1;
        }


        int euler()//daca este eulerian
        {
            if (conex() == 0) return 0;//conex
            for (int i = 1; i <= n; i++)
                if (G[i] % 2 == 1) return 0;//si toate gradele pare
            return 1;
        }

        void ciclu_eulerian(int k)//construieste un ciclu eulerian
        {
            int maxx = 0, nmax = 0;
            richTextBox1.AppendText(k.ToString() + " "); //afiseaza varful curent
            for (int i = 1; i <= n; i++)//cauta varful urmator cu grad maxim
            {
                if (A[k, i] == 1)
                    if (G[i] > maxx)
                    {
                        maxx = grad(i);
                        nmax = i;
                    }
            }
            if (nmax != 0)
            {
                A[k, nmax] = A[nmax, k] = 0;//sterge muchia
                G[k]--;//scade gradele
                G[nmax]--;
                ciclu_eulerian(nmax);//merge in varful urmator
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            for (int i = 1; i <= n; i++) G[i] = grad(i);
            if (euler() == 1)
            {
                richTextBox1.AppendText("nu este eulerian");
                //ciclu_eulerian(1);
            }
            else
                richTextBox1.AppendText("este eulerian");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grafuriNeorientateCicluriEuleriene f2 = new grafuriNeorientateCicluriEuleriene();
            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateGrafulEulerian f2 = new codGrafuriNeorientateGrafulEulerian();
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
