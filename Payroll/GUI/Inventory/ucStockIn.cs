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
    public partial class ucStockIn : UserControl
    {
        DBClass db = new DBClass();

        public ucStockIn()
        {
            InitializeComponent();
            GetProduct();
        }

        private void ucStockIn_Load(object sender, EventArgs e)
        {
            // Clear the DataGridView to avoid duplication
            dgvProd.Rows.Clear();
            // Retrieve data into grid
            string strSql = @"SELECT p.PROD_ID, p.PROD_CODE, p.PROD_NAME, c.CATE_NAME, u.UOM_NAME, s.po_date, s.po_rate, s.po_quantity
                      FROM tb_product p, tb_category c, tb_uom u , tb_stock_in s
                       WHERE p.CATE_ID = c.CATE_ID AND p.UOM_ID = u.UOM_ID AND s.PROD_ID = p.PROD_ID";

            DataSet ds = db.GetDataSet(strSql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var productId = ds.Tables[0].Rows[i]["PROD_ID"];
                    var str_POdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["PO_DATE"]).ToString("dd-MMM-yyyy");
                    var prodCode = ds.Tables[0].Rows[i]["PROD_CODE"];
                    var prodName = ds.Tables[0].Rows[i]["PROD_NAME"];
                    var category = ds.Tables[0].Rows[i]["CATE_NAME"];
                    var uom = ds.Tables[0].Rows[i]["UOM_NAME"];
                    var str_rate = ds.Tables[0].Rows[i]["PO_RATE"];
                    var str_quantity = ds.Tables[0].Rows[i]["PO_QUANTITY"];
                    dgvProd.Rows.Add(productId, str_POdate, prodCode, prodName, category, uom, str_rate, str_quantity);
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

        private bool GetValidation()
        {
            if (cmbProd.Text.Trim() == "")    // Product Name
            {
                MessageBox.Show("Product field is required.");
                cmbProd.Focus();
                cmbProd.BackColor = Color.Honeydew;
                return false;
            }
            if (txtProd_rate.Text.Trim() == "")    // Product rate 
            {
                MessageBox.Show("Product rate field is required.");
                txtProd_rate.Focus();
                txtProd_rate.BackColor = Color.Honeydew;
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
                string str_rate = txtProd_rate.Text;
                string str_quantity = txtProd_qty.Text;
                string str_POdate = dtpDate.Value.ToString("dd-MMM-yyyy");

                // Create the INSERT SQL query string
                string strSQL = "INSERT INTO tb_stock_in (PROD_ID, PO_DATE, PO_RATE, PO_QUANTITY) VALUES ('"
                    + str_product + "', '" + str_POdate + "', '" + str_rate + "', '" + str_quantity + "')";

                // Execute the non-query
                if (db.RunDmlQuery(strSQL))
                {
                    string strSql = @"SELECT p.PROD_ID, p.PROD_CODE, p.PROD_NAME, c.CATE_NAME, u.UOM_NAME, p.IS_ACTIVE 
                      FROM tb_product p, tb_category c, tb_uom u
                      WHERE p.CATE_ID = c.CATE_ID AND p.UOM_ID = u.UOM_ID AND p.PROD_ID = '"+ str_product + "'";
                    DataSet ds = db.GetDataSet(strSql);

                    // Retrieve data into grid
                    if (ds.Tables[0].Rows.Count > 0)
                    { 
                        // Add data into grid
                        string productCode = ds.Tables[0].Rows[0]["PROD_CODE"].ToString();
                        string productName = ds.Tables[0].Rows[0]["PROD_NAME"].ToString();
                        string productCate = ds.Tables[0].Rows[0]["CATE_NAME"].ToString();
                        string productUom = ds.Tables[0].Rows[0]["UOM_NAME"].ToString();
                       
                        //dgvProd.Rows.Add(productCode, productCate,productUom, cmbProd.Text, str_rate, str_quantity, str_POdate);
                        dgvProd.Rows.Add();
                        dgvProd.Rows[0].Cells["PO_DATE"].Value = str_POdate;
                        dgvProd.Rows[0].Cells["PROD_CODE"].Value = productCode;
                        dgvProd.Rows[0].Cells["PROD_NAME"].Value = productName;
                        dgvProd.Rows[0].Cells["PROD_CATE"].Value = productCate;
                        dgvProd.Rows[0].Cells["PROD_UOM"].Value = productUom;
                        dgvProd.Rows[0].Cells["PROD_RATE"].Value = str_rate;
                        dgvProd.Rows[0].Cells["PROD_QTY"].Value = str_quantity;
                    }
                        

                    // Clear input fields
                    cmbProd.SelectedIndex = -1;
                    txtProd_rate.Clear();
                    txtProd_qty.Clear();
                  

                    MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed to add Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Product name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        
    }
}
