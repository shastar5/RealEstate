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
    public partial class BigPicture : Form, DBInterface
    {
        string DBFile;
        public string query;
        String strConn;
        SQLiteConnection cn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteParameter picture;

        public BigPicture()
        {
            InitializeComponent();
        }
        private void loadPicture()
        {
            strConn = "Data Source=" + DBFile + "; Version=3;";
            cn.ConnectionString = strConn;
            cn.Open();
            cmd.CommandText = query;
            cmd = new SQLiteCommand(query, cn);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteCommandBuilder cbd = new SQLiteCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            byte[] ap = (byte[])(ds.Tables[0].Rows[0]["picture"]);
            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            ms.Close();
            cn.Close();
        }
        public void setDBfile(string DBFile)
        {
            this.DBFile = DBFile;
        }
        private void BigPicture_Load(object sender, EventArgs e)
        {
            loadPicture();
        }
    }
}
