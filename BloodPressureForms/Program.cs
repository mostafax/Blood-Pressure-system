using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodPressureForms
{
    static class Program
    {
        public static bool MakeHiden;
        public static string PersonName;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            EmailNotification.EmailNotificationsClient emailNotification = new EmailNotification.EmailNotificationsClient();
            emailNotification.notify();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
