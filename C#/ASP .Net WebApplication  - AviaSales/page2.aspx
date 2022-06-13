<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="SPS_Lab5.page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#33ccbb;">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="<b>НОВЕ ЗАМОВЛЕННЯ — КРОК 1" ForeColor="Black"></asp:Label>
        <div id="div" onmousemove="hide_div()">
            <script type="text/javascript">
                function hide_div() {
                    if (document.getElementById('Label1').style.color != 'black') {
                        document.getElementById('div').style.display = 'none';
                    }
                }
            </script>
            <br/>
            <asp:Label ID="Label2" runat="server" Text="Прізвище/Ім’я латиницею:"></asp:Label>
            <br/>
            <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="220px" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
            &emsp;
            <asp:Label ID="Label8" runat="server" ForeColor="#FF2000"></asp:Label>
            <br/>
            <br/>
            <asp:Label ID="Label3" runat="server" Text="ПОСВІДЧЕННЯ ВОДІЯ (JPEG/PNG, min 100x150, max 200x300):"></asp:Label>
            <br/>
            <asp:FileUpload ID="FileUpload1" runat="server" Height="25px" Width="315px" />
            &emsp;
            <asp:Label ID="Label5" runat="server" ForeColor="#FF2000"></asp:Label>
            <br/>
            <br/>
            <asp:Label ID="Label4" runat="server" Text="КЛАС АВТО: &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;МАРКА І МОДЕЛЬ:"></asp:Label>
            <br/>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="140px"  OnSelectedIndexChanged = "DropDownList1_SelectedIndexChanged" AutoPostBack="True" >
                <asp:ListItem>Легковий</asp:ListItem>
                <asp:ListItem>Дрібновантажний</asp:ListItem>
            </asp:DropDownList>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
            <asp:DropDownList ID="DropDownList2" runat="server" Height="25px" Width="190px">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <br/>
            <br/>
            <br/>
            <br/>
            <br/>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="ДАЛІ" Height="40px" Width="100px" OnClick="Button1_Click" OnClientClick = "hide()"/>&emsp;
            <asp:Button ID="Button2" runat="server" Text="НАЗАД" Height="40px" Width="100px" OnClick="Button2_Click" OnClientClick = "hide()"/>
            <script type="text/javascript">
                function hide() {
                    document.getElementById('Button1').style.display = 'none';
                    document.getElementById('Button2').style.display = 'none';
                    }
            </script>
        </div>
        <br/>
        <asp:Button ID="Button3" runat="server" Text="НА ГОЛОВНУ" Height="40px" Width="120px" Visible="False" OnClick="Button3_Click"/>
    </form>
</body>
</html>
