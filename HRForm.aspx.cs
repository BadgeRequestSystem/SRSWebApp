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
        ClientScript.RegisterStartupScript(typeof(Page), "exampleScript", 
            "if(confirm(\"Are you sure?\"))" +
            "{ document.getElementById('Button1').click(); }", true); 
    }

    protected void Button1_Click(object sender, EventArgs e) //Does the deleting after the pop-up dialog
    {
        if (ListBox1.SelectedItem != null)
        {
            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.database.windows.net;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM Employees WHERE [UserID] = @uid", Connection);
                cmd.Parameters.AddWithValue("@uid", ListBox1.SelectedItem.Value);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("~/HRForm.aspx");
        }
    }
}