using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace RealEstate
{
  
    public interface FIndInterface
    {
        void setValue(Findvalue findvalue);
    }
    public interface UserTypeInterface
    {
        void setUserType(Boolean user);
    }
    public partial class findtest : Form, DBInterface, FIndInterface, UserTypeInterface
    {
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteParameter picture;

        Findvalue findvalue = new Findvalue();
        string DBFile = "";
        Boolean userType;
        public findtest()
        {
            InitializeComponent();
            
        }

        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }
        public void setValue(Findvalue FV)
        {
            findvalue.type = FV.type;
            findvalue.state = FV.state;
            findvalue.sellPrice = FV.sellPrice;
            findvalue.sellPriceSize = FV.sellPriceSize;
            findvalue.Income = FV.Income;
            findvalue.yearPercent = FV.yearPercent;
            findvalue.yearPercentSize = FV.yearPercentSize;
            findvalue.takeOverPrice = FV.takeOverPrice;
            findvalue.distance = FV.distance;
            findvalue.addr = FV.addr;
            findvalue.roadwidth = FV.roadwidth;
            findvalue.roadwidthSize = FV.roadwidthSize;
            label1.Text = findvalue.type.ToString() + findvalue.state.ToString() + findvalue.sellPrice.ToString()
                + findvalue.sellPriceSize.ToString() + findvalue.takeOverPrice.ToString() + findvalue.Income.ToString() + findvalue.yearPercent.ToString()
                + findvalue.yearPercentSize.ToString()+ findvalue.distance.ToString()
                + findvalue.addr.ToString() + findvalue.roadwidth.ToString() + findvalue.roadwidthSize.ToString();
            if (userType == false)
                MessageBox.Show("a");
        }
        public void setUserType(Boolean userType)
        {
            this.userType = userType;
        }
        private void showResult()
        {
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            String query = "select * from info1";

            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string a = "";
                int i;
                for (i = 0; i < 27; i++)
                {
                    a += rdr[i];
                }
                
            }

            rdr.Close();
        }
    }
}
