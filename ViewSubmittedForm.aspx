<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewSubmittedForm.aspx.cs" Inherits="ViewSubmittedForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>

        <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS: You can use this stylesheet to override any Bootstrap styles and/or apply your own styles -->
    <link href="css/custom.css" rel="stylesheet">

</head>
<body bgcolor="aliceblue">

    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand">
                	<span class="glyphicon glyphicon-fire"></span> 
                	 SRS Badge Request System
                </a>
               

        </div></div></nav>
    <div class="jumbotron feature">
		<div class="container">
			<center><h1><span class="glyphicon glyphicon-equalizer"></span>View Submitted Form</h1></center>
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
        <asp:Button ID="editButton" runat="server" Text="Edit" />
        <br />
        <br />
        <br />


    </center>
    </div>
    </form>

            </div></div>
<body bgcolor="aliceblue">
   
</body>
</html>
