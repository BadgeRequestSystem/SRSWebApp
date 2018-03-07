﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Text.RegularExpressions;

public partial class EditRequestForm : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
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
    }

    protected void SubmmitButton_Click(object sender, EventArgs e)
    {
        try
        {
            string strippedSSN = Regex.Replace(SSNTextBox.Text, "[^0-9]", "");
            HttpCookie aCookie = Request.Cookies["userInfo"];
            string state = "Pending";
            //Creates Connection to database and updates Requests with new request.
            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.database.windows.net;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
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
            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.database.windows.net;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
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