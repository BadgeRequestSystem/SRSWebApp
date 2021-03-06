﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;

public partial class SavedRequestForm : System.Web.UI.Page
{
    public static Methods m = new Methods();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!m.CookieExists("userInfo")) //Fixes 'Chuck E Hacker' bug
        {
            m.SIMPLE_POPUP("Something went wrong!");
            Response.Redirect("~/General/Login.aspx"); //Send unauthorized user back to login page.
        }

        /*DOUBLE CLICK EVENT FOR LISTBOX*/
        if (Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "move")
        {
            HttpCookie cCookie = new HttpCookie("draftInfo"); //trying to store info that will be seen on ViewSubmittedForm.aspx into cooked 'submittedCookieInfo'
            Response.Cookies.Add(cCookie);
            m.readDraftInfo(cCookie, ListBox1.SelectedValue);


            Response.Redirect("~/General/EditRequestForm.aspx");
        }
        ListBox1.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(ListBox1, "move"));
        /****************/

        HttpCookie aCookie = Request.Cookies["userInfo"];
        ListBox1 = m.fillListBoxDRAFT(ListBox1, aCookie.Values["userName"]);





    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/MainMenuForm.aspx");
    }
}