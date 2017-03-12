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
        void setValue(double sellPrice, double Income, double yearPercent, double takeOverPrice,
            string distance, string addr, string roadwidth);
    }
    public partial class findtest : Form, DBInterface
    {
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteParameter picture;

        double sellPrice;
        double Income;
        double yearPercent;
        double takeOverPrice;
        string distance;
        string addr;
        string roadwidth;

        string DBFile = "";
        public findtest()
        {
            InitializeComponent();
            
        }

        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }
        public void setValue(double sellPrice, double Income, double yearPercent, double takeOverPrice,
            string distance, string addr, string roadwidth)
        {
            this.sellPrice = sellPrice;
            this.Income = Income;
            this.yearPercent = yearPercent;
            this.takeOverPrice = takeOverPrice;
            this.distance = distance;
            this.addr = addr;
            this.roadwidth = roadwidth;
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
                for (i = 0; i < 25; i++)
                {
                    a += rdr[i];
                }
                MessageBox.Show(a);
            }

            rdr.Close();
        }
    }
}
