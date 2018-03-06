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
        reasonforrequestLabel.Text = "Reason for Request: " + aCookie.Values["Reason"];
        getdateLabel.Text = "G.E.T. Date: " + aCookie.Values["GET"].Replace(" 12:00:00 AM", "");
        ssnLabel.Text = "SSN: " + aCookie.Values["SSN"];
        dateofbirthLabel.Text = "Date of Birth: " + aCookie.Values["DOB"].Replace(" 12:00:00 AM", "");
        typeofbadgeLabel.Text = "Type of Badge Required: " + aCookie.Values["TOB"];
        proximitycardLabel.Text = "Proximity Card Required: " + aCookie.Values["Proximity"];
        emergencyaccessLabel.Text = "Emergency Access Required: " + aCookie.Values["Emergency"];
        continuecomputeraccountsLabel.Text = "Continue Computer Accounts: " + aCookie.Values["Accounts"];
        TextBox1.Text = aCookie.Values["Notes"];

        initialsLabel.Text = "Initials: " + aCookie["Initials"];
        useridLabel.Text = "UserID: " + aCookie["UserID"];
        ecompanyLabel.Text = "Employee Company: " + aCookie["Company"];
        departmentLabel.Text = "Department: " + aCookie["Department"];
        worklocationLabel.Text = "Work Location: " + aCookie["Location"];
        workphoneLabel.Text = "Work Phone: " + aCookie["Phone"];
        emanagerLabel.Text = "Employee Manager: " + aCookie["Manager"];
        mworklocationLabel.Text = "Manager Work Location: " + aCookie["ManagerLocation"];
        mworkphoneLabel.Text = "Manager Work Phone: " + aCookie["ManagerPhone"];
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