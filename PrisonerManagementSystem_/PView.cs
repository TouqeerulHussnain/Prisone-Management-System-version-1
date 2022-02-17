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
    public partial class PView : Form
    {
        public PView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataSet SDdataSet;
        int i = 0;
        int[] idArrey = new int[100];
        int id;
        int last_i;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtboxSearch.Text);
            idArrey[i] = id;
             SDdataSet = DataAccessLayer.SearchReg(id);
            dataGridView.DataSource = SDdataSet.Tables["Search_pdata"];
            last_i = i;
            i++;
            btnRewind.Enabled = true;
           
        }

        private void PView_Load(object sender, EventArgs e)
        {
            DataSet dt = DataAccessLayer.GetThroughtDataAdapter();
            dataGridView.DataSource = dt.Tables["Tb_data"];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            DataSet dt = DataAccessLayer.GetThroughtDataAdapter();
            dataGridView.DataSource = dt.Tables["Tb_data"];
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
                SDdataSet = DataAccessLayer.SearchReg(idArrey[last_i]);

                dataGridView.DataSource = SDdataSet.Tables["Search_pdata"];
            }
        }
    }
}
