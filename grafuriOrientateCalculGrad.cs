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
    public partial class grafuriOrientateCalculGrad : Form
    {
        int[,] a = new int[10, 10];
        int[,] b = new int[10, 10];
        int n, m, i;
        Graphics g;
        public grafuriOrientateCalculGrad()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("gradCalcul1.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox1.AppendText(n.ToString() + "\n" + m.ToString() + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox1.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    a[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    b[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())]= 1;
                }
                richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {//grad extern
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("Grade exterioare: " + "\n");
            for (i = 1; i <= n; i++)
            {
                richTextBox1.AppendText(i.ToString() + " : " + gradExtern(i));
                richTextBox1.AppendText("\n");
            }
        }

        int gradExtern(int v)
        {
            int g = 0;
            for (int i = 1; i <= n; i++)
            {
                g = g + a[v, i];
            }
            return g;
        }
        int gradIntern(int v)
        {
            int g = 0;
            for (int i = 1; i <= n; i++)
            {
                g = g + b[v, i];
            }
            return g;
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
            g.DrawEllipse(p, 150, 400, 50, 50);//2
            g.DrawEllipse(p, 550, 550, 50, 50);//3
            g.DrawEllipse(p, 550, 150, 50, 50);//4

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 175, 200, 175, 400);//1 2
            g.DrawLine(p, 200, 175, 550, 175);//1 4
            g.DrawLine(p, 194, 410, 552, 185);//2 4
            g.DrawLine(p, 197, 435, 550, 565);//2 3
            g.DrawLine(p, 575, 200, 573, 550);//3 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 163.0F;
            float x2 = 163.0F; float y2 = 413.0F;
            float x3 = 563.0F; float y3 = 563.0F;
            float x4 = 563.0F; float y4 = 163.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            //Thread.Sleep(1000);
        }
    

        private void grafuriOrientateCalculGrad_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {//grad intern
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("Grade interioare: " + "\n");
            for (i = 1; i <= n; i++)
            {
                richTextBox1.AppendText(i.ToString() + " : " + gradIntern(i));
                richTextBox1.AppendText("\n");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateCalculGrad f2 = new codGrafuriOrientateCalculGrad();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grafuriOrientateMatriceaDeAdiacenta f2 = new grafuriOrientateMatriceaDeAdiacenta();
            f2.Show();
        }
    }
}
