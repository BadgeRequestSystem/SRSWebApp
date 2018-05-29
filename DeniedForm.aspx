<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeniedForm.aspx.cs" Inherits="DeniedForm" %>

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
        <p>
            <div id="listboxFormPanel">
                <p>
                    <asp:listbox id="ListBox1" runat="server" height="323px" font-size="100%" backcolor="#CCCCCC" font-bold="True" forecolor="Black" width="100%"></asp:listbox>
                </p>
            </div>
            <div id="listboxFormPanelText">
                <img alt="MainMenuImage" class="auto-style1" src="Images/srslogo52818.png" id="testPic" width="100%" height="85%" /><br />
                <asp:label id="Label1" runat="server" font-bold="True" font-size="XX-Large" forecolor="#FF9900" text="Denied"></asp:label>

            </div>
            <div id="listboxFormPanelButtons">
                <p>
                    <asp:button id="Button1" runat="server" text="Back" onclick="Button1_Click" width="100%" font-bold="True" backcolor="#CCCCCC" bordercolor="#FF9900" font-size="Large" />
                </p>
            </div>
        </p>
    </div>












</form>

</html>
