<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="success.aspx.cs" Inherits="ADClient.success" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#00CC66">
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="ВІТАЄМО ВАС, КОРИСТУВАЧ " 
            Font-Size="X-Large"></asp:Label><br />
        <asp:Button ID="Button1" runat="server" Text="Exit" Font-Size="Large" 
            onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
