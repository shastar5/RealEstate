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
        public double yearPercent;
        public int yearPercentSize;
        public double takeOverPrice;
        public string distance;
        public string addr;
        public string roadwidth;
        public int roadwidthSize;

    }
    public partial class FirstMenu : Form
    {
        string DBFile;
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
            findvalues.sellPriceSize = -1;
            findvalues.yearPercentSize = -1;
           


            //로그인 창 나오면 삭제해야함
            deskPath = deskPath.Replace("\\", "/"); //\\글자 /로 바꾸기
            DBFile = deskPath + @"/DB.db";
            DBLocation.Text = "DB파일 위치 : " + DBFile;
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            string query = "Create table if not exists info1 (id INTEGER  PRIMARY KEY autoincrement, addr varchar(1000), roadAddr varchar(1000), "
                + "area varchar(100), station varchar(100), useArea varchar(100), distance varchar(100), roadWidth varchar(100), "
                + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC, type INTEGER, state INTEGER)";
            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();

            try
            {
                query = "Create table if not exists info2 (id INTEGER  PRIMARY KEY autoincrement, buildingName varchar(2000), price NUMERIC, "
                + "rental varchar(100), area NUMERIC, distanceToStation NUMERIC, monthlyIncome NUMERIC, yearlyIncome NUMERIC, roadWidth NUMERIC, isCorner Boolean)";
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
            findvalues.distance = TB_Distance.Text.ToString();
            findvalues.addr = TB_Addr.Text.ToString();
            findvalues.roadwidth = TB_RoadWidth.Text.ToString();
        }
        private double checkNulls(string num)
        {
            num.Trim(); //공백 제거
            if (num.Equals(""))
                return -9999; //빈값 처리
            return double.Parse(num);
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
          
            if (findvalues.type == -1)
            {
                MessageBox.Show("찾을 건물 종류를 선택해주세요");
            }
            else
            {
                if(HiddenBox.Checked == true)
                {
                    ManagerView mv = new ManagerView();
                    mv.Show();
                }
                else
                {
                    UserView uv = new UserView();
                    uv.Show();
                }
                setData();
                findtest findtest = new findtest();
                findtest.setDBfile(DBFile);
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
                        + "area varchar(100), station varchar(100), useArea varchar(100), distance varchar(100), roadWidth varchar(100), "
                        + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                        + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                        + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC, type INTEGER, state INTEGER)";
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
        private void CB_sellPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CB_sellPrice.SelectedIndex == 0)
            {
                findvalues.sellPriceSize = 0;
            }
            else if(CB_sellPrice.SelectedIndex == 1)
            {
                findvalues.sellPriceSize = 1;
            }
        }

        private void CB_YearPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_YearPercent.SelectedIndex == 0)
            {
                findvalues.yearPercentSize = 0;
            }
            else if (CB_YearPercent.SelectedIndex == 1)
            {
                findvalues.yearPercentSize = 1;
            }
        }

        private void CB_RoadWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_RoadWidth.SelectedIndex == 0)
            {
                findvalues.roadwidthSize = 0;
            }
            else if (CB_RoadWidth.SelectedIndex == 1)
            {
                findvalues.roadwidthSize = 1;
            }
        }
    }

}
