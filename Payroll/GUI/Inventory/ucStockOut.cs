using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NGPayroll
{
    public partial class ucStockOut : UserControl
    {
        DBClass db = new DBClass();

        public ucStockOut()
        {
            InitializeComponent();
            GetProduct();

        }
        private void ucStockOut_Load(object sender, EventArgs e)
        {
            // Clear the DataGridView to avoid duplication
            dgvProd.Rows.Clear();
            // Retrieve data into grid
            string strSql = @"SELECT p.PROD_ID, p.PROD_NAME, c.CATE_NAME, SUM(s.po_quantity) as total_quantity
                      FROM tb_product p, tb_category c , tb_stock_in s
                       WHERE p.CATE_ID = c.CATE_ID  AND s.PROD_ID = p.PROD_ID  
                       GROUP BY p.PROD_ID, p.PROD_NAME, c.CATE_NAME";

            DataSet ds = db.GetDataSet(strSql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var productId = ds.Tables[0].Rows[i]["PROD_ID"];
                    var prodName = ds.Tables[0].Rows[i]["PROD_NAME"];
                    var category = ds.Tables[0].Rows[i]["CATE_NAME"];
                    var str_quantity = ds.Tables[0].Rows[i]["total_quantity"];
                    dgvProd.Rows.Add(productId,"", prodName, category, str_quantity,"");
                }
            }

        }
        private void GetProduct()
        {
            string strSql = "SELECT PROD_ID,PROD_NAME FROM TB_PRODUCT ORDER BY PROD_NAME";
            DataSet ds = db.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int value = Convert.ToInt32(ds.Tables[0].Rows[i]["PROD_ID"]);
                    string key = ds.Tables[0].Rows[i]["PROD_NAME"].ToString();
                    cmbProd.Items.Add(new KeyValuePair<string, int>(key, value));
                }
            }
            cmbProd.DisplayMember = "Key";
            cmbProd.ValueMember = "Value";
        }


        private void cmbProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProd.Text.Length == 0)
            {
                cmbProd.SelectedIndex = -1;
            }
            else
            {
                KeyValuePair<string, int> sItemVal = (KeyValuePair<string, int>)cmbProd.SelectedItem;
                cmbProd.Tag = sItemVal.Value;
                cmbProd.Text = sItemVal.Key;
            }
        }


        private bool GetValidation()
        {
            if (cmbProd.Text.Trim() == "")    // Product Name
            {
                MessageBox.Show("Product field is required.");
                cmbProd.Focus();
                cmbProd.BackColor = Color.Honeydew;
                return false;
            }
            
            if (txtProd_qty.Text.Length == 0)       //Product quantity
            {
                MessageBox.Show("Product quantity field is required.");
                txtProd_qty.Focus();
                txtProd_qty.BackColor = Color.Honeydew;
                return false;
            }


            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if the text box is not empty
            if (GetValidation())
            {
                string str_product = cmbProd.Tag.ToString();
                string do_quantity = txtProd_qty.Text;
                string str_DOdate = dtpDate.Value.ToString("dd-MMM-yyyy");

                // Create the INSERT SQL query string
                string strSQL = "INSERT INTO TB_STOCK_OUT (PROD_ID, DEL_DATE, DEL_QUANTITY) VALUES ('"
                    + str_product + "', '" + str_DOdate + "', '" + do_quantity + "')";

                // Execute the non-query
                if (db.RunDmlQuery(strSQL))
                {
                    string strSql = @"SELECT p.PROD_ID, p.PROD_NAME, c.CATE_NAME, s.po_date, s.po_quantity, so.del_date, so.del_quantity, 
                                             SUM(s.po_quantity) - NVL(SUM(so.del_quantity), 0) as available_qty
                                      FROM tb_product p, tb_category c, tb_stock_in s, tb_stock_out so
                                      WHERE p.CATE_ID = c.CATE_ID 
                                         AND p.PROD_ID = s.PROD_ID 
                                         AND p.PROD_ID = so.PROD_ID(+)
                                         AND p.PROD_ID = '" + str_product + @"'
                                        GROUP BY p.PROD_ID, p.PROD_NAME, c.CATE_NAME, s.po_date, s.po_quantity, so.del_date, so.del_quantity";

                    DataSet ds = db.GetDataSet(strSql);

                    // Retrieve data into grid
                    //if (ds.Tables[0].Rows.Count > 0)
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        // Add data into grid
                        string productName = ds.Tables[0].Rows[0]["PROD_NAME"].ToString();
                        string productCate = ds.Tables[0].Rows[0]["CATE_NAME"].ToString();
                        string availableQty = ds.Tables[0].Rows[0]["AVAILABLE_QTY"].ToString();
                      
                        dgvProd.Rows.Add();
                        dgvProd.Rows[0].Cells["DO_DATE"].Value = str_DOdate;
                        dgvProd.Rows[0].Cells["PROD_NAME"].Value = productName;
                        dgvProd.Rows[0].Cells["PROD_CATE"].Value = productCate;
                        dgvProd.Rows[0].Cells["AVL_QTY"].Value = availableQty;
                        dgvProd.Rows[0].Cells["DO_QUANTITY"].Value = do_quantity;
                    }
                     
                     // Clear input fields
                    cmbProd.SelectedIndex = -1;
                    txtProd_qty.Clear();


                    MessageBox.Show("Product check out successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed to check out Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Product name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        
        
    }
}
