<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoInfo.aspx.cs" Inherits="DemoInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <center>
        <strong>Message from the developers</strong><br />
        "This web application was developed for a 1920x1080 resolution, with the primary testing browser being Firefox. Due to our limited knowledge of Javascript and Bootstrap at the time of this projects development, you may notice minor issues while using this demo.
        <br />
        The developers who worked on this project are not strong in their artistic capability. As you demo this project, you may notice graphical bugs and things in general that could have been designed better.
        <br />
        Thanks for taking the time to demo our work!"
        <br />
        -Devs
    </center>
        <br />
        <br />
        <br />
        <br />
        <center>
        <strong>Demo Login Information</strong><br />
        Example Manager account -> (Username: Chuck)(Password: Prather)
        <br />
        Example HR account -> (Username: Jane)(Password: Adams)
        <br />
        Example Employee account -> (Username: James)(Password: Cliett)
        <br />
        Keep in mind while demoing this project, we prevent these base accounts from being edited or deleted in the Update Employee's function. You are free to create as many employee's as you wish, however; you may not create login credentials for your custom employees unless you create your own database and hook up the project to it.
    </center>
        <br />
        <br />
        <br />
        <br />
        <center>
        <strong>Regarding information format</strong><br />
        When putting in information for a user's <strong>UserID</strong>, the format is: five characters long, first character is an alphabet character (like 'a' or 'b'), the last four are numeric characters ('1', '2' etc). Take t1234 as an example of a valid UserID.
        <br />
        <strong>Phone numbers</strong> have the normal xxx-xxx-xxxx format.
        <br />
        <strong>SSN</strong> format must look like: xxx-xx-xxxx
        <br />
        <strong>Locations</strong> could like similar to: 123-1A Rm 1234
        <br />
        <strong>Employee Company</strong> example: SRS. 
        <br />
        <strong>Department</strong> example: HR
    </center>
        <br />
        <br />
        <br />
        <br />
        <center>
        <strong>General Information</strong><br />
        We have disabled email notifications for the demo version. Download the zip containing everything you need to set-up your own database for the project <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">here</asp:LinkButton>. All you would need to do is hook up your database in the Methods.cs file which is located in the 'App_Code' folder.
        <br />
        Creating credentials is out of scope for this projects design. This would in practice be handled in a different way, so you will need to go into your Credentials table and create your custom login information if you wish to create more.
        <br />
        As a Manager you will be able to Approve/Deny/Need the requests from employee's underneath you. 
        <br />
        An HR user will be able to Update, Create, and Delete employees from the database. We do however put restrictions on the preexisting employees on our database to prevent griefing to our demo database.
        <br />
        The user manual for this project can be found <asp:LinkButton ID="UserManual" runat="server" OnClick="UserManual_Click">here</asp:LinkButton>

    </center>
    </form>
</body>
</html>
