using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonerManagementSystem_.Employee
{
    public partial class EAdd : Form
    {
        public EAdd()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            
            int prisnerID;
            int prisnerID2;
            int check = 0;
            prisnerID = int.Parse(txtID.Text);
            SqlDataReader reader = EmployeeDataAccess.Get_E_Reader_Ids();
            while (reader.Read())
            {
                prisnerID2 = int.Parse(reader["EId"].ToString());
                if (prisnerID2 == prisnerID)
                {
                    MessageBox.Show("This Id Already Exit");
                    check = 1;
                    break;

                }
            }

            if (check == 0)
            {
                int id = int.Parse(txtID.Text);
                string name = txtName.Text;
                string cnic = txtCNIC.Text;
                string password = txtPassword.Text;
                string designation = txtDesignation.Text;

                string address = txtAddress.Text;

                string Ephone = txtEPhone.Text;
                try
                {

                    EmployeeDataAccess.Add_E_Record(id, name, cnic, password, designation, address,
                        Ephone);
                    MessageBox.Show("Data Added");
                }
                catch (Exception)
                {

                    MessageBox.Show("error ");
                }

                this.Hide();
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
