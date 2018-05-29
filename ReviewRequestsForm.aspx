<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewRequestsForm.aspx.cs" Inherits="ReviewRequestsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<form id="form1" runat="server">

    <div id="overtop">
        <p></p>
    </div>
    <div id="overbottom">
        <p>
            <br></br>
            SRS - Badge Request System: Augusta University Senior Capstone Project
            
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
        <br /><br />
        <img alt="MainMenuImage" class="auto-style1" src="Images/srslogo52818.png" id="testPic" width="50%" height="15%" /><br />
        <asp:label id="Label1" runat="server" font-bold="True" font-size="XX-Large" forecolor="#FF9900" text="Review Requests"></asp:label>
        <br /><br /><br /><br /><br /><br /><br />

        <asp:button id="pendingButton" runat="server" text="Pending" onclick="pendingButton_Click" font-size="200%" backcolor="#CCCCCC" bordercolor="#FF9900" font-bold="True" />
        <br /><br /><br />
        <asp:button id="approvedButton" runat="server" text="Approved" onclick="approvedButton_Click" font-size="200%" backcolor="#CCCCCC" bordercolor="#FF9900" font-bold="True" />
        <br /><br /><br />
        <asp:button id="deniedButton" runat="server" text="Denied" onclick="deniedButton_Click" font-size="200%" backcolor="#CCCCCC" bordercolor="#FF9900" font-bold="True" />

    </div>

    <div id="reviewRequestsBackButton">
        <p>
            &nbsp;
        </p>
        <p>
            <asp:button id="backButton" runat="server" onclick="backButton_Click" text="Back" font-bold="True" backcolor="#CCCCCC" bordercolor="#FF9900" font-size="185%" />
        </p>
    </div>
    </p>
    </div>



</form>

</html>
