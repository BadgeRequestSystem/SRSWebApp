using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;

public partial class PendingActionForm : System.Web.UI.Page
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

        HttpCookie managerCookie = new HttpCookie("Manager");
        managerCookie.Value = aCookie.Values["Manager"];
        Response.Cookies.Add(managerCookie);

        /*DOUBLE CLICK EVENT FOR LISTBOX*/
        if (Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "move")
        {
            HttpCookie bCookie = new HttpCookie("submittedCookieInfo");
            Response.Cookies.Add(bCookie);

            using (SqlConnection Connection = new SqlConnection("Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;User ID=pwndatnerd;Password=AaronDavidRandall!3"))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Requests WHERE RequestID=@RequestID", Connection);
                cmd.Parameters.AddWithValue("@RequestID", ListBox1.SelectedValue);
                
                Connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bCookie["Employee"] = reader["Employee"].ToString();
                        bCookie["Reason"] = reader["ReasonForRequest"].ToString();
                        bCookie["GET"] = reader["GETDate"].ToString();
                        bCookie["SSN"] = reader["SSN"].ToString();
                        bCookie["DOB"] = reader["DateOfBirth"].ToString();
                        bCookie["TOB"] = reader["TypeOfBadge"].ToString();
                        bCookie["Proximity"] = reader["ProximityCard"].ToString();
                        bCookie["Emergency"] = reader["EmergencyAccess"].ToString();
                        bCookie["Accounts"] = reader["ContinueAccounts"].ToString();
                        bCookie["Notes"] = reader["Notes"].ToString();
                    }
                    Connection.Close();
                }

                int firstIndex = bCookie["Employee"].IndexOf(' ');
                string fName = bCookie["Employee"].Substring(0, firstIndex);
                int secondIndex = bCookie["Employee"].LastIndexOf(' ');
                string lName = bCookie["Employee"].Substring(secondIndex + 1);
                //string mName = bCookie["Employee"].Substring(firstIndex + 2, bCookie["Employee"].Length - lName.Length - 1);


                //SqlCommand cmd2 = new SqlCommand(@"SELECT * FROM Employees WHERE [First Name]=@fName AND [Last Name]=@lName AND [Middle Name]=@mName", Connection);
                //cmd2.Parameters.AddWithValue("@fName", fName);
                //cmd2.Parameters.AddWithValue("@lName", lName);
                //cmd2.Parameters.AddWithValue("@mName", mName);
                SqlCommand cmd2 = new SqlCommand(@"SELECT * FROM Employees WHERE [First Name]=@fName AND [Last Name]=@lName", Connection);
                cmd2.Parameters.AddWithValue("@fName", fName);
                cmd2.Parameters.AddWithValue("@lName", lName);



                Connection.Open();
                using (SqlDataReader reader2 = cmd2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        bCookie["Initials"] = reader2["Initials"].ToString();
                        bCookie["UserID"] = reader2["UserID"].ToString();
                        bCookie["Company"] = reader2["Employee Company"].ToString();
                        bCookie["Department"] = reader2["Department"].ToString();
                        bCookie["Location"] = reader2["Work Location"].ToString();
                        bCookie["Phone"] = reader2["Work Phone Number"].ToString();
                        bCookie["Manager"] = reader2["Manager Name"].ToString();
                        bCookie["ManagerLocation"] = reader2["Manager Work Location"].ToString();
                        bCookie["ManagerPhone"] = reader2["Manager Work Phone Number"].ToString();
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
        Response.Redirect("~/MainMenuForm.aspx");
    }



}