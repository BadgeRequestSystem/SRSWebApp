<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingActionForm.aspx.cs" Inherits="PendingActionForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
    <link rel="stylesheet" type="text/css" href="style.css">

</head>
<body bgcolor="aliceblue">

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
                <p></p>
            </div>
            <div id="overmiddle">
                <p></p>
            </div>
            <div id="listboxFormPanel">
                <p>
                    <asp:ListBox ID="ListBox1" runat="server" Height="309px" Font-Size="Medium" BackColor="#CCCCCC" Font-Bold="True" Width="100%"></asp:ListBox>
                </p>
            </div>
            <div id="listboxFormPanelButtons">
                <p>
                    <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" Width="100%" Font-Bold="True" BorderColor="#FF9900" Font-Size="Large" BackColor="#CCCCCC" />
                    
                </p>
            </div>
            <div id="listboxFormPanelText">
                <img alt="MainMenuImage" class="auto-style1" src="Images/srslogo52818.png" id="testPic" width="100%" height="85%" /><br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="#FF9900" Text="Pending Action"></asp:Label>
            </div>
        </form>
    </body>
</html>
