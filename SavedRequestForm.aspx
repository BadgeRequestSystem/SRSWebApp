﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SavedRequestForm.aspx.cs" Inherits="SavedRequestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="aliceblue">
    <form id="form1" runat="server">
    <div>
        <br /><br /><br />
    <center>
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Employee" DataValueField="Employee"  Height="150px" Font-Size="20px"></asp:ListBox>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:badge_requestConnectionString %>" SelectCommand="Select [Employee] + '   ' + CAST([CurrentDate] AS varchar(15)) AS PendingDisplay From Drafts WHERE (([RequestState] = @RequestState) AND ([Username] = @Username))">--%>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=badgerequest.cthyx0iu4w46.us-east-2.rds.amazonaws.com;Initial Catalog=badge_request;Persist Security Info=True;User ID=pwndatnerd;Password=AaronDavidRandall!3" SelectCommand="Select [Employee], [CurrentDate] From Drafts WHERE (([RequestState] = @RequestState) AND ([Username] = @Username))" ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:Parameter DefaultValue="Draft" Name="RequestState" Type="String" />
                <asp:CookieParameter CookieName="USERname" Name="Username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back" Width="100px" Font-Bold="true"/>
    </center>
    </div>
    </form>
</body>
</html>
