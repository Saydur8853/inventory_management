namespace NGPayroll
{
    partial class ucProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvProd = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_CATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProd_name = new System.Windows.Forms.TextBox();
            this.lblProd_name = new System.Windows.Forms.Label();
            this.txtProd_code = new System.Windows.Forms.TextBox();
            this.lblProd_code = new System.Windows.Forms.Label();
            this.lblProd_cate = new System.Windows.Forms.Label();
            this.CB_isActive = new System.Windows.Forms.CheckBox();
            this.cmbCate = new System.Windows.Forms.ComboBox();
            this.cmbUom = new System.Windows.Forms.ComboBox();
            this.lblProd_uom = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatia", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(387, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Products";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(537, 227);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(451, 227);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(365, 227);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(279, 227);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvProd
            // 
            this.dgvProd.AllowUserToAddRows = false;
            this.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PROD_CODE,
            this.PROD_NAME,
            this.PROD_CATE,
            this.PROD_UOM,
            this.STATUS,
            this.update});
            this.dgvProd.Location = new System.Drawing.Point(159, 285);
            this.dgvProd.Name = "dgvProd";
            this.dgvProd.Size = new System.Drawing.Size(644, 215);
            this.dgvProd.TabIndex = 11;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 60;
            // 
            // PROD_CODE
            // 
            this.PROD_CODE.HeaderText = "Product Code";
            this.PROD_CODE.Name = "PROD_CODE";
            // 
            // PROD_NAME
            // 
            this.PROD_NAME.HeaderText = "Product Name";
            this.PROD_NAME.Name = "PROD_NAME";
            this.PROD_NAME.Width = 200;
            // 
            // PROD_CATE
            // 
            this.PROD_CATE.HeaderText = "Product Category";
            this.PROD_CATE.Name = "PROD_CATE";
            this.PROD_CATE.Width = 150;
            // 
            // PROD_UOM
            // 
            this.PROD_UOM.HeaderText = "Product UOM";
            this.PROD_UOM.Name = "PROD_UOM";
            // 
            // STATUS
            // 
            this.STATUS.HeaderText = "Status";
            this.STATUS.Name = "STATUS";
            this.STATUS.Width = 50;
            // 
            // update
            // 
            this.update.HeaderText = "Column1";
            this.update.Name = "update";
            this.update.Visible = false;
            // 
            // txtProd_name
            // 
            this.txtProd_name.Location = new System.Drawing.Point(395, 102);
            this.txtProd_name.Name = "txtProd_name";
            this.txtProd_name.Size = new System.Drawing.Size(166, 20);
            this.txtProd_name.TabIndex = 10;
            // 
            // lblProd_name
            // 
            this.lblProd_name.AutoSize = true;
            this.lblProd_name.Location = new System.Drawing.Point(305, 105);
            this.lblProd_name.Name = "lblProd_name";
            this.lblProd_name.Size = new System.Drawing.Size(81, 13);
            this.lblProd_name.TabIndex = 9;
            this.lblProd_name.Text = "Product Name :";
            // 
            // txtProd_code
            // 
            this.txtProd_code.Location = new System.Drawing.Point(395, 75);
            this.txtProd_code.Name = "txtProd_code";
            this.txtProd_code.Size = new System.Drawing.Size(166, 20);
            this.txtProd_code.TabIndex = 17;
            // 
            // lblProd_code
            // 
            this.lblProd_code.AutoSize = true;
            this.lblProd_code.Location = new System.Drawing.Point(311, 79);
            this.lblProd_code.Name = "lblProd_code";
            this.lblProd_code.Size = new System.Drawing.Size(75, 13);
            this.lblProd_code.TabIndex = 16;
            this.lblProd_code.Text = "Product Code:";
            // 
            // lblProd_cate
            // 
            this.lblProd_cate.AutoSize = true;
            this.lblProd_cate.Location = new System.Drawing.Point(291, 131);
            this.lblProd_cate.Name = "lblProd_cate";
            this.lblProd_cate.Size = new System.Drawing.Size(95, 13);
            this.lblProd_cate.TabIndex = 18;
            this.lblProd_cate.Text = "Product Category :";
            // 
            // CB_isActive
            // 
            this.CB_isActive.AutoSize = true;
            this.CB_isActive.Location = new System.Drawing.Point(395, 188);
            this.CB_isActive.Name = "CB_isActive";
            this.CB_isActive.Size = new System.Drawing.Size(15, 14);
            this.CB_isActive.TabIndex = 19;
            this.CB_isActive.UseVisualStyleBackColor = true;
            // 
            // cmbCate
            // 
            this.cmbCate.FormattingEnabled = true;
            this.cmbCate.Location = new System.Drawing.Point(395, 129);
            this.cmbCate.Name = "cmbCate";
            this.cmbCate.Size = new System.Drawing.Size(166, 21);
            this.cmbCate.TabIndex = 20;
            this.cmbCate.SelectedIndexChanged += new System.EventHandler(this.cmbCate_SelectedIndexChanged);
            // 
            // cmbUom
            // 
            this.cmbUom.FormattingEnabled = true;
            this.cmbUom.Location = new System.Drawing.Point(395, 156);
            this.cmbUom.Name = "cmbUom";
            this.cmbUom.Size = new System.Drawing.Size(166, 21);
            this.cmbUom.TabIndex = 22;
            this.cmbUom.SelectedIndexChanged += new System.EventHandler(this.cmbUom_SelectedIndexChanged);
            // 
            // lblProd_uom
            // 
            this.lblProd_uom.AutoSize = true;
            this.lblProd_uom.Location = new System.Drawing.Point(308, 158);
            this.lblProd_uom.Name = "lblProd_uom";
            this.lblProd_uom.Size = new System.Drawing.Size(78, 13);
            this.lblProd_uom.TabIndex = 21;
            this.lblProd_uom.Text = "Product UOM :";
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(332, 188);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(54, 13);
            this.lblActive.TabIndex = 23;
            this.lblActive.Text = "Is Active :";
            // 
            // ucProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.cmbUom);
            this.Controls.Add(this.lblProd_uom);
            this.Controls.Add(this.cmbCate);
            this.Controls.Add(this.CB_isActive);
            this.Controls.Add(this.lblProd_cate);
            this.Controls.Add(this.txtProd_code);
            this.Controls.Add(this.lblProd_code);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvProd);
            this.Controls.Add(this.txtProd_name);
            this.Controls.Add(this.lblProd_name);
            this.Controls.Add(this.label1);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(1120, 620);
            this.Load += new System.EventHandler(this.ucProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvProd;
        private System.Windows.Forms.TextBox txtProd_name;
        private System.Windows.Forms.Label lblProd_name;
        private System.Windows.Forms.TextBox txtProd_code;
        private System.Windows.Forms.Label lblProd_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_CATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn update;
        private System.Windows.Forms.Label lblProd_cate;
        private System.Windows.Forms.CheckBox CB_isActive;
        private System.Windows.Forms.ComboBox cmbCate;
        private System.Windows.Forms.ComboBox cmbUom;
        private System.Windows.Forms.Label lblProd_uom;
        private System.Windows.Forms.Label lblActive;
    }
}
