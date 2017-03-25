using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System.Windows.Xps.Packaging;

namespace RealEstate
{
    public interface IdInterface
    {
        void setID(int id);
    }
    public partial class ManagerView : Form, DBInterface, IdInterface, FIndInterface
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

        Findvalue findvalue = new Findvalue();
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        // Database keyword declare

        int countofrows = 0;
        DataGridView dgv, commentview, memoview;
        // dgv's stack
        Queue<int> todo = new Queue<int>();
        Stack<int> commentdelete = new Stack<int>();
        Stack<int> memodelete = new Stack<int>();

        string strConn2 = "Server=104.199.249.56;Database=realestate;Uid=realestate_admin;Pwd=123456;";
        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }
        public void setID(int id)
        {
            this.id = id;
        }
        public void setValue(Findvalue FV)
        {
            findvalue = FV;
        }
        public ManagerView()
        {
            InitializeComponent();
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
            dgv = ContentOfRentals;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            commentview = commentGridView;
            commentview.AutoGenerateColumns = false;
            commentview.RowHeadersVisible = false;
            commentview.Columns[0].ReadOnly = true;
            commentview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            memoview = memoGridView;
            memoview.RowHeadersVisible = false;
            memoview.AutoGenerateColumns = false;
            memoview.Columns[1].Width = Convert.ToInt32(memoview.Width * 0.33);
            memoview.Columns[2].Width = memoview.Width - memoview.Columns[1].Width - 1;
            memoview.Columns[0].Visible = false;
            commentview.Columns[0].Visible = false;
        }
        private void readData2()
        {
            string query = "select * from info1 where id = " + id;
            MySqlConnection conn = new MySqlConnection(strConn2);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
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
                    case 1:
                        Dagagu.Checked = true;
                        break;
                    case 2:
                        Building.Checked = true;
                        break;
                    case 4:
                        SanggaHome.Checked = true;
                        break;
                    case 8:
                        NewConstruction.Checked = true;
                        break;
                    case 16:
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
                profilePictureID = int.Parse(rdr[31].ToString());
            }

            rdr.Close();
            conn.Close();
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
                    case 1:
                        Dagagu.Checked = true;
                        break;
                    case 2:
                        Building.Checked = true;
                        break;
                    case 4:
                        SanggaHome.Checked = true;
                        break;
                    case 8:
                        NewConstruction.Checked = true;
                        break;
                    case 16:
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
            if (type != 16)
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

        private void updateDataGrid2(int i)
        {
            MySqlConnection conn = new MySqlConnection(strConn2);
            string query = "UPDATE info2 SET floor = @floor, area = @area, storeName = @storeName," +
                " deposit = @deposit, monthlyIncome = @monthlyIncome, managementPrice = @managementPrice, etc = @etc where id = @id AND buildingID = " + id;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@floor", dgv.Rows[i].Cells["floor"].Value);
                cmd.Parameters.AddWithValue("@area", dgv.Rows[i].Cells["floor_area"].Value);
                cmd.Parameters.AddWithValue("@storeName", dgv.Rows[i].Cells["storeName"].Value);
                cmd.Parameters.AddWithValue("@deposit", dgv.Rows[i].Cells["storeDeposit"].Value);
                cmd.Parameters.AddWithValue("@monthlyIncome", dgv.Rows[i].Cells["monthlyIncome"].Value);
                cmd.Parameters.AddWithValue("@managementPrice", dgv.Rows[i].Cells["managementPrice"].Value);
                cmd.Parameters.AddWithValue("@etc", dgv.Rows[i].Cells["etc"].Value);
                cmd.Parameters.AddWithValue("@id", dgv.Rows[i].Cells["_id"].Value);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void updateDataGrid(int i)
        {
            /*
            "Create table if not exists info2 (id INTEGER  PRIMARY KEY autoincrement, buildingID INTEGER, floor NUMERIC, area NUMERIC, storeName varchar(100), "
            + "deposit NUMERIC, monthlyIncome NUMERIC, managementPrice NUMERIC, etc NUMERIC, FOREIGN KEY(buildingID) REFERENCES info1(id))";

            */
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            string sql = "UPDATE info2 SET floor = @floor, area = @area, storeName = @storeName," +
                " deposit = @deposit, monthlyIncome = @monthlyIncome, managementPrice = @managementPrice, etc = @etc where id = @id AND buildingID = " + id;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                con.Open();

                cmd.Parameters.AddWithValue("@floor", dgv.Rows[i].Cells["floor"].Value);
                cmd.Parameters.AddWithValue("@area", dgv.Rows[i].Cells["floor_area"].Value);
                cmd.Parameters.AddWithValue("@storeName", dgv.Rows[i].Cells["storeName"].Value);
                cmd.Parameters.AddWithValue("@deposit", dgv.Rows[i].Cells["storeDeposit"].Value);
                cmd.Parameters.AddWithValue("@monthlyIncome", dgv.Rows[i].Cells["monthlyIncome"].Value);
                cmd.Parameters.AddWithValue("@managementPrice", dgv.Rows[i].Cells["managementPrice"].Value);
                cmd.Parameters.AddWithValue("@etc", dgv.Rows[i].Cells["etc"].Value);
                cmd.Parameters.AddWithValue("@id", dgv.Rows[i].Cells["_id"].Value);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void updatecomment2(int index)
        {
            MySqlConnection conn = new MySqlConnection(strConn2);
            string query = "UPDATE comment SET content = @content WHERE id = @id AND buildingID = " + id;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {

                cmd.Parameters.AddWithValue("@content", commentview.Rows[index].Cells["Content"].Value);
                cmd.Parameters.AddWithValue("@id", commentview.Rows[index].Cells["order"].Value);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void updatecomment(int index)
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            string sql = "UPDATE comment SET content = @content WHERE id = @id AND buildingID = " + id;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                con.Open();

                cmd.Parameters.AddWithValue("@content", commentview.Rows[index].Cells["Content"].Value);
                cmd.Parameters.AddWithValue("@id", commentview.Rows[index].Cells["order"].Value);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void updatememo2(int index)
        {
            MySqlConnection conn = new MySqlConnection(strConn2);
            string query = "UPDATE memo SET c_date = @c_date, memo = @memo WHERE id = @id AND buildingID = " + id;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {

                cmd.Parameters.AddWithValue("@c_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@memo", memoview.Rows[index].Cells[2].Value);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void updatememo(int index)
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            string sql = "UPDATE memo SET c_date = @c_date, memo = @memo WHERE id = @id AND buildingID = " + id;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                con.Open();

                cmd.Parameters.AddWithValue("@c_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@memo", memoview.Rows[index].Cells[2].Value);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void deleteDataGrid2()
        {
            MySqlConnection conn = new MySqlConnection(strConn2);
            string query = "DELETE FROM info2 WHERE id = @id AND buildingID = " + id;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int count = todo.Count;

            for (int j = 0; j < count; ++j)
            {
                int num = todo.Dequeue();

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

            conn.Close();
        }
        private void deleteDataGrid()
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            string sql = "DELETE FROM info2 WHERE id = @id AND buildingID = " + id;
            cmd = new SQLiteCommand(sql, con);
            con.Open();
            int count = todo.Count;

            for (int j = 0; j < count; ++j)
            {
                int num = todo.Dequeue();

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

            con.Close();
        }

        private void readDataGrid2()
        {
            int i = 0;
            string query = "select * from info2 where buildingId =" + id;
            try
            {
                MySqlConnection conn = new MySqlConnection(strConn2);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells[0].Value = rdr.GetValue(0);
                    dgv.Rows[i].Cells[1].Value = rdr.GetValue(2);
                    dgv.Rows[i].Cells[2].Value = rdr.GetValue(3);
                    dgv.Rows[i].Cells[3].Value = rdr.GetValue(4);
                    dgv.Rows[i].Cells[4].Value = rdr.GetValue(5);
                    dgv.Rows[i].Cells[5].Value = rdr.GetValue(6);
                    dgv.Rows[i].Cells[6].Value = rdr.GetValue(7);
                    dgv.Rows[i].Cells[7].Value = rdr.GetValue(8);
                    i++;
                }
                conn.Close();
                countofrows = i;
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }

            //dgv.Sort(dgv.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
            dgv.Columns[0].Visible = false;

            showSum();
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

            dgv.Sort(dgv.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
            dgv.Columns[0].Visible = false;

            showSum();
        }

        private void showSum()
        {
            int i;
            // Get sum of each column and add additional column and shows
            double sumofArea = 0, sumofDeposit = 0, sumofMonthlyIncome = 0, sumofManagementPrice = 0;

            if (dgv.Rows.Count == 0)
                return;
            for (i = 0; i < dgv.Rows.Count; ++i)
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

            i = dgv.Rows.Add();
            dgv.Rows[i].Cells[1].Value = "합계";
            dgv.Rows[i].Cells[2].Value = sumofArea;
            dgv.Rows[i].Cells[3].Value = null;
            dgv.Rows[i].Cells[4].Value = sumofDeposit;
            dgv.Rows[i].Cells[5].Value = sumofMonthlyIncome;
            dgv.Rows[i].Cells[6].Value = sumofManagementPrice;
            dgv.Rows[i].Cells[7].Value = null;

            dgv.Refresh();
        }

        private double getSumofIncome()
        {
            int i;
            double sumofMonthlyIncome = 0;

            if (dgv.Rows.Count == 0)
                return 0;

            for (i = 0; i < dgv.Rows.Count - 1; ++i)
            {
                if (dgv.Rows[i].Cells[5].Value != DBNull.Value)
                    sumofMonthlyIncome += Convert.ToDouble(dgv.Rows[i].Cells[5].Value);
            }

            return sumofMonthlyIncome;
        }
        private void InsertRowsDataGridView2(int i)
        {
            MySqlConnection conn = new MySqlConnection(strConn2);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO info2 VALUES(@id, @buildingID, @floor, @area, @storeName, @deposit, @monthlyIncome, @managementPrice, @etc)", conn);
                if (dgv.Rows.Count != 0)
                {
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

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        private void InsertRowsDataGridView(int i)
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

                if (dgv.Rows.Count != 0)
                {
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

        private void saveData2()
        {
            MySqlConnection conn = new MySqlConnection(strConn2);
            string query = "update info1 SET addr = @Addr , roadAddr = @RoadAddr, area = @Area, station = @Station, useArea = @UseArea, distance = @Distance, "
                 + "roadWidth = @RoadWidth, totalArea = @TotalArea, completeYear = @CompleteYear, parking = @Parking, acHeating = @AcHeating, EV = @EV, "
                 + "buildingName = @BuildingName, owner = @Owner, tel = @Tel, meno = @Meno, deposit = @Deposit, income = @Income, loan = @Loan, "
                 + "interest = @Interest, takeOverPrice = @TakeOverPrice, sellPrice = @SellPrice, payedPrice = @PayedPrice, yearPercent = @YearPercent, "
                 + "type = @Type, state = @State, premium = @Premium, monthlyPay = @MonthlyPay, maintenance = @Maintenance, isCorner = @IsCorner, profilePictureID = @ProfilePictureID where id  = " + id;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.Add(new MySqlParameter("@Addr", MySqlDbType.String) { Value = addr });
            cmd.Parameters.Add(new MySqlParameter("@RoadAddr", MySqlDbType.String) { Value = roadAddr });
            cmd.Parameters.Add(new MySqlParameter("@Area", MySqlDbType.String) { Value = area });
            cmd.Parameters.Add(new MySqlParameter("@Station", MySqlDbType.String) { Value = station });
            cmd.Parameters.Add(new MySqlParameter("@UseArea", MySqlDbType.String) { Value = useArea });

            cmd.Parameters.Add(new MySqlParameter("@Distance", MySqlDbType.Double) { Value = distance });
            cmd.Parameters.Add(new MySqlParameter("@RoadWidth", MySqlDbType.Double) { Value = roadWidth });
            cmd.Parameters.Add(new MySqlParameter("@TotalArea", MySqlDbType.String) { Value = totalArea });
            cmd.Parameters.Add(new MySqlParameter("@CompleteYear", MySqlDbType.String) { Value = completeYear });
            cmd.Parameters.Add(new MySqlParameter("@Parking", MySqlDbType.String) { Value = parking });
            cmd.Parameters.Add(new MySqlParameter("@AcHeating", MySqlDbType.String) { Value = acHeating });
            cmd.Parameters.Add(new MySqlParameter("@EV", MySqlDbType.String) { Value = EV });
            cmd.Parameters.Add(new MySqlParameter("@BuildingName", MySqlDbType.String) { Value = buildingName });

            cmd.Parameters.Add(new MySqlParameter("@Owner", MySqlDbType.String) { Value = owner });
            cmd.Parameters.Add(new MySqlParameter("@Tel", MySqlDbType.String) { Value = tel });
            cmd.Parameters.Add(new MySqlParameter("@Meno", MySqlDbType.String) { Value = meno });
            cmd.Parameters.Add(new MySqlParameter("@Deposit", MySqlDbType.Double) { Value = deposit });
            cmd.Parameters.Add(new MySqlParameter("@Income", MySqlDbType.Double) { Value = Income });
            cmd.Parameters.Add(new MySqlParameter("@Loan", MySqlDbType.Double) { Value = loan });
            cmd.Parameters.Add(new MySqlParameter("@Interest", MySqlDbType.Double) { Value = interest });
            cmd.Parameters.Add(new MySqlParameter("@TakeOverPrice", MySqlDbType.Double) { Value = takeOverPrice });
            cmd.Parameters.Add(new MySqlParameter("@SellPrice", MySqlDbType.Double) { Value = sellPrice });
            cmd.Parameters.Add(new MySqlParameter("@PayedPrice", MySqlDbType.Double) { Value = payedPrice });
            cmd.Parameters.Add(new MySqlParameter("@YearPercent", MySqlDbType.Double) { Value = yearPercent });
            cmd.Parameters.Add(new MySqlParameter("@Type", MySqlDbType.Int32) { Value = type });
            cmd.Parameters.Add(new MySqlParameter("@State", MySqlDbType.Int32) { Value = state });
            cmd.Parameters.Add(new MySqlParameter("@Premium", MySqlDbType.Double) { Value = premium });
            cmd.Parameters.Add(new MySqlParameter("@MonthlyPay", MySqlDbType.Double) { Value = monthlyPay });
            cmd.Parameters.Add(new MySqlParameter("@Maintenance", MySqlDbType.Double) { Value = maintenance });
            cmd.Parameters.Add(new MySqlParameter("@IsCorner", MySqlDbType.Int32) { Value = isCorner });
            cmd.Parameters.Add(new MySqlParameter("@ProfilePictureID", MySqlDbType.Int32) { Value = profilePictureID });


            cmd.ExecuteNonQuery();
            conn.Close();
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
            cmd.Parameters.Add(new SQLiteParameter("@Addr") { Value = addr });
            cmd.Parameters.Add(new SQLiteParameter("@RoadAddr") { Value = roadAddr });
            cmd.Parameters.Add(new SQLiteParameter("@Area") { Value = area });
            cmd.Parameters.Add(new SQLiteParameter("@Station") { Value = station });
            cmd.Parameters.Add(new SQLiteParameter("@UseArea") { Value = useArea });

            cmd.Parameters.Add(new SQLiteParameter("@Distance") { Value = distance });
            cmd.Parameters.Add(new SQLiteParameter("@RoadWidth") { Value = roadWidth });
            cmd.Parameters.Add(new SQLiteParameter("@TotalArea") { Value = totalArea });
            cmd.Parameters.Add(new SQLiteParameter("@CompleteYear") { Value = completeYear });
            cmd.Parameters.Add(new SQLiteParameter("@Parking") { Value = parking });
            cmd.Parameters.Add(new SQLiteParameter("@AcHeating") { Value = acHeating });
            cmd.Parameters.Add(new SQLiteParameter("@EV") { Value = EV });
            cmd.Parameters.Add(new SQLiteParameter("@BuildingName") { Value = buildingName });

            cmd.Parameters.Add(new SQLiteParameter("@Owner") { Value = owner });
            cmd.Parameters.Add(new SQLiteParameter("@Tel") { Value = tel });
            cmd.Parameters.Add(new SQLiteParameter("@Meno") { Value = meno });
            cmd.Parameters.Add(new SQLiteParameter("@Deposit") { Value = deposit });
            cmd.Parameters.Add(new SQLiteParameter("@Income") { Value = Income });
            cmd.Parameters.Add(new SQLiteParameter("@Loan") { Value = loan });
            cmd.Parameters.Add(new SQLiteParameter("@Interest") { Value = interest });
            cmd.Parameters.Add(new SQLiteParameter("@TakeOverPrice") { Value = takeOverPrice });
            cmd.Parameters.Add(new SQLiteParameter("@SellPrice") { Value = sellPrice });
            cmd.Parameters.Add(new SQLiteParameter("@PayedPrice") { Value = payedPrice });
            cmd.Parameters.Add(new SQLiteParameter("@YearPercent") { Value = yearPercent });
            cmd.Parameters.Add(new SQLiteParameter("@Type") { Value = type });
            cmd.Parameters.Add(new SQLiteParameter("@State") { Value = state });
            cmd.Parameters.Add(new SQLiteParameter("@Premium") { Value = premium });
            cmd.Parameters.Add(new SQLiteParameter("@MonthlyPay") { Value = monthlyPay });
            cmd.Parameters.Add(new SQLiteParameter("@Maintenance") { Value = maintenance });
            cmd.Parameters.Add(new SQLiteParameter("@IsCorner") { Value = isCorner });
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
                type = 1;
            }
            else if (Building.Checked)
            {
                type = 1 << 1;
            }
            else if (SanggaHome.Checked)
            {
                type = 1 << 2;
            }
            else if (NewConstruction.Checked)
            {
                type = 1 << 3;
            }
            if (Sangga.Checked)
            {
                type = 1 << 4;
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
            if (TB_Addr.Text.Equals(null))
            {
                return;
            }
            string addr = "http://map.daum.net/link/search/" + TB_Addr.Text;
            System.Diagnostics.Process.Start(addr);
        }

        public void loadPicture()
        {
            if (profilePictureID != -1)
            {
                cn.Open(); 
                string query = "select picture from pictures where id = " + profilePictureID +" and buildingid = "+id;
                try
                {
                    cmd = new SQLiteCommand(query, cn);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    SQLiteCommandBuilder cbd = new SQLiteCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    cn.Close();
                    byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
                    MemoryStream ms = new MemoryStream(ap);
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                    ms.Close();
                    cn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("열고자하는 부동산의 프로필 사진이 DB파일에 존재 하지 않습니다\n");
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void ManagerView_Load(object sender, EventArgs e)
        {
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            //readData();
            readData2();

            loadPicture();

            //readDataGrid();
            readDataGrid2();

            //readcomment();
            readcomment2();

            //readmemo();
            readmemo2();

            if (dgv.Rows.Count > 0)
            {
                dgv.Columns[0].ReadOnly = true;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                commentview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                commentview.Columns[commentview.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void readcomment2()
        {
            int i = 0;
            string query = "select * from comment where buildingId =" + id;
            try
            {
                MySqlConnection conn = new MySqlConnection(strConn2);

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    commentview.Rows.Add();
                    commentview.Rows[i].Cells[0].Value = rdr.GetValue(0);
                    commentview.Rows[i++].Cells[1].Value = rdr.GetValue(1);
                }
                conn.Close();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }
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
                    commentview.Rows[i].Cells[0].Value = reader.GetValue(0);
                    commentview.Rows[i++].Cells[1].Value = reader.GetValue(1);
                }
                con.Close();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void readmemo2()
        {
            int i = 0;
            string query = "select * from memo where buildingId =" + id;
            try
            {
                MySqlConnection conn = new MySqlConnection(strConn2);

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    memoview.Rows.Add();
                    memoview.Rows[i].Cells[0].Value = rdr.GetValue(0);
                    memoview.Rows[i].Cells[1].Value = rdr.GetValue(1);
                    memoview.Rows[i++].Cells[2].Value = rdr.GetValue(2);
                }
                conn.Close();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void readmemo()
        {
            int i = 0;
            string sql = "select * from memo where buildingId =" + id;
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
                    memoview.Rows.Add();
                    memoview.Rows[i].Cells[0].Value = reader.GetValue(0);
                    memoview.Rows[i].Cells[1].Value = reader.GetValue(1);
                    memoview.Rows[i++].Cells[2].Value = reader.GetValue(2);
                }
                con.Close();
            }
            catch (SQLiteException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            ErrorStr2Num = 0;
            setData();
            int isOpen = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.Equals("ShowPicture"))
                {
                    isOpen = 1;
                }
            }
            if (isOpen == 1)
                MessageBox.Show("사진추가/삭제 창을 닫고 저장해주세요.");
            else if (ErrorStr2Num == 0)
            {
                //saveData();
                saveData2();

                /*
                SQLiteConnection con = new SQLiteConnection();
                con.ConnectionString = strConn;
                string sql = "UPDATE info2 SET floor = @floor, area = @area, storeName = @storeName," +
                " deposit = @deposit, monthlyIncome = @monthlyIncome, managementPrice = @managementPrice, etc = @etc where id = @id AND buildingID = " + id;
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                con.Open();
                */
                for (int i = 0; i < dgv.Rows.Count; ++i)
                {
                    if (dgv.Rows[i].Cells[0].Value != null)
                    {
                        //updateDataGrid(i);
                        updateDataGrid2(i);
                    }
                    else
                    {
                        //InsertRowsDataGridView(i);
                        if(dgv.Rows[i].Cells[1].Value != null)
                            if(!dgv.Rows[i].Cells[1].Value.Equals("합계"))
                                InsertRowsDataGridView2(i);
                    }
                }

                for (int i = 0; i < commentview.Rows.Count; ++i)
                {
                    if (commentview.Rows[i].Cells[0].Value != null)
                    {
                        //updatecomment(i);
                        updatecomment2(i);
                    }
                    else
                    {
                        //insertComment(i);
                        insertComment2(i);
                    }
                }

                for (int i = 0; i < memoview.Rows.Count; ++i)
                {
                    if (memoview.Rows[i].Cells[0].Value != null)
                    {
                        //updatememo(i);
                        updatememo2(i);
                    }
                    else
                    {
                        //insertMemo(i);
                        insertMemo2(i);
                    }
                }
                MessageBox.Show("저장 완료 했습니다.");
                this.Close();
                /*FindView findtest = new FindView();
                findtest.setDBfile(DBFile);
                findtest.setUserType(false);
                findtest.setValue(findvalue);
                findtest.Show();*/
            }
            else
                MessageBox.Show("숫자 입력란에 숫자만 넣어주세요. 다시 확인해주세요 ");

        }
        private void readProfilePicture2()
        {
            MySqlConnection conn = new MySqlConnection(strConn2);
            String query = "select profilePictureID from info1 where id = " + id;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                profilePictureID = int.Parse(rdr[0].ToString());
            }
            conn.Close();
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
                //readProfilePicture();
                readProfilePicture2();
                ShowPicture showpicture = new ShowPicture();
                showpicture.setDBfile(DBFile);
                showpicture.Owner = this;
                showpicture.buildingID = id;
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
            dgv.Rows.Add();
            deleteSum();
            showSum();
        }

        private void delete_row_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgv.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    todo.Enqueue(oneCell.RowIndex);
                    //deleteDataGrid();
                    deleteDataGrid2();
                    dgv.Rows.RemoveAt(oneCell.RowIndex);
                }
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
                {
                    memodelete.Push(oneCell.RowIndex);
                    // deletememo();
                    deletememo2();
                    memoview.Rows.RemoveAt(oneCell.RowIndex);
                }
        }

        private void deletememo2()
        {
            MySqlConnection conn = new MySqlConnection(strConn2);
            string query = "DELETE FROM memo WHERE id = @id AND buildingID = " + id;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            while (memodelete.Count > 0)
            {
                cmd.Parameters.AddWithValue("@id", memoview.Rows[memodelete.Pop()].Cells["memoid"].Value);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
        private void deletememo()
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            string sql = "DELETE FROM memo WHERE id = @id AND buildingID = " + id;
            cmd = new SQLiteCommand(sql, con);
            con.Open();

            while (memodelete.Count > 0)
            {
                cmd.Parameters.AddWithValue("@id", memoview.Rows[memodelete.Pop()].Cells["memoid"].Value);
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }

        private void deleteComment2()
        {
            MySqlConnection conn = new MySqlConnection(strConn2);
            string query = "DELETE FROM comment WHERE id = @id AND buildingID = " + id;

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            while (commentdelete.Count > 0)
            {
                cmd.Parameters.AddWithValue("@id", commentview.Rows[commentdelete.Pop()].Cells["order"].Value);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
        private void deleteComment()
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            string sql = "DELETE FROM comment WHERE id = @id AND buildingID = " + id;
            cmd = new SQLiteCommand(sql, con);
            con.Open();

            while (commentdelete.Count > 0)
            {
                cmd.Parameters.AddWithValue("@id", commentview.Rows[commentdelete.Pop()].Cells["order"].Value);
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }

        private void insertComment2(int index)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strConn2);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO comment VALUES (@id, @content, @buildingID)", conn);
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@buildingID", id);
                cmd.Parameters.AddWithValue("@content", commentview.Rows[index].Cells["Content"].Value);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void insertComment(int index)
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO comment VALUES (@id, @content, @buildingID)", con);
                con.Open();

                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@buildingID", id);
                cmd.Parameters.AddWithValue("@content", commentview.Rows[index].Cells["Content"].Value);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void insertMemo2(int index)
        {
            try
            {
                string query = "INSERT INTO memo VALUES(@id, @c_date, @memo, @buildingID)";
                MySqlConnection conn = new MySqlConnection(strConn2);

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@c_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@memo", memoview.Rows[index].Cells["memo"].Value);
                cmd.Parameters.AddWithValue("@buildingID", id);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void insertMemo(int index)
        {
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = strConn;
            try
            {
                SQLiteCommand cmd = new SQLiteCommand("INSERT INTO memo VALUES(@id, @c_date, @memo, @buildingID)", con);
                con.Open();


                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@c_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@memo", memoview.Rows[index].Cells["memo"].Value);
                cmd.Parameters.AddWithValue("@buildingID", id);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void addcomment_Click(object sender, EventArgs e)
        {
            commentview.Rows.Add();
        }

        private void deletecomment_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in commentview.SelectedCells)
                if (oneCell.Selected)
                {
                    commentdelete.Push(oneCell.RowIndex);
                    // deleteComment();
                    deleteComment2();
                    commentview.Rows.RemoveAt(oneCell.RowIndex);
                }
        }



        private void ContentOfRentals_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateTB();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("정말 자료를 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    //deleteDB();
                    deleteDB2();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deleteDB()
        {
            cn.Open();
            string query = "delete from info1 where id = " + id;
            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();
            query = "delete from pictures where buildingid = " + id;
            cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();
            cn.Close();

        }
        private void deleteDB2()
        {
            string query = "delete from comment where buildingid = " + id;
            MySqlConnection conn = new MySqlConnection(strConn2);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from info2 where buildingid = " + id;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from memo where buildingid = " + id;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from info1 where id = " + id;
            cmd.ExecuteNonQuery();

            conn.Close();

            cn.Open();
            query = "delete from pictures where buildingid = " + id;
            SQLiteCommand cmd2 = new SQLiteCommand(query, cn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }

        // dgv에 digit 말고는 들어갈 수 없게
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ContentOfRentals_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (dgv.CurrentCell.ColumnIndex == 0 || dgv.CurrentCell.ColumnIndex == 3 || dgv.CurrentCell.ColumnIndex == 7) //Desired Column
            {
                // Does nothing
            }
            else
            {
                System.Windows.Forms.TextBox tb = e.Control as System.Windows.Forms.TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            System.Windows.Controls.PrintDialog pDialog = new System.Windows.Controls.PrintDialog();
            pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            pDialog.UserPageRangeEnabled = true;

            Nullable<Boolean> print = pDialog.ShowDialog();
            if (print == true)
            {
                XpsDocument xpsDocument = new XpsDocument("C:\\Users\\Soobin\\Desktop\\FixedDocumentSequence.xps", FileAccess.ReadWrite);
                System.Windows.Documents.FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
            }

            
        }

        private void updateTB()
        {
            double UpdateSellPrice = checkNulls(TB_SellPrice.Text.ToString());
            double UpdateDeposit = checkNulls(TB_Deposit.Text.ToString());
            double UpdateLoan = checkNulls(TB_Loan.Text.ToString());
            double UpdateTakeOverPrice = -9999;
            double UpdateIncome;
            double UpdateYearPercent;
            

            if (UpdateSellPrice != -9999 && UpdateDeposit != -9999 && UpdateLoan != -9999)
            {
                UpdateTakeOverPrice = UpdateSellPrice - UpdateDeposit - UpdateLoan;
                TB_TakeOverPrice.Text = UpdateTakeOverPrice.ToString();
            }
            else
                TB_TakeOverPrice.Text = "";

            if (type != 6)
            {
                //UpdateIncome = checkNulls(TB_Income.Text.ToString());
                UpdateIncome = getSumofIncome();
                TB_Income.Text = getSumofIncome().ToString();
            }
            else
            {
                //UpdateIncome = checkNulls(TB_Income2.Text.ToString());
                UpdateIncome = getSumofIncome();
                TB_Income2.Text = getSumofIncome().ToString();

            }
            if (UpdateTakeOverPrice != -9999 && UpdateIncome != -9999)
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
    }

}
