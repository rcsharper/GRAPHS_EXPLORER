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
            textBox1.Enabled = false;
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
}
