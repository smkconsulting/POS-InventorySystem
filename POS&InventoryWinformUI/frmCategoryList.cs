using POS_Inventory.BLL.Repositories;
using POS_Inventory.BO.Models;
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
    public partial class frmCategoryList : Form
    {
        public frmCategoryList()
        {
            InitializeComponent();
            LoadRecords();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var frm = new frmCategory(this);
            frm.btnUpdate.Visible = false;
            frm.lblTitle.Text = "Add Category";
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadRecords()
        {
            dataGridView1.Rows.Clear();
            var db = new CategoryRepository();
            var categories = db.GetAll().ToList();
            for (int i = 0; i < categories.Count(); i++)
            {
                dataGridView1.Rows.Add(i+1, categories[i].CategoryId, categories[i].Name);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName=="Edit")
            {
                var frm = new frmCategory(this);
                frm.btnSave.Visible = false;
                frm.lblTitle.Text = "Edit Category";
                frm.lblId.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                frm.txtCategoryName.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                frm.ShowDialog();
            }
            if (colName == "Delete")
            {
                var result = MessageBox.Show("Are you sure you want to Delete", "confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView1[1, e.RowIndex].Value.ToString());
                    var db = new CategoryRepository();
                    db.Delete(new CategoryBO() {CategoryId=id });
                    LoadRecords();
                    MessageBox.Show("Category Deleted successfully");

                }

            }
        }
    }
}
