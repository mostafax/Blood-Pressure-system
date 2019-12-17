using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace BloodPressure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CRUD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CRUD.svc or CRUD.svc.cs at the Solution Explorer and start debugging.

   
    public class CRUD : ICRUD
    {
        static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\moham\\source\\repos\\BloodPressure\\App_Data\\BloodPressure.mdf;Integrated Security=True";
        SqlConnection sqlConn = new SqlConnection(connString);
 
        public void insertBloodTrack(BloodTrack bt)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("insert into BloodTrack values (@TrackDate,@HighBloodPressure,@LowBloodPressure,@PersonID)", sqlConn);
            cmd.Parameters.AddWithValue("@TrackDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@HighBloodPressure", bt.HighBloodPressure);
            cmd.Parameters.AddWithValue("@LowBloodPressure", bt.LowBloodPressure);
            cmd.Parameters.AddWithValue("@PersonID", bt.PersonID);
            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void insertDiet(Diet d)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("insert into Diet values (@Name,@Type)",sqlConn);
            cmd.Parameters.AddWithValue("@Name", d.Name);
            cmd.Parameters.AddWithValue("@Type", d.Type);
            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void insertDietMeal(DietMeal dm)
        {
            
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("insert into DietMeal values (@DietID,@BreakFast,@Lunch,@Dinner)", sqlConn);
            cmd.Parameters.AddWithValue("@DietID", dm.DietID);
            cmd.Parameters.AddWithValue("@BreakFast", dm.BreakFast);
            cmd.Parameters.AddWithValue("@Lunch", dm.Lunch);
            cmd.Parameters.AddWithValue("@Dinner", dm.Dinner);
            
            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void insertMeal(Meal m)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("insert into Meal (Name,Type) values (@Name,@Type)", sqlConn);
            cmd.Parameters.AddWithValue("@Name", m.Name);
            cmd.Parameters.AddWithValue("@Type", m.Type);
            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void insertPerson(Person p)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("insert into Person (Name,Age,Weight,Gender,Email,Password,DietID,UpdatePressure) values (@Name,@Age,@Weight,@Gender,@Email,@Password,@DietID,@UpdatePressure)", sqlConn);
            
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Age", p.Age);
            cmd.Parameters.AddWithValue("@Weight", p.Weight);
            cmd.Parameters.AddWithValue("@Gender", p.Gender);
            cmd.Parameters.AddWithValue("@Email",p.Email);
            cmd.Parameters.AddWithValue("@Password",p.Password);
            cmd.Parameters.AddWithValue("@DietID", p.DietID);
            cmd.Parameters.AddWithValue("@UpdatePressure",p.UpdatePressure);
            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        public Person viewPersonInfo(int PersonID)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("select * from  Person where PersonID = @PersonID", sqlConn);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader result;
            result = cmd.ExecuteReader();

            if (result.HasRows){
                result.Read();
            }
            
            return new Person(result, sqlConn);
        }
    }
}
