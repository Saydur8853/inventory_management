using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.Design;
using System.IO;

namespace NGPayroll
{
    public partial class Report_New_Recruitment_UC : UserControl
    {

        List<int> srcUnit = new List<int>();
        List<int> srcEmpType = new List<int>();
        List<int> srcDept = new List<int>();
        List<int> srcSec = new List<int>();
        List<int> srcLine = new List<int>();
        List<int> srcShift = new List<int>();
        List<int> srcDesig = new List<int>();
        List<int> srcEmpCode = new List<int>();
        public Report_New_Recruitment_UC()
        {
            InitializeComponent();

            func_combo_unit();
            func_combo_emp_type();
            func_combo_department();
            func_combo_section();
            func_combo_line();
            func_combo_desig();
            func_combo_shift();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            payroll_main_form main_form = this.ParentForm as payroll_main_form; // new payroll_main_form();
            main_form.splitContainer1.Panel2.Controls.Clear();

            ucDashboard objDashBoard = new ucDashboard();
            main_form.splitContainer1.Panel2.Controls.Add(objDashBoard);
            objDashBoard.Show();
        } // End of private void btn_exit_Click(object sender, EventArgs e)

        void func_combo_unit()
        {
            string query = "SELECT UNIT_ID, UNIT_NAME FROM UNIT ORDER BY UNIT_NAME";
            DBClass db = new DBClass();
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                combo_unit_name.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }

            combo_unit_name.DisplayMember = "Key";
            combo_unit_name.ValueMember = "Value";
        } // End of void func_combo_unit()

        void func_combo_emp_type()
        {
            string query = "SELECT EMP_CATEGORY_ID, EMP_CATEGORY_NAME FROM EMP_CATEGORY ORDER BY EMP_CATEGORY_NAME";
            DBClass db = new DBClass();
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                combo_emp_type.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }

