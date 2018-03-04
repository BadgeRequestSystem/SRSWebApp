﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;

public partial class EditRequestForm : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmmitButton_Click(object sender, EventArgs e)
    {
        try
        {
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
                cmd.Parameters.AddWithValue("@SSN", SSNTextBox.Text);
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
                cmd.Parameters.AddWithValue("@SSN", SSNTextBox.Text);
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

        }
    }
}