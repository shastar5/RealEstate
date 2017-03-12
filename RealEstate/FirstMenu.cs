using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace RealEstate
{
    public partial class InitialFoam : Form
    {
        string DBFile;
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
  

        //로인창으로 옮겨야함 deskpath;
        String deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //바탕화면 경로 가져오기


        public InitialFoam()
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
            cn.Close();

        }
        private void btn_find_Click(object sender, EventArgs e)
        {
            findtest findtest = new findtest();
            findtest.setDBfile(DBFile);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // This is linked click event listener
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Init_탭컨트롤.SelectedTab == Page_준비)
            {

            }

            else if (Init_탭컨트롤.SelectedTab == Page_완료)
            {

            }

            else if (Init_탭컨트롤.SelectedTab == Page_보류)
            {

            }

            else if (Init_탭컨트롤.SelectedTab == Page_매매)
            {

            }
        }

        private void btn_건물추가_Click(object sender, EventArgs e)
        {
            AddMenu addMenu = new AddMenu();
            addMenu.setDBfile(DBFile);
            addMenu.Show();
        }

        /*
         * 라디오버튼 체크 리스너
         */
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        // 상가 라디오 버튼 클릭되었을 때
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            
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

        private void TB_TakeOverPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void DBLocation_Click(object sender, EventArgs e)
        {

        }

        private void InitialFoam_Load(object sender, EventArgs e)
        {

        }

        private void InitialFoam_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

      
    }
}
