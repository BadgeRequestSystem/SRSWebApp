﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;

public partial class PendingActionForm : System.Web.UI.Page
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
            HttpCookie bCookie = new HttpCookie("submittedCookieInfo");
            Response.Cookies.Add(bCookie);
            m.basicRead(bCookie, ListBox1.SelectedValue, true); //true because we only need some basic info (refer to Methods.cs for more context)
            Response.Redirect("~/Manager/ManagerReviewForm.aspx");
        }
        ListBox1.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(ListBox1, "move"));
        /****************/

        HttpCookie aCookie = Request.Cookies["userInfo"];
        ListBox1 = m.fillListBox(ListBox1, aCookie.Values["userName"], aCookie.Values["Manager"], "Pending"); //Populate the listbox *This must come after the double click event*
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/MainMenuForm.aspx");
    }



}