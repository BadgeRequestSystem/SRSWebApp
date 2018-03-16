using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditEmployeeForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CancelButton_Click(object sender, EventArgs e) //back button
    {
        Response.Redirect("~/HRForm.aspx");
    }

    protected void SaveButton_Click(object sender, EventArgs e) //dont use
    {
        //dont use me plz
    }

    protected void SubmmitButton_Click(object sender, EventArgs e) //save button
    {
        Response.Redirect("~/HRForm.aspx");
    }
}