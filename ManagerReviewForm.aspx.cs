using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mail;

public partial class ManagerReviewForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SSNTextBox.ReadOnly = true;
        SSNTextBox.BackColor = System.Drawing.Color.LightGray;

        GetTextBox.ReadOnly = true;
        GetTextBox.BackColor = System.Drawing.Color.LightGray;

        DOBTextBox.ReadOnly = true;
        DOBTextBox.BackColor = System.Drawing.Color.LightGray;

        NotesTextBox.ReadOnly = true;
        NotesTextBox.BackColor = System.Drawing.Color.LightGray;

        ProximityCheckBox.Enabled = false;
        EmergencyCheckBox.Enabled = false;
        AccountsCheckBox.Enabled = false;

        EmployeeDDL.Enabled = false;
        ReasonDDL.Enabled = false;
        BadgeTypeDDL.Enabled = false;

        HttpCookie aCookie = Request.Cookies["userInfo"];
        if (Request.Cookies["submittedCookieInfo"] != null)
        {
            Methods m = new Methods(); //Contains useful methods we can use like santizing input
            HttpCookie cCookie = Request.Cookies["submittedCookieInfo"];
            EmployeeDDL.Text = cCookie["Employee"];
            ReasonDDL.Text = cCookie["Reason"];
            GetTextBox.Text = cCookie["GET"].Replace(" 12:00:00 AM", ""); ;
            SSNTextBox.Text = m.lastFourOnly(cCookie["SSN"]); //so now we should only be seeing the last four of the social security number (this shouldn't affect functionality whatsoever)
            DOBTextBox.Text = cCookie["DOB"].Replace(" 12:00:00 AM", ""); ;
            BadgeTypeDDL.Text = cCookie["TOB"];
            if (cCookie["Proximity"] == "True")
                ProximityCheckBox.Checked = true;
            if (cCookie["Emergency"] == "True")
                EmergencyCheckBox.Checked = true;
            if (cCookie["Accounts"] == "True")
                AccountsCheckBox.Checked = true;
            NotesTextBox.Text = cCookie["Notes"];
            requestIDTxtBx.Text = cCookie["RequestID"];

            Response.Cookies["submittedCookieInfo"].Expires = DateTime.Now.AddDays(-1);


        }
    }

    protected void InfoButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"Update Requests
                    SET [Editable]=@canEdit
                    WHERE RequestID=@RequestID;", Connection);
            cmd.Parameters.AddWithValue("@canEdit", true); //user can now edit that request
            cmd.Parameters.AddWithValue("@RequestID", requestIDTxtBx.Text);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        sendNotification(EmployeeDDL.Text, "Need");
        Response.Redirect("~/PendingActionForm.aspx");


    }

    protected void ApproveButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"Update Requests
                    SET [RequestState] = 'Approved'
                    WHERE RequestID=@RequestID;", Connection);
            cmd.Parameters.AddWithValue("@RequestID", requestIDTxtBx.Text);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        sendNotification(EmployeeDDL.Text, "Approved");
        Response.Redirect("~/PendingActionForm.aspx");
    }

    protected void DenyButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"Update Requests
                    SET [RequestState] = 'Denied'
                    WHERE RequestID=@RequestID;", Connection);
            cmd.Parameters.AddWithValue("@RequestID", requestIDTxtBx.Text);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        sendNotification(EmployeeDDL.Text, "Denied");
        Response.Redirect("~/PendingActionForm.aspx");
    }

    public void sendNotification(string Employee, string Response)
    {
        try
        {
            if (Response != "Need")
            {
                //Response should be either "Accepted" or "Denied"
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("dontreplysrsmail@gmail.com");
                mail.To.Add(returnEmail(Employee));
                mail.Subject = String.Format("SRS Badge Request {0}", Response);
                mail.IsBodyHtml = true;
                string body1 = String.Format("Dear {0},\n\tWe wanted to inform you that your SRS Badge Request has been {1}." + "\nWe thank you for your patience. \nSincerely,\nThe SRS Badge Request System\n", Employee, Response);
                mail.Body = body1 + "Please click " + "<a href = 'http://srswebapp-test.us-west-2.elasticbeanstalk.com/Login.aspx' > HERE </a>" + "if you would like to vist the SRS Badge Request Site.";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("dontreplysrsmail@gmail.com", "Password!1");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            else
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("dontreplysrsmail@gmail.com");
                mail.To.Add(returnEmail(Employee));
                mail.Subject = String.Format("SRS Badge Request Needs Review");
                mail.IsBodyHtml = true;
                string body1 = String.Format("Dear {0},\n\tWe wanted to inform you that your SRS Badge Request has been flagged due to an error." + "\nPlease review your pending requests and make any needed corrections.\nSincerely,\nThe SRS Badge Request System\n", Employee);
                mail.Body = body1 + "Please click " + "<a href = 'http://srswebapp-test.us-west-2.elasticbeanstalk.com/Login.aspx' > HERE </a>" + "if you would like to vist the SRS Badge Request Site.";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("dontreplysrsmail@gmail.com", "Password!1");
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
        using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(@"Select Email FROM Credentials WHERE UserID =
                                            (Select UserID FROM Employees WHERE ([First Name] + ' ' + [Middle Name]  + ' ' + [Last Name]) =@employee)", Connection);
            cmd.Parameters.AddWithValue("@employee", Employee);
            email = (string)cmd.ExecuteScalar();
        }


        return email;

    }
}