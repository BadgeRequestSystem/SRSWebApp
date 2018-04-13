<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
			<h1><span class="glyphicon glyphicon-equalizer"></span></h1>
			<form id="form1" runat="server">
        <div>
            <center>
			    <img alt="Savannah River Site Logo" class="auto-style1" src="Images/SRSLogo.png" /><br />
			    <asp:Label ID="RequestLabel" runat="server" text="Badge Request System"  Font-Bold="True" Font-Size="25pt" ForeColor="Black" /><br />
			<br />
            <asp:Label ID="userLabel" runat="server" Text="Username:" Font-Bold="true"/>
			<br /> 
			<asp:TextBox ID="userBox" Columns="20" MaxLength="25" Text="" runat="server" Height="25px"/>
			<br />
            <br />
			<asp:Label ID="passLabel" runat="server" Text="Password:" Font-Bold="true"/>
			<br /> 
			<asp:TextBox ID="passBox" Columns="20" MaxLength="25" Text="" runat="server" Height="25px" TextMode="Password"/>
			<br />
			<asp:Button id="loginButton" Text="Login" OnClick="LoginBtn_Click" runat="server" Font-Bold="true" Width="100px"/>
            </center>

        </div>
    	<p>
			&nbsp;</p>
    </form>

            </div></div>
<body bgcolor="aliceblue">
    
</body>
</html>
