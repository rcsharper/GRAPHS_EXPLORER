using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class testFinalRadioPanel : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\BazaDeDate.mdf;Integrated Security=True");
        radio[] v = new radio[100];
        int[] s = new int[100];
        int k, nr = 0, i, nota2;
        int[] v1 = new int[100];
        int id = 0;
        
        public testFinalRadioPanel()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (string.Compare(v[nr].r1.Trim(), v[nr].rc.Trim()) == 0)
                s[nr] = 2;
            else
                s[nr] = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (string.Compare(v[nr].r2.Trim(), v[nr].rc.Trim()) == 0)
                s[nr] = 2;
            else
                s[nr] = 0;
        }
        
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (string.Compare(v[nr].r3.Trim(), v[nr].rc.Trim()) == 0)
                s[nr] = 2;
            else
                s[nr] = 0;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            nr = 1;
            label1.Text = v[nr].intrebare;
            radioButton1.Text = v[nr].r1;
            radioButton2.Text = v[nr].r2;
            radioButton3.Text = v[nr].r3;

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            nr = 2;
            label1.Text = v[nr].intrebare;
            radioButton1.Text = v[nr].r1;
            radioButton2.Text = v[nr].r2;
            radioButton3.Text = v[nr].r3;

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            nr = 3;
            label1.Text = v[nr].intrebare;
            radioButton1.Text = v[nr].r1;
            radioButton2.Text = v[nr].r2;
            radioButton3.Text = v[nr].r3;

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            nr = 4;
            label1.Text = v[nr].intrebare;
            radioButton1.Text = v[nr].r1;
            radioButton2.Text = v[nr].r2;
            radioButton3.Text = v[nr].r3;

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            nr = 5;
            label1.Text = v[nr].intrebare;
            radioButton1.Text = v[nr].r1;
            radioButton2.Text = v[nr].r2;
            radioButton3.Text = v[nr].r3;

        }

        private void panel6_Click(object sender, EventArgs e)
        {
            nr = 6;
            label1.Text = v[nr].intrebare;
            radioButton1.Text = v[nr].r1;
            radioButton2.Text = v[nr].r2;
            radioButton3.Text = v[nr].r3;

        }

        private void panel7_Click(object sender, EventArgs e)
        {
            nr = 7;
            label1.Text = v[nr].intrebare;
            radioButton1.Text = v[nr].r1;
            radioButton2.Text = v[nr].r2;
            radioButton3.Text = v[nr].r3;

        }

        private void panel8_Click(object sender, EventArgs e)
        {
            nr = 8;
            label1.Text = v[nr].intrebare;
            radioButton1.Text = v[nr].r1;
            radioButton2.Text = v[nr].r2;
            radioButton3.Text = v[nr].r3;

        }

        private void panel9_Click(object sender, EventArgs e)
        {
            nr = 9;
            label1.Text = v[nr].intrebare;
            radioButton1.Text = v[nr].r1;
            radioButton2.Text = v[nr].r2;
            radioButton3.Text = v[nr].r3;

        }
        private void generareVector()
        {
            k = 0;
            using (StreamReader fin = new StreamReader("C2S2.txt"))
            {
                while (!fin.EndOfStream)
                {
                    string linie = fin.ReadLine();
                    string[] v1 = linie.Split('|');
                    k++;
                    v[k] = new radio();
                    v[k].intrebare = v1[0].ToString();
                    v[k].r1 = v1[1].ToString();
                    v[k].r2 = v1[2].ToString();
                    v[k].r3 = v1[3].ToString();;
                    v[k].rc = v1[4].ToString();
                }
                fin.Close();
            }
        }

        private void testFinalRadioPanel_Load(object sender, EventArgs e)
        {
            for (i = 1; i <= 99; i++)
                v1[i] = 0;

            generareVector();
            ApplyGradientToPanel(panel10);
        }
        private void ApplyGradientToPanel(Panel panel)
        {
            Color startColor = Color.LightSeaGreen;
            Color endColor = Color.Khaki;

            LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical);


            panel.BackColor = Color.Transparent;
            panel.BackgroundImage = new Bitmap(panel.Width, panel.Height);
            using (Graphics g = Graphics.FromImage(panel.BackgroundImage))
            {
                g.FillRectangle(brush, panel.ClientRectangle);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            k = 0;
            using (StreamReader fin = new StreamReader("radioPanel.txt"))
            {
                while (!fin.EndOfStream)
                {
                    string linie = fin.ReadLine();
                    string[] v1 = linie.Split('|');
                    k++;
                    v[k] = new radio();
                    v[k].intrebare = v1[0].ToString();
                    v[k].r1 = v1[1].ToString();
                    v[k].r2 = v1[2].ToString();
                    v[k].r3 = v1[3].ToString();
                    v[k].rc = v1[4].ToString();
                }
                fin.Close(); //MessageBox.Show(k.ToString());
            }

            con.Open();
            string select = "select Id from utilizatori where nume_utilizator=@n";
            SqlCommand cmd = new SqlCommand(select, con);
            cmd.Parameters.AddWithValue("n", textBox1.Text);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                id = Convert.ToInt32(r[0].ToString());
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nr > 1)
            {
                nr--;
                label1.Text = v[nr].intrebare;
                radioButton1.Text = v[nr].r1;
                radioButton2.Text = v[nr].r2;
                radioButton3.Text = v[nr].r3;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nr < k)
            {
                nr++;
                label1.Text = v[nr].intrebare;
                radioButton1.Text = v[nr].r1;
                radioButton2.Text = v[nr].r2;
                radioButton3.Text = v[nr].r3;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //rezultat
            for (i = 1; i <= k; i++)
                nota2 = nota2 + s[i];
            MessageBox.Show(nota2.ToString());

            con.Open();
            string insert = @"insert into catalog(id_elev,test,nota)values(@id_elev,@test,@nota)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("id_elev", id);
            cmd.Parameters.AddWithValue("test", "1");
            cmd.Parameters.AddWithValue("nota", nota2.ToString());
            SqlDataReader r = cmd.ExecuteReader();
            con.Close();
        }



    }
}
