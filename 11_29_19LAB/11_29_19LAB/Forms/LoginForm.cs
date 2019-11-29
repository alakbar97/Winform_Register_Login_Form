using _11_29_19LAB.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_29_19LAB.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Database database = new Database("companyDb");
            if (database.CheckUser(textBox1.Text,textBox2.Text))
            {
                MessageBox.Show("Logined Successfully!");
            }
            else
            {
                MessageBox.Show("Failed!");
            }
        }
    }
}
