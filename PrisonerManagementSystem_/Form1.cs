using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonerManagementSystem_
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            pictureBox1.BringToFront();
        }
        DialogResult result;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            if (DataAccessLayer.loginSecure == 1)
            {
                result = MessageBox.Show("want to log out", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel)
                {
                    DataAccessLayer.loginSecure = 1;
                }
                else if (result == DialogResult.OK)
                {
                    DataAccessLayer.loginSecure = 0;
                }
                
                Home h = new Home();
                h.Show();
                //this.Show();
            }
            else
            {
                LoginForm login = new LoginForm();
                login.Show();
            }

            
                
           
        }

        private void btnPrisoner_Click(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
            PrisonerBox.BringToFront();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.White;
            pictureBox1.BringToFront();
            
            PrisonerBox.Enabled = false;
            employeeControl1.Enabled = false;
            if (DataAccessLayer.loginSecure == 1)
            {
                PrisonerBox.Enabled = true;
                employeeControl1.Enabled = true;
                btnLogin.Text = "   Logout";
                
                btnLogin.ForeColor = Color.White;
                
            }
            
            else
            {
                btnLogin.Text = "  Login";
                btnLogin.ForeColor = Color.White;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // pictureBox1.BringToFront();
            PrisonerBox.Enabled = false;
        }

        private void prisonerControl1_Load(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
            
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
            EmployeeBox.BringToFront();
        }

        private void PrisonerBox_Enter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           // pictureBox1.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataAccessLayer.MasterLogin = 1;
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void employeeControl1_Load(object sender, EventArgs e)
        {

        }

        private void PrisonerBox_Enter_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
