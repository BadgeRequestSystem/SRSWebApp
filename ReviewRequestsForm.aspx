<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewRequestsForm.aspx.cs" Inherits="ReviewRequestsForm" %>

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
			<center><h1><span class="glyphicon glyphicon-equalizer"></span>Review Requests</h1></center>
			<form id="form1" runat="server">
        <div>
            <br /><br /><br />
            <center>
        <asp:Button ID="pendingButton" runat="server" Text="Pending" OnClick="pendingButton_Click" Height="40px" Width="100px" Font-Size="14pt"/>
        <br /><br />
        <asp:Button ID="approvedButton" runat="server" Text="Approved" OnClick="approvedButton_Click" Height="40px" Width="100px" Font-Size="14pt"/>
        <br /><br />
        <asp:Button ID="deniedButton" runat="server" Text="Denied" OnClick="deniedButton_Click" Height="40px" Width="100px" Font-Size="14pt"/>
        <br />
             </center>

            <asp:Button ID="backButton" runat="server" OnClick="backButton_Click" Text="Back" Width="100px" Font-Bold="true"/>

        </div>
    </form>

            </div></div>
<body bgcolor="aliceblue">
    
</body>
</html>
