﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DemoInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UserManual_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("/Site_Data/UserManual.pdf");
        }
        catch
        {

        }
        
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Server.Transfer("~/Site_Data/Database.zip");
        }
        catch
        {

        }
    }
}