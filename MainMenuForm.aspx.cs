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

        //Individual Cookies---No longer needed---
        //if (Request.Cookies["userName"] != null && !Label2.Text.Contains(Server.HtmlEncode(Request.Cookies["userName"].Value)))
        //    Label2.Text = Label2.Text + Server.HtmlEncode(Request.Cookies["userName"].Value);

        //if (Request.Cookies["isManager"].Value == "True")
        //{
        //    ButtonReviewRequests.Visible = true;
        //}
        //if (Request.Cookies["isHR"].Value == "True")
        //{
        //    ButtonUpdateEmployees.Visible = true;
        //}

        //if (Request.Cookies["userInfo"]["userName"] != null && !Label2.Text.Contains(Server.HtmlEncode(Request.Cookies["userInfo"]["userName"].Value)))
        //    Label2.Text = Label2.Text + Server.HtmlEncode(Request.Cookies["userInfo"]["userName"].Value);
        //Individual Cookies---No longer needed---
    }


    protected void ButtonLogout_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }

    protected void ButtonNewRequest_Click(object sender, EventArgs e)
    {

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

    }

    protected void ButtonUpdateEmployees_Click(object sender, EventArgs e)
    {

    }
}