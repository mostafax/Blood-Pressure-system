using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BloodPressure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmailNotifications" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmailNotifications.svc or EmailNotifications.svc.cs at the Solution Explorer and start debugging.
    public class EmailNotifications : IEmailNotifications
    {
        CRUD crudMethods = new CRUD();
        public void notify()
        {
            List<string> Emails = new List<string>();
            Emails = crudMethods.getObservers();
            string messageBody = "Reminder Remember to measure your blood pressure ";
            string email = "mostafamousa1080p@gmail.com";
            for (int i=0;i<Emails.Count;i++)
            {
                SendNotification(messageBody, Emails[i]);
            }

        }

        public void SendNotification(string messageBody, string toAddressString)
        {
            var fromAddress = new MailAddress("odpproject2050@gmail.com", "Blood Pressure System");
            var toAddress = new MailAddress(toAddressString, "To Name");
            const string fromPassword = "google2019";
            const string subject = "Blood Pressure Notification";
            string body = messageBody;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
            };

            var message = new MailMessage(fromAddress.ToString(), toAddress.ToString(), subject, body);
            smtp.Send(message);
        }
    }


    
}
