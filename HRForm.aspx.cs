using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HRForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenuForm.aspx");
    }

    protected void newButton_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/EditEmployeeForm.aspx");
    }

    protected void deleteButton_Click(object sender, EventArgs e) //Pop-up dialog, if sucessful confirmation, we activate Button1_Click()
    {
        Methods m = new Methods();
        if (ListBox1.SelectedItem != null)
        {
            HttpCookie bCookie = new HttpCookie("EmployeeToDelete");
            Response.Cookies.Add(bCookie);
            string UID = ListBox1.SelectedValue;
            m.HRForm_Read(bCookie, UID);

            /*BEGIN POP-UP*/
            ClientScript.RegisterStartupScript(typeof(Page), "exampleScript",
            "if(confirm(\"Are you sure you want to delete " + bCookie["First Name"] + " " + bCookie["Middle Name"] + " " + bCookie["Last Name"] + "? \"))" +
            "{ document.getElementById('Button1').click(); }", true);
            /*END POP-UP*/

            m.DeleteCookie("EmployeeToDelete");
        }


    }

    protected void Button1_Click(object sender, EventArgs e) //Does the deleting after the pop-up dialog
    {
        Methods m = new Methods();
        if (ListBox1.SelectedItem != null)
        {
            string UID = ListBox1.SelectedValue;
            m.DeleteFromEmployeesByUID(UID);
            Response.Redirect("~/HRForm.aspx");
        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        Methods m = new Methods();
        if (ListBox1.SelectedItem != null)
        {
            HttpCookie bCookie = new HttpCookie("selectedEmployee");
            Response.Cookies.Add(bCookie);
            string UID = ListBox1.SelectedValue;
            m.HRForm_Read(bCookie, UID);
            Response.Redirect("~/EditEmployeeForm.aspx");
        }

    }


}
