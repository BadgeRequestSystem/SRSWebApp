using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewSubmittedForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Methods m = new Methods(); //Contains useful methods we can use like santizing input
        HttpCookie aCookie = Request.Cookies["submittedCookieInfo"];
        employeeLabel0.Text = aCookie.Values["Employee"];
        reasonforrequestLabel0.Text = aCookie.Values["Reason"];
        getdateLabel0.Text = aCookie.Values["GET"].Replace(" 12:00:00 AM", "");
        ssnLabel0.Text = m.lastFourOnly(aCookie.Values["SSN"]); //so now we should only be seeing the last four of the social security number (this shouldn't affect functionality whatsoever)
        dateofbirthLabel0.Text = aCookie.Values["DOB"].Replace(" 12:00:00 AM", "");
        typeofbadgeLabel0.Text = aCookie.Values["TOB"];
        proximitycardLabel0.Text = aCookie.Values["Proximity"];
        emergencyaccessLabel0.Text = aCookie.Values["Emergency"];
        continuecomputeraccountsLabel0.Text = aCookie.Values["Accounts"];
        TextBox1.Text = aCookie.Values["Notes"];

        initialsLabel0.Text = aCookie["Initials"];
        useridLabel0.Text = aCookie["UserID"];
        ecompanyLabel0.Text = aCookie["Company"];
        departmentLabel0.Text = aCookie["Department"];
        worklocationLabel0.Text = aCookie["Location"];
        workphoneLabel0.Text = aCookie["Phone"];
        emanagerLabel0.Text = aCookie["Manager"];
        mworklocationLabel0.Text = aCookie["ManagerLocation"];
        mworkphoneLabel0.Text = aCookie["ManagerPhone"];

        if (aCookie["Editable"] != null) //We only get this cookie from PendingForm, so this is a check to make sure the request is pending.
        {
            if (aCookie["Editable"] == "False") //We got here from PendingForm and the request is uneditable so we hide editbutton
                editButton.Visible = false;

        }
        else
            editButton.Visible = false; //We got here from Approved or Denied form, so we hide the editbutton (only requests that are pending can be edited)

    }

    protected void backButton_Click(object sender, EventArgs e)
    {
        Methods m = new Methods();
        m.DeleteCookie("submittedCookieInfo");
        Response.Redirect("~/ReviewRequestsForm.aspx");

    }

    protected void editButton_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/EditRequestForm.aspx"); //We are taking the 'submittedCookieInfo' cookie and bringing it to EditRequestForm so we can use it there.



    }
}