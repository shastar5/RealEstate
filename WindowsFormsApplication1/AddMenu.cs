using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RealEstate;

namespace WindowsFormsApplication1
{
    public partial class AddMenu : Form
    {

        public AddMenu()
        {
            InitializeComponent();

            listView1.View = View.Details;

            listView1.BeginUpdate();

            listView1.Columns.Add("index");
            listView1.Columns.Add("Content");

            ListViewItem lvi = new ListViewItem("1");
            lvi.SubItems.Add("사거리에 보기가 좋다");
            listView1.Items.Add(lvi);



            listView1.EndUpdate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NaverMap nm = new NaverMap();
            nm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowPicture pc = new ShowPicture();
            pc.Show();
        }

        // 코멘트 부분

      

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

    public class Comment
    {
        int index;
        string data;
      
        Comment() { }

        Comment(int arg0, string arg1)
        {
            this.index = arg0;
            this.data = arg1;
        }
    }
}
