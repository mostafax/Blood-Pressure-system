using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace BloodPressure
{
    public class Person
    {
        public Person() { this.PersonID = 0;this.Email = "None";this.Password = "None"; }
        public Person(SqlDataReader Result, SqlConnection sqlConn)
        {
            this.PersonID = int.Parse(Result["PersonID"].ToString());
            //this.DietID = -1;
            this.Name = Result["Name"].ToString();
            this.Age = int.Parse(Result["Age"].ToString());
            this.Email = Result["Email"].ToString();
            this.Password = Result["Password"].ToString();
            this.Weight = int.Parse(Result["Weight"].ToString());
            sqlConn.Close();
        }
        public string Name;
        public string Email;
        public string Password;
        public string Gender;
        public float Weight;
        public int Age;
        public int DietID;
        public int PersonID;
    }
}