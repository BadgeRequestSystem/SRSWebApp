<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewSubmittedForm.aspx.cs" Inherits="ViewSubmittedForm" %>

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
            <p>
                SRS - Badge Request System: Augusta University Senior Capstone Project
            </p>
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
            &nbsp;<asp:label id="employeeLabel" runat="server" text="Employee: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="initialsLabel" runat="server" text="Initials: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="useridLabel" runat="server" text="UserID: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="ecompanyLabel" runat="server" text="Employee Company: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="departmentLabel" runat="server" text="Department: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="worklocationLabel" runat="server" text="Work Location: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="workphoneLabel" runat="server" text="Work Phone: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="emanagerLabel" runat="server" text="Employee Manager: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="mworklocationLabel" runat="server" text="Manager Work Location: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="mworkphoneLabel" runat="server" text="Manager Work Phone: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="reasonforrequestLabel" runat="server" text="Reason for Request: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="ssnLabel" runat="server" text="SSN: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="getdateLabel" runat="server" text="G.E.T. Date: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="dateofbirthLabel" runat="server" text="Date of Birth: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="typeofbadgeLabel" runat="server" text="Type of badge required: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="proximitycardLabel" runat="server" text="Proximity Card? " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="emergencyaccessLabel" runat="server" text="Emergency Access? " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:label id="continuecomputeraccountsLabel" runat="server" text="Continue Computer Accounts? " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <br />
            <br />
            <asp:label id="notesLabel" runat="server" text="Notes: " font-size="22px" Font-Bold="True" ForeColor="#FF9900"></asp:label>
            <br />
            <asp:textbox id="TextBox1" runat="server" height="112px" textmode="MultiLine" width="250px" font-size="22px" BackColor="#CCCCCC"></asp:textbox>
        </p>
        <p>
            <br />
            <br />
            <asp:button id="backButton" runat="server" onclick="backButton_Click" text="Back" width="100px" font-bold="True" BackColor="#CCCCCC" BorderColor="#FF9900" Font-Size="Large" />
            <asp:button id="editButton" runat="server" text="Edit" BackColor="#CCCCCC" BorderColor="#FF9900" Font-Bold="True" Font-Size="Large" Width="100px" />
        </p>

    </div>
    </form>
</html>
