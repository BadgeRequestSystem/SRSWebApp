using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMenuForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        HttpCookie aCookie = Request.Cookies["userInfo"];
        if (!Label2.Text.Contains(aCookie["userName"]))
            Label2.Text = "Welcome, " + aCookie["userName"];
        if (aCookie["isManager"] == "True")
            ButtonReviewRequests.Visible = true;
        if (aCookie["isHR"] == "True")
            ButtonUpdateEmployees.Visible = true;

    }


    protected void ButtonLogout_Click1(object sender, EventArgs e)
    {
        if (Request.Cookies["userInfo"] != null)
        {
            Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1);
        }
        if (Request.Cookies["USERname"] != null)
        {
            Response.Cookies["USERname"].Expires = DateTime.Now.AddDays(-1);
        }
        Response.Redirect("~/Login.aspx");
    }

    protected void ButtonNewRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EditRequestForm.aspx");
    }

    protected void ButtonViewSavedRequests_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SavedRequestForm.aspx");
    }

    protected void ButtonViewSubmittedRequests_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ReviewRequestsForm.aspx");
    }

    protected void ButtonReviewRequests_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PendingActionForm.aspx");
    }

    protected void ButtonUpdateEmployees_Click(object sender, EventArgs e)
    {

    }
}