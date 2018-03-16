<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenuForm.aspx.cs" Inherits="MainMenuForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
</head>
<body bgcolor="aliceblue">
    <form id="form1" runat="server">
    <div>
    
    </div>
         <div align="right"><asp:Label ID="Label2" runat="server" Text="Welcome, " Font-Size="14pt"></asp:Label></div>
        <br />
        <center>
        <asp:Label ID="Label1" runat="server" Text="Main Menu" Font-Size="25pt"></asp:Label>
           
        <p>
            <asp:Button ID="ButtonNewRequest" runat="server" Text="New Request" OnClick="ButtonNewRequest_Click" Height="40px" Width="300px" Font-Size="14pt"/>
        </p>
        <asp:Button ID="ButtonViewSavedRequests" runat="server" Text="View Drafts" OnClick="ButtonViewSavedRequests_Click" Height="40px" Width="300px" Font-Size="14pt"/>
        <p>
            <asp:Button ID="ButtonViewSubmittedRequests" runat="server" Text="View Submitted Requests" OnClick="ButtonViewSubmittedRequests_Click" Height="40px" Width="300px" Font-Size="14pt"/>
        </p>
        <p>
            <asp:Button ID="ButtonReviewRequests" runat="server" Text="Review Requests" OnClick="ButtonReviewRequests_Click" Visible="False" Height="40px" Width="300px" Font-Size="14pt"/>
        </p>
        <p>
            <asp:Button ID="ButtonUpdateEmployees" runat="server" Text="Update Employees" OnClick="ButtonUpdateEmployees_Click" Visible="False" Height="40px" Width="300px" Font-Size="14pt"/>
        </p>
        <p>
            </center>
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click1" Width="100px" Font-Bold="true"/>
        </p>
    </form>
</body>
</html>
