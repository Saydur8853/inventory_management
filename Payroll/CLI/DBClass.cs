using System;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Collections.Generic;

namespace NGPayroll
{
    public class DBClass
    {
        public static string olePath = null;
        public static OracleConnection oCon;
        public static OleDbConnection oleCon;

        public string strConn = "user id=TG_" + ConfigurationManager.AppSettings["sID"] + "; password=TG_"
            + ConfigurationManager.AppSettings["sID"] + "; data source=" + ConfigurationManager.AppSettings["hostName"] + "/orcl";

        private string oleConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + olePath + @"; Persist  Security Info=False;";        
        
        #region =============== [Oracle Connection] ===============
        public DBClass()
        {
            oCon = new OracleConnection(strConn);
            oleCon = new OleDbConnection(oleConn);
        }
        private bool OpenConn()
        {
            try
            {
                if (oCon.State.Equals(ConnectionState.Closed))
                {
                    oCon.Open();
                }
                return true;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool CloseConn()
        {
            try
            {
                oCon.Close();
                return true;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public string GetUnitName()
        {
            string strName = "";
            string strSql = "SELECT DISTINCT UNIT_NAME FROM TB_UNIT ORDER BY UNIT_NAME";
            DataSet ds = GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0) strName = ds.Tables[0].Rows[0]["UNIT_NAME"].ToString();
            return strName;
        }        
        public string GetReportPath()
        {
            return ConfigurationManager.AppSettings["ReportsPath"];
        }
        public bool RunDmlQuery(string query)
        {
            try
            {
                this.CloseConn(); this.OpenConn();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oCon;
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                this.CloseConn();
                return true;
            }
            catch (OracleException ex)
            {
                if (ex.ErrorCode == 1830)
                {
                    query = "ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MON-YYYY HH24:MI:SS'";
                    if (RunDmlQuery(query))
                    {
                    }
                }
                else if (ex.ErrorCode == 1)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message + query, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }
        public DataSet GetDataSet(string query)
        {
            DataSet ds = null;
            try
            {
                this.CloseConn(); this.OpenConn();
                OracleCommand cmd = new OracleCommand();
                OracleDataAdapter adp = new OracleDataAdapter(query, oCon);
                ds = new DataSet();
                adp.Fill(ds); this.CloseConn();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }
        public string GetScalerReader(string query)
        {
            try
            {
                this.CloseConn(); this.OpenConn();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oCon;
                cmd.CommandText = query;
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                return dr["num_rows"].ToString();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.ToString();
            }
        }
        public OracleDataReader GetExecuteReader(string query)
        {
            OracleDataReader dr = null;
            try
            {
                this.CloseConn(); this.OpenConn();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oCon;
                cmd.CommandText = query;
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            //return dr;
        }
        #endregion
    }
}
