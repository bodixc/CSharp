<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SPS_Lab6.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <body background="blue-background-blur.jpg">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="X" ForeColor="White" Font-Size="Large" Font-Names="Imprint MT Shadow"></asp:Label>
            <br/>
            <asp:TextBox ID="TextBox1" runat="server" Height="40px" Width="250px" Font-Size="Large"></asp:TextBox>
            <br/><br/>
            <asp:Label ID="Label2" runat="server" Text="Y" ForeColor="White" Font-Size="Large" Font-Names="Imprint MT Shadow"></asp:Label>
            <br/>
            <asp:TextBox ID="TextBox2" runat="server" Height="40px" Width="250px" Font-Size="Large"></asp:TextBox>
            <br/><br/>
            <asp:Button ID="Button" runat="server" Text="Результат: " ForeColor="Black" Font-Size="Large" Font-Names="Imprint MT Shadow" OnClick="Button_Click"></asp:Button>
            &nbsp;
            <asp:Label ID="Label3" runat="server" Text="" ForeColor="White" Font-Size="X-Large" Font-Names="Imprint MT Shadow"></asp:Label>
            <br/>
        </div>
    </form>
</body>
</html>
