using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace RealEstate
{
   
    public interface PicturInterface
    {
        void setMode(string mode);
    }

    public partial class ShowPicture : Form, DBInterface, PicturInterface
    {
        string DBFile= "";
        string tableName="";
        string imageName;
        public int tableID=0;
        int imageCount=0;
        public int profilePictureID=-1;
        string mode; // 추가 1 관리자 수정 2 유저 보기용
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteParameter picture;

        String deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //바탕화면 경로 가져오기

        
        public ShowPicture()
        {
            
            InitializeComponent();
        }



        private void ShowPicture_Load(object sender, EventArgs e)
        {
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cmd.Connection = cn;
            label1.Text = "";
            string query;
            switch (mode)
            {
                case "addMode":
                    //table name is temp
                    cn.Open();
                    tableName = "picture" + tableID.ToString();
                    query = "Create table if not exists " + tableName + " (id INTEGER  PRIMARY KEY autoincrement, picture image)";
                    cmd = new SQLiteCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    break;
                case "managerMode":
                    cn.Open();
                    tableName = "picture" + tableID.ToString();
                    query = "Create table if not exists "+ tableName+" (id INTEGER  PRIMARY KEY autoincrement, picture image)";
                    cmd = new SQLiteCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    //table name is picture+id
                    break;
                case "userMode":
                    cn.Open();
                    tableName = "picture" + tableID.ToString();
                    query = "Create table if not exists " + tableName + " (id INTEGER  PRIMARY KEY autoincrement, picture image)";
                    cmd = new SQLiteCommand(query, cn);
                    cmd.ExecuteNonQuery();
                    btn_AddPicture.Enabled = false;
                    btn_DeletePicture.Enabled = false;
                    btn_ProfilePicture.Enabled = false;
                    cn.Close();

                    break; 
            }
            if(profilePictureID==-1)
                label2.Text = "프로필 사진이 없습니다.";
            else
                label2.Text = "프로필 사진  : 사진 " + profilePictureID;

            picture = new SQLiteParameter("@picture", SqlDbType.Image);
            loadData();
        }

        private void open()
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.InitialDirectory = deskPath;
                f.Filter = "ALL|*.*|JPEGS|*.jpg|Bitmap|*.bmp|GIFS|*.gif|PNGS|*.png";
                f.FilterIndex = 1;
                f.Multiselect = true;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    
                    foreach (string files in f.FileNames)
                    {
                        imageCount++;
                        pictureBox1.Image = Image.FromFile(files);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                       
                        savePicture();
                    }
                    loadData();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString());  }

        }
        private void savePicture()
        {
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] a = ms.GetBuffer();
                ms.Close();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@picture", a);
                cmd.CommandText = "insert into "+ tableName +" (picture) values (@picture)";
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                pictureBox1.Image = null;
            }
        }

        private void loadPicture()
        {

            string id = listBox1.Text.ToString();
            id = id.Replace("사진 ", "");
            cn.Open();
            cmd.CommandText = "select picture from " + tableName + " where id = " + id;
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteCommandBuilder cbd = new SQLiteCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            label1.Text = listBox1.Text.ToString();
            ms.Close();
            cn.Close();

        }
        private void loadData()
        {
            listBox1.Items.Clear();
            cmd.CommandText = "select id from " + tableName;
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox1.Items.Add("사진 "+dr[0].ToString());
                }
            }
            dr.Close();
            cn.Close();
        }
        private void deletePicture()
        {
            string id = listBox1.Text.ToString();
            id = id.Replace("사진 ", "");
            cn.Open();
            cmd.CommandText = "Delete From " + tableName + " where id = " + id;
            cmd.ExecuteNonQuery();
            cn.Close();
            pictureBox1.Image = null;
            label1.Text = "";
            if(id.Equals(profilePictureID.ToString())) {
                label2.Text = "프로필 사진이 없습니다.";
                profilePictureID = -1;
                
                
                if (mode.Equals("managerMode"))
                {
                    cn.Open();
                    cmd.CommandText = "update info1 SET profilePictureID = -1 where id = " + tableID;
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    ManagerView managerview = new ManagerView();
                    managerview.profilePictureID = profilePictureID;
                }
                else if(mode.Equals("addMode"))
                {
                    AddMenu addmenu = new AddMenu();
                    addmenu.profilePictureID = profilePictureID;
                }

            }
            MessageBox.Show("사진 " + id + "가 삭제되었습니다.");
            loadData();

        }
        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }

        public void setMode(string mode)
        {
            this.mode = mode;
        }
        private void btn_AddPicture_Click(object sender, EventArgs e)
        {
            open();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = l.SelectedIndex;
                loadPicture();
            }
        }

        private void btn_DeletePicture_Click(object sender, EventArgs e)
        {
            deletePicture();
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = l.SelectedIndex;
                loadPicture();
            }
        }

        private void btn_SavePicture_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0||mode.Equals("userMode"))
                 this.Close();
            //if you do not save any photo, then close
            else if(profilePictureID == -1)
                MessageBox.Show("프로필 사진을 정해주세요");
            else
            {
                switch (mode)
                {
                    case "addMode":
                        AddMenu addmenu = (AddMenu)this.Owner;
                        addmenu.loadPicture(tableName);
                        break;
                    case "managerMode":
                        ManagerView managerview = (ManagerView)this.Owner;
                        managerview.loadPicture(tableName);
                        
                        break;
                    case "userMode":
                        UserView userview = (UserView)this.Owner;
                        userview.loadPicture(tableName);
                        break;
                }
                this.Close();
            }
        }

        private void btn_ProfilePicture_Click(object sender, EventArgs e)
        {
            string id = listBox1.Text.ToString();
            id = id.Replace("사진 ", "");
            if(!id.Equals(""))
            {
                switch (mode)
                {
                    case "addMode":
                        AddMenu addmenu = (AddMenu)this.Owner;
                        profilePictureID = int.Parse(id);
                        addmenu.profilePictureID = profilePictureID;
                        addmenu.loadPicture(tableName);
                        break;
                    case "managerMode":
                        ManagerView managerview = (ManagerView)this.Owner;
                        profilePictureID = int.Parse(id);

                        cn.Open();
                        cmd.CommandText = "update info1 SET profilePictureID = " + profilePictureID + " where id = " + tableID;
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        managerview.profilePictureID = profilePictureID;
                        managerview.loadPicture(tableName);
                        break;
                    case "userMode" :
                        UserView userview = (UserView)this.Owner;
                        profilePictureID = int.Parse(id);
                        userview.profilePictureID = profilePictureID;
                        break;
                }
               
                label2.Text = "프로필 사진  : 사진 " + id;
                MessageBox.Show("사진 " + id + "가 프로필 사진으로 지정되었습니다");

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex.ToString().Equals("-1"))
            {
                MessageBox.Show("사진을 선택해주세요");
            }
            else
            {
                string query = "";
                string openPictureID = listBox1.SelectedItem.ToString();
                openPictureID = openPictureID.Replace("사진 ", "");
                query = "select picture from " + tableName + " where id =" + openPictureID;
                BigPicture bigpicture = new BigPicture();
                bigpicture.Owner = this;
                bigpicture.query = query;
                bigpicture.setDBfile(DBFile);
                bigpicture.Show();
            }
        }
    }
}
