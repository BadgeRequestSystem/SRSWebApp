using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMenuForm : System.Web.UI.Page
{
    public static Methods m = new Methods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!m.CookieExists("userInfo")) //Fixes 'Chuck E Hacker' bug
            Response.Redirect("~/General/Login.aspx"); //Send unauthorized user back to login page.

        HttpCookie aCookie = Request.Cookies["userInfo"];
        if (!Label2.Text.Contains(aCookie["userName"]))
            Label2.Text = Label2.Text + aCookie["userName"];
        if (aCookie["isManager"] == "True")
            ButtonReviewRequests.Visible = true;
        if (aCookie["isHR"] == "True")
            ButtonUpdateEmployees.Visible = true;


    }


    protected void ButtonLogout_Click1(object sender, EventArgs e)
    {
        m.DeleteCookie("userInfo");
        m.DeleteCookie("USERname");
        Response.Redirect("~/General/Login.aspx");
    }

    protected void ButtonNewRequest_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/EditRequestForm.aspx");
    }

    protected void ButtonViewSavedRequests_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/SavedRequestForm.aspx");
    }

    protected void ButtonViewSubmittedRequests_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/ReviewRequestsForm.aspx");
    }

    protected void ButtonReviewRequests_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/PendingActionForm.aspx");
    }

    protected void ButtonUpdateEmployees_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/HR/HRForm.aspx");
    }
}