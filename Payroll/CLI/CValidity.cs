using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NGPayroll
{
    public static class CValidity
    {
        public static bool File_Exist_or_Not(string path)
        {
            return System.IO.File.Exists(path);
        }

        public static void check_number_value(object sender,KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b' || e.KeyChar == '\u0001' || e.KeyChar == '\u0003' || (e.KeyChar >= '\u0016' && e.KeyChar <= '\u001a'))
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
                MessageBox.Show("The input value should be Numeric only", "Numeric Value Only", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void check_numeric_value(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b' || e.KeyChar == '.')
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
                MessageBox.Show("The input value should be Numeric only", "Numeric Value Only", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static bool date(string strToCheck)
        {
            Regex regex = new Regex("^\\d{2}\\/\\d{2}\\/\\d{4}$");
            return regex.IsMatch(strToCheck);
        }

        public static bool IsCo_ordinate(string strToCheck)
        {
            Regex regex = new Regex("^((\\d{1,3})(\\.?)(\\d*)?(\\:)?){0,2}(\\d{1,3})(\\.?)(\\d*)?$");
            return regex.IsMatch(strToCheck);
        }

        public static void check_Alphabetic_value(KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == ' ' || e.KeyChar == '-' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
        }
        #region "Numeric Value Check"
        static public void IntegerValueCheck(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            TextBox txtB = (TextBox)sender;
            if (e.KeyChar < 48 || e.KeyChar > 57)
                e.Handled = true;
        }

        static public void IntegerValueCheckWithMinusSymbol(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            TextBox txtB = (TextBox)sender;
            if (e.KeyChar == 45 && txtB.Text.Length == 0) return;
            if (e.KeyChar < 48 || e.KeyChar > 57)
                e.Handled = true;
        }

        static public void NumericValueCheckWithMinusSymbol(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            TextBox txtB = (TextBox)sender;
            bool flag = txtB.Text.Trim().Contains(".");
            if (e.KeyChar == 45 && txtB.Text.Length == 0) return;
            if (e.KeyChar == 46 && !flag) return;
            if (e.KeyChar < 48 || e.KeyChar > 57)
                e.Handled = true;
        }

        static public void NumericValueCheck(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8) return;
            TextBox txtB = (TextBox)sender;
            bool flag = txtB.Text.Trim().Contains(".");
            if (e.KeyChar == 46 && !flag) return;
            if (e.KeyChar < 48 || e.KeyChar > 57)
                e.Handled = true;
        }
        static public bool IsNumberContain(string str)
        {
            if (str.Length > 0)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= '0' && str[i] <= '9') return true;
                }
            }
            return false;
        }

        static public bool IsNumeric(string str)
        {
            if (str.Length > 0)
            {
                bool flag = false;
                int i = 0;
                if (str[i] == '-')
                    i = 1;
                for (; i < str.Length; i++)
                {
                    if (str[i] == '.')
                    {
                        if (flag)
                            return false;
                        flag = true;
                    }
                    else if (str[i] >= '0' && str[i] <= '9') continue;
                    else return false;
                }
            }
            return true;
        }
        static public bool IsInterger(string str)
        {
            if (str.Length > 0)
            {
                int i = 0;
                for (; i < str.Length; i++)
                {
                    if (str[i] >= '0' && str[i] <= '9') continue;
                    else return false;
                }
            }
            return true;
        }
        #endregion

    }
}
