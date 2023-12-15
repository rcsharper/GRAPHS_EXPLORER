# GRAPHS_EXPLORER
GRAPHS_EXPLORER
	Graphs_Explorer este o aplicatie realizata cu scopul intelegerii capitolului Grafuri – clasa XI.
Structura:
Aplicatia este realizata in limbajul de programare C#, Visual Studio 2022 si contine:
•	Teorie, programe functionale, aplicatii si teste de finalizare a subcapitolelor.
•	Aplicatia este construita pe algoritmi intalniti des in capitolul GRAFURILOR
•	Baza de date foloseste SQL SERVER pentru securitate
•	O parte din aplicatii sunt structurate pe baza algoritmului de  BACKTRACKING.
•	Grafurile sunt realizate prin intermediul clasei GRAPHICS (Clasa Graphics face parte din spațiul de nume System.Drawing și oferă un set puternic de metode și proprietăți pentru desenarea graficelor pe o varietate de suprafețe, cum ar fi formulare, controale și imagini.)
Am ales sa folosesc GRAPHICS, nu doar pentru ca imi este o tema mai cunoscuta, dar si pentru o memorie minima – astfel pot crea cate aplicatii doresc fara sa imi fac griji pentru stocarea de memorie.
1.	Autentificare
	Acest formular are scopul de a loga utilizatorii prin intermediul numelui de utilizator si a parolei.
2.	Inregistrare
	In cazul in care utilizatorul nu si-a creat inca un cont, acesta se poate intoarce de la logare sau pagina de start pentru a-si introduce datele necesare. 
	De asemenea, am adaugat si o serie de 3 intrebari personale cu rolul de a-si verifica identitatea in cazul recuperarii sau schimbarii parolei.
3.	 Meniu
	Meniul este structurat in mai multe componente:
o	CAPITOLUL 1 – GRAFURI NEORIENTATE
	
o	CAPITOLUL 2 – GRAFURI ORIENTATE
	
o	CAPITOLUL 3 – ARBORI
	
o	APLICATII 
	Aceasta componenta a meniului ii ofera utilizatorului diverse probleme dintre care sa aleaga si sa le rezolve. Elevul isi poate introduce rezolvarea si va primi la final punctajul primit pentru codul introdus, punctaj ce va fi adunat la cel introdus de dinainte in baza de date.
o	CREARE SI PARCURGERE GRAF 
	Prezinta diverse programe care lasa elevul sa isi creeze graful, iar apoi, cu ajutorul metodei BACKTRACKING, sa il parcurga si sa ii afiseze rezultaul in functie de scopul sau.
o	TESTE
	Testele apar la final de subcapitol cu scopul de verifica cunostintele acumulate de catre elev.
Pentru următoarele aplicații, pentru salvarea și prelucrarea datelor am folosit și fisiere test, dar și o bază de date în sqlServer care cuprinde tabelele utilizatori(Id, nume_utilizator, email, nume, prenume, parola, data_nasterii, punctaj), catalog (Id, id_elev, test, nota) si aplicatii (Id, nume_aplicatie, cerinta, capitol, punctaj, date, fisier).


Autentificare

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

Inregistrare

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

Meniu

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class meniu : Form
    {
        public bool okgn, okgo, oka;
        public static string user = Autentificare.user;
        public meniu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void meniu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            textBox1.Text = user.ToString();

        }
        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //PAGINA DE PROFIL
        private void pAGINADEPROFILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //paginaDeProfil f2 = new paginaDeProfil();
            //f2.Show();
        }
        //GRAFURI NEORIENTATE
        private void iNTRODUCEREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriNeorientate f2 = new grafuriNeorientate();
            f2.Show();
        }

        private void cALCULGRADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriNeorientateCalculGrad f2 = new grafuriNeorientateCalculGrad();
            f2.Show();
        }

        private void mATRICEALANTURILORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriNeorientateMatriceaLanturilor f2 = new grafuriNeorientateMatriceaLanturilor();
            f2.Show();
        }

        private void cICLURIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cICLURILUNGIMELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriNeorientateCicluriDeLungimel f2 = new grafuriNeorientateCicluriDeLungimel();
            f2.Show();
        }

        private void gRAFULEULERIANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriNeorientateGrafulEulerian f2 = new grafuriNeorientateGrafulEulerian();
            f2.Show();
        }

        private void cICLURIEULERIENEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriNeorientateCicluriEuleriene f2 = new grafuriNeorientateCicluriEuleriene();
            f2.Show();
        }

        private void gRAFULHAMILTONIANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriNeorientateGrafulHamiltonian f2 = new grafuriNeorientateGrafulHamiltonian();
            f2.Show();
        }

        private void cOMPONENTECONEXEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComponenteConexe f2 = new ComponenteConexe();
            f2.Show();
        }
        private void cOMPONENTACONEXAMAXIMAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            grafuriOrientateComponentaConexaMaxima f2 = new grafuriOrientateComponentaConexaMaxima();
            f2.Show();
        }
        private void tESTC1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testC1S1 f2 = new testC1S1();
            f2.Show();
            if (okgn == false)
                okgn = true;
        }

       

        //GRAFURI ORIENTATE
        private void iNTRODUCEREToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            grafuriOrientate f2 = new grafuriOrientate();
            f2.Show();
        }
        private void cALCULGRADToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            grafuriOrientateCalculGrad f2 = new grafuriOrientateCalculGrad();
            f2.Show();
        }
        private void aPLICATIIDEBAZAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriOrientateBaza f2 = new grafuriOrientateBaza();
            f2.Show();
        }
        private void mATRICEADEADIACENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriOrientateMatriceaDeAdiacenta f2 = new grafuriOrientateMatriceaDeAdiacenta();
            f2.Show();
        }

        private void mATRICEADRUMURILORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriOrientateMatriceaDrumurilor f2 = new grafuriOrientateMatriceaDrumurilor();
            f2.Show();
        }

        private void cICLURICAREINCEPCUKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriOrientateCicluriCareIncepCuk f2 = new grafuriOrientateCicluriCareIncepCuk();
            f2.Show();
        }

        private void cOMPONENTECONEXEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComponenteConexe f2 = new ComponenteConexe();
            f2.Show();
        }

        private void cOMPONENTACONEXAMAXIMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriOrientateComponentaConexaMaxima f2 = new grafuriOrientateComponentaConexaMaxima();
            f2.Show();
        }
        private void cOMPONENTATARECONEXAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafuriOrientateComponentaTareConexa f2 = new grafuriOrientateComponentaTareConexa();
            f2.Show();
        }
        private void tESTC2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testC3S3 f2 = new testC3S3();
            f2.Show();
            if(okgo == false)
            {
                okgo = true;
            }
        }

        //ARBORI
        private void iNTRODUCEREToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            arbori f2 = new arbori();
            f2.Show();
        }

        private void vECTORTATIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arboriVectorTati f2 = new arboriVectorTati();
            f2.Show();
        }

        private void fRUNZEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            arboriFrunze f2 = new arboriFrunze();
            f2.Show();
        }

        private void lANTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            arboriLant f2 = new arboriLant();
            f2.Show();
        }
        private void tESTC3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            testC3S3 f2 = new testC3S3();
            f2.Show();
            if (oka == false)
            {
                oka = true;
            }
        }


        //CREARE GRAF
        private void lANTURIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graf f2 = new graf();
            f2.Show();
        }

        private void cALCULGRADToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            gradGraf f2 = new gradGraf();
            f2.Show();
        }

       
        private void mATRICEADRUMURILORToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            matriceaDrumurilor f2 = new matriceaDrumurilor(); 
            f2.Show();
        }
        //APLICATII
        private void aPLICATIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aplicatii f2 = new aplicatii();
            f2.Show();
        }

        //TESTE
        private void tESTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void tESTC1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            testC1S1 f2 = new testC1S1();
            f2.Show();
        }

        private void sUBIECTUL1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testC1S1 f2 = new testC1S1();
            f2.Show();
        }

        private void sUBIECTUL2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testC1S2 f2 = new testC1S2();
            f2.Show();
        }

        private void sUBIECTUL3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testC1S3 f2 = new testC1S3();
            f2.Show();
        }

       
        private void tESTC2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            testC2S1 f2 = new testC2S1();
            f2.Show();
        }
        private void sUBIECTUL1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            testC2S1 f2 = new testC2S1();
            f2.Show();
        }

        private void sUBIECTUL2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            testC2S2 f2 = new testC2S2();
            f2.Show();
        }

        private void sUBIECTUL3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            testC2S3 f2 = new testC2S3();
            f2.Show();
        }


        private void tESTC3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testC3S1 f2 = new testC3S1();
            f2.Show();
        }

        private void sUBIECTUL1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            testC3S1 f2 = new testC3S1();
            f2.Show();
        }

        private void sUBIECTUL2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            testC3S2 f2 = new testC3S2();
            f2.Show();
        }

        private void sUBIECTUL3ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            testC3S3 f2 = new testC3S3();
            f2.Show();
        }


        private void tESTFINALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testFinalRadioPanel f2 = new testFinalRadioPanel();
            f2.Show();
        }
        private void tESTRADIOPANELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testFinalRadioPanel f2 = new testFinalRadioPanel();
            f2.Show();
        }

        private void tESTCHECKBACKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testFinalCheckBack f2 = new testFinalCheckBack();
            f2.Show();
        }

        //AJUTOR
        private void aJUTORToolStripMenuItem_Click(object sender, EventArgs e)
        {
         } 
}
GRAFURI NEORIENTATE

