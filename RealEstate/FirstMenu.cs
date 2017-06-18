using System;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

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
        public int isCorner;

    }
    public partial class FirstMenu : Form
    {
        Boolean user;
        string strConn;

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlCommandBuilder mbd;
        MySqlDataReader rdr;

        //로인창으로 옮겨야함 deskpath;
        String deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //바탕화면 경로 가져오기
        Findvalue findvalues = new Findvalue();

        int ErrorStr2Num;

        public FirstMenu()
        {

            InitializeComponent();

            //findvalue 예외 처리를 위한 초기화
            findvalues.type = 0;
            findvalues.state = 1;
            findvalues.roadwidthSize = -1;
            findvalues.takeOverPriceSize = -1;
            findvalues.IncomeSize = -1;
            findvalues.sellPriceSize = -1;
            findvalues.yearPercentSize = -1;
            findvalues.isCorner = -1;
            //userType 손님용으로 초기화
            user = true;
            checkBox1.Checked = true;

        }

        private void setData() //입력한 검색 값 가져오기
        {
            findvalues.sellPrice = checkNulls(TB_SellPrice.Text.ToString());
            findvalues.takeOverPrice = checkNulls(TB_TakeOverPrice.Text.ToString());
            findvalues.Income = checkNulls(TB_Income.Text.ToString());
            findvalues.yearPercent = checkNulls(TB_YearPercent.Text.ToString());
            findvalues.distance = checkNulls(TB_Distance.Text.ToString());
            findvalues.addr = TB_Addr.Text.ToString().Trim();
            findvalues.roadwidth = checkNulls(TB_RoadWidth.Text.ToString());
            
        }
        private Boolean checkException()  //검색 에러 핸들
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
            double number = 0;
            num.Trim(); //공백 제거
            if (num.Equals(""))
                return -9999; //빈값 처리
            try
            {
                number = double.Parse(num);
            }
            catch (Exception ex)
            {
                ErrorStr2Num = -1; //숫자가 아닐경우 에러로 인식, number는 0으로 리턴
            }
            return number;
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
            ErrorStr2Num = 0;
            int isOpen = 0;
            setData();
            foreach (Form form in Application.OpenForms)  //검색창 이미 열려 있는 확인
            {
                if (form.Name.Equals( "FindView"))
                {
                    isOpen = 1; 
                }
            }
            
            if (findvalues.type == -1)
            {
                MessageBox.Show("찾을 건물 종류를 선택해주세요");
            }
            else if (isOpen == 1)
            {
                MessageBox.Show("검색 창이 이미 열려 있습니다.");
            }
            else if(checkException())
            {
                if (ErrorStr2Num == 0)
                {
                    FindView findtest = new FindView();
                    //user타입, 검색값 넘겨주기
                    findtest.setUserType(user);
                    findtest.setValue(findvalues);
                    findtest.Show();
                }
                else
                    MessageBox.Show("숫자 입력란에 숫자만 넣어주세요. 다시 확인해주세요 ");

            }

        }
      

        // This is linked click event listener
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e) //검색할 건물 상태 
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
        
        private void radioButton_CheckedChanged(object sender, EventArgs e) //건물 종류
        {
            if (RB_CornerAll.Checked)
                findvalues.isCorner = -1;
            else if (RB_CornerExist.Checked)
                findvalues.isCorner = 1;
            else if (RB_CornerNone.Checked)
                findvalues.isCorner = 0;
        }
        private void allType_checked(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            getType();
        }
        private void otherType_checked(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            getType();
        }
        private void getType()
        {
            findvalues.type = 0;
            if (checkBox1.Checked) //전체
                findvalues.type = 0;
            if (checkBox2.Checked) //다가구 1
                findvalues.type += 1;
            if (checkBox3.Checked) //빌딩 2 
                findvalues.type += 1 << 1;
            if (checkBox4.Checked) //상가주택 4 
                findvalues.type += 1 << 2;
            if (checkBox5.Checked) //신축부지 8
                findvalues.type += 1 << 3;
            if (checkBox6.Checked) //상가 16
                findvalues.type += 1 << 4;
        }
        private void btn_addBuilding_Click(object sender, EventArgs e)
        {
            int isOpen = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.Equals( "AddMenu")) //추가 창 열려 있는지 확인
                {
                    isOpen = 1;
                    MessageBox.Show("추가 창이 이미 열려 있습니다.");
                }
            }
            if (isOpen == 0)
            {
                AddMenu addMenu = new AddMenu();
                addMenu.Show();
            }

        }
        private void createTable()
        {

            string query = "drop table info2";
            conn.Open();
            cmd = new MySqlCommand(query, conn);

            cmd.ExecuteNonQuery();

            cmd.CommandText = "drop table comment";
            cmd.ExecuteNonQuery();


            cmd.CommandText = "drop table memo";
            cmd.ExecuteNonQuery();


            cmd.CommandText = "drop table info1";
            cmd.ExecuteNonQuery();


            cmd.CommandText = "drop table pictures";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "Create table info1(id INTEGER  PRIMARY KEY auto_increment, addr varchar(1000), roadAddr varchar(1000), "
                           + "area varchar(100), station varchar(100), useArea varchar(100), distance NUMERIC, roadWidth NUMERIC, "
                        + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                        + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                        + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC, type INTEGER, state INTEGER, premium NUMERIC, monthlyPay NUMERIC, maintenance NUMERIC, isCorner INTEGER, profilePictureID INTEGER, netIncome NUMERIC)";
            cmd.ExecuteNonQuery();


            cmd.CommandText = "Create table if not exists info2(id INTEGER PRIMARY KEY auto_increment, buildingID INTEGER, floor NUMERIC, area NUMERIC, storeName varchar(100), "
                + "deposit NUMERIC, monthlyIncome NUMERIC, managementPrice NUMERIC, etc varchar(100), FOREIGN KEY(buildingID) REFERENCES info1(id))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Create table if not exists comment(id INTEGER PRIMARY KEY auto_increment, content varchar(1000), buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Create table if not exists memo(id INTEGER PRIMARY KEY auto_increment, c_date DATETIME, memo varchar(1000)" +
                ", buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Create table if not exists pictures(id INTEGER  PRIMARY KEY auto_increment, buildingid INTEGER, picture LONGBLOB)";
            cmd.ExecuteNonQuery();
            conn.Close();

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
        private void HiddenBox_CheckedChanged(object sender, EventArgs e) //옆에 손님이 있으면 user로 인식, 없으면 manager로 인식하게 하기 위한것 
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
            strConn = MysqlIp.Logic.getStrConn(); //DLL에서 mysql server ip 불러오기
            conn = new MySqlConnection(strConn);
            //createTable();
        }
      
    }

}
