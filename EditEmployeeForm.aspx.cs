using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditEmployeeForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeDDL.Items.Add("No Manager");
        if (Request.Cookies["selectedEmployee"] != null)
        {
            HttpCookie cCookie = Request.Cookies["selectedEmployee"];
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
            if (cCookie["Manager Name"] == "")
            {
                EmployeeDDL.Text = "No Manager";
            }
            else
            {
                EmployeeDDL.Text = cCookie["Manager Name"];
            }
            Response.Cookies["selectedEmployee"].Expires = DateTime.Now.AddDays(-1);

        }

    }

    protected void CancelButton_Click(object sender, EventArgs e) //back button
    {
        Response.Redirect("~/HRForm.aspx");

    }

    protected void SaveButton_Click(object sender, EventArgs e) //dont use
    {
        //dont use me plz
    }

    protected void SubmmitButton_Click(object sender, EventArgs e) //save button
    {
        Methods m = new Methods(); //Contains useful methods we can use like santizing input

        if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "" && TextBox7.Text != "" && TextBox8.Text != "" && TextBox9.Text != "" && EmployeeDDL.SelectedItem != null && TextBox5.ReadOnly == false)
        {
            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Employees
                    VALUES (@LName, @FName, @MName, @Initials, @UserID, @ECompany, @Department, @WLocation, @WPhone, @EManager, @MWLocation, @MWPhone);", Connection);
                cmd.Parameters.AddWithValue("@LName", m.sanitizeInput(TextBox3.Text));
                cmd.Parameters.AddWithValue("@FName", m.sanitizeInput(TextBox1.Text));
                cmd.Parameters.AddWithValue("@MName", m.sanitizeInput(TextBox2.Text));
                cmd.Parameters.AddWithValue("@Initials", m.sanitizeInput(TextBox4.Text));
                cmd.Parameters.AddWithValue("@UserID", TextBox5.Text); //one would think 5 characters would be enough to deter sql injection attempts :)
                cmd.Parameters.AddWithValue("@ECompany", m.sanitizeInput(TextBox6.Text));
                cmd.Parameters.AddWithValue("@Department", m.sanitizeInput(TextBox7.Text));
                cmd.Parameters.AddWithValue("@WLocation", m.sanitizeInput(TextBox8.Text));
                cmd.Parameters.AddWithValue("@WPhone", m.sanitizeInput(TextBox9.Text));
                cmd.Parameters.AddWithValue("@MWLocation", m.sanitizeInput(TextBox10.Text));
                cmd.Parameters.AddWithValue("@MWPhone", m.sanitizeInput(TextBox11.Text));
                if (EmployeeDDL.SelectedItem.Text == "No Manager") //if the 'No Manager' option is selected then Manager Name in database is empty
                {
                    cmd.Parameters.AddWithValue("@EManager", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EManager", EmployeeDDL.SelectedItem.Text);
                }
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
                cmd.Parameters.AddWithValue("@LName", m.sanitizeInput(TextBox3.Text));
                cmd.Parameters.AddWithValue("@FName", m.sanitizeInput(TextBox1.Text));
                cmd.Parameters.AddWithValue("@MName", m.sanitizeInput(TextBox2.Text));
                cmd.Parameters.AddWithValue("@Initials", m.sanitizeInput(TextBox4.Text));
                cmd.Parameters.AddWithValue("@UserID", TextBox5.Text); //one would think 5 characters would be enough to deter sql injection attempts :)
                cmd.Parameters.AddWithValue("@ECompany", m.sanitizeInput(TextBox6.Text));
                cmd.Parameters.AddWithValue("@Department", m.sanitizeInput(TextBox7.Text));
                cmd.Parameters.AddWithValue("@WLocation", m.sanitizeInput(TextBox8.Text));
                cmd.Parameters.AddWithValue("@WPhone", m.sanitizeInput(TextBox9.Text));
                cmd.Parameters.AddWithValue("@MWLocation", m.sanitizeInput(TextBox10.Text));
                cmd.Parameters.AddWithValue("@MWPhone", m.sanitizeInput(TextBox11.Text));
                if (EmployeeDDL.SelectedItem.Text == "No Manager") //if the 'No Manager' option is selected then Manager Name in database is empty
                {
                    cmd.Parameters.AddWithValue("@EManager", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EManager", EmployeeDDL.SelectedItem.Text);
                }
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("~/HRForm.aspx");
        }
    }



    protected void EmployeeDDL_Load(object sender, EventArgs e)
    {
    }

    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {

    }
}