Introducere
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class grafuriNeorientate : Form
    {
        Graphics g;
        int nr = 0;
        public grafuriNeorientate()
        {
            InitializeComponent();
        }

        private void grafuriNeorientate_Load(object sender, EventArgs e)
        {
            titluLabel.Visible = true;
            label6.Visible = true;
            label1.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            button1.Visible = false;

            panel1.Visible = false;
            panel2.Visible = false;

            label7.Visible = false;

            this.Size = new Size(1210, 715);

            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
        }

        private void grafuriNeorientate_Click(object sender, EventArgs e)
        {
            nr++;
            if (nr == 1)
            {
                this.Size = new Size(1350, 715);
                titluLabel.Visible = false;
                label6.Visible = false;
                label1.Visible = true;

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                button1.Visible = true;

                panel1.Visible = true;
                panel2.Visible = true;

                label7.Visible = true;

                afis1(1);
            }
            if(nr == 2)
            {
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;

                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
            }
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
            g.DrawEllipse(p, 150, 100, 50, 50);//1
            g.DrawEllipse(p, 200, 300, 50, 50);//2
            g.DrawEllipse(p, 100, 250, 50, 50);//3
            g.DrawEllipse(p, 300, 150, 50, 50);//4
            g.DrawEllipse(p, 450, 100, 50, 50);//5
            g.DrawEllipse(p, 550, 200, 50, 50);//6
            g.DrawEllipse(p, 350, 350, 50, 50);//7

            g.DrawLine(p, 180, 150, 215, 300);//1 2
            g.DrawLine(p, 215, 300, 145, 285);//2 3
            g.DrawLine(p, 215, 300, 308, 192);//2 4
            g.DrawLine(p, 145, 258, 300, 185);//3 4

            g.DrawLine(p, 345, 160, 450, 130);//4 5
            g.DrawLine(p, 330, 200, 360, 350);//4 7
            g.DrawLine(p, 495, 138, 555, 205);//5 6
            g.DrawLine(p, 555, 235, 395, 360);//6 7


            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 113.0F;
            float x2 = 213.0F; float y2 = 313.0F;
            float x3 = 113.0F; float y3 = 263.0F;
            float x4 = 313.0F; float y4 = 163.0F;
            float x5 = 463.0F; float y5 = 113.0F;
            float x6 = 563.0F; float y6 = 213.0F;
            float x7 = 363.0F; float y7 = 363.0F;

            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            //Thread.Sleep(1000);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            grafuriNeorientateCalculGrad f2 = new grafuriNeorientateCalculGrad();
            f2.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
Calcul grad
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
    public partial class grafuriNeorientateCalculGrad : Form
    {
        int[,] A = new int[20, 20];
        int[] L = new int[20];
        int n, x, y, cnt, i, j, m;
        int grad = 0;
        int u = 0;
        int a, b, nr = 0, nrText = 0, mcx, mcy;
        Pen p = new Pen(Color.Black, 2);
        string fileName;
        bool ok1 = false, ok2 = false, ok3 = false;
        int mcx1 = 0, mcx2 = 0, mcy1 = 0, mcy2 = 0;
        bool okLinie;
        Graphics g;
        public grafuriNeorientateCalculGrad()
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
            using (StreamReader fin = new StreamReader("TextFileCalculGraf.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n.ToString() + "\n" + m.ToString() + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    A[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    A[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (i = 1; i <= n; i++)
            {
                grad = 0;
                for (j = 1; j <= n; j++)
                    grad = grad + A[i, j];
                richTextBox1.AppendText("Nodul " + i.ToString() + " are gradul " + grad.ToString() + " ." + "\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("\n");
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    richTextBox1.AppendText(A[i, j].ToString());
                }
                richTextBox1.AppendText("\n");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            grafuriNeorientateMatriceaLanturilor f2 = new grafuriNeorientateMatriceaLanturilor();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateCalculGrad f2 = new codGrafuriNeorientateCalculGrad();
            f2.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //desen
            afis1(1);
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

            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);

            //Thread.Sleep(1000);
        }
        private void grafuriNeorientateCalculGrad_Load(object sender, EventArgs e)
        {

        }
    }
}
Matricea lanturilor
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
    public partial class grafuriNeorientateMatriceaLanturilor : Form
    {
        int[,] a = new int[10, 10];
        int[] x = new int[10];
        int[] smax = new int[10];
        int[] p = new int[10];
        int i, f, n, m, k, lmax;
        Graphics g;
        public grafuriNeorientateMatriceaLanturilor()
        {
            InitializeComponent();
        }

        private void grafuriNeorientateMatriceaLanturilor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("MatriceaLanturilor.txt"))
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
                    a[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                }
                richTextBox2.AppendText("\n");
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void rw()
        {
            int i, j, k;
            for (k = 1; k <= n; k++)
                for (i = 1; i <= n; i++)
                    for (j = 1; j <= n; j++)
                        if (i != j)
                            if (a[i, j] == 0)
                                a[i, j] = a[i, k] * a[k, j];
        }
        void afis()
        {
            for (int i = 1; i <= n; i++)
            {
                richTextBox1.AppendText("\n");
                for (int
                j = 1; j <= n; j++)
                    richTextBox1.AppendText(a[i, j].ToString() + " ");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            rw();
            afis();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 450, 200, 50, 50);//1
            g.DrawEllipse(p, 300, 300, 50, 50);//2
            g.DrawEllipse(p, 450, 400, 50, 50);//3
            g.DrawEllipse(p, 550, 300, 50, 50);//4
            g.DrawEllipse(p, 650, 200, 50, 50);//5
            g.DrawEllipse(p, 650, 400, 50, 50);//6
            g.DrawEllipse(p, 850, 400, 50, 50);//7
            g.DrawEllipse(p, 850, 200, 50, 50);//8
            g.DrawEllipse(p, 1000, 300, 50, 50);//9

            g.DrawLine(p, 457, 235, 345, 305);//1 2
            g.DrawLine(p, 475, 250, 475, 400);//1 3
            g.DrawLine(p, 500, 225, 650, 225);//1 5

            g.DrawLine(p, 340, 345, 450, 412);//2 3
            g.DrawLine(p, 491, 405, 558, 345);//3 4
            g.DrawLine(p, 500, 425, 650, 425);//3 6

            g.DrawLine(p, 590, 304, 655, 242);//4 5
            g.DrawLine(p, 700, 225, 850, 225);//5 8
            g.DrawLine(p, 700, 425, 850, 425);//6 7
            g.DrawLine(p, 875, 400, 875, 250);//7 8

            g.DrawLine(p, 896, 411, 1006, 341);//7 9
            g.DrawLine(p, 896, 237, 1003, 311);//8 9

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 463.0F; float y1 = 213.0F;
            float x2 = 313.0F; float y2 = 313.0F;
            float x3 = 463.0F; float y3 = 413.0F;
            float x4 = 563.0F; float y4 = 313.0F;
            float x5 = 663.0F; float y5 = 213.0F;
            float x6 = 663.0F; float y6 = 413.0F;
            float x7 = 863.0F; float y7 = 413.0F;
            float x8 = 863.0F; float y8 = 213.0F;
            float x9 = 1013.0F; float y9 = 313.0F;
            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);
            g.DrawString("9", drawFont, drawBrush, x9, y9);
            //Thread.Sleep(1000);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateMatriceaLanturilor f2 = new codGrafuriNeorientateMatriceaLanturilor();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grafuriNeorientateCicluriDeLungimel f2 = new grafuriNeorientateCicluriDeLungimel();
            f2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
    }
}

Cicluri lungime l
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class grafuriNeorientateCicluriDeLungimel : Form
    {
        int[] X = new int[20];
        int[] P = new int[20];
        int i, j, n, l;
        Graphics g;
        public grafuriNeorientateCicluriDeLungimel()
        {
            InitializeComponent();
        }

        private void grfauriNeorientateCicluriDeLungimel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox1.Text);
            l = int.Parse(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            back(1);
        }
        void back(int k)
        {
            for (int i = 1; i <= n; i++)
                if (P[i] != 1)
                {
                    X[k] = i;
                    P[i] = 1;
                    if (k == l) afisare();
                    else back(k + 1);
                    P[i] = 0;
                }
        }
       
            
        
        void afisare()
        {
            for (int i = 1; i <= l; i++)
                richTextBox1.AppendText(X[i].ToString() + " ");
            richTextBox1.AppendText(X[1] + "\n");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateCicluriDeLungimel f2 = new codGrafuriNeorientateCicluriDeLungimel();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grafuriNeorientateGrafulEulerian f2 = new grafuriNeorientateGrafulEulerian();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 150, 100, 50, 50);//1
            g.DrawEllipse(p, 200, 300, 50, 50);//2
            g.DrawEllipse(p, 100, 250, 50, 50);//3
            g.DrawEllipse(p, 300, 150, 50, 50);//4
            g.DrawEllipse(p, 450, 100, 50, 50);//5
            g.DrawEllipse(p, 550, 200, 50, 50);//6
            g.DrawEllipse(p, 350, 350, 50, 50);//7

            g.DrawLine(p, 180, 150, 215, 300);//1 2
            g.DrawLine(p, 215, 300, 145, 285);//2 3
            g.DrawLine(p, 215, 300, 308, 192);//2 4
            g.DrawLine(p, 145, 258, 300, 185);//3 4

            g.DrawLine(p, 345, 160, 450, 130);//4 5
            g.DrawLine(p, 330, 200, 360, 350);//4 7
            g.DrawLine(p, 495, 138, 555, 205);//5 6
            g.DrawLine(p, 555, 235, 395, 360);//6 7


            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 113.0F;
            float x2 = 213.0F; float y2 = 313.0F;
            float x3 = 113.0F; float y3 = 263.0F;
            float x4 = 313.0F; float y4 = 163.0F;
            float x5 = 463.0F; float y5 = 113.0F;
            float x6 = 563.0F; float y6 = 213.0F;
            float x7 = 363.0F; float y7 = 363.0F;

            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            //Thread.Sleep(1000);
        }
    }
}

