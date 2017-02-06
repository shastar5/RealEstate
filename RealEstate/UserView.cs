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
    public partial class UserView : Form
    {
        public interface DBInterface
        {
            void setDBfile(String DBFile);
        }
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

        }
        public UserView()
        {
            InitializeComponent();
        } 
        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
