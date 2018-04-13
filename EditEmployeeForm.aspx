<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditEmployeeForm.aspx.cs" Inherits="EditEmployeeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>

        <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS: You can use this stylesheet to override any Bootstrap styles and/or apply your own styles -->
    <link href="css/custom.css" rel="stylesheet">

</head>
<body bgcolor="aliceblue">

    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand">
                	<span class="glyphicon glyphicon-fire"></span> 
                	 SRS Badge Request System
                </a>
               

        </div></div></nav>
    <div class="jumbotron feature">
		<div class="container">
            <center>
			<h1><span class="glyphicon glyphicon-equalizer"></span>Edit Employees</h1>
			<form id="form1" runat="server">
    <div>
             <Center>
           <asp:Label ID="RequestLabel" runat="server" text=""  Font-Bold="True" Font-Size="23pt" />
             
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Middle Name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Initials"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            UserID<br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Employee Company"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Department"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Work Location"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Work Phone"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:Label ID="EmployeeLabel" runat="server" Text="Employee Manager:" />
        <div>
        <asp:DropDownList ID="EmployeeDDL" runat="server" Width="125px" DataSourceID="SqlDataSource1" DataTextField="Last_Name" DataValueField="Last_Name" AppendDataBoundItems="True" OnLoad="EmployeeDDL_Load" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;Persist Security Info=True;User ID=pwndatnerd;Password=AaronDavidRandall!3" SelectCommand="SELECT Employees.[First Name] + ' ' + Employees.[Middle Name] + ' ' + Employees.[Last Name] AS Last_Name, Employees.[UserID] AS uid, Credentials.[isManager] FROM [Employees] INNER JOIN [Credentials] ON Employees.[UserID] = Credentials.[UserID] WHERE Credentials.[isManager] = 'True'" ProviderName="System.Data.SqlClient">
                </asp:SqlDataSource>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Manager Work Location"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Manager Work Phone"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        </div>
        <div>
            <br />
        </div>
        <div>
            <br />
        </div>
        <br />
        <asp:Button ID="CancelButton" text="Back" runat="server" OnClick="CancelButton_Click" Width="100px" Font-Bold="true"/>
        <asp:Button ID="SubmmitButton" Text="Save" runat="server" OnClick="SubmmitButton_Click" Width="100px" Font-Bold="true"/>
            
             </Center>
    </div>
    </form>
                </center>

            </div></div>
<body>
    
</body>
</html>
