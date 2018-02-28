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

                    //logged in succesfully, storing isManager and isHR to fields and then to cookie
                    //I hope this gets changed as I think it will so I can update the project file on GIT...
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

                    //Individual cookies---No longer needed---
                    //HttpCookie aCookie = new HttpCookie("userName");
                    //aCookie.Value = userBox.Text;
                    //Response.Cookies.Add(aCookie);
                    //HttpCookie bCookie = new HttpCookie("isManager");
                    //bCookie.Value = Convert.ToString(isManager);
                    //Response.Cookies.Add(bCookie);
                    //HttpCookie cCookie = new HttpCookie("isHR");
                    //cCookie.Value = Convert.ToString(isHR);
                    //Response.Cookies.Add(cCookie);
                    //Individual cookies---No longer needed---

                    HttpCookie aCookie = new HttpCookie("userInfo");
                    aCookie.Values["userName"] = userBox.Text;
                    aCookie.Values["isManager"] = isManager.ToString();
                    aCookie.Values["isHR"] = isHR.ToString();
                    Response.Cookies.Add(aCookie);


                    Response.Redirect("~/MainMenuForm.aspx");

                    //For testing---No Longer Needed---
                    //userBox.Text = isManager.ToString(); 
                    //userBox.Text = isHR.ToString();
                    //For testing---No Longer Needed---
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