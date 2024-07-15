using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Configuration;

namespace NGPayroll
{
    public partial class Payroll_Login_form : Form
    {
        public Payroll_Login_form()
        {
            InitializeComponent();
            lblComName.Parent = pictureBox4;
            lblComName.BackColor = Color.Transparent;
            label1.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;            
            txtUserName.Text = "";
            txtPassWord.Text = "";

        }
        private void getLoginFromData()
        {
            DBClass db = new DBClass();
            string sql = "SELECT USER_ID,USER_NAME,PASSWORD,PRIVILEGE_ARRAY FROM TB_USERS WHERE LOWER(USER_NAME)='" + txtUserName.Text.ToLower() + "' AND PASSWORD='" + txtPassWord.Text + "' ";
            DataSet ds = db.GetDataSet(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CConfig.user_id = Convert.ToInt32(ds.Tables[0].Rows[i]["USER_ID"].ToString());
                    var user_name = ds.Tables[0].Rows[i]["USER_NAME"];
                    var user_pass = ds.Tables[0].Rows[i]["PASSWORD"];
                    ConfigurationManager.AppSettings["UserID"] = ds.Tables[0].Rows[i]["USER_ID"].ToString();
                    ConfigurationManager.AppSettings["UserName"] = ds.Tables[0].Rows[i]["USER_NAME"].ToString();
                    if (user_name.ToString().ToLower() == txtUserName.Text.ToLower() && user_pass.ToString() == txtPassWord.Text)
                    {
                        payroll_main_form mForm = new payroll_main_form();
                        mForm.passvalue = user_name.ToString();
                        mForm.Show(); this.Hide();
                    }
                    else
                        MessageBox.Show("Invalid User Name or Password given.", "Error");
                }
            }
            
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            getLoginFromData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblComName.Location = new Point(lblComName.Location.X + 5, lblComName.Location.Y);
            if (lblComName.Location.X > this.Width) lblComName.Location = new Point(0 - lblComName.Width, lblComName.Location.Y);
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) getLoginFromData();
        } // End of private void txt_password_KeyPress(object sender, KeyPressEventArgs e)

        private void txt_user_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.Home||e.KeyCode==Keys.F3)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                else if (e.KeyCode == Keys.F1)
                {
                    txtUserName.Text = "NG_Payroll";
                    txtPassWord.Text = "ng_payroll";
                }
                else if (e.KeyCode == Keys.F2)
                {
                    txtUserName.Text = "ferdous";
                    txtPassWord.Text = "AllahU";
                }
                else if (e.KeyCode == Keys.F3)
                {
                    txtUserName.Text = "ict";
                    txtPassWord.Text = "ict";
                    btn_login_Click(sender, e);
                }
            }
            
        }// End of private void txt_user_name_KeyUp(object sender, KeyEventArgs e)

        private void lblPasswd_Click(object sender, EventArgs e)
        {
            //txt_user_name.Text = "Sumon";
            //txt_password.Text = "sumon";
        }  // End of private void txt_password_KeyUp(object sender, KeyEventArgs e)
    }
}
