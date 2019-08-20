using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReviewRequestsForm : System.Web.UI.Page
{
    public static Methods m = new Methods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!m.CookieExists("userInfo")) //Fixes 'Chuck E Hacker' bug
        {
            m.SIMPLE_POPUP("Something went wrong!");
            Response.Redirect("~/General/Login.aspx"); //Send unauthorized user back to login page.
        }
    }

    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/MainMenuForm.aspx");
    }

    protected void pendingButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/PendingForm.aspx");
    }

    protected void approvedButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/ApprovedForm.aspx");
    }

    protected void deniedButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/DeniedForm.aspx");
    }
}