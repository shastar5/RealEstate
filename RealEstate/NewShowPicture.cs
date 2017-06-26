using MetroFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate
{
    
    public interface PictureInterface
    {
        void setMode(string mode);
    }
    public partial class NewShowPicture : MetroFramework.Forms.MetroForm
    {
        public int buildingID = 0;
        int imageCount = 0;
        int totalImage = 0;
        int percent = 0;
        public int profilePictureID = -1;
        string mode; // 추가 1 관리자 수정 2 유저 보기용
        string[] pictureNum = new string[10000];
        String strConn;

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlCommandBuilder mbd;
        MySqlDataReader rdr;
        MySqlParameter picture;
        String deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //바탕화면 경로 가져오기

        NewManagerView newManagerView;
        NewAddMenu newAddMenu;
        NewUserView newUserView;
        public NewShowPicture()
        {
            InitializeComponent();
        }
        public NewShowPicture(NewManagerView newManagerView)
        {
            InitializeComponent();
            this.newManagerView = newManagerView;
        }
        public NewShowPicture(NewAddMenu newAddMenu)
        {
            InitializeComponent();
            this.newAddMenu = newAddMenu;
        }
        public NewShowPicture(NewUserView newUserView)
        {
            InitializeComponent();
            this.newUserView = newUserView;
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
                NewShowPicture.ActiveForm.Size = NewShowPicture.ActiveForm.MaximumSize;
                progressBar1.Show();
                label1.Text = "사진 업로드 중입니다.";
                if (f.ShowDialog() == DialogResult.OK)
                {
                    btn_AddPicture.Enabled = false;
                    btn_DeletePicture.Enabled = false;
                    btn_ProfilePicture.Enabled = false;
                    btn_SavePicture.Enabled = false;
                    totalImage = f.FileNames.Length;
                    foreach (string files in f.FileNames)
                    {
                        imageCount++;
                        pictureBox1.Image = Image.FromFile(files);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        percent = 100 / totalImage;
                        savePicture();
                        progressBar1.Increment(percent);
                    }
                    loadData();
                    progressBar1.Increment(100);
                    label1.Text = "";
                    MetroMessageBox.Show(this, "사진 추가 완료했습니다.", "사진 추가 완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                btn_AddPicture.Enabled = true;
                btn_DeletePicture.Enabled = true;
                btn_ProfilePicture.Enabled = true;
                btn_SavePicture.Enabled = true;
                progressBar1.Hide();
                NewShowPicture.ActiveForm.Size = NewShowPicture.ActiveForm.MinimumSize;
                progressBar1.Value = 0;
            }
            catch (Exception ex) { MetroMessageBox.Show(this, ex.ToString(), "에러"); }

        }
        private void savePicture()
        {
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.GetBuffer();

                string query = "insert into pictures (buildingid, picture) values (" + buildingID.ToString() + ", @picture)";
                conn.Open();
                cmd = new MySqlCommand(query, conn);

                cmd.Parameters.Clear();
                cmd.Parameters.Add("@picture", MySqlDbType.LongBlob);
                cmd.Parameters["@picture"].Value = img;
                cmd.ExecuteNonQuery();
                conn.Close();
                ms.Close();
                pictureBox1.Image = null;
            }
        }

        private void loadPicture() //저장된 사진들 불러오기
        {
            string id = listBox1.Text.ToString();
            id = id.Replace("사진 ", "");
            string query = "select picture from pictures where id = " + pictureNum[int.Parse(id)] + " and buildingid = " + buildingID.ToString();
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            da = new MySqlDataAdapter(cmd);
            mbd = new MySqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label1.Text = listBox1.Text.ToString();
            ms.Close();
            conn.Close();

        }
        private void loadData() //저장 된 사진의 이름 불러오기
        {
            int count = 0;
            string query = "select id from pictures where buildingid =" + buildingID.ToString();
            listBox1.Items.Clear();
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    pictureNum[++count] = rdr[0].ToString();
                    listBox1.Items.Add("사진 " + count);
                }
            }
            rdr.Close();
            conn.Close();
        }
        private void deletePicture()
        {
            string id = listBox1.Text.ToString();
            string query;
            int i = 0;
            if (id.Equals(""))
                MetroMessageBox.Show(this, "삭제할 사진을 선택해주세요", "사진 미 선택", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                id = id.Replace("사진 ", "");
                conn.Open();
                query = "Delete From pictures where id = " + pictureNum[int.Parse(id)] + " and buildingid = " + buildingID.ToString();
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                pictureBox1.Image = null;
                label1.Text = "";
                if (pictureNum[int.Parse(id)].Equals(profilePictureID.ToString()))
                {  //프로필 사진을 지웠을 때 
                    label2.Text = "프로필 사진이 없습니다.";
                    profilePictureID = -1;


                    if (mode.Equals("managerMode"))
                    {
                        conn.Open();
                        cmd.CommandText = "update info1 SET profilePictureID = -1 where id = " + buildingID.ToString();
                        cmd.ExecuteNonQuery();
                        conn.Close();
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
                    for (i = 1; i < 10000; i++)
                    {
                        if (pictureNum[i] == null)
                        {
                            label2.Text = "프로필 사진이 없습니다.";
                            profilePictureID = -1;
                            break;
                        }
                        if (pictureNum[i].Equals(profilePictureID.ToString()) && pictureNum[i] != null)
                        {
                            if (string.Compare(pictureNum[int.Parse(id)], profilePictureID.ToString()) < 0)
                                i--;
                            label2.Text = "프로필 사진  : 사진 " + i;
                            break;
                        }

                    }


                }
                id = (int.Parse(id)).ToString();

                MetroMessageBox.Show(this, "사진 " + id + "가 삭제되었습니다.", "사진 삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            loadData();
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
            if (listBox1.Items.Count == 0 || mode.Equals("userMode"))
                this.Close();
            //if you do not save any photo, then close
            else if (profilePictureID == -1)
                MetroMessageBox.Show(this, "프로필 사진을 정해주세요", "사진 미 선택", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                switch (mode) //모드에 따른 프로필 사진 지정 여부 검사
                {
                    case "addMode":
                        newAddMenu.loadPicture();
                        break;
                    case "managerMode":
                        newManagerView.loadPicture();

                        break;
                    case "userMode":
                        newUserView.loadPicture();
                        break;
                }
                this.Close();
            }
        }

        private void btn_ProfilePicture_Click(object sender, EventArgs e)
        {
            string query;
            string id = listBox1.Text.ToString();
            id = id.Replace("사진 ", "");
            if (!id.Equals(""))
            {
                switch (mode) //모드에 따른 사진 추가 기능 유무 설정
                {
                    case "addMode":
                        profilePictureID = int.Parse(pictureNum[int.Parse(id)]);
                        conn.Open();
                        query = "update info1 SET profilePictureID = " + profilePictureID + " where id = " + buildingID.ToString();
                        cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        newAddMenu.profilePictureID = profilePictureID;
                        newAddMenu.loadPicture();
                        break;
                    case "managerMode":
                        profilePictureID = int.Parse(pictureNum[int.Parse(id)]);
                        conn.Open();
                        query = "update info1 SET profilePictureID = " + profilePictureID + " where id = " + buildingID.ToString();
                        cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        newManagerView.profilePictureID = profilePictureID;
                        newManagerView.loadPicture();
                        break;
                    case "userMode":
                        profilePictureID = int.Parse(pictureNum[int.Parse(id)]);
                        newUserView.profilePictureID = profilePictureID;
                        break;
                }

                label2.Text = "프로필 사진  : 사진 " + id;
                MetroMessageBox.Show(this, "사진 " + id + "가 프로필 사진으로 지정되었습니다", "프로필 사진 설정 완료", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex.ToString().Equals("-1"))
            {
                MetroMessageBox.Show(this, "사진을 선택해주세요", "사진 미 선택", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                string query = "";
                string openPictureID = listBox1.SelectedItem.ToString();
                openPictureID = openPictureID.Replace("사진 ", "");
                query = "select picture from pictures where buildingid =" + buildingID + " and id = " + pictureNum[int.Parse(openPictureID)];
                NewBigPicture newbigpicture = new NewBigPicture();
                newbigpicture.Owner = this;
                newbigpicture.query = query;
                newbigpicture.Show();
            }
        }

        private void NewShowPicture_Load(object sender, EventArgs e)
        {
            progressBar1.Hide();
            string query;
            strConn = MysqlIp.Logic.getStrConn(); //DLL에서 mysql server ip 불러오기
            conn = new MySqlConnection(strConn);
            label1.Text = "";
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
            picture = new MySqlParameter("@picture", MySqlDbType.LongBlob);
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
                conn.Open();
                query = "select picture from pictures where id = " + profilePictureID + " and buildingid = " + buildingID.ToString();
                cmd = new MySqlCommand(query, conn);
                da = new MySqlDataAdapter(cmd);
                mbd = new MySqlCommandBuilder(da);

                DataSet ds = new DataSet();
                da.Fill(ds);
                byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
                MemoryStream ms = new MemoryStream(ap);
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                label1.Text = listBox1.Text.ToString();
                ms.Close();
                conn.Close();

                listBox1.SelectedIndex = --i;

            }
        }
    }
}
