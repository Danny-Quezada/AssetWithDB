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
    public partial class FrmEmployee : Form
    {
        private IAssetService AssetService;
        private IEmployeeServices EmployeeServices;
        private int selection=-1;

        public FrmEmployee(IEmployeeServices employeeServices,IAssetService assetService)
        {
            this.AssetService = assetService;
            this.EmployeeServices = employeeServices;
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Validate() == false)
            {
                MessageBox.Show("Rellene todos los datos, por favor");
                return;
            }
            Employee employee = new Employee
            {
                Names=txtNames.Text,
                Lastname=txtLastNames.Text,
                Address=txtAddress.Text,
                Dni=txtDNI.Text,
                Email=txtEmail.Text,
                Phone=txtPhone.Text,
                Status="Active"
            };
            EmployeeServices.Create(employee);
            CleanTxt();
            fillDgv();
        }

        private bool Validate()
        {
            if(string.IsNullOrEmpty(txtNames.Text) && string.IsNullOrEmpty(txtLastNames.Text) && string.IsNullOrEmpty(txtAddress.Text) && string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtDNI.Text))
            {
                return false;
            }
            return true;
        }
        private void fillDgv()
        {
            dgvEmployee.DataSource = null;
            List<Employee> employees = EmployeeServices.GetAll();
            dgvEmployee.DataSource = employees;
        }
        private void CleanTxt()
        {
            txtAddress.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            txtLastNames.Clear();
            txtNames.Clear();
            txtPhone.Clear();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            fillDgv();
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selection = e.RowIndex;

                
            }
          
        }

        private void agregarAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selection >= 0)
            {
                string DNI =(string) dgvEmployee.Rows[selection].Cells[6].Value;
                FrmSelection frmSelection = new FrmSelection(DNI, EmployeeServices, AssetService);
                frmSelection.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione empleado por favor.");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
