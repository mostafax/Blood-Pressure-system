using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BloodPressure;


namespace BloodPressureForms
{
    public partial class Register : Form
    {

        public Register()
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            Login login = new Login();
            login.Show();
            this.Hide();


            CRUDService.CRUDClient crud = new CRUDService.CRUDClient();
            Person p = new Person();
            p.Name = NameBox.Text;
            p.Age = int.Parse(AgeBox.Text);
            p.Weight = float.Parse(WeightBox.Text);
            p.Gender = GenderBox.Text;
            p.Email = EmailBox.Text;
            p.Password = PasswordBox.Text;

            int Person_ID = crud.insertPerson(p);

            
            
        }
    }
}
