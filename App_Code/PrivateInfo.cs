using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for PrivateInfo
/// </summary>
namespace PI
{
    public static class PrivateInfo
    {
        public static string SQL_STRING = "Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3";
        public static string WEB_LINK = "http://srswebapp-test.us-west-2.elasticbeanstalk.com";
        public static string companyEmail = "srsmail@example.com"; //For live demo purposes we should probably disable email notifications but leave the feature available in the github
        public static string companyEmailPassword = "Password!1";
        public static int companyEmailPort = 587;
        public static string companyEmailServer = "smtp.gmail.com";

    }
}
