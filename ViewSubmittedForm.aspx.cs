﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewSubmittedForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie aCookie = Request.Cookies["submittedCookieInfo"];
        employeeLabel0.Text = aCookie.Values["Employee"];
        reasonforrequestLabel0.Text = aCookie.Values["Reason"];
        getdateLabel0.Text = aCookie.Values["GET"].Replace(" 12:00:00 AM", "");
        ssnLabel0.Text = aCookie.Values["SSN"];
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