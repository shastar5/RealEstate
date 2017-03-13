using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace RealEstate
{
    public partial class FirstMenu : Form
    {
        string DBFile;
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        int type = 0;
        int state = 1;
        double sellPrice;
        double Income;
        double yearPercent;
        double takeOverPrice;
        string distance;
        string addr;
        string roadwidth;

        //로인창으로 옮겨야함 deskpath;
        String deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //바탕화면 경로 가져오기


        public FirstMenu()
        {

            InitializeComponent();

            // Set tab control click event listener
            Init_탭컨트롤.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);


            //로그인 창 나오면 삭제해야함
            deskPath = deskPath.Replace("\\", "/"); //\\글자 /로 바꾸기
            DBFile = deskPath + @"/DB.db";
            DBLocation.Text = "DB파일 위치 : " + DBFile;
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            string query = "Create table if not exists info1 (id INTEGER  PRIMARY KEY autoincrement, addr varchar(2000), roadAddr varchar(2000), "
                + "area varchar(100), station varchar(100), useArea varchar(100), distance varchar(100), roadWidth varchar(100), "
                + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC)";
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
        private void btn_find_Click(object sender, EventArgs e)
        {
            if (type == 0)
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
                findtest findtest = new findtest();
                findtest.setDBfile(DBFile);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // This is linked click event listener
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Init_탭컨트롤.SelectedTab == Page_준비)
            {
                state = 1;
            }

            else if (Init_탭컨트롤.SelectedTab == Page_완료)
            {
                state = 2;
            }

            else if (Init_탭컨트롤.SelectedTab == Page_보류)
            {
                state = 3;
            }

            else if (Init_탭컨트롤.SelectedTab == Page_매매)
            {
                state = 4;
            }
        }

       
        public Boolean getSangga(object sender, EventArgs e)
        {
            return false;
        }

        /*
         * 라디오버튼 체크 리스너
         */
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                type = 1;
            }
            else if (radioButton2.Checked)
            {
                type = 2;
            }
            else if (radioButton3.Checked)
            {
                type = 3;
            }
            else if (radioButton4.Checked)
            {
                type = 4;
            }
            else if (radioButton5.Checked)
            {
                type = 5;
            }
            else if(radioButton6.Checked)
            {
                type = 6;
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
                    string query = "Create table if not exists info1 (id INTEGER  PRIMARY KEY autoincrement, addr varchar(2000), roadAddr varchar(2000), "
                        + "area varchar(100), station varchar(100), useArea varchar(100), distance varchar(100), roadWidth varchar(100), "
                        + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                        + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                        + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC)";
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

        

  

       
    }

}
