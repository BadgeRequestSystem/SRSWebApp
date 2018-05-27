using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using AES; //Accesses our static methods in 'Encryption.cs'
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Methods
/// </summary>
public class Methods : System.Web.UI.Page
{
    //So we won't have the connection string hanging around every page and changing it here will change it everywhere! (Except for the aspx.cs pages but I want to fix that too!)
    public string SQL_STRING = "Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3";
    public string WEB_LINK = "http://srswebapp-test.us-west-2.elasticbeanstalk.com";
    public string companyEmail = "dontreplysrsmail@gmail.com"; //For live demo purposes we should probably disable email notifications but leave the feature available in the github
    public string companyEmailPassword = "Password!1";
    public int companyEmailPort = 587;
    public string companyEmailServer = "smtp.gmail.com";
    //~~

    public Methods()
    {

    }

    public string sanitizeInput(string x)
    {
        string toReturn = x;

        if (toReturn.Contains("'"))
        {
            toReturn = toReturn.Replace("'", "");
        }


        return toReturn;
    }

    public string lastFourOnly(string x)
    {
        string toReturn = "*****" + x[5] + x[6] + x[7] + x[8];

        return toReturn;

    }
    public string stripSSN(string SSN)
    {
        return Regex.Replace(SSN, "[^0-9]", "");
    }

    public void DeleteCookie(string CookieName) //Check if cookie exists, and if it does it will delete it.
    {
        if (HttpContext.Current.Request.Cookies[CookieName] != null)
            HttpContext.Current.Response.Cookies[CookieName].Expires = DateTime.Now.AddDays(-1);
    }
    public bool CookieExists(string CookieName) //Check if cookie exists, and if it does it will delete it.
    {
        if (HttpContext.Current.Request.Cookies[CookieName] != null)
            return true;
        else
            return false;
    }

    public string sliceEmployee(string Employee, string CASE) //given an employee, return either the First or Last name
    {
        int firstIndex, secondIndex = -1;
        string lName, fName = string.Empty;

        if (CASE == "First Name")
        {
            firstIndex = Employee.IndexOf(' ');
            fName = Employee.Substring(0, firstIndex);
            return fName;
        }
        if (CASE == "Last Name")
        {
            secondIndex = Employee.LastIndexOf(' ');
            lName = Employee.Substring(secondIndex + 1);
            return lName;
        }
        else
            return "";

    }
    public void sendNotification(string Employee, string Manager)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(companyEmailServer);

            mail.From = new MailAddress(companyEmail);
            mail.To.Add(returnEmail(Employee));
            mail.Subject = "SRS Badge Request Received";
            mail.IsBodyHtml = true;
            string body1 = String.Format("Dear {0},\n\tWe wanted to inform you that your SRS Badge Request has been received." + "\nYou will be notified on the status of your request shortly. We thank you for your patience. \nSincerely,\nThe SRS Badge Request System\n", Employee);
            mail.Body = body1 + "<a href = '" + WEB_LINK + "' > Login to view your request! </a>";

            SmtpServer.Port = companyEmailPort;
            SmtpServer.Credentials = new System.Net.NetworkCredential(companyEmail, companyEmailPassword);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            MailMessage mail2 = new MailMessage();
            SmtpClient SmtpServer2 = new SmtpClient(companyEmailServer);

            mail2.From = new MailAddress(companyEmail);
            mail2.To.Add(returnEmail(Manager));
            mail2.Subject = "SRS Badge Request Attention Needed";
            mail2.Body = String.Format("Dear {0},\n\tWe wanted to inform you that {1} has put in a request for a new badge." +
                "\nPlease review the request at your earliest convenience. We thank you for your time. \nSincerely,\nThe SRS Badge Request System", Manager, Employee);