Graful eulerian
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class grafuriNeorientateGrafulEulerian : Form
    {
        int[,] A = new int[20, 20];
        int[] G = new int[20];
        int[] P = new int[20];
        int n, m, i, j;
        SolidBrush br = new SolidBrush(Color.SkyBlue);
        Graphics g;
        public grafuriNeorientateGrafulEulerian()
        {
            InitializeComponent();
        }

        private void grafuriNeorientateGrafulEulerian_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileGrafulEulerian.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n + "\n" + m + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    A[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    A[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                   
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
            //richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 150, 125, 50, 50);
            g.DrawEllipse(p, 300, 50, 50, 50);
            g.DrawEllipse(p, 300, 200, 50, 50);
            g.DrawEllipse(p, 500, 50, 50, 50);
            g.DrawEllipse(p, 500, 200, 50, 50);
            g.DrawEllipse(p, 400, 300, 50, 50);
            //AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            //p.CustomEndCap = bigArrow;
            g.DrawLine(p, 200, 150, 300, 75);
            g.DrawLine(p, 350, 75, 500, 75);
            g.DrawLine(p, 525, 100, 525, 200);
            g.DrawLine(p, 500, 225, 350, 225);
            g.DrawLine(p, 350, 225, 425, 300);
            g.DrawLine(p, 425, 300, 500, 225);
            g.DrawLine(p, 525, 200, 350, 75);
            g.DrawLine(p, 325, 100, 325, 200);
            g.DrawLine(p, 325, 200, 200, 150);
            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 138.0F;
            float x2 = 313.0F; float y2 = 63.0F;
            float x3 = 313.0F; float y3 = 213.0F;
            float x4 = 513.0F; float y4 = 63.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 413.0F; float y6 = 313.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            //Thread.Sleep(1000);
        }
        void afis2(int i)
        {
            if (i <= 10)
            {
                desen2(i);
                afis2(i + 1);
            }
        }
        void desen2(int i)
        {
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Red, 2);
            g.DrawEllipse(p, 150, 125, 50, 50);
            g.DrawEllipse(p, 300, 50, 50, 50);
            g.DrawEllipse(p, 300, 200, 50, 50);
            g.DrawEllipse(p, 500, 50, 50, 50);
            g.DrawEllipse(p, 500, 200, 50, 50);
            g.DrawEllipse(p, 400, 300, 50, 50);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p1.CustomEndCap = bigArrow;
            if (i <= 10)
            {
                if (i == 1)
                    g.DrawLine(p1, 200, 150, 300, 75);
                if (i == 2)
                    g.DrawLine(p1, 350, 75, 500, 75);
                if (i == 3)
                    g.DrawLine(p1, 525, 100, 525, 200);
                if (i == 4)
                    g.DrawLine(p1, 500, 225, 350, 225);
                if (i == 5)
                    g.DrawLine(p1, 350, 225, 425, 300);
                if (i == 6)
                    g.DrawLine(p1, 425, 300, 500, 225);
                if (i == 7)
                    g.DrawLine(p1, 525, 200, 350, 75);
                if (i == 8)
                    g.DrawLine(p1, 325, 100, 325, 200);
                if (i == 9)
                    g.DrawLine(p1, 325, 200, 200, 150);
            }
            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 138.0F;
            float x2 = 313.0F; float y2 = 63.0F;
            float x3 = 313.0F; float y3 = 213.0F;
            float x4 = 513.0F; float y4 = 63.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 413.0F; float y6 = 313.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            Thread.Sleep(1000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = 1;
            afis2(1);
        }
        int grad(int k)//calculeaza gradul varfului k
        {
            int s = 0;
            for (int i = 1; i <= n; i++)
                if (A[k, i] == 1) s++;
            return s;
        }

        void DF(int s)//parcurge graful din varful s si marcheaza varfurile accesibile
        {
            P[s] = 1;
            for (int i = 1; i <= n; i++)
                if (A[s, i] == 1 && P[i] == 0)
                    DF(i);
        }

        int conex()//conexitatea grafului
        {
            DF(1);
            for (int i = 1; i <= n; i++)
                if (P[i] == 0) return 0;
            return 1;
        }


        int euler()//daca este eulerian
        {
            if (conex() == 0) return 0;//conex
            for (int i = 1; i <= n; i++)
                if (G[i] % 2 == 1) return 0;//si toate gradele pare
            return 1;
        }

        void ciclu_eulerian(int k)//construieste un ciclu eulerian
        {
            int maxx = 0, nmax = 0;
            richTextBox1.AppendText(k.ToString() + " "); //afiseaza varful curent
            for (int i = 1; i <= n; i++)//cauta varful urmator cu grad maxim
            {
                if (A[k, i] == 1)
                    if (G[i] > maxx)
                    {
                        maxx = grad(i);
                        nmax = i;
                    }
            }
            if (nmax != 0)
            {
                A[k, nmax] = A[nmax, k] = 0;//sterge muchia
                G[k]--;//scade gradele
                G[nmax]--;
                ciclu_eulerian(nmax);//merge in varful urmator
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            for (int i = 1; i <= n; i++) G[i] = grad(i);
            if (euler() == 1)
            {
                richTextBox1.AppendText("nu este eulerian");
                //ciclu_eulerian(1);
            }
            else
                richTextBox1.AppendText("este eulerian");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grafuriNeorientateCicluriEuleriene f2 = new grafuriNeorientateCicluriEuleriene();
            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateGrafulEulerian f2 = new codGrafuriNeorientateGrafulEulerian();
            f2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
    }
}

Cicluri euleriene
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
    public partial class grafuriNeorientateCicluriEuleriene : Form
    {
        int[,] a = new int[20, 20];
        int[] L = new int[20];
        int n, i, j, m;
        Graphics g;
        public grafuriNeorientateCicluriEuleriene()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileGrafulEulerian.txt"))
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
        void rw()
        {
            int i, j, k;
            for (k = 1; k <= n; k++)
                for (i = 1; i <= n; i++)
                    for (j = 1; j <= n; j++)
                        if (i != j)
                            if (a[i, j] == 0)
                                a[i, j] = a[i, k] * a[k, j];
        }


        void afis()
        {
            richTextBox1.AppendText("Matricea drumurilor acestui graf este : " + "\n" + "\n");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                    richTextBox1.AppendText(a[i, j].ToString() + " ");
                richTextBox1.AppendText("\n");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateCicluriEuleriene f2 = new codGrafuriNeorientateCicluriEuleriene();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriNeorientateGrafulHamiltonian f2 = new grafuriNeorientateGrafulHamiltonian();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            rw();
            afis();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 150, 125, 50, 50);
            g.DrawEllipse(p, 300, 50, 50, 50);
            g.DrawEllipse(p, 300, 200, 50, 50);
            g.DrawEllipse(p, 500, 50, 50, 50);
            g.DrawEllipse(p, 500, 200, 50, 50);
            g.DrawEllipse(p, 400, 300, 50, 50);
            //AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            //p.CustomEndCap = bigArrow;
            g.DrawLine(p, 200, 150, 300, 75);
            g.DrawLine(p, 350, 75, 500, 75);
            g.DrawLine(p, 525, 100, 525, 200);
            g.DrawLine(p, 500, 225, 350, 225);
            g.DrawLine(p, 350, 225, 425, 300);
            g.DrawLine(p, 425, 300, 500, 225);
            g.DrawLine(p, 525, 200, 350, 75);
            g.DrawLine(p, 325, 100, 325, 200);
            g.DrawLine(p, 325, 200, 200, 150);
            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 138.0F;
            float x2 = 313.0F; float y2 = 63.0F;
            float x3 = 313.0F; float y3 = 213.0F;
            float x4 = 513.0F; float y4 = 63.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 413.0F; float y6 = 313.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            //Thread.Sleep(1000);
        }
    
        private void grafuriNeorientateCicluriEuleriene_Load(object sender, EventArgs e)
        {

        }
    }
}
Graful hamiltonian
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
                richTextBox1.AppendText("Da");
            else
                richTextBox1.AppendText("Nu");
        }
        
       private void button4_Click(object sender, EventArgs e)
        {
            grafuriNeorientateComponenteConexe f2 = new grafuriNeorientateComponenteConexe();
            f2.Show();
        }

    }
}
Componente conexe
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
    public partial class grafuriNeorientateComponenteConexe : Form
    {
        int[,] a = new int[20, 20];
        int[] x = new int[20];
        int[] p = new int[20];
        int n, m, i, j;
        Graphics g;
        public grafuriNeorientateComponenteConexe()
        {
            InitializeComponent();
        }

        private void grafuriNeorientateComponenteConexe_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileCompConexe.txt"))
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
                    //d[int.Parse(v[0].Trim().ToString())]++;
                    //d[int.Parse(v[0].Trim().ToString())]++;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void bf(int k)
        {
            int i, s, d;
            x[1] = k;
            p[k] = 1;
            s = d = 1;
            while (s <= d)
            {
                for (i = 1; i <= n; i++)
                    if (a[x[s], i] == 1 && p[i] != 1)
                    {
                        d++;
                        x[d] = i;
                        p[i] = 1;
                    }
                s++;
            }
            for (i = 1; i <= d; i++)
                richTextBox1.AppendText(x[i].ToString() + " ");
            richTextBox1.AppendText("\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            int i;
            for (i = 1; i <= n; i++)
                if (p[i] != 1)
                    bf(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriNeorientateComponentaConexaMaxima f2 = new grafuriNeorientateComponentaConexaMaxima();
            f2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
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
            g.DrawEllipse(p, 300, 200, 50, 50);//1
            g.DrawEllipse(p, 300, 450, 50, 50);//2
            g.DrawEllipse(p, 450, 350, 50, 50);//3
            g.DrawEllipse(p, 550, 200, 50, 50);//4
            g.DrawEllipse(p, 700, 250, 50, 50);//5
            g.DrawEllipse(p, 600, 400, 50, 50);//6
            g.DrawEllipse(p, 700, 500, 50, 50);//7
            g.DrawEllipse(p, 750, 400, 50, 50);//8

            g.DrawLine(p, 325, 250, 325, 450);//1 2
            g.DrawLine(p, 350, 225, 550, 225);//1 4
            g.DrawLine(p, 342, 455, 452, 385);//2 3
            g.DrawLine(p, 490, 355, 560, 245);//3 4
            g.DrawLine(p, 645, 440, 705, 510);//6 7
            g.DrawLine(p, 730, 500, 765, 445);//7 8

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 313.0F; float y1 = 213.0F;
            float x2 = 313.0F; float y2 = 463.0F;
            float x3 = 463.0F; float y3 = 363.0F;
            float x4 = 563.0F; float y4 = 213.0F;
            float x5 = 713.0F; float y5 = 263.0F;
            float x6 = 613.0F; float y6 = 413.0F;
            float x7 = 713.0F; float y7 = 513.0F;
            float x8 = 763.0F; float y8 = 413.0F;
            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);
            //Thread.Sleep(1000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateComponenteConexe f2 = new codGrafuriNeorientateComponenteConexe();
            f2.Show();
        }
    }
}
Componenta conexa maxima
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
    public partial class grafuriNeorientateComponentaConexaMaxima : Form
    {
        int[,] a = new int[10, 10];
        int[] suc = new int[100];
        int[] pred = new int[100];
        int n, m, nrc, i, j;
        int k, mk = 0, c, mc;
        Graphics g;

        public grafuriNeorientateComponentaConexaMaxima()
        {
            InitializeComponent();
        }

        private void grafuriNeorientateComponentaConexaMaxima_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriNeorientateComponentaConexaMaxima f2 = new codGrafuriNeorientateComponentaConexaMaxima();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileCompConexe.txt"))
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
                    a[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                    //ge[int.Parse(v[0].Trim().ToString())]++;
                    //gi[int.Parse(v[0].Trim().ToString())]++;
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
        
        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 700, 250, 50, 50);//5
            g.DrawEllipse(p, 600, 400, 50, 50);//6
            g.DrawEllipse(p, 700, 500, 50, 50);//7
            g.DrawEllipse(p, 750, 400, 50, 50);//8

            g.DrawLine(p, 325, 250, 325, 450);//1 2
            g.DrawLine(p, 350, 225, 550, 225);//1 4
            g.DrawLine(p, 342, 455, 452, 385);//2 3
            g.DrawLine(p, 490, 355, 560, 245);//3 4
            g.DrawLine(p, 645, 440, 705, 510);//6 7
            g.DrawLine(p, 730, 500, 765, 445);//7 8

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 313.0F; float y1 = 213.0F;
            float x2 = 313.0F; float y2 = 463.0F;
            float x3 = 463.0F; float y3 = 363.0F;
            float x4 = 563.0F; float y4 = 213.0F;
            float x5 = 713.0F; float y5 = 263.0F;
            float x6 = 613.0F; float y6 = 413.0F;
            float x7 = 713.0F; float y7 = 513.0F;
            float x8 = 763.0F; float y8 = 413.0F;
            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);
            //Thread.Sleep(1000);
        }
    }
}


GRAFURI ORIENTATE

