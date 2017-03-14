using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace RealEstate
{
    public interface IdInterface
    {
        void setID(int id);
    }
    public partial class ManagerView : Form, DBInterface, IdInterface
    {

        ShowPicture sp;
        int id; // 선택한 건물 id
        //전체 보이는용 변수
        int type;
        int state;
        string DBFile;
        string addr;
        string roadAddr;
        string area;
        string station;
        string useArea;
        double distance;
        double roadWidth;
        string totalArea;
        string completeYear;
        string parking;
        string acHeating;
        string EV;

        //상가
        double premium;
        double monthlyPay;
        double maintenance;

        //관리자용 변수
        string buildingName;
        string owner;
        string tel;
        string meno;
        double deposit;
        double Income;
        double loan;
        double interest;
        double payedPrice;
        double sellPrice;
        double takeOverPrice;
        double yearPercent;

        int isCorner;

        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteParameter picture;

        // Database keyword declare
        SQLiteCommand sqlCMD;
        SQLiteDataReader sqlReader;
        DataGridView dgv;

        // DataGridView 설정
        private void readDataGrid()
        {
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
            while (sqlReader.Read())
            {
                // Column이 7개니까
                for (j = 0; j < 7; j++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells[j].Value = sqlReader.GetValue(j++);
                }
            }

            cn.Close();
        }

        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }
        public void setID(int id)
        {
            this.id = id;
        }

        public ManagerView()
        {
            InitializeComponent();
            dgv = ContentOfRentals;
        }
        private void readData()
        {
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            String query = "select * from info1 where id = " + id;

            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TB_Addr.Text = rdr[1].ToString();
                TB_RoadAddr.Text = rdr[2].ToString();
                TB_Area.Text = rdr[3].ToString();
                TB_Station.Text = rdr[4].ToString();
                TB_UseDistrict.Text = rdr[5].ToString();
                TB_Distance.Text = rdr[6].ToString();
                TB_RoadWidth.Text = rdr[7].ToString();
                TB_TotalArea.Text = rdr[8].ToString();
                TB_CompleteYear.Text = rdr[9].ToString();
                TB_Parking.Text = rdr[10].ToString();
                TB_AC_Heating.Text = rdr[11].ToString();
                TB_EV.Text = rdr[12].ToString();
                TB_BuildName.Text = rdr[13].ToString();
                TB_Owner.Text = rdr[14].ToString();
                TB_Tel.Text = rdr[15].ToString();
                TB_Memo.Text = rdr[16].ToString();
                TB_Deposit.Text = rdr[17].ToString();
                TB_Income.Text = rdr[18].ToString();
                TB_Income2.Text = rdr[18].ToString();
                TB_Loan.Text = rdr[19].ToString();
                TB_Interest.Text = rdr[20].ToString();
                TB_TakeOverPrice.Text = rdr[21].ToString();

                TB_SellPrice.Text = rdr[22].ToString();
                TB_PayedPrice.Text = rdr[23].ToString();
                TB_YearPercent.Text = rdr[24].ToString();
                type = int.Parse(rdr[25].ToString());

                panel6.Show();
                panel2.Hide();
                switch (type)
                {
                    case 2:
                        Dagagu.Checked= true;
                        break;
                    case 3:
                        Building.Checked = true;
                        break;
                    case 4:
                        SanggaHome.Checked = true;
                        break;
                    case 5:
                        NewConstruction.Checked = true;
                        break;
                    case 6:
                        Sangga.Checked = true;
                        panel6.Hide();
                        panel2.Visible = true;
                        panel2.Show();
                        break;
                }
                state = int.Parse(rdr[26].ToString());
                switch(state)
                {
                    case 1:
                        Tab_control.SelectedTab = Page_prepare;
                        break;
                    case 2:
                        Tab_control.SelectedTab = Page_complete;
                        break;
                    case 3:
                        Tab_control.SelectedTab = Page_wait;
                        break;
                    case 4:
                        Tab_control.SelectedTab = Page_sell;
                        break;
                    
                }
                TB_Premium.Text = rdr[27].ToString();
                TB_MonthlyPay.Text = rdr[28].ToString();
                TB_Maintenance.Text = rdr[29].ToString();
                isCorner = int.Parse(rdr[30].ToString());
                if(isCorner==0)
                {
                    CB_corner.Checked = false;
                }
                else
                {
                    CB_corner.Checked = true;
                }
               
            }


            rdr.Close();
            cn.Close();
        }
        private void setData()
        {
            addr = TB_Addr.Text.ToString();
            roadAddr = TB_RoadAddr.Text.ToString();
            area = TB_Area.Text.ToString();
            station = TB_Station.Text.ToString();
            useArea = TB_UseDistrict.Text.ToString();

            distance = checkNulls(TB_Distance.Text.ToString());
            roadWidth = checkNulls(TB_RoadWidth.Text.ToString());

            totalArea = TB_TotalArea.Text.ToString();
            completeYear = TB_CompleteYear.Text.ToString();
            parking = TB_Parking.Text.ToString();
            acHeating = TB_AC_Heating.Text.ToString();
            EV = TB_EV.Text.ToString();

            buildingName = TB_BuildName.Text.ToString();
            owner = TB_Owner.Text.ToString();
            tel = TB_Tel.Text.ToString();
            meno = TB_Memo.Text.ToString();


            deposit = checkNulls(TB_Deposit.Text.ToString());
            if (type != 6)
            {
                Income = checkNulls(TB_Income.Text.ToString());
            }
            else
            {
                Income = checkNulls(TB_Income2.Text.ToString());
            }
            loan = checkNulls(TB_Loan.Text.ToString());
            interest = checkNulls(TB_Interest.Text.ToString());

            takeOverPrice = checkNulls(TB_TakeOverPrice.Text.ToString());
            sellPrice = checkNulls(TB_SellPrice.Text.ToString());
            payedPrice = checkNulls(TB_PayedPrice.Text.ToString());
            yearPercent = checkNulls(TB_YearPercent.Text.ToString());

            premium = checkNulls(TB_Premium.Text.ToString());
            monthlyPay = checkNulls(TB_MonthlyPay.Text.ToString());
            maintenance = checkNulls(TB_Maintenance.Text.ToString());
        }
        private double checkNulls(string num)
        {
            num.Trim(); //공백 제거
            if (num.Equals(""))
                return -9999; //빈값 처리
            return double.Parse(num);
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Dagagu.Checked)
            {
                type = 2;
            }
            else if (Building.Checked)
            {
                type = 3;
            }
            else if (SanggaHome.Checked)
            {
                type = 4;
            }
            else if (NewConstruction.Checked)
            {
                type = 5;
            }
            if (Sangga.Checked)
            {
                type = 6;
                panel6.Hide();
                panel2.Visible = true;
                panel2.Show();
            }
            else
            {
                panel6.Show();
                panel2.Hide();
            }
        }

        private void typeOnlyNum(object sender, KeyPressEventArgs e)
        {
            //숫자,백스페이스,마이너스,소숫점 만 입력받는다.
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 46) //8:백스페이스,45:마이너스,46:소수점
            {
                e.Handled = true;
            }
        }
        private void CB_corner_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_corner.Checked)
            {
                isCorner = 1;
            }
            else
            {
                isCorner = 0;
            }
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

        private void ManagerView_Load(object sender, EventArgs e)
        {
            readData();
        }
    }

}
