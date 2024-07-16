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
    public partial class ucProduct : UserControl
    {
        DBClass db = new DBClass();
        public ucProduct()
        {
            InitializeComponent();
            GetCategory();
            GetUom();

        }
        private void ucProduct_Load(object sender, EventArgs e)
        {
            // Clear the DataGridView to avoid duplication
            dgvProd.Rows.Clear();
            // Retrieve data into grid
            string strSql = @"SELECT p.PROD_ID, p.PROD_CODE, p.PROD_NAME, c.CATE_NAME, u.UOM_NAME, p.IS_ACTIVE 
                      FROM tb_product p 
                      JOIN tb_category c ON p.CATE_ID = c.CATE_ID 
                      JOIN tb_uom u ON p.UOM_ID = u.UOM_ID";

            DataSet ds = db.GetDataSet(strSql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var uomId = ds.Tables[0].Rows[i]["PROD_ID"];
                    var prodCode = ds.Tables[0].Rows[i]["PROD_CODE"];
                    var prodName = ds.Tables[0].Rows[i]["PROD_NAME"];
                    var category = ds.Tables[0].Rows[i]["CATE_NAME"];
                    var uom = ds.Tables[0].Rows[i]["UOM_NAME"];
                    var isActive = ds.Tables[0].Rows[i]["IS_ACTIVE"];
                    dgvProd.Rows.Add(uomId, prodCode, prodName, category, uom, isActive);
                }
            }

        }
        private void GetCategory()
        {
            string strSql = "SELECT CATE_ID,CATE_NAME FROM TB_CATEGORY ORDER BY CATE_NAME";
            DataSet ds = db.GetDataSet(strSql);
            if(ds.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int value = Convert.ToInt32(ds.Tables[0].Rows[i]["CATE_ID"]);
                    string key = ds.Tables[0].Rows[i]["CATE_NAME"].ToString();
                    cmbCate.Items.Add(new KeyValuePair<string, int>(key, value));
                }
            }
            cmbCate.DisplayMember = "Key";
            cmbCate.ValueMember = "Value";
        }

        private void GetUom()
        {
            string strSql = "SELECT * FROM TB_UOM ORDER BY UOM_NAME";
            DataSet ds = db.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int value = Convert.ToInt32(ds.Tables[0].Rows[i]["UOM_ID"]);
                    string key = ds.Tables[0].Rows[i]["UOM_NAME"].ToString();
                    cmbUom.Items.Add(new KeyValuePair<string, int>(key, value));
                }
            }
            cmbUom.DisplayMember = "Key";
            cmbUom.ValueMember = "Value";
        }

    
        private void cmbCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCate.Text.Length == 0)
            {
                cmbCate.SelectedIndex = -1;
            }
            else { 
            KeyValuePair<string, int> sItemVal = (KeyValuePair<string, int>)cmbCate.SelectedItem;
            cmbCate.Tag = sItemVal.Value;
            cmbCate.Text = sItemVal.Key;
            }
        }

        private void cmbUom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUom.Text.Length == 0)
            {
                cmbUom.SelectedIndex = -1;
            }
            else
            {
                KeyValuePair<string, int> sItemVal = (KeyValuePair<string, int>)cmbUom.SelectedItem;
                cmbUom.Tag = sItemVal.Value;
                cmbUom.Text = sItemVal.Key;
            }
        }



        //Validation check function 
        private bool GetValidation()
        {
            if (txtProd_code.Text.Trim() == "")    // Product code
            {
                MessageBox.Show("Product Code field is required.");
                txtProd_code.Focus();
                txtProd_code.BackColor = Color.Honeydew;
                return false;
            }
            if (txtProd_name.Text.Trim() == "")    // Product Name 
            {
                MessageBox.Show("Product name field is required.");
                txtProd_name.Focus();
                txtProd_name.BackColor = Color.Honeydew;
                return false;
            }
            if (cmbCate.Text.Length == 0)       //Product Category
            {
                MessageBox.Show("Product Category field is required.");
                cmbCate.Focus();
                cmbCate.BackColor = Color.Honeydew;
                return false;
            }
            if (cmbUom.Text.Length == 0)    //UOM 
            {
                MessageBox.Show("UOM field is required.");
                cmbUom.Focus();
                cmbUom.BackColor = Color.Honeydew;
                return false;
            }
            
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
                // Check if the text box is not empty
                if (GetValidation())
                {
                    string prodCode = txtProd_code.Text;
                    string prodName = txtProd_name.Text;
                    string category = cmbCate.Tag.ToString();
                    string uom = cmbUom.Tag.ToString();
                    string isActive = CB_isActive.Checked ? "Y" : "N";

                    //added for show cat_name, and uom_name in the dgv
                    string categoryName = cmbCate.Text;
                    string uomName = cmbUom.Text; 

                    int id = 0;
                    
                    // Get the next CATE_ID
                    DataSet ds = db.GetDataSet("SELECT (NVL(MAX(PROD_ID), 0) + 1) AS PROD_ID FROM tb_product");
                    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        id = Convert.ToInt32(ds.Tables[0].Rows[0]["PROD_ID"]);
                    }

                    // Create the INSERT SQL query string
                    string strSQL = "INSERT INTO tb_product (PROD_ID, PROD_CODE, PROD_NAME, CATE_ID, UOM_ID, IS_ACTIVE) VALUES ('" 
                        + id + "','" + prodCode + "', '" + prodName + "', '"+ category + "', '"+ uom + "', '"+isActive+"')";

                    // Execute the non-query
                    if (db.RunDmlQuery(strSQL))
                    {
                        // Add data into grid
                        dgvProd.Rows.Add(id, prodCode, prodName, categoryName, uomName, isActive);
                        
                        // Clear input fields
                        txtProd_code.Clear();
                        txtProd_name.Clear();
                        cmbCate.SelectedIndex = -1;
                        cmbUom.SelectedIndex = -1; 
                        CB_isActive.Checked = false;

                        MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Failed to add Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Product name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvProd.Rows.Clear();

            // Get the search text
            string subquary = "";
            string status = CB_isActive.Checked ? "Y" : "N";


            // Check if the text box is not empty
            if (txtProd_name.Text.Trim() != "") subquary = subquary + " and LOWER(p.PROD_NAME) = '" + txtProd_name.Text.ToLower() + "'";
            if (txtProd_code.Text.Trim() != "") subquary = subquary + " and LOWER(p.PROD_CODE) = '" + txtProd_code.Text.ToLower() + "'";
            if (cmbCate.Text.Trim() != "") subquary = subquary + " and p.CATE_ID = '" + cmbCate.Tag.ToString() + "'";
            if (cmbUom.Text.Trim() != "") subquary = subquary + " and p.UOM_ID = '" + cmbUom.Tag.ToString() + "'";
            subquary = subquary + " and p.IS_ACTIVE = '" + status + "'";


            // Retrieve categories matching the search text
           string strSql = @"SELECT p.PROD_ID, p.PROD_CODE, p.PROD_NAME, c.CATE_NAME, u.UOM_NAME, p.IS_ACTIVE 
                      FROM tb_product p, tb_category c, tb_uom u
                      WHERE p.CATE_ID = c.CATE_ID AND p.UOM_ID = u.UOM_ID" + subquary;
            DataSet ds = db.GetDataSet(strSql);

            // Retrieve data into grid
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                   var uomId = ds.Tables[0].Rows[i]["PROD_ID"];
                   var prodCode = ds.Tables[0].Rows[i]["PROD_CODE"];
                   var prodName = ds.Tables[0].Rows[i]["PROD_NAME"];
                   var category = ds.Tables[0].Rows[i]["CATE_NAME"];
                   var uom = ds.Tables[0].Rows[i]["UOM_NAME"];
                   var isActive = ds.Tables[0].Rows[i]["IS_ACTIVE"];

                    // Add a new row to the DataGridView
                    dgvProd.Rows.Add();
                    dgvProd.Rows[i].Cells["PROD_CODE"].Value = prodCode;
                    dgvProd.Rows[i].Cells["PROD_NAME"].Value = prodName;
                    dgvProd.Rows[i].Cells["PROD_CATE"].Value = category;
                    dgvProd.Rows[i].Cells["PROD_UOM"].Value = uom;
                    dgvProd.Rows[i].Cells["STATUS"].Value = isActive;
                }
            }
            else
            {
                MessageBox.Show("No Product found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a cell or row is selected
            if (dgvProd.SelectedRows.Count > 0)
            {
                int prodId = 0; bool b = false;
                for (int i = 0; i < dgvProd.SelectedRows.Count; i++)
                {
                    prodId = Convert.ToInt32(dgvProd.SelectedRows[i].Cells["ID"].Value);
                    string strSQL = "DELETE FROM tb_product WHERE PROD_ID = " + prodId;
                    b = db.RunDmlQuery(strSQL);
                }

                if (b)
                {
                    // Remove the selected row from the DataGridView

                    dgvProd.Rows.Clear();

                    MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Please select product to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            {
                //DO: Edit data into uom table
                // Ensure a cell or row is selected
                if (dgvProd.Rows.Count > 0)
                {
                    bool b = false;
                    int prodId = 0;
                    
                    for (int i = 0; i < dgvProd.Rows.Count; i++)
                    {
                        if (dgvProd.Rows[i].Cells["FLAG"].Value != null && dgvProd.Rows[i].Cells["FLAG"].Value.ToString() == "U")
                        {
                            prodId = Convert.ToInt32(dgvProd.Rows[i].Cells["ID"].Value);
                            string prodName = dgvProd.Rows[i].Cells["PROD_NAME"].Value.ToString();
                            string prodCode = dgvProd.Rows[i].Cells["PROD_CODE"].Value.ToString();
                            string status = dgvProd.Rows[i].Cells["STATUS"].Value.ToString();

                            string strSQL = "UPDATE tb_product SET PROD_NAME = '" + prodName + "', PROD_CODE = '" + prodCode + "', IS_ACTIVE = '" + status + "' WHERE PROD_ID = " + prodId;

                            b = db.RunDmlQuery(strSQL);
                        }
                    }
                    if (b)
                    {
                        // Remove the selected row from the DataGridView

                        dgvProd.Rows.Clear();
                        MessageBox.Show("PRODUCT updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select PRODUCT to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //placeing Flag for cell end edit 
        private void dgvProd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) dgvProd.Rows[e.RowIndex].Cells["FLAG"].Value = "U";
        }

        

    }
}
