using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_InventoryWinformUI
{
    public partial class Form1 : Form
    {
        private Form activeForm;
        public void OpenChildForm(Form childform)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(childform);
            panel2.Tag = childform;
            childform.BringToFront();
            childform.Show();

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnManageBrand_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBrandList());
        }


    }
}
