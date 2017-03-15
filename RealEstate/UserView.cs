using System;
using System.Windows.Forms;
using System.Data.SQLite;
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

        private void UserView_Load(object sender, EventArgs e)
        {

        }
    }
}
