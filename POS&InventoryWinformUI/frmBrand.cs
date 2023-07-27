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
    public partial class frmBrand : Form
    {
        private readonly frmBrandList _frmBrandList;
        public frmBrand(frmBrandList frm)
        {
            InitializeComponent();
            this._frmBrandList = frm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBrandName.Text!=string.Empty && txtBrandName.Text.Length>2)
            {
                var result = MessageBox.Show("Are you sure you want to Add " + txtBrandName.Text,"confirm",MessageBoxButtons.YesNo);
                if (result==DialogResult.Yes)
                {
                    var db = new BrandRepository();
                    db.Add(new BrandBO() { Name = txtBrandName.Text });
                    _frmBrandList.LoadRecords();
                    MessageBox.Show("Brand Added successfully");
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
                MessageBox.Show("Brand Name is empty or less than 3 characters", "invalid");
                return;
            }
        }
        private void ClearBoxes()
        {
            txtBrandName.Clear();
            txtBrandName.Focus();
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

        }
    }
}