INTRODUCERE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class ComponenteConexe : Form
    {
        int i, j, n=8, m=10;
        Graphics g;
        public ComponenteConexe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//desenare
            afis1(1);
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
            g.DrawEllipse(p, 200, 200, 50, 50);
            g.DrawEllipse(p, 350, 200, 50, 50);
            g.DrawEllipse(p, 200, 350, 50, 50);
            g.DrawEllipse(p, 350, 350, 50, 50);

            g.DrawEllipse(p, 500, 200, 50, 50);
            g.DrawEllipse(p, 650, 200, 50, 50);
            g.DrawEllipse(p, 500, 350, 50, 50);
            g.DrawEllipse(p, 650, 350, 50, 50);

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            //g.DrawLine(p, );

            //g.DrawLine(p, );//1 3 sau 3 1
            /*
            float startAngle = 0.0F;
            float sweepAngle = 270.0F;
            Rectangle rect = new Rectangle(225, 250, 50, 200);
            // Draw arc to screen.
            g.DrawArc(p, rect, startAngle, sweepAngle);
           */

            g.DrawLine(p, 250, 225, 350, 225);//1 2
            g.DrawLine(p, 375, 350, 375, 250);//4 2
            g.DrawLine(p, 355, 360, 245, 235);//4 1
            g.DrawLine(p, 250, 375, 350, 375);//3 4
            g.DrawLine(p, 250, 230, 250, 370);//3 1
            g.DrawLine(p, 200, 370, 200, 230);//1 3
            g.DrawLine(p, 400, 225, 500, 225);//2 5
            g.DrawLine(p, 650, 225, 550, 225);//6 5
            g.DrawLine(p, 525, 250, 525, 350);//5 7
            g.DrawLine(p, 550, 375, 650, 375);//7 8
            g.DrawLine(p, 675, 350, 675, 250);//8 6

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x1 = 213.0F; float y1 = 213.0F;
            float x2 = 363.0F; float y2 = 213.0F;
            float x3 = 213.0F; float y3 = 363.0F;
            float x4 = 363.0F; float y4 = 363.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 663.0F; float y6 = 213.0F;
            float x7 = 513.0F; float y7 = 363.0F;
            float x8 = 663.0F; float y8 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);

        }
        private void button2_Click(object sender, EventArgs e)
        {//parcurgere
            i = 1;
            afis2(1);
        }
        void afis2(int i)
        {
            if (i <= n + m)
            {
                desen2(i);
                afis2(i + 1);
            }
        }
        void desen2(int i)
        {
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Red, 2);
            Pen p2 = new Pen(Color.MediumPurple, 2);
            Pen p3 = new Pen(Color.RoyalBlue, 2);
            SolidBrush s1 = new SolidBrush(Color.LightYellow);
            SolidBrush s2 = new SolidBrush(Color.LightCoral);
            SolidBrush s3 = new SolidBrush(Color.LightSkyBlue);
            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 213.0F; float y1 = 213.0F;
            float x2 = 363.0F; float y2 = 213.0F;
            float x3 = 213.0F; float y3 = 363.0F;
            float x4 = 363.0F; float y4 = 363.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 663.0F; float y6 = 213.0F;
            float x7 = 513.0F; float y7 = 363.0F;
            float x8 = 663.0F; float y8 = 363.0F;
            AdjustableArrowCap bigArrow1 = new AdjustableArrowCap(7, 7);
            p1.CustomEndCap = bigArrow1;
            AdjustableArrowCap bigArrow2 = new AdjustableArrowCap(7, 7);
            p2.CustomEndCap = bigArrow2;
            AdjustableArrowCap bigArrow3 = new AdjustableArrowCap(7, 7);
            p3.CustomEndCap = bigArrow3;

            if (i <= n + m)
            {
                if (i == 1)
                    g.FillEllipse(s1, 200, 200, 50, 50);
                if (i == 2)
                    g.DrawLine(p1, 250, 230, 250, 370);//3 1
                if (i == 3)
                    g.FillEllipse(s1, 200, 350, 50, 50);
                if (i == 4)
                    g.DrawLine(p1, 200, 370, 200, 230);//1 3
                if (i == 5)
                    g.DrawLine(p1, 250, 375, 350, 375);//3 4
                if (i == 6)
                    g.FillEllipse(s1, 350, 350, 50, 50);
                if (i == 7)
                    g.DrawLine(p1, 355, 360, 245, 235);//4 1
                if (i == 8)
                    g.DrawLine(p2, 250, 225, 350, 225);//1 2 
                if (i == 9)
                    g.FillEllipse(s2, 350, 200, 50, 50);
                if (i == 10)
                    g.DrawLine(p2, 400, 225, 500, 225);//2 5
                if (i == 11)
                    g.FillEllipse(s3, 500, 200, 50, 50);
                if (i == 12)
                    g.DrawLine(p3, 525, 250, 525, 350);//5 7
                if (i == 13)
                    g.FillEllipse(s3, 500, 350, 50, 50);
                if (i == 14)
                    g.DrawLine(p3, 550, 375, 650, 375);//7 8
                if (i == 15)
                    g.FillEllipse(s3, 650, 350, 50, 50);
                if (i == 16)
                    g.DrawLine(p3, 675, 350, 675, 250);//8 6
                if (i == 17)
                    g.FillEllipse(s3, 650, 200, 50, 50);
                if (i == 18)
                    g.DrawLine(p3, 650, 225, 550, 225);//6 5
            }

            //g.DrawLine(p, 375, 350, 375, 250);//4 2
            g.DrawEllipse(p, 200, 200, 50, 50);
            g.DrawEllipse(p, 350, 200, 50, 50);
            g.DrawEllipse(p, 200, 350, 50, 50);
            g.DrawEllipse(p, 350, 350, 50, 50);

            g.DrawEllipse(p, 500, 200, 50, 50);
            g.DrawEllipse(p, 650, 200, 50, 50);
            g.DrawEllipse(p, 500, 350, 50, 50);
            g.DrawEllipse(p, 650, 350, 50, 50);

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);
            Thread.Sleep(1000);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            grafuriOrientateComponenteConexe f2 = new grafuriOrientateComponenteConexe();
            f2.Show();
        }

        private void ComponenteConexe_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
CITIRE SI AFISARE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class grafuriOrientateCitireSiAfisare : Form
    {
        Graphics g;
        public grafuriOrientateCitireSiAfisare()
        {
            InitializeComponent();
        }

        private void grafuriOrientateCitireSiAfisare_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateCalculGrad f2 = new grafuriOrientateCalculGrad();
            f2.Show();
        }

        private void grafuriOrientateCitireSiAfisare_MouseClick(object sender, MouseEventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 350, 150, 50, 50);
            g.DrawEllipse(p, 500, 300, 50, 50);
            g.DrawEllipse(p, 600, 400, 50, 50);
            g.DrawEllipse(p, 400, 500, 50, 50);
            g.DrawEllipse(p, 250, 450, 50, 50);
            g.DrawEllipse(p, 200, 300, 50, 50);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;
            g.DrawLine(p, 375, 200, 250, 325);//1 6
            g.DrawLine(p, 500, 325, 375, 200);//2 1
            g.DrawLine(p, 525, 350, 425, 500);//2 4
            g.DrawLine(p, 625, 400, 525, 350);//3 2
            //g.DrawLine(p, );//3 3
            float startAngle = 270.0F;
            float sweepAngle = 270.0F;
            Rectangle rect = new Rectangle(625, 425, 50, 50);
            // Draw arc to screen.
            g.DrawArc(p, rect, startAngle, sweepAngle);
            g.DrawLine(p, 425, 500, 525, 350);//4 2
            g.DrawLine(p, 300, 475, 425, 500);//5 4
            g.DrawLine(p, 250, 325, 375, 200);//6 1
            g.DrawLine(p, 250, 325, 500, 325);//6 2
            g.DrawLine(p, 250, 325, 425, 500);//6 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 513.0F; float y2 = 313.0F;
            float x3 = 613.0F; float y3 = 413.0F;
            float x4 = 413.0F; float y4 = 513.0F;
            float x5 = 263.0F; float y5 = 463.0F;
            float x6 = 213.0F; float y6 = 313.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

    }
}

CALCUL GRAD
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
    public partial class grafuriOrientateCalculGrad : Form
    {
        int[,] a = new int[10, 10];
        int[,] b = new int[10, 10];
        int n, m, i;
        Graphics g;
        public grafuriOrientateCalculGrad()
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
            using (StreamReader fin = new StreamReader("gradCalcul1.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox1.AppendText(n.ToString() + "\n" + m.ToString() + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox1.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    a[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    b[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())]= 1;
                }
                richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {//grad extern
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("Grade exterioare: " + "\n");
            for (i = 1; i <= n; i++)
            {
                richTextBox1.AppendText(i.ToString() + " : " + gradExtern(i));
                richTextBox1.AppendText("\n");
            }
        }

        int gradExtern(int v)
        {
            int g = 0;
            for (int i = 1; i <= n; i++)
            {
                g = g + a[v, i];
            }
            return g;
        }
        int gradIntern(int v)
        {
            int g = 0;
            for (int i = 1; i <= n; i++)
            {
                g = g + b[v, i];
            }
            return g;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 150, 150, 50, 50);//1
            g.DrawEllipse(p, 150, 400, 50, 50);//2
            g.DrawEllipse(p, 550, 550, 50, 50);//3
            g.DrawEllipse(p, 550, 150, 50, 50);//4

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 175, 200, 175, 400);//1 2
            g.DrawLine(p, 200, 175, 550, 175);//1 4
            g.DrawLine(p, 194, 410, 552, 185);//2 4
            g.DrawLine(p, 197, 435, 550, 565);//2 3
            g.DrawLine(p, 575, 200, 573, 550);//3 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 163.0F;
            float x2 = 163.0F; float y2 = 413.0F;
            float x3 = 563.0F; float y3 = 563.0F;
            float x4 = 563.0F; float y4 = 163.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            //Thread.Sleep(1000);
        }
    

        private void grafuriOrientateCalculGrad_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {//grad intern
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("Grade interioare: " + "\n");
            for (i = 1; i <= n; i++)
            {
                richTextBox1.AppendText(i.ToString() + " : " + gradIntern(i));
                richTextBox1.AppendText("\n");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateCalculGrad f2 = new codGrafuriOrientateCalculGrad();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grafuriOrientateMatriceaDeAdiacenta f2 = new grafuriOrientateMatriceaDeAdiacenta();
            f2.Show();
        }
    }
}

BAZA
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
    public partial class grafuriOrientateBaza : Form
    {
        int[,] a = new int[20, 20];
        int[] L = new int[20];
        int n, x, y, cnt, i, j, m;
        int grafext = 0;
        int grafint = 0;
        int u = 0;
        Graphics g;
        public grafuriOrientateBaza()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileArce.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n.ToString() + "\n" + m.ToString() + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + " ");
                    string[] v = linie.Split(' ');
                    a[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            for (i = 1; i <= n; i++)
            {
                grafext = 0;
                for (j = 1; j <= n; j++)
                    grafext = grafext + a[i, j];
                richTextBox1.AppendText("d +(" + i.ToString() + ") =" + grafext.ToString() + "\n");
                //se = se + de;
            }
            //suma gradelor ext
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            for (j = 1; j <= n; j++)
            {
                grafint = 0;
                for (i = 1; i <= n; i++)
                    grafint = grafint + a[i, j];
                richTextBox1.AppendText("d -(" + j.ToString() + ") =" + grafint.ToString() + "\n");
            }
            //suma gradelor int
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            //cout<<"Lista de adiacenta"<<endl;
            richTextBox1.AppendText("lista de adiacenta: " + "\n");
            for (i = 1; i <= n; i++)
            {
                richTextBox1.AppendText("varful " + i.ToString() + " : ");
                for (j = 1; j <= n; j++)
                    if (a[i, j] == 1)//|| a[j][i] == 1)//vecini
                        richTextBox1.AppendText(j.ToString() + " ");
                richTextBox1.AppendText("\n");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateBaza f2 = new codGrafuriOrientateBaza();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("vecini: " + "\n");
            for (i = 1; i <= n; i++)
            {
                richTextBox1.AppendText("varful " + i.ToString() + " : ");
                for (j = 1; j <= n; j++)
                    if (a[i, j] == 1 || a[j, i] == 1)//vecini
                        richTextBox1.AppendText(j.ToString() + " ");
                richTextBox1.AppendText("\n");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 350, 150, 50, 50);//1
            g.DrawEllipse(p, 600, 150, 50, 50);//2
            g.DrawEllipse(p, 250, 300, 50, 50);//3
            g.DrawEllipse(p, 450, 250, 50, 50);//4
            g.DrawEllipse(p, 550, 350, 50, 50);//5
            g.DrawEllipse(p, 700, 250, 50, 50);//6
            g.DrawEllipse(p, 700, 400, 50, 50);//7

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 293, 305, 393, 190);//3 1
            g.DrawLine(p, 393, 190, 453, 260);//1 4
            g.DrawLine(p, 491, 256, 603, 186);//2 4
            g.DrawLine(p, 603, 186, 582, 350);//2 5
            g.DrawLine(p, 453, 260, 293, 305);//4 3
            g.DrawLine(p, 582, 350, 491, 256);//4 5
            g.DrawLine(p, 569, 349, 716, 250);//5 6
            g.DrawLine(p, 735, 297, 600, 385);//6 5

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 613.0F; float y2 = 163.0F;
            float x3 = 263.0F; float y3 = 313.0F;
            float x4 = 463.0F; float y4 = 263.0F;
            float x5 = 563.0F; float y5 = 363.0F;
            float x6 = 713.0F; float y6 = 263.0F;
            float x7 = 713.0F; float y7 = 413.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateCalculGrad f2 = new grafuriOrientateCalculGrad();
            f2.Show();
        }

        private void grafuriOrientateBaza_Load(object sender, EventArgs e)
        {

        }
    }
}

