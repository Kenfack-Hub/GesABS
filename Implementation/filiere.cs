using GesPres.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GesPres.Implementation
{
    public class filiere : donnees
    {
        private string NumF;
        private string NomF;
        private string AbF;

        public string GETSETNumF { get => NumF; set => NumF = value; }
        public string GETSETNomF { get => NomF; set => NomF = value; }
        public string GETSETAbF { get => AbF; set => AbF = value; }
        bool trouver(string NumF)
        {
            connecter();
            cmd.CommandText = "select count(NumF) from Filieres where NumF='" + NumF+"'";
            cmd.Connection = con;
            int nbr = int.Parse(cmd.ExecuteScalar().ToString());
            Deconnecter();
            if (nbr==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Ajouter()
        {
            if (!trouver(NumF))
            {
                connecter();
                cmd.CommandText = "INSERT INTO Filieres (NumF, NomF, AbF) VALUES (@NumF, @NomF, @AbF)";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@NumF", NumF);
                cmd.Parameters.AddWithValue("@NomF", NomF);
                cmd.Parameters.AddWithValue("@AbF", AbF);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Filière ajoutée avec succès");
                Deconnecter();
            }
            else
            {
                MessageBox.Show("Le numéro de la filière existe déjà !");
            }
        }
        public void Modifier(string ouldnumF, string newnumF)
        {
            if (!trouver(ouldnumF)==true)
            {
                if (!trouver(newnumF) == false || ouldnumF!=newnumF)
                {
                    connecter();
                    cmd.CommandText = "UPDATE Filieres SET NumF='" + NumF + "',NomF='" + NomF + "',AbF='" + AbF + "' WHERE NumF='" + ouldnumF + "'";
                   /* cmd.Parameters.AddWithValue("@NumF", NumF);
                    cmd.Parameters.AddWithValue("@NomF", NomF);
                    cmd.Parameters.AddWithValue("@AbF", AbF);*/
                    cmd.Connection=con;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Filière modifiée avec succès");
                    Deconnecter();
                }
                if (trouver(newnumF) == true || ouldnumF == newnumF)
                {
                    connecter();
                    cmd.CommandText = "UPDATE Filieres SET NomF='"+ NomF + "',AbF='" + AbF + "' WHERE NumF='" + ouldnumF + "'";
                    /*cmd.Parameters.AddWithValue("@NumF", NumF);
                    cmd.Parameters.AddWithValue("@NomF", NomF);
                    cmd.Parameters.AddWithValue("@AbF", AbF);*/
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Filière modifiée avec succès");
                    Deconnecter();
                }
            }
            else
            {
                MessageBox.Show("La filière que vous voulez modifier n'existe pas!");
            }

        }
        public void supprimer(string numf)
        {
            DialogResult r = MessageBox.Show("Voulez vous supprimer cette filière??", "Avertissement", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                if (trouver(numf) == false)
                {
                    MessageBox.Show("la filière que vous voulez supprimer n'existe pas");
                }
                else if(trouverFK(numf)==true){
                    MessageBox.Show("La filière que vous voulez supprimer est utilisée par d'autres" +
                        "ressource vous ne pouvez pas la supprimé!!","Avertissement");
                }
                else
                {
                    connecter();
                    cmd.CommandText = "DELETE FROM Filieres WHERE Numf='" + numf + "'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    Deconnecter();
                    MessageBox.Show("La filière supprimée avec succès ");
                }
            }
        }
        bool trouverFK(string NumF)
        {
            connecter();
            cmd.CommandText = "select count(NumF) from Inscription where NumF='" + NumF + "'";
            cmd.Connection = con;
            int nbr = int.Parse(cmd.ExecuteScalar().ToString());
            Deconnecter();
            if (nbr == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void RemplirGrid( DataGridView DG,string NumF, string NomF, string AbF)
        {
            string SQL = "SELECT * FROM ViewF";
            string WWHERE = "WHERE";
            if (NumF != "")
            {
                WWHERE = WWHERE + "Numéro='" + NumF + "' AND";
            }
            if (NomF != "")
            {
                WWHERE = WWHERE + "Nom LIKE'" + NomF + "%' AND";
            }
            if (AbF != "")
            {
                WWHERE = WWHERE + "Abreviation LIKE'" + AbF + "%' AND";
            }
            if (WWHERE == "WHERE")
            {
                WWHERE = "";
            }
            else
            {
                WWHERE = WWHERE.Substring(0, WWHERE.Length - 5) ;
            }
            SQL = SQL + WWHERE;
            connecter();
            cmd.CommandText = SQL;  // Ajout d'un espace après "FROM"
            cmd.Connection = con;
            adapter.SelectCommand = cmd;
            if (DataSet.Tables["DTViewF"] != null)
            {
                DataSet.Tables["DTViewF"].Clear();
            }

            adapter.Fill(DataSet, "DTViewF");
            DG.DataSource = DataSet.Tables["DTViewF"];
            Deconnecter();
        }

    }
}
