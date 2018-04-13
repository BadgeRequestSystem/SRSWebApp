<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HRForm.aspx.cs" Inherits="HRForm" %>

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
			<center><h1><span class="glyphicon glyphicon-equalizer"></span>Employees</h1></center>
			<form id="form1" runat="server">
    <div>
    
    </div>
        <center>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="empNAME" DataValueField="uid"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;Persist Security Info=True;User ID=pwndatnerd;Password=AaronDavidRandall!3" SelectCommand="SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS empNAME, [UserID] AS uid FROM Employees ORDER BY [Last Name]" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
        <br />
        <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />                                                                                                                
        <asp:Button ID="newButton" runat="server" Text="New" OnClick="newButton_Click" />
        <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" />
        <asp:Button ID="deleteButton" runat="server" Text="Delete" OnClick="deleteButton_Click" />
            <asp:Button ID="Button1" Visible="true" SkinID="button"  OnClick="Button1_Click"  runat="server" style="display:none" />
            </center>
    </form>

            </div></div>
<body>
    
                                                                                                                                                 
</body>
</html>