MATRICEA DE ADIACENTA
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
    public partial class grafuriOrientateMatriceaDeAdiacenta : Form
    {
        int[,] A = new int[10, 10];
        int i, j, n, m;
        Graphics g;
        public grafuriOrientateMatriceaDeAdiacenta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileArce.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n.ToString() + "\n" + m.ToString() + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    A[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    //a[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                    //ge[int.Parse(v[0].Trim().ToString())]++;
                    //gi[int.Parse(v[0].Trim().ToString())]++;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            richTextBox1.AppendText("Matricea de adiacenta este:" + "\n" + "\n");
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    richTextBox1.AppendText(A[i, j].ToString() + " ");

                }
                richTextBox1.AppendText("\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 250, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 350, 50, 50);//2
            g.DrawEllipse(p, 400, 500, 50, 50);//3
            g.DrawEllipse(p, 600, 350, 50, 50);//4
            g.DrawEllipse(p, 450, 150, 50, 50);//5
            g.DrawEllipse(p, 350, 250, 50, 50);//6

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 275, 200, 275, 350);//1 2
            g.DrawLine(p, 290, 393, 406, 507);//2 3
            g.DrawLine(p, 443, 505, 605, 390);//3 4
            g.DrawLine(p, 420, 500, 375, 300);//3 6
            g.DrawLine(p, 295, 190, 360, 255);//1 6

            g.DrawLine(p, 600, 365, 400, 280);//4 6
            g.DrawLine(p, 610, 355, 490, 195);//4 5
            g.DrawLine(p, 450, 167, 300, 167);//5 1

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 263.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 363.0F;
            float x3 = 413.0F; float y3 = 513.0F;
            float x4 = 613.0F; float y4 = 363.0F;
            float x5 = 463.0F; float y5 = 163.0F;
            float x6 = 363.0F; float y6 = 263.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateMatriceaDeAdiacenta f2 = new codGrafuriOrientateMatriceaDeAdiacenta();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateMatriceaDrumurilor f2 = new grafuriOrientateMatriceaDrumurilor();
            f2.Show();
        }

        private void grafuriOrientateMatriceaDeAdiacenta_Load(object sender, EventArgs e)
        {

        }
    }
}

MATRICEA DRUMURILOR
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
    public partial class grafuriOrientateMatriceaDrumurilor : Form
    {
        int[,] a = new int[20, 20];
        int[] L = new int[20];
        int n, i, j, m;
        Graphics g;
        public grafuriOrientateMatriceaDrumurilor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("MatriceaDrumurilor.txt"))
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

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            rw();
            afis();
        }
        void rw()
        {
            int i, j, k;
            for (k = 1; k <= n; k++)
                for (i = 1; i <= n; i++)
                    for (j = 1; j <= n; j++)
                        if (i != j)
                            if (a[i, j] == 0)
                                a[i, j] = a[i, k] * a[k, j];
        }
        void afis()
        {
            richTextBox1.AppendText("Matricea drumurilor acestui graf este : " + "\n" + "\n");
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                    richTextBox1.AppendText(a[i, j].ToString() + " ");
                richTextBox1.AppendText("\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 150, 150, 50, 50);//1
            g.DrawEllipse(p, 150, 350, 50, 50);//2
            g.DrawEllipse(p, 450, 150, 50, 50);//3
            g.DrawEllipse(p, 450, 450, 50, 50);//4
            g.DrawEllipse(p, 550, 350, 50, 50);//5

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 175, 200, 175, 350);//1 2
            g.DrawLine(p, 195, 360, 455, 190);//2 3
            g.DrawLine(p, 475, 200, 475, 450);//3 4

            g.DrawLine(p, 454, 460, 200, 380);//4 2
            g.DrawLine(p, 200, 375, 550, 375);//2 5
            g.DrawLine(p, 555, 360, 200, 178);//5 1

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 163.0F; float y1 = 163.0F;
            float x2 = 163.0F; float y2 = 363.0F;
            float x3 = 463.0F; float y3 = 163.0F;
            float x4 = 463.0F; float y4 = 463.0F;
            float x5 = 563.0F; float y5 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateMatriceaDrumurilor f2 = new codGrafuriOrientateMatriceaDrumurilor();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateCicluriCareIncepCuk f2 = new grafuriOrientateCicluriCareIncepCuk();
            f2.Show();
        }

        private void grafuriOrientateMatriceaDrumurilor_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();

        }
    }
}

CICLURI CARE INCEP CU K
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
    public partial class grafuriOrientateCicluriCareIncepCuk : Form
    {
        int[,] A = new int[10, 10];
        int i, j, n, m, k;
        int[] X = new int[50];
        int[] p = new int[50];
        Graphics g;
        public grafuriOrientateCicluriCareIncepCuk()
        {
            InitializeComponent();
        }

        private void grafuriOrientateCicluriCareIncepCuk_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFileCicluK.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n.ToString() + "\n" + m.ToString() + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    A[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    A[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                    //d[int.Parse(v[0].Trim().ToString())]++;
                    //d[int.Parse(v[0].Trim().ToString())]++;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void afis(int n)
        {
            for (int i = 1; i <= n; i++)
                richTextBox1.AppendText(X[i].ToString() + " ");
            richTextBox1.AppendText("\n");
        }

        void back(int k, int pas)
        {
            for (int i = 1; i <= n; i++)
                if (p[i] != 1 && A[X[pas - 1], i] == 1)
                {
                    X[pas] = i;
                    p[i] = 1;
                    if (X[pas] == k && pas > 3) afis(pas);
                    else back(k, pas + 1);
                    p[i] = 0;
                }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            k = int.Parse(textBox1.Text);
            X[1] = k;
            back(k, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 250, 100, 50, 50);//1
            g.DrawEllipse(p, 150, 250, 50, 50);//2
            g.DrawEllipse(p, 250, 400, 50, 50);//3
            g.DrawEllipse(p, 400, 400, 50, 50);//4
            g.DrawEllipse(p, 500, 200, 50, 50);//5
            g.DrawEllipse(p, 600, 300, 50, 50);//6

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 255, 141, 198, 270);//1 2
            g.DrawLine(p, 198, 270, 255, 407);//2 3
            g.DrawLine(p, 300, 425, 400, 425);//3 4
            g.DrawLine(p, 445, 409, 509, 242);//4 5
            g.DrawLine(p, 505, 210, 297, 135);//5 1
            g.DrawLine(p, 198, 270, 600, 320);//2 6
            g.DrawLine(p, 600, 320, 545, 240);//6 5
            g.DrawLine(p, 600, 320, 445, 413);//6 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 263.0F; float y1 = 113.0F;
            float x2 = 163.0F; float y2 = 263.0F;
            float x3 = 263.0F; float y3 = 413.0F;
            float x4 = 413.0F; float y4 = 413.0F;
            float x5 = 513.0F; float y5 = 213.0F;
            float x6 = 613.0F; float y6 = 313.0F;
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateCicluriCareIncepCuk f2 = new codGrafuriOrientateCicluriCareIncepCuk();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateComponenteConexe f2 = new grafuriOrientateComponenteConexe();
            f2.Show();
        }
    }
}

COMPONENTE CONEXE
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
    public partial class grafuriOrientateComponenteConexe : Form
    {
        int[,] a = new int[20, 20];
        int[] x = new int[20];
        int[] p = new int[20];
        int n, m, i, j;
        Graphics g;
        public grafuriOrientateComponenteConexe()
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
            using (StreamReader fin = new StreamReader("TextFileCompConexe.txt"))
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
                    //d[int.Parse(v[0].Trim().ToString())]++;
                    //d[int.Parse(v[0].Trim().ToString())]++;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void bf(int k)
        {
            int i, s, d;
            x[1] = k;
            p[k] = 1;
            s = d = 1;
            while (s <= d)
            {
                for (i = 1; i <= n; i++)
                    if (a[x[s], i] == 1 && p[i] != 1)
                    {
                        d++;
                        x[d] = i;
                        p[i] = 1;
                    }
                s++;
            }
            for (i = 1; i <= d; i++)
                richTextBox1.AppendText(x[i].ToString() + " ");
            richTextBox1.AppendText("\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            int i;
            for (i = 1; i <= n; i++)
                if (p[i] != 1)
                    bf(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 700, 250, 50, 50);//5
            g.DrawEllipse(p, 600, 400, 50, 50);//6
            g.DrawEllipse(p, 700, 500, 50, 50);//7
            g.DrawEllipse(p, 750, 400, 50, 50);//8

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 325, 250, 325, 450);//1 2
            g.DrawLine(p, 350, 225, 550, 225);//1 4
            g.DrawLine(p, 342, 455, 452, 385);//2 3
            g.DrawLine(p, 490, 355, 560, 245);//3 4
            g.DrawLine(p, 645, 440, 705, 510);//6 7
            g.DrawLine(p, 730, 500, 765, 445);//7 8

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 313.0F; float y1 = 213.0F;
            float x2 = 313.0F; float y2 = 463.0F;
            float x3 = 463.0F; float y3 = 363.0F;
            float x4 = 563.0F; float y4 = 213.0F;
            float x5 = 713.0F; float y5 = 263.0F;
            float x6 = 613.0F; float y6 = 413.0F;
            float x7 = 713.0F; float y7 = 513.0F;
            float x8 = 763.0F; float y8 = 413.0F;
            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);
            //Thread.Sleep(1000);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateComponenteConexe f2 = new codGrafuriOrientateComponenteConexe();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateComponentaConexaMaxima f2 = new grafuriOrientateComponentaConexaMaxima();
            f2.Show();
        }

        private void grafuriOrientateComponenteConexe_Load(object sender, EventArgs e)
        {

        }
    }
}

COMPONENTA CONEXA MAXIMA
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
    public partial class grafuriOrientateComponenteConexe : Form
    {
        int[,] a = new int[20, 20];
        int[] x = new int[20];
        int[] p = new int[20];
        int n, m, i, j;
        Graphics g;
        public grafuriOrientateComponenteConexe()
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
            using (StreamReader fin = new StreamReader("TextFileCompConexe.txt"))
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
                    //d[int.Parse(v[0].Trim().ToString())]++;
                    //d[int.Parse(v[0].Trim().ToString())]++;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void bf(int k)
        {
            int i, s, d;
            x[1] = k;
            p[k] = 1;
            s = d = 1;
            while (s <= d)
            {
                for (i = 1; i <= n; i++)
                    if (a[x[s], i] == 1 && p[i] != 1)
                    {
                        d++;
                        x[d] = i;
                        p[i] = 1;
                    }
                s++;
            }
            for (i = 1; i <= d; i++)
                richTextBox1.AppendText(x[i].ToString() + " ");
            richTextBox1.AppendText("\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
            int i;
            for (i = 1; i <= n; i++)
                if (p[i] != 1)
                    bf(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 700, 250, 50, 50);//5
            g.DrawEllipse(p, 600, 400, 50, 50);//6
            g.DrawEllipse(p, 700, 500, 50, 50);//7
            g.DrawEllipse(p, 750, 400, 50, 50);//8

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
            p.CustomEndCap = bigArrow;

            g.DrawLine(p, 325, 250, 325, 450);//1 2
            g.DrawLine(p, 350, 225, 550, 225);//1 4
            g.DrawLine(p, 342, 455, 452, 385);//2 3
            g.DrawLine(p, 490, 355, 560, 245);//3 4
            g.DrawLine(p, 645, 440, 705, 510);//6 7
            g.DrawLine(p, 730, 500, 765, 445);//7 8

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            float x1 = 313.0F; float y1 = 213.0F;
            float x2 = 313.0F; float y2 = 463.0F;
            float x3 = 463.0F; float y3 = 363.0F;
            float x4 = 563.0F; float y4 = 213.0F;
            float x5 = 713.0F; float y5 = 263.0F;
            float x6 = 613.0F; float y6 = 413.0F;
            float x7 = 713.0F; float y7 = 513.0F;
            float x8 = 763.0F; float y8 = 413.0F;
            //float x7 = 
            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);
            g.DrawString("7", drawFont, drawBrush, x7, y7);
            g.DrawString("8", drawFont, drawBrush, x8, y8);
            //Thread.Sleep(1000);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            codGrafuriOrientateComponenteConexe f2 = new codGrafuriOrientateComponenteConexe();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            grafuriOrientateComponentaConexaMaxima f2 = new grafuriOrientateComponentaConexaMaxima();
            f2.Show();
        }

        private void grafuriOrientateComponenteConexe_Load(object sender, EventArgs e)
        {

        }
    }
}


