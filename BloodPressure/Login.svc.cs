using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BloodPressure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Login" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Login.svc or Login.svc.cs at the Solution Explorer and start debugging.
    public class Login : ILogin
    {
        //TODO .. impelemt Login Function -> return -1 if not valid else return PersonID. 
        // Note -> For using Any of CRUD methods You Can Do As Follwing :
        //  CRUD crudMethods = new CRUD();
        int ILogin.Login(string Email)
        {
            throw new NotImplementedException();
        }
    }
}
