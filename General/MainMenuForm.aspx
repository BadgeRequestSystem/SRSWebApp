<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenuForm.aspx.cs" Inherits="MainMenuForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="overtop">
            <p></p>
        </div>
        <div id="overbottom">
            <p>
                <br></br>
                <strong>SRS - Badge Request System: Augusta University Senior Capstone Project</strong>

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
            <br />
            <br />
            <img alt="MainMenuImage" class="auto-style1" src="Images/srslogo52818.png" id="testPic" width="50%" height="15%" /><br />
            <asp:Label ID="mainMenuLabel" runat="server" Text="Main Menu" Font-Size="300%" ForeColor="Orange" Font-Bold="True"></asp:Label><br />
            <asp:Label ID="Label2" runat="server" Text="Logged in as: " Font-Size="150%" ForeColor="white" Font-Bold="True"></asp:Label><br />
            <br />
            <br />
            <br />
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click1" Font-Size="170%" Font-Bold="true" BackColor="#FF9900" /><br />
            <br />
            <br />
            <br />
            <asp:Button ID="ButtonNewRequest" runat="server" Text="New Request" OnClick="ButtonNewRequest_Click" Font-Size="170%" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Font-Bold="True" /><br />
            <br />
            <asp:Button ID="ButtonViewSavedRequests" runat="server" Text="View Drafts" OnClick="ButtonViewSavedRequests_Click" Font-Size="170%" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Font-Bold="True" /><br />
            <br />
            <asp:Button ID="ButtonViewSubmittedRequests" runat="server" Text="Submitted Requests" OnClick="ButtonViewSubmittedRequests_Click" Font-Size="170%" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Font-Bold="True" /><br />
            <br />
            <asp:Button ID="ButtonUpdateEmployees" runat="server" Text="Update Employees" OnClick="ButtonUpdateEmployees_Click" Font-Size="170%" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Visible="False" Font-Bold="True" /><br />
            <br />
            <asp:Button ID="ButtonReviewRequests" runat="server" Text="Review Requests" OnClick="ButtonReviewRequests_Click" Font-Size="170%" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Visible="False" Font-Bold="True" /><br />
            <br />

        </div>

    </form>
</body>
</html>
