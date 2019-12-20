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
        int insertPerson(Person p);

        [OperationContract]
        void insertDiet(Diet d);

        [OperationContract]
        void insertMeal(Meal m);

        [OperationContract]
        void insertDietMeal(DietMeal dm);

        [OperationContract]
        void insertBloodTrack(BloodTrack bt, int PersonID);

        [OperationContract]
        Person viewPersonInfo(int PersonID);

        [OperationContract]
        List<string> viewPersonDiet(int PersonID);

        [OperationContract]
        List<BloodTrack> viewPersonBloodPressure(int PersonID);

        [OperationContract]
        List<string> getObservers();

        [OperationContract]
        int updatePerson(Person p);

        [OperationContract]
        int getSuitableDiet(float Pressure);

        [OperationContract]
        void setPersonDiet(int DietID, int PersonID);

    }
}
