using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Shared
{
    public class Constants
    {
        public static class Areas
        {
            public const string Administration = "Administration";
        }

        public static class EmailTemplates
        {
            public const string AddNewUserNotification = "Add New User Notification";
        }

        public static class MainPages
        {
            public const string Home = "HomePage";
            public const string Sample = "Sample";

            // System pages
            public const string Dashboard = "Dashboard";
            public const string EmailTemplates = "Email Templates";
            public const string EmailTemplateEdit = "Email Template Edit";
            public const string Settings = "Settings";
            public const string SettingEdit = "Edit Setting";
            public const string Login = "Login";
            public const string Logs = "Application Logs";
            public const string TraceLogs = "Trace Logs";
            public const string Users = "Users";
            public const string UserCreate = "Add New User";
            public const string UserEdit = "Edit User";
            public const string ReleaseHistory = "Release History";
            public const string PageNotFound = "Page Not Found";
            public const string Error = "Error";
            public const string AntiForgery = "Oops!";
            public const string AccessDenied = "Access Denied";
            public const string AdAccountNotFound = "AD Account Not Found";
        }

        public static class Messages
        {
            public const string Error = "An error occurred while processing your request. " +
                                        "If these issue persists, then please contact customer service.";

            public const string PageNotFound = "Sorry, the page you're looking for cannot be found. " +
                                               "If these issue persists, then please contact customer service.";

            public const string InvalidData = "One or more fields contain invalid data. Please fix and submit again. " +
                                              "If these issue persists, then please contact customer service.";

            public const string NotAuthorized = "You does not have access to Application. Please contact your manager.";

            public const string AccessDenied = "You do not have permission to perform the selected operation. Please contact your manager.";

            public const string AdAccountNotFound = "Your AD Account is not found. Please contact your manager.";
        }
        public const string Role_Admin = "Admin";
        public const string Role_Customer = "Customer";
        public const string Role_Employee = "Employee";
        public const string Role_Barber = "Barber";
        public const string Role_Owner = "Owner";
        public static class RoleNames
        {
            public const string Developer = "Developer";
            public const string Administrator = "Administrator";
            public const string ApplicationManager = "Application Manager";
            public const string Auditor = "Auditor";
            public const string Carrier = "Carrier";
            public const string Broker = "Broker";
            public const string Shipper = "Shipper";
        }

        public static class Settings
        {
            public const string LogClearDays = "log.clear.days";
            public const string EmailSend = "email.send";
            public static string EmailAddresses = "email.to.addresses";
        }

        /// <summary>
        /// Cache time in minutes.
        /// </summary>
        public static class CacheTimes
        {
            public const int Default = 60;
        }


        public static class SD
        {
            public const string Role_Admin = "Admin";
            public const string Role_Customer = "Customer";
            public const string Role_Employee = "Employee";
            public const string Role_Barber = "Barber";
            public const string Role_Owner = "Owner";

            public const string Local_InitialBooking = "InitialRoomBookingInfo";
            public const string Local_RoomOrderDetails = "RoomOrderDetails";
            public const string Local_Token = "JWT Token";
            public const string Local_UserDetails = "User Details";
            public const string Local_UserName = "User Name";
            public const string Local_BookDetails = "Book Details";


            public const string Status_Pending = "Pending";
            public const string Status_Booked = "Booked";
            public const string Status_CheckedIn = "CheckedIn";
            public const string Status_CheckedOut_Completed = "CheckedOut";
            public const string Status_NoShow = "NoShow";
            public const string Status_Cancelled = "Cancelled";

            public const string error_msg_operation_failed = "Operation Failed!Kindly contact your administrator";
            public const string msg_delete_success = "Delete operation successfull";

        }
    }
}
