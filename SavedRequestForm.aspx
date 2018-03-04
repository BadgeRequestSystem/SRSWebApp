<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SavedRequestForm.aspx.cs" Inherits="SavedRequestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="PendingDisplay" DataValueField="PendingDisplay"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:badge_requestConnectionString %>" SelectCommand="Select [Employee] + '   ' + CAST([CurrentDate] AS varchar(15)) AS PendingDisplay From Drafts WHERE (([RequestState] = @RequestState) AND ([Username] = @Username))">
            <SelectParameters>
                <asp:Parameter DefaultValue="Draft" Name="RequestState" Type="String" />
                <asp:CookieParameter CookieName="USERname" Name="Username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" />
    
    </div>
    </form>
</body>
</html>
