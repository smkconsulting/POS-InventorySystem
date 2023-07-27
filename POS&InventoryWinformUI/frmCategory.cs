using POS_Inventory.BLL.Repositories;
using POS_Inventory.BO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_InventoryWinformUI
{
    public partial class frmCategory : Form
    {
        private readonly frmCategoryList _frmCategoryList;
        public frmCategory(frmCategoryList frm)
        {
            InitializeComponent();
            this._frmCategoryList = frm;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text!=string.Empty && txtCategoryName.Text.Length>2)
            {
                var result = MessageBox.Show("Are you sure you want to Add " + 
                    txtCategoryName.Text,"confirm",MessageBoxButtons.YesNo);
                if (result==DialogResult.Yes)
                {
                    var db = new CategoryRepository();
                    db.Add(new CategoryBO() { Name = txtCategoryName.Text });
                    _frmCategoryList.LoadRecords();
                    MessageBox.Show("Category Added successfully");
                    ClearBoxes();
                    return;
                }
                else
                {
                    ClearBoxes();
                    return;
                }
            }
           else
            {
                MessageBox.Show("Category Name is empty or less than 3 characters", "invalid");
                return;
            }
        }
        private void ClearBoxes()
        {
            txtCategoryName.Clear();
            txtCategoryName.Focus();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text != string.Empty && txtCategoryName.Text.Length > 2)
            {
                var result = MessageBox.Show("Are you sure you want to Update " +
                    txtCategoryName.Text, "confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var db = new CategoryRepository();
                    db.Update(new CategoryBO() { CategoryId = int.Parse(lblId.Text), Name = txtCategoryName.Text });
                    _frmCategoryList.LoadRecords();
                    MessageBox.Show("Category Updated successfully");
                    this.Close();

                }
                else
                {
                    ClearBoxes();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Category Name is empty or less than 3 characters", "invalid");
                return;
            }

        }
    }
}
