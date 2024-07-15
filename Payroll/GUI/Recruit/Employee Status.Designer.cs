using System.Windows.Forms;
using System.Drawing;

namespace NGPayroll
{
    partial class employee_status_UC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employee_status_UC));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_unit_id = new System.Windows.Forms.TextBox();
            this.txt_section_id = new System.Windows.Forms.TextBox();
            this.txt_dept_id = new System.Windows.Forms.TextBox();
            this.txt_emp_type = new System.Windows.Forms.TextBox();
            this.txt_line_id = new System.Windows.Forms.TextBox();
            this.txt_designation_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker_from = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker_to = new System.Windows.Forms.DateTimePicker();
            this.datagrid_emp_status = new System.Windows.Forms.DataGridView();
            this.emp_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tr_stand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.combo_emp_type = new System.Windows.Forms.ComboBox();
            this.combo_department = new System.Windows.Forms.ComboBox();
            this.combo_line_name = new System.Windows.Forms.ComboBox();
            this.combo_section_name = new System.Windows.Forms.ComboBox();
            this.combo_designation_name = new System.Windows.Forms.ComboBox();
            this.combo_unit_name = new System.Windows.Forms.ComboBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.btnExitUserControl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_emp_status)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(465, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Status";
            // 
            // txt_unit_id
            // 
            this.txt_unit_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_unit_id.Location = new System.Drawing.Point(501, 80);
            this.txt_unit_id.Name = "txt_unit_id";
            this.txt_unit_id.Size = new System.Drawing.Size(37, 20);
            this.txt_unit_id.TabIndex = 1;
            this.txt_unit_id.Visible = false;
            // 
            // txt_section_id
            // 
            this.txt_section_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_section_id.Location = new System.Drawing.Point(501, 110);
            this.txt_section_id.Name = "txt_section_id";
            this.txt_section_id.Size = new System.Drawing.Size(37, 20);
            this.txt_section_id.TabIndex = 2;
            this.txt_section_id.Visible = false;
            // 
            // txt_dept_id
            // 
            this.txt_dept_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_dept_id.Location = new System.Drawing.Point(501, 137);
            this.txt_dept_id.Name = "txt_dept_id";
            this.txt_dept_id.Size = new System.Drawing.Size(37, 20);
            this.txt_dept_id.TabIndex = 3;
            this.txt_dept_id.Visible = false;
            // 
            // txt_emp_type
            // 
            this.txt_emp_type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_emp_type.Location = new System.Drawing.Point(995, 82);
            this.txt_emp_type.Name = "txt_emp_type";
            this.txt_emp_type.Size = new System.Drawing.Size(41, 20);
            this.txt_emp_type.TabIndex = 4;
            this.txt_emp_type.Visible = false;
            // 
            // txt_line_id
            // 
            this.txt_line_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_line_id.Location = new System.Drawing.Point(995, 110);
            this.txt_line_id.Name = "txt_line_id";
            this.txt_line_id.Size = new System.Drawing.Size(41, 20);
            this.txt_line_id.TabIndex = 5;
            this.txt_line_id.Visible = false;
            // 
            // txt_designation_id
            // 
            this.txt_designation_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_designation_id.Location = new System.Drawing.Point(995, 137);
            this.txt_designation_id.Name = "txt_designation_id";
            this.txt_designation_id.Size = new System.Drawing.Size(41, 20);
            this.txt_designation_id.TabIndex = 6;
            this.txt_designation_id.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(103, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Unit Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(103, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Section";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(103, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Department";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(575, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Employee Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(575, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Line";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(575, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Designation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(285, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Date From";
            // 
            // dateTimePicker_from
            // 
            this.dateTimePicker_from.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_from.Location = new System.Drawing.Point(365, 177);
            this.dateTimePicker_from.Name = "dateTimePicker_from";
            this.dateTimePicker_from.Size = new System.Drawing.Size(133, 21);
            this.dateTimePicker_from.TabIndex = 6;
            this.dateTimePicker_from.ValueChanged += new System.EventHandler(this.dateTimePicker_from_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Location = new System.Drawing.Point(515, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "To";
            // 
            // dateTimePicker_to
            // 
            this.dateTimePicker_to.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_to.Location = new System.Drawing.Point(554, 177);
            this.dateTimePicker_to.Name = "dateTimePicker_to";
            this.dateTimePicker_to.Size = new System.Drawing.Size(131, 21);
            this.dateTimePicker_to.TabIndex = 7;
            // 
            // datagrid_emp_status
            // 
            this.datagrid_emp_status.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_emp_status.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagrid_emp_status.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_emp_status.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emp_code,
            this.name,
            this.designation,
            this.joining,
            this.gross,
            this.age,
            this.ot,
            this.tr,
            this.tr_stand});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagrid_emp_status.DefaultCellStyle = dataGridViewCellStyle6;
            this.datagrid_emp_status.Location = new System.Drawing.Point(106, 217);
            this.datagrid_emp_status.Name = "datagrid_emp_status";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_emp_status.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.datagrid_emp_status.Size = new System.Drawing.Size(883, 325);
            this.datagrid_emp_status.TabIndex = 19;
            // 
            // emp_code
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.emp_code.DefaultCellStyle = dataGridViewCellStyle2;
            this.emp_code.HeaderText = "EMP CODE";
            this.emp_code.Name = "emp_code";
            this.emp_code.ReadOnly = true;
            // 
            // name
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.name.DefaultCellStyle = dataGridViewCellStyle3;
            this.name.HeaderText = "NAME";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 200;
            // 
            // designation
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.designation.DefaultCellStyle = dataGridViewCellStyle4;
            this.designation.HeaderText = "DESIGNATION";
            this.designation.Name = "designation";
            this.designation.ReadOnly = true;
            this.designation.Width = 150;
            // 
            // joining
            // 
            dataGridViewCellStyle5.Format = "dd-MMM-yyyy";
            this.joining.DefaultCellStyle = dataGridViewCellStyle5;
            this.joining.HeaderText = "JOINING";
            this.joining.Name = "joining";
            // 
            // gross
            // 
            this.gross.HeaderText = "GROSS";
            this.gross.Name = "gross";
            // 
            // age
            // 
            this.age.HeaderText = "AGE";
            this.age.Name = "age";
            this.age.ReadOnly = true;
            this.age.Width = 50;
            // 
            // ot
            // 
            this.ot.HeaderText = "OT";
            this.ot.Name = "ot";
            this.ot.Width = 50;
            // 
            // tr
            // 
            this.tr.HeaderText = "TR";
            this.tr.Name = "tr";
            this.tr.Width = 50;
            // 
            // tr_stand
            // 
            this.tr_stand.HeaderText = "TR.STAND";
            this.tr_stand.Name = "tr_stand";
            this.tr_stand.Width = 80;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(932, 550);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.TabIndex = 99;
            this.label9.Text = "Total";
            // 
            // combo_emp_type
            // 
            this.combo_emp_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_emp_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_emp_type.DropDownHeight = 120;
            this.combo_emp_type.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_emp_type.FormattingEnabled = true;
            this.combo_emp_type.IntegralHeight = false;
            this.combo_emp_type.Location = new System.Drawing.Point(680, 81);
            this.combo_emp_type.Name = "combo_emp_type";
            this.combo_emp_type.Size = new System.Drawing.Size(312, 23);
            this.combo_emp_type.TabIndex = 1;
            this.combo_emp_type.SelectedIndexChanged += new System.EventHandler(this.combo_emp_type_SelectedIndexChanged);
            this.combo_emp_type.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_emp_type_KeyPress);
            // 
            // combo_department
            // 
            this.combo_department.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_department.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_department.DropDownHeight = 120;
            this.combo_department.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_department.FormattingEnabled = true;
            this.combo_department.IntegralHeight = false;
            this.combo_department.Location = new System.Drawing.Point(191, 136);
            this.combo_department.Name = "combo_department";
            this.combo_department.Size = new System.Drawing.Size(307, 23);
            this.combo_department.TabIndex = 4;
            this.combo_department.SelectedIndexChanged += new System.EventHandler(this.combo_department_SelectedIndexChanged);
            this.combo_department.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_department_KeyPress);
            // 
            // combo_line_name
            // 
            this.combo_line_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_line_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_line_name.DropDownHeight = 120;
            this.combo_line_name.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_line_name.FormattingEnabled = true;
            this.combo_line_name.IntegralHeight = false;
            this.combo_line_name.Location = new System.Drawing.Point(680, 109);
            this.combo_line_name.Name = "combo_line_name";
            this.combo_line_name.Size = new System.Drawing.Size(312, 23);
            this.combo_line_name.TabIndex = 3;
            this.combo_line_name.SelectedIndexChanged += new System.EventHandler(this.combo_line_name_SelectedIndexChanged);
            this.combo_line_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_line_name_KeyPress);
            // 
            // combo_section_name
            // 
            this.combo_section_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_section_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_section_name.DropDownHeight = 120;
            this.combo_section_name.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_section_name.FormattingEnabled = true;
            this.combo_section_name.IntegralHeight = false;
            this.combo_section_name.Location = new System.Drawing.Point(191, 108);
            this.combo_section_name.Name = "combo_section_name";
            this.combo_section_name.Size = new System.Drawing.Size(307, 23);
            this.combo_section_name.TabIndex = 2;
            this.combo_section_name.SelectedIndexChanged += new System.EventHandler(this.combo_section_name_SelectedIndexChanged);
            this.combo_section_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_section_name_KeyPress);
            // 
            // combo_designation_name
            // 
            this.combo_designation_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_designation_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_designation_name.DropDownHeight = 120;
            this.combo_designation_name.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_designation_name.FormattingEnabled = true;
            this.combo_designation_name.IntegralHeight = false;
            this.combo_designation_name.Location = new System.Drawing.Point(680, 137);
            this.combo_designation_name.Name = "combo_designation_name";
            this.combo_designation_name.Size = new System.Drawing.Size(312, 23);
            this.combo_designation_name.TabIndex = 5;
            this.combo_designation_name.SelectedIndexChanged += new System.EventHandler(this.combo_designation_name_SelectedIndexChanged);
            this.combo_designation_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_designation_name_KeyPress);
            // 
            // combo_unit_name
            // 
            this.combo_unit_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combo_unit_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_unit_name.DropDownHeight = 120;
            this.combo_unit_name.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_unit_name.FormattingEnabled = true;
            this.combo_unit_name.IntegralHeight = false;
            this.combo_unit_name.Location = new System.Drawing.Point(191, 79);
            this.combo_unit_name.Name = "combo_unit_name";
            this.combo_unit_name.Size = new System.Drawing.Size(307, 23);
            this.combo_unit_name.TabIndex = 0;
            this.combo_unit_name.SelectedIndexChanged += new System.EventHandler(this.combo_unit_name_SelectedIndexChanged);
            this.combo_unit_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_unit_name_KeyPress);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.Window;
            this.btn_clear.BackgroundImage = global::NGPayroll.Properties.Resources.clear;
            this.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(538, 562);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(84, 32);
            this.btn_clear.TabIndex = 9;
            this.btn_clear.Text = "Clear";
            this.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.Window;
            this.btn_save.BackgroundImage = global::NGPayroll.Properties.Resources.save1;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_save.Location = new System.Drawing.Point(447, 562);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(92, 32);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Save";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Window;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = global::NGPayroll.Properties.Resources.delete_all_participants;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(152, 575);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(134, 37);
            this.button6.TabIndex = 13;
            this.button6.Text = "Micro Delete";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Window;
            this.button5.BackgroundImage = global::NGPayroll.Properties.Resources.gnome_edit_delete;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(55, 575);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 37);
            this.button5.TabIndex = 12;
            this.button5.Text = "Delete";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.SystemColors.Window;
            this.btn_search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_search.BackgroundImage")));
            this.btn_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_search.Location = new System.Drawing.Point(692, 171);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(35, 30);
            this.btn_search.TabIndex = 8;
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btnExitUserControl
            // 
            this.btnExitUserControl.BackColor = System.Drawing.SystemColors.Window;
            this.btnExitUserControl.BackgroundImage = global::NGPayroll.Properties.Resources.Close;
            this.btnExitUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExitUserControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitUserControl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitUserControl.Location = new System.Drawing.Point(621, 562);
            this.btnExitUserControl.Name = "btnExitUserControl";
            this.btnExitUserControl.Size = new System.Drawing.Size(83, 32);
            this.btnExitUserControl.TabIndex = 100;
            this.btnExitUserControl.Text = "Exit";
            this.btnExitUserControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExitUserControl.UseVisualStyleBackColor = false;
            this.btnExitUserControl.Visible = false;
            this.btnExitUserControl.Click += new System.EventHandler(this.btnExitUserControl_Click);
            // 
            // employee_status_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NGPayroll.Properties.Resources.bk_images1;
            this.Controls.Add(this.btnExitUserControl);
            this.Controls.Add(this.combo_unit_name);
            this.Controls.Add(this.combo_designation_name);
            this.Controls.Add(this.combo_section_name);
            this.Controls.Add(this.combo_line_name);
            this.Controls.Add(this.combo_department);
            this.Controls.Add(this.combo_emp_type);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.datagrid_emp_status);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.dateTimePicker_to);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePicker_from);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_designation_id);
            this.Controls.Add(this.txt_line_id);
            this.Controls.Add(this.txt_emp_type);
            this.Controls.Add(this.txt_dept_id);
            this.Controls.Add(this.txt_section_id);
            this.Controls.Add(this.txt_unit_id);
            this.Controls.Add(this.label1);
            this.Name = "employee_status_UC";
            this.Size = new System.Drawing.Size(1087, 662);
            this.Load += new System.EventHandler(this.employee_status_UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_emp_status)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_unit_id;
        private System.Windows.Forms.TextBox txt_section_id;
        private System.Windows.Forms.TextBox txt_dept_id;
        private System.Windows.Forms.TextBox txt_emp_type;
        private System.Windows.Forms.TextBox txt_line_id;
        private System.Windows.Forms.TextBox txt_designation_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker_from;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker_to;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView datagrid_emp_status;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_save;
        private Label label9;
        private ComboBox combo_emp_type;
        private ComboBox combo_department;
        private ComboBox combo_line_name;
        private ComboBox combo_section_name;
        private ComboBox combo_designation_name;
        private ComboBox combo_unit_name;
        private DataGridViewTextBoxColumn emp_code;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn designation;
        private DataGridViewTextBoxColumn joining;
        private DataGridViewTextBoxColumn gross;
        private DataGridViewTextBoxColumn age;
        private DataGridViewTextBoxColumn ot;
        private DataGridViewTextBoxColumn tr;
        private DataGridViewTextBoxColumn tr_stand;
        private Button btnExitUserControl;
    }
}
