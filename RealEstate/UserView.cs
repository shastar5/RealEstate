using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Data;

namespace RealEstate
{
    public partial class UserView : Form, DBInterface, IdInterface
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
        
        double deposit;
        double Income;
        double loan;
        double interest;
        double payedPrice;
        double sellPrice;
        double takeOverPrice;
        double yearPercent;
        int isCorner;
        //프로필 유무
        public int profilePictureID=-1;

        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        // Database keyword declare
        DataGridView dgv, commentview;

        public UserView()
        {
            InitializeComponent();

            dgv = ContentOfRentals;

            commentview = commentGridView;
            commentview.AutoGenerateColumns = false;
            commentview.RowHeadersVisible = false;
            commentview.Columns[0].ReadOnly = true;
            commentview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }
        public void setID(int id) // 선택된 건물 id가져오기
        {
            this.id = id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TB_Addr.Text.Equals(null))
            {
                return;
            }
            string addr = "http://map.daum.net/link/search/" + TB_Addr.Text;
            System.Diagnostics.Process.Start(addr);
        }
        private void readData() //DB파일 있는 자료를 가져오기 
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
                if (rdr[6].ToString().Equals("-9999"))
                    TB_Distance.Text = "";
                else
                    TB_Distance.Text = rdr[6].ToString();
                if (rdr[7].ToString().Equals("-9999"))
                    TB_RoadWidth.Text = "";
                else
                    TB_RoadWidth.Text = rdr[7].ToString();
                TB_TotalArea.Text = rdr[8].ToString();
                TB_CompleteYear.Text = rdr[9].ToString();
                TB_Parking.Text = rdr[10].ToString();
                TB_AC_Heating.Text = rdr[11].ToString();
                TB_EV.Text = rdr[12].ToString();
                //TB_BuildName.Text = rdr[13].ToString();
                //TB_Owner.Text = rdr[14].ToString();
                //TB_Tel.Text = rdr[15].ToString();
                //TB_Memo.Text = rdr[16].ToString();

                if (rdr[17].ToString().Equals("-9999"))
                    TB_Deposit.Text = "";
                else
                    TB_Deposit.Text = rdr[17].ToString();

                if (rdr[18].ToString().Equals("-9999"))
                {
                    TB_Income.Text = "";
                    TB_Income2.Text = "";
                }
                else
                {
                    TB_Income.Text = rdr[18].ToString();
                    TB_Income2.Text = rdr[18].ToString();
                }

                if (rdr[19].ToString().Equals("-9999"))
                    TB_Loan.Text = "";
                else
                    TB_Loan.Text = rdr[19].ToString();

                if (rdr[20].ToString().Equals("-9999"))
                    TB_Interest.Text = "";
                else
                    TB_Interest.Text = rdr[20].ToString();

                if (rdr[21].ToString().Equals("-9999"))
                    TB_TakeOverPrice.Text = "";
                else
                    TB_TakeOverPrice.Text = rdr[21].ToString();

                if (rdr[22].ToString().Equals("-9999"))
                    TB_SellPrice.Text = "";
                else
                    TB_SellPrice.Text = rdr[22].ToString();
                /*
                if (rdr[23].ToString().Equals("-9999"))
                    TB_PayedPrice.Text = "";
                else
                    TB_PayedPrice.Text = rdr[23].ToString();
                */
                if (rdr[24].ToString().Equals("-9999"))
                    TB_YearPercent.Text = "";
                else
                    TB_YearPercent.Text = rdr[24].ToString();

                type = int.Parse(rdr[25].ToString());

                profilePictureID = int.Parse(rdr[31].ToString());

                panel6.Show();
                panel2.Hide();
                switch (type)
                {
                    case 2:
                        Dagagu.Checked = true;
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
                switch (state)
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
                
                if (rdr[27].ToString().Equals("-9999"))
                    TB_Premium.Text = "";
                else
                    TB_Premium.Text = rdr[27].ToString();

                if (rdr[28].ToString().Equals("-9999"))
                    TB_MonthlyPay.Text = "";
                else
                    TB_MonthlyPay.Text = rdr[28].ToString();

                if (rdr[29].ToString().Equals("-9999"))
                    TB_Maintenance.Text = "";
                else
                    TB_Maintenance.Text = rdr[29].ToString();

                isCorner = int.Parse(rdr[30].ToString());
                if (isCorner == 0)
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
        private void btn_clicked(object sender, EventArgs e)
        {
            switch (state)
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
            switch (type)
            {
                case 2:
                    Dagagu.Checked = true;
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
            if (isCorner == 0)
            {
                CB_corner.Checked = false;
            }
            else
            {
                CB_corner.Checked = true;
            }
        }
        public void loadPicture(string tableName)  //사진 불러오기
        {
            if (profilePictureID != -1)
            {
                cn.Open();
                string query = "select picture from " + tableName + " where id = " + profilePictureID;
                cmd = new SQLiteCommand(query, cn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                SQLiteCommandBuilder cbd = new SQLiteCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds);
                byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
                MemoryStream ms = new MemoryStream(ap);
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                ms.Close();
                cn.Close();
            }
        }
        private void UserView_Load(object sender, EventArgs e)
        {
            readData();
            loadPicture("picture" + id);
            readDataGrid();
            readcomment();

            for (int i = 0; i < dgv.ColumnCount; ++i)
                dgv.AutoResizeColumn(i);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int isOpen = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.Equals("ShowPicture")) //사진 추가/삭제창 열려있는지 확인
                {
                    isOpen = 1;
                    MessageBox.Show("사진추가/삭제 창이 이미 열려 있습니다.");
                }
            }
            if (isOpen == 0)
            {
                ShowPicture showpicture = new ShowPicture();
                showpicture.setDBfile(DBFile);
                showpicture.Owner = this;
                //id. 프로필 사진 번호, 모드 보내기
                showpicture.tableID = id;
                showpicture.profilePictureID = profilePictureID;
                showpicture.setMode("userMode");
                showpicture.Show();
            }
        }

        private void readDataGrid()
        {
            /*
             "Create table if not exists info2 (0id INTEGER  PRIMARY KEY autoincrement, 1buildingID INTEGER,2 floor NUMERIC, 3area NUMERIC, 4storeName varchar(100), "
             + "5deposit NUMERIC, 6monthlyIncome NUMERIC, 7managementPrice NUMERIC, 8etc NUMERIC, FOREIGN KEY(buildingID) REFERENCES info1(id))";
             */

            int i = 0;
            string sql = "select * from info2 where buildingId =" + id;
            try
            {
                SQLiteConnection con = new SQLiteConnection();
                strConn = "Data Source=" + DBFile + "; Version=3;";
                con.ConnectionString = strConn;

                // 여기 select * from info2 where id=? 로 고쳐
                SQLiteCommand sqlCMD = new SQLiteCommand(sql, con);
                SQLiteDataReader reader;
                con.Open();
                reader = sqlCMD.ExecuteReader();

                while (reader.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells[0].Value = reader.GetValue(2);
                    dgv.Rows[i].Cells[1].Value = reader.GetValue(3);
                    dgv.Rows[i].Cells[2].Value = reader.GetValue(4);
                    dgv.Rows[i].Cells[3].Value = reader.GetValue(5);
                    dgv.Rows[i].Cells[4].Value = reader.GetValue(6);
                    dgv.Rows[i].Cells[5].Value = reader.GetValue(7);
                    dgv.Rows[i].Cells[6].Value = reader.GetValue(8);
                    i++;
                }
                con.Close();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }

            showSum();
        }

        private void showSum()
        {
            if (dgv.Rows.Count == 0)
                return;
            int i;
            // Get sum of each column and add additional column and shows
            double sumofArea = 0, sumofDeposit = 0, sumofMonthlyIncome = 0, sumofManagementPrice = 0;

            for (i = 0; i < dgv.Rows.Count; ++i)
            {
                if (dgv.Rows[i].Cells[1].Value != DBNull.Value)
                    sumofArea += Convert.ToDouble(dgv.Rows[i].Cells[1].Value);
                if (dgv.Rows[i].Cells[3].Value != DBNull.Value)
                    sumofDeposit += Convert.ToDouble(dgv.Rows[i].Cells[3].Value);
                if (dgv.Rows[i].Cells[4].Value != DBNull.Value)
                    sumofMonthlyIncome += Convert.ToDouble(dgv.Rows[i].Cells[4].Value);
                if (dgv.Rows[i].Cells[5].Value != DBNull.Value)
                    sumofManagementPrice += Convert.ToDouble(dgv.Rows[i].Cells[5].Value);
            }
            
            dgv.Rows[i].Cells[0].Value = "합계";
            dgv.Rows[i].Cells[1].Value = sumofArea;
            dgv.Rows[i].Cells[3].Value = sumofDeposit;
            dgv.Rows[i].Cells[4].Value = sumofMonthlyIncome;
            dgv.Rows[i].Cells[5].Value = sumofManagementPrice;

            dgv.Refresh();
        }

        private void readcomment()
        {
            /*
            query = "Create table if not exists comment (id INTEGER PRIMARY KEY AUTOINCREMENT, content varchar(1000), buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();

            query = "Create table if not exists memo (id INTEGER PRIMARY KEY AUTOINCREMENT, c_date DATE DEFAULT CURRENT_TIMESTAMP, memo varchar(1000)" +
                ", buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
             */
            int i = 0;
            string sql = "select * from comment where buildingId =" + id;
            try
            {
                SQLiteConnection con = new SQLiteConnection();
                strConn = "Data Source=" + DBFile + "; Version=3;";
                con.ConnectionString = strConn;

                SQLiteCommand sqlCMD = new SQLiteCommand(sql, con);
                SQLiteDataReader reader;
                con.Open();
                reader = sqlCMD.ExecuteReader();

                while (reader.Read())
                {
                    commentview.Rows.Add();
                    commentview.Rows[i++].Cells[1].Value = reader.GetValue(1);
                }
                con.Close();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
