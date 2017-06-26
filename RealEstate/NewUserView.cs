using MetroFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class NewUserView : MetroFramework.Forms.MetroForm, IdInterface
    {
        int id; // 선택한 건물 id
        int type;
        int state;

        int isCorner;
        //프로필 유무
        public int profilePictureID = -1;
        string strConn;

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlCommandBuilder mbd;
        MySqlDataReader rdr;

        // Database keyword declare
        DataGridView dgv, commentview;



        public NewUserView()
        {
            InitializeComponent();

            dgv = ContentOfRentals;

            commentview = commentGridView;
            commentview.AutoGenerateColumns = false;

            commentview.Columns[0].ReadOnly = true;
            commentview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        private void readData() //서버에 있는 자료를 가져오기 
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
                panel3.Location = new Point(17, 410);
                metroLabel37.Location = new Point(593, 414);
                ContentOfRentals.Location = new Point(401, 445);
                this.Size = MaximumSize;
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
                        panel3.Location = new Point(17, 349);
                        metroLabel37.Location = new Point(593, 353);
                        ContentOfRentals.Location = new Point(401, 384);
                        this.Size = this.MinimumSize;
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

      

        public void loadPicture()//프로필 사진 불러오기위해 추가
        {
            string query = "select picture from pictures where id = " + profilePictureID + " and buildingid = " + id;
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            da = new MySqlDataAdapter(cmd);
            mbd = new MySqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            ms.Close();
            conn.Close();

        }
        private void NewUserView_Load(object sender, EventArgs e)
        {
            strConn = MysqlIp.Logic.getStrConn(); //DLL에서 mysql server ip 불러오기
            conn = new MySqlConnection(strConn);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            commentview.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            readData();
            loadPicture();

            readDataGrid();

            readcomment();

            commentview.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            commentview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            commentview.Columns[commentview.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                        MetroMessageBox.Show(Owner, "사진추가/삭제 창이 이미 열려있습니다", "창 중복 방지", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch { };
            if (isOpen == 0)
            {
                NewShowPicture newShowPicture = new NewShowPicture(this);
                newShowPicture.Owner = this;
                //id. 프로필 사진 번호, 모드 보내기
                newShowPicture.buildingID = id;
                newShowPicture.profilePictureID = profilePictureID;
                newShowPicture.setMode("userMode");
                newShowPicture.Show();
            }
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
                    if (rdr.GetValue(2).ToString().Equals(""))
                        dgv.Rows[i].Cells[0].Value = null;
                    else
                        dgv.Rows[i].Cells[0].Value = rdr.GetValue(2);
                    dgv.Rows[i].Cells[1].Value = rdr.GetValue(3);
                    dgv.Rows[i].Cells[2].Value = rdr.GetValue(4);
                    dgv.Rows[i].Cells[3].Value = rdr.GetValue(5);
                    dgv.Rows[i].Cells[4].Value = rdr.GetValue(6);
                    dgv.Rows[i].Cells[5].Value = rdr.GetValue(7);
                    dgv.Rows[i].Cells[6].Value = rdr.GetValue(8);
                    i++;
                }
                conn.Close();
            }
            catch (MySqlException e)
            {
                MetroMessageBox.Show(Owner, e.ToString(), "에러");
            }

            dgv.Sort(dgv.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

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

            dgv.Rows.Add();

            dgv.Rows[i].Cells[0].Value = "합계";
            dgv.Rows[i].Cells[1].Value = sumofArea;
            dgv.Rows[i].Cells[3].Value = sumofDeposit;
            dgv.Rows[i].Cells[4].Value = sumofMonthlyIncome;
            dgv.Rows[i].Cells[5].Value = sumofManagementPrice;

            dgv.Refresh();
        }

        private void btn_JustClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    commentview.Rows[i++].Cells[1].Value = rdr.GetValue(1);
                }
                conn.Close();
            }
            catch (MySqlException e)
            {
                MetroMessageBox.Show(Owner, e.ToString(), "에러");
            }
        }

    }
}

