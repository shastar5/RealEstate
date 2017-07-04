namespace RealEstate
{
    partial class BuildingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildingReport));
            this.info1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GoogleMySql = new RealEstate.GoogleMySql();
            this.info2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.picturesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.info1TableAdapter = new RealEstate.GoogleMySqlTableAdapters.info1TableAdapter();
            this.info2TableAdapter = new RealEstate.GoogleMySqlTableAdapters.info2TableAdapter();
            this.commentTableAdapter = new RealEstate.GoogleMySqlTableAdapters.commentTableAdapter();
            this.memoTableAdapter = new RealEstate.GoogleMySqlTableAdapters.memoTableAdapter();
            this.picturesTableAdapter = new RealEstate.GoogleMySqlTableAdapters.picturesTableAdapter();
            this.tableAdapterManager = new RealEstate.GoogleMySqlTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.info1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoogleMySql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.info2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // info1BindingSource
            // 
            this.info1BindingSource.DataMember = "info1";
            this.info1BindingSource.DataSource = this.GoogleMySql;
            // 
            // GoogleMySql
            // 
            this.GoogleMySql.DataSetName = "GoogleMySql";
            this.GoogleMySql.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // info2BindingSource
            // 
            this.info2BindingSource.DataMember = "info2";
            this.info2BindingSource.DataSource = this.GoogleMySql;
            // 
            // commentBindingSource
            // 
            this.commentBindingSource.DataMember = "comment";
            this.commentBindingSource.DataSource = this.GoogleMySql;
            // 
            // memoBindingSource
            // 
            this.memoBindingSource.DataMember = "memo";
            this.memoBindingSource.DataSource = this.GoogleMySql;
            // 
            // picturesBindingSource
            // 
            this.picturesBindingSource.DataMember = "pictures";
            this.picturesBindingSource.DataSource = this.GoogleMySql;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(23, 18);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "인쇄";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(756, 18);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 1;
            this.metroButton2.Text = "나가기";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.info1BindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.info2BindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.commentBindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.memoBindingSource;
            reportDataSource5.Name = "DataSet5";
            reportDataSource5.Value = this.picturesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RealEstate.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(834, 693);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
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
            // picturesTableAdapter
            // 
            this.picturesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.commentTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.info1TableAdapter = null;
            this.tableAdapterManager.info2TableAdapter = null;
            this.tableAdapterManager.memoTableAdapter = null;
            this.tableAdapterManager.picturesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealEstate.GoogleMySqlTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // BuildingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 773);
            this.ControlBox = false;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildingReport";
            this.Load += new System.EventHandler(this.BuildingReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.info1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoogleMySql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.info2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource info1BindingSource;
        private GoogleMySql GoogleMySql;
        private System.Windows.Forms.BindingSource info2BindingSource;
        private System.Windows.Forms.BindingSource commentBindingSource;
        private System.Windows.Forms.BindingSource memoBindingSource;
        private System.Windows.Forms.BindingSource picturesBindingSource;
        private GoogleMySqlTableAdapters.info1TableAdapter info1TableAdapter;
        private GoogleMySqlTableAdapters.info2TableAdapter info2TableAdapter;
        private GoogleMySqlTableAdapters.commentTableAdapter commentTableAdapter;
        private GoogleMySqlTableAdapters.memoTableAdapter memoTableAdapter;
        private GoogleMySqlTableAdapters.picturesTableAdapter picturesTableAdapter;
        private GoogleMySqlTableAdapters.TableAdapterManager tableAdapterManager;
    }
}