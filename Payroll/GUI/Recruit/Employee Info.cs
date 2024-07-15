using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Drawing.Imaging;
using System.Configuration;


namespace NGPayroll
{
    public partial class employee_Information_UC : UserControl
    {
        DataSet ds;        
        int CurrentData = 0;
        int TotalDataFound = 0;
        DBClass db = new DBClass();
        byte[] empImage { get; set; }
        byte[] empSign {get; set;}
       
        public string empCodeInfo ;
        public UserControl lastUserControlEmpInfo;
        public int getExitForLastUserControlEmpInfo = 0;
        
        public employee_Information_UC()
        {
            InitializeComponent();
            
            getFieldClearFromData();
            populate_combobox_item();
            cmbStatus.SelectedIndex = 0;
            combo_weekend.SelectedIndex= 0;
            combo_gender.SelectedIndex= 0;
            combo_religion.SelectedIndex= 0;
            combo_marital.SelectedIndex= 0;

            func_combo_pos();
            func_combo_unit();
            func_combo_line();
            func_combo_grade();
            func_combo_section();
            func_combo_PreDist();
            func_combo_PerDist();
            func_combo_education();
            func_combo_department();
            func_combo_designation();
            func_combo_salary_rule();
            func_combo_emp_category();
            func_combo_working_rule();
          //  autocomplete_permanent_address_text();
        }

        private void autocomplete_permanent_address_text()
        {
            
            string sql = @"SELECT distinct nvl(BANG_PARMANENT_VILL,'.'),nvl(BANG_PARMANENT_PS,'.'),nvl(BANG_PARMANENT_DIST,'.'),nvl(BANG_PARMANENT_POST,'.') FROM Emp_personal";
            OracleDataReader reader = db.GetExecuteReader(sql);
           
            AutoCompleteStringCollection parm_dist_Collection = new AutoCompleteStringCollection();
            AutoCompleteStringCollection parm_vill_Collection = new AutoCompleteStringCollection();
            AutoCompleteStringCollection parm_PO_Collection = new AutoCompleteStringCollection();
            AutoCompleteStringCollection parm_PS_Collection = new AutoCompleteStringCollection();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    char f = ' ';

                    var r = convert_from_unicode(reader.GetString(2), f);
                    var rr = System.Net.WebUtility.HtmlDecode(reader.GetString(2));

                    if (!String.IsNullOrEmpty(reader.GetString(2))) parm_dist_Collection.Add(reader.GetString(2).ToString());
                    if (reader.GetString(0) != DBNull.Value.ToString()) parm_vill_Collection.Add(reader.GetString(0));
                    if (reader.GetString(3) != DBNull.Value.ToString()) parm_PO_Collection.Add(reader.GetString(3));
                    if (reader.GetString(1) != DBNull.Value.ToString()) parm_PS_Collection.Add(reader.GetString(1));

                }
            }
            reader.Close();
            
