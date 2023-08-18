using GesPres.Classes;
using GesPres.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace GesPres.parametrage
{
    public partial class frmParametrage : Form
    {
        public frmParametrage()
        {
            InitializeComponent();
        }
        bool modifier = false;
        filiere ouldf= new filiere();
        filiere newf= new filiere();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmParametrage_Load(object sender, EventArgs e)
        {
            donnees d = new donnees();
            d.RemplirGrid("ViewF", DGVFiliere);

        }

        private void lblAb1_Click(object sender, EventArgs e)
        {

        }

        private void tbpGroupe_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            txtNumF.Text = DGVFiliere.CurrentRow.Cells[0].Value.ToString();
            txtNomF.Text = DGVFiliere.CurrentRow.Cells[1].Value.ToString();
            txtAbF.Text = DGVFiliere.CurrentRow.Cells[2].Value.ToString();
            txtNumF.Enabled=false; txtNomF.Enabled=false; txtAbF.Enabled=false;
        }

        private void DGVFiliere_DoubleClick(object sender, EventArgs e)
        {
            txtNumF.Text = DGVFiliere.CurrentRow.Cells[0].Value.ToString();
            txtNomF.Text = DGVFiliere.CurrentRow.Cells[1].Value.ToString();
            txtAbF.Text = DGVFiliere.CurrentRow.Cells[2].Value.ToString();
            txtNumF.Enabled = false; txtNomF.Enabled = false; txtAbF.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            filiere filiere = new filiere();
            filiere.GETSETNumF=txtNumF.Text;
            filiere.GETSETNomF=txtNomF.Text;
            filiere.GETSETAbF=txtAbF.Text;
            filiere.Ajouter();
            donnees donnees = new donnees();
            donnees.RemplirGrid("ViewF", DGVFiliere);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            filiere ouldf = new filiere();
            ouldf.GETSETNumF = txtNumF.Text;
            ouldf.GETSETNomF = txtNomF.Text;
            ouldf.GETSETAbF = txtAbF.Text;
            Ginterfaces ginterfaces = new Ginterfaces();
            ginterfaces.activercontroles(grbSaisieFiliere);
            modifier = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(modifier==true)
            {
                
                newf.GETSETNumF= txtNumF.Text;
                newf.GETSETNomF=(txtNomF.Text);
                newf.GETSETAbF=(txtAbF.Text);
                newf.Modifier(ouldf.GETSETNumF, newf.GETSETNumF);

                donnees donnees = new donnees();
                donnees.RemplirGrid("ViewF", DGVFiliere); 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            newf.GETSETNumF = DGVFiliere.CurrentRow.Cells[0].Value.ToString();

            newf.supprimer(newf.GETSETNumF);

            donnees donnees = new donnees();
            donnees.RemplirGrid("ViewF", DGVFiliere);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            filiere filiere = new filiere();
            filiere.GETSETNumF = txtNumF.Text;
            filiere.GETSETNomF = txtNomF.Text;
            filiere.GETSETAbF = txtAbF.Text;

            filiere.RemplirGrid(DGVFiliere, filiere.GETSETNumF, filiere.GETSETNomF, filiere.GETSETAbF); ;
        }
    }
}
