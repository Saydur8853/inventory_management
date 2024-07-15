using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NGPayroll
{
    public partial class frmSecurityInputBox : Form
    {
        TextBox PassW;
        //public UserControl lastUserControlAttd;
        public frmSecurityInputBox(ref TextBox Password)
        {
            InitializeComponent();
            PassW = Password;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBoxPasswd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtBoxPasswd_TextChanged(object sender, EventArgs e)
        {
            PassW.Text = txtBoxPasswd.Text;
        }

    }
}
