using System;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class Login : Form
    {
        private FirstMenu firstMenu;


        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                MessageBox.Show("Return Key Pressed");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBox1.Text.ToString(), "admin"))
            {
                if (string.Equals(textBox2.Text.ToString(), "admin"))
                {
                    if (firstMenu == null)
                    {
                        this.Hide();
                        firstMenu = new FirstMenu();
                        firstMenu.ShowDialog();
                        this.Close();

                    }
                }
                else
                    MessageBox.Show("아이디 혹은 비밀번호가 올바르지 않습니다");
            }
            else
                MessageBox.Show("아이디 혹은 비밀번호가 올바르지 않습니다");
        }

    }
}
