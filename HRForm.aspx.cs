using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HRForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



    }




    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenuForm.aspx");
    }

    protected void newButton_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/EditEmployeeForm.aspx");
    }

    protected void deleteButton_Click(object sender, EventArgs e) //Pop-up dialog, if sucessful confirmation, we activate Button1_Click()
    {
        if (ListBox1.SelectedItem != null)
        {
            HttpCookie bCookie = new HttpCookie("EmployeeToDelete");
            Response.Cookies.Add(bCookie);

            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Employees WHERE UserID=@UID", Connection);
                cmd.Parameters.AddWithValue("@UID", ListBox1.SelectedValue);
                Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bCookie["Last Name"] = reader["Last Name"].ToString().Trim();
                        bCookie["First Name"] = reader["First Name"].ToString().Trim();
                        bCookie["Middle Name"] = reader["Middle Name"].ToString().Trim();

                    }
                    Connection.Close();
                }
            }
            ClientScript.RegisterStartupScript(typeof(Page), "exampleScript",
            "if(confirm(\"Are you sure you want to delete " + bCookie["First Name"] + " " + bCookie["Middle Name"] + " " + bCookie["Last Name"] + "? \"))" +
            "{ document.getElementById('Button1').click(); }", true);

            Response.Cookies["EmployeeToDelete"].Expires = DateTime.Now.AddDays(-1);
        }


    }

    protected void Button1_Click(object sender, EventArgs e) //Does the deleting after the pop-up dialog
    {
        if (ListBox1.SelectedItem != null)
        {
            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM Employees WHERE [UserID] = @uid", Connection);
                cmd.Parameters.AddWithValue("@uid", ListBox1.SelectedItem.Value);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("~/HRForm.aspx");
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedItem != null)
        {
            HttpCookie bCookie = new HttpCookie("selectedEmployee");
            Response.Cookies.Add(bCookie);

            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Employees WHERE UserID=@UID", Connection);
                cmd.Parameters.AddWithValue("@UID", ListBox1.SelectedValue);
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
            Response.Redirect("~/EditEmployeeForm.aspx");
        }

    }


}
