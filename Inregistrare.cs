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
    public partial class Inregistrare : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\BazaDeDate.mdf;Integrated Security=True");
        string user;
        string textFileName;
        int nr = 0;
        bool ok1 = false, ok2 = false;
        string fileName;
        public Inregistrare()
        {
            InitializeComponent();
        }

        private void Inregistrare_Load(object sender, EventArgs e)
        {//Form -> FormBorderStyle = FixedToolWindow

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //inregistrare
            string parola1 = textBox5.Text;
            string parola2 = textBox6.Text;
            if (parola1 != parola2)
            {
                MessageBox.Show("Parolele introduse NU sunt identice!");

            }
            else
            {
                ok1 = true;
            }
            if (ok1 == true && ok2 == true)
            {
                c.Open();
                string insert = "insert into utilizatori(nume_utilizator,email,nume,prenume,parola,data_nasterii) values(@nume_utilizator,@email,@nume,@prenume,@parola,@data_nasterii)";
                SqlCommand cmd = new SqlCommand(insert, c);
                cmd.Parameters.AddWithValue("nume_utilizator", textBox1.Text);
                cmd.Parameters.AddWithValue("email", textBox2.Text);
                cmd.Parameters.AddWithValue("nume", textBox3.Text);
                cmd.Parameters.AddWithValue("prenume", textBox4.Text);
                cmd.Parameters.AddWithValue("parola", textBox5.Text);
                cmd.Parameters.AddWithValue("data_nasterii", dateTimePicker1.Value);
                SqlDataReader r = cmd.ExecuteReader();
                c.Close();
            
                meniu f2 = new meniu();
                f2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Adresa de email sau parolele sunt invalide!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaginaStart f2 = new PaginaStart();
            f2.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            bool ok = false;
            string email = textBox2.Text;
            if (email.Contains("@") && email.Contains("."))
            {
                ok = true;
                ok2 = true;
            }
            if (ok == false)
            {
                MessageBox.Show("Adresa de email este invalida!");

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
