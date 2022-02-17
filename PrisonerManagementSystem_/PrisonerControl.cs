using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonerManagementSystem_
{
    public partial class PrisonerControl : UserControl
    {
        public PrisonerControl()
        {
            InitializeComponent();
        }

        private void btnPrisoner_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPrisoner_Click(object sender, EventArgs e)
        {
            PAdd add = new PAdd();
            add.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PDelete del = new PDelete();
            del.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PUpdate up = new PUpdate();
            up.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            PView view = new PView();
            view.Show();
        }
    }
}
