namespace NGPayroll
{
    partial class Attendance_Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendance_Details));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsmAttdManupulation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLockData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUnlockData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLeaveUnlock = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLockByDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUnlockByDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRetriveAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAttSearch = new System.Windows.Forms.TextBox();
            this.chk_dt = new System.Windows.Forms.CheckBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchData = new System.Windows.Forms.Button();
            this.btnSearchFromData = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_emp_name = new System.Windows.Forms.Label();
            this.dgvAttd = new System.Windows.Forms.DataGridView();
            this.attDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.late = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.night = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMP_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nightFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_OT_HOLDER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_IN_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_OUT_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATTD_LOCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EARLY_OUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAttDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEmpInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmWeekend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetWeekend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshWeekend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShiftManupulation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeShift = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshShift = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetOnMissingInTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResetInTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshInTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOutTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetOnMissingOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResetOutTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshOutTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOutTimeByOT = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSetInAndOutTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetOnMissingInOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetOnResetInOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshInOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOverTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetOverTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveOTHours = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNight = new System.Windows.Forms.ToolStripMenuItem();
            this.nightYesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nightNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOnStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetOnStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetOnStatus2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLeave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLeaveCPL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLeaveLWP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaternityLeave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLeave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAutoLeave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLayOff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLOW = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHoliday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetHoliday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefreshHoliday = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportDataToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txt_emp_code = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txt_unit_id = new System.Windows.Forms.TextBox();
            this.txt_dept_id = new System.Windows.Forms.TextBox();
            this.txt_emp_type = new System.Windows.Forms.TextBox();
            this.txt_section_id = new System.Windows.Forms.TextBox();
            this.txt_shift_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_line_id = new System.Windows.Forms.TextBox();
            this.dTp_nextDay = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.LB_attendance_details = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_clr = new System.Windows.Forms.Button();
            this.btn_clr_all = new System.Windows.Forms.Button();
            this.combo_unit_name = new System.Windows.Forms.ComboBox();
            this.combo_emp_type = new System.Windows.Forms.ComboBox();
            this.combo_section_name = new System.Windows.Forms.ComboBox();
            this.combo_department = new System.Windows.Forms.ComboBox();
            this.combo_line_name = new System.Windows.Forms.ComboBox();
            this.combo_shift = new System.Windows.Forms.ComboBox();
            this.comBoxDesig = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExitUserControl = new System.Windows.Forms.Button();
            this.btn_clear_allData = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttd)).BeginInit();
            this.cmsAttDetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmAttdManupulation
            // 
            this.tsmAttdManupulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLockData,
            this.tsmiUnlockData,
            this.tsmiDeleteData,
            this.tsmiLeaveUnlock,
            this.tsmiLockByDate,
            this.tsmiUnlockByDate,
            this.tsmiRetriveAttendance});
            this.tsmAttdManupulation.Image = global::NGPayroll.Properties.Resources.mainBanner_service;
            this.tsmAttdManupulation.Name = "tsmAttdManupulation";
            this.tsmAttdManupulation.Size = new System.Drawing.Size(213, 22);
            this.tsmAttdManupulation.Text = "Attendance Manupulation";
            // 
            // tsmiLockData
            // 
            this.tsmiLockData.Image = global::NGPayroll.Properties.Resources.logoff1;
            this.tsmiLockData.Name = "tsmiLockData";
            this.tsmiLockData.Size = new System.Drawing.Size(174, 22);
            this.tsmiLockData.Text = "Lock";
            this.tsmiLockData.Click += new System.EventHandler(this.tsmiLockData_Click);
            // 
            // tsmiUnlockData
            // 
            this.tsmiUnlockData.Image = global::NGPayroll.Properties.Resources.unloc;
            this.tsmiUnlockData.Name = "tsmiUnlockData";
            this.tsmiUnlockData.Size = new System.Drawing.Size(174, 22);
            this.tsmiUnlockData.Text = "Unlock";
            this.tsmiUnlockData.Click += new System.EventHandler(this.tsmiUnlockData_Click);
            // 
            // tsmiDeleteData
            // 
            this.tsmiDeleteData.Image = global::NGPayroll.Properties.Resources.gnome_edit_delete;
            this.tsmiDeleteData.Name = "tsmiDeleteData";
            this.tsmiDeleteData.Size = new System.Drawing.Size(174, 22);
            this.tsmiDeleteData.Text = "Delete";
            this.tsmiDeleteData.Click += new System.EventHandler(this.tsmiDeleteData_Click);
            // 
            // tsmiLeaveUnlock
            // 
            this.tsmiLeaveUnlock.Image = global::NGPayroll.Properties.Resources.lock_and_key_web_icon;
            this.tsmiLeaveUnlock.Name = "tsmiLeaveUnlock";
            this.tsmiLeaveUnlock.Size = new System.Drawing.Size(174, 22);
            this.tsmiLeaveUnlock.Text = "Leave Unlock";
            this.tsmiLeaveUnlock.Click += new System.EventHandler(this.tsmiLeaveUnlock_Click);
            // 
            // tsmiLockByDate
            // 
            this.tsmiLockByDate.Image = global::NGPayroll.Properties.Resources.lock_date;
            this.tsmiLockByDate.Name = "tsmiLockByDate";
            this.tsmiLockByDate.Size = new System.Drawing.Size(174, 22);
            this.tsmiLockByDate.Text = "Lock By Date";
            this.tsmiLockByDate.Click += new System.EventHandler(this.tsmiLockByDate_Click);
            // 
            // tsmiUnlockByDate
            // 
            this.tsmiUnlockByDate.Image = global::NGPayroll.Properties.Resources.unlock;
            this.tsmiUnlockByDate.Name = "tsmiUnlockByDate";
            this.tsmiUnlockByDate.Size = new System.Drawing.Size(174, 22);
            this.tsmiUnlockByDate.Text = "Unlock By Date";
            this.tsmiUnlockByDate.Click += new System.EventHandler(this.tsmiUnlockByDate_Click);
            // 
            // tsmiRetriveAttendance
            // 
            this.tsmiRetriveAttendance.Image = global::NGPayroll.Properties.Resources.agt_reload;
            this.tsmiRetriveAttendance.Name = "tsmiRetriveAttendance";
            this.tsmiRetriveAttendance.Size = new System.Drawing.Size(174, 22);
            this.tsmiRetriveAttendance.Text = "Retrive Attendance";
            this.tsmiRetriveAttendance.Click += new System.EventHandler(this.tsmiRetriveAttendance_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(418, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attendance Details";
            // 
            // txtAttSearch
            // 
            this.txtAttSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAttSearch.Location = new System.Drawing.Point(119, 17);
            this.txtAttSearch.Name = "txtAttSearch";
            this.helpProvider1.SetShowHelp(this.txtAttSearch, true);
            this.txtAttSearch.Size = new System.Drawing.Size(134, 23);
            this.txtAttSearch.TabIndex = 3;
            this.txtAttSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtAttSearch, resources.GetString("txtAttSearch.ToolTip"));
            this.txtAttSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAttSearch_KeyUp);
            // 
            // chk_dt
            // 
            this.chk_dt.AutoSize = true;
            this.chk_dt.Checked = true;
            this.chk_dt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_dt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_dt.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chk_dt.Location = new System.Drawing.Point(308, 18);
            this.chk_dt.Name = "chk_dt";
            this.chk_dt.Size = new System.Drawing.Size(93, 20);
            this.chk_dt.TabIndex = 16;
            this.chk_dt.Text = "Date From";
            this.toolTip1.SetToolTip(this.chk_dt, "Checked if Need to Manupulate Specific Attendance Date\r\nUnchecked Manululate 40 D" +
        "ays Before From Date");
            this.chk_dt.UseVisualStyleBackColor = true;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd-MMM-yyyy";
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(407, 18);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(117, 20);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.Value = new System.DateTime(2015, 5, 12, 6, 9, 0, 0);
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd-MMM-yyyy";
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(576, 18);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(118, 20);
            this.dtpEnd.TabIndex = 1;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.btnSearchData);
            this.groupBox1.Controls.Add(this.btnSearchFromData);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.txtAttSearch);
            this.groupBox1.Controls.Add(this.chk_dt);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(25, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 49);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "------";
            // 
            // btnSearchData
            // 
            this.btnSearchData.BackColor = System.Drawing.Color.White;
            this.btnSearchData.BackgroundImage = global::NGPayroll.Properties.Resources.Search_Mag;
            this.btnSearchData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchData.ForeColor = System.Drawing.Color.White;
            this.btnSearchData.Location = new System.Drawing.Point(266, 17);
            this.btnSearchData.Name = "btnSearchData";
            this.btnSearchData.Size = new System.Drawing.Size(28, 24);
            this.btnSearchData.TabIndex = 116;
            this.toolTip1.SetToolTip(this.btnSearchData, "Click to Search Employee Attendance");
            this.btnSearchData.UseVisualStyleBackColor = false;
            this.btnSearchData.Click += new System.EventHandler(this.btnSearchFromData_Click);
            // 
            // btnSearchFromData
            // 
            this.btnSearchFromData.BackColor = System.Drawing.Color.White;
            this.btnSearchFromData.BackgroundImage = global::NGPayroll.Properties.Resources.pngSearch;
            this.btnSearchFromData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchFromData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchFromData.ForeColor = System.Drawing.Color.White;
            this.btnSearchFromData.Location = new System.Drawing.Point(710, 16);
            this.btnSearchFromData.Name = "btnSearchFromData";
            this.btnSearchFromData.Size = new System.Drawing.Size(28, 24);
            this.btnSearchFromData.TabIndex = 115;
            this.toolTip1.SetToolTip(this.btnSearchFromData, "Click to Search Employee Attendance");
            this.btnSearchFromData.UseVisualStyleBackColor = false;
            this.btnSearchFromData.Click += new System.EventHandler(this.btnSearchFromData_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(543, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 16);
            this.label8.TabIndex = 100;
            this.label8.Text = "To";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Location = new System.Drawing.Point(12, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 16);
            this.label11.TabIndex = 100;
            this.label11.Text = "A/P/W/H/L/N";
            // 
            // lbl_emp_name
            // 
            this.lbl_emp_name.AutoSize = true;
            this.lbl_emp_name.Font = new System.Drawing.Font("Maiandra GD", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_emp_name.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_emp_name.Location = new System.Drawing.Point(785, 210);
            this.lbl_emp_name.Name = "lbl_emp_name";
            this.lbl_emp_name.Size = new System.Drawing.Size(197, 15);
            this.lbl_emp_name.TabIndex = 26;
            this.lbl_emp_name.Tag = "    ";
            this.lbl_emp_name.Text = "                                      ";
            // 
            // dgvAttd
            // 
            this.dgvAttd.AllowUserToAddRows = false;
            this.dgvAttd.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attDate,
            this.empCode,
            this.empName,
            this.inTime,
            this.late,
            this.workHour,
            this.outTime,
            this.overTime,
            this.status,
            this.night,
            this.status2,
            this.EMP_ID,
            this.rFlag,
            this.nightFlag,
            this.inFlag,
            this.outFlag,
            this.shiftName,
            this.shift_id,
            this.remarks,
            this.IS_OT_HOLDER,
            this.IS_IN_TIME,
            this.IS_OUT_TIME,
            this.ATTD_LOCK,
            this.EARLY_OUT});
            this.dgvAttd.ContextMenuStrip = this.cmsAttDetails;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttd.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvAttd.Location = new System.Drawing.Point(25, 232);
            this.dgvAttd.Name = "dgvAttd";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttd.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAttd.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvAttd.Size = new System.Drawing.Size(1050, 325);
            this.dgvAttd.TabIndex = 23;
            this.dgvAttd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttDetails_CellEndEdit);
            this.dgvAttd.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAttDetails_CellFormatting);
            this.dgvAttd.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAttDetails_DataError);
            this.dgvAttd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvAttDetails_KeyUp);
            // 
            // attDate
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.attDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.attDate.HeaderText = "Date";
            this.attDate.Name = "attDate";
            this.attDate.ReadOnly = true;
            this.attDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // empCode
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.empCode.HeaderText = "Code";
            this.empCode.Name = "empCode";
            this.empCode.ReadOnly = true;
            this.empCode.Width = 70;
            // 
            // empName
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.empName.DefaultCellStyle = dataGridViewCellStyle4;
            this.empName.HeaderText = "Name";
            this.empName.Name = "empName";
            this.empName.ReadOnly = true;
            this.empName.Width = 200;
            // 
            // inTime
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.inTime.HeaderText = "In Time";
            this.inTime.Name = "inTime";
            this.inTime.Width = 70;
            // 
            // late
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.late.DefaultCellStyle = dataGridViewCellStyle6;
            this.late.HeaderText = "Late";
            this.late.Name = "late";
            this.late.Width = 50;
            // 
            // workHour
            // 
            this.workHour.HeaderText = "Work Hour";
            this.workHour.Name = "workHour";
            this.workHour.Width = 40;
            // 
            // outTime
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Format = "G";
            dataGridViewCellStyle7.NullValue = null;
            this.outTime.DefaultCellStyle = dataGridViewCellStyle7;
            this.outTime.HeaderText = "Out Time";
            this.outTime.Name = "outTime";
            this.outTime.Width = 70;
            // 
            // overTime
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.overTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.overTime.HeaderText = "OT";
            this.overTime.Name = "overTime";
            this.overTime.Width = 40;
            // 
            // status
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle9;
            this.status.HeaderText = "STS";
            this.status.Name = "status";
            this.status.Width = 40;
            // 
            // night
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.night.DefaultCellStyle = dataGridViewCellStyle10;
            this.night.HeaderText = "Night";
            this.night.Name = "night";
            this.night.Width = 45;
            // 
            // status2
            // 
            this.status2.HeaderText = "STS2";
            this.status2.Name = "status2";
            this.status2.Width = 40;
            // 
            // EMP_ID
            // 
            this.EMP_ID.HeaderText = "EMP ID";
            this.EMP_ID.Name = "EMP_ID";
            this.EMP_ID.Visible = false;
            // 
            // rFlag
            // 
            this.rFlag.HeaderText = "Remarks_Flag";
            this.rFlag.Name = "rFlag";
            this.rFlag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rFlag.Visible = false;
            this.rFlag.Width = 30;
            // 
            // nightFlag
            // 
            this.nightFlag.HeaderText = "Night_Flag";
            this.nightFlag.Name = "nightFlag";
            this.nightFlag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.nightFlag.Visible = false;
            // 
            // inFlag
            // 
            this.inFlag.HeaderText = "In_flag";
            this.inFlag.Name = "inFlag";
            this.inFlag.ReadOnly = true;
            this.inFlag.Visible = false;
            this.inFlag.Width = 30;
            // 
            // outFlag
            // 
            this.outFlag.HeaderText = "out_flag";
            this.outFlag.Name = "outFlag";
            this.outFlag.ReadOnly = true;
            this.outFlag.Visible = false;
            this.outFlag.Width = 30;
            // 
            // shiftName
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Silver;
            this.shiftName.DefaultCellStyle = dataGridViewCellStyle11;
            this.shiftName.HeaderText = "Shift";
            this.shiftName.Name = "shiftName";
            this.shiftName.ReadOnly = true;
            this.shiftName.Width = 150;
            // 
            // shift_id
            // 
            this.shift_id.HeaderText = "shift_id";
            this.shift_id.Name = "shift_id";
            this.shift_id.Visible = false;
            this.shift_id.Width = 20;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            // 
            // IS_OT_HOLDER
            // 
            this.IS_OT_HOLDER.HeaderText = "OT_HOLDER";
            this.IS_OT_HOLDER.Name = "IS_OT_HOLDER";
            this.IS_OT_HOLDER.Visible = false;
            // 
            // IS_IN_TIME
            // 
            this.IS_IN_TIME.HeaderText = "IS_IN_TIME";
            this.IS_IN_TIME.Name = "IS_IN_TIME";
            this.IS_IN_TIME.Visible = false;
            // 
            // IS_OUT_TIME
            // 
            this.IS_OUT_TIME.HeaderText = "IS_OUT_TIME";
            this.IS_OUT_TIME.Name = "IS_OUT_TIME";
            this.IS_OUT_TIME.Visible = false;
            // 
            // ATTD_LOCK
            // 
            this.ATTD_LOCK.HeaderText = "ATTD_LOCK";
            this.ATTD_LOCK.Name = "ATTD_LOCK";
            this.ATTD_LOCK.Visible = false;
            // 
            // EARLY_OUT
            // 
            this.EARLY_OUT.HeaderText = "Early Out";
            this.EARLY_OUT.Name = "EARLY_OUT";
            this.EARLY_OUT.Visible = false;
            // 
            // cmsAttDetails
            // 
            this.cmsAttDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEmpInfo,
            this.tsmWeekend,
            this.tsmShiftManupulation,
            this.tsmiSaveData,
            this.tsmiRefresh,
            this.tsmInTime,
            this.tsmOutTime,
            this.tsmSetInAndOutTime,
            this.tsmOverTime,
            this.tsmNight,
            this.tsmOnStatus,
            this.tsmLeave,
            this.tsmHoliday,
            this.tsmiExportDataToExcel,
            this.tsmAttdManupulation});
            this.cmsAttDetails.Name = "contextMenuStrip1";
            this.cmsAttDetails.Size = new System.Drawing.Size(214, 356);
            this.cmsAttDetails.Opening += new System.ComponentModel.CancelEventHandler(this.cmsAttDetails_Opening);
            // 
            // tsmiEmpInfo
            // 
            this.tsmiEmpInfo.Image = global::NGPayroll.Properties.Resources.ml;
            this.tsmiEmpInfo.Name = "tsmiEmpInfo";
            this.tsmiEmpInfo.Size = new System.Drawing.Size(213, 22);
            this.tsmiEmpInfo.Text = "Employee Info";
            this.tsmiEmpInfo.Click += new System.EventHandler(this.tsmiEmpInfo_Click);
            // 
            // tsmWeekend
            // 
            this.tsmWeekend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetWeekend,
            this.tsmiRefreshWeekend});
            this.tsmWeekend.Name = "tsmWeekend";
            this.tsmWeekend.Size = new System.Drawing.Size(213, 22);
            this.tsmWeekend.Text = "Set Weekend";
            // 
            // tsmiSetWeekend
            // 
            this.tsmiSetWeekend.Name = "tsmiSetWeekend";
            this.tsmiSetWeekend.Size = new System.Drawing.Size(163, 22);
            this.tsmiSetWeekend.Text = "Set Weekend";
            this.tsmiSetWeekend.Click += new System.EventHandler(this.tsmiSetWeekend_Click);
            // 
            // tsmiRefreshWeekend
            // 
            this.tsmiRefreshWeekend.Name = "tsmiRefreshWeekend";
            this.tsmiRefreshWeekend.Size = new System.Drawing.Size(163, 22);
            this.tsmiRefreshWeekend.Text = "Refresh weekend";
            this.tsmiRefreshWeekend.Click += new System.EventHandler(this.tsmiRefreshWeekend_Click);
            // 
            // tsmShiftManupulation
            // 
            this.tsmShiftManupulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChangeShift,
            this.tsmiRefreshShift});
            this.tsmShiftManupulation.Name = "tsmShiftManupulation";
            this.tsmShiftManupulation.Size = new System.Drawing.Size(213, 22);
            this.tsmShiftManupulation.Text = "Shift Manupulation";
            // 
            // tsmiChangeShift
            // 
            this.tsmiChangeShift.Name = "tsmiChangeShift";
            this.tsmiChangeShift.Size = new System.Drawing.Size(142, 22);
            this.tsmiChangeShift.Text = "Change Shift";
            this.tsmiChangeShift.Click += new System.EventHandler(this.tsmiChangeShift_Click);
            // 
            // tsmiRefreshShift
            // 
            this.tsmiRefreshShift.Name = "tsmiRefreshShift";
            this.tsmiRefreshShift.Size = new System.Drawing.Size(142, 22);
            this.tsmiRefreshShift.Text = "Refresh Shift";
            this.tsmiRefreshShift.Click += new System.EventHandler(this.tsmiRefreshShift_Click);
            // 
            // tsmiSaveData
            // 
            this.tsmiSaveData.Image = global::NGPayroll.Properties.Resources.Savex;
            this.tsmiSaveData.Name = "tsmiSaveData";
            this.tsmiSaveData.Size = new System.Drawing.Size(213, 22);
            this.tsmiSaveData.Text = "Update Data";
            this.tsmiSaveData.Click += new System.EventHandler(this.tsmiSaveData_Click);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Image = global::NGPayroll.Properties.Resources.update2;
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(213, 22);
            this.tsmiRefresh.Text = "Refresh Data";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // tsmInTime
            // 
            this.tsmInTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetOnMissingInTime,
            this.tsmiResetInTime,
            this.tsmiRefreshInTime});
            this.tsmInTime.Name = "tsmInTime";
            this.tsmInTime.Size = new System.Drawing.Size(213, 22);
            this.tsmInTime.Text = "Set In Time";
            // 
            // tsmiSetOnMissingInTime
            // 
            this.tsmiSetOnMissingInTime.Name = "tsmiSetOnMissingInTime";
            this.tsmiSetOnMissingInTime.Size = new System.Drawing.Size(155, 22);
            this.tsmiSetOnMissingInTime.Text = "Set On Missing";
            this.tsmiSetOnMissingInTime.Click += new System.EventHandler(this.tsmiSetOnMissingInTime_Click);
            // 
            // tsmiResetInTime
            // 
            this.tsmiResetInTime.Name = "tsmiResetInTime";
            this.tsmiResetInTime.Size = new System.Drawing.Size(155, 22);
            this.tsmiResetInTime.Text = "Reset In Time";
            this.tsmiResetInTime.Click += new System.EventHandler(this.tsmiResetInTime_Click);
            // 
            // tsmiRefreshInTime
            // 
            this.tsmiRefreshInTime.Name = "tsmiRefreshInTime";
            this.tsmiRefreshInTime.Size = new System.Drawing.Size(155, 22);
            this.tsmiRefreshInTime.Text = "Refresh In Time";
            this.tsmiRefreshInTime.Click += new System.EventHandler(this.tsmiRefreshInTime_Click);
            // 
            // tsmOutTime
            // 
            this.tsmOutTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetOnMissingOut,
            this.tsmiResetOutTime,
            this.tsmiRefreshOutTime,
            this.tsmiOutTimeByOT});
            this.tsmOutTime.Name = "tsmOutTime";
            this.tsmOutTime.Size = new System.Drawing.Size(213, 22);
            this.tsmOutTime.Text = "Set Out Time";
            // 
            // tsmiSetOnMissingOut
            // 
            this.tsmiSetOnMissingOut.Name = "tsmiSetOnMissingOut";
            this.tsmiSetOnMissingOut.Size = new System.Drawing.Size(165, 22);
            this.tsmiSetOnMissingOut.Text = "Set On Missing";
            this.tsmiSetOnMissingOut.Click += new System.EventHandler(this.tsmiSetOnMissingOut_Click);
            // 
            // tsmiResetOutTime
            // 
            this.tsmiResetOutTime.Name = "tsmiResetOutTime";
            this.tsmiResetOutTime.Size = new System.Drawing.Size(165, 22);
            this.tsmiResetOutTime.Text = "Reset Out Time";
            this.tsmiResetOutTime.Click += new System.EventHandler(this.tsmiResetOutTime_Click);
            // 
            // tsmiRefreshOutTime
            // 
            this.tsmiRefreshOutTime.Name = "tsmiRefreshOutTime";
            this.tsmiRefreshOutTime.Size = new System.Drawing.Size(165, 22);
            this.tsmiRefreshOutTime.Text = "Refresh Out Time";
            this.tsmiRefreshOutTime.Click += new System.EventHandler(this.tsmiRefreshOutTime_Click);
            // 
            // tsmiOutTimeByOT
            // 
            this.tsmiOutTimeByOT.Name = "tsmiOutTimeByOT";
            this.tsmiOutTimeByOT.Size = new System.Drawing.Size(165, 22);
            this.tsmiOutTimeByOT.Text = "Out Time By OT";
            this.tsmiOutTimeByOT.Click += new System.EventHandler(this.tsmiOutTimeByOT_Click);
            // 
            // tsmSetInAndOutTime
            // 
            this.tsmSetInAndOutTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetOnMissingInOut,
            this.tsmiSetOnResetInOut,
            this.tsmiRefreshInOut});
            this.tsmSetInAndOutTime.Name = "tsmSetInAndOutTime";
            this.tsmSetInAndOutTime.Size = new System.Drawing.Size(213, 22);
            this.tsmSetInAndOutTime.Text = "In And Out Time";
            // 
            // tsmiSetOnMissingInOut
            // 
            this.tsmiSetOnMissingInOut.Name = "tsmiSetOnMissingInOut";
            this.tsmiSetOnMissingInOut.Size = new System.Drawing.Size(182, 22);
            this.tsmiSetOnMissingInOut.Text = "Set On Missing Time";
            this.tsmiSetOnMissingInOut.Click += new System.EventHandler(this.tsmiSetOnMissingInOut_Click);
            // 
            // tsmiSetOnResetInOut
            // 
            this.tsmiSetOnResetInOut.Name = "tsmiSetOnResetInOut";
            this.tsmiSetOnResetInOut.Size = new System.Drawing.Size(182, 22);
            this.tsmiSetOnResetInOut.Text = "Set On Reset Time";
            this.tsmiSetOnResetInOut.Click += new System.EventHandler(this.tsmiSetOnResetInOut_Click);
            // 
            // tsmiRefreshInOut
            // 
            this.tsmiRefreshInOut.Name = "tsmiRefreshInOut";
            this.tsmiRefreshInOut.Size = new System.Drawing.Size(182, 22);
            this.tsmiRefreshInOut.Text = "Refresh In Out Time";
            this.tsmiRefreshInOut.Visible = false;
            this.tsmiRefreshInOut.Click += new System.EventHandler(this.tsmiRefreshInOut_Click);
            // 
            // tsmOverTime
            // 
            this.tsmOverTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetOverTime,
            this.tsmiRemoveOTHours});
            this.tsmOverTime.Name = "tsmOverTime";
            this.tsmOverTime.Size = new System.Drawing.Size(213, 22);
            this.tsmOverTime.Text = "Over Time";
            // 
            // tsmiSetOverTime
            // 
            this.tsmiSetOverTime.Name = "tsmiSetOverTime";
            this.tsmiSetOverTime.Size = new System.Drawing.Size(147, 22);
            this.tsmiSetOverTime.Text = "Set Over Time";
            this.tsmiSetOverTime.Click += new System.EventHandler(this.tsmiSetOverTime_Click);
            // 
            // tsmiRemoveOTHours
            // 
            this.tsmiRemoveOTHours.Name = "tsmiRemoveOTHours";
            this.tsmiRemoveOTHours.Size = new System.Drawing.Size(147, 22);
            this.tsmiRemoveOTHours.Text = "Remove OT";
            this.tsmiRemoveOTHours.Click += new System.EventHandler(this.tsmiRemoveOTHours_Click);
            // 
            // tsmNight
            // 
            this.tsmNight.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nightYesToolStripMenuItem,
            this.nightNoToolStripMenuItem});
            this.tsmNight.Name = "tsmNight";
            this.tsmNight.Size = new System.Drawing.Size(213, 22);
            this.tsmNight.Text = "Night";
            this.tsmNight.Visible = false;
            // 
            // nightYesToolStripMenuItem
            // 
            this.nightYesToolStripMenuItem.Name = "nightYesToolStripMenuItem";
            this.nightYesToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.nightYesToolStripMenuItem.Text = "Night Yes";
            this.nightYesToolStripMenuItem.Click += new System.EventHandler(this.tsmiNightYes_Click);
            // 
            // nightNoToolStripMenuItem
            // 
            this.nightNoToolStripMenuItem.Name = "nightNoToolStripMenuItem";
            this.nightNoToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.nightNoToolStripMenuItem.Text = "Night No";
            this.nightNoToolStripMenuItem.Click += new System.EventHandler(this.tsmiNightNo_Click);
            // 
            // tsmOnStatus
            // 
            this.tsmOnStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetOnStatus,
            this.tsmiSetOnStatus2});
            this.tsmOnStatus.Name = "tsmOnStatus";
            this.tsmOnStatus.Size = new System.Drawing.Size(213, 22);
            this.tsmOnStatus.Text = "Status";
            // 
            // tsmiSetOnStatus
            // 
            this.tsmiSetOnStatus.Name = "tsmiSetOnStatus";
            this.tsmiSetOnStatus.Size = new System.Drawing.Size(131, 22);
            this.tsmiSetOnStatus.Text = "On Status";
            this.tsmiSetOnStatus.Click += new System.EventHandler(this.tsmiSetOnStatus_Click);
            // 
            // tsmiSetOnStatus2
            // 
            this.tsmiSetOnStatus2.Name = "tsmiSetOnStatus2";
            this.tsmiSetOnStatus2.Size = new System.Drawing.Size(131, 22);
            this.tsmiSetOnStatus2.Text = "On Status2";
            this.tsmiSetOnStatus2.Click += new System.EventHandler(this.tsmiSetOnStatus2_Click);
            // 
            // tsmLeave
            // 
            this.tsmLeave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLeaveCPL,
            this.tsmiLeaveLWP,
            this.tsmiMaternityLeave,
            this.tsmiLeave,
            this.tsmiAutoLeave,
            this.tsmiLayOff,
            this.tsmiGL,
            this.tsmiLOW});
            this.tsmLeave.Name = "tsmLeave";
            this.tsmLeave.Size = new System.Drawing.Size(213, 22);
            this.tsmLeave.Text = "Leave";
            // 
            // tsmiLeaveCPL
            // 
            this.tsmiLeaveCPL.Name = "tsmiLeaveCPL";
            this.tsmiLeaveCPL.Size = new System.Drawing.Size(192, 22);
            this.tsmiLeaveCPL.Text = "Leave (CPL/SPL)";
            this.tsmiLeaveCPL.Click += new System.EventHandler(this.tsmiLeaveCPL_Click);
            // 
            // tsmiLeaveLWP
            // 
            this.tsmiLeaveLWP.Name = "tsmiLeaveLWP";
            this.tsmiLeaveLWP.Size = new System.Drawing.Size(192, 22);
            this.tsmiLeaveLWP.Text = "Leave (LWP)";
            this.tsmiLeaveLWP.Visible = false;
            this.tsmiLeaveLWP.Click += new System.EventHandler(this.tsmiLeaveLWP_Click);
            // 
            // tsmiMaternityLeave
            // 
            this.tsmiMaternityLeave.Name = "tsmiMaternityLeave";
            this.tsmiMaternityLeave.Size = new System.Drawing.Size(192, 22);
            this.tsmiMaternityLeave.Text = "Leave (Maternity)";
            this.tsmiMaternityLeave.Click += new System.EventHandler(this.tsmiMaternityLeave_Click);
            // 
            // tsmiLeave
            // 
            this.tsmiLeave.Name = "tsmiLeave";
            this.tsmiLeave.Size = new System.Drawing.Size(192, 22);
            this.tsmiLeave.Text = "Leave (CL/SL/EL)";
            this.tsmiLeave.Click += new System.EventHandler(this.tsmiLeave_Click);
            // 
            // tsmiAutoLeave
            // 
            this.tsmiAutoLeave.Name = "tsmiAutoLeave";
            this.tsmiAutoLeave.Size = new System.Drawing.Size(192, 22);
            this.tsmiAutoLeave.Text = "Auto Leave (CL/SL/EL)";
            this.tsmiAutoLeave.Click += new System.EventHandler(this.tsmiAutoLeave_Click);
            // 
            // tsmiLayOff
            // 
            this.tsmiLayOff.Name = "tsmiLayOff";
            this.tsmiLayOff.Size = new System.Drawing.Size(192, 22);
            this.tsmiLayOff.Text = "LO(LOF)";
            this.tsmiLayOff.Click += new System.EventHandler(this.lOLOFToolStripMenuItem_Click);
            // 
            // tsmiGL
            // 
            this.tsmiGL.Name = "tsmiGL";
            this.tsmiGL.Size = new System.Drawing.Size(192, 22);
            this.tsmiGL.Text = "Leave(GL)";
            this.tsmiGL.Click += new System.EventHandler(this.leaveGLToolStripMenuItem_Click);
            // 
            // tsmiLOW
            // 
            this.tsmiLOW.Name = "tsmiLOW";
            this.tsmiLOW.Size = new System.Drawing.Size(192, 22);
            this.tsmiLOW.Text = "LOW(LOFWeekend)";
            this.tsmiLOW.Click += new System.EventHandler(this.lOWLOFWeekendToolStripMenuItem_Click);
            // 
            // tsmHoliday
            // 
            this.tsmHoliday.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetHoliday,
            this.tsmiRefreshHoliday});
            this.tsmHoliday.Name = "tsmHoliday";
            this.tsmHoliday.Size = new System.Drawing.Size(213, 22);
            this.tsmHoliday.Text = "Set Holiday";
            // 
            // tsmiSetHoliday
            // 
            this.tsmiSetHoliday.Name = "tsmiSetHoliday";
            this.tsmiSetHoliday.Size = new System.Drawing.Size(157, 22);
            this.tsmiSetHoliday.Text = "Set Holiday";
            this.tsmiSetHoliday.Click += new System.EventHandler(this.tsmiSetHoliday_Click);
            // 
            // tsmiRefreshHoliday
            // 
            this.tsmiRefreshHoliday.Name = "tsmiRefreshHoliday";
            this.tsmiRefreshHoliday.Size = new System.Drawing.Size(157, 22);
            this.tsmiRefreshHoliday.Text = "Refresh Holiday";
            this.tsmiRefreshHoliday.Click += new System.EventHandler(this.tsmiRefreshHoliday_Click);
            // 
            // tsmiExportDataToExcel
            // 
            this.tsmiExportDataToExcel.Image = global::NGPayroll.Properties.Resources.excel;
            this.tsmiExportDataToExcel.Name = "tsmiExportDataToExcel";
            this.tsmiExportDataToExcel.Size = new System.Drawing.Size(213, 22);
            this.tsmiExportDataToExcel.Text = "Export To Excel";
            this.tsmiExportDataToExcel.Click += new System.EventHandler(this.tsmiExportDataToExcel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(979, 563);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 14);
            this.label9.TabIndex = 109;
            this.label9.Text = "Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(28, 564);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 15);
            this.label13.TabIndex = 110;
            this.label13.Text = "Attendance";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Info";
            // 
            // txt_emp_code
            // 
            this.txt_emp_code.Location = new System.Drawing.Point(10, 69);
            this.txt_emp_code.Name = "txt_emp_code";
            this.txt_emp_code.Size = new System.Drawing.Size(108, 22);
            this.txt_emp_code.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txt_emp_code, "F1   -  Upload Employee Code From TXT File\r\nEnter To Add Employee Code Into The L" +
        "ist Box");
            this.txt_emp_code.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_emp_code_KeyUp);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(497, 123);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(54, 20);
            this.txtPassword.TabIndex = 113;
            this.txtPassword.Visible = false;
            // 
            // txt_unit_id
            // 
            this.txt_unit_id.Location = new System.Drawing.Point(315, 67);
            this.txt_unit_id.Name = "txt_unit_id";
            this.txt_unit_id.Size = new System.Drawing.Size(35, 20);
            this.txt_unit_id.TabIndex = 1;
            this.txt_unit_id.Visible = false;
            // 
            // txt_dept_id
            // 
            this.txt_dept_id.Location = new System.Drawing.Point(315, 93);
            this.txt_dept_id.Name = "txt_dept_id";
            this.txt_dept_id.Size = new System.Drawing.Size(35, 20);
            this.txt_dept_id.TabIndex = 2;
            this.txt_dept_id.Visible = false;
            // 
            // txt_emp_type
            // 
            this.txt_emp_type.Location = new System.Drawing.Point(695, 69);
            this.txt_emp_type.Name = "txt_emp_type";
            this.txt_emp_type.Size = new System.Drawing.Size(37, 20);
            this.txt_emp_type.TabIndex = 4;
            this.txt_emp_type.Visible = false;
            // 
            // txt_section_id
            // 
            this.txt_section_id.Location = new System.Drawing.Point(695, 95);
            this.txt_section_id.Name = "txt_section_id";
            this.txt_section_id.Size = new System.Drawing.Size(37, 20);
            this.txt_section_id.TabIndex = 5;
            this.txt_section_id.Visible = false;
            // 
            // txt_shift_id
            // 
            this.txt_shift_id.Location = new System.Drawing.Point(695, 121);
            this.txt_shift_id.Name = "txt_shift_id";
            this.txt_shift_id.Size = new System.Drawing.Size(37, 20);
            this.txt_shift_id.TabIndex = 6;
            this.txt_shift_id.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(28, 71);
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
            this.label3.Location = new System.Drawing.Point(28, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Department";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(28, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Line Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(415, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(415, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Section";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(415, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Shift Name";
            // 
            // txt_line_id
            // 
            this.txt_line_id.Location = new System.Drawing.Point(315, 119);
            this.txt_line_id.Name = "txt_line_id";
            this.txt_line_id.Size = new System.Drawing.Size(35, 20);
            this.txt_line_id.TabIndex = 3;
            this.txt_line_id.Visible = false;
            // 
            // dTp_nextDay
            // 
            this.dTp_nextDay.CustomFormat = "dd-MMM-yyyy";
            this.dTp_nextDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTp_nextDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTp_nextDay.Location = new System.Drawing.Point(180, 114);
            this.dTp_nextDay.Name = "dTp_nextDay";
            this.dTp_nextDay.Size = new System.Drawing.Size(112, 20);
            this.dTp_nextDay.TabIndex = 116;
            this.dTp_nextDay.Value = new System.DateTime(2015, 5, 12, 6, 9, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Location = new System.Drawing.Point(29, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Emp Code";
            // 
            // LB_attendance_details
            // 
            this.LB_attendance_details.FormattingEnabled = true;
            this.LB_attendance_details.ItemHeight = 15;
            this.LB_attendance_details.Location = new System.Drawing.Point(164, 12);
            this.LB_attendance_details.Name = "LB_attendance_details";
            this.LB_attendance_details.Size = new System.Drawing.Size(128, 139);
            this.LB_attendance_details.TabIndex = 2;
            this.LB_attendance_details.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LB_attendance_details_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.LB_attendance_details);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.btn_clr);
            this.groupBox2.Controls.Add(this.btn_clr_all);
            this.groupBox2.Controls.Add(this.txt_emp_code);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dTp_nextDay);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Maiandra GD", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.groupBox2.Location = new System.Drawing.Point(782, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 152);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attendance For ";
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Transparent;
            this.btn_add.BackgroundImage = global::NGPayroll.Properties.Resources.add21;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.ForeColor = System.Drawing.Color.Transparent;
            this.btn_add.Location = new System.Drawing.Point(130, 30);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(27, 27);
            this.btn_add.TabIndex = 630;
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_clr
            // 
            this.btn_clr.BackColor = System.Drawing.Color.Transparent;
            this.btn_clr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clr.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_clr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clr.ForeColor = System.Drawing.Color.Transparent;
            this.btn_clr.Image = global::NGPayroll.Properties.Resources.clear;
            this.btn_clr.Location = new System.Drawing.Point(130, 66);
            this.btn_clr.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clr.Name = "btn_clr";
            this.btn_clr.Size = new System.Drawing.Size(27, 27);
            this.btn_clr.TabIndex = 632;
            this.btn_clr.UseVisualStyleBackColor = false;
            this.btn_clr.Click += new System.EventHandler(this.btn_clr_Click);
            // 
            // btn_clr_all
            // 
            this.btn_clr_all.BackColor = System.Drawing.Color.Transparent;
            this.btn_clr_all.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clr_all.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_clr_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clr_all.ForeColor = System.Drawing.Color.Transparent;
            this.btn_clr_all.Image = global::NGPayroll.Properties.Resources.delete_all_participants;
            this.btn_clr_all.Location = new System.Drawing.Point(130, 100);
            this.btn_clr_all.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clr_all.Name = "btn_clr_all";
            this.btn_clr_all.Size = new System.Drawing.Size(27, 27);
            this.btn_clr_all.TabIndex = 631;
            this.btn_clr_all.UseVisualStyleBackColor = false;
            this.btn_clr_all.Click += new System.EventHandler(this.btn_clr_all_Click);
            // 
            // combo_unit_name
            // 
            this.combo_unit_name.DropDownHeight = 120;
            this.combo_unit_name.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_unit_name.FormattingEnabled = true;
            this.combo_unit_name.IntegralHeight = false;
            this.combo_unit_name.Location = new System.Drawing.Point(116, 67);
            this.combo_unit_name.Name = "combo_unit_name";
            this.combo_unit_name.Size = new System.Drawing.Size(291, 23);
            this.combo_unit_name.TabIndex = 103;
            this.combo_unit_name.SelectedIndexChanged += new System.EventHandler(this.combo_unit_name_SelectedIndexChanged);
            this.combo_unit_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_unit_name_KeyPress);
            // 
            // combo_emp_type
            // 
            this.combo_emp_type.DropDownHeight = 120;
            this.combo_emp_type.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_emp_type.FormattingEnabled = true;
            this.combo_emp_type.IntegralHeight = false;
            this.combo_emp_type.Location = new System.Drawing.Point(500, 68);
            this.combo_emp_type.Name = "combo_emp_type";
            this.combo_emp_type.Size = new System.Drawing.Size(265, 23);
            this.combo_emp_type.TabIndex = 104;
            this.combo_emp_type.SelectedIndexChanged += new System.EventHandler(this.combo_emp_type_SelectedIndexChanged);
            this.combo_emp_type.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_emp_type_KeyPress);
            // 
            // combo_section_name
            // 
            this.combo_section_name.DropDownHeight = 120;
            this.combo_section_name.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_section_name.FormattingEnabled = true;
            this.combo_section_name.IntegralHeight = false;
            this.combo_section_name.Location = new System.Drawing.Point(500, 94);
            this.combo_section_name.Name = "combo_section_name";
            this.combo_section_name.Size = new System.Drawing.Size(265, 23);
            this.combo_section_name.TabIndex = 105;
            this.combo_section_name.SelectedIndexChanged += new System.EventHandler(this.combo_section_name_SelectedIndexChanged);
            this.combo_section_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_section_name_KeyPress);
            // 
            // combo_department
            // 
            this.combo_department.DropDownHeight = 120;
            this.combo_department.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_department.FormattingEnabled = true;
            this.combo_department.IntegralHeight = false;
            this.combo_department.Location = new System.Drawing.Point(116, 93);
            this.combo_department.Name = "combo_department";
            this.combo_department.Size = new System.Drawing.Size(291, 23);
            this.combo_department.TabIndex = 106;
            this.combo_department.SelectedIndexChanged += new System.EventHandler(this.combo_department_SelectedIndexChanged);
            this.combo_department.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_department_KeyPress);
            // 
            // combo_line_name
            // 
            this.combo_line_name.DropDownHeight = 120;
            this.combo_line_name.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_line_name.FormattingEnabled = true;
            this.combo_line_name.IntegralHeight = false;
            this.combo_line_name.Location = new System.Drawing.Point(116, 119);
            this.combo_line_name.Name = "combo_line_name";
            this.combo_line_name.Size = new System.Drawing.Size(291, 23);
            this.combo_line_name.TabIndex = 107;
            this.combo_line_name.SelectedIndexChanged += new System.EventHandler(this.combo_line_name_SelectedIndexChanged);
            this.combo_line_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_line_name_KeyPress);
            // 
            // combo_shift
            // 
            this.combo_shift.DropDownHeight = 120;
            this.combo_shift.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_shift.FormattingEnabled = true;
            this.combo_shift.IntegralHeight = false;
            this.combo_shift.Location = new System.Drawing.Point(500, 121);
            this.combo_shift.Name = "combo_shift";
            this.combo_shift.Size = new System.Drawing.Size(265, 23);
            this.combo_shift.TabIndex = 108;
            this.combo_shift.SelectedIndexChanged += new System.EventHandler(this.combo_shift_SelectedIndexChanged);
            this.combo_shift.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_shift_KeyPress);
            // 
            // comBoxDesig
            // 
            this.comBoxDesig.DropDownHeight = 120;
            this.comBoxDesig.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxDesig.FormattingEnabled = true;
            this.comBoxDesig.IntegralHeight = false;
            this.comBoxDesig.Location = new System.Drawing.Point(116, 145);
            this.comBoxDesig.Name = "comBoxDesig";
            this.comBoxDesig.Size = new System.Drawing.Size(291, 23);
            this.comBoxDesig.TabIndex = 116;
            this.comBoxDesig.SelectedIndexChanged += new System.EventHandler(this.comBoxDesig_SelectedIndexChanged);
            this.comBoxDesig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comBoxDesig_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label12.Location = new System.Drawing.Point(28, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 16);
            this.label12.TabIndex = 117;
            this.label12.Text = "Designation";
            // 
            // btnExitUserControl
            // 
            this.btnExitUserControl.BackColor = System.Drawing.SystemColors.Window;
            this.btnExitUserControl.BackgroundImage = global::NGPayroll.Properties.Resources.Close;
            this.btnExitUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExitUserControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitUserControl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitUserControl.Location = new System.Drawing.Point(582, 568);
            this.btnExitUserControl.Name = "btnExitUserControl";
            this.btnExitUserControl.Size = new System.Drawing.Size(90, 32);
            this.btnExitUserControl.TabIndex = 112;
            this.btnExitUserControl.Text = "Exit";
            this.btnExitUserControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExitUserControl.UseVisualStyleBackColor = false;
            this.btnExitUserControl.Click += new System.EventHandler(this.btnExitUserControl_Click);
            // 
            // btn_clear_allData
            // 
            this.btn_clear_allData.BackColor = System.Drawing.SystemColors.Window;
            this.btn_clear_allData.BackgroundImage = global::NGPayroll.Properties.Resources.clear;
            this.btn_clear_allData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_clear_allData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear_allData.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear_allData.Location = new System.Drawing.Point(499, 568);
            this.btn_clear_allData.Name = "btn_clear_allData";
            this.btn_clear_allData.Size = new System.Drawing.Size(84, 32);
            this.btn_clear_allData.TabIndex = 98;
            this.btn_clear_allData.Text = "Clear";
            this.btn_clear_allData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clear_allData.UseVisualStyleBackColor = false;
            this.btn_clear_allData.Click += new System.EventHandler(this.btn_clear_allData_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Window;
            this.btnUpdate.BackgroundImage = global::NGPayroll.Properties.Resources.upload_folder4;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdate.Location = new System.Drawing.Point(403, 568);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 32);
            this.btnUpdate.TabIndex = 97;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.BackgroundImage = global::NGPayroll.Properties.Resources.upload_folder4;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(300, 568);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 32);
            this.button1.TabIndex = 118;
            this.button1.Text = "Update";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Attendance_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comBoxDesig);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbl_emp_name);
            this.Controls.Add(this.btnExitUserControl);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.combo_shift);
            this.Controls.Add(this.combo_line_name);
            this.Controls.Add(this.combo_department);
            this.Controls.Add(this.combo_section_name);
            this.Controls.Add(this.combo_emp_type);
            this.Controls.Add(this.combo_unit_name);
            this.Controls.Add(this.btn_clear_allData);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txt_line_id);
            this.Controls.Add(this.dgvAttd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_shift_id);
            this.Controls.Add(this.txt_section_id);
            this.Controls.Add(this.txt_emp_type);
            this.Controls.Add(this.txt_dept_id);
            this.Controls.Add(this.txt_unit_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPassword);
            this.DoubleBuffered = true;
            this.Name = "Attendance_Details";
            this.helpProvider1.SetShowHelp(this, true);
            this.Size = new System.Drawing.Size(1087, 622);
            this.Load += new System.EventHandler(this.attendance_details_UC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttd)).EndInit();
            this.cmsAttDetails.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAttSearch;
        private System.Windows.Forms.CheckBox chk_dt;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAttd;
        private System.Windows.Forms.Button btn_clear_allData;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip cmsAttDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveData;
        private System.Windows.Forms.ToolStripMenuItem tsmNight;
        private System.Windows.Forms.ToolStripMenuItem tsmWeekend;
        private System.Windows.Forms.ToolStripMenuItem tsmInTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetOnMissingInTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiResetInTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshInTime;
        private System.Windows.Forms.ToolStripMenuItem tsmOutTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetOnMissingOut;
        private System.Windows.Forms.ToolStripMenuItem tsmiResetOutTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshOutTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiOutTimeByOT;
        private System.Windows.Forms.ToolStripMenuItem tsmSetInAndOutTime;
        private System.Windows.Forms.ToolStripMenuItem tsmOverTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetOverTime;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveOTHours;
        private System.Windows.Forms.ToolStripMenuItem tsmShiftManupulation;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeShift;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshShift;
        private System.Windows.Forms.ToolStripMenuItem tsmiLockData;
        private System.Windows.Forms.ToolStripMenuItem tsmiUnlockData;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteData;
        private System.Windows.Forms.ToolStripMenuItem tsmiLockByDate;
        private System.Windows.Forms.ToolStripMenuItem tsmiUnlockByDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem nightYesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nightNoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmpInfo;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label lbl_emp_name;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportDataToExcel;
        private System.Windows.Forms.Button btnExitUserControl;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmOnStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetOnStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetOnStatus2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSearchFromData;
        private System.Windows.Forms.ToolStripMenuItem tsmHoliday;
        private System.Windows.Forms.ToolStripMenuItem tsmLeave;
        private System.Windows.Forms.ToolStripMenuItem tsmiLeaveLWP;
        private System.Windows.Forms.ToolStripMenuItem tsmiLeaveCPL;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaternityLeave;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txt_unit_id;
        private System.Windows.Forms.TextBox txt_dept_id;
        private System.Windows.Forms.TextBox txt_emp_type;
        private System.Windows.Forms.TextBox txt_section_id;
        private System.Windows.Forms.TextBox txt_shift_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_line_id;
        private System.Windows.Forms.DateTimePicker dTp_nextDay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_emp_code;
        private System.Windows.Forms.Button btn_clr_all;
        private System.Windows.Forms.Button btn_clr;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ListBox LB_attendance_details;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox combo_unit_name;
        private System.Windows.Forms.ComboBox combo_emp_type;
        private System.Windows.Forms.ComboBox combo_section_name;
        private System.Windows.Forms.ComboBox combo_department;
        private System.Windows.Forms.ComboBox combo_line_name;
        private System.Windows.Forms.ComboBox combo_shift;
        private System.Windows.Forms.ToolStripMenuItem tsmiAutoLeave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetWeekend;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshWeekend;
        private System.Windows.Forms.ToolStripMenuItem tsmiRetriveAttendance;
        private System.Windows.Forms.ComboBox comBoxDesig;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem tsmiLeaveUnlock;
        private System.Windows.Forms.DataGridViewTextBoxColumn attDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn empCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn empName;
        private System.Windows.Forms.DataGridViewTextBoxColumn inTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn late;
        private System.Windows.Forms.DataGridViewTextBoxColumn workHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn outTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn overTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn night;
        private System.Windows.Forms.DataGridViewTextBoxColumn status2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMP_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn rFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn nightFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn inFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn outFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftName;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_OT_HOLDER;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_IN_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_OUT_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATTD_LOCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn EARLY_OUT;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetHoliday;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshHoliday;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetOnMissingInOut;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetOnResetInOut;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshInOut;
        private System.Windows.Forms.ToolStripMenuItem tsmAttdManupulation;
        private System.Windows.Forms.Button btnSearchData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLayOff;
        private System.Windows.Forms.ToolStripMenuItem tsmiLOW;
        private System.Windows.Forms.ToolStripMenuItem tsmiGL;
        private System.Windows.Forms.ToolStripMenuItem tsmiLeave;
    }
}
