<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewSubmittedForm.aspx.cs" Inherits="ViewSubmittedForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="aliceblue">
    <form id="form1" runat="server">
    <div>
    <center>

        <br /><br /><br />
        <asp:Label ID="employeeLabel" runat="server" Text="Employee: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="initialsLabel" runat="server" Text="Initials: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="useridLabel" runat="server" Text="UserID: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="ecompanyLabel" runat="server" Text="Employee Company: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="departmentLabel" runat="server" Text="Department: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="worklocationLabel" runat="server" Text="Work Location: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="workphoneLabel" runat="server" Text="Work Phone: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="emanagerLabel" runat="server" Text="Employee Manager: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="mworklocationLabel" runat="server" Text="Manager Work Location: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="mworkphoneLabel" runat="server" Text="Manager Work Phone: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="reasonforrequestLabel" runat="server" Text="Reason for Request: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="ssnLabel" runat="server" Text="SSN: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="getdateLabel" runat="server" Text="G.E.T. Date: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="dateofbirthLabel" runat="server" Text="Date of Birth: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="typeofbadgeLabel" runat="server" Text="Type of badge required: " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="proximitycardLabel" runat="server" Text="Proximity Card? " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="emergencyaccessLabel" runat="server" Text="Emergency Access? " Font-Size="22px"></asp:Label>
        <br />
        <asp:Label ID="continuecomputeraccountsLabel" runat="server" Text="Continue Computer Accounts? " Font-Size="22px"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="notesLabel" runat="server" Text="Notes: " Font-Size="22px"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="112px" TextMode="MultiLine" Width="250px" Font-Size="22px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="backButton" runat="server" OnClick="backButton_Click" Text="Back"  Width="100px" Font-Bold="true"/>
        <br />
        <br />
        <br />


    </center>
    </div>
    </form>
</body>
</html>
