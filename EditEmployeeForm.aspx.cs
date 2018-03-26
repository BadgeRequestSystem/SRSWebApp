﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditEmployeeForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["selectedEmployee"] != null)
        {
            HttpCookie cCookie = Request.Cookies["selectedEmployee"];
            EmployeeDDL.SelectedIndex = EmployeeDDL.Items.IndexOf(EmployeeDDL.Items.FindByValue(cCookie["Manager Name"]));
            TextBox1.Text = cCookie["First Name"];
            TextBox2.Text = cCookie["Middle Name"];
            TextBox3.Text = cCookie["Last Name"];
            TextBox4.Text = cCookie["Initials"];
            TextBox5.Text = cCookie["UserID"];
            TextBox5.ReadOnly = true;
            TextBox6.Text = cCookie["Employee Company"];
            TextBox7.Text = cCookie["Department"];
            TextBox8.Text = cCookie["Work Location"];
            TextBox9.Text = cCookie["Work Phone Number"];
            TextBox10.Text = cCookie["Manager Work Location"];
            TextBox11.Text = cCookie["Manager Work Phone Number"];
        }
    }

    protected void CancelButton_Click(object sender, EventArgs e) //back button
    {
        if (Request.Cookies["selectedEmployee"] != null)
            Response.Cookies["selectedEmployee"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("~/HRForm.aspx");
    }

    protected void SaveButton_Click(object sender, EventArgs e) //dont use
    {
        //dont use me plz
    }

    protected void SubmmitButton_Click(object sender, EventArgs e) //save button
    {
        if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "" && TextBox8.Text != "" && TextBox9.Text != "" && EmployeeDDL.SelectedItem != null && TextBox5.ReadOnly == false)
        {
            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Employees
                    VALUES (@LName, @FName, @MName, @Initials, @UserID, @ECompany, @Department, @WLocation, @WPhone, @EManager, @MWLocation, @MWPhone);", Connection);
                cmd.Parameters.AddWithValue("@LName", TextBox3.Text);
                cmd.Parameters.AddWithValue("@FName", TextBox1.Text);
                cmd.Parameters.AddWithValue("@MName", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Initials", TextBox4.Text);
                cmd.Parameters.AddWithValue("@UserID", TextBox5.Text);
                cmd.Parameters.AddWithValue("@ECompany", TextBox6.Text);
                cmd.Parameters.AddWithValue("@Department", TextBox7.Text);
                cmd.Parameters.AddWithValue("@WLocation", TextBox8.Text);
                cmd.Parameters.AddWithValue("@WPhone", TextBox9.Text);
                cmd.Parameters.AddWithValue("@EManager", EmployeeDDL.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@MWLocation", TextBox10.Text);
                cmd.Parameters.AddWithValue("@MWPhone", TextBox11.Text);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("~/HRForm.aspx");
        }
        if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox6.Text != "" && TextBox7.Text != "" && TextBox8.Text != "" && TextBox9.Text != "" && EmployeeDDL.SelectedItem != null && TextBox5.ReadOnly == true)
        {
            //This is our Update button case
            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(@"Update Employees
                    SET [First Name]=@FName, [Last Name]=@LName, [Middle Name]=@MName, [Initials]=@Initials, [Employee Company]=@ECompany, [Department]=@Department, [Work Location]=@WLocation, [Work Phone Number]=@WPhone, [Manager Name]=@EManager, [Manager Work Location]=@MWLocation, [Manager Work Phone Number]=@MWPhone
                    WHERE UserID=@UserID;", Connection);
                cmd.Parameters.AddWithValue("@LName", TextBox3.Text);
                cmd.Parameters.AddWithValue("@FName", TextBox1.Text);
                cmd.Parameters.AddWithValue("@MName", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Initials", TextBox4.Text);
                cmd.Parameters.AddWithValue("@UserID", TextBox5.Text);
                cmd.Parameters.AddWithValue("@ECompany", TextBox6.Text);
                cmd.Parameters.AddWithValue("@Department", TextBox7.Text);
                cmd.Parameters.AddWithValue("@WLocation", TextBox8.Text);
                cmd.Parameters.AddWithValue("@WPhone", TextBox9.Text);
                cmd.Parameters.AddWithValue("@EManager", EmployeeDDL.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@MWLocation", TextBox10.Text);
                cmd.Parameters.AddWithValue("@MWPhone", TextBox11.Text);
                cmd.ExecuteNonQuery();
            }
            Response.Cookies["selectedEmployee"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/HRForm.aspx");
        }
    }


}