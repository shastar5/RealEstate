using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RealEstate;
using System.Data.SQLite;

namespace RealEstate
{
    public interface DBInterface
    {
        void setDBfile(String DBFile);
    }
    public partial class AddMenu : Form, DBInterface
    {
        ShowPicture sp;
        NaverMap nm;
        Boolean isHidden = false;

        //전체 보이는용 변수
        string DBFile;
        string addr;
        string roadAddr;
        string area;
        string station;
        string useArea;
        string distance;
        string roadWidth;
        string totalArea;
        string completeYear;
        string parking;
        string acHeating;
        string EV;


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


        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteParameter picture;

        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
            TB_AC_Heating.Text = DBFile;
        }

        private void setData()
        {
            addr = TB_Addr.Text.ToString();
            roadAddr = TB_Addr.Text.ToString();
            area = TB_Area.Text.ToString();
            station = TB_Station.Text.ToString();
            useArea = TB_UseDistrict.Text.ToString();
            
            distance = TB_Distance.Text.ToString();
            roadWidth = TB_RoadWidth.Text.ToString();

            totalArea = TB_TotalArea.Text.ToString();
            completeYear = TB_CompleteYear.Text.ToString();
            parking = TB_Parking.Text.ToString();
            acHeating = TB_AC_Heating.Text.ToString();
            EV = TB_EV.Text.ToString();

            buildingName = TB_BuildName.Text.ToString();
            owner = TB_Owner.Text.ToString();
            tel = TB_Tel.Text.ToString();
            meno = TB_Memo.Text.ToString();
            
            /*
            deposit = double.Parse(TB_Deposit.Text.ToString());
            Income = double.Parse(TB_Income.Text.ToString()); 
            loan = double.Parse(TB_Loan.Text.ToString()); 
            interest = double.Parse(TB_Interest.Text.ToString()); 
            takeOverPrice = double.Parse(TB_PayedPrice.Text.ToString()); 
            sellPrice = double.Parse(TB_SellPrice.Text.ToString()); 
            payedPrice = double.Parse(TB_TakeOverPrice.Text.ToString()); 
            yearPercent = double.Parse(TB_YearPercent.Text.ToString()); 
            */

        }

        private void saveData()
        {
            DBFile = "C:/Users/HUN/Desktop/DB.db";

            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            string query = "Create table if not exists info1 (id INTEGER PRIMARY KEY, addr varchar(2000), roadAddr varchar(2000), "
                + "area varchar(100), station varchar(100), useArea varchar(100), distance varchar(100), roadWidth varchar(100), "
                + "totalArea varchar(100), completeYear varchar(100), parking varchar(100), acHeating varchar(100), EV varchar(100), "
                + "buildingName varchar(100), owner varchar(100), tel varchar(100), meno varchar(100), deposit NUMERIC, income NUMERIC, loan NUMERIC, interest NUMERIC, takeOverPrice NUMERIC, "
                + "sellPrice NUMERIC, payedPrice NUMERIC, yearPercent NUMERIC)";
            query = "insert into info1(id, addr, roadAddr, area, station, useArea, distance, roadWidth, totalArea, completeYear,"
                + " parking, acHeating, EV, buildingName, owner, tel, meno, deposit, income, loan, interest, takeOverPrice,"
                + " sellPrice, payedPrice, yearPercent) values(null, '" + addr + "', '" + roadAddr + "', '" + area + "', '" + station + "', "
                + "'" + useArea + "', '" + distance + "', '" + roadWidth + "', '" + totalArea + "', '" + completeYear + "', '" + parking + "', "
                + "'" + acHeating + "', '" + EV + "', '" + buildingName + "', '" + owner + "', '" + tel + "', '" + meno + "', " + deposit + ", "
                + Income + ", " + loan + ", " + interest + ", " + takeOverPrice + ", " + sellPrice + ", " + payedPrice + ", " + yearPercent+ ")";

            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        void test()
        {
            DBFile = "C:/Users/HUN/Desktop/DB.db";

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
                for (i = 0; i < 25; i++)
                {
                    a += rdr[i];
                }
                MessageBox.Show(a);
            }

            rdr.Close();
        }
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            setData();
            saveData();
            test();
        }


        public AddMenu()
        {
            InitializeComponent();

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

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if(sp == null)
            {
                sp = new RealEstate.ShowPicture();
                sp.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void TB_Owner_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dagagu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Building_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SanggaHome_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NewConstruction_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Sangga_CheckedChanged(object sender, EventArgs e)
        {
            if(Sangga.Checked == true)
            {
                panel6.Hide();
            } else
            {
                panel6.Show();
            }
        }

      
    }
}
