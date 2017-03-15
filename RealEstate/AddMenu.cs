using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace RealEstate
{
    //해야할것 라디오 버튼 매매 준비 이런거 상태 추가해야함
    public interface DBInterface
    {
        void setDBfile(String DBFile);
    }
    public partial class AddMenu : Form, DBInterface
    {
        ShowPicture sp;
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

        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        DataGridView dgv;
        DataTable dt;

        // DataGridView 설정
        private void readDataGrid()
        {
            /*
             "Create table if not exists info2 (id INTEGER  PRIMARY KEY autoincrement, buildingID INTEGER, floor NUMERIC, area NUMERIC, storeName varchar(100), "
             + "deposit NUMERIC, monthlyIncome NUMERIC, managementPrice NUMERIC, etc NUMERIC, FOREIGN KEY(buildingID) REFERENCES info1(id))";
             */ 

            int i = 0, j = 0;
            double sumOfArea = 0, sumOfDeposit = 0, sumOfIncome = 0, sumOfManage = 0;
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            SQLiteCommand sqlCMD = new SQLiteCommand("select * from info2", cn);
            SQLiteDataReader reader;
            try
            {
                cn.Open();
                reader = sqlCMD.ExecuteReader();

                while(reader.Read())
                {
                    dgv.Rows.Add();

                    dgv.Rows[i].Cells[j++].Value = reader.GetInt32(2);

                    dgv.Rows[i].Cells[j++].Value = reader.GetDouble(3);
                    sumOfArea += reader.GetDouble(3);

                    dgv.Rows[i].Cells[j++].Value = reader.GetString(4);

                    dgv.Rows[i].Cells[j++].Value = reader.GetDouble(5);
                    sumOfDeposit += reader.GetDouble(5);

                    dgv.Rows[i].Cells[j++].Value = reader.GetDouble(6);
                    sumOfIncome += reader.GetDouble(6);

                    dgv.Rows[i].Cells[j++].Value = reader.GetDouble(7);
                    sumOfManage += reader.GetDouble(7);

                    dgv.Rows[i].Cells[j].Value = reader.GetString(8);

                    i++;
                }
                cn.Close();

            } catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            dgv.Rows[i].Cells[1].Value = sumOfArea;
            dgv.Rows[i].Cells[3].Value = sumOfDeposit;
            dgv.Rows[i].Cells[4].Value = sumOfIncome;
            dgv.Rows[i].Cells[5].Value = sumOfManage;

            dgv.Refresh();
        }
        
        private void saveDataGrid()
        {
            try
            {
                SQLiteCommand sqlCMD;
                sqlCMD = new SQLiteCommand("SELECT * from info2", cn);
                dt = new DataTable();
                cn.ConnectionString = strConn;
                cn.Open();

                using (SQLiteDataReader reader = sqlCMD.ExecuteReader())
                {
                    dt.Load(reader);
                    //dgv.DataSource = dt;
                }

                cn.Close();
                dgv.Refresh();
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
                + " sellPrice, payedPrice, yearPercent, type, state, premium, monthlyPay, maintenance, isCorner) values(null, '" + addr + "', '" + roadAddr + "', '" + area + "', '" + station + "', "
                + "'" + useArea + "', '" + distance + "', '" + roadWidth + "', '" + totalArea + "', '" + completeYear + "', '" + parking + "', "
                + "'" + acHeating + "', '" + EV + "', '" + buildingName + "', '" + owner + "', '" + tel + "', '" + meno + "', " + deposit + ", "
                + Income + ", " + loan + ", " + interest + ", " + takeOverPrice + ", " + sellPrice + ", " + payedPrice + ", " + yearPercent+ ", "
                + type + ", " + state + ", " + premium + ", " + monthlyPay + ", " + maintenance + ", " + isCorner + ")";
            
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
                readDataGrid();
                saveDataGrid();
                setData();
                saveData();
                test();
            }
        }


        public AddMenu()
        {
            InitializeComponent();
            type = -1;
            state = 1;
            isCorner = 0;

            listView1.View = View.Details;
            listView1.BeginUpdate();
            AddComment(1, "asdf");
            AddComment(2, "dfdf");
            AddComment(3, "As");
            listView1.EndUpdate();

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
     
        }

        // 코멘트 부분

      

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        

        private void AddMenu_Load(object sender, EventArgs e)
        {
            dgv = ContentOfRentals;
            dgv.AutoGenerateColumns = false;
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if(sp == null)
            {
                sp = new RealEstate.ShowPicture();
                sp.Show();
            }
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
    }
}
