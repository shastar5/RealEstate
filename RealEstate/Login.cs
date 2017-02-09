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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBox1.Text.ToString(), "admin"))
            {
                if (string.Equals(textBox2.Text.ToString(), "admin"))
                {
                    if (init == null)
                    {
                        init = new InitialFoam();
                        init.Owner = this;
                        this.Hide();
                        init.ShowDialog();
                    }
                }
            }
            else
                MessageBox.Show("아이디 혹은 비밀번호가 올바르지 않습니다");
        }

    }
}
