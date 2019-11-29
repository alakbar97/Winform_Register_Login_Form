using _11_29_19LAB.Classes;
using _11_29_19LAB.Db;
using _11_29_19LAB.Forms;
using System;
using System.Web.Helpers;
using System.Windows.Forms;

namespace _11_29_19LAB
{
    public partial class EnteranceForm : Form
    {
        public EnteranceForm()
        {
            InitializeComponent();
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void EnteranceForm_Load(object sender, EventArgs e)
        {
            User user = new User
            {
                Email = "admin@gmail.com",
                Name = "Adminka SABIT",
                Surname = "Adminov",
                Password = Crypto.HashPassword("Admin"),
                RoleType = RoleType.Admin
            };

            Database database = new Database("companyDb");
            if (!database.IsUserExist(user.Email))
            {
                database.AddUser(user);
            }

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
