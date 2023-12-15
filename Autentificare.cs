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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Graphs_Explorer
{
    public partial class Autentificare : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\BazaDeDate.mdf;Integrated Security=True");
        bool ok1 = false, ok2 = false;
        private int i = 0;
        private string[] v;
        public static string user;
        public Autentificare()
        {
            InitializeComponent();
        }

        private void Autentificare_Load(object sender, EventArgs e)
        {
            
            timer1.Start();

            

            linkLabel1.Visible = false;
            linkLabel2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = textBox1.Text;
            c.Open();
            string select = "select * from utilizatori where nume_utilizator=@t1";
            SqlCommand cmd = new SqlCommand(select, c);
            cmd.Parameters.AddWithValue("t1", textBox1.Text);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read() == true)
            {
                ok1 = true;
            }
            else
            {
                MessageBox.Show("Numele de utilizator este invalid!");

                linkLabel1.Visible = true;
                linkLabel2.Visible = false;
            }
            c.Close();

            c.Open();
            string select1 = "select * from utilizatori where parola=@p1";
            SqlCommand cmd1 = new SqlCommand(select1, c);
            cmd1.Parameters.AddWithValue("p1", textBox2.Text);
            SqlDataReader r1 = cmd.ExecuteReader();
            if (r1.Read() == true)
            {
                ok2 = true;
            }
            else
            {
                MessageBox.Show("Parola este invalida!");

                linkLabel1.Visible = true;
                linkLabel2.Visible = false;
            }
            c.Close();

            if (ok1 == true && ok2 == true)
            {
                meniu f2 = new meniu();
                f2.Show();

                ok1 = false;
                ok2 = false;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//inregistrareLinkLabel

            Inregistrare f2 = new Inregistrare();
            f2.Show();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaginaStart f2 = new PaginaStart();
            f2.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = (char)0;
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
