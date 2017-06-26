using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace RealEstate
{
    public partial class NewBigPicture : MetroFramework.Forms.MetroForm
    {
        public string query;
        String strConn;
        public NewBigPicture()
        {
            InitializeComponent();
        }
        private void loadPicture()
        {
            MySqlConnection conn = new MySqlConnection(strConn);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            MySqlCommandBuilder mbd = new MySqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            ms.Close();
            conn.Close();
        }

        private void newBigPicture_Load(object sender, EventArgs e)
        {
            strConn = MysqlIp.Logic.getStrConn(); //DLL에서 mysql server ip 불러오기 MySqlConnection conn = new MySqlConnection(strConn2);
            loadPicture();
        }
    }
}
