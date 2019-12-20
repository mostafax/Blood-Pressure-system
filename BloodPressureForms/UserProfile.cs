using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BloodPressure;

namespace BloodPressureForms
{
    public partial class UserProfile : Form
    {
        public UserProfile()
        {
            InitializeComponent();
            PasswordBox.PasswordChar = '*';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.Show();
            this.Hide();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            
            Person p = new Person();
            CRUDService.CRUDClient crud = new CRUDService.CRUDClient();
            p = crud.viewPersonInfo(Login.Person_ID);

            NameBox.Text = p.Name;
            AgeBox.Text = (p.Age).ToString();
            WeightBox.Text = (p.Weight).ToString();
            if (p.Gender == "Male")
            {
                GenderBox.SelectedIndex = 0;
            }
            else
            {
                GenderBox.SelectedIndex = 1;
            }
            EmailBox.Text = p.Email;
            PasswordBox.Text = p.Password;
            


        }
    }
}
