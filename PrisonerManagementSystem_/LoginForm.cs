using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrisonerManagementSystem_.Employee;
using System.Data.SqlClient;

namespace PrisonerManagementSystem_
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Home h = new Home();
            h.Show();
            this.Close();
        }



        string password;
        int Master_ID = 7420;
        string Master_Password = "7420";
        int id;
        string passwordEntered;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            passwordEntered = txtPassword.Text;
            id = int.Parse(txtName.Text);
            #region With Adapter login
            if (DataAccessLayer.MasterLogin == 0)
            {
                 
                DataSet dt = EmployeeDataAccess.Get_E_ThroughtDataAdapter(id);
                DataRow row = dt.Tables[0].Rows[0];
                password = row.ItemArray.GetValue(3).ToString();
                if (password == passwordEntered)
                {
                    MessageBox.Show("Logined");
                    this.Hide();
                    DataAccessLayer.loginSecure = 1;
                    Home h = new Home();
                    h.Show();

                }
                else
                {
                    MessageBox.Show("Invalid Inputs");
                }

            }
            else 
            {
                if (id == Master_ID && passwordEntered == Master_Password)
                {
                    MessageBox.Show("Logined");
                this.Hide();
                DataAccessLayer.loginSecure = 1;
                Home h = new Home();
                h.Show();
                }
                
            }
            

            
            #endregion
            #region with Reader Login
            //string passwordEntered = txtPassword.Text;
            //int idEnter = int.Parse(txtName.Text);
            //SqlDataReader reader = EmployeeDataAccess.Get_E_Reader_SelectedIds(idEnter);
            //while (reader.Read())
            //{


            //    password = reader["EPassword"].ToString();

            //}
            
            
           
            //if (password == passwordEntered)
            //{
            //    MessageBox.Show("Logined");
            //    this.Hide();
            //    DataAccessLayer.loginSecure = 1;
            //    Home h = new Home();
            //    h.Show();
                
            //}
            //else MessageBox.Show("Unvalid");
            #endregion
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