ARBORI
INTRODUCERE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class arbori : Form
    {

        int nr = 0;
        Graphics g;
        public arbori()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            arboriVectorTati f2 = new arboriVectorTati();
            f2.Show();
        }

        private void arbori_Load(object sender, EventArgs e)
        {
            titluLabel.Visible = true;
            this.Size = new Size(869, 726);

            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            panel1.Visible = false;
            panel2.Visible = false;

            label2.Visible = false;

            button1.Visible = false;


        }

        private void arbori_Click(object sender, EventArgs e)
        {
            nr++;
            if (nr == 1)
            {
                this.Size = new Size(1211, 726);
                titluLabel.Visible = false;

                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;

                panel1.Visible = true;
                panel2.Visible = true;

                label2.Visible = true;

                button1.Visible = true;
            }
            if(nr==2)
            {
                afis1(1);
            }

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
            g.DrawEllipse(p, 350, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 250, 50, 50);//2
            g.DrawEllipse(p, 150, 350, 50, 50);//3
            g.DrawEllipse(p, 250, 350, 50, 50);//4
            g.DrawEllipse(p, 450, 250, 50, 50);//5
            g.DrawEllipse(p, 450, 350, 50, 50);//6

            g.DrawLine(p, 356, 191, 292, 255);//1 2
            g.DrawLine(p, 395, 190, 455, 258);//1 5
            g.DrawLine(p, 475, 300, 475, 350);//5 6
            g.DrawLine(p, 258, 292, 188, 352);//2 3
            g.DrawLine(p, 275, 300, 275, 350);//2 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 263.0F;
            float x3 = 163.0F; float y3 = 363.0F;
            float x4 = 263.0F; float y4 = 363.0F;
            float x5 = 463.0F; float y5 = 263.0F;
            float x6 = 463.0F; float y6 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
VECTOR TATI
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
    public partial class arboriVectorTati : Form
    {
        int[,] A = new int[10, 10];
        int[] T = new int[100];
        int[] P = new int[100];
        int i, j, n, m;
        Graphics g;
        public arboriVectorTati()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("arbori2.txt"))
            {
                n = int.Parse(fin.ReadLine());
                m = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n + "\n" + m + "\n");
                for (i = 1; i <= m; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    A[int.Parse(v[0].Trim().ToString()), int.Parse(v[1].Trim().ToString())] = 1;
                    A[int.Parse(v[1].Trim().ToString()), int.Parse(v[0].Trim().ToString())] = 1;
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void BF(int v)
        {
            int st = 1, dr = 1;
            int[] Q = new int[100];
            Q[st] = v;
            P[v] = 1;
            while (st <= dr)
            {
                int i = Q[st];
                for (int j = 1; j <= n; j++)
                    if (P[j] != 1 && A[i, j] == 1)
                    {
                        dr++;
                        Q[dr] = j;
                        T[j] = i;
                        P[j] = 1;
                    }
                st++;
            }
        }
        void afisare()
        {
            for (int i = 1; i <= n; i++)
                richTextBox1.AppendText(i.ToString() + " " + T[i].ToString() + "\n");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            BF(1);
            afisare();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
        }
        void afis1(int i)
        {
            if (i <= 10)
            {
                desen1(i);
                afis1(i + 1);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void arboriVectorTati_Load(object sender, EventArgs e)
        {

        }

        void desen1(int i)
        {
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);
            g.DrawEllipse(p, 350, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 250, 50, 50);//2
            g.DrawEllipse(p, 350, 350, 50, 50);//3
            g.DrawEllipse(p, 450, 250, 50, 50);//4
            g.DrawEllipse(p, 150, 350, 50, 50);//5

            g.DrawLine(p, 356, 191, 292, 255);//1 2
            g.DrawLine(p, 395, 190, 455, 258);//1 4
            g.DrawLine(p, 258, 292, 194, 359);//2 5

            g.DrawLine(p, 300, 275, 450, 275);//2 4
            g.DrawLine(p, 375, 200, 375, 350);//1 3
            g.DrawLine(p, 293, 292, 358, 357);//2 3

            g.DrawLine(p, 453, 285, 200, 375);//4 5
            g.DrawLine(p, 400, 365, 458, 292);//3 4
            g.DrawLine(p, 350, 375, 200, 375);//3 5

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 263.0F;
            float x3 = 363.0F; float y3 = 363.0F;
            float x4 = 463.0F; float y4 = 263.0F;
            float x5 = 163.0F; float y5 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            codArboriVectorTati f2 = new codArboriVectorTati();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arboriFrunze f2 = new arboriFrunze();
            f2.Show();
        }
    }
}

FRUNZE
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
    public partial class arboriFrunze : Form
    {
        int[] T = new int[100];
        int[] p = new int[100];
        int i, j, n;
        Graphics g;
        public arboriFrunze()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("arbori2.txt"))
            {
                n = int.Parse(fin.ReadLine());
                richTextBox2.AppendText(n.ToString() + "\n");
                for (i = 1; i <= n; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    T[int.Parse(v[0].Trim().ToString())] = int.Parse(v[1].Trim().ToString());
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (i = 1; i <= n; i++)
                if (T[T[i]] != 0)
                    richTextBox1.AppendText(i.ToString() + " ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 350, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 250, 50, 50);//2
            g.DrawEllipse(p, 150, 350, 50, 50);//3
            g.DrawEllipse(p, 250, 350, 50, 50);//4
            g.DrawEllipse(p, 450, 250, 50, 50);//5
            g.DrawEllipse(p, 450, 350, 50, 50);//6

            g.DrawLine(p, 356, 191, 292, 255);//1 2
            g.DrawLine(p, 395, 190, 455, 258);//1 5
            g.DrawLine(p, 475, 300, 475, 350);//5 6
            g.DrawLine(p, 258, 292, 188, 352);//2 3
            g.DrawLine(p, 275, 300, 275, 350);//2 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 263.0F;
            float x3 = 163.0F; float y3 = 363.0F;
            float x4 = 263.0F; float y4 = 363.0F;
            float x5 = 463.0F; float y5 = 263.0F;
            float x6 = 463.0F; float y6 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void arboriFrunze_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            codArboriFrunze f2 = new codArboriFrunze();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arboriLant f2 = new arboriLant();
            f2.Show();
        }
    }
}

LANT
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
    public partial class arboriLant : Form
    {
        int[] t = new int[100];
        int i, j, n, p, q;
        Graphics g;
        public arboriLant()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("arbori1.txt"))
            {
                n = int.Parse(fin.ReadLine());
                p = Convert.ToInt32(textBox1.Text);
                q = Convert.ToInt32(textBox2.Text);
                richTextBox2.AppendText(n.ToString() + "\n" + p.ToString() + "\n" + q.ToString() + "\n");
                for (i = 1; i <= n; i++)
                {
                    string linie = fin.ReadLine();
                    richTextBox2.AppendText(linie + "\n");
                    string[] v = linie.Split(' ');
                    t[int.Parse(v[0].Trim().ToString())] = int.Parse(v[1].Trim().ToString());
                }
                richTextBox2.Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Bold);
                fin.Close();
            }
        }
        void schimba(int r)
        {
            if (t[r] != 0)
            {
                schimba(t[r]);
                t[t[r]] = r;
            }
        }

        void drum(int v)
        {
            if (v != 0)
            {
                drum(t[v]);
                richTextBox1.AppendText(v.ToString() + " ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            schimba(p);
            t[p] = 0;
            drum(q);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            afis1(1);
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
            g.DrawEllipse(p, 350, 150, 50, 50);//1
            g.DrawEllipse(p, 250, 250, 50, 50);//2
            g.DrawEllipse(p, 150, 350, 50, 50);//3
            g.DrawEllipse(p, 250, 350, 50, 50);//4
            g.DrawEllipse(p, 450, 250, 50, 50);//5
            g.DrawEllipse(p, 450, 350, 50, 50);//6

            g.DrawLine(p, 356, 191, 292, 255);//1 2
            g.DrawLine(p, 395, 190, 455, 258);//1 5
            g.DrawLine(p, 475, 300, 475, 350);//5 6
            g.DrawLine(p, 258, 292, 188, 352);//2 3
            g.DrawLine(p, 275, 300, 275, 350);//2 4

            Font drawFont = new Font("Arial", 18);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x1 = 363.0F; float y1 = 163.0F;
            float x2 = 263.0F; float y2 = 263.0F;
            float x3 = 163.0F; float y3 = 363.0F;
            float x4 = 263.0F; float y4 = 363.0F;
            float x5 = 463.0F; float y5 = 263.0F;
            float x6 = 463.0F; float y6 = 363.0F;

            g.DrawString("1", drawFont, drawBrush, x1, y1);
            g.DrawString("2", drawFont, drawBrush, x2, y2);
            g.DrawString("3", drawFont, drawBrush, x3, y3);
            g.DrawString("4", drawFont, drawBrush, x4, y4);
            g.DrawString("5", drawFont, drawBrush, x5, y5);
            g.DrawString("6", drawFont, drawBrush, x6, y6);

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            codArboriLant f2 = new codArboriLant();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }

        private void arboriLant_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
    }
}


CREARE GRAF

