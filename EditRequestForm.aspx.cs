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
        if (Request.Cookies["draftInfo"] != null)
        {
            HttpCookie cCookie = Request.Cookies["draftInfo"];
            EmployeeDDL.Text = cCookie["Employee"];
            ReasonDDL.Text = cCookie["Reason"];
            GetTextBox.Text = cCookie["GET"].Replace(" 12:00:00 AM", ""); ;
            SSNTextBox.Text = cCookie["SSN"];
            DOBTextBox.Text = cCookie["DOB"].Replace(" 12:00:00 AM", ""); ;
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
        else if (aCookie["isManager"] != "True" )
        {
            SqlDataSource1.SelectCommand = "SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [UserID]='" + aCookie["UserID"] + "'";
            //SqlDataSource1.SelectCommand = "SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [UserID]=@UserID";
            //SqlDataSource1.SelectParameters.Add("@UserID", aCookie["UserID"]);
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
            SqlDataSource1.SelectCommand = "SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees] WHERE [Department]='" + temp + "'";
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
            SmtpClient SmtpServer = new SmtpClient("smtp.mail.com");

            mail.From = new MailAddress("dontreplyplz@workmail.com");
            mail.To.Add(returnEmail(Employee));
            mail.Subject = "SRS Badge Request Received";
            mail.Body = String.Format("Dear {0},\n\tWe wanted to inform you that your SRS Badge Request has been received." +
                "\nYou will be notified on the status of your request shortly. We thank you for your patience. \nSincerely,\nThe SRS Badge Request System", Employee);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("dontreplyplz@workmail.com", "Password!1");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            MailMessage mail2 = new MailMessage();
            SmtpClient SmtpServer2 = new SmtpClient("smtp.mail.com");

            mail2.From = new MailAddress("dontreplyplz@workmail.com");
            mail2.To.Add(returnEmail(Manager));
            mail2.Subject = "SRS Badge Request Attention Needed";
            mail2.Body = String.Format("Dear {0},\n\tWe wanted to inform you that {1} has put in a request for a new badge." +
                "\nPlease review the request at your earliest convenience. We thank you for your time. \nSincerely,\nThe SRS Badge Request System", Manager, Employee);

            SmtpServer2.Port = 587;
            SmtpServer2.Credentials = new System.Net.NetworkCredential("dontreplyplz@workmail.com", "Password!1");
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

            sendNotification(EmployeeDDL.Text, aCookie["Manager"]);
            Response.Redirect("~/MainMenuForm.aspx");
        }
        catch (Exception ex)
        {
            string msg = "There was an error submitting the request form. Please make sure all fields are filled out correctly and try again.";
            Response.Write("<script>alert('" + msg + "')</script>");
        }
        
    }

    protected void CancelButton_Click(object sender, EventArgs e)
    {
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