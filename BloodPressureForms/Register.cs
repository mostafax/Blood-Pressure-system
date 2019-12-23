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

            CRUDService.CRUDClient crud = new CRUDService.CRUDClient();
            Person p = new Person();

            if (Program.MakeHiden)
            {
                p.Email = "none";
                p.Password = "none";
            }
            else
            {
                p.Email = EmailBox.Text;
                p.Password = PasswordBox.Text;
            }

            p.Name = NameBox.Text;
            p.Age = int.Parse(AgeBox.Text);
            p.Weight = float.Parse(WeightBox.Text);
            p.Gender = GenderBox.Text;

            if (!crud.validName(NameBox.Text))
            {
                Login.Person_ID = crud.insertPerson(p);
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
                MessageBox.Show("User Name is aready exist.");

            


        }

        private void Register_Load(object sender, EventArgs e)
        {
            if (Program.MakeHiden == true)
            {
                label6.Visible = false;
                label7.Visible = false;
                NameBox.ReadOnly = true;
                NameBox.Text = Program.PersonName;
                EmailBox.Visible = false;
                PasswordBox.Visible = false;
            }
        }
    }
}
