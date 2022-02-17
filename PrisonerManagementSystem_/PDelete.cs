using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PrisonerManagementSystem_
{
    public partial class PDelete : Form
    {
        public PDelete()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PDelete_Load(object sender, EventArgs e)
        {
            //DataSet dt = DataAccessLayer.GetPrisonerIdsThoughtAdapter();
          
            //cmbID.Items.Add(dt);
            
            SqlDataReader reader = DataAccessLayer.GetPrisonerIds();
            while (reader.Read())
            {
                cmbID.Items.Add(reader["PId"].ToString());
            }
        }
        private int prisnerID;
        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {

            prisnerID = int.Parse(cmbID.SelectedItem.ToString());
            SqlDataReader reader = DataAccessLayer.GetPrisonerSelectedIds(prisnerID);
            while (reader.Read())
            {
                txtName.Text = reader["PName"].ToString();
               txtCNIC.Text = reader["PCnic"].ToString();
                txtEntryDate.Text = reader["DateOfEntry"].ToString();
                txtReleaseData.Text = reader["DateOfRelease"].ToString();
                txtCirme.Text = reader["Crime"].ToString();
                txtAddress.Text = reader["PAddress"].ToString();
                txtRName.Text= reader["PRelativeName"].ToString();
                txtRPhone.Text = reader["PRPhone"].ToString();
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DataAccessLayer.DeleteRecord(prisnerID);
            this.Hide();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
