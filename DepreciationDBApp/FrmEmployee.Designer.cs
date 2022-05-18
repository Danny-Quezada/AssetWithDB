
namespace DepreciationDBApp.Forms
{
    partial class FrmEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtLastNames = new System.Windows.Forms.TextBox();
            this.txtNames = new System.Windows.Forms.TextBox();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.cmsAssets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarAssetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbInformation.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.cmsAssets.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.flowLayoutPanel1);
            this.gbInformation.Controls.Add(this.label6);
            this.gbInformation.Controls.Add(this.label5);
            this.gbInformation.Controls.Add(this.label4);
            this.gbInformation.Controls.Add(this.label3);
            this.gbInformation.Controls.Add(this.label2);
            this.gbInformation.Controls.Add(this.label1);
            this.gbInformation.Controls.Add(this.txtDNI);
            this.gbInformation.Controls.Add(this.txtEmail);
            this.gbInformation.Controls.Add(this.txtPhone);
            this.gbInformation.Controls.Add(this.txtAddress);
            this.gbInformation.Controls.Add(this.txtLastNames);
            this.gbInformation.Controls.Add(this.txtNames);
            this.gbInformation.Location = new System.Drawing.Point(12, 21);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(257, 417);
            this.gbInformation.TabIndex = 0;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Information";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCreate);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 339);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 72);
            this.flowLayoutPanel1.TabIndex = 13;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(3, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(111, 30);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "Create Employee";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 30);
            this.button2.TabIndex = 13;
            this.button2.Text = "Delete Employee";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "DNI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "LastName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Names";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(81, 289);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(170, 23);
            this.txtDNI.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(81, 237);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(170, 23);
            this.txtEmail.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(81, 188);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(170, 23);
            this.txtPhone.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(81, 142);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(170, 23);
            this.txtAddress.TabIndex = 2;
            // 
            // txtLastNames
            // 
            this.txtLastNames.Location = new System.Drawing.Point(81, 90);
            this.txtLastNames.Name = "txtLastNames";
            this.txtLastNames.Size = new System.Drawing.Size(170, 23);
            this.txtLastNames.TabIndex = 1;
            // 
            // txtNames
            // 
            this.txtNames.Location = new System.Drawing.Point(81, 45);
            this.txtNames.Name = "txtNames";
            this.txtNames.Size = new System.Drawing.Size(170, 23);
            this.txtNames.TabIndex = 0;
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.ContextMenuStrip = this.cmsAssets;
            this.dgvEmployee.Location = new System.Drawing.Point(317, 12);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowTemplate.Height = 25;
            this.dgvEmployee.Size = new System.Drawing.Size(641, 439);
            this.dgvEmployee.TabIndex = 1;
            this.dgvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellContentClick);
            // 
            // cmsAssets
            // 
            this.cmsAssets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarAssetsToolStripMenuItem});
            this.cmsAssets.Name = "cmsAssets";
            this.cmsAssets.Size = new System.Drawing.Size(151, 26);
            // 
            // agregarAssetsToolStripMenuItem
            // 
            this.agregarAssetsToolStripMenuItem.Name = "agregarAssetsToolStripMenuItem";
            this.agregarAssetsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarAssetsToolStripMenuItem.Text = "Agregar assets";
            this.agregarAssetsToolStripMenuItem.Click += new System.EventHandler(this.agregarAssetsToolStripMenuItem_Click);
            // 
            // FrmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 494);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.gbInformation);
            this.Name = "FrmEmployee";
            this.Text = "FrmEmployee";
            this.Load += new System.EventHandler(this.FrmEmployee_Load);
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.cmsAssets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.TextBox txtNames;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtLastNames;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.ContextMenuStrip cmsAssets;
        private System.Windows.Forms.ToolStripMenuItem agregarAssetsToolStripMenuItem;
    }
}