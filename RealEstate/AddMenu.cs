using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;

namespace RealEstate
{
    //해야할것 라디오 버튼 매매 준비 이런거 상태 추가해야함
    public interface DBInterface
    {
        void setDBfile(String DBFile);
    }
    public partial class AddMenu : Form, DBInterface
    {
        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x0;
        private const int MF_GRAYED = 0x1;
        private const int MF_DISABLED = 0x2;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

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
        public int profilePictureID=-1;
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        DataGridView dgv;



        // DataGridView 설정

        private void readDataGrid()
        {
            /*
             "Create table if not exists info2 (0id INTEGER  PRIMARY KEY autoincrement, 1buildingID INTEGER,2 floor NUMERIC, 3area NUMERIC, 4storeName varchar(100), "
             + "5deposit NUMERIC, 6monthlyIncome NUMERIC, 7managementPrice NUMERIC, 8etc NUMERIC, FOREIGN KEY(buildingID) REFERENCES info1(id))";
             */

            int i = 0;

            try
            {
                SQLiteConnection con = new SQLiteConnection();
                strConn = "Data Source=" + DBFile + "; Version=3;";
                con.ConnectionString = strConn;

                // 여기 select * from info2 where id=? 로 고쳐
                SQLiteCommand sqlCMD = new SQLiteCommand("select * from info2", con);
                SQLiteDataReader reader;
                con.Open();
                reader = sqlCMD.ExecuteReader();

                while(reader.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells[0].Value = reader.GetValue(0);

                    dgv.Rows[i].Cells[1].Value = reader.GetValue(2);

                    dgv.Rows[i].Cells[2].Value = reader.GetValue(3);

                    dgv.Rows[i].Cells[3].Value = reader.GetValue(4);

                    dgv.Rows[i].Cells[4].Value = reader.GetValue(5);

                    dgv.Rows[i].Cells[5].Value = reader.GetValue(6);

                    dgv.Rows[i].Cells[6].Value = reader.GetValue(7);

                    dgv.Rows[i].Cells[7].Value = reader.GetValue(8);
                    i++;
                }
                con.Close();
            } catch(SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }
            
            // Get sum of each column and add additional column and shows
            double sumofArea = 0, sumofDeposit = 0, sumofMonthlyIncome = 0, sumofManagementPrice = 0;
            
            for(i=0;i<dgv.Rows.Count-1;++i)
            {
                if (dgv.Rows[i].Cells[2].Value != DBNull.Value)
                    sumofArea += Convert.ToDouble(dgv.Rows[i].Cells[2].Value);
                if (dgv.Rows[i].Cells[4].Value != DBNull.Value)
                    sumofDeposit += Convert.ToDouble(dgv.Rows[i].Cells[4].Value);
                if (dgv.Rows[i].Cells[5].Value != DBNull.Value)
                    sumofMonthlyIncome += Convert.ToDouble(dgv.Rows[i].Cells[5].Value);
                if (dgv.Rows[i].Cells[6].Value != DBNull.Value)
                    sumofManagementPrice += Convert.ToDouble(dgv.Rows[i].Cells[6].Value);
            }
            
            dgv.Rows.Add();
            i = dgv.Rows.Count-1;

            dgv.Rows[i].Cells[0].Value = "합계";
            dgv.Rows[i].Cells[2].Value = sumofArea;
            dgv.Rows[i].Cells[4].Value = sumofDeposit;
            dgv.Rows[i].Cells[5].Value = sumofMonthlyIncome;
            dgv.Rows[i].Cells[6].Value = sumofManagementPrice;
            
            dgv.Refresh();
        }

        private void saveDataGrid()
        {
            /*
            "Create table if not exists info2 (id INTEGER  PRIMARY KEY autoincrement, buildingID INTEGER, floor NUMERIC, area NUMERIC, storeName varchar(100), "
            + "deposit NUMERIC, monthlyIncome NUMERIC, managementPrice NUMERIC, etc NUMERIC, FOREIGN KEY(buildingID) REFERENCES info1(id))";

            */
            int i, rowCount = 0;

            // Get RowCount
            rowCount = dgv.Rows.Count;

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO info2 VALUES(@id, @buildingID, @floor, @area, @storeName, @deposit, @monthlyIncome, @managementPrice, @etc)", con);
                con.Open();
                for (i = 0; i < rowCount; i++)
                {
                    //cmd.Parameters.AddWithValue("@id", dgv.Rows[i].Cells["id"].Value);
                    cmd.Parameters.AddWithValue("@id", null);
                    cmd.Parameters.AddWithValue("@buildingID", getid());
                    cmd.Parameters.AddWithValue("@floor", dgv.Rows[i].Cells["floor"].Value);
                    cmd.Parameters.AddWithValue("@area", dgv.Rows[i].Cells["floor_area"].Value);
                    cmd.Parameters.AddWithValue("@storeName", dgv.Rows[i].Cells["storeName"].Value);
                    cmd.Parameters.AddWithValue("@deposit", dgv.Rows[i].Cells["storeDeposit"].Value);
                    cmd.Parameters.AddWithValue("@monthlyIncome", dgv.Rows[i].Cells["monthlyIncome"].Value);
                    cmd.Parameters.AddWithValue("@managementPrice", dgv.Rows[i].Cells["managementPrice"].Value);
                    cmd.Parameters.AddWithValue("@etc", dgv.Rows[i].Cells["etc"].Value);

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            } catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }

