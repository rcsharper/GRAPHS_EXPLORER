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
    public partial class testC2S1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\BazaDeDate.mdf;Integrated Security=True");
        int i, j, ok, x, n, nr = 0, n1 = 0;
        int[] v1 = new int[100];
        //CheckBox[] c = new CheckBox[10];
        int[] v = new int[100];
        string s;
        intreb[] vect = new intreb[100];
        private static int nota1 = 0;
        int id = 0;
        public static string user = Autentificare.user;
        public testC2S1()
        {
            InitializeComponent();
        }
        struct intreb
        {
            public string test, raspuns, punctaj;
        };
        private void testC2S1_Load(object sender, EventArgs e)
        {
            for (i = 1; i <= 99; i++)
                v1[i] = 0;

            textBox1.Enabled = false;
            textBox1.Text = user.ToString();

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
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                s = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
            }
            StreamReader f = new StreamReader(s);
            while (!f.EndOfStream)
            {
                n1++;
                vect[n1].test = f.ReadLine();
                vect[n1].raspuns = f.ReadLine();
                vect[n1].punctaj = f.ReadLine();
            }
            Random r = new Random();
            for (i = 1; i <= 10; i++)
            {
                int ok = 0;

                while (ok == 0)
                {
                    x = r.Next(1, n1);
                    if (v1[x] == 0)
                    {
                        v1[x] = 1;
                        v[i] = x;
                        ok = 1;
                    }
                }
            }
            checkBox1.Text = vect[v[1]].test;
            checkBox2.Text = vect[v[2]].test;
            checkBox3.Text = vect[v[3]].test;
            checkBox4.Text = vect[v[4]].test;
            checkBox5.Text = vect[v[5]].test;
            checkBox6.Text = vect[v[6]].test;
            checkBox7.Text = vect[v[7]].test;
            checkBox8.Text = vect[v[8]].test;
            checkBox9.Text = vect[v[9]].test;
            checkBox10.Text = vect[v[10]].test;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && vect[v[1]].raspuns == "Da")
                nr++;
            if (checkBox2.Checked && vect[v[2]].raspuns == "Da")
                nr++;
            if (checkBox3.Checked && vect[v[3]].raspuns == "Da")
                nr++;
            if (checkBox4.Checked && vect[v[4]].raspuns == "Da")
                nr++;
            if (checkBox5.Checked && vect[v[4]].raspuns == "Da")
                nr++;
            if (checkBox6.Checked && vect[v[4]].raspuns == "Da")
                nr++;
            if (checkBox7.Checked && vect[v[4]].raspuns == "Da")
                nr++;
            if (checkBox8.Checked && vect[v[4]].raspuns == "Da")
                nr++;
            if (checkBox9.Checked && vect[v[4]].raspuns == "Da")
                nr++;
            if (checkBox10.Checked && vect[v[4]].raspuns == "Da")
                nr++;

            nota1 = nr * 3;

            con.Open();
            string insert = @"insert into catalog(id_elev,test,nota)values(@id_elev,@test,@nota)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("id_elev", id);
            cmd.Parameters.AddWithValue("test", "2");
            cmd.Parameters.AddWithValue("nota", nota1.ToString());
            SqlDataReader r = cmd.ExecuteReader();
            con.Close();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                s = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
            }

            using (StreamWriter f = File.AppendText("rezultate.txt"))
            {
                f.WriteLine(textBox1.Text + "|" + nota1.ToString() + "|" + DateTime.Now.ToString());
                f.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            testC2S2 f2 = new testC2S2();
            f2.Show();
        }
    }
}
