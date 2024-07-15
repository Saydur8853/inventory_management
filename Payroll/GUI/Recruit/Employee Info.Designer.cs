using System.Windows.Forms;
using System.Drawing;
using System;
using System.Data;
using System.Data.OracleClient;

namespace NGPayroll
{
    partial class employee_Information_UC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employee_Information_UC));
            this.emp_info_lbl = new System.Windows.Forms.Label();
            this.txtEmpCode = new System.Windows.Forms.TextBox();
            this.txt_emp_name = new System.Windows.Forms.TextBox();
            this.txt_father_name = new System.Windows.Forms.TextBox();
            this.txt_emp_mother = new System.Windows.Forms.TextBox();
            this.combo_gender = new System.Windows.Forms.ComboBox();
            this.combo_religion = new System.Windows.Forms.ComboBox();
            this.combo_marital = new System.Windows.Forms.ComboBox();
            this.combo_blood = new System.Windows.Forms.ComboBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.txt_vill_present = new System.Windows.Forms.TextBox();
            this.txt_po_present = new System.Windows.Forms.TextBox();
            this.txt_ps_present = new System.Windows.Forms.TextBox();
            this.txt_vill_parmanent = new System.Windows.Forms.TextBox();
            this.txt_po_parmanent = new System.Windows.Forms.TextBox();
            this.txt_ps_parmanent = new System.Windows.Forms.TextBox();
            this.txt_national_id = new System.Windows.Forms.TextBox();
            this.txt_remarks = new System.Windows.Forms.TextBox();
            this.txt_beneficiary = new System.Windows.Forms.TextBox();
            this.combo_relation = new System.Windows.Forms.ComboBox();
            this.dtpCloseDate = new System.Windows.Forms.DateTimePicker();
            this.emp_code_lbl = new System.Windows.Forms.Label();
            this.name_lbl = new System.Windows.Forms.Label();
            this.father_lbl = new System.Windows.Forms.Label();
            this.mother_lbl = new System.Windows.Forms.Label();
            this.gender_lbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.marital_lbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bday_lbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.vill_lbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.vill1_lbl = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ps_lbl = new System.Windows.Forms.Label();
            this.ps1_lbl = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.txt_designation = new System.Windows.Forms.TextBox();
            this.txt_unit = new System.Windows.Forms.TextBox();
            this.txt_category = new System.Windows.Forms.TextBox();
            this.txt_department = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txt_section = new System.Windows.Forms.TextBox();
            this.txt_user_id = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txt_working_time = new System.Windows.Forms.TextBox();
            this.txt_salary_rule = new System.Windows.Forms.TextBox();
            this.txt_gross = new System.Windows.Forms.TextBox();
            this.txt_basic = new System.Windows.Forms.TextBox();
            this.txtProximityNo = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_cell_no = new System.Windows.Forms.TextBox();
            this.combo_weekend = new System.Windows.Forms.ComboBox();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.RB_Bank = new System.Windows.Forms.RadioButton();
            this.RB_Mobile = new System.Windows.Forms.RadioButton();
            this.RB_None = new System.Windows.Forms.RadioButton();
            this.CB_ot_holder = new System.Windows.Forms.CheckBox();
            this.CB_quater = new System.Windows.Forms.CheckBox();
            this.CB_tax = new System.Windows.Forms.CheckBox();
            this.CB_contractual = new System.Windows.Forms.CheckBox();
            this.chkResign = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPhotoPath = new System.Windows.Forms.TextBox();
            this.cmbDesig = new System.Windows.Forms.ComboBox();
            this.CBox_Unit = new System.Windows.Forms.ComboBox();
            this.CBox_Category = new System.Windows.Forms.ComboBox();
            this.CBox_Department = new System.Windows.Forms.ComboBox();
            this.CBox_Section = new System.Windows.Forms.ComboBox();
            this.CBox_Group = new System.Windows.Forms.ComboBox();
            this.CBox_WorkingTime = new System.Windows.Forms.ComboBox();
            this.CBox_SalaryRule = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtSignPath = new System.Windows.Forms.TextBox();
            this.lbRecordCount = new System.Windows.Forms.Label();
            this.lbCountData = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grLos = new System.Windows.Forms.GroupBox();
            this.lbLos = new System.Windows.Forms.Label();
            this.grLv = new System.Windows.Forms.GroupBox();
            this.lbLv = new System.Windows.Forms.Label();
            this.lbDetails = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSavePhoto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetDefaultImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUploadPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUploadPhotoByFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_husband_name = new System.Windows.Forms.TextBox();
            this.husband_lbl = new System.Windows.Forms.Label();
            this.edu_lbl = new System.Windows.Forms.Label();
            this.lbLastCode = new System.Windows.Forms.Label();
            this.lbLastUpdate = new System.Windows.Forms.Label();
            this.btnUploadSignature = new System.Windows.Forms.Button();
            this.cmdBtnUploadPhoto = new System.Windows.Forms.Button();
            this.lbLastDay = new System.Windows.Forms.Label();
            this.myListBox = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pBoxPhoto = new System.Windows.Forms.PictureBox();
            this.pBoxEmpSignature = new System.Windows.Forms.PictureBox();
            this.txtLicenseNo = new System.Windows.Forms.TextBox();
            this.cmbEL = new System.Windows.Forms.ComboBox();
            this.txtErpCode = new System.Windows.Forms.TextBox();
            this.cmbPresDist = new System.Windows.Forms.ComboBox();
            this.cmbPerDist = new System.Windows.Forms.ComboBox();
            this.cmbEducation = new System.Windows.Forms.ComboBox();
            this.txtEmployement = new System.Windows.Forms.TextBox();
            this.txtNomineeCellNo = new System.Windows.Forms.TextBox();
            this.cmbIncrSeg = new System.Windows.Forms.ComboBox();
            this.txtQtr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnExitLastUC = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEL = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtBangHusband = new System.Windows.Forms.TextBox();
            this.txtBangMotherName = new System.Windows.Forms.TextBox();
            this.txtBangFatherName = new System.Windows.Forms.TextBox();
            this.txtEmpNameBang = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txtBangParmentDist = new System.Windows.Forms.TextBox();
            this.txtBangParmentPS = new System.Windows.Forms.TextBox();
            this.txtBangParmentPO = new System.Windows.Forms.TextBox();
            this.txtBangParmentVill = new System.Windows.Forms.TextBox();
            this.txtBangPresentDist = new System.Windows.Forms.TextBox();
            this.txtBangPresentPS = new System.Windows.Forms.TextBox();
            this.txtBangPresentPO = new System.Windows.Forms.TextBox();
            this.txtBangPresentVill = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtBang_nomini = new System.Windows.Forms.TextBox();
            this.cmbPos = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.cmbGrd = new System.Windows.Forms.ComboBox();
            this.grLos.SuspendLayout();
            this.grLv.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxEmpSignature)).BeginInit();
            this.SuspendLayout();
            // 
            // emp_info_lbl
            // 
            this.emp_info_lbl.AutoSize = true;
            this.emp_info_lbl.BackColor = System.Drawing.Color.Transparent;
            this.emp_info_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp_info_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.emp_info_lbl.Location = new System.Drawing.Point(386, 18);
            this.emp_info_lbl.Name = "emp_info_lbl";
            this.emp_info_lbl.Size = new System.Drawing.Size(297, 31);
            this.emp_info_lbl.TabIndex = 0;
            this.emp_info_lbl.Text = "Employee Information";
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEmpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpCode.Location = new System.Drawing.Point(142, 70);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Size = new System.Drawing.Size(121, 22);
            this.txtEmpCode.TabIndex = 1;
            this.txtEmpCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtEmpCode, resources.GetString("txtEmpCode.ToolTip"));
            this.txtEmpCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEmpCode_KeyUp);
            // 
            // txt_emp_name
            // 
            this.txt_emp_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_emp_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_emp_name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_emp_name.Location = new System.Drawing.Point(142, 96);
            this.txt_emp_name.Name = "txt_emp_name";
            this.txt_emp_name.Size = new System.Drawing.Size(171, 22);
            this.txt_emp_name.TabIndex = 2;
            this.txt_emp_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_emp_name, "F5   - To Search Employee by Selected Value");
            this.txt_emp_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_emp_name_KeyUp);
            // 
            // txt_father_name
            // 
            this.txt_father_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_father_name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_father_name.Location = new System.Drawing.Point(142, 122);
            this.txt_father_name.Name = "txt_father_name";
            this.txt_father_name.Size = new System.Drawing.Size(171, 22);
            this.txt_father_name.TabIndex = 3;
            this.txt_father_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_father_name, "F5   - To Search Employee by Selected Value");
            this.txt_father_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_father_name_KeyUp);
            // 
            // txt_emp_mother
            // 
            this.txt_emp_mother.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_emp_mother.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_emp_mother.Location = new System.Drawing.Point(142, 148);
            this.txt_emp_mother.Name = "txt_emp_mother";
            this.txt_emp_mother.Size = new System.Drawing.Size(171, 22);
            this.txt_emp_mother.TabIndex = 4;
            this.txt_emp_mother.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_emp_mother, "F5   - To Search Employee by Selected Value");
            this.txt_emp_mother.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_emp_mother_KeyUp);
            // 
            // combo_gender
            // 
            this.combo_gender.AllowDrop = true;
            this.combo_gender.AutoCompleteCustomSource.AddRange(new string[] {
            "FEMALE",
            "MALE"});
            this.combo_gender.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_gender.FormattingEnabled = true;
            this.combo_gender.Location = new System.Drawing.Point(142, 201);
            this.combo_gender.Name = "combo_gender";
            this.combo_gender.Size = new System.Drawing.Size(121, 24);
            this.combo_gender.TabIndex = 6;
            this.combo_gender.Tag = "";
            this.toolTip1.SetToolTip(this.combo_gender, "F5   - To Search Employee by Selected Value");
            this.combo_gender.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo_gender_KeyUp);
            // 
            // combo_religion
            // 
            this.combo_religion.AllowDrop = true;
            this.combo_religion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_religion.FormattingEnabled = true;
            this.combo_religion.Location = new System.Drawing.Point(351, 201);
            this.combo_religion.Name = "combo_religion";
            this.combo_religion.Size = new System.Drawing.Size(130, 24);
            this.combo_religion.TabIndex = 7;
            this.toolTip1.SetToolTip(this.combo_religion, "F5   - To Search Employee by Selected Value");
            this.combo_religion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo_religion_KeyUp);
            // 
            // combo_marital
            // 
            this.combo_marital.AllowDrop = true;
            this.combo_marital.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_marital.FormattingEnabled = true;
            this.combo_marital.Location = new System.Drawing.Point(142, 229);
            this.combo_marital.Name = "combo_marital";
            this.combo_marital.Size = new System.Drawing.Size(121, 24);
            this.combo_marital.TabIndex = 8;
            this.toolTip1.SetToolTip(this.combo_marital, "F5   - Press F5 to Search");
            this.combo_marital.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo_marital_KeyUp);
            // 
            // combo_blood
            // 
            this.combo_blood.AllowDrop = true;
            this.combo_blood.BackColor = System.Drawing.SystemColors.Window;
            this.combo_blood.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_blood.FormattingEnabled = true;
            this.combo_blood.Location = new System.Drawing.Point(351, 228);
            this.combo_blood.Name = "combo_blood";
            this.combo_blood.Size = new System.Drawing.Size(130, 24);
            this.combo_blood.TabIndex = 9;
            this.toolTip1.SetToolTip(this.combo_blood, "F5   - Press F5 to Search");
            this.combo_blood.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo_blood_KeyUp);
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpBirthDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthDate.Location = new System.Drawing.Point(142, 257);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(121, 20);
            this.dtpBirthDate.TabIndex = 10;
            this.dtpBirthDate.ValueChanged += new System.EventHandler(this.dtpBirthDate_ValueChanged);
            this.dtpBirthDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpBirthDate_KeyUp);
            // 
            // txt_age
            // 
            this.txt_age.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_age.Enabled = false;
            this.txt_age.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_age.Location = new System.Drawing.Point(351, 255);
            this.txt_age.Name = "txt_age";
            this.txt_age.Size = new System.Drawing.Size(130, 22);
            this.txt_age.TabIndex = 11;
            this.txt_age.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_vill_present
            // 
            this.txt_vill_present.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_vill_present.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_vill_present.Location = new System.Drawing.Point(142, 281);
            this.txt_vill_present.Name = "txt_vill_present";
            this.txt_vill_present.Size = new System.Drawing.Size(121, 22);
            this.txt_vill_present.TabIndex = 12;
            this.txt_vill_present.Text = "MAWNA";
            this.txt_vill_present.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_vill_present, "F5   - To Search Employee by Selected Value");
            this.txt_vill_present.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_vill_present_KeyUp);
            // 
            // txt_po_present
            // 
            this.txt_po_present.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_po_present.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_po_present.Location = new System.Drawing.Point(351, 281);
            this.txt_po_present.Name = "txt_po_present";
            this.txt_po_present.Size = new System.Drawing.Size(130, 22);
            this.txt_po_present.TabIndex = 13;
            this.txt_po_present.Text = "SREEPUR";
            this.txt_po_present.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_po_present, "F5   - To Search Employee by Selected Value");
            this.txt_po_present.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_po_present_KeyUp);
            // 
            // txt_ps_present
            // 
            this.txt_ps_present.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ps_present.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ps_present.Location = new System.Drawing.Point(142, 307);
            this.txt_ps_present.Name = "txt_ps_present";
            this.txt_ps_present.Size = new System.Drawing.Size(121, 22);
            this.txt_ps_present.TabIndex = 14;
            this.txt_ps_present.Text = "SREEPUR";
            this.txt_ps_present.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_ps_present, "F5   - To Search Employee by Selected Value");
            this.txt_ps_present.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_ps_present_KeyUp);
            // 
            // txt_vill_parmanent
            // 
            this.txt_vill_parmanent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_vill_parmanent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_vill_parmanent.Location = new System.Drawing.Point(142, 333);
            this.txt_vill_parmanent.Name = "txt_vill_parmanent";
            this.txt_vill_parmanent.Size = new System.Drawing.Size(121, 22);
            this.txt_vill_parmanent.TabIndex = 16;
            this.txt_vill_parmanent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_vill_parmanent, "F5   - To Search Employee by Selected Value");
            this.txt_vill_parmanent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_vill_parmanent_KeyUp);
            // 
            // txt_po_parmanent
            // 
            this.txt_po_parmanent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_po_parmanent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_po_parmanent.Location = new System.Drawing.Point(351, 333);
            this.txt_po_parmanent.Name = "txt_po_parmanent";
            this.txt_po_parmanent.Size = new System.Drawing.Size(130, 22);
            this.txt_po_parmanent.TabIndex = 17;
            this.txt_po_parmanent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_po_parmanent, "F5   - To Search Employee by Selected Value");
            this.txt_po_parmanent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_po_parmanent_KeyUp);
            // 
            // txt_ps_parmanent
            // 
            this.txt_ps_parmanent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ps_parmanent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ps_parmanent.Location = new System.Drawing.Point(142, 359);
            this.txt_ps_parmanent.Name = "txt_ps_parmanent";
            this.txt_ps_parmanent.Size = new System.Drawing.Size(121, 22);
            this.txt_ps_parmanent.TabIndex = 18;
            this.txt_ps_parmanent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_ps_parmanent, "F5   - To Search Employee by Selected Value");
            this.txt_ps_parmanent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_ps_parmanent_KeyUp);
            // 
            // txt_national_id
            // 
            this.txt_national_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_national_id.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_national_id.Location = new System.Drawing.Point(142, 487);
            this.txt_national_id.Name = "txt_national_id";
            this.txt_national_id.Size = new System.Drawing.Size(121, 22);
            this.txt_national_id.TabIndex = 20;
            this.txt_national_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_national_id, "F5   - To Search Employee by Selected Value");
            this.txt_national_id.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_national_id_KeyUp);
            // 
            // txt_remarks
            // 
            this.txt_remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_remarks.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks.Location = new System.Drawing.Point(780, 462);
            this.txt_remarks.Name = "txt_remarks";
            this.txt_remarks.Size = new System.Drawing.Size(132, 22);
            this.txt_remarks.TabIndex = 24;
            this.txt_remarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_remarks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_remarks_KeyUp);
            // 
            // txt_beneficiary
            // 
            this.txt_beneficiary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_beneficiary.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_beneficiary.Location = new System.Drawing.Point(586, 488);
            this.txt_beneficiary.Name = "txt_beneficiary";
            this.txt_beneficiary.Size = new System.Drawing.Size(121, 22);
            this.txt_beneficiary.TabIndex = 22;
            this.txt_beneficiary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_beneficiary, "F5   - To Search Employee by Selected Value");
            this.txt_beneficiary.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_beneficiary_KeyUp);
            // 
            // combo_relation
            // 
            this.combo_relation.AllowDrop = true;
            this.combo_relation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_relation.FormattingEnabled = true;
            this.combo_relation.Location = new System.Drawing.Point(795, 487);
            this.combo_relation.Name = "combo_relation";
            this.combo_relation.Size = new System.Drawing.Size(130, 24);
            this.combo_relation.TabIndex = 23;
            this.toolTip1.SetToolTip(this.combo_relation, "F5   - Press F5 to Search");
            this.combo_relation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo_relation_KeyUp);
            // 
            // dtpCloseDate
            // 
            this.dtpCloseDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpCloseDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCloseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCloseDate.Location = new System.Drawing.Point(142, 513);
            this.dtpCloseDate.Name = "dtpCloseDate";
            this.dtpCloseDate.Size = new System.Drawing.Size(121, 20);
            this.dtpCloseDate.TabIndex = 51;
            this.toolTip1.SetToolTip(this.dtpCloseDate, "F5   - To Search Employee by Close Date");
            this.dtpCloseDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpCloseDate_KeyUp);
            // 
            // emp_code_lbl
            // 
            this.emp_code_lbl.AutoSize = true;
            this.emp_code_lbl.BackColor = System.Drawing.Color.Transparent;
            this.emp_code_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp_code_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.emp_code_lbl.Location = new System.Drawing.Point(40, 74);
            this.emp_code_lbl.Name = "emp_code_lbl";
            this.emp_code_lbl.Size = new System.Drawing.Size(100, 14);
            this.emp_code_lbl.TabIndex = 57;
            this.emp_code_lbl.Text = "Employee Code";
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.name_lbl.Location = new System.Drawing.Point(38, 100);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(102, 14);
            this.name_lbl.TabIndex = 58;
            this.name_lbl.Text = "Employee Name";
            // 
            // father_lbl
            // 
            this.father_lbl.AutoSize = true;
            this.father_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.father_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.father_lbl.Location = new System.Drawing.Point(47, 125);
            this.father_lbl.Name = "father_lbl";
            this.father_lbl.Size = new System.Drawing.Size(92, 14);
            this.father_lbl.TabIndex = 59;
            this.father_lbl.Text = "Father\'s Name";
            // 
            // mother_lbl
            // 
            this.mother_lbl.AutoSize = true;
            this.mother_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mother_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.mother_lbl.Location = new System.Drawing.Point(41, 151);
            this.mother_lbl.Name = "mother_lbl";
            this.mother_lbl.Size = new System.Drawing.Size(98, 14);
            this.mother_lbl.TabIndex = 60;
            this.mother_lbl.Text = "Mother\'s Name";
            // 
            // gender_lbl
            // 
            this.gender_lbl.AutoSize = true;
            this.gender_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gender_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gender_lbl.Location = new System.Drawing.Point(90, 206);
            this.gender_lbl.Name = "gender_lbl";
            this.gender_lbl.Size = new System.Drawing.Size(50, 14);
            this.gender_lbl.TabIndex = 63;
            this.gender_lbl.Text = "Gender";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(291, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 76;
            this.label7.Text = "Religion";
            // 
            // marital_lbl
            // 
            this.marital_lbl.AutoSize = true;
            this.marital_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marital_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.marital_lbl.Location = new System.Drawing.Point(91, 234);
            this.marital_lbl.Name = "marital_lbl";
            this.marital_lbl.Size = new System.Drawing.Size(49, 14);
            this.marital_lbl.TabIndex = 64;
            this.marital_lbl.Text = "Marital";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Location = new System.Drawing.Point(306, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 77;
            this.label9.Text = "Blood";
            // 
            // bday_lbl
            // 
            this.bday_lbl.AutoSize = true;
            this.bday_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bday_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bday_lbl.Location = new System.Drawing.Point(81, 260);
            this.bday_lbl.Name = "bday_lbl";
            this.bday_lbl.Size = new System.Drawing.Size(59, 14);
            this.bday_lbl.TabIndex = 65;
            this.bday_lbl.Text = "Birthday";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Location = new System.Drawing.Point(315, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 16);
            this.label11.TabIndex = 78;
            this.label11.Text = "Age";
            // 
            // vill_lbl
            // 
            this.vill_lbl.AutoSize = true;
            this.vill_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vill_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.vill_lbl.Location = new System.Drawing.Point(101, 284);
            this.vill_lbl.Name = "vill_lbl";
            this.vill_lbl.Size = new System.Drawing.Size(38, 14);
            this.vill_lbl.TabIndex = 70;
            this.vill_lbl.Text = "VILL.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label13.Location = new System.Drawing.Point(316, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 16);
            this.label13.TabIndex = 79;
            this.label13.Text = "P.O.";
            // 
            // vill1_lbl
            // 
            this.vill1_lbl.AutoSize = true;
            this.vill1_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vill1_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.vill1_lbl.Location = new System.Drawing.Point(102, 337);
            this.vill1_lbl.Name = "vill1_lbl";
            this.vill1_lbl.Size = new System.Drawing.Size(38, 14);
            this.vill1_lbl.TabIndex = 72;
            this.vill1_lbl.Text = "VILL.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label15.Location = new System.Drawing.Point(316, 336);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 16);
            this.label15.TabIndex = 81;
            this.label15.Text = "P.O.";
            // 
            // ps_lbl
            // 
            this.ps_lbl.AutoSize = true;
            this.ps_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ps_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ps_lbl.Location = new System.Drawing.Point(108, 310);
            this.ps_lbl.Name = "ps_lbl";
            this.ps_lbl.Size = new System.Drawing.Size(31, 14);
            this.ps_lbl.TabIndex = 71;
            this.ps_lbl.Text = "P.S.";
            // 
            // ps1_lbl
            // 
            this.ps1_lbl.AutoSize = true;
            this.ps1_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ps1_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ps1_lbl.Location = new System.Drawing.Point(109, 363);
            this.ps1_lbl.Name = "ps1_lbl";
            this.ps1_lbl.Size = new System.Drawing.Size(31, 14);
            this.ps1_lbl.TabIndex = 73;
            this.ps1_lbl.Text = "P.S.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label18.Location = new System.Drawing.Point(312, 309);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 16);
            this.label18.TabIndex = 80;
            this.label18.Text = "DIST";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label19.Location = new System.Drawing.Point(312, 362);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 16);
            this.label19.TabIndex = 82;
            this.label19.Text = "DIST";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label20.Location = new System.Drawing.Point(66, 490);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 14);
            this.label20.TabIndex = 68;
            this.label20.Text = "National ID";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label21.Location = new System.Drawing.Point(714, 465);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 16);
            this.label21.TabIndex = 85;
            this.label21.Text = "Remarks";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label22.Location = new System.Drawing.Point(518, 492);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 14);
            this.label22.TabIndex = 69;
            this.label22.Text = "Nominee";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label23.Location = new System.Drawing.Point(732, 491);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(61, 16);
            this.label23.TabIndex = 84;
            this.label23.Text = "Relation";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label24.Location = new System.Drawing.Point(490, 258);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(94, 16);
            this.label24.TabIndex = 92;
            this.label24.Text = "Working Time";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label25.Location = new System.Drawing.Point(533, 75);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(51, 16);
            this.label25.TabIndex = 86;
            this.label25.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.AllowDrop = true;
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(586, 73);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 22);
            this.cmbStatus.TabIndex = 25;
            this.toolTip1.SetToolTip(this.cmbStatus, "F5   - To Search Employee by Selected Value");
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            this.cmbStatus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbStatus_KeyUp);
            // 
            // dtpJoinDate
            // 
            this.dtpJoinDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dtpJoinDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpJoinDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJoinDate.Location = new System.Drawing.Point(798, 73);
            this.dtpJoinDate.Name = "dtpJoinDate";
            this.dtpJoinDate.Size = new System.Drawing.Size(110, 20);
            this.dtpJoinDate.TabIndex = 26;
            this.toolTip1.SetToolTip(this.dtpJoinDate, "F5   - List of Current Month Employee\r\nF8   - List of Current Date Employee\r\n");
            this.dtpJoinDate.ValueChanged += new System.EventHandler(this.dtpJoinDate_ValueChanged);
            this.dtpJoinDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtpJoinDate_KeyUp);
            this.dtpJoinDate.Leave += new System.EventHandler(this.dtpJoinDate_Leave);
            // 
            // txt_designation
            // 
            this.txt_designation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_designation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.txt_designation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_designation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_designation.Location = new System.Drawing.Point(772, 125);
            this.txt_designation.Name = "txt_designation";
            this.txt_designation.Size = new System.Drawing.Size(24, 20);
            this.txt_designation.TabIndex = 24;
            // 
            // txt_unit
            // 
            this.txt_unit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_unit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_unit.Location = new System.Drawing.Point(890, 151);
            this.txt_unit.Name = "txt_unit";
            this.txt_unit.Size = new System.Drawing.Size(22, 20);
            this.txt_unit.TabIndex = 26;
            // 
            // txt_category
            // 
            this.txt_category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_category.Location = new System.Drawing.Point(890, 177);
            this.txt_category.Name = "txt_category";
            this.txt_category.Size = new System.Drawing.Size(22, 20);
            this.txt_category.TabIndex = 27;
            // 
            // txt_department
            // 
            this.txt_department.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_department.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_department.Location = new System.Drawing.Point(890, 203);
            this.txt_department.Name = "txt_department";
            this.txt_department.Size = new System.Drawing.Size(21, 20);
            this.txt_department.TabIndex = 28;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label26.Location = new System.Drawing.Point(708, 72);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(87, 16);
            this.label26.TabIndex = 98;
            this.label26.Text = "Joining Date";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label27.Location = new System.Drawing.Point(500, 128);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(84, 16);
            this.label27.TabIndex = 87;
            this.label27.Text = "Designation";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label28.Location = new System.Drawing.Point(551, 153);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(33, 16);
            this.label28.TabIndex = 88;
            this.label28.Text = "Unit";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label29.Location = new System.Drawing.Point(516, 179);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(68, 16);
            this.label29.TabIndex = 89;
            this.label29.Text = "Category";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label30.Location = new System.Drawing.Point(498, 205);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(86, 16);
            this.label30.TabIndex = 90;
            this.label30.Text = "Department";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label31.Location = new System.Drawing.Point(797, 128);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(46, 16);
            this.label31.TabIndex = 60;
            this.label31.Text = "Grade";
            // 
            // txt_section
            // 
            this.txt_section.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_section.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_section.Location = new System.Drawing.Point(775, 229);
            this.txt_section.Name = "txt_section";
            this.txt_section.Size = new System.Drawing.Size(20, 20);
            this.txt_section.TabIndex = 29;
            // 
            // txt_user_id
            // 
            this.txt_user_id.BackColor = System.Drawing.SystemColors.Control;
            this.txt_user_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_user_id.Location = new System.Drawing.Point(930, 77);
            this.txt_user_id.Name = "txt_user_id";
            this.txt_user_id.Size = new System.Drawing.Size(22, 20);
            this.txt_user_id.TabIndex = 61;
            this.txt_user_id.Visible = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label32.Location = new System.Drawing.Point(528, 232);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(56, 16);
            this.label32.TabIndex = 91;
            this.label32.Text = "Section";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label33.Location = new System.Drawing.Point(797, 232);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(46, 16);
            this.label33.TabIndex = 99;
            this.label33.Text = "Group";
            // 
            // txt_working_time
            // 
            this.txt_working_time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_working_time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_working_time.Location = new System.Drawing.Point(881, 256);
            this.txt_working_time.Name = "txt_working_time";
            this.txt_working_time.Size = new System.Drawing.Size(30, 20);
            this.txt_working_time.TabIndex = 31;
            // 
            // txt_salary_rule
            // 
            this.txt_salary_rule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_salary_rule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_salary_rule.Location = new System.Drawing.Point(881, 282);
            this.txt_salary_rule.Name = "txt_salary_rule";
            this.txt_salary_rule.Size = new System.Drawing.Size(30, 20);
            this.txt_salary_rule.TabIndex = 32;
            // 
            // txt_gross
            // 
            this.txt_gross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_gross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_gross.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gross.Location = new System.Drawing.Point(586, 308);
            this.txt_gross.Name = "txt_gross";
            this.txt_gross.Size = new System.Drawing.Size(121, 22);
            this.txt_gross.TabIndex = 36;
            this.txt_gross.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_gross, "F1   - List along with Gross (Ex <10,000\r\nF2   - List along with Gross (Ex >10,00" +
        "0)\r\nF5   - List along with Gross (Ex =10,000)\r\nF12  - Update The Information");
            this.txt_gross.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_gross_KeyUp);
            // 
            // txt_basic
            // 
            this.txt_basic.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_basic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_basic.Enabled = false;
            this.txt_basic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_basic.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_basic.Location = new System.Drawing.Point(800, 308);
            this.txt_basic.Name = "txt_basic";
            this.txt_basic.Size = new System.Drawing.Size(111, 21);
            this.txt_basic.TabIndex = 63;
            this.txt_basic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProximityNo
            // 
            this.txtProximityNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProximityNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProximityNo.Location = new System.Drawing.Point(800, 334);
            this.txtProximityNo.Name = "txtProximityNo";
            this.txtProximityNo.Size = new System.Drawing.Size(111, 21);
            this.txtProximityNo.TabIndex = 38;
            this.txtProximityNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtProximityNo, "F5   - List along with Proximity Card No.");
            this.txtProximityNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProximityNo_KeyUp);
            this.txtProximityNo.Leave += new System.EventHandler(this.txtProximityNo_Leave);
            // 
            // txt_email
            // 
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_email.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(800, 360);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(111, 21);
            this.txt_email.TabIndex = 40;
            this.txt_email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_email, "F5   - Press F5 to Search");
            this.txt_email.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_email_KeyUp);
            // 
            // txt_cell_no
            // 
            this.txt_cell_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cell_no.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cell_no.Location = new System.Drawing.Point(586, 361);
            this.txt_cell_no.Name = "txt_cell_no";
            this.txt_cell_no.Size = new System.Drawing.Size(121, 21);
            this.txt_cell_no.TabIndex = 39;
            this.txt_cell_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_cell_no, "F5   - Press F5 to Search");
            this.txt_cell_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_cell_no_KeyUp);
            // 
            // combo_weekend
            // 
            this.combo_weekend.AllowDrop = true;
            this.combo_weekend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.combo_weekend.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_weekend.FormattingEnabled = true;
            this.combo_weekend.ItemHeight = 14;
            this.combo_weekend.Location = new System.Drawing.Point(586, 334);
            this.combo_weekend.Name = "combo_weekend";
            this.combo_weekend.Size = new System.Drawing.Size(121, 22);
            this.combo_weekend.TabIndex = 37;
            this.toolTip1.SetToolTip(this.combo_weekend, "F5   - Press F5 to Search");
            this.combo_weekend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo_weekend_KeyUp);
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNo.Location = new System.Drawing.Point(586, 386);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(121, 21);
            this.txtAccountNo.TabIndex = 41;
            this.txtAccountNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtAccountNo, "F5     - Search By Bank Account No\r\nF6     - Search By Mobile Bank Accont No\r\nF11" +
        "   - Update Acc.No With Accont Type\r\nF12   - Update The Specific Account  No ");
            this.txtAccountNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAccountNo_KeyUp);
            // 
            // RB_Bank
            // 
            this.RB_Bank.AutoSize = true;
            this.RB_Bank.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Bank.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.RB_Bank.Location = new System.Drawing.Point(710, 388);
            this.RB_Bank.Name = "RB_Bank";
            this.RB_Bank.Size = new System.Drawing.Size(57, 20);
            this.RB_Bank.TabIndex = 42;
            this.RB_Bank.TabStop = true;
            this.RB_Bank.Text = "Bank";
            this.toolTip1.SetToolTip(this.RB_Bank, "F5     - Search By Bank Account Holder\r\nF12   - Update Account Type");
            this.RB_Bank.UseVisualStyleBackColor = true;
            this.RB_Bank.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RB_Bank_KeyUp);
            // 
            // RB_Mobile
            // 
            this.RB_Mobile.AutoSize = true;
            this.RB_Mobile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Mobile.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.RB_Mobile.Location = new System.Drawing.Point(767, 387);
            this.RB_Mobile.Name = "RB_Mobile";
            this.RB_Mobile.Size = new System.Drawing.Size(102, 20);
            this.RB_Mobile.TabIndex = 43;
            this.RB_Mobile.TabStop = true;
            this.RB_Mobile.Text = "Mobile Bank";
            this.toolTip1.SetToolTip(this.RB_Mobile, "F5     - Search By Mobile Bank Accont Holder\r\nF12   - Update Account Type");
            this.RB_Mobile.UseVisualStyleBackColor = true;
            this.RB_Mobile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RB_Mobile_KeyUp);
            // 
            // RB_None
            // 
            this.RB_None.AutoSize = true;
            this.RB_None.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_None.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.RB_None.Location = new System.Drawing.Point(866, 388);
            this.RB_None.Name = "RB_None";
            this.RB_None.Size = new System.Drawing.Size(57, 20);
            this.RB_None.TabIndex = 44;
            this.RB_None.TabStop = true;
            this.RB_None.Text = "Cash";
            this.toolTip1.SetToolTip(this.RB_None, "F5     - Search Employee\r\nF12   - Update Account Type");
            this.RB_None.UseVisualStyleBackColor = true;
            this.RB_None.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RB_None_KeyUp);
            // 
            // CB_ot_holder
            // 
            this.CB_ot_holder.AutoSize = true;
            this.CB_ot_holder.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_ot_holder.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CB_ot_holder.Location = new System.Drawing.Point(829, 415);
            this.CB_ot_holder.Name = "CB_ot_holder";
            this.CB_ot_holder.Size = new System.Drawing.Size(89, 20);
            this.CB_ot_holder.TabIndex = 46;
            this.CB_ot_holder.Text = "OT Holder";
            this.CB_ot_holder.UseVisualStyleBackColor = true;
            this.CB_ot_holder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CB_ot_holder_KeyUp);
            // 
            // CB_quater
            // 
            this.CB_quater.AutoSize = true;
            this.CB_quater.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_quater.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CB_quater.Location = new System.Drawing.Point(746, 514);
            this.CB_quater.Name = "CB_quater";
            this.CB_quater.Size = new System.Drawing.Size(72, 20);
            this.CB_quater.TabIndex = 47;
            this.CB_quater.Text = "Quater";
            this.CB_quater.UseVisualStyleBackColor = true;
            this.CB_quater.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CB_quater_KeyUp);
            // 
            // CB_tax
            // 
            this.CB_tax.AutoSize = true;
            this.CB_tax.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_tax.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CB_tax.Location = new System.Drawing.Point(780, 415);
            this.CB_tax.Name = "CB_tax";
            this.CB_tax.Size = new System.Drawing.Size(49, 20);
            this.CB_tax.TabIndex = 48;
            this.CB_tax.Text = "Tax";
            this.CB_tax.UseVisualStyleBackColor = true;
            this.CB_tax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CB_tax_KeyUp);
            // 
            // CB_contractual
            // 
            this.CB_contractual.AutoSize = true;
            this.CB_contractual.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_contractual.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.CB_contractual.Location = new System.Drawing.Point(711, 439);
            this.CB_contractual.Name = "CB_contractual";
            this.CB_contractual.Size = new System.Drawing.Size(103, 20);
            this.CB_contractual.TabIndex = 45;
            this.CB_contractual.Text = "Contractual";
            this.CB_contractual.UseVisualStyleBackColor = true;
            this.CB_contractual.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CB_contractual_KeyUp);
            // 
            // chkResign
            // 
            this.chkResign.AutoSize = true;
            this.chkResign.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResign.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chkResign.Location = new System.Drawing.Point(19, 513);
            this.chkResign.Name = "chkResign";
            this.chkResign.Size = new System.Drawing.Size(123, 18);
            this.chkResign.TabIndex = 50;
            this.chkResign.Text = "Resign/Inactive";
            this.chkResign.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label34.Location = new System.Drawing.Point(503, 285);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(81, 16);
            this.label34.TabIndex = 93;
            this.label34.Text = "Salary Rule";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label35.Location = new System.Drawing.Point(540, 311);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(44, 16);
            this.label35.TabIndex = 94;
            this.label35.Text = "Gross";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label36.Location = new System.Drawing.Point(757, 310);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(41, 16);
            this.label36.TabIndex = 100;
            this.label36.Text = "Basic";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label37.Location = new System.Drawing.Point(516, 337);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(68, 16);
            this.label37.TabIndex = 95;
            this.label37.Text = "Weekend";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label38.Location = new System.Drawing.Point(711, 336);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(88, 16);
            this.label38.TabIndex = 101;
            this.label38.Text = "Proximity No";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label39.Location = new System.Drawing.Point(534, 363);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(50, 16);
            this.label39.TabIndex = 96;
            this.label39.Text = "Cell No";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label40.Location = new System.Drawing.Point(758, 363);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(40, 16);
            this.label40.TabIndex = 102;
            this.label40.Text = "Email";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label41.Location = new System.Drawing.Point(502, 389);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(82, 16);
            this.label41.TabIndex = 97;
            this.label41.Text = "Account No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(38, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 66;
            this.label1.Text = "Present";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(30, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 67;
            this.label2.Text = "Parmanent";
            // 
            // txtPhotoPath
            // 
            this.txtPhotoPath.Location = new System.Drawing.Point(956, 77);
            this.txtPhotoPath.Name = "txtPhotoPath";
            this.txtPhotoPath.Size = new System.Drawing.Size(55, 20);
            this.txtPhotoPath.TabIndex = 137;
            this.txtPhotoPath.Visible = false;
            // 
            // cmbDesig
            // 
            this.cmbDesig.AllowDrop = true;
            this.cmbDesig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbDesig.DropDownHeight = 110;
            this.cmbDesig.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesig.FormattingEnabled = true;
            this.cmbDesig.IntegralHeight = false;
            this.cmbDesig.Location = new System.Drawing.Point(586, 124);
            this.cmbDesig.Name = "cmbDesig";
            this.cmbDesig.Size = new System.Drawing.Size(210, 22);
            this.cmbDesig.TabIndex = 27;
            this.toolTip1.SetToolTip(this.cmbDesig, "F5   - To Search Employee by Selected Designation\r\nF8   - New Designation Entry");
            this.cmbDesig.SelectedIndexChanged += new System.EventHandler(this.CBox_Designation_SelectedIndexChanged);
            this.cmbDesig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBox_Designation_KeyPress);
            this.cmbDesig.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBox_Designation_KeyUp);
            // 
            // CBox_Unit
            // 
            this.CBox_Unit.AllowDrop = true;
            this.CBox_Unit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CBox_Unit.DropDownHeight = 110;
            this.CBox_Unit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBox_Unit.FormattingEnabled = true;
            this.CBox_Unit.IntegralHeight = false;
            this.CBox_Unit.Location = new System.Drawing.Point(586, 150);
            this.CBox_Unit.Name = "CBox_Unit";
            this.CBox_Unit.Size = new System.Drawing.Size(326, 22);
            this.CBox_Unit.TabIndex = 29;
            this.toolTip1.SetToolTip(this.CBox_Unit, "F5   - To Search Employee by Selected Value");
            this.CBox_Unit.SelectedIndexChanged += new System.EventHandler(this.CBox_Unit_SelectedIndexChanged);
            this.CBox_Unit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBox_Unit_KeyPress);
            this.CBox_Unit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBox_Unit_KeyUp);
            // 
            // CBox_Category
            // 
            this.CBox_Category.AllowDrop = true;
            this.CBox_Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CBox_Category.DropDownHeight = 110;
            this.CBox_Category.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBox_Category.FormattingEnabled = true;
            this.CBox_Category.IntegralHeight = false;
            this.CBox_Category.Location = new System.Drawing.Point(586, 176);
            this.CBox_Category.Name = "CBox_Category";
            this.CBox_Category.Size = new System.Drawing.Size(326, 22);
            this.CBox_Category.TabIndex = 30;
            this.toolTip1.SetToolTip(this.CBox_Category, "F5   - To Search Employee by Selected Value");
            this.CBox_Category.SelectedIndexChanged += new System.EventHandler(this.CBox_Category_SelectedIndexChanged);
            this.CBox_Category.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBox_Category_KeyPress);
            this.CBox_Category.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBox_Category_KeyUp);
            // 
            // CBox_Department
            // 
            this.CBox_Department.AllowDrop = true;
            this.CBox_Department.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CBox_Department.DropDownHeight = 110;
            this.CBox_Department.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBox_Department.FormattingEnabled = true;
            this.CBox_Department.IntegralHeight = false;
            this.CBox_Department.Location = new System.Drawing.Point(586, 202);
            this.CBox_Department.Name = "CBox_Department";
            this.CBox_Department.Size = new System.Drawing.Size(325, 22);
            this.CBox_Department.TabIndex = 31;
            this.toolTip1.SetToolTip(this.CBox_Department, "F5   - To Search Employee by Selected Value");
            this.CBox_Department.SelectedIndexChanged += new System.EventHandler(this.CBox_Department_SelectedIndexChanged);
            this.CBox_Department.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBox_Department_KeyPress);
            this.CBox_Department.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBox_Department_KeyUp);
            // 
            // CBox_Section
            // 
            this.CBox_Section.AllowDrop = true;
            this.CBox_Section.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CBox_Section.DropDownHeight = 110;
            this.CBox_Section.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBox_Section.FormattingEnabled = true;
            this.CBox_Section.IntegralHeight = false;
            this.CBox_Section.Location = new System.Drawing.Point(586, 229);
            this.CBox_Section.Name = "CBox_Section";
            this.CBox_Section.Size = new System.Drawing.Size(210, 22);
            this.CBox_Section.TabIndex = 32;
            this.toolTip1.SetToolTip(this.CBox_Section, "F5   - To Search Employee by Selected Value");
            this.CBox_Section.SelectedIndexChanged += new System.EventHandler(this.CBox_Section_SelectedIndexChanged);
            this.CBox_Section.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBox_Section_KeyPress);
            this.CBox_Section.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBox_Section_KeyUp);
            // 
            // CBox_Group
            // 
            this.CBox_Group.AllowDrop = true;
            this.CBox_Group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CBox_Group.DropDownHeight = 110;
            this.CBox_Group.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBox_Group.FormattingEnabled = true;
            this.CBox_Group.IntegralHeight = false;
            this.CBox_Group.Location = new System.Drawing.Point(844, 229);
            this.CBox_Group.Name = "CBox_Group";
            this.CBox_Group.Size = new System.Drawing.Size(67, 22);
            this.CBox_Group.TabIndex = 33;
            this.toolTip1.SetToolTip(this.CBox_Group, "F5   - To Search Employee by Selected Value");
            this.CBox_Group.SelectedIndexChanged += new System.EventHandler(this.CBox_Group_SelectedIndexChanged);
            this.CBox_Group.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBox_Group_KeyPress);
            this.CBox_Group.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBox_Group_KeyUp);
            // 
            // CBox_WorkingTime
            // 
            this.CBox_WorkingTime.AllowDrop = true;
            this.CBox_WorkingTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CBox_WorkingTime.DropDownHeight = 110;
            this.CBox_WorkingTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBox_WorkingTime.FormattingEnabled = true;
            this.CBox_WorkingTime.IntegralHeight = false;
            this.CBox_WorkingTime.Location = new System.Drawing.Point(586, 255);
            this.CBox_WorkingTime.Name = "CBox_WorkingTime";
            this.CBox_WorkingTime.Size = new System.Drawing.Size(325, 22);
            this.CBox_WorkingTime.TabIndex = 34;
            this.toolTip1.SetToolTip(this.CBox_WorkingTime, "F5   - To Search Employee by Selected Value");
            this.CBox_WorkingTime.SelectedIndexChanged += new System.EventHandler(this.CBox_WorkingTime_SelectedIndexChanged);
            this.CBox_WorkingTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBox_WorkingTime_KeyPress);
            this.CBox_WorkingTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBox_WorkingTime_KeyUp);
            // 
            // CBox_SalaryRule
            // 
            this.CBox_SalaryRule.AllowDrop = true;
            this.CBox_SalaryRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CBox_SalaryRule.DropDownHeight = 110;
            this.CBox_SalaryRule.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBox_SalaryRule.FormattingEnabled = true;
            this.CBox_SalaryRule.IntegralHeight = false;
            this.CBox_SalaryRule.Location = new System.Drawing.Point(586, 282);
            this.CBox_SalaryRule.Name = "CBox_SalaryRule";
            this.CBox_SalaryRule.Size = new System.Drawing.Size(325, 22);
            this.CBox_SalaryRule.TabIndex = 35;
            this.toolTip1.SetToolTip(this.CBox_SalaryRule, "F5   - To Search Employee by Selected Value");
            this.CBox_SalaryRule.SelectedIndexChanged += new System.EventHandler(this.CBox_SalaryRule_SelectedIndexChanged);
            this.CBox_SalaryRule.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBox_SalaryRule_KeyPress);
            this.CBox_SalaryRule.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CBox_SalaryRule_KeyUp);
            // 
            // txtSignPath
            // 
            this.txtSignPath.Location = new System.Drawing.Point(1014, 77);
            this.txtSignPath.Name = "txtSignPath";
            this.txtSignPath.Size = new System.Drawing.Size(53, 20);
            this.txtSignPath.TabIndex = 143;
            this.txtSignPath.Visible = false;
            // 
            // lbRecordCount
            // 
            this.lbRecordCount.AutoSize = true;
            this.lbRecordCount.BackColor = System.Drawing.SystemColors.Control;
            this.lbRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbRecordCount.Location = new System.Drawing.Point(20, 574);
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Size = new System.Drawing.Size(184, 16);
            this.lbRecordCount.TabIndex = 75;
            this.lbRecordCount.Text = "                                            ";
            this.lbRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCountData
            // 
            this.lbCountData.AutoSize = true;
            this.lbCountData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbCountData.Location = new System.Drawing.Point(915, 525);
            this.lbCountData.Name = "lbCountData";
            this.lbCountData.Size = new System.Drawing.Size(134, 16);
            this.lbCountData.TabIndex = 147;
            this.lbCountData.Text = "Current Data No: 1";
            this.lbCountData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // grLos
            // 
            this.grLos.Controls.Add(this.lbLos);
            this.grLos.Font = new System.Drawing.Font("Monotype Corsiva", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grLos.Location = new System.Drawing.Point(918, 312);
            this.grLos.Name = "grLos";
            this.grLos.Size = new System.Drawing.Size(165, 49);
            this.grLos.TabIndex = 150;
            this.grLos.TabStop = false;
            this.grLos.Text = "Length of Service";
            // 
            // lbLos
            // 
            this.lbLos.AutoSize = true;
            this.lbLos.BackColor = System.Drawing.SystemColors.Control;
            this.lbLos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLos.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbLos.Location = new System.Drawing.Point(8, 23);
            this.lbLos.Name = "lbLos";
            this.lbLos.Size = new System.Drawing.Size(99, 13);
            this.lbLos.TabIndex = 160;
            this.lbLos.Text = "                       ";
            // 
            // grLv
            // 
            this.grLv.Controls.Add(this.lbLv);
            this.grLv.Font = new System.Drawing.Font("Monotype Corsiva", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grLv.Location = new System.Drawing.Point(918, 367);
            this.grLv.Name = "grLv";
            this.grLv.Size = new System.Drawing.Size(165, 45);
            this.grLv.TabIndex = 151;
            this.grLv.TabStop = false;
            this.grLv.Text = "Leave Balance";
            // 
            // lbLv
            // 
            this.lbLv.AutoSize = true;
            this.lbLv.BackColor = System.Drawing.SystemColors.Control;
            this.lbLv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLv.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbLv.Location = new System.Drawing.Point(10, 21);
            this.lbLv.Name = "lbLv";
            this.lbLv.Size = new System.Drawing.Size(127, 13);
            this.lbLv.TabIndex = 146;
            this.lbLv.Text = "                              ";
            this.lbLv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDetails
            // 
            this.lbDetails.AutoSize = true;
            this.lbDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetails.Location = new System.Drawing.Point(919, 443);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.Size = new System.Drawing.Size(72, 16);
            this.lbDetails.TabIndex = 152;
            this.lbDetails.TabStop = true;
            this.lbDetails.Text = "More Info...";
            this.lbDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDetails.Click += new System.EventHandler(this.link_lbl_emp_details_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSavePhoto,
            this.tsmiSetDefaultImage,
            this.tsmiUploadPicture,
            this.tsmiUploadPhotoByFolder});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 108);
            // 
            // tsmiSavePhoto
            // 
            this.tsmiSavePhoto.Image = global::NGPayroll.Properties.Resources.Save_As1;
            this.tsmiSavePhoto.Name = "tsmiSavePhoto";
            this.tsmiSavePhoto.Size = new System.Drawing.Size(156, 26);
            this.tsmiSavePhoto.Text = "Save Photo";
            this.tsmiSavePhoto.Click += new System.EventHandler(this.tsmiSavePhoto_Click);
            // 
            // tsmiSetDefaultImage
            // 
            this.tsmiSetDefaultImage.Image = global::NGPayroll.Properties.Resources.ml;
            this.tsmiSetDefaultImage.Name = "tsmiSetDefaultImage";
            this.tsmiSetDefaultImage.Size = new System.Drawing.Size(156, 26);
            this.tsmiSetDefaultImage.Text = "Default Image";
            this.tsmiSetDefaultImage.Click += new System.EventHandler(this.tsmiSetDefaultImage_Click);
            // 
            // tsmiUploadPicture
            // 
            this.tsmiUploadPicture.Image = global::NGPayroll.Properties.Resources.upload_pic;
            this.tsmiUploadPicture.Name = "tsmiUploadPicture";
            this.tsmiUploadPicture.Size = new System.Drawing.Size(156, 26);
            this.tsmiUploadPicture.Text = "Upload Picture";
            this.tsmiUploadPicture.Click += new System.EventHandler(this.tsmiUploadPicture_Click);
            // 
            // tsmiUploadPhotoByFolder
            // 
            this.tsmiUploadPhotoByFolder.Image = global::NGPayroll.Properties.Resources.upload_pico;
            this.tsmiUploadPhotoByFolder.Name = "tsmiUploadPhotoByFolder";
            this.tsmiUploadPhotoByFolder.Size = new System.Drawing.Size(156, 26);
            this.tsmiUploadPhotoByFolder.Text = "Upload Folder";
            this.tsmiUploadPhotoByFolder.Click += new System.EventHandler(this.tsmiUploadPhotoByFolder_Click);
            // 
            // txt_husband_name
            // 
            this.txt_husband_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_husband_name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_husband_name.Location = new System.Drawing.Point(142, 174);
            this.txt_husband_name.Name = "txt_husband_name";
            this.txt_husband_name.Size = new System.Drawing.Size(171, 22);
            this.txt_husband_name.TabIndex = 5;
            this.txt_husband_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txt_husband_name, "F5   - To Search Employee by Selected Value");
            this.txt_husband_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_husband_name_KeyUp);
            // 
            // husband_lbl
            // 
            this.husband_lbl.AutoSize = true;
            this.husband_lbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.husband_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.husband_lbl.Location = new System.Drawing.Point(44, 178);
            this.husband_lbl.Name = "husband_lbl";
            this.husband_lbl.Size = new System.Drawing.Size(95, 14);
            this.husband_lbl.TabIndex = 62;
            this.husband_lbl.Text = "Husband/Wife";
            // 
            // edu_lbl
            // 
            this.edu_lbl.AutoSize = true;
            this.edu_lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edu_lbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.edu_lbl.Location = new System.Drawing.Point(278, 489);
            this.edu_lbl.Name = "edu_lbl";
            this.edu_lbl.Size = new System.Drawing.Size(71, 16);
            this.edu_lbl.TabIndex = 83;
            this.edu_lbl.Text = "Education";
            // 
            // lbLastCode
            // 
            this.lbLastCode.AutoSize = true;
            this.lbLastCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbLastCode.Location = new System.Drawing.Point(1010, 501);
            this.lbLastCode.Name = "lbLastCode";
            this.lbLastCode.Size = new System.Drawing.Size(32, 16);
            this.lbLastCode.TabIndex = 154;
            this.lbLastCode.Text = "      ";
            this.lbLastCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLastCode.Visible = false;
            this.lbLastCode.Click += new System.EventHandler(this.lblLastUpdateCode_Click);
            // 
            // lbLastUpdate
            // 
            this.lbLastUpdate.AutoSize = true;
            this.lbLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbLastUpdate.Location = new System.Drawing.Point(915, 501);
            this.lbLastUpdate.Name = "lbLastUpdate";
            this.lbLastUpdate.Size = new System.Drawing.Size(96, 16);
            this.lbLastUpdate.TabIndex = 155;
            this.lbLastUpdate.Text = "Last Update:";
            this.lbLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLastUpdate.Visible = false;
            // 
            // btnUploadSignature
            // 
            this.btnUploadSignature.BackColor = System.Drawing.SystemColors.Window;
            this.btnUploadSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUploadSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadSignature.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUploadSignature.Location = new System.Drawing.Point(1006, 251);
            this.btnUploadSignature.Name = "btnUploadSignature";
            this.btnUploadSignature.Size = new System.Drawing.Size(62, 27);
            this.btnUploadSignature.TabIndex = 50;
            this.btnUploadSignature.Text = "SIGN";
            this.btnUploadSignature.UseVisualStyleBackColor = false;
            this.btnUploadSignature.Click += new System.EventHandler(this.btnUploadSignature_Click);
            // 
            // cmdBtnUploadPhoto
            // 
            this.cmdBtnUploadPhoto.BackColor = System.Drawing.SystemColors.Window;
            this.cmdBtnUploadPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdBtnUploadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBtnUploadPhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBtnUploadPhoto.Location = new System.Drawing.Point(932, 251);
            this.cmdBtnUploadPhoto.Name = "cmdBtnUploadPhoto";
            this.cmdBtnUploadPhoto.Size = new System.Drawing.Size(65, 27);
            this.cmdBtnUploadPhoto.TabIndex = 49;
            this.cmdBtnUploadPhoto.Text = "IMAGE";
            this.cmdBtnUploadPhoto.UseVisualStyleBackColor = false;
            this.cmdBtnUploadPhoto.Click += new System.EventHandler(this.cmdBtnUploadPhoto_Click);
            // 
            // lbLastDay
            // 
            this.lbLastDay.AutoSize = true;
            this.lbLastDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastDay.ForeColor = System.Drawing.Color.Maroon;
            this.lbLastDay.Location = new System.Drawing.Point(922, 420);
            this.lbLastDay.Name = "lbLastDay";
            this.lbLastDay.Size = new System.Drawing.Size(54, 15);
            this.lbLastDay.TabIndex = 158;
            this.lbLastDay.Text = "Last Day";
            this.lbLastDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLastDay.Visible = false;
            // 
            // myListBox
            // 
            this.myListBox.FormattingEnabled = true;
            this.myListBox.Location = new System.Drawing.Point(971, 1);
            this.myListBox.Name = "myListBox";
            this.myListBox.Size = new System.Drawing.Size(112, 17);
            this.myListBox.TabIndex = 163;
            this.myListBox.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Help";
            // 
            // pBoxPhoto
            // 
            this.pBoxPhoto.BackColor = System.Drawing.SystemColors.Window;
            this.pBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxPhoto.ContextMenuStrip = this.contextMenuStrip1;
            this.pBoxPhoto.Location = new System.Drawing.Point(931, 99);
            this.pBoxPhoto.Name = "pBoxPhoto";
            this.pBoxPhoto.Size = new System.Drawing.Size(138, 151);
            this.pBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxPhoto.TabIndex = 102;
            this.pBoxPhoto.TabStop = false;
            this.toolTip1.SetToolTip(this.pBoxPhoto, "Right Click to Upload Employee\'s Picture.");
            // 
            // pBoxEmpSignature
            // 
            this.pBoxEmpSignature.BackColor = System.Drawing.SystemColors.Window;
            this.pBoxEmpSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxEmpSignature.Location = new System.Drawing.Point(930, 282);
            this.pBoxEmpSignature.Name = "pBoxEmpSignature";
            this.pBoxEmpSignature.Size = new System.Drawing.Size(137, 24);
            this.pBoxEmpSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxEmpSignature.TabIndex = 141;
            this.pBoxEmpSignature.TabStop = false;
            this.toolTip1.SetToolTip(this.pBoxEmpSignature, "Click Here to Upload Employee\'s Signature.");
            this.pBoxEmpSignature.Click += new System.EventHandler(this.pBoxEmpSignature_Click);
            // 
            // txtLicenseNo
            // 
            this.txtLicenseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicenseNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseNo.Location = new System.Drawing.Point(586, 462);
            this.txtLicenseNo.Name = "txtLicenseNo";
            this.txtLicenseNo.Size = new System.Drawing.Size(121, 22);
            this.txtLicenseNo.TabIndex = 171;
            this.txtLicenseNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtLicenseNo, "F5     - To Search Employee\r\nF12   - Update License No");
            this.txtLicenseNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLicenseNo_KeyUp);
            // 
            // cmbEL
            // 
            this.cmbEL.AllowDrop = true;
            this.cmbEL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEL.FormattingEnabled = true;
            this.cmbEL.Items.AddRange(new object[] {
            "N/A",
            "July",
            "January"});
            this.cmbEL.Location = new System.Drawing.Point(586, 435);
            this.cmbEL.Name = "cmbEL";
            this.cmbEL.Size = new System.Drawing.Size(121, 24);
            this.cmbEL.TabIndex = 173;
            this.toolTip1.SetToolTip(this.cmbEL, "F5   - To Search Employee by Selected Value");
            this.cmbEL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbEL_KeyUp);
            // 
            // txtErpCode
            // 
            this.txtErpCode.BackColor = System.Drawing.Color.White;
            this.txtErpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtErpCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErpCode.Location = new System.Drawing.Point(351, 70);
            this.txtErpCode.Name = "txtErpCode";
            this.txtErpCode.Size = new System.Drawing.Size(130, 22);
            this.txtErpCode.TabIndex = 175;
            this.txtErpCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtErpCode, "F5   - Search By %.....%\r\nF12 - Update Education");
            this.txtErpCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtErpCode_KeyUp);
            // 
            // cmbPresDist
            // 
            this.cmbPresDist.AllowDrop = true;
            this.cmbPresDist.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPresDist.FormattingEnabled = true;
            this.cmbPresDist.Location = new System.Drawing.Point(351, 305);
            this.cmbPresDist.Name = "cmbPresDist";
            this.cmbPresDist.Size = new System.Drawing.Size(130, 24);
            this.cmbPresDist.TabIndex = 177;
            this.cmbPresDist.Text = "GAZIPUR";
            this.toolTip1.SetToolTip(this.cmbPresDist, "F5   - Press F5 to Search");
            this.cmbPresDist.SelectedIndexChanged += new System.EventHandler(this.cmbPresDist_SelectedIndexChanged);
            this.cmbPresDist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbPresDist_KeyUp);
            // 
            // cmbPerDist
            // 
            this.cmbPerDist.AllowDrop = true;
            this.cmbPerDist.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPerDist.FormattingEnabled = true;
            this.cmbPerDist.Location = new System.Drawing.Point(351, 357);
            this.cmbPerDist.Name = "cmbPerDist";
            this.cmbPerDist.Size = new System.Drawing.Size(130, 24);
            this.cmbPerDist.TabIndex = 178;
            this.toolTip1.SetToolTip(this.cmbPerDist, "F5   - Press F5 to Search");
            this.cmbPerDist.SelectedIndexChanged += new System.EventHandler(this.cmbPerDist_SelectedIndexChanged);
            this.cmbPerDist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbPerDist_KeyUp);
            // 
            // cmbEducation
            // 
            this.cmbEducation.AllowDrop = true;
            this.cmbEducation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEducation.FormattingEnabled = true;
            this.cmbEducation.Location = new System.Drawing.Point(351, 486);
            this.cmbEducation.Name = "cmbEducation";
            this.cmbEducation.Size = new System.Drawing.Size(130, 24);
            this.cmbEducation.TabIndex = 179;
            this.toolTip1.SetToolTip(this.cmbEducation, "F5   - Search By Education\r\nF12 - Update Educational Qualification");
            this.cmbEducation.SelectedIndexChanged += new System.EventHandler(this.cmbEducation_SelectedIndexChanged);
            this.cmbEducation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbEducation_KeyUp);
            // 
            // txtEmployement
            // 
            this.txtEmployement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployement.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployement.Location = new System.Drawing.Point(586, 411);
            this.txtEmployement.Name = "txtEmployement";
            this.txtEmployement.Size = new System.Drawing.Size(121, 21);
            this.txtEmployement.TabIndex = 167;
            this.txtEmployement.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtEmployement, "F5   - To Search Employee by Selected Value");
            this.txtEmployement.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtEmployement_KeyUp);
            // 
            // txtNomineeCellNo
            // 
            this.txtNomineeCellNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomineeCellNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomineeCellNo.Location = new System.Drawing.Point(351, 513);
            this.txtNomineeCellNo.Name = "txtNomineeCellNo";
            this.txtNomineeCellNo.Size = new System.Drawing.Size(130, 22);
            this.txtNomineeCellNo.TabIndex = 168;
            this.txtNomineeCellNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtNomineeCellNo, "F5   - To Search Employee by Selected Value");
            this.txtNomineeCellNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNomineeCellNo_KeyUp);
            // 
            // cmbIncrSeg
            // 
            this.cmbIncrSeg.AllowDrop = true;
            this.cmbIncrSeg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIncrSeg.FormattingEnabled = true;
            this.cmbIncrSeg.Items.AddRange(new object[] {
            "N/A",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbIncrSeg.Location = new System.Drawing.Point(810, 436);
            this.cmbIncrSeg.Name = "cmbIncrSeg";
            this.cmbIncrSeg.Size = new System.Drawing.Size(103, 24);
            this.cmbIncrSeg.TabIndex = 173;
            this.cmbIncrSeg.Text = "<Incr Segment>";
            this.toolTip1.SetToolTip(this.cmbIncrSeg, "F5   - To Search Employee by Selected Value");
            this.cmbIncrSeg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbIncrSeg_KeyUp);
            // 
            // txtQtr
            // 
            this.txtQtr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtQtr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtr.Location = new System.Drawing.Point(810, 512);
            this.txtQtr.Name = "txtQtr";
            this.txtQtr.Size = new System.Drawing.Size(106, 22);
            this.txtQtr.TabIndex = 231;
            this.txtQtr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtQtr, "F5   - List along with Allowane (Ex =500)\r\nF12  - Update The Information");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(506, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 166;
            this.label3.Text = "Experience";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(265, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 169;
            this.label4.Text = "Nominee Cell";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(962, 77);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 170;
            this.txtPassword.Visible = false;
            // 
            // btnExitLastUC
            // 
            this.btnExitLastUC.BackColor = System.Drawing.SystemColors.Window;
            this.btnExitLastUC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExitLastUC.BackgroundImage")));
            this.btnExitLastUC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExitLastUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitLastUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitLastUC.Location = new System.Drawing.Point(649, 550);
            this.btnExitLastUC.Name = "btnExitLastUC";
            this.btnExitLastUC.Size = new System.Drawing.Size(71, 28);
            this.btnExitLastUC.TabIndex = 56;
            this.btnExitLastUC.Text = "Exit";
            this.btnExitLastUC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExitLastUC.UseVisualStyleBackColor = false;
            this.btnExitLastUC.Click += new System.EventHandler(this.btnExitLastUC_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.Window;
            this.btn_clear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_clear.BackgroundImage")));
            this.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(578, 550);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(72, 28);
            this.btn_clear.TabIndex = 53;
            this.btn_clear.Text = "Clear";
            this.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Window;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(489, 550);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 28);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(508, 465);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 172;
            this.label5.Text = "License No";
            // 
            // chkEL
            // 
            this.chkEL.AutoSize = true;
            this.chkEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEL.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEL.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chkEL.Location = new System.Drawing.Point(485, 437);
            this.chkEL.Name = "chkEL";
            this.chkEL.Size = new System.Drawing.Size(99, 20);
            this.chkEL.TabIndex = 174;
            this.chkEL.Text = "EL Segment";
            this.chkEL.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(279, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 14);
            this.label6.TabIndex = 176;
            this.label6.Text = "ERP Code";
            // 
            // txtBangHusband
            // 
            this.txtBangHusband.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangHusband.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F);
            this.txtBangHusband.Location = new System.Drawing.Point(320, 174);
            this.txtBangHusband.Name = "txtBangHusband";
            this.txtBangHusband.Size = new System.Drawing.Size(161, 23);
            this.txtBangHusband.TabIndex = 188;
            this.txtBangHusband.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangHusband.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_spouse_name_KeyUp);
            // 
            // txtBangMotherName
            // 
            this.txtBangMotherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangMotherName.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F);
            this.txtBangMotherName.Location = new System.Drawing.Point(320, 148);
            this.txtBangMotherName.Name = "txtBangMotherName";
            this.txtBangMotherName.Size = new System.Drawing.Size(161, 23);
            this.txtBangMotherName.TabIndex = 187;
            this.txtBangMotherName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangMotherName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_mother_name_KeyUp);
            // 
            // txtBangFatherName
            // 
            this.txtBangFatherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangFatherName.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F);
            this.txtBangFatherName.Location = new System.Drawing.Point(320, 123);
            this.txtBangFatherName.Name = "txtBangFatherName";
            this.txtBangFatherName.Size = new System.Drawing.Size(161, 23);
            this.txtBangFatherName.TabIndex = 186;
            this.txtBangFatherName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangFatherName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_father_name_KeyUp);
            // 
            // txtEmpNameBang
            // 
            this.txtEmpNameBang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtEmpNameBang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpNameBang.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpNameBang.Location = new System.Drawing.Point(320, 96);
            this.txtEmpNameBang.Name = "txtEmpNameBang";
            this.txtEmpNameBang.Size = new System.Drawing.Size(161, 23);
            this.txtEmpNameBang.TabIndex = 185;
            this.txtEmpNameBang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmpNameBang.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_name_KeyUp);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label44.Location = new System.Drawing.Point(37, 449);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(65, 14);
            this.label44.TabIndex = 220;
            this.label44.Text = "স্থায়ী ঠিকানা";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(113, 465);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 14);
            this.label8.TabIndex = 219;
            this.label8.Text = "থানা";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label12.Location = new System.Drawing.Point(114, 439);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 14);
            this.label12.TabIndex = 218;
            this.label12.Text = "গ্রাম";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label16.Location = new System.Drawing.Point(317, 462);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 16);
            this.label16.TabIndex = 217;
            this.label16.Text = "জেলা";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label42.Location = new System.Drawing.Point(308, 436);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 16);
            this.label42.TabIndex = 216;
            this.label42.Text = "ডাকঘর";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label43.Location = new System.Drawing.Point(26, 396);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(76, 14);
            this.label43.TabIndex = 211;
            this.label43.Text = "বর্তমান ঠিকানা";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label17.Location = new System.Drawing.Point(317, 412);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 16);
            this.label17.TabIndex = 215;
            this.label17.Text = "জেলা";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Location = new System.Drawing.Point(113, 412);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 14);
            this.label10.TabIndex = 213;
            this.label10.Text = "থানা";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label14.Location = new System.Drawing.Point(308, 386);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 16);
            this.label14.TabIndex = 214;
            this.label14.Text = "ডাকঘর";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label45.Location = new System.Drawing.Point(114, 387);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(26, 14);
            this.label45.TabIndex = 212;
            this.label45.Text = "গ্রাম";
            // 
            // txtBangParmentDist
            // 
            this.txtBangParmentDist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBangParmentDist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBangParmentDist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangParmentDist.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBangParmentDist.Location = new System.Drawing.Point(351, 461);
            this.txtBangParmentDist.Name = "txtBangParmentDist";
            this.txtBangParmentDist.Size = new System.Drawing.Size(130, 23);
            this.txtBangParmentDist.TabIndex = 210;
            this.txtBangParmentDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangParmentDist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_par_dist_KeyUp);
            // 
            // txtBangParmentPS
            // 
            this.txtBangParmentPS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBangParmentPS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBangParmentPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangParmentPS.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBangParmentPS.Location = new System.Drawing.Point(142, 461);
            this.txtBangParmentPS.Name = "txtBangParmentPS";
            this.txtBangParmentPS.Size = new System.Drawing.Size(121, 23);
            this.txtBangParmentPS.TabIndex = 209;
            this.txtBangParmentPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangParmentPS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_par_Ps_KeyUp);
            // 
            // txtBangParmentPO
            // 
            this.txtBangParmentPO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBangParmentPO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBangParmentPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangParmentPO.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBangParmentPO.Location = new System.Drawing.Point(351, 435);
            this.txtBangParmentPO.Name = "txtBangParmentPO";
            this.txtBangParmentPO.Size = new System.Drawing.Size(130, 23);
            this.txtBangParmentPO.TabIndex = 208;
            this.txtBangParmentPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangParmentPO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_par_po_KeyUp);
            // 
            // txtBangParmentVill
            // 
            this.txtBangParmentVill.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBangParmentVill.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBangParmentVill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangParmentVill.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBangParmentVill.Location = new System.Drawing.Point(142, 435);
            this.txtBangParmentVill.Name = "txtBangParmentVill";
            this.txtBangParmentVill.Size = new System.Drawing.Size(121, 23);
            this.txtBangParmentVill.TabIndex = 207;
            this.txtBangParmentVill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangParmentVill.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_par_vill_KeyUp);
            // 
            // txtBangPresentDist
            // 
            this.txtBangPresentDist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangPresentDist.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBangPresentDist.Location = new System.Drawing.Point(351, 409);
            this.txtBangPresentDist.Name = "txtBangPresentDist";
            this.txtBangPresentDist.Size = new System.Drawing.Size(130, 23);
            this.txtBangPresentDist.TabIndex = 206;
            this.txtBangPresentDist.Text = "MvRxcyi";
            this.txtBangPresentDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangPresentDist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_pre_dist_KeyUp);
            // 
            // txtBangPresentPS
            // 
            this.txtBangPresentPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangPresentPS.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBangPresentPS.Location = new System.Drawing.Point(142, 409);
            this.txtBangPresentPS.Name = "txtBangPresentPS";
            this.txtBangPresentPS.Size = new System.Drawing.Size(121, 23);
            this.txtBangPresentPS.TabIndex = 205;
            this.txtBangPresentPS.Text = "m`i";
            this.txtBangPresentPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangPresentPS.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_pre_PS_KeyUp);
            // 
            // txtBangPresentPO
            // 
            this.txtBangPresentPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangPresentPO.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBangPresentPO.Location = new System.Drawing.Point(351, 383);
            this.txtBangPresentPO.Name = "txtBangPresentPO";
            this.txtBangPresentPO.Size = new System.Drawing.Size(130, 23);
            this.txtBangPresentPO.TabIndex = 204;
            this.txtBangPresentPO.Text = "wgR©vcyi evRvi";
            this.txtBangPresentPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangPresentPO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_pre_po_KeyUp);
            // 
            // txtBangPresentVill
            // 
            this.txtBangPresentVill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBangPresentVill.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBangPresentVill.Location = new System.Drawing.Point(142, 383);
            this.txtBangPresentVill.Name = "txtBangPresentVill";
            this.txtBangPresentVill.Size = new System.Drawing.Size(121, 23);
            this.txtBangPresentVill.TabIndex = 203;
            this.txtBangPresentVill.Text = "fvIqvj wgR©vcyi";
            this.txtBangPresentVill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBangPresentVill.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_pre_vill_KeyUp);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label50.Location = new System.Drawing.Point(483, 518);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(104, 14);
            this.label50.TabIndex = 227;
            this.label50.Text = "Nominee Bangla";
            // 
            // txtBang_nomini
            // 
            this.txtBang_nomini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBang_nomini.Font = new System.Drawing.Font("SutonnyMJ", 9.749999F);
            this.txtBang_nomini.Location = new System.Drawing.Point(587, 513);
            this.txtBang_nomini.Name = "txtBang_nomini";
            this.txtBang_nomini.Size = new System.Drawing.Size(156, 23);
            this.txtBang_nomini.TabIndex = 226;
            this.txtBang_nomini.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBang_nomini.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_bang_nomini_KeyUp);
            // 
            // cmbPos
            // 
            this.cmbPos.AllowDrop = true;
            this.cmbPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbPos.DropDownHeight = 110;
            this.cmbPos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPos.FormattingEnabled = true;
            this.cmbPos.IntegralHeight = false;
            this.cmbPos.Location = new System.Drawing.Point(585, 98);
            this.cmbPos.Name = "cmbPos";
            this.cmbPos.Size = new System.Drawing.Size(323, 22);
            this.cmbPos.TabIndex = 228;
            this.cmbPos.SelectedIndexChanged += new System.EventHandler(this.cmbPos_SelectedIndexChanged);
            this.cmbPos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbPos_KeyUp);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label46.Location = new System.Drawing.Point(517, 101);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 16);
            this.label46.TabIndex = 229;
            this.label46.Text = "Position";
            // 
            // cmbGrd
            // 
            this.cmbGrd.AllowDrop = true;
            this.cmbGrd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbGrd.DropDownHeight = 110;
            this.cmbGrd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGrd.FormattingEnabled = true;
            this.cmbGrd.IntegralHeight = false;
            this.cmbGrd.Location = new System.Drawing.Point(845, 124);
            this.cmbGrd.Name = "cmbGrd";
            this.cmbGrd.Size = new System.Drawing.Size(67, 22);
            this.cmbGrd.TabIndex = 230;
            this.cmbGrd.SelectedIndexChanged += new System.EventHandler(this.cmbGrd_SelectedIndexChanged);
            this.cmbGrd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_grade_KeyUp);
            // 
            // employee_Information_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.txtQtr);
            this.Controls.Add(this.cmbGrd);
            this.Controls.Add(this.cmbPos);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.txtBang_nomini);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.txtBangParmentDist);
            this.Controls.Add(this.txtBangParmentPS);
            this.Controls.Add(this.txtBangParmentPO);
            this.Controls.Add(this.txtBangParmentVill);
            this.Controls.Add(this.txtBangPresentDist);
            this.Controls.Add(this.txtBangPresentPS);
            this.Controls.Add(this.txtBangPresentPO);
            this.Controls.Add(this.txtBangPresentVill);
            this.Controls.Add(this.txtBangHusband);
            this.Controls.Add(this.txtBangMotherName);
            this.Controls.Add(this.txtBangFatherName);
            this.Controls.Add(this.txtEmpNameBang);
            this.Controls.Add(this.cmbEducation);
            this.Controls.Add(this.cmbPerDist);
            this.Controls.Add(this.cmbPresDist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtErpCode);
            this.Controls.Add(this.chkEL);
            this.Controls.Add(this.cmbIncrSeg);
            this.Controls.Add(this.cmbEL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLicenseNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNomineeCellNo);
            this.Controls.Add(this.txtEmployement);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.emp_info_lbl);
            this.Controls.Add(this.pBoxPhoto);
            this.Controls.Add(this.lbLastDay);
            this.Controls.Add(this.myListBox);
            this.Controls.Add(this.lbLastUpdate);
            this.Controls.Add(this.lbLastCode);
            this.Controls.Add(this.dtpCloseDate);
            this.Controls.Add(this.edu_lbl);
            this.Controls.Add(this.husband_lbl);
            this.Controls.Add(this.txt_husband_name);
            this.Controls.Add(this.lbDetails);
            this.Controls.Add(this.lbCountData);
            this.Controls.Add(this.lbRecordCount);
            this.Controls.Add(this.txtSignPath);
            this.Controls.Add(this.btnUploadSignature);
            this.Controls.Add(this.pBoxEmpSignature);
            this.Controls.Add(this.btnExitLastUC);
            this.Controls.Add(this.CBox_SalaryRule);
            this.Controls.Add(this.CBox_WorkingTime);
            this.Controls.Add(this.CBox_Group);
            this.Controls.Add(this.CBox_Section);
            this.Controls.Add(this.CBox_Department);
            this.Controls.Add(this.CBox_Category);
            this.Controls.Add(this.CBox_Unit);
            this.Controls.Add(this.cmbDesig);
            this.Controls.Add(this.txtPhotoPath);
            this.Controls.Add(this.cmdBtnUploadPhoto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.emp_code_lbl);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.chkResign);
            this.Controls.Add(this.CB_contractual);
            this.Controls.Add(this.CB_tax);
            this.Controls.Add(this.CB_quater);
            this.Controls.Add(this.CB_ot_holder);
            this.Controls.Add(this.RB_None);
            this.Controls.Add(this.RB_Mobile);
            this.Controls.Add(this.RB_Bank);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.combo_weekend);
            this.Controls.Add(this.txt_cell_no);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txtProximityNo);
            this.Controls.Add(this.txt_basic);
            this.Controls.Add(this.txt_gross);
            this.Controls.Add(this.txt_salary_rule);
            this.Controls.Add(this.txt_working_time);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.txt_user_id);
            this.Controls.Add(this.txt_section);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txt_department);
            this.Controls.Add(this.txt_category);
            this.Controls.Add(this.txt_unit);
            this.Controls.Add(this.txt_designation);
            this.Controls.Add(this.dtpJoinDate);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.ps1_lbl);
            this.Controls.Add(this.ps_lbl);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.vill1_lbl);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.vill_lbl);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bday_lbl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.marital_lbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gender_lbl);
            this.Controls.Add(this.mother_lbl);
            this.Controls.Add(this.father_lbl);
            this.Controls.Add(this.name_lbl);
            this.Controls.Add(this.combo_relation);
            this.Controls.Add(this.txt_beneficiary);
            this.Controls.Add(this.txt_remarks);
            this.Controls.Add(this.txt_national_id);
            this.Controls.Add(this.txt_ps_parmanent);
            this.Controls.Add(this.txt_po_parmanent);
            this.Controls.Add(this.txt_vill_parmanent);
            this.Controls.Add(this.txt_ps_present);
            this.Controls.Add(this.txt_po_present);
            this.Controls.Add(this.txt_vill_present);
            this.Controls.Add(this.txt_age);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.combo_blood);
            this.Controls.Add(this.combo_marital);
            this.Controls.Add(this.combo_religion);
            this.Controls.Add(this.combo_gender);
            this.Controls.Add(this.txt_emp_mother);
            this.Controls.Add(this.txt_father_name);
            this.Controls.Add(this.txt_emp_name);
            this.Controls.Add(this.txtEmpCode);
            this.Controls.Add(this.grLos);
            this.Controls.Add(this.grLv);
            this.Controls.Add(this.txtPassword);
            this.Name = "employee_Information_UC";
            this.Size = new System.Drawing.Size(1098, 622);
            this.Load += new System.EventHandler(this.employee_Information_UC_Load);
            this.grLos.ResumeLayout(false);
            this.grLos.PerformLayout();
            this.grLv.ResumeLayout(false);
            this.grLv.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxEmpSignature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        void label_label()
        {
            this.emp_info_lbl.BackColor = Color.Transparent;
            this.emp_code_lbl.BackColor = Color.Transparent;
            this.name_lbl.BackColor = Color.Transparent;
            this.father_lbl.BackColor = Color.Transparent;
            this.mother_lbl.BackColor = Color.Transparent;
            this.husband_lbl.BackColor = Color.Transparent;
            this.gender_lbl.BackColor = Color.Transparent;
            this.marital_lbl.BackColor = Color.Transparent;
            this.bday_lbl.BackColor = Color.Transparent;
            this.vill_lbl.BackColor = Color.Transparent;
            this.ps_lbl.BackColor = Color.Transparent;
            this.vill1_lbl.BackColor = Color.Transparent;
            this.edu_lbl.BackColor = Color.Transparent;
            this.ps1_lbl.BackColor = Color.Transparent;
            this.label20.BackColor = Color.Transparent;
            this.label22.BackColor = Color.Transparent;
            this.label7.BackColor = Color.Transparent;
            this.label9.BackColor = Color.Transparent;
            this.label11.BackColor = Color.Transparent;
            this.label13.BackColor = Color.Transparent;
            this.label18.BackColor = Color.Transparent;
            this.label15.BackColor = Color.Transparent;
            this.label19.BackColor = Color.Transparent;
            this.label21.BackColor = Color.Transparent;
            this.label23.BackColor = Color.Transparent;
            this.label1.BackColor = Color.Transparent;
            this.label2.BackColor = Color.Transparent;
            this.chkResign.BackColor = Color.Transparent;
            this.label25.BackColor = Color.Transparent;
            this.label26.BackColor = Color.Transparent;
            this.label27.BackColor = Color.Transparent;
            this.label28.BackColor = Color.Transparent;
            this.label29.BackColor = Color.Transparent;
            this.label30.BackColor = Color.Transparent;
            this.label31.BackColor = Color.Transparent;
            this.label32.BackColor = Color.Transparent;
            this.label33.BackColor = Color.Transparent;
            this.label24.BackColor = Color.Transparent;
            this.label34.BackColor = Color.Transparent;
            this.label35.BackColor = Color.Transparent;
            this.label36.BackColor = Color.Transparent;
            this.label37.BackColor = Color.Transparent;
            this.label38.BackColor = Color.Transparent;
            this.label39.BackColor = Color.Transparent;
            this.label40.BackColor = Color.Transparent;
            this.label41.BackColor = Color.Transparent;
            this.CB_ot_holder.BackColor = Color.Transparent;
            this.CB_quater.BackColor = Color.Transparent;
            this.CB_tax.BackColor = Color.Transparent;
            this.CB_contractual.BackColor = Color.Transparent;
            this.RB_Mobile.BackColor = Color.Transparent;
            this.RB_Bank.BackColor = Color.Transparent;
            this.RB_None.BackColor = Color.Transparent;
            this.lbLv.BackColor = Color.Transparent;
            this.lbLos.BackColor = Color.Transparent;
            this.lbDetails.BackColor = Color.Transparent;
            this.lbCountData.BackColor = Color.Transparent;
            this.lbLastCode.BackColor = Color.Transparent;
            this.lbLastUpdate.BackColor = Color.Transparent;
            this.lbRecordCount.BackColor = Color.Transparent;
            this.grLos.BackColor = Color.Transparent;
            this.grLv.BackColor = Color.Transparent;
            this.pBoxPhoto.BackColor = Color.Transparent;
            this.pBoxEmpSignature.BackColor = Color.Transparent;

        }
        #endregion

        private System.Windows.Forms.Label emp_info_lbl;
        private System.Windows.Forms.TextBox txtEmpCode;
        private System.Windows.Forms.TextBox txt_emp_name;
        private System.Windows.Forms.TextBox txt_father_name;
        private System.Windows.Forms.TextBox txt_emp_mother;
        private System.Windows.Forms.ComboBox combo_gender;
        private System.Windows.Forms.ComboBox combo_religion;
        private System.Windows.Forms.ComboBox combo_marital;
        private System.Windows.Forms.ComboBox combo_blood;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.TextBox txt_age;
        private System.Windows.Forms.TextBox txt_vill_present;
        private System.Windows.Forms.TextBox txt_po_present;
        private System.Windows.Forms.TextBox txt_ps_present;
        private System.Windows.Forms.TextBox txt_vill_parmanent;
        private System.Windows.Forms.TextBox txt_po_parmanent;
        private System.Windows.Forms.TextBox txt_ps_parmanent;
        private System.Windows.Forms.TextBox txt_national_id;
        private System.Windows.Forms.TextBox txt_remarks;
        private System.Windows.Forms.TextBox txt_beneficiary;
        private System.Windows.Forms.ComboBox combo_relation;
        private System.Windows.Forms.DateTimePicker dtpCloseDate;
        private System.Windows.Forms.Label emp_code_lbl;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.Label father_lbl;
        private System.Windows.Forms.Label mother_lbl;
        private System.Windows.Forms.Label gender_lbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label marital_lbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label bday_lbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label vill_lbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label vill1_lbl;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label ps_lbl;
        private System.Windows.Forms.Label ps1_lbl;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpJoinDate;
        private System.Windows.Forms.TextBox txt_designation;
        private System.Windows.Forms.TextBox txt_unit;
        private System.Windows.Forms.TextBox txt_category;
        private System.Windows.Forms.TextBox txt_department;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txt_section;
        private System.Windows.Forms.TextBox txt_user_id;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txt_working_time;
        private System.Windows.Forms.TextBox txt_salary_rule;
        private System.Windows.Forms.TextBox txt_gross;
        private System.Windows.Forms.TextBox txt_basic;
        private System.Windows.Forms.TextBox txtProximityNo;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_cell_no;
        private System.Windows.Forms.ComboBox combo_weekend;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.RadioButton RB_Bank;
        private System.Windows.Forms.RadioButton RB_Mobile;
        private System.Windows.Forms.RadioButton RB_None;
        private System.Windows.Forms.CheckBox CB_ot_holder;
        private System.Windows.Forms.CheckBox CB_quater;
        private System.Windows.Forms.CheckBox CB_tax;
        private System.Windows.Forms.CheckBox CB_contractual;
        private System.Windows.Forms.CheckBox chkResign;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private PictureBox pBoxPhoto;
        private Button cmdBtnUploadPhoto;
        private TextBox txtPhotoPath;
        private ComboBox cmbDesig;
        private ComboBox CBox_Unit;
        private ComboBox CBox_Category;
        private ComboBox CBox_Department;
        private ComboBox CBox_Section;
        private ComboBox CBox_Group;
        private ComboBox CBox_WorkingTime;
        private ComboBox CBox_SalaryRule;
        private Button btnExitLastUC;
        private PictureBox pBoxEmpSignature;
        private Button btnUploadSignature;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txtSignPath;
        private Label lbRecordCount;
        private Label lbCountData;
        private OpenFileDialog openFileDialog1;
        private GroupBox grLos;
        private GroupBox grLv;
        private Label lbLv;
        private LinkLabel lbDetails;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiSetDefaultImage;
        private ToolStripMenuItem tsmiUploadPicture;
        private ToolStripMenuItem tsmiUploadPhotoByFolder;
        private TextBox txt_husband_name;
        private Label husband_lbl;
        private Label edu_lbl;
        private Label lbLastCode;
        private Label lbLastUpdate;
        private Label lbLastDay;
        private Label lbLos;
        private ListBox myListBox;
        private ToolTip toolTip1;
        private Label label3;
        private TextBox txtEmployement;
        private TextBox txtNomineeCellNo;
        private Label label4;
        private Button btnSave;
        private TextBox txtPassword;
        private Label label5;
        private TextBox txtLicenseNo;
        private ComboBox cmbEL;
        private CheckBox chkEL;
        private TextBox txtErpCode;
        private Label label6;
        private ComboBox cmbPresDist;
        private ComboBox cmbPerDist;
        private ComboBox cmbEducation;
        private ToolStripMenuItem tsmiSavePhoto;
        private SaveFileDialog saveFileDialog1;
        private ComboBox cmbIncrSeg;
        private TextBox txtBangHusband;
        private TextBox txtBangMotherName;
        private TextBox txtBangFatherName;
        private TextBox txtEmpNameBang;
        private Label label44;
        private Label label8;
        private Label label12;
        private Label label16;
        private Label label42;
        private Label label43;
        private Label label17;
        private Label label10;
        private Label label14;
        private Label label45;
        private TextBox txtBangParmentDist;
        private TextBox txtBangParmentPS;
        private TextBox txtBangParmentPO;
        private TextBox txtBangParmentVill;
        private TextBox txtBangPresentDist;
        private TextBox txtBangPresentPS;
        private TextBox txtBangPresentPO;
        private TextBox txtBangPresentVill;
        private Label label50;
        private TextBox txtBang_nomini;
        private ComboBox cmbPos;
        private Label label46;
        private ComboBox cmbGrd;
        private TextBox txtQtr;

        public string leave_bal1 { get; set; }
    }
}
