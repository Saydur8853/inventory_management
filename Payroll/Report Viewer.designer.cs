namespace NGPayroll
{
    partial class CrystalReportViewerUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnExitRptViewerUC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1087, 569);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // btnExitRptViewerUC
            // 
            this.btnExitRptViewerUC.Location = new System.Drawing.Point(982, 575);
            this.btnExitRptViewerUC.Name = "btnExitRptViewerUC";
            this.btnExitRptViewerUC.Size = new System.Drawing.Size(105, 33);
            this.btnExitRptViewerUC.TabIndex = 1;
            this.btnExitRptViewerUC.Text = "Exit";
            this.btnExitRptViewerUC.UseVisualStyleBackColor = true;
            this.btnExitRptViewerUC.Click += new System.EventHandler(this.btnExitRptViewerUC_Click);
            // 
            // report_viewer_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExitRptViewerUC);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "report_viewer_UC";
            this.Size = new System.Drawing.Size(1090, 622);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnExitRptViewerUC;
    }
}