            txtBangParmentDist.AutoCompleteCustomSource = parm_dist_Collection;
            txtBangParmentVill.AutoCompleteCustomSource = parm_vill_Collection;
            txtBangParmentPO.AutoCompleteCustomSource = parm_PO_Collection;
            txtBangParmentPS.AutoCompleteCustomSource = parm_PS_Collection;
        }

        private string convert_from_unicode(string str, char c)
        {

            string rtstr = "";
            for (int i = 2; i < str.Length; i += 6)
            {
                string str1 = str.Substring(i, 4);
                c = (char)Int16.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                rtstr += c;
            }
            return rtstr;

        }
        private void func_combo_PreDist()
        {
            
            string query = "SELECT DISTINCT PRESENT_DIST FROM EMP_PERSONAL WHERE PRESENT_DIST IS NOT NULL ORDER BY PRESENT_DIST";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                string value = dr.GetString(0);
                string key = dr.GetString(0);
                cmbPresDist.Items.Add(new KeyValuePair<string, string>(key, value));
            }
            dr.Close();
            cmbPresDist.DisplayMember = "Key";
            cmbPresDist.ValueMember = "Value";
        }
        private void func_combo_PerDist()
        {
            
            string query = "SELECT DISTINCT PARMANENT_DIST FROM EMP_PERSONAL WHERE PARMANENT_DIST IS NOT NULL ORDER BY PARMANENT_DIST";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                string value = dr.GetString(0);
                string key = dr.GetString(0);
                cmbPerDist.Items.Add(new KeyValuePair<string, string>(key, value));
            }
            dr.Close();
            cmbPerDist.DisplayMember = "Key";
            cmbPerDist.ValueMember = "Value";
        }
        private void func_combo_education()
        {
            
            string query = "SELECT DISTINCT EDUCATION FROM EMP_PERSONAL WHERE EDUCATION IS NOT NULL ORDER BY EDUCATION";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                string value = dr.GetString(0);
                string key = dr.GetString(0);
                cmbEducation.Items.Add(new KeyValuePair<string, string>(key, value));
            }
            dr.Close();
            cmbEducation.DisplayMember = "Key";
            cmbEducation.ValueMember = "Value";
        }
        private void getFieldClearFromData()
        {
            getDefaultImage();
            getDefaultSignature();
            CConfig.getClrData(this);
            combo_gender.Text = "MALE";
            combo_religion.Text = "ISLAM";
            combo_marital.Text = "SINGLE";
            txt_vill_present.Text = "VAWAL MIRZAPUR";
            txt_po_present.Text = "MIRZAPUR BAZAR";
            txt_ps_present.Text = "SADAR";
            cmbPresDist.Text = "GAZIPUR";
            txtBangPresentVill.Text = "fvIqvj wgR©vcyi";
            txtBangPresentPO.Text = "wgR©vcyi evRvi";
            txtBangPresentPS.Text = "m`i";
            txtBangPresentDist.Text = "MvRxcyi";

            cmbStatus.Text = "Active";
            CBox_Category.Tag = "3";
            CBox_Category.Text = "WORKER";
            CBox_Unit.Tag = "1";
            CBox_Unit.Text = "Talha Fabrics Ltd";
            combo_weekend.Text = "N/A";
            txtEmpCode.Focus();
            //txt_age.Text = "15";
            RB_None.Checked = true;
            CB_ot_holder.Checked = true;
            chkResign.Checked = false;
            lbLos.Text = "";
            lbLv.Text = "";
            btnSave.Text="Save";
            cmbIncrSeg.Text = "<Incr Segment>";
            //dtpBirthDate.Value = DateTime.Now.AddYears(-18).Date;
            dtpCloseDate.Value = dtpJoinDate.Value = DateTime.Now.Date;
        }
        private void employee_Information_UC_Load(object sender, EventArgs e)
        {
            getMaternityStatus();
            lbCountData.Text = "";
            getFieldClearFromData();
            lbLastUpdate.Visible = false;
            lbLastCode.Visible = false;                  
        }
        private void getDefaultImage()
        {
            
            string strSql = "SELECT PARAMETER,DEFAULT_IMAGE FROM FEATURE WHERE ATTRIBUTE='DEFAULT_IMAGE'";
            DataSet ds = db.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                empImage = (byte[])ds.Tables[0].Rows[0]["DEFAULT_IMAGE"];
                txtPhotoPath.Text = ds.Tables[0].Rows[0]["PARAMETER"].ToString();
                pBoxPhoto.Image = Image.FromStream(CDisplay.GetMemoryStream(empImage));
            }
            else pBoxPhoto.Image = null;
        }
        private void getDefaultSignature()
        {
            
            string strSql = "SELECT PARAMETER,DEFAULT_IMAGE FROM FEATURE WHERE ATTRIBUTE='DEFAULT_IMAGE'";
            DataSet ds = db.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                empSign = (byte[])ds.Tables[0].Rows[0]["DEFAULT_IMAGE"];
                txtSignPath.Text = ds.Tables[0].Rows[0]["PARAMETER"].ToString();
                pBoxEmpSignature.Image = Image.FromStream(CDisplay.GetMemoryStream(empSign));
            }
            else pBoxEmpSignature.Image = null;
        }
        private void getMaternityStatus()
        {
            
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
        private string GetServicePeriod()
        {
            string strLoS = "";
            if (cmbStatus.Text == "Active") strLoS = CConfig.getDateDiff(dtpJoinDate.Value.Date, DateTime.Now.Date, true);
            else strLoS = CConfig.getDateDiff(dtpJoinDate.Value.Date, dtpCloseDate.Value.Date, true);
            return strLoS;
        }
        public int[] GetLeaveBalance(string str)
        {
            int cYear = DateTime.Now.Year, pYear = cYear - 1;
            int[] CSE = new int[3]; CSE[0] = CSE[1] = CSE[2] = 0;
            string strSql = @"SELECT 14-NVL(GRANT_SL,0) SL,NVL(CASE WHEN DATE_OF_JOINING<'01-Jan-" + cYear + @"' THEN 10
                ELSE ROUND(10/365*(365-ROUND(MONTHS_BETWEEN(DATE_OF_JOINING,'01-Jan-" + cYear + @"')/12*365+1))) END,0)-NVL(GRANT_CL,0) CL,
                DECODE(E_O.EL_HOLDER,'Y',((CASE WHEN (TRUNC(MONTHS_BETWEEN(SYSDATE,DATE_OF_JOINING)/12))<1 THEN 0 ELSE NVL(ROUND(PRESENT/18,0),0) END)-NVL(GRANT_EL,0)),0) EL
            FROM EMP_OFFICIAL E_O,(SELECT DISTINCT A.EMP_ID,COUNT(A.EMP_ID) PRESENT FROM ATTENDANCE_DETAILS A,EMP_OFFICIAL O,
                    (SELECT E.EMP_ID,MAX(E.LAST_COUNTING_DATE+1) LAST_DATE FROM EARN_LEAVE_PROCESS E
                    WHERE E.LAST_COUNTING_DATE<'01-Jan-" + cYear + @"' GROUP BY E.EMP_ID) E
                WHERE A.ATTD_DATE BETWEEN NVL(E.LAST_DATE,O.DATE_OF_JOINING) AND '" + dtpCloseDate.Text
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
            WHERE E_O.EMP_ID=P.EMP_ID(+) AND E_O.EMP_ID=LV.EMP_ID(+) AND E_O.EMP_ID=LX.EMP_ID(+)" + str;

            DataSet ds = db.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grLv.Visible = true;
                lbLv.Parent = grLv;
                DataRow dr = ds.Tables[0].Rows[0];
                int iEL = Convert.ToInt32(dr["EL"]);
                int iCL = Convert.ToInt32(dr["CL"]);
                int iSL = Convert.ToInt32(dr["SL"]);
                CSE[0] = iCL; CSE[1] = iSL; CSE[2] = iEL;
            }
            else grLv.Visible = false;
            return CSE;
        }
        
        private double getBasicSalary()
        {
            double dblBasic = 0.0;
            
            string sql = "SELECT RULE_ID, NVL(RULE_BASIC,0) RULE_BASIC, NVL(RULE_HOUSE_RENT,0) RULE_HOUSE_RENT, NVL(RULE_MEDICAL,0) RULE_MEDICAL, NVL(RULE_TRANSPORT,0) RULE_TRANSPORT, NVL(RULE_FOOD,0) RULE_FOOD FROM SALARY_RULE_INFO WHERE RULE_ID = " + CBox_SalaryRule.Tag;
            OracleDataReader dr = db.GetExecuteReader(sql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    int intAllow = Convert.ToInt32(dr["RULE_MEDICAL"]) + Convert.ToInt32(dr["RULE_TRANSPORT"]) + Convert.ToInt32(dr["RULE_FOOD"]);
                    if (Convert.ToInt32(dr["RULE_BASIC"]) == 50) dblBasic = Math.Round(Convert.ToDouble(txt_gross.Text) * (Convert.ToDouble(dr["RULE_BASIC"]) / 100.0), 0);
                    else dblBasic = Math.Round((Convert.ToDouble(txt_gross.Text) - (double)intAllow) / (1.0 + Convert.ToDouble(dr["RULE_HOUSE_RENT"]) / 100.0), 0);
                }
            }
            return dblBasic;
        }  // End of private double getBasicSalary()
        public void getEmpInfoDisplay(string strSubQuery)
        {
            
            string sql = @"SELECT DISTINCT E_O.EMP_ID,E_O.EMP_CODE,ERP_CODE,UPPER(E_O.EMP_NAME) EMP_NAME,UPPER(FATHER_NAME) FATHER_NAME,
                                UPPER(MOTHER_NAME) MOTHER_NAME,UPPER(HUSBAND_NAME) HUSBAND_NAME,SEX,RELIGION,MARITAL_STATUS,BLOOD_GROUP,
                                DATE_OF_BIRTH,UPPER(PRESENT_VILL) PRESENT_VILL,UPPER(PRESENT_HOUSE) PRESENT_HOUSE,UPPER(PRESENT_PS) PRESENT_PS,
                                UPPER(PRESENT_DIST) PRESENT_DIST,UPPER(PARMANENT_HOUSE) PARMANENT_HOUSE,UPPER(PARMANENT_VILL) PARMANENT_VILL,
                                UPPER(PARMANENT_PS) PARMANENT_PS,UPPER(PARMANENT_DIST) PARMANENT_DIST,EDUCATION,EMPLOYEMENT,NATIONAL_ID,
                                UPPER(BENEFICIARY_NAME) BENEFICIARY_NAME,RELATION_WITH_BENEFICIARY,NOMINEE_CELL_NO,UPPER(E_P.REMARKS) REMARKS,
                                DATE_OF_JOINING,UPPER(DESIGNATION_NAME) DESIGNATION_NAME,E_O.POS_ID,P.POS_NAME,G.GRD_ID,E_O.EMP_GRADE,INITCAP(UNIT_NAME) UNIT_NAME,INCR_SEGMENT,
                                EMP_CATEGORY_NAME,UPPER(DEPARTMENT_NAME) DEPARTMENT_NAME,UPPER(SECTION_NAME) SECTION_NAME,LINE_NAME,SHIFT_NAME,E_O.EMP_STATUS,RULE_NAME,E_O.RULE_ID,
                                NVL(E_O.GROSS,0) GROSS,ROUND(DECODE(RULE_BASIC,50,(E_O.GROSS * RULE_BASIC/100),(E_O.GROSS - (RULE_MEDICAL + RULE_TRANSPORT + RULE_FOOD))/(1 + RULE_BASIC / 100))) BASIC,
                                DECODE(BANK_ACCOUNT_HOLDER,'Y',ACCOUNT_NO,'M',NVL(MOBILE_BANK_ACC_NO,ACCOUNT_NO),NVL(ACCOUNT_NO,MOBILE_BANK_ACC_NO)) ACCOUNT_NO,NVL(CONTRACTUAL,'N') CONTRACTUAL,
                                E_O.LICENSE_NO,NVL(EL_HOLDER,'N') EL_HOLDER,NVL(EL_SEGMENT,'None') EL_SEGMENT,E_P.E_MAIL,E_O.WEEKEND,PROXIMITY_NO,E_P.CONTACT_NO,BANK_ACCOUNT_HOLDER,NVL(E_O.OVER_TIME,'N') OVER_TIME,
                                NVL(E_O.LUNCH,'N') LUNCH,E_O.QTR_ALW,NVL(E_O.TAX_HOLDER,'N') TAX_HOLDER,NVL(RESIGN_GIVEN,'N') RESIGN_GIVEN,CLOSE_DATE,E_O.DESIGNATION_ID,E_O.UNIT_ID,E_O.EMP_CATEGORY_ID,
                                E_O.DEPARTMENT_ID,E_O.SECTION_ID,E_O.LINE_ID,E_O.SHIFT_ID,E_P.BANG_FATHER_NAME,E_O.BANG_EMP_NAME,E_P.BANG_MOTHER_NAME,E_P.BANG_HUSBAND_NAME,E_P.BANG_PRESENT_VILL,E_P.BANG_PRESENT_POST,
                                E_P.BANG_PRESENT_PS,E_P.BANG_PRESENT_DIST,E_P.BANG_PARMANENT_VILL,E_P.BANG_PARMANENT_POST,E_P.BANG_PARMANENT_PS,E_P.BANG_PARMANENT_DIST,E_O.BANG_BENEFICIARY_NAME
                            FROM EMP_PERSONAL E_P,UNIT UNI,LINE LIN,EMP_CATEGORY E_C,DEPARTMENT DEPT,SECTION SEC,DESIGNATION DESG,SHIFT_INFO S_I,EMP_OFFICIAL E_O,SALARY_RULE_INFO SAL_RUL,TB_POSITION_LEVEL P,TB_EMP_GRADE G
                            WHERE E_O.EMP_ID = E_P.EMP_ID AND E_O.POS_ID = P.POS_ID AND E_O.GRD_ID = G.GRD_ID AND E_O.UNIT_ID = UNI.UNIT_ID 
                                AND E_O.EMP_CATEGORY_ID = E_C.EMP_CATEGORY_ID AND DEPT.DEPARTMENT_ID = E_O.DEPARTMENT_ID AND SEC.SECTION_ID = E_O.SECTION_ID 
                                AND LIN.LINE_ID = E_O.LINE_ID AND E_O.SHIFT_ID = S_I.SHIFT_ID(+) AND E_O.DESIGNATION_ID = DESG.DESIGNATION_ID AND E_O.RULE_ID = SAL_RUL.RULE_ID(+) " + strSubQuery;
            
            ds = db.GetDataSet(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CurrentData = 0;
                TotalDataFound = ds.Tables[0].Rows.Count;
                DataRow dr = ds.Tables[CurrentData].Rows[0];
                FillFormData(dr);
            }//if (Ds.Tables[0].Rows.Count > 0)
            else
            {
                MessageBox.Show("No data found.", "Info");
                lbCountData.Text = "";
                txtEmpCode.Focus();
            }           
            lbRecordCount.Text = "Total: " + TotalDataFound + " Data Found.";
        }// End of 
        
        //---------------[STARY] FOR DESIGNATION -------------------//
        void func_combo_designation()
        {
            string query = "SELECT DESIGNATION_ID, DESIGNATION_NAME from DESIGNATION ORDER BY DESIGNATION_NAME";
            
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                cmbDesig.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }

            cmbDesig.DisplayMember = "Key";
            cmbDesig.ValueMember = "Value";
        }

        private void CBox_Designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDesig.Text.Trim().Length < 1) cmbDesig.SelectedIndex = -1;
            else
            {
                KeyValuePair<string, int> sVal = (KeyValuePair<string, int>)cmbDesig.SelectedItem;
                cmbDesig.Tag = sVal.Value;
                cmbDesig.Text = sVal.Key;
                DataSet ds = db.GetDataSet("SELECT G.GRD_ID,D.GRADE FROM DESIGNATION D,TB_EMP_GRADE G WHERE D.GRADE = G.GRADE_NAME AND D.DESIGNATION_ID='" + cmbDesig.Tag + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbGrd.Tag = ds.Tables[0].Rows[0]["GRD_ID"];
                    cmbGrd.Text = ds.Tables[0].Rows[0]["GRADE"].ToString();
                }
            }
        }

        private void CBox_Designation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> sVal = (KeyValuePair<string, int>)cmbDesig.SelectedItem;
                cmbDesig.Tag = sVal.Value;
                cmbDesig.Text = sVal.Key;
                DataSet ds = db.GetDataSet("SELECT G.GRD_ID,D.GRADE FROM DESIGNATION D,TB_EMP_GRADE G WHERE D.GRADE = G.GRADE_NAME AND D.DESIGNATION_ID='" + cmbDesig.Tag + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbGrd.Tag = ds.Tables[0].Rows[0]["GRD_ID"];
                    cmbGrd.Text = ds.Tables[0].Rows[0]["GRADE"].ToString();
                }
            }   
        }
        //---------------------- END FOR DESIGNATION ------------------//

        //--------------------- [START] FOR UNIT ---------------------//
        void func_combo_unit()
        {
            
            string query = "SELECT UNIT_ID, UNIT_NAME FROM UNIT ORDER BY UNIT_NAME";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));
                string key = dr.GetString(1);
                CBox_Unit.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            dr.Close();
            CBox_Unit.DisplayMember = "Key";
            CBox_Unit.ValueMember = "Value";
        }

        private void CBox_Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>) CBox_Unit.SelectedItem;

            CBox_Unit.Tag = selectedItemVal.Value;  // make text value to dispalay value
            CBox_Unit.Text = selectedItemVal.Key;   // make the value to tag property of textbox
            
        }

        private void CBox_Unit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>) CBox_Unit.SelectedItem;

                CBox_Unit.Tag = selectedItemVal.Value;  // make text value to dispalay value
                CBox_Unit.Text = selectedItemVal.Key;   // make the value to tag property of textbox
            }
        }
        //--------------------- END UNIT --------------------------//

        //--------------------- [START] FOR EMPLOYEE CATEGORY -------------//
        void func_combo_emp_category()
        {
            string query = "SELECT EMP_CATEGORY_ID, EMP_CATEGORY_NAME FROM EMP_CATEGORY ORDER BY EMP_CATEGORY_NAME";
            
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                CBox_Category.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }
            dr.Close();
            CBox_Category.DisplayMember = "Key";
            CBox_Category.ValueMember = "Value";
        }

        private void CBox_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_Category.SelectedItem;
            CBox_Category.Tag = selectedItemVal.Value;
            CBox_Category.Text = selectedItemVal.Key;
            if (CBox_Category.Text.ToUpper() == "WORKER")
            {
                chkEL.Checked = true;
                if (dtpJoinDate.Value.Month > 6) cmbEL.Text = "July";
                else cmbEL.Text = "January";
            }
            else
            {
                chkEL.Checked = false;
                cmbEL.Text = "N/A";
            }
        }

        private void CBox_Category_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_Category.SelectedItem;

                CBox_Category.Tag = selectedItemVal.Value;  // make text value to dispalay value
                CBox_Category.Text = selectedItemVal.Key;   // make the value to tag property of textbox
                
            }
        }
        //------------------ END EMPLOYEE CATEGORY --------------------//

        //------------------- [START] DEPARTMENT ---------------------//
        void func_combo_department()
        {
            string sql = "SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM DEPARTMENT ORDER BY DEPARTMENT_NAME";
            
            OracleDataReader dr = db.GetExecuteReader(sql);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                CBox_Department.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }
            dr.Close();
            CBox_Department.DisplayMember = "Key";
            CBox_Department.ValueMember = "Value";
        }

        private void CBox_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_Department.SelectedItem;

            CBox_Department.Tag = selectedItemVal.Value;  // make text value to dispalay value
            CBox_Department.Text = selectedItemVal.Key;   // make the value to tag property of textbox
            
        }

        private void CBox_Department_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_Department.SelectedItem;

                CBox_Department.Tag = selectedItemVal.Value;  // make text value to dispalay value
                CBox_Department.Text = selectedItemVal.Key;   // make the value to tag property of textbox
                txt_department.Text = "";
            }
        }
        //-------------------- END DEPARTMENT ------------------------//

        //-------------------- [START] SECTION COMBOBOX-----------------------//
        void func_combo_section()
        {
            string query = "SELECT SECTION_ID, SECTION_NAME FROM SECTION ORDER BY SECTION_NAME";
            
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                CBox_Section.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }
            dr.Close();
            CBox_Section.DisplayMember = "Key";
            CBox_Section.ValueMember = "Value";
        }

        private void CBox_Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_Section.SelectedItem;

            CBox_Section.Tag = selectedItemVal.Value;  // make text value to dispalay value
            CBox_Section.Text = selectedItemVal.Key;   // make the value to tag property of textbox
            
        }

        private void CBox_Section_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_Section.SelectedItem;

                CBox_Section.Tag = selectedItemVal.Value;  // make text value to dispalay value
                CBox_Section.Text = selectedItemVal.Key;   // make the value to tag property of textbox
            
            }
        }
        //------------------------ END SECTION COMBOBOX ------------------------//

        //------------------------ START LINE/GROUP -----------------------------//
        void func_combo_line()
        {
            string query = "SELECT LINE_ID, LINE_NAME FROM LINE ORDER BY LINE_NAME";
            
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {

                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                CBox_Group.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }
            dr.Close();
            CBox_Group.DisplayMember = "Key";
            CBox_Group.ValueMember = "Value";
        }
        void func_combo_pos()
        {
            //DataSet ds = db.GetDataSet("SELECT POS_ID, POS_NAME FROM T$_POSITION_LEVEL ORDER BY POS_NAME");
            DataSet ds = db.GetDataSet("SELECT POS_ID, POS_NAME FROM TB_POSITION_LEVEL ORDER BY POS_NAME");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string key = ds.Tables[0].Rows[i]["POS_NAME"].ToString();
                int val = Convert.ToInt32(ds.Tables[0].Rows[i]["POS_ID"]);
                cmbPos.Items.Add(new KeyValuePair<string, int>(key, val));
            }
            cmbPos.DisplayMember = "Key";
            cmbPos.ValueMember = "Value";
        }
        void func_combo_grade()
        {
            //DataSet ds = db.GetDataSet("SELECT GRD_ID, GRADE_NAME FROM T$_EMP_GRADE ORDER BY GRADE_NAME");
            DataSet ds = db.GetDataSet("SELECT GRD_ID, GRADE_NAME FROM TB_EMP_GRADE ORDER BY GRADE_NAME");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string key = ds.Tables[0].Rows[i]["GRADE_NAME"].ToString();
                int val = Convert.ToInt32(ds.Tables[0].Rows[i]["GRD_ID"]);
                cmbGrd.Items.Add(new KeyValuePair<string, int>(key, val));
            }
            cmbGrd.DisplayMember = "Key";
            cmbGrd.ValueMember = "Value";
        }
        private void cmbGrd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGrd.Text.Trim().Length < 1) cmbGrd.SelectedIndex = -1;
            else
            {
                KeyValuePair<string, int> sVal = (KeyValuePair<string, int>)cmbGrd.SelectedItem;
                cmbGrd.Tag = sVal.Value;
                cmbGrd.Text = sVal.Key;
            }
        }

        private void cmbPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPos.Text.Trim().Length < 1) cmbPos.SelectedIndex = -1;
            else
            {
                KeyValuePair<string, int> sVal = (KeyValuePair<string, int>)cmbPos.SelectedItem;
                cmbPos.Tag = sVal.Value;
                cmbPos.Text = sVal.Key;
            }
        }
        private void CBox_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_Group.SelectedItem;
            CBox_Group.Tag = selectedItemVal.Value;
            CBox_Group.Text = selectedItemVal.Key;
            
        }

        private void CBox_Group_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_Group.SelectedItem;

                CBox_Group.Tag = selectedItemVal.Value;  // make text value to dispalay value
                CBox_Group.Text = selectedItemVal.Key;   // make the value to tag property of textbox
               
            }
        }
        //--------------------- END LINE/GROUP -------------------------------//

        //----------------------- [START] SHIFT INFO ----------------------//
        void func_combo_working_rule()
        {
            
            string query = "SELECT SHIFT_ID, SHIFT_NAME FROM SHIFT_INFO ORDER BY SHIFT_NAME";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                CBox_WorkingTime.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }
            dr.Close();
            CBox_WorkingTime.DisplayMember = "Key";
            CBox_WorkingTime.ValueMember = "Value";
        }

        private void CBox_WorkingTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_WorkingTime.SelectedItem;

            CBox_WorkingTime.Tag = selectedItemVal.Value;  // make text value to dispalay value
            CBox_WorkingTime.Text = selectedItemVal.Key;   // make the value to tag property of textbox
            
        }

        private void CBox_WorkingTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_WorkingTime.SelectedItem;

                CBox_WorkingTime.Tag = selectedItemVal.Value;  // make text value to dispalay value
                CBox_WorkingTime.Text = selectedItemVal.Key;   // make the value to tag property of textbox
                
            }
        }
        //--------------------- END SHIFT INFORMATION ------------------------------//

        //--------------------- START SALARY RULE ------------------------------//
        void func_combo_salary_rule()
        {
            
            string query = "SELECT RULE_ID, RULE_NAME FROM SALARY_RULE_INFO ORDER BY RULE_NAME";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));    // designation id
                string key = dr.GetString(1);  //designation name

                CBox_SalaryRule.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }
            dr.Close();
            CBox_SalaryRule.DisplayMember = "Key";
            CBox_SalaryRule.ValueMember = "Value";
        }

        private void CBox_SalaryRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_SalaryRule.SelectedItem;

            CBox_SalaryRule.Tag = selectedItemVal.Value;  // make text value to dispalay value
            CBox_SalaryRule.Text = selectedItemVal.Key;   // make the value to tag property of textbox
        }

        private void CBox_SalaryRule_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selectedItemVal = (KeyValuePair<string, int>)CBox_SalaryRule.SelectedItem;

                CBox_SalaryRule.Tag = selectedItemVal.Value;  // make text value to dispalay value
                CBox_SalaryRule.Text = selectedItemVal.Key;   // make the value to tag property of textbox
                
            }
        }
        //----------------------- END SALARY RULE -----------------------//
        private void populate_combobox_item()
        {

            /****** start set combobox items for GENDER ******/

            combo_gender.Items.Add(new KeyValuePair<string, string>("MALE", "MALE"));
            combo_gender.Items.Add(new KeyValuePair<string, string>("FEMALE", "FEMALE"));

            combo_gender.DisplayMember = "key";
            combo_gender.ValueMember = "Value";

            /****** end set combobox items for GENDER ******/

            /****** start set combobox items for RELIGION ******/
            combo_religion.Items.Add(new KeyValuePair<string, string>("ISLAM", "ISLAM"));
            combo_religion.Items.Add(new KeyValuePair<string, string>("SONATON", "SONATON"));
            combo_religion.Items.Add(new KeyValuePair<string, string>("BUDDHIST", "BUDDHIST"));
            combo_religion.Items.Add(new KeyValuePair<string, string>("KRISTIAN", "KRISTIAN"));

            combo_religion.DisplayMember = "key";
            combo_religion.ValueMember = "Value";

            /****** end set combobox items for RELIGION ******/

            /****** start set combobox items for MARITAL STATUS ******/

            combo_marital.Items.Add(new KeyValuePair<string, string>("SINGLE", "SINGLE"));
            combo_marital.Items.Add(new KeyValuePair<string, string>("MARRIED", "MARRIED"));
            combo_marital.Items.Add(new KeyValuePair<string, string>("WIDOW", "WIDOW"));
            combo_marital.Items.Add(new KeyValuePair<string, string>("DIVORCED", "DIVORCED"));

            combo_marital.DisplayMember = "key";
            combo_marital.ValueMember = "Value";

            /****** end set combobox items for MARITAL STATUS ******/

            /****** start set combobox items for BLOOD GROUP ******/

            combo_blood.Items.Add(new KeyValuePair<string, string>("A+", "A+"));
            combo_blood.Items.Add(new KeyValuePair<string, string>("A-", "A-"));
            combo_blood.Items.Add(new KeyValuePair<string, string>("B+", "B+"));
            combo_blood.Items.Add(new KeyValuePair<string, string>("B-", "B-"));
            combo_blood.Items.Add(new KeyValuePair<string, string>("O+", "O+"));
            combo_blood.Items.Add(new KeyValuePair<string, string>("O-", "O-"));
            combo_blood.Items.Add(new KeyValuePair<string, string>("AB+", "AB+"));
            combo_blood.Items.Add(new KeyValuePair<string, string>("AB-", "AB-"));

            combo_blood.DisplayMember = "key";
            combo_blood.ValueMember = "Value";

            /****** end set combobox items for BLOOD GROUP ******/

            /****** start set combobox items for RELATION ******/

            combo_relation.Items.Add(new KeyValuePair<string, string>("Father", "Father"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Mother", "Mother"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Brother", "Brother"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Sister", "Sister"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Husband", "Husband"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Wife", "Wife"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Son", "Son"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Doughter", "Doughter")); 
            combo_relation.Items.Add(new KeyValuePair<string, string>("Uncle", "Uncle"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Aunt", "Aunt"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Cousin", "Cousin"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Father-in-law", "Father-in-law"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Mother-in-law", "Mother-in-law"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Brother-in-law", "Brother-in-law"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Sister-in-law", "Sister-in-law"));
            combo_relation.Items.Add(new KeyValuePair<string, string>("Others", "Others"));
            
            combo_relation.DisplayMember = "key";
            combo_relation.ValueMember = "Value";

            /****** end set combobox items for RELATION ******/

            /****** start set combobox items for STATUS ******/

            cmbStatus.Items.Add(new KeyValuePair<string, string>("Active", "Active"));
            cmbStatus.Items.Add(new KeyValuePair<string, string>("Close", "Close"));
            cmbStatus.Items.Add(new KeyValuePair<string, string>("Inactive", "Inactive"));
            cmbStatus.Items.Add(new KeyValuePair<string, string>("Maternity", "Maternity"));

            cmbStatus.DisplayMember = "key";
            cmbStatus.ValueMember = "Value";

            /****** end set combobox items for STATUS ******/

            /****** start set combobox items for WEEKEND ******/

            combo_weekend.Items.Add(new KeyValuePair<string, string>("Friday", "Friday"));
            combo_weekend.Items.Add(new KeyValuePair<string, string>("Saturday", "Saturday"));
            combo_weekend.Items.Add(new KeyValuePair<string, string>("Sunday", "Sunday"));
            combo_weekend.Items.Add(new KeyValuePair<string, string>("Monday", "Monday"));
            combo_weekend.Items.Add(new KeyValuePair<string, string>("Tuesday", "Tuesday"));
            combo_weekend.Items.Add(new KeyValuePair<string, string>("Wednesday", "Wednesday"));
            combo_weekend.Items.Add(new KeyValuePair<string, string>("Thursday", "Thursday"));
            combo_weekend.Items.Add(new KeyValuePair<string, string>("N/A", "N/A"));

            combo_weekend.DisplayMember = "key";
            combo_weekend.ValueMember = "Value";
        }
        private void FormControlMode(int Mode)
        {
            switch (Mode)
            {
                case 0:
                    lbLastUpdate.Visible = true;
                    lbLastCode.Visible = true;
                    lbCountData.Visible = false;
                    lbRecordCount.Visible = false;
                    lbLastCode.Cursor = Cursors.Hand;
                    lbLastCode.Text = txtEmpCode.Text.Trim();
                    break;
                case 1:
                    lbLastUpdate.Visible = false;
                    lbLastCode.Visible = false;
                    lbCountData.Visible = true;
                    lbRecordCount.Visible = true;
                    break;
            }
        }        
        private void btn_clear_Click(object sender, EventArgs e)
        {
            employee_Information_UC_Load(sender, e);
            FormControlMode(1);
            btnSave.Text = "Save";
        }
        private void getLogFileForInsertData()
        {
            string strLogQuery = "";
            
            strLogQuery += " CODE: " + txtEmpCode.Text + Environment.NewLine;
            strLogQuery += " ERP_ID: " + txtErpCode.Text + Environment.NewLine;
            strLogQuery += " NAME: " + txt_emp_name.Text + Environment.NewLine;
            strLogQuery += " STATUS: " + cmbStatus.Text + Environment.NewLine;
            strLogQuery += " DOJ: " + dtpJoinDate.Text + Environment.NewLine;
            strLogQuery += " GROSS" + txt_gross.Text + Environment.NewLine;
            strLogQuery += " DESIG: " + cmbDesig.Text + Environment.NewLine;
            strLogQuery += " UNIT: " + CBox_Unit.Text + Environment.NewLine;
            strLogQuery += " CATEGORY: " + CBox_Category.Text + Environment.NewLine;
            strLogQuery += " DEPT: " + CBox_Department.Text + Environment.NewLine;
            strLogQuery += " SECTION: " + CBox_Section.Text + Environment.NewLine;
            strLogQuery += " SHIFT: " + CBox_Group.Text + Environment.NewLine;
            strLogQuery += " SALARY_RULE: " + CBox_SalaryRule.Text + Environment.NewLine;
            strLogQuery += " PROXIMITY: " + txtProximityNo.Text + Environment.NewLine;
            strLogQuery += " BENEFICIARY: " + txt_beneficiary.Text + Environment.NewLine;
            strLogQuery += " RELATIONSHIP: " + combo_relation.Text + Environment.NewLine;
            strLogQuery += " QUALIFICATION: " + cmbEducation.Text + Environment.NewLine;
            strLogQuery += " EXPERIENCE: " + txtEmployement.Text + Environment.NewLine;
            strLogQuery += " CONTACT_NO: " + txt_cell_no.Text + Environment.NewLine;
            strLogQuery += " WEEKEND: " + combo_weekend.Text + Environment.NewLine;
            strLogQuery += " INCR_SEGMENT: " + cmbIncrSeg.Text + Environment.NewLine;
            strLogQuery += " ACCOUNT_NO: " + txtAccountNo.Text;
            if (RB_None.Checked) strLogQuery += " SALARY_PAY: Cash Pay";
            if (RB_Bank.Checked) strLogQuery += " SALARY_PAY: Bank Pay";
            if (RB_Mobile.Checked) strLogQuery += " SALARY_PAY: Mobile Pay";
            if (CB_tax.Checked) strLogQuery += " TAX_HODER: True"; else strLogQuery += " TAX_HODER: False";
            if (CB_ot_holder.Checked) strLogQuery += " OT_HODER: True"; else strLogQuery += " OT_HODER: False";
            if (CB_quater.Checked) strLogQuery += " QUATER_HODER: True"; else strLogQuery += " QUATER_HODER: False";
            if (CB_contractual.Checked) strLogQuery += " CONTRACTUAL: True"; else strLogQuery += " CONTRACTUAL: False";
            if (chkEL.Checked) strLogQuery += " EL_HODER: True"; else strLogQuery += " EL_HODER: False";
            strLogQuery += " EL_SEGMENT: " + cmbEL.Text + ".";
            if (strLogQuery != "") 
            {
                string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strLogQuery + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                db.RunDmlQuery(strSql);
            }
        }
        private void getSaveEmpInfoFromData()
        {
 	        try
            {
                string strEmpCode = txtEmpCode.Text.Trim();
                string strErpCode = txtErpCode.Text.Trim();
                string strEmpName = txt_emp_name.Text.Trim();
                string emp_name_local = txtEmpNameBang.Text.Trim();
                string strFatherName = txt_father_name.Text.Trim();
                string strMotherName = txt_emp_mother.Text.Trim();
                string strSpouseName = txt_husband_name.Text.Trim();

                string bang_father_name = CConfig.SetEscapeChar(txtBangFatherName.Text.Trim());
                string bang_mother_name = CConfig.SetEscapeChar(txtBangMotherName.Text.Trim());
                string bang_husb_wife_name = CConfig.SetEscapeChar(txtBangHusband.Text.Trim());
                string bang_nomini_name = CConfig.SetEscapeChar(txtBang_nomini.Text.Trim());

                string gender = combo_gender.Text;
                string religion = combo_religion.Text;// selectedItemVal.Value;
                string marital_status = combo_marital.Text;// selectedItemVal.Value;
                string blood_group = combo_blood.Text; //selectedItemVal.Value;
                string date_of_birth = dtpBirthDate.Text; //txt_birthday.Text;
                string present_vill = txt_vill_present.Text.Trim();
                string present_post = txt_po_present.Text.Trim();
                string present_ps = txt_ps_present.Text.Trim();
                string present_dist = cmbPresDist.Text.Trim();
                string parmanent_vill = txt_vill_parmanent.Text.Trim();
                string parmanent_post = txt_po_parmanent.Text.Trim();
                string parmanent_ps = txt_ps_parmanent.Text.Trim();
                string parmanent_dist = cmbPerDist.Text.Trim();

                string bang_present_vill = CConfig.SetEscapeChar(txtBangPresentVill.Text.Trim());
                string bang_present_post_office = CConfig.SetEscapeChar(txtBangPresentPO.Text.Trim());
                string bang_present_police_station = CConfig.SetEscapeChar(txtBangPresentPS.Text.Trim());
                string bang_present_dist = CConfig.SetEscapeChar(txtBangPresentDist.Text.Trim());
                string bang_parmanent_vill = CConfig.SetEscapeChar(txtBangParmentVill.Text.Trim());
                string bang_parmanent_post_office = CConfig.SetEscapeChar(txtBangParmentPO.Text.Trim());
                string bang_parmanent_police_station = CConfig.SetEscapeChar(txtBangParmentPS.Text.Trim());
                string bang_parmanent_dist = CConfig.SetEscapeChar(txtBangParmentDist.Text.Trim());



                string national_id = txt_national_id.Text.Trim();
                string strEducation = cmbEducation.Text.Trim();
                string beneficiary = txt_beneficiary.Text.Trim();
                string relation = combo_relation.Text;
                string remarks = txt_remarks.Text.Trim();
                string strStatus = cmbStatus.Text;
                string joinDate = dtpJoinDate.Text;
                string grade = cmbGrd.Text.Trim();
                int desig_id = Convert.ToInt32(cmbDesig.Tag);
                int unit_id = Convert.ToInt32(CBox_Unit.Tag);
                int cate_id = Convert.ToInt32(CBox_Category.Tag);
                int dept_id = Convert.ToInt32(CBox_Department.Tag);
                int sec_id = Convert.ToInt32(CBox_Section.Tag);
                int group_id = Convert.ToInt32(CBox_Group.Tag);
                int shift_id = Convert.ToInt32(CBox_WorkingTime.Tag);
                int rule_id = Convert.ToInt32(CBox_SalaryRule.Tag);
                double gross = Convert.ToDouble(txt_gross.Text.Trim());
                string weekend = combo_weekend.Text;
                string card_no = txtProximityNo.Text.Trim();
                string cell_no = txt_cell_no.Text.Trim();
                string nomineeCellNo = txtNomineeCellNo.Text.Trim();
                string email = txt_email.Text.Trim();
                string licenseNo = txtLicenseNo.Text.Trim();
                string strEmployement = txtEmployement.Text.Trim();
                string family = txtQtr.Text.Trim() == "" ? "0" : txtQtr.Text.Trim();
                string strAccType = "", strBankAccNo = "", mBankAccNo = "";
                if (RB_Bank.Checked)
                {
                    strAccType = "Y";//RB_Bank.Text;
                    strBankAccNo = txtAccountNo.Text.Trim();
                }
                else if (RB_Mobile.Checked)
                {
                    strAccType = "M";//RB_Mobile.Text;
                    mBankAccNo = txtAccountNo.Text.Trim();
                }
                else if (RB_None.Checked)
                {
                    strAccType = "N";
                    if(txtAccountNo.Text.Trim().Contains('.'))
                        strBankAccNo = txtAccountNo.Text.Trim();
                    else mBankAccNo = txtAccountNo.Text.Trim();
                }
                string strEmpType = CB_contractual.Checked ? "Y" : "N";
                string otHolder = CB_ot_holder.Checked ? "Y" : "N";
                string quater = CB_quater.Checked ? "Y" : "N";
                string tax = CB_tax.Checked ? "Y" : "N";
                string resign_given = chkResign.Checked ? "Y" : "N";
                string resign_date = dtpCloseDate.Text;
                string strELChk = chkEL.Checked ? "Y" : "N";                    
                string strELSegment = cmbEL.Text;
                string strSql, strResignDate = "";
                int intEID = 0;
                
                strSql = "SELECT NVL(MAX(EMP_ID),0) + 1 AS EID FROM EMP_OFFICIAL";
                DataSet ds = db.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count > 0) intEID = Convert.ToInt32(ds.Tables[0].Rows[0]["EID"]);
                strSql = "SELECT EMP_ID FROM EMP_OFFICIAL WHERE EMP_CODE='" + strEmpCode + "'";
                ds = db.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count>0)
                {
                    MessageBox.Show("Employee Code " + strEmpCode + " already exists in database, please enter new employee code.", "Insertion Error");
                    getFieldClearFromData();
                }
                else
                {
                    if (strStatus != "Active")
                    {
                        strResignDate = dtpCloseDate.Value.ToString("dd-MMM-yyyy");
                        if (cmbStatus.Text == "Maternity") getMaternityLeave(intEID);
                    }
                    string strQuery = @"INSERT INTO EMP_OFFICIAL (EMP_ID, EMP_CODE, EMP_NAME, ERP_CODE, UNIT_ID, EMP_CATEGORY_ID, DEPARTMENT_ID, SECTION_ID, LINE_ID, DESIGNATION_ID, SHIFT_ID, DATE_OF_JOINING, PROXIMITY_NO, LICENSE_NO, EMP_STATUS, CLOSE_DATE,EMP_STATUS_CHANGE_DATE,GRD_ID,POS_ID, 
                                            GROSS, WEEKEND, OVER_TIME, LUNCH, USER_ID, ACCOUNT_NO, MOBILE_BANK_ACC_NO, BANK_ACCOUNT_HOLDER, TAX_HOLDER, RULE_ID, EMP_GRADE, BANG_EMP_GRADE, BENEFICIARY_NAME, RELATION_WITH_BENEFICIARY, EL_HOLDER, EL_SEGMENT,INCR_SEGMENT,BANG_BENEFICIARY_NAME,BANG_EMP_NAME,QTR_ALW) 
                                        VALUES ('" + intEID + "', '" + strEmpCode + "', '" + strEmpName + "', '" + strErpCode + "','" + unit_id + "', '" + cate_id + "', '" + dept_id + "', '" + sec_id + "', '" + group_id + "', '" + desig_id + "', '" + shift_id + "', '" + joinDate +
                                            "', '" + card_no + "', '" + licenseNo + "','" + strStatus + "','" + strResignDate + "', TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'), '" + cmbGrd.Tag + "','" + cmbPos.Tag + "','" + gross + "', '" + weekend + "', '" + otHolder + "', '" + quater +
                                            "', '" + ConfigurationManager.AppSettings["UserID"] + "','" + strBankAccNo + "', '" + mBankAccNo + "','" + strAccType + "', '" + tax + "', '" + rule_id + "', '" + grade + "','" + grade + "','" + beneficiary + "', '" + relation + "','" + strELChk + "','" + strELSegment + "','" + cmbIncrSeg.Text + "',N'" + bang_nomini_name + "', '" + emp_name_local + "','" + family + "')";

                    if (db.RunDmlQuery(strQuery))
                    {
                        string strQuery2 = @"INSERT INTO EMP_PERSONAL (FATHER_NAME, MOTHER_NAME, DATE_OF_BIRTH, NOMINEE_CELL_NO, SEX, CONTRACTUAL, CONTACT_NO, MARITAL_STATUS, RELIGION, NATIONAL_ID, BLOOD_GROUP, E_MAIL,
                                                EMPLOYEMENT, EMP_ID, HUSBAND_NAME, REMARKS, PRESENT_HOUSE, PRESENT_VILL, PRESENT_PS, PRESENT_DIST, PARMANENT_HOUSE, PARMANENT_VILL, PARMANENT_PS, PARMANENT_DIST, EDUCATION,
                                                BANG_FATHER_NAME,BANG_MOTHER_NAME,BANG_HUSBAND_NAME,BANG_PRESENT_VILL, BANG_PRESENT_POST, BANG_PRESENT_PS, BANG_PRESENT_DIST, BANG_PARMANENT_VILL, BANG_PARMANENT_POST, BANG_PARMANENT_PS, BANG_PARMANENT_DIST) 
                                            VALUES ('" + strFatherName + "', '" + strMotherName + "', '" + date_of_birth + "', '" + nomineeCellNo + "', '" + gender + "', '" + strEmpType + "','" + cell_no + "','" + marital_status +
                                                "', '" + religion + "', '" + national_id + "', '" + blood_group + "', '" + email + "', '" + strEmployement + "', '" + intEID + "', '" + strSpouseName + "', '" + remarks + "','" + present_post + 
                                                "', '" + present_vill + "','" + present_ps+ "', '" + present_dist + "', '" + parmanent_vill + "','" + parmanent_post + "', '" + parmanent_ps + "', '" + parmanent_dist + "', '" + strEducation + "','" + bang_father_name + "', '" + bang_mother_name + "','" + bang_husb_wife_name + "','" + bang_present_vill + "', '" + bang_present_post_office + "', '" + bang_present_police_station + "', '" + bang_present_dist + "', '" + bang_parmanent_vill + "', '" + bang_parmanent_post_office + "','" + bang_parmanent_police_station + "', '" + bang_parmanent_dist + "' )";


                       
                        if (db.RunDmlQuery(strQuery2))
                        {
                            getLogFileForInsertData();
                            MessageBox.Show("Information Saved Successfully", "Save");
                            FormControlMode(0);
                        }
                        else
                        {
                            strSql = "DELETE EMP_OFFICIAL WHERE EMP_CODE='" + strEmpCode + "'";
                            db.RunDmlQuery(strSql);
                        }
                    }
                    else
                    {
                        strSql = "DELETE EMP_OFFICIAL WHERE EMP_CODE='" + strEmpCode + "'";
                        db.RunDmlQuery(strSql);
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// End of private void getSaveEmpInfoFromData
        private void getLogFileForUpdateData()
        {
            string strLogQuery = "";
            
            if (txtEmpCode.Text.Trim() != ds.Tables[0].Rows[CurrentData]["EMP_CODE"].ToString())
                strLogQuery += " EMP_CODE: " + ds.Tables[0].Rows[CurrentData]["EMP_CODE"].ToString() + " TO " + txtEmpCode.Text.Trim() + Environment.NewLine;
            if (cmbStatus.Text != ds.Tables[0].Rows[CurrentData]["EMP_STATUS"].ToString())
                strLogQuery += " EMP_STATUS: " + ds.Tables[0].Rows[0]["EMP_STATUS"].ToString() + " TO " + cmbStatus.Text + Environment.NewLine;
            if (txt_gross.Text != ds.Tables[0].Rows[0]["GROSS"].ToString())
                strLogQuery += " GROSS: " + ds.Tables[0].Rows[0]["GROSS"].ToString() + " TO " + txt_gross.Text + Environment.NewLine;
            if (cmbDesig.Text != ds.Tables[0].Rows[0]["DESIGNATION_NAME"].ToString())
                strLogQuery += " DESI: " + ds.Tables[0].Rows[0]["DESIGNATION_NAME"].ToString() + " TO " + cmbDesig.Text + Environment.NewLine;
            if (CBox_Unit.Text != ds.Tables[0].Rows[0]["UNIT_NAME"].ToString())
                strLogQuery += " UNIT: " + ds.Tables[0].Rows[0]["UNIT_NAME"].ToString() + " TO " + CBox_Unit.Text + Environment.NewLine;
            if (CBox_Category.Text != ds.Tables[0].Rows[0]["EMP_CATEGORY_NAME"].ToString())
                strLogQuery += " CATEGORY: " + ds.Tables[0].Rows[0]["EMP_CATEGORY_NAME"].ToString() + " TO " + CBox_Category.Text + Environment.NewLine;
            if (CBox_Department.Text != ds.Tables[0].Rows[0]["DEPARTMENT_NAME"].ToString())
                strLogQuery += " DEPT: " + ds.Tables[0].Rows[0]["DEPARTMENT_NAME"].ToString() + " TO " + CBox_Department.Text + Environment.NewLine;
            if (CBox_Section.Text != ds.Tables[0].Rows[0]["SECTION_NAME"].ToString())
                strLogQuery += " SECTION: " + ds.Tables[0].Rows[0]["SECTION_NAME"].ToString() + " TO " + CBox_Section.Text + Environment.NewLine;
            if (CBox_Group.Text != ds.Tables[0].Rows[0]["LINE_NAME"].ToString())
                strLogQuery += " SHIFT: " + ds.Tables[0].Rows[0]["LINE_NAME"].ToString() + " TO " + CBox_Group.Text + Environment.NewLine;
            if (CBox_SalaryRule.Text != ds.Tables[0].Rows[0]["RULE_NAME"].ToString())
                strLogQuery += " SALARY_RULE: " + ds.Tables[0].Rows[0]["RULE_NAME"].ToString() + " TO " + CBox_SalaryRule.Text + Environment.NewLine;
            if (txtProximityNo.Text != ds.Tables[0].Rows[0]["PROXIMITY_NO"].ToString())
                strLogQuery += " PROXIMITY: " + ds.Tables[0].Rows[0]["PROXIMITY_NO"].ToString() + " TO " + txtProximityNo.Text + Environment.NewLine;
            if (txtAccountNo.Text != ds.Tables[0].Rows[0]["ACCOUNT_NO"].ToString())
                strLogQuery += " ACCOUNT_NO: " + ds.Tables[0].Rows[0]["ACCOUNT_NO"].ToString() + " TO " + txtAccountNo.Text + Environment.NewLine;
            if (cmbIncrSeg.Text != ds.Tables[0].Rows[0]["INCR_SEGMENT"].ToString())
                strLogQuery += " INCR_SEGMENT: " + ds.Tables[0].Rows[0]["INCR_SEGMENT"].ToString() + " TO " + cmbIncrSeg.Text + Environment.NewLine;
            if (cmbEL.Text != ds.Tables[0].Rows[0]["EL_SEGMENT"].ToString())
                strLogQuery += " EL_SEGMENT: " + ds.Tables[0].Rows[0]["EL_SEGMENT"].ToString() + " TO " + cmbEL.Text + Environment.NewLine;
            if (combo_weekend.Text != ds.Tables[0].Rows[0]["WEEKEND"].ToString())
                strLogQuery += " WEEKEND: " + ds.Tables[0].Rows[0]["WEEKEND"].ToString() + " TO " + combo_weekend.Text + Environment.NewLine;
            if (dtpJoinDate.Text != Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_OF_JOINING"]).Date.ToString("dd-MMM-yyyy"))
                strLogQuery += " DOJ: " + Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_OF_JOINING"]).Date.ToString("dd-MMM-yyyy") + " TO " + dtpJoinDate.Text + Environment.NewLine;
            if (dtpBirthDate.Text != Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_OF_BIRTH"]).Date.ToString("dd-MMM-yyyy"))
                strLogQuery += " DOJ: " + Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE_OF_BIRTH"]).Date.ToString("dd-MMM-yyyy") + " TO " + dtpBirthDate.Text + Environment.NewLine;
            if (dtpCloseDate.Text != ds.Tables[0].Rows[0]["CLOSE_DATE"].ToString() || dtpCloseDate.Text != Convert.ToDateTime(ds.Tables[0].Rows[0]["CLOSE_DATE"]).Date.ToString("dd-MMM-yyyy"))
                strLogQuery += " CLOSE DATE: " + (ds.Tables[0].Rows[0]["CLOSE_DATE"].ToString() == "" ? "NULL" : ""+Convert.ToDateTime(ds.Tables[0].Rows[0]["CLOSE_DATE"]).Date.ToString("dd-MMM-yyyy")+"") + " TO " + dtpCloseDate.Text + Environment.NewLine;
            if (cmbEducation.Text.Trim() != ds.Tables[0].Rows[CurrentData]["EDUCATION"].ToString())
            {
                strLogQuery += " QUALIFICATION: " + cmbEducation.Text.Trim() + Environment.NewLine;
                if (ds.Tables[0].Rows[CurrentData]["EDUCATION"].ToString().Length > 0)
                    strLogQuery += " QUALIFICATION: " + ds.Tables[0].Rows[CurrentData]["EDUCATION"].ToString() + " TO " + cmbEducation.Text.Trim() + Environment.NewLine;
            }
            if (txtEmployement.Text.Trim() != ds.Tables[0].Rows[CurrentData]["EMPLOYEMENT"].ToString())
            {
                strLogQuery += " EXPERIENCE: " + txtEmployement.Text.Trim() + Environment.NewLine;
                if (ds.Tables[0].Rows[CurrentData]["EMPLOYEMENT"].ToString().Length > 0)
                    strLogQuery += " EXPERIENCE: " + ds.Tables[0].Rows[CurrentData]["EMPLOYEMENT"].ToString() + " TO " + txtEmployement.Text.Trim() + Environment.NewLine;
            }
            if (txtErpCode.Text.Trim() != ds.Tables[0].Rows[CurrentData]["ERP_CODE"].ToString())
            {
                strLogQuery += " ERP_CODE: " + txtErpCode.Text.Trim() + Environment.NewLine;
                if (ds.Tables[0].Rows[CurrentData]["ERP_CODE"].ToString().Length > 0)
                    strLogQuery += " ERP_CODE: " + ds.Tables[0].Rows[CurrentData]["ERP_CODE"].ToString() + " TO " + txtErpCode.Text.Trim() + Environment.NewLine;
            }
            if (txt_beneficiary.Text.Trim() != ds.Tables[0].Rows[CurrentData]["BENEFICIARY_NAME"].ToString())
            {
                strLogQuery += " BENEFICIARY: " + txt_beneficiary.Text.Trim() + Environment.NewLine;
                if (ds.Tables[0].Rows[CurrentData]["BENEFICIARY_NAME"].ToString().Length > 0)
                    strLogQuery += " BENEFICIARY: " + ds.Tables[0].Rows[CurrentData]["BENEFICIARY_NAME"].ToString() + " TO " + txt_beneficiary.Text.Trim() + Environment.NewLine;
            }
            if (combo_relation.Text.Trim() != ds.Tables[0].Rows[CurrentData]["RELATION_WITH_BENEFICIARY"].ToString())
            {
                strLogQuery += " RELATIONSHIP: " + combo_relation.Text.Trim() + Environment.NewLine;
                if (ds.Tables[0].Rows[CurrentData]["RELATION_WITH_BENEFICIARY"].ToString().Length > 0)
                    strLogQuery += " RELATIONSHIP: " + ds.Tables[0].Rows[CurrentData]["RELATION_WITH_BENEFICIARY"].ToString() + " TO " + combo_relation.Text.Trim() + Environment.NewLine;
            }
            if (txt_cell_no.Text.Trim() != ds.Tables[0].Rows[CurrentData]["CONTACT_NO"].ToString())
            {
                strLogQuery += " CONTACT_NO: " + txt_cell_no.Text.Trim() + Environment.NewLine;
                if (ds.Tables[0].Rows[CurrentData]["CONTACT_NO"].ToString().Length > 0)
                    strLogQuery += " CONTACT_NO: " + ds.Tables[0].Rows[CurrentData]["CONTACT_NO"].ToString() + " TO " + txt_cell_no.Text.Trim() + Environment.NewLine;
            }
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["BANK_ACCOUNT_HOLDER"]) == 'N')
            {
                if (RB_Bank.Checked) strLogQuery += " SALARY_PAY: Cash To Bank ";
                else if (RB_Mobile.Checked) strLogQuery += " SALARY_PAY: Cash To Mobile ";
            }
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["BANK_ACCOUNT_HOLDER"]) == 'Y')
            {
                if (RB_None.Checked) strLogQuery += " SALARY_PAY: Bank To Cash ";
                else if (RB_Mobile.Checked) strLogQuery += " SALARY_PAY: Bank To Mobile ";
            }
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["BANK_ACCOUNT_HOLDER"]) == 'M')
            {
                if (RB_None.Checked) strLogQuery += " SALARY_PAY: Mobile To Cash ";
                else if (RB_Bank.Checked) strLogQuery += " SALARY_PAY: Mobile To Bank ";
            }
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["TAX_HOLDER"]) == 'Y') if (!CB_tax.Checked) strLogQuery += " TAX_HOLDER: False ";
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["TAX_HOLDER"]) == 'N') if (CB_tax.Checked) strLogQuery += " TAX_HOLDER: True ";
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["EL_HOLDER"]) == 'Y') if (!chkEL.Checked) strLogQuery += " EL_HOLDER: False ";
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["EL_HOLDER"]) == 'N') if (chkEL.Checked) strLogQuery += " EL_HOLDER: True ";
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["LUNCH"]) == 'Y') if (!CB_quater.Checked) strLogQuery += " QUATER_HOLDER: False ";
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["LUNCH"]) == 'N') if (CB_quater.Checked) strLogQuery += " QUATER_HOLDER: True ";
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["OVER_TIME"]) == 'Y') if (!CB_ot_holder.Checked) strLogQuery += " OT_HOLDER: False ";
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["OVER_TIME"]) == 'N') if (CB_ot_holder.Checked) strLogQuery += " OT_HOLDER: True ";
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["CONTRACTUAL"]) == 'Y') if (!CB_contractual.Checked) strLogQuery += " CONTRACTUAL: False ";
            if (Convert.ToChar(ds.Tables[0].Rows[CurrentData]["CONTRACTUAL"]) == 'N') if (CB_contractual.Checked) strLogQuery += " CONTRACTUAL: True ";
            if (strLogQuery != "")
            {
                string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strLogQuery.Trim() + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                db.RunDmlQuery(strSql);
            }
        }
        private void getUpdateEmpInfoFromData()
        {
            if (MessageBox.Show("Are you sure to update employee (" + txtEmpCode.Text + ")", "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int intEID = Convert.ToInt32(txtEmpCode.Tag);
                    string strEmpCode = txtEmpCode.Text.Trim();
                    string strErpCode = txtErpCode.Text.Trim();
                    string emp_name = txt_emp_name.Text.Trim();
                    string emp_name_bang = CConfig.SetEscapeChar(txtEmpNameBang.Text.Trim().ToString());
                    string father_name = txt_father_name.Text.Trim();
                    string mother_name = txt_emp_mother.Text.Trim();

                    string bang_father_name = CConfig.SetEscapeChar(txtBangFatherName.Text.Trim());
                    string bang_mother_name = CConfig.SetEscapeChar(txtBangMotherName.Text.Trim());
                    string bang_husb_wife_name = CConfig.SetEscapeChar(txtBangHusband.Text.Trim());
                    string bang_nomini_name = CConfig.SetEscapeChar(txtBang_nomini.Text.Trim());



                    string spouse_name = txt_husband_name.Text.Trim();
                    string gender = combo_gender.Text;
                    string religion = combo_religion.Text;// selectedItemVal.Value;
                    string marital_status = combo_marital.Text;// selectedItemVal.Value;
                    string blood_group = combo_blood.Text; //selectedItemVal.Value;
                    string date_of_birth = dtpBirthDate.Text; //txt_birthday.Text;
                    string present_vill = txt_vill_present.Text.Trim();
                    string present_post = txt_po_present.Text.Trim();
                    string present_ps = txt_ps_present.Text.Trim();
                    string present_dist = cmbPresDist.Text.Trim();
                    string parmanent_vill = txt_vill_parmanent.Text.Trim();
                    string parmanent_post = txt_po_parmanent.Text.Trim();
                    string parmanent_ps = txt_ps_parmanent.Text.Trim();
                    string parmanent_dist = cmbPerDist.Text.Trim();

                    string bang_present_vill = CConfig.SetEscapeChar(txtBangPresentVill.Text.Trim());
                    string bang_present_post_office = CConfig.SetEscapeChar(txtBangPresentPO.Text.Trim());
                    string bang_present_police_station = CConfig.SetEscapeChar(txtBangPresentPS.Text.Trim());
                    string bang_present_dist = CConfig.SetEscapeChar(txtBangPresentDist.Text.Trim());
                    string bang_parmanent_vill = CConfig.SetEscapeChar(txtBangParmentVill.Text.Trim());
                    string bang_parmanent_post_office = CConfig.SetEscapeChar(txtBangParmentPO.Text.Trim());
                    string bang_parmanent_police_station = CConfig.SetEscapeChar(txtBangParmentPS.Text.Trim());
                    string bang_parmanent_dist = CConfig.SetEscapeChar(txtBangParmentDist.Text.Trim());


                    string national_id = txt_national_id.Text.Trim();
                    string strEducation = cmbEducation.Text.Trim();
                    string beneficiary = txt_beneficiary.Text.Trim();
                    string relation = combo_relation.Text;
                    string remarks = txt_remarks.Text.Trim();
                    string strStatus = cmbStatus.Text; //selectedItemVal.Value;
                    string joining_date = dtpJoinDate.Text; //txt_joining_dt.Text;
                    string grade = cmbGrd.Text.Trim();
                    int desig_id = Convert.ToInt32(cmbDesig.Tag); //;Convert.ToInt32(txt_designation.Tag.ToString());
                    int unit_id = Convert.ToInt32(CBox_Unit.Tag.ToString());
                    int category_id = Convert.ToInt32(CBox_Category.Tag); //Convert.ToInt32(txt_category.Tag.ToString());
                    int dept_id = Convert.ToInt32(CBox_Department.Tag); //Convert.ToInt32(txt_department.Tag.ToString());
                    int section_id = Convert.ToInt32(CBox_Section.Tag);  //Convert.ToInt32(txt_section.Tag.ToString());
                    int group_id = Convert.ToInt32(CBox_Group.Tag); //Convert.ToInt32(txt_group.Tag.ToString());
                    int intShiftID = Convert.ToInt32(CBox_WorkingTime.Tag); //Convert.ToInt32(txt_working_time.Tag.ToString());
                    int rule_id = Convert.ToInt32(CBox_SalaryRule.Tag); //Convert.ToInt32(txt_salary_rule.Tag.ToString());
                    double gross = Convert.ToDouble(txt_gross.Text.Trim());
                    string weekend = combo_weekend.Text; //selectedItemVal.Value;
                    string strProxyNo = txtProximityNo.Text.Trim();
                    string cell_no = txt_cell_no.Text.Trim();
                    string nomineeCellNo = txtNomineeCellNo.Text.Trim();
                    string strLicenseNo = txtLicenseNo.Text.Trim();
                    string email = txt_email.Text.Trim();
                    string strEmployement = txtEmployement.Text.Trim();
                    string qtrBill = txtQtr.Text.Trim() == "" ? "0" : txtQtr.Text.Trim();
                    string strAccType = "", strBankAccNo = "", mBankAccNo = "", strResignDate = "";
                    if (RB_Bank.Checked)
                    {
                        strAccType = "Y";
                        strBankAccNo = txtAccountNo.Text.Trim();
                    }
                    else if (RB_Mobile.Checked)
                    {
                        strAccType = "M";
                        mBankAccNo = txtAccountNo.Text.Trim();
                    }
                    else if (RB_None.Checked)
                    {
                        strAccType = "N";
                        if (txtAccountNo.Text.Contains('.'))
                            strBankAccNo = txtAccountNo.Text.Trim();
                        else mBankAccNo = txtAccountNo.Text.Trim();
                    }
                    string strEmpType = CB_contractual.Checked ? "Y" : "N";
                    string ot_holder = CB_ot_holder.Checked ? "Y" : "N";
                    string quater_holder = CB_quater.Checked ? "Y" : "N";
                    string tax_holder = CB_tax.Checked ? "Y" : "N";
                    string strIsResign = chkResign.Checked ? "Y" : "N";
                    string strEL = chkEL.Checked ? "Y" : "N";
                    string strELSegment = cmbEL.Text.Trim();
                    if (strStatus != "Active")
                    {
                        strResignDate = dtpCloseDate.Value.ToString("dd-MMM-yyyy");
                        if (cmbStatus.Text == "Maternity") getMaternityLeave(intEID);
                    }
                    
                    string strQuery = @"UPDATE EMP_OFFICIAL SET EMP_CODE = '" + strEmpCode + "',ERP_CODE = '" + strErpCode + "',EMP_NAME = '" + emp_name + "', BANG_EMP_NAME = N'" + emp_name_bang + "', DATE_OF_JOINING = '" + joining_date + "', PROXIMITY_NO = '" + strProxyNo + "', LINE_ID = '" + group_id +
                            "', EL_HOLDER='" + strEL + "',EL_SEGMENT='" + strELSegment + "',EMP_STATUS = '" + strStatus + "', DESIGNATION_ID = '" + desig_id + "', UNIT_ID = '" + unit_id + "', EMP_CATEGORY_ID = '" + category_id + "', DEPARTMENT_ID = '" + dept_id +
                            "', ACCOUNT_NO = '" + strBankAccNo + "',SECTION_ID = '" + section_id + "', RULE_ID = '" + rule_id + "', GROSS = '" + gross + "', WEEKEND = '" + weekend + "', RESIGN_GIVEN = '" + strIsResign + "', MOBILE_BANK_ACC_NO = '" + mBankAccNo +
                            "', BANK_ACCOUNT_HOLDER = '" + strAccType + "', LICENSE_NO = '" + strLicenseNo + "', SHIFT_ID = '" + intShiftID + "',  TAX_HOLDER = '" + tax_holder + "', OVER_TIME = '" + ot_holder + "', BENEFICIARY_NAME = '" + beneficiary + "', INCR_SEGMENT = '" + cmbIncrSeg.Text + "', GRD_ID='" + cmbGrd.Tag + "',POS_ID='" + cmbPos.Tag + "', EMP_GRADE = '" + grade +
                            "',BANG_EMP_GRADE = '" + grade + "',LUNCH='" + quater_holder + "', CLOSE_DATE = '" + strResignDate + "', USER_ID='" + ConfigurationManager.AppSettings["UserID"] + "', EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'), RELATION_WITH_BENEFICIARY = '" + relation + "',BANG_BENEFICIARY_NAME=N'" + bang_nomini_name + "', QTR_ALW='" + qtrBill + "' WHERE EMP_ID = '" + intEID + @"'";
                    if (db.RunDmlQuery(strQuery))
                    {
                        string strQuery2 = @"UPDATE EMP_PERSONAL SET FATHER_NAME = '" + father_name + "', MOTHER_NAME = '" + mother_name + "', HUSBAND_NAME = '" + spouse_name + "', REMARKS = '" + remarks +
                                "', DATE_OF_BIRTH = '" + date_of_birth + "', SEX = '" + gender + "', MARITAL_STATUS = '" + marital_status + "', RELIGION = '" + religion + "',NOMINEE_CELL_NO = '" + nomineeCellNo +
                                "', PRESENT_VILL = '" + present_vill + "', PRESENT_HOUSE = '" + present_post + "', PRESENT_PS = '" + present_ps + "', PRESENT_DIST = '" + present_dist + "', PARMANENT_HOUSE = '" + parmanent_vill +
                                "', PARMANENT_VILL = '" + parmanent_post + "', PARMANENT_PS = '" + parmanent_ps + "', PARMANENT_DIST = '" + parmanent_dist + "', NATIONAL_ID = '" + national_id + "', BLOOD_GROUP = '" + blood_group +
                                "',  CONTACT_NO = '" + cell_no + "',  E_MAIL = '" + email + "', CONTRACTUAL = '" + strEmpType + "',  EDUCATION = '" + strEducation + "', EMPLOYEMENT = '" + strEmployement + "', BANG_FATHER_NAME='" + bang_father_name + "', BANG_MOTHER_NAME='" + bang_mother_name + "', BANG_HUSBAND_NAME='" + bang_husb_wife_name + "', BANG_PRESENT_VILL='" + bang_present_vill + "', BANG_PRESENT_POST ='" + bang_present_post_office +
                                "', BANG_PRESENT_PS = '" + bang_present_police_station + "', BANG_PRESENT_DIST = '" + bang_present_dist + "', BANG_PARMANENT_VILL = '" + bang_parmanent_vill + "', BANG_PARMANENT_POST ='" + bang_parmanent_post_office +
                                "', BANG_PARMANENT_PS = '" + bang_parmanent_police_station + "', BANG_PARMANENT_DIST ='" + bang_parmanent_dist + "' WHERE EMP_ID = '" + intEID + @"'";
                        if (db.RunDmlQuery(strQuery2))
                        {
                            getLogFileForUpdateData();
                            MessageBox.Show("Updated Employee (" + txtEmpCode.Text + ") Successfully.", "Save As...");
                            FormControlMode(0);                    
                        }
                    }
                } // End of try(update)
                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }//End of private void getUpdateEmpInfoFromData        
        private bool getFormValidationRule()
        {
            if (txtEmpCode.Text.Length == 0)    // emp_code
            {
                MessageBox.Show("Employee code field is required.");
                txtEmpCode.Focus();
                txtEmpCode.BackColor = Color.Honeydew;
                return false;
            }
            if (txt_emp_name.Text.Length == 0)    // emp_name
            {
                MessageBox.Show("Employee name field is required.");
                txt_emp_name.Focus();
                txt_emp_name.BackColor = Color.Honeydew;
                return false;
            }
            if (cmbDesig.Text.Length == 0)       //group
            {
                MessageBox.Show("Designation field is required.");
                cmbDesig.Focus();
                cmbDesig.BackColor = Color.Honeydew;
                return false;
            }
            if (CBox_Group.Text.Length == 0)    //designation
            {
                MessageBox.Show("Group field is required.");
                CBox_Group.Focus();
                CBox_Group.BackColor = Color.Honeydew;
                return false;
            }
            if (CBox_WorkingTime.Text.Length == 0)    //working time - salary rule
            {
                MessageBox.Show("Working Time [Salary Rule] field is required.");
                CBox_WorkingTime.Focus();
                CBox_WorkingTime.BackColor = Color.Honeydew;
                return false;
            }
            if (CBox_Unit.Text.Length == 0)       // unit
            {
                MessageBox.Show("Unit field is required.");
                CBox_Unit.Focus();
                CBox_Unit.BackColor = Color.Honeydew;
                return false;
            }
            if (CBox_Category.Text.Length == 0)    //category
            {
                MessageBox.Show("Category field is required.");
                CBox_Category.Focus();
                CBox_Category.BackColor = Color.Honeydew;
                return false;
            }

            if (CBox_Department.Text.Length == 0)    //department
            {
                MessageBox.Show("Department field is required.");
                CBox_Department.Focus();
                CBox_Department.BackColor = Color.Honeydew;
                return false;
            }
            if (txt_gross.Text.Length == 0)    //department
            {
                MessageBox.Show("Gross salary field is required.");
                txt_gross.Focus();
                txt_gross.BackColor = Color.Honeydew;
                return false;
            }
            return true;
        }
        private void cmbStatusValidation()
        {
            if (cmbStatus.Text == "Maternity")
            {
                if (combo_gender.Text.ToUpper() == "MALE")
                {
                    MessageBox.Show("Confirm Employee Sex Type");
                    combo_gender.Focus();
                }
                if (combo_marital.Text.ToUpper() == "SINGLE")
                {
                    MessageBox.Show("Confirm Employee Marital Status");
                    combo_marital.Focus();
                }
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (getFormValidationRule())
            {
                if (btnSave.Text == "Save") getSaveEmpInfoFromData();
                else getUpdateEmpInfoFromData();
                getFieldClearFromData();
            }  //end if (form_validate() == true)
        }
        //#########################################################        
        private void FillFormData(DataRow dr)
        {
            txtEmpCode.Tag = dr["EMP_ID"].ToString();
            txtEmpCode.Text = dr["EMP_CODE"].ToString();
            txtErpCode.Text = dr["ERP_CODE"].ToString();
            txt_emp_name.Text = dr["EMP_NAME"].ToString();
            txt_father_name.Text = dr["FATHER_NAME"].ToString();
            txt_emp_mother.Text = dr["MOTHER_NAME"].ToString();
            txt_husband_name.Text = dr["HUSBAND_NAME"].ToString();

            txtEmpNameBang.Text = dr["BANG_EMP_NAME"].ToString();
            txtBangFatherName.Text = dr["BANG_FATHER_NAME"].ToString();
            txtBang_nomini.Text = dr["BANG_BENEFICIARY_NAME"].ToString();
            txtBangMotherName.Text = dr["BANG_MOTHER_NAME"].ToString();
            txtBangHusband.Text = dr["BANG_HUSBAND_NAME"].ToString();

            txtBangPresentVill.Text = dr["BANG_PRESENT_VILL"].ToString();
            txtBangPresentPO.Text = dr["BANG_PRESENT_POST"].ToString();
            txtBangPresentPS.Text = dr["BANG_PRESENT_PS"].ToString();
            txtBangPresentDist.Text = dr["BANG_PRESENT_DIST"].ToString();

            txtBangParmentVill.Text = dr["BANG_PARMANENT_VILL"].ToString();
            txtBangParmentPO.Text = dr["BANG_PARMANENT_POST"].ToString();
            txtBangParmentPS.Text = dr["BANG_PARMANENT_PS"].ToString();
            txtBangParmentDist.Text = dr["BANG_PARMANENT_DIST"].ToString();

            combo_gender.Text = dr["SEX"].ToString();
            combo_religion.Text = dr["RELIGION"].ToString();
            combo_marital.Text = dr["MARITAL_STATUS"].ToString();
            combo_blood.Text = dr["BLOOD_GROUP"].ToString();
            dtpBirthDate.Text = Convert.ToDateTime(dr["DATE_OF_BIRTH"]).ToString();
            txt_age.Text = Math.Floor((DateTime.Today.Date - dtpBirthDate.Value.Date).TotalDays / 365.0).ToString();
            txt_vill_present.Text = dr["PRESENT_VILL"].ToString();
            txt_po_present.Text = dr["PRESENT_HOUSE"].ToString();
            txt_ps_present.Text = dr["PRESENT_PS"].ToString();
            cmbPresDist.Text = dr["PRESENT_DIST"].ToString();
            txt_vill_parmanent.Text = dr["PARMANENT_HOUSE"].ToString();
            txt_po_parmanent.Text = dr["PARMANENT_VILL"].ToString();
            txt_ps_parmanent.Text = dr["PARMANENT_PS"].ToString();
            cmbPerDist.Text = dr["PARMANENT_DIST"].ToString();
            txt_national_id.Text = dr["NATIONAL_ID"].ToString();
            cmbEducation.Text = dr["EDUCATION"].ToString();
            txt_beneficiary.Text = dr["BENEFICIARY_NAME"].ToString();
            combo_relation.Text = dr["RELATION_WITH_BENEFICIARY"].ToString();
            txt_remarks.Text = dr["REMARKS"].ToString();
            cmbStatus.Text = dr["EMP_STATUS"].ToString();
            dtpJoinDate.Text = dr["DATE_OF_JOINING"].ToString();
            cmbDesig.Text = dr["DESIGNATION_NAME"].ToString();
            txt_designation.Tag = dr["DESIGNATION_ID"].ToString();
            cmbGrd.Text = dr["EMP_GRADE"].ToString();
            cmbGrd.Tag = dr["GRD_ID"].ToString();
            cmbPos.Text = dr["POS_NAME"].ToString();
            cmbPos.Tag = dr["POS_ID"].ToString();
            CBox_Unit.Text = dr["UNIT_NAME"].ToString();
            txt_unit.Tag = dr["UNIT_ID"].ToString();
            CBox_Category.Text = dr["EMP_CATEGORY_NAME"].ToString();
            txt_category.Tag = dr["EMP_CATEGORY_ID"].ToString();
            CBox_Department.Text = dr["DEPARTMENT_NAME"].ToString();
            txt_department.Tag = dr["DEPARTMENT_ID"].ToString();
            CBox_Section.Text = dr["SECTION_NAME"].ToString();
            txt_section.Tag = dr["SECTION_ID"].ToString();
            CBox_Group.Text = dr["LINE_NAME"].ToString();
            txt_user_id.Tag = dr["LINE_ID"].ToString();
            CBox_WorkingTime.Text = dr["SHIFT_NAME"].ToString();
            txt_working_time.Tag = dr["SHIFT_ID"].ToString();
            CBox_SalaryRule.Text = dr["RULE_NAME"].ToString();
            txt_salary_rule.Tag = dr["RULE_ID"].ToString();
            txt_gross.Text = dr["GROSS"].ToString();
            txt_basic.Text = dr["BASIC"].ToString();
            combo_weekend.Text = dr["WEEKEND"].ToString();
            txtProximityNo.Text = dr["PROXIMITY_NO"].ToString();
            txt_cell_no.Text = dr["CONTACT_NO"].ToString();
            txtLicenseNo.Text = dr["LICENSE_NO"].ToString();
            txt_email.Text = dr["E_MAIL"].ToString();
            txtEmployement.Text = dr["EMPLOYEMENT"].ToString();
            txtNomineeCellNo.Text = dr["NOMINEE_CELL_NO"].ToString();
            txtAccountNo.Text = dr["ACCOUNT_NO"].ToString();
            string strAccType = dr["BANK_ACCOUNT_HOLDER"].ToString();
            string family = txtQtr.Text.Trim() == "" ? "0" : txtQtr.Text.Trim();
            if (strAccType == "Y") RB_Bank.Checked = true;
            else if (strAccType == "M") RB_Mobile.Checked = true;
            else if (strAccType == "N") RB_None.Checked = true;
            CB_ot_holder.Checked = dr["OVER_TIME"].ToString() == "Y" ? true : false;
            CB_tax.Checked = dr["TAX_HOLDER"].ToString() == "Y" ? true : false;
            CB_quater.Checked = dr["LUNCH"].ToString() == "Y" ? true : false;
            txtQtr.Text = dr["QTR_ALW"].ToString();
            CB_contractual.Checked = dr["CONTRACTUAL"].ToString() == "Y" ? true : false;
            chkEL.Checked = dr["EL_HOLDER"].ToString() == "Y" ? true : false;
            cmbIncrSeg.Text = dr["INCR_SEGMENT"].ToString();
            cmbEL.Text = dr["EL_SEGMENT"].ToString();
            //================= Employee Photo ====================
            
            string strSql = "SELECT PHOTO,EMP_PHOTO FROM EMP_PERSONAL WHERE EMP_ID='" + txtEmpCode.Tag + "'";
            DataSet Ds = db.GetDataSet(strSql);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (Ds.Tables[0].Rows[0]["EMP_PHOTO"] != DBNull.Value)
                {
                    empImage = (byte[])Ds.Tables[0].Rows[0]["EMP_PHOTO"];
                    txtPhotoPath.Text = Ds.Tables[0].Rows[0]["PHOTO"].ToString();
                    pBoxPhoto.Image = Image.FromStream(CDisplay.GetMemoryStream(empImage));
                }
                else getDefaultImage();
            }
            else getDefaultImage();
            ///================= Employee Signature ====================
            strSql = "SELECT SIGNATURE FROM EMP_SIGNATURE WHERE EMP_ID='" + txtEmpCode.Tag + "'";
            Ds = db.GetDataSet(strSql);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (Ds.Tables[0].Rows[0][0] != DBNull.Value)
                {
                    empSign = (byte[])Ds.Tables[0].Rows[0]["SIGNATURE"];
                    pBoxEmpSignature.Image = Image.FromStream(CDisplay.GetMemoryStream(empSign));
                }
                else getDefaultSignature();
            }
            else getDefaultSignature();
            //====================== Length of service calculation ======================
            grLos.Visible = true;
            lbLos.Parent = grLos;
            lbLos.Text = GetServicePeriod();
            //====================== Leave Balance calculation ======================
            int[] CSE = this.GetLeaveBalance(" AND E_O.EMP_ID='" + txtEmpCode.Tag.ToString() + "'");
            lbLv.Text = "CL : " + CSE[0] + " SL : " + CSE[1] + (CSE[2] > 0 ? " EL :" + CSE[2] : "");

            chkResign.Checked = dr["RESIGN_GIVEN"].ToString() == "Y" ? true : false;
            if (dr["CLOSE_DATE"].ToString() != null && dr["CLOSE_DATE"].ToString() != "")
            {
                dtpCloseDate.Text = dr["CLOSE_DATE"].ToString();
                lbLastDay.Visible = true;
                grLv.Visible = false;
                lbLastDay.Text = "last W.Day : " + dtpCloseDate.Value.ToString("dd-MMM-yyyy");
            }
            else
            {
                dtpCloseDate.Text = DateTime.Now.ToString();
                lbLastDay.Visible = false;
                grLv.Visible = true;
            } //txt_resign_date.Text = dr["CLOSE_DATE"].ToString();
            lbCountData.Text = "Current Data No: " + (CurrentData + 1).ToString();
            btnSave.Text = "Update";
            FormControlMode(1);
            txtEmpCode.Focus();
        }
        private void lblLastUpdateCode_Click(object sender, EventArgs e)
        {
            getEmpInfoDisplay(" AND E_O.EMP_CODE = '" + lbLastCode.Text.Trim() + "'");
        }
        private void txtEmpCode_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (txtEmpCode.Text.Trim().Length > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string chkQuery = "SELECT EMP_ID FROM EMP_OFFICIAL WHERE EMP_CODE = '" + txtEmpCode.Text + "'";
                    OracleDataReader dr = db.GetExecuteReader(chkQuery);
                    if (dr.Read())
                    {
                        getEmpInfoDisplay(" AND E_O.EMP_CODE = '" + txtEmpCode.Text.Trim() + "'");
                        return;
                    }
                    else
                    {
                        txtErpCode.Focus();
                        btnSave.Text = "Save";
                    }
                }//if (e.KeyCode == Keys.Enter)

                else if (e.KeyCode == Keys.F8)    // Display Details
                {
                    getEmpInfoDisplay(" AND E_O.EMP_CODE = '" + txtEmpCode.Text.Trim() + "'");
                    return;
                } // End of if (e.KeyCode == Keys.F8)    / Display Details

                else if (e.KeyCode == Keys.F9)  // Go to attendance details
                {
                    payroll_main_form mForm = ParentForm as payroll_main_form;
                    mForm.splitContainer1.Panel2.Controls.Clear();
                    Attendance_Details objAttdDetailsUC = new Attendance_Details();
                    mForm.splitContainer1.Panel2.Controls.Add(objAttdDetailsUC);
                    objAttdDetailsUC.Show();
                    objAttdDetailsUC.getExitForLastUserControlAttd = 1;
                    objAttdDetailsUC.getDisplayAttDetails(" AND A.EMP_CODE = '" + txtEmpCode.Text.Trim() + "' AND C.ATTD_DATE BETWEEN '" + DateTime.Now.Date.AddDays(-30).Date.ToString("dd-MMM-yyyy") + "' AND '" + DateTime.Now.Date.ToString("dd-MMM-yyyy") + "'");
                    objAttdDetailsUC.lastUserControlAttd = this;
                } // End of if (e.KeyCode == Keys.F9)  / Go to attendance details

                else if (e.KeyCode == Keys.F1)  // Focus on gross
                {
                    txt_gross.Focus();
                }// End of if (e.KeyCode == Keys.F9)  /Focus on gross

                else if (e.KeyCode == Keys.F2)        // Focus on Proximity
                {
                    txtProximityNo.Focus();
                }// End of if (e.KeyCode == Keys.F2)  / Focus on Proximity

                else if (e.KeyCode == Keys.F3)        // Focus on Designation   
                {
                    cmbDesig.Focus();
                }// End of if (e.KeyCode == Keys.F3)  / Focus on Designation

                else if (e.KeyCode == Keys.F4)        // Close employee
                {
                    getUpdateEmpInfoFromData();
                }// End of if (e.KeyCode == Keys.F4)  / Close employee

                else if (e.KeyCode == Keys.F5)       // Search by %......%
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.EMP_CODE LIKE '%" + txtEmpCode.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }// End of if (e.KeyCode == Keys.F5)  / Search by %......%

                else if (e.KeyCode == Keys.F6)       // Store previous code
                {
                    if (MessageBox.Show("Are you sure to delete employee (" + txtEmpCode.Text + ") ?", "Confirmation", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        frmSecurityInputBox objSecurityInputBox = new frmSecurityInputBox(ref txtPassword);
                        objSecurityInputBox.ShowDialog();
                        if (txtPassword.Text == "d123")
                        {
                            string sqlDel = "DELETE EMP_PERSONAL WHERE EMP_ID = '" + txtEmpCode.Tag + "'";
                            if (db.RunDmlQuery(sqlDel))
                            {
                                sqlDel = "DELETE EMP_OFFICIAL WHERE EMP_ID = '" + txtEmpCode.Tag + "'";
                                if (db.RunDmlQuery(sqlDel))
                                {
                                    sqlDel = sqlDel.Replace("'", string.Empty);
                                    string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + sqlDel + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                                    db.RunDmlQuery(strSql);
                                    MessageBox.Show("Deleted Employee (" + txtEmpCode.Text + ") Successfully.", "Save As...");
                                    FormControlMode(0);
                                    txtEmpCode.Focus();
                                }
                            }
                        }
                    }

                }// End of if (e.KeyCode == Keys.F6)  / Store previous code

                else if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))           // Reset
                {
                    getFieldClearFromData();
                }// End of if (e.KeyCode == Keys.F7)  / Reset
            }
            if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.Down) && txtEmpCode.Tag != null && ds.Tables[0].Rows.Count > 0)
            {
                if (CurrentData == ds.Tables[0].Rows.Count - 1) CurrentData = 0;
                else CurrentData++;
                FillFormData(ds.Tables[0].Rows[CurrentData]);
                return;
            }
            else if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Left) && txtEmpCode.Tag != null && ds.Tables[0].Rows.Count > 0)
            {
                if (CurrentData == 0) CurrentData = ds.Tables[0].Rows.Count - 1;
                else CurrentData--;
                FillFormData(ds.Tables[0].Rows[CurrentData]);
                return;
            }//End of Arrow Navigator
            else return;
        }
        private void link_lbl_emp_details_Click(object sender, EventArgs e)
        {
            payroll_main_form mForm = ParentForm as payroll_main_form;
            mForm.splitContainer1.Panel2.Controls.Clear();
            employee_status_UC objEmpStatusUC = new employee_status_UC();
            mForm.splitContainer1.Panel2.Controls.Add(objEmpStatusUC);
            objEmpStatusUC.Show();
            objEmpStatusUC.getExitForLastUserControlEmpStatus = 1;
            objEmpStatusUC.getEmpStatusDisplay(" AND A.EMP_CODE = '" + txtEmpCode.Text.Trim() + "'");
            objEmpStatusUC.lastUserControlEmpStatus = this;
        }
        private void txt_emp_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtEmpNameBang.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_O.EMP_NAME) LIKE '%" + txt_emp_name.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void txt_father_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtBangFatherName.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.FATHER_NAME) LIKE '%" + txt_father_name.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void txt_emp_mother_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtBangMotherName.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.MOTHER_NAME) LIKE '%" + txt_emp_mother.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void txt_husband_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtBangHusband.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.HUSBAND_NAME) LIKE '%" + txt_emp_name.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_husband_name_KeyUp(object sender, EventArgs e)
        private void combo_gender_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) combo_religion.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.SEX) LIKE '%" + combo_gender.Text.ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void combo_religion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) combo_marital.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (combo_religion.SelectedIndex != -1)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.RELIGION) = '" + combo_religion.Text.Trim().ToUpper() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void combo_marital_KeyUp(object sender, KeyEventArgs e)
        {
            CPresent.flag = 1;
            if (e.KeyCode == Keys.Enter) combo_blood.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (combo_marital.SelectedIndex != -1)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.MARITAL_STATUS) = '" + combo_marital.Text.Trim().ToUpper() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }// End of if (combo_marital.Text != "") 
            } // End of if (e.KeyCode == Keys.F5)
            CPresent.flag = 0;    
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void combo_blood_KeyUp(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter) dtpBirthDate.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (combo_blood.SelectedIndex != -1)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_P.BLOOD_GROUP = '" + combo_blood.Text.Trim() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }//End of Arrow Navigator
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            //dtpBirthDate.MaxDate = DateTime.Now.Date.AddYears(-18).AddDays(7).Date;
        }
        private void dtpBirthDate_KeyUp(object sender, KeyEventArgs e)
        {
            TimeSpan ts = DateTime.Parse(DateTime.Now.ToString()).Subtract(DateTime.Parse(dtpBirthDate.Text));
            int age = (ts.Days + 1) / 365; // int division will trancate the fractional part and will take the YEAR part only --- //ts.Days gives 1 day less
            txt_age.Text = age.ToString();
            if (e.KeyCode == Keys.Enter) txt_vill_present.Focus();
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void txt_vill_present_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_po_present.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.PRESENT_VILL) LIKE '%" + txt_vill_present.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_vill_present_KeyUp(object sender, EventArgs e)
        private void txt_po_present_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_ps_present.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.PRESENT_HOUSE) LIKE '%" + txt_po_present.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_po_present_KeyUp(object sender, EventArgs e)
        private void txt_ps_present_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cmbPresDist.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.PRESENT_PS) LIKE '%" + txt_ps_present.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_ps_present_KeyUp(object sender, EventArgs e)
        private void txt_vill_parmanent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_po_parmanent.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.PARMANENT_HOUSE) LIKE '%" + txt_vill_parmanent.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_vill_parmanent_KeyUp(object sender, EventArgs e)

        private void txt_po_parmanent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_ps_parmanent.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.PARMANENT_VILL) LIKE '%" + txt_po_parmanent.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_po_parmanent_KeyUp(object sender, EventArgs e)

        private void txt_ps_parmanent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cmbPerDist.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.PARMANENT_PS) LIKE '%" + txt_ps_parmanent.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_ps_parmanent_KeyUp(object sender, EventArgs e)

        private void txt_national_id_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cmbEducation.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_P.NATIONAL_ID) LIKE '%" + txt_national_id.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)
        } //End of private void txt_national_id_KeyUp(object sender, EventArgs e)

        private void txt_beneficiary_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) combo_relation.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (txt_beneficiary.Text.Trim().Length > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_O.BENEFICIARY_NAME) LIKE '%" + txt_beneficiary.Text.Trim().ToUpper() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5)
        } //End of private void txt_beneficiary_KeyUp(object sender, EventArgs e)

        private void combo_relation_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtBang_nomini.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (combo_relation.SelectedIndex != -1)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_O.RELATION_WITH_BENEFICIARY) = '" + combo_relation.Text.Trim().ToUpper() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5) 
        } //End of private void combo_relation_KeyUp(object sender, EventArgs e)
        private void getMaternityLeave(int intEID)
        {
            
            string strSql="", strQuery = "";
            DateTime dtToDate = dtpCloseDate.Value.AddDays(111).Date;
            strQuery = "DELETE ATTENDANCE_DETAILS WHERE EMP_ID = '" + intEID + "' AND ATTD_DATE BETWEEN '" + dtpCloseDate.Text + "' AND '" + dtToDate.ToString("dd-MMM-yyyy") + "'";
            if (db.RunDmlQuery(strQuery))
            {
                for (int intMLDay = 0; intMLDay < 112; intMLDay++)
                {
                    strSql = @"INSERT INTO ATTENDANCE_DETAILS(EMP_ID,ATTD_DATE,ATTD_REMARKS,STATUS,STATUS2,OVER_TIME,NIGHT_STATUS,ATTD_LOCKED,SHIFT_ID,USER_ID) 
                                VALUES('" + intEID + "','" + dtpCloseDate.Value.AddDays(intMLDay).Date.ToString("dd-MMM-yyyy") + "','Maternity Leave','L','L','0','N','Y','" + CBox_WorkingTime.Tag + "','" + ConfigurationManager.AppSettings["UserID"] + @"')";
                    if (!db.RunDmlQuery(strSql)) MessageBox.Show(strSql);
                }
            }
        }
        private void dtpCloseDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtNomineeCellNo.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                getEmpInfoDisplay(" AND CLOSE_DATE = '" + dtpCloseDate.Value.ToString("dd-MMM-yyyy") + "' ORDER BY E_O.EMP_CODE ASC");
                return;
            }
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void txtNomineeCellNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cmbStatus.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (combo_relation.SelectedIndex != -1)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_P.NOMINEE_CELL_NO = '" + txtNomineeCellNo.Text.Trim() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5) 
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStatusValidation();
        }
        private void cmbStatus_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) dtpJoinDate.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (cmbStatus.SelectedIndex != -1)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5)
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)

        private void dtpJoinDate_KeyUp(object sender, KeyEventArgs e)
        {
            CPresent.flag = 1;
            if (e.KeyCode == Keys.F5)     // Month wise Employee Searching
            {
                string emp_joining_dateTimePick = dtpJoinDate.Value.ToString("MM");
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND (EXTRACT (MONTH FROM(E_O.DATE_OF_JOINING))) = '" + emp_joining_dateTimePick + "' ORDER BY E_O.EMP_CODE ASC");
                return;
            }
            else if (e.KeyCode == Keys.F8)
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.DATE_OF_JOINING ='" + dtpJoinDate.Text + "' ORDER BY E_O.EMP_CODE ASC");
                return;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                cmbPos.Focus();
                cmbIncrSeg.Text = dtpJoinDate.Value.ToString("MMMM");
                if (dtpJoinDate.Value.Day > 15) cmbIncrSeg.Text = dtpJoinDate.Value.AddMonths(1).ToString("MMMM");
            }
            CPresent.flag = 0;
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private string getSubQuery()
        {
            string strGetSubSql = "";
            if (CBox_Unit.Text.Trim().Length > 0) strGetSubSql += " AND E_O.UNIT_ID='" + CBox_Unit.Tag + "'";
            if (CBox_Group.Text.Trim().Length > 0) strGetSubSql += " AND E_O.LINE_ID='" + CBox_Group.Tag + "'";
            if (CBox_Section.Text.Trim().Length > 0) strGetSubSql += " AND E_O.SECTION_ID='" + CBox_Section.Tag + "'";
            if (CBox_SalaryRule.Text.Trim().Length > 0) strGetSubSql += " AND E_O.RULE_ID='" + CBox_SalaryRule.Tag + "'";
            if (CBox_WorkingTime.Text.Trim().Length > 0) strGetSubSql += " AND E_O.SHIFT_ID='" + CBox_WorkingTime.Tag + "'";
            if (CBox_Category.Text.Trim().Length > 0) strGetSubSql += " AND E_O.EMP_CATEGORY_ID='" + CBox_Category.Tag + "'";
            if (CBox_Department.Text.Trim().Length > 0) strGetSubSql += " AND E_O.DEPARTMENT_ID='" + CBox_Department.Tag + "'";
            if (cmbDesig.Text.Trim().Length > 0) strGetSubSql += " AND E_O.DESIGNATION_ID='" + cmbDesig.Tag + "'";
            return strGetSubSql;
        }
        private void CBox_Designation_KeyUp(object sender, KeyEventArgs e)
        {
            CPresent.flag = 1;
            if (cmbDesig.SelectedIndex != -1)
            {
                if (e.KeyCode == Keys.F5)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "'" + getSubQuery() + " ORDER BY E_O.EMP_CODE ASC");
                    return;
                }// End of if (e.KeyCode == Keys.F5)
                else if (e.KeyCode == Keys.F8)
                {
                    //payroll_main_form mForm = ParentForm as payroll_main_form;
                    //mForm.splitContainer1.Panel2.Controls.Clear();
                    //designation_UC obj_designation_uc = new designation_UC();
                    //obj_designation_uc.desig_name_emp_info = cmbDesig.Text;
                    //mForm.splitContainer1.Panel2.Controls.Add(obj_designation_uc);
                    //obj_designation_uc.Show();
                    //obj_designation_uc.desig_emp_Show();
                    ////obj_designation_uc.getExitForLastUserControlDesig = 1;
                    //obj_designation_uc.lastUserControlDesig = this;
                }// End of if (e.KeyCode == Keys.F8)  / Goto Designation Entry form
                else if (e.KeyCode == Keys.Enter) cmbGrd.Focus();
            } // End of if (CBox_Designation.Text != "")
            CPresent.flag = 0;
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)

        
        private void CBox_Unit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CBox_Category.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (CBox_Unit.Tag != null)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "'" + getSubQuery() + " ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5) 
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)

        private void CBox_Category_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CBox_Department.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (CBox_Category.Tag != null)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "'" + getSubQuery() + " ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5) 
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)

        private void CBox_Department_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CBox_Section.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (CBox_Department.Tag != null)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "'" + getSubQuery() + " ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5) 
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)

        private void CBox_Section_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CBox_Group.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (CBox_Section.Tag != null)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "'" + getSubQuery() + " ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5) 
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)

        private void CBox_Group_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) CBox_WorkingTime.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (CBox_Group.Tag != null)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "'" + getSubQuery() + " ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5) 
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)

        private void CBox_WorkingTime_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) CBox_SalaryRule.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (CBox_WorkingTime.Tag != null)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "'" + getSubQuery() + " ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5) 
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void CBox_SalaryRule_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_gross.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (CBox_SalaryRule.Tag != null)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "'" + getSubQuery() + " ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5) 
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void txt_gross_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_gross.Text.Trim().Length > 0)
            {
                if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F5)
                {
                    if (e.KeyCode == Keys.F1)     // Searching Employee by gross(Ex. <10000)
                    {
                        getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.GROSS < '" + txt_gross.Text.Trim() + @"' ORDER BY GROSS, E_O.EMP_CODE");
                        return;
                    }
                    else if (e.KeyCode == Keys.F2)     // Searching Employee by gross(Ex. <10000)
                    {
                        getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.GROSS > '" + txt_gross.Text.Trim() + @"' ORDER BY GROSS, E_O.EMP_CODE");
                        return;
                    }
                    else if (e.KeyCode == Keys.F5)     // Searching Employee by gross(Ex. =10000)
                    {
                        getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.GROSS = '" + txt_gross.Text.Trim() + @"' ORDER BY GROSS, E_O.EMP_CODE");
                        return;
                    }
                }// End of if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F5)  / Search by Gross
                else if (e.KeyCode == Keys.F12)
                {
                    if (txtEmpCode.Text.Trim().Length > 0)
                    {
                        
                        string strQuery = "UPDATE EMP_OFFICIAL SET GROSS='" + txt_gross.Text.Trim() + "',USER_ID=" + ConfigurationManager.AppSettings["UserID"] + ",EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM') WHERE EMP_CODE = '" + txtEmpCode.Text.Trim() + "'";
                        if (db.RunDmlQuery(strQuery))
                        {
                            strQuery = strQuery.Replace("'", string.Empty);
                            string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strQuery + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                            db.RunDmlQuery(strSql);
                            MessageBox.Show("Updated Successfully", "Save As", MessageBoxButtons.OK);
                            FormControlMode(0);
                        }
                        else
                        {
                            MessageBox.Show("Failed");
                            FormControlMode(1);
                            txt_gross.Focus();
                        }

                    } // End of else if (e.KeyCode == Keys.F12)  --Update Gross
                }

            } // End of if (txt_grade.Text != "")
            
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_gross.Text.Trim().Length > 0)
                {
                    txt_basic.Text = getBasicSalary().ToString();
                    combo_weekend.Focus();
                    return;
                }
                else combo_weekend.Focus();
            } // End of else if (e.KeyCode == Keys.Enter)
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)

        private void combo_weekend_KeyUp(object sender, KeyEventArgs e)
        {
            CPresent.flag = 1;
            if (e.KeyCode == Keys.F5)
            {
                if (combo_weekend.SelectedIndex != -1)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.WEEKEND = '" + combo_weekend.Text.Trim() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }//End of Arrow Navigator
            else if (e.KeyCode == Keys.Enter)
            {
                txtProximityNo.Focus();
            }
            CPresent.flag = 0;
        }//End of private void combo_weekend_KeyUp(object sender, EventArgs e)
        
        private void txtProximityNo_KeyUp(object sender, KeyEventArgs e)
        {
            CPresent.flag = 1;
            if (e.KeyCode == Keys.F5)     // Searching Employee by gross
            {
                if (txtProximityNo.Text.Trim().Length > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.PROXIMITY_NO = '" + txtProximityNo.Text.Trim() + "' ORDER BY E_O.EMP_CODE");
                    return;
                } // End of if (txt_card_no.Text != "")
            }// End of if (e.KeyCode == Keys.F5)  / Search by PROXIMITY_NO
            else if (e.KeyCode == Keys.F12)
            {
                if (txtProximityNo.Text.Trim().Length > 0)
                {
                    
                    string strQuery = "UPDATE EMP_OFFICIAL SET PROXIMITY_NO='" + txtProximityNo.Text.Trim() + "',USER_ID='" + ConfigurationManager.AppSettings["UserID"] + "',EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM') WHERE EMP_CODE= '" + txtEmpCode.Text.Trim() + "'";
                    if (db.RunDmlQuery(strQuery))
                    {
                        strQuery = strQuery.Replace("'", string.Empty);
                        string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strQuery + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                        db.RunDmlQuery(strSql);
                        MessageBox.Show("Updated Successfully", "Save As", MessageBoxButtons.OK);
                        FormControlMode(0);
                    }                    
                    else
                    {
                        MessageBox.Show("Failed");
                        FormControlMode(1);
                        txtProximityNo.Focus();
                    }
                } // End of if (txt_card_no.Text != "")
            }// End of if (e.KeyCode == Keys.F12)  / Update Proximity
            else if (e.KeyCode == Keys.Enter)  txt_cell_no.Focus();
        } //End of private void txt_card_no_KeyUp(object sender, EventArgs e)

        private void txt_cell_no_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (txt_cell_no.Text.Trim().Length > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_P.CONTACT_NO LIKE '%" + txt_cell_no.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }//End of Arrow Navigator
            else if (e.KeyCode == Keys.Enter)
            txt_email.Focus();
        } //End of private void txt_cell_no_KeyUp(object sender, EventArgs e)

        private void txt_email_KeyUp(object sender, KeyEventArgs e)
        {
            CPresent.flag = 1;
            if (e.KeyCode == Keys.F5)
            {
                if (txt_email.Text.Trim().Length > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_P.E_MAIL LIKE '%" + txt_email.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }//End of Arrow Navigator
            else if (e.KeyCode == Keys.Enter)
            {
                txtAccountNo.Focus();
            }
            CPresent.flag = 0; 
        } //End of private void txt_email_KeyUp(object sender, EventArgs e)
        private void txtAccountNo_KeyUp(object sender, KeyEventArgs e)
        {
            string strAccNo="";
            DBClass db=new DBClass();
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAccountNo.Text.Trim().Length > 0) 
                    RB_Bank.Focus();
                else 
                    RB_None.Focus();
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (txtAccountNo.Text.Trim().Length > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.ACCOUNT_NO LIKE '%" + txtAccountNo.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (txtAccountNo.Text.Trim().Length > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.MOBILE_BANK_ACC_NO LIKE '%" + txtAccountNo.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
            else if (e.KeyCode == Keys.F11)
            {
                if (RB_Bank.Checked) { strAccNo = " BANK_ACCOUNT_HOLDER='Y', ACCOUNT_NO='" + txtAccountNo.Text.Trim() + "'"; }
                else if (RB_Mobile.Checked) { strAccNo = " BANK_ACCOUNT_HOLDER='M', MOBILE_BANK_ACC_NO='" + txtAccountNo.Text.Trim() + "'"; }
                string strQuery = "UPDATE EMP_OFFICIAL SET " + strAccNo + ",USER_ID='" + ConfigurationManager.AppSettings["UserID"] + "',EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM') WHERE EMP_CODE='" + txtEmpCode.Text.Trim() + "'";
                if (db.RunDmlQuery(strQuery))
                {
                    strQuery = strQuery.Replace("'", string.Empty);
                    string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strQuery + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                    db.RunDmlQuery(strSql);
                    MessageBox.Show("Updated Successfully", "Save As", MessageBoxButtons.OK);
                    FormControlMode(0);
                }
                else
                {
                    MessageBox.Show("Failed");
                    FormControlMode(1);
                    txtAccountNo.Focus();
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (RB_Bank.Checked) { strAccNo = "ACCOUNT_NO='" + txtAccountNo.Text.Trim() + "'"; }
                else if (RB_Mobile.Checked) { strAccNo = "MOBILE_BANK_ACC_NO='" + txtAccountNo.Text.Trim() + "'"; }
                string strQuery = "UPDATE EMP_OFFICIAL SET " + strAccNo + ",USER_ID='" + ConfigurationManager.AppSettings["UserID"] + "',EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM') WHERE EMP_CODE='" + txtEmpCode.Text.Trim() + "'";
                if (db.RunDmlQuery(strQuery))
                {
                    strQuery = strQuery.Replace("'", string.Empty);
                    string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strQuery + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                    db.RunDmlQuery(strSql);
                    MessageBox.Show("Updated Successfully", "Save As", MessageBoxButtons.OK);
                    FormControlMode(0);
                }
                else
                {
                    MessageBox.Show("Failed");
                    FormControlMode(1);
                    txtAccountNo.Focus();
                }
            }
        } //End of private void txt_account_no_KeyUp(object sender, EventArgs e)
        private void RB_Bank_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtEmployement.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (RB_Bank.Checked)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.BANK_ACCOUNT_HOLDER = 'Y' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (RB_Bank.Checked)
                {
                    
                    string strQuery = "UPDATE EMP_OFFICIAL SET BANK_ACCOUNT_HOLDER='Y',USER_ID='" + ConfigurationManager.AppSettings["UserID"] + "',EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM') WHERE EMP_CODE='" + txtEmpCode.Text.Trim() + "'";
                    if (db.RunDmlQuery(strQuery))
                    {
                        strQuery = strQuery.Replace("'", string.Empty);
                        string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strQuery + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                        db.RunDmlQuery(strSql);
                        MessageBox.Show("Updated Successfully", "Save As", MessageBoxButtons.OK);
                        FormControlMode(0);
                    }                
                }
                else
                {
                    MessageBox.Show("Failed");
                    FormControlMode(1);
                }
            }
        } //End of private void RB_Bank_KeyUp(object sender, EventArgs e)
        private void RB_Mobile_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtEmployement.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (RB_Mobile.Checked)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.BANK_ACCOUNT_HOLDER = 'M' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (RB_Mobile.Checked)
                {
                    
                    string strQuery = "UPDATE EMP_OFFICIAL SET BANK_ACCOUNT_HOLDER='M',USER_ID='" + ConfigurationManager.AppSettings["UserID"] + "',EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM') WHERE EMP_CODE='" + txtEmpCode.Text.Trim() + "'";
                    if (db.RunDmlQuery(strQuery))
                    {
                        strQuery = strQuery.Replace("'", string.Empty);
                        string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strQuery + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                        db.RunDmlQuery(strSql);
                        MessageBox.Show("Updated Successfully", "Save As", MessageBoxButtons.OK);
                        FormControlMode(0);
                    }
                }
                else
                {
                    MessageBox.Show("Failed");
                    FormControlMode(1);
                }
            }
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void RB_None_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtEmployement.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (RB_None.Checked)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.BANK_ACCOUNT_HOLDER = 'N' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (RB_None.Checked)
                {
                    
                    string strQuery = "UPDATE EMP_OFFICIAL SET BANK_ACCOUNT_HOLDER='N',USER_ID='" + ConfigurationManager.AppSettings["UserID"] + "',EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM') WHERE EMP_CODE='" + txtEmpCode.Text.Trim() + "'";
                    if (db.RunDmlQuery(strQuery))
                    {
                        strQuery = strQuery.Replace("'", string.Empty);
                        string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strQuery + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                        db.RunDmlQuery(strSql);
                        MessageBox.Show("Updated Successfully", "Save As", MessageBoxButtons.OK);
                        FormControlMode(0);
                    }
                }
                else
                {
                    MessageBox.Show("Failed");
                    FormControlMode(1);
                }
            }
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void txtEmployement_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) CB_ot_holder.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (txtEmployement.Text !="")
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_P.EMPLOYEMENT = '" + txtEmployement.Text.Trim() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void CB_quater_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_remarks.Focus();
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void CB_tax_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_remarks.Focus();
        }//End of private void txt_gross_KeyUp(object sender, EventArgs e)
        private void CB_ot_holder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cmbEL.Focus();
        } //End of private void CB_ot_holder_KeyUp(object sender, EventArgs e)
        private void CB_contractual_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_remarks.Focus();
        } //End of private void CB_contractual_KeyUp(object sender, EventArgs e)
        private void txt_remarks_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_beneficiary.Focus();
        } //End of private void txt_remarks_KeyUp(object sender, EventArgs e)
        private void btnExitLastUC_Click(object sender, EventArgs e)
        {
            payroll_main_form mForm = ParentForm as payroll_main_form;
            mForm.splitContainer1.Panel2.Controls.Clear();
            if (getExitForLastUserControlEmpInfo == 1)
            {
                mForm.splitContainer1.Panel2.Controls.Add(lastUserControlEmpInfo);
                lastUserControlEmpInfo.Show();
            }
            else
            {
                ucDashboard objDashBoard = new ucDashboard();
                mForm.splitContainer1.Panel2.Controls.Add(objDashBoard);
                objDashBoard.Show();
            }
        }
        
        #region =======================================[Update Image & Signature]=======================================
        private void getUploadPhoto()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) txtPhotoPath.Text = folderBrowserDialog1.SelectedPath;
            if (MessageBox.Show("Are You Sure to Upload Picture from Folder " + txtPhotoPath.Text + "\\", " Upload Picture from Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] files = Directory.GetFiles(txtPhotoPath.Text + "\\", "*.jpg", SearchOption.AllDirectories);
                string[] array = files;
                for (int i = 0; i < array.Length; i++)
                {
                    string strText = array[i];
                    
                    string strEmpCode = strText.Substring(strText.LastIndexOf('\\') + 1);
                    try
                    {
                        strEmpCode = strEmpCode.Substring(0, strEmpCode.IndexOf('.'));
                        FileStream fileStream = new FileStream(strText, FileMode.Open, FileAccess.Read);
                        byte[] array2 = new byte[fileStream.Length];
                        fileStream.Read(array2, 0, System.Convert.ToInt32(fileStream.Length));
                        fileStream.Close();
                        OracleConnection oCon = new OracleConnection(db.strConn);
                        oCon.Open();
                        string strQuery = "UPDATE EMP_PERSONAL SET PHOTO='" + txtPhotoPath.Text + "\\', EMP_PHOTO= :BlobParameter WHERE EMP_ID = (SELECT EMP_ID FROM EMP_OFFICIAL WHERE EMP_CODE='" + strEmpCode + "')";
                        OracleParameter oracleParameter = new OracleParameter();
                        oracleParameter.OracleType = OracleType.Blob;
                        oracleParameter.ParameterName = "BlobParameter";
                        oracleParameter.Value = array2;
                        OracleCommand oCommand = new OracleCommand(strQuery, oCon);
                        oCommand.Parameters.Add(oracleParameter);
                        oCommand.ExecuteNonQuery();
                        oCommand.Dispose();
                        oCon.Close();
                        oCon.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //MessageBox.Show("Action obtained", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Action perform Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void tsmiSetDefaultImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdPhoto = new OpenFileDialog();
            ofdPhoto.Filter = "Jpeg (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
            ofdPhoto.Title = "Select Item Photograph";
            ofdPhoto.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();

            if ((ofdPhoto.ShowDialog()) == DialogResult.OK)
            {
                pBoxPhoto.Image = null;
                FileStream fileStream = new FileStream(ofdPhoto.FileName, FileMode.Open, FileAccess.Read);
                empImage = new byte[fileStream.Length];
                fileStream.Read(empImage, 0, Convert.ToInt32(fileStream.Length));
                fileStream.Close();

                byte[] baNewImageTemp = CDisplay.ResizeImageFile(empImage, pBoxPhoto.Size, ImageFormat.Jpeg);
                pBoxPhoto.Image = Image.FromStream(CDisplay.GetMemoryStream(baNewImageTemp));
                
                empImage = baNewImageTemp;
                string strSql = "SELECT DEFAULT_IMAGE FROM FEATURE WHERE ATTRIBUTE='DEFAULT_IMAGE'";
                DataSet ds = db.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    OracleConnection connected = new OracleConnection(db.strConn);
                    connected.Open();
                    strSql = "UPDATE FEATURE SET PARAMETER='" + ofdPhoto.FileName + "', DEFAULT_IMAGE=  :BlobParameter WHERE ATTRIBUTE='DEFAULT_IMAGE'";
                    OracleParameter oracleParameter = new OracleParameter();
                    oracleParameter.OracleType = OracleType.Blob;
                    oracleParameter.ParameterName = "BlobParameter";
                    oracleParameter.Value = empImage;
                    OracleCommand oracleCommand = new OracleCommand(strSql, connected);
                    oracleCommand.Parameters.Add(oracleParameter);
                    oracleCommand.ExecuteNonQuery();
                    oracleCommand.Dispose();
                    connected.Close();
                    connected.Dispose();
                    MessageBox.Show("Successfully Default Image (" + ofdPhoto.FileName + ") Uploaded.", "Save As...");
                }
                else
                {
                    OracleConnection connected = new OracleConnection(db.strConn);
                    connected.Open();
                    strSql = "INSERT INTO FEATURE (FEATURE_ID, DEFAULT_IMAGE, PARAMETER, ATTRIBUTE) VALUES ('1', :BlobParameter, '" + ofdPhoto.FileName + "', 'DEFAULT_IMAGE') ";
                    OracleParameter oracleParameter = new OracleParameter();
                    oracleParameter.OracleType = OracleType.Blob;
                    oracleParameter.ParameterName = "BlobParameter";
                    oracleParameter.Value = empImage;
                    OracleCommand oracleCommand = new OracleCommand(strSql, connected);
                    oracleCommand.Parameters.Add(oracleParameter);
                    oracleCommand.ExecuteNonQuery();
                    oracleCommand.Dispose();
                    connected.Close();
                    connected.Dispose();
                    MessageBox.Show("Successfully Default Image (" + ofdPhoto.FileName + ") Uploaded.", "Save");
                }
            }
            FormControlMode(0);
            txtEmpCode.Focus();
        }
        //private ImageCodecInfo FindEncoder()
        //{
        //    ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
        //    ImageCodecInfo[] array = imageEncoders;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        ImageCodecInfo imageCodecInfo = array[i];
        //        if (imageCodecInfo.FormatID.Equals(this.guid))
        //        {
        //            return imageCodecInfo;
        //        }
        //    }
        //    return null;
        //}
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtPhotoPath.Text = saveFileDialog1.FileName;
        }
        private void tsmiSavePhoto_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "\"BMP (*.bmp)|*.bmp|All files (*.*)|*.*\";";
            saveFileDialog1.FileOk += new CancelEventHandler(saveFileDialog1_FileOk);
            if (txtEmpCode.Tag != null && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(pBoxPhoto.Width, pBoxPhoto.Height);
                pBoxPhoto.DrawToBitmap(bitmap, pBoxPhoto.ClientRectangle);
                bitmap.Save(txtPhotoPath.Text, ImageFormat.Bmp);
            }
        }
        //private void Save(string fileName, ImageFormat format)
        //{
        //    if (format == null)
        //    {
        //        throw new ArgumentNullException("format");
        //    }
        //    ImageCodecInfo imageCodecInfo = FindEncoder();
        //    if (imageCodecInfo == null)
        //    {
        //        imageCodecInfo = FindEncoder();
        //    }
        //    Save(fileName, imageCodecInfo, null);
        //}
        
       
        private void cmdBtnUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdImage=new OpenFileDialog();
            ofdImage.Filter = "Jpeg (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
            ofdImage.Title = "Select Item Photograph";
            ofdImage.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();

            if ((ofdImage.ShowDialog()) == DialogResult.OK)
            {
                pBoxPhoto.Image = null;
                txtPhotoPath.Text = ofdImage.FileName;
                FileStream fileStream = new FileStream(ofdImage.FileName, FileMode.Open, FileAccess.Read);
                empImage = new byte[fileStream.Length];
                fileStream.Read(empImage, 0, System.Convert.ToInt32(fileStream.Length));
                fileStream.Close();

                byte[] baNewImageTemp = CDisplay.ResizeImageFile(empImage, new Size(pBoxEmpSignature.Size.Width + 100, pBoxEmpSignature.Size.Height + 100), ImageFormat.Jpeg);
                pBoxPhoto.Image = Image.FromStream(CDisplay.GetMemoryStream(baNewImageTemp));
                if (txtEmpCode.Tag !=null  && txtEmpCode.Tag != "")
                {
                    
                    OracleConnection connected = new OracleConnection(db.strConn);
                    connected.Open();
                    string commandText = "UPDATE EMP_PERSONAL SET PHOTO='" + txtPhotoPath.Text + "',EMP_PHOTO=  :BlobParameter WHERE EMP_ID ='" + txtEmpCode.Tag + "'";
                    OracleParameter oracleParameter = new OracleParameter();
                    oracleParameter.OracleType = OracleType.Blob;
                    oracleParameter.ParameterName = "BlobParameter";
                    oracleParameter.Value = empImage;
                    OracleCommand oracleCommand = new OracleCommand(commandText, connected);
                    oracleCommand.Parameters.Add(oracleParameter);
                    oracleCommand.ExecuteNonQuery();
                    oracleCommand.Dispose();
                    connected.Close();
                    connected.Dispose();
                }
                FormControlMode(0); 
                txtEmpCode.Focus();
            }                
        }
        private void tsmiUploadPicture_Click(object sender, EventArgs e)
        {
            cmdBtnUploadPhoto_Click(sender, e);
        }
        private void tsmiUploadPhotoByFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select the directory that you want to use as the default.";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            openFileDialog1.FileName = null;
            getUploadPhoto();
        }
        private void getUploadSigneture()
        {
            string strSignPath = "";
            
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) strSignPath = folderBrowserDialog1.SelectedPath;
            if (MessageBox.Show("Are You Sure to Upload Signeture from Folder " + strSignPath, " Upload Picture from Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] files = System.IO.Directory.GetFiles(strSignPath + "\\", "*.jpg", System.IO.SearchOption.AllDirectories);
                string[] array = files;
                for (int i = 0; i < array.Length; i++)
                {
                    string strText = array[i];
                    string strEmpCode = strText.Substring(strText.LastIndexOf('\\') + 1);
                    try
                    {
                        strEmpCode = strEmpCode.Substring(0, strEmpCode.IndexOf('.'));
                        string strSql = "SELECT EMP_ID FROM EMP_OFFICIAL WHERE EMP_CODE='" + strEmpCode + "'";
                        OracleDataReader dr = db.GetExecuteReader(strSql);
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                string EMP_ID = dr["EMP_ID"].ToString();
                                FileStream fileStream = new FileStream(strText, FileMode.Open, FileAccess.Read);
                                byte[] array2 = new byte[fileStream.Length];
                                fileStream.Read(array2, 0, System.Convert.ToInt32(fileStream.Length));
                                fileStream.Close();
                                OracleConnection oCon = new OracleConnection(db.strConn);
                                oCon.Open();
                                strSql = "INSERT INTO EMP_SIGNATURE (EMP_ID, SIGNATURE, CREATE_BY, CREATE_DATE) VALUES ('" + EMP_ID + "', :BlobParameter, '" + ConfigurationManager.AppSettings["UserName"] + "',SYSDATE)";
                                OracleParameter oParameter = new OracleParameter();
                                oParameter.OracleType = OracleType.BFile;
                                oParameter.ParameterName = "BlobParameter";
                                oParameter.Value = array2;
                                OracleCommand oracleCommand = new OracleCommand(strSql, oCon);
                                oracleCommand.Parameters.Add(oParameter);
                                oracleCommand.ExecuteNonQuery();
                                oracleCommand.Dispose();
                                oCon.Close();
                                oCon.Dispose();
                            }
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                MessageBox.Show("Action perform Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnUploadSignature_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSign = new OpenFileDialog();
            ofdSign.Filter = "Jpeg (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
            ofdSign.Title = "Select Item Photograph";
            ofdSign.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();

            if ((ofdSign.ShowDialog()) == DialogResult.OK)
            {
                pBoxEmpSignature.Image = null;
                FileStream fileStream = new FileStream(ofdSign.FileName, FileMode.Open, FileAccess.Read);
                empSign = new byte[fileStream.Length];
                fileStream.Read(empSign, 0, Convert.ToInt32(fileStream.Length));
                fileStream.Close();

                byte[] baNewImageTemp = CDisplay.ResizeImageFile(empSign, pBoxEmpSignature.Size, ImageFormat.Jpeg);
                pBoxEmpSignature.Image = Image.FromStream(CDisplay.GetMemoryStream(baNewImageTemp));

                if (txtEmpCode.Tag != null && txtEmpCode.Tag != "")
                {
                    
                    empImage = baNewImageTemp;
                    string Sql = "SELECT * FROM EMP_SIGNATURE WHERE EMP_ID='" + txtEmpCode.Tag + "'";
                    DataSet ds = db.GetDataSet(Sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        OracleConnection connected = new OracleConnection(db.strConn);
                        connected.Open();
                        string commandText = "UPDATE EMP_SIGNATURE SET SIGNATURE= :BlobParameter WHERE EMP_ID ='" + txtEmpCode.Tag + "'";
                        OracleParameter oracleParameter = new OracleParameter();
                        oracleParameter.OracleType = OracleType.Blob;
                        oracleParameter.ParameterName = "BlobParameter";
                        oracleParameter.Value = empSign;
                        OracleCommand oracleCommand = new OracleCommand(commandText, connected);
                        oracleCommand.Parameters.Add(oracleParameter);
                        oracleCommand.ExecuteNonQuery();
                        oracleCommand.Dispose();
                        connected.Close();
                        connected.Dispose();
                        MessageBox.Show("Successfully Signature (" + txtEmpCode.Text + ") Uploaded.", "Save As...");
                    }
                    else
                    {
                        OracleConnection connected = new OracleConnection(db.strConn);
                        connected.Open();
                        string commandText = "INSERT INTO EMP_SIGNATURE (EMP_ID, SIGNATURE, CREATE_BY, CREATE_DATE) VALUES ('" + txtEmpCode.Tag + "', :BlobParameter, '" + ConfigurationManager.AppSettings["UserName"] + "', TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'))";
                        OracleParameter oracleParameter = new OracleParameter();
                        oracleParameter.OracleType = OracleType.Blob;
                        oracleParameter.ParameterName = "BlobParameter";
                        oracleParameter.Value = empSign;
                        OracleCommand oracleCommand = new OracleCommand(commandText, connected);
                        oracleCommand.Parameters.Add(oracleParameter);
                        oracleCommand.ExecuteNonQuery();
                        oracleCommand.Dispose();
                        connected.Close();
                        connected.Dispose();
                        MessageBox.Show("Successfully Signature (" + txtEmpCode.Text + ") Uploaded.", "Save");
                    }
                }
            }
            FormControlMode(0);
            txtEmpCode.Focus();
        }
        private void pBoxEmpSignature_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select the directory that you want to use as the default.";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            openFileDialog1.FileName = null;
            getUploadSigneture();
        }
        #endregion

        #region =======================================[MyListBoxView]=======================================
        /*
        private void txt_vill_present_TextChanged(object sender, EventArgs e)
        {
            //if (CPresent.flag == 0)
            //{
            //    if (txt_vill_present.Text != "")
            //    {
            //        CPresent.search_by = txt_vill_present.Text;
            //        Display.presentVillageName_Into_ListBox(txt_vill_present, myListBox, CPresent.search_by);
            //        return;
            //    }
            //    myListBox.Visible = false;
            //}

        }  //End of private void txt_vill_present_TextChanged(object sender, EventArgs e)

        private void txt_ps_present_TextChanged(object sender, EventArgs e)
        {

            //if (CPresent.flag == 0)
            //{
            //    if (txt_ps_present.Text != "")
            //    {
            //        CPresent.search_by = txt_ps_present.Text;
            //        Display.presentPoliceStationName_Into_ListBox(txt_ps_present, myListBox, CPresent.search_by);
            //        return;
            //    }
            //    myListBox.Visible = false;
            //}
        }  //End of private void txt_ps_present_TextChanged(object sender, EventArgs e)

        private void txt_vill_parmanent_TextChanged(object sender, EventArgs e)
        {
            //if (CPresent.flag == 0)
            //{
            //    if (txt_vill_parmanent.Text != "")
            //    {
            //        CPresent.search_by = txt_vill_parmanent.Text;
            //        Display.parmanentVillagetName_Into_ListBox(txt_vill_parmanent, myListBox, CPresent.search_by);
            //        return;
            //    }
            //    myListBox.Visible = false;
            //}
        }  //End of private void txt_vill_parmanent_TextChanged(object sender, EventArgs e)

        private void txt_ps_parmanent_TextChanged(object sender, EventArgs e)
        {
            //if (CPresent.flag == 0)
            //{
            //    if (txt_ps_parmanent.Text != "")
            //    {
            //        CPresent.search_by = txt_ps_parmanent.Text;
            //        Display.parmanentPoliceStationName_Into_ListBox(txt_ps_parmanent, myListBox, CPresent.search_by);
            //        return;
            //    }
            //    myListBox.Visible = false;
            //}
        }  //End of private void txt_ps_parmanent_TextChanged(object sender, EventArgs e)

        private void txt_po_present_TextChanged(object sender, EventArgs e)
        {
            //if (CPresent.flag == 0)
            //{
            //    if (txt_po_present.Text != "")
            //    {
            //        CPresent.search_by = txt_po_present.Text;
            //        Display.presentPostOffcie_Info_ListBox(txt_po_present, myListBox, CPresent.search_by);
            //        return;
            //    }
            //    myListBox.Visible = false;
            //}
        }  //End of private void txt_po_present_TextChanged(object sender, EventArgs e)

        private void txt_dist_present_TextChanged(object sender, EventArgs e)
        {
            //if (CPresent.flag == 0)
            //{
            //    if (txt_dist_present.Text != "")
            //    {
            //        CPresent.search_by = txt_dist_present.Text;
            //        Display.presentDistrictName_Into_ListBox(txt_dist_present, myListBox, CPresent.search_by);
            //        return;
            //    }
            //    myListBox.Visible = false;
            //}
        }  //End of private void txt_emp_name_TextChanged(object sender, EventArgs e)

        private void txt_po_parmanent_TextChanged(object sender, EventArgs e)
        {
            //if (CPresent.flag == 0)
            //{
            //    if (txt_po_parmanent.Text != "")
            //    {
            //        CPresent.search_by = txt_po_parmanent.Text;
            //        Display.ParmanentPostOffcie_Info_ListBox(txt_po_parmanent, myListBox, CPresent.search_by);
            //        return;
            //    }
            //    myListBox.Visible = false;
            //}
        }  //End of private void txt_po_parmanent_TextChanged(object sender, EventArgs e)

        private void txt_dist_parmanent_TextChanged(object sender, EventArgs e)
        {
            //if (CPresent.flag == 0)
            //{
            //    if (txt_dist_parmanent.Text != "")
            //    {
            //        CPresent.search_by = txt_dist_parmanent.Text;
            //        Display.parmanentDistrictName_Into_ListBox(txt_dist_parmanent, myListBox, CPresent.search_by);
            //        return;
            //    }
            //    myListBox.Visible = false;
            //}
        }  //End of private void txt_dist_parmanent_TextChanged(object sender, EventArgs e)
        
        private void txtEducation_TextChanged(object sender, EventArgs e)
        {
            if (CPresent.flag == 0)
            {
                if (txtEducation.Text != "")
                {
                    CPresent.search_by = txtEducation.Text;
                    Display.EducationLevel_Into_ListBox(txtEducation, myListBox, CPresent.search_by);
                    return;
                }
                myListBox.Visible = false;
            }
        }  //End of private void txtEducation_TextChanged(object sender, EventArgs e)

        private void txt_card_no_TextChanged(object sender, EventArgs e)
        {
            if (CPresent.flag == 0)
            {
                if (txt_card_no.Text != "")
                {
                    CPresent.search_by = txt_card_no.Text;
                    Display.proximitycard_Into_ListBox(txt_card_no, myListBox, CPresent.search_by);
                    return;
                }
                myListBox.Visible = false;
            }
        }  //End of private void txt_card_no_TextChanged(object sender, EventArgs e)

        private void myListBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (myListBox.SelectedIndex != -1)
            {
                myListBox.Visible = false;
                SendKeys.Send("{TAB}");
            }
        } //End of private void myListBox_MouseClick(object sender, MouseEventArgs e)

        private void myListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CPresent.flag_listBox == 0 && myListBox.SelectedIndex != -1)
            {
                CPresent.flag = 1;
                if (CPresent.listBoxForWhom == "EMP_CODE")
                {
                    EMP_ID = System.Convert.ToInt32(myListBox.SelectedValue);
                    CPresent.listBoxToTextBox(txt_emp_code, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "EMP_NAME")
                {
                    CPresent.listBoxToTextBox(txt_emp_name, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "PRESENT_VILL")
                {
                    CPresent.listBoxToTextBox(txt_vill_present, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "PRESENT_PS")
                {
                    CPresent.listBoxToTextBox(txt_ps_present, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "PRESENT_DIST")
                {
                    CPresent.listBoxToTextBox(txt_dist_present, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "PRESENT_POSTOFFICE")
                {
                    CPresent.listBoxToTextBox(txt_po_present, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "PARMANENT_VILL")
                {
                    CPresent.listBoxToTextBox(txt_vill_parmanent, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "PARMANENT_PS")
                {
                    CPresent.listBoxToTextBox(txt_ps_parmanent, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "PARMANENT_POSTOFFICE")
                {
                    CPresent.listBoxToTextBox(txt_po_parmanent, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "PARMANENT_DIST")
                {
                    CPresent.listBoxToTextBox(txt_dist_parmanent, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "EDUCATION")
                {
                    CPresent.listBoxToTextBox(txtEducation, myListBox, 1);
                }
                else if (CPresent.listBoxForWhom == "EMP_PROXIMITY")
                {
                    CPresent.listBoxToTextBox(txt_card_no, myListBox, 1);
                }
                CPresent.flag = 0;
            }
        } //End of private void myListBox_SelectedIndexChanged(object sender, EventArgs e)
*/

        #endregion
        private void txtLicenseNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_remarks.Focus();
            else if (e.KeyCode == Keys.F5)       // Search by %......%
            {
                getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.LICENSE_NO LIKE '%" + txtLicenseNo.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                return;
            }// End of if (e.KeyCode == Keys.F5)  / Search by %......%
            else if (e.KeyCode == Keys.F12)       // Search by %......%
            {
                DBClass db=new DBClass();
                string strQuery = "UPDATE EMP_OFFICIAL SET LICENSE_NO = '" + txtLicenseNo.Text.Trim() + "%',USER_ID=" + ConfigurationManager.AppSettings["UserID"] + ",EMP_STATUS_CHANGE_DATE=TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM') WHERE EMP_CODE='" + txtEmpCode.Text.Trim() + "'";
                if (db.RunDmlQuery(strQuery))
                {
                    strQuery = strQuery.Replace("'", string.Empty);
                    string strSql = "INSERT INTO LOG_TAB (USER_ID,WORKING_PLACE,DESCRIPTION,DT,EMP_CODE) VALUES('" + ConfigurationManager.AppSettings["UserID"] + "','EMPLOYEE_ENTRY','" + strQuery + "',TO_DATE('" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "','dd-Mon-yyyy hh12:mi:ss AM'),'" + txtEmpCode.Text.Trim() + "')";
                    db.RunDmlQuery(strSql);
                    MessageBox.Show("Updated Successful", "Save As...");
                    FormControlMode(0);
                }
                else
                {
                    MessageBox.Show("Failed");
                    FormControlMode(1);
                    txtLicenseNo.Focus();
                }
            }// End of if (e.KeyCode == Keys.F5)  / Search by %......%

        }
        
        private void cmbPresDist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_vill_parmanent.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (cmbPresDist.Text.Trim().Length > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_P.PRESENT_DIST LIKE '%" + cmbPresDist.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
        }

        private void cmbPerDist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtBangPresentVill.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (cmbPerDist.Text.Trim().Length > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_P.PARMANENT_DIST LIKE '%" + cmbPerDist.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
        }
        private void cmbPerDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, string> sItemVal = (KeyValuePair<string, string>) cmbPerDist.SelectedItem;
            string sql = "SELECT PARMANENT_DIST FROM EMP_PERSONAL WHERE PARMANENT_DIST='" + sItemVal.Value + "' ORDER BY PARMANENT_DIST";
        }

        private void cmbPresDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, string> sItemVal = (KeyValuePair<string, string>) cmbPresDist.SelectedItem;
            string sql = "SELECT PRESENT_DIST FROM EMP_PERSONAL WHERE PRESENT_DIST='" + sItemVal.Value + "' ORDER BY PRESENT_DIST";
        }

        private void txtErpCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_emp_name.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (txtErpCode.Text.Trim().Length > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_O.ERP_CODE LIKE '%" + txtErpCode.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                if (cmbEducation.SelectedIndex > 0)
                {
                    
                    string sql = "UPDATE EMP_PERSONAL SET EDUCATION='" + cmbEducation.Text.Trim() + "' WHERE EMP_ID='" + txtEmpCode.Tag + "'";
                    if (db.RunDmlQuery(sql))
                    {
                        MessageBox.Show("Update Successful", "Info", MessageBoxButtons.OK);
                        FormControlMode(0);
                    }
                    else FormControlMode(1);
                }
            }
        }
        private void cmbEducation_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, string> sItemVal = (KeyValuePair<string, string>) cmbEducation.SelectedItem;
            string sql = "SELECT EDUCATION FROM EMP_PERSONAL WHERE EDUCATION='" + sItemVal.Value + "' ORDER BY EDUCATION";
        }

        private void cmbEducation_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) dtpCloseDate.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (cmbEducation.SelectedIndex > 0)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND E_P.EDUCATION LIKE '%" + cmbEducation.Text.Trim() + "%' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }// End of if (e.KeyCode == Keys.F5)
            else if (e.KeyCode == Keys.F12)
            {
                if (cmbEducation.SelectedIndex > 0)
                {
                    
                    string sql = "UPDATE EMP_PERSONAL SET EDUCATION ='" + cmbEducation.Text.Trim() + "' WHERE EMP_ID='" + txtEmpCode.Tag + "'";
                    if (db.RunDmlQuery(sql))
                    {
                        MessageBox.Show("Update Successful", "Info", MessageBoxButtons.OK);
                        FormControlMode(0);
                    }
                    else FormControlMode(1);
                }
            }
        }

        private void txtProximityNo_Leave(object sender, EventArgs e)
        {
            if (txtProximityNo.Text.Trim().Length > 0)
            {
                
                string strProxy = "SELECT DISTINCT EMP_CODE FROM EMP_OFFICIAL WHERE PROXIMITY_NO = '" + txtProximityNo.Text.Trim() + "'";
                DataSet ds = db.GetDataSet(strProxy);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (MessageBox.Show("Already Exist This Proximity No To(" + ds.Tables[0].Rows[0]["EMP_CODE"] + ")", "Checked", MessageBoxButtons.OKCancel) == DialogResult.OK) txtProximityNo.Focus();
                    else txtEmpCode.Focus();
                }
                else txt_cell_no.Focus();
            }
            else txt_cell_no.Focus();
        }

        private void cmbIncrSeg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_remarks.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (combo_relation.SelectedIndex != -1)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) = '" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_O.INCR_SEGMENT) = '" + cmbIncrSeg.Text.Trim().ToUpper() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
        }

        private void cmbEL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txt_remarks.Focus();
            else if (e.KeyCode == Keys.F5)
            {
                if (combo_relation.SelectedIndex != -1)
                {
                    getEmpInfoDisplay(" AND UPPER(E_O.EMP_STATUS) ='" + cmbStatus.Text.Trim().ToUpper() + "' AND UPPER(E_O.EL_SEGMENT) = '" + cmbEL.Text.Trim().ToUpper() + "' ORDER BY E_O.EMP_CODE ASC");
                    return;
                }
            }
        }

        private void dtpJoinDate_ValueChanged(object sender, EventArgs e)
        {
            cmbIncrSeg.Text = dtpJoinDate.Value.ToString("MMMM");
            if (dtpJoinDate.Value.Day > 15) cmbIncrSeg.Text = dtpJoinDate.Value.AddMonths(1).ToString("MMMM");
        }

        private void dtpJoinDate_Leave(object sender, EventArgs e)
        {
            cmbIncrSeg.Text = dtpJoinDate.Value.ToString("MMMM");
            if (dtpJoinDate.Value.Day > 15) cmbIncrSeg.Text = dtpJoinDate.Value.AddMonths(1).ToString("MMMM");
        }

        private void txt_bang_father_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_emp_mother.Focus();
            }
        }

        //private void txt_bang_father_name_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txt_emp_mother.Focus();
        //    }
        //}

        private void txt_bang_mother_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_husband_name.Focus();
            }
        }

        private void txt_bang_spouse_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                combo_gender.Focus();
            }
        }

        private void txt_bang_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_father_name.Focus();
            }
        }

        private void txt_bang_pre_vill_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBangPresentPO.Focus();
            }
        }

        private void txt_bang_pre_po_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBangPresentPS.Focus();
            }
        }

        private void txt_bang_pre_PS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBangPresentDist.Focus();
            }
        }

        private void txt_bang_pre_dist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBangParmentVill.Focus();
            }
        }

        private void txt_bang_par_vill_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBangParmentPO.Focus();
            }
        }

        private void txt_bang_par_po_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBangParmentPS.Focus();
            }
        }

        private void txt_bang_par_Ps_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBangParmentDist.Focus();
            }
        }

        private void txt_bang_par_dist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_national_id.Focus();
            }
        }

        private void cmbPos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDesig.Focus();
            }
        }

        private void txt_grade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CBox_Unit.Focus();
            }
        }

        private void txt_bang_nomini_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }
    }
}