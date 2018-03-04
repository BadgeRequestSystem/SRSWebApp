using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewSubmittedForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie aCookie = Request.Cookies["submittedCookieInfo"];
        employeeLabel.Text = employeeLabel.Text + aCookie.Values["Employee"];
    }

    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ReviewRequestsForm.aspx");
        
    }
}