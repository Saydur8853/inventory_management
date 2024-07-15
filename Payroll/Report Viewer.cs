using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace NGPayroll
{
    public partial class CrystalReportViewerUC : UserControl
    {   
        public UserControl lastUserControlRptViewer;
        public CrystalReportViewerUC()
        {
            InitializeComponent();
        }
        private void btnExitRptViewerUC_Click(object sender, EventArgs e)
        {
            payroll_main_form mForm = this.ParentForm as payroll_main_form;
            mForm.splitContainer1.Panel2.Controls.Clear();
            mForm.splitContainer1.Panel2.Controls.Add(lastUserControlRptViewer);
            lastUserControlRptViewer.Show();            
        }
    }
}
