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
        private void ucUom_Load(object sender, EventArgs e)
        {
            // Clear the DataGridView to avoid duplication
            dgvUOM.Rows.Clear();
            // Retrieve data into grid
            DataSet ds = db.GetDataSet("SELECT * FROM tb_uom");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var uomId = ds.Tables[0].Rows[i]["uom_ID"];
                    var uomName = ds.Tables[0].Rows[i]["uom_NAME"];
                    dgvUOM.Rows.Add(uomId, uomName);
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
                        dgvProd.Rows.Add(prodCode, prodName, category, uom, isActive);
                        
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

    }
}
