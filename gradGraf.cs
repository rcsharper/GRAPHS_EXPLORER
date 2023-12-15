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
    public partial class gradGraf : Form
    {
        public Button[] v = new Button[100];
        public int n = 0;
        public int[,] a11 = new int[10, 10];
        string linie;
        int nr = 0, i, j, p1, p2, p3, p4, x, y, L;
        Pen p = new Pen(Color.Black, 1);
        public gradGraf()
        {
            InitializeComponent();
        }
        private void gradGraf_Load(object sender, EventArgs e)
        {

        } 
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g1 = this.CreateGraphics();
            back1 ob = new back1(n, a11, v);
            ob.back(1, n, g1);
            DisplayMatrix(a11, n);
        }
        private void DisplayMatrix(int[,] matrix, int size)
        {
            richTextBox1.Clear();
            int s = 0;
            richTextBox1.AppendText("Grad: " + "\n");
            for (int i = 1; i <= size; i++)
            {
                s = 0;
                for (int j = 1; j <= size; j++)
                {
                    s = s + a11[i, j];
                }
                richTextBox1.AppendText(i.ToString() + " : " + s.ToString());
                richTextBox1.AppendText("\n");
            }
        }


        private void gradGraf_MouseClick(object sender, MouseEventArgs e)
        {
            n++;
            v[n] = new Button();
            v[n].Location = new Point(e.X, e.Y);
            v[n].Height = 20;
            v[n].Width = 20;
            v[n].Text = n.ToString();
            v[n].Tag = Convert.ToString(n);
            v[n].Click += new EventHandler(v_Click);
            this.Controls.Add(v[n]);
        }
        public void v_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            int nrb = Convert.ToInt32(((Button)sender).Tag);

            nr++;
            if (nr % 2 == 0)
            {
                x = nrb;
                p1 = ((Button)sender).Location.X;
                p2 = ((Button)sender).Location.Y;
                PointF punct1 = new PointF(p1 + 5, p2 + 5);
                PointF punct2 = new PointF(p3 + 5, p4 + 5);
                g.DrawLine(p, punct1, punct2);
                a11[x, y] = 1;
                a11[y, x] = 1;
            }
            else
            {
                y = nrb;
                p3 = ((Button)sender).Location.X;
                p4 = ((Button)sender).Location.Y;
            }
        }
        class back1
        {
            public Button[] v1 = new Button[10];
            public int n1, K = 0, j = 0;
            public int[,] a1 = new int[9, 9];
            public int[] st = new int[7];

            public back1(int n, int[,] a, Button[] v)
            {
                n1 = n;
                a1 = a;
                v1 = v;
            }

            public void init(int K)
            {
                st[K] = 0;
            }

            public bool succ(int K)
            {

                if (st[K] < n1)
                {
                    st[K]++;
                    return true;
                }
                else return false;
            }

            public bool valid(int K)
            {
                bool ev;
                ev = true;
                for (int i = 1; i <= K - 1; i++)
                {
                    if (st[i] == st[K])
                    {
                        ev = false;
                        break;
                    }
                }
                if (K > 1 && a1[st[K - 1], st[K]] == 0)
                {
                    ev = false;
                }
                if (K == n1 && a1[st[1], st[n1]] == 0)
                {
                    ev = false;
                }
                return ev;
            }

            public bool sol(int K, int L)
            {
                return (K == n1);
            }

            public void tipar(int K, Graphics g)
            {
                int i;
                Pen p1 = new Pen(Color.Black, 2);
                Pen p2 = new Pen(Color.Red, 2);

                for (i = 1; i <= K - 2; i++)
                {
                    int a5 = v1[st[i]].Location.X + 5;
                    int b = v1[st[i]].Location.Y + 5;
                    int c = v1[st[i + 1]].Location.X + 5;
                    int d = v1[st[i + 1]].Location.Y + 5;
                    g.DrawLine(p2, a5, b, c, d);

                    PointF pt22 = new PointF(540 + (80.0F) + 30 * i, (80.0F) + j * 30);
                    SolidBrush b22 = new SolidBrush(Color.Black);
                    Font f22 = new Font("Arial", 18, FontStyle.Italic);
                    g.DrawString(st[i].ToString(), f22, b22, pt22);

                    System.Threading.Thread.Sleep(500);
                }

                int a51 = v1[st[1]].Location.X + 5;
                int b1 = v1[st[1]].Location.Y + 5;
                int c1 = v1[st[n1]].Location.X + 5;
                int d1 = v1[st[n1]].Location.Y + 5;
                g.DrawLine(p2, a51, b1, c1, d1);

                PointF pt221 = new PointF(540 + (80.0F) + 30 * i, (80.0F) + j * 30);
                SolidBrush b221 = new SolidBrush(Color.Black);
                Font f221 = new Font("Arial", 18, FontStyle.Italic);
                g.DrawString(st[1].ToString(), f221, b221, pt221);

                System.Threading.Thread.Sleep(1000);

                for (i = 1; i <= K - 2; i++)
                {
                    int a4 = v1[st[i]].Location.X + 5;
                    int b4 = v1[st[i]].Location.Y + 5;
                    int c4 = v1[st[i + 1]].Location.X + 5;
                    int d4 = v1[st[i + 1]].Location.Y + 5;
                    g.DrawLine(p1, a4, b4, c4, d4);
                }
            }

            public void back(int K, int L, Graphics g)
            {
                if (K == n1 + 1)
                {
                    tipar(K, g);
                    j++;
                }
                else
                {
                    init(K);
                    while (succ(K))
                    {
                        if (valid(K))
                        {
                            back(K + 1, n1, g);
                        }
                    }
                }
            }
        }



    }
}
