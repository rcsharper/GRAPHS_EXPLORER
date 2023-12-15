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
    public partial class grafuriNeorientateCalculGrad : Form
    {
        int[,] A = new int[20, 20];
        int[] L = new int[20];
        int n, x, y, cnt, i, j, m;
        int grad = 0;
        int u = 0;
        int a, b, nr = 0, nrText = 0, mcx, mcy;
        Pen p = new Pen(Color.Black, 2);
        string fileName;
        bool ok1 = false, ok2 = false, ok3 = false;
        int mcx1 = 0, mcx2 = 0, mcy1 = 0, mcy2 = 0;
        bool okLinie;
        Graphics g;
        public grafuriNeorientateCalculGrad()
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
            using (StreamReader fin = new StreamReader("TextFileCalculGraf.txt"))
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
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (i = 1; i <= n; i++)
            {
                grad = 0;
                for (j = 1; j <= n; j++)
                    grad = grad + A[i, j];
                richTextBox1.AppendText("Nodul " + i.ToString() + " are gradul " + grad.ToString() + " ." + "\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("\n");
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    richTextBox1.AppendText(A[i, j].ToString());
                }
                richTextBox1.AppendText("\n");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            grafuriNeorientateMatriceaLanturilor f2 = new grafuriNeorientateMatriceaLanturilor();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateCalculGrad f2 = new codGrafuriNeorientateCalculGrad();
            f2.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //desen
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
            g.DrawEllipse(p, 300, 200, 50, 50);//1
            g.DrawEllipse(p, 300, 450, 50, 50);//2
            g.DrawEllipse(p, 450, 350, 50, 50);//3
            g.DrawEllipse(p, 550, 200, 50, 50);//4

            g.DrawLine(p, 325, 250, 325, 450);//1 2
            g.DrawLine(p, 350, 225, 550, 225);//1 4
            g.DrawLine(p, 342, 455, 452, 385);//2 3
            g.DrawLine(p, 490, 355, 560, 245);//3 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 313.0F; float y1 = 213.0F;
            float x2 = 313.0F; float y2 = 463.0F;
            float x3 = 463.0F; float y3 = 363.0F;
            float x4 = 563.0F; float y4 = 213.0F;

            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);

            //Thread.Sleep(1000);
        }
        private void grafuriNeorientateCalculGrad_Load(object sender, EventArgs e)
        {

        }
    }
}
