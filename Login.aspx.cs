using System;
using System.Web;

public partial class Login : System.Web.UI.Page
{
    public static Methods m = new Methods();


    protected void Page_Load(object sender, EventArgs e)
    {
        /*If user somehow ends up back on Login page, lets make them log back in and reset their session */
        /*REMOVE EVERY POSSIBLE COOKIE THAT MAY HAVE BEEN RECEIVED TO PREVENT ERRORS*/
        m.DeleteCookie("userInfo");
        m.DeleteCookie("USERname");
        m.DeleteCookie("submittedCookieInfo");
        m.DeleteCookie("Manager");
        m.DeleteCookie("draftInfo");
        m.DeleteCookie("EmployeeToDelete");
        m.DeleteCookie("selectedEmployee");
        /*****************************************************************************/
    }

    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        HttpCookie aCookie = new HttpCookie("userInfo");
        Response.Cookies.Add(aCookie);

        if (m.checkLogin(aCookie, userBox.Text, passBox.Text) == true) /*We will check the login info, then we will fill the 'userInfo' cookie and send them to the MainMenuForm.*/
            Response.Redirect("~/MainMenuForm.aspx"); //successful login
        else
            Response.Redirect("~/Login.aspx"); //failed login



    }
}