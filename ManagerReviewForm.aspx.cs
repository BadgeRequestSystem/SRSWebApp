using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;

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
            HttpCookie cCookie = Request.Cookies["submittedCookieInfo"];
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
        Response.Redirect("~/PendingActionForm.aspx");
    }
}