        private void setData()
        {
            addr = TB_Addr.Text.ToString();
            roadAddr = TB_RoadAddr.Text.ToString();
            area = TB_Area.Text.ToString();
            station = TB_Distance.Text.ToString();
            useArea = TB_UseDistrict.Text.ToString();
            
            distance = checkNulls(TB_Station.Text.ToString());
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

        private void saveData()
        {

            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            string query = "insert into info1(id, addr, roadAddr, area, station, useArea, distance, roadWidth, totalArea, completeYear,"
                + " parking, acHeating, EV, buildingName, owner, tel, meno, deposit, income, loan, interest, takeOverPrice,"
                + " sellPrice, payedPrice, yearPercent, type, state, premium, monthlyPay, maintenance, isCorner, profilePictureID) values(null, '" + addr + "', '" + roadAddr + "', '" + area + "', '" + station + "', "
                + "'" + useArea + "', '" + distance + "', '" + roadWidth + "', '" + totalArea + "', '" + completeYear + "', '" + parking + "', "
                + "'" + acHeating + "', '" + EV + "', '" + buildingName + "', '" + owner + "', '" + tel + "', '" + meno + "', " + deposit + ", "
                + Income + ", " + loan + ", " + interest + ", " + takeOverPrice + ", " + sellPrice + ", " + payedPrice + ", " + yearPercent+ ", "
                + type + ", " + state + ", " + premium + ", " + monthlyPay + ", " + maintenance + ", " + isCorner + ", " +profilePictureID +")";
            
            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab_control.SelectedTab == Page_prepare)
            {
                state = 1;
            }

            else if (Tab_control.SelectedTab == Page_complete)
            {
                state = 2;
            }

            else if (Tab_control.SelectedTab == Page_wait)
            {
                state = 3;
            }

            else if (Tab_control.SelectedTab == Page_sell)
            {
                state = 4;
            }
        }

        private int getid()
        {
            int tableID = 0;

            cn.Open();
            string query = "select MAX(id) from info1";
            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (!rdr[0].ToString().Equals(""))
                    tableID = int.Parse(rdr[0].ToString());
            }
            cn.Close();

            return tableID;
        }

        void test()
        {
            //DBFile = "C:/Users/HUN/Desktop/DB.db";

            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            String query = "select * from info1";

            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string a="";
                int i;
                for (i = 0; i < 31; i++)
                {
                    a += rdr[i];
                }
                //MessageBox.Show(a);
            }

            rdr.Close();
            cn.Close();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (type == -1)
            {
                MessageBox.Show("건물 종류를 선택해주세요");
            }
            else
            {
                setData();
                saveData();
                saveDataGrid();
                MessageBox.Show("저장 완료 했습니다.");
                this.Close();
                
            }
        }


        public AddMenu()
        {
            InitializeComponent();
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);

            type = -1;
            state = 1;
            isCorner = 0;

            strConn = "Data Source=" + DBFile + "; Version=3;";

        }
        // 코멘트에 더하기
        private void AddComment(int idx, string content)
        {
            ListViewItem lvi = new ListViewItem(idx.ToString());
            lvi.SubItems.Add(content);
            listView1.Items.Add(lvi);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        // 코멘트 부분

      

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        

        private void AddMenu_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection();
            cmd = new SQLiteCommand();
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;

            dgv = ContentOfRentals;
            dgv.AutoGenerateColumns = false;
            dgv.Columns[0].ReadOnly = true;
            readDataGrid();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int tableID=0;
            ShowPicture showpicture = new ShowPicture();
            showpicture.setDBfile(DBFile);
            showpicture.setMode("addMode");
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            string query = "select MAX(id) from info1";
            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if(!rdr[0].ToString().Equals(""))
                    tableID = int.Parse(rdr[0].ToString());
            }
            cn.Close();
            tableID+=1;
            showpicture.tableID = tableID;
            showpicture.Owner = this;
            showpicture.Show();
        }
        private void notSaveClose()
        {
            int tableID = 0;
            cn.Open();
            string query = "select MAX(id) from info1";
            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                if (!rdr[0].ToString().Equals(""))
                    tableID = int.Parse(rdr[0].ToString());
            }
            rdr.Close();
            tableID += 1;
            cmd.CommandText = "drop table if exists picture" + tableID;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
       

        

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            } else
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

        private void AddMenu_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CB_corner_CheckedChanged(object sender, EventArgs e)
        {
            if(CB_corner.Checked)
            {
                isCorner = 1;
            }
            else
            {
                isCorner = 0;
            }
        }

        private void ContentOfRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void loadPicture(string tableName)
        {
            if (profilePictureID != -1)
            {
                cn.Open();
                string query = "select picture from "+tableName+" where id = " + profilePictureID;
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

        private void btn_JustClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("저장하지않고 종료하겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                notSaveClose();
                this.Close();

            }

        }
    }
}