            SmtpServer2.Port = companyEmailPort;
            SmtpServer2.Credentials = new System.Net.NetworkCredential(companyEmail, companyEmailPassword);
            SmtpServer2.EnableSsl = true;
            SmtpServer2.Send(mail2);
        }
        catch (Exception ex)
        {

        }
    }
    public void Review_sendNotifcation(string Employee, string Response) //ManagerReviewForm version
    {
        try
        {
            if (Response != "Need")
            {
                //Response should be either "Accepted" or "Denied"
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(companyEmailServer);

                mail.From = new MailAddress(companyEmail);
                mail.To.Add(returnEmail(Employee));
                mail.Subject = String.Format("SRS Badge Request {0}", Response);
                mail.IsBodyHtml = true;
                string body1 = String.Format("Dear {0},\n\tWe wanted to inform you that your SRS Badge Request has been {1}." + "\nWe thank you for your patience. \nSincerely,\nThe SRS Badge Request System\n", Employee, Response);
                mail.Body = body1 + "Please click " + "<a href = '" + WEB_LINK + "' > HERE </a>" + "if you would like to vist the SRS Badge Request Site.";

                SmtpServer.Port = companyEmailPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(companyEmail, companyEmailPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            else
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(companyEmailServer);

                mail.From = new MailAddress(companyEmail);
                mail.To.Add(returnEmail(Employee));
                mail.Subject = String.Format("SRS Badge Request Needs Review");
                mail.IsBodyHtml = true;
                string body1 = String.Format("Dear {0},\n\tWe wanted to inform you that your SRS Badge Request has been flagged due to an error." + "\nPlease review your pending requests and make any needed corrections.\nSincerely,\nThe SRS Badge Request System\n", Employee);
                mail.Body = body1 + "Please click " + "<a href = '" + WEB_LINK + "' > HERE </a>" + "if you would like to vist the SRS Badge Request Site.";

                SmtpServer.Port = companyEmailPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(companyEmail, companyEmailPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
        }
        catch (Exception ex)
        {

        }


    }
    public string returnEmail(string Employee)
    {
        HttpCookie aCookie = Request.Cookies["userInfo"];
        string email = string.Empty;
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"Select Email FROM Credentials WHERE UserID =
                                            (Select UserID FROM Employees WHERE ([First Name] + ' ' + [Middle Name]  + ' ' + [Last Name]) =@employee)", Connection);
            cmd.Parameters.AddWithValue("@employee", Employee);
            email = (string)cmd.ExecuteScalar();
            Connection.Close();
        }
        return email;
    }

    public void SIMPLE_POPUP(string message)
    {
        HttpContext.Current.Response.Write("<script>alert('" + message + "')</script>");
    }


    /*SQL RELATED METHODS BELOW!*/

    public void EditEmployee(string CASE, string LName, string FName, string MName, string Initials, string UserID, string ECompany, string Department, string WLocation, string WPhone, string MWLocation, string MWPhone, string EManager)
    {
        SqlCommand query = new SqlCommand(); //store the command here

        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            if (CASE == "NEW")
                query = new SqlCommand(@"INSERT INTO Employees
                    VALUES (@LName, @FName, @MName, @Initials, @UserID, @ECompany, @Department, @WLocation, @WPhone, @EManager, @MWLocation, @MWPhone);", Connection);
            if (CASE == "UPDATE")
                query = new SqlCommand(@"Update Employees
                    SET [First Name]=@FName, [Last Name]=@LName, [Middle Name]=@MName, [Initials]=@Initials, [Employee Company]=@ECompany, [Department]=@Department, [Work Location]=@WLocation, [Work Phone Number]=@WPhone, [Manager Name]=@EManager, [Manager Work Location]=@MWLocation, [Manager Work Phone Number]=@MWPhone
                    WHERE UserID=@UserID;", Connection);
            Connection.Open();
            SqlCommand cmd = query;
            cmd.Parameters.AddWithValue("@LName", sanitizeInput(LName));
            cmd.Parameters.AddWithValue("@FName", sanitizeInput(FName));
            cmd.Parameters.AddWithValue("@MName", sanitizeInput(MName));
            cmd.Parameters.AddWithValue("@Initials", sanitizeInput(Initials));
            cmd.Parameters.AddWithValue("@UserID", UserID); //one would think 5 characters would be enough to deter sql injection attempts :)
            cmd.Parameters.AddWithValue("@ECompany", sanitizeInput(ECompany));
            cmd.Parameters.AddWithValue("@Department", sanitizeInput(Department));
            cmd.Parameters.AddWithValue("@WLocation", sanitizeInput(WLocation));
            cmd.Parameters.AddWithValue("@WPhone", sanitizeInput(WPhone));
            cmd.Parameters.AddWithValue("@MWLocation", sanitizeInput(MWLocation));
            cmd.Parameters.AddWithValue("@MWPhone", sanitizeInput(MWPhone));
            if (EManager == "No Manager") //if the 'No Manager' option is selected then Manager Name in database is empty
            {
                cmd.Parameters.AddWithValue("@EManager", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("@EManager", sanitizeInput(EManager));
            }
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }

    public void HRForm_Read(HttpCookie bCookie, string UID)
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Employees WHERE UserID=@UID", Connection);
            cmd.Parameters.AddWithValue("@UID", UID);
            Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bCookie["Last Name"] = reader["Last Name"].ToString().Trim();
                    bCookie["First Name"] = reader["First Name"].ToString().Trim();
                    bCookie["Middle Name"] = reader["Middle Name"].ToString().Trim();
                    bCookie["Initials"] = reader["Initials"].ToString().Trim();
                    bCookie["UserID"] = reader["UserID"].ToString().Trim();
                    bCookie["Employee Company"] = reader["Employee Company"].ToString().Trim();
                    bCookie["Department"] = reader["Department"].ToString().Trim();
                    bCookie["Work Location"] = reader["Work Location"].ToString().Trim();
                    bCookie["Work Phone Number"] = reader["Work Phone Number"].ToString().Trim();
                    bCookie["Manager Name"] = reader["Manager Name"].ToString().Trim();
                    bCookie["Manager Work Location"] = reader["Manager Work Location"].ToString().Trim();
                    bCookie["Manager Work Phone Number"] = reader["Manager Work Phone Number"].ToString().Trim();

                }
                Connection.Close();
            }
        }
    }

    public void DeleteFromEmployeesByUID(string UID)
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Employees WHERE [UserID] = @uid", Connection);
            cmd.Parameters.AddWithValue("@uid", UID);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }

    public void Request_Read(HttpCookie bCookie, string REQID, bool specialCase) //specialCase is used in basicRead(). specialCase should be true if used from PendingForm or PendingActionForm
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            basicRead(bCookie, REQID, specialCase); //I've made this method in order to make sql read calling more versatile.

            SqlCommand cmd2 = new SqlCommand(@"SELECT * FROM Employees WHERE [First Name]=@fName AND [Last Name]=@lName", Connection);
            cmd2.Parameters.AddWithValue("@fName", sliceEmployee(bCookie["Employee"], "First Name"));
            cmd2.Parameters.AddWithValue("@lName", sliceEmployee(bCookie["Employee"], "Last Name"));
            Connection.Open();
            using (SqlDataReader reader2 = cmd2.ExecuteReader())
            {
                while (reader2.Read())
                {
                    bCookie["Initials"] = reader2["Initials"].ToString();
                    bCookie["UserID"] = reader2["UserID"].ToString();
                    bCookie["Company"] = reader2["Employee Company"].ToString();
                    bCookie["Department"] = reader2["Department"].ToString();
                    bCookie["Location"] = reader2["Work Location"].ToString();
                    bCookie["Phone"] = reader2["Work Phone Number"].ToString();
                    bCookie["Manager"] = reader2["Manager Name"].ToString();
                    bCookie["ManagerLocation"] = reader2["Manager Work Location"].ToString();
                    bCookie["ManagerPhone"] = reader2["Manager Work Phone Number"].ToString();
                }
                Connection.Close();
            }
        }
    }


    public void basicRead(HttpCookie bCookie, string REQID, bool specialCase) //Part 1 for Request_Read(), and also used for PendingActionForm. if specialCase = true, then we store the "Editable" flag into bCookie.
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Requests WHERE RequestID=@RequestID", Connection);
            cmd.Parameters.AddWithValue("@RequestID", REQID);
            bCookie["RequestID"] = REQID;
            Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    bCookie["Employee"] = reader["Employee"].ToString();
                    bCookie["Reason"] = reader["ReasonForRequest"].ToString();
                    bCookie["GET"] = reader["GETDate"].ToString();
                    bCookie["SSN"] = reader["SSN"].ToString();
                    bCookie["DOB"] = reader["DateOfBirth"].ToString();
                    bCookie["TOB"] = reader["TypeOfBadge"].ToString();
                    bCookie["Proximity"] = reader["ProximityCard"].ToString();
                    bCookie["Emergency"] = reader["EmergencyAccess"].ToString();
                    bCookie["Accounts"] = reader["ContinueAccounts"].ToString();
                    bCookie["Notes"] = reader["Notes"].ToString();
                    if (specialCase == true)
                        bCookie["Editable"] = reader["Editable"].ToString(); //The 'is this request editable' flag.
                }
                Connection.Close();
            }
        }
    }


    public void SubmitRequest(string Employee, string Reason, string GET, string SSN, string DOB, string BadgeType, bool Proximity, bool Emergency, bool Accounts, string Notes, string Username, string State, bool canEdit, string REQID)
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            SqlCommand query = new SqlCommand(); //store the command here
            if (REQID == "") //Normal case
                query = new SqlCommand(@"INSERT INTO Requests
                    VALUES (@Employee, @Reason, @GET, @SSN, @DOB, @BadgeType, @Proximity, @Emergency, @Accounts, @Notes, @CurrentDate, @State, @Username, @canEdit);", Connection);
            if (REQID != "") //if REQID has something, then we are updating a request.
                query = new SqlCommand(@"Update Requests SET [Employee]=@Employee, [ReasonForRequest]=@Reason, [GETDate]=@GET, [SSN]=@SSN, [DateOfBirth]=@DOB, [TypeOfBadge]=@BadgeType, [ProximityCard]=@Proximity, [EmergencyAccess]=@Emergency, [ContinueAccounts]=@Accounts, [Notes]=@Notes, [CurrentDate]=@CurrentDate, [RequestState]=@State, [Username]=@Username, [Editable]=@canEdit WHERE RequestID=@reqID;", Connection);

            Connection.Open();
            SqlCommand cmd = query;
            cmd.Parameters.AddWithValue("@Employee", Employee);
            cmd.Parameters.AddWithValue("@Reason", Reason);
            cmd.Parameters.AddWithValue("@GET", GET);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@BadgeType", BadgeType);
            cmd.Parameters.AddWithValue("@Proximity", Proximity);
            cmd.Parameters.AddWithValue("@Emergency", Emergency);
            cmd.Parameters.AddWithValue("@Accounts", Accounts);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@canEdit", false); //by default, a user cannot edit a pending request until a manager checks off on it.
            if (REQID != "")
                cmd.Parameters.AddWithValue("@reqID", REQID);

            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }

    public void SaveRequest(string Employee, string Reason, string GET, string SSN, string DOB, string BadgeType, bool Proximity, bool Emergency, bool Accounts, string Notes, string Username) //Saving request as a DRAFT
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO Drafts
                    VALUES (@Employee, @Reason, @GET, @SSN, @DOB, @BadgeType, @Proximity, @Emergency, @Accounts, @Notes, @CurrentDate, @State, @Username);", Connection);
            cmd.Parameters.AddWithValue("@Employee", Employee);
            cmd.Parameters.AddWithValue("@Reason", Reason);
            cmd.Parameters.AddWithValue("@GET", GET);
            cmd.Parameters.AddWithValue("@SSN", SSN);
            cmd.Parameters.AddWithValue("@DOB", DOB);
            cmd.Parameters.AddWithValue("@BadgeType", BadgeType);
            cmd.Parameters.AddWithValue("@Proximity", Proximity);
            cmd.Parameters.AddWithValue("@Emergency", Emergency);
            cmd.Parameters.AddWithValue("@Accounts", Accounts);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@State", "Draft");

            cmd.ExecuteNonQuery();
        }
    }

    public void ReviewForm(string REQID, string action) //ManagerReviewForm - Approve, deny, or needs more info
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            SqlCommand query = new SqlCommand(); //store the command here
            if (action == "Approve")
                query = new SqlCommand(@"Update Requests
                    SET [RequestState] = 'Approved'
                    WHERE RequestID=@RequestID;", Connection);
            else if (action == "Deny")
                query = new SqlCommand(@"Update Requests
                    SET [RequestState] = 'Denied'
                    WHERE RequestID=@RequestID;", Connection);
            else if (action == "Info")
                query = new SqlCommand(@"Update Requests
                    SET [Editable]=@canEdit
                    WHERE RequestID=@RequestID;", Connection);

            Connection.Open();
            SqlCommand cmd = query;
            cmd.Parameters.AddWithValue("@RequestID", REQID);
            if (action == "Info")
                cmd.Parameters.AddWithValue("@canEdit", true);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }


    public void LoginCookie(HttpCookie aCookie, string userName) //Fills the 'userInfo' cookie after the password hash matches the password from the user.
    {


        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Credentials WHERE Username=@uname", Connection);
            cmd.Parameters.AddWithValue("@uname", sanitizeInput(userName));
            Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    aCookie.Values["userName"] = userName;
                    aCookie.Values["isManager"] = reader["isManager"].ToString();
                    aCookie.Values["isHR"] = reader["isHR"].ToString();
                    aCookie.Values["UserID"] = reader["UserID"].ToString();
                    aCookie.Values["Email"] = reader["Email"].ToString().Trim();

                }
                Connection.Close();
            }
            SqlCommand cmdGetManagerName = new SqlCommand(@"SELECT [Manager Name] FROM Employees
                                                    WHERE UserID=@tempID", Connection);
            cmdGetManagerName.Parameters.AddWithValue("@tempID", aCookie.Values["UserID"]);
            Connection.Open();
            aCookie.Values["Manager"] = cmdGetManagerName.ExecuteScalar().ToString().Trim(); //grabbing the Manager's name given the employee UserID
            Connection.Close();

        }
    }

    public void checkLogin(HttpCookie aCookie, string userName, string passWord)
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            try
            {
                Connection.Open();

                SqlCommand cmd = new SqlCommand(@"Select PasswordHash FROM Credentials   WHERE Username=@uname", Connection);
                cmd.Parameters.AddWithValue("@uname", sanitizeInput(userName));

                string passwordHash = (string)cmd.ExecuteScalar(); //grab password hash from database
                bool result = Encryption.ValidateInput(passWord, passwordHash); //call our ValidateInput method for the given password and the passwordHash we have on record.

                if (result == true) //SUCCESSFUL LOGIN
                {
                    Connection.Close();
                    LoginCookie(aCookie, sanitizeInput(userName)); //Fill the login cookie 'userInfo'
                }

                else //LOGIN UNSUCCESFUL
                    Connection.Close();

            }
            catch (Exception ex)
            {
                Connection.Close();
            }
        }
    }

    public ListBox fillListBoxDRAFT(ListBox LB, string USERNAME) //SavedRequestForm's fill listbox method.
    {
        SqlConnection connection = new SqlConnection(SQL_STRING);
        connection.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(@"Select [Employee], [CurrentDate] From Drafts WHERE (([RequestState] = @RequestState) AND ([Username] = @Username))", connection);
        adapter.SelectCommand.Parameters.AddWithValue("@Username", USERNAME);
        adapter.SelectCommand.Parameters.AddWithValue("@RequestState", "Draft");
        adapter.Fill(ds);
        LB.DataSource = ds;
        LB.DataTextField = "Employee";
        LB.DataValueField = "Employee";
        LB.DataBind();
        connection.Close();

        return LB;
    }

    public ListBox fillListBox(ListBox LB, string USERNAME, string STATUS) //This method will fill the list boxes for PendingForm, DeniedForm, and ApprovedForm. string STATUS is either "Pending","Denied", or "Approved"
    {
        SqlConnection connection = new SqlConnection(SQL_STRING);
        connection.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(@"Select CAST([RequestID] AS varchar(200)) + '   ' + [Employee] + '   ' + CAST([CurrentDate] AS varchar(15)) AS PendingDisplay, [RequestID] From Requests WHERE (([RequestState] = @RequestState) AND ([Username] = @Username))", connection);
        adapter.SelectCommand.Parameters.AddWithValue("@Username", USERNAME);
        adapter.SelectCommand.Parameters.AddWithValue("@RequestState", STATUS);
        adapter.Fill(ds);
        LB.DataSource = ds;
        LB.DataTextField = "PendingDisplay";
        LB.DataValueField = "RequestID";
        LB.DataBind();
        connection.Close();

        return LB;
    }
    public ListBox fillListBox(ListBox LB, string USERNAME, string MANAGER, string STATUS) //string STATUS is either "Pending","Denied", or "Approved". This is used for PendingActionForm listbox that requires manager to be passed in.
    {
        SqlConnection connection = new SqlConnection(SQL_STRING);
        connection.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(@"Select CAST([RequestID] AS varchar(200)) + '   ' + [Employee] + '   ' + CAST([CurrentDate] AS varchar(15)) AS PendingDisplay, [RequestID] From Requests JOIN Employees ON [Employee] = ([First Name] + ' ' + [Middle Name] + ' ' + [Last Name]) WHERE ([RequestState] = @RequestState AND [Username] = @CookieUsername) OR ([RequestState] = @RequestState AND [Manager Name] = @CookieManager)", connection);
        adapter.SelectCommand.Parameters.AddWithValue("@CookieUsername", USERNAME);
        adapter.SelectCommand.Parameters.AddWithValue("@RequestState", STATUS);
        adapter.SelectCommand.Parameters.AddWithValue("@CookieManager", MANAGER);
        adapter.Fill(ds);
        LB.DataSource = ds;
        LB.DataTextField = "PendingDisplay";
        LB.DataValueField = "RequestID";
        LB.DataBind();
        connection.Close();

        return LB;
    }
    public ListBox fillListBox(ListBox LB) //HRForm overload. Literally grabbing all employees, so pretty basic method.
    {
        SqlConnection connection = new SqlConnection(SQL_STRING);
        connection.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS empNAME, [UserID] AS uid FROM Employees ORDER BY [Last Name]", connection);
        adapter.Fill(ds);
        LB.DataSource = ds;
        LB.DataTextField = "empNAME";
        LB.DataValueField = "uid";
        LB.DataBind();
        connection.Close();

        return LB;
    }
    public DropDownList fillDDL(DropDownList DDL, string USERID,string isManager)
    {
        if (isManager == "False") //they are not a manager so we just show their name
        {
            SqlConnection connection = new SqlConnection(SQL_STRING);
            connection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [UserID]=@UserID", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@UserID", USERID);
            adapter.Fill(ds);
            DDL.DataSource = ds;
            DDL.DataTextField = "Last_Name";
            DDL.DataValueField = "Last_Name";
            DDL.DataBind();
            connection.Close();
        }
        else //they are a manager
        {
            string temp;
            using (SqlConnection Connection = new SqlConnection(SQL_STRING))
            {
                Connection.Open();
                SqlCommand cmdGetDepartment = new SqlCommand(@"SELECT Department FROM Employees 
                                                    WHERE UserID=@UserID", Connection);
                cmdGetDepartment.Parameters.AddWithValue("@UserID", USERID);
                temp = (string)cmdGetDepartment.ExecuteScalar();
                Connection.Close();
            }
            SqlConnection connection = new SqlConnection(SQL_STRING);
            connection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [Department]=@department", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@department", temp);
            adapter.Fill(ds);
            DDL.DataSource = ds;
            DDL.DataTextField = "Last_Name";
            DDL.DataValueField = "Last_Name";
            DDL.DataBind();
            connection.Close();
        }
        return DDL;
    }

    public void readDraftInfo(HttpCookie cCookie,string Employee) //SavedRequestForm | reading all drafts from an employee
    {
        using (SqlConnection Connection = new SqlConnection(SQL_STRING))
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Drafts WHERE Employee=@Employee", Connection);
            cmd.Parameters.AddWithValue("@Employee", Employee);
            Connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cCookie["Employee"] = reader["Employee"].ToString();
                    cCookie["Reason"] = reader["ReasonForRequest"].ToString();
                    cCookie["GET"] = reader["GETDate"].ToString();
                    cCookie["SSN"] = reader["SSN"].ToString();
                    cCookie["DOB"] = reader["DateOfBirth"].ToString();
                    cCookie["TOB"] = reader["TypeOfBadge"].ToString();
                    cCookie["Proximity"] = reader["ProximityCard"].ToString();
                    cCookie["Emergency"] = reader["EmergencyAccess"].ToString();
                    cCookie["Accounts"] = reader["ContinueAccounts"].ToString();
                    cCookie["Notes"] = reader["Notes"].ToString();
                }
                Connection.Close();
            }


        }
    }


}
