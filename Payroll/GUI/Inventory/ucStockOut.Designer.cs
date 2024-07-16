﻿namespace NGPayroll
{
    partial class ucStockOut
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
            this.txtProd_qty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbProd = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblProd_name = new System.Windows.Forms.Label();
            this.dgvProd = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_CATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEL_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROD_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatia", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(458, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "Stock Out";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtProd_qty
            // 
            this.txtProd_qty.Location = new System.Drawing.Point(466, 154);
            this.txtProd_qty.Name = "txtProd_qty";
            this.txtProd_qty.Size = new System.Drawing.Size(166, 20);
            this.txtProd_qty.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Date: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(466, 186);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(166, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // cmbProd
            // 
            this.cmbProd.FormattingEnabled = true;
            this.cmbProd.Location = new System.Drawing.Point(466, 121);
            this.cmbProd.Name = "cmbProd";
            this.cmbProd.Size = new System.Drawing.Size(166, 21);
            this.cmbProd.TabIndex = 45;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(649, 172);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 34);
            this.btnAdd.TabIndex = 44;
            this.btnAdd.Text = "SOLD";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblProd_name
            // 
            this.lblProd_name.AutoSize = true;
            this.lblProd_name.Location = new System.Drawing.Point(379, 124);
            this.lblProd_name.Name = "lblProd_name";
            this.lblProd_name.Size = new System.Drawing.Size(81, 13);
            this.lblProd_name.TabIndex = 42;
            this.lblProd_name.Text = "Product Name :";
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
            this.PROD_RATE,
            this.DEL_DATE,
            this.PROD_QTY,
            this.FLAG});
            this.dgvProd.Location = new System.Drawing.Point(91, 266);
            this.dgvProd.Name = "dgvProd";
            this.dgvProd.Size = new System.Drawing.Size(846, 215);
            this.dgvProd.TabIndex = 52;
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
            // PROD_RATE
            // 
            this.PROD_RATE.HeaderText = "Rate";
            this.PROD_RATE.Name = "PROD_RATE";
            // 
            // DEL_DATE
            // 
            this.DEL_DATE.HeaderText = "DEL Date";
            this.DEL_DATE.Name = "DEL_DATE";
            // 
            // PROD_QTY
            // 
            this.PROD_QTY.HeaderText = "Quantity";
            this.PROD_QTY.Name = "PROD_QTY";
            // 
            // FLAG
            // 
            this.FLAG.HeaderText = "Column1";
            this.FLAG.Name = "FLAG";
            this.FLAG.Visible = false;
            // 
            // ucStockOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvProd);
            this.Controls.Add(this.txtProd_qty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmbProd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblProd_name);
            this.Controls.Add(this.label1);
            this.Name = "ucStockOut";
            this.Size = new System.Drawing.Size(1920, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProd_qty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbProd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblProd_name;
        private System.Windows.Forms.DataGridView dgvProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_CATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEL_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROD_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG;
    }
}
