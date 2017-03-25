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
using System.IO;

namespace RealEstate
{
    public partial class DBMerge : Form, DBInterface
    {
        String deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //바탕화면 경로 가져오기

        string DBFile1, DBFile2;
        string strConn1, strConn2;

        SQLiteConnection cn1 = new SQLiteConnection();
        SQLiteConnection cn2 = new SQLiteConnection();
        SQLiteCommand cmd1 = new SQLiteCommand();
        SQLiteCommand cmd2 = new SQLiteCommand();
        SQLiteDataReader rdr1, rdr2;


        public DBMerge()
        {
            //strConn = "Data Source=" + DBFile + "; Version=3;";
            InitializeComponent();
        }

        private void btn_CurrentDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog find = new OpenFileDialog();
            find.InitialDirectory = deskPath;
            find.Filter = "DB|*.db";
            if (find.ShowDialog() == DialogResult.OK)
            {
                DBFile1 = find.FileName;
                DBFile1 = DBFile1.Replace("\\", "/"); //\\을 /로 
                label1.Text = "합쳐질 DB : " +DBFile1.ToString();
            }
        }

        private void btn_AddDB_Click(object sender, EventArgs e)
        {

            OpenFileDialog find = new OpenFileDialog();
            find.InitialDirectory = deskPath;
            find.Filter = "DB|*.db";
            if (find.ShowDialog() == DialogResult.OK)
            {
                DBFile2 = find.FileName;
                DBFile2 = DBFile2.Replace("\\", "/"); //\\을 /로 
                label2.Text = "합쳐질 DB : " + DBFile2.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Merge_Click(object sender, EventArgs e)
        {
            string query;
            int found = 0;
            if (label1.Text.Equals(label2.Text))
                MessageBox.Show("같은 위치의 같은 이름의 두 파일은 합칠 수 없습니다.");
            else if (label2.Text.Equals("추가될 DB : "))
                MessageBox.Show("추가될 DB파일을 선택해주세요.");
            else if(label3.Text.Equals("합치기 완료!"))
                MessageBox.Show("이미 DB파일 합치기를 완료했습니다.");
            else
            {
                DialogResult dr = MessageBox.Show("두 DB파일을 합치겠습니까?\n경고! : 부동산에 설정된 프로필 사진이 손실 될 수도 있습니다.!", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    strConn1 = "Data Source=" + DBFile1 + "; Version=3;";
                    cn1.ConnectionString = strConn1;
                    strConn2 = "Data Source=" + DBFile2 + "; Version=3;";
                    cn2.ConnectionString = strConn2;

                    cn2.Open();
                    query = "select id, buildingid, picture from pictures";
                    cmd2 = new SQLiteCommand(query, cn2);
                    rdr2 = cmd2.ExecuteReader();
                    cn1.Open();

                    while (rdr2.Read())
                    {
                        byte[] addPicture = (byte[])(rdr2[2]);
                        found = 0;
                        query = "select picture from pictures where buildingid = " + rdr2[1].ToString();
                        cmd1 = new SQLiteCommand(query, cn1);
                        rdr1 = cmd1.ExecuteReader();
                        while (rdr1.Read())  //그림 비교 해서 있으면 found = 1 , 없으면 found  = 0으로 추가 실시
                        {
                            byte[] currentPicture = (byte[])(rdr1[0]);
                            bool Equal = currentPicture.SequenceEqual(addPicture);
                            if (Equal)
                                found = 1;
                        }
                        rdr1.Close();
                        if (found == 0)
                        {

                            MemoryStream ms = new MemoryStream(addPicture);
                            cmd1.Parameters.Clear();
                            cmd1.Parameters.AddWithValue("@picture", addPicture);
                            cmd1.CommandText = "insert into pictures (id, buildingid, picture) values (null, " + rdr2[1].ToString() + ", @picture)";
                            cmd1.ExecuteNonQuery();

                        }


                    }

                    rdr2.Close();
                    cn2.Close();
                    cn1.Close();
                    label3.Text = "합치기 완료!";
                }
            }
        }

        private void DBMerge_Load(object sender, EventArgs e)
        {
            label1.Text += DBFile1;

        }

       

        public void setDBfile(string DBFile)
        {
            this.DBFile1 = DBFile;
        }
        
    }
}
