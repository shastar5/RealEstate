﻿using System;

namespace RealEstate
{
    public partial class BuildingReport : MetroFramework.Forms.MetroForm, IdInterface
    {
        private int id;
        public BuildingReport()
        {
            InitializeComponent();
        }

        private void BuildingReport_Load(object sender, EventArgs e)
        {
            label1.Text = id.ToString();
            
            // TODO: 이 코드는 데이터를 'GoogleMySql.info1' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.info1TableAdapter.Fill(this.GoogleMySql.info1);
            // TODO: 이 코드는 데이터를 'GoogleMySql.info2' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.info2TableAdapter.Fill(this.GoogleMySql.info2);
            // TODO: 이 코드는 데이터를 'GoogleMySql.comment' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.commentTableAdapter.Fill(this.GoogleMySql.comment);
            // TODO: 이 코드는 데이터를 'GoogleMySql.memo' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.memoTableAdapter.Fill(this.GoogleMySql.memo);
            // TODO: 이 코드는 데이터를 'GoogleMySql.pictures' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.picturesTableAdapter.Fill(this.GoogleMySql.pictures);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            reportViewer1.PrintDialog();
        }

        public void setID(int id)
        {
            this.id = id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
