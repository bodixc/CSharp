<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="SPS_Lab5.page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#33ccbb;">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="<b>--------------------------------------------------------------------------------------------
                <br/>
            ОРЕНДУЙТЕ І КАТАЙТЕСЬ З КОМПАНІЄЮ «РАУЛЬ БЕЗ РУЛЯ»
                <br/>
                --------------------------------------------------------------------------------------------
                <br/>
                "></asp:Label><br/><br/>
            <asp:Label ID="Label2" runat="server" Text="Прізвище/Ім’я латиницею:"></asp:Label>
            <br/>
            <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="220px" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
            &emsp;
            <asp:Label ID="Label4" runat="server" ForeColor="#FF2000"></asp:Label>
            <br/>
            <br/>
            <asp:Label ID="Label3" runat="server" Text="Емейл-адреса:"></asp:Label>
            <br/>
            <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="220px" OnTextChanged="TextBox2_TextChanged" AutoPostBack="true"></asp:TextBox>
            &emsp;
            <asp:Label ID="Label5" runat="server" ForeColor="#FF2000"></asp:Label>
            <br/>
            <br/>
            <br/>
            <br/>
            <asp:Button ID="Button1" runat="server" Height="40px" Text="ІСНУЮЧІ ЗАМОВЛЕННЯ" Width="220px" Visible="false" OnClick="Button1_Click" OnClientClick="hide()"/>
            <br/>
            <br/>
            <asp:Button ID="Button2" runat="server" Height="40px" Text="НОВЕ ЗАМОВЛЕННЯ " Width="220px" Visible="false" OnClick="Button2_Click" OnClientClick="hide()"/>
            </div>
            <script type="text/javascript">
                function hide() {
                    document.getElementById('Button1').style.display = 'none';
                    document.getElementById('Button2').style.display = 'none';
                    }
            </script>
    </form>
</body>
</html>
