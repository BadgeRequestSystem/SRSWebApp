<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApprovedForm.aspx.cs" Inherits="ApprovedForm" %>

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
        <p>
            <div id="listboxFormPanel">
                <p>
                    <asp:listbox id="ListBox1" runat="server" onselectedindexchanged="ListBox1_SelectedIndexChanged" height="323px" font-size="Medium" forecolor="Black" BackColor="#CCCCCC" Font-Bold="True" Width="100%"></asp:listbox>

                </p>
            </div>
            <div id="listboxFormPanelText">
                <p>
                    <asp:label id="Label1" runat="server" font-bold="True" font-size="XX-Large" forecolor="#FF9900" text="Approved"></asp:label>
                </p>
            </div>
            <div id="listboxFormPanelButtons">
                <p>
                    <asp:button id="Button1" runat="server" text="Back" onclick="Button1_Click" width="100%" font-bold="True" forecolor="Black" BackColor="#CCCCCC" BorderColor="#FF9900" Font-Size="Large" />
                </p>
            </div>
        </p>
    </div>








</form>
</html>
