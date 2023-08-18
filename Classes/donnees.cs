using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GesPres.Classes
{
    public class donnees
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter adapter = new SqlDataAdapter();
        public DataSet DataSet = new DataSet();

        public void connecter()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = "initial catalog=ABSENCES; data source=CARTELOB; integrated security=true";
                con.Open();
            }
        }
        public void Deconnecter()
        {
            if (con.State == ConnectionState.Open || con.State == ConnectionState.Connecting)
            {
                con.Close();
            }
        }
        public void RemplirGrid(string TabVue, DataGridView DG)
        {
            connecter();
            cmd.CommandText = "SELECT * FROM " + TabVue;  // Ajout d'un espace après "FROM"
            cmd.Connection = con;
            adapter.SelectCommand = cmd;
            if (DataSet.Tables["DT" + TabVue] != null)
            {
                DataSet.Tables["DT" + TabVue].Clear();
            }

            adapter.Fill(DataSet, "DT" + TabVue);
            DG.DataSource = DataSet.Tables["DT" + TabVue];
            Deconnecter();
        }

    }
}
