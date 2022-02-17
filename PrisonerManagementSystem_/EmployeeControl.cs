using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrisonerManagementSystem_.Employee;
namespace PrisonerManagementSystem_
{
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl()
        {
            InitializeComponent();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EDelete del = new EDelete();
            del.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            
            EView view = new EView();
            view.Show();
        }

        private void btnAddPrisoner_Click(object sender, EventArgs e)
        {
            EAdd add = new EAdd();
            add.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Eupdate update = new Eupdate();
            update.Show();
        }
    }
}
