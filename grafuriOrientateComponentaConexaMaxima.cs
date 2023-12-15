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
    public partial class grafuriOrientateComponentaConexaMaxima : Form
    {
        int[,] a = new int[10, 10];
        int[] suc = new int[100];
        int[] pred = new int[100];
        int n, m, nrc, i, j;
        int k, mk = 0, c, mc;
        Graphics g;
        public grafuriOrientateComponentaConexaMaxima()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
       

        private void grafuriOrientateComponentaConexaMaxima_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateComponentaConexaMaxima f2 = new codGrafuriOrientateComponentaConexaMaxima();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateComponentaTareConexa f2 = new grafuriOrientateComponentaTareConexa();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileComponentaConexaMaxima.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n.ToString() + "\n" + m.ToString() + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    a[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void dfsuc(int nod, int nrc)
        {
            //int k;
            suc[nod] = nrc;
            for (k = 1; k <= n; k++)
                if (a[nod, k] == 1 && suc[k] == 0)
                    dfsuc(k, nrc);
        }

        void dfpred(int nod, int nrc)
        {
            //int k;
            pred[nod] = nrc;
            for (k = 1; k <= n; k++)
                if (a[k, nod] == 1 && pred[k] == 0)
                    dfpred(k, nrc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            nrc = 1; mk = 0;
            for (i = 1; i <= n; i++)
                if (suc[i] == 0)
                {
                    dfsuc(i, nrc);
                    dfpred(i, nrc);
                    for (int j = 1; j <= n; j++)
                        if (suc[j] != pred[j])
                            suc[j] = pred[j] = 0;
                    nrc++;
                }
            for (i = 1; i < nrc; i++)
            {
                k = 0;
                for (j = 1; j <= n; j++)
                    if (suc[j] == i)
                        k++;
                if (k > mk)
                {
                    mk = k;
                    mc = i;
                }
            }
            for (j = 1; j <= n; j++)
                if (suc[j] == mc)
                    richTextBox1.AppendText(j.ToString() + " ");
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

        AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
        p.CustomEndCap = bigArrow;

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
        
        g.DrawString("1", drawFont, drawBrush, x1, y1);
        g.DrawString("2", drawFont, drawBrush, x2, y2);
        g.DrawString("3", drawFont, drawBrush, x3, y3);
        g.DrawString("4", drawFont, drawBrush, x4, y4);
        
        //Thread.Sleep(1000);
        }
    }
}

