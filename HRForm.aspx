<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HRForm.aspx.cs" Inherits="HRForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <center>
        <asp:Label ID="Label1" runat="server" Text="Employees"></asp:Label>
        <br />
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="empNAME" DataValueField="uid"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:badge_requestConnectionString %>" SelectCommand="SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS empNAME, [UserID] AS uid FROM Employees"></asp:SqlDataSource>
        <br />
        <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />                                                                                                                
        <asp:Button ID="newButton" runat="server" Text="New" OnClick="newButton_Click" />
        <asp:Button ID="updateButton" runat="server" Text="Update" />
        <asp:Button ID="deleteButton" runat="server" Text="Delete" OnClick="deleteButton_Click" />
            </center>
    </form>
                                                                                                                                                 
</body>
</html>