            combo_emp_type.DisplayMember = "Key";
            combo_emp_type.ValueMember = "Value";
        } // End of void func_combo_emp_type()

        void func_combo_department()
        {
            string sql = "SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM DEPARTMENT ORDER BY DEPARTMENT_NAME";
            DBClass db = new DBClass();
            OracleDataReader dr = db.GetExecuteReader(sql);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                combo_dept.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }

            combo_dept.DisplayMember = "Key";
            combo_dept.ValueMember = "Value";
        } // End of void func_combo_department()

        void func_combo_section()
        {
            string query = "SELECT SECTION_ID, SECTION_NAME FROM SECTION ORDER BY SECTION_NAME";
            DBClass db = new DBClass();
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                combo_sec.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }

            combo_sec.DisplayMember = "Key";
            combo_sec.ValueMember = "Value";
        } // End of void func_combo_section()

        void func_combo_line()
        {
            string query = "SELECT LINE_ID, LINE_NAME FROM LINE ORDER BY LINE_NAME";
            DBClass db = new DBClass();
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                combo_line_name.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }

            combo_line_name.DisplayMember = "Key";
            combo_line_name.ValueMember = "Value";
        } // End of void func_combo_line()

        void func_combo_desig()
        {
            string query = "SELECT DESIGNATION_ID, DESIGNATION_NAME FROM DESIGNATION ORDER BY DESIGNATION_NAME";
            DBClass db = new DBClass();
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                combo_desig.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }

            combo_desig.DisplayMember = "Key";
            combo_desig.ValueMember = "Value";
        } // End of void func_combo_desig()

        void func_combo_shift()
        {
            string query = "SELECT SHIFT_ID, SHIFT_NAME FROM SHIFT_INFO ORDER BY SHIFT_NAME";
            DBClass db = new DBClass();
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                combo_shift.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }

            combo_shift.DisplayMember = "Key";
            combo_shift.ValueMember = "Value";
        } // End of void func_combo_shift()
        
        private CrystalReportViewerUC load_report_viewer()
        {
            payroll_main_form form = this.ParentForm as payroll_main_form;
            form.splitContainer1.Panel2.Controls.Clear();
            CrystalReportViewerUC report_viewer = new CrystalReportViewerUC();
            form.splitContainer1.Panel2.Controls.Add(report_viewer);
            report_viewer.Show();
            return report_viewer;
        }
        private void PopulateSearchVariable()
        {
            srcUnit = new List<int>();
            srcEmpType = new List<int>();
            srcDept = new List<int>();
            srcSec = new List<int>();
            srcLine = new List<int>();
            srcShift = new List<int>();
            srcDesig = new List<int>();
            srcEmpCode = new List<int>();

            foreach (DataGridViewRow cmb_Dgvr in dataGridView_list.Rows)
            {
                if (cmb_Dgvr.Cells[0].Value == null) break;
                if (cmb_Dgvr.Cells[2].Value.ToString() == "Unit")
                {
                    srcUnit.Add(Convert.ToInt32(cmb_Dgvr.Cells[1].Value.ToString()));
                }
                else if (cmb_Dgvr.Cells[2].Value.ToString() == "EmpType")
                {
                    srcEmpType.Add(Convert.ToInt32(cmb_Dgvr.Cells[1].Value.ToString()));
                }
                else if (cmb_Dgvr.Cells[2].Value.ToString() == "Dept")
                {
                    srcDept.Add(Convert.ToInt32(cmb_Dgvr.Cells[1].Value.ToString()));
                }
                else if (cmb_Dgvr.Cells[2].Value.ToString() == "Sec")
                {
                    srcSec.Add(Convert.ToInt32(cmb_Dgvr.Cells[1].Value.ToString()));
                }
                else if (cmb_Dgvr.Cells[2].Value.ToString() == "Line")
                {
                    srcLine.Add(Convert.ToInt32(cmb_Dgvr.Cells[1].Value.ToString()));
                }
                else if (cmb_Dgvr.Cells[2].Value.ToString() == "Shift")
                {
                    srcShift.Add(Convert.ToInt32(cmb_Dgvr.Cells[1].Value.ToString()));
                }
                else if (cmb_Dgvr.Cells[2].Value.ToString() == "Desig")
                {
                    srcDesig.Add(Convert.ToInt32(cmb_Dgvr.Cells[1].Value.ToString()));
                }
                else if (cmb_Dgvr.Cells[2].Value.ToString() == "EmpCode")
                {
                    srcEmpCode.Add(Convert.ToInt32(cmb_Dgvr.Cells[1].Value.ToString()));
                }
            }   // End of foreach (DataGridViewRow cmb_Dgvr in dataGridView_list.Rows)
        }   // End of private void PopulateSearchVariable()

        private string generate_sub_query(string field_name_for_date = null)
        {
            PopulateSearchVariable();
            string sub_query = "";

            if (srcUnit.Count > 0 || combo_unit_name.SelectedIndex > -1)
            {
                sub_query += GenrateCode(combo_unit_name, "UNIT_ID", srcUnit);

            }
            if (srcEmpType.Count > 0 || combo_emp_type.SelectedIndex > -1)
            {
                sub_query += GenrateCode(combo_emp_type, "EMP_CATEGORY_ID", srcEmpType);
            }
            if (srcDept.Count > 0 || combo_dept.SelectedIndex > -1)
            {
                sub_query += GenrateCode(combo_dept, "DEPARTMENT_ID", srcDept);
            }

            if (srcSec.Count > 0 || combo_sec.SelectedIndex > -1)
            {
                sub_query += GenrateCode(combo_sec, "SECTION_ID", srcSec);
            }

            if (srcLine.Count > 0 || combo_line_name.SelectedIndex > -1)
            {
                sub_query += GenrateCode(combo_line_name, "LINE_ID", srcLine);
            }

            if (srcShift.Count > 0 || combo_shift.SelectedIndex > -1)
            {
                sub_query += GenrateCode(combo_shift, "SHIFT_ID", srcShift);
            }

            if (srcDesig.Count > 0 || combo_desig.SelectedIndex > -1)
            {
                sub_query += GenrateCode(combo_desig, "DESIGNATION_ID", srcDesig);
            }

            if (srcEmpCode.Count > 0 || txt_emp_code.Text != "")
            {
                sub_query += GenrateCode(txt_emp_code, "EMP_CODE", srcEmpCode);
            }

            if ((field_name_for_date != null) && (chk_dt.Checked))
            {
                sub_query = sub_query + " AND " + field_name_for_date + " BETWEEN '" + from_DTPicker.Text + "' AND '" + to_DTPicker.Text + @"'";
            }
            else
            {
                sub_query = sub_query + " AND " + field_name_for_date + " <'" + to_DTPicker.Text + @"' ";
            }

            return sub_query;
        }

        private string GenrateCode(object FieldObject, string db_coloum_id, List<int> srcList)
        {
            string sub_query = "";
            bool flag = false;
            if (FieldObject.ToString().Contains("ComboBox"))
            {
                ComboBox combo_name = (ComboBox)FieldObject;
                if (combo_name.SelectedIndex > -1)
                {
                    KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_name.SelectedItem;
                    sub_query += " AND E_O." + db_coloum_id + " IN ('" + selected_item.Value.ToString();
                    flag = true;
                }
            }
            else
            {
                TextBox combo_name = (TextBox)FieldObject;
                if (combo_name.Text != "")
                {
                    sub_query += " AND E_O." + db_coloum_id + " IN ('" + combo_name.Text;
                    flag = true;
                }
            }

            if (srcList.Count > 0)
            {
                if (flag)
                    sub_query += "', '" + srcList[0].ToString();
                else
                    sub_query += " AND E_O." + db_coloum_id + " IN ('" + srcList[0].ToString();
                for (int i = 1; i < srcList.Count; i++)
                {
                    sub_query += "', '" + srcList[i].ToString();
                }
            }
            sub_query += "')";
            return sub_query;
        }

        private void btn_id_card_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT U.UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                E_O.EMP_NAME,
                                E_O.UNIT_ID,
                                E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,
                                E_O.SECTION_ID,
                                E_O.LINE_ID,
                                E_O.SHIFT_ID,
                                L.LINE_NAME AS IN_TIME31,
                                E_O.DESIGNATION_ID,
                                E_O.DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.EMP_PHOTO,
                                SIGN.SIGNATURE,
                                E_P.PARMENENT_ADDRESS AS IN_TIME30,
                                INITCAP((E_P.PARMANENT_HOUSE)||',') AS IN_TIME6,
                                INITCAP((E_P.PARMANENT_VILL)||',') AS IN_TIME7,
                                INITCAP((E_P.PARMANENT_PS)||',') AS IN_TIME8,
                                INITCAP((E_P.PARMANENT_DIST)||',') AS IN_TIME9,
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                SEC.SECTION_NAME  AS IN_TIME5,
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,LINE L,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                EMP_SIGNATURE SIGN,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.EMP_ID=SIGN.EMP_ID(+)
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                AND E_O.EMP_STATUS='Active' " + sub_query + @"
                            ORDER BY DEP.DEPARTMENT_NAME, SEC.SECTION_NAME, E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();
            var report_path = db.GetReportPath() + "rpt_id_card_tfl.rpt";
            r_d.Load(report_path);
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        } // End of private void btn_id_card_Click(object sender, EventArgs e)

        private void btn_single_id_card_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT U.UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                E_O.EMP_NAME,
                                E_O.UNIT_ID,
                                E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,
                                E_O.SECTION_ID,
                                E_O.LINE_ID,
                                E_O.SHIFT_ID,
                                L.LINE_NAME AS IN_TIME31,
                                E_O.DESIGNATION_ID,
                                E_O.DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.EMP_PHOTO,
                                SIGN.SIGNATURE,
                                E_P.PARMENENT_ADDRESS AS IN_TIME30,
                                INITCAP((E_P.PARMANENT_HOUSE)||',') AS IN_TIME6,
                                INITCAP((E_P.PARMANENT_VILL)||',') AS IN_TIME7,
                                INITCAP((E_P.PARMANENT_PS)||',') AS IN_TIME8,
                                INITCAP((E_P.PARMANENT_DIST)||',') AS IN_TIME9,
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                SEC.SECTION_NAME AS IN_TIME5,
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,LINE L,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                EMP_SIGNATURE SIGN,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                 AND E_O.EMP_ID=SIGN.EMP_ID(+)
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                AND E_O.EMP_STATUS='Active' " + sub_query + @"
                            ORDER BY DEP.DEPARTMENT_NAME, SEC.SECTION_NAME, E_O.EMP_CODE ASC";
            
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_id_card_single_tfl_f.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        } // End of private void btn_single_id_card_Click(object sender, EventArgs e)

        private void btn_declaration_letter_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");

            string sql = @"SELECT e_o.emp_name,e_o.emp_code,
                                DEPARTMENT_NAME,SECTION_NAME,
                                LINE_NAME,EMP_CATEGORY_NAME,
                                U.UNIT_NAME,des.designation_name,
                                to_char(e_o.date_of_joining, 'dd-Mon-yyyy') as date_of_joining,
                                e_p.father_name as in_time1,
                                E_P.PARMANENT_HOUSE as in_time2,
                                E_P.PARMANENT_VILL as in_time3,
                                E_P.PARMANENT_PS as in_time4,
                                E_P.PARMANENT_DIST as in_time5
                            from emp_official e_o, 
                                emp_personal e_p,
                                designation des,
                                unit u,EMP_CATEGORY E_C,DEPARTMENT DEP,SECTION S,LINE L
                            where e_o.emp_id=e_p.emp_id AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                and u.unit_id=e_o.unit_id AND E_O.EMP_CATEGORY_ID=E_C.EMP_CATEGORY_ID
                                and e_o.designation_id=des.designation_id AND E_O.SECTION_ID=S.SECTION_ID
                                and e_o.emp_status='Active' AND E_O.LINE_ID=L.LINE_ID " + sub_query + @"
                            order by e_o.emp_code asc";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_declaration_letter_tfl.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        } // End of private void btn_declaration_letter_Click(object sender, EventArgs e)

        private void btnAgeCertificateEng_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sql = @"Select u.unit_name as emp_category_Name,
                                u.address as status, e_o.emp_name,
                                e_o.date_of_joining as attd_date, 
                                e_o.emp_code, sec.section_name, l.line_name,
                                (e_o.emp_code||'/'||sec.section_name||'/'||l.line_name) OVER_TIME,
                                UPPER(
                                CASE
                                    WHEN E_P.SEX='FEMALE' AND E_P.MARITAL_STATUS !='SINGLE'
                                        THEN NVL(E_P.HUSBAND_NAME,NVL(E_P.FATHER_NAME,''))
                                    ELSE NVL(E_P.FATHER_NAME,NVL(E_P.MOTHER_NAME,''))
                                END) AS shift_name,      --------------------------(FATHER/HUSBAND/WIFE) NAME
                                INITCAP(NVL(E_P.PRESENT_VILL,E_P.PRESENT_HOUSE)||', '||NVL(E_P.PRESENT_HOUSE,E_P.PRESENT_PS)||', '||NVL(E_P.PRESENT_PS,E_P.PRESENT_DIST)||', '||NVL(E_P.PRESENT_DIST,'')) as out_time,
                                INITCAP(NVL(E_P.PARMANENT_HOUSE,E_P.PARMANENT_VILL)||', '||NVL(E_P.PARMANENT_VILL,E_P.PARMANENT_PS)||', '||NVL(E_P.PARMANENT_PS,E_P.PARMANENT_DIST)||', '||NVL(E_P.PARMANENT_DIST,'')) as early_out,
                                e_p.emp_photo 
                            from emp_official e_o,
                                emp_personal e_p,
                                section sec,
                                line l,
                                unit u
                            Where e_o.section_id=sec.section_id
                                and e_o.line_id=l.line_id
                                and e_o.emp_id=e_p.emp_id
                                and e_o.unit_id=u.unit_id
                                and e_o.emp_status='Active'" + generate_sub_query("E_O.DATE_OF_JOINING") + @"
                            order by e_o.emp_code asc";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_AgeCertificate.rpt");
            r_d.Database.Tables["daily_attendance_report"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        } // End of private void btn_age_certificate_Click(object sender, EventArgs e)

        private void btnAppointmentLetterBang_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sql = @"SELECT DISTINCT E_O.EMP_CODE,E_O.GROSS,
                                E_O.BANG_EMP_NAME  AS EMP_NAME,
                                NVL(E_P.BANG_FATHER_NAME ,'') AS FATHER_NAME,
                                NVL(E_P.BANG_MOTHER_NAME,'') AS MOTHER_NAME,
                                NVL(E_P.BANG_HUSBAND_NAME,'') AS HUSBAND_NAME,
                                (E_P.BANG_PARMANENT_POST) AS PER_HOUSE,
                                (E_P.BANG_PARMANENT_VILL) AS PER_VILLAGE,
                                (E_P.BANG_PARMANENT_PS) AS PER_PS,
                                (E_P.BANG_PARMANENT_DIST) AS PER_DISTRICT,
                                (E_P.BANG_PRESENT_VILL) AS PRE_VILLAGE,
                                (E_P.BANG_PRESENT_POST) AS PRE_HOUSE,
                                (E_P.BANG_PRESENT_PS) AS PRE_PS,
                                (E_P.BANG_PRESENT_DIST) AS PRE_DISTRICT,
                                E_O.DATE_OF_JOINING,E_O.EMP_GRADE,to_Char(E_P.DATE_OF_BIRTH,'dd-Mon-yyyy') DATE_OF_BIRTH,
                                SEC.BANG_SEC_NAME SECTION_NAME,
                                E_C.BANG_EMP_TYPE_NAME EMP_CATEGORY_NAME
                                ,DEP.BANG_DEPT_NAME AS DEPARTMENT_NAME 
                                ,DES.BANG_DESIGNATION_NAME AS DESIGNATION_NAME
                                ,S_R_INFO.RULE_TRANSPORT,
                                S_R_INFO.RULE_MEDICAL,
                                (U.UNIT_NAME) AS UNIT_NAME,
                                --(U.ADDRESS) AS ADDRESS,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100),ROUND((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))) AS BASIC,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100)/2,ROUND(((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))* RULE_HOUSE_RENT/100)) AS HOUSE_RENT,
                                RULE_FOOD AS ADDRESS
                            FROM EMP_PERSONAL E_P,EMP_OFFICIAL E_O,DEPARTMENT DEP,DESIGNATION DES,UNIT U,SALARY_RULE_INFO S_R_INFO,SECTION SEC,EMP_CATEGORY E_C
                            WHERE E_O.EMP_ID=E_P.EMP_ID AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=E_C.EMP_CATEGORY_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.RULE_ID=S_R_INFO.RULE_ID                                
                                AND E_O.EMP_STATUS='Active'" + generate_sub_query("E_O.DATE_OF_JOINING") + @"
                            ORDER BY E_O.EMP_CODE ASC";
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_appointment_letter_tfl.rpt");
            r_d.Database.Tables["appointment_letter"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        } // End of private void btn_appointment_letter_Click(object sender, EventArgs e)

        private void btn_joining_letter_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();
            
            string sql = @"SELECT NULL EMP_ID,E_O.EMP_CODE,
                                E_O.DATE_OF_JOINING, 
                                UPPER(E_O.EMP_NAME) AS EMP_NAME,
                                UPPER(CASE
                                    WHEN E_P.SEX='FEMALE' AND E_P.MARITAL_STATUS !='SINGLE'
                                        THEN NVL(E_P.HUSBAND_NAME,E_P.FATHER_NAME)
                                    ELSE NVL(E_P.FATHER_NAME,'')
                                END) EMP_CATEGORY,
                                E_C.EMP_CATEGORY_NAME,
                                SYSDATE AS WEEKEND,
                                INITCAP(U.UNIT_NAME) AS UNIT_NAME,
                                INITCAP(U.ADDRESS) AS ADDRESS,
                                DEP.DEPARTMENT_NAME,
                                SEC.SECTION_NAME,
                                UPPER(DES.DESIGNATION_NAME) AS DESIGNATION_NAME
                            FROM EMP_OFFICIAL E_O, 
                                EMP_PERSONAL E_P,
                                DEPARTMENT DEP,
                                UNIT U,SECTION SEC,
                                DESIGNATION DES,EMP_CATEGORY E_C
                            WHERE E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.EMP_CATEGORY_ID=E_C.EMP_CATEGORY_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.EMP_STATUS='Active' " + sub_query + @"
                            ORDER BY E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_joining_letter_tfl.rpt");
            r_d.Database.Tables["regular_employee_status"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        } // End of private void btn_joining_letter_Click(object sender, EventArgs e)

        private void btnEmpInfoVerificationForm_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();
        
            string sql = @"SELECT DISTINCT U.ADDRESS,
                                INITCAP(U.UNIT_NAME) AS UNIT_NAME,
                                E_O.UNIT_ID,
                                E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,
                                E_O.SECTION_ID,
                                E_O.LINE_ID,
                                E_O.SHIFT_ID,
                                E_O.DESIGNATION_ID,
                                E_O.EMP_CODE,
                                E_O.EMP_NAME,
                                DEP.DEPARTMENT_NAME AS SECTION_NAME,
                                UPPER(DES.DESIGNATION_NAME) AS DESIGNATION_NAME,
                                UPPER(CASE
                                    WHEN  UPPER(DEP.DEPARTMENT_NAME)=UPPER(SEC.SECTION_NAME)
                                        THEN DEP.DEPARTMENT_NAME
                                    WHEN  UPPER(DEP.DEPARTMENT_NAME)<>UPPER(SEC.SECTION_NAME)
                                        THEN DEP.DEPARTMENT_NAME||' / '||SEC.SECTION_NAME 
                                    ELSE NULL
                                END) DEPARTMENT_NAME,
                                E_P.DATE_OF_BIRTH AS DATE_OF_JOINING, 
                                UPPER(
                                CASE
                                    WHEN E_P.SEX='FEMALE' AND E_P.MARITAL_STATUS !='SINGLE'
                                        THEN NVL(E_P.HUSBAND_NAME,E_P.FATHER_NAME)
                                    ELSE NVL(E_P.FATHER_NAME,'')
                                END) AS IN_TIME1, --NVL(E_P.FATHER_NAME,E_P.HUSBAND_NAME)
                                UPPER(NVL(E_P.MOTHER_NAME,'')) AS IN_TIME2,
                                TRUNC(MONTHS_BETWEEN(SYSDATE,E_P.DATE_OF_BIRTH)/12) AS IN_TIME3,
                                INITCAP(NVL(E_P.PARMANENT_HOUSE,'')) AS IN_TIME4,
                                INITCAP(NVL(E_P.PARMANENT_VILL,'')) AS IN_TIME5,
                                INITCAP(NVL(E_P.PARMANENT_PS,'')) AS IN_TIME6,
                                INITCAP(NVL(E_P.PARMANENT_DIST,'')) AS IN_TIME7,
                                UPPER(E_O.BENEFICIARY_NAME) AS IN_TIME8,
                                E_O.RELATION_WITH_BENEFICIARY AS IN_TIME9,
                                E_P.CONTACT_NO AS IN_TIME10,
                                INITCAP(NVL(E_P.PRESENT_VILL,'')) AS IN_TIME11,
                                INITCAP(NVL(E_P.PRESENT_HOUSE,'')) AS IN_TIME12,
                                INITCAP(NVL(E_P.PRESENT_PS,'')) AS IN_TIME13,
                                INITCAP(NVL(E_P.PRESENT_DIST,'')) AS IN_TIME14,
                                J_H.JOB_COMPANY_NAME AS IN_TIME15,
                                J_H.JOB_ADDRESS AS IN_TIME16,
                                J_H.JOB_DESIGNATION AS IN_TIME17,
                                TRUNC(MONTHS_BETWEEN(J_H.JOB_END,J_H.JOB_START)/12) AS IN_TIME18,
                                CASE
                                    WHEN (TRUNC(J_H.JOB_END-ADD_MONTHS(J_H.JOB_START,TRUNC(MONTHS_BETWEEN(J_H.JOB_END,J_H.JOB_START)/12)*12 + TRUNC(MOD(MONTHS_BETWEEN(J_H.JOB_END,J_H.JOB_START),12)))+1))>15
                                        THEN TRUNC(MOD(MONTHS_BETWEEN(J_H.JOB_END,J_H.JOB_START),12)+1)
                                    ELSE TRUNC(MOD(MONTHS_BETWEEN(J_H.JOB_END,J_H.JOB_START),12))
                                END AS IN_TIME19,
                                J_H.JOB_CONTACT AS IN_TIME20,
                                CASE
                                    WHEN E_O.EMP_CATEGORY_ID IN (4,5)
                                        THEN  'STAFF'||' & '|| 'OFFICER '
                                    ELSE CAT.EMP_CATEGORY_NAME
                                END EMP_CATEGORY_NAME
                            FROM UNIT U,
                               EMP_PERSONAL E_P, 
                               EMP_OFFICIAL E_O, 
                               DESIGNATION DES,
                               DEPARTMENT DEP, 
                               EMP_CATEGORY CAT,
                               JOB_HISTORY J_H,
                               SECTION SEC
                           WHERE E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                AND E_O.EMP_ID= J_H.EMP_ID( + )
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_STATUS='Active' " + sub_query + @"
                            ORDER BY CASE
                                    WHEN E_O.EMP_CATEGORY_ID IN (4,5)
                                        THEN  'STAFF'||' & '|| 'OFFICER '
                                    ELSE CAT.EMP_CATEGORY_NAME
                                END, DEPARTMENT_NAME, TO_NUMBER(E_O.EMP_CODE)";
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_EmpInfoVerificationForm.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]); 
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        } // End of private void btn_verification_letter_Click(object sender, EventArgs e)
        
        private void btn_clear_Click(object sender, EventArgs e)
        {
            dataGridView_list.Rows.Clear();
            srcDesig = new List<int>();
            srcDept = new List<int>();
            srcEmpCode = new List<int>();
            srcEmpType = new List<int>();
            srcLine = new List<int>();
            srcSec = new List<int>();
            srcShift = new List<int>();
            srcUnit = new List<int>();
            combo_unit_name.SelectedIndex = -1;
            combo_emp_type.SelectedIndex = -1;
            combo_dept.SelectedIndex = -1;
            combo_sec.SelectedIndex = -1;
            combo_line_name.SelectedIndex = -1;
            combo_shift.SelectedIndex = -1;
            txt_emp_code.Text = null;
        } // End of private void btn_clear_Click(object sender, EventArgs e)

        private void btn_clear_MouseHover(object sender, EventArgs e)
        {
            ToolTip popMenuHelp = new ToolTip();
            popMenuHelp.ToolTipTitle = "Help";
            popMenuHelp.IsBalloon = true;
            popMenuHelp.SetToolTip(btn_clear, "Click To Clear All");
        } // End of private void btn_clear_MouseHover(object sender, EventArgs e)

        private void btn_exit_MouseHover(object sender, EventArgs e)
        {
            ToolTip popMenuHelp = new ToolTip();
            popMenuHelp.ToolTipTitle = "Help";
            popMenuHelp.IsBalloon = true;
            popMenuHelp.SetToolTip(btn_exit, "Click To Exit");
        }

        private void btn_emp_with_pic_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT INITCAP(U.UNIT_NAME) AS UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME,
                                E_O.DATE_OF_JOINING,
                                E_P.EMP_PHOTO,
                                UPPER(DES.DESIGNATION_NAME) AS DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                SEC.SECTION_NAME AS IN_TIME5,
                                E_O.EMP_STATUS_CHANGE_DATE AS IN_TIME31,
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                AND E_O.EMP_STATUS='Active' " + sub_query + @"
                            ORDER BY DEP.DEPARTMENT_NAME, SEC.SECTION_NAME, E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();

            var report_path = db.GetReportPath() + "rpt_emp_with_pic_tfl.rpt";
            r_d.Load(report_path);
            
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        } // End of private void btn_single_id_card_Click(object sender, EventArgs e)

        private void btn_id_card_with_no_pic_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT U.UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                E_O.EMP_NAME,
                                E_O.UNIT_ID,
                                E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,
                                E_O.SECTION_ID,
                                E_O.LINE_ID,
                                E_O.SHIFT_ID,
                                L.LINE_NAME AS IN_TIME31,
                                E_O.DESIGNATION_ID,
                                E_O.DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.PHOTO AS IN_TIME4,
                                E_P.PARMENENT_ADDRESS  AS IN_TIME31,
                                INITCAP((E_P.PARMANENT_HOUSE)||',') AS IN_TIME6,
                                INITCAP((E_P.PARMANENT_VILL)||',') AS IN_TIME7,
                                INITCAP((E_P.PARMANENT_PS)||',') AS IN_TIME8,
                                INITCAP((E_P.PARMANENT_DIST)||',') AS IN_TIME9,
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                SEC.SECTION_NAME  AS IN_TIME5,
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                LINE L,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                AND E_O.EMP_STATUS='Active' " + sub_query + @"
                            ORDER BY DEP.DEPARTMENT_NAME, SEC.SECTION_NAME, E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();

            var report_path = db.GetReportPath() + "rpt_id_card_with_no_pic.rpt";
            r_d.Load(report_path);
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }// End of private void btn_id_card_with_no_pic_Click(object sender, EventArgs e)
        

        private void btn_add_unit_Click(object sender, EventArgs e)
        {
            if (combo_unit_name.Text != "")
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_unit_name.SelectedItem;
                dataGridView_list.Rows.Add(combo_unit_name.Text, selected_item.Value,"Unit");
                combo_unit_name.SelectedIndex = -1;
                combo_unit_name.Focus();
            }
        }// End of private void add_unit_Click(object sender, EventArgs e)

        private void btn_add_emp_type_Click(object sender, EventArgs e)
        {
            if (combo_emp_type.Text != "")
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_emp_type.SelectedItem;
                dataGridView_list.Rows.Add(combo_emp_type.Text, selected_item.Value,"EmpType");
                combo_emp_type.SelectedIndex = -1;
                combo_emp_type.Focus();
            }
        }// End of private void btn_add_emp_type_Click(object sender, EventArgs e)

        private void btn_add_dept_Click(object sender, EventArgs e)
        {
            if (combo_dept.Text != "")
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_dept.SelectedItem;
                dataGridView_list.Rows.Add(combo_dept.Text, selected_item.Value,"Dept");
                combo_dept.SelectedIndex =-1;
                combo_dept.Focus();
            }
        }// End of private void btn_add_dept_Click(object sender, EventArgs e)

        private void btn_add_sec_Click(object sender, EventArgs e)
        {
            if (combo_sec.Text != "")
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_sec.SelectedItem;
                dataGridView_list.Rows.Add(combo_sec.Text, selected_item.Value,"Sec");
                combo_sec.SelectedIndex = -1;
                combo_sec.Focus();
            }
        }// End of private void btn_add_sec_Click(object sender, EventArgs e)

        private void btn_add_line_Click(object sender, EventArgs e)
        {
            if (combo_line_name.Text != "")
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_line_name.SelectedItem;
                dataGridView_list.Rows.Add(combo_line_name.Text, selected_item.Value,"Line");
                combo_line_name.SelectedIndex = -1;
                combo_line_name.Focus();
            }
        }// End of private void btn_add_line_Click(object sender, EventArgs e)

        private void btn_add_shift_Click(object sender, EventArgs e)
        {
            if (combo_shift.Text != "")
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_shift.SelectedItem;
                dataGridView_list.Rows.Add(combo_shift.Text, selected_item.Value, "Shift");
                combo_shift.SelectedIndex = -1;
                combo_shift.Focus();
            }
        }// End of private void btn_add_shift_Click(object sender, EventArgs e)

        private void btn_add_desig_Click(object sender, EventArgs e)
        {
            if (combo_desig.Text != "")
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_desig.SelectedItem;
                dataGridView_list.Rows.Add(combo_desig.Text, selected_item.Value,"Desig");
                combo_desig.SelectedIndex = -1;
                combo_desig.Focus();
            }
        }// End of private void btn_add_desig_Click(object sender, EventArgs e)

        private void btn_add_emp_code_Click(object sender, EventArgs e)
        {
            if (txt_emp_code.Text != "")
            {
                dataGridView_list.Rows.Add(txt_emp_code.Text, txt_emp_code.Text, "EmpCode");
                txt_emp_code.Text = "";
                txt_emp_code.Focus();
            }
        } // End of private void btn_add_emp_code_Click(object sender, EventArgs e)

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView_list.Rows.Clear();
            srcDesig = new List<int>();
            srcDept = new List<int>();
            srcEmpCode = new List<int>();
            srcEmpType = new List<int>();
            srcLine = new List<int>();
            srcSec = new List<int>();
            srcShift = new List<int>();
            srcUnit = new List<int>();

        }// End of private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        
        private void btn_single_id_b_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT U.UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                E_O.EMP_NAME,
                                E_O.UNIT_ID,
                                E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,
                                E_O.SECTION_ID,
                                E_O.LINE_ID,
                                E_O.SHIFT_ID,
                                L.LINE_NAME AS IN_TIME31,
                                E_O.DESIGNATION_ID,
                                E_O.DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.PARMENENT_ADDRESS AS IN_TIME30,
                                INITCAP((E_P.PARMANENT_HOUSE)||',') AS IN_TIME6,
                                INITCAP((E_P.PARMANENT_VILL)||',') AS IN_TIME7,
                                INITCAP((E_P.PARMANENT_PS)||',') AS IN_TIME8,
                                INITCAP((E_P.PARMANENT_DIST)||',') AS IN_TIME9,
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                SEC.SECTION_NAME  AS IN_TIME5,
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                LINE L,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                AND E_O.EMP_STATUS='Active' " + sub_query + @"
                            ORDER BY DEP.DEPARTMENT_NAME, SEC.SECTION_NAME, E_O.EMP_CODE ASC";
            
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_id_card_single_tfl_b.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }// End of private void btn_id_card_reg_Click(object sender, EventArgs e)

        private void btn_id_card_reg_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT U.UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                E_O.EMP_NAME,
                                E_O.UNIT_ID,
                                E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,
                                E_O.SECTION_ID,
                                E_O.LINE_ID,
                                E_O.SHIFT_ID,
                                L.LINE_NAME AS IN_TIME31,
                                E_O.DESIGNATION_ID,
                                E_O.DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.EMP_PHOTO,
                                SIGN.SIGNATURE,
                                E_P.PARMENENT_ADDRESS AS IN_TIME30,
                                INITCAP((E_P.PARMANENT_HOUSE)||',') AS IN_TIME6,
                                INITCAP((E_P.PARMANENT_VILL)||',') AS IN_TIME7,
                                INITCAP((E_P.PARMANENT_PS)||',') AS IN_TIME8,
                                INITCAP((E_P.PARMANENT_DIST)||',') AS IN_TIME9,
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                SEC.SECTION_NAME  AS IN_TIME5,
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,LINE L,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                EMP_SIGNATURE SIGN,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                 AND E_O.EMP_ID=SIGN.EMP_ID(+)
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                AND E_O.EMP_STATUS='Active' " + sub_query + @"
                            ORDER BY DEP.DEPARTMENT_NAME, SEC.SECTION_NAME, E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_id_card_reg_tfl.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }   // End of private void btn_single_id_car_Click(object sender, EventArgs e)

        
        private void btn_single_id_car_n_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            
            string sql = @"SELECT U.UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                E_O.EMP_NAME,
                                E_O.UNIT_ID,
                                E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,
                                E_O.SECTION_ID,
                                E_O.LINE_ID,
                                E_O.SHIFT_ID,
                                L.LINE_NAME AS IN_TIME31,
                                E_O.DESIGNATION_ID,
                                E_O.DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.EMP_PHOTO,
                                SIGN.SIGNATURE,
                                E_P.PARMENENT_ADDRESS AS IN_TIME30,
                                INITCAP((E_P.PARMANENT_HOUSE)||',') AS IN_TIME6,
                                INITCAP((E_P.PARMANENT_VILL)||',') AS IN_TIME7,
                                INITCAP((E_P.PARMANENT_PS)||',') AS IN_TIME8,
                                INITCAP((E_P.PARMANENT_DIST)||',') AS IN_TIME9,
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                SEC.SECTION_NAME  AS IN_TIME5,
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,LINE L,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                EMP_SIGNATURE SIGN,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.EMP_ID=SIGN.EMP_ID(+)
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                AND E_O.EMP_STATUS='Active' " + sub_query + @"
                            ORDER BY DEP.DEPARTMENT_NAME, SEC.SECTION_NAME, E_O.EMP_CODE ASC";
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_id_card_single_tfl_new_f.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }// End of private void btn_single_id_car_n_Click(object sender, EventArgs e)

        private void emp_with_pic_A4_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            
            string sql = @"SELECT U.UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                E_O.EMP_STATUS  AS IN_TIME4,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME,
                                E_O.DATE_OF_JOINING,
                                E_P.EMP_PHOTO,
                                UPPER(DES.DESIGNATION_NAME) AS DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                SEC.SECTION_NAME AS IN_TIME5,
                                E_O.EMP_STATUS_CHANGE_DATE AS IN_TIME31,
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID " + sub_query + @"
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                --AND E_O.EMP_STATUS !='Active' 
                            ORDER BY DEP.DEPARTMENT_NAME, SEC.SECTION_NAME, E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_emp_with_pic_A4_tfl.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }// End of private void btn_with_pic_A4_Click(object sender, EventArgs e)

        private void from_DTPicker_ValueChanged(object sender, EventArgs e)
        {
            to_DTPicker.Value = new DateTime(from_DTPicker.Value.Year, from_DTPicker.Value.Month, DateTime.DaysInMonth(from_DTPicker.Value.Year, from_DTPicker.Value.Month));
        }// End of private void from_DTPicker_ValueChanged(object sender, EventArgs e)

        private void Report_New_Recruitment_UC_Load(object sender, EventArgs e)
        {
            from_DTPicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }// End of private void Report_New_Recruitment_UC_Load(object sender, EventArgs e)

        private void btn_dicpln_action_ltr_1_nttml_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT DISTINCT U.UNIT_NAME,
                                E_O.EMP_CODE, 
                                E_O.DATE_OF_JOINING,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME, 
                                INITCAP(E_P.FATHER_NAME) AS IN_TIME1, 
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                INITCAP(NVL(E_P.HUSBAND_NAME,E_P.FATHER_NAME)) AS IN_TIME2,
                                INITCAP(E_P.PARMANENT_HOUSE) AS IN_TIME3,
                                INITCAP(E_P.PARMANENT_VILL) AS IN_TIME4,
                                INITCAP(E_P.PARMANENT_PS) AS IN_TIME5,
                                INITCAP(E_P.PARMANENT_DIST) AS IN_TIME6,
                                E_O.EMP_STATUS_CHANGE_DATE AS SALARY_FOR
                            FROM UNIT U,EMP_OFFICIAL E_O, EMP_PERSONAL E_P, DEPARTMENT DEP, DESIGNATION DES
                            WHERE E_O.EMP_ID=E_P.EMP_ID " + sub_query + @"
                                AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                            ORDER BY UNIT_NAME,DEP.DEPARTMENT_NAME, E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();

            var report_path = db.GetReportPath() + "rpt_dicpln_action_ltr_1_tfl.rpt";
            r_d.Load(report_path);

            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }// End of private void btn_dicpln_action_ltr_1_nttml_Click(object sender, EventArgs e)

        private void btn_dicpln_action_ltr_2_nttml_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT DISTINCT U.UNIT_NAME,
                                E_O.EMP_CODE, 
                                E_O.DATE_OF_JOINING,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME, 
                                INITCAP(E_P.FATHER_NAME) AS IN_TIME1, 
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                INITCAP(NVL(E_P.HUSBAND_NAME,E_P.FATHER_NAME)) AS IN_TIME2,
                                INITCAP(E_P.PARMANENT_HOUSE) AS IN_TIME3,
                                INITCAP(E_P.PARMANENT_VILL) AS IN_TIME4,
                                INITCAP(E_P.PARMANENT_PS) AS IN_TIME5,
                                INITCAP(E_P.PARMANENT_DIST) AS IN_TIME6,
                                E_O.EMP_STATUS_CHANGE_DATE AS SALARY_FOR
                            FROM UNIT U,EMP_OFFICIAL E_O, EMP_PERSONAL E_P, DEPARTMENT DEP, DESIGNATION DES
                            WHERE E_O.EMP_ID=E_P.EMP_ID " + sub_query + @"
                                AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                            ORDER BY UNIT_NAME,DEP.DEPARTMENT_NAME, E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();

            var report_path = db.GetReportPath() + "rpt_dicpln_action_ltr_2_tfl.rpt";
            r_d.Load(report_path);

            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }// End of private void btn_dicpln_action_ltr_2_nttml_Click(object sender, EventArgs e)

        private void btn_dicpln_action_ltr_3_nttml_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT DISTINCT U.UNIT_NAME,
                                E_O.EMP_CODE, 
                                E_O.DATE_OF_JOINING,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME, 
                                INITCAP(E_P.FATHER_NAME) AS IN_TIME1, 
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                INITCAP(NVL(E_P.HUSBAND_NAME,E_P.FATHER_NAME)) AS IN_TIME2,
                                INITCAP(E_P.PARMANENT_HOUSE) AS IN_TIME3,
                                INITCAP(E_P.PARMANENT_VILL) AS IN_TIME4,
                                INITCAP(E_P.PARMANENT_PS) AS IN_TIME5,
                                INITCAP(E_P.PARMANENT_DIST) AS IN_TIME6,
                                E_O.EMP_STATUS_CHANGE_DATE AS SALARY_FOR
                            FROM UNIT U,EMP_OFFICIAL E_O, EMP_PERSONAL E_P, DEPARTMENT DEP, DESIGNATION DES
                            WHERE E_O.EMP_ID=E_P.EMP_ID " + sub_query + @"
                                AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                            ORDER BY UNIT_NAME,DEP.DEPARTMENT_NAME, E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();

            var report_path = db.GetReportPath() + "rpt_dicpln_action_ltr_3_tfl.rpt";
            r_d.Load(report_path);

            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }// End of private void btn_dicpln_action_ltr_3_nttml_Click(object sender, EventArgs e)

        private void btn_termination_letter_prob_nttml_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT DISTINCT U.UNIT_NAME,
                                E_O.EMP_CODE, 
                                E_O.DATE_OF_JOINING,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME, 
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                L.LINE_NAME,
                                E_O.EMP_STATUS_CHANGE_DATE AS SALARY_FOR
                            FROM UNIT U,EMP_OFFICIAL E_O, EMP_PERSONAL E_P, DEPARTMENT DEP, DESIGNATION DES, LINE L
                            WHERE E_O.EMP_ID=E_P.EMP_ID  " + sub_query + @"
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                            ORDER BY UNIT_NAME,DEP.DEPARTMENT_NAME,  L.LINE_NAME, E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();

            var report_path = db.GetReportPath() + "rpt_termination_letter_prob_tfl.rpt";
            r_d.Load(report_path);

            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }// End of private void btn_termination_letter_prob_nttml_Click(object sender, EventArgs e)

        private void btn_termination_letter_nttml_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT DISTINCT U.UNIT_NAME,
                                E_O.EMP_CODE, 
                                E_O.DATE_OF_JOINING,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME, 
                                INITCAP(E_P.FATHER_NAME) AS IN_TIME1, 
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                INITCAP(NVL(E_P.HUSBAND_NAME,E_P.FATHER_NAME)) AS IN_TIME2,
                                INITCAP(E_P.PARMANENT_HOUSE) AS IN_TIME3,
                                INITCAP(E_P.PARMANENT_VILL) AS IN_TIME4,
                                INITCAP(E_P.PARMANENT_PS) AS IN_TIME5,
                                INITCAP(E_P.PARMANENT_DIST) AS IN_TIME6,
                                E_O.EMP_STATUS_CHANGE_DATE AS SALARY_FOR
                            FROM UNIT U,EMP_OFFICIAL E_O, EMP_PERSONAL E_P, DEPARTMENT DEP, DESIGNATION DES
                            WHERE E_O.EMP_ID=E_P.EMP_ID " + sub_query + @"
                                AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                            ORDER BY UNIT_NAME,DEP.DEPARTMENT_NAME, E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();

            var report_path = db.GetReportPath() + "rpt_termination_letter_tfl.rpt";
            r_d.Load(report_path);

            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void txt_emp_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_emp_code.Text != "")
                {
                    DBClass db = new DBClass();
                    string emp_code = txt_emp_code.Text;
                    string sql = @"select emp_name from emp_official where emp_code='" + txt_emp_code.Text + "'";
                    OracleDataReader dr = db.GetExecuteReader(sql);
                    if (dr.Read())
                    {
                        lbl_emp_name.Text = dr["emp_name"].ToString();
                    }
                    dataGridView_list.Rows.Add(txt_emp_code.Text, txt_emp_code.Text, "EmpCode");
                    txt_emp_code.Text = "";
                    txt_emp_code.Focus();
                }
            }
            else if (e.KeyCode == Keys.F1) UploadTextFile();
            else if (e.Control&&e.Alt&&e.KeyCode == Keys.Home)
            {
                btnEvolishIDCardBack.Visible=true;
                btnEvolishIDCardFront.Visible = true;
            }
            else if (e.Control && e.Alt && e.KeyCode == Keys.End)
            {
                btnEvolishIDCardBack.Visible = false;
                btnEvolishIDCardFront.Visible = false;
            }
        }// End of private void txt_emp_code_KeyDown(object sender, EventArgs e)
        
        private void combo_emp_type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                if (combo_emp_type.Text != "")
                {
                    KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_emp_type.SelectedItem;
                    dataGridView_list.Rows.Add(combo_emp_type.Text, selected_item.Value,"EmpType");
                    combo_emp_type.SelectedIndex = -1;
                    combo_emp_type.Focus();
                }
            }
        }// End of private void combo_emp_type_KeyDown(object sender, EventArgs e)

        private void combo_dept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combo_dept.Text != "")
                {
                    KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_dept.SelectedItem;
                    dataGridView_list.Rows.Add(combo_dept.Text, selected_item.Value,"Dept");
                    combo_dept.SelectedIndex = -1;
                    combo_dept.Focus();
                }
            }
        }// End of private void combo_dept_KeyDown(object sender, EventArgs e)

        private void combo_sec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combo_sec.Text != "")
                {
                    KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_sec.SelectedItem;
                    dataGridView_list.Rows.Add(combo_sec.Text, selected_item.Value, "Sec");
                    combo_sec.SelectedIndex = -1;
                    combo_sec.Focus();
                }
            }
        }// End of private void combo_sec_KeyDown(object sender, EventArgs e)

        private void combo_line_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combo_line_name.Text != "")
                {
                    KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_line_name.SelectedItem;
                    dataGridView_list.Rows.Add(combo_line_name.Text, selected_item.Value, "Line");
                    combo_line_name.SelectedIndex = -1;
                    combo_line_name.Focus();
                }
            }
        }// End of private void combo_line_name_KeyDown(object sender, EventArgs e)

        private void combo_shift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combo_shift.Text != "")
                {
                    KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_shift.SelectedItem;
                    dataGridView_list.Rows.Add(combo_shift.Text, selected_item.Value,"Shift");
                    combo_shift.SelectedIndex = -1;
                    combo_shift.Focus();
                }
            }

        }// End of private void combo_shift_KeyDown(object sender, EventArgs e)

        private void combo_desig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combo_desig.Text != "")
                {
                    KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_desig.SelectedItem;
                    dataGridView_list.Rows.Add(combo_desig.Text, selected_item.Value, "Desig");
                    combo_desig.SelectedIndex = -1;
                    combo_desig.Focus();
                }
            }
        }// End of private void combo_desig_KeyDown(object sender, EventArgs e)
        private void UploadTextFile()
        {
            OpenFileDialog ofdEmpCode = new OpenFileDialog();
            ofdEmpCode.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            ofdEmpCode.Filter = "Text only. |*.TXT;";
            if (ofdEmpCode.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Are You Sure To Upload Employee List From TXT File (" + ofdEmpCode.FileName + ")", "Upload .TXT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string FilePath = ofdEmpCode.FileName;
                    string[] lines = File.ReadAllLines(FilePath);
                    foreach (string line in lines)
                    {
                        // Use a tab to indent each line of the file.
                        dataGridView_list.Rows.Add(line, line, "EmpCode");
                    }
                }
            }
        }// End of private void combo_emp_code_KeyDown(object sender, EventArgs e)
        private void btn_id_card_nsml_Click(object sender, EventArgs e)
        {
            string sub_query_id = generate_sub_query("DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT INITCAP(U.UNIT_NAME) AS UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME,
                                E_O.UNIT_ID,
                                E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,
                                E_O.SECTION_ID,
                                E_O.LINE_ID,
                                E_O.SHIFT_ID,
                                E_O.DESIGNATION_ID,
                                E_O.DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.EMP_PHOTO AS PHOTO,
                                INITCAP((E_P.PARMANENT_HOUSE)||',') AS IN_TIME6,
                                INITCAP((E_P.PARMANENT_VILL)||',') AS IN_TIME7,
                                INITCAP((E_P.PARMANENT_PS)||',') AS IN_TIME8,
                                INITCAP((E_P.PARMANENT_DIST)||',') AS IN_TIME9,
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                (SEC.SECTION_NAME||' - '||L.LINE_NAME) AS IN_TIME5,
                                --CAT.EMP_CATEGORY_NAME
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                LINE L,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID 
                                AND E_O.EMP_STATUS='Active' " + sub_query_id + @"
                            ORDER BY UNIT_NAME,DEP.DEPARTMENT_NAME, SECTION_NAME, E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();

            var report_path = db.GetReportPath() + "rpt_id_card_nsml.rpt";
            r_d.Load(report_path);
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btn_single_id_card_nsml_Click(object sender, EventArgs e)
        {
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            DBClass db = new DBClass();

            string sql = @"SELECT INITCAP(U.UNIT_NAME) AS UNIT_NAME,
                                U.ADDRESS,
                                E_O.EMP_CODE,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME,
                                E_O.UNIT_ID,
                                E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,
                                E_O.SECTION_ID,
                                E_O.LINE_ID,
                                E_O.SHIFT_ID,
                                E_O.DESIGNATION_ID,
                                E_O.DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.EMP_PHOTO AS PHOTO,
                                INITCAP((E_P.PARMANENT_HOUSE)||',') AS IN_TIME6,
                                INITCAP((E_P.PARMANENT_VILL)||',') AS IN_TIME7,
                                INITCAP((E_P.PARMANENT_PS)||',') AS IN_TIME8,
                                INITCAP((E_P.PARMANENT_DIST)||',') AS IN_TIME9,
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                (SEC.SECTION_NAME||' - '||L.LINE_NAME) AS IN_TIME5,
                                --CAT.EMP_CATEGORY_NAME
                                CASE
                                    WHEN CAT.EMP_CATEGORY_NAME='Worker'
                                        THEN  UPPER('PERMANENT')
                                    ELSE UPPER('CONTACTUAL')
                                 END EMP_CATEGORY_NAME
                            FROM UNIT U,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                LINE L,
                                EMP_CATEGORY CAT
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID
                                AND E_O.EMP_STATUS='Active'" + sub_query + @"
                            ORDER BY UNIT_NAME, DEP.DEPARTMENT_NAME, SECTION_NAME, E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();

            var report_path = db.GetReportPath() + "rpt_id_card_single_nsml.rpt";
            r_d.Load(report_path);
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);    // for 1st sql

            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;

            obj_report_viewer_uc.crystalReportViewer1.Refresh();

            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }// End of private void combo_emp_code_KeyDown(object sender, EventArgs e)

        private void btn_police_verify_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            
            string sql = @"SELECT DISTINCT U.UNIT_NAME,
                                E_O.EMP_CODE, 
                                E_O.DATE_OF_JOINING,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME, 
                                INITCAP(E_P.FATHER_NAME) AS IN_TIME1, 
                                DES.DESIGNATION_NAME,
                                DEP.DEPARTMENT_NAME,
                                INITCAP(NVL(E_P.HUSBAND_NAME,E_P.FATHER_NAME)) AS IN_TIME2,
                                INITCAP(E_P.PARMANENT_HOUSE) AS IN_TIME3,
                                INITCAP(E_P.PARMANENT_VILL) AS IN_TIME4,
                                INITCAP(E_P.PARMANENT_PS) AS IN_TIME5,
                                INITCAP(E_P.PARMANENT_DIST) AS IN_TIME6,
                                E_O.EMP_STATUS_CHANGE_DATE AS SALARY_FOR
                            FROM UNIT U,EMP_OFFICIAL E_O, EMP_PERSONAL E_P, DEPARTMENT DEP, DESIGNATION DES
                            WHERE E_O.EMP_ID=E_P.EMP_ID " + sub_query + @"
                                AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                            ORDER BY UNIT_NAME,DEP.DEPARTMENT_NAME, E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_police_verification_letter_tfl.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btnNomineeDeclareAndNominationForm_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sub_query = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT E_O.EMP_CODE,INITCAP(U.UNIT_NAME) AS UNIT_NAME,U.ADDRESS,CAT.EMP_CATEGORY_NAME EMP_CATEGORY_NAME,DEP.BANG_DEPT_NAME DEPARTMENT_NAME,SEC.BANG_SEC_NAME SECTION_NAME,L.BANG_LINE_NAME LINE_NAME,
                                E_O.BANG_EMP_NAME AS EMP_NAME,E_P.SEX AS EMP_CATEGORY_STATUS,--------------SEX
                                (NVL(E_P.BANG_PRESENT_VILL,'fvIqvj wgR©vcyi')||', '||NVL(E_P.BANG_PRESENT_POST,'wgR©vcyi evRvi')||',') AS PRESENT,
                                (NVL(E_P.BANG_PRESENT_PS,'m`i')||', '||NVL(E_P.BANG_PRESENT_DIST,'MvRxcyi')) AS IN_TIME1,
                                (
                                CASE
                                    WHEN E_P.SEX='FEMALE' AND E_P.MARITAL_STATUS !='SINGLE'
                                        THEN NVL(E_P.BANG_HUSBAND_NAME,NVL(E_P.BANG_FATHER_NAME,NVL(E_P.BANG_MOTHER_NAME,'')))
                                    ELSE NVL(E_P.BANG_FATHER_NAME,NVL(E_P.BANG_MOTHER_NAME,''))
                                END) AS IN_TIME2,                                              --(FATHER/MOTHER/HUSBAND/WIFE) NAME
                                TO_CHAR(E_P.DATE_OF_BIRTH,'DD') AS IN_TIME3,                   --BIRTH DAY
                                TO_CHAR(E_P.DATE_OF_BIRTH,'Month') AS IN_TIME4,                --BIRTH MONTH
                                TO_CHAR(E_P.DATE_OF_BIRTH,'YYYY') AS IN_TIME5,                 --BIRTH YEAR
                                (NVL(E_P.REMARKS,'')) AS IN_TIME6,                      --BIRTH SIGN
                                (NVL(E_P.BANG_PARMANENT_POST,'')) AS IN_TIME7,              --PARMANENT VILLAGE
                                (NVL(E_P.BANG_PARMANENT_VILL,'')) AS IN_TIME8,               --PARMANENT POST OFFICE
                                (NVL(E_P.BANG_PARMANENT_PS,'')) AS IN_TIME9,                 --PARMANENT POLICE STATION
                                (NVL(E_P.BANG_PARMANENT_DIST,'')) AS IN_TIME10,              --PARMANENT DISTRICT
                                E_O.DATE_OF_JOINING,SIG.SIGNATURE,
                                (DES.BANG_DESIGNATION_NAME ) AS DESIGNATION_NAME,
                                (E_O.BANG_BENEFICIARY_NAME) AS IN_TIME11,                      --NOMINEE NAME
                                E_O.RELATION_WITH_BENEFICIARY AS IN_TIME12                     --RELATION WITH NOMINEE
                           FROM UNIT U,LINE L,EMP_PERSONAL E_P,EMP_OFFICIAL E_O,DESIGNATION DES,DEPARTMENT DEP,EMP_CATEGORY CAT,SECTION SEC,EMP_SIGNATURE SIG    
                           WHERE E_O.LINE_ID=L.LINE_ID
                                AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.EMP_ID=SIG.EMP_ID(+)
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID " + sub_query + @"
                            ORDER BY UNIT_NAME,CAT.EMP_CATEGORY_NAME,DEP.DEPARTMENT_NAME,TO_NUMBER(E_O.EMP_CODE)";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_nomineeDeclareAndNominationForm_tfl.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btnJobDescriptionBeamFitter_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT E_O.EMP_CODE,EMP_NAME,NVL(EMP_GRADE,'0')  EMP_GRADE,DESIGNATION_NAME,DATE_OF_JOINING,UNIT_NAME,ADDRESS,EMP_CATEGORY_NAME,DEPARTMENT_NAME,SECTION_NAME,LINE_NAME,E_P.EDUCATION IN_TIME1
                         FROM EMP_OFFICIAL E_O,DESIGNATION DES,UNIT U,EMP_CATEGORY E_C,DEPARTMENT DEP,SECTION SEC,LINE L,EMP_PERSONAL E_P
                         WHERE E_O.DESIGNATION_ID=DES.DESIGNATION_ID AND U.UNIT_ID=E_O.UNIT_ID AND E_C.EMP_CATEGORY_ID=E_O.EMP_CATEGORY_ID AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID 
                            AND E_O.EMP_STATUS='Active' AND E_O.EMP_ID=E_P.EMP_ID AND E_O.SECTION_ID=SEC.SECTION_ID AND E_O.LINE_ID=L.LINE_ID " + subQuery + " ORDER BY UNIT_NAME,EMP_CATEGORY_NAME,E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_JobDescriptionBeamFitter.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btnJobDescriptionLineMan_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT E_O.EMP_CODE,EMP_NAME,NVL(EMP_GRADE,'0')  EMP_GRADE,DESIGNATION_NAME,DATE_OF_JOINING,UNIT_NAME,ADDRESS,EMP_CATEGORY_NAME,DEPARTMENT_NAME,SECTION_NAME,LINE_NAME,E_P.EDUCATION IN_TIME1
                         FROM EMP_OFFICIAL E_O,DESIGNATION DES,UNIT U,EMP_CATEGORY E_C,DEPARTMENT DEP,SECTION SEC,LINE L,EMP_PERSONAL E_P
                         WHERE E_O.DESIGNATION_ID=DES.DESIGNATION_ID AND U.UNIT_ID=E_O.UNIT_ID AND E_C.EMP_CATEGORY_ID=E_O.EMP_CATEGORY_ID AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID 
                            AND E_O.EMP_STATUS='Active' AND E_O.EMP_ID=E_P.EMP_ID AND E_O.SECTION_ID=SEC.SECTION_ID AND E_O.LINE_ID=L.LINE_ID " + subQuery + " ORDER BY UNIT_NAME,EMP_CATEGORY_NAME,E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_JobDescriptionLineMan.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btnJobDescriptionLoomOperator_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT E_O.EMP_CODE,EMP_NAME,NVL(EMP_GRADE,'0')  EMP_GRADE,DESIGNATION_NAME,DATE_OF_JOINING,UNIT_NAME,ADDRESS,EMP_CATEGORY_NAME,DEPARTMENT_NAME,SECTION_NAME,LINE_NAME,E_P.EDUCATION IN_TIME1
                         FROM EMP_OFFICIAL E_O,DESIGNATION DES,UNIT U,EMP_CATEGORY E_C,DEPARTMENT DEP,SECTION SEC,LINE L,EMP_PERSONAL E_P
                         WHERE E_O.DESIGNATION_ID=DES.DESIGNATION_ID AND U.UNIT_ID=E_O.UNIT_ID AND E_C.EMP_CATEGORY_ID=E_O.EMP_CATEGORY_ID AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID 
                            AND E_O.EMP_STATUS='Active' AND E_O.EMP_ID=E_P.EMP_ID AND E_O.SECTION_ID=SEC.SECTION_ID AND E_O.LINE_ID=L.LINE_ID " + subQuery + " ORDER BY UNIT_NAME,EMP_CATEGORY_NAME,E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_JobDescriptionLoomOperator.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btnJobDescriptionFitter_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT E_O.EMP_CODE,EMP_NAME,NVL(EMP_GRADE,'0')  EMP_GRADE,DESIGNATION_NAME,DATE_OF_JOINING,UNIT_NAME,ADDRESS,EMP_CATEGORY_NAME,DEPARTMENT_NAME,SECTION_NAME,LINE_NAME,E_P.EDUCATION IN_TIME1
                         FROM EMP_OFFICIAL E_O,DESIGNATION DES,UNIT U,EMP_CATEGORY E_C,DEPARTMENT DEP,SECTION SEC,LINE L,EMP_PERSONAL E_P
                         WHERE E_O.DESIGNATION_ID=DES.DESIGNATION_ID AND U.UNIT_ID=E_O.UNIT_ID AND E_C.EMP_CATEGORY_ID=E_O.EMP_CATEGORY_ID AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID 
                            AND E_O.EMP_STATUS='Active' AND E_O.EMP_ID=E_P.EMP_ID AND E_O.SECTION_ID=SEC.SECTION_ID AND E_O.LINE_ID=L.LINE_ID " + subQuery + " ORDER BY UNIT_NAME,EMP_CATEGORY_NAME,E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_JobDescriptionFitter.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btnJobDescriptionMender_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT E_O.EMP_CODE,EMP_NAME,NVL(EMP_GRADE,'0')  EMP_GRADE,DESIGNATION_NAME,DATE_OF_JOINING,UNIT_NAME,ADDRESS,EMP_CATEGORY_NAME,DEPARTMENT_NAME,SECTION_NAME,LINE_NAME,E_P.EDUCATION IN_TIME1
                         FROM EMP_OFFICIAL E_O,DESIGNATION DES,UNIT U,EMP_CATEGORY E_C,DEPARTMENT DEP,SECTION SEC,LINE L,EMP_PERSONAL E_P
                         WHERE E_O.DESIGNATION_ID=DES.DESIGNATION_ID AND U.UNIT_ID=E_O.UNIT_ID AND E_C.EMP_CATEGORY_ID=E_O.EMP_CATEGORY_ID AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID 
                            AND E_O.EMP_STATUS='Active' AND E_O.EMP_ID=E_P.EMP_ID AND E_O.SECTION_ID=SEC.SECTION_ID AND E_O.LINE_ID=L.LINE_ID " + subQuery + " ORDER BY UNIT_NAME,EMP_CATEGORY_NAME,E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_JobDescriptionMender.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btnJobDescriptionSizer_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT E_O.EMP_CODE,EMP_NAME,NVL(EMP_GRADE,'0')  EMP_GRADE,DESIGNATION_NAME,DATE_OF_JOINING,UNIT_NAME,ADDRESS,E_O.GROSS,EMP_CATEGORY_NAME,DEPARTMENT_NAME,SECTION_NAME,LINE_NAME,E_P.EDUCATION IN_TIME1
                         FROM EMP_OFFICIAL E_O,DESIGNATION DES,UNIT U,EMP_CATEGORY E_C,DEPARTMENT DEP,SECTION SEC,LINE L,EMP_PERSONAL E_P
                         WHERE E_O.DESIGNATION_ID=DES.DESIGNATION_ID AND U.UNIT_ID=E_O.UNIT_ID AND E_C.EMP_CATEGORY_ID=E_O.EMP_CATEGORY_ID AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID 
                            AND E_O.EMP_STATUS='Active' AND E_O.EMP_ID=E_P.EMP_ID AND E_O.SECTION_ID=SEC.SECTION_ID AND E_O.LINE_ID=L.LINE_ID " + subQuery + " ORDER BY UNIT_NAME,EMP_CATEGORY_NAME,E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_JobDescriptionSizer.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btnJobDescriptionWarper_Click(object sender, EventArgs e)
        {

            DBClass db = new DBClass();
            DateTime date = new DateTime(to_DTPicker.Value.Year,to_DTPicker.Value.Month,1);
            string first_date = date.ToString("dd-MMM-yyyy");
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();

            string sql = @"SELECT E_O.EMP_CODE,
                                  EMP_NAME,
                                  NVL(EMP_GRADE,'0')  EMP_GRADE,
                                  DESIGNATION_NAME,
                                  DATE_OF_JOINING,
                                  UNIT_NAME,
                                  ADDRESS,
                                  EMP_CATEGORY_NAME,
                                  E_O.GROSS,
                                  DEPARTMENT_NAME,
                                  SECTION_NAME,
                                  LINE_NAME,
                                  E_P.EDUCATION EMP_EDUCATION,
                                  to_char(to_date('"+to_DTPicker.Text+@"','dd-Mon-yyyy'),'Month')||' '||(to_number(to_char(to_date('"+to_DTPicker.Text+@"','dd-Mon-yyyy'),'YYYY'))-1)||' - '|| to_char(to_date('"+to_DTPicker.Text+@"','dd-Mon-yyyy'),'YYYY') as sessions,
                                  ((TRUNC(MONTHS_BETWEEN('" + to_DTPicker.Text + @"',E_O.DATE_OF_JOINING)/12))||' Y, '||
                                    TRUNC(MOD(MONTHS_BETWEEN('" + to_DTPicker.Text + @"',E_O.DATE_OF_JOINING),12))||' M, '||
                                    TRUNC(to_date('" + to_DTPicker.Text + "','dd/MM/yyyy')- ADD_MONTHS(E_O.DATE_OF_JOINING,TRUNC(MONTHS_BETWEEN('" + to_DTPicker.Text + @"',E_O.DATE_OF_JOINING)/12)*12 + 
                                    TRUNC(MOD(MONTHS_BETWEEN('" + to_DTPicker.Text + @"',E_O.DATE_OF_JOINING),12)))+1)||' D') AS SERVICE_PERIOD, 
                                  to_date('" +first_date+@"','dd-Mon-yyyy') first_date_of_month
                         FROM EMP_OFFICIAL E_O,DESIGNATION DES,UNIT U,EMP_CATEGORY E_C,DEPARTMENT DEP,SECTION SEC,LINE L,EMP_PERSONAL E_P
                         WHERE E_O.DESIGNATION_ID=DES.DESIGNATION_ID 
                         AND U.UNIT_ID=E_O.UNIT_ID 
                         AND E_C.EMP_CATEGORY_ID=E_O.EMP_CATEGORY_ID 
                         AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID 
                         AND E_O.EMP_STATUS='Active' 
                         AND E_O.EMP_ID=E_P.EMP_ID 
                         AND E_O.SECTION_ID=SEC.SECTION_ID 
                         AND E_O.LINE_ID=L.LINE_ID " + subQuery + @" 
                         ORDER BY UNIT_NAME,EMP_CATEGORY_NAME,E_O.EMP_CODE";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_JobDescriptionWarper.rpt");
            r_d.Database.Tables["job_description_warper"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void btnAppointmentLetterEng_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sql = @"SELECT DISTINCT E_O.EMP_CODE,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME,
                                UPPER(NVL(E_P.FATHER_NAME,'')) AS IN_TIME1,
                                UPPER(NVL(E_P.MOTHER_NAME,'')) AS IN_TIME2,
                                UPPER(NVL(E_P.HUSBAND_NAME,'')) AS IN_TIME3,
                                INITCAP(E_P.PARMANENT_HOUSE) AS IN_TIME5,
                                INITCAP(E_P.PARMANENT_VILL) AS IN_TIME12,
                                INITCAP(E_P.PARMANENT_PS) AS IN_TIME6,
                                INITCAP(E_P.PARMANENT_DIST) AS IN_TIME7,
                                INITCAP(E_P.PRESENT_VILL) AS IN_TIME9,
                                INITCAP(E_P.PRESENT_HOUSE) AS IN_TIME13,
                                INITCAP(E_P.PRESENT_PS) AS IN_TIME10,
                                INITCAP(E_P.PRESENT_DIST) AS IN_TIME11,
                                E_O.DATE_OF_JOINING,NVL(E_O.GROSS,0) GROSS,
                                UPPER(DEP.DEPARTMENT_NAME) AS DEPARTMENT_NAME,
                                UPPER(DES.DESIGNATION_NAME) AS DESIGNATION_NAME,
                                NVL(E_O.EMP_GRADE,DES.GRADE) AS GRADE,
                                INITCAP(U.UNIT_NAME) AS UNIT_NAME,
                                INITCAP(U.ADDRESS) AS ADDRESS,
                                S_R_INFO.RULE_TRANSPORT,
                                S_R_INFO.RULE_MEDICAL,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100),ROUND((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))) AS BASIC,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100)/2,ROUND(((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))* RULE_HOUSE_RENT/100)) AS HOUSE_RANT
                            FROM EMP_PERSONAL E_P,EMP_OFFICIAL E_O,DEPARTMENT DEP,DESIGNATION DES,UNIT U,SALARY_RULE_INFO S_R_INFO
                            WHERE E_O.EMP_ID=E_P.EMP_ID AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.RULE_ID=S_R_INFO.RULE_ID
                                AND E_O.EMP_STATUS='Active'" + generate_sub_query("E_O.DATE_OF_JOINING") + @"
                            ORDER BY E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_AppointmentLetterEng.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC objRptViewerUC = this.load_report_viewer();
            objRptViewerUC.crystalReportViewer1.ReportSource = r_d;
            objRptViewerUC.crystalReportViewer1.Refresh();
            objRptViewerUC.lastUserControlRptViewer = this;
        }

        private void btnFitnessCertificate_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sql = @"SELECT DISTINCT E_O.EMP_CODE,
                                UPPER(E_O.EMP_NAME) AS EMP_NAME,
                                UPPER(NVL(E_P.FATHER_NAME,'')) AS IN_TIME1,
                                UPPER(NVL(E_P.MOTHER_NAME,'')) AS IN_TIME2,
                                UPPER(NVL(E_P.HUSBAND_NAME,'')) AS IN_TIME3,
                                INITCAP(E_P.PARMANENT_HOUSE) AS IN_TIME5,
                                INITCAP(E_P.PARMANENT_VILL) AS IN_TIME12,
                                INITCAP(E_P.PARMANENT_PS) AS IN_TIME6,
                                INITCAP(E_P.PARMANENT_DIST) AS IN_TIME7,
                                INITCAP(E_P.PRESENT_VILL) AS IN_TIME9,
                                INITCAP(E_P.PRESENT_HOUSE) AS IN_TIME13,
                                INITCAP(E_P.PRESENT_PS) AS IN_TIME10,
                                INITCAP(E_P.PRESENT_DIST) AS IN_TIME11,
                                E_O.DATE_OF_JOINING,NVL(E_O.GROSS,0) GROSS,
                                UPPER(DEP.DEPARTMENT_NAME) AS DEPARTMENT_NAME,
                                UPPER(DES.DESIGNATION_NAME) AS DESIGNATION_NAME,
                                NVL(E_O.EMP_GRADE,DES.GRADE) AS GRADE,
                                INITCAP(U.UNIT_NAME) AS UNIT_NAME,
                                INITCAP(U.ADDRESS) AS ADDRESS,
                                S_R_INFO.RULE_TRANSPORT,
                                S_R_INFO.RULE_MEDICAL,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100),ROUND((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))) AS BASIC,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100)/2,ROUND(((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))* RULE_HOUSE_RENT/100)) AS HOUSE_RANT
                            FROM EMP_PERSONAL E_P,EMP_OFFICIAL E_O,DEPARTMENT DEP,DESIGNATION DES,UNIT U,SALARY_RULE_INFO S_R_INFO
                            WHERE E_O.EMP_ID=E_P.EMP_ID AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.RULE_ID=S_R_INFO.RULE_ID
                                AND E_O.EMP_STATUS='Active'" + generate_sub_query("E_O.DATE_OF_JOINING") + @"
                            ORDER BY E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_FitnessCertificate.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC objRptViewerUC = this.load_report_viewer();
            objRptViewerUC.crystalReportViewer1.ReportSource = r_d;
            objRptViewerUC.crystalReportViewer1.Refresh();
            objRptViewerUC.lastUserControlRptViewer = this;
        }

        private void btnAgeFitnessCertificate_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sql = @"SELECT E_O.EMP_CODE,U.UNIT_NAME,U.ADDRESS,E_O.EMP_NAME,E_P.EMP_PHOTO,
                                DATE_OF_BIRTH AS SALARY_FOR,SECTION_NAME,LINE_NAME,DEPARTMENT_NAME,
                                UPPER(CASE
                                    WHEN UPPER(E_P.SEX)='FEMALE' AND UPPER(E_P.MARITAL_STATUS) !='SINGLE'
                                    THEN NVL(E_P.HUSBAND_NAME,NVL(E_P.FATHER_NAME,''))
                                END) AS IN_TIME6, -----(FATHER/HUSBAND/WIFE) NAME
                                NVL(E_P.MOTHER_NAME,'')  AS IN_TIME7,
                                INITCAP(NVL(E_P.PARMANENT_HOUSE,'')) IN_TIME1,
                                INITCAP(NVL(E_P.PARMANENT_VILL,'')) IN_TIME2,
                                INITCAP(NVL(E_P.PARMANENT_PS,'')) IN_TIME3,
                                INITCAP(NVL(E_P.PARMANENT_DIST,'')) IN_TIME4,
                                TRUNC(MONTHS_BETWEEN(SYSDATE,DATE_OF_BIRTH)/12) GRADE
                            FROM EMP_PERSONAL E_P,EMP_OFFICIAL E_O,SECTION SEC,LINE L,UNIT U,DEPARTMENT DEP
                            WHERE E_O.EMP_ID=E_P.EMP_ID AND E_O.LINE_ID=L.LINE_ID AND EMP_STATUS='Active' 
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.UNIT_ID=U.UNIT_ID " + generate_sub_query("E_O.DATE_OF_JOINING") + @"
                            ORDER BY E_O.EMP_CODE ASC";

            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_AgeVerificationAndFitnessCertificate.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC objRptViewerUC = this.load_report_viewer();
            objRptViewerUC.crystalReportViewer1.ReportSource = r_d;
            objRptViewerUC.crystalReportViewer1.Refresh();
            objRptViewerUC.lastUserControlRptViewer = this;
        }

        private void btnEvolishIDCardFront_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_IDCardFrontPartEvolishLandScape.rpt");
            CrystalReportViewerUC objRptViewerUC = this.load_report_viewer();
            objRptViewerUC.crystalReportViewer1.ReportSource = r_d;
            objRptViewerUC.crystalReportViewer1.Refresh();
            objRptViewerUC.lastUserControlRptViewer = this;
        }
        private void btnEvolishIDCardBack_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_IDCardBackPartEvolishLandScape.rpt");
            CrystalReportViewerUC objRptViewerUC = this.load_report_viewer();
            objRptViewerUC.crystalReportViewer1.ReportSource = r_d;
            objRptViewerUC.crystalReportViewer1.Refresh();
            objRptViewerUC.lastUserControlRptViewer = this;
        }

        private void btnIDCardDistributionList_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string strQuery = @"SELECT E_O.EMP_CODE,U.UNIT_NAME,U.ADDRESS,E_O.EMP_NAME,E_P.EMP_PHOTO,
                                DATE_OF_JOINING,DATE_OF_BIRTH AS SALARY_FOR,SECTION_NAME,DEPARTMENT_NAME,
                                LINE_NAME,TRUNC(MONTHS_BETWEEN(SYSDATE,DATE_OF_BIRTH)/12) GRADE
                            FROM EMP_PERSONAL E_P,EMP_OFFICIAL E_O,SECTION SEC,LINE L,UNIT U,DEPARTMENT DEP
                            WHERE E_O.EMP_ID=E_P.EMP_ID AND E_O.LINE_ID=L.LINE_ID AND EMP_STATUS='Active' 
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.UNIT_ID=U.UNIT_ID " + generate_sub_query("E_O.DATE_OF_JOINING") + @"
                            ORDER BY E_O.EMP_CODE ASC"; 
            
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_IDCardDistributionList.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(strQuery).Tables[0]);
            CrystalReportViewerUC objRptViewerUC = this.load_report_viewer();
            objRptViewerUC.crystalReportViewer1.ReportSource = r_d;
            objRptViewerUC.crystalReportViewer1.Refresh();
            objRptViewerUC.lastUserControlRptViewer = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");

            string sql = @"SELECT U.BANG_UNIT_NAME as UNIT_NAME,
                                U.BANG_ADDRESS as ADDRESS,
                                E_O.EMP_CODE,
                                E_O.BANG_EMP_NAME as EMP_NAME,
                                to_char( E_O.DATE_OF_JOINING,'DD/MM/YYYY') as DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.PHOTO AS IN_TIME4,
                                E_P.EMP_PHOTO,
                                E_S.SIGNATURE,
                            E_P.BANG_PARMANENT_POST||',' AS IN_TIME6,
                               E_P.BANG_PARMANENT_VILL||','  AS IN_TIME7,
                            E_P.BANG_PARMANENT_PS||',' AS IN_TIME8,
                         E_P.BANG_PARMANENT_DIST||','  AS IN_TIME9,
                                  DES.BANG_DESIGNATION_NAME as DESIGNATION_NAME,
                                  DEP.BANG_DEPT_NAME AS DEPARTMENT_NAME,
                                   SEC.BANG_SEC_NAME AS IN_TIME5,
                            L.BANG_LINE_NAME as  IN_TIME31,
                             CAT.BANG_EMP_TYPE_NAME as EMP_CATEGORY_NAME
                            FROM UNIT U,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                LINE L,
                                EMP_CATEGORY CAT,
                                EMP_SIGNATURE E_S
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_S.EMP_ID(+)=E_O.EMP_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID " + subQuery + @"
                                AND E_O.EMP_STATUS='Active'
                            ORDER BY DEPARTMENT_NAME, SECTION_NAME, E_O.EMP_CODE ASC";
            ReportDocument r_d = new ReportDocument();
            string s = db.GetReportPath() + "rpt_bangla_id_card_front_evolish.rpt";
            r_d.Load(db.GetReportPath() + "rpt_bangla_id_card_front_evolish.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC objRptViewerUC = this.load_report_viewer();
            objRptViewerUC.crystalReportViewer1.ReportSource = r_d;
            objRptViewerUC.crystalReportViewer1.Refresh();
            objRptViewerUC.lastUserControlRptViewer = this;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");

            string sql = @"SELECT U.BANG_UNIT_NAME as UNIT_NAME,
                                U.BANG_ADDRESS as ADDRESS,
                                E_O.EMP_CODE,
                                E_O.BANG_EMP_NAME as EMP_NAME,
                                to_char( E_O.DATE_OF_JOINING,'DD/MM/YYYY') as DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.PHOTO AS IN_TIME4,
                                E_P.EMP_PHOTO,
                                E_S.SIGNATURE,
                            E_P.BANG_PARMANENT_POST||',' AS IN_TIME6,
                               E_P.BANG_PARMANENT_VILL||','  AS IN_TIME7,
                            E_P.BANG_PARMANENT_PS||',' AS IN_TIME8,
                         E_P.BANG_PARMANENT_DIST||','  AS IN_TIME9,
                                  DES.BANG_DESIGNATION_NAME as DESIGNATION_NAME,
                                  DEP.BANG_DEPT_NAME AS DEPARTMENT_NAME,
                                   SEC.BANG_SEC_NAME AS IN_TIME5,
                            L.BANG_LINE_NAME as  IN_TIME31,
                             CAT.BANG_EMP_TYPE_NAME as EMP_CATEGORY_NAME
                            FROM UNIT U,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                LINE L,
                                EMP_CATEGORY CAT,
                                EMP_SIGNATURE E_S
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_S.EMP_ID(+)=E_O.EMP_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID " + subQuery + @"
                                AND E_O.EMP_STATUS='Active'
                            ORDER BY DEPARTMENT_NAME, SECTION_NAME, E_O.EMP_CODE ASC";
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_bangla_id_card_back_evolish.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC objRptViewerUC = this.load_report_viewer();
            objRptViewerUC.crystalReportViewer1.ReportSource = r_d;
            objRptViewerUC.crystalReportViewer1.Refresh();
            objRptViewerUC.lastUserControlRptViewer = this;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string subQuery = generate_sub_query("E_O.DATE_OF_JOINING");

            string sql = @"SELECT U.BANG_UNIT_NAME as UNIT_NAME,
                                U.BANG_ADDRESS as ADDRESS,
                                E_O.EMP_CODE,
                                E_O.BANG_EMP_NAME as EMP_NAME,
                                to_char( E_O.DATE_OF_JOINING,'DD/MM/YYYY') as DATE_OF_JOINING,
                                E_P.BLOOD_GROUP AS IN_TIME1,
                                E_P.CONTACT_NO AS IN_TIME2,
                                E_P.NATIONAL_ID AS IN_TIME3,
                                E_P.PHOTO AS IN_TIME4,
                                E_P.EMP_PHOTO,
                                E_S.SIGNATURE,
                            E_P.BANG_PARMANENT_POST||',' AS IN_TIME6,
                               E_P.BANG_PARMANENT_VILL||','  AS IN_TIME7,
                            E_P.BANG_PARMANENT_PS||',' AS IN_TIME8,
                         E_P.BANG_PARMANENT_DIST||','  AS IN_TIME9,
                                  DES.BANG_DESIGNATION_NAME as DESIGNATION_NAME,
                                  DEP.BANG_DEPT_NAME AS DEPARTMENT_NAME,
                                   SEC.BANG_SEC_NAME AS IN_TIME5,
                            L.BANG_LINE_NAME as  IN_TIME31,
                             CAT.BANG_EMP_TYPE_NAME as EMP_CATEGORY_NAME
                            FROM UNIT U,
                                EMP_PERSONAL E_P,
                                EMP_OFFICIAL E_O,
                                DESIGNATION DES,
                                DEPARTMENT DEP,
                                SECTION SEC,
                                LINE L,
                                EMP_CATEGORY CAT,
                                EMP_SIGNATURE E_S
                            WHERE E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.LINE_ID=L.LINE_ID
                                AND E_O.EMP_ID=E_P.EMP_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_S.EMP_ID(+)=E_O.EMP_ID
                                AND E_O.EMP_CATEGORY_ID=CAT.EMP_CATEGORY_ID " + subQuery + @"
                                AND E_O.EMP_STATUS='Active'
                            ORDER BY DEPARTMENT_NAME, SECTION_NAME, E_O.EMP_CODE ASC";
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_bangla_id_card.rpt");
            r_d.Database.Tables["salary_sheet"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC objRptViewerUC = this.load_report_viewer();
            objRptViewerUC.crystalReportViewer1.ReportSource = r_d;
            objRptViewerUC.crystalReportViewer1.Refresh();
            objRptViewerUC.lastUserControlRptViewer = this;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sql = @"SELECT DISTINCT E_O.EMP_CODE,E_O.GROSS,
                                E_O.BANG_EMP_NAME AS EMP_NAME,
                                E_P.BANG_FATHER_NAME AS FATHER_NAME,
                                E_P.BANG_MOTHER_NAME AS MOTHER_NAME,
                                E_P.BANG_HUSBAND_NAME AS HUSBAND_NAME,
                                E_P.BANG_PARMANENT_POST AS PER_HOUSE,
                                E_P.BANG_PARMANENT_VILL AS PER_VILLAGE,
                                E_P.BANG_PARMANENT_PS AS PER_PS,
                                E_P.BANG_PARMANENT_DIST AS PER_DISTRICT,
                                E_P.BANG_PRESENT_VILL AS PRE_VILLAGE,
                                E_P.BANG_PRESENT_POST AS PRE_HOUSE,
                                E_P.BANG_PRESENT_PS AS PRE_PS,
                                E_P.BANG_PRESENT_DIST AS PRE_DISTRICT,
                                E_O.DATE_OF_JOINING,E_O.EMP_GRADE,to_Char(E_P.DATE_OF_BIRTH,'dd-Mon-yyyy') DATE_OF_BIRTH,
                                SEC.BANG_SEC_NAME SECTION_NAME,
                                E_C.BANG_EMP_TYPE_NAME EMP_CATEGORY_NAME,
                                DEP.BANG_DEPT_NAME AS DEPARTMENT_NAME,
                                DES.BANG_DESIGNATION_NAME AS DESIGNATION_NAME,
                                S_R_INFO.RULE_TRANSPORT,
                                S_R_INFO.RULE_MEDICAL,
                                U.BANG_UNIT_NAME AS UNIT_NAME,
                                U.BANG_ADDRESS AS ADDRESS,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100),ROUND((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))) AS BASIC,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100)/2,ROUND(((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))* RULE_HOUSE_RENT/100)) AS HOUSE_RENT
                            FROM EMP_PERSONAL E_P,EMP_OFFICIAL E_O,DEPARTMENT DEP,DESIGNATION DES,UNIT U,SALARY_RULE_INFO S_R_INFO,SECTION SEC,EMP_CATEGORY E_C
                            WHERE E_O.EMP_ID=E_P.EMP_ID AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID
                                AND E_O.EMP_CATEGORY_ID=E_C.EMP_CATEGORY_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.RULE_ID=S_R_INFO.RULE_ID                                
                                AND E_O.EMP_STATUS='Active'" + generate_sub_query("E_O.DATE_OF_JOINING") + @"
                            ORDER BY E_O.EMP_CODE ASC";
            ReportDocument r_d = new ReportDocument();
            r_d.Load(db.GetReportPath() + "rpt_appointment_letter_BANG.rpt");
            r_d.Database.Tables["appointment_letter"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            string sql = @"SELECT DISTINCT E_O.EMP_CODE,E_O.GROSS,
                                E_O.BANG_EMP_NAME AS EMP_NAME,
                                E_P.BANG_FATHER_NAME AS FATHER_NAME,
                                E_P.BANG_MOTHER_NAME AS MOTHER_NAME,
                                E_P.BANG_HUSBAND_NAME AS HUSBAND_NAME,
                                E_P.BANG_PARMANENT_POST AS PER_HOUSE,
                                E_P.BANG_PARMANENT_VILL AS PER_VILLAGE,
                                E_P.BANG_PARMANENT_PS AS PER_PS,
                                E_P.BANG_PARMANENT_DIST AS PER_DISTRICT,
                                E_P.BANG_PRESENT_VILL AS PRE_VILLAGE,
                                E_P.BANG_PRESENT_POST AS PRE_HOUSE,
                                E_P.BANG_PRESENT_PS AS PRE_PS,
                                E_P.BANG_PRESENT_DIST AS PRE_DISTRICT,
                                E_O.DATE_OF_JOINING,E_O.EMP_GRADE,to_Char(E_P.DATE_OF_BIRTH,'dd-Mon-yyyy') DATE_OF_BIRTH,
                                SEC.BANG_SEC_NAME SECTION_NAME,
                                E_C.BANG_EMP_TYPE_NAME EMP_CATEGORY_NAME,
                                DEP.BANG_DEPT_NAME AS DEPARTMENT_NAME,
                                DES.BANG_DESIGNATION_NAME AS DESIGNATION_NAME,
                                S_R_INFO.RULE_TRANSPORT,
                                S_R_INFO.RULE_MEDICAL,
                                U.BANG_UNIT_NAME AS UNIT_NAME,
                                --U.BANG_ADDRESS AS ADDRESS,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100),ROUND((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))) AS BASIC,
                                DECODE(RULE_BASIC,50,ROUND((E_O.GROSS*S_R_INFO.RULE_BASIC)/100)/2,ROUND(((E_O.GROSS-(S_R_INFO.RULE_TRANSPORT+S_R_INFO.RULE_MEDICAL+S_R_INFO.RULE_FOOD))/((100+S_R_INFO.RULE_BASIC)/100))* RULE_HOUSE_RENT/100)) AS HOUSE_RENT,
                                RULE_FOOD AS ADDRESS
                            FROM EMP_PERSONAL E_P,EMP_OFFICIAL E_O,DEPARTMENT DEP,DESIGNATION DES,UNIT U,SALARY_RULE_INFO S_R_INFO,SECTION SEC,EMP_CATEGORY E_C
                            WHERE E_O.EMP_ID=E_P.EMP_ID AND E_O.UNIT_ID=U.UNIT_ID
                                AND E_O.DEPARTMENT_ID=DEP.DEPARTMENT_ID
                                AND E_O.SECTION_ID=SEC.SECTION_ID and E_O.EMP_CATEGORY_ID in('4','7')
                                AND E_O.EMP_CATEGORY_ID=E_C.EMP_CATEGORY_ID
                                AND E_O.DESIGNATION_ID=DES.DESIGNATION_ID
                                AND E_O.RULE_ID=S_R_INFO.RULE_ID                                
                                AND E_O.EMP_STATUS='Active'" + generate_sub_query("E_O.DATE_OF_JOINING") + @"
                            ORDER BY E_O.EMP_CODE ASC";
            ReportDocument r_d = new ReportDocument();
            //r_d.Load(db.GetReportPath() + "rpt_appointment_letter_tfl_SEC.rpt");
            r_d.Load(db.GetReportPath() + "rpt_appointment_letter_tfl.rpt");
            r_d.Database.Tables["appointment_letter"].SetDataSource(db.GetDataSet(sql).Tables[0]);
            CrystalReportViewerUC obj_report_viewer_uc = this.load_report_viewer();
            obj_report_viewer_uc.crystalReportViewer1.ReportSource = r_d;
            obj_report_viewer_uc.crystalReportViewer1.Refresh();
            obj_report_viewer_uc.lastUserControlRptViewer = this;
        }
    } // End of public partial class Report_New_Recruitment_UC : UserControl
} // End of namespace WindowsFormsApplication1
