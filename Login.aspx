<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - SRS Badge Request</title>
    <style type="text/css">
        .auto-style1 {
            width: 349px;
            height: 144px;
        }
    </style>
</head>
<body bgcolor="aliceblue">
    <form id="form1" runat="server">
        <div>
            <center>
			    <img alt="Savannah River Site Logo" class="auto-style1" src="Images/SRSLogo.png" /><br />
			    <asp:Label ID="RequestLabel" runat="server" text="Badge Request System"  Font-Bold="True" Font-Size="25pt" ForeColor="SteelBlue" /><br />
			<br />
            <asp:Label ID="userLabel" runat="server" Text="Username:" Font-Bold="true"/>
			<br /> 
			<asp:TextBox ID="userBox" Columns="20" MaxLength="25" Text="" runat="server" Height="25px"/>
			<br />
            <br />
			<asp:Label ID="passLabel" runat="server" Text="Password:" Font-Bold="true"/>
			<br /> 
			<asp:TextBox ID="passBox" Columns="20" MaxLength="25" Text="" runat="server" Height="25px" TextMode="Password"/>
			<br />
			<asp:Button id="loginButton" Text="Login" OnClick="LoginBtn_Click" runat="server" Font-Bold="true" Width="100px"/>
            </center>

        </div>
    	<p>
			&nbsp;</p>
    </form>
</body>
</html>
