using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReviewRequestsForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie aCookie = Request.Cookies["userInfo"];
    }

    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenuForm.aspx");
    }

    protected void pendingButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PendingForm.aspx");
    }

    protected void approvedButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ApprovedForm.aspx");
    }

    protected void deniedButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/DeniedForm.aspx");
    }
}