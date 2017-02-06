using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApplication1
{
    
    public partial class InitialFoam : Form
    {

        string DBFile;
        String deskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //바탕화면 경로 가져오기

        public InitialFoam()
        {
            InitializeComponent();

            // Set tab control click event listener
            Init_탭컨트롤.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        // This is linked click event listener
        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Init_탭컨트롤.SelectedTab == Page_준비)
            {

            }

            else if(Init_탭컨트롤.SelectedTab == Page_완료)
            {

            }

            else if(Init_탭컨트롤.SelectedTab == Page_보류)
            {

            }

            else if (Init_탭컨트롤.SelectedTab == Page_매매)
            {

            }

            else if (Init_탭컨트롤.SelectedTab == Page_전체)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_건물추가_Click(object sender, EventArgs e)
        {
            AddMenu addMenu = new AddMenu();
            addMenu.setDBfile(DBFile); //디비 파일 위치 전송
            addMenu.Show();

        }

        private void btn_찾기_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_매매_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Panel_InitText_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
