<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SRS-Badge Request</title>
    <link rel="stylesheet" type="text/css" href="style.css" />

</head>
<body>
    <form id="form1" runat="server">
        <p>

            <div id="overtop">
                <p></p>
            </div>
            <div id="overbottom">
                <p>
                    <br></br>
                    SRS - Badge Request System: Augusta University Senior Capstone Project
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
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />

                <br />
                <br />
                <asp:Label ID="ErrorMessage" runat="server" Text="Sorry but something went very wrong." Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" Text="This is really embarassing. How about we just start over?" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Start Over" BorderStyle="Solid" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" Width="25%" OnClick="Button1_Click" />
            </div>
    </form>
</body>
</html>
