using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace RealEstate
{

    public partial class ManagerView : Form, DBInterface
    {
        //전체 보이는용 변수
        string DBFile;
        string addr;
        string roadAddr;
        string area;
        string station;
        string useArea;
        string totalArea;
        string completeYear;
        string parking;
        string acHeating;
        string EV;

        //관리자용 변수
        string owner;
        string tel;
        string meno;
        double deposit;
        double Income;
        double loan;
        double interest;
        double takeOverPrice;
        double sellPrice;
        double payedPrice;
        double yearPercent;

        // Database keyword declare
        SQLiteCommand sqlCMD;
        SQLiteConnection cn;
        SQLiteDataReader sqlReader;
        SQLiteDataAdapter adapter;
        DataGridView dgv;
        DataTable dt;

        private void saveDataGrid()
        {
            dt = new DataTable();

            cn.Open();
            sqlCMD = cn.CreateCommand();

            // 이 부분 수정할 것. buildingID = ID로 수정해야됨
            sqlCMD.CommandText = string.Format("SELECT * FROM info2");
            adapter = new SQLiteDataAdapter(sqlCMD);
            adapter.Fill(dt);
            adapter.Update(dt);

            cn.Close();
        }

        // DataGridView 설정
        private void readDataGrid()
        {
            dt = new DataTable();
            int i = 0, j = 0;
            string DBFile;
            string strConn = "";
            string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            deskPath = deskPath.Replace("\\", "/"); //\\글자 /로 바꾸기
            DBFile = deskPath + @"/DB.db";
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;

            cn.Open();
            sqlCMD = cn.CreateCommand();

            // 이 부분 수정할 것. buildingID = ID로 수정해야됨
            sqlCMD.CommandText = "SELECT * FROM info2 WHERE buildingID";
            sqlReader = sqlCMD.ExecuteReader();

            adapter = new SQLiteDataAdapter(sqlCMD);
            adapter.Fill(dt);
            dgv.DataSource = dt;

            // 오름차순으로 정렬
            dgv.Sort(dgv.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            cn.Close();
        }

        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }

        private void setData()
        {
            addr = TB_Addr.Text.ToString();
            roadAddr = TB_Addr.Text.ToString();
            area = TB_Area.Text.ToString();
            station = TB_Station.Text.ToString();
            useArea = TB_UseDistrict.Text.ToString();
            totalArea = TB_TotalArea.Text.ToString();
            completeYear = TB_CompleteYear.Text.ToString();
            parking = TB_Parking.Text.ToString();
            acHeating = TB_AC_Heating.Text.ToString();
            EV = TB_EV.Text.ToString();

            owner = TB_Owner.Text.ToString();
            tel = TB_Tel.Text.ToString();
            meno = TB_Memo.Text.ToString();

            deposit = double.Parse(TB_Deposit.Text.ToString());
            Income = double.Parse(TB_Income.Text.ToString()); 
            loan = double.Parse(TB_Loan.Text.ToString()); 
            interest = double.Parse(TB_Interest.Text.ToString()); 
            takeOverPrice = double.Parse(TB_PayedPrice.Text.ToString()); 
            sellPrice = double.Parse(TB_SellPrice.Text.ToString()); 
            payedPrice = double.Parse(TB_TakeOverPrice.Text.ToString()); 
            yearPercent = double.Parse(TB_YearPercent.Text.ToString()); 

        }
        public ManagerView()
        {
            InitializeComponent();

            dgv = ContentOfRentals;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TB_Addr.Text.Equals(null))
            {
                return;
            }
            string addr = "http://map.daum.net/link/search/" + TB_Addr.Text;
            System.Diagnostics.Process.Start(addr);
        }



    }

}
