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
    public partial class testFinalCheckBack : Form
    {
        public int i, j, ok, x, n, nr = 0, n1 = 0, k = 0, y;
        int[] v = new int[100];
        CheckBox[] c = new CheckBox[10];
        int[] st = new int[100];
        Class2[] vect = new Class2[100];
        Class1[] v2 = new Class1[10000];
        public testFinalCheckBack()
        {
            InitializeComponent();
        }

        private void testFinalCheckBack_Load(object sender, EventArgs e)
        {
            ApplyGradientToPanel(panel1);

        }

        private void ApplyGradientToPanel(Panel panel)
        {          
            Color startColor = Color.MediumPurple;
            Color endColor = Color.DarkSlateBlue;
       
            LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical);

            
            panel.BackColor = Color.Transparent;
            panel.BackgroundImage = new Bitmap(panel.Width, panel.Height);
            using (Graphics g = Graphics.FromImage(panel.BackgroundImage))
            {
                g.FillRectangle(brush, panel.ClientRectangle);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader f = new StreamReader("TextFileBackCheck.txt"))
            {
                while (!f.EndOfStream)
                {
                    n1++;
                    vect[n1] = new Class2();
                    vect[n1].test = f.ReadLine();
                    vect[n1].raspuns = f.ReadLine();
                    vect[n1].punctaj = Convert.ToInt32(f.ReadLine());
                }
                f.Close();
            }
        }
        bool valid(int niv)
        {
            int i, nr = 0;
            for (i = 1; i <= niv - 1; i++)

                if (st[i] == st[niv])
                    return false;
            for (i = 1; i <= niv; i++)
                nr += Convert.ToInt32(vect[i].punctaj);

            if (nr > 40)
                return false;
            if (niv == 4 && nr != 40)
                return false;

            return true;
        }

        void afis()
        {

            k++;
            v2[k] = new Class1();
            v2[k].a = st[1];
            v2[k].b = st[2];
            v2[k].c = st[3];
            v2[k].d = st[4];
            dataGridView1.Rows.Add(st[1], st[2], st[3], st[4]);

        }
        void back(int niv)
        {
            if (niv == 5)
            {
                afis();
            }
            else
                for (int i = 1; i <= n1; i++)
                {
                    st[niv] = i;
                    if (valid(niv))
                        back(niv + 1);
                }
        }   
        private void button2_Click(object sender, EventArgs e)
        {
            back(1);
            Random r = new Random();
            y = r.Next(1, 18);

            checkBox1.Text = vect[v2[y].a].test;
            checkBox2.Text = vect[v2[y].b].test;
            checkBox3.Text = vect[v2[y].c].test;
            checkBox4.Text = vect[v2[y].d].test;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int nota = 0;
            if (checkBox1.Checked && vect[v2[y].a].raspuns == "Da")
                nota += vect[v2[y].a].punctaj;
            if (checkBox2.Checked && vect[v2[y].b].raspuns == "Da")
                nota += vect[v2[y].b].punctaj;
            if (checkBox3.Checked && vect[v2[y].c].raspuns == "Da")
                nota += vect[v2[y].c].punctaj;
            if (checkBox4.Checked && vect[v2[y].d].raspuns == "Da")
                nota += vect[v2[y].d].punctaj;
            MessageBox.Show(nota.ToString());
        }
    }
}
