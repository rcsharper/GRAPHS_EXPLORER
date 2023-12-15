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
    public partial class grafuriNeorientateGrafulHamiltonian : Form
    {
        int[,] a = new int[50, 50];
        int[] x = new int[50];
        int[] p = new int[50];
        int i, j, n, m, ok;
        Graphics g;
        public grafuriNeorientateGrafulHamiltonian()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileGrafHamiltonian.txt"))
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
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        int valid(int k)
        {
            if (k > 1) 
                if (a[x[k], x[k - 1]] == 0) 
                    return 0;
            if (k == n) 
                if (a[x[1], x[n]] == 0) 
                    return 0;
            return 1;
        }

        private void grafuriNeorientateGrafulHamiltonian_Load(object sender, EventArgs e)
        {

        }

        void back(int k)
        {
            if (ok == 0)
                for (i = 1; i <= n; i++)
                    if (p[i] == 0)
                    {
                        x[k] = i; p[i] = 1;
                        if (valid(k) == 1) 
                            if (k == n) 
                                ok = 1;
                            else 
                                back(k + 1);
                        p[i] = 0;
                    }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            afis1(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateGrafulHamiltonian f2 = new codGrafuriNeorientateGrafulHamiltonian();
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
            g.DrawEllipse(p, 450, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 150, 50, 50);//2
            g.DrawEllipse(p, 250, 300, 50, 50);//3
            g.DrawEllipse(p, 600, 500, 50, 50);//4
            g.DrawEllipse(p, 600, 300, 50, 50);//5
            g.DrawEllipse(p, 600, 150, 50, 50);//6

            g.DrawLine(p, 300, 175, 450, 175);//2 1
            g.DrawLine(p, 500, 175, 600, 175);//1 6
            g.DrawLine(p, 625, 200, 625, 300);//6 5
            g.DrawLine(p, 300, 325, 600, 325);//3 5
            g.DrawLine(p, 625, 350, 625, 500);//5 4
            g.DrawLine(p, 288, 347, 608, 508);//3 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 463.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 163.0F;
            float x3 = 263.0F; float y3 = 313.0F;
            float x4 = 613.0F; float y4 = 513.0F;
            float x5 = 613.0F; float y5 = 313.0F;
            float x6 = 613.0F; float y6 = 163.0F;

            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

            //Thread.Sleep(1000);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            back(1);
            if (ok == 1)
                richTextBox1.AppendText("Nu");
            else
                richTextBox1.AppendText("Da");
        }
        
       private void button4_Click(object sender, EventArgs e)
        {
            grafuriNeorientateComponenteConexe f2 = new grafuriNeorientateComponenteConexe();
            f2.Show();
        }

    }
}
