<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewSubmittedForm.aspx.cs" Inherits="ViewSubmittedForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>


        <asp:Label ID="employeeLabel" runat="server" Text="Employee: "></asp:Label>
        <br />
        <asp:Label ID="initialsLabel" runat="server" Text="Initials: "></asp:Label>
        <br />
        <asp:Label ID="useridLabel" runat="server" Text="UserID: "></asp:Label>
        <br />
        <asp:Label ID="ecompanyLabel" runat="server" Text="Employee Company: "></asp:Label>
        <br />
        <asp:Label ID="departmentLabel" runat="server" Text="Department: "></asp:Label>
        <br />
        <asp:Label ID="worklocationLabel" runat="server" Text="Work Location: "></asp:Label>
        <br />
        <asp:Label ID="workphoneLabel" runat="server" Text="Work Phone: "></asp:Label>
        <br />
        <asp:Label ID="emanagerLabel" runat="server" Text="Employee Manager: "></asp:Label>
        <br />
        <asp:Label ID="mworklocationLabel" runat="server" Text="Manager Work Location: "></asp:Label>
        <br />
        <asp:Label ID="mworkphoneLabel" runat="server" Text="Manager Work Phone: "></asp:Label>
        <br />
        <asp:Label ID="reasonforrequestLabel" runat="server" Text="Reason for Request: "></asp:Label>
        <br />
        <asp:Label ID="ssnLabel" runat="server" Text="SSN: "></asp:Label>
        <br />
        <asp:Label ID="getdateLabel" runat="server" Text="G.E.T. Date: "></asp:Label>
        <br />
        <asp:Label ID="dateofbirthLabel" runat="server" Text="Date of Birth: "></asp:Label>
        <br />
        <asp:Label ID="typeofbadgeLabel" runat="server" Text="Type of badge required: "></asp:Label>
        <br />
        <asp:Label ID="proximitycardLabel" runat="server" Text="Proximity Card? "></asp:Label>
        <br />
        <asp:Label ID="emergencyaccessLabel" runat="server" Text="Emergency Access? "></asp:Label>
        <br />
        <asp:Label ID="continuecomputeraccountsLabel" runat="server" Text="Continue Computer Accounts? "></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="notesLabel" runat="server" Text="Notes: "></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="112px" TextMode="MultiLine" Width="188px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="backButton" runat="server" OnClick="backButton_Click" Text="Back" />
        <br />
        <br />
        <br />


    </center>
    </div>
    </form>
</body>
</html>
