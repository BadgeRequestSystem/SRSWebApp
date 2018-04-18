﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenuForm.aspx.cs" Inherits="MainMenuForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<form id="form1" runat="server">
    <body bgcolor="aliceblue">



        <div id="overtop">
            <p></p>
        </div>
        <div id="overbottom">
            <p>
                <br></br>
                <p>SRS - Badge Request System: Augusta University Senior Capstone Project
            </p>
                <p></p>
            </p>
        </div>
        <div id="overright">
            <p></p>
        </div>
        <div id="overleft">
            <p>&nbsp;</p>
        </div>
        <div id="overmiddle">
            <p>
            </p>
        </div>
        <div id="mainpageWelcome">
            <p>
                <asp:Label ID="Label2" runat="server" Text="Welcome, " Font-Size="XX-Large" ForeColor="Orange" Font-Bold="True"></asp:Label>
                <p></p>
                <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click1" Width="100px" Font-Bold="true" BackColor="#FF9900" />
            </p>
        </div>
        <div id="overmiddleleft">
            <br />
            <br />
            <br />
            <p>
                <asp:Button ID="ButtonNewRequest" runat="server" Text="New Request" OnClick="ButtonNewRequest_Click" Height="65px" Width="320px" Font-Size="X-Large" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Font-Bold="True" />
            </p>
            <p>

                <asp:Button ID="ButtonViewSavedRequests" runat="server" Text="View Drafts" OnClick="ButtonViewSavedRequests_Click" Height="65px" Width="320px" Font-Size="X-Large" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Font-Bold="True" />
            </p>
            <p>

                <asp:Button ID="ButtonViewSubmittedRequests" runat="server" Text="View Submitted Requests" OnClick="ButtonViewSubmittedRequests_Click" Height="65px" Width="320px" Font-Size="X-Large" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Font-Bold="True" />
            </p>
            <asp:Button ID="ButtonUpdateEmployees" runat="server" Text="Update Employees" OnClick="ButtonUpdateEmployees_Click" Height="65px" Width="320px" Font-Size="X-Large" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Visible="False" Font-Bold="True" />
            <p>
                <asp:Button ID="ButtonReviewRequests" runat="server" Text="Review Requests" OnClick="ButtonReviewRequests_Click" Height="65px" Width="320px" Font-Size="X-Large" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Visible="False" Font-Bold="True" />
            </p>
        </div>
        <div id="overmiddleright">
            <asp:Image ID="Image1" runat="server" Height="394px" ImageUrl="~/Images/srs logo main menu.png" Width="426px" />
        </div>








        </div>
         <div align="right"></div>
        <br />
        <center>
        
            
            
        </p>
        <p>
        
            </p>
            <p>
            
            </p>
        <p>
            
        </p>
        <p>
            
            </p>
        
        <p>
            
            </center>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
</form>
</body>
</html>
