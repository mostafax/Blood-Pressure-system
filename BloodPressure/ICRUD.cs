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
        [OperationContract (IsOneWay =false)]
        int insertPerson(Person p);

        [OperationContract(IsOneWay =true)]
        void insertDiet(Diet d);

        [OperationContract(IsOneWay =true)]
        void insertMeal(Meal m);

        [OperationContract(IsOneWay =true)]
        void insertDietMeal(DietMeal dm);

        [OperationContract(IsOneWay =true)]
        void insertBloodTrack(BloodTrack bt, int PersonID);

        [OperationContract(IsOneWay =false)]
        Person viewPersonInfo(int PersonID);

        [OperationContract(IsOneWay =false)]
        List<string> viewPersonDiet(int PersonID);

        [OperationContract(IsOneWay =false)]
        List<BloodTrack> viewPersonBloodPressure(int PersonID);

        [OperationContract(IsOneWay =false)]
        List<string> getObservers();

        [OperationContract(IsOneWay =true)]
        void updatePerson(Person p);

        [OperationContract(IsOneWay =false)]
        int getSuitableDiet(float Pressure);

        [OperationContract(IsOneWay =true)]
        void setPersonDiet(int DietID, int PersonID);

        [OperationContract(IsOneWay =false)]
        bool validName(string Name);
    }
}
