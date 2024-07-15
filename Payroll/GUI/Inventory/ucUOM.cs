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
    public partial class ucUom : UserControl
        
    {
        DBClass db = new DBClass();
        public ucUom()
        {
            InitializeComponent();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the text box is not empty
                if (txtUom.Text.Trim() != "")
                {
                    string text = txtUom.Text;
                    int id = 0;

                    // Get the next CATE_ID
                    DataSet ds = db.GetDataSet("SELECT (NVL(MAX(UOM_ID), 0) + 1) AS UOM_ID FROM tb_uom");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        id = Convert.ToInt32(ds.Tables[0].Rows[0]["UOM_ID"]);
                    }

                    // Create the INSERT SQL query string
                    string strSQL = "INSERT INTO tb_uom (UOM_ID, UOM_NAME) VALUES ('" + id + "', '" + text + "')";

                    // Execute the non-query
                    if (db.RunDmlQuery(strSQL))
                    {
                        // Add data into grid
                        dgvUOM.Rows.Add(id, text);
                        txtUom.Clear();
                        MessageBox.Show("uom added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Failed to add uom.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("uom name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dgvUOM.Rows.Clear();

                // Get the search text
                string subquary = "";
                string text = txtUom.Text.ToLower();

                // Check if the text box is not empty
                if (txtUom.Text.Trim() != "") subquary = " and LOWER(uom_name) = '" + text + "'";

                // Retrieve categories matching the search text
                DataSet ds = db.GetDataSet("SELECT * FROM tb_uom WHERE 1 = 1" + subquary);
                // Retrieve data into grid
                //DataSet ds = db.GetDataSet("select * from tb_uom where cate_name='" + text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var uomId = ds.Tables[0].Rows[i]["UOM_ID"];
                        var uomName = ds.Tables[0].Rows[i]["UOM_NAME"];

                        // Add a new row to the DataGridView
                        dgvUOM.Rows.Add();
                        dgvUOM.Rows[i].Cells["ID"].Value = uomId;
                        dgvUOM.Rows[i].Cells["UOM"].Value = uomName;
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
            {
                //DO: Edit data into uom table
                // Ensure a cell or row is selected
                if (dgvUOM.Rows.Count > 0)
                {
                    int uomId = 0; bool b = false;
                    string uomName = "";
                    for (int i = 0; i < dgvUOM.Rows.Count; i++)
                    {
                        if (dgvUOM.Rows[i].Cells["FLAG"].Value != null && dgvUOM.Rows[i].Cells["FLAG"].Value.ToString() == "U")
                        {
                            uomId = Convert.ToInt32(dgvUOM.Rows[i].Cells["ID"].Value);
                            uomName = dgvUOM.Rows[i].Cells["UOM"].Value.ToString();

                            string strSQL = "UPDATE tb_uom SET UOM_NAME = '" + uomName + "' WHERE UOM_ID = " + uomId;

                            b = db.RunDmlQuery(strSQL);
                        }
                    }
                    if (b)
                    {
                        // Remove the selected row from the DataGridView

                        dgvUOM.Rows.Clear();
                        MessageBox.Show("uom updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select uom to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dgvUOM_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) dgvUOM.Rows[e.RowIndex].Cells["FLAG"].Value = "U";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a cell or row is selected
                if (dgvUOM.SelectedRows.Count > 0)
                {
                    int uomId = 0; bool b = false;
                    for (int i = 0; i < dgvUOM.SelectedRows.Count; i++)
                    {
                        uomId = Convert.ToInt32(dgvUOM.SelectedRows[i].Cells["ID"].Value);
                        string strSQL = "DELETE FROM tb_uom WHERE UOM_ID = " + uomId;
                        b = db.RunDmlQuery(strSQL);
                    }
                    
                    if (b)
                    {
                        // Remove the selected row from the DataGridView

                       dgvUOM.Rows.Clear();                        
                      
                        MessageBox.Show("UOM deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please select UOM to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUOM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
