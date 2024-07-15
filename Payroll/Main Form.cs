using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Configuration;



namespace NGPayroll
{
    public partial class payroll_main_form : Form
    {
        string[] privilege_array;
        public string user_name;
        public string passvalue
        {
            get { return user_name; }
            set{ user_name = value; }
        }        
        public payroll_main_form()
        {
            InitializeComponent();
            com_lvl.Parent = pictureBox2;
            com_lvl.BackColor = Color.Transparent; 
            login_as.BackColor = Color.DodgerBlue;            
        }        
        private void add_child_control_of_parent(int control_id, TreeNode parent_node)
        {
            int i = 0;
            DBClass db = new DBClass();
            string query = "SELECT CONTROL_ID,CONTROL_NAME,DESCRIPTION,CALLING_ID,CONTROL_TYPE,PRIORITY FROM TB_CONTROLS WHERE CONTROL_TYPE = 'MENU' AND CALLING_ID = '" + control_id + "' ORDER BY PRIORITY";
            OracleDataReader dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = dr.GetString(1).ToString();
                newNode.Tag = dr.GetString(1).ToString();
                newNode.Name = dr.GetValue(0).ToString();
                if (this.privilege_array.Contains(dr.GetValue(0).ToString()))
                {
                    parent_node.Nodes.Insert(i, newNode);
                    add_child_control_of_parent(Convert.ToInt32(dr.GetValue(0)), parent_node.Nodes[i]);
                    i++;
                }
            }
            dr.Close();
        }

        private void payroll_main_form_Load(object sender, EventArgs e)
        {         
            DBClass db = new DBClass();
            login_as.Text = user_name.ToUpper();
            string strQuery = "SELECT COMPANY_ID,COMPANY_NAME FROM TB_COMPANY WHERE COMPANY_ID = (SELECT COMPANY_ID FROM TB_USERS WHERE USER_ID='" + ConfigurationManager.AppSettings["UserID"] + "')";
            DataSet ds = db.GetDataSet(strQuery);
            if (ds.Tables[0].Rows.Count > 0)
            {
                com_lvl.Text = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
                CConfig.MASTER_TAG = Convert.ToInt32(ds.Tables[0].Rows[0]["COMPANY_ID"].ToString());
            }
            string query = @"SELECT PRIVILEGE_ARRAY FROM TB_USERS WHERE USER_NAME = '" + user_name + "'";
            OracleDataReader dr = db.GetExecuteReader(query);
            string all_privilege = null;
            while (dr.Read())
            {
                all_privilege = dr.GetString(0);
                privilege_array = all_privilege.Split(',');
            }
            int pos = 0;
            query = "SELECT CONTROL_ID,CONTROL_NAME,DESCRIPTION,CALLING_ID,CONTROL_TYPE,PRIORITY FROM TB_CONTROLS WHERE CONTROL_TYPE = 'MENU' AND CALLING_ID = '0' ORDER BY PRIORITY";
            dr = db.GetExecuteReader(query);
            while (dr.Read())
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = dr.GetString(1).ToString();
                newNode.Tag = dr.GetString(1).ToString();
                newNode.Name = dr.GetValue(0).ToString();
                if (privilege_array.Contains(dr.GetValue(0).ToString()))
                {
                    treeView_login.Nodes.Insert(pos, newNode);
                    add_child_control_of_parent(Convert.ToInt32(dr.GetValue(0)), treeView_login.Nodes[pos]);
                    pos++;
                }
            }
            dr.Close();
            treeView_login.ExpandAll();
            treeView_login.Refresh();
            treeView_login.Nodes[0].EnsureVisible();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            com_lvl.Location = new Point(com_lvl.Location.X + 5, com_lvl.Location.Y);
            if (com_lvl.Location.X > this.Width) com_lvl.Location = new Point(0 - com_lvl.Width, com_lvl.Location.Y);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Payroll_Login_form mForm = new Payroll_Login_form();
            this.Hide(); mForm.Show();
        }

        private void payroll_main_form_Shown(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            ucDashboard objDashBoard = new ucDashboard();
            this.splitContainer1.Panel2.Controls.Add(objDashBoard);
            objDashBoard.BringToFront();
        }
        
        private void treeView_login_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tnMenuName = treeView_login.SelectedNode;
            string strTnMenu =  tnMenuName.ToString();
            this.splitContainer1.Panel2.Controls.Clear();

            string strUom = "UOM"; 
            string strProd = "Product";
            string strRcv = "Stoct IN";
            string strDel = "Stock Out";
            string strCate = "Category";

            if (strTnMenu.ToString() == "TreeNode: " + strCate.ToString())
            {
                ucCategory oCate = new ucCategory();
                splitContainer1.Panel2.Controls.Add(oCate); 
                oCate.Show();
            }
            else if (strTnMenu.ToString() == "TreeNode: " + strUom.ToString())
            {
                ucUom oUom = new ucUom();
                splitContainer1.Panel2.Controls.Add(oUom);
                oUom.Show();
            }
            else if (strTnMenu.ToString() == "TreeNode: " + strProd.ToString())
            {
                ucProduct oProd = new ucProduct();
                splitContainer1.Panel2.Controls.Add(oProd);
                oProd.Show();
            }
            else if (strTnMenu.ToString() == "TreeNode: " + strRcv.ToString())
            {
                ucStockIn oRcv = new ucStockIn();
                splitContainer1.Panel2.Controls.Add(oRcv);
                oRcv.Show();
            }
            else if (strTnMenu.ToString() == "TreeNode: " + strDel.ToString())
            {
                ucStockOut oDel = new ucStockOut();
                splitContainer1.Panel2.Controls.Add(oDel);
                oDel.Show();
            }
            else
            {
                ucDashboard oDash = new ucDashboard();
                splitContainer1.Panel2.Controls.Add(oDash); oDash.Show();
            } //splitContainer1.Panel2.Controls.Clear();
        }
        private void payroll_main_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
