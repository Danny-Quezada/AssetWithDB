using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Enums;
using DepreciationDBApp.Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepreciationDBApp.Forms
{
    public partial class Form1 : Form
    {
        private IAssetService assetService;
        private IEmployeeServices employeeServices;
        public Form1(IEmployeeServices eemployeeServices, IAssetService assetService)
        {
            this.assetService = assetService;
            this.employeeServices = eemployeeServices;
            InitializeComponent();
            
        }

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            if(Validations.emptyFIelds(txtName.Text, txtDescription.Text, txtAmount.Text, txtAmount_Residual.Text, txtTerms.Text, cmbStatus.SelectedIndex))
            {
                if(Validations.ValidationAmount(decimal.Parse(txtAmount.Text), decimal.Parse(txtAmount_Residual.Text)))
                {
                    Asset asset = new Asset()
                    {
                        Name = txtName.Text,
                        Description = txtDescription.Text,
                        Amount = decimal.Parse(txtAmount.Text),
                        AmountResidual = decimal.Parse(txtAmount_Residual.Text),
                        Terms = Int32.Parse(txtTerms.Text),
                        Code = Guid.NewGuid().ToString(),
                        Status = cmbStatus.SelectedItem.ToString(),
                        IsActive = true
                    };
                    assetService.Create(asset);
                    cleanTxts();
                    fillDgv();
                    return;
                }
                MessageBox.Show("The Amount must be mayor that the Amount_Residual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("You have must fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            fillDgv();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validations.emptyFIelds(txtName.Text, txtDescription.Text, txtAmount.Text, txtAmount_Residual.Text, txtTerms.Text, cmbStatus.SelectedIndex))
            {
                if (Validations.ValidationAmount(decimal.Parse(txtAmount.Text), decimal.Parse(txtAmount_Residual.Text)))
                {
                    object n = dgvAsset.CurrentRow.Cells[0].Value;
                    Asset asset = assetService.FindById((Int32)n);
                    asset.Name = txtName.Text;
                    asset.Description = txtDescription.Text;
                    asset.Amount = decimal.Parse(txtAmount.Text);
                    asset.AmountResidual = decimal.Parse(txtAmount_Residual.Text);
                    asset.Terms = Int32.Parse(txtTerms.Text);
                    asset.Status = cmbStatus.SelectedItem.ToString();

                    assetService.Update(asset);
                    cleanTxts();
                    fillDgv();
                    return;
                }
                MessageBox.Show("The Amount must be mayor that the Amount_Residual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("You have must fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.AddRange(Enum.GetValues(typeof(StatusAsset)).Cast<object>().ToArray());
            fillDgv();
            txtSearch.Visible = false;
            btnSearch.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                object n = dgvAsset.CurrentRow.Cells[0].Value;
                Asset asset = assetService.FindById((Int32)n);
                asset.IsActive = false;
                assetService.Update(asset);
                if (assetService.Delete(asset))
                {
                    cleanTxts();
                    fillDgv();
                }
            }
            catch
            {
                MessageBox.Show("You must select a DataGridView element", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAsset_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
//                Asset asset = assetService.FindById(e.RowIndex);
                Asset asset = assetService.GetAll()[e.RowIndex];
                txtName.Text = asset.Name;
                txtDescription.Text = asset.Description;
                txtAmount.Text = asset.Amount.ToString();
                txtAmount_Residual.Text = asset.AmountResidual.ToString();
                txtTerms.Text = asset.Terms.ToString();
                
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only letters are allowed");
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed");
            }
        }

        private void txtAmount_Residual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed");
            }
        }

        private void txtTerms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed");
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }

        private void cmbSelectSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            txtSearch.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbSelectSearch.SelectedIndex > -1)
            {
                if (cmbSelectSearch.SelectedIndex == 0)
                {
                    List<Asset> assets = new List<Asset>();
                    assets.Add(assetService.FindById(Int32.Parse(txtSearch.Text)));
                    fillDgv(assets);
                    return;
                }
                List<Asset> assets1 = assetService.FindByName(txtSearch.Text);
                fillDgv(assets1);
                return;

            }
            MessageBox.Show("You have to select an option in the comboBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region
        private void cleanTxts()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtAmount_Residual.Text = string.Empty;
            txtTerms.Text = string.Empty;
            cmbStatus.SelectedIndex = -1;
        }
        private void fillDgv(List<Asset> assets)
        {
            dgvAsset.DataSource = null;
            dgvAsset.DataSource = assets;
        }
        private void fillDgv()
        {
            dgvAsset.DataSource = null;
            List<Asset> assets = assetService.GetAll();
            dgvAsset.DataSource = assets;
        }
        #endregion

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmbSelectSearch.SelectedIndex == 0)
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Only numbers are allowed");
                    return;
                }
            }
            else
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Only letters are allowed");
                }
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            FrmEmployee frmEmployee = new FrmEmployee(employeeServices,assetService);
            frmEmployee.ShowDialog();
        }
    }
}
