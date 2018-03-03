using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



//enter stuff here
public partial class ApprovedForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*So in order for the listbox to get the userName cookie, we have to request the userInfo cookie, create a new cookie that will hold ONLY username!*/
        /*So aCookie is the original cookie, usernameCookie is the new cookie that gets assigned aCookie.Values["userName"], and of course we named the new cookie USERname*/
        /*USERname is the cookie that will be looked for in the .aspx file*/
        HttpCookie aCookie = Request.Cookies["userInfo"];
        HttpCookie usernameCookie = new HttpCookie("USERname");
        usernameCookie.Value = aCookie.Values["userName"];
        Response.Cookies.Add(usernameCookie);

        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ReviewRequestsForm.aspx");
    }
}