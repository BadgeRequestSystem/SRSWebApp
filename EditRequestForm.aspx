<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRequestForm.aspx.cs" Inherits="EditRequestForm" %>

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
			<center><h1><span class="glyphicon glyphicon-equalizer"></span>Request Form</h1></center>
			<form id="EditRequest" runat="server">
    <div>
        <br />

         <Center>
           <asp:Label ID="RequestLabel" runat="server" text=""  Font-Bold="True" Font-Size="23pt" />
             
        <div>
            <br />
            <br />
        </div>
        <asp:Label ID="EmployeeLabel" runat="server" Text="Employee:" />
        <div>
        <asp:DropDownList ID="EmployeeDDL" runat="server" Width="125px" DataSourceID="SqlDataSource1" DataTextField="Last_Name" DataValueField="Last_Name" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;Persist Security Info=True;User ID=pwndatnerd;Password=AaronDavidRandall!3" SelectCommand="SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS Last_Name FROM [Employees]" ProviderName="System.Data.SqlClient">
                </asp:SqlDataSource>
        </div>
        <asp:Label ID="ReasonLabel" runat="server" Text="Reason For Request:" />
        <div>
            <asp:DropDownList ID="ReasonDDL" runat="server" Width="125px" >
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Area Access Change</asp:ListItem>
                <asp:ListItem>Appearance Change</asp:ListItem>
                <asp:ListItem>Damaged Badge</asp:ListItem>
                <asp:ListItem>Job Change</asp:ListItem>
                <asp:ListItem>Lost Badge</asp:ListItem>
                <asp:ListItem>Name Change</asp:ListItem>
                <asp:ListItem>New/Changed Clearance</asp:ListItem>
                <asp:ListItem>New Employee</asp:ListItem>
                <asp:ListItem>Rebadging Cycle</asp:ListItem>
                <asp:ListItem>Downgrade</asp:ListItem>
                <asp:ListItem>HRP</asp:ListItem>
                <asp:ListItem>LSE/Intern</asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div>
            <br />
        </div>
        <asp:Label ID="getDateLabel" Text="G.E.T. Date:" runat="server" />
        <div>
            <asp:TextBox ID="GetTextBox" columns="20" MaxLength="25" Placeholder="mm/dd/yyyy" runat="server"  />
        </div>
        <br />
        <asp:Label ID="SSNLabel" Text ="SSN:" runat="server" />
        <div>
            <asp:TextBox ID="SSNTextBox" Columns="20" MaxLength="25" placeholder="XXX-XX-XXXX" runat="server"  />

        </div>
        <br />
        <asp:Label ID="DOBLabel" Text="Date of Birth:" runat="server" />
        <div>
            <asp:TextBox ID="DOBTextBox" Columns="20" MaxLength="25" placeholder="mm/dd/yyyy" runat="server" />
        </div>
        <br />
        <asp:Label ID="BadgeTypeLabel" Text="Type of Badge:" runat="server" />
        <div>
            <asp:DropDownList ID="BadgeTypeDDL" runat="server" Width="125px" >
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>L</asp:ListItem>
                <asp:ListItem>Q</asp:ListItem>
                <asp:ListItem>Uncleared</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <asp:Label ID="ProximityCardLabel" Text="Proximity Card?" runat="server" />
        <div>
            <asp:CheckBox ID="ProximityCheckBox" runat="server" />
        </div>
        <br />
        <asp:Label ID="EmergencyLabel" Text="Emergency Access?" runat="server" />
        <div>
            <asp:CheckBox ID="EmergencyCheckBox" runat="server" />
        </div>
        <br />
        <asp:Label ID="ComputerAccountsLabel" Text ="Contunue Previous Computer Accounts?" runat="server" />
        <div>
            <asp:CheckBox ID="AccountsCheckBox" runat="server" />
        </div> 
        <br />
        <asp:Label ID="NotesLabel" Text="Notes:(max 500 char)" runat="server" />
        <div>
                <asp:TextBox ID="NotesTextBox" Columns ="20" MaxLength="500" runat="server" Height="200px" TextMode="MultiLine" Width="400px" />
        </div>
        <asp:Button ID="CancelButton" text="Cancel" runat="server" OnClick="CancelButton_Click" Width="100px" Font-Bold="true"/>
        <asp:Button ID="SaveButton" Text="Save Draft" runat="server" OnClick="SaveButton_Click" Width="100px" Font-Bold="true"/>
        <asp:Button ID="SubmmitButton" Text="Submit" runat="server" OnClick="SubmmitButton_Click" Width="100px" Font-Bold="true"/>
            
             </Center>



        
    </div>
    </form>

            </div></div>
<body bgcolor="aliceblue">
    
</body>
</html>
