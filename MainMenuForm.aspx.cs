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
        if (Request.Cookies["userName"] != null && !Label2.Text.Contains(Server.HtmlEncode(Request.Cookies["userName"].Value)))
            Label2.Text = Label2.Text + Server.HtmlEncode(Request.Cookies["userName"].Value);

        if (Request.Cookies["isManager"].Value == "1")
        {
            ButtonReviewRequests.Visible = true;
        }
        if (Request.Cookies["isHR"].Value == "1")
        {
            ButtonUpdateEmployees.Visible = true;
        }


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