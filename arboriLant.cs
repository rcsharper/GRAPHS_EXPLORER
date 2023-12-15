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
    public partial class arboriLant : Form
    {
        int[] t = new int[100];
        int i, j, n, p, q;
        Graphics g;
        public arboriLant()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("arbori1.txt"))
            {
                n = int.Parse(fin.ReadLine());
                p = Convert.ToInt32(textBox1.Text);
                q = Convert.ToInt32(textBox2.Text);
                richTextBox2.AppendText(n.ToString() + "\n" + p.ToString() + "\n" + q.ToString() + "\n");
                for (i = 1; i <= n; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    t[int.Parse(v[0].Trim().ToString())] = int.Parse(v[1].Trim().ToString());
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void schimba(int r)
        {
            if (t[r] != 0)
            {
                schimba(t[r]);
                t[t[r]] = r;
            }
        }

        void drum(int v)
        {
            if (v != 0)
            {
                drum(t[v]);
                richTextBox1.AppendText(v.ToString() + " ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            schimba(p);
            t[p] = 0;
            drum(q);
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
            g.DrawEllipse(p, 350, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 250, 50, 50);//2
            g.DrawEllipse(p, 150, 350, 50, 50);//3
            g.DrawEllipse(p, 250, 350, 50, 50);//4
            g.DrawEllipse(p, 450, 250, 50, 50);//5
            g.DrawEllipse(p, 450, 350, 50, 50);//6

            g.DrawLine(p, 356, 191, 292, 255);//1 2
            g.DrawLine(p, 395, 190, 455, 258);//1 5
            g.DrawLine(p, 475, 300, 475, 350);//5 6
            g.DrawLine(p, 258, 292, 188, 352);//2 3
            g.DrawLine(p, 275, 300, 275, 350);//2 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 263.0F;
            float x3 = 163.0F; float y3 = 363.0F;
            float x4 = 263.0F; float y4 = 363.0F;
            float x5 = 463.0F; float y5 = 263.0F;
            float x6 = 463.0F; float y6 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            codArboriLant f2 = new codArboriLant();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void arboriLant_Load(object sender, EventArgs e)
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
