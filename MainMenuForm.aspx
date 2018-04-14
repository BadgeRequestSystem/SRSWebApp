<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainMenuForm.aspx.cs" Inherits="MainMenuForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<form id="form1" runat="server">
    <body bgcolor="aliceblue">



        <div id="overtop">
            <p></p>
        </div>
        <div id="overbottom">
            <p>&nbsp;</p>
        </div>
        <div id="overright">
            <p></p>
        </div>
        <div id="overleft">
            <p>&nbsp;</p>
        </div>
        <div id="overmiddle">
            <p>
            </p>
        </div>
        <div id="mainpageWelcome">
            <p>
                <asp:Label ID="Label2" runat="server" Text="Welcome, " Font-Size="XX-Large" ForeColor="Orange" Font-Bold="True"></asp:Label>
                <p></p>
                <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click1" Width="100px" Font-Bold="true" BackColor="#FF9900" />
            </p>
        </div>
        <div id="overmiddleleft">
            <p>
                <asp:Button ID="ButtonNewRequest" runat="server" Text="New Request" OnClick="ButtonNewRequest_Click" Height="105px" Width="379px" Font-Size="14pt" ForeColor="Black" BackColor="#FF9900" />
            </p>
            <p>
                <br />
                <br />
                <br />
                <asp:Button ID="ButtonViewSavedRequests" runat="server" Text="View Drafts" OnClick="ButtonViewSavedRequests_Click" Height="107px" Width="376px" Font-Size="14pt" ForeColor="Black" BackColor="#FF9900" />
            </p>
            <p>
                <br />
                <br />
                <br />
                <asp:Button ID="ButtonViewSubmittedRequests" runat="server" Text="View Submitted Requests" OnClick="ButtonViewSubmittedRequests_Click" Height="102px" Width="376px" Font-Size="14pt" ForeColor="Black" BackColor="#FF9900" />
            </p>
        </div>
        <div id="overmiddleright">
            <p>
                <asp:Button ID="ButtonReviewRequests" runat="server" Text="Review Requests" OnClick="ButtonReviewRequests_Click" Height="115px" Width="396px" Font-Size="14pt" ForeColor="Black" BackColor="Gray" Enabled="False" />
            </p>
            <p>
                
                <br />
                
                <br />
                <br />
                <asp:Button ID="ButtonUpdateEmployees" runat="server" Text="Update Employees" OnClick="ButtonUpdateEmployees_Click" Height="111px" Width="404px" Font-Size="14pt" ForeColor="Black" BackColor="Gray" Enabled="False" />
            </p>
        </div>

        <div id="overmiddleleftABOVEtext">
            <p><asp:Label ID="employees_label" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#FF9900" Text="Employees"></asp:Label></p>
        </div>
        <div id="overmiddlerightABOVEtext">
            <p><asp:Label ID="managerAndHR_label" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#FF9900" Text="Manager and HR"></asp:Label></p>
        </div>







        </div>
         <div align="right"></div>
        <br />
        <center>
        
            
            
        </p>
        <p>
        
            </p>
            <p>
            
            </p>
        <p>
            
        </p>
        <p>
            
            </p>
        
        <p>
            
            </center>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
</form>
</body>
</html>
