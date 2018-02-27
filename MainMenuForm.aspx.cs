using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMenuForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = Response.Cookies["UserName"].Value;
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

    }

    protected void ButtonViewSubmittedRequests_Click(object sender, EventArgs e)
    {

    }

    protected void ButtonReviewRequests_Click(object sender, EventArgs e)
    {

    }

    protected void ButtonUpdateEmployees_Click(object sender, EventArgs e)
    {

    }
}