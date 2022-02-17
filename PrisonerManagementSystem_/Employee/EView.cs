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
namespace PrisonerManagementSystem_.Employee
{
    public partial class EView : Form
    {
        public EView()
        {
            InitializeComponent();
            btnRewind.Enabled = false;
        }

        private void EView_Load(object sender, EventArgs e)
        {
            btnShowAll.BackColor = Color.Yellow;
            DataSet dt = EmployeeDataAccess.Get_E_ThroughtDataAdapter();
            dataGridView.DataSource = dt.Tables["Tb_data"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            DataSet dt = EmployeeDataAccess.Get_E_ThroughtDataAdapter();
            dataGridView.DataSource = dt.Tables["Tb_data"];
        }
        DataSet SDdataSet;
        int i = 0;
        int[] idArrey = new int[100];
        int id;
        int last_i;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            id = int.Parse(txtboxSearch.Text);
            idArrey[i] = id;
            SDdataSet = EmployeeDataAccess.Search_E_Reg(id); 
            
            dataGridView.DataSource = SDdataSet.Tables["Search_Edata"];
            
            last_i = i;
            i++;
            btnRewind.Enabled = true;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnRewind_Click(object sender, EventArgs e)
        {
            if (last_i <= 0)
            {
                btnRewind.Enabled = false;
                i = 0;
            }
            else 
            {
                last_i = last_i - 1;
                SDdataSet = EmployeeDataAccess.Search_E_Reg(idArrey[last_i]);
                
                dataGridView.DataSource = SDdataSet.Tables["Search_Edata"];
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
