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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.realestateDataSet = new RealEstate.realestateDataSet();
            this.info1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.info1TableAdapter = new RealEstate.realestateDataSetTableAdapters.info1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.realestateDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.info1BindingSource)).BeginInit();
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
            // realestateDataSet
            // 
            this.realestateDataSet.DataSetName = "realestateDataSet";
            this.realestateDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // info1BindingSource
            // 
            this.info1BindingSource.DataMember = "info1";
            this.info1BindingSource.DataSource = this.realestateDataSet;
            // 
            // info1TableAdapter
            // 
            this.info1TableAdapter.ClearBeforeFill = true;
            // 
            // buildingreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 725);
            this.Controls.Add(this.reportViewer1);
            this.Name = "buildingreport";
            this.Text = "buildingreport";
            this.Load += new System.EventHandler(this.buildingreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.realestateDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.info1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource info1BindingSource;
        private realestateDataSet realestateDataSet;
        private realestateDataSetTableAdapters.info1TableAdapter info1TableAdapter;
    }
}