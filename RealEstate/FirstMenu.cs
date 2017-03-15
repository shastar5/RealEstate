using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace RealEstate
{
    public struct Findvalue
    {
        public int type;
        public int state;
        public double sellPrice;
        public int sellPriceSize;
        public double Income;
        public int IncomeSize;
        public double yearPercent;
        public int yearPercentSize;
        public double takeOverPrice;
        public int takeOverPriceSize;
        public double distance;
        public string addr;
        public double roadwidth;
        public int roadwidthSize;

    }
    public partial class FirstMenu : Form
    {
        string DBFile;
        Boolean user;
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        

        //로인창으로 옮겨야함 deskpath;
        String deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //바탕화면 경로 가져오기
        Findvalue findvalues = new Findvalue();
    


        public FirstMenu()
        {

            InitializeComponent();

            //findvalue 예외 처리를 위한 초기화
            findvalues.type = -1;
            findvalues.state = 1;
            findvalues.roadwidthSize = -1;
            findvalues.takeOverPriceSize = -1;
            findvalues.IncomeSize = -1;
            findvalues.sellPriceSize = -1;
            findvalues.yearPercentSize = -1;

            //userType 손님용으로 초기화
            user = true;


            //로그인 창 나오면 삭제해야함
            deskPath = deskPath.Replace("\\", "/"); //\\글자 /로 바꾸기
            DBFile = deskPath + @"/DB.db";
            DBLocation.Text = "DB파일 위치 : " + DBFile;
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            string query = "Create table if not exists info1 (id INTEGER  PRIMARY KEY autoincrement, addr varchar(1000), roadAddr varchar(1000), "
                + "area varchar(100), station varchar(100), useArea varchar(100), distance NUMERIC, roadWidth NUMERIC, "
                + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC, type INTEGER, state INTEGER, premium NUMERIC, monthlyPay NUMERIC, maintenance NUMERIC, isCorner INTEGER)";
            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();

            try
            {
                query = "Create table if not exists info2 (id INTEGER  PRIMARY KEY autoincrement, buildingID INTEGER, floor NUMERIC, area NUMERIC, storeName varchar(100), "
                + "deposit NUMERIC, monthlyIncome NUMERIC, managementPrice NUMERIC, etc varchar(100), FOREIGN KEY(buildingID) REFERENCES info1(id))";
                cmd = new SQLiteCommand(query, cn);
                cmd.ExecuteNonQuery();
            } catch(SQLiteException e)
            {
                MessageBox.Show(e.Message);
            }

            cn.Close();

        }

        private void setData()
        {
            findvalues.sellPrice = checkNulls(TB_SellPrice.Text.ToString());
            findvalues.takeOverPrice = checkNulls(TB_TakeOverPrice.Text.ToString());
            findvalues.Income = checkNulls(TB_Income.Text.ToString());
            findvalues.yearPercent = checkNulls(TB_YearPercent.Text.ToString());
            findvalues.distance = checkNulls(TB_Distance.Text.ToString());
            findvalues.addr = TB_Addr.Text.ToString();
            findvalues.roadwidth = checkNulls(TB_RoadWidth.Text.ToString());
            
        }
        private Boolean checkException()
        {
            if (findvalues.sellPriceSize != -1 && TB_SellPrice.Text.Equals(""))
            {
                MessageBox.Show("매매금액을 정해주세요");
                return false;
            }
            else if (findvalues.sellPriceSize == -1 && !TB_SellPrice.Text.Equals(""))
            {
                MessageBox.Show("매매금액 범위를 정해주세요");
                return false;
            }
            if (findvalues.takeOverPriceSize != -1 && TB_TakeOverPrice.Text.Equals(""))
            {
                MessageBox.Show("인수금액을 정해주세요");
                return false;
            }
            else if (findvalues.takeOverPriceSize == -1 && !TB_TakeOverPrice.Text.Equals(""))
            {
                MessageBox.Show("인수금액 범위를 정해주세요");
                return false;
            }
            if (findvalues.IncomeSize != -1 && TB_Income.Text.Equals(""))
            {
                MessageBox.Show("월 수입을 정해주세요");
                return false;
            }
            else if (findvalues.IncomeSize == -1 && !TB_Income.Text.Equals(""))
            {
                MessageBox.Show("월 수입 범위를 정해주세요");
                return false;
            }

            if (findvalues.yearPercentSize != -1 && TB_YearPercent.Text.Equals(""))
            {
                MessageBox.Show("연수익율을 정해주세요");
                return false;
            }
            else if (findvalues.yearPercentSize == -1 && !TB_YearPercent.Text.Equals(""))
            {
                MessageBox.Show("연수익율 범위를 정해주세요");
                return false;
            }
            if (findvalues.roadwidthSize != -1 && TB_RoadWidth.Text.Equals(""))
            {
                MessageBox.Show("도로너비를 정해주세요");
                return false;
            }
            else if (findvalues.roadwidthSize == -1 && !TB_RoadWidth.Text.Equals(""))
            {
                MessageBox.Show("도로너비 범위를 정해주세요");
                return false;
            }
            
            return true;
        }
        private double checkNulls(string num)
        {
            num.Trim(); //공백 제거
            if (num.Equals(""))
                return -9999; //빈값 처리
            return double.Parse(num);
        }

        private void typeOnlyNum(object sender, KeyPressEventArgs e)
        {
            //숫자,백스페이스,마이너스,소숫점 만 입력받는다.
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 46) //8:백스페이스,45:마이너스,46:소수점
            {
                e.Handled = true;
            }
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
             setData();
            if (findvalues.type == -1)
            {
                MessageBox.Show("찾을 건물 종류를 선택해주세요");
            }
            else if(checkException())
            {
                
                findtest findtest = new findtest();
                findtest.setDBfile(DBFile);
                findtest.setUserType(user);
                findtest.setValue(findvalues);
                findtest.Show();
                
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // This is linked click event listener
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab_control.SelectedTab == Page_prepare)
            {
                findvalues.state = 1;
            }

            else if (Tab_control.SelectedTab == Page_complete)
            {
                findvalues.state = 2;
            }

            else if (Tab_control.SelectedTab == Page_wait)
            {
                findvalues.state = 3;
            }

            else if (Tab_control.SelectedTab == Page_sell)
            {
                findvalues.state = 4;
            }
        }

       


        //라디오버튼 체크 리스너
        
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                findvalues.type = 1;
            }
            else if (radioButton2.Checked)
            {
                findvalues.type = 2;
            }
            else if (radioButton3.Checked)
            {
                findvalues.type = 3;
            }
            else if (radioButton4.Checked)
            {
                findvalues.type = 4;
            }
            else if (radioButton5.Checked)
            {
                findvalues.type = 5;
            }
            else if(radioButton6.Checked)
            {
                findvalues.type = 6;
            }
        }

        private void btn_addBuilding_Click(object sender, EventArgs e)
        {
            AddMenu addMenu = new AddMenu();
            addMenu.setDBfile(DBFile);
            addMenu.Show();

            if (radioButton6.Checked == true)
            {

            }
        }

        private void btn_DBFind_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog find = new OpenFileDialog();
                find.InitialDirectory = deskPath;
                find.Filter = "DB|*.db";
                if (find.ShowDialog() == DialogResult.OK)
                {
                    DBFile = find.FileName;
                    DBFile = DBFile.Replace("\\", "/"); //\\을 /로 바꾸기
                    DBLocation.Text = "DB파일 위치 : " + DBFile;
                    strConn = "Data Source=" + DBFile + "; Version=3;";
                    cn.ConnectionString = strConn;
                    cn.Open();
                    string query = "Create table if not exists info1 (id INTEGER  PRIMARY KEY autoincrement, addr varchar(1000), roadAddr varchar(1000), "
                           + "area varchar(100), station varchar(100), useArea varchar(100), distance NUMERIC, roadWidth NUMERIC, "
                        + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                        + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                        + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC, type INTEGER, state INTEGER, premium NUMERIC, monthlyPay NUMERIC, maintenance NUMERIC, isCorner INTEGER)";
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        //이상 미만 선택 리스너  
        // index : 0 blank return value -1 
        // index : 1 and more return vaulue 0 
        // index : 2 less return value 1   
        private void CB_sellPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CB_sellPrice.SelectedIndex == 0)
            {
                findvalues.sellPriceSize = -1;
            }
            else if(CB_sellPrice.SelectedIndex == 1)
            {
                findvalues.sellPriceSize = 0;
            }
            else if (CB_sellPrice.SelectedIndex == 2)
            {
                findvalues.sellPriceSize = 1;
            }
        }
        private void CB_TakeOverPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_TakeOverPrice.SelectedIndex == 0)
            {
                findvalues.takeOverPriceSize = -1;
            }
            else if (CB_TakeOverPrice.SelectedIndex == 1)
            {
                findvalues.takeOverPriceSize = 0;
            }
            else if (CB_TakeOverPrice.SelectedIndex == 2)
            {
                findvalues.takeOverPriceSize = 1;
            }
        }
        private void CB_Income_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Income.SelectedIndex == 0)
            {
                findvalues.IncomeSize = -1;
            }
            else if (CB_Income.SelectedIndex == 1)
            {
                findvalues.IncomeSize = 0;
            }
            else if (CB_Income.SelectedIndex == 2)
            {
                findvalues.IncomeSize = 1;
            }
        }

        private void CB_YearPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_YearPercent.SelectedIndex == 0)
            {
                findvalues.yearPercentSize = -1;
            }
            else if (CB_YearPercent.SelectedIndex == 1)
            {
                findvalues.yearPercentSize = 0;
            }
            else if (CB_YearPercent.SelectedIndex == 2)
            {
                findvalues.yearPercentSize = 1;
            }
        }

        private void CB_RoadWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_RoadWidth.SelectedIndex == 0)
            {
                findvalues.roadwidthSize = -1;
            }
            else if (CB_RoadWidth.SelectedIndex == 1)
            {
                findvalues.roadwidthSize = 0;
            }
            else if (CB_RoadWidth.SelectedIndex == 2)
            {
                findvalues.roadwidthSize = 1;
            }
        }

        //checkBox listener
        private void HiddenBox_CheckedChanged(object sender, EventArgs e)
        {
            if (HiddenBox.Checked)
            {
                user = false;
            }
            else
            {
                user = true;
            }
        }

        private void FirstMenu_Load(object sender, EventArgs e)
        {

        }
    }

}
