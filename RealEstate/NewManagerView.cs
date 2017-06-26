using MetroFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RealEstate
{
    /*
    public interface IdInterface
    {
        void setID(int id);
    }
    */

    public partial class NewManagerView : MetroFramework.Forms.MetroForm, IdInterface, FIndInterface
    {
        Size OriginalSize;
        int id; // 선택한 건물 id
        //전체 보이는용 변수
        int type;
        int state;
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
        double netIncome;
        int isCorner;

        public int profilePictureID = -1;

        int ErrorStr2Num;

        Findvalue findvalue = new Findvalue();
        String strConn;
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlCommandBuilder mbd;
        MySqlDataReader rdr;
        // Database keyword declare

        int countofrows = 0;
        DataGridView dgv, commentview, memoview;
        // dgv's stack
        Queue<int> todo = new Queue<int>();
        Stack<int> commentdelete = new Stack<int>();
        Stack<int> memodelete = new Stack<int>();
        buildingreport br;

        public void setID(int id)
        {
            this.id = id;
        }
        public void setValue(Findvalue FV)
        {
            findvalue = FV;
        }
        
        public NewManagerView()
        {
            InitializeComponent();
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
        private void readData()
        {
            string query = "select * from info1 where id = " + id;
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            rdr = cmd.ExecuteReader();
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
                }
                else
                {
                    TB_Income.Text = rdr[18].ToString();
                }

                if (rdr[19].ToString().Equals("-9999"))
                    TB_Loan.Text = "";
                else
                    TB_Loan.Text = rdr[19].ToString();

                if (rdr[20].ToString().Equals("-9999"))
                {
                    TB_Interest.Text = "";
                    TB_Interest2.Text = "";
                }
                else
                {
                    TB_Interest.Text = rdr[20].ToString();
                    TB_Interest2.Text = rdr[20].ToString();
                }

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
                {
                    TB_Maintenance.Text = "";
                    TB_Maintenance2.Text = "";
                }
                else
                {
                    TB_Maintenance.Text = rdr[29].ToString();
                    TB_Maintenance2.Text = rdr[29].ToString();
                }
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

                if (rdr[32].ToString().Equals("-9999"))
                {
                    TB_NetIncome.Text = "";
                    TB_NetIncome2.Text = "";
                }
                else
                {
                    TB_NetIncome.Text = rdr[32].ToString();
                    TB_NetIncome2.Text = rdr[32].ToString();

                }

            }

            rdr.Close();
            conn.Close();
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
                maintenance = checkNulls(TB_Maintenance.Text.ToString());
                netIncome = checkNulls(TB_NetIncome.Text.ToString());
                interest = checkNulls(TB_Interest.Text.ToString());
            }
            else
            {
                Income = checkNulls(TB_MonthlyPay.Text.ToString());
                maintenance = checkNulls(TB_Maintenance2.Text.ToString());
                netIncome = checkNulls(TB_NetIncome2.Text.ToString());
                interest = checkNulls(TB_Interest2.Text.ToString());
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

        private void updateDataGrid(int i)
        {
            string query = "UPDATE info2 SET floor = @floor, area = @area, storeName = @storeName," +
                " deposit = @deposit, monthlyIncome = @monthlyIncome, managementPrice = @managementPrice, etc = @etc where id = @id AND buildingID = " + id;
            try
            {
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                /*
                cmd.Parameters.AddWithValue("@floor", dgv.Rows[i].Cells["floor"].Value);
                cmd.Parameters.AddWithValue("@area", dgv.Rows[i].Cells["floor_area"].Value);
                cmd.Parameters.AddWithValue("@storeName", dgv.Rows[i].Cells["storeName"].Value);
                cmd.Parameters.AddWithValue("@deposit", dgv.Rows[i].Cells["storeDeposit"].Value);
                cmd.Parameters.AddWithValue("@monthlyIncome", dgv.Rows[i].Cells["monthlyIncome"].Value);
                cmd.Parameters.AddWithValue("@managementPrice", dgv.Rows[i].Cells["managementPrice"].Value);
                cmd.Parameters.AddWithValue("@etc", dgv.Rows[i].Cells["etc"].Value);
                cmd.Parameters.AddWithValue("@id", dgv.Rows[i].Cells["_id"].Value);
                */

                cmd.Parameters.Add("@floor", MySqlDbType.Decimal);
                cmd.Parameters.Add("@area", MySqlDbType.Decimal);
                cmd.Parameters.Add("@storeName", MySqlDbType.VarChar);
                cmd.Parameters.Add("@deposit", MySqlDbType.Decimal);
                cmd.Parameters.Add("@monthlyIncome", MySqlDbType.Decimal);
                cmd.Parameters.Add("@managementPrice", MySqlDbType.Decimal);
                cmd.Parameters.Add("@etc", MySqlDbType.VarChar);
                cmd.Parameters.Add("@id", MySqlDbType.Int32);

                cmd.Parameters["@floor"].Value = dgv.Rows[i].Cells["floor"].Value;
                cmd.Parameters["@area"].Value = dgv.Rows[i].Cells["floor_area"].Value;
                cmd.Parameters["@storeName"].Value = dgv.Rows[i].Cells["storeName"].Value;
                cmd.Parameters["@deposit"].Value = dgv.Rows[i].Cells["storeDeposit"].Value;
                cmd.Parameters["@monthlyIncome"].Value = dgv.Rows[i].Cells["monthlyIncome"].Value;
                cmd.Parameters["@managementPrice"].Value = dgv.Rows[i].Cells["managementPrice"].Value;
                cmd.Parameters["@etc"].Value = dgv.Rows[i].Cells["etc"].Value;
                cmd.Parameters["@id"].Value = dgv.Rows[i].Cells["_id"].Value;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MetroMessageBox.Show(this,e.ToString(), "에러");
            }
        }

        private void updatecomment(int index)
        {
            string query = "UPDATE comment SET content = @content WHERE id = @id AND buildingID = " + id;

            conn.Open();
            cmd = new MySqlCommand(query, conn);
            try
            {

                cmd.Parameters.AddWithValue("@content", commentview.Rows[index].Cells["Content"].Value);
                cmd.Parameters.AddWithValue("@id", commentview.Rows[index].Cells["order"].Value);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MetroMessageBox.Show(this, e.ToString(), "에러");
            }
        }

        private void updatememo(int index)
        {
            string query = "UPDATE memo SET c_date = @c_date, memo = @memo WHERE id = @id AND buildingID = " + id;

            conn.Open();
            cmd = new MySqlCommand(query, conn);
            try
            {

                cmd.Parameters.AddWithValue("@c_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@memo", memoview.Rows[index].Cells[2].Value);
                cmd.Parameters.AddWithValue("@id", memoview.Rows[index].Cells[0].Value);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MetroMessageBox.Show(this, e.ToString(), "에러");
            }
        }

        private void deleteDataGrid()
        {
            string query = "DELETE FROM info2 WHERE id = @id AND buildingID = " + id;

            conn.Open();
            cmd = new MySqlCommand(query, conn);
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

        private void readDataGrid()
        {
            int i = 0;
            string query = "select * from info2 where buildingId =" + id;
            try
            {
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();
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
            catch (MySqlException e)
            {
                MetroMessageBox.Show(this, e.ToString(), "에러");
            }

            //dgv.Sort(dgv.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
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
        private double getSumofdeposit()
        {
            int i;
            double sumofMaintain = 0;

            if (dgv.Rows.Count == 0)
                return 0;

            for (i = 0; i < dgv.Rows.Count - 1; ++i)
            {
                if (dgv.Rows[i].Cells[4].Value != DBNull.Value)
                    sumofMaintain += Convert.ToDouble(dgv.Rows[i].Cells[4].Value);
            }

            return sumofMaintain;
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
        private double getSumofMaintain()
        {
            int i;
            double sumofMaintain = 0;

            if (dgv.Rows.Count == 0)
                return 0;

            for (i = 0; i < dgv.Rows.Count - 1; ++i)
            {
                if (dgv.Rows[i].Cells[6].Value != DBNull.Value)
                    sumofMaintain += Convert.ToDouble(dgv.Rows[i].Cells[6].Value);
            }

            return sumofMaintain;
        }
        private void InsertRowsDataGridView(int i)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand("INSERT INTO info2 VALUES(@id, @buildingID, @floor, @area, @storeName, @deposit, @monthlyIncome, @managementPrice, @etc)", conn);
                if (dgv.Rows.Count != 0)
                {
                    /*
                    cmd.Parameters.AddWithValue("@buildingID", id);
                    cmd.Parameters.AddWithValue("@floor", dgv.Rows[i].Cells["floor"].Value);
                    cmd.Parameters.AddWithValue("@area", dgv.Rows[i].Cells["floor_area"].Value);
                    cmd.Parameters.AddWithValue("@storeName", dgv.Rows[i].Cells["storeName"].Value);
                    cmd.Parameters.AddWithValue("@deposit", dgv.Rows[i].Cells["storeDeposit"].Value);
                    cmd.Parameters.AddWithValue("@monthlyIncome", dgv.Rows[i].Cells["monthlyIncome"].Value);
                    cmd.Parameters.AddWithValue("@managementPrice", dgv.Rows[i].Cells["managementPrice"].Value);
                    cmd.Parameters.AddWithValue("@etc", dgv.Rows[i].Cells["etc"].Value);
                    */
                    cmd.Parameters.Add("@id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@buildingID", MySqlDbType.Int32);
                    cmd.Parameters.Add("@floor", MySqlDbType.Decimal);
                    cmd.Parameters.Add("@area", MySqlDbType.Decimal);
                    cmd.Parameters.Add("@storeName", MySqlDbType.VarChar);
                    cmd.Parameters.Add("@deposit", MySqlDbType.Decimal);
                    cmd.Parameters.Add("@monthlyIncome", MySqlDbType.Decimal);
                    cmd.Parameters.Add("@managementPrice", MySqlDbType.Decimal);
                    cmd.Parameters.Add("@etc", MySqlDbType.VarChar);

                    cmd.Parameters["@id"].Value = null;
                    cmd.Parameters["@buildingID"].Value = id;
                    cmd.Parameters["@floor"].Value = dgv.Rows[i].Cells["floor"].Value;
                    cmd.Parameters["@area"].Value = dgv.Rows[i].Cells["floor_area"].Value;
                    cmd.Parameters["@storeName"].Value = dgv.Rows[i].Cells["storeName"].Value;
                    cmd.Parameters["@deposit"].Value = dgv.Rows[i].Cells["storeDeposit"].Value;
                    cmd.Parameters["@monthlyIncome"].Value = dgv.Rows[i].Cells["monthlyIncome"].Value;
                    cmd.Parameters["@managementPrice"].Value = dgv.Rows[i].Cells["managementPrice"].Value;
                    cmd.Parameters["@etc"].Value = dgv.Rows[i].Cells["etc"].Value;
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
            catch (Exception e)
            {
                MetroMessageBox.Show(this, e.ToString(), "에러");
            }

        }

        private void saveData()
        {
            string query = "update info1 SET addr = @Addr , roadAddr = @RoadAddr, area = @Area, station = @Station, useArea = @UseArea, distance = @Distance, "
                 + "roadWidth = @RoadWidth, totalArea = @TotalArea, completeYear = @CompleteYear, parking = @Parking, acHeating = @AcHeating, EV = @EV, "
                 + "buildingName = @BuildingName, owner = @Owner, tel = @Tel, meno = @Meno, deposit = @Deposit, income = @Income, loan = @Loan, "
                 + "interest = @Interest, takeOverPrice = @TakeOverPrice, sellPrice = @SellPrice, payedPrice = @PayedPrice, yearPercent = @YearPercent, "
                 + "type = @Type, state = @State, premium = @Premium, monthlyPay = @MonthlyPay, maintenance = @Maintenance, isCorner = @IsCorner, "
                 + "profilePictureID = @ProfilePictureID, netIncome = @NetIncome where id  = " + id;

            conn.Open();
            cmd = new MySqlCommand(query, conn);
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
            cmd.Parameters.Add(new MySqlParameter("@NetIncome", MySqlDbType.Double) { Value = netIncome });


            cmd.ExecuteNonQuery();
            conn.Close();
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
                ContentOfRentals.Size = ContentOfRentals.MinimumSize;
                panel1.Location = new Point(404, 521);
                panel3.Location = new Point(17, 521);
                this.Size = this.MinimumSize;
            }
            else
            {
                panel6.Show();
                panel2.Hide();
                ContentOfRentals.Size = ContentOfRentals.MaximumSize;
                panel1.Location = new Point(404, 681);
                panel3.Location = new Point(17, 681);
                this.Size = OriginalSize;
            }
            updateTB();
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
                conn.Open();
                string query = "select picture from pictures where id = " + profilePictureID + " and buildingid = " + id;

                cmd = new MySqlCommand(query, conn);
                da = new MySqlDataAdapter(cmd);
                mbd = new MySqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds);
                byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
                MemoryStream ms = new MemoryStream(ap);
                pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                ms.Close();

                conn.Close();
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void NewManagerView_Load(object sender, EventArgs e)
        {
            OriginalSize = this.Size;

            strConn = MysqlIp.Logic.getStrConn(); //DLL에서 mysql server ip 불러오기
            conn = new MySqlConnection(strConn);
            print.Click += new EventHandler(print_Click);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            commentview.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            memoview.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            readData();

            loadPicture();

            readDataGrid();

            readcomment();

            readmemo();

            if (dgv.Rows.Count > 0)
            {
                dgv.Columns[0].ReadOnly = true;
                dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                commentview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                commentview.Columns[commentview.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void readcomment()
        {
            int i = 0;
            string query = "select * from comment where buildingId =" + id;
            try
            {

                conn.Open();
                cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    commentview.Rows.Add();
                    commentview.Rows[i].Cells[0].Value = rdr.GetValue(0);
                    commentview.Rows[i++].Cells[1].Value = rdr.GetValue(1);
                }
                conn.Close();
            }
            catch (MySqlException e)
            {
                MetroMessageBox.Show(this, e.ToString(), "에러");
            }
        }

        private void readmemo()
        {
            int i = 0;
            string query = "select * from memo where buildingId =" + id;
            try
            {
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    memoview.Rows.Add();
                    memoview.Rows[i].Cells[0].Value = rdr.GetValue(0);
                    memoview.Rows[i].Cells[1].Value = rdr.GetValue(1);
                    memoview.Rows[i++].Cells[2].Value = rdr.GetValue(2);
                }
                conn.Close();
            }
            catch (MySqlException e)
            {
                MetroMessageBox.Show(this, e.ToString(), "에러");
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            ErrorStr2Num = 0;
            setData();
            int isOpen = 0;
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name.Equals("NewShowPicture"))
                    {
                        isOpen = 1;
                        MetroMessageBox.Show(this, "사진추가/삭제 창이 이미 열려있습니다", "창 중복 방지", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch { };
            if (isOpen == 1)
                MetroMessageBox.Show(this, "사진추가/삭제 창을 닫고 저장해주세요.", "창 중복 방지", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            else if (ErrorStr2Num == 0)
            {
                saveData();

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
                        updateDataGrid(i);
                    }
                    else
                    {
                        for (int j = 1; j <= 7; j++)
                        {
                            if (dgv.Rows[i].Cells[j].Value != null)
                            {
                                string a;
                                if (dgv.Rows[i].Cells[1].Value == null)
                                    a = null;
                                else
                                    a = string.Copy(dgv.Rows[i].Cells[1].Value.ToString());
                                if (a == null || !a.Equals("합계"))
                                {
                                    InsertRowsDataGridView(i);
                                    break;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < commentview.Rows.Count; ++i)
                {
                    if (commentview.Rows[i].Cells[0].Value != null)
                    {
                        updatecomment(i);
                    }
                    else
                    {
                        insertComment(i);
                    }
                }

                for (int i = 0; i < memoview.Rows.Count; ++i)
                {
                    if (memoview.Rows[i].Cells[0].Value != null)
                    {
                        updatememo(i);
                    }
                    else
                    {
                        insertMemo(i);
                    }
                }
                MetroMessageBox.Show(this, "저장 완료 했습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                /*FindView findtest = new FindView();
                findtest.setDBfile(DBFile);
                findtest.setUserType(false);
                findtest.setValue(findvalue);
                findtest.Show();*/
            }
            else
                MetroMessageBox.Show(this, "숫자 입력란에 숫자만 넣어주세요. 다시 확인해주세요 ", "입력값 확인", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
        private void readProfilePicture()
        {
            MySqlConnection conn = new MySqlConnection(strConn);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int isOpen = 0;
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name.Equals("NewShowPicture"))
                    {
                        isOpen = 1;
                        MetroMessageBox.Show(this, "사진추가/삭제 창이 이미 열려있습니다", "창 중복 방지", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch { };
            if (isOpen == 0)
            {
                readProfilePicture();
                NewShowPicture newShowPicture = new NewShowPicture(this);
                newShowPicture.Owner = this;
                newShowPicture.buildingID = id;
                newShowPicture.profilePictureID = profilePictureID;
                newShowPicture.setMode("managerMode");
                newShowPicture.Show();
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
        private void updateSumOfGrid(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
            {
                dgv.Rows.RemoveAt(dgv.Rows.Count - 1);
            }
            showSum();
        }
        private void delete_row_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dgv.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    todo.Enqueue(oneCell.RowIndex);
                    deleteDataGrid();
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
                    deletememo();
                    memoview.Rows.RemoveAt(oneCell.RowIndex);
                }
        }

        private void deletememo()
        {
            string query = "DELETE FROM memo WHERE id = @id AND buildingID = " + id;

            conn.Open();
            cmd = new MySqlCommand(query, conn);
            while (memodelete.Count > 0)
            {
                cmd.Parameters.AddWithValue("@id", memoview.Rows[memodelete.Pop()].Cells["memoid"].Value);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }

        private void deleteComment()
        {
            string query = "DELETE FROM comment WHERE id = @id AND buildingID = " + id;

            conn.Open();
            cmd = new MySqlCommand(query, conn);
            while (commentdelete.Count > 0)
            {
                cmd.Parameters.AddWithValue("@id", commentview.Rows[commentdelete.Pop()].Cells["order"].Value);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }

        private void insertComment(int index)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand("INSERT INTO comment VALUES (@id, @content, @buildingID)", conn);
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@buildingID", id);
                cmd.Parameters.AddWithValue("@content", commentview.Rows[index].Cells["Content"].Value);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MetroMessageBox.Show(this, e.ToString(), "에러");
            }
        }

        private void insertMemo(int index)
        {
            try
            {
                string query = "INSERT INTO memo VALUES(@id, @c_date, @memo, @buildingID)";

                conn.Open();
                cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@c_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@memo", memoview.Rows[index].Cells["memo"].Value);
                cmd.Parameters.AddWithValue("@buildingID", id);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                MetroMessageBox.Show(this, e.ToString(), "에러");
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
                    deleteComment();
                    commentview.Rows.RemoveAt(oneCell.RowIndex);
                }
        }



        private void ContentOfRentals_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateTB();
            if (dgv.Rows.Count > 1)
            {
                dgv.Rows.RemoveAt(dgv.Rows.Count -1);
            }
            showSum();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MetroMessageBox.Show(this, "정말 자료를 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    deleteDB();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, e.ToString(), "에러");
            }
        }


        private void deleteDB()
        {
            string query = "delete from comment where buildingid = " + id;
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from info2 where buildingid = " + id;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from memo where buildingid = " + id;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from info1 where id = " + id;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "delete from pictures where buildingid = " + id;
            cmd.ExecuteNonQuery();

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
            if (br == null)
            {
                br = new buildingreport();
                br.setID(Convert.ToInt32(id));
                br.setMode("ManagerView");
                br.Show();
            }
        }


        private void updateTB()
        {
            double UpdateSellPrice = checkNulls(TB_SellPrice.Text.ToString());
            double UpdateDeposit = getSumofdeposit();
            double UpdateLoan = checkNulls(TB_Loan.Text.ToString());
            double UpdateTakeOverPrice = checkNulls(TB_TakeOverPrice.Text.ToString());
            double UpdateIncome;
            double UpdateYearPercent;
            double UpdateInterest;
            double UpdateMaintenance = getSumofMaintain();

            if (UpdateSellPrice != -9999 && UpdateDeposit != -9999 && UpdateLoan != -9999)
            {
                UpdateTakeOverPrice = UpdateSellPrice - UpdateDeposit - UpdateLoan;
                TB_TakeOverPrice.Text = UpdateTakeOverPrice.ToString();
            }
            else
                TB_TakeOverPrice.Text = "";

            if (type != 16)
            {
                //UpdateIncome = checkNulls(TB_Income.Text.ToString());
                UpdateIncome = getSumofIncome();
                TB_Income.Text = getSumofIncome().ToString();
                TB_Maintenance.Text = getSumofMaintain().ToString();
                TB_Deposit.Text = getSumofdeposit().ToString();
                UpdateInterest = checkNulls(TB_Interest.Text.ToString());

                if (UpdateInterest != -9999 && UpdateIncome != -9999 && UpdateMaintenance != -9999)
                    TB_NetIncome.Text = (UpdateIncome - UpdateInterest - UpdateMaintenance).ToString();
                else
                    TB_NetIncome.Text = "";
            }
            else
            {
                TB_Maintenance2.Text = getSumofMaintain().ToString();
                //UpdateIncome = checkNulls(TB_Income2.Text.ToString());
                UpdateIncome = getSumofIncome();
                TB_MonthlyPay.Text = getSumofIncome().ToString();

                UpdateInterest = checkNulls(TB_Interest2.Text.ToString());
                UpdateMaintenance = checkNulls(TB_Maintenance2.Text.ToString());
                if (UpdateInterest != -9999 && UpdateIncome != -9999 && UpdateMaintenance != -9999)
                    TB_NetIncome2.Text = (UpdateIncome - UpdateInterest - UpdateMaintenance).ToString();
                else
                    TB_NetIncome.Text = "";
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