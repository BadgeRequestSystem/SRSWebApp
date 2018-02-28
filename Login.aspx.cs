using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;

public partial class Login : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        byte isManager = 0;
        byte isHR = 0;
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

                if (result > 0) //LOGIN SUCCESFUL
                {

                    //logged in succesfully, now trying to grab isManager and isHR from database to store as cookie
                    cmd = new SqlCommand(@"SELECT Count(*) FROM Credentials 
                                        WHERE Username=@uname and 
                                        Password=@pass and
                                        isManager=@isManager and
                                        isHR=@isHR", Connection);
                    cmd.Parameters.AddWithValue("@isManager", isManager);
                    cmd.Parameters.AddWithValue("@isHR", isHR);

                    HttpCookie aCookie = new HttpCookie("userName");
                    aCookie.Value = userBox.Text;
                    Response.Cookies.Add(aCookie);
                    HttpCookie bCookie = new HttpCookie("isManager");
                    bCookie.Value = Convert.ToString(isManager);
                    Response.Cookies.Add(bCookie);
                    HttpCookie cCookie = new HttpCookie("isHR");
                    cCookie.Value = Convert.ToString(isHR);
                    Response.Cookies.Add(cCookie);


                    Response.Redirect("~/MainMenuForm.aspx");
                    //userBox.Text = Convert.ToString(isManager); 
                }

                else //LOGIN UNSUCCESFUL
                {
                    Response.Redirect("~/Login.aspx");
                    //userBox.Text = "FAIL";

                }
                    
            }
            catch (Exception ex)
            {

            }
        }

    }
}