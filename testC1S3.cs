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
    public partial class testC1S3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\BazaDeDate.mdf;Integrated Security=True");
        int i = 0, nota3, n = 5, x;
        string s1;
        itemi[] v = new itemi[100];
        Label[] l = new Label[100];
        System.Windows.Forms.TextBox[] t = new System.Windows.Forms.TextBox[100];
        //TextBox[] t = new TextBox[100];
        int[] vf = new int[100];
        Random r = new Random();
        int[] v1 = new int[100];
        int id;
        public static string user = Autentificare.user;
        public testC1S3()
        {
            InitializeComponent();
        }

        private void testC1S3_Load(object sender, EventArgs e)
        {
            for (i = 1; i <= 99; i++)
                v1[i] = 0;

            textBox1.Enabled = false;
            textBox1.Text = user.ToString();
        }
        void getid()
        {
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
            getid();

            int i1;
            i = 0;

            using (StreamReader f = new StreamReader("C1S1.txt"))
            {
                while (!f.EndOfStream)
                {
                    v[i] = new itemi();
                    v[i].intrebare = f.ReadLine();
                    v[i].raspuns = f.ReadLine();
                    v[i].punctaj = f.ReadLine();
                    i++;
                }

                f.Close();
            }

            for (i1 = 0; i1 < n; i1++)
            {
                int ok = 1;
                while (ok == 1)
                {
                    x = r.Next(0, i);
                    if (vf[x] == 0)
                    {
                        ok = 0;
                        v1[i1] = x;
                        vf[x]++;
                    }
                }
            }
            for (int j = 0; j < n; j++)
            {
                l[j] = new Label();
                l[j].Text = v[v1[j]].intrebare;
                this.l[j].AutoSize = true;
                l[j].Location = new Point(400, 200 + j * 40);
                this.Controls.Add(l[j]);
                //t[j] = new TextBox();
                t[j] = new System.Windows.Forms.TextBox();
                t[j].Location = new Point(300, 200 + j * 40);
                this.Controls.Add(t[j]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nota3 = 0;

            for (int j = 0; j < n; j++)
            {

                if (string.Compare(t[j].Text.Trim(), v[v1[j]].raspuns.Trim()) == 0)
                    nota3++;
            }
            
            MessageBox.Show(nota3.ToString());
            con.Open();
            string insert = @"insert into catalog(id_elev,test,nota)values(@id_elev,@test,@nota)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("id_elev", id);
            cmd.Parameters.AddWithValue("test", "1");
            cmd.Parameters.AddWithValue("nota", nota3.ToString());
            SqlDataReader r = cmd.ExecuteReader();
            con.Close();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            meniu f2 = new meniu();
            f2.Show();
        }
    }
}
