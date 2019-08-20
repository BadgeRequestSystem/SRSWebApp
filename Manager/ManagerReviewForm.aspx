<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerReviewForm.aspx.cs" Inherits="ManagerReviewForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<form id="ManagerReview" runat="server">


    <asp:checkbox id="isEditableCheckBox" runat="server" visible="False" />


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
        <div id="editRequestFormBottomButtons">
        <p>
            <asp:button id="ApproveButton" text="Approve" runat="server" onclick="ApproveButton_Click" font-bold="True" backcolor="#CCCCCC" bordercolor="#FF9900" font-size="180%" />
            <asp:button id="DenyButton" text="Deny" runat="server" onclick="DenyButton_Click" font-bold="True" backcolor="#CCCCCC" bordercolor="#FF9900" font-size="180%" />
            <asp:button id="InfoButton" text="Needs More Info" runat="server" onclick="InfoButton_Click" font-bold="True" backcolor="#CCCCCC" bordercolor="#FF9900" font-size="180%" />
            <asp:button id="BackButton" text="Back" runat="server" font-bold="True" backcolor="#CCCCCC" bordercolor="#FF9900" font-size="180%" onclick="BackButton_Click" />
        </p>
    </div>
    <div id="editRequestFormMainData">
        <br />
        <br />
        <br />
        <br />
        <p>
            <asp:label id="EmployeeLabel" runat="server" text="Employee:" font-bold="True" font-size="Large" forecolor="white" />
            <div>
                <asp:dropdownlist id="EmployeeDDL" runat="server" width="30%" backcolor="#CCCCCC" />
            </div>
            <asp:label id="ReasonLabel" runat="server" text="Reason For Request:" font-bold="True" font-size="Large" forecolor="white" />
            <div>
                <asp:dropdownlist id="ReasonDDL" runat="server" width="30%" backcolor="#CCCCCC">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Area Access Change</asp:ListItem>
                    <asp:ListItem>Appearance Change</asp:ListItem>
                    <asp:ListItem>Damaged Badge</asp:ListItem>
                    <asp:ListItem>Job Change</asp:ListItem>
                    <asp:ListItem>Lost Badge</asp:ListItem>
                    <asp:ListItem>Name Change</asp:ListItem>
                    <asp:ListItem>New/Changed Clearance</asp:ListItem>
                    <asp:ListItem>New Employee</asp:ListItem>
                    <asp:ListItem>Rebadging Cycle</asp:ListItem>
                    <asp:ListItem>Downgrade</asp:ListItem>
                    <asp:ListItem>HRP</asp:ListItem>
                    <asp:ListItem>LSE/Intern</asp:ListItem>
                </asp:dropdownlist>
                <br />
            </div>
            <div>
                <br />
            </div>
            <asp:label id="getDateLabel" text="G.E.T. Date:" runat="server" font-bold="True" font-size="Large" forecolor="white" />
            <div>
                <asp:textbox id="GetTextBox" columns="20" width="30%" maxlength="25" placeholder="mm/dd/yyyy" runat="server" backcolor="#CCCCCC" />
            </div>
            <br />
            <asp:label id="SSNLabel" text="SSN:" runat="server" font-bold="True" font-size="Large" forecolor="white" />
            <div>
                <asp:textbox id="SSNTextBox" columns="20" width="30%" maxlength="25" placeholder="XXX-XX-XXXX" runat="server" backcolor="#CCCCCC" />

            </div>
            <br />
            <asp:label id="DOBLabel" text="Date of Birth:" runat="server" font-bold="True" font-size="Large" forecolor="white" />
            <div>
                <asp:textbox id="DOBTextBox" width="30%" columns="20" maxlength="25" placeholder="mm/dd/yyyy" runat="server" backcolor="#CCCCCC" />
            </div>
            <br />
            <asp:label id="BadgeTypeLabel" text="Type of Badge:" runat="server" font-bold="True" font-size="Large" forecolor="white" />
            <div>
                <asp:dropdownlist id="BadgeTypeDDL" runat="server" width="30%" backcolor="#CCCCCC">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>L</asp:ListItem>
                    <asp:ListItem>Q</asp:ListItem>
                    <asp:ListItem>Uncleared</asp:ListItem>
                </asp:dropdownlist>
            </div>
        </p>
    </div>
    <div id="editRequestFormCheckBoxData">
        <br />
        <br />
        <asp:label id="ProximityCardLabel" text="Proximity Card?" runat="server" font-bold="True" font-size="Large" forecolor="white" />
        <div>
            <asp:checkbox id="ProximityCheckBox" runat="server" />
        </div>
        <br />
        <asp:label id="EmergencyLabel" text="Emergency Access?" runat="server" font-bold="True" font-size="Large" forecolor="white" />
        <div>
            <asp:checkbox id="EmergencyCheckBox" runat="server" />
        </div>
        <br />
        <asp:label id="ComputerAccountsLabel" text="Contunue Previous Computer Accounts?" runat="server" font-bold="True" font-size="Large" forecolor="white" />
        <div>
            <asp:checkbox id="AccountsCheckBox" runat="server" />
        </div>
        <br />
        <asp:label id="NotesLabel" text="Additional Information:" runat="server" font-bold="True" font-size="Large" forecolor="white" />

        <asp:textbox id="NotesTextBox" columns="20" placeholder="Maximum of 500 characters" maxlength="500" runat="server" height="35%" textmode="MultiLine" width="100%" backcolor="#CCCCCC" />


    </div>

    <div id="editRequestFormTopRightText">
        <img alt="Savannah River Site Logo" class="auto-style1" src="Images/srslogo52818.png" id="testPic" width="80%" height="75%" /><br />
        <asp:label id="Label1" runat="server" font-bold="True" font-size="XX-Large" forecolor="#FF9900" text="Manager Review Form"></asp:label>

    </div>


    <asp:textbox id="requestIDTxtBx" runat="server" readonly="True" visible="False"></asp:textbox>
</form>
</html>
