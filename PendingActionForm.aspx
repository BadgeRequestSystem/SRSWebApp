<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingActionForm.aspx.cs" Inherits="PendingActionForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <br />
            <br />
            <br />
           
            <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="PendingDisplay" DataValueField="RequestID" Height="150px" Font-Size="20px"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;Persist Security Info=True;User ID=pwndatnerd;Password=AaronDavidRandall!3" SelectCommand="Select CAST([RequestID] AS varchar(200)) + '   ' + [Employee] + '   ' + CAST([CurrentDate] AS varchar(15)) AS PendingDisplay, [RequestID] From Requests JOIN Employees ON [Employee] = ([First Name] + ' ' + [Middle Name] + ' ' + [Last Name]) WHERE ([RequestState] = @RequestState AND [Username] = @CookieUsername) OR ([RequestState] = @RequestState AND [Manager Name] = @CookieManager)" ProviderName="System.Data.SqlClient">
                
            <SelectParameters>
                <asp:Parameter DefaultValue="Pending" Name="RequestState" Type="String" />
                <asp:CookieParameter CookieName="USERname" Name="CookieUsername" Type="String" />
                <asp:CookieParameter CookieName="Manager" Name="CookieManager" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click"  Width="100px" Font-Bold="true"/>
            </center>
    </div>
    </form>
</body>
</html>
