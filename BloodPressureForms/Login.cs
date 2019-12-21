using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodPressureForms
{
    public partial class Login : Form
    {
        public static int Person_ID;
        public Login()
        {
            InitializeComponent();
            PasswordBox.PasswordChar = '*';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            LoginService.LoginClient login = new LoginService.LoginClient();
            int ID = login.Login(UsernameBox.Text, PasswordBox.Text);
            if (ID == -1)
            {
                MessageBox.Show("Invalid Username or Password");
            }
            else
            {
                Person_ID = ID;
                UserDetails userDetails = new UserDetails();
                userDetails.Show();
                this.Hide();
            }

        }
    }
}
