using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Domain.Entities;
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
    public partial class FrmSelection : Form
    {
        private IAssetService AssetService;
        private IEmployeeServices EmployeeServices;
        private string DNI;
        public FrmSelection(string pDNI,IEmployeeServices employeeServices,IAssetService assetService)
        {
            this.DNI = pDNI;
            this.EmployeeServices = employeeServices;
            this.AssetService = assetService;
            InitializeComponent();
        }

        private void FrmSelection_Load(object sender, EventArgs e)
        {
            FillDGV();
        }
        private void FillDGV()
        {
            this.dgvAssets.DataSource = AssetService.GetAll();
        }

        private void dgvAssets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int Id=Convert.ToInt32(dgvAssets.Rows[e.RowIndex].Cells[0].Value);
                EmployeeServices.SetAssetToEmployee(employee: EmployeeServices.FindByDni(DNI),asset: AssetService.FindById(Convert.ToInt32(Id)));
            }
        }
    }
}
