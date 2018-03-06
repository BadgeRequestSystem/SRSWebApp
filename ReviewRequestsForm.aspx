<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewRequestsForm.aspx.cs" Inherits="ReviewRequestsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
        <asp:Button ID="pendingButton" runat="server" Text="Pending" OnClick="pendingButton_Click" />
        <br />
        <asp:Button ID="approvedButton" runat="server" Text="Approved" OnClick="approvedButton_Click" />
        <br />
        <asp:Button ID="deniedButton" runat="server" Text="Denied" OnClick="deniedButton_Click" />
        <br />
             </center>

            <asp:Button ID="backButton" runat="server" OnClick="backButton_Click" Text="Back" />

        </div>
    </form>
</body>
</html>
