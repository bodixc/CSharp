<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ADClient._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#0099FF">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="User" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="TextBox1" runat="server" Font-Size="Large"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Password" Font-Size="Large"></asp:Label><br />
        <asp:TextBox ID="TextBox2" runat="server" Font-Size="Large" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" Font-Size="Large" /><br />
        <asp:Button ID="Button2" runat="server" Text="Create OU" Font-Size="Large" 
            onclick="Button2_Click"/>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Create 50 Users" 
            Font-Size="Large" onclick="Button3_Click"/>
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
