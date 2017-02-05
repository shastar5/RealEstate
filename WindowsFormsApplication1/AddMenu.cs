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
        ShowPicture sp;
        NaverMap nm;

        public AddMenu()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.BeginUpdate();
            AddComment(1, "asdf");
            AddComment(2, "dfdf");
            AddComment(3, "As");
            listView1.EndUpdate();
        }

        // 코멘트에 더하기
        private void AddComment(int idx, string content)
        {
            ListViewItem lvi = new ListViewItem(idx.ToString());
            lvi.SubItems.Add(content);
            listView1.Items.Add(lvi);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nm == null)
            {
                nm = new RealEstate.NaverMap();
                nm.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
     
        }

        // 코멘트 부분

      

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AddMenu_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if(sp == null)
            {
                sp = new RealEstate.ShowPicture();
                sp.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