GRAD GRAF
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class gradGraf : Form
    {
        public Button[] v = new Button[100];
        public int n = 0;
        public int[,] a11 = new int[10, 10];
        string linie;
        int nr = 0, i, j, p1, p2, p3, p4, x, y, L;
        Pen p = new Pen(Color.Black, 1);
        public gradGraf()
        {
            InitializeComponent();
        }
        private void gradGraf_Load(object sender, EventArgs e)
        {

        } 
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g1 = this.CreateGraphics();
            back1 ob = new back1(n, a11, v);
            ob.back(1, n, g1);
            DisplayMatrix(a11, n);
        }
        private void DisplayMatrix(int[,] matrix, int size)
        {
            richTextBox1.Clear();
            int s = 0;
            richTextBox1.AppendText("Grad: " + "\n");
            for (int i = 1; i <= size; i++)
            {
                s = 0;
                for (int j = 1; j <= size; j++)
                {
                    s = s + a11[i, j];
                }
                richTextBox1.AppendText(i.ToString() + " : " + s.ToString());
                richTextBox1.AppendText("\n");
            }
        }


        private void gradGraf_MouseClick(object sender, MouseEventArgs e)
        {
            n++;
            v[n] = new Button();
            v[n].Location = new Point(e.X, e.Y);
            v[n].Height = 20;
            v[n].Width = 20;
            v[n].Text = n.ToString();
            v[n].Tag = Convert.ToString(n);
            v[n].Click += new EventHandler(v_Click);
            this.Controls.Add(v[n]);
        }
        public void v_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            int nrb = Convert.ToInt32(((Button)sender).Tag);

            nr++;
            if (nr % 2 == 0)
            {
                x = nrb;
                p1 = ((Button)sender).Location.X;
                p2 = ((Button)sender).Location.Y;
                PointF punct1 = new PointF(p1 + 5, p2 + 5);
                PointF punct2 = new PointF(p3 + 5, p4 + 5);
                g.DrawLine(p, punct1, punct2);
                a11[x, y] = 1;
                a11[y, x] = 1;
            }
            else
            {
                y = nrb;
                p3 = ((Button)sender).Location.X;
                p4 = ((Button)sender).Location.Y;
            }
        }
        class back1
        {
            public Button[] v1 = new Button[10];
            public int n1, K = 0, j = 0;
            public int[,] a1 = new int[9, 9];
            public int[] st = new int[7];

            public back1(int n, int[,] a, Button[] v)
            {
                n1 = n;
                a1 = a;
                v1 = v;
            }

            public void init(int K)
            {
                st[K] = 0;
            }

            public bool succ(int K)
            {

                if (st[K] < n1)
                {
                    st[K]++;
                    return true;
                }
                else return false;
            }

            public bool valid(int K)
            {
                bool ev;
                ev = true;
                for (int i = 1; i <= K - 1; i++)
                {
                    if (st[i] == st[K])
                    {
                        ev = false;
                        break;
                    }
                }
                if (K > 1 && a1[st[K - 1], st[K]] == 0)
                {
                    ev = false;
                }
                if (K == n1 && a1[st[1], st[n1]] == 0)
                {
                    ev = false;
                }
                return ev;
            }

            public bool sol(int K, int L)
            {
                return (K == n1);
            }

            public void tipar(int K, Graphics g)
            {
                int i;
                Pen p1 = new Pen(Color.Black, 2);
                Pen p2 = new Pen(Color.Red, 2);

                for (i = 1; i <= K - 2; i++)
                {
                    int a5 = v1[st[i]].Location.X + 5;
                    int b = v1[st[i]].Location.Y + 5;
                    int c = v1[st[i + 1]].Location.X + 5;
                    int d = v1[st[i + 1]].Location.Y + 5;
                    g.DrawLine(p2, a5, b, c, d);

                    PointF pt22 = new PointF(540 + (80.0F) + 30 * i, (80.0F) + j * 30);
                    SolidBrush b22 = new SolidBrush(Color.Black);
                    Font f22 = new Font("Arial", 18, FontStyle.Italic);
                    g.DrawString(st[i].ToString(), f22, b22, pt22);

                    System.Threading.Thread.Sleep(500);
                }

                int a51 = v1[st[1]].Location.X + 5;
                int b1 = v1[st[1]].Location.Y + 5;
                int c1 = v1[st[n1]].Location.X + 5;
                int d1 = v1[st[n1]].Location.Y + 5;
                g.DrawLine(p2, a51, b1, c1, d1);

                PointF pt221 = new PointF(540 + (80.0F) + 30 * i, (80.0F) + j * 30);
                SolidBrush b221 = new SolidBrush(Color.Black);
                Font f221 = new Font("Arial", 18, FontStyle.Italic);
                g.DrawString(st[1].ToString(), f221, b221, pt221);

                System.Threading.Thread.Sleep(1000);

                for (i = 1; i <= K - 2; i++)
                {
                    int a4 = v1[st[i]].Location.X + 5;
                    int b4 = v1[st[i]].Location.Y + 5;
                    int c4 = v1[st[i + 1]].Location.X + 5;
                    int d4 = v1[st[i + 1]].Location.Y + 5;
                    g.DrawLine(p1, a4, b4, c4, d4);
                }
            }

            public void back(int K, int L, Graphics g)
            {
                if (K == n1 + 1)
                {
                    tipar(K, g);
                    j++;
                }
                else
                {
                    init(K);
                    while (succ(K))
                    {
                        if (valid(K))
                        {
                            back(K + 1, n1, g);
                        }
                    }
                }
            }
        }



    }
}
MATRICEA DRUMURILOR
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs_Explorer
{
    public partial class matriceaDrumurilor : Form
    {
        public Button[] v = new Button[100];
        public int n = 0;
        public int[,] a11 = new int[10, 10];
        string linie;
        int nr = 0, i, j, p1, p2, p3, p4, x, y, L;
        Pen p = new Pen(Color.Black, 1);

        public matriceaDrumurilor()
        {
            InitializeComponent();
        }

        private void matriceaDrumurilor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g1 = this.CreateGraphics();
            back1 ob = new back1(n, a11, v);
            ob.back(1, n, g1);
            DisplayMatrix(a11, n);
        }
        private void DisplayMatrix(int[,] matrix, int size)
        {
            //StringBuilder sb = new StringBuilder();
            richTextBox1.AppendText("Matricea drumurilor: " + "\n");
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    richTextBox1.AppendText(matrix[i, j].ToString() + " ");
                }
                richTextBox1.AppendText("\n");
            }
            //MessageBox.Show(richTextBox1.ToString());
        }



        private void matriceaDrumurilor_MouseClick(object sender, MouseEventArgs e)
        {
            n++;
            v[n] = new Button();
            v[n].Location = new Point(e.X, e.Y);
            v[n].Height = 20;
            v[n].Width = 20;
            v[n].Text = n.ToString();
            v[n].Tag = Convert.ToString(n);
            v[n].Click += new EventHandler(v_Click);
            this.Controls.Add(v[n]);
        }
        public void v_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            int nrb = Convert.ToInt32(((Button)sender).Tag);

            nr++;
            if (nr % 2 == 0)
            {
                x = nrb;
                p1 = ((Button)sender).Location.X;
                p2 = ((Button)sender).Location.Y;
                PointF punct1 = new PointF(p1 + 5, p2 + 5);
                PointF punct2 = new PointF(p3 + 5, p4 + 5);
                g.DrawLine(p, punct1, punct2);
                a11[x, y] = 1;
                a11[y, x] = 1;
            }
            else
            {
                y = nrb;
                p3 = ((Button)sender).Location.X;
                p4 = ((Button)sender).Location.Y;
            }
        }
        class back1
        {
            public Button[] v1 = new Button[10];
            public int n1, K = 0, j = 0;
            public int[,] a1 = new int[9, 9];
            public int[] st = new int[7];

            public back1(int n, int[,] a, Button[] v)
            {
                n1 = n;
                a1 = a;
                v1 = v;
            }

            public void init(int K)
            {
                st[K] = 0;
            }

            public bool succ(int K)
            {

                if (st[K] < n1)
                {
                    st[K]++;
                    return true;
                }
                else return false;
            }

            public bool valid(int K)
            {
                bool ev;
                ev = true;
                for (int i = 1; i <= K - 1; i++)
                {
                    if (st[i] == st[K])
                    {
                        ev = false;
                        break;
                    }
                }
                if (K > 1 && a1[st[K - 1], st[K]] == 0)
                {
                    ev = false;
                }
                if (K == n1 && a1[st[1], st[n1]] == 0)
                {
                    ev = false;
                }
                return ev;
            }

            public bool sol(int K, int L)
            {
                return (K == n1);
            }

            public void tipar(int K, Graphics g)
            {
                int i;
                Pen p1 = new Pen(Color.Black, 2);
                Pen p2 = new Pen(Color.Red, 2);

                for (i = 1; i <= K - 2; i++)
                {
                    int a5 = v1[st[i]].Location.X + 5;
                    int b = v1[st[i]].Location.Y + 5;
                    int c = v1[st[i + 1]].Location.X + 5;
                    int d = v1[st[i + 1]].Location.Y + 5;
                    g.DrawLine(p2, a5, b, c, d);

                    PointF pt22 = new PointF(540 + (80.0F) + 30 * i, (80.0F) + j * 30);
                    SolidBrush b22 = new SolidBrush(Color.Black);
                    Font f22 = new Font("Arial", 18, FontStyle.Italic);
                    g.DrawString(st[i].ToString(), f22, b22, pt22);

                    System.Threading.Thread.Sleep(500);
                }

                int a51 = v1[st[1]].Location.X + 5;
                int b1 = v1[st[1]].Location.Y + 5;
                int c1 = v1[st[n1]].Location.X + 5;
                int d1 = v1[st[n1]].Location.Y + 5;
                g.DrawLine(p2, a51, b1, c1, d1);

                PointF pt221 = new PointF(540 + (80.0F) + 30 * i, (80.0F) + j * 30);
                SolidBrush b221 = new SolidBrush(Color.Black);
                Font f221 = new Font("Arial", 18, FontStyle.Italic);
                g.DrawString(st[1].ToString(), f221, b221, pt221);

                System.Threading.Thread.Sleep(1000);

                for (i = 1; i <= K - 2; i++)
                {
                    int a4 = v1[st[i]].Location.X + 5;
                    int b4 = v1[st[i]].Location.Y + 5;
                    int c4 = v1[st[i + 1]].Location.X + 5;
                    int d4 = v1[st[i + 1]].Location.Y + 5;
                    g.DrawLine(p1, a4, b4, c4, d4);
                }
            }

            public void back(int K, int L, Graphics g)
            {
                if (K == n1 + 1)
                {
                    tipar(K, g);
                    j++;
                }
                else
                {
                    init(K);
                    while (succ(K))
                    {
                        if (valid(K))
                        {
                            back(K + 1, n1, g);
                        }
                    }
                }
            }
        }

    }
}

