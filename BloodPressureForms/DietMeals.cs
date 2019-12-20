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
    public partial class DietMeals : Form
    {
        public DietMeals()
        {
            InitializeComponent();
        }

        private void DietMeals_Load(object sender, EventArgs e)
        {
            CRUDService.CRUDClient crud = new CRUDService.CRUDClient();
            List<string> Meals = new List<string>();
            Meals = crud.viewPersonDiet(Login.Person_ID).ToList();
            DietName_value.Text = Meals[0];
            DietType_value.Text = Meals[1];
            MealBreakfast_value.Text = Meals[2];
            MealBreakfast.Text = Meals[3];
            MealLunch_value.Text = Meals[4];
            MealLuch.Text = Meals[5];
            MealDinner_value.Text = Meals[6];
            MealDinner.Text = Meals[7];

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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
    }
}
