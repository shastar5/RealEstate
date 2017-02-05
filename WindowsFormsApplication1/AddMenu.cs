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

namespace WindowsFormsApplication1
{
    public interface DBInterface
    {
        void setDBfile(String DBFile);
    }
    public partial class AddMenu : Form, DBInterface
    {
        ShowPicture sp;
        NaverMap nm;
        //전체 보이는용 변수
        string DBFile;
        string addr;
        string roadAddr;
        string area;
        string station;
        string useArea;
        string publicPrice;
        string sumPP;
        string totalArea;
        string buildArea;
        string floorNum;
        string completeYear;
        string parking;
        string acHeating;
        string EV;
        string totalMemo;

        //관리자용 변수
        string owner;
        string tel;
        string meno;
        double deposit;
        double Income;
        double loan;
        double interest;
        double takeOverPrice;
        double sellPrice;
        double payedPrice;
        double yearPercent;
        double monthPercent;

        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }

        private void setData()
        {
            addr = TB_Addr.Text.ToString();
            roadAddr = TB_Addr.Text.ToString();
            area = TB_Area.Text.ToString();
            station = TB_Station.Text.ToString();
            useArea = TB_UseDistrict.Text.ToString();
            publicPrice = TB_PublicPrice.Text.ToString();
            sumPP = TB_SumPP.Text.ToString();
            totalArea = TB_TotalArea.Text.ToString();
            buildArea = TB_BuildArea.Text.ToString();
            floorNum = TB_FloorNum.Text.ToString();
            completeYear = TB_CompleteYear.Text.ToString();
            parking = TB_Parking.Text.ToString();
            acHeating = TB_AC_Heating.Text.ToString();
            EV = TB_EV.Text.ToString();
            totalMemo = TB_TotalMemo.Text.ToString();

            owner = TB_Owner.Text.ToString();
            tel = TB_Tel.Text.ToString();
            meno = TB_Memo.Text.ToString();

            deposit = double.Parse(TB_Deposit.Text.ToString());
            Income = double.Parse(TB_Income.Text.ToString()); ;
            loan = double.Parse(TB_Loan.Text.ToString()); ;
            interest = double.Parse(TB_Interest.Text.ToString()); ;
            takeOverPrice = double.Parse(TB_TakeOverPrice.Text.ToString()); ;
            sellPrice = double.Parse(TB_SellPrice.Text.ToString()); ;
            payedPrice = double.Parse(TB_PayedPrice.Text.ToString()); ;
            yearPercent = double.Parse(TB_YearPercent.Text.ToString()); ;
            monthPercent = double.Parse(TB_MonthPercent.Text.ToString()); ;

        }
        public AddMenu()
        {
            InitializeComponent();

            listView1.View = View.Details;

            listView1.BeginUpdate();

            listView1.Columns.Add("index");
            listView1.Columns.Add("Content");

            ListViewItem lvi = new ListViewItem("1");
            lvi.SubItems.Add("사거리에 보기가 좋다");
            listView1.Items.Add(lvi);



            listView1.EndUpdate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nm == null)
            {
                nm = new RealEstate.NaverMap();
                nm.Show();
            }
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
    }

    public class Comment
    {
        int index;
        string data;
      
        Comment() { }

        Comment(int arg0, string arg1)
        {
            this.index = arg0;
            this.data = arg1;
        }
    }
}
