<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingActionForm.aspx.cs" Inherits="PendingActionForm" %>

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
			<center><h1><span class="glyphicon glyphicon-equalizer"></span>Pending Action</h1></center>
			<form id="form1" runat="server">
    <div>
        <center>
            <br />
            <br />
            <br />
           
            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="PendingDisplay" DataValueField="RequestID" Height="150px" Font-Size="20px"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;Persist Security Info=True;User ID=pwndatnerd;Password=AaronDavidRandall!3" SelectCommand="Select CAST([RequestID] AS varchar(200)) + '   ' + [Employee] + '   ' + CAST([CurrentDate] AS varchar(15)) AS PendingDisplay, [RequestID] From Requests JOIN Employees ON [Employee] = ([First Name] + ' ' + [Middle Name] + ' ' + [Last Name]) WHERE ([RequestState] = @RequestState AND [Username] = @CookieUsername) OR ([RequestState] = @RequestState AND [Manager Name] = @CookieManager)" ProviderName="System.Data.SqlClient">
                
            <SelectParameters>
                <asp:Parameter DefaultValue="Pending" Name="RequestState" Type="String" />
                <asp:CookieParameter CookieName="USERname" Name="CookieUsername" Type="String" />
                <asp:CookieParameter CookieName="Manager" Name="CookieManager" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click"  Width="100px" Font-Bold="true"/>
            </center>
    </div>
    </form>

            </div></div>
<body>
    
</body>
</html>
