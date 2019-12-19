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
        static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\First Term - 4th Year\\SW Architecture\\Project\\Blood-Pressure-system\\BloodPressure\\App_Data\\BloodPressure.mdf;Integrated Security=True";
        SqlConnection sqlConn = new SqlConnection(connString);

        public List<string> getObservers()
        {
            
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("select Email from BloodTrack, Person where BloodTrack.NextBloodTrack >= GETDATE() and Person.PersonID = BloodTrack.PersonID", sqlConn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            List<string> Emailslist = new List<string>();

            while (reader.Read())
            {
                Emailslist.Add(reader.GetString(0));
            }

            sqlConn.Close();
            return Emailslist;
        }

        public int getSuitableDiet(float Pressure)
        {
            if (Pressure >= 120 && Pressure <= 140)
            {
                return 8;
            }
            else if (Pressure > 140)
            {
                return 9;
            }
            else
                return 10;
        }

        public void insertBloodTrack(BloodTrack bt, int PersonID)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("insert into BloodTrack values (@TrackDate,@HighBloodPressure,@LowBloodPressure,@PersonID,@NextBloodTrack)", sqlConn);

            cmd.Parameters.AddWithValue("@TrackDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@HighBloodPressure", bt.HighBloodPressure);
            cmd.Parameters.AddWithValue("@LowBloodPressure", bt.LowBloodPressure);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@NextBloodTrack", DateTime.Now.AddDays(1));
            int DiteID = getSuitableDiet(bt.HighBloodPressure);
            cmd.ExecuteNonQuery();
            sqlConn.Close();
            setPersonDiet(DiteID, PersonID);
            
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

        public int insertPerson(Person p)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("insert into Person (Name,Age,Weight,Gender,Email,Password) values (@Name,@Age,@Weight,@Gender,@Email,@Password);SELECT scope_identity()", sqlConn);
            
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Age", p.Age);
            cmd.Parameters.AddWithValue("@Weight", p.Weight);
            cmd.Parameters.AddWithValue("@Gender", p.Gender);
            cmd.Parameters.AddWithValue("@Email",p.Email);
            cmd.Parameters.AddWithValue("@Password",p.Password);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            
            sqlConn.Close();
            return id;
        }

        public void setPersonDiet(int DietID, int PersonID)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("update Person set DietID = @DietID where Person.PersonID = @PersonID;", sqlConn);

            cmd.Parameters.AddWithValue("@DietID", DietID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public void updatePerson(Person p)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("update Person set Name = @Name, Age = @Age,Weight = @Weight,Gender = @Gender,Email =@Email, Password=@Password,DietID = @DietID where Person.PersonID = @PersonID;", sqlConn);

            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Age", p.Age);
            cmd.Parameters.AddWithValue("@Weight", p.Weight);
            cmd.Parameters.AddWithValue("@Gender", p.Gender);
            cmd.Parameters.AddWithValue("@Email", p.Email);
            cmd.Parameters.AddWithValue("@Password", p.Password);
            cmd.Parameters.AddWithValue("@DietID", p.DietID);
            cmd.Parameters.AddWithValue("@PersonID", p.PersonID);
            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        public List<BloodTrack> viewPersonBloodPressure(int PersonID)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("select TrackDate, HighBloodPressure, LowBloodPressure from BloodTrack where BloodTrack.PersonID = @PersonID", sqlConn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            bool First = true;
            List<BloodTrack> BloodPressurelist = new List<BloodTrack>();

            while (reader.Read())
            {
                BloodTrack temp = new BloodTrack();
                temp.TrackDate = DateTime.Parse(reader["TrackDate"].ToString());
                temp.HighBloodPressure = float.Parse(reader["HighBloodPressure"].ToString());
                temp.LowBloodPressure = float.Parse(reader["LowBloodPressure"].ToString());
                BloodPressurelist.Add(temp);
            }

            sqlConn.Close();
            return BloodPressurelist;
        }

        public List<string> viewPersonDiet(int PersonID)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("select Diet.DietName,Diet.DietType, Meal.Name,Meal.Type from  Person, Diet, DietMeal, Meal where PersonID = @PersonID AND Diet.DietID = (select Person.DietID from Person where Person.PersonID = @PersonID) AND (DietMeal.BreakFast = Meal.MealID OR DietMeal.Lunch = Meal.MealID OR DietMeal.Dinner = Meal.MealID ) AND DietMeal.DietID = Person.DietID ", sqlConn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            bool First = true;
            List<string> Dietlist = new List<string>();
            
            while (reader.Read())
            {
                if(First)
                {
                    Dietlist.Add(reader.GetString(0));
                    Dietlist.Add(reader.GetString(1));
                    First = false;
                }
               
                Dietlist.Add(reader.GetString(2));
                Dietlist.Add(reader.GetString(3));
            }

            sqlConn.Close();
            return Dietlist;
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
