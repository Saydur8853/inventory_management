using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;

namespace NGPayroll
{
    public partial class Attendance_Details : UserControl
    {
        public string attdEmpCode;
        public UserControl lastUserControlAttd;
        public int getExitForLastUserControlAttd = 0;
        List<int> srcUnit = new List<int>();
        List<int> srcEmpType = new List<int>();
        List<int> srcDept = new List<int>();
        List<int> srcSec = new List<int>();
        List<int> srcLine = new List<int>();
        List<int> srcShift = new List<int>();
        List<int> srcDesig = new List<int>();
        
        #region  ===================== Emp_code from emp_info =======================================
        public void getDisplayAttDetails(string strSubQuery)
        {
            int EID, SID, isIN, isOut;
            DBClass db = new DBClass();
            dgvAttd.Rows.Clear();
            string strQuery, empCode, empName, attDate, inTime, strLate, workHour, outTime, overTime, strStatus, nightStatus, strStatus2, shiftName, attdRemarks, strEarlyOut, strOTHolder, attLock, strSql = "";
            strQuery = @"SELECT ATTD_DATE AS ATTEN_DATE,A.EMP_CODE,A.EMP_NAME,C.IN_TIME, NVL(C.LATE,0) LATE,NVL(ROUND((C.OUT_TIME - C.IN_TIME)*24,0),0) WORKING_HOUR,C.OUT_TIME,NVL(C.OVER_TIME,0) OVER_TIME,C.STATUS,NVL(C.NIGHT_STATUS,'N') NIGHT_STATUS,
                       C.STATUS2,A.EMP_ID,SF.SHIFT_NAME,C.SHIFT_ID,C.ATTD_REMARKS,NVL(IS_IN_TIME_MANUAL,0) IS_IN_TIME,NVL(IS_OUT_TIME_MANUAL,0) IS_OUT_TIME,NVL(C.EARLY_OUT,0) EARLY_OUT,NVL(A.OVER_TIME,'N') IS_OT_HOLDER,NVL(ATTD_LOCKED,'N') ATTD_LOCKED
                    FROM EMP_OFFICIAL A, ATTENDANCE_DETAILS C, SHIFT_INFO SF WHERE A.EMP_ID=C.EMP_ID AND C.SHIFT_ID=SF.SHIFT_ID " + strSubQuery + " ORDER BY ATTD_DATE DESC, A.EMP_CODE";
            
            DataSet dS = db.GetDataSet(strQuery);
            if (dS.Tables[0].Rows.Count > 0)
            {
                int rDx = dgvAttd.Rows.Count;
                foreach (DataRow dr in dS.Tables[0].Rows)
                {
                    empCode = dr[1].ToString();
                    empName = dr[2].ToString();
                    strLate = dr[4].ToString();
                    attLock = dr[19].ToString();
                    workHour = dr[5].ToString();
                    overTime = dr[7].ToString();
                    strStatus = dr[8].ToString();
                    nightStatus = dr[9].ToString();
                    strStatus2 = dr[10].ToString();
                    shiftName = dr[12].ToString();
                    SID = Convert.ToInt32(dr[13]);
                    EID = Convert.ToInt32(dr[11]);
                    isIN = Convert.ToInt32(dr[15]);
                    isOut = Convert.ToInt32(dr[16]);
                    attdRemarks = dr[14].ToString();
                    strEarlyOut = dr[17].ToString();
                    strOTHolder = dr[18].ToString();
                    if (dr[3].ToString() == "") inTime = dr[3].ToString();
                    else inTime = Convert.ToDateTime(dr[3].ToString()).ToString("HH:mm:ss");
                    if (dr[6].ToString() == "") outTime = dr[6].ToString();
                    else outTime = Convert.ToDateTime(dr[6].ToString()).ToString("HH:mm:ss");
                    attDate = Convert.ToDateTime(dr[0].ToString()).ToString("dd-MMM-yyyy");

                    dgvAttd.Rows.Add(attDate, empCode, empName, inTime, strLate, workHour, outTime, overTime, strStatus, nightStatus, strStatus2, EID, null, null, null, null, shiftName, SID, attdRemarks, strOTHolder, isIN, isOut, attLock);
                    if (attLock == "Y") dgvAttd.Rows[rDx].DefaultCellStyle.BackColor = Color.Red;
                    if (strStatus == "A") dgvAttd.Rows[rDx].DefaultCellStyle.ForeColor = Color.Red;
                    if (strStatus == "W") dgvAttd.Rows[rDx].DefaultCellStyle.ForeColor = Color.Orange;
                    if (strStatus == "H") dgvAttd.Rows[rDx].DefaultCellStyle.ForeColor = Color.DarkViolet;
                    if (strStatus == "L") dgvAttd.Rows[rDx].DefaultCellStyle.BackColor = Color.GreenYellow;
                    if (attdRemarks == "Auto_Leave") dgvAttd.Rows[rDx].DefaultCellStyle.BackColor = Color.LightPink;
                    rDx++;
                }    // end while (dr.Read())   
            }    // end if (dr.HasRows)   Cells["overTime"].Value
            btnUpdate.Enabled = true;
            tsmiSaveData.Enabled = true;
            // ============================= this query count attd(A/P/L/W/Y) =============================
            List<string> oList = new List<string>();
            foreach (DataGridViewRow Dr in dgvAttd.Rows)
            {
                if (Dr.Cells["status"].Value == null) break;
                oList.Add(Dr.Cells["status"].Value.ToString());
            }
            List<string> A = oList.FindAll(FindA);
            List<string> P = oList.FindAll(FindP);
            List<string> L = oList.FindAll(FindL);
            List<string> W = oList.FindAll(FindW);
            List<string> H = oList.FindAll(FindH);

            List<string> nList = new List<string>();
            foreach (DataGridViewRow Dr in dgvAttd.Rows)
            {
                if (Dr.Cells["night"].Value == null) break;
                nList.Add(Dr.Cells["night"].Value.ToString());
            }
            List<string> Y = nList.FindAll(FindY);
            double dblOTHr = 0;
            strSql = "SELECT NVL(SUM(C.OVER_TIME),0) OVER_TIME FROM EMP_OFFICIAL A, ATTENDANCE_DETAILS C, SHIFT_INFO SF WHERE A.EMP_ID=C.EMP_ID AND C.SHIFT_ID=SF.SHIFT_ID " + strSubQuery;
            DataSet ds = db.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dblOTHr = Convert.ToDouble(ds.Tables[0].Rows[0]["OVER_TIME"]);
            }
            label13.Text = "A: " + A.Count + ", P: " + P.Count + ", L: " + L.Count + ", W: " + W.Count + ", H: " + H.Count + ", N: " + Y.Count + ", OT: " + dblOTHr.ToString();
            label9.Text = "Total: " + (dgvAttd.Rows.Count);
        }// End of public void code_emp_info_Show()
        #endregion

