using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BloodPressure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmailNotifications" in both code and config file together.
    [ServiceContract]
    public interface IEmailNotifications
    {
        [OperationContract]
        void notify();

        [OperationContract]
        void SendNotification(string messageBody, string toAddressString);
    }
}
