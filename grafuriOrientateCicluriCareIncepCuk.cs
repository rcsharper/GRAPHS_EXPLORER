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
    public partial class grafuriOrientateCicluriCareIncepCuk : Form
    {
        int[,] A = new int[10, 10];
        int i, j, n, m, k;
        int[] X = new int[50];
        int[] p = new int[50];
        Graphics g;
        public grafuriOrientateCicluriCareIncepCuk()
        {
            InitializeComponent();
        }

        private void grafuriOrientateCicluriCareIncepCuk_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileCicluK.txt"))
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
                    A[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                    //d[int.Parse(v[0].Trim().ToString())]++;
                    //d[int.Parse(v[0].Trim().ToString())]++;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void afis(int n)
        {
            for (int i = 1; i <= n; i++)
                richTextBox1.AppendText(X[i].ToString() + " ");
            richTextBox1.AppendText("\n");
        }

        void back(int k, int pas)
        {
            for (int i = 1; i <= n; i++)
                if (p[i] != 1 && A[X[pas - 1], i] == 1)
                {
                    X[pas] = i;
                    p[i] = 1;
                    if (X[pas] == k && pas > 3) afis(pas);
                    else back(k, pas + 1);
                    p[i] = 0;
                }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            k = int.Parse(textBox1.Text);
            X[1] = k;
            back(k, 2);
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
            g.DrawEllipse(p, 250, 100, 50, 50);//1
            g.DrawEllipse(p, 150, 250, 50, 50);//2
            g.DrawEllipse(p, 250, 400, 50, 50);//3
            g.DrawEllipse(p, 400, 400, 50, 50);//4
            g.DrawEllipse(p, 500, 200, 50, 50);//5
            g.DrawEllipse(p, 600, 300, 50, 50);//6

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 255, 141, 198, 270);//1 2
            g.DrawLine(p, 198, 270, 255, 407);//2 3
            g.DrawLine(p, 300, 425, 400, 425);//3 4
            g.DrawLine(p, 445, 409, 509, 242);//4 5
            g.DrawLine(p, 505, 210, 297, 135);//5 1
            g.DrawLine(p, 198, 270, 600, 320);//2 6
            g.DrawLine(p, 600, 320, 545, 240);//6 5
            g.DrawLine(p, 600, 320, 445, 413);//6 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 263.0F; float y1 = 113.0F;
            float x2 = 163.0F; float y2 = 263.0F;
            float x3 = 263.0F; float y3 = 413.0F;
            float x4 = 413.0F; float y4 = 413.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 613.0F; float y6 = 313.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateCicluriCareIncepCuk f2 = new codGrafuriOrientateCicluriCareIncepCuk();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateComponenteConexe f2 = new grafuriOrientateComponenteConexe();
            f2.Show();
        }
    }
}
