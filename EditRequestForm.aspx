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
        <asp:DropDownList ID="EmployeeDDL" runat="server" Width="125px" />
        </div>
        <asp:Label ID="ReasonLabel" runat="server" Text="Reason For Request:" />
        <div>
            <asp:DropDownList ID="ReasonDDL" runat="server" Width="125px" />
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
            <asp:DropDownList ID="BadgeTypeDDL" runat="server" Width="125px" />
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
        <asp:Button ID="SaveButton" Text="Cancel" runat="server" />
        <asp:Button ID="SubmmitButton" Text="Submit" runat="server" OnClick="SubmmitButton_Click" />
            
             



        
    </div>
    </form>
</body>
</html>
