﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HRForm : System.Web.UI.Page
{
    public static Methods m = new Methods();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!m.CookieExists("userInfo")) //Fixes 'Chuck E Hacker' bug
        {
            m.SIMPLE_POPUP("Something went wrong!");
            Response.Redirect("~/General/Login.aspx"); //Send unauthorized user back to login page.
        }
        HttpCookie aCookie = Request.Cookies["userInfo"];
        if (aCookie["isHR"] == "False")
        {
            Response.Redirect("~/General/MainMenuForm.aspx"); //Send unauthorized user back to main menu.
        }
        if (!IsPostBack)
            ListBox1 = m.fillListBox(ListBox1);





    }

    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/General/MainMenuForm.aspx");
    }

    protected void newButton_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/HR/EditEmployeeForm.aspx");
    }

    protected void deleteButton_Click(object sender, EventArgs e) //Pop-up dialog, if sucessful confirmation, we activate Button1_Click()
    {


        if (ListBox1.SelectedItem != null)
        {
            HttpCookie bCookie = new HttpCookie("EmployeeToDelete");
            Response.Cookies.Add(bCookie);
            string UID = ListBox1.SelectedValue;
            if (m.liveDemoEnabled == false)
            {
                m.HRForm_Read(bCookie, UID); //Read from database
                                             /*BEGIN POP-UP*/
                ClientScript.RegisterStartupScript(typeof(Page), "exampleScript",
    "if(confirm(\"Are you sure you want to delete " + bCookie["First Name"] + " " + bCookie["Middle Name"] + " " + bCookie["Last Name"] + "? \"))" +
    "{ document.getElementById('Button1').click(); }", true);
                /*END POP-UP*/
                m.DeleteCookie("EmployeeToDelete");
            }
            else if (m.liveDemoEnabled == true)
            {
                if (UID == "A1234" || UID == "c0239" || UID == "e3923")
                {
                    m.SIMPLE_POPUP("Cannot edit standard demo profiles!");
                    m.DeleteCookie("EmployeeToDelete");

                }
            }


        }


    }

    protected void Button1_Click(object sender, EventArgs e) //Does the deleting after the pop-up dialog
    {
        if (ListBox1.SelectedItem != null)
        {
            string UID = ListBox1.SelectedValue;
            m.DeleteFromEmployeesByUID(UID);
            Response.Redirect("~/HR/HRForm.aspx");
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedItem != null)
        {
            if(m.liveDemoEnabled == false)
            {
                HttpCookie bCookie = new HttpCookie("selectedEmployee");
                Response.Cookies.Add(bCookie);
                string UID = ListBox1.SelectedValue;
                m.HRForm_Read(bCookie, UID); //Read from database
                Response.Redirect("~/HR/EditEmployeeForm.aspx");
            }
            else if (m.liveDemoEnabled == true)
            {
                if (ListBox1.SelectedValue == "A1234" || ListBox1.SelectedValue == "c0239" || ListBox1.SelectedValue == "e3923")
                {
                    m.SIMPLE_POPUP("Cannot edit standard demo profiles!");

                }
            }
        }

    }


}
