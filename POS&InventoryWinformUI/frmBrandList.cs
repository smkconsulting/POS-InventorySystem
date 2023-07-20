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
    public partial class frmBrandList : Form
    {
        public frmBrandList()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add(i, "1", "Brand" + i.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var frm = new frmBrand();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
