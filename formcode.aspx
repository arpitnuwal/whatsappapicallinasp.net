<%@ Page Language="C#" AutoEventWireup="true" CodeFile="formcode.aspx.cs" Inherits="formcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div>
            <asp:Image ID="imgQR" runat="server" Width="250" Height="250" />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            <br /><br />

            <asp:TextBox ID="txtNumber" runat="server" Placeholder="Enter number"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5" Columns="40" Placeholder="Type message"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
            <br /><br />
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
