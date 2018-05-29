<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRequestForm.aspx.cs" Inherits="EditRequestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="EditRequest" runat="server">

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
            <p>
                <asp:Label ID="viewSubmittedFlagLabel" runat="server" Text="viewSubmittedFlag1" Visible="False"></asp:Label>
            </p>
        </div>
        <div id="overleft">
            <p></p>
        </div>
        <div id="overmiddle">
            <p></p>
        </div>
        <div id="editRequestFormBottomButtons">
            <asp:Button ID="CancelButton" Text="Cancel" runat="server" OnClick="CancelButton_Click"  Font-Bold="True" BorderColor="#FF9900" Font-Size="150%" />
            <asp:Button ID="SaveButton" Text="Save Draft" runat="server" OnClick="SaveButton_Click"  Font-Bold="True" BorderColor="#FF9900" Font-Size="150%" />
            <asp:Button ID="SubmmitButton" Text="Submit" runat="server" OnClick="SubmmitButton_Click" Font-Bold="True" BorderColor="#FF9900" Font-Size="150%" />
        </div>

        <div id="editRequestFormMainData">
            <br /><br /><br /><br /><br /><br /><br />
            <asp:Label ID="EmployeeLabel" runat="server" Text="Employee:" Font-Bold="True" Font-Size="150%" ForeColor="White" />

            <asp:DropDownList ID="EmployeeDDL" runat="server" Width="30%" BackColor="#CCCCCC" style="text-align: center" /><br />
            <br />
            <br />

            <asp:Label ID="ReasonLabel" runat="server" Text="Reason For Request:" Font-Bold="True" Font-Size="150%" ForeColor="White" />

            <asp:DropDownList ID="ReasonDDL" runat="server" Width="30%" BackColor="#CCCCCC" style="text-align: center">
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
            </asp:DropDownList>
            <br />
            <br />

            <asp:Label ID="getDateLabel" Text="G.E.T. Date:" runat="server" Font-Bold="True" Font-Size="150%" ForeColor="White" />

            <asp:TextBox ID="GetTextBox" Columns="20" MaxLength="25" Placeholder="mm/dd/yyyy" runat="server" BackColor="#CCCCCC" Width="30%" style="text-align: center" /><br />
            <br />
            <br />

            <asp:Label ID="SSNLabel" Text="SSN:" runat="server" Font-Bold="True" Font-Size="150%" ForeColor="White" />

            <asp:TextBox ID="SSNTextBox" Columns="20" MaxLength="25" placeholder="XXX-XX-XXXX" runat="server" BackColor="#CCCCCC" Width="30%" style="text-align: center" /><br />
            <br />
            <br />

            <asp:Label ID="DOBLabel" Text="Date of Birth:" runat="server" Font-Bold="True" Font-Size="150%" ForeColor="White" />

            <asp:TextBox ID="DOBTextBox" Columns="20" MaxLength="25" placeholder="mm/dd/yyyy" runat="server" BackColor="#CCCCCC" Width="30%" style="text-align: center" /><br />
            <br />
            <br />

            <asp:Label ID="BadgeTypeLabel" Text="Type of Badge:" runat="server" Font-Bold="True" Font-Size="150%" ForeColor="White" />

            <asp:DropDownList ID="BadgeTypeDDL" runat="server" Width="30%" BackColor="#CCCCCC" style="text-align: center" >
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>L</asp:ListItem>
                <asp:ListItem>Q</asp:ListItem>
                <asp:ListItem>Uncleared</asp:ListItem>
            </asp:DropDownList>

        </div>

        <div id="editRequestFormCheckBoxData">
            <br />
            <br />
            <asp:Label ID="ProximityCardLabel" Text="Proximity Card?" runat="server" Font-Bold="True" Font-Size="150%" ForeColor="White" />

            <asp:CheckBox ID="ProximityCheckBox" runat="server" /><br />
            <br />
            <br />

            <asp:Label ID="EmergencyLabel" Text="Emergency Access?" runat="server" Font-Bold="True" Font-Size="150%" ForeColor="White" />

            <asp:CheckBox ID="EmergencyCheckBox" runat="server" /><br />
            <br />
            <br />

            <asp:Label ID="ComputerAccountsLabel" Text="Continue Previous Computer Accounts?" runat="server" Font-Bold="True" Font-Size="150%" ForeColor="White" />

            <asp:CheckBox ID="AccountsCheckBox" runat="server" /><br />
            <br />
            <br />

            <asp:Label ID="NotesLabel" Text="Notes:" runat="server" Font-Bold="True" Font-Size="150%" ForeColor="White" /><br />

            <asp:TextBox ID="NotesTextBox" Columns="20" MaxLength="500" runat="server" placeholder="Maximum of 500 characters" Height="35%" TextMode="MultiLine" Width="100%" BackColor="#CCCCCC" />

        </div>

        <div id="editRequestFormTopRightText">
            <img alt="Savannah River Site Logo" class="auto-style1" src="Images/srslogo52818.png" id="testPic" width="80%" height="75%" /><br />
            <asp:Label ID="Label1" runat="server" Text="Edit Request Form" Font-Bold="True" Font-Size="250%" ForeColor="#FF9900"></asp:Label>

        </div>

    </form>
    <script type="text/javascript" src="jquery-2.2.2.min.js"></script>
    <script type="text/javascript" src="JS.js"></script>
</body>
</html>
