using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mail;

public partial class EditRequestForm : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //NotesTextBox.Text = returnEmail("Aaron Something Prather");
        HttpCookie aCookie = Request.Cookies["userInfo"];
        if (Request.Cookies["draftInfo"] != null) //checking if we are loading a draft
        {
            HttpCookie cCookie = Request.Cookies["draftInfo"];
            EmployeeDDL.Text = cCookie["Employee"];
            ReasonDDL.Text = cCookie["Reason"];
            GetTextBox.Text = cCookie["GET"].Replace(" 12:00:00 AM", "");
            SSNTextBox.Text = cCookie["SSN"];
            DOBTextBox.Text = cCookie["DOB"].Replace(" 12:00:00 AM", "");
            BadgeTypeDDL.Text = cCookie["TOB"];
            if (cCookie["Proximity"] == "True")
                ProximityCheckBox.Checked = true;
            if (cCookie["Emergency"] == "True")
                EmergencyCheckBox.Checked = true;
            if (cCookie["Accounts"] == "True")
                AccountsCheckBox.Checked = true;
            NotesTextBox.Text = cCookie["Notes"];

            Response.Cookies["draftInfo"].Expires = DateTime.Now.AddDays(-1);


        }
        else if (Request.Cookies["submittedCookieInfo"] != null && viewSubmittedFlagLabel.Text.Contains("1")) //checking to see if we are loading a pending request (someone editing an existing request)
        {
            viewSubmittedFlagLabel.Text = viewSubmittedFlagLabel.Text.Replace("1",""); //So this solves the problem of the undeleted cookie putting back the original values. When user hits submit, it will skip over this 'if statement' because there wont be a '1' in the viewSubmittedFlagLabel text. Hey it works right lol
            SaveButton.Visible = false; //Disabled 'Save Draft' if we are loading in from a pending request
            HttpCookie fCookie = Request.Cookies["submittedCookieInfo"];
            EmployeeDDL.Text = fCookie["Employee"];
            ReasonDDL.Text = fCookie["Reason"];
            GetTextBox.Text = fCookie["GET"].Replace(" 12:00:00 AM", "");
            SSNTextBox.Text = fCookie["SSN"];
            DOBTextBox.Text = fCookie["DOB"].Replace(" 12:00:00 AM", "");
            BadgeTypeDDL.Text = fCookie["TOB"];
            if (fCookie["Proximity"] == "True")
                ProximityCheckBox.Checked = true;
            if (fCookie["Emergency"] == "True")
                EmergencyCheckBox.Checked = true;
            if (fCookie["Accounts"] == "True")
                AccountsCheckBox.Checked = true;
            NotesTextBox.Text = fCookie["Notes"];

            //we dont want to remove the submittedCookieInfo cookie yet. (we will remove it on 'Cancel' and on 'Submit') *this is so that we can know if we are updating an existing request or not :)
        }

        if (aCookie["isManager"] != "True")
        {
            //SqlDataSource1.SelectCommand = "SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [UserID]='" + aCookie["UserID"] + "'";
            SqlDataSource1.SelectCommand = "SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [UserID]=@UserID";
            SqlDataSource1.SelectParameters.Add("UserID", aCookie["UserID"]);
        }
        else
        {
            string temp;
            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                Connection.Open();
                SqlCommand cmdGetDepartment = new SqlCommand(@"SELECT Department FROM Employees 
                                                    WHERE UserID=@UserID", Connection);
                cmdGetDepartment.Parameters.AddWithValue("@UserID", aCookie["UserID"]);
                temp = (string)cmdGetDepartment.ExecuteScalar();
                Connection.Close();
            }
            //SqlDataSource1.SelectCommand = "SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [Department]='" + temp + "'";
            //SqlDataSource1.SelectCommand = "SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [Manager Name]=@manager";
            //SqlDataSource1.SelectParameters.Add("manager", aCookie["Manager"]);
            SqlDataSource1.SelectCommand = "SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [Department]=@department";
            SqlDataSource1.SelectParameters.Add("department", temp);
        }
    }










    public void sendNotification(string Employee, string Manager)
    {
        //dontreplyplz @workmail.com
        //Password!1

        // the email method with correct config set up, just need a real email address to send it to
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("dontreplysrsmail@gmail.com");
            mail.To.Add(returnEmail(Employee));
            mail.Subject = "SRS Badge Request Received";
            mail.IsBodyHtml = true;
            string body1 = String.Format("Dear {0},\n\tWe wanted to inform you that your SRS Badge Request has been received." + "\nYou will be notified on the status of your request shortly. We thank you for your patience. \nSincerely,\nThe SRS Badge Request System\n", Employee);
            mail.Body = body1 + "<a href = 'http://srswebapp-test.us-west-2.elasticbeanstalk.com/Login.aspx' > Login to view your request! </a>";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("dontreplysrsmail@gmail.com", "Password!1");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            MailMessage mail2 = new MailMessage();
            SmtpClient SmtpServer2 = new SmtpClient("smtp.gmail.com");

            mail2.From = new MailAddress("dontreplysrsmail@gmail.com");
            mail2.To.Add(returnEmail(Manager));
            mail2.Subject = "SRS Badge Request Attention Needed";
            mail2.Body = String.Format("Dear {0},\n\tWe wanted to inform you that {1} has put in a request for a new badge." +
                "\nPlease review the request at your earliest convenience. We thank you for your time. \nSincerely,\nThe SRS Badge Request System", Manager, Employee);

            SmtpServer2.Port = 587;
            SmtpServer2.Credentials = new System.Net.NetworkCredential("dontreplysrsmail@gmail.com", "Password!1");
            SmtpServer2.EnableSsl = true;
            SmtpServer2.Send(mail2);
            //Console.WriteLine("Sucesss");

        }
        catch (Exception ex)
        {
            //Console.WriteLine("Fail");
        }


    }




    public string returnEmail(string Employee)
    {
        HttpCookie aCookie = Request.Cookies["userInfo"];
        string email = string.Empty;
        using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"Select Email FROM Credentials WHERE UserID =
                                            (Select UserID FROM Employees WHERE ([First Name] + ' ' + [Middle Name]  + ' ' + [Last Name]) =@employee)", Connection);
            cmd.Parameters.AddWithValue("@employee", Employee);
            email = (string)cmd.ExecuteScalar();
            //SqlCommand cmd = new SqlCommand(@"SELECT UserID FROM Employees WHERE ([First Name] + ' ' + [Middle Name] + ' ' + [Last Name]) = @manager", Connection);
            //cmd.Parameters.AddWithValue("@manager", aCookie["Manager"]);
            //string ID = (string)cmd.ExecuteScalar();

            //SqlCommand cmd2 = new SqlCommand(@"Select Email FROM Credentials  WHERE UserID =@userID", Connection);
            //cmd2.Parameters.AddWithValue("@userID", ID);
            //email = (string)cmd2.ExecuteScalar();


        }


        return email;

    }

    protected void SubmmitButton_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["submittedCookieInfo"] != null) //existing pending request update
        {
            try
            {
                string strippedSSN = Regex.Replace(SSNTextBox.Text, "[^0-9]", "");
                HttpCookie aCookie = Request.Cookies["userInfo"];
                HttpCookie vCookie = Request.Cookies["submittedCookieInfo"]; //so we can grab the request ID
                string state = "Pending";
                //Creates Connection to database and updates Requests with new request.
                using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
                {
                    Connection.Open();
                    SqlCommand cmd2 = new SqlCommand(@"Update Requests SET [Employee]=@Employee, [ReasonForRequest]=@Reason, [GETDate]=@GET, [SSN]=@SSN, [DateOfBirth]=@DOB, [TypeOfBadge]=@BadgeType, [ProximityCard]=@Proximity, [EmergencyAccess]=@Emergency, [ContinueAccounts]=@Accounts, [Notes]=@Notes, [CurrentDate]=@CurrentDate, [RequestState]=@State, [Username]=@Username, [Editable]=@canEdit WHERE RequestID=@reqID;", Connection);
                    cmd2.Parameters.AddWithValue("@Employee", EmployeeDDL.Text);
                    cmd2.Parameters.AddWithValue("@Reason", ReasonDDL.Text);
                    cmd2.Parameters.AddWithValue("@GET", GetTextBox.Text);
                    
                    cmd2.Parameters.AddWithValue("@SSN", strippedSSN);
                    cmd2.Parameters.AddWithValue("@DOB", DOBTextBox.Text);
                    cmd2.Parameters.AddWithValue("@BadgeType", BadgeTypeDDL.Text);
                    cmd2.Parameters.AddWithValue("@Proximity", ProximityCheckBox.Checked);
                    cmd2.Parameters.AddWithValue("@Emergency", EmergencyCheckBox.Checked);
                    cmd2.Parameters.AddWithValue("@Accounts", AccountsCheckBox.Checked);
                    cmd2.Parameters.AddWithValue("@Notes", NotesTextBox.Text);
                    //cmd2.Parameters.AddWithValue("@Notes", "SQL TEST");
                    cmd2.Parameters.AddWithValue("@Username", aCookie["userName"]);
                    cmd2.Parameters.AddWithValue("@CurrentDate", DateTime.Today);
                    cmd2.Parameters.AddWithValue("@State", state);
                    cmd2.Parameters.AddWithValue("@reqID", vCookie["RequestID"]);
                    cmd2.Parameters.AddWithValue("@canEdit", false); //User can't edit pending request again until manager checks off on it.

                    cmd2.ExecuteNonQuery();
                }

                sendNotification(EmployeeDDL.Text, aCookie["Manager"]); //Should we use a different email response if a user is updating his pending request?
                Response.Cookies["submittedCookieInfo"].Expires = DateTime.Now.AddDays(-1); //we finally remove the cookie
                Response.Redirect("~/MainMenuForm.aspx",false); //had to add false as second parameter because without it, the current page execution would stop and wouldnt update the database.
            }
            catch (Exception ex)
            {
                string msg = "There was an error submitting the request form. Please make sure all fields are filled out correctly and try again.";
                Response.Write("<script>alert('" + msg + "')</script>");
            }
        }

        else //normal request creation
        {
            try
            {
                string strippedSSN = Regex.Replace(SSNTextBox.Text, "[^0-9]", "");
                HttpCookie aCookie = Request.Cookies["userInfo"];
                string state = "Pending";
                //Creates Connection to database and updates Requests with new request.
                using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO Requests
                    VALUES (@Employee, @Reason, @GET, @SSN, @DOB, @BadgeType, @Proximity, @Emergency, @Accounts, @Notes, @CurrentDate, @State, @Username, @canEdit);", Connection);
                    cmd.Parameters.AddWithValue("@Employee", EmployeeDDL.Text);
                    cmd.Parameters.AddWithValue("@Reason", ReasonDDL.Text);
                    cmd.Parameters.AddWithValue("@GET", GetTextBox.Text);
                    //cmd.Parameters.AddWithValue("@SSN", SSNTextBox.Text);
                    cmd.Parameters.AddWithValue("@SSN", strippedSSN);
                    cmd.Parameters.AddWithValue("@DOB", DOBTextBox.Text);
                    cmd.Parameters.AddWithValue("@BadgeType", BadgeTypeDDL.Text);
                    cmd.Parameters.AddWithValue("@Proximity", ProximityCheckBox.Checked);
                    cmd.Parameters.AddWithValue("@Emergency", EmergencyCheckBox.Checked);
                    cmd.Parameters.AddWithValue("@Accounts", AccountsCheckBox.Checked);
                    cmd.Parameters.AddWithValue("@Notes", NotesTextBox.Text);
                    cmd.Parameters.AddWithValue("@Username", aCookie["userName"]);
                    cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Today);
                    cmd.Parameters.AddWithValue("@State", state);
                    cmd.Parameters.AddWithValue("@canEdit", false); //by default, a user cannot edit a pending request until a manager checks off on it.

                    cmd.ExecuteNonQuery();
                }

                sendNotification(EmployeeDDL.Text, aCookie["Manager"]);
                Response.Redirect("~/MainMenuForm.aspx");
            }
            catch (Exception ex)
            {
                string msg = "There was an error submitting the request form. Please make sure all fields are filled out correctly and try again.";
                Response.Write("<script>alert('" + msg + "')</script>");
            }
        }


    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["submittedCookieInfo"] != null)
            Response.Cookies["submittedCookieInfo"].Expires = DateTime.Now.AddDays(-1); //Removes the cookie that stored the loaded in pending request (from ViewSubmittedForm edit button)

        Response.Redirect("~/MainMenuForm.aspx");
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
        try
        {
            string strippedSSN = Regex.Replace(SSNTextBox.Text, "[^0-9]", "");
            HttpCookie aCookie = Request.Cookies["userInfo"];
            string state = "Draft";
            //---------TODO-Change DOB and GET to check for no date given
            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Drafts
                    VALUES (@Employee, @Reason, @GET, @SSN, @DOB, @BadgeType, @Proximity, @Emergency, @Accounts, @Notes, @CurrentDate, @State, @Username);", Connection);
                cmd.Parameters.AddWithValue("@Employee", EmployeeDDL.Text);
                cmd.Parameters.AddWithValue("@Reason", ReasonDDL.Text);
                cmd.Parameters.AddWithValue("@GET", GetTextBox.Text);
                //cmd.Parameters.AddWithValue("@SSN", SSNTextBox.Text);
                cmd.Parameters.AddWithValue("@SSN", strippedSSN);
                cmd.Parameters.AddWithValue("@DOB", DOBTextBox.Text);
                cmd.Parameters.AddWithValue("@BadgeType", BadgeTypeDDL.Text);
                cmd.Parameters.AddWithValue("@Proximity", ProximityCheckBox.Checked);
                cmd.Parameters.AddWithValue("@Emergency", EmergencyCheckBox.Checked);
                cmd.Parameters.AddWithValue("@Accounts", AccountsCheckBox.Checked);
                cmd.Parameters.AddWithValue("@Notes", NotesTextBox.Text);
                cmd.Parameters.AddWithValue("@Username", aCookie["userName"]);
                cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@State", state);

                cmd.ExecuteNonQuery();
            }
            Response.Redirect("~/MainMenuForm.aspx");
        }
        catch (Exception ex)
        {
            string msg = "Something went wrong saving your draft. Our bad. Probably had something to do with the SSN field, too many numbers or something.";
            Response.Write("<script>alert('" + msg + "')</script>");
        }
    }
}