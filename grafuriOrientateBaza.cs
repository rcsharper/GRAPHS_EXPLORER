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
    public partial class grafuriOrientateBaza : Form
    {
        int[,] a = new int[20, 20];
        int[] L = new int[20];
        int n, x, y, cnt, i, j, m;
        int grafext = 0;
        int grafint = 0;
        int u = 0;
        Graphics g;
        public grafuriOrientateBaza()
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
                    richTextBox2.AppendText(linie + " ");
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
            for (i = 1; i <= n; i++)
            {
                grafext = 0;
                for (j = 1; j <= n; j++)
                    grafext = grafext + a[i, j];
                richTextBox1.AppendText("d +(" + i.ToString() + ") =" + grafext.ToString() + "\n");
                //se = se + de;
            }
            //suma gradelor ext
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            for (j = 1; j <= n; j++)
            {
                grafint = 0;
                for (i = 1; i <= n; i++)
                    grafint = grafint + a[i, j];
                richTextBox1.AppendText("d -(" + j.ToString() + ") =" + grafint.ToString() + "\n");
            }
            //suma gradelor int
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            //cout<<"Lista de adiacenta"<<endl;
            richTextBox1.AppendText("lista de adiacenta: " + "\n");
            for (i = 1; i <= n; i++)
            {
                richTextBox1.AppendText("varful " + i.ToString() + " : ");
                for (j = 1; j <= n; j++)
                    if (a[i, j] == 1)//|| a[j][i] == 1)//vecini
                        richTextBox1.AppendText(j.ToString() + " ");
                richTextBox1.AppendText("\n");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateBaza f2 = new codGrafuriOrientateBaza();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("vecini: " + "\n");
            for (i = 1; i <= n; i++)
            {
                richTextBox1.AppendText("varful " + i.ToString() + " : ");
                for (j = 1; j <= n; j++)
                    if (a[i, j] == 1 || a[j, i] == 1)//vecini
                        richTextBox1.AppendText(j.ToString() + " ");
                richTextBox1.AppendText("\n");
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
            g.DrawEllipse(p, 600, 150, 50, 50);//2
            g.DrawEllipse(p, 250, 300, 50, 50);//3
            g.DrawEllipse(p, 450, 250, 50, 50);//4
            g.DrawEllipse(p, 550, 350, 50, 50);//5
            g.DrawEllipse(p, 700, 250, 50, 50);//6
            g.DrawEllipse(p, 700, 400, 50, 50);//7

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 293, 305, 393, 190);//3 1
            g.DrawLine(p, 393, 190, 453, 260);//1 4
            g.DrawLine(p, 491, 256, 603, 186);//2 4
            g.DrawLine(p, 603, 186, 582, 350);//2 5
            g.DrawLine(p, 453, 260, 293, 305);//4 3
            g.DrawLine(p, 582, 350, 491, 256);//4 5
            g.DrawLine(p, 569, 349, 716, 250);//5 6
            g.DrawLine(p, 735, 297, 600, 385);//6 5

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 613.0F; float y2 = 163.0F;
            float x3 = 263.0F; float y3 = 313.0F;
            float x4 = 463.0F; float y4 = 263.0F;
            float x5 = 563.0F; float y5 = 363.0F;
            float x6 = 713.0F; float y6 = 263.0F;
            float x7 = 713.0F; float y7 = 413.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateCalculGrad f2 = new grafuriOrientateCalculGrad();
            f2.Show();
        }

        private void grafuriOrientateBaza_Load(object sender, EventArgs e)
        {

        }
    }
}
