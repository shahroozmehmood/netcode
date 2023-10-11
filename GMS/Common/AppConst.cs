using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMS.Common
{
    public class AppConst
    {


        public const string AppName = "Gym Management System";

        public const string UnhandledException = "Unhandled Exception";
        public const string AuthTokenNotProvided = "Authorization Token Not Provided";
        public const string UnauthRequest = "Unauthorized Request";
        public const string AccessDenied = "Authorization has been denied for this request.";

        public const string INVALID_REQUEST = "The request is invalid";
        public const string MISSING_PARAMETER = "Required query parameter is missing";
        public const string MISSING_HEADER = "Required header is missing";

        public const string EXCEPTION_ERROR = "Oops something went wrong while processing your request please try again later!";

        public const bool manual_signups_enabled = false;
        public const string CNIC_ALREADY_EXIST = "CNIC already exists";
        public const string MEMBER_NO_ALREADY_EXIST = "Member no already exists";
        public const string SUBSCRIPTION_ALREADY_EXIST = "Subscription already exists";

        public const string MEMBER_DOESNOT_EXIST = "Member does not exists";
        public const string SUBSCRIPTION_DOESNOT_EXIST = "Subscription does not exists";
        public const string SUBSCRIPTION_PERIOD_DOESNOT_EXIST = "Subscription Period does not exists";
        public const string GENDER_REQUIRED = "Gender Required";

        #region
        public const string CRON_TRIGGER_STOCK_UPDATE = "CRON_TRIGGER_STOCK_UPDATE";
        public const string CRON_GROUP_STOCK_UPDATE = "CRON_GROUP_STOCK_UPDATE";

        #endregion

        #region User Roles related Strings //For more you can refer to Database Roles table

        public const string ROLE_Admin = "Admin";
        public const string ROLE_User = "User";


        #endregion

        public enum Gender
        {
            FEMALE = 0,
            MALE = 1
        }
        public enum Action
        {
            SAVE = 0,
            UPDATE = 1
        }

    }
  
}