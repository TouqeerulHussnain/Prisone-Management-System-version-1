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
namespace PrisonerManagementSystem_.Employee
{
    public partial class Eupdate : Form
    {
        public Eupdate()
        {
            InitializeComponent();
        }

        private void Eupdate_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = EmployeeDataAccess.Get_E_Reader_Ids();
            while (reader.Read())
            {
                cmbID.Items.Add(reader["EId"].ToString());
            }
        }
        private int EmployeeId;
        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeId = int.Parse(cmbID.SelectedItem.ToString());
            SqlDataReader reader = EmployeeDataAccess.Get_E_Reader_SelectedIds(EmployeeId);
            while (reader.Read())
            {
                txtName.Text = reader["EName"].ToString();
                txtCNIC.Text = reader["ECnic"].ToString();
                txtPassword.Text = reader["EPassword"].ToString();
                txtDesignation.Text = reader["EdDesignation"].ToString();
                txtAddress.Text = reader["EAddress"].ToString();
                txtEPhone.Text = reader["EPhone"].ToString();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(cmbID.SelectedItem.ToString());
            string name = txtName.Text;
            string cnic = txtCNIC.Text;
            string password = txtPassword.Text;
            string designation = txtDesignation.Text;

            string address = txtAddress.Text;

            string Ephone = txtEPhone.Text;
            try
            {
                EmployeeDataAccess.Update_E_(id, name, cnic, password, designation, address,
                    Ephone);
                
               
            }
            catch (Exception)
            {

                MessageBox.Show("error ");
            }

            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
