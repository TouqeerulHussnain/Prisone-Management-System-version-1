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
    public partial class PUpdate : Form
    {
        public PUpdate()
        {
            InitializeComponent();
        }
        private int prisnerID;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PUpdate_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = DataAccessLayer.GetPrisonerIds();
            while (reader.Read())
            {
                cmbID.Items.Add(reader["PId"].ToString());
            }
        }

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            prisnerID = int.Parse(cmbID.SelectedItem.ToString());
            SqlDataReader reader = DataAccessLayer.GetPrisonerSelectedIds(prisnerID);
            while (reader.Read())
            {
                txtName.Text = reader["PName"].ToString();
                txtCNIC.Text = reader["PCnic"].ToString();
                txtEntryDate.Text = reader["DateOfEntry"].ToString();
                txtReleaseDate.Text = reader["DateOfRelease"].ToString();
                txtCrime.Text = reader["Crime"].ToString();
                txtAddress.Text = reader["PAddress"].ToString();
                txtRName.Text = reader["PRelativeName"].ToString();
                txtRPhone.Text = reader["PRPhone"].ToString();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = prisnerID;
            string name = txtName.Text;
            string cnic = txtCNIC.Text;
            string DOE = txtEntryDate.Text;
            string DOR = txtReleaseDate.Text;
            string crime = txtCrime.Text;
            string address = txtAddress.Text;
            string relativeName = txtRName.Text;
            string relativePhone = txtRPhone.Text;
            DataAccessLayer.Update(id, name, cnic, DOE, DOR, crime, address,
                    relativeName, relativePhone);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
