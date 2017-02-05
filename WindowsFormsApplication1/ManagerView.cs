using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class ManagerView : Form
    {
        NaverMap nm;

        public ManagerView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nm == null)
            {
                nm = new NaverMap();
                nm.Show();
            }
        }
    }
}
