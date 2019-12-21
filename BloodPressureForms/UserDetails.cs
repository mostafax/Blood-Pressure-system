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
    public partial class UserDetails : Form 
    {
        public UserDetails()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.Show();
            this.Hide();
            
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            HistoryBloodPressure HB = new HistoryBloodPressure();
            HB.Show();
            this.Hide();
        }

        private void DietMeal_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DietMeals dietMeals = new DietMeals();
            dietMeals.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BloodPressure_Panel.Show();
        }

        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            Person p = new Person();
            CRUDService.CRUDClient crud = new CRUDService.CRUDClient();

            p = crud.viewPersonInfo(Login.Person_ID);
            UserName_Label.Text = p.Name;
            
        }

        private void DietMeal_Panel_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
