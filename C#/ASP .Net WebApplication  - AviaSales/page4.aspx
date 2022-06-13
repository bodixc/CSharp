<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page4.aspx.cs" Inherits="SPS_Lab5.page4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#33ccbb;">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="<b>ЗВІТ ПРО ОФОРМЛЕННЯ ЗАМОВЛЕННЯ" ForeColor="Black"></asp:Label>
        <div id="div" onmousemove="hide_div()">
            <script type="text/javascript">
                function hide_div() {
                    if (document.getElementById('Label1').style.color != 'black') {
                        document.getElementById('div').style.display = 'none';
                    }
                }
            </script>
            <br/>
            &emsp;
            <asp:Label ID="Label2" runat="server" Width="425px" Text="Деталі замовлення:"></asp:Label>
            <br/>
            <asp:Table ID="Table1" runat="server" GridLines="Both" Height="345px" Width="320px" BackColor="White" BorderColor="Black" BorderStyle="Double">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Прізвище Ім'я</asp:TableCell>
                    <asp:TableCell ID="TC0" runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Ел. пошта</asp:TableCell>
                    <asp:TableCell ID="TC1" runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Посвідчення водія</asp:TableCell>
                    <asp:TableCell ID="TC2" runat="server"><asp:Image ID="Img" runat="server"></asp:Image></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Тип автомобіля</asp:TableCell>
                    <asp:TableCell ID="TC3" runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Автомобіль</asp:TableCell>
                    <asp:TableCell ID="TC4" runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Початок аренди</asp:TableCell>
                    <asp:TableCell ID="TC5" runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Кінець аренди</asp:TableCell>
                    <asp:TableCell ID="TC6" runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Тривалість аренди</asp:TableCell>
                    <asp:TableCell ID="TC7" runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Вартість</asp:TableCell>
                    <asp:TableCell ID="TC8" runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Номер замовлення</asp:TableCell>
                    <asp:TableCell ID="TC9" runat="server"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br/>
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br/>
        </div>
        <br/>
        <asp:Button ID="Button1" runat="server" Text="НА ГОЛОВНУ" OnClick="Button1_Click"/>
    </form>
</body>
</html>
