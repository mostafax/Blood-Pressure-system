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
using System.Windows.Forms.DataVisualization.Charting;

namespace BloodPressureForms
{
    public partial class HistoryBloodPressure : Form
    {
        public HistoryBloodPressure()
        {
            InitializeComponent();
        }

        private void HistoryBloodPressure_Load(object sender, EventArgs e)
        {
            CRUDService.CRUDClient crud = new CRUDService.CRUDClient();
            List<BloodTrack> bt = new List<BloodTrack>();
            bt = crud.viewPersonBloodPressure(Login.Person_ID).ToList();


            for (int i = 0; i < bt.Count(); i++)
            {
                
                this.chart1.Series["High Blood Pressure"].Points.AddXY( bt[i].TrackDate, bt[i].HighBloodPressure);
                this.chart1.Series["Low Blood Pressure"].Points.AddXY(bt[i].TrackDate, bt[i].LowBloodPressure);
              
            }

        }

        private void chart1_Click(object sender, EventArgs e)
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
