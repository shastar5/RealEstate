using System;
using System.Windows.Forms;

namespace RealEstate
{

    public partial class ManagerView : Form, DBInterface
    {
        //전체 보이는용 변수
        string DBFile;
        string addr;
        string roadAddr;
        string area;
        string station;
        string useArea;
        string totalArea;
        string completeYear;
        string parking;
        string acHeating;
        string EV;

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
            totalArea = TB_TotalArea.Text.ToString();
            completeYear = TB_CompleteYear.Text.ToString();
            parking = TB_Parking.Text.ToString();
            acHeating = TB_AC_Heating.Text.ToString();
            EV = TB_EV.Text.ToString();

            owner = TB_Owner.Text.ToString();
            tel = TB_Tel.Text.ToString();
            meno = TB_Memo.Text.ToString();

            deposit = double.Parse(TB_Deposit.Text.ToString());
            Income = double.Parse(TB_Income.Text.ToString()); 
            loan = double.Parse(TB_Loan.Text.ToString()); 
            interest = double.Parse(TB_Interest.Text.ToString()); 
            takeOverPrice = double.Parse(TB_PayedPrice.Text.ToString()); 
            sellPrice = double.Parse(TB_SellPrice.Text.ToString()); 
            payedPrice = double.Parse(TB_TakeOverPrice.Text.ToString()); 
            yearPercent = double.Parse(TB_YearPercent.Text.ToString()); 

        }
        public ManagerView()
        {
            InitializeComponent();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SaveData_Click(object sender, EventArgs e)
        {

        }

        private void TB_Deposit_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManagerView_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void TB_Parking_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void TB_CompleteYear_TextChanged(object sender, EventArgs e)
        {

        }

        private void TB_EV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void TB_AC_Heating_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void TB_RoadWidth_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TB_Distance_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

    }

}
