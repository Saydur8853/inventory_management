using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace NGPayroll
{
    public static class CPresent
    {
        public static string listBoxForWhom;
        public static int flag_listBox;
        public static int flag;
        public static string search_by;
        public static string[] month = new string[]
		{
			"Jan",
			"Feb",
			"Mar",
			"Apr",
			"May",
			"Jun",
			"Jul",
			"Aug",
			"Sep",
			"Oct",
			"Nov",
			"Dec"
		};

        public static void Key_Up_Event_for_ListBox_Access(TextBox myTextBox, ListBox myListBox, KeyEventArgs e, string type_str)
        {
            if (e.KeyData == Keys.Down)
            {
                if (myListBox.SelectedIndex == myListBox.Items.Count - 1)
                {
                    myTextBox.Text = type_str;
                    myListBox.ClearSelected();
                    myTextBox.Focus();
                    myTextBox.Select(myTextBox.Text.Length, 0);
                    return;
                }
                myListBox.SelectedIndex++;
                return;
            }
            else
            {
                if (e.KeyData != Keys.Up)
                {
                    if (e.KeyData == Keys.Escape)
                    {
                        myListBox.Visible = false;
                        myTextBox.Clear();
                    }
                    return;
                }
                if (myListBox.SelectedIndex == -1)
                {
                    myListBox.SelectedIndex = myListBox.Items.Count - 1;
                    return;
                }
                if (myListBox.SelectedIndex == 0)
                {
                    myTextBox.Text = type_str;
                    myListBox.ClearSelected();
                    myTextBox.Focus();
                    myTextBox.Select(myTextBox.Text.Length, 0);
                    return;
                }
                myListBox.SelectedIndex--;
                return;
            }
        }

        public static void showListBox(TextBox mytextBox, ListBox mylistBox)
        {
            int x = mytextBox.Location.X;
            int y = mytextBox.Location.Y + mytextBox.Height;
            mylistBox.Location = new Point(x, y);
            mylistBox.Size = new Size(mytextBox.Size.Width, 150);
        }

        public static void listBoxToTextBox(TextBox myTextBox, ListBox myListBox, int position)
        {
            myTextBox.Text = ((DataRowView)myListBox.SelectedItem).Row.ItemArray.ElementAt(position).ToString().TrimEnd(new char[0]);
            myTextBox.Focus();
            myTextBox.Select(myTextBox.Text.Length, 0);
        }

        public static DataSet convertintobangla(DataSet ds, int index)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i][index] = HttpUtility.HtmlDecode(ds.Tables[0].Rows[i][index].ToString()).ToString();
            }
            return ds;
        }

        public static DataSet CommonListBox(ListBox myListBox, string query, string displayMenber, string valueMember)
        {
            DBClass oDbClass = new DBClass();
            CPresent.flag_listBox = 1;
            myListBox.ClearSelected();
            myListBox.DataSource = null;
            DataSet dataSet = new DataSet();
            dataSet = oDbClass.GetDataSet(query);
            myListBox.DisplayMember = displayMenber;
            myListBox.ValueMember = valueMember;
            myListBox.DataSource = dataSet.Tables[0].DefaultView;
            if (myListBox.Items.Count < 1)
            {
                myListBox.Visible = false;
            }
            else
            {
                myListBox.Show();
                myListBox.BringToFront();
            }
            myListBox.SelectedIndex = -1;
            CPresent.flag_listBox = 0;
            return dataSet;
        }

        public static DataSet CommonListBox(ListBox myListBox, string query)
        {
            DBClass db = new DBClass();
            CPresent.flag_listBox = 1;
            myListBox.ClearSelected();
            myListBox.DataSource = null;
            DataSet dataSet = new DataSet();
            dataSet = db.GetDataSet(query);
            try
            {
                myListBox.DisplayMember = dataSet.Tables[0].Columns[1].ColumnName;
                myListBox.ValueMember = dataSet.Tables[0].Columns[0].ColumnName;
                myListBox.DataSource = dataSet.Tables[0].DefaultView;
                if (myListBox.Items.Count < 1)
                {
                    myListBox.Visible = false;
                }
                else
                {
                    myListBox.Show();
                    myListBox.BringToFront();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            myListBox.SelectedIndex = -1;
            CPresent.flag_listBox = 0;
            return dataSet;
        }

        public static DataSet CommonListBox(ListBox myListBox, string query, string displayMenber, string valueMember, int index)
        {
            DBClass db = new DBClass();
            CPresent.flag_listBox = 1;
            myListBox.ClearSelected();
            myListBox.DataSource = null;
            DataSet dataSet = new DataSet();
            dataSet = db.GetDataSet(query);
            dataSet = CPresent.convertintobangla(dataSet, index);
            myListBox.DisplayMember = displayMenber;
            myListBox.ValueMember = valueMember;
            myListBox.DataSource = dataSet.Tables[0].DefaultView;
            if (myListBox.Items.Count < 1)
            {
                myListBox.Visible = false;
            }
            else
            {
                myListBox.Show();
                myListBox.BringToFront();
            }
            myListBox.SelectedIndex = -1;
            CPresent.flag_listBox = 0;
            return dataSet;
        }

        public static DataSet CommonComboBox(ComboBox myListBox, string query, string displayMenber, string valueMember)
        {
            DBClass db = new DBClass();
            CPresent.flag_listBox = 1;
            myListBox.DataSource = null;
            DataSet dataSet = new DataSet();
            dataSet = db.GetDataSet(query);
            myListBox.DisplayMember = displayMenber;
            myListBox.ValueMember = valueMember;
            myListBox.DataSource = dataSet.Tables[0].DefaultView;
            if (myListBox.Items.Count < 1)
            {
                myListBox.Visible = false;
            }
            else
            {
                myListBox.Show();
                myListBox.BringToFront();
            }
            myListBox.SelectedIndex = -1;
            CPresent.flag_listBox = 0;
            return dataSet;
        }

        public static DataSet CommonComboBox(ComboBox myComboBox, string query)
        {
            DBClass db = new DBClass();
            CPresent.flag_listBox = 1;
            myComboBox.DataSource = null;
            myComboBox.Items.Clear();
            DataSet dataSet = new DataSet();
            dataSet = db.GetDataSet(query);
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                myComboBox.Items.Add(dataSet.Tables[0].Rows[i][0]);
            }
            if (myComboBox.Items.Count < 1)
            {
                myComboBox.Visible = false;
            }
            else
            {
                myComboBox.Show();
                myComboBox.BringToFront();
            }
            myComboBox.SelectedIndex = -1;
            CPresent.flag_listBox = 0;
            return dataSet;
        }

        public static string Current_Date()
        {
            int day = System.DateTime.Today.Day;
            int num = System.DateTime.Today.Month;
            string text;
            if (day < 10)
            {
                text = "0" + day.ToString();
            }
            else
            {
                text = day.ToString();
            }
            if (num < 10)
            {
                text = text + "/0" + num.ToString();
            }
            else
            {
                text = text + "/" + num.ToString();
            }
            return text + "/" + System.DateTime.Today.Year;
        }

        public static string Picture_Path(string sourcePath, string filName)
        {
            string text = "C:\\Documents and Settings\\ABDULLAH-AL-MAMUN\\Desktop\\CURRENT TASK\\THMS\\User Picture\\";
            text += filName;
            System.IO.File.Copy(sourcePath, text, true);
            return text;
        }

        public static System.Collections.ArrayList CommonComboBoxByArrayList(ComboBox myComboBox, string statement)
        {
            DBClass db = new DBClass();
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
            try
            {
                myComboBox.Items.Clear();
                OracleDataReader oracleDataReader = db.GetExecuteReader(statement);
                if (oracleDataReader.HasRows)
                {
                    arrayList.Add(0);
                    myComboBox.Items.Add("(ALL)");
                    while (oracleDataReader.Read())
                    {
                        arrayList.Add(oracleDataReader.GetInt32(0));
                        myComboBox.Items.Add(oracleDataReader.GetString(1));
                    }
                }
            }
            catch (System.Exception arg)
            {
                MessageBox.Show("Error : " + arg);
            }
            return arrayList;
        }

        public static Image Display_Picture(string path, int size)
        {
            Image image = Image.FromFile(path);
            float num = (float)image.Size.Width / (float)((double)image.Size.Height * 1.0);
            int num2;
            int num3;
            if ((double)num >= 1.0)
            {
                num2 = size;
                num3 = (int)((float)num2 / num);
            }
            else
            {
                num3 = size;
                num2 = (int)((float)num3 * num);
            }
            return image.GetThumbnailImage(num2, num3, null, System.IntPtr.Zero);
        }

        public static string getDateFromMask(string str)
        {
            if (CValidity.date(str))
            {
                return string.Concat(new string[]
				{
					str.Substring(0, 2),
					"-",
					CPresent.month[(int)(System.Convert.ToInt16(str.Substring(3, 2)) - 1)],
					"-",
					str.Substring(6)
				});
            }
            return "";
        }

        public static string setDateToMask(object value)
        {
            string text = "";
            if (value != System.DBNull.Value)
            {
                System.DateTime date = System.Convert.ToDateTime(value).Date;
                if (date.Day > 9)
                {
                    text = date.Day.ToString();
                }
                else
                {
                    text = "0" + date.Day.ToString();
                }
                if (date.Month > 9)
                {
                    text += date.Month.ToString();
                }
                else
                {
                    text = text + "0" + date.Month.ToString();
                }
                text += date.Year.ToString();
            }
            return text;
        }
    }
}
