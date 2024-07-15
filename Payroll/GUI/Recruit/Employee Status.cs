using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace NGPayroll
{
    public partial class employee_status_UC : UserControl
    {
        public UserControl lastUserControlEmpStatus;
        public int getExitForLastUserControlEmpStatus = 0;
        public employee_status_UC()
        {
            InitializeComponent();
            func_combo_unit();
            func_combo_line();
            func_combo_section();
            func_combo_emp_type();
            func_combo_department();
            func_combo_designation();
            btn_save.Enabled = false;
        }
        public void getEmpStatusDisplay(string strSubQuery)
        {
            DBClass db = new DBClass();
            datagrid_emp_status.Rows.Clear();
            string strSql = @"SELECT A.EMP_CODE,A.EMP_NAME,C.DESIGNATION_NAME,TO_CHAR(DATE_OF_JOINING,'dd-Mon-yyyy') JOIN_DATE, A.GROSS, EXTRACT(YEAR FROM sysdate) - EXTRACT(YEAR FROM DATE_OF_BIRTH) AGE, 
                            A.OVER_TIME, A.TRANSPORT,A.TRANSPORT_STAND, D.EMP_CATEGORY_NAME   
                        FROM EMP_OFFICIAL A, EMP_PERSONAL B, DESIGNATION C, EMP_CATEGORY D, SECTION E, LINE F, DEPARTMENT G
                        WHERE A.EMP_STATUS = 'Active' AND A.EMP_ID=B.EMP_ID AND A.DESIGNATION_ID = C.DESIGNATION_ID
                            AND A.DESIGNATION_ID=C.DESIGNATION_ID AND A.EMP_CATEGORY_ID = D.EMP_CATEGORY_ID AND A.SECTION_ID=E.SECTION_ID
                            AND A.DEPARTMENT_ID=G.DEPARTMENT_ID AND A.LINE_ID=F.LINE_ID " + strSubQuery+@" ORDER BY EMP_CODE";
            OracleDataReader dr = db.GetExecuteReader(strSql);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string emp_code = dr.GetValue(0).ToString();
                    string emp_name = dr.GetValue(1).ToString();
                    string emp_desig = dr.GetValue(2).ToString();
                    string emp_joining = dr.GetValue(3).ToString();
                    string emp_gross = dr.GetValue(4).ToString();
                    string emp_age = dr.GetValue(5).ToString();
                    string emp_ot = dr.GetValue(6).ToString();
                    string emp_tr = dr.GetValue(7).ToString();
                    string emp_tr_stand = dr.GetValue(8).ToString();
                    datagrid_emp_status.Rows.Add(emp_code, emp_name, emp_desig,emp_joining, emp_gross, emp_age, emp_ot, emp_tr, emp_tr_stand);
                }
                dr.Close();
                int c = datagrid_emp_status.Rows.Count - 1;
                label9.Text = "Total: " + c;
                btn_save.Enabled = true;
            }
            else
            {
                MessageBox.Show("No data found from date " + dateTimePicker_from.Text + " to " + dateTimePicker_to.Text);
                btn_save.Enabled = false;
            }
        } // End of desig_emp_Show()
        
        void func_combo_emp_type()
        {
            DBClass db = new DBClass();
            string query = "select EMP_CATEGORY_ID, EMP_CATEGORY_NAME from EMP_CATEGORY ORDER BY EMP_CATEGORY_NAME";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));
                string key = dr.GetString(1);
                combo_emp_type.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            dr.Close();
            combo_emp_type.DisplayMember = "Key";
            combo_emp_type.ValueMember = "Value";
        }

        private void combo_emp_type_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DBClass db = new DBClass();
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_emp_type.SelectedItem;
                combo_emp_type.Tag = selected_item.Value;
                combo_emp_type.Text = selected_item.Key;
                string sql = "select *from emp_category where emp_category_id='" + combo_emp_type.Tag + "'";
                OracleDataReader dr = db.GetExecuteReader(sql);
                if (dr.Read()) txt_emp_type.Text = dr["emp_category_id"].ToString(); dr.Close();
            }
            if (combo_emp_type.Text.Length == 0) txt_emp_type.Text = "";
        }


        private void combo_emp_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_emp_type.SelectedItem;
            combo_emp_type.Tag = selected_item.Value;
            combo_emp_type.Text = selected_item.Key;
            string sql = "select *from emp_category where emp_category_id='" + combo_emp_type.Tag + "'";
            OracleDataReader dr = db.GetExecuteReader(sql);
            if (dr.Read()) txt_emp_type.Text = dr["emp_category_id"].ToString(); dr.Close();
            if (combo_emp_type.Text.Length == 0) txt_emp_type.Text = "";
        }

        void func_combo_department()
        {
            DBClass db = new DBClass();
            string sql = "select DEPARTMENT_ID, DEPARTMENT_NAME from DEPARTMENT ORDER BY DEPARTMENT_NAME";
            OracleDataReader dr = db.GetExecuteReader(sql);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));
                string key = dr.GetString(1);
                combo_department.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            dr.Close();
            combo_department.DisplayMember = "Key";
            combo_department.ValueMember = "Value";
        }


        private void combo_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_department.SelectedItem;
            combo_department.Tag = selected_item.Value;
            combo_department.Text = selected_item.Key;
            string sql = "select *from department where department_id='" + combo_department.Tag + "'";
            OracleDataReader dr = db.GetExecuteReader(sql);
            if (dr.Read()) txt_dept_id.Text = dr["department_id"].ToString(); dr.Close();
            if (combo_department.Text.Length == 0) txt_dept_id.Text = "";
        }


        private void combo_department_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DBClass db = new DBClass();
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_department.SelectedItem;
                combo_department.Tag = selected_item.Value;
                combo_department.Text = selected_item.Key;
                string sql = "select *from department where department_id='" + combo_department.Tag + "'";
                OracleDataReader dr = db.GetExecuteReader(sql);
                if (dr.Read()) txt_dept_id.Text = dr["department_id"].ToString();
            }
            if (combo_department.Text.Length == 0) txt_dept_id.Text = "";
        }

        void func_combo_section()
        {
            DBClass db = new DBClass();
            string query = "select SECTION_ID, SECTION_NAME from SECTION ORDER BY SECTION_NAME";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));
                string key = dr.GetString(1);
                combo_section_name.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            dr.Close();
            combo_section_name.DisplayMember = "Key";
            combo_section_name.ValueMember = "Value";
        }

        void func_combo_line()
        {
            DBClass db = new DBClass();
            string query = "select LINE_ID, LINE_NAME from LINE ORDER BY LINE_NAME";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));
                string key = dr.GetString(1);
                combo_line_name.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            dr.Close();
            combo_line_name.DisplayMember = "Key";
            combo_line_name.ValueMember = "Value";
        }

        void func_combo_designation()
        {
            DBClass db = new DBClass();
            string query = "select DESIGNATION_ID, DESIGNATION_NAME from DESIGNATION ORDER BY DESIGNATION_NAME";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));
                string key = dr.GetString(1);
                combo_designation_name.Items.Add(new KeyValuePair<string, int>(key, value));
            }
            dr.Close();
            combo_designation_name.DisplayMember = "Key";
            combo_designation_name.ValueMember = "Value";
        }

        void func_combo_unit()
        {
            DBClass db = new DBClass();
            string query = "select UNIT_ID, UNIT_NAME from UNIT ORDER BY UNIT_NAME";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                int value = Convert.ToInt32(dr.GetValue(0));
                string key = dr.GetString(1);
                combo_unit_name.Items.Add(new KeyValuePair<string, int>(key, value)); // add as key-value pair 
            }
            dr.Close();
            combo_unit_name.SelectedIndex = 0;
            combo_unit_name.DisplayMember = "Key";
            combo_unit_name.ValueMember = "Value";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string strSql = "";
            if (txt_emp_type.Text != "" & combo_emp_type.Text.Length != 0) strSql += " AND D.EMP_CATEGORY_ID = '" + txt_emp_type.Text + "'";
            if (txt_section_id.Text != "" & combo_section_name.Text.Length != 0) strSql += " AND E.SECTION_ID = '" + txt_section_id.Text + "'";
            if (txt_line_id.Text != "" & combo_line_name.Text.Length != 0) strSql += " AND F.LINE_ID= '" + txt_line_id.Text + "'";
            if (txt_dept_id.Text != "" & combo_department.Text.Length != 0) strSql += " AND G.DEPARTMENT_ID= '" + txt_dept_id.Text + "'";
            if (txt_designation_id.Text != "" & combo_designation_name.Text.Length != 0) strSql += " AND C.DESIGNATION_ID= '" + txt_designation_id.Text + "'";
            getEmpStatusDisplay(strSql + " AND DATE_OF_JOINING BETWEEN '" + dateTimePicker_from.Text + "' AND '" + dateTimePicker_to.Text + "'");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DBClass db = new DBClass();
            if (MessageBox.Show("Do you want to update changes?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {                
                for (int i = 0; i < datagrid_emp_status.Rows.Count - 1; i++)
                {
                    var emp_id = datagrid_emp_status.Rows[i].Cells[0].Value.ToString();
                    var joindt = datagrid_emp_status.Rows[i].Cells[3].Value;
                    var gross = datagrid_emp_status.Rows[i].Cells[4].Value;
                    var over_time = datagrid_emp_status.Rows[i].Cells[6].Value.ToString();
                    var transport = datagrid_emp_status.Rows[i].Cells[7].Value.ToString();

                    string sql = @"update emp_official set gross='" + gross + "',OVER_TIME='" + over_time + "',TRANSPORT='" + transport + "',DATE_OF_JOINING=to_date('" + joindt + "','DD-MM-YYYY') where EMP_CODE='" + emp_id + "'";
                    bool r = db.RunDmlQuery(sql);
                }
                MessageBox.Show("Data Update Successfully", "Updated Data");
            }
            else  MessageBox.Show("Not Updated .","Error");
        }

        private void combo_section_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_section_name.SelectedItem;

            combo_section_name.Tag = selected_item.Value;  // make text value to dispalay value
            combo_section_name.Text = selected_item.Key;   // make the value to tag property of textbox

            string sql = "select *from section where section_id='" + combo_section_name.Tag + "'";
            DBClass db = new DBClass();

            OracleDataReader dr = db.GetExecuteReader(sql);
            if (dr.Read())
            {
                txt_section_id.Text = dr["section_id"].ToString();
            }
            if (combo_section_name.Text.Length == 0)
            {
                txt_section_id.Text = "";
            }
        }

        private void combo_section_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_section_name.SelectedItem;

                combo_section_name.Tag = selected_item.Value;  // make text value to dispalay value
                combo_section_name.Text = selected_item.Key;   // make the value to tag property of textbox

                string sql = "select *from section where section_id='" + combo_section_name.Tag + "'";
                DBClass db = new DBClass();

                OracleDataReader dr = db.GetExecuteReader(sql);
                if (dr.Read())
                {
                    txt_section_id.Text = dr["section_id"].ToString();
                }
            }
            if (combo_section_name.Text.Length == 0)
            {
                txt_section_id.Text = "";
            }
        }

        private void combo_line_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_line_name.SelectedItem;

            combo_line_name.Tag = selected_item.Value;  // make text value to dispalay value
            combo_line_name.Text = selected_item.Key;   // make the value to tag property of textbox

            string sql = "select *from line where line_id='" + combo_line_name.Tag + "'";
            DBClass db = new DBClass();

            OracleDataReader dr = db.GetExecuteReader(sql);
            if (dr.Read())
            {
                txt_line_id.Text = dr["line_id"].ToString();
            }
            if (combo_line_name.Text.Length == 0)
            {
                txt_line_id.Text = "";
            }
        }

        private void combo_line_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_line_name.SelectedItem;

                combo_line_name.Tag = selected_item.Value;  // make text value to dispalay value
                combo_line_name.Text = selected_item.Key;   // make the value to tag property of textbox

                string sql = "select *from line where line_id='" + combo_line_name.Tag + "'";
                DBClass db = new DBClass();

                OracleDataReader dr = db.GetExecuteReader(sql);
                if (dr.Read())
                {
                    txt_line_id.Text = dr["line_id"].ToString();
                }
            }
            if (combo_line_name.Text.Length == 0)
            {
                txt_line_id.Text = "";
            }
        }

        private void combo_designation_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_designation_name.SelectedItem;

            combo_designation_name.Tag = selected_item.Value;  // make text value to dispalay value
            combo_designation_name.Text = selected_item.Key;   // make the value to tag property of textbox

            string sql = "select *from designation where designation_id='" + combo_designation_name.Tag + "'";
            DBClass db = new DBClass();

            OracleDataReader dr = db.GetExecuteReader(sql);
            if (dr.Read())
            {
                txt_designation_id.Text = dr["designation_id"].ToString();
            }
            if (combo_designation_name.Text.Length == 0)
            {
                txt_designation_id.Text = "";
            }
        }

        private void combo_designation_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_designation_name.SelectedItem;

                combo_designation_name.Tag = selected_item.Value;  // make text value to dispalay value
                combo_designation_name.Text = selected_item.Key;   // make the value to tag property of textbox

                string sql = "select *from designation where designation_id='" + combo_designation_name.Tag + "'";
                DBClass db = new DBClass();

                OracleDataReader dr = db.GetExecuteReader(sql);
                if (dr.Read())
                {
                    txt_designation_id.Text = dr["designation_id"].ToString();
                }
            }
            if (combo_designation_name.Text.Length == 0)
            {
                txt_designation_id.Text = "";
            }
        }

        private void combo_unit_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_unit_name.SelectedItem;

            combo_unit_name.Tag = selected_item.Value;  // make text value to dispalay value
            combo_unit_name.Text = selected_item.Key;   // make the value to tag property of textbox

            string sql = "select *from unit where unit_id='" + combo_unit_name.Tag + "'";
            DBClass db = new DBClass();

            OracleDataReader dr = db.GetExecuteReader(sql);
            if (dr.Read())
            {
                txt_unit_id.Text = dr["unit_id"].ToString();
            }
            if (combo_unit_name.Text.Length == 0)
            {
                txt_unit_id.Text = "";
            }
        }

        private void combo_unit_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                KeyValuePair<string, int> selected_item = (KeyValuePair<string, int>)combo_unit_name.SelectedItem;

                combo_unit_name.Tag = selected_item.Value;  // make text value to dispalay value
                combo_unit_name.Text = selected_item.Key;   // make the value to tag property of textbox

                string sql = "select *from unit where unit_id='" + combo_unit_name.Tag + "'";
                DBClass db = new DBClass();

                OracleDataReader dr = db.GetExecuteReader(sql);
                if (dr.Read())
                {
                    txt_unit_id.Text = dr["unit_id"].ToString();
                }
            }
            if (combo_unit_name.Text.Length == 0)
            {
                txt_unit_id.Text = "";
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            datagrid_emp_status.Rows.Clear();
            combo_unit_name.Text = "";
            txt_unit_id.Text = "";
            combo_emp_type.Text = "";
            txt_emp_type.Text = "";
            combo_section_name.Text = "";
            txt_section_id.Text = "";
            combo_line_name.Text = "";
            txt_line_id.Text = "";
            combo_department.Text = "";
            txt_dept_id.Text = "";
            combo_designation_name.Text = "";
            txt_designation_id.Text = "";
        }
        private void employee_status_UC_Load(object sender, EventArgs e)
        {
            dateTimePicker_from.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void dateTimePicker_from_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_to.Value = new DateTime(dateTimePicker_from.Value.Year, dateTimePicker_from.Value.Month, DateTime.DaysInMonth(dateTimePicker_from.Value.Year, dateTimePicker_from.Value.Month));
        }

        private void btnExitUserControl_Click(object sender, EventArgs e)
        {
            payroll_main_form mForm = this.ParentForm as payroll_main_form;
            mForm.splitContainer1.Panel2.Controls.Clear();
            if (getExitForLastUserControlEmpStatus == 1)
            {
                mForm.splitContainer1.Panel2.Controls.Add(lastUserControlEmpStatus);
                lastUserControlEmpStatus.Show();
            }
            else
            {
                ucDashboard objDashBoard = new ucDashboard();
                mForm.splitContainer1.Panel2.Controls.Add(objDashBoard);
                objDashBoard.Show();
            }
        }
    }
}