        #region  ===================== Attendance_details_UC() and combo function ===================
        public Attendance_Details()
        {
            InitializeComponent();
            func_combo_unit();
            func_combo_line();
            func_combo_shift();
            func_comBoxDesig();
            func_combo_section();
            func_combo_emp_type();
            func_combo_department();
            dgvAttd.Rows.ToString().ToUpper();
        }
        private bool Isnumber(string p)
        {
            foreach (char a in p)
            {
                if (a >= '0' && a <= '9') return true;
                else return false;
            }
            return true;
        }
        private int inManual(int intEID, string attDate)
        {
            int inManual = 0;
            DBClass db = new DBClass();
            string strSql = "SELECT IN_TIME FROM ATTENDANCE_DETAILS WHERE EMP_ID = '" + intEID + "' AND ATTD_DATE ='" + attDate + "'";
            OracleDataReader dr = db.GetExecuteReader(strSql);
            if (dr.Read()) if (dr["IN_TIME"] == DBNull.Value) inManual = 1;
            return inManual;
        }
        private int outManual(int intEID, string attDate)
        {
            int outManual = 0;
            DBClass db = new DBClass();
            string strSql = "SELECT OUT_TIME FROM ATTENDANCE_DETAILS WHERE EMP_ID = '" + intEID + "' AND ATTD_DATE ='" + attDate + "'";
            OracleDataReader dr = db.GetExecuteReader(strSql);
            if (dr.Read()) if (dr["OUT_TIME"] == DBNull.Value) outManual = 1;
            return outManual;
        }
        void func_combo_unit()
        {
            DBClass db = new DBClass();
            string query = "SELECT UNIT_ID, UNIT_NAME FROM UNIT ORDER BY UNIT_NAME";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));
                string key = dr.GetString(1);
                combo_unit_name.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            combo_unit_name.DisplayMember = "Key";
            combo_unit_name.ValueMember = "Value"; 
        }
        void func_combo_emp_type()
        {
            DBClass db = new DBClass();
            string query = "SELECT EMP_CATEGORY_ID, EMP_CATEGORY_NAME FROM EMP_CATEGORY ORDER BY EMP_CATEGORY_NAME";
            DataSet ds = db.GetDataSet(query);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int value = Convert.ToInt32(dr[0].ToString());
                string key = dr[1].ToString();
                combo_emp_type.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            combo_emp_type.DisplayMember = "Key";
            combo_emp_type.ValueMember = "Value";
        }
        void func_combo_department()
        {
            DBClass db = new DBClass();
            string sql = "SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM DEPARTMENT ORDER BY DEPARTMENT_NAME";
            DataSet ds = db.GetDataSet(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int value = Convert.ToInt32(dr[0].ToString());
                string key = dr[1].ToString();
                combo_department.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            combo_department.DisplayMember = "Key";
            combo_department.ValueMember = "Value";
        }
        void func_combo_section()
        {
            DBClass db = new DBClass();
            string query = "SELECT SECTION_ID, SECTION_NAME FROM SECTION ORDER BY SECTION_NAME";
            DataSet ds = db.GetDataSet(query);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int value = Convert.ToInt32(dr[0].ToString());
                string key = dr[1].ToString();
                combo_section_name.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            combo_section_name.DisplayMember = "Key";
            combo_section_name.ValueMember = "Value";
        }
        void func_combo_line()
        {
            DBClass db = new DBClass();
            string query = "SELECT LINE_ID, LINE_NAME FROM LINE ORDER BY LINE_NAME";
            DataSet ds = db.GetDataSet(query);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int value = Convert.ToInt32(dr[0].ToString());
                string key = dr[1].ToString();
                combo_line_name.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            combo_line_name.DisplayMember = "Key";
            combo_line_name.ValueMember = "Value";
        }
        void func_combo_shift()
        {
            DBClass db = new DBClass();
            string query = "SELECT SHIFT_ID, SHIFT_NAME FROM SHIFT_INFO ORDER BY SHIFT_NAME";
            DataSet ds = db.GetDataSet(query);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int value = Convert.ToInt32(dr[0]);
                string key = dr[1].ToString();
                combo_shift.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            combo_shift.DisplayMember = "Key";
            combo_shift.ValueMember = "Value";
        }
        void func_comBoxDesig()
        {
            DBClass db = new DBClass();
            string query = "SELECT DESIGNATION_ID, DESIGNATION_NAME FROM DESIGNATION ORDER BY DESIGNATION_NAME";
            DataSet ds = db.GetDataSet(query);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int value = Convert.ToInt32(dr[0]);
                string key = dr[1].ToString();
                comBoxDesig.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            comBoxDesig.DisplayMember = "Key";
            comBoxDesig.ValueMember = "Value";
        }
        private void combo_unit_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_unit_name.SelectedItem;
            combo_unit_name.Tag = selectedItemVal.Value;
            combo_unit_name.Text = selectedItemVal.Key;
            if (combo_unit_name.Text.Trim().Length < 1) combo_unit_name.SelectedIndex = -1;
        }
        private void combo_unit_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DBClass db = new DBClass();
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_unit_name.SelectedItem;
                combo_unit_name.Tag = selectedItemVal.Value;
                combo_unit_name.Text = selectedItemVal.Key;
                string sql = "select *from unit where unit_id='" + combo_unit_name.Tag + "'";
                DataSet ds = db.GetDataSet(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txt_unit_id.Text = dr["unit_id"].ToString();
                }
            }
            if (combo_unit_name.Text.Length == 0) txt_unit_id.Text = "";
        }
        private void UploadTextFile()
        {
            string FilePath;
            DBClass DB = new DBClass();
            string code = txt_emp_code.Text;
            OpenFileDialog emp_code_dialog = new OpenFileDialog();
            emp_code_dialog.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            emp_code_dialog.Filter = "Text only. |*.TXT;";
            if (emp_code_dialog.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Are You Sure To Upload Employee List From TXT File (" + emp_code_dialog.FileName + ")", "Upload .TXT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FilePath = emp_code_dialog.FileName;
                    string[] lines = File.ReadAllLines(FilePath);
                    foreach (string line in lines)
                    {
                        // Use a tab to indent each line of the file.
                        LB_attendance_details.Items.Add(line);
                    }
                }
            }
        }
        private void combo_emp_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_emp_type.SelectedItem;
            combo_emp_type.Tag = selectedItemVal.Value;
            combo_emp_type.Text = selectedItemVal.Key;
            if (combo_emp_type.Text.Trim().Length < 1) combo_emp_type.SelectedIndex = -1;
        }
        private void combo_emp_type_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DBClass db = new DBClass();
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_emp_type.SelectedItem;
                combo_emp_type.Tag = selectedItemVal.Value;
                combo_emp_type.Text = selectedItemVal.Key;
                string sql = "select *from emp_category where emp_category_id='" + combo_emp_type.Tag + "'";
                DataSet ds = db.GetDataSet(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txt_emp_type.Text = dr["emp_category_id"].ToString();
                }
            }
            if (combo_emp_type.Text.Length == 0) txt_emp_type.Text = "";
        }
        private void combo_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_department.SelectedItem;
            combo_department.Tag = selectedItemVal.Value;
            combo_department.Text = selectedItemVal.Key;
            if (combo_department.Text.Trim().Length < 1) combo_department.SelectedIndex = -1;
        }
        private void combo_department_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DBClass db = new DBClass();
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_department.SelectedItem;
                combo_department.Tag = selectedItemVal.Value;
                combo_department.Text = selectedItemVal.Key;
                string sql = "select *from department where department_id='" + combo_department.Tag + "'";
                DataSet ds = db.GetDataSet(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txt_dept_id.Text = dr["department_id"].ToString();
                }
            }
            if (combo_department.Text.Length == 0) txt_dept_id.Text = "";
        }
        private void combo_section_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_section_name.SelectedItem;
            combo_section_name.Tag = selectedItemVal.Value;
            combo_section_name.Text = selectedItemVal.Key;
            if (combo_section_name.Text.Trim().Length < 1) combo_section_name.SelectedIndex = -1;
        }
        private void combo_section_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DBClass db = new DBClass();
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_section_name.SelectedItem;
                combo_section_name.Tag = selectedItemVal.Value;
                combo_section_name.Text = selectedItemVal.Key;
                string sql = "select *from section where section_id='" + combo_section_name.Tag + "'";
                DataSet ds = db.GetDataSet(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txt_section_id.Text = dr["section_id"].ToString();
                }
            }
            if (combo_section_name.Text.Length == 0) txt_section_id.Text = "";
        }
        private void combo_line_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_line_name.SelectedItem;
            combo_line_name.Tag = selectedItemVal.Value;
            combo_line_name.Text = selectedItemVal.Key;
            if (combo_line_name.Text.Trim().Length < 1) combo_line_name.SelectedIndex = -1;
        }
        private void combo_line_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DBClass db = new DBClass();
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_line_name.SelectedItem;
                combo_line_name.Tag = selectedItemVal.Value;
                combo_line_name.Text = selectedItemVal.Key;
                string sql = "select *from line where line_id='" + combo_line_name.Tag + "'";
                DataSet ds = db.GetDataSet(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txt_line_id.Text = dr["line_id"].ToString();
                }
            }
            if (combo_line_name.Text.Length == 0) txt_line_id.Text = "";
        }
        private void combo_shift_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_shift.SelectedItem;
            combo_shift.Tag = selectedItemVal.Value;
            combo_shift.Text = selectedItemVal.Key;
            if (combo_shift.Text.Trim().Length < 1) combo_shift.SelectedIndex = -1;
        }
        private void combo_shift_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DBClass db = new DBClass();
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_shift.SelectedItem;
                combo_shift.Tag = selectedItemVal.Value;
                combo_shift.Text = selectedItemVal.Key;
                string sql = "select *from shift_info where shift_id='" + combo_shift.Tag + "'";                
                DataSet ds = db.GetDataSet(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txt_shift_id.Text = dr["shift_id"].ToString();
                }
            }
            if (combo_shift.Text.Length == 0) txt_shift_id.Text = "";
        }
        private void comBoxDesig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> sItems = (KeyValuePair<string, int>)comBoxDesig.SelectedItem;
                comBoxDesig.Tag = sItems.Value;
                comBoxDesig.Text = sItems.Key;
            }
        }
        private void comBoxDesig_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> sItems = (KeyValuePair<string, int>)comBoxDesig.SelectedItem;
            comBoxDesig.Tag = sItems.Value;
            comBoxDesig.Text = sItems.Key;
            if (comBoxDesig.Text.Trim().Length < 1) comBoxDesig.SelectedIndex = -1;
        }
        private void btn_clear_allData_Click(object sender, EventArgs e)
        {
            dgvAttd.Rows.Clear();
            CConfig.getClrData(this);
        }
        private void dgvAttDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)     // for upper case
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }
        #endregion

        #region  ===================== Attendance_details_UC_Load ===================================
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (this.txt_emp_code.Text != "")
            {
                LB_attendance_details.Items.Add(this.txt_emp_code.Text);
                this.txt_emp_code.Focus();
                this.txt_emp_code.Clear();
            }
        }
        private void btn_clr_Click(object sender, EventArgs e)
        {
            if (this.LB_attendance_details.SelectedIndex != -1)
            {
                this.LB_attendance_details.Items.RemoveAt(this.LB_attendance_details.SelectedIndex);
                this.btn_clr.Enabled = false;
                this.txt_emp_code.Focus();
            }
        }
        private void btn_clr_all_Click(object sender, EventArgs e)
        {
            if (this.LB_attendance_details.Items.Count > 0)
            {
                if (MessageBox.Show("Do you want to Clear All Data ", "Clear All Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.LB_attendance_details.Items.Clear();
                    this.txt_emp_code.Focus();
                }
            }
        }
        private void getMaternityStatus()
        {
            DBClass db = new DBClass();
            string strSql, strEmpName = "";
            strSql = "SELECT EMP_ID,EMP_NAME||' ('||EMP_CODE||')' EMP_CODE,CLOSE_DATE FROM EMP_OFFICIAL WHERE EMP_STATUS='Maternity'";
            DataSet ds = db.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32((DateTime.Now.Date - Convert.ToDateTime(ds.Tables[0].Rows[i]["CLOSE_DATE"].ToString())).TotalDays) >= 112)
                    {
                        strEmpName += "\n" + ds.Tables[0].Rows[i]["EMP_CODE"].ToString();
                        strSql = "UPDATE EMP_OFFICIAL SET EMP_STATUS='Active',CLOSE_DATE='',USER_ID='" + ConfigurationManager.AppSettings["UserID"] + "',EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM') WHERE EMP_ID='" + ds.Tables[0].Rows[i]["EMP_ID"] + "'";
                        db.RunDmlQuery(strSql);
                    }
                }
                if (strEmpName != "") MessageBox.Show("List Of Employee Active From Maternity Leave: " + strEmpName, "Maternity Leave");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tsmiSaveData_Click(sender, e);
        }
        private void dgvAttDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgvAttd.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
        }
        private void attendance_details_UC_Load(object sender, EventArgs e)
        {
            getMaternityStatus();
            dtpStart.Value = DateTime.Now.Date;
        }
        private void txt_emp_code_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) UploadTextFile();
            else if (e.KeyCode == Keys.Enter)
            {
                DBClass db = new DBClass();
                if (txt_emp_code.Text != "")
                {
                    string sql = @"select emp_name from emp_official where emp_code='" + txt_emp_code.Text + "'";
                    DataSet ds = db.GetDataSet(sql);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        lbl_emp_name.Text = dr["emp_name"].ToString();
                        LB_attendance_details.Items.Add(txt_emp_code.Text);
                        txt_emp_code.Clear();
                        txt_emp_code.Focus();
                    }
                }
            }
        } // END OF private void txt_emp_code_KeyUp(object sender, KeyEventArgs e)
        private void LB_attendance_details_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearchFromData.Focus();
        }
        private void btnExitUserControl_Click(object sender, EventArgs e)
        {
            payroll_main_form mForm = this.ParentForm as payroll_main_form;
            mForm.splitContainer1.Panel2.Controls.Clear();
            if (getExitForLastUserControlAttd == 1)
            {
                mForm.splitContainer1.Panel2.Controls.Add(lastUserControlAttd);
                lastUserControlAttd.Show();
            }
            else
            {
                ucDashboard objDashBoard = new ucDashboard();
                mForm.splitContainer1.Panel2.Controls.Add(objDashBoard);
                objDashBoard.Show();
            }
        }
        #endregion

        #region ===================== Attendance Search By Function Key ============================
        private void txtAttSearch_KeyDown(object sender, KeyEventArgs e)
        {          
            /*    
            strQuery = @"select c.attd_date atten_date, a.emp_code, a.emp_name, c.in_time, c.late, nvl(round((c.out_time - c.in_time)*24)-1,0) as working_hour,
                            c.out_time, c.over_time, c.status, c.night_status, c.status2,a.emp_id,sf.shift_name,c.shift_id,c.ATTD_REMARKS,c.IS_IN_TIME_MANUAL,c.IS_OUT_TIME_MANUAL
                        from emp_official a,attendance_details c, shift_info sf
                        where a.emp_id=c.emp_id and c.shift_id=sf.shift_id" + subQuery + " order by atten_date desc";
            DataSet Ds = db.get_data_set(strQuery);
            if (Ds.Tables[0].Rows.Count>0)
            {
                dgvAttDetails.Rows.Clear();
                int rDx = dgvAttDetails.Rows.Count;
                foreach (DataRow dr in Ds.Tables[0].Rows)
                {
                    emp_attd_date = Convert.ToDateTime(dr[0].ToString()).ToString("dd-MMM-yyyy");
                    emp_code = dr[1].ToString();
                    emp_name = dr[2].ToString();
                    if (dr[3].ToString() == "") emp_intime = dr[3].ToString();
                    else emp_intime = Convert.ToDateTime(dr[3].ToString()).ToString("HH:mm:ss");
                    emp_late = dr[4].ToString();
                    emp_working_hour = dr[5].ToString();
                    if (dr[6].ToString() == "") emp_outtime = dr[6].ToString();
                    else emp_outtime = Convert.ToDateTime(dr[6].ToString()).ToString("HH:mm:ss");
                    emp_overtime = dr[7].ToString();
                    emp_status = dr[8].ToString();
                    emp_night_status = dr[9].ToString();
                    emp_status2 = dr[10].ToString();
                    emp_id = Convert.ToInt32(dr[11]);
                    shift_name = dr[12].ToString();
                    shift_id = Convert.ToInt32(dr[13]);
                    attd_remarks = dr[14].ToString();
                    isintime = Convert.ToInt32(dr[15]);
                    isouttime = Convert.ToInt32(dr[16]);
                    dgvAttDetails.Rows.Add(emp_attd_date, emp_code, emp_name, emp_intime, emp_late, emp_working_hour, emp_outtime, emp_overtime, emp_status, emp_night_status, emp_status2, emp_id, null, null, null, null, shift_name, shift_id, attd_remarks, null, isintime, isouttime);
                    if (emp_status == "A") dgvAttDetails.Rows[rDx].DefaultCellStyle.ForeColor = Color.Red;
                    if (emp_status == "W") dgvAttDetails.Rows[rDx].DefaultCellStyle.ForeColor = Color.Orange;
                    if (emp_status == "H") dgvAttDetails.Rows[rDx].DefaultCellStyle.ForeColor = Color.DarkViolet;
                    if (emp_status == "L") dgvAttDetails.Rows[rDx].DefaultCellStyle.BackColor = Color.GreenYellow;
                    rDx++;
                }    // end while (dr.Read())   
            }    // end if (dr.HasRows)

            label9.Text = "Total: " + (dgvAttDetails.Rows.Count);
            btnUpdate.Enabled = true;
                
            // ============================= this query count attd(A/P/L/W/Y) =============================
            List<string> oList=new List<string>();
            foreach(DataGridViewRow Dr in dgvAttDetails.Rows)
            {
                if (Dr.Cells["status"].Value == null) break; 
                oList.Add(Dr.Cells["status"].Value.ToString());
            }
            List<string> A = oList.FindAll(FindA);
            List<string> P = oList.FindAll(FindP);
            List<string> L = oList.FindAll(FindL);
            List<string> W = oList.FindAll(FindW);
            List<string> H = oList.FindAll(FindH);
                
            List<string> nList = new List<string>();
            foreach (DataGridViewRow dr in dgvAttDetails.Rows)
            {
                if (dr.Cells["night"].Value == null) break;
                nList.Add(dr.Cells["night"].Value.ToString());
            }
            List<string> Y = nList.FindAll(FindY);

            label13.Text = "A: " + A.Count + ", P: " + P.Count + ", L: " + L.Count + ", W: " + W.Count + ", H: " + H.Count + ", N: " + Y.Count;
*/         
        }
        #endregion

        #region ===================== This Function count attd(A/P/L/W/Y) ==========================

        private static bool FindA(string bk)
        {
            return bk == "A";
        }
        private static bool FindP(string bk)
        {
            return bk == "P";
        }
        private static bool FindL(string bk)
        {
            return bk == "L";
        }
        private static bool FindW(string bk)
        {
            return bk == "W";
        }
        private static bool FindH(string bk)
        {
            return bk == "H";
        }
        private static bool FindY(string bk)
        {
            return bk == "Y";
        }
        #endregion

        #region ===================== ToolStripMenuItem ============================================
        private void cmsEnable()
        {
            if (dgvAttd.SelectedRows.Count > 0)
            {
                tsmLeave.Enabled = true;
                tsmNight.Enabled = true;
                tsmInTime.Enabled = true;
                tsmHoliday.Enabled = true;
                tsmWeekend.Enabled = true;
                tsmOutTime.Enabled = true;
                tsmOverTime.Enabled = true;
                tsmiEmpInfo.Enabled = true;
                tsmOnStatus.Enabled = true;
                tsmiSaveData.Enabled = true;
                tsmiLockData.Enabled = true;
                tsmiUnlockData.Enabled = true;
                tsmiDeleteData.Enabled = true;
                tsmiLeaveUnlock.Enabled = true;
                tsmSetInAndOutTime.Enabled = true;
                tsmShiftManupulation.Enabled = true;
                tsmiRetriveAttendance.Enabled = true;
                return;
            }
            else
            {                
                tsmLeave.Enabled = false;
                tsmNight.Enabled = false;
                tsmInTime.Enabled = false;
                tsmHoliday.Enabled = false;
                tsmWeekend.Enabled = false;
                tsmOutTime.Enabled = false;
                tsmOverTime.Enabled = false;
                tsmiEmpInfo.Enabled = false;
                tsmOnStatus.Enabled = false;
                tsmiSaveData.Enabled = false;
                tsmiLockData.Enabled = false;
                tsmiUnlockData.Enabled = false;
                tsmiDeleteData.Enabled = false;
                tsmiLeaveUnlock.Enabled = false;
                tsmSetInAndOutTime.Enabled = false;
                tsmShiftManupulation.Enabled = false;
                tsmiRetriveAttendance.Enabled = false;
                return;
            }
        }
        private void cmsAttDetails_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAttd.RowCount > 0)
            {
                tsmLeave.Visible = true;
                tsmNight.Visible = true;
                tsmInTime.Visible = true;
                tsmHoliday.Visible = true;
                tsmWeekend.Visible = true;
                tsmOutTime.Visible = true;
                tsmOverTime.Visible = true;
                tsmiEmpInfo.Visible = true;
                tsmOnStatus.Visible = true;
                tsmiRefresh.Visible = true;
                tsmiRefresh.Enabled = true;
                tsmiSaveData.Visible = true;
                tsmSetInAndOutTime.Visible = true;
                tsmAttdManupulation.Visible = true;
                tsmAttdManupulation.Enabled = true;
                tsmShiftManupulation.Visible = true;
                tsmiExportDataToExcel.Visible = true;
                tsmiExportDataToExcel.Enabled = true;
                cmsEnable();
                return;
            }
            else
            {
                tsmLeave.Visible = false;
                tsmNight.Visible = false;
                tsmInTime.Visible = false;
                tsmHoliday.Visible = false;
                tsmWeekend.Visible = false;
                tsmOutTime.Visible = false;
                tsmOverTime.Visible = false;
                tsmiEmpInfo.Visible = false;
                tsmOnStatus.Visible = false;
                tsmiRefresh.Visible = false;
                tsmiSaveData.Visible = false;
                tsmSetInAndOutTime.Visible = false;
                tsmAttdManupulation.Visible = false;
                tsmShiftManupulation.Visible = false;
                tsmiExportDataToExcel.Visible = false;
                return;
            }
        }
        private void tsmiChangeShift_Click(object sender, EventArgs e)
        {
            string strShift = combo_shift.Text.Trim();
            int iShift = Convert.ToInt32(combo_shift.Tag);
            if (iShift > 0 && strShift.Trim().Length > 0)
            {
                foreach (DataGridViewRow row in dgvAttd.SelectedRows)
                {
                    row.Cells["rFlag"].Value = "U";
                    row.Cells["shift_id"].Value = iShift;
                    row.Cells["shiftName"].Value = strShift;
                }
            }
            else MessageBox.Show("Select Shift Name");
        }
        private int GetShiftPlan(string date, int emp_id)
        {
            int result = 0;
            DBClass db = new DBClass();
            string strQuery = "SELECT DAILY_SHIFT_ALLOCATION.SHIFT_ID AS SFTID FROM EMP_OFFICIAL,DAILY_SHIFT_ALLOCATION WHERE EMP_OFFICIAL.EMP_ID =DAILY_SHIFT_ALLOCATION.EMP_ID AND SHIFT_DATE= '" + date + "' AND EMP_OFFICIAL.EMP_ID='" + emp_id + "'";
            DataSet ds = db.GetDataSet(strQuery);
            if (ds.Tables[0].Rows.Count > 0) result = Convert.ToInt32(ds.Tables[0].Rows[0]["SFTID"]);
            else
            {
                strQuery = "SELECT GROUP_SHIFT_ALLOCATION.SHIFT_ID AS SFTID FROM EMP_OFFICIAL,LINE,GROUP_SHIFT_ALLOCATION WHERE EMP_OFFICIAL.LINE_ID=LINE.LINE_ID  AND  GROUP_SHIFT_ALLOCATION.LINE_ID=LINE.LINE_ID  AND  GROUP_SHIFT_ALLOCATION.LINE_ID=EMP_OFFICIAL.LINE_ID AND DATE_OF_JOINING<= '" + date + "' AND '" + date + "' BETWEEN FROM_DATE AND TO_DATE AND EMP_OFFICIAL.EMP_ID ='" + emp_id + "'";
                ds = db.GetDataSet(strQuery);
                if (ds.Tables[0].Rows.Count > 0) result = Convert.ToInt32(ds.Tables[0].Rows[0]["SFTID"]);
                else
                {
                    strQuery = "SELECT EMP_OFFICIAL.SHIFT_ID AS SFTID FROM EMP_OFFICIAL WHERE EMP_OFFICIAL.EMP_ID ='" + emp_id + "'";
                    ds = db.GetDataSet(strQuery);
                    if (ds.Tables[0].Rows.Count > 0) result = Convert.ToInt32(ds.Tables[0].Rows[0]["SFTID"]);
                }
            }
            return result;
        }
        private void tsmiRefreshShift_Click(object sender, EventArgs e)
        {
            if (dgvAttd.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Do you want to change the Shift of Selected Rows ", "change the Shift of Selected Rows", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Random rnd = new Random();
                    DBClass db = new DBClass();
                    int i, hour, minute, second, intEID, intSID, intAttSID;
                    string sql, strAttDate, in_time, out_time, in_time_m, in_time_sub, out_time_m, out_time_sub, strAttLock = "";

                    for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        strAttDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                        intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                        intAttSID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                        strAttLock = dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper();
                        
                        intSID = this.GetShiftPlan(strAttDate, intEID);
                        if (intSID != 0 && intAttSID != intSID && strAttLock == "N")
                        {
                            intAttSID = intSID;
                            sql = "SELECT IN_TIME,OUT_TIME,GRACE,IN_TIME_FROM,SHIFT_NAME FROM SHIFT_INFO WHERE SHIFT_ID ='" + intAttSID + "'";
                            OracleDataReader dr = db.GetExecuteReader(sql);
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    /*
                                    if (dgvAttDetails.SelectedRows[i].Cells["inTime"].Value == null || dgvAttDetails.SelectedRows[i].Cells["inTime"].Value.ToString() == "") dgvAttDetails.SelectedRows[i].Cells["IS_IN_TIME"].Value = 1;
                                    if (dgvAttDetails.SelectedRows[i].Cells["outTime"].Value == null || dgvAttDetails.SelectedRows[i].Cells["outTime"].Value.ToString() == "") dgvAttDetails.SelectedRows[i].Cells["IS_OUT_TIME"].Value = 1;

                                    // ================ Set In Time =======================
                                    in_time_m = dr["IN_TIME"].ToString();
                                    in_time_sub = in_time_m.Substring(0, 2);   // Substring two digit form in-time 
                                    hour = rnd.Next(Convert.ToInt32(in_time_sub)-1, Convert.ToInt32(in_time_sub));   // random generate number 
                                    if (hour < Convert.ToInt32(in_time_sub)) minute = rnd.Next(50, 59);                    // random number genarate between 50 to 59
                                    else minute = rnd.Next(50, 59);                      // random number genarate between 1 to 5
                                    second = rnd.Next(1, 59);
                                    in_time = hour + ":" + minute + ":" + second;     // concatenate hour,minute and second
                                    dgvAttDetails.SelectedRows[i].Cells["inTime"].Value = in_time.ToString();
                                    
                                    // ================ Set Out Time =======================
                                    out_time_m = dr["OUT_TIME"].ToString();
                                    //outDateTime = Convert.ToDateTime(attd_date).AddDays(1);
                                    //nextDay = Convert.ToDateTime(outDateTime).ToString("dd-MMM-yyyy");
                                    dgvAttDetails.SelectedRows[i].Cells["outTime"].Value = out_time_m.ToString();
                                    //if (out_time_m == "06:00" || out_time_m == "05:00") dgvAttDetails.SelectedRows[i].Cells["night"].Value = "Y";
                                    if (TimeSpan.Parse(out_time_m).Hours < 9)
                                        dgvAttDetails.SelectedRows[i].Cells["night"].Value = "Y"; 
                                    else dgvAttDetails.SelectedRows[i].Cells["night"].Value = "N";

                                    out_time_sub = out_time_m.Substring(0, 2);
                                    hour = rnd.Next(Convert.ToInt32(out_time_sub), Convert.ToInt32(out_time_sub));   // random generate number 
                                    if (hour < Convert.ToInt32(out_time_sub)) minute = rnd.Next(01, 09);                    // random number genarate between 50 to 59
                                    else minute = rnd.Next(01, 05);
                                    second = rnd.Next(1, 59);
                                    out_time = hour + ":" + minute + ":" + second;
                                    dgvAttDetails.SelectedRows[i].Cells["outTime"].Value = out_time.ToString();
                                    */
                                    //if (out_time_m == "05:00" || out_time_m == "06:00")
                                    //{
                                    //    my_out_date = nextDay + " " + out_time.ToString();
                                    //    dgvAttDetails.SelectedRows[i].Cells["outTime"].Value = my_out_date;
                                    //}
                                    //else
                                    //{
                                    //    my_out_date = Convert.ToDateTime(attd_date).ToString("dd-MMM-yyyy") + " " + out_time.ToString();
                                    //    dgvAttDetails.SelectedRows[i].Cells["outTime"].Value = my_out_date;
                                    //}
                                    //string value = oracleDataReader["IN_TIME"].ToString();
                                    //string value2 = oracleDataReader["OUT_TIME"].ToString();
                                    //string value3 = oracleDataReader["GRACE"].ToString();
                                    //string value4 = oracleDataReader["IN_TIME_FROM"].ToString();
                                    //this.myDataGridView.SelectedRows[i].Cells["ATTD_SHIFT_ID"].Value = num;
                                    //this.myDataGridView.SelectedRows[i].Cells["SHIFT_IN_TIME"].Value = value;
                                    //this.myDataGridView.SelectedRows[i].Cells["SHIFT_OUT_TIME"].Value = value2;
                                    //this.myDataGridView.SelectedRows[i].Cells["IN_TIME_FROM"].Value = value4;
                                    //this.myDataGridView.SelectedRows[i].Cells["GRACE"].Value = value3; 


                                    //dgvAttDetails.SelectedRows[i].Cells["overTime"].Value = 0;
                                    //dgvAttDetails.SelectedRows[i].Cells["workHour"].Value = 8;
                                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                                    dgvAttd.SelectedRows[i].Cells["shift_id"].Value = intAttSID;
                                    dgvAttd.SelectedRows[i].Cells["shiftName"].Value = dr["SHIFT_NAME"];
                                }
                            }
                            dr.Close();
                        }
                    }
                }
            }
            /*if (dgvAttDetails.SelectedRows.Count > 0)
            {

                if (MessageBox.Show("Do you want to change the Shift of Selected Rows ", "change the Shift of Selected Rows", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DBClass db = new DBClass();
                    bool result = false;

                    for (int count = 0; count < dgvAttDetails.SelectedRows.Count; count++)
                    {
                        string emp_code = "", emp_id = "", shift_name = "", shift_id = "", str_intime = "", str_outtime = "", attd_date = "", update_query = "", select_query = "", select_query2 = "";
                        DateTime out_time_actual = new DateTime();
                        DateTime in_time_actual = new DateTime();
                        DateTime calculate_date1 = new DateTime();
                        DateTime calculate_date2 = new DateTime();
                        DateTime out_time_from = new DateTime();
                        DateTime lunch_start = new DateTime();
                        DateTime lunch_end = new DateTime();
                        TimeSpan time_calculation = new TimeSpan();
                        TimeSpan time_lunch_calculation = new TimeSpan();
                        int work_hour_time_calculation = 0;
                        int lunch_calculation = 0;
                        int work_hour_with_munite = 0;
                        int work_hour = 0;
                        int work_munite = 0;
                        int work_limit = 8;
                        double work_time_cal = 0.0, over_time = 0.0;
                        emp_code = dgvAttDetails.SelectedRows[count].Cells["empCode"].Value.ToString();
                        attd_date = dgvAttDetails.SelectedRows[count].Cells["attDate"].Value.ToString();
                        shift_name = combo_shift.Text;
                        select_query = @"select emp_code,min(movement_time) in_time,max(movement_time) out_time from employee_movement_register where  emp_code='" + emp_code + "' and attd_date='" + attd_date + "' group by emp_code";
                        OracleDataReader dr = db.multiple_value_query(select_query);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                str_intime = dr.GetValue(1).ToString();
                                str_outtime = dr.GetValue(2).ToString();
                                in_time_actual = Convert.ToDateTime(str_intime);
                                out_time_actual = Convert.ToDateTime(str_outtime);
                            }
                        }
                        if (str_intime != "" && str_outtime != "")
                        {
                            select_query2 = @"select shift_id,lunce_start,lunce_end,OUT_TIME_FROM from shift_info where shift_name='" + shift_name + "'";
                            OracleDataReader data = db.multiple_value_query(select_query2);
                            if (data.HasRows)
                            {
                                while (data.Read())
                                {
                                    shift_id = data.GetValue(0).ToString();
                                    lunch_start = Convert.ToDateTime(attd_date + " " + data.GetValue(1) + ":00");
                                    lunch_end = Convert.ToDateTime(attd_date + " " + data.GetValue(2) + ":00");
                                    time_lunch_calculation = lunch_end - lunch_start;
                                    lunch_calculation = time_lunch_calculation.Hours * 60 + time_lunch_calculation.Minutes;
                                    out_time_from = Convert.ToDateTime(attd_date + " " + data.GetValue(3) + ":00");
                                }
                            }
                            string query = @"select emp_code,movement_time from employee_movement_register where emp_code='" + emp_code + @"' and attd_date='" + attd_date + "'  order by movement_time asc";
                            DataSet ds = db.get_data_set(query);
                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    calculate_date1 = Convert.ToDateTime(ds.Tables[0].Rows[i]["MOVEMENT_TIME"]);
                                    calculate_date2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["MOVEMENT_TIME"]);
                                    time_calculation = calculate_date1 - calculate_date2;
                                    work_hour_time_calculation += time_calculation.Hours * 60 + time_calculation.Minutes;
                                }

                                if (work_hour_time_calculation > 0)
                                {
                                    work_hour_with_munite = work_hour_time_calculation - lunch_calculation;
                                    work_hour = work_hour_with_munite / 60;
                                    work_munite = work_hour_with_munite % 60;
                                    if (work_munite > 44) work_time_cal = work_hour + 1;
                                    else if (work_munite > 24) work_time_cal = work_hour + 0.5;
                                    else work_time_cal = work_hour;
                                    if (work_time_cal > work_limit)
                                    {
                                        over_time = work_time_cal - work_limit;
                                    }
                                }
                                else
                                {
                                    work_time_cal = 0;
                                    over_time = 0;
                                }
                                if (calculate_date1 > out_time_from)
                                {
                                    update_query = @"update attendance_details set work_hour=" + work_time_cal + ",in_time=null,OUT_TIME=to_date('" + Convert.ToDateTime(out_time_actual).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh12:mi:ss am'),
                                             over_time=" + over_time + ",shift_id=" + shift_id.ToString() + " where emp_id in(select emp_id from emp_official where emp_code='" + emp_code + "') and attd_date='" + attd_date + "' and NVL(attd_locked,'N')!='Y'";
                                    result = db.RunDmlQuery(update_query);
                                }
                                else
                                {
                                    update_query = @"update attendance_details set work_hour=" + work_time_cal + ",IN_TIME=to_date('" + Convert.ToDateTime(out_time_actual).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh12:mi:ss am'),
                                             out_time=null,over_time=" + over_time + ",shift_id=" + shift_id.ToString() + " where emp_id in(select emp_id from emp_official where emp_code='" + emp_code + "') and attd_date='" + attd_date + "' and NVL(attd_locked,'N')!='Y'";
                                    result = db.RunDmlQuery(update_query);
                                }

                            }
                            else
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    calculate_date1 = Convert.ToDateTime(ds.Tables[0].Rows[i + 1]["MOVEMENT_TIME"]);
                                    calculate_date2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["MOVEMENT_TIME"]);
                                    time_calculation = calculate_date1 - calculate_date2;
                                    work_hour_time_calculation += time_calculation.Hours * 60 + time_calculation.Minutes;
                                }
                                if (work_hour_time_calculation > 0)
                                {
                                    work_hour_with_munite = work_hour_time_calculation - lunch_calculation;
                                    work_hour = work_hour_with_munite / 60;
                                    work_munite = work_hour_with_munite % 60;
                                    if (work_munite > 44) work_time_cal = work_hour + 1;
                                    else if (work_munite > 24) work_time_cal = work_hour + 0.5;
                                    else work_time_cal = work_hour;
                                    if (work_time_cal > work_limit)
                                    {
                                        over_time = work_time_cal - work_limit;
                                    }
                                }
                                else
                                {
                                    work_time_cal = 0;
                                    over_time = 0;
                                }

                                update_query = @"update attendance_details set work_hour=" + work_time_cal + ",IN_TIME=to_date('" + Convert.ToDateTime(in_time_actual).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh12:mi:ss am'),
                                                OUT_TIME=to_date('" + Convert.ToDateTime(out_time_actual).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh12:mi:ss am'),
                                             over_time=" + over_time + ",shift_id=" + shift_id.ToString() + " where emp_id in(select emp_id from emp_official where emp_code='" + emp_code + "') and attd_date='" + attd_date + "' and NVL(attd_locked,'N')!='Y'";
                                result = db.RunDmlQuery(update_query);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no data of " + emp_code + " in Employee Movement Register at " + attd_date + ". Please check it...");
                        }
                    }

                    if (result)
                    {
                        MessageBox.Show("successfully Changed Shift....");
                    }
                }
            }*/
        }
        private void tsmiLeaveLWP_Click(object sender, EventArgs e)
        {
            int i, intEID;
            bool uFlag = false;
            DBClass db = new DBClass();
            string strSql, strQuery, attDate = "";
            if (MessageBox.Show("Are You Sure to Post LWP Leave", "Save As...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmSecurityInputBox oPwd = new frmSecurityInputBox(ref txtPassword);
                oPwd.ShowDialog();
                if (txtPassword.Text == "l123")
                {
                    for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                        {
                            attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                            intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                            strQuery = "UPDATE ATTENDANCE_DETAILS SET IN_TIME='', LATE = '0', OUT_TIME = '', OVER_TIME='0',ATTD_LOCKED='Y',STATUS='L', NIGHT_STATUS='N', STATUS2='L', ATTD_REMARKS='LWP',USER_ID = '" 
                                + ConfigurationManager.AppSettings["UserID"] + "', IS_IN_TIME_MANUAL='1',IS_OUT_TIME_MANUAL='1' WHERE NVL(ATTD_LOCKED,'N') !='Y' AND ATTD_DATE = '" + attDate + "' AND EMP_ID = '" + intEID + "'";
                            if (db.RunDmlQuery(strQuery))
                            {
                                strQuery = strQuery.Replace("'", string.Empty);
                                strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','ATTENDANCE_DETAILS','" + strQuery +
                                        "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + dgvAttd.SelectedRows[i].Cells["EMPCODE"].Value.ToString() + "')";
                                uFlag = db.RunDmlQuery(strSql);
                            }
                        }
                    }
                    if (uFlag)
                    {
                        MessageBox.Show("LWP Leave Posting Successfully", "Save As...", MessageBoxButtons.OK, MessageBoxIcon.None);
                        dgvAttd.Rows.Clear();
                    }
                }
                else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Action Canceled");
        }
        private int GetLeaveBalance(string strEmp, string strLv)
        {
            DBClass db = new DBClass(); int iLv = 0, cYear = dtpEnd.Value.Year, pYear = cYear - 1;
            string strSql = @"SELECT 14-NVL(GRANT_SL,0) SL,NVL(CASE WHEN DATE_OF_JOINING<'01-Jan-" + cYear + @"' THEN 10
                ELSE ROUND(10/365*(365-ROUND(MONTHS_BETWEEN(DATE_OF_JOINING,'01-Jan-" + cYear + @"')/12*365+1))) END,0)-NVL(GRANT_CL,0) CL,
                DECODE(E_O.EL_HOLDER,'Y',((CASE WHEN (TRUNC(MONTHS_BETWEEN(SYSDATE,DATE_OF_JOINING)/12))<1 THEN 0 ELSE NVL(ROUND(PRESENT/18,0),0) END)-NVL(GRANT_EL,0)),0) EL
            FROM EMP_OFFICIAL E_O,(SELECT DISTINCT A.EMP_ID,COUNT(A.EMP_ID) PRESENT FROM ATTENDANCE_DETAILS A,EMP_OFFICIAL O,
                    (SELECT E.EMP_ID,MAX(E.LAST_COUNTING_DATE+1) LAST_DATE FROM EARN_LEAVE_PROCESS E
                    WHERE E.LAST_COUNTING_DATE<'01-Jan-" + cYear + @"' GROUP BY E.EMP_ID) E
                WHERE A.ATTD_DATE BETWEEN NVL(E.LAST_DATE,O.DATE_OF_JOINING) AND '" + dtpEnd.Text 
                    + @"' AND O.EMP_ID=A.EMP_ID AND O.EMP_ID=E.EMP_ID(+) AND A.STATUS='P' GROUP BY A.EMP_ID) P,
                (SELECT EMP_ID,SUM(NVL(CL,0)) GRANT_CL, SUM(NVL(SL,0)) GRANT_SL,SUM(NVL(EL,0)) GRANT_EL
                FROM (SELECT EMP_ID,DECODE(TYPE,'CL',SUM(GRANT_DAYS)) CL,DECODE(UPPER(TYPE),'ML',SUM(GRANT_DAYS),'SL',SUM(GRANT_DAYS)) SL, 0 EL
                FROM LEAVE WHERE FROM_DATE >= '01-Jan-" + cYear + @"' GROUP BY EMP_ID,TYPE
                UNION ALL
                SELECT L.EMP_ID,0 CL, 0 SL, DECODE(L.TYPE,'EL',SUM(L.GRANT_DAYS)) EL
                FROM LEAVE L,EMP_OFFICIAL E_O WHERE E_O.EMP_ID=L.EMP_ID AND E_O.EL_SEGMENT='July' AND L.FROM_DATE >= '01-Jan-" + pYear + @"' GROUP BY L.EMP_ID,TYPE
                UNION ALL
                SELECT L.EMP_ID,0 CL, 0 SL, DECODE(L.TYPE,'EL',SUM(L.GRANT_DAYS)) EL
                FROM LEAVE L,EMP_OFFICIAL E_O WHERE E_O.EMP_ID=L.EMP_ID AND E_O.EL_SEGMENT='January' AND L.FROM_DATE >= '01-Jul-" + pYear + @"' GROUP BY L.EMP_ID,TYPE)
                GROUP BY EMP_ID) LV,
                (SELECT L.EMP_ID,TYPE,GRANT_DAYS,FROM_DATE,TO_DATE FROM LEAVE L,(SELECT EMP_ID,MAX(FROM_DATE) MAX_DATE FROM LEAVE WHERE FROM_DATE>= '01-Jan-" + cYear + @"' GROUP BY EMP_ID) MX
                WHERE L.EMP_ID=MX.EMP_ID AND L.FROM_DATE=MX.MAX_DATE) LX 
            WHERE E_O.EMP_ID=P.EMP_ID(+) AND E_O.EMP_ID=LV.EMP_ID(+) AND E_O.EMP_ID=LX.EMP_ID(+) AND E_O.EMP_ID = '" + strEmp + "'";
            DataSet ds = db.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (strLv == "CL") iLv = Convert.ToInt32(ds.Tables[0].Rows[0]["CL"]);
                else if (strLv == "ML" || strLv == "SL") iLv = Convert.ToInt32(ds.Tables[0].Rows[0]["SL"]);
                else if (strLv == "EL" || strLv == "AL") iLv = Convert.ToInt32(ds.Tables[0].Rows[0]["EL"]);
            }
            return iLv;
        }
        private void tsmiLeave_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            bool uFlag = false; int i, intLID = 0;
            string strSql, strEmp, strDT, strCode = "";
            string year = dtpStart.Value.ToString("yyyy");            
            string strType = Interaction.InputBox("Enter Leave Type(Ex. CL/SL/EL).", "Leave Type").ToUpper();
            if (strType.Trim().Length > 0)
            {
                if (MessageBox.Show("Do You Want To Post " + strType + " Leave", "Leave Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmSecurityInputBox oPwd = new frmSecurityInputBox(ref txtPassword);
                    oPwd.ShowDialog();
                    if (txtPassword.Text == "l123")
                    {
                        for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
                        {
                            if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                            {
                                //int r = dgvAttd.CurrentRow.Index;
                                strDT = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                                strEmp = dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value.ToString();
                                strCode = dgvAttd.SelectedRows[i].Cells["empCode"].Value.ToString();
                                if (this.GetLeaveBalance(strEmp, strType) > 0)
                                {
                                    strSql = "UPDATE ATTENDANCE_DETAILS SET IN_TIME = '', LATE = '0', EARLY_OUT='0', OUT_TIME = '', OVER_TIME='0',STATUS='L',NIGHT_STATUS='N',STATUS2='L',ATTD_REMARKS='" + strType + "',USER_ID='"
                                        + ConfigurationManager.AppSettings["uID"] + "', ATTD_LOCKED='Y' WHERE NVL(ATTD_LOCKED,'N') !='Y' AND STATUS2 NOT IN('W','H') AND ATTD_DATE = '" + strDT + "' AND EMP_ID='" + strEmp + "'";
                                    if (db.RunDmlQuery(strSql))
                                    {
                                        strSql = "SELECT NVL(MAX(TO_NUMBER(LEAVE_ID)),0) + 1 AS LID FROM LEAVE";
                                        DataSet ds = db.GetDataSet(strSql); if (ds.Tables[0].Rows.Count > 0) intLID = Convert.ToInt32(ds.Tables[0].Rows[0]["LID"]);
                                        strSql = "INSERT INTO LEAVE(LEAVE_ID, EMP_ID, EMP_CODE, TYPE, FROM_DATE, TO_DATE, GRANT_DAYS, REMARKS, LEAVE_ENTRY_DATE) VALUES('" + intLID + "','"
                                            + strEmp + "','" + strCode + "','" + strType + "','" + strDT + "','" + strDT + "','1','" + strType + "','" + DateTime.Now.Date.ToString("dd-MMM-yyyy") + "')";
                                        uFlag = db.RunDmlQuery(strSql);
                                    }
                                }
                            }
                        }
                        if (uFlag)
                        {
                            dgvAttd.Rows.Clear();
                            MessageBox.Show(strType + " Leave Posting Successfully", "Save As.");
                        }
                    }
                    else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Action Canceled");
            }
        }
        private void tsmiAutoLeave_Click(object sender, EventArgs e)
        {
            bool uFlag = false;
            string strSql, strEmp, strDT, strCode = "";
            int i, intLID = 0; DBClass db = new DBClass();
            string year = dtpStart.Value.ToString("yyyy");
            string strType = Interaction.InputBox("Enter Leave Type(Ex. CL/SL/EL).", "Leave Type").ToUpper();
            if (strType.Trim().Length > 0)
            {
                if (MessageBox.Show("Do You Want To Post Auto " + strType + " Leave", "Leave Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmSecurityInputBox oPwd = new frmSecurityInputBox(ref txtPassword);
                    oPwd.ShowDialog();
                    if (txtPassword.Text == "l123")
                    {
                        for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
                        {
                            if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                            {
                                //int r = dgvAttd.CurrentRow.Index;
                                strDT = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                                strEmp = dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value.ToString();
                                strCode = dgvAttd.SelectedRows[i].Cells["empCode"].Value.ToString();
                                if (this.GetLeaveBalance(strEmp, strType) > 0)
                                {
                                    strSql = "UPDATE ATTENDANCE_DETAILS SET IN_TIME = '', LATE = '0', EARLY_OUT='0', OUT_TIME = '', OVER_TIME='0',STATUS='L', NIGHT_STATUS='N', STATUS2='L',ATTD_REMARKS='Auto " + strType + "',USER_ID='"
                                        + ConfigurationManager.AppSettings["uID"] + "', ATTD_LOCKED='Y' WHERE NVL(ATTD_LOCKED,'N') !='Y' AND STATUS2 NOT IN('W','H') AND ATTD_DATE = '" + strDT + "' AND EMP_ID='" + strEmp + "'";
                                    if (db.RunDmlQuery(strSql))
                                    {
                                        strSql = "SELECT NVL(MAX(TO_NUMBER(LEAVE_ID)),0) + 1 AS LID FROM LEAVE";
                                        DataSet ds = db.GetDataSet(strSql);
                                        if (ds.Tables[0].Rows.Count > 0) intLID = Convert.ToInt32(ds.Tables[0].Rows[0]["LID"]);
                                        strSql = "INSERT INTO LEAVE(LEAVE_ID, EMP_ID, EMP_CODE, TYPE, FROM_DATE, TO_DATE, GRANT_DAYS, REMARKS, LEAVE_ENTRY_DATE) VALUES('"
                                            + intLID + "','" + strEmp + "','" + strCode + "','" + strType + "','" + strDT + "','" + strDT + "','1','Auto " + strType + "','" + DateTime.Now.Date.ToString("dd-MMM-yyyy") + "')";
                                        uFlag = db.RunDmlQuery(strSql);
                                    }
                                }
                            }
                        }
                        if (uFlag)
                        {
                            dgvAttd.Rows.Clear();
                            MessageBox.Show("Auto " + strType + " Posting Successfully", "Save As.");
                        }
                    }
                    else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Action Canceled");
            }
        }
        private void tsmiLeaveCPL_Click(object sender, EventArgs e)
        {
            //int i, intEID;
            //bool uFlag = false;
            //DBClass db = new DBClass();
            //string strSql, strQuery,attDate = "";
            //if (MessageBox.Show("Do You Want To Post CPL/SPL/ADL/SML Leave", "Save As...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
            //    objSecurityInputBox.ShowDialog();
            //    if (txtPassword.Text == "l123")
            //    {
            //        for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            //        {
            //            if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
            //            {
            //                attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
            //                intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);

            //                strQuery = "UPDATE ATTENDANCE_DETAILS SET IN_TIME='', LATE = '0', OUT_TIME = '', OVER_TIME='0',ATTD_LOCKED='Y',STATUS='L', NIGHT_STATUS='N', STATUS2='L', ATTD_REMARKS='CPL',USER_ID = '" + ConfigurationManager.AppSettings["UserID"] + "', IS_IN_TIME_MANUAL='1',IS_OUT_TIME_MANUAL='1' WHERE NVL(ATTD_LOCKED,'N') !='Y' AND ATTD_DATE = '" + attDate + "' AND EMP_ID = '" + intEID + "'";
            //                if (db.RunDmlQuery(strQuery))
            //                {
            //                    strQuery = strQuery.Replace("'", string.Empty);
            //                    strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','ATTENDANCE_DETAILS','" + strQuery +
            //                                "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + dgvAttd.SelectedRows[i].Cells["EMPCODE"].Value.ToString() + "')";
            //                    uFlag = db.RunDmlQuery(strSql);
            //                }
            //            }
            //        }
            //        if (uFlag == true)
            //        {
            //            MessageBox.Show("CPL Leave Posting Successfully", "Save As...", MessageBoxButtons.OK);
            //            dgvAttd.Rows.Clear();
            //        }
            //    }
            //    else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //}
            //else MessageBox.Show("Action Canceled");

            int i, iEmp;
            bool uFlag = false;
            DBClass db = new DBClass();
            string strSql, strQuery, attDate = "";
            string strType = Interaction.InputBox("Enter Leave Type(Ex. ADL/CPL/SPL/LWP/SML).", "Leave Type").ToUpper();
            if (strType.Trim().Length > 0)
            {
                if (MessageBox.Show("Do You Want To Post " + strType.Trim() + " Leave", "Save As...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmSecurityInputBox oPwd = new frmSecurityInputBox(ref txtPassword);
                    oPwd.ShowDialog();
                    if (txtPassword.Text == "l123")
                    {
                        for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
                        {
                            attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                            iEmp = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);

                            strQuery = "UPDATE ATTENDANCE_DETAILS SET IN_TIME='',LATE = '0',OUT_TIME = '', OVER_TIME='0',ATTD_LOCKED='Y',STATUS='L', NIGHT_STATUS='N', STATUS2='L', ATTD_REMARKS='" + strType.Trim()
                                + "',USER_ID = '" + CConfig.user_id + "',IS_IN_TIME_MANUAL='1',IS_OUT_TIME_MANUAL='1' WHERE NVL(ATTD_LOCKED,'N') !='Y' AND ATTD_DATE = '" + attDate + "' AND EMP_ID = '" + iEmp + "'";
                            if (db.RunDmlQuery(strQuery))
                            {
                                strQuery = strQuery.Replace("'", string.Empty);
                                strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + CConfig.user_id + "','ATTENDANCE_DETAILS','" + strQuery +
                                    "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + dgvAttd.SelectedRows[i].Cells["EMPCODE"].Value.ToString() + "')";
                                uFlag = db.RunDmlQuery(strSql);
                            }
                        }
                        if (uFlag)
                        {
                            MessageBox.Show(strType.Trim() + " Leave Posting Successfully", "Save As...", MessageBoxButtons.OK);
                            dgvAttd.Rows.Clear();
                        }
                    }
                    else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Action Canceled");
            }
        }
        private void tsmiMaternityLeave_Click(object sender, EventArgs e)
        {
            int i, intEID;
            bool uFlag = false;
            DBClass db = new DBClass();
            string strQuery, attDate = "";
            if (MessageBox.Show("Do You Want To Post Maternity Leave", "Save As...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "l123")
                {
                    for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                        {
                            attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                            intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                            strQuery = "UPDATE ATTENDANCE_DETAILS SET IN_TIME='', LATE = '0', OUT_TIME = '', OVER_TIME='0',ATTD_LOCKED='Y', STATUS='L', NIGHT_STATUS='N', STATUS2='L', ATTD_REMARKS='Maternity Leave',USER_ID= '" + ConfigurationManager.AppSettings["UserID"] + "', IS_IN_TIME_MANUAL='1',IS_OUT_TIME_MANUAL='1' WHERE NVL(ATTD_LOCKED,'N') !='Y' AND ATTD_DATE ='" + attDate + "' AND EMP_ID='" + intEID + "'";
                            uFlag = db.RunDmlQuery(strQuery);
                        }
                    }
                    if (uFlag == true)
                    {
                        MessageBox.Show("Maternity Leave Posting Successfully", "Save As...");
                        dgvAttd.Rows.Clear();
                    }
                }
                else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error); 
            }
            else MessageBox.Show("Action Canceled");
        }
        private void tsmiOutTimeByOT_Click(object sender, EventArgs e)
        {
            tsmiSetOverTime_Click(sender, e);
        } // end of private void outTimeByOTToolStripMenuItem_Click(object sender, EventArgs e)
        
        private void tsmiRemoveOTHours_Click(object sender, EventArgs e)
        {
            tsmiResetOutTime_Click(sender, e);
        } //private void removeOTToolStripMenuItem_Click(object sender, EventArgs e)
        private void tsmiSaveData_Click(object sender, EventArgs e)
        {
            if (dgvAttd.Rows.Count > 0)
            {
                bool flag = true;
                DBClass db = new DBClass();
                int i, intEID, intSID, intIsInTime, intIsOutTime;
                string strQuery, strAttDate, strInTime, strLate, strOutTime, strOverTime, strStatus, strNight, strStatus2, strAttRemarks = "";

                for (i = 0; i < dgvAttd.Rows.Count&&flag; i++)
                {
                    string strLock = dgvAttd.Rows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper();
                    if (strLock == "N" && dgvAttd.Rows[i].Cells["rFlag"].Value != null && dgvAttd.Rows[i].Cells["rFlag"].Value.ToString() == "U")
                    {
                        strAttDate = dgvAttd.Rows[i].Cells["attDate"].Value.ToString();
                        strInTime = dgvAttd.Rows[i].Cells["inTime"].Value.ToString();
                        strLate = dgvAttd.Rows[i].Cells["late"].Value.ToString();
                        //intWkHr = Convert.ToInt32(dgvAttDetails.Rows[i].Cells["workHour"].Value);
                        strOutTime = dgvAttd.Rows[i].Cells["outTime"].Value.ToString();
                        strOverTime = dgvAttd.Rows[i].Cells["overTime"].Value.ToString();
                        strStatus = dgvAttd.Rows[i].Cells["status"].Value.ToString().ToUpper().Trim();
                        strNight = dgvAttd.Rows[i].Cells["night"].Value.ToString().ToUpper().Trim();
                        strStatus2 = dgvAttd.Rows[i].Cells["status2"].Value.ToString().ToUpper().Trim();
                        intEID = Convert.ToInt32(dgvAttd.Rows[i].Cells["EMP_ID"].Value);
                        intSID = Convert.ToInt32(dgvAttd.Rows[i].Cells["shift_id"].Value);
                        intIsInTime = Convert.ToInt32(dgvAttd.Rows[i].Cells["IS_IN_TIME"].Value);
                        intIsOutTime = Convert.ToInt32(dgvAttd.Rows[i].Cells["IS_OUT_TIME"].Value);
                        strAttRemarks = dgvAttd.Rows[i].Cells["remarks"].Value.ToString().Trim();
                        if (strOutTime.Length > 0)
                        {
                            if (strNight =="Y") strOutTime = Convert.ToDateTime(strAttDate).AddDays(1).ToString("dd-MMM-yyyy") + " " + strOutTime;
                            else strOutTime = Convert.ToDateTime(strAttDate).ToString("dd-MMM-yyyy") + " " + strOutTime;
                        }
                        //strSql = "SELECT OUT_TIME_FROM FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
                        //DataSet ds = db.get_data_set(strSql);
                        //if (ds.Tables[0].Rows.Count > 0)
                        //{
                        //    if (strOutTime.Length > 0)
                        //    {
                        //        if (TimeSpan.Parse(strOutTime.ToString()).Hours <= TimeSpan.Parse(ds.Tables[0].Rows[0]["OUT_TIME_FROM"].ToString()).Hours)
                        //            strOutTime = Convert.ToDateTime(strAttDate).AddDays(1).ToString("dd-MMM-yyyy") + " " + strOutTime;
                        //        else strOutTime = Convert.ToDateTime(strAttDate).ToString("dd-MMM-yyyy") + " " + strOutTime;
                        //    }
                        //}
                        //if (strOutTime.Length > 0)
                        //{
                        //    //if (TimeSpan.Parse(strOutTime).Hours <= 9) 
                        //    if ((TimeSpan.Parse(strInTime).Hours + intWkHr) >= 24) strOutTime = Convert.ToDateTime(strAttDate).AddDays(1).ToString("dd-MMM-yyyy") + " " + strOutTime;
                        //    else strOutTime = Convert.ToDateTime(strAttDate).ToString("dd-MMM-yyyy") + " " + strOutTime;
                        //}
                        if (strInTime.Length > 0) strInTime = Convert.ToDateTime(strAttDate).ToString("dd-MMM-yyyy") + " " + strInTime;
                        strQuery = @"UPDATE ATTENDANCE_DETAILS SET IN_TIME=" + (strInTime.ToString() == "" ? "NULL" : "TO_DATE('" + strInTime + "','dd-Mon-yyyy hh24:mi:ss')") + ", LATE = '" + strLate + "', OUT_TIME =" + (strOutTime.ToString() == "" ? "NULL" : " TO_DATE('" + strOutTime + "','dd-Mon-yyyy hh24:mi:ss')") + ",OVER_TIME='" +
                                strOverTime + "',STATUS='" + strStatus + "',NIGHT_STATUS='" + strNight + "', STATUS2='" + strStatus2 + "', ATTD_REMARKS='" + strAttRemarks + "', IS_IN_TIME_MANUAL='" + intIsInTime + "',IS_OUT_TIME_MANUAL='" + intIsOutTime + "',USER_ID= '" + ConfigurationManager.AppSettings["UserID"] + "',SHIFT_ID ='" + intSID +
                                "' WHERE ATTD_DATE =TO_DATE('" + Convert.ToDateTime(strAttDate).ToString("dd-MMM-yyyy") + "','dd-Mon-yyyy') AND EMP_ID='" + intEID + "' AND NVL(ATTD_LOCKED,'N') !='Y'";
                        flag = db.RunDmlQuery(strQuery);
                    }                    
                }
                if (flag)
                {
                    dgvAttd.Rows.Clear();
                    MessageBox.Show("Data Updated Successfully.", "Save As...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Data Updated Failed.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
        private void tsmiSetOverTime_Click(object sender, EventArgs e)
        {
            double over_time_value = 0.0;
            DBClass db = new DBClass(); bool result = false;
            DateTime out_time, in_time, shift_info_out_date;
            string in_time_process,out_time_process, sql = "";            
            for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                {
                    string attd_date = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                    string emp_code = dgvAttd.SelectedRows[i].Cells["empCode"].Value.ToString();
                    string shift_name = dgvAttd.SelectedRows[i].Cells["shiftName"].Value.ToString();
                    string status2 = dgvAttd.SelectedRows[i].Cells["status2"].Value.ToString();
                    string status = dgvAttd.SelectedRows[i].Cells["status"].Value.ToString();
                    string work_time = dgvAttd.SelectedRows[i].Cells["workHour"].Value.ToString();
                    string late = dgvAttd.SelectedRows[i].Cells["late"].Value.ToString();
                    string out_time_dgv = dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString();
                    string in_time_dgv = dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString();
                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                    in_time = DateTime.Parse(attd_date + " " + in_time_dgv);
                    out_time = Convert.ToDateTime(attd_date + " " + out_time_dgv);
                    if (in_time_dgv != "" && out_time_dgv != "")
                    {
                        string shift_info_in_time = get_shift_in_time(shift_name);
                        string shift_info_out_time = get_shift_out_time(shift_name);
                        out_time_process = out_time.ToShortDateString();
                        in_time_process = in_time.ToShortDateString();

                        if (status == "P")
                        {
                            if (status2 == "W")
                            {
                                if (shift_info_out_time == "05:00" || shift_info_out_time == "06:00")
                                {
                                    out_time = out_time.AddDays(1);
                                    TimeSpan overtime = out_time - in_time;
                                    if (overtime.Hours > 0)
                                    {
                                        if (overtime.Minutes >= 44) over_time_value = overtime.Hours + 1.0;
                                        else if (overtime.Minutes > 24) over_time_value = overtime.Hours + 0.5;
                                        else over_time_value = overtime.Hours;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                    }
                                    else
                                    {
                                        over_time_value = 0;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                    }
                                }
                                else
                                {
                                    if (out_time < in_time)
                                    {
                                        out_time = out_time.AddHours(12);
                                    }
                                    TimeSpan overtime = out_time - in_time;
                                    if (overtime.Hours > 0)
                                    {
                                        if (overtime.Minutes >= 44) over_time_value = overtime.Hours + 1.0;
                                        else if (overtime.Minutes > 24) over_time_value = overtime.Hours + 0.5;
                                        else over_time_value = overtime.Hours;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                    }
                                    else
                                    {
                                        over_time_value = 0;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                    }
                                }
                            }
                            else if (status2 == "H")
                            {

                                if (shift_info_out_time == "05:00" || shift_info_out_time == "06:00")
                                {
                                    out_time = out_time.AddDays(1);
                                    TimeSpan overtime = out_time - in_time;
                                    if (overtime.Hours > 0)
                                    {
                                        if (overtime.Minutes >= 44) over_time_value = overtime.Hours + 1.0;
                                        else if (overtime.Minutes > 24) over_time_value = overtime.Hours + 0.5;
                                        else over_time_value = overtime.Hours;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                        status = "P";
                                    }
                                    else
                                    {
                                        over_time_value = 0;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                        status = "P";
                                    }
                                }
                                else
                                {
                                    if (out_time < in_time)
                                    {
                                        out_time = out_time.AddHours(12);
                                    }
                                    TimeSpan overtime = out_time - in_time;
                                    if (overtime.Hours > 0)
                                    {
                                        if (overtime.Minutes >= 44) over_time_value = overtime.Hours + 1.0;
                                        else if (overtime.Minutes > 24) over_time_value = overtime.Hours + 0.5;
                                        else over_time_value = overtime.Hours;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                        status = "P";
                                    }
                                    else
                                    {
                                        over_time_value = 0;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                        status = "P";
                                    }
                                }

                            }
                            else
                            {
                                shift_info_out_date = DateTime.Parse(out_time_process + " " + shift_info_out_time);
                                if (shift_info_out_time == "05:00" || shift_info_out_time == "06:00")
                                {
                                    out_time = out_time.AddDays(1);
                                    TimeSpan overtime = out_time - shift_info_out_date.AddDays(1);
                                    if (overtime.Hours > 0)
                                    {
                                        if (overtime.Minutes >= 44) over_time_value = overtime.Hours + 1.0;
                                        else if (overtime.Minutes > 24) over_time_value = overtime.Hours + 0.5;
                                        else over_time_value = overtime.Hours;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                    }
                                    else
                                    {
                                        over_time_value = 0;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;
                                    }
                                }
                                else
                                {
                                    TimeSpan overtime = out_time - shift_info_out_date;
                                    if (overtime.Hours > 0)
                                    {
                                        if (overtime.Minutes >= 44) over_time_value = overtime.Hours + 1.0;
                                        else if (overtime.Minutes > 24) over_time_value = overtime.Hours + 0.5;
                                        else over_time_value = overtime.Hours;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;

                                    }
                                    else
                                    {
                                        over_time_value = 0;
                                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = over_time_value;

                                    }
                                }
                            }
                        }
                    }
                    sql = @"update attendance_details  set in_time=to_date('" + in_time.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss am'),out_time=to_date('" + out_time.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss am'),over_time=trunc(to_number(" + over_time_value.ToString() + "),1),status='" + status + "' where emp_id in (select emp_id from emp_official where emp_code='" + emp_code + "') and attd_date=to_date('" + attd_date + "','dd-Mon-yyyy')";
                    result = db.RunDmlQuery(sql);
                }
                if (result)
                {
                    MessageBox.Show("OverTime Update Successfully....");
                }
                else
                {
                    MessageBox.Show("Update is not successful");
                }
            }
        }

        private string get_shift_in_time(string shift_name)
        {
            string shift_in_time = "";
            DBClass db = new DBClass();
            string sql = "select in_time from shift_info where shift_name='" + shift_name + "'";
            OracleDataReader dr = db.GetExecuteReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    shift_in_time = dr.GetString(0);
                }
            }
            return shift_in_time;
        }
        private string get_shift_out_time(string shift_name)
        {
            DBClass db = new DBClass();
            string sql = "";
            string shift_out_time = "";
            sql = @"select out_time from shift_info where shift_name='" + shift_name + "'";
            OracleDataReader dr = db.GetExecuteReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    shift_out_time = dr.GetString(0);
                }
            }
            return shift_out_time;
        }
        private void tsmiSetOnMissingInTime_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            DBClass db = new DBClass();
            int i, intEID, hour, minute, second, intSID;
            string strSql, attDate, sInTime, inIimeSub, inTime = "";
            for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString() == "" && dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "L")
                {
                    attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                    intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                    intSID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                    if (dgvAttd.SelectedRows[i].Cells["status2"].Value.ToString() == "W".Trim() || dgvAttd.SelectedRows[i].Cells["status2"].Value.ToString() == "H".Trim())
                        dgvAttd.SelectedRows[i].Cells["inTime"].Value = inTime.ToString();
                    else 
                    {
                        dgvAttd.SelectedRows[i].Cells["status2"].Value = "P";
                        strSql = "SELECT IN_TIME FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
                        DataSet ds = db.GetDataSet(strSql);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            sInTime = ds.Tables[0].Rows[0]["IN_TIME"].ToString();
                            inIimeSub = sInTime.Substring(0, 2);
                            hour = rnd.Next(Convert.ToInt32(inIimeSub) - 1, Convert.ToInt32(inIimeSub));
                            if (hour < Convert.ToInt32(inIimeSub)) minute = rnd.Next(50, 59);
                            else minute = rnd.Next(50, 59);
                            second = rnd.Next(1, 59);
                            inTime = hour + ":" + minute + ":" + second;
                            dgvAttd.SelectedRows[i].Cells["inTime"].Value = inTime.ToString();
                        }
                        dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                        dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                        dgvAttd.SelectedRows[i].Cells["status"].Value = "P";
                        dgvAttd.SelectedRows[i].Cells["IS_IN_TIME"].Value = inManual(intEID, attDate);
                    }                    
                }
                else return;
            }
        }
        private void tsmiResetInTime_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            DBClass db = new DBClass();
            int i, intEID, hour, minute, second, intSID;
            string strSql, attDate, inTime, sInTime, inIimeSub = "";
            for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString() != "" && dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "L")
                {
                    attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                    intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                    intSID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                    strSql = "SELECT IN_TIME FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
                    DataSet ds = db.GetDataSet(strSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sInTime = ds.Tables[0].Rows[0]["IN_TIME"].ToString();
                        inIimeSub = sInTime.Substring(0, 2);
                        hour = rnd.Next(Convert.ToInt32(inIimeSub) - 1, Convert.ToInt32(inIimeSub));
                        if (hour < Convert.ToInt32(inIimeSub)) minute = rnd.Next(50, 59);
                        else minute = rnd.Next(50, 59);
                        second = rnd.Next(1, 59);
                        inTime = hour + ":" + minute + ":" + second;
                        dgvAttd.SelectedRows[i].Cells["inTime"].Value = inTime.ToString();
                    }
                    dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                    dgvAttd.SelectedRows[i].Cells["status"].Value = "P";
                    dgvAttd.SelectedRows[i].Cells["IS_IN_TIME"].Value = inManual(intEID, attDate);
                    if (dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "W" || dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "H")
                        dgvAttd.SelectedRows[i].Cells["status2"].Value = "P";
                }
            }
        }
        private void tsmiRefreshInTime_Click(object sender, EventArgs e)
        {
            int i, intSID, intLate;
            Random rnd = new Random();
            DBClass db = new DBClass();
            TimeSpan tsLate = new TimeSpan();
            string strSql, attDate, strInTime, sInTime = "";
            for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString() != "" && dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "L")
                {
                    attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                    strInTime = dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString();
                    intSID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                    strSql = "SELECT GRACE FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
                    DataSet ds = db.GetDataSet(strSql);
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        intLate = 0;
                        sInTime = ds.Tables[0].Rows[0]["GRACE"].ToString();
                        if (DateTime.Parse(strInTime) > DateTime.Parse(sInTime))
                        {
                            tsLate = DateTime.Parse(strInTime) - DateTime.Parse(sInTime);
                            intLate = tsLate.Hours * 60 + tsLate.Minutes;
                        }
                        dgvAttd.SelectedRows[i].Cells["late"].Value = intLate.ToString();
                    }
                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                }
            }
        }
        private void tsmiSetOnMissingOut_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            DBClass db = new DBClass();
            int i, intEID, hour, minute, second, intSID;
            string strSql, outTime, attDate, sOutTime, mOutTime = "";
            for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString() == "" && dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "L")
                {
                    attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                    intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                    intSID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                    strSql = "SELECT OUT_TIME FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
                    DataSet ds = db.GetDataSet(strSql);
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        sOutTime = ds.Tables[0].Rows[0]["OUT_TIME"].ToString();
                        mOutTime = sOutTime.Substring(0, 2);
                        hour = rnd.Next(Convert.ToInt32(mOutTime), Convert.ToInt32(mOutTime));
                        if (hour < Convert.ToInt32(mOutTime)) minute = rnd.Next(01, 05);
                        else minute = rnd.Next(01, 09);
                        second = rnd.Next(1, 59);
                        outTime = hour + ":" + minute + ":" + second;
                        dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                        dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = 0;
                        dgvAttd.SelectedRows[i].Cells["outTime"].Value = outTime.ToString();
                        dgvAttd.SelectedRows[i].Cells["IS_OUT_TIME"].Value = outManual(intEID, attDate);
                        if (TimeSpan.Parse(dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString()).Hours < 9)
                            dgvAttd.SelectedRows[i].Cells["night"].Value = "Y";
                    }
                }
            }  // end of for loop
        }
        private void tsmiResetOutTime_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            DBClass db = new DBClass();
            int i, intEID, hour, minute, second, intSID;
            string strSql, outTime, attDate, sOutTime, mOutTime = "";
            for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString() != "" && dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "L")
                {
                    attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                    intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                    intSID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                    strSql = "SELECT OUT_TIME FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
                    DataSet ds = db.GetDataSet(strSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sOutTime = ds.Tables[0].Rows[0]["OUT_TIME"].ToString();
                        mOutTime = sOutTime.Substring(0, 2);
                        hour = rnd.Next(Convert.ToInt32(mOutTime), Convert.ToInt32(mOutTime));
                        if (hour < Convert.ToInt32(mOutTime)) minute = rnd.Next(01, 05);
                        else minute = rnd.Next(01, 09);
                        second = rnd.Next(1, 59);
                        outTime = hour + ":" + minute + ":" + second;
                        dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                        dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = 0;
                        dgvAttd.SelectedRows[i].Cells["outTime"].Value = outTime.ToString();
                        dgvAttd.SelectedRows[i].Cells["IS_OUT_TIME"].Value = outManual(intEID, attDate);
                        if (TimeSpan.Parse(dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString()).Hours < 9)
                            dgvAttd.SelectedRows[i].Cells["night"].Value = "Y";
                    }
                }
            }  // end of for loop
        }
        private void tsmiRefreshOutTime_Click(object sender, EventArgs e)
        {
            double dblOTHr;
            Random rnd = new Random();
            DBClass db = new DBClass();
            int i, intSID, intEarlyOut;
            TimeSpan tsOTHr = new TimeSpan();
            string strSql, strOutTime, strStatus2, sOutTime, sLunchStart, sLunchEnd, attDate, strInTime = "";
            for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString() != "" && dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "L") 
                {
                    attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                    strStatus2 = dgvAttd.SelectedRows[i].Cells["status2"].Value.ToString();
                    intSID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                    strSql = "SELECT OUT_TIME,LUNCE_START,LUNCE_END FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
                    DataSet ds = db.GetDataSet(strSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                        if (TimeSpan.Parse(dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString()).Hours < 9)
                        {
                            dgvAttd.SelectedRows[i].Cells["night"].Value = "Y";
                            attDate = Convert.ToDateTime(dgvAttd.SelectedRows[i].Cells["attDate"].Value).AddDays(1).ToString("dd-MMM-yyyy");
                        }
                        strOutTime = attDate + " " + dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString();
                        sOutTime = attDate + " " + ds.Tables[0].Rows[0]["OUT_TIME"].ToString();
                        if (dgvAttd.SelectedRows[i].Cells["IS_OT_HOLDER"].Value.ToString() == "Y")
                        {
                            sLunchStart = ds.Tables[0].Rows[0]["LUNCE_START"].ToString();
                            sLunchEnd = ds.Tables[0].Rows[0]["LUNCE_END"].ToString();
                            if (strStatus2 != "W" && strStatus2 != "H") tsOTHr = DateTime.Parse(strOutTime) - DateTime.Parse(sOutTime);
                            else
                            {
                                if (dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString() != "")
                                {
                                    strInTime = attDate + " " + dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString();
                                    tsOTHr = (DateTime.Parse(strOutTime) - DateTime.Parse(strInTime)) - (DateTime.Parse(sLunchEnd) - DateTime.Parse(sLunchStart));
                                }
                                else tsOTHr = (DateTime.Parse(strOutTime) - DateTime.Parse(sOutTime)) - (DateTime.Parse(sLunchEnd) - DateTime.Parse(sLunchStart));
                            }
                            int intTimeDiff = tsOTHr.Hours * 60 + tsOTHr.Minutes;
                            if (intTimeDiff > 0)
                            {
                                intEarlyOut = 0;
                                if (tsOTHr.Minutes > 44) dblOTHr = tsOTHr.Hours + 1;
                                else if (tsOTHr.Minutes > 24) dblOTHr = tsOTHr.Hours + 0.5;
                                else dblOTHr = tsOTHr.Hours;
                            }
                            else
                            {
                                dblOTHr = 0;
                                intEarlyOut = intTimeDiff * -1;
                            }
                            dgvAttd.SelectedRows[i].Cells["overTime"].Value = dblOTHr.ToString();
                            dgvAttd.SelectedRows[i].Cells["EARLY_OUT"].Value = intEarlyOut.ToString();
                        }
                        else dgvAttd.SelectedRows[i].Cells["overTime"].Value = 0;
                        dgvAttd.SelectedRows[i].Cells["status"].Value = "P";
                        if (strStatus2 != "W" && strStatus2 != "H") dgvAttd.SelectedRows[i].Cells["status2"].Value = "P";
                    }
                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                }
            }
        }       
        private void tsmiNightYes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (TimeSpan.Parse(dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString()).Hours < 9)
                {
                    dgvAttd.Rows[i].Cells["night"].Value = "Y";
                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                    dgvAttd.SelectedRows[i].Cells["night"].Style.ForeColor = Color.Navy;
                }
            }
        }
        private void tsmiNightNo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                dgvAttd.SelectedRows[i].Cells["night"].Style.ForeColor = Color.Navy;
            }
        }

        private void tsmiEmpInfo_Click(object sender, EventArgs e)
        {
            payroll_main_form mForm = this.ParentForm as payroll_main_form;
            mForm.splitContainer1.Panel2.Controls.Clear();
            employee_Information_UC objEmpInfo = new employee_Information_UC();
            mForm.splitContainer1.Panel2.Controls.Add(objEmpInfo);
            objEmpInfo.Show();
            objEmpInfo.getExitForLastUserControlEmpInfo = 1;
            objEmpInfo.getEmpInfoDisplay(" AND E_O.EMP_CODE = '" + dgvAttd.SelectedRows[0].Cells["empCode"].Value.ToString() + "'");
            objEmpInfo.lastUserControlEmpInfo = this;
        }
        private void tsmiDeleteData_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            if (MessageBox.Show("Are you sure to delete data?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "d123")
                {
                    bool uFlag = false;
                    for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        string strQuery = "DELETE FROM ATTENDANCE_DETAILS WHERE ATTD_DATE = '" + Convert.ToDateTime(dgvAttd.SelectedRows[i].Cells["attDate"].Value).ToString("dd-MMM-yyyy") + "' AND EMP_ID = '" + Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value) + "' AND NVL(ATTD_LOCKED,'N') !='Y'";
                        if (db.RunDmlQuery(strQuery))
                        {
                            strQuery = strQuery.Replace("'", string.Empty);
                            string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','ATTENDANCE_DETAILS','" + strQuery +
                                        "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + dgvAttd.SelectedRows[i].Cells["EMPCODE"].Value.ToString() + "')";
                            uFlag = db.RunDmlQuery(strSql);
                        }
                    }
                    if (uFlag == true)
                    {
                        dgvAttd.Rows.Clear();
                        MessageBox.Show("Data Deleted Successfully");
                    } // END OF if (r == true)
                }  //if (input result == DialogResult.Yes)
            }   //if (result == DialogResult.Yes)
        }
        private void tsmiLockData_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            if (MessageBox.Show("Are you sure to lock attendance data?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                bool rFlag = false;
                frmSecurityInputBox oPwd = new frmSecurityInputBox(ref txtPassword);
                oPwd.ShowDialog();
                if (txtPassword.Text == "lk123")
                {
                    for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        string sql = "UPDATE ATTENDANCE_DETAILS SET ATTD_LOCKED='Y' WHERE  ATTD_DATE = '" + Convert.ToDateTime(dgvAttd.SelectedRows[i].Cells["attDate"].Value).ToString("dd-MMM-yyyy") + "' AND EMP_ID = '" + Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value) + "'";
                        rFlag = db.RunDmlQuery(sql);
                    }
                    if (rFlag)
                    {
                        dgvAttd.Rows.Clear();
                        MessageBox.Show("Data Locked Successfully");
                    } 
                }
                else MessageBox.Show("Mismatch Password");
            }
            dgvAttd.ReadOnly = true;
        }
        private void tsmiUnlockData_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            if (MessageBox.Show("Are you sure to Unlock attendance data?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                bool r = false;
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "lk123")
                {
                    for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        string sql = "UPDATE ATTENDANCE_DETAILS SET ATTD_LOCKED='N' WHERE STATUS !='L' AND ATTD_DATE = '" + Convert.ToDateTime(dgvAttd.SelectedRows[i].Cells["attDate"].Value).ToString("dd-MMM-yyyy") + "' AND EMP_ID = '" + Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value) + "'";
                        r = db.RunDmlQuery(sql);
                    }
                    if (r == true)
                    {
                        MessageBox.Show("Data Unlocked Successfully");
                        dgvAttd.Rows.Clear();
                    }
                }
                else MessageBox.Show("Mismatch Password");
            }
            dgvAttd.ReadOnly = false;
        }
        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            getDisplayAttDetails(generate_subQuery("C.ATTD_DATE"));
        }
        private void tsmiExportDataToExcel_Click(object sender, EventArgs e)
        {
            CConfig.getExportDataToExcel(dgvAttd,"Attendance");
            //SaveFileDialog saveFileDialogCSV = new SaveFileDialog();
            //saveFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();
            //saveFileDialogCSV.Filter = "CSV files (.csv)|*.csv|All files (.*)|*.*";
            //saveFileDialogCSV.FilterIndex = 1;
            //saveFileDialogCSV.RestoreDirectory = true;
            //if (saveFileDialogCSV.ShowDialog() == DialogResult.OK)
            //    exportfile(saveFileDialogCSV.FileName.ToString());
        }
        private void tsmiSetOnStatus_Click(object sender, EventArgs e)
        {
            string strStatus = Interaction.InputBox("Enter Attendance Status(P/A/W/H).", "Insert Status");   // get value using inputbox
            if (strStatus.Trim().Length > 0)
            {
                if (strStatus.ToString() == "P" || strStatus.ToString() == "p") tsmiSetOnMissingInTime_Click(sender, e);
                else if (strStatus.ToString() == "A" || strStatus.ToString() == "a")
                {
                    for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                        dgvAttd.SelectedRows[i].Cells["inTime"].Value = "";
                        dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                        dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                        dgvAttd.SelectedRows[i].Cells["status"].Value = "A";
                        dgvAttd.SelectedRows[i].Cells["outTime"].Value = "";
                        dgvAttd.SelectedRows[i].Cells["workHour"].Value = "0";
                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = "0";
                        dgvAttd.SelectedRows[i].Cells["status"].Style.ForeColor = Color.Red;
                        if (dgvAttd.SelectedRows[i].Cells["status2"].Value.ToString() != "W" || dgvAttd.SelectedRows[i].Cells["status2"].Value.ToString() != "H")
                            dgvAttd.SelectedRows[i].Cells["status2"].Value = "A";
                    }

                }
                else if (strStatus.ToString() == "W" || strStatus.ToString() == "w") tsmiSetWeekend_Click(sender, e);
                else if (strStatus.ToString() == "H" || strStatus.ToString() == "h") tsmiSetHoliday_Click(sender, e);
            }
            else return;
        }
        private void tsmiSetOnStatus2_Click(object sender, EventArgs e)
        {
            string strStatus = Interaction.InputBox("Enter Attendance Status(P/A/W/H).", "Insert Status");   // get value using inputbox
            if (strStatus.Trim().Length > 0)
            {
                if (strStatus.ToString() == "A" || strStatus.ToString() == "a")
                {
                    for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                        {
                            dgvAttd.SelectedRows[i].Cells["status"].Style.ForeColor = Color.Red;
                            dgvAttd.SelectedRows[i].Cells["inTime"].Value = "";
                            dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                            dgvAttd.SelectedRows[i].Cells["workHour"].Value = "0";
                            dgvAttd.SelectedRows[i].Cells["outTime"].Value = "";
                            dgvAttd.SelectedRows[i].Cells["overTime"].Value = "0";
                            dgvAttd.SelectedRows[i].Cells["status"].Value = "A";
                            dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                            dgvAttd.SelectedRows[i].Cells["status2"].Value = "A";
                            dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                        }
                    }

                }
                else if (strStatus.ToString() == "W" || strStatus.ToString() == "w") tsmiSetWeekend_Click(sender, e);
                else if (strStatus.ToString() == "H" || strStatus.ToString() == "h") tsmiSetHoliday_Click(sender, e);
                else if (strStatus.ToString() == "P" || strStatus.ToString() == "p") tsmiSetOnMissingInTime_Click(sender, e);
            }
            else return;
        }
        private void tsmiSetWeekend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                {
                    if (dgvAttd.SelectedRows[i].Cells["status"].Value.ToString().ToUpper() != "L")
                    {
                        dgvAttd.SelectedRows[i].Cells["inTime"].Value = "";
                        dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                        dgvAttd.SelectedRows[i].Cells["workHour"].Value = "0";
                        dgvAttd.SelectedRows[i].Cells["outTime"].Value = "";
                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = "0";
                        dgvAttd.SelectedRows[i].Cells["status"].Value = "W";
                        dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                        dgvAttd.SelectedRows[i].Cells["status2"].Value = "W";
                        dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                    }
                }
            }
        }

        private void tsmiRefreshWeekend_Click(object sender, EventArgs e)
        {
            if (dgvAttd.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Do you want to change the Weekend of Selected Rows ", "change the Weekend of Selected Rows", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    string strWeek = "";
                    DBClass db = new DBClass();
                    for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                        {
                            int intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                            string strStatus = dgvAttd.SelectedRows[i].Cells["STATUS"].Value.ToString();
                            string strAttDate = dgvAttd.SelectedRows[i].Cells["ATTDATE"].Value.ToString();

                            if (dgvAttd.SelectedRows[i].Cells["STATUS"].Value.ToString().ToUpper() != "L")
                            {                               
                                string strQuery = "SELECT WEEKEND FROM EMP_OFFICIAL WHERE EMP_ID='" + intEID + "'";
                                DataSet ds = db.GetDataSet(strQuery);
                                if (ds.Tables[0].Rows.Count > 0) strWeek = ds.Tables[0].Rows[0]["WEEKEND"].ToString();
                                if (DateTime.Parse(strAttDate).DayOfWeek.ToString().ToUpper() == strWeek.ToUpper())
                                {
                                    dgvAttd.SelectedRows[i].Cells["STATUS"].Value = "W";
                                    dgvAttd.SelectedRows[i].Cells["STATUS2"].Value = "W";
                                    dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                                    dgvAttd.SelectedRows[i].Cells["inTime"].Value = "";
                                    dgvAttd.SelectedRows[i].Cells["outTime"].Value = "";
                                    dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                                    dgvAttd.SelectedRows[i].Cells["overTime"].Value = "0";
                                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                                }
                                else if (dgvAttd.SelectedRows[i].Cells["STATUS2"].Value.ToString() == "W")
                                {
                                    dgvAttd.SelectedRows[i].Cells["STATUS"].Value = "P";
                                    dgvAttd.SelectedRows[i].Cells["STATUS2"].Value = "P";
                                    dgvAttd.SelectedRows[i].Cells["overTime"].Value = "0";
                                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                                }
                            }
                        }
                    }
                }
            }
            /*string strWeek = "";
            DBClass db = new DBClass();
            if (dgvAttDetails.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Do you want to change the Weekend of Selected Rows ", "change the Weekend of Selected Rows", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    for (int i = 0; i < dgvAttDetails.SelectedRows.Count; i++)
                    {

                        int intEID = Convert.ToInt32(dgvAttDetails.SelectedRows[i].Cells["EMP_ID"].Value);
                        string strStatus = dgvAttDetails.SelectedRows[i].Cells["STATUS"].Value.ToString();
                        string strAttDate = dgvAttDetails.SelectedRows[i].Cells["ATTDATE"].Value.ToString();
                        string emp_code = dgvAttDetails.SelectedRows[i].Cells["empCode"].Value.ToString();
                        string in_time = "", out_time = "", del_query = "", select_query = "";

                        select_query = @"select in_time,out_time from attendance_details where attd_date='" + strAttDate + "' and emp_id=" + intEID + "";
                        OracleDataReader dr = db.multiple_value_query(select_query);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                in_time = (dr.GetValue(0).ToString() == "") ? "" : dr.GetValue(0).ToString();
                                out_time = (dr.GetValue(1).ToString() == "") ? "" : dr.GetValue(1).ToString();
                            }
                        }
                        if (in_time == "" && out_time == "")
                        {
                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + "' ";
                            db.RunDmlQuery(del_query);
                        }
                        else if (in_time != "" && out_time == "")
                        {
                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + @"'
                                and MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(in_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am')";
                            db.RunDmlQuery(del_query);
                        }
                        else if (in_time == "" && out_time != "")
                        {
                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + @"'
                                and MOVEMENT_TIME=to_date('" + Convert.ToDateTime(out_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am')";
                            db.RunDmlQuery(del_query);
                        }
                        else
                        {
                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + @"' 
                                and MOVEMENT_TIME>=to_date('" + Convert.ToDateTime(in_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') and 
                                MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(out_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am')";
                            db.RunDmlQuery(del_query);
                        }
                        if (dgvAttDetails.SelectedRows[i].Cells["STATUS"].Value.ToString().ToUpper() != "L")
                        {
                            string strQuery = "SELECT WEEKEND FROM WEEKEND_SETUP WHERE '" + strAttDate + "' BETWEEN FROM_DATE AND TO_DATE AND EMP_ID='" + intEID + "'";
                            DataSet ds = db.get_data_set(strQuery);
                            if (ds.Tables[0].Rows.Count > 0) strWeek = ds.Tables[0].Rows[0]["WEEKEND"].ToString();
                            else
                            {
                                strQuery = "SELECT WEEKEND FROM EMP_OFFICIAL WHERE EMP_ID='" + intEID + "'";
                                ds = db.get_data_set(strQuery);
                                if (ds.Tables[0].Rows.Count > 0) strWeek = ds.Tables[0].Rows[0]["WEEKEND"].ToString();
                            }
                            if (DateTime.Parse(strAttDate).DayOfWeek.ToString().ToUpper() == strWeek.ToUpper())
                            {
                                dgvAttDetails.SelectedRows[i].Cells["STATUS"].Value = "W";
                                dgvAttDetails.SelectedRows[i].Cells["STATUS2"].Value = "W";
                                dgvAttDetails.SelectedRows[i].Cells["late"].Value = "0";
                                dgvAttDetails.SelectedRows[i].Cells["inTime"].Value = "";
                                dgvAttDetails.SelectedRows[i].Cells["outTime"].Value = "";
                                dgvAttDetails.SelectedRows[i].Cells["night"].Value = "N";
                                dgvAttDetails.SelectedRows[i].Cells["overTime"].Value = "0";
                                dgvAttDetails.SelectedRows[i].Cells["rFlag"].Value = "U";
                            }
                            else if (dgvAttDetails.SelectedRows[i].Cells["STATUS2"].Value.ToString() == "W")
                            {
                                dgvAttDetails.SelectedRows[i].Cells["STATUS"].Value = "P";
                                dgvAttDetails.SelectedRows[i].Cells["STATUS2"].Value = "P";
                                dgvAttDetails.SelectedRows[i].Cells["overTime"].Value = "0";
                                dgvAttDetails.SelectedRows[i].Cells["rFlag"].Value = "U";
                            }
                        }
                    }
                }
            }*/
        }

        private void tsmiLockByDate_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            if (MessageBox.Show("Are you sure to lock attendance data?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "lk123")
                {
                    string sql = "UPDATE ATTENDANCE_DETAILS SET ATTD_LOCKED='Y' WHERE ATTD_LOCKED!='Y' AND ATTD_DATE BETWEEN'" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";
                    if (db.RunDmlQuery(sql))
                    {
                        MessageBox.Show("Data Locked Successfully");
                        dgvAttd.Rows.Clear();
                    }
                }
                else MessageBox.Show("Mismatch Password");
            }
            dgvAttd.ReadOnly = true;
        }

        private void tsmiUnlockByDate_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            if (MessageBox.Show("Are you sure to Unlock attendance data?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "lk123")
                {
                    string sql = "UPDATE ATTENDANCE_DETAILS SET ATTD_LOCKED='N' WHERE ATTD_LOCKED='Y' AND STATUS !='L' AND ATTD_DATE BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'";
                    if (db.RunDmlQuery(sql))
                    {
                        MessageBox.Show("Data Unlocked Successfully");
                        dgvAttd.Rows.Clear();
                    }
                }
                else MessageBox.Show("Mismatch Password");
            }
            dgvAttd.ReadOnly = false;
        }
        private void dgvAttDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Random rnd = new Random();
                DBClass db = new DBClass();
                string strSql, strAttdRemarks = "";
                string strOTHr = dgvAttd.Rows[e.RowIndex].Cells["overTime"].Value.ToString();
                string strStatus = dgvAttd.Rows[e.RowIndex].Cells["status"].Value.ToString().Trim();
                string strNight = dgvAttd.Rows[e.RowIndex].Cells["night"].Value.ToString();
                string strInTime = dgvAttd.Rows[e.RowIndex].Cells["inTime"].Value.ToString();
                string strOutTime = dgvAttd.Rows[e.RowIndex].Cells["outTime"].Value.ToString();
                string strWkHr = dgvAttd.Rows[e.RowIndex].Cells["workHour"].Value.ToString();
                string emp_code = dgvAttd.Rows[e.RowIndex].Cells["empCode"].Value.ToString();
                int intEID = Convert.ToInt32(dgvAttd.Rows[e.RowIndex].Cells["EMP_ID"].Value);
                string strAttDate = dgvAttd.Rows[e.RowIndex].Cells["attDate"].Value.ToString();
                int intSID = Convert.ToInt32(dgvAttd.Rows[e.RowIndex].Cells["shift_id"].Value);
                string strLock = dgvAttd.Rows[e.RowIndex].Cells["ATTD_LOCK"].Value.ToString().ToUpper();

                if (strLock == "N")
                {
                    #region =========================================
                    if (strStatus.ToUpper() != "L")
                    {
                        if (e.ColumnIndex == status.Index)
                        {
                            if (strStatus.ToUpper() == "A")
                            {
                                /*string in_time = "", out_time = "", del_query = "", select_query="";
                            
                                select_query = @"select in_time,out_time from attendance_details where attd_date='" + strAttDate + "' and emp_id=" + intEID + "";
                                OracleDataReader dr = db.multiple_value_query(select_query);
                                if(dr.HasRows)
                                {
                                    while(dr.Read())
                                    {
                                        in_time = (dr.GetValue(0).ToString() == "") ? "" : dr.GetValue(0).ToString();
                                        out_time = (dr.GetValue(1).ToString() == "") ? "" : dr.GetValue(1).ToString();
                                    }
                                }
                                if (in_time == "" && out_time=="")
                                {
                                    del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + "' ";
                                    db.RunDmlQuery(del_query);
                                }
                                else if (in_time != "" && out_time == "")
                                {
                                    del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + @"'
                                    and MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(in_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am')";
                                    db.RunDmlQuery(del_query);
                                }
                                else if (in_time == "" && out_time != "")
                                {
                                    del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + @"'
                                    and MOVEMENT_TIME=to_date('" + Convert.ToDateTime(out_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am')";
                                    db.RunDmlQuery(del_query);
                                }
                                else
                                {
                                    del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + @"' 
                                    and MOVEMENT_TIME>=to_date('" + Convert.ToDateTime(in_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') and 
                                    MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(out_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am')";
                                    db.RunDmlQuery(del_query);
                                }*/
                                dgvAttd.Rows[e.RowIndex].Cells["status"].Style.ForeColor = Color.Red;
                                dgvAttd.Rows[e.RowIndex].Cells["inTime"].Value = "";
                                dgvAttd.Rows[e.RowIndex].Cells["late"].Value = "0";
                                dgvAttd.Rows[e.RowIndex].Cells["workHour"].Value = "0";
                                dgvAttd.Rows[e.RowIndex].Cells["outTime"].Value = "";
                                dgvAttd.Rows[e.RowIndex].Cells["overTime"].Value = "0";
                                dgvAttd.Rows[e.RowIndex].Cells["night"].Value = "N";
                                dgvAttd.Rows[e.RowIndex].Cells["rFlag"].Value = "U";
                                if (dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString() != "W" || dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString() != "H")
                                    dgvAttd.Rows[e.RowIndex].Cells["status2"].Value = "A";
                            }
                            else if (strStatus.ToUpper() == "W" || strStatus.ToUpper() == "H")
                            {
                                dgvAttd.Rows[e.RowIndex].Cells["status"].Style.ForeColor = Color.Maroon;
                                dgvAttd.Rows[e.RowIndex].Cells["inTime"].Value = "";
                                dgvAttd.Rows[e.RowIndex].Cells["late"].Value = "0";
                                dgvAttd.Rows[e.RowIndex].Cells["workHour"].Value = "0";
                                dgvAttd.Rows[e.RowIndex].Cells["outTime"].Value = "";
                                dgvAttd.Rows[e.RowIndex].Cells["overTime"].Value = "0";
                                dgvAttd.Rows[e.RowIndex].Cells["night"].Value = "N";
                                dgvAttd.Rows[e.RowIndex].Cells["status2"].Value = strStatus;
                                dgvAttd.Rows[e.RowIndex].Cells["rFlag"].Value = "U";//for Flag
                            }
                            else if (strStatus.ToUpper() == "P")
                            {
                                int hour, minute, second;
                                string in_time, in_time_m, in_time_sub = "";
                                strSql = "SELECT S.IN_TIME, A.IN_TIME AS INTIME FROM SHIFT_INFO S,ATTENDANCE_DETAILS A WHERE S.SHIFT_ID=A.SHIFT_ID AND S.SHIFT_ID= '" + intSID + "' AND A.EMP_ID='" + intEID + "' AND A.ATTD_DATE='" + strAttDate + "'";
                                OracleDataReader dr = db.GetExecuteReader(strSql);
                                while (dr.Read())
                                {
                                    in_time_m = dr["in_time"].ToString();
                                    in_time_sub = in_time_m.Substring(0, 2);   // Substring two digit form in-time 
                                    hour = rnd.Next(Convert.ToInt32(in_time_sub) - 1, Convert.ToInt32(in_time_sub));   // random generate number 
                                    if (hour < Convert.ToInt32(in_time_sub)) minute = rnd.Next(55, 59);
                                    else minute = rnd.Next(1, 5);                      // random number genarate between 1 to 5
                                    second = rnd.Next(1, 59);
                                    in_time = hour + ":" + minute + ":" + second;     // concatenate hour,minute and second
                                    dgvAttd.Rows[e.RowIndex].Cells["inTime"].Value = in_time.ToString();
                                    if (dr["inTime"] == DBNull.Value) dgvAttd.Rows[e.RowIndex].Cells["IS_IN_TIME"].Value = 1;
                                }
                                dr.Close();
                                dgvAttd.Rows[e.RowIndex].Cells["late"].Value = "0";
                                dgvAttd.Rows[e.RowIndex].Cells["status"].Value = "P";    // set status = P 
                                dgvAttd.Rows[e.RowIndex].Cells["rFlag"].Value = "U"; // for Flag
                                dgvAttd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                                dgvAttd.Rows[e.RowIndex].Cells["night"].Value = "N";
                                if (dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString().ToUpper() != "W" || dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString().ToUpper() != "H")
                                    dgvAttd.Rows[e.RowIndex].Cells["status2"].Value = "P";   // set sts2 = p
                            }
                            else return;
                        }
                        else if (e.ColumnIndex == night.Index)
                        {
                            if (strNight.ToUpper() == "Y" || strNight.ToUpper() == "N")
                            {
                                if (dgvAttd.Rows[e.RowIndex].Cells["inTime"].Value.ToString().Length > 0 && dgvAttd.Rows[e.RowIndex].Cells["outTime"].Value.ToString().Length > 0)
                                {
                                    dgvAttd.Rows[e.RowIndex].Cells["night"].Style.ForeColor = Color.Navy;
                                    dgvAttd.Rows[e.RowIndex].Cells["night"].Value = strNight.ToUpper();
                                    dgvAttd.Rows[e.RowIndex].Cells["rFlag"].Value = "U";
                                }
                            }
                            else return;
                        }
                        else if (e.ColumnIndex == overTime.Index)
                        {
                            if (strOTHr.Trim().Length > 0)
                            {
                                if (strInTime.Trim().Length > 0 && strStatus != "L")
                                {
                                    double dblOTHr;
                                    TimeSpan tsOTHr = new TimeSpan();
                                    string strSftOutTime, sLunchStart, sLunchEnd;
                                    string strStatus2 = dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString();
                                    strSql = "SELECT OUT_TIME,LUNCE_START,LUNCE_END,OUT_TIME_FROM FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
                                    DataSet ds = db.GetDataSet(strSql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        int intEarlyOut, intRndm = rnd.Next(-100, 650);
                                        dgvAttd.Rows[e.RowIndex].Cells["night"].Value = "N";
                                        strSftOutTime = strAttDate + " " + ds.Tables[0].Rows[0]["OUT_TIME"].ToString();
                                        int intOTHrs = Convert.ToInt32(dgvAttd.Rows[e.RowIndex].Cells["overTime"].Value);
                                        strOutTime = DateTime.Parse(strSftOutTime).AddHours((double)intOTHrs).AddSeconds((double)intRndm).ToString("HH:mm:ss");
                                        strInTime = strAttDate + " " + dgvAttd.Rows[e.RowIndex].Cells["inTime"].Value.ToString();
                                        dgvAttd.Rows[e.RowIndex].Cells["outTime"].Value = strOutTime.ToString();
                                        //if (TimeSpan.Parse(strOutTime.ToString()).Hours < 9)
                                        if (TimeSpan.Parse(strOutTime.ToString()).Hours <= TimeSpan.Parse(ds.Tables[0].Rows[0]["OUT_TIME_FROM"].ToString()).Hours)
                                        {
                                            dgvAttd.Rows[e.RowIndex].Cells["night"].Value = "Y";
                                            strAttDate = Convert.ToDateTime(dgvAttd.Rows[e.RowIndex].Cells["attDate"].Value).AddDays(1).ToString("dd-MMM-yyyy");
                                        }
                                        strOutTime = strAttDate + " " + strOutTime.ToString();
                                        sLunchEnd = ds.Tables[0].Rows[0]["LUNCE_END"].ToString();
                                        sLunchStart = ds.Tables[0].Rows[0]["LUNCE_START"].ToString();
                                        if (strStatus2 != "W" && strStatus2 != "H") tsOTHr = DateTime.Parse(strOutTime) - DateTime.Parse(strSftOutTime);
                                        else tsOTHr = (DateTime.Parse(strOutTime) - DateTime.Parse(strInTime)) - (DateTime.Parse(sLunchEnd) - DateTime.Parse(sLunchStart));
                                        int intTimeDiff = tsOTHr.Hours * 60 + tsOTHr.Minutes;
                                        if (intTimeDiff > 0)
                                        {
                                            intEarlyOut = 0;
                                            if (tsOTHr.Minutes > 44) dblOTHr = tsOTHr.Hours + 1;
                                            else if (tsOTHr.Minutes > 24) dblOTHr = tsOTHr.Hours + 0.5;
                                            else dblOTHr = tsOTHr.Hours;
                                        }
                                        else
                                        {
                                            dblOTHr = 0;
                                            intEarlyOut = intTimeDiff * -1;
                                        }
                                        if (dgvAttd.Rows[e.RowIndex].Cells["IS_OT_HOLDER"].Value.ToString() == "Y")
                                        {
                                            dgvAttd.Rows[e.RowIndex].Cells["EARLY_OUT"].Value = 0;
                                            dgvAttd.Rows[e.RowIndex].Cells["overTime"].Value = dblOTHr.ToString();
                                        }
                                        else
                                        {
                                            dgvAttd.Rows[e.RowIndex].Cells["overTime"].Value = 0;
                                            dgvAttd.Rows[e.RowIndex].Cells["EARLY_OUT"].Value = intEarlyOut.ToString();
                                        }
                                    }
                                    dgvAttd.Rows[e.RowIndex].Cells["rFlag"].Value = "U";
                                    dgvAttd.Rows[e.RowIndex].Cells["overTime"].Style.ForeColor = Color.Blue;
                                }
                                else return;
                            }
                            else return;
                        }
                        else if (e.ColumnIndex == workHour.Index)
                        {
                            if (strWkHr.Trim().Length > 0)
                            {
                                if (strInTime.Trim().Length > 0 && strStatus != "L")
                                {
                                    double dblOTHr;
                                    TimeSpan tsOTHr = new TimeSpan();
                                    string strSftOutTime, sLunchStart, sLunchEnd;
                                    string strStatus2 = dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString();
                                    strSql = "SELECT OUT_TIME,LUNCE_START,LUNCE_END,OUT_TIME_FROM FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
                                    DataSet ds = db.GetDataSet(strSql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        int intEarlyOut, intRndm = rnd.Next(-100, 650);
                                        dgvAttd.Rows[e.RowIndex].Cells["night"].Value = "N";
                                        strSftOutTime = strAttDate + " " + ds.Tables[0].Rows[0]["OUT_TIME"].ToString();
                                        int intWkHrs = Convert.ToInt32(dgvAttd.Rows[e.RowIndex].Cells["workHour"].Value) - 8;
                                        strOutTime = DateTime.Parse(strSftOutTime).AddHours((double)intWkHrs).AddSeconds((double)intRndm).ToString("HH:mm:ss");
                                        strInTime = strAttDate + " " + dgvAttd.Rows[e.RowIndex].Cells["inTime"].Value.ToString();
                                        dgvAttd.Rows[e.RowIndex].Cells["outTime"].Value = strOutTime.ToString();
                                        // (TimeSpan.Parse(strOutTime.ToString()).Hours < 9)
                                        if (TimeSpan.Parse(strOutTime.ToString()).Hours <= TimeSpan.Parse(ds.Tables[0].Rows[0]["OUT_TIME_FROM"].ToString()).Hours)
                                        {
                                            dgvAttd.Rows[e.RowIndex].Cells["night"].Value = "Y";
                                            strAttDate = Convert.ToDateTime(dgvAttd.Rows[e.RowIndex].Cells["attDate"].Value).AddDays(1).ToString("dd-MMM-yyyy");
                                        }
                                        strOutTime = strAttDate + " " + strOutTime.ToString();
                                        sLunchEnd = ds.Tables[0].Rows[0]["LUNCE_END"].ToString();
                                        sLunchStart = ds.Tables[0].Rows[0]["LUNCE_START"].ToString();
                                        if (strStatus2 != "W" && strStatus2 != "H") tsOTHr = DateTime.Parse(strOutTime) - DateTime.Parse(strSftOutTime);
                                        else tsOTHr = (DateTime.Parse(strOutTime) - DateTime.Parse(strInTime)) - (DateTime.Parse(sLunchEnd) - DateTime.Parse(sLunchStart));
                                        int intTimeDiff = tsOTHr.Hours * 60 + tsOTHr.Minutes;
                                        if (intTimeDiff > 0)
                                        {
                                            intEarlyOut = 0;
                                            if (tsOTHr.Minutes > 44) dblOTHr = tsOTHr.Hours + 1;
                                            else if (tsOTHr.Minutes > 24) dblOTHr = tsOTHr.Hours + 0.5;
                                            else dblOTHr = tsOTHr.Hours;
                                        }
                                        else
                                        {
                                            dblOTHr = 0;
                                            intEarlyOut = intTimeDiff * -1;
                                        }
                                        if (dgvAttd.Rows[e.RowIndex].Cells["IS_OT_HOLDER"].Value.ToString() == "Y")
                                        {
                                            dgvAttd.Rows[e.RowIndex].Cells["EARLY_OUT"].Value = 0;
                                            dgvAttd.Rows[e.RowIndex].Cells["overTime"].Value = dblOTHr.ToString();
                                        }
                                        else
                                        {
                                            dgvAttd.Rows[e.RowIndex].Cells["overTime"].Value = 0;
                                            dgvAttd.Rows[e.RowIndex].Cells["EARLY_OUT"].Value = intEarlyOut.ToString();
                                        }
                                    }
                                    dgvAttd.Rows[e.RowIndex].Cells["rFlag"].Value = "U";
                                    dgvAttd.Rows[e.RowIndex].Cells["workHour"].Style.ForeColor = Color.Blue;
                                }
                                else return;
                            }
                            else return;
                        }
                        else if (e.ColumnIndex == remarks.Index)
                        {
                            if (strAttdRemarks != "" || strAttdRemarks != null)
                            {
                                dgvAttd.Rows[e.RowIndex].Cells["remarks"].Value = strAttdRemarks;
                                dgvAttd.Rows[e.RowIndex].Cells["rFlag"].Value = "U";//for Flag
                            }
                            else return;
                        }
                        else if (e.ColumnIndex == inTime.Index)
                        {
                            if (strInTime != null && strInTime != "")
                            {
                                dgvAttd.Rows[e.RowIndex].Cells["inTime"].Value = strInTime.ToString();
                                dgvAttd.Rows[e.RowIndex].Cells["outTime"].Value = strOutTime.ToString();
                                dgvAttd.Rows[e.RowIndex].Cells["status"].Value = "P";    // set status = P 
                                dgvAttd.Rows[e.RowIndex].Cells["rFlag"].Value = "U"; // for Flag
                                dgvAttd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                                if (dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString().ToUpper() != "W" || dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString().ToUpper() != "H")
                                    dgvAttd.Rows[e.RowIndex].Cells["status2"].Value = "P";
                            }
                            else return;

                            /*int shift_id;
                            string emp_id = "", attd_date = "", shift_grace = "", in_time = "", del_query = "", insert_query = "", machine_no = "", update_query = "", select_query = "", select_query2 = "";
                            DateTime in_time_convert = new DateTime();
                            TimeSpan in_time_time = new TimeSpan();
                            DateTime out_time_actual = new DateTime();
                            DateTime calculate_date1 = new DateTime();
                            DateTime calculate_date2 = new DateTime();
                            DateTime shift_in_time = new DateTime();
                            DateTime lunch_start = new DateTime();
                            DateTime lunch_end = new DateTime();
                            TimeSpan time_calculation = new TimeSpan();
                            TimeSpan time_lunch_calculation = new TimeSpan();
                            TimeSpan late_calculation = new TimeSpan();
                            int late = 0;
                            int work_hour_time_calculation = 0;
                            int lunch_calculation = 0;
                            int work_hour_with_munite = 0;
                            int work_hour = 0;
                            int work_munite = 0;

                            int work_limit = 8;
                            double work_time_cal = 0.0, over_time = 0.0;
                            if (strOutTime != null && strOutTime != "")
                            {
                                attd_date = dgvAttDetails.Rows[e.RowIndex].Cells["attDate"].Value.ToString();
                                in_time = dgvAttDetails.Rows[e.RowIndex].Cells["inTime"].Value.ToString();
                                shift_id = Convert.ToInt32(dgvAttDetails.Rows[e.RowIndex].Cells["shift_id"].Value);
                                in_time_time = (TimeSpan)Convert.ToDateTime(in_time).TimeOfDay;
                                select_query = @"select a_d.in_time,a_d.out_time,s_i.grace,s_i.in_time,S_I.lunce_start,S_I.lunce_end,a_d.emp_id from attendance_details a_d, shift_info s_i where a_d.shift_id=s_i.shift_id and  attd_date='" + attd_date + "' and a_d.shift_id=" + shift_id + " and emp_id in (select emp_id from emp_official where emp_code='" + emp_code + "')";
                                OracleDataReader dr = db.multiple_value_query(select_query);
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        out_time_actual = Convert.ToDateTime(dr.GetValue(1));
                                        shift_grace = dr.GetValue(2).ToString();
                                        shift_in_time = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(3) + ":00").AddMinutes(Convert.ToDouble(shift_grace.Substring(0, shift_grace.IndexOf(':'))));
                                        lunch_start = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(4) + ":00");
                                        lunch_end = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(5) + ":00");
                                        emp_id = dr.GetValue(6).ToString();
                                        time_lunch_calculation = lunch_end - lunch_start;
                                        lunch_calculation = time_lunch_calculation.Hours * 60 + time_lunch_calculation.Minutes;
                                    }
                                }
                                in_time_convert = Convert.ToDateTime(attd_date + ' ' + in_time_time);
                                select_query2 = @"select distinct MACHINE_NO from employee_movement_register where emp_code='" + emp_code + "' and movement_time<=to_date('" + out_time_actual.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am')";
                                OracleDataReader data = db.multiple_value_query(select_query2);
                                if (data.HasRows)
                                {
                                    while (data.Read())
                                    {
                                        machine_no = data.GetValue(0).ToString();
                                    }
                                }
                                del_query = @"delete employee_movement_register where emp_code='" + emp_code + "' and machine_no='" + machine_no + "' and  movement_time<=to_date('" + in_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am')";
                                db.RunDmlQuery(del_query);
                                insert_query = @"insert into employee_movement_register(emp_code,attd_date,machine_no,movement_time) values('" + emp_code + "','" + Convert.ToDateTime(attd_date).ToString("dd-MMM-yyyy") + "'," + machine_no + ",to_date('" + in_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am'))";
                                db.RunDmlQuery(insert_query);
                                string query = @"select emp_code,movement_time from employee_movement_register where emp_code='" + emp_code + @"'  
                                and MOVEMENT_TIME>=to_date('" + in_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') and 
                                    MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(out_time_actual).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am')
                                order by movement_time asc";
                                DataSet ds = db.get_data_set(query);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                                    {
                                        calculate_date1 = Convert.ToDateTime(ds.Tables[0].Rows[i + 1]["MOVEMENT_TIME"]);
                                        calculate_date2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["MOVEMENT_TIME"]);
                                        time_calculation = calculate_date1 - calculate_date2;
                                        work_hour_time_calculation += time_calculation.Hours * 60 + time_calculation.Minutes;
                                    }
                                }

                                if (work_hour_time_calculation > 0)
                                {
                                    work_hour_with_munite = work_hour_time_calculation - lunch_calculation;
                                    work_hour = work_hour_with_munite / 60;
                                    work_munite = work_hour_with_munite % 60;
                                    if (work_munite > 44) work_time_cal = work_hour + 1;
                                    else if (work_munite > 24) work_time_cal = work_hour + 0.5;
                                    else work_time_cal = work_hour;
                                    if (work_time_cal > work_limit)
                                    {
                                        over_time = work_time_cal - work_limit;
                                    }
                                }
                                else
                                {
                                    work_time_cal = 0;
                                    over_time = 0;
                                }
                                if (in_time_convert > shift_in_time)
                                {
                                    late_calculation = in_time_convert - shift_in_time;
                                    late = late_calculation.Minutes;
                                }
                                else
                                {
                                    late = 0;
                                }
                                update_query = @"update attendance_details set work_hour=" + work_time_cal + ",IN_TIME=to_date('" + Convert.ToDateTime(in_time_convert).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh12:mi:ss am'),
                                                 late=" + late + ",over_time=" + over_time + " where emp_id=" + emp_id + " and attd_date='" + attd_date + "' and NVL(attd_locked,'N')!='Y'";
                                db.RunDmlQuery(update_query);
                            }*/
                        }

                        else if (e.ColumnIndex == outTime.Index)
                        {
                            if (strOutTime != null && strOutTime != "")
                            {
                                dgvAttd.Rows[e.RowIndex].Cells["inTime"].Value = strInTime.ToString();
                                dgvAttd.Rows[e.RowIndex].Cells["outTime"].Value = strOutTime.ToString();
                                if (TimeSpan.Parse(dgvAttd.Rows[e.RowIndex].Cells["outTime"].Value.ToString()).Hours <= 9)
                                    dgvAttd.Rows[e.RowIndex].Cells["night"].Value = "Y";
                                else dgvAttd.Rows[e.RowIndex].Cells["night"].Value = "N";
                                dgvAttd.Rows[e.RowIndex].Cells["status"].Value = "P";    // set status = P 
                                dgvAttd.Rows[e.RowIndex].Cells["rFlag"].Value = "U"; // for Flag
                                dgvAttd.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                                if (dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString().ToUpper() != "W" || dgvAttd.Rows[e.RowIndex].Cells["status2"].Value.ToString().ToUpper() != "H")
                                    dgvAttd.Rows[e.RowIndex].Cells["status2"].Value = "P";
                            }
                            else return;

                            /*int shift_id;
                            string emp_id = "", attd_date = "", out_time = "", del_query = "", insert_query = "", machine_no = "", update_query = "", select_query = "", select_query2 = "";
                            DateTime out_time_convert = new DateTime();
                            TimeSpan out_time_time = new TimeSpan();
                            DateTime in_time_actual = new DateTime();
                            DateTime calculate_date1 = new DateTime();
                            DateTime calculate_date2 = new DateTime();
                            DateTime lunch_start = new DateTime();
                            DateTime lunch_end = new DateTime();
                            TimeSpan time_calculation = new TimeSpan();
                            TimeSpan time_lunch_calculation = new TimeSpan();
                            int work_hour_time_calculation = 0;
                            int lunch_calculation = 0;
                            int work_hour_with_munite = 0;
                            int work_hour = 0;
                            int work_munite = 0;

                            int work_limit = 8;
                            double work_time_cal = 0.0, over_time = 0.0;
                            if (strInTime != null && strInTime != "")
                            {
                                attd_date = dgvAttDetails.Rows[e.RowIndex].Cells["attDate"].Value.ToString();
                                out_time = dgvAttDetails.Rows[e.RowIndex].Cells["outTime"].Value.ToString();
                                shift_id = Convert.ToInt32(dgvAttDetails.Rows[e.RowIndex].Cells["shift_id"].Value);
                                out_time_time = (TimeSpan)Convert.ToDateTime(out_time).TimeOfDay;
                                select_query = @"select a_d.in_time,a_d.out_time,S_I.lunce_start,S_I.lunce_end,a_d.emp_id from attendance_details a_d, shift_info s_i where a_d.shift_id=s_i.shift_id and  attd_date='" + attd_date + "' and a_d.shift_id=" + shift_id + " and emp_id in (select emp_id from emp_official where emp_code='" + emp_code + "')";
                                OracleDataReader dr = db.multiple_value_query(select_query);
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        in_time_actual = Convert.ToDateTime(dr.GetValue(0));
                                        lunch_start = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(2) + ":00");
                                        lunch_end = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(3) + ":00");
                                        emp_id = dr.GetValue(4).ToString();
                                        time_lunch_calculation = lunch_end - lunch_start;
                                        lunch_calculation = time_lunch_calculation.Hours * 60 + time_lunch_calculation.Minutes;
                                    }
                                }
                                if ((out_time_time.Hours == 0 || out_time_time.Hours < 12) && out_time_time.Minutes > 0 && out_time_time.Seconds > 0)
                                {
                                    out_time_convert = Convert.ToDateTime(in_time_actual.AddDays(1).ToString("dd-MMM-yyyy") + ' ' + out_time_time);
                                }
                                else
                                {
                                    out_time_convert = Convert.ToDateTime(in_time_actual.ToString("dd-MMM-yyyy") + ' ' + out_time_time);
                                }
                                select_query2 = @"select distinct MACHINE_NO from employee_movement_register where emp_code='" + emp_code + "' and movement_time>to_date('" + in_time_actual.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') ";
                                OracleDataReader data = db.multiple_value_query(select_query2);
                                if (data.HasRows)
                                {
                                    while (data.Read())
                                    {
                                        machine_no = data.GetValue(0).ToString();
                                    }
                                }
                                del_query = @"delete employee_movement_register where emp_code='" + emp_code + "' and machine_no='" + machine_no + "' and movement_time between to_date('" + out_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') and to_date('" + out_time_convert.AddHours(3).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') ";
                                db.RunDmlQuery(del_query);
                                insert_query = @"insert into employee_movement_register(emp_code,attd_date,machine_no,movement_time) values('" + emp_code + "','" + Convert.ToDateTime(attd_date).ToString("dd-MMM-yyyy") + "'," + machine_no + ",to_date('" + out_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am'))";
                                db.RunDmlQuery(insert_query);
                                string query = @"select emp_code,movement_time from employee_movement_register where emp_code='" + emp_code + @"' and MOVEMENT_TIME>=to_date('" + in_time_actual.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') and 
                                    MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(out_time_convert).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am')
                                order by movement_time asc";
                                DataSet ds = db.get_data_set(query);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                                    {
                                        calculate_date1 = Convert.ToDateTime(ds.Tables[0].Rows[i + 1]["MOVEMENT_TIME"]);
                                        calculate_date2 = Convert.ToDateTime(ds.Tables[0].Rows[i]["MOVEMENT_TIME"]);
                                        time_calculation = calculate_date1 - calculate_date2;
                                        work_hour_time_calculation += time_calculation.Hours * 60 + time_calculation.Minutes;
                                    }
                                }

                                if (work_hour_time_calculation > 0)
                                {
                                    work_hour_with_munite = work_hour_time_calculation - lunch_calculation;
                                    work_hour = work_hour_with_munite / 60;
                                    work_munite = work_hour_with_munite % 60;
                                    if (work_munite > 44) work_time_cal = work_hour + 1;
                                    else if (work_munite > 24) work_time_cal = work_hour + 0.5;
                                    else work_time_cal = work_hour;
                                    if (work_time_cal > work_limit)
                                    {
                                        over_time = work_time_cal - work_limit;
                                    }
                                }
                                else
                                {
                                    work_time_cal = 0;
                                    over_time = 0;
                                }

                                update_query = @"update attendance_details set work_hour=" + work_time_cal + ",OUT_TIME=to_date('" + Convert.ToDateTime(out_time_convert).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh12:mi:ss am'),
                                                 over_time=" + over_time + " where emp_id=" + emp_id + " and attd_date='" + attd_date + "' and NVL(attd_locked,'N')!='Y'";
                                db.RunDmlQuery(update_query);
                            }*/
                        }
                    }
                    else MessageBox.Show("Invalied Operation.\nHere " + dgvAttd.Rows[e.RowIndex].Cells["remarks"].Value.ToString() + " Leave Found, Please Sure to Update Your Data.", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    #endregion
                }
            }
        }
        
        private void tsmiLeaveUnlock_Click(object sender, EventArgs e)
        {
            bool uFlag = false;
            DBClass db = new DBClass();
            if (MessageBox.Show("Are you sure to Unlock Leave?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "lk123")
                {
                    for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        string strSql = "UPDATE ATTENDANCE_DETAILS SET ATTD_LOCKED='N' WHERE STATUS ='L' AND ATTD_DATE = '" + Convert.ToDateTime(dgvAttd.SelectedRows[i].Cells["attDate"].Value).ToString("dd-MMM-yyyy") + "' AND EMP_ID = '" + Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value) + "'";
                        uFlag = db.RunDmlQuery(strSql);
                    }
                    if (uFlag == true)
                    {
                        MessageBox.Show("Leave Unlocked Successfully");
                        dgvAttd.Rows.Clear();
                    }
                }
                else MessageBox.Show("Invalied Securit.y Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            dgvAttd.ReadOnly = false;
        }
        private void tsmiRetriveAttendance_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want to Rectify The Attendance From Salary Sheet", "Rectify the attendance from salary", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "r123") getAttendanceFromSalarySheet();
                else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Action Canceled");
        }
        private void getAttendanceFromSalarySheet()
        {
            int i, intEID, intIndex;
            DBClass db = new DBClass();
            DateTime dtAttDate = default(DateTime);
            string strQuery, strAttDate, strINOUT, strIN, strOUT = "";
            for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                strAttDate = dgvAttd.SelectedRows[i].Cells["ATTDATE"].Value.ToString();
                intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                dtAttDate = DateTime.Parse(strAttDate);
                strQuery = "SELECT IN_TIME" + dtAttDate.Day + " AS IN_TIME FROM SALARY WHERE EMP_ID='" + intEID + "' AND SALARY_FOR='01-" + dtAttDate.Date.ToString("MMM-yyyy") + "'";
                DataSet ds = db.GetDataSet(strQuery);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["IN_TIME"] != DBNull.Value)
                    {
                        strINOUT = ds.Tables[0].Rows[0]["IN_TIME"].ToString();
                        if (strINOUT.Contains(Environment.NewLine))
                        {
                            intIndex = strINOUT.IndexOf(Environment.NewLine);
                            strIN = strINOUT.Substring(0, intIndex + 1);
                            strOUT = strINOUT.Substring(intIndex + 2);
                            if (strIN.Contains("-"))
                            {
                                intIndex = strIN.IndexOf("-");
                                strIN = strIN.Substring(0, intIndex).Trim();
                            }
                            dgvAttd.SelectedRows[i].Cells["INTIME"].Value = strIN.ToString();
                            if (strOUT.Contains("-"))
                            {
                                intIndex = strOUT.IndexOf("-");
                                strOUT = strOUT.Substring(0, intIndex).Trim();
                            }
                            dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                            dgvAttd.SelectedRows[i].Cells["OUTTIME"].Value = strOUT.ToString();
                        }
                    }
                }
            }
        }
        private void tsmiSetHoliday_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["status"].Value.ToString().ToUpper() != "L")
                {
                    dgvAttd.SelectedRows[i].Cells["inTime"].Value = "";
                    dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                    dgvAttd.SelectedRows[i].Cells["workHour"].Value = "0";
                    dgvAttd.SelectedRows[i].Cells["outTime"].Value = "";
                    dgvAttd.SelectedRows[i].Cells["overTime"].Value = "0";
                    dgvAttd.SelectedRows[i].Cells["status"].Value = "H";
                    dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                    dgvAttd.SelectedRows[i].Cells["status2"].Value = "H";
                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                    dgvAttd.SelectedRows[i].Cells["status"].Style.ForeColor = Color.Maroon;
                }
            }
        }
        private void tsmiRefreshHoliday_Click(object sender, EventArgs e)
        {
            string strQuery = "";
            DBClass db = new DBClass();
            DataSet ds = new DataSet();
            if (dgvAttd.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Do you want to change the Weekend of Selected Rows ", "change the Weekend of Selected Rows", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        string strStatus = dgvAttd.SelectedRows[i].Cells["STATUS"].Value.ToString();
                        int intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                        string strAttDate = dgvAttd.SelectedRows[i].Cells["ATTDATE"].Value.ToString();
                        if (dgvAttd.SelectedRows[i].Cells["STATUS"].Value.ToString().ToUpper() != "L")
                        {
                            strQuery = "SELECT TYPE FROM HOLIDAY WHERE DT = '" + strAttDate + "'";
                            ds = db.GetDataSet(strQuery);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                dgvAttd.SelectedRows[i].Cells["STATUS"].Value = "H";
                                dgvAttd.SelectedRows[i].Cells["STATUS2"].Value = "H";
                                dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                                dgvAttd.SelectedRows[i].Cells["inTime"].Value = "";
                                dgvAttd.SelectedRows[i].Cells["outTime"].Value = "";
                                dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                                dgvAttd.SelectedRows[i].Cells["overTime"].Value = "0";
                                dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                            }
                            else if (dgvAttd.SelectedRows[i].Cells["STATUS2"].Value.ToString() == "H")
                            {
                                dgvAttd.SelectedRows[i].Cells["STATUS"].Value = "P";
                                dgvAttd.SelectedRows[i].Cells["STATUS2"].Value = "P";
                                dgvAttd.SelectedRows[i].Cells["overTime"].Value = "0";
                                dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                            }
                        }
                    }
                }
            }
        }
        private void tsmiSetOnMissingInOut_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            DBClass db = new DBClass();
            int i, hour, minute, second, intEID, intSID;
            string strSql, attDate, inTime, outTime, sInTime, mInTime, sOutTime, mOutTime = "";
            for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                intSID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                strSql = "SELECT IN_TIME,OUT_TIME FROM SHIFT_INFO WHERE SHIFT_ID ='" + intSID + "'";
                DataSet ds = db.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // ================ Set In Time =======================
                    sInTime = ds.Tables[0].Rows[0]["IN_TIME"].ToString();
                    mInTime = sInTime.Substring(0, 2);
                    hour = rnd.Next(Convert.ToInt32(mInTime) - 1, Convert.ToInt32(mInTime));
                    if (hour < Convert.ToInt32(mInTime)) minute = rnd.Next(50, 59);
                    else minute = rnd.Next(01, 05);
                    second = rnd.Next(1, 59);
                    inTime = hour + ":" + minute + ":" + second;

                    // ================ Set Out Time =======================
                    sOutTime = ds.Tables[0].Rows[0]["OUT_TIME"].ToString();
                    mOutTime = sOutTime.Substring(0, 2);
                    hour = rnd.Next(Convert.ToInt32(mOutTime), Convert.ToInt32(mOutTime));
                    if (hour < Convert.ToInt32(mOutTime)) minute = rnd.Next(01, 09);
                    else minute = rnd.Next(01, 05);
                    second = rnd.Next(1, 59);
                    outTime = hour + ":" + minute + ":" + second;
                    dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                    dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                    dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                    dgvAttd.SelectedRows[i].Cells["overTime"].Value = 0;
                    dgvAttd.SelectedRows[i].Cells["workHour"].Value = 8;
                    dgvAttd.SelectedRows[i].Cells["status"].Value = "P";
                    if (dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString() == "")
                        dgvAttd.SelectedRows[i].Cells["inTime"].Value = inTime.ToString();
                    if (dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString() == "")
                        dgvAttd.SelectedRows[i].Cells["outTime"].Value = outTime.ToString();
                    dgvAttd.SelectedRows[i].Cells["IS_IN_TIME"].Value = inManual(intEID, attDate);
                    dgvAttd.SelectedRows[i].Cells["IS_OUT_TIME"].Value = outManual(intEID, attDate);
                    if (TimeSpan.Parse(dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString()).Hours < 9)
                        dgvAttd.SelectedRows[i].Cells["night"].Value = "Y";
                }
            }
        }
        private void tsmiSetOnResetInOut_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            DBClass db = new DBClass();
            int i, hour, minute, second, intEID, intSID;
            string strSql, attDate, inTime, outTime, sInTime, mInTime, sOutTime, mOutTime = "";
            for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
            {
                if (dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString() != "" && dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString() != "")
                {
                    attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                    intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);
                    intSID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                    strSql = "SELECT IN_TIME,OUT_TIME FROM SHIFT_INFO WHERE SHIFT_ID ='" + intSID + "'";
                    DataSet ds = db.GetDataSet(strSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // ================ Set In Time =======================
                        sInTime = ds.Tables[0].Rows[0]["IN_TIME"].ToString();
                        mInTime = sInTime.Substring(0, 2);
                        hour = rnd.Next(Convert.ToInt32(mInTime) - 1, Convert.ToInt32(mInTime));
                        if (hour < Convert.ToInt32(mInTime)) minute = rnd.Next(50, 59);
                        else minute = rnd.Next(01, 05);
                        second = rnd.Next(1, 59);
                        inTime = hour + ":" + minute + ":" + second;

                        // ================ Set Out Time =======================
                        sOutTime = ds.Tables[0].Rows[0]["OUT_TIME"].ToString();
                        mOutTime = sOutTime.Substring(0, 2);
                        hour = rnd.Next(Convert.ToInt32(mOutTime), Convert.ToInt32(mOutTime));
                        if (hour < Convert.ToInt32(mOutTime)) minute = rnd.Next(01, 09);
                        else minute = rnd.Next(01, 05);
                        second = rnd.Next(1, 59);
                        outTime = hour + ":" + minute + ":" + second;
                        dgvAttd.SelectedRows[i].Cells["late"].Value = "0";
                        dgvAttd.SelectedRows[i].Cells["night"].Value = "N";
                        dgvAttd.SelectedRows[i].Cells["rFlag"].Value = "U";
                        dgvAttd.SelectedRows[i].Cells["overTime"].Value = 0;
                        dgvAttd.SelectedRows[i].Cells["workHour"].Value = 8;
                        dgvAttd.SelectedRows[i].Cells["status"].Value = "P";
                        dgvAttd.SelectedRows[i].Cells["inTime"].Value = inTime.ToString();
                        dgvAttd.SelectedRows[i].Cells["outTime"].Value = outTime.ToString();
                        dgvAttd.SelectedRows[i].Cells["IS_IN_TIME"].Value = inManual(intEID, attDate);
                        dgvAttd.SelectedRows[i].Cells["IS_OUT_TIME"].Value = outManual(intEID, attDate);
                        if (TimeSpan.Parse(dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString()).Hours < 9)
                            dgvAttd.SelectedRows[i].Cells["night"].Value = "Y";
                        if (dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "W" || dgvAttd.SelectedRows[i].Cells["status"].Value.ToString() != "H")
                            dgvAttd.SelectedRows[i].Cells["status2"].Value = "P";
                    }
                }
            }
        }
        private void tsmiRefreshInOut_Click(object sender, EventArgs e)
        {            
            tsmiRefreshInTime_Click(sender, e);
            tsmiRefreshOutTime_Click(sender, e);
            //double dblOTHr;
            //Random rnd = new Random();
            //DBClass db = new DBClass();
            //int i, intSID, intEarlyOut;
            //TimeSpan tsOTHr = new TimeSpan();
            //string strSql, strInTime, strOutTime, strStatus2, sOutTime, sLunchStart, sLunchEnd, attDate = "";
            //for (i = 0; i < dgvAttDetails.SelectedRows.Count; i++)
            //{
            //    if (dgvAttDetails.SelectedRows[i].Cells["inTime"].Value.ToString() != "" && dgvAttDetails.SelectedRows[i].Cells["outTime"].Value.ToString() != "" && dgvAttDetails.SelectedRows[i].Cells["status"].Value.ToString() != "L")
            //    {
            //        attDate = dgvAttDetails.SelectedRows[i].Cells["attDate"].Value.ToString();
            //        strStatus2 = dgvAttDetails.SelectedRows[i].Cells["status2"].Value.ToString();
            //        intSID = Convert.ToInt32(dgvAttDetails.SelectedRows[i].Cells["shift_id"].Value);
            //        strSql = "SELECT OUT_TIME,LUNCE_START,LUNCE_END FROM SHIFT_INFO WHERE SHIFT_ID= '" + intSID + "'";
            //        DataSet ds = db.get_data_set(strSql);
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            dgvAttDetails.SelectedRows[i].Cells["night"].Value = "N";
            //            strInTime = attDate + " " + dgvAttDetails.SelectedRows[i].Cells["inTime"].Value.ToString();
            //            if (TimeSpan.Parse(dgvAttDetails.SelectedRows[i].Cells["outTime"].Value.ToString()).Hours < 9)
            //            {
            //                dgvAttDetails.SelectedRows[i].Cells["night"].Value = "Y";
            //                attDate = Convert.ToDateTime(dgvAttDetails.SelectedRows[i].Cells["attDate"].Value).AddDays(1).ToString("dd-MMM-yyyy");
            //            }
            //            strOutTime = attDate + " " + dgvAttDetails.SelectedRows[i].Cells["outTime"].Value.ToString();
            //            sOutTime = attDate + " " + ds.Tables[0].Rows[0]["OUT_TIME"].ToString();
            //            if (dgvAttDetails.SelectedRows[i].Cells["IS_OT_HOLDER"].Value.ToString() == "Y")
            //            {
            //                sLunchStart = ds.Tables[0].Rows[0]["LUNCE_START"].ToString();
            //                sLunchEnd = ds.Tables[0].Rows[0]["LUNCE_END"].ToString();
            //                if (strStatus2 != "W" && strStatus2 != "H") tsOTHr = DateTime.Parse(strOutTime) - DateTime.Parse(sOutTime);
            //                else tsOTHr = (DateTime.Parse(strOutTime) - DateTime.Parse(strInTime)) - (DateTime.Parse(sLunchEnd) - DateTime.Parse(sLunchStart));
            //                int intTimeDiff = tsOTHr.Hours * 60 + tsOTHr.Minutes;
            //                if (intTimeDiff > 0)
            //                {
            //                    intEarlyOut = 0;
            //                    if (tsOTHr.Minutes > 44) dblOTHr = tsOTHr.Hours + 1;
            //                    else if (tsOTHr.Minutes > 24) dblOTHr = tsOTHr.Hours + 0.5;
            //                    else dblOTHr = tsOTHr.Hours;
            //                }
            //                else
            //                {
            //                    dblOTHr = 0;
            //                    intEarlyOut = intTimeDiff * -1;
            //                }
            //                dgvAttDetails.SelectedRows[i].Cells["overTime"].Value = dblOTHr.ToString();
            //                dgvAttDetails.SelectedRows[i].Cells["EARLY_OUT"].Value = intEarlyOut.ToString();
            //            }
            //            else dgvAttDetails.SelectedRows[i].Cells["overTime"].Value = 0;
            //        }
            //        dgvAttDetails.SelectedRows[i].Cells["rFlag"].Value = "U";
            //    }
            //}
        }                
        #endregion
        
        #region ===================SubclassTypeValidator Query =============================
        private string generateSubQuery()
        {
            string subQuery = "";
            if (combo_unit_name.SelectedIndex > -1) subQuery += GenrateCode(combo_unit_name, "UNIT_ID");
            if (combo_emp_type.SelectedIndex > -1) subQuery += GenrateCode(combo_emp_type, "EMP_CATEGORY_ID");
            if (combo_department.SelectedIndex > -1) subQuery += GenrateCode(combo_department, "DEPARTMENT_ID");
            if (combo_section_name.SelectedIndex > -1) subQuery += GenrateCode(combo_section_name, "SECTION_ID");
            if (combo_line_name.SelectedIndex > -1) subQuery += GenrateCode(combo_line_name, "LINE_ID");
            if (combo_shift.SelectedIndex > -1) subQuery += GenrateCode(combo_shift, "SHIFT_ID");
            if (comBoxDesig.SelectedIndex > -1) subQuery += GenrateCode(comBoxDesig, "DESIGNATION_ID");
            //==================================
            if (LB_attendance_details.Items.Count != 0)
            {
                subQuery += " AND A.EMP_CODE IN('";
                for (int i = 0; i < LB_attendance_details.Items.Count; i++)
                {
                    subQuery += LB_attendance_details.Items[i];
                    if (i != LB_attendance_details.Items.Count - 1) subQuery += "', '";
                    else subQuery += "') ";
                }
            }
            //if (txtAttSearch.Text != null && txtAttSearch.Text != "")
            //{
            //    if (Isnumber(txtAttSearch.Text)) subQuery += " AND A.EMP_CODE ='" + txtAttSearch.Text + "' ";
            //    else subQuery += " AND UPPER(C.STATUS) IN ('" + txtAttSearch.Text.ToUpper().Replace(",", "','") + "')";
            //}
            return subQuery;
        }
        private string generate_subQuery(string strFieldNameForDate = null)
        {
            string subQuery = "";
            if (combo_unit_name.SelectedIndex > -1) subQuery += GenrateCode(combo_unit_name, "UNIT_ID");
            if (combo_emp_type.SelectedIndex > -1) subQuery += GenrateCode(combo_emp_type, "EMP_CATEGORY_ID");
            if (combo_department.SelectedIndex > -1) subQuery += GenrateCode(combo_department, "DEPARTMENT_ID");
            if (combo_section_name.SelectedIndex > -1) subQuery += GenrateCode(combo_section_name, "SECTION_ID");
            if (combo_line_name.SelectedIndex > -1) subQuery += GenrateCode(combo_line_name, "LINE_ID");
            if (combo_shift.SelectedIndex > -1) subQuery += GenrateCode(combo_shift, "SHIFT_ID");
            if (comBoxDesig.SelectedIndex > -1) subQuery += GenrateCode(comBoxDesig, "DESIGNATION_ID");
            //==================================
            if (LB_attendance_details.Items.Count != 0)
            {
                subQuery += " AND A.EMP_CODE IN('";
                for (int i = 0; i < LB_attendance_details.Items.Count; i++)
                {
                    subQuery += LB_attendance_details.Items[i];
                    if (i != LB_attendance_details.Items.Count - 1) subQuery += "', '";
                    else subQuery += "') ";
                }
            }
            if (txtAttSearch.Text != null && txtAttSearch.Text != "")
            {
                if (Isnumber(txtAttSearch.Text)) subQuery += " AND A.EMP_CODE ='" + txtAttSearch.Text + "' ";
                else subQuery += " AND UPPER(C.STATUS) IN ('" + txtAttSearch.Text.ToUpper().Replace(",", "','") + "')";
            }
            if ((strFieldNameForDate != null) && (chk_dt.Checked))
                subQuery += " AND " + strFieldNameForDate + " BETWEEN '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "' AND '" + dtpEnd.Value.ToString("dd-MMM-yyyy") + "'";
            else subQuery += " AND " + strFieldNameForDate + " BETWEEN '" + dtpStart.Value.AddDays(-40).ToString("dd-MMM-yyyy") + "' AND '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "'";
            return subQuery;
        }
        private string GenrateCode(ComboBox combo_name, string db_coloum_id)
        {
            string subQuery = "";
            if (combo_name == combo_shift)
            {
                if (combo_name.SelectedIndex > -1)
                {
                    KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>) combo_name.SelectedItem;
                    subQuery += " AND C." + db_coloum_id + " = '" + selectedItemVal.Value.ToString() + "' ";
                }
            }
            else
            {
                if (combo_name.SelectedIndex > -1)
                {
                    KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)combo_name.SelectedItem;
                    subQuery += " AND A." + db_coloum_id + " = '" + selectedItemVal.Value.ToString() + "' ";
                }
            }            
            return subQuery;
        }
        private void btnSearchFromData_Click(object sender, EventArgs e)
        {
            getDisplayAttDetails(generate_subQuery("C.ATTD_DATE"));
            /*
            DBClass db = new DBClass();
            dgvAttDetails.Rows.Clear();
            int emp_id, shift_id, isintime, isouttime;
            txtAttSearch.Text = txtAttSearch.Text.ToUpper();
            string sql, emp_code, emp_name, attDate, emp_intime, emp_late, emp_working_hour, emp_outtime, emp_overtime, emp_status, emp_night_status, emp_status2, shift_name, attd_remarks = "";
            sql = @"select c.attd_date as atten_date, a.emp_code, a.emp_name, c.in_time, c.late, nvl(round((c.out_time - c.in_time)*24)-1,0) as working_hour,
                       c.out_time, c.over_time, c.status, c.night_status, c.status2,a.emp_id,sf.shift_name,c.shift_id,c.ATTD_REMARKS,C.IS_IN_TIME_MANUAL,C.IS_OUT_TIME_MANUAL
                    from emp_official a, attendance_details c, shift_info sf
                    where c.shift_id=sf.shift_id and a.emp_id=c.emp_id " + generate_subQuery("c.attd_date") + @" order by atten_date desc";
            DataSet ds = db.get_data_set(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int rDx = dgvAttDetails.Rows.Count;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    attDate = Convert.ToDateTime(dr[0].ToString()).ToString("dd-MMM-yyyy");
                    emp_code = dr[1].ToString();
                    emp_name = dr[2].ToString();
                    if (dr[3].ToString()=="") emp_intime = dr[3].ToString();
                    else emp_intime = Convert.ToDateTime(dr[3].ToString()).ToString("HH:mm:ss"); //ToString("dd-MMM-yyyy HH:mm:ss");
                    emp_late = dr[4].ToString();
                    emp_working_hour = dr[5].ToString();
                    if (dr[6].ToString()=="") emp_outtime = dr[6].ToString();
                    else emp_outtime = Convert.ToDateTime(dr[6].ToString()).ToString("HH:mm:ss");
                    emp_overtime = dr[7].ToString();
                    emp_status = dr[8].ToString();
                    emp_night_status = dr[9].ToString();
                    emp_status2 = dr[10].ToString();
                    emp_id = Convert.ToInt32(dr[11]);
                    shift_name = dr[12].ToString();
                    shift_id = Convert.ToInt32(dr[13]);
                    attd_remarks = dr[14].ToString();
                    isintime = Convert.ToInt32(dr[15]);
                    isouttime = Convert.ToInt32(dr[16]);
                    dgvAttDetails.Rows.Add(attDate, emp_code, emp_name, emp_intime, emp_late, emp_working_hour, emp_outtime, emp_overtime, emp_status, emp_night_status, emp_status2, emp_id, null, null, null, null, shift_name, shift_id, attd_remarks, null, isintime, isouttime);
                    if (emp_status == "A") dgvAttDetails.Rows[rDx].DefaultCellStyle.ForeColor = Color.Red;
                    if (emp_status == "W") dgvAttDetails.Rows[rDx].DefaultCellStyle.ForeColor = Color.Orange;
                    if (emp_status == "H") dgvAttDetails.Rows[rDx].DefaultCellStyle.ForeColor = Color.DarkViolet;
                    if (emp_status == "L") dgvAttDetails.Rows[rDx].DefaultCellStyle.BackColor = Color.GreenYellow;
                    rDx++;
                } // end while (dr.Read())   
            } // end if (dr.HasRows)
            btnUpdate.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            // ============================= this query count attd(A/P/L/W/Y) =============================
            List<string> oList = new List<string>();
            foreach (DataGridViewRow Dr in dgvAttDetails.Rows)
            {
                if (Dr.Cells["status"].Value == null) break;
                oList.Add(Dr.Cells["status"].Value.ToString());
            }
            List<string> A = oList.FindAll(FindA);
            List<string> P = oList.FindAll(FindP);
            List<string> L = oList.FindAll(FindL);
            List<string> W = oList.FindAll(FindW);
            List<string> H = oList.FindAll(FindH);

            List<string> nList = new List<string>();
            foreach (DataGridViewRow Dr in dgvAttDetails.Rows)
            {
                if (Dr.Cells["night"].Value == null) break;
                nList.Add(Dr.Cells["night"].Value.ToString());
            }
            List<string> Y = nList.FindAll(FindY);
            label13.Text = "A: " + A.Count + ", P: " + P.Count + ", L: " + L.Count + ", W: " + W.Count + ", H: " + H.Count + ", N: " + Y.Count;// +", OT: " + eOT;
            label9.Text = "Total: " + (dgvAttDetails.Rows.Count);
           */ 
        }
        private void exportfile(string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut, false, Encoding.Unicode);
            string strRow;

            sw.WriteLine(columnNames(dgvAttd, "\t"));
            foreach (DataGridViewRow  dr in dgvAttd.Rows)
            {
                int i;
                strRow = "";
                bool flag = false;
                for (i = 0; i < dgvAttd.ColumnCount; i++)
                {
                   DataGridViewColumn oColum = dgvAttd.Rows[0].Cells[i].OwningColumn;
                    if (oColum.Visible)
                    {
                        if (flag) strRow +="\t";
                        if (dr.Cells[i].Value == null) break;
                        strRow += dr.Cells[i].Value.ToString();
                        flag = true;
                    }
                }
                sw.WriteLine(strRow);
            }
            // Closes the text stream and the database connenction.
            sw.Close();

            // Notifies the user.
            MessageBox.Show("Action Perform Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string columnNames(DataGridView dtSchemaTable, string delimiter)
        {
            int i;
            string strOut = "";
            if (delimiter.ToLower() == "tab") delimiter = "\t";
            bool flag = false;
            for (i = 0; i < dtSchemaTable.ColumnCount; i++)
            {
                DataGridViewColumn oColum = dtSchemaTable.Rows[0].Cells[i].OwningColumn;
                if (oColum.Visible)
                {
                    if (flag) strOut += delimiter;
                    strOut += oColum.Name.ToString();
                    flag = true;
                }
            }
            return strOut;
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void txtAttSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string subQuery = generateSubQuery();
            if (chk_dt.Checked) subQuery += " AND C.ATTD_DATE BETWEEN '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "' AND '" + dtpEnd.Value.ToString("dd-MMM-yyyy") + "'";
            else subQuery += " AND C.ATTD_DATE BETWEEN '" + dtpStart.Value.AddDays(-40).ToString("dd-MMM-yyyy") + "' AND '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "'";

            if (e.KeyCode == Keys.F1)
            {
                getDisplayAttDetails(subQuery + " AND C.IN_TIME IS NULL AND C.STATUS = 'P'");
                return;
            } //============================= In time missing
            else if (e.KeyCode == Keys.F2)
            {
                getDisplayAttDetails(subQuery + " AND C.OUT_TIME IS NULL AND C.STATUS = 'P'");
                return;
            }  //============================= Out time missing
            else if (e.KeyCode == Keys.F3)
            {
                if (txtAttSearch.Text == "") subQuery += " AND C.LATE>'0' AND C.STATUS = 'P'";
                else subQuery += "AND C.LATE " + txtAttSearch.Text + " AND C.STATUS = 'P'";
                getDisplayAttDetails(subQuery);
            }//============================= late status
            else if (e.KeyCode == Keys.F4)
            {
                if (txtAttSearch.Text == "") subQuery += " AND C.OVER_TIME>'0' AND C.STATUS = 'P'";
                else subQuery += "AND C.OVER_TIME " + txtAttSearch.Text + " AND C.STATUS = 'P'";
                getDisplayAttDetails(subQuery);
            } //============================= over time Satus                
            else if (e.KeyCode == Keys.F5 || e.KeyCode == Keys.Enter)
            {
                if (!(txtAttSearch.Text != ""))
                {
                    MessageBox.Show("What do you search (A/P/W/H/L/N) on Status ...???", "Search By (A/P/W/H/L/N) ??????", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtAttSearch.Focus();
                    return;
                }
                if (Isnumber(txtAttSearch.Text))
                {
                    getDisplayAttDetails(subQuery + " AND A.EMP_CODE ='" + txtAttSearch.Text + "'");
                    return;
                }
                else if (txtAttSearch.Text.ToUpper() == "Y" || txtAttSearch.Text.ToUpper() == "N")
                {
                    getDisplayAttDetails(subQuery + "AND C.NIGHT_STATUS='" + txtAttSearch.Text.ToUpper() + "'");
                    return;
                }
                else
                {
                    getDisplayAttDetails(subQuery + " AND UPPER(C.STATUS) IN ('" + txtAttSearch.Text.ToUpper().Replace(",", "','") + "')");
                    return;
                }
            } //============================= Attd status1
            else if (e.KeyCode == Keys.F6)
            {
                if (txtAttSearch.Text == "") subQuery += " AND C.EARLY_OUT>'0' AND C.STATUS = 'P'";
                else subQuery += "AND C.EARLY_OUT " + txtAttSearch.Text + " AND C.STATUS = 'P'";
                getDisplayAttDetails(subQuery);
                return;
            } //============================= Early out
            else if (e.KeyCode == Keys.F7)
            {
                if (!(txtAttSearch.Text != ""))
                {
                    MessageBox.Show("What do you search (A/P/W/H/L/N) on Status2 ...???", "Search By (A/P/W/H/L/N) ??????", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txtAttSearch.Focus();
                    return;
                }
                if (txtAttSearch.Text.ToUpper() == "Y" || txtAttSearch.Text.ToUpper() == "N")
                {
                    getDisplayAttDetails(subQuery + "AND C.NIGHT_STATUS='" + txtAttSearch.Text.ToUpper() + "'");
                    return;
                }
                else if (Isnumber(txtAttSearch.Text))
                {
                    getDisplayAttDetails(subQuery + " AND A.EMP_CODE ='" + txtAttSearch.Text + "'");
                    return;
                }
                else
                {
                    getDisplayAttDetails(subQuery + " AND UPPER(C.STATUS2) IN ('" + txtAttSearch.Text.ToUpper().Replace(",", "','") + "')");
                    return;
                }
            } //============================= Attd status2                
            else if (e.KeyCode == Keys.F8)
            {
                if (!(txtAttSearch.Text != ""))
                {
                    getDisplayAttDetails(generateSubQuery() + " AND C.ATTD_DATE = '" + dtpStart.Text + "'");
                    return;
                }
                if (CConfig.getParmisionSpecificEmployee(txtAttSearch.Text))
                {
                    string strSubSql = generateSubQuery();
                    if (chk_dt.Checked) strSubSql += " AND C.ATTD_DATE BETWEEN '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "' AND '" + dtpEnd.Value.ToString("dd-MMM-yyyy") + "'";
                    else strSubSql += " AND C.ATTD_DATE BETWEEN '" + dtpStart.Value.AddMonths(-2).ToString("dd-MMM-yyyy") + "' AND '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "'";
                    getDisplayAttDetails(strSubSql + " AND A.EMP_CODE ='" + txtAttSearch.Text + "'");
                    return;
                }
            } //============================= display specific employee's attd
            else if (e.KeyCode == Keys.F9)
            {
                if (!(txtAttSearch.Text != ""))
                {
                    getDisplayAttDetails(generateSubQuery() + " AND A.DATE_OF_JOINING >= '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "' AND C.OVER_TIME " + txtAttSearch.Text + " AND C.STATUS='P' AND C.ATTD_DATE BETWEEN '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "' AND '" + dtpStart.Value.AddDays(30).ToString("dd-MMM-yyyy") + "'");
                    return;
                }
                string strSubSql = generateSubQuery() + " AND C.ATTD_DATE BETWEEN '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "' AND '" + dtpEnd.Value.ToString("dd-MMM-yyyy") + "'";
                if (!chk_dt.Checked) strSubSql += " AND A.DATE_OF_JOINING >= '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "'";
                else strSubSql += " AND A.DATE_OF_JOINING BETWEEN '" + dtpStart.Value.ToString("dd-MMM-yyyy") + "' AND '" + dtpEnd.Value.ToString("dd-MMM-yyyy") + "'";
                getDisplayAttDetails(strSubSql);
                return;
            } //============================= Joining date attendance
            else if (e.KeyCode == Keys.F10)
            {
                getDisplayAttDetails(subQuery + " AND UPPER(C.STATUS)='" + txtAttSearch.Text.ToUpper() + "' AND UPPER(C.STATUS2) IN ('W','H')");
                return;
            } //============================= Status in Weekend/Holiday
            else if (e.KeyCode == Keys.F11)
            {
                if (txtAttSearch.Text == "") subQuery += " AND NVL(ROUND((C.OUT_TIME - C.IN_TIME)*24,0),0)> '8'";
                else subQuery += " AND NVL(ROUND((C.OUT_TIME - C.IN_TIME)*24,0),0) " + txtAttSearch.Text;
                if (txt_emp_code.Text != "") subQuery += " AND C.OVER_TIME " + txt_emp_code.Text;
                getDisplayAttDetails(subQuery + " AND C.STATUS='P'");
                return;
            } //============================= Working Hour
            else if (e.KeyCode == Keys.F12)
            {
                string strSubSql = generateSubQuery();
                int intDayOfWeek = Convert.ToInt32(dtpEnd.Value.Date.DayOfWeek) + 1;
                if (chk_dt.Checked) strSubSql += " AND TO_NUMBER(TO_CHAR(ATTD_DATE,'D'))='" + intDayOfWeek + "' AND STATUS2!='W' AND A.EMP_ID IN (SELECT EMP_ID FROM ATTENDANCE_DETAILS WHERE ATTD_DATE='" + dtpEnd.Text + "' AND STATUS2='W')";
                else strSubSql += " AND TO_NUMBER(TO_CHAR( ATTD_DATE,'D'))!='" + intDayOfWeek + "' AND STATUS2='W' AND A.EMP_ID IN (SELECT EMP_ID FROM ATTENDANCE_DETAILS WHERE ATTD_DATE='" + dtpEnd.Text + "' AND STATUS2='W')";
                getDisplayAttDetails(strSubSql + " AND C.ATTD_DATE BETWEEN '" + dtpStart.Text + "' AND '" + dtpEnd.Text + "'");
                return;
            } //============================= Present/Leave in Weekend
            else if (e.KeyCode == Keys.Escape)
            {
                if (!(txtAttSearch.Text != ""))
                {
                    MessageBox.Show("Set IN Time Here...(Ex. 05:30:00)", "Set IN Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAttSearch.Focus();
                    return;
                }
                else
                {
                    subQuery += " AND TO_CHAR(C.IN_TIME,'hh24:mi:ss') <='" + txtAttSearch.Text + "' AND C.STATUS = 'P'";
                    getDisplayAttDetails(subQuery);
                    return;
                }
            } //============================= Present/Leave in Weekend
        }
        #endregion

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            //dtpToDate.MinDate = dtpFromDate.Value;
            dtpEnd.Value = dtpStart.Value;
            //dtpFromDate.MinDate = DateTime.Now.AddMonths(-2).Date;
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            //dtpToDate.MinDate = dtpFromDate.Value;
            //dtpToDate.MaxDate = dtpFromDate.Value.AddMonths(10).Date;
        }

        private void dgvAttDetails_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F1)
            //{
            //    string emp_code = "", sub_query = "(";
            //    if (dgvAttd.SelectedRows.Count > 0)
            //    {
            //        for (int count = 0; count < dgvAttd.SelectedRows.Count; count++)
            //        {
            //            emp_code = emp_code + "'" + dgvAttd.SelectedRows[count].Cells["empCode"].Value.ToString() + "',";
            //        }
            //    }
            //    sub_query = sub_query + emp_code;
            //    sub_query = sub_query.Remove(emp_code.Length - 1) + "')";
            //    payroll_main_form mForm = ParentForm as payroll_main_form;
            //    mForm.splitContainer1.Panel2.Controls.Clear();
            //    Movement_Register objAttdDetailsUC = new Movement_Register();
            //    mForm.splitContainer1.Panel2.Controls.Add(objAttdDetailsUC);
            //    objAttdDetailsUC.Show();
            //    objAttdDetailsUC.get_exit_for_user_control = 1;
            //    objAttdDetailsUC.get_employee_movement_reg(" and e_o.emp_code in " + sub_query + " and emr.attd_date between '" + dtpStart.Text + "' and '" + dtpEnd.Text + "'");
            //    objAttdDetailsUC.lastUserControlAttd = this;
            //}

            if (e.KeyCode == Keys.F2)
            {
                DBClass db = new DBClass();
                string emp_code = "", sub_query = "(", sub_string = "";
                if (dgvAttd.SelectedRows.Count > 0)
                {
                    for (int count = 0; count < dgvAttd.SelectedRows.Count; count++)
                    {
                        emp_code = emp_code + "'" + dgvAttd.SelectedRows[count].Cells["empCode"].Value.ToString() + "',";
                    }
                }
                sub_query = sub_query + emp_code;
                sub_query = sub_query.Remove(emp_code.Length - 1) + "')";
                sub_string = " and e_o.emp_code in " + sub_query + " and m_r.attd_date between '" + dtpStart.Text + "' and '" + dtpEnd.Text + "'";

                string sql = @"select E_O.EMP_ID,E_O.EMP_CODE,E_O.EMP_NAME,m_r.attd_date,m_r.MACHINE_NO,m_r.movement_time,U.UNIT_NAME,E_C.EMP_CATEGORY_NAME,DEP.DEPARTMENT_NAME,SEC.SECTION_NAME,S_I.SHIFT_NAME,DES.DESIGNATION_NAME
                           from emp_official e_o,employee_movement_register m_r,emp_category e_c, department dep,section sec, shift_info s_i,unit u,designation des
                           where E_O.EMP_CODE=m_r.EMP_CODE
                           and U.UNIT_ID=E_O.UNIT_ID
                           and E_C.EMP_CATEGORY_ID=E_O.EMP_CATEGORY_ID
                           and DEP.DEPARTMENT_ID=E_O.DEPARTMENT_ID
                           and SEC.SECTION_ID=E_O.SECTION_ID
                           and S_I.SHIFT_ID=E_O.SHIFT_ID
                           and DES.DESIGNATION_ID=E_O.DESIGNATION_ID
                           " + sub_string + @"
                           order by E_O.EMP_ID,m_r.attd_date,m_r.movement_time asc";
                ReportDocument r_d = new ReportDocument();
                r_d.Load(db.GetReportPath() + "rpt_daily_movement_register.rpt");
                r_d.Database.Tables["movement_register"].SetDataSource(db.GetDataSet(sql).Tables[0]);
                CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
                obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
                obj_report_viewer_uc.crystalReportViewer1.Refresh();
                obj_report_viewer_uc.lastUserControlRptViewer = this;
            }
            //if (e.KeyCode == Keys.F3)
            //{
            //    string emp_code = "", sub_query = "(";
            //    if (dgvAttd.SelectedRows.Count > 0)
            //    {
            //        for (int count = 0; count < dgvAttd.SelectedRows.Count; count++)
            //        {
            //            emp_code = emp_code + "'" + dgvAttd.SelectedRows[count].Cells["empCode"].Value.ToString() + "',";
            //        }
            //    }
            //    sub_query = sub_query + emp_code;
            //    sub_query = sub_query.Remove(emp_code.Length - 1) + "')";
            //    payroll_main_form mForm = ParentForm as payroll_main_form;
            //    mForm.splitContainer1.Panel2.Controls.Clear();
            //    Weekend_Process objAttdDetailsUC = new Weekend_Process();
            //    mForm.splitContainer1.Panel2.Controls.Add(objAttdDetailsUC);
            //    objAttdDetailsUC.Show();
            //    objAttdDetailsUC.get_exit_for_user_control = 1;
            //    objAttdDetailsUC.show_weekend(" and e_o.emp_code in " + sub_query + " and week.weekend_date between '" + dtpStart.Text + "' and '" + dtpEnd.Text + "'");
            //    objAttdDetailsUC.lastUserControlAttd = this;
            //}
            if (e.KeyCode == Keys.F4)
            {
                //string emp_code = "", sub_query = "(";
                //if (dgvAttDetails.SelectedRows.Count > 0)
                //{
                //    for (int count = 0; count < dgvAttDetails.SelectedRows.Count; count++)
                //    {
                //        emp_code = emp_code + "'" + dgvAttDetails.SelectedRows[count].Cells["empCode"].Value.ToString() + "',";

                //    }
                //}
                //sub_query = sub_query + emp_code;
                //sub_query = sub_query.Remove(emp_code.Length - 1) + "')";
                //payroll_main_form mForm = ParentForm as payroll_main_form;
                //mForm.splitContainer1.Panel2.Controls.Clear();
                //daily_shift_allocation_UC objAttdDetailsUC = new daily_shift_allocation_UC();
                //mForm.splitContainer1.Panel2.Controls.Add(objAttdDetailsUC);
                //objAttdDetailsUC.Show();
                //objAttdDetailsUC.get_exit_for_user_control = 1;
                //objAttdDetailsUC.show_daily_shift_allocation(" and e_o.emp_code in " + sub_query + " and DAILY.SHIFT_DATE between '" + dtpFromDate.Text + "' and '" + dtpToDate.Text + "'");
                //objAttdDetailsUC.lastUserControlAttd = this;
            }
            if (e.KeyCode == Keys.A)
            {
                DBClass db = new DBClass();
                int shift_id;
                string emp_id = "", attd_date = "", shift_grace = "", in_time = "", del_query = "", insert_query = "", machine_no = "", update_query = "", select_query = "", select_query2 = "";
                DateTime in_time_convert = new DateTime();
                TimeSpan in_time_time = new TimeSpan();
                DateTime out_time_actual = new DateTime();
                DateTime calculate_date1 = new DateTime();
                DateTime calculate_date2 = new DateTime();
                DateTime shift_in_time = new DateTime();
                DateTime lunch_start = new DateTime();
                DateTime lunch_end = new DateTime();
                TimeSpan time_calculation = new TimeSpan();
                TimeSpan time_lunch_calculation = new TimeSpan();
                TimeSpan late_calculation = new TimeSpan();
                int late = 0;
                int work_hour_time_calculation = 0;
                int lunch_calculation = 0;
                int work_hour_with_munite = 0;
                int work_hour = 0;
                int work_munite = 0;

                int work_limit = 8;
                double work_time_cal = 0.0, over_time = 0.0;
                for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                {
                    if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                    {
                        string strOut = dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString();
                        string emp_code = dgvAttd.SelectedRows[i].Cells["empCode"].Value.ToString();
                        if (strOut != null && strOut != "")
                        {
                            attd_date = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                            in_time = dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString();
                            shift_id = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                            in_time_time = (TimeSpan)Convert.ToDateTime(in_time).TimeOfDay;
                            select_query = @"select a_d.in_time,a_d.out_time,s_i.grace,s_i.in_time,S_I.lunce_start,S_I.lunce_end,a_d.emp_id from attendance_details a_d, shift_info s_i where a_d.shift_id=s_i.shift_id and  attd_date='" + attd_date + "' and a_d.shift_id=" + shift_id + " and emp_id in (select emp_id from emp_official where emp_code='" + emp_code + "')";
                            OracleDataReader dr = db.GetExecuteReader(select_query);
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    out_time_actual = Convert.ToDateTime(dr.GetValue(1));
                                    shift_grace = dr.GetValue(2).ToString();
                                    shift_in_time = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(3) + ":00").AddMinutes(Convert.ToDouble(shift_grace.Substring(0, shift_grace.IndexOf(':'))));
                                    lunch_start = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(4) + ":00");
                                    lunch_end = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(5) + ":00");
                                    emp_id = dr.GetValue(6).ToString();
                                    time_lunch_calculation = lunch_end - lunch_start;
                                    lunch_calculation = time_lunch_calculation.Hours * 60 + time_lunch_calculation.Minutes;
                                }
                            }
                            in_time_convert = Convert.ToDateTime(attd_date + ' ' + in_time_time);
                            select_query2 = @"select distinct MACHINE_NO from employee_movement_register where emp_code='" + emp_code + "' and movement_time<=to_date('" + out_time_actual.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am')";
                            OracleDataReader data = db.GetExecuteReader(select_query2);
                            if (data.HasRows)
                            {
                                while (data.Read())
                                {
                                    machine_no = data.GetValue(0).ToString();
                                }
                            }
                            // insert into employee_movement_register(emp_code,attd_date,machine_no,movement_time) values('2008398','15-Feb-2018',,to_date('15-Feb-2018 07:53:39 AM','dd-Mon-yyyy hh:mi:ss am'))

                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "' and machine_no='" + machine_no + "' and attd_date='" + attd_date + "' and  movement_time<=to_date('" + in_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am')";
                            db.RunDmlQuery(del_query);
                            insert_query = @"insert into employee_movement_register(emp_code,attd_date,machine_no,movement_time) values('" + emp_code + "','" + Convert.ToDateTime(attd_date).ToString("dd-MMM-yyyy") + "'," + machine_no + ",to_date('" + in_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am'))";
                            db.RunDmlQuery(insert_query);
                            string query = @"select emp_code,movement_time from employee_movement_register where emp_code='" + emp_code + @"'  
                            and MOVEMENT_TIME>=to_date('" + in_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') and 
                                MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(out_time_actual).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am')
                            order by movement_time asc";
                            DataSet ds = db.GetDataSet(query);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int count = 0; count < ds.Tables[0].Rows.Count - 1; count++)
                                {
                                    calculate_date1 = Convert.ToDateTime(ds.Tables[0].Rows[count + 1]["MOVEMENT_TIME"]);
                                    calculate_date2 = Convert.ToDateTime(ds.Tables[0].Rows[count]["MOVEMENT_TIME"]);
                                    time_calculation = calculate_date1 - calculate_date2;
                                    work_hour_time_calculation += time_calculation.Hours * 60 + time_calculation.Minutes;
                                }
                            }

                            if (work_hour_time_calculation > 0)
                            {
                                work_hour_with_munite = work_hour_time_calculation - lunch_calculation;
                                work_hour = work_hour_with_munite / 60;
                                work_munite = work_hour_with_munite % 60;
                                if (work_munite > 44) work_time_cal = work_hour + 1;
                                else if (work_munite > 24) work_time_cal = work_hour + 0.5;
                                else work_time_cal = work_hour;
                                if (work_time_cal > work_limit)
                                {
                                    over_time = work_time_cal - work_limit;
                                }
                            }
                            else
                            {
                                work_time_cal = 0;
                                over_time = 0;
                            }
                            if (in_time_convert > shift_in_time)
                            {
                                late_calculation = in_time_convert - shift_in_time;
                                late = late_calculation.Minutes;
                            }
                            else
                            {
                                late = 0;
                            }
                            update_query = @"update attendance_details set work_hour=" + work_time_cal + ",IN_TIME=to_date('" + Convert.ToDateTime(in_time_convert).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh12:mi:ss am'),
                                             late=" + late + ",over_time=" + over_time + " where emp_id=" + emp_id + " and attd_date='" + attd_date + "' and NVL(attd_locked,'N')!='Y'";
                            db.RunDmlQuery(update_query);
                        }
                    }
                }

            }
            if (e.KeyCode == Keys.Q)
            {
                DBClass db = new DBClass();
                int shift_id;
                string emp_id = "", attd_date = "", out_time = "", del_query = "", insert_query = "", machine_no = "", update_query = "", select_query = "", select_query2 = "";
                DateTime out_time_convert = new DateTime();
                TimeSpan out_time_time = new TimeSpan();
                DateTime in_time_actual = new DateTime();
                DateTime calculate_date1 = new DateTime();
                DateTime calculate_date2 = new DateTime();
                DateTime lunch_start = new DateTime();
                DateTime lunch_end = new DateTime();
                TimeSpan time_calculation = new TimeSpan();
                TimeSpan time_lunch_calculation = new TimeSpan();
                int work_hour_time_calculation = 0;
                int lunch_calculation = 0;
                int work_hour_with_munite = 0;
                int work_hour = 0;
                int work_munite = 0;

                int work_limit = 8;
                double work_time_cal = 0.0, over_time = 0.0;
                for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                {
                    if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                    {
                        string strInTime = dgvAttd.SelectedRows[i].Cells["inTime"].Value.ToString();
                        string emp_code = dgvAttd.SelectedRows[i].Cells["empCode"].Value.ToString();
                        if (strInTime != null && strInTime != "")
                        {
                            attd_date = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                            out_time = dgvAttd.SelectedRows[i].Cells["outTime"].Value.ToString();
                            shift_id = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["shift_id"].Value);
                            out_time_time = (TimeSpan)Convert.ToDateTime(out_time).TimeOfDay;
                            select_query = @"select a_d.in_time,a_d.out_time,S_I.lunce_start,S_I.lunce_end,a_d.emp_id from attendance_details a_d, shift_info s_i where a_d.shift_id=s_i.shift_id and  attd_date='" + attd_date + "' and a_d.shift_id=" + shift_id + " and emp_id in (select emp_id from emp_official where emp_code='" + emp_code + "')";
                            OracleDataReader dr = db.GetExecuteReader(select_query);
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    in_time_actual = Convert.ToDateTime(dr.GetValue(0));
                                    lunch_start = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(2) + ":00");
                                    lunch_end = Convert.ToDateTime(attd_date + ' ' + dr.GetValue(3) + ":00");
                                    emp_id = dr.GetValue(4).ToString();
                                    time_lunch_calculation = lunch_end - lunch_start;
                                    lunch_calculation = time_lunch_calculation.Hours * 60 + time_lunch_calculation.Minutes;
                                }
                            }
                            if ((out_time_time.Hours == 0 || out_time_time.Hours < 12) && out_time_time.Minutes > 0 && out_time_time.Seconds > 0)
                            {
                                out_time_convert = Convert.ToDateTime(in_time_actual.AddDays(1).ToString("dd-MMM-yyyy") + ' ' + out_time_time);
                            }
                            else
                            {
                                out_time_convert = Convert.ToDateTime(in_time_actual.ToString("dd-MMM-yyyy") + ' ' + out_time_time);
                            }
                            select_query2 = @"select distinct MACHINE_NO from employee_movement_register where emp_code='" + emp_code + "' and movement_time>=to_date('" + in_time_actual.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') ";
                            OracleDataReader data = db.GetExecuteReader(select_query2);
                            if (data.HasRows)
                            {
                                while (data.Read())
                                {
                                    machine_no = data.GetValue(0).ToString();
                                }
                            }
                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "' and machine_no='" + machine_no + "' and attd_date='" + attd_date + "' and movement_time between to_date('" + out_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') and to_date('" + out_time_convert.AddHours(5).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') ";
                            db.RunDmlQuery(del_query);
                            insert_query = @"insert into employee_movement_register(emp_code,attd_date,machine_no,movement_time) values('" + emp_code + "','" + Convert.ToDateTime(attd_date).ToString("dd-MMM-yyyy") + "'," + machine_no + ",to_date('" + out_time_convert.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am'))";
                            db.RunDmlQuery(insert_query);
                            string query = @"select emp_code,movement_time from employee_movement_register where emp_code='" + emp_code + @"' and MOVEMENT_TIME>=to_date('" + in_time_actual.ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') and 
                                MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(out_time_convert).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am')
                            order by movement_time asc";
                            DataSet ds = db.GetDataSet(query);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int count = 0; count < ds.Tables[0].Rows.Count - 1; count++)
                                {
                                    calculate_date1 = Convert.ToDateTime(ds.Tables[0].Rows[count + 1]["MOVEMENT_TIME"]);
                                    calculate_date2 = Convert.ToDateTime(ds.Tables[0].Rows[count]["MOVEMENT_TIME"]);
                                    time_calculation = calculate_date1 - calculate_date2;
                                    work_hour_time_calculation += time_calculation.Hours * 60 + time_calculation.Minutes;
                                }
                            }

                            if (work_hour_time_calculation > 0)
                            {
                                work_hour_with_munite = work_hour_time_calculation - lunch_calculation;
                                work_hour = work_hour_with_munite / 60;
                                work_munite = work_hour_with_munite % 60;
                                if (work_munite > 44) work_time_cal = work_hour + 1;
                                else if (work_munite > 24) work_time_cal = work_hour + 0.5;
                                else work_time_cal = work_hour;
                                if (work_time_cal > work_limit)
                                {
                                    over_time = work_time_cal - work_limit;
                                }
                            }
                            else
                            {
                                work_time_cal = 0;
                                over_time = 0;
                            }

                            update_query = @"update attendance_details set work_hour=" + work_time_cal + ",OUT_TIME=to_date('" + Convert.ToDateTime(out_time_convert).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh12:mi:ss am'),
                                             over_time=" + over_time + " where emp_id=" + emp_id + " and attd_date='" + attd_date + "' and NVL(attd_locked,'N')!='Y'";
                            db.RunDmlQuery(update_query);
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Z)
            {
                DBClass db = new DBClass();
                string in_time = "", out_time = "", del_query = "", select_query = "", strAttDate = "", intEID = "", emp_code = "";
                for (int i = 0; i < dgvAttd.SelectedRows.Count; i++)
                {
                    if (dgvAttd.SelectedRows[i].Cells["ATTD_LOCK"].Value.ToString().ToUpper() == "N")
                    {
                        strAttDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                        intEID = dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value.ToString();
                        emp_code = dgvAttd.SelectedRows[i].Cells["empCode"].Value.ToString();
                        select_query = @"select in_time,out_time from attendance_details where attd_date='" + strAttDate + "' and emp_id=" + intEID + "";
                        OracleDataReader dr = db.GetExecuteReader(select_query);
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                in_time = (dr.GetValue(0).ToString() == "") ? "" : dr.GetValue(0).ToString();
                                out_time = (dr.GetValue(1).ToString() == "") ? "" : dr.GetValue(1).ToString();
                            }
                        }
                        if (in_time == "" && out_time == "")
                        {
                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + "' ";
                            db.RunDmlQuery(del_query);
                        }
                        else if (in_time != "" && out_time == "")
                        {
                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + @"'
                                and MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(in_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am')";
                            db.RunDmlQuery(del_query);
                        }
                        else if (in_time == "" && out_time != "")
                        {
                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + @"'
                                and MOVEMENT_TIME=to_date('" + Convert.ToDateTime(out_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am')";
                            db.RunDmlQuery(del_query);
                        }
                        else
                        {
                            del_query = @"delete employee_movement_register where emp_code='" + emp_code + "'and attd_date='" + strAttDate + @"' 
                                and MOVEMENT_TIME>=to_date('" + Convert.ToDateTime(in_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + @"','dd-Mon-yyyy hh:mi:ss am') and 
                                MOVEMENT_TIME<=to_date('" + Convert.ToDateTime(out_time).ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh:mi:ss am')";
                            db.RunDmlQuery(del_query);
                        }
                    }
                }
            }
        }

        private CrystalReportViewerUC load_report_viewer()
        {
            payroll_main_form mForm = this.ParentForm as payroll_main_form;
            mForm.splitContainer1.Panel2.Controls.Clear();
            CrystalReportViewerUC report_viewer = new CrystalReportViewerUC();
            mForm.splitContainer1.Panel2.Controls.Add(report_viewer);
            report_viewer.Show();
            return report_viewer;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dgvAttd.Rows.Count > 0)
            {
                bool flag = true;
                DBClass db = new DBClass();
                int i, emp_id, shift_id, isintime, isouttime;
                string strQuery, strAttDate, strInTime, strLate, strOutTime, strOverTime, strStatus, strNight, strStatus2, strAttRemarks = "";

                for (i = 0; i < dgvAttd.Rows.Count && flag; i++)
                {
                    if (dgvAttd.Rows[i].Cells["rFlag"].Value != null && dgvAttd.Rows[i].Cells["rFlag"].Value.ToString() == "U")
                    {
                        strAttDate = dgvAttd.Rows[i].Cells["attDate"].Value.ToString();
                        strInTime = (dgvAttd.Rows[i].Cells["inTime"].Value == "") ? "" : Convert.ToDateTime(dgvAttd.Rows[i].Cells["inTime"].Value).ToString("HH:mm:ss");
                        strLate = dgvAttd.Rows[i].Cells["late"].Value.ToString();
                        strOutTime = (dgvAttd.Rows[i].Cells["outTime"].Value == "") ? "" : Convert.ToDateTime(dgvAttd.Rows[i].Cells["outTime"].Value).ToString("HH:mm:ss");
                        strOverTime = dgvAttd.Rows[i].Cells["overTime"].Value.ToString();
                        strStatus = dgvAttd.Rows[i].Cells["status"].Value.ToString().ToUpper();
                        strNight = dgvAttd.Rows[i].Cells["night"].Value.ToString();
                        strStatus2 = dgvAttd.Rows[i].Cells["status2"].Value.ToString().ToUpper();
                        emp_id = Convert.ToInt32(dgvAttd.Rows[i].Cells["EMP_ID"].Value);
                        shift_id = Convert.ToInt32(dgvAttd.Rows[i].Cells["shift_id"].Value);
                        isintime = Convert.ToInt32(dgvAttd.Rows[i].Cells["IS_IN_TIME"].Value);
                        isouttime = Convert.ToInt32(dgvAttd.Rows[i].Cells["IS_OUT_TIME"].Value);
                        strAttRemarks = dgvAttd.Rows[i].Cells["remarks"].Value.ToString();
                        if (strOutTime.Length > 0)
                        {
                            if (TimeSpan.Parse(strOutTime).Hours < 9) strOutTime = Convert.ToDateTime(strAttDate).AddDays(1).ToString("dd-MMM-yyyy") + " " + strOutTime;
                            else strOutTime = Convert.ToDateTime(strAttDate).ToString("dd-MMM-yyyy") + " " + strOutTime;
                        }
                        if (strInTime.Length > 0) strInTime = Convert.ToDateTime(strAttDate).ToString("dd-MMM-yyyy") + " " + strInTime;
                        strQuery = @"update ATTENDANCE_DETAILS set in_time=" + (strInTime.ToString() == "" ? "NULL" : "to_date('" + strInTime + "','dd-Mon-yyyy hh24:mi:ss')") + ", late = '" + strLate + "', out_time =" + (strOutTime.ToString() == "" ? "NULL" : " to_date('" + strOutTime + "','dd-Mon-yyyy hh24:mi:ss')") + ",over_time='" +
                            strOverTime + "',status='" + strStatus + "',night_status='" + strNight + "', status2='" + strStatus2 + "', ATTD_REMARKS='" + strAttRemarks + "',USER_ID= '" + CConfig.login_user_id + "',shift_id ='" + shift_id +
                            "' where attd_date =to_date('" + Convert.ToDateTime(strAttDate).ToString("dd-MMM-yyyy") + "','dd-Mon-yyyy') and emp_id='" + emp_id + "'";
                        flag = db.RunDmlQuery(strQuery);
                    }
                }
                if (flag == true)
                {
                    MessageBox.Show("Data Updated Successfully.", "Save As...", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    dgvAttd.Rows.Clear();
                }
                else MessageBox.Show("Data Updated Failed.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        
        }

        private void lOLOFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, intEID;
            bool uFlag = false;
            DBClass db = new DBClass();
            string strSql, strQuery, attDate = "";
            if (MessageBox.Show("Do You Want To Post LO", "Save As...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "l123")
                {
                    for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                        intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);

                        strQuery = "UPDATE ATTENDANCE_DETAILS SET IN_TIME='', LATE = '0', OUT_TIME = '', OVER_TIME='0',ATTD_LOCKED='Y',STATUS='L', NIGHT_STATUS='N', STATUS2='L', ATTD_REMARKS='LO',USER_ID = '" + ConfigurationManager.AppSettings["UserID"] + "', IS_IN_TIME_MANUAL='1',IS_OUT_TIME_MANUAL='1' WHERE NVL(ATTD_LOCKED,'N') !='Y' AND ATTD_DATE = '" + attDate + "' AND EMP_ID = '" + intEID + "'";
                        if (db.RunDmlQuery(strQuery))
                        {
                            strQuery = strQuery.Replace("'", string.Empty);
                            strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','ATTENDANCE_DETAILS','" + strQuery +
                                        "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + dgvAttd.SelectedRows[i].Cells["EMPCODE"].Value.ToString() + "')";
                            uFlag = db.RunDmlQuery(strSql);
                        }
                    }
                    if (uFlag == true)
                    {
                        MessageBox.Show("LO Posting Successfully", "Save As...", MessageBoxButtons.OK);
                        dgvAttd.Rows.Clear();
                    }
                }
                else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Action Canceled");
        }

        private void lOWLOFWeekendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, intEID;
            bool uFlag = false;
            DBClass db = new DBClass();
            string strSql, strQuery, attDate = "";
            if (MessageBox.Show("Do You Want To Post LOW", "Save As...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "l123")
                {
                    for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                        intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);

                        strQuery = "UPDATE ATTENDANCE_DETAILS SET IN_TIME='', LATE = '0', OUT_TIME = '', OVER_TIME='0',ATTD_LOCKED='Y',STATUS='L', NIGHT_STATUS='N', STATUS2='L', ATTD_REMARKS='LOW',USER_ID = '" + ConfigurationManager.AppSettings["UserID"] + "', IS_IN_TIME_MANUAL='1',IS_OUT_TIME_MANUAL='1' WHERE NVL(ATTD_LOCKED,'N') !='Y' AND ATTD_DATE = '" + attDate + "' AND EMP_ID = '" + intEID + "'";
                        if (db.RunDmlQuery(strQuery))
                        {
                            strQuery = strQuery.Replace("'", string.Empty);
                            strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','ATTENDANCE_DETAILS','" + strQuery +
                                        "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + dgvAttd.SelectedRows[i].Cells["EMPCODE"].Value.ToString() + "')";
                            uFlag = db.RunDmlQuery(strSql);
                        }
                    }
                    if (uFlag == true)
                    {
                        MessageBox.Show("LOW Posting Successfully", "Save As...", MessageBoxButtons.OK);
                        dgvAttd.Rows.Clear();
                    }
                }
                else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Action Canceled");
        }

        private void leaveGLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, intEID;
            bool uFlag = false;
            DBClass db = new DBClass();
            string strSql, strQuery, attDate = "";
            if (MessageBox.Show("Do You Want To Post GL", "Save As...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                objSecurityInputBox.ShowDialog();
                if (txtPassword.Text == "l123")
                {
                    for (i = 0; i < dgvAttd.SelectedRows.Count; i++)
                    {
                        attDate = dgvAttd.SelectedRows[i].Cells["attDate"].Value.ToString();
                        intEID = Convert.ToInt32(dgvAttd.SelectedRows[i].Cells["EMP_ID"].Value);

                        strQuery = "UPDATE ATTENDANCE_DETAILS SET IN_TIME='', LATE = '0', OUT_TIME = '', OVER_TIME='0',ATTD_LOCKED='Y',STATUS='L', NIGHT_STATUS='N', STATUS2='L', ATTD_REMARKS='GL',USER_ID = '" + ConfigurationManager.AppSettings["UserID"] + "', IS_IN_TIME_MANUAL='1',IS_OUT_TIME_MANUAL='1' WHERE NVL(ATTD_LOCKED,'N') !='Y' AND ATTD_DATE = '" + attDate + "' AND EMP_ID = '" + intEID + "'";
                        uFlag = db.RunDmlQuery(strQuery);
                     }
                    if (uFlag == true)
                    {
                        MessageBox.Show("GL Posting Successfully", "Save As...", MessageBoxButtons.OK);
                        dgvAttd.Rows.Clear();
                    }
                }
                else MessageBox.Show("Invalied Security Code", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Action Canceled");
        }
    }
}