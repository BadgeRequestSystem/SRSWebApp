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
        bool isManager = false;
        bool isHR = false;
        string tempID;
        string tempMan;
        string tempEmail;
        using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
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

                    //logged in succesfully, storing isManager and isHR to fields and then to cookie
                    SqlCommand cmdGetManager = new SqlCommand(@"SELECT isManager FROM Credentials 
                                                    WHERE Username=@uname and Password=@pass", Connection);
                    cmdGetManager.Parameters.AddWithValue("@uname", userBox.Text);
                    cmdGetManager.Parameters.AddWithValue("@pass", passBox.Text);
                    bool temp = (bool)cmdGetManager.ExecuteScalar();
                    isManager = temp;

                    SqlCommand cmdGetHR = new SqlCommand(@"SELECT isHR FROM Credentials 
                                                    WHERE Username=@uname and Password=@pass", Connection);
                    cmdGetHR.Parameters.AddWithValue("@uname", userBox.Text);
                    cmdGetHR.Parameters.AddWithValue("@pass", passBox.Text);
                    temp = (bool)cmdGetHR.ExecuteScalar();
                    isHR = temp;

                    SqlCommand cmdGetUserID = new SqlCommand(@"SELECT UserID FROM Credentials 
                                                    WHERE Username=@uname and Password=@pass", Connection);
                    cmdGetUserID.Parameters.AddWithValue("@uname", userBox.Text);
                    cmdGetUserID.Parameters.AddWithValue("@pass", passBox.Text);
                    tempID = (string)cmdGetUserID.ExecuteScalar();

                    SqlCommand cmdGetManagerName = new SqlCommand(@"SELECT [Manager Name] FROM Employees
                                                    WHERE UserID=@tempID", Connection);
                    cmdGetManagerName.Parameters.AddWithValue("@tempID", tempID);
                    tempMan = (string)cmdGetManagerName.ExecuteScalar();

                    SqlCommand cmdGetEmail = new SqlCommand(@"SELECT Email FROM Credentials
                                                    WHERE Username=@uname and Password=@pass", Connection);
                    cmdGetManagerName.Parameters.AddWithValue("@tempID", tempID);
                    tempEmail = (string)cmdGetManagerName.ExecuteScalar();

                    HttpCookie aCookie = new HttpCookie("userInfo");
                    aCookie.Values["userName"] = userBox.Text;
                    aCookie.Values["isManager"] = isManager.ToString();
                    aCookie.Values["isHR"] = isHR.ToString();
                    aCookie.Values["UserID"] = tempID;
                    aCookie.Values["Manager"] = tempMan;
                    aCookie.Values["Email"] = tempEmail;
                    Response.Cookies.Add(aCookie);

                    Connection.Close();
                    Response.Redirect("~/MainMenuForm.aspx");

                }

                else //LOGIN UNSUCCESFUL
                {
                    Connection.Close();
                    Response.Redirect("~/Login.aspx");

                }
                    
            }
            catch (Exception ex)
            {

            }
        }

    }
}