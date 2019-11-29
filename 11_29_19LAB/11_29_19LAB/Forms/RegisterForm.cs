using _11_29_19LAB.Classes;
using _11_29_19LAB.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Windows.Forms;

namespace _11_29_19LAB.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbx_Email.Text)|| String.IsNullOrEmpty(tbx_Name.Text)|| String.IsNullOrEmpty(tbx_Password.Text)|| String.IsNullOrEmpty(tbx_Surname.Text))
            {
                MessageBox.Show("Fill ALL Inputs");
            }
            else
            {
                User user = new User
                {
                    Email = tbx_Email.Text,
                    Name = tbx_Name.Text,
                    Surname = tbx_Surname.Text,
                    Password = Crypto.HashPassword(tbx_Password.Text),
                    RoleType=RoleType.User
                };
                Database database = new Database("companyDb");
                if (!database.IsUserExist(user.Email))
                {
                    database.AddUser(user);
                    MessageBox.Show("Registered Successfuly!");
                }
                else
                {
                    MessageBox.Show("This Email Already Registered!");
                }
               
            }
        }
    }
}
