using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace NGPayroll
{
    public partial class ucCategory : UserControl
    {
        DBClass db = new DBClass();
        public ucCategory()
        {
            InitializeComponent();
        }
        private void ucCategory_Load(object sender, EventArgs e)
        {
            // Clear the DataGridView to avoid duplication
            dgvCate.Rows.Clear();
            // Retrieve data into grid
            DataSet ds = db.GetDataSet("SELECT * FROM tb_category");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var cateId = ds.Tables[0].Rows[i]["CATE_ID"];
                    var cateName = ds.Tables[0].Rows[i]["CATE_NAME"];
                    dgvCate.Rows.Add(cateId, cateName);
                }
            }
        }
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    int id = 0;
        //    string text = txtCate.Text;
        //    //DO: insert data into category table
        //    DataSet ds = db.GetDataSet("SELECT (NVL(MAX(CATE_ID),0)+1) AS CATE_ID FROM TB_CATEGORY");
        //    if (ds.Tables[0].Rows.Count > 0) id = Convert.ToInt32(ds.Tables[0].Rows[0]["CATE_ID"]);

        //    string strSQL = "INSERT INTO tb_category (CATE_ID, CATE_NAME) VALUES ('" + id + "', '" + text + "')";
        //    if (db.RunDmlQuery(strSQL))
        //    {
        //        //DO: Add data into grid 
        //        dgvCate.Rows.Add(id, txtCate.Text);
        //        txtCate.Clear();
        //    }
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the text box is not empty
                if (txtCate.Text.Trim() != "")
                {
                    string text = txtCate.Text;
                    int id = 0;

                    // Get the next CATE_ID
                    DataSet ds = db.GetDataSet("SELECT (NVL(MAX(CATE_ID), 0) + 1) AS CATE_ID FROM TB_CATEGORY");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        id = Convert.ToInt32(ds.Tables[0].Rows[0]["CATE_ID"]);
                    }

                    // Create the INSERT SQL query string
                    string strSQL = "INSERT INTO tb_category (CATE_ID, CATE_NAME) VALUES ('" + id + "', '" + text + "')";

                    // Execute the non-query
                    if (db.RunDmlQuery(strSQL))
                    {
                        // Add data into grid
                        dgvCate.Rows.Add(id, text);
                        txtCate.Clear();
                        MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Category name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear the DataGridView to show only the search results
                dgvCate.Rows.Clear();

                // Get the search text
                string subquary = "";
                string text = txtCate.Text.ToLower();                

                // Check if the text box is not empty
                if (txtCate.Text.Trim() != "") subquary = " and LOWER(cate_name) = '" + text + "'";

                // Retrieve categories matching the search text
                DataSet ds = db.GetDataSet("SELECT * FROM tb_category WHERE 1 = 1" + subquary);
                // Retrieve data into grid
                //DataSet ds = db.GetDataSet("select * from tb_category where cate_name='" + text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var cateId = ds.Tables[0].Rows[i]["CATE_ID"];
                        var cateName = ds.Tables[0].Rows[i]["CATE_NAME"];

                        // Add a new row to the DataGridView
                        dgvCate.Rows.Add();
                        dgvCate.Rows[i].Cells["ID"].Value = cateId;
                        dgvCate.Rows[i].Cells["CATE"].Value = cateName;
                    }
                }
                else
                {
                    MessageBox.Show("No categories found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            //DO: Edit data into category table
            // Ensure a cell or row is selected
            if (dgvCate.Rows.Count > 0)
            {
                int categoryId = 0; bool b = false;
                string categoryName = "";
                for (int i = 0; i < dgvCate.Rows.Count; i++)
                {
                    if (dgvCate.Rows[i].Cells["update"].Value != null && dgvCate.Rows[i].Cells["update"].Value.ToString() == "U")
                    {
                        categoryId = Convert.ToInt32(dgvCate.Rows[i].Cells["ID"].Value);
                        categoryName = dgvCate.Rows[i].Cells["CATE"].Value.ToString();

                        string strSQL = "UPDATE tb_category SET CATE_NAME = '" + categoryName + "' WHERE CATE_ID = " + categoryId;

                        b = db.RunDmlQuery(strSQL);
                    }
                }
                if (b)
                {
                    // Remove the selected row from the DataGridView

                    dgvCate.Rows.Clear();
                    MessageBox.Show("Category updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select category to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a cell or row is selected
                if (dgvCate.SelectedRows.Count > 0)
                {
                    int categoryId = 0; bool b = false;
                    for (int i = 0; i < dgvCate.SelectedRows.Count; i++)
                    {
                        categoryId = Convert.ToInt32(dgvCate.SelectedRows[i].Cells["ID"].Value);
                        string strSQL = "DELETE FROM tb_category WHERE CATE_ID = " + categoryId;
                         b = db.RunDmlQuery(strSQL);
                    }
                    if (b)
                    {
                        // Remove the selected row from the DataGridView

                        //dgvCate.ClearSelection();
                        dgvCate.Rows.Clear();                        

                        MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select category to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1) dgvCate.Rows[e.RowIndex].Cells["UPDATE"].Value="U";
        }
    }
}
