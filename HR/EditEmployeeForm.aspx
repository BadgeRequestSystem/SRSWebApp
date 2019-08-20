<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditEmployeeForm.aspx.cs" Inherits="EditEmployeeForm" %>

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
            <div id="editRequestFormBottomButtons">
                <p>
                    <asp:button id="CancelButton" text="Back" runat="server" onclick="CancelButton_Click" font-bold="True" backcolor="#CCCCCC" bordercolor="#FF9900" font-size="180%" />
                    <asp:button id="SubmmitButton" text="Save" runat="server" onclick="SubmmitButton_Click" font-bold="True" backcolor="#CCCCCC" bordercolor="#FF9900" font-size="180%" />
                </p>
            </div>

        </p>
    </div>
    <div id="editRequestFormMainData">
        <br /><br /><br /><br />
        <asp:label id="Label1" runat="server" text="First Name" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox1" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>

        <br /><br /><br />
        <asp:label id="Label2" runat="server" text="Middle Name" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox2" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>

        <br /><br /><br />
        <asp:label id="Label3" runat="server" text="Last Name" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox3" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>

        <br /><br /><br />
        <asp:label id="Label4" runat="server" text="Initials" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox4" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>

        <br /><br /><br />
        <asp:label id="Label12" runat="server" text="UserID" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox5" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>

        <br /><br /><br />

        <asp:label id="Label7" runat="server" text="Work Location" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox8" runat="server" width="30%" backcolor="#CCCCCC" ontextchanged="TextBox8_TextChanged"></asp:textbox>

        <br /><br /><br />
        <asp:label id="Label8" runat="server" text="Work Phone" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox9" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>

    </div>
    <div id="editRequestFormCheckBoxData">
        <br /><br />
        <asp:label id="Label5" runat="server" text="Employee Company" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox6" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>

        <br /><br /><br />
        <asp:label id="Label6" runat="server" text="Department" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox7" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>

        <br /><br /><br />
        <asp:label id="EmployeeLabel" runat="server" text="Employee Manager:" font-bold="True" font-size="Large" forecolor="white" />

        <asp:dropdownlist id="EmployeeDDL" runat="server" width="30%" appenddatabounditems="True" onload="EmployeeDDL_Load" backcolor="#CCCCCC" />

        <br />
        <br /><br /><br />
        <asp:label id="Label9" runat="server" text="Manager Work Location" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox10" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>
        <br />
        <br /><br /><br />
        <asp:label id="Label10" runat="server" text="Manager Work Phone" font-bold="True" font-size="Large" forecolor="white"></asp:label>

        <asp:textbox id="TextBox11" runat="server" width="30%" backcolor="#CCCCCC"></asp:textbox>

    </div>
    <div id="editRequestFormTopRightText">
        <img alt="Savannah River Site Logo" class="auto-style1" src="Images/srslogo52818.png" id="testPic" width="80%" height="75%" /><br />
        <asp:label id="Label11" runat="server" font-bold="True" font-size="XX-Large" forecolor="#FF9900" text="Edit Employees"></asp:label>

    </div>


</form>
</html>
