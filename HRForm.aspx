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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;Persist Security Info=True;User ID=pwndatnerd;Password=AaronDavidRandall!3" SelectCommand="SELECT [First Name] + ' ' + [Middle Name] + ' ' + [Last Name] AS empNAME, [UserID] AS uid FROM Employees" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
        <br />
        <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />                                                                                                                
        <asp:Button ID="newButton" runat="server" Text="New" OnClick="newButton_Click" />
        <asp:Button ID="updateButton" runat="server" Text="Update" />
        <asp:Button ID="deleteButton" runat="server" Text="Delete" OnClick="deleteButton_Click" />
            <asp:Button ID="Button1" Visible="true" SkinID="button"  OnClick="Button1_Click"  runat="server" style="display:none" />
            </center>
    </form>
                                                                                                                                                 
</body>
</html>
