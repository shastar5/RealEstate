using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RealEstate
{

    public partial class buildingreport : Form, IdInterface, DBInterface, PicturInterface
    {
        private int id;
        string strConn2;
        private string DBFile;
        private string mode;

        public interface DBInterface
        {
            void setDBfile(string DBFile);
        }

        public interface PictureInterface
        {
            void setMode(string mode);
        }

        public interface IdInterface
        {
            void setID(int id);
        }

        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }

        public void setMode(string mode) //모드 계승
        {
            this.mode = mode;
        }

        public void setID(int id)
        {
            this.id = id;
        }

        public buildingreport()
        {
            InitializeComponent();
            
        }

        private void buildingreport_Load(object sender, EventArgs e)
        {
            strConn2 = MysqlIp.Logic.getStrConn();
            MySqlConnection con = new MySqlConnection(strConn2);
            MySqlDataAdapter info1, info2, memo, comment;

            con.Open();
            
            info1 = new MySqlDataAdapter("select * from info1 where id = "+id, con);
            info2 = new MySqlDataAdapter("select * from info2 where buildingId = " + id, con);
            comment = new MySqlDataAdapter("select * from comment where buildingId = " + id, con);
            memo = new MySqlDataAdapter("select * from memo where buildingId = " + id, con);
            
            DataTable info1dt = new DataTable();
            info1.Fill(info1dt);
            info1BindingSource.DataSource = info1dt;

            DataTable info2dt = new DataTable();
            info2.Fill(info2dt);
            info2BindingSource.DataSource = info2dt;

            DataTable commentdt = new DataTable();
            comment.Fill(commentdt);
            commentBindingSource.DataSource = commentdt;
            /*
            DataTable memodt = new DataTable();
            memo.Fill(memodt);
            memoBindingSource.DataSource = memodt;
            con.Close();
            */

            con.Close();

            realestateDataSet.setID(Convert.ToInt32(id));
            this.memoTableAdapter.Fill(this.realestateDataSet.memo);
            /*
            // TODO: 이 코드는 데이터를 'realestateDataSet.comment' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.commentTableAdapter.Fill(this.realestateDataSet.comment);
            // TODO: 이 코드는 데이터를 'realestateDataSet.memo' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.memoTableAdapter.Fill(this.realestateDataSet.memo);
            
            // TODO: 이 코드는 데이터를 'realestateDataSet.info2' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.info2TableAdapter.Fill(this.realestateDataSet.info2);
            // TODO: 이 코드는 데이터를 'realestateDataSet.info1' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.info1TableAdapter.Fill(this.realestateDataSet.info1);
            */
            this.reportViewer2.RefreshReport();
        }

        private void info1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void info2BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void memoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void commentBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }


    }
}
