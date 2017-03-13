using System;
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
            /*
            label1.Text = findvalue.type.ToString() + findvalue.state.ToString() + findvalue.sellPrice.ToString()
                + findvalue.sellPriceSize.ToString() + findvalue.takeOverPrice.ToString() + findvalue.Income.ToString() + findvalue.yearPercent.ToString()
                + findvalue.yearPercentSize.ToString()+ findvalue.distance.ToString()
                + findvalue.addr.ToString() + findvalue.roadwidth.ToString() + findvalue.roadwidthSize.ToString();*/
            
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
            String query = "select * from info1 where state = ";
            if (findvalue.type.Equals(1))
            {
                query += findvalue.state.ToString() + " and type not in (1)";
            }
            else
            {
                query += findvalue.state.ToString() + " and type = " + findvalue.type.ToString();
            }
            query = addDobuleToQuery1(query, "sellPrice", findvalue.sellPrice, findvalue.sellPriceSize);
            query = addDobuleToQuery1(query, "yearPercent", findvalue.yearPercent, findvalue.yearPercentSize);
            query = addDobuleToQuery1(query, "roadWidth", findvalue.roadwidth, findvalue.roadwidthSize);
            
            //size더 추가해야할듯?

            string a = "";


            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int i;
                for (i = 0; i < 27; i++)
                {
                    a += rdr[i];
                }
                label1.Text = a;
            }

            rdr.Close();
            cn.Close();
        }
        private string addDobuleToQuery1(string query, string variableName, double variableValue, int variableSize)
        {
            if (variableSize.Equals(0))
            {
                query += " and " + variableName + " >= " + variableValue.ToString();
            }
            else if (variableSize.Equals(1))
            {
                query += " and " + variableName + " < " + variableValue.ToString();
            }
            else if(variableSize.Equals(2))
            {
                query += " and " + variableName + " = " + variableValue.ToString();
            }
            return query;
        }
        private string addDobuleToQuery2(string query, string variableName, double variableValue)
        {
            if (!variableValue.Equals(-9999))
            {
                addDobuleToQuery1(query, variableName, variableValue, 2);
            }
            return query;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            showResult();
        }
    }
}
