<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRequestForm.aspx.cs" Inherits="EditRequestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="EditRequest" runat="server">
    <div>
        <br />

         <Center>
           <asp:Label ID="RequestLabel" runat="server" text="Request Form"  Font-Bold="True" Font-Size="23pt" />
             </Center>
        <div>
            <br />
            <br />
        </div>
        <asp:Label ID="EmployeeLabel" runat="server" Text="Employee:" />
        <div>
        <asp:DropDownList ID="EmployeeDDL" runat="server" Width="125px" DataSourceID="SqlDataSource1" DataTextField="Last_Name" DataValueField="Last_Name" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:badge_requestConnectionString %>" SelectCommand="SELECT [First Name] + [Middle Name] + [Last Name] AS Last_Name FROM [Employees]"></asp:SqlDataSource>
        </div>
        <asp:Label ID="ReasonLabel" runat="server" Text="Reason For Request:" />
        <div>
            <asp:DropDownList ID="ReasonDDL" runat="server" Width="125px" >
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
        </div>
        <div>
            <br />
        </div>
        <asp:Label ID="getDateLabel" Text="G.E.T. Date:" runat="server" />
        <div>
            <asp:TextBox ID="GetTextBox" columns="20" MaxLength="25" Placeholder="mm/dd/yyyy" runat="server"  />
        </div>
        <br />
        <asp:Label ID="SSNLabel" Text ="SSN:" runat="server" />
        <div>
            <asp:TextBox ID="SSNTextBox" Columns="20" MaxLength="25" placeholder="XXX-XX-XXXX" runat="server"  />

        </div>
        <br />
        <asp:Label ID="DOBLabel" Text="Date of Birth:" runat="server" />
        <div>
            <asp:TextBox ID="DOBTextBox" Columns="20" MaxLength="25" placeholder="mm/dd/yyyy" runat="server" />
        </div>
        <br />
        <asp:Label ID="BadgeTypeLabel" Text="Type of Badge:" runat="server" />
        <div>
            <asp:DropDownList ID="BadgeTypeDDL" runat="server" Width="125px" >
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>L</asp:ListItem>
                <asp:ListItem>Q</asp:ListItem>
                <asp:ListItem>Uncleared</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <asp:Label ID="ProximityCardLabel" Text="Proximity Card?" runat="server" />
        <div>
            <asp:CheckBox ID="ProximityCheckBox" runat="server" />
        </div>
        <br />
        <asp:Label ID="EmergencyLabel" Text="Emergency Access?" runat="server" />
        <div>
            <asp:CheckBox ID="EmergencyCheckBox" runat="server" />
        </div>
        <br />
        <asp:Label ID="ComputerAccountsLabel" Text ="Contunue Previous Computer Accounts?" runat="server" />
        <div>
            <asp:CheckBox ID="AccountsCheckBox" runat="server" />
        </div> 
        <br />
        <asp:Label ID="NotesLabel" Text="Notes:(max 500 char)" runat="server" />
        <div>
                <asp:TextBox ID="NotesTextBox" Columns ="20" MaxLength="500" runat="server" Height="200px" TextMode="MultiLine" Width="400px" />
        </div>
        <asp:Button ID="CancelButton" text="Cancel" runat="server" />
        <asp:Button ID="SaveButton" Text="Save Draft" runat="server" />
        <asp:Button ID="SubmmitButton" Text="Submit" runat="server" OnClick="SubmmitButton_Click" />
            
             



        
    </div>
    </form>
</body>
</html>
