using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;

public partial class PendingForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*So in order for the listbox to get the userName cookie, we have to request the userInfo cookie, create a new cookie that will hold ONLY username!*/
        /*So aCookie is the original cookie, usernameCookie is the new cookie that gets assigned aCookie.Values["userName"], and of course we named the new cookie USERname*/
        /*USERname is the cookie that will be looked for in the .aspx file*/
        HttpCookie aCookie = Request.Cookies["userInfo"];
        HttpCookie usernameCookie = new HttpCookie("USERname");
        usernameCookie.Value = aCookie.Values["userName"];
        Response.Cookies.Add(usernameCookie);


        /*DOUBLE CLICK EVENT FOR LISTBOX*/
        if (Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "move")
        {
            //THIS IS WHERE THE EVENT GOES

            HttpCookie bCookie = new HttpCookie("submittedCookieInfo"); //trying to store info that will be seen on ViewSubmittedForm.aspx into cooked 'submittedCookieInfo'
            //bCookie.Values["Employee"] = usernameCookie.Value;
            //bCookie.Values["SSN"] = null;
            //bCookie.Values["Initials"] = grabSQLData("Initials", ListBox1.SelectedValue.Substring(0, ListBox1.SelectedValue.IndexOf(" ") + 1));
            Response.Cookies.Add(bCookie);

            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.database.windows.net;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Requests WHERE RequestID=@RequestID", Connection);
                cmd.Parameters.AddWithValue("@RequestID", ListBox1.SelectedValue);
                Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bCookie["Employee"] = reader["Employee"].ToString();
                        bCookie["SSN"] = reader["SSN"].ToString();
                        bCookie["DOB"] = reader["DateOfBirth"].ToString();
                    }
                    Connection.Close();
                }


            }

            Response.Redirect("~/ViewSubmittedForm.aspx");
        }
        ListBox1.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(ListBox1, "move"));
        /****************/


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ReviewRequestsForm.aspx");
    }


    /*Trying to have a general sql data grab function, but we need to correct sql tables first, need a way to access Employees table consistently (Username is not UserID so we cant compare right now)*/

    //public string grabSQLData(string s, string reqID)
    //{
    //    HttpCookie aCookie = Request.Cookies["userInfo"];
    //    string toReturn = string.Empty;

    //    using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.database.windows.net;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
    //    {
    //        SqlCommand cmdGetManager = new SqlCommand(@"SELECT " + s + " FROM Employees WHERE Username=@uname and Password=@pass", Connection);
    //        cmdGetManager.Parameters.AddWithValue("@uname", aCookie.Values["userName"]);

    //        toReturn = (string)cmdGetManager.ExecuteScalar();
    //    }

    //    if (toReturn == "True")
    //        toReturn = "Yes";
    //    else if (toReturn == "False")
    //        toReturn = "No";

    //    return toReturn;
    //}
}