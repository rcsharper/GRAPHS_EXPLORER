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
    public partial class arboriVectorTati : Form
    {
        int[,] A = new int[10, 10];
        int[] T = new int[100];
        int[] P = new int[100];
        int i, j, n, m;
        Graphics g;
        public arboriVectorTati()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("arbori2.txt"))
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
        }
        void BF(int v)
        {
            int st = 1, dr = 1;
            int[] Q = new int[100];
            Q[st] = v;
            P[v] = 1;
            while (st <= dr)
            {
                int i = Q[st];
                for (int j = 1; j <= n; j++)
                    if (P[j] != 1 && A[i, j] == 1)
                    {
                        dr++;
                        Q[dr] = j;
                        T[j] = i;
                        P[j] = 1;
                    }
                st++;
            }
        }
        void afisare()
        {
            for (int i = 1; i <= n; i++)
                richTextBox1.AppendText(i.ToString() + " " + T[i].ToString() + "\n");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            BF(1);
            afisare();
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

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void arboriVectorTati_Load(object sender, EventArgs e)
        {

        }

        void desen1(int i)
        {
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);
            g.DrawEllipse(p, 350, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 250, 50, 50);//2
            g.DrawEllipse(p, 350, 350, 50, 50);//3
            g.DrawEllipse(p, 450, 250, 50, 50);//4
            g.DrawEllipse(p, 150, 350, 50, 50);//5

            g.DrawLine(p, 356, 191, 292, 255);//1 2
            g.DrawLine(p, 395, 190, 455, 258);//1 4
            g.DrawLine(p, 258, 292, 194, 359);//2 5

            g.DrawLine(p, 300, 275, 450, 275);//2 4
            g.DrawLine(p, 375, 200, 375, 350);//1 3
            g.DrawLine(p, 293, 292, 358, 357);//2 3

            g.DrawLine(p, 453, 285, 200, 375);//4 5
            g.DrawLine(p, 400, 365, 458, 292);//3 4
            g.DrawLine(p, 350, 375, 200, 375);//3 5

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 263.0F;
            float x3 = 363.0F; float y3 = 363.0F;
            float x4 = 463.0F; float y4 = 263.0F;
            float x5 = 163.0F; float y5 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            codArboriVectorTati f2 = new codArboriVectorTati();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arboriFrunze f2 = new arboriFrunze();
            f2.Show();
        }
    }
}
