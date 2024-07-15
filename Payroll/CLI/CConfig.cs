using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NGPayroll
{
    public class CConfig
    {
        public static System.Collections.Generic.Dictionary<string, Form> CollectionOfForms = new System.Collections.Generic.Dictionary<string, Form>();

        public static System.Collections.Generic.Dictionary<string, UserControl> userControlCollection = new System.Collections.Generic.Dictionary<string, UserControl>();

        public static System.Collections.Generic.Dictionary<string, DataGridView> DicDataGridView = new System.Collections.Generic.Dictionary<string, DataGridView>();

        public static DataSet myDataset = null;
        //public static DataSet statusDataset;

        public static string report_for;

        public static string login_user_name;

        public static int login_user_id = 0;
        public static int user_id = 0;
        public static int COMPANY_TAG = 0;
        public static int COMPANY = 1;

        public static string schema_name;

        public static int MASTER_TAG = 0;

        public static int UNIT_TAG = 0;

        public static int MASTER_UNIT_TAG = 0;

        public static void Cystal_Allow_Password(ReportClass obj, string server_name, string user_name, string password)
        {
            new TableLogOnInfos();
            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.ServerName = server_name;
            connectionInfo.UserID = user_name;
            connectionInfo.Password = password;
            Tables tables = obj.Database.Tables;
            foreach (Table table in tables)
            {
                tableLogOnInfo = table.LogOnInfo;
                tableLogOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogOnInfo);
            }
        }
        public static string SetEscapeChar(string p)
        {
            string Abc = "";
            Abc = p.Replace("'", "''");
            Abc = Abc.Replace("?", "‡");
            return Abc;
        }
        public static int getIntegreDataFromdatasetByBinarySearch(DataSet ds, string colName, int start, int end, int searchValue)
        {
            int num = (start + end) / 2;
            if (num < 0 || num >= ds.Tables[0].Rows.Count)
            {
                return -1;
            }
            int num2 = System.Convert.ToInt32(ds.Tables[0].Rows[num][colName]);
            if (num2 == searchValue)
            {
                return num;
            }
            if (start >= end)
            {
                return -1;
            }
            if (num2 < searchValue)
            {
                return CConfig.getIntegreDataFromdatasetByBinarySearch(ds, colName, num + 1, end, num2);
            }
            return CConfig.getIntegreDataFromdatasetByBinarySearch(ds, colName, start, num - 1, num2);
        }

        public static DialogResult InputBox(string title, string promptText, ref string value, bool visible)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button button = new Button();
            Button button2 = new Button();
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            if (!visible)
            {
                textBox.UseSystemPasswordChar = true;
            }
            button.Text = "OK";
            button2.Text = "Cancel";
            button.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            button.SetBounds(228, 72, 75, 23);
            button2.SetBounds(309, 72, 75, 23);
            label.AutoSize = true;
            textBox.Anchor |= AnchorStyles.Right;
            button.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            button2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[]
			{
				label,
				textBox,
				button,
				button2
			});
            form.ClientSize = new Size(System.Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = button;
            form.CancelButton = button2;
            DialogResult result = form.ShowDialog();
            value = textBox.Text;
            return result;
        }

        public int getStringDataFromdatasetByBinarySearch(DataSet ds, string colName, int start, int end, string searchValue)
        {
            int num = (start + end) / 2;
            if (num < 0 || num >= ds.Tables[0].Rows.Count)
            {
                return -1;
            }
            string text = ds.Tables[0].Rows[num][colName].ToString();
            if (text == searchValue)
            {
                return num;
            }
            if (start >= end)
            {
                return -1;
            }
            if (text.CompareTo(searchValue) < 0)
            {
                return this.getStringDataFromdatasetByBinarySearch(ds, colName, num + 1, end, text);
            }
            return this.getStringDataFromdatasetByBinarySearch(ds, colName, start, num - 1, text);
        }

        public static void getClrData(Control b)
        {
            foreach (Control ctrl in b.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = "";
                else if (ctrl is ComboBox) ctrl.Text = "";
                else if (ctrl is RichTextBox) ctrl.Text = "";
                else if (ctrl is MaskedTextBox) ctrl.Text = "";
                else if (ctrl is ListBox) ((ListBox)ctrl).Items.Clear();
                else if (ctrl is CheckBox) ((CheckBox)ctrl).Checked = false;
                if (ctrl.HasChildren) CConfig.getClrData(ctrl);
            }
        }
        public static string getDateDiffShort(DateTime fromDate, DateTime endDate, bool isDetails)
        {
            string strText = "";
            int intY = Convert.ToInt32((endDate.Date - fromDate.Date).TotalDays / 365.0);
            if (intY > 0)
            {
                if (fromDate.AddYears(intY).Date <= endDate.Date) fromDate = fromDate.AddYears(intY);
                else
                {
                    intY--;
                    fromDate = fromDate.AddYears(intY);
                }
            }
            int intM = Convert.ToInt32((endDate.Date - fromDate.Date).TotalDays / 30.0);
            if (intM > 0)
            {
                if (fromDate.AddMonths(intM).Date <= endDate.Date) fromDate = fromDate.AddMonths(intM);
                else
                {
                    intM--;
                    fromDate = fromDate.AddMonths(intM);
                }
            }
            int intD = Convert.ToInt32((endDate.Date - fromDate.Date).TotalDays);
            if (isDetails)
            {
                if (intY > 0) strText = intY.ToString() + " Y";
                if (intM > 0) strText += " " + intM.ToString() + " M";
                if (intD > 0) strText += " " + intD.ToString() + " D";
                strText = strText.Trim();
            }
            else strText = intY.ToString() + "-" + intM.ToString() + "-" + intD.ToString();
            return strText;
        }
        public static string getDateDiff(System.DateTime fromDate, System.DateTime endDate, bool isDetails)
        {
            string strText = "";
            int intY = System.Convert.ToInt32((endDate.Date - fromDate.Date).TotalDays / 365.0);
            if (intY > 0)
            {
                if (fromDate.AddYears(intY).Date <= endDate.Date)
                {
                    fromDate = fromDate.AddYears(intY);
                }
                else
                {
                    intY--;
                    fromDate = fromDate.AddYears(intY);
                }
            }
            int intM = System.Convert.ToInt32((endDate.Date - fromDate.Date).TotalDays / 30.0);
            if (intM > 0)
            {
                if (fromDate.AddMonths(intM).Date <= endDate.Date)
                {
                    fromDate = fromDate.AddMonths(intM);
                }
                else
                {
                    intM--;
                    fromDate = fromDate.AddMonths(intM);
                }
            }
            int intD = System.Convert.ToInt32((endDate.Date - fromDate.Date).TotalDays);
            if (isDetails)
            {
                if (intY > 0)
                {
                    if (intY == 1)
                    {
                        strText = intY.ToString() + " Year";
                    }
                    else
                    {
                        strText = intY.ToString() + " Years";
                    }
                }
                if (intM > 0)
                {
                    if (intM == 1)
                    {
                        strText = strText + " " + intM.ToString() + " Month";
                    }
                    else
                    {
                        strText = strText + " " + intM.ToString() + " Months";
                    }
                }
                if (intD > 0)
                {
                    if (intD == 1)
                    {
                        strText = strText + " " + intD.ToString() + " Day";
                    }
                    else
                    {
                        strText = strText + " " + intD.ToString() + " Days";
                    }
                }
                strText = strText.Trim();
            }
            else
            {
                strText = intY.ToString()+"-"+intM.ToString()+"-"+intD.ToString();
            }
            return strText;
        }
        public static void getExportDataToExcel(DataGridView dgvSchema, string sFileName)
        {
            SaveFileDialog sfdExport = new SaveFileDialog();
            sfdExport.InitialDirectory = Application.ExecutablePath.ToString();
            sfdExport.Filter = "CSV Files (*.csv)|*.csv|CSV (MS-DOS) (*.csv)|*.csv|CSV (Machintosh) (*.csv)|*.csv|CSV (Comma delimited) (*.csv)|*.csv|Excel Add-in (*.xlam)|*.xlam|Excel Template (*.xltx)|*.xltx|Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Add-in (*.xla)|*.xla|Excel 97-2003 Template (*.xlt)|*.xlt|Excel 97-2003 Workbook (*.xls)|*.xls|Excel Binary Workbook (*.xlsb)|*.xlsb|Excel Macro-Enabled Template (*.xltm)|*.xltm|Excel Macro-Enabled Workbook (*.xlsm)|*.xlsm|XML Data (*.xml)|*.xml|XPS Documents (*.xps)|*.xps|XML Spreadsheet 2003 (*.xml)|*.xml|Unicode Text (*.txt)|*.txt|Text (MS-DOS) (*.txt)|*.txt|Text Documents (*.txt)|*.txt|Text (Machintosh) (*.txt)|*.txt|Text (Tab delimited) (*.txt)|*.txt|OpenDocument Spreadsheet (*.ods)|*.ods|Strict Open XML Spreadsheet (*.xlsx)|*.xlsx|PDF(*.pdf)|*.pdf|All files (*.*)|*.*";
            sfdExport.FileName = sFileName.ToString();
            sfdExport.FilterIndex = 1;
            sfdExport.RestoreDirectory = true;
            if (sfdExport.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfdExport.FileName, false, Encoding.Unicode);
                sw.WriteLine(dgvColNames(dgvSchema, "\t"));
                foreach (DataGridViewRow dr in dgvSchema.Rows)
                {
                    string strCel = "";
                    bool bFlag = false;
                    int col = dgvSchema.ColumnCount;
                    for (int i = 0; i < col; i++)
                    {
                        DataGridViewColumn dgvCol = dgvSchema.Rows[0].Cells[i].OwningColumn;
                        if (dgvCol.Visible)
                        {
                            if (bFlag) strCel += "\t";
                            if (dr.Cells[i].Value == null) break;
                            if (dr.Cells[i].Value.ToString().Contains("\r\n")) dr.Cells[i].Value = dr.Cells[i].Value.ToString().Replace("\r\n", "-");
                            strCel += dr.Cells[i].Value.ToString();
                            bFlag = true;
                        }
                    }
                    sw.WriteLine(strCel);
                }
                sw.Close();
                MessageBox.Show("Action Perform Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private static string dgvColNames(DataGridView dgvSchemaTable, string delimiter)
        {
            bool bFlag = false;
            string strOut = "";
            if (delimiter.ToLower() == "tab") delimiter = "\t";
            for (int i = 0; i < dgvSchemaTable.ColumnCount; i++)
            {
                DataGridViewColumn dgvCol = dgvSchemaTable.Rows[0].Cells[i].OwningColumn;
                if (dgvCol.Visible)
                {
                    if (bFlag) strOut += delimiter;
                    strOut += dgvCol.Name.ToString();
                    bFlag = true;
                }
            }
            return strOut;
        }

        public static void UploadTextFile(Control ctrlName)
        {
            string FilePath;
            OpenFileDialog ofdEmpCode = new OpenFileDialog();
            ofdEmpCode.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            ofdEmpCode.Filter = "Text only. |*.TXT;";
            if (ofdEmpCode.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Are You Sure To Upload Employee List From TXT File (" + ofdEmpCode.FileName + ")", "Upload .TXT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    FilePath = ofdEmpCode.FileName;
                    string[] lines = File.ReadAllLines(FilePath);
                    foreach (string line in lines)
                    {
                        if (ctrlName.ToString().Contains("ListBox"))
                        {
                            ListBox objCtrl = (ListBox)ctrlName;
                            objCtrl.Items.Add(line);
                        }
                        else if (ctrlName.ToString().Contains("DataGridView"))
                        {
                            DataGridView objCtrl = (DataGridView)ctrlName;
                            objCtrl.Rows.Add(line, line, "EmpCode");
                        }
                    }
                }
            }
        }

        public static void getEmpCode(Control ctrlFor, TextBox txtCode, Label lblEmpName)
        {
            DBClass db = new DBClass();
            string strQuery = "SELECT EMP_NAME FROM EMP_OFFICIAL WHERE EMP_CODE = '" + txtCode.Text.Trim() + "'";
            DataSet ds = db.GetDataSet(strQuery);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lblEmpName.Text = dr["EMP_NAME"].ToString();
                if (ctrlFor.ToString().Contains("ListBox"))
                {
                    ListBox objCtrl = (ListBox)ctrlFor;
                    objCtrl.Items.Add(txtCode.Text);
                }
                else if (ctrlFor.ToString().Contains("DataGridView"))
                {
                    DataGridView objCtrl = (DataGridView)ctrlFor;
                    objCtrl.Rows.Add(txtCode.Text, txtCode.Text, "EmpCode");
                }
                txtCode.Clear();
                txtCode.Focus();
            }
        }
        private static void releaseObject(object obj)
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
        public static bool getParmisionSpecificEmployee(string strEmpCode)
        {
            bool Result = false;
            DBClass db = new DBClass();
            if (CConfig.MASTER_TAG == 0) Result = true;
            else
            {
                string strQuery = "SELECT COMPANY_ID FROM TB_UNIT WHERE COMPANY_ID = '"+CConfig.MASTER_TAG+"' AND UNIT_ID IN (SELECT UNIT_ID FROM EMP_OFFICIAL WHERE EMP_CODE = '" + strEmpCode + "')";
                DataSet ds = db.GetDataSet(strQuery);
                if(ds.Tables[0].Rows.Count>0)
                {
                    if ((int)Convert.ToInt16(ds.Tables[0].Rows[0]["COMPANY_ID"]) == CConfig.MASTER_TAG) Result = true;
                    else MessageBox.Show("You do not have the permission to access (" + strEmpCode + ")");
                }
            }
            return Result;
        }
    }
}
