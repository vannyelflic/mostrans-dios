<%@ Page Language="VB" AutoEventWireup="false" CodeFile="yo.aspx.vb" Inherits="yo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" style="width:200px"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="E" /> &nbsp;
            <asp:Button ID="Button2" runat="server" Text="D" /><br />
            <asp:TextBox ID="TextBox2" runat="server" style="width:200px"></asp:TextBox>
        </div>

        <label id="myid" runat="server" style="color:white;font-size:4px;width:auto"></label>
    </form>
</body>
</html>
