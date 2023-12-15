using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class aplicatii : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\BazaDeDate.mdf;Integrated Security=True");
        int ok = 0, nr = 0;
        double nota;
        string s;
        int idA;
        public aplicatii()
        {
            InitializeComponent();
        }

        private void aplicatii_Load(object sender, EventArgs e)
        {
            textBoxN.Text = Autentificare.user;

            numeAplicatie();
            
            /*
            c.Open();
            string select = "select * from aplicatii";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                //dataGridView1.Rows.Add(r[0].ToString(), r[1].ToString(), r[2].ToString(), r[3].ToString(), r[4].ToString());
            }
            c.Close();*/

            textBoxN.Enabled = false;
            textBoxCerinta.Enabled = false;
            richTextBox4.Enabled = false;
            richTextBox2.Enabled = false;

            
        }
        private void numeAplicatie()
        {
            c.Open();
            string select = "select fisier,Id from aplicatii";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                comboBox2.Items.Add(r[0].ToString());
                idA = Convert.ToInt32(r[1].ToString());
            }
            c.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            selectCapitol();

            

        }
        void selectCapitol()
        {
            c.Open();
            string select = "select capitol,cerinta,date from aplicatii where fisier=@c2";
            SqlCommand cmd = new SqlCommand(select, c);
            cmd.Parameters.AddWithValue("c2", comboBox2.Text);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                comboBox1.Text = r[0].ToString();
                textBoxCerinta.Text = comboBox2.SelectedItem.ToString();
                richTextBox4.Text = r[1].ToString();
                richTextBox2.Text = r[2].ToString();
            }
            c.Close();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            s = comboBox2.Text;

            using (StreamReader fin = new StreamReader(s))
            {
                while (!fin.EndOfStream)
                {
                    string linie = fin.ReadLine();
                    nr++;
                }
                fin.Close();
            }

            using (StreamReader fin = new StreamReader(s))
            {
                while (!fin.EndOfStream)
                {
                    string linie = fin.ReadLine();
                    if (richTextBox1.Text.Contains(linie))
                        ok++;
                }
                fin.Close();
            }

            nota = (double)ok / nr * 10;
            MessageBox.Show(nota.ToString());

            c.Open();
            string update = "update utilizatori set punctaj = punctaj + @n where nume_utilizator = @tbn";
            SqlCommand cmd = new SqlCommand(update, c);
            cmd.Parameters.AddWithValue("n", nota);
            cmd.Parameters.AddWithValue("tbn", textBoxN.Text);
            cmd.ExecuteNonQuery();
            c.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(StreamReader fin = new StreamReader(s))
            {
                while(!fin.EndOfStream)
                {
                    string linie = fin.ReadLine();
                    richTextBox3.AppendText(linie + "\n");
                }
                fin.Close();
            }
        }
    }
}
