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
    public partial class EDelete : Form
    {
        public EDelete()
        {
            InitializeComponent();
        }
        private int EmployeeId;
        private void EDelete_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = EmployeeDataAccess.Get_E_Reader_Ids();
            while (reader.Read())
            {
                cmbID.Items.Add(reader["EId"].ToString());
            }

            
        }

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeId = int.Parse(cmbID.SelectedItem.ToString());
            SqlDataReader reader = EmployeeDataAccess.Get_E_Reader_SelectedIds(EmployeeId);
            while (reader.Read())
            {
                txtName.Text = reader["EName"].ToString();
                txtECnic.Text = reader["ECnic"].ToString();
                txtPassword.Text = reader["EPassword"].ToString();
                txtDesignation.Text = reader["EdDesignation"].ToString();
                txtAddress.Text = reader["EAddress"].ToString();
                txtEPhone.Text = reader["EPhone"].ToString();
               
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EmployeeDataAccess.Delete_E_Record(EmployeeId);
            this.Hide();
        }

        private void txtCnic_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
