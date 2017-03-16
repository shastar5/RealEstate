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

        public int profilePictureID=-1;
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteParameter picture;

        // Database keyword declare
        SQLiteCommand sqlCMD;
        SQLiteDataReader sqlReader;
        DataGridView dgv;
        public UserView()
        {
            InitializeComponent();
        }
        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }
        public void setID(int id)
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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowPicture showpicture = new ShowPicture();
            showpicture.setDBfile(DBFile);
            showpicture.Owner = this;
            showpicture.tableID = id;
            showpicture.setMode("userMode");
            showpicture.Show();
        }
    }
}
