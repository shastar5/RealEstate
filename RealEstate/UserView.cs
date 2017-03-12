using System;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class UserView : Form
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TB_Addr.Text.Equals(null))
            {
                return;
            }
            string addr = "http://map.daum.net/link/search/" + TB_Addr.Text;
            System.Diagnostics.Process.Start(addr);
        }

        private void UserView_Load(object sender, EventArgs e)
        {

        }
    }
}
