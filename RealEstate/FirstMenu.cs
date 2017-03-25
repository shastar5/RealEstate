using System;
using System.Windows.Forms;
using System.Data.SQLite;
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
        string DBFile;
        Boolean user;
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        

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


            deskPath = deskPath.Replace("\\", "/"); //\\글자 /로 바꾸기
            DBFile = deskPath + @"/DB.db";
            DBLocation.Text = "DB파일 위치 : " + DBFile;
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            //info1 테이블 생성
            string query = "Create table if not exists info1 (id INTEGER  PRIMARY KEY autoincrement, addr varchar(1000), roadAddr varchar(1000), "
                + "area varchar(100), station varchar(100), useArea varchar(100), distance NUMERIC, roadWidth NUMERIC, "
                + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC, type INTEGER, state INTEGER, premium NUMERIC, monthlyPay NUMERIC, maintenance NUMERIC, isCorner INTEGER, profilePictureID INTEGER)";
            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();

            query = "Create table if not exists pictures (id INTEGER  PRIMARY KEY autoincrement, buildingid INTEGER, picture image)";
            cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();
          
            try
            {
                query = "Create table if not exists info2 (id INTEGER PRIMARY KEY autoincrement, buildingID INTEGER, floor NUMERIC, area NUMERIC, storeName varchar(100), "
                + "deposit NUMERIC, monthlyIncome NUMERIC, managementPrice NUMERIC, etc varchar(100), FOREIGN KEY(buildingID) REFERENCES info1(id))";
                cmd = new SQLiteCommand(query, cn);
                cmd.ExecuteNonQuery();
            } catch(SQLiteException e)
            {
                MessageBox.Show(e.Message);
            }

            query = "Create table if not exists comment (id INTEGER PRIMARY KEY AUTOINCREMENT, content varchar(1000), buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();

            query = "Create table if not exists memo (id INTEGER PRIMARY KEY AUTOINCREMENT, c_date DATE, memo varchar(1000)" +
                ", buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();

            cn.Close();

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
                    //DBFIle위치, user타입, 검색값 넘겨주기
                    findtest.setDBfile(DBFile);
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
                //DBFILE넘기기
                addMenu.setDBfile(DBFile);
                addMenu.Show();
            }

        }
        private void createTable()
        {
            string strConn2 = "Server=104.154.105.21;Database=realestate;Uid=realestate_admin;Pwd=123456;"; 

            string query = "Create table if not exists info1 (id INTEGER  PRIMARY KEY auto_increment, addr varchar(1000), roadAddr varchar(1000), "
                           + "area varchar(100), station varchar(100), useArea varchar(100), distance NUMERIC, roadWidth NUMERIC, "
                        + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                        + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                        + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC, type INTEGER, state INTEGER, premium NUMERIC, monthlyPay NUMERIC, maintenance NUMERIC, isCorner INTEGER, profilePictureID INTEGER)";
            
            MySqlConnection conn = new MySqlConnection(strConn2);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            
            cmd.CommandText = "Create table if not exists info2 (id INTEGER PRIMARY KEY auto_increment, buildingID INTEGER, floor NUMERIC, area NUMERIC, storeName varchar(100), "
                + "deposit NUMERIC, monthlyIncome NUMERIC, managementPrice NUMERIC, etc varchar(100), FOREIGN KEY(buildingID) REFERENCES info1(id))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Create table if not exists comment (id INTEGER PRIMARY KEY auto_increment, content varchar(1000), buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "Create table if not exists memo (id INTEGER PRIMARY KEY auto_increment, c_date DATETIME, memo varchar(1000)" +
                ", buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }
        private void btn_DBMerge_Click(object sender, EventArgs e)
        {
            DBMerge DbMerge = new DBMerge();
            //DBFIle위치, user타입, 검색값 넘겨주기
            DbMerge.setDBfile(DBFile);
            DbMerge.Show();
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
                    //새로 연 DB에 테이블이 없을 경우 생성
                    string query = "Create table if not exists info1 (id INTEGER  PRIMARY KEY autoincrement, addr varchar(1000), roadAddr varchar(1000), "
                           + "area varchar(100), station varchar(100), useArea varchar(100), distance NUMERIC, roadWidth NUMERIC, "
                        + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                        + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                        + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC, type INTEGER, state INTEGER, premium NUMERIC, monthlyPay NUMERIC, maintenance NUMERIC, isCorner INTEGER, profilePictureID INTEGER)";
                    SQLiteCommand cmd = new SQLiteCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    /*
                    query = "Create table if not exists temp (id INTEGER  PRIMARY KEY autoincrement, picture image)";
                    cmd = new SQLiteCommand(query, cn);
                    cmd.ExecuteNonQuery();*/
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
            //createTable();
        }
        private void btn_Back_UP_Click(object sender, EventArgs e)
        {

            string time = DateTime.Now.ToString("yyyy년MM월dd일HH시mm분ss초_백업파일"); //백업 파일 이름
            string sDirPath = deskPath + "/backup";
            string backupFile = sDirPath + "/ " + time + ".db";
            DirectoryInfo di = new DirectoryInfo(sDirPath); 
            if (di.Exists == false) //폴더가 없으면 생성
            {
                di.Create();
            }
            try
            {
                File.Copy(DBFile, backupFile);
                MessageBox.Show("백업파일을 생성했습니다.\n위치 : " + backupFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("백업파일을 생성하지 못했습니다.\n이유 : " + ex.ToString());
            }
        }

      
    }

}
