using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
namespace BloodPressure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICRUD" in both code and config file together.
    [ServiceContract]
    public interface ICRUD
    {
        [OperationContract]
        void insertPerson(Person p);

        [OperationContract]
        void insertDiet(Diet d);

        [OperationContract]
        void insertMeal(Meal m);

        [OperationContract]
        void insertDietMeal(DietMeal dm);

        [OperationContract]
        void insertBloodTrack(BloodTrack bt);

        [OperationContract]
        Person viewPersonInfo(int PersonID);

    }
}
