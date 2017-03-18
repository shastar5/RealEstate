using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace RealEstate
{
    public interface IdInterface
    {
        void setID(int id);
    }
    public partial class ManagerView : Form, DBInterface, IdInterface
    {
        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x0;
        private const int MF_GRAYED = 0x1;
        private const int MF_DISABLED = 0x2;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);


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

        public int profilePictureID = -1;

        int ErrorStr2Num;

        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        // Database keyword declare
        int countofrows = 0;
        DataGridView dgv;
        Stack<int> todo = new Stack<int>();
        Stack<int> toinsert = new Stack<int>();

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
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
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
                TB_BuildName.Text = rdr[13].ToString();
                TB_Owner.Text = rdr[14].ToString();
                TB_Tel.Text = rdr[15].ToString();
                TB_Memo.Text = rdr[16].ToString();

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

                if (rdr[23].ToString().Equals("-9999"))
                    TB_PayedPrice.Text = "";
                else
                    TB_PayedPrice.Text = rdr[23].ToString();

                if (rdr[24].ToString().Equals("-9999"))
                    TB_YearPercent.Text = "";
                else
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
                if(isCorner==0)
                {
                    CB_corner.Checked = false;
                }
                else
                {
                    CB_corner.Checked = true;
                }
               profilePictureID = int.Parse(rdr[31].ToString());
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
                ErrorStr2Num = -1;
            }
            return number;
        }

        private void updateDataGrid()
        {
            /*
            "Create table if not exists info2 (id INTEGER  PRIMARY KEY autoincrement, buildingID INTEGER, floor NUMERIC, area NUMERIC, storeName varchar(100), "
            + "deposit NUMERIC, monthlyIncome NUMERIC, managementPrice NUMERIC, etc NUMERIC, FOREIGN KEY(buildingID) REFERENCES info1(id))";

            */
            int i, rowCount = 0, rowNum;

            // Get RowCount
            rowCount = dgv.Rows.Count;

            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            string sql = "UPDATE info2 SET floor = @floor, area = @area, storeName = @storeName," +
                " deposit = @deposit, monthlyIncome = @monthlyIncome, managementPrice = @managementPrice, etc = @etc where id = @id AND buildingID = " + id;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                con.Open();

                // 업데이트가 필요한 위치를 찾아서 저장함
                for(rowNum =0;rowNum<rowCount;++rowNum)
                {
                    if (dgv.Rows[rowNum].Cells[0].Value == null)
                        break;
                }

                for (i = 0; i < rowNum; ++i)
                {
                    cmd.Parameters.AddWithValue("@floor", dgv.Rows[i].Cells["floor"].Value);
                    cmd.Parameters.AddWithValue("@area", dgv.Rows[i].Cells["floor_area"].Value);
                    cmd.Parameters.AddWithValue("@storeName", dgv.Rows[i].Cells["storeName"].Value);
                    cmd.Parameters.AddWithValue("@deposit", dgv.Rows[i].Cells["storeDeposit"].Value);
                    cmd.Parameters.AddWithValue("@monthlyIncome", dgv.Rows[i].Cells["monthlyIncome"].Value);
                    cmd.Parameters.AddWithValue("@managementPrice", dgv.Rows[i].Cells["managementPrice"].Value);
                    cmd.Parameters.AddWithValue("@etc", dgv.Rows[i].Cells["etc"].Value);
                    cmd.Parameters.AddWithValue("@id", dgv.Rows[i].Cells["_id"].Value);

                    cmd.ExecuteNonQuery();

                }

                
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void deleteDataGrid()
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            string sql = "DELETE FROM info2 WHERE id = @id AND buildingID = " + id;
            cmd = new SQLiteCommand(sql, con);
            con.Open();
            int count = todo.Count;

            while (todo.Count > 0)
            {
                for(int i=0;i<count;++i)
                {
                    int num = todo.Pop();

                    cmd.Parameters.AddWithValue("@floor", dgv.Rows[num].Cells["floor"].Value);
                    cmd.Parameters.AddWithValue("@area", dgv.Rows[num].Cells["floor_area"].Value);
                    cmd.Parameters.AddWithValue("@storeName", dgv.Rows[num].Cells["storeName"].Value);
                    cmd.Parameters.AddWithValue("@deposit", dgv.Rows[num].Cells["storeDeposit"].Value);
                    cmd.Parameters.AddWithValue("@monthlyIncome", dgv.Rows[num].Cells["monthlyIncome"].Value);
                    cmd.Parameters.AddWithValue("@managementPrice", dgv.Rows[num].Cells["managementPrice"].Value);
                    cmd.Parameters.AddWithValue("@etc", dgv.Rows[num].Cells["etc"].Value);
                    cmd.Parameters.AddWithValue("@id", dgv.Rows[num].Cells["_id"].Value);

                    cmd.ExecuteNonQuery();
                }
            }

            con.Close();
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
                countofrows = i;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }

            showSum();
        }

        private void showSum()
        {
            int i;
            // Get sum of each column and add additional column and shows
            double sumofArea = 0, sumofDeposit = 0, sumofMonthlyIncome = 0, sumofManagementPrice = 0;

            for (i = 0; i < dgv.Rows.Count - 1; ++i)
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

            i = countofrows;

            dgv.Rows.Add();
            dgv.Rows[i].Cells[0].Value = "합계";
            dgv.Rows[i].Cells[2].Value = sumofArea;
            dgv.Rows[i].Cells[4].Value = sumofDeposit;
            dgv.Rows[i].Cells[5].Value = sumofMonthlyIncome;
            dgv.Rows[i].Cells[6].Value = sumofManagementPrice;

            dgv.Refresh();
        }

        private int getid()
        {
            int tableID = 0;

            cn.Open();
            string query = "select MAX(id) from info2";
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

        private void InsertRowsDataGridView()
        {
            /*
            "Create table if not exists info2 (id INTEGER  PRIMARY KEY autoincrement, buildingID INTEGER, floor NUMERIC, area NUMERIC, storeName varchar(100), "
            + "deposit NUMERIC, monthlyIncome NUMERIC, managementPrice NUMERIC, etc NUMERIC, FOREIGN KEY(buildingID) REFERENCES info1(id))";
            */
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO info2 VALUES(@id, @buildingID, @floor, @area, @storeName, @deposit, @monthlyIncome, @managementPrice, @etc)", con);
                con.Open();

                while(toinsert.Count > 0)
                {
                    int i = toinsert.Pop() - 1;
                    cmd.Parameters.AddWithValue("@id", null);
                    cmd.Parameters.AddWithValue("@buildingID", id);
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
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void saveData()
        {

            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();

            SQLiteCommand cmd = new SQLiteCommand(cn);
            cmd.CommandText =
                "update info1 SET addr = @Addr , roadAddr = @RoadAddr, area = @Area, station = @Station, useArea = @UseArea, distance = @Distance, "
                 + "roadWidth = @RoadWidth, totalArea = @TotalArea, completeYear = @CompleteYear, parking = @Parking, acHeating = @AcHeating, EV = @EV, "
                 + "buildingName = @BuildingName, owner = @Owner, tel = @Tel, meno = @Meno, deposit = @Deposit, income = @Income, loan = @Loan, "
                 + "interest = @Interest, takeOverPrice = @TakeOverPrice, sellPrice = @SellPrice, payedPrice = @PayedPrice, yearPercent = @YearPercent, "
                 + "type = @Type, state = @State, premium = @Premium, monthlyPay = @MonthlyPay, maintenance = @Maintenance, isCorner = @IsCorner, profilePictureID = @ProfilePictureID where id  = " + id;
            cmd.Parameters.Add(new SQLiteParameter("@Addr") {Value = addr});
            cmd.Parameters.Add(new SQLiteParameter("@RoadAddr") { Value = roadAddr });
            cmd.Parameters.Add(new SQLiteParameter("@Area") {Value = area});
            cmd.Parameters.Add(new SQLiteParameter("@Station") {Value = station});
            cmd.Parameters.Add(new SQLiteParameter("@UseArea") {Value = useArea});
            
            cmd.Parameters.Add(new SQLiteParameter("@Distance") {Value = distance});
            cmd.Parameters.Add(new SQLiteParameter("@RoadWidth") {Value = roadWidth});
            cmd.Parameters.Add(new SQLiteParameter("@TotalArea") {Value = totalArea});
            cmd.Parameters.Add(new SQLiteParameter("@CompleteYear") {Value = completeYear});
            cmd.Parameters.Add(new SQLiteParameter("@Parking") {Value = parking});
            cmd.Parameters.Add(new SQLiteParameter("@AcHeating") {Value = acHeating});
            cmd.Parameters.Add(new SQLiteParameter("@EV") {Value = EV});
            cmd.Parameters.Add(new SQLiteParameter("@BuildingName") { Value = buildingName });

            cmd.Parameters.Add(new SQLiteParameter("@Owner") {Value = owner});
            cmd.Parameters.Add(new SQLiteParameter("@Tel") {Value = tel});
            cmd.Parameters.Add(new SQLiteParameter("@Meno") {Value = meno});
            cmd.Parameters.Add(new SQLiteParameter("@Deposit") {Value = deposit});
            cmd.Parameters.Add(new SQLiteParameter("@Income") {Value = Income});
            cmd.Parameters.Add(new SQLiteParameter("@Loan") {Value = loan});
            cmd.Parameters.Add(new SQLiteParameter("@Interest") {Value = interest});
            cmd.Parameters.Add(new SQLiteParameter("@TakeOverPrice") {Value = takeOverPrice});
            cmd.Parameters.Add(new SQLiteParameter("@SellPrice") {Value = sellPrice});
            cmd.Parameters.Add(new SQLiteParameter("@PayedPrice") {Value = payedPrice});
            cmd.Parameters.Add(new SQLiteParameter("@YearPercent") {Value = yearPercent});
            cmd.Parameters.Add(new SQLiteParameter("@Type") {Value = type});
            cmd.Parameters.Add(new SQLiteParameter("@State") {Value = state});
            cmd.Parameters.Add(new SQLiteParameter("@Premium") {Value = premium});
            cmd.Parameters.Add(new SQLiteParameter("@MonthlyPay") {Value = monthlyPay});
            cmd.Parameters.Add(new SQLiteParameter("@Maintenance") {Value = maintenance});
            cmd.Parameters.Add(new SQLiteParameter("@IsCorner") {Value = isCorner});
            cmd.Parameters.Add(new SQLiteParameter("@ProfilePictureID") { Value = profilePictureID });


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

        public void loadPicture(string tableName)
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
                cn.Close();
                byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
                MemoryStream ms = new MemoryStream(ap);
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                ms.Close();
                cn.Close();
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void ManagerView_Load(object sender, EventArgs e)
        {
            readDataGrid();
            readData();
            loadPicture("picture" + id);
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            ErrorStr2Num = 0;
            setData();
            if (ErrorStr2Num == 0)
            {
                saveData();
                updateDataGrid();
                InsertRowsDataGridView();
                MessageBox.Show("저장 완료 했습니다.");
                this.Close();
            }
            else
                MessageBox.Show("숫자 입력란에 숫자만 넣어주세요. 다시 확인해주세요 ");

        }

        private void readProfilePicture()
        {
            cn.Open();
            String query = "select profilePictureID from info1 where id = " + id;

            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                profilePictureID = int.Parse(rdr[0].ToString());
            }
            cn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int isOpen = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.Equals("ShowPicture"))
                {
                    isOpen = 1;
                    MessageBox.Show("사진추가/삭제 창이 이미 열려 있습니다.");
                }
            }
            if (isOpen == 0)
            {
                readProfilePicture();
                ShowPicture showpicture = new ShowPicture();
                showpicture.setDBfile(DBFile);
                showpicture.Owner = this;
                showpicture.tableID = id;
                showpicture.profilePictureID = profilePictureID;
                showpicture.setMode("managerMode");
                showpicture.Show();
            }
        }

        private void deleteSum()
        {
            if (dgv.Rows.Count > 1)
            {
                dgv.Rows.RemoveAt(dgv.Rows.Count - 2);
            }
        }

        private void add_row_Click(object sender, EventArgs e)
        {
            toinsert.Push(dgv.Rows.Add());
            deleteSum();
            countofrows++;
            showSum();
        }

        private void delete_row_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgv.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    todo.Push(oneCell.RowIndex);
                    deleteDataGrid();
                    dgv.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
        }
    }

}
