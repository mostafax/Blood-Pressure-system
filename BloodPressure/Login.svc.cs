using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace BloodPressure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Login" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Login.svc or Login.svc.cs at the Solution Explorer and start debugging.
    public class Login : ILogin
    {
        //TODO .. impelemt Login Function -> return -1 if not valid else return PersonID. 
        // Note -> For using Any of CRUD methods You Can Do As Follwing :
        //  CRUD crudMethods = new CRUD();
        static string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mostafax\\Desktop\\Blood-Pressure-system\\BloodPressure\\App_Data\\BloodPressure.mdf;Integrated Security=True";
        SqlConnection sqlConn = new SqlConnection(connString);
        int ILogin.Login(string Name, string Password)
        {
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT PersonID,Name,password FROM Person  WHERE Person.Name = @Name AND (Person.Password = @Password or Person.Password = 'none') ", sqlConn);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Password", Password);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            int r = 0;
            if (reader.Read())
            {
                r = reader.GetInt32(0);
                sqlConn.Close();
                return r;

            }

            sqlConn.Close();
            return -1; 
        }
    }
}
