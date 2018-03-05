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
        employeeLabel.Text = "Employee: " + aCookie.Values["Employee"];
        ssnLabel.Text = "SSN: " + aCookie.Values["SSN"];
        dateofbirthLabel.Text = "Date of Birth: " + aCookie.Values["DOB"].Replace(" 12:00:00 AM", "");
        
    }

    protected void backButton_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["submittedCookieInfo"] != null)
        {
            Response.Cookies["submittedCookieInfo"].Expires = DateTime.Now.AddDays(-1);
        }
        Response.Redirect("~/ReviewRequestsForm.aspx");
        
    }
}