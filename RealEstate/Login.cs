using System;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class Login : Form
    {
        private string _id = "", _pw = "";
        private InitialFoam init;


        public Login()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                button1_Click(this, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBox1.Text.ToString(), "admin"))
            {
                if (string.Equals(textBox2.Text.ToString(), "admin"))
                {
                    if (init == null)
                    {
                        init = new InitialFoam();
                        Hide();
                        init.ShowDialog();
                    }
                }
            }
            else
                MessageBox.Show("아이디 혹은 비밀번호가 올바르지 않습니다");
        }

    }
}
