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
        //X버튼 금지
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
        //프로필 유무
        public int profilePictureID=-1;
        //숫자를 글자로 만들 때 에러 유무
        int ErrorStr2Num; 

        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        DataGridView dgv, commentview, memoview;

        private void saveDataGrid()
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO info2 VALUES(@id, @buildingID, @floor, @area, @storeName, @deposit, @monthlyIncome, @managementPrice, @etc)", con);
                con.Open();
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
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

        private void setData() //작성한 데이터 저장하기
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
            //상가 일 때 상가가 아닐 때 수입 저장 위치
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
            double number= 0;
            num.Trim(); //공백 제거
            if (num.Equals(""))
                return -9999; //빈값 처리
            try
            {
                number = double.Parse(num);
            }
            catch(Exception ex)
            {
                ErrorStr2Num = -1; //에러가 났음을 알려줌 그경우 number는 0으로 리턴
            }
            return number;

        }

        private void saveData() //info1 테이블 insert하는 함수
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
        
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e) //건물 상태에 대한 정보 저장
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

        private int getid() //저장할 id 정하기  기존에 저장된 id최대값에서 +1
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

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            ErrorStr2Num = 0;
            if (type == -1)
            {
                MessageBox.Show("건물 종류를 선택해주세요");
            }
            else
            {
                setData();
                if (ErrorStr2Num == 0)
                {
                    saveData();
                    saveDataGrid();
                    insertComment();
                    insertMemo();
                    MessageBox.Show("저장 완료 했습니다.");
                    this.Close();
                }
                else
                    MessageBox.Show("숫자 입력란에 숫자만 넣어주세요. 다시 확인해주세요 ");
            }
        }


        public AddMenu()
        {
            InitializeComponent();
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);

            //미선택을 초기화함
            type = -1;
            state = 1;
            isCorner = 0;

            strConn = "Data Source=" + DBFile + "; Version=3;";

        }
        
        private void AddMenu_Load(object sender, EventArgs e)
        {
            cn = new SQLiteConnection();
            cmd = new SQLiteCommand();
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;

            dgv = ContentOfRentals;
            dgv.AutoGenerateColumns = false;

            commentview = commentGridView;
            commentview.AutoGenerateColumns = false;
            commentview.RowHeadersVisible = false;
            commentview.Columns[0].ReadOnly = true;
            commentview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            memoview = memoGridView;
            memoview.RowHeadersVisible = false;
            memoview.AutoGenerateColumns = false;
            memoview.Columns[0].ReadOnly = true;
            memoview.Columns[0].Width = memoview.Width / 4;
            memoview.Columns[1].Width = memoview.Width - memoview.Columns[0].Width - 1;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int tableID=0; //저장할 picture테이블의 명 id
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
            showpicture.tableID = tableID; //테이블 id보내줘서 picture+id로 테이블 생성
            showpicture.Owner = this;
            showpicture.Show();
        }
        private void notSaveClose() //저장안함 할 경우 해당 picture 테이블 삭제
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
       
        private void radioButton_CheckedChanged(object sender, EventArgs e) //건물 종류에 따른 TB설정 
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

        private void CB_corner_CheckedChanged(object sender, EventArgs e) //코너 유무
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
        
        public void loadPicture(string tableName) //프로필 사진 불러오기위해 추가
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

        private void btn_JustClose_Click(object sender, EventArgs e) //저장안하기 클릭시
        {
            DialogResult dr = MessageBox.Show("저장하지않고 종료하겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                notSaveClose();
                this.Close();

            }

        }
        private void updateTB() //숫자만 입력했을 떄 인식하도록 해주고, 수식 계산 해줌 
        {
            double UpdateSellPrice = checkNulls(TB_SellPrice.Text.ToString());
            double UpdateDeposit = checkNulls(TB_Deposit.Text.ToString());
            double UpdateLoan = checkNulls(TB_Loan.Text.ToString());
            double UpdateTakeOverPrice = -9999;
            double UpdateIncome;
            double UpdateYearPercent;

            if (UpdateSellPrice != -9999 && UpdateDeposit != -9999 && UpdateLoan != -9999) //인수금액 연산
            {
                UpdateTakeOverPrice = UpdateSellPrice - UpdateDeposit - UpdateLoan;
                TB_TakeOverPrice.Text = UpdateTakeOverPrice.ToString();
            }
            else
                TB_TakeOverPrice.Text = "";

            if (type != 6)
            {
                UpdateIncome = checkNulls(TB_Income.Text.ToString());
            }
            else
            {
                UpdateIncome = checkNulls(TB_Income2.Text.ToString());
            }
            if (UpdateTakeOverPrice != -9999 && UpdateIncome != -9999) //연수익 연산
            {

                UpdateYearPercent = UpdateIncome / UpdateTakeOverPrice * 12 * 100;
                UpdateYearPercent = Math.Ceiling(UpdateYearPercent / 0.1) * 0.1;
                TB_YearPercent.Text = UpdateYearPercent.ToString();
            }
            else
                TB_YearPercent.Text = "";
        }


        private void TB_NUMTextChanged(object sender, EventArgs e)
        {
            updateTB();
        }

        private void addRow_Click(object sender, EventArgs e)
        {
            dgv.Rows.Add();
        }

        private void deleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgv.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    dgv.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
        }

        private void insertComment()
        {
            /*
            query = "Create table if not exists comment (id INTEGER PRIMARY KEY AUTOINCREMENT, 
            content varchar(1000), buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            */


            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO comment VALUES(@id, @content, @buildingID)", con);
                con.Open();
                for (int i = 0; i < commentview.Rows.Count; ++i)
                {
                    cmd.Parameters.AddWithValue("@id", null);
                    cmd.Parameters.AddWithValue("@content", commentview.Rows[i].Cells["Content"].Value);
                    cmd.Parameters.AddWithValue("@buildingID", getid());

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void insertMemo()
        {
            /*
            query = "Create table if not exists memo (id INTEGER PRIMARY KEY AUTOINCREMENT, c_date DATE DEFAULT CURRENT_TIMESTAMP, memo varchar(1000)" +
                ", buildingID INTEGER, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            */
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO memo VALUES(@id, @c_date, @memo, @buildingID)", con);
                con.Open();
                for (int i = 0; i < memoview.Rows.Count; ++i)
                {
                    cmd.Parameters.AddWithValue("@id", null);
                    cmd.Parameters.AddWithValue("@c_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@memo", memoview.Rows[i].Cells["memo"].Value);
                    cmd.Parameters.AddWithValue("@buildingID", getid());

                    cmd.ExecuteNonQuery();

                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void addMemo_Click(object sender, EventArgs e)
        {
            memoview.Rows.Add();
        }

        private void deleteMemo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in memoview.SelectedCells)
                if (oneCell.Selected)
                    memoview.Rows.RemoveAt(oneCell.RowIndex);
        }

        private void addcoment_Click(object sender, EventArgs e)
        {
            commentview.Rows.Add();
        }

        private void deletecomment_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in commentview.SelectedCells)
                if (oneCell.Selected)
                    commentview.Rows.RemoveAt(oneCell.RowIndex);
        }
    }
}
