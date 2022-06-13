<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page7.aspx.cs" Inherits="SPS_Lab5.page7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#33ccbb;">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="<b>ЗВІТ ПРО " ForeColor="Black"></asp:Label>
        <div id="div" onmousemove="hide_div()">
            <script type="text/javascript">
                function hide_div() {
                    if (document.getElementById('Label1').style.color != 'black') {
                        document.getElementById('div').style.display = 'none';
                    }
                }
            </script>
            <br/>
            <asp:Table ID="Table1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Double" GridLines="Both">
                <asp:TableRow ID="TR0" runat="server">
                    <asp:TableCell runat="server">Замовлення</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TR1" runat="server">
                    <asp:TableCell runat="server">Тривалість</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TR2" runat="server">
                    <asp:TableCell runat="server">Дата закінчення</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TR3" runat="server">
                    <asp:TableCell runat="server">Вартість</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br/>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br/>
            <script type="text/javascript">
                function hide() {
                    document.getElementById('Button1').style.display = 'none';
                }
            </script>
        </div>
        <br/>
        <asp:Button ID="Button1" runat="server" Text="НА ГОЛОВНУ" OnClick="Button1_Click"/>
    </form>
</body>
</html>
