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
        using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.database.windows.net;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
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

    
}