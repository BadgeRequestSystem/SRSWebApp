<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeniedForm.aspx.cs" Inherits="DeniedForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <center>
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Employee" DataValueField="RequestID"></asp:ListBox>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:badge_requestConnectionString %>" SelectCommand="SELECT [RequestID], [Employee], [Username] FROM [Requests] WHERE (([RequestState] = @RequestState) AND ([Username] = @Username))">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Denied" Name="RequestState" Type="String" />
                        <asp:CookieParameter CookieName="USERname" Name="Username" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
    </center>
        </div>
    </form>
</body>
</html>
