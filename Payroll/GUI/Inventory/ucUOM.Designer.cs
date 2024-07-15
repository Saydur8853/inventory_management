namespace NGPayroll
{
    partial class ucUom
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvUOM = new System.Windows.Forms.DataGridView();
            this.txtUom = new System.Windows.Forms.TextBox();
            this.lblUom = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUOM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatia", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(455, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "UOM";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(614, 129);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvUOM
            // 
            this.dgvUOM.AllowUserToAddRows = false;
            this.dgvUOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUOM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.UOM,
            this.FLAG});
            this.dgvUOM.Location = new System.Drawing.Point(346, 171);
            this.dgvUOM.Name = "dgvUOM";
            this.dgvUOM.Size = new System.Drawing.Size(343, 150);
            this.dgvUOM.TabIndex = 8;
            this.dgvUOM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUOM_CellContentClick);
            this.dgvUOM.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUOM_CellEndEdit);
            // 
            // txtUom
            // 
            this.txtUom.Location = new System.Drawing.Point(387, 132);
            this.txtUom.Name = "txtUom";
            this.txtUom.Size = new System.Drawing.Size(221, 20);
            this.txtUom.TabIndex = 7;
            // 
            // lblUom
            // 
            this.lblUom.AutoSize = true;
            this.lblUom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblUom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUom.Location = new System.Drawing.Point(343, 135);
            this.lblUom.Name = "lblUom";
            this.lblUom.Size = new System.Drawing.Size(40, 15);
            this.lblUom.TabIndex = 6;
            this.lblUom.Text = "UOM :";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(727, 217);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(727, 171);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(727, 130);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            this.UOM.Width = 200;
            // 
            // FLAG
            // 
            this.FLAG.HeaderText = "Column1";
            this.FLAG.Name = "FLAG";
            this.FLAG.Visible = false;
            // 
            // ucUom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvUOM);
            this.Controls.Add(this.txtUom);
            this.Controls.Add(this.lblUom);
            this.Controls.Add(this.label1);
            this.Name = "ucUom";
            this.Size = new System.Drawing.Size(1120, 620);
            this.Load += new System.EventHandler(this.ucUom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvUOM;
        private System.Windows.Forms.TextBox txtUom;
        private System.Windows.Forms.Label lblUom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG;
    }
}
