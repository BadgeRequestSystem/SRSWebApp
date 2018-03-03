using System;
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
        //---------TODO--------------Create Query for inserting requests into table--------
        //using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.database.windows.net;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
        //{
        //    Connection.Open();
        //    SqlCommand cmd = new SqlCommand(@"INSERT INTO Requests
        //            VALUES ();", Connection);
        //    cmd.Parameters.AddWithValue("@Employee", EmployeeDDL);
        //    cmd.Parameters.AddWithValue("@Reason", ReasonDDL);
        //    cmd.Parameters.AddWithValue("@GET", GetTextBox);
        //    cmd.Parameters.AddWithValue("@SSN", SSNTextBox);
        //    cmd.Parameters.AddWithValue("@DOB", DOBTextBox);
        //    cmd.Parameters.AddWithValue("@BadgeType", BadgeTypeDDL);
        //    cmd.Parameters.AddWithValue("@Proximity", ProximityCheckBox);
        //    cmd.Parameters.AddWithValue("@Emergency", EmergencyCheckBox);
        //    cmd.Parameters.AddWithValue("@Accounts", AccountsCheckBox);
        //    cmd.Parameters.AddWithValue("@Notes", NotesTextBox);
        //}

    }
}