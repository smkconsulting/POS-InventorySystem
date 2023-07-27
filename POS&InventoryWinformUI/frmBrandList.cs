using POS_Inventory.BLL.Repositories;
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
            LoadRecords();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var frm = new frmBrand(this);
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadRecords()
        {
            dataGridView1.Rows.Clear();
            var db = new BrandRepository();
            var brands = db.GetAll().ToList();
            for (int i = 0; i < brands.Count(); i++)
            {
                dataGridView1.Rows.Add(i+1, brands[i].BrandId, brands[i].Name);
            }
        }
    }
}
