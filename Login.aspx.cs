using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Login : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.database.windows.net;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
        {
            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT Count(*) FROM Credentials 
                                        WHERE Username=@uname and 
                                        Password=@pass", Connection);
                cmd.Parameters.AddWithValue("@uname", userBox.Text);
                cmd.Parameters.AddWithValue("@pass", passBox.Text);
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    Response.Cookies["UserName"].Value = userBox.Text;
                    Response.Redirect("~/MainMenuForm.aspx");
                }
                    
                else
                    Response.Redirect("~/Login.aspx");
            }
            catch (Exception ex)
            {
                
            }
        }

    }
}