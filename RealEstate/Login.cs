﻿using System;
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(KeyPressEventArgs.Equals(e.KeyChar, Keys.Return))
            {
                
            }
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
                        Owner = init;
                        init.ShowDialog();
                    }
                }
            }
            else
                MessageBox.Show("아이디 혹은 비밀번호가 올바르지 않습니다");
        }

    }
}
