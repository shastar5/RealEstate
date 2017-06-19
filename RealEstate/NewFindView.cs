using MetroFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate
{
    /*
    public interface FIndInterface
    {
        void setValue(Findvalue findvalue);
    }
    public interface UserTypeInterface
    {
        void setUserType(Boolean user);
    }*/
    public partial class NewFindView : MetroFramework.Forms.MetroForm, FIndInterface, UserTypeInterface
    {
        String strConn;

        Findvalue findvalue = new Findvalue();
        Boolean userType;
        int dataGridRowID = -1;
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader rdr;

        enum findIndex
        {
            ID,
            BUILDINGNAME,
            SELLPRICE,
            TOTALAREA,
            DISTANCE,
            INCOME,
            YEARPERCENT,
            ROADWIDTH,
            ISCORNER
        }

        public NewFindView()
        {
            InitializeComponent();
        }

        public void setValue(Findvalue FV)
        {
            findvalue = FV;
        }
        public void setUserType(Boolean userType)
        {
            this.userType = userType;
        }

        private void showResult()
        {
            string[,] findResults = new string[1000, 9];
            int Findcount = 0;
            Boolean addrFind = false;

            string query = "select * from info1 where state = ";

            if (findvalue.type.Equals(0))
            {
                query += findvalue.state.ToString() + " and type not in (0)";
            }
            else if (!findvalue.type.Equals(1) && !findvalue.type.Equals(2) && !findvalue.type.Equals(4) && !findvalue.type.Equals(8) && !findvalue.type.Equals(16))
            {
                query += findvalue.state.ToString() + " and (";
                if ((findvalue.type & 1) != 0)
                    query += " type = 1 or";
                if ((findvalue.type & 1 << 1) != 0)
                    query += " type = 2 or";
                if ((findvalue.type & 1 << 2) != 0)
                    query += " type = 4 or";
                if ((findvalue.type & 1 << 3) != 0)
                    query += " type = 8 or";
                if ((findvalue.type & 1 << 4) != 0)
                    query += " type = 16 or";
                query = query.Substring(0, query.Length - 3); //마지막 or 삭제
                query += ")";
            }
            else
                query += findvalue.state.ToString() + " and type = " + findvalue.type.ToString();
            query = addDobuleToQuery1(query, "sellPrice", findvalue.sellPrice, findvalue.sellPriceSize);
            query = addDobuleToQuery1(query, "takeOverPrice", findvalue.takeOverPrice, findvalue.takeOverPriceSize);
            query = addDobuleToQuery1(query, "income", findvalue.Income, findvalue.IncomeSize);
            query = addDobuleToQuery1(query, "yearPercent", findvalue.yearPercent, findvalue.yearPercentSize);
            if (findvalue.distance != -9999)
                query = addDobuleToQuery1(query, "distance", findvalue.distance, 2);
            query = addDobuleToQuery1(query, "roadWidth", findvalue.roadwidth, findvalue.roadwidthSize);
            if (findvalue.isCorner == 0)
                query += " and isCorner = 0";
            else if (findvalue.isCorner == 1)
                query += " and isCorner = 1";
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                addrFind = false;

                if (rdr["addr"].ToString().Contains(findvalue.addr))
                    addrFind = true;

                if (addrFind)
                {
                    findResults[Findcount, (int)findIndex.ID] = rdr["id"].ToString();
                    findResults[Findcount, (int)findIndex.BUILDINGNAME] = checkValid(rdr["buildingName"].ToString());
                    findResults[Findcount, (int)findIndex.SELLPRICE] = checkValid(rdr["sellPrice"].ToString());
                    findResults[Findcount, (int)findIndex.TOTALAREA] = checkValid(rdr["totalArea"].ToString());
                    findResults[Findcount, (int)findIndex.DISTANCE] = checkValid(rdr["distance"].ToString());
                    findResults[Findcount, (int)findIndex.INCOME] = checkValid(rdr["income"].ToString());
                    findResults[Findcount, (int)findIndex.YEARPERCENT] = checkValid(rdr["yearPercent"].ToString());
                    findResults[Findcount, (int)findIndex.ROADWIDTH] = checkValid(rdr["roadWidth"].ToString());
                    findResults[Findcount, (int)findIndex.ISCORNER] = rdr["isCorner"].ToString();
                    if (findResults[Findcount, (int)findIndex.ISCORNER].Equals("1"))
                        findResults[Findcount, (int)findIndex.ISCORNER] = "Y";
                    else
                        findResults[Findcount, (int)findIndex.ISCORNER] = "N";
                    string[] row = { findResults[Findcount, 0], findResults[Findcount, 1], findResults[Findcount, 2], findResults[Findcount, 3]
                        , findResults[Findcount,4], findResults[Findcount,5], findResults[Findcount,6], findResults[Findcount,7], findResults[Findcount,8]};
                    dataGridView1.Rows.Add(row);
                    Findcount++;
                }
            }
            MetroMessageBox.Show(Owner, "검색 조건에 맞는 " + Findcount + "개의 부동산을 찾았습니다.", "부동산 검색결과",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            rdr.Close();
            conn.Close();
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            else if (variableSize.Equals(2))
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


        private void button2_Click(object sender, EventArgs e)
        {
            int isOpen = 0;
            string id;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name.Equals("NewManagerView") || form.Name.Equals("NewUserView"))
                {
                    isOpen = 1;
                }
            }

            if (dataGridRowID == -1)
            {
                MetroMessageBox.Show(Owner,"자세히 볼 부동산을 선택해주세요","부동산 미 선택", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (isOpen == 1)
            {
                MetroMessageBox.Show(Owner,"상세 정보 창이 이미 열려 있습니다.", "창 중복 방지", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (userType)
            {
                id = dataGridView1.Rows[dataGridRowID].Cells[0].Value.ToString();
                UserView userview = new UserView();
                userview.setID(int.Parse(id));
                userview.Show();
            }
            else
            {
                id = dataGridView1.Rows[dataGridRowID].Cells[0].Value.ToString();
                ManagerView mangerview = new ManagerView();
                mangerview.setID(int.Parse(id));
                mangerview.setValue(findvalue);
                mangerview.Show();
                this.Close();
            }


        }

        private void NewFindView_Load(object sender, EventArgs e)
        {
            strConn = MysqlIp.Logic.getStrConn(); //DLL에서 mysql server ip 불러오기
            conn = new MySqlConnection(strConn);
            dataGridView1.ColumnCount = 9;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGridView1.Columns[0].Name = "번호";
            dataGridView1.Columns[0].Width = dataGridView1.Width / 15;
            dataGridView1.Columns[1].Name = "건물명";
            dataGridView1.Columns[1].Width = (int)(dataGridView1.Width / 2.9);
            dataGridView1.Columns[2].Name = "매매금액";
            dataGridView1.Columns[2].Width = dataGridView1.Width / 12;
            dataGridView1.Columns[3].Name = "연면적";
            dataGridView1.Columns[3].Width = dataGridView1.Width / 14;
            dataGridView1.Columns[4].Name = "역과의 거리";
            dataGridView1.Columns[4].Width = dataGridView1.Width / 10;
            dataGridView1.Columns[5].Name = "월수입";
            dataGridView1.Columns[5].Width = dataGridView1.Width / 14;
            dataGridView1.Columns[6].Name = "연수익률";
            dataGridView1.Columns[6].Width = dataGridView1.Width / 12;
            dataGridView1.Columns[7].Name = "도로너비";
            dataGridView1.Columns[7].Width = dataGridView1.Width / 12;
            dataGridView1.Columns[8].Name = "코너유무";
            dataGridView1.Columns[8].Width = dataGridView1.Width / 12;

            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.CurrentCell = dataGridView1.TopLeftHeaderCell;
            showResult();

            dataGridView1.ClearSelection();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridRowID = e.RowIndex;
        }
    }
}
