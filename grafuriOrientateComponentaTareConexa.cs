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
    public partial class grafuriOrientateComponentaTareConexa : Form
    {
        int[,] a = new int[10, 10];
        int[] ps = new int[100];
        int[] pf = new int[100];
        int i, n, m, k, l, j;
        int[] x = new int[100];
        int[] p = new int[100];

        public grafuriOrientateComponentaTareConexa()
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
            using (StreamReader fin = new StreamReader("TextFileComponentaTareConexa.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n.ToString() + "\n" + m.ToString() + " " + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie.ToString() + "\n");
                    string[] v = linie.Split(' ');
                    a[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                //k = int.Parse(fin.ReadLine());
                fin.Close();
            }
            textBox3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k = int.Parse(textBox3.Text);
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            richTextBox1.AppendText("Varful " + k.ToString() + " face parte dintr-o componenta conexa care are ");
            dfsuc(k);
            dfpred(k);
            for (int i = 1; i <= n; i++)
                if (pf[i] * ps[i] == 0)
                    pf[i] = ps[i] = 0;
            int t = 0;
            for (int i = 1; i <= n; i++)
                if (pf[i] == 1)
                    t++;
            richTextBox1.AppendText(t.ToString() + " varfuri: " + "\n");
            for (int i = 1; i <= n; i++)
                if (pf[i] == 1)
                    richTextBox1.AppendText(i.ToString() + " ");
            richTextBox1.AppendText("\n");
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateComponentaTareConexa f2 = new codGrafuriOrientateComponentaTareConexa();
            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            meniu f2 = new meniu();
            f2.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void dfsuc(int nod)
        {
            int k;
            pf[nod] = 1;
            for (k = 1; k <= n; k++)
                if (a[nod, k] == 1 && pf[k] == 0)
                    dfsuc(k);
        }
        void dfpred(int nod)
        {
            int k;
            ps[nod] = 1;
            for (k = 1; k <= n; k++)
                if (a[k, nod] == 1 && ps[k] == 0)
                    dfpred(k);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            j = int.Parse(textBox1.Text);
            l = int.Parse(textBox2.Text);
            richTextBox1.AppendText("\n" + j.ToString() + " " + l.ToString() + " ->");
            dfsuc(j);
            dfpred(j);
            for (int i = 1; i <= n; i++)
                if (pf[i] * ps[i] == 0 || ps[i] * pf[i] == 0)
                    pf[i] = ps[i] = 0;
            if (pf[l] == 1 && j != l)
                richTextBox1.AppendText("se afla in aceeasi componenta conexa");
            else
                richTextBox1.AppendText("nu se afla in aceeasi componenta conexa");
        }

        private void grafuriOrientateComponentaTareConexa_Load(object sender, EventArgs e)
        {

        }
    }
}
