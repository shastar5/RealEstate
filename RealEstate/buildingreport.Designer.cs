namespace RealEstate
{
    partial class buildingreport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.info1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.realestateDataSet = new RealEstate.realestateDataSet();
            this.info2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.info1TableAdapter = new RealEstate.realestateDataSetTableAdapters.info1TableAdapter();
            this.info2TableAdapter = new RealEstate.realestateDataSetTableAdapters.info2TableAdapter();
            this.commentTableAdapter = new RealEstate.realestateDataSetTableAdapters.commentTableAdapter();
            this.memoTableAdapter = new RealEstate.realestateDataSetTableAdapters.memoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.info1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realestateDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.info2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.info1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RealEstate.estatereport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 51);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(713, 662);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.info1BindingSource;
            reportDataSource3.Name = "DataSet2";
            reportDataSource3.Value = this.info2BindingSource;
            reportDataSource4.Name = "DataSet3";
            reportDataSource4.Value = this.commentBindingSource;
            reportDataSource5.Name = "DataSet4";
            reportDataSource5.Value = this.memoBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "RealEstate.estatereport.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(1196, 725);
            this.reportViewer2.TabIndex = 1;
            // 
            // info1BindingSource
            // 
            this.info1BindingSource.DataMember = "info1";
            this.info1BindingSource.DataSource = this.realestateDataSet;
            this.info1BindingSource.CurrentChanged += new System.EventHandler(this.info1BindingSource_CurrentChanged);
            // 
            // realestateDataSet
            // 
            this.realestateDataSet.DataSetName = "realestateDataSet";
            this.realestateDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // info2BindingSource
            // 
            this.info2BindingSource.DataMember = "info2";
            this.info2BindingSource.DataSource = this.realestateDataSet;
            this.info2BindingSource.CurrentChanged += new System.EventHandler(this.info2BindingSource_CurrentChanged);
            // 
            // commentBindingSource
            // 
            this.commentBindingSource.DataMember = "comment";
            this.commentBindingSource.DataSource = this.realestateDataSet;
            this.commentBindingSource.CurrentChanged += new System.EventHandler(this.commentBindingSource_CurrentChanged);
            // 
            // memoBindingSource
            // 
            this.memoBindingSource.DataMember = "memo";
            this.memoBindingSource.DataSource = this.realestateDataSet;
            this.memoBindingSource.CurrentChanged += new System.EventHandler(this.memoBindingSource_CurrentChanged);
            // 
            // info1TableAdapter
            // 
            this.info1TableAdapter.ClearBeforeFill = true;
            // 
            // info2TableAdapter
            // 
            this.info2TableAdapter.ClearBeforeFill = true;
            // 
            // commentTableAdapter
            // 
            this.commentTableAdapter.ClearBeforeFill = true;
            // 
            // memoTableAdapter
            // 
            this.memoTableAdapter.ClearBeforeFill = true;
            // 
            // buildingreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 725);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "buildingreport";
            this.Text = "buildingreport";
            this.Load += new System.EventHandler(this.buildingreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.info1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realestateDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.info2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource info1BindingSource;
        private realestateDataSet realestateDataSet;
        private realestateDataSetTableAdapters.info1TableAdapter info1TableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource info2BindingSource;
        private realestateDataSetTableAdapters.info2TableAdapter info2TableAdapter;
        private System.Windows.Forms.BindingSource commentBindingSource;
        private System.Windows.Forms.BindingSource memoBindingSource;
        private realestateDataSetTableAdapters.commentTableAdapter commentTableAdapter;
        private realestateDataSetTableAdapters.memoTableAdapter memoTableAdapter;
    }
}