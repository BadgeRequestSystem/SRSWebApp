<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingForm.aspx.cs" Inherits="PendingForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="aliceblue">
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />
    <center>
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="PendingDisplay" DataValueField="RequestID" Height="150px" Font-Size="20px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:badge_requestConnectionString %>" SelectCommand="Select CAST([RequestID] AS varchar(200)) + '   ' + [Employee] + '   ' + CAST([CurrentDate] AS varchar(15)) AS PendingDisplay, [RequestID] From Requests WHERE (([RequestState] = @RequestState) AND ([Username] = @Username))">
            <SelectParameters>
                <asp:Parameter DefaultValue="Pending" Name="RequestState" Type="String" />
                <asp:CookieParameter CookieName="USERname" Name="Username" Type="String" />
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
