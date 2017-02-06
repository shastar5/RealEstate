using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Controls;
using RealEstate;

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
        }

        private void btn_건물추가_Click(object sender, EventArgs e)
        {
            AddMenu addMenu = new AddMenu();
            addMenu.setDBfile(DBFile); //디비 파일 위치 전송
            addMenu.Show();

        }

        /*
         * 라디오버튼 체크 리스너
         */ 
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }


    }
