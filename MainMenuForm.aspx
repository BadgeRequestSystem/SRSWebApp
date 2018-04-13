<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenuForm.aspx.cs" Inherits="MainMenuForm" %>

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


    <form id="form1" runat="server">

    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand">
                	<span class="glyphicon glyphicon-fire"></span> 
                	 SRS Badge Request System
                </a>
                 <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click1" Width="100px" Font-Bold="true"/>
                    


        </div></div></nav>
    
        
    <div>
    <div class="jumbotron feature">
		<div class="container">
            <asp:Label ID="Label2" runat="server" Text="Welcome, " Font-Size="14pt" ForeColor="Black"></asp:Label>
            <br />
            <center>
			<h1><span class="glyphicon glyphicon-equalizer"></span>Main Menu<a class="navbar-brand">
                </a>
               
                <p>
            <asp:Button ID="ButtonNewRequest" runat="server" Text="New Request" OnClick="ButtonNewRequest_Click" Height="40px" Width="300px" Font-Size="14pt" ForeColor="Black"/>
        </p>
        <p>
        <asp:Button ID="ButtonViewSavedRequests" runat="server" Text="View Drafts" OnClick="ButtonViewSavedRequests_Click" Height="40px" Width="300px" Font-Size="14pt" ForeColor="Black"/>
            </p>
            <p>
            <asp:Button ID="ButtonViewSubmittedRequests" runat="server" Text="View Submitted Requests" OnClick="ButtonViewSubmittedRequests_Click" Height="40px" Width="300px" Font-Size="14pt" ForeColor="Black"/>
            </p>
        <p>
            <asp:Button ID="ButtonReviewRequests" runat="server" Text="Review Requests" OnClick="ButtonReviewRequests_Click" Visible="False" Height="40px" Width="300px" Font-Size="14pt" ForeColor="Black"/>
        </p>
        <p>
            <asp:Button ID="ButtonUpdateEmployees" runat="server" Text="Update Employees" OnClick="ButtonUpdateEmployees_Click" Visible="False" Height="40px" Width="300px" Font-Size="14pt" ForeColor="Black"/>
            </p>
            </h1></center>
			

            </div></div>





    </div>
         <div align="right"></div>
        <br />
        <center>
        
           
        
        <p>
            </center>
           
        </p>
    </form>
</body>
</html>
