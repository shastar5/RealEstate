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
using System.Runtime.InteropServices;

namespace RealEstate
{
   
    public interface PicturInterface
    {
        void setMode(string mode);
    }

    public partial class ShowPicture : Form, DBInterface, PicturInterface
    {
        string DBFile= "";
        public int buildingID=0;
        int imageCount=0;
        public int profilePictureID=-1;
        string mode; // 추가 1 관리자 수정 2 유저 보기용
        string[] pictureNum = new string[10000];
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteParameter picture;

        String deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //바탕화면 경로 가져오기

        //X버튼 금지
        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x0;
        private const int MF_GRAYED = 0x1;
        private const int MF_DISABLED = 0x2;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

        public ShowPicture()
        {
            
            InitializeComponent();
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);

        }



        private void ShowPicture_Load(object sender, EventArgs e)
        {
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cmd.Connection = cn;
            label1.Text = "";
            int ProfileIndex = -1;
            int i;
            switch (mode)  //모드에 맞게 사진 불러오기
            {
                case "addMode":
                    break;
                case "managerMode":
                    break;
                case "userMode":
                    btn_AddPicture.Enabled = false;
                    btn_DeletePicture.Enabled = false;
                    btn_ProfilePicture.Enabled = false;
                    break; 
            }
            picture = new SQLiteParameter("@picture", SqlDbType.Image);
            loadData();
            if (profilePictureID == -1)
                label2.Text = "프로필 사진이 없습니다.";
            else
            {
                for (i = 1; i < 10000; i++)
                {
                    if (pictureNum[i].Equals(profilePictureID.ToString()))
                        break;
                }
                label2.Text = "프로필 사진 : 사진 " + i;
                cn.Open();
                cmd.CommandText = "select picture from pictures where id = " + profilePictureID + " and buildingid = " + buildingID.ToString();
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
                listBox1.SelectedIndex = --i;
               
                
            }
        }

        private void open()  //사진 추가 버튼 눌렀을 때 사진 선택 및 저장
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.InitialDirectory = deskPath;
                f.Filter = "ALL|*.JPG;*.BMP;*.GIF;*.PNG|JPEGS|*.JPG|Bitmap|*.BMP|GIFS|*.GIF|PNGS|*.PNG";
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
        private void savePicture()  //그림 추가
        {
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] a = ms.GetBuffer();
                ms.Close();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@picture", a);
                cmd.CommandText = "insert into pictures (buildingid, picture) values (" + buildingID.ToString()+", @picture)";
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                pictureBox1.Image = null;
            }
        }

        private void loadPicture() //저장된 사진들 불러오기
        {

            string id = listBox1.Text.ToString();
            id = id.Replace("사진 ", "");
            cn.Open();
            cmd.CommandText = "select picture from pictures where id = " + pictureNum[int.Parse(id)] + " and buildingid = " + buildingID.ToString();
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
        private void loadData() //저장 된 사진의 이름 불러오기
        {
            int count = 0;
            listBox1.Items.Clear();
            cmd.CommandText = "select id from pictures where buildingid =" + buildingID.ToString();
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    pictureNum[++count] = dr[0].ToString();
                    listBox1.Items.Add("사진 "+ count);
                }
            }
            dr.Close();
            cn.Close();
        }
        private void deletePicture()
        {
            string id = listBox1.Text.ToString();
            int i = 0;
            if (id.Equals(""))
                MessageBox.Show("삭제할 사진을 선택해주세요");
            else { 
            id = id.Replace("사진 ", "");
            cn.Open();
            cmd.CommandText = "Delete From pictures where id = " + pictureNum[int.Parse(id)] + " and buildingid = " + buildingID.ToString();
            cmd.ExecuteNonQuery();
            cn.Close();
            pictureBox1.Image = null;
            label1.Text = "";
                if (pictureNum[int.Parse(id)].Equals(profilePictureID.ToString()))
                {  //프로필 사진을 지웠을 때 
                    label2.Text = "프로필 사진이 없습니다.";
                    profilePictureID = -1;


                    if (mode.Equals("managerMode"))
                    {
                        cn.Open();
                        cmd.CommandText = "update info1 SET profilePictureID = -1 where id = " + buildingID.ToString();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        ManagerView managerview = new ManagerView();
                        managerview.profilePictureID = profilePictureID;
                        managerview.pictureBox1.Image = null;
                    }
                    else if (mode.Equals("addMode"))
                    {
                        AddMenu addmenu = new AddMenu();
                        addmenu.profilePictureID = profilePictureID;
                    }
                }
                else
                {
                    for(i=1; i<10000; i++)
                    {
                        if (pictureNum[i].Equals(profilePictureID.ToString()))
                        {
                            i--;
                            break;
                        }
                    }
                    label2.Text = "프로필 사진 : " + i;

                }
                id = (int.Parse(id)).ToString();
                MessageBox.Show("사진 " + id + "가 삭제되었습니다.");
            }
            loadData();
        }
        public void setDBfile(string DBFile) //DB파일위치 계승
        {
            this.DBFile = DBFile;
        }

        public void setMode(string mode) //모드 계승
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
            if (l.SelectedIndex != -1) //리스트 박스에 저장된 사진 리스트 불러오기
            {
                listBox1.SelectedIndex = l.SelectedIndex; 
                loadPicture();
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ListBox l = sender as ListBox; //리스트 박스에 저장된 사진 리스트 불러오기 키보드 로 움직일 떄
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


        private void btn_SavePicture_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0||mode.Equals("userMode"))
                 this.Close();
            //if you do not save any photo, then close
            else if(profilePictureID == -1)
                MessageBox.Show("프로필 사진을 정해주세요");
            else
            {
                switch (mode) //모드에 따른 프로필 사진 지정 여부 검사
                {
                    case "addMode":
                        AddMenu addmenu = (AddMenu)this.Owner;
                        addmenu.loadPicture();
                        break;
                    case "managerMode":
                        ManagerView managerview = (ManagerView)this.Owner;
                        managerview.loadPicture();
                        
                        break;
                    case "userMode":
                        UserView userview = (UserView)this.Owner;
                        userview.loadPicture();
                        break;
                }
                this.Close();
            }
        }

        private void btn_ProfilePicture_Click(object sender, EventArgs e)
        {
            string id = listBox1.Text.ToString();
            id = id.Replace("사진 ", "");
            if (!id.Equals(""))
            {
                switch (mode) //모드에 따른 사진 추가 기능 유무 설정
                {
                    case "addMode":
                        AddMenu addmenu = (AddMenu)this.Owner;
                        profilePictureID = int.Parse( pictureNum[int.Parse(id)] );
                        addmenu.profilePictureID = profilePictureID;
                        addmenu.loadPicture();
                        break;
                    case "managerMode":
                        ManagerView managerview = (ManagerView)this.Owner;
                        profilePictureID = int.Parse(pictureNum[int.Parse(id)]);

                        cn.Open();
                        cmd.CommandText = "update info1 SET profilePictureID = " + profilePictureID + " where id = " + buildingID.ToString();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        managerview.profilePictureID = profilePictureID;
                        managerview.loadPicture();
                        break;
                    case "userMode" :
                        UserView userview = (UserView)this.Owner;
                        profilePictureID = int.Parse(pictureNum[int.Parse(id)]);
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
                query = "select picture from pictures where buildingid =" +buildingID + " and id = "+ pictureNum[int.Parse(openPictureID)];
                BigPicture bigpicture = new BigPicture();
                bigpicture.Owner = this;
                bigpicture.query = query;
                bigpicture.setDBfile(DBFile);
                bigpicture.Show();
            }
        }
    }
}
