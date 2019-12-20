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
            label1.Text = Meals[0];
        }
    }
}
