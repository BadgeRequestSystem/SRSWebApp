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
        else if (aCookie["isManager"] != "True")
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

    protected void InfoButton_Click(object sender, EventArgs e)
    {
        


    }

    protected void ApproveButton_Click(object sender, EventArgs e)
    {
        
    }

    protected void DenyButton_Click(object sender, EventArgs e)
    {
       
    }
}