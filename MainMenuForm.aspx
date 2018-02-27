<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenuForm.aspx.cs" Inherits="MainMenuForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
         <div align="right"><asp:Label ID="Label2" runat="server" Text="USERNAME"></asp:Label></div>

        <center>
        <asp:Label ID="Label1" runat="server" Text="Main Menu"></asp:Label>
           
        <p>
            <asp:Button ID="ButtonNewRequest" runat="server" Text="New Request" OnClick="ButtonNewRequest_Click" />
        </p>
        <asp:Button ID="ButtonViewSavedRequests" runat="server" Text="View Saved Requests" OnClick="ButtonViewSavedRequests_Click" />
        <p>
            <asp:Button ID="ButtonViewSubmittedRequests" runat="server" Text="View Submitted Requests" OnClick="ButtonViewSubmittedRequests_Click" />
        </p>
        <p>
            <asp:Button ID="ButtonReviewRequests" runat="server" Text="Review Requests" OnClick="ButtonReviewRequests_Click" />
        </p>
        <p>
            <asp:Button ID="ButtonUpdateEmployees" runat="server" Text="Update Employees" OnClick="ButtonUpdateEmployees_Click" />
        </p>
        <p>
            </center>
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click1" />
        </p>
    </form>
</body>
</html>
