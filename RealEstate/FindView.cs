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
    public partial class FindView : Form, DBInterface, FIndInterface, UserTypeInterface
    {
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteParameter picture;

        Findvalue findvalue = new Findvalue();
        string DBFile = "";
        Boolean userType;
        
        enum findIndex
        {
            ID,
            SELLPRICE,
            TOTALAREA,
            DISTANCE,
            INCOME,
            YEARINCOME,
            ROADWIDTH,
            ISCORNER
        }

        public FindView()
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
            findvalue.IncomeSize = FV.IncomeSize;
            findvalue.yearPercent = FV.yearPercent;
            findvalue.yearPercentSize = FV.yearPercentSize;
            findvalue.takeOverPrice = FV.takeOverPrice;
            findvalue.takeOverPriceSize = FV.takeOverPriceSize;
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
            string[,] findResults = new string[1000, 8];
            int Findcount = 0;
            char[] token = { ' ', ',', '\n', '\t'};
            string[] tokenResult;
            Boolean addrFind = false;
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
            query = addDobuleToQuery1(query, "takeOverPrice", findvalue.takeOverPrice, findvalue.takeOverPriceSize);
            query = addDobuleToQuery1(query, "income", findvalue.Income, findvalue.IncomeSize);
            query = addDobuleToQuery1(query, "yearPercent", findvalue.yearPercent, findvalue.yearPercentSize);
            if (findvalue.distance != -9999)
                query = addDobuleToQuery1(query, "distance", findvalue.distance, 2);
            query = addDobuleToQuery1(query, "roadWidth", findvalue.roadwidth, findvalue.roadwidthSize);


            string b = "";

            SQLiteCommand cmd = new SQLiteCommand(query, cn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int i;
               
                string c = rdr["income"].ToString();
                tokenResult = rdr["addr"].ToString().Split(token);
                foreach(var item in tokenResult)
                {
                    if (item.ToString().Contains(findvalue.addr))
                        addrFind = true;
                }
                if (addrFind)
                {
                    findResults[Findcount, (int)findIndex.ID] = rdr["id"].ToString();
                    findResults[Findcount, (int)findIndex.SELLPRICE] = checkValid(rdr["sellPrice"].ToString());
                    findResults[Findcount, (int)findIndex.TOTALAREA] = checkValid(rdr["totalArea"].ToString());
                    findResults[Findcount, (int)findIndex.DISTANCE] = checkValid(rdr["distance"].ToString());
                    findResults[Findcount, (int)findIndex.INCOME] = checkValid(rdr["income"].ToString());
                    if (findResults[Findcount, (int)findIndex.INCOME].Equals(""))
                        findResults[Findcount, (int)findIndex.YEARINCOME] = "";
                    else
                        findResults[Findcount, (int)findIndex.YEARINCOME] = (double.Parse(findResults[Findcount, (int)findIndex.INCOME]) * 12).ToString();
                    findResults[Findcount, (int)findIndex.ROADWIDTH] = checkValid(rdr["roadWidth"].ToString());
                    findResults[Findcount, (int)findIndex.ISCORNER] = rdr["isCorner"].ToString();
                    if (findResults[Findcount, (int)findIndex.ISCORNER].Equals("1"))
                        findResults[Findcount, (int)findIndex.ISCORNER] = "Y";
                    else
                        findResults[Findcount, (int)findIndex.ISCORNER] = "N";
                    Findcount++;
                }
                b += "번호 : " + rdr["id"] + " 매매 금액 : " + rdr["sellPrice"] + " 연면적 : " + rdr["totalArea"]
                    + " 역과 거리 : " + rdr["distance"] + " 월수입 : " + rdr["income"] + " 연수입 : " + (double.Parse(c) * 12).ToString()
                    + " 도로너비 : " + rdr["roadWidth"] + " 코너유무 : " + rdr["isCorner"];
                b += "\n";

            }
            label1.Text =b;

            rdr.Close();
            cn.Close();
        }
        private string checkValid(string num)
        {
            if (num.Equals("-9999"))
                return "";
            return num;
        }
        //만약 variableSize가 -1 이면 그 값을 지닌 변수는 where에 안넣음 0이면 이상 1이면 미만 2는 이내
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
                query += " and " + variableName + " <= " + variableValue.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (userType)
            {
                UserView userview = new UserView();
                userview.setDBfile(DBFile);
                userview.setID(1);
                userview.Show();
            }
            else
            {
                ManagerView mangerview = new ManagerView();
                mangerview.setDBfile(DBFile);
                mangerview.setID(1);
                // mangerview.loadPicture("picture1")
                mangerview.Show();
            }
        
        }
    }
}
