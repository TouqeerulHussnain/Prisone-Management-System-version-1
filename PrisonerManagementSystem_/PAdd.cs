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
    public partial class PAdd : Form
    {
        public PAdd()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int prisnerID;
        int prisnerID2;
        int check = 0;
        private void txtAdd_Click(object sender, EventArgs e)
        {
            prisnerID = int.Parse(txtID.Text);
            SqlDataReader reader = DataAccessLayer.GetPrisonerIds();
            while (reader.Read())
            {
                prisnerID2 = int.Parse(reader["PId"].ToString());
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
                string DOE = txtEntryDate.Text;
                string DOR = txtReleaseDate.Text;
                string crime = txtCrime.Text;
                string address = txtAddress.Text;
                string relativeName = txtRName.Text;
                string relativePhone = txtRPhone.Text;
                try
                {
                    DataAccessLayer.AddRecord(id, name, cnic, DOE, DOR, crime, address,
                        relativeName, relativePhone);

                }
                catch (Exception)
                {

                    MessageBox.Show("Error");
                }
                
                this.Hide();
            }
            
            
        }

        private void PAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
