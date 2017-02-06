using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace RealEstate
{
    public interface DBInterface
    {
        void setDBfile(String DBFile);
    }
    public partial class ManagerView : Form, DBInterface
    {
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
            takeOverPrice = double.Parse(TB_PayedPrice.Text.ToString()); ;
            sellPrice = double.Parse(TB_SellPrice.Text.ToString()); ;
            payedPrice = double.Parse(TB_TakeOverPrice.Text.ToString()); ;
            yearPercent = double.Parse(TB_YearPercent.Text.ToString()); ;
            monthPercent = double.Parse(TB_MonthPercent.Text.ToString()); ;

        }
        public ManagerView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nm == null)
            {
                nm = new NaverMap();
                nm.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
