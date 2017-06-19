using MetroFramework;
using System;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class NewLogin : MetroFramework.Forms.MetroForm
    {
        private NewFirstMenu newFirstMenu;

        public NewLogin()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (string.Equals(TB_ID.Text.ToString(), "admin"))
            {
                if (string.Equals(TB_PW.Text.ToString(), "admin"))
                {
                    if (newFirstMenu == null)
                    {
                        this.Hide();
                        newFirstMenu = new NewFirstMenu();
                        newFirstMenu.ShowDialog();
                        this.Close();

                    }
                }
                else
                    MetroMessageBox.Show(Owner, "아이디 혹은 비밀번호가 올바르지 않습니다", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
                MetroMessageBox.Show(Owner, "아이디 혹은 비밀번호가 올바르지 않습니다", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
    
}