PARCURGERE GRAF
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Graphs_Explorer
{
    public partial class graf : Form
    {
        public Button[] v = new Button[100];
        public int n = 0;
        public int[,] a11 = new int[10, 10];
        string linie;
        int nr = 0, i, j, p1, p2, p3, p4, x, y, L;
        Pen p = new Pen(Color.Black, 1);
        public graf()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu f2 = new meniu();
            f2.Show();
        }
        private void graf_Load(object sender, EventArgs e)
        {

        }

        private void graf_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void graf_MouseClick(object sender, MouseEventArgs e)
        {
            n++;
            v[n] = new Button();
            v[n].Location = new Point(e.X, e.Y);
            v[n].Height = 20;
            v[n].Width = 20;
            v[n].Text = n.ToString();
            v[n].Tag = Convert.ToString(n);
            v[n].Click += new EventHandler(v_Click);
            this.Controls.Add(v[n]);
            //MessageBox.Show(n.ToString());
        }
        public void v_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            int nrb = Convert.ToInt32(((Button)sender).Tag);



            nr++;
            if (nr % 2 == 0)
            {
                x = nrb;


                p1 = ((Button)sender).Location.X;
                p2 = ((Button)sender).Location.Y;
                PointF punct1 = new PointF(p1 + 5, p2 + 5);
                PointF punct2 = new PointF(p3 + 5, p4 + 5);
                g.DrawLine(p, punct1, punct2);
                a11[x, y] = 1;
                a11[y, x] = 1;


            }
            else
            {
                y = nrb;
                p3 = ((Button)sender).Location.X;
                p4 = ((Button)sender).Location.Y;


            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // int L = int.Parse(textBox1.Text);

            Graphics g1 = this.CreateGraphics();

            back1 ob = new back1(n, a11, v);
            ob.back(1, n, g1);
        }

        class back1
        {
            public Button[] v1 = new Button[10];
            public int n1, K = 0, j = 0;
            public int[,] a1 = new int[9, 9];

            public int[] st = new int[7];
            public back1(int n, int[,] a, Button[] v)
            {
                n1 = n;
                a1 = a;
                v1 = v;
            }
            public void init(int K)
            {
                st[K] = 0;
            }
            public bool succ(int K)
            {
                if (st[K] < n1)
                {
                    st[K]++;
                    return true;
                }
                else return false;
            }
            public bool valid(int K)
            {
                bool ev;
                ev = true;
                for (int i = 1; i <= K - 1; i++)
                    if (st[i] == st[K])
                        ev = false;
                if ((K > 1) && (a1[st[K - 1], st[K]] == 0))
                    ev = false;
                if (K == n1 && a1[st[1], st[n1]] == 0)
                    ev = false;
                return ev;
            }
            public bool sol(int K, int L)
            {
                return (K == n1);
            }
            public void tipar(int K, Graphics g)
            {

                int i;

                Pen p1 = new Pen(Color.Black, 2);
                Pen p2 = new Pen(Color.Red, 2);

                // Thread.Sleep(500);
                for (i = 1; i <= K - 2; i++)
                {
                    int a5 = v1[st[i]].Location.X + 5;
                    int b = v1[st[i]].Location.Y + 5;
                    int c = v1[st[i + 1]].Location.X + 5;
                    int d = v1[st[i + 1]].Location.Y + 5;
                    g.DrawLine(p2, a5, b, c, d);

                    PointF pt22 = new PointF(540 + (80.0F) + 30 * i, (80.0F) + j * 30);
                    SolidBrush b22 = new SolidBrush(Color.Black);
                    Font f22 = new Font("Arial", 18, FontStyle.Italic);
                    g.DrawString(st[i].ToString(), f22, b22, pt22);

                    Thread.Sleep(500);

                }
                int a51 = v1[st[1]].Location.X + 5;
                int b1 = v1[st[1]].Location.Y + 5;
                int c1 = v1[st[n1]].Location.X + 5;
                int d1 = v1[st[n1]].Location.Y + 5;
                g.DrawLine(p2, a51, b1, c1, d1);

                PointF pt221 = new PointF(540 + (80.0F) + 30 * i, (80.0F) + j * 30);
                SolidBrush b221 = new SolidBrush(Color.Black);
                Font f221 = new Font("Arial", 18, FontStyle.Italic);
                g.DrawString(st[1].ToString(), f221, b221, pt221);

                Thread.Sleep(1000);


                for (i = 1; i <= K - 2; i++)
                {



                    int a4 = v1[st[i]].Location.X + 5;
                    int b4 = v1[st[i]].Location.Y + 5;
                    int c4 = v1[st[i + 1]].Location.X + 5;
                    int d4 = v1[st[i + 1]].Location.Y + 5;
                    g.DrawLine(p1, a4, b4, c4, d4);

                }
            }
            public void back(int K, int L, Graphics g)
            {

                if (K == n1 + 1)
                {
                    tipar(K, g);
                    j++;
                }
                else
                {
                    init(K);
                    while (succ(K))
                        if ((valid(K)))
                            back(K + 1, n1, g);
                }
            }

        }
    }
}

APLICATII
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


TESTE
C=CAPITOLUL, S=SUBIECTUL

C1S1
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
    public partial class testC1S1 : Form
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
        public static string user=Autentificare.user;
        public testC1S1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        struct intreb
        {
            public string test, raspuns, punctaj;
        }; 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void testC1S1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            for (i = 1; i <= 99; i++)
                v1[i] = 0;

            textBox1.Enabled = false;
            textBox1.Text = user.ToString();

            con.Open();
            string select = "select Id from utilizatori where nume_utilizator=@n";
            SqlCommand cmd = new SqlCommand(select, con);
            cmd.Parameters.AddWithValue("n", textBox1.Text);
            SqlDataReader r = cmd.ExecuteReader();
            while(r.Read())
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

            nota1 = nr;

            con.Open();
            string insert = @"insert into catalog(id_elev,test,nota)values(@id_elev,@test,@nota)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("id_elev", id);
            cmd.Parameters.AddWithValue("test", "1");
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
            testC1S2 f2 = new testC1S2();
            f2.Show();
        }

    }
}
C1S2
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
    public partial class testC1S2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\BazaDeDate.mdf;Integrated Security=True");
        radio[] v = new radio[100];
        int[] s = new int[100];
        int k, nr = 0, i, nota2;
        int[] v1 = new int[100];
        string s1;
        int id;
        public static string user = Autentificare.user;
        public testC1S2()
        {
            InitializeComponent();
        }

        private void testC1S2_Load(object sender, EventArgs e)
        {
            for (i = 1; i <= 99; i++)
                v1[i] = 0;

            textBox1.Enabled = false;
            textBox1.Text = user.ToString();
        }
       
   
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (string.Compare(v[nr].r1.Trim(), v[nr].rc.Trim()) == 0)
                s[nr] = 2;
            else
                s[nr] = 0;*/
            if (v != null && nr >= 0 && nr < v.Length && v[nr] != null)
            {
                if (v[nr].r1 != null && v[nr].rc != null && string.Compare(v[nr].r1.Trim(), v[nr].rc.Trim()) == 0)
                    s[nr] = 2;
                else
                    s[nr] = 0;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (string.Compare(v[nr].r2.Trim(), v[nr].rc.Trim()) == 0)
                s[nr] = 2;
            else
                s[nr] = 0;
            */
            if (v != null && nr >= 0 && nr < v.Length && v[nr] != null)
            {
                if (v[nr].r2 != null && v[nr].rc != null && string.Compare(v[nr].r2.Trim(), v[nr].rc.Trim()) == 0)
                    s[nr] = 2;
                else
                    s[nr] = 0;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (string.Compare(v[nr].r3.Trim(), v[nr].rc.Trim()) == 0)
                s[nr] = 2;
            else
                s[nr] = 0;
            */
            if (v != null && nr >= 0 && nr < v.Length && v[nr] != null)
            {
                if (v[nr].r3 != null && v[nr].rc != null && string.Compare(v[nr].r3.Trim(), v[nr].rc.Trim()) == 0)
                    s[nr] = 2;
                else
                    s[nr] = 0;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            k = 0;
            using (StreamReader fin = new StreamReader("C1S2.txt"))
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
                fin.Close();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
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

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                s1 = openFileDialog1.InitialDirectory + openFileDialog1.FileName;


            }
            using (StreamWriter f = File.AppendText("rezultate.txt"))
            {
                f.WriteLine(textBox1.Text + "|" + nota2.ToString() + "|" + DateTime.Now.ToString());
                f.Close();
            }


            testC1S3 f2 = new testC1S3();
            f2.Show();

        }
    }
}

C1S3
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



C2S1

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

C2S2
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
    public partial class testC2S2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\BazaDeDate.mdf;Integrated Security=True");
        radio[] v = new radio[100];
        int[] s = new int[100];
        int k, nr = 0, i, nota2;
        int[] v1 = new int[100];
        string s1;
        int id;
        public static string user = Autentificare.user;
        public testC2S2()
        {
            InitializeComponent();
        }

        private void testC2S2_Load(object sender, EventArgs e)
        {
            for (i = 1; i <= 99; i++)
                v1[i] = 0;

            textBox1.Enabled = false;
            textBox1.Text = user.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (v != null && nr >= 0 && nr < v.Length && v[nr] != null)
            {
                if (v[nr].r1 != null && v[nr].rc != null && string.Compare(v[nr].r1.Trim(), v[nr].rc.Trim()) == 0)
                    s[nr] = 2;
                else
                    s[nr] = 0;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (v != null && nr >= 0 && nr < v.Length && v[nr] != null)
            {
                if (v[nr].r2 != null && v[nr].rc != null && string.Compare(v[nr].r2.Trim(), v[nr].rc.Trim()) == 0)
                    s[nr] = 2;
                else
                    s[nr] = 0;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (v != null && nr >= 0 && nr < v.Length && v[nr] != null)
            {
                if (v[nr].r3 != null && v[nr].rc != null && string.Compare(v[nr].r3.Trim(), v[nr].rc.Trim()) == 0)
                    s[nr] = 2;
                else
                    s[nr] = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                    v[k].r3 = v1[3].ToString();
                    v[k].rc = v1[4].ToString();
                }
                fin.Close();
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

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                s1 = openFileDialog1.InitialDirectory + openFileDialog1.FileName;


            }
            using (StreamWriter f = File.AppendText("rezultate.txt"))
            {
                f.WriteLine(textBox1.Text + "|" + nota2.ToString() + "|" + DateTime.Now.ToString());
                f.Close();
            }


            testC2S3 f2 = new testC2S3();
            f2.Show();
        }
    }
}
C2S3
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
    public partial class testC2S3 : Form
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
        public testC2S3()
        {
            InitializeComponent();
        }

        private void testC2S3_Load(object sender, EventArgs e)
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

            using (StreamReader f = new StreamReader("C2S1.txt"))
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

C3S1
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
    public partial class testC3S1 : Form
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
        public testC3S1()
        {
            InitializeComponent();
        }
        struct intreb
        {
            public string test, raspuns, punctaj;
        };
        private void testC3S1_Load(object sender, EventArgs e)
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

            nota1 = nr;

            con.Open();
            string insert = @"insert into catalog(id_elev,test,nota)values(@id_elev,@test,@nota)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("id_elev", id);
            cmd.Parameters.AddWithValue("test", "3");
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
            testC3S2 f2 = new testC3S2();
            f2.Show();
        }
    }
}

C3S2
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
    public partial class testC3S2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\BazaDeDate.mdf;Integrated Security=True");
        radio[] v = new radio[100];
        int[] s = new int[100];
        int k, nr = 0, i, nota2;
        int[] v1 = new int[100];
        string s1;
        int id;
        public static string user = Autentificare.user;
        public testC3S2()
        {
            InitializeComponent();
        }

        private void testC3S2_Load(object sender, EventArgs e)
        {
            for (i = 1; i <= 99; i++)
                v1[i] = 0;

            textBox1.Enabled = false;
            textBox1.Text = user.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            k = 0;
            using (StreamReader fin = new StreamReader("C3S2.txt"))
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
                fin.Close();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (v != null && nr >= 0 && nr < v.Length && v[nr] != null)
            {
                if (v[nr].r1 != null && v[nr].rc != null && string.Compare(v[nr].r1.Trim(), v[nr].rc.Trim()) == 0)
                    s[nr] = 2;
                else
                    s[nr] = 0;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (v != null && nr >= 0 && nr < v.Length && v[nr] != null)
            {
                if (v[nr].r2 != null && v[nr].rc != null && string.Compare(v[nr].r2.Trim(), v[nr].rc.Trim()) == 0)
                    s[nr] = 2;
                else
                    s[nr] = 0;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (v != null && nr >= 0 && nr < v.Length && v[nr] != null)
            {
                if (v[nr].r3 != null && v[nr].rc != null && string.Compare(v[nr].r3.Trim(), v[nr].rc.Trim()) == 0)
                    s[nr] = 2;
                else
                    s[nr] = 0;
            }
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

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                s1 = openFileDialog1.InitialDirectory + openFileDialog1.FileName;


            }
            using (StreamWriter f = File.AppendText("rezultate.txt"))
            {
                f.WriteLine(textBox1.Text + "|" + nota2.ToString() + "|" + DateTime.Now.ToString());
                f.Close();
            }


            testC3S3 f2 = new testC3S3();
            f2.Show();
        }
    }
}

C3S3
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
    public partial class testC3S3 : Form
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
        public testC3S3()
        {
            InitializeComponent();
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

            using (StreamReader f = new StreamReader("C3S1.txt"))
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

        private void testC3S3_Load(object sender, EventArgs e)
        {
            for (i = 1; i <= 99; i++)
                v1[i] = 0;

            textBox1.Enabled = false;
            textBox1.Text = user.ToString();
        }
    }
}


TEST FINAL CHECK-BACK
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

TEST FINAL – RADIO PANEL
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


