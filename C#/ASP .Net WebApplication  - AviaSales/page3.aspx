<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page3.aspx.cs" Inherits="SPS_Lab5.page3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#33ccbb;">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="<b>НОВЕ ЗАМОВЛЕННЯ — КРОК 2" ForeColor="Black"></asp:Label>
        <div id="div" onmousemove="hide_div()">
            <script type="text/javascript">
                function hide_div() {
                    if (document.getElementById('Label1').style.color != 'black') {
                        document.getElementById('div').style.display = 'none';
                    }
                }
            </script>
            <br/>
            <asp:Label ID="Label2" runat="server" Text="Дата початку оренди:"></asp:Label>
            <br/>
            <br/>
            <asp:Label ID="Label3" runat="server" Text="Число:&emsp;Місяць:&emsp;&emsp;&emsp;Рік:"></asp:Label>
            <br/>
            <asp:TextBox ID="TextBox1" runat="server" Width="45px" OnTextChanged="TextBox_TextChanged" AutoPostBack="True"></asp:TextBox>
            &#160;
            <asp:TextBox ID="TextBox2" runat="server" Width="85px" OnTextChanged="TextBox_TextChanged" AutoPostBack="True"></asp:TextBox>
            &#160;
            <asp:TextBox ID="TextBox3" runat="server" Width="60px" OnTextChanged="TextBox_TextChanged" AutoPostBack="True"></asp:TextBox>
            &emsp;
            <asp:Label ID="Label8" runat="server" ForeColor="#FF2000"></asp:Label>
            <br/>
            <br/>        
            <asp:Label ID="Label4" runat="server" Text="Тривалість:"></asp:Label>
            <br/> 
            <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="120px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem>1 день</asp:ListItem>
                <asp:ListItem>3 дні</asp:ListItem>
                <asp:ListItem>1 тиждень</asp:ListItem>
                <asp:ListItem>2 тижні</asp:ListItem>
            </asp:DropDownList>
            <br/>
            <br/> 
            <asp:Label ID="Label5" runat="server" Text="Дата закінчення оренди:"></asp:Label>
            <br/>
            <br/>
            <asp:Label ID="Label6" runat="server" Text="Число:&emsp;Місяць:&emsp;&emsp;&emsp;Рік:"></asp:Label>
            <br/>
            <asp:TextBox ID="TextBox4" runat="server" Width="45px" ReadOnly="True"></asp:TextBox>
            &#160;
            <asp:TextBox ID="TextBox5" runat="server" Width="85px" ReadOnly="True"></asp:TextBox>
            &#160;
            <asp:TextBox ID="TextBox6" runat="server" Width="60px" ReadOnly="True"></asp:TextBox>
            <br/>
            <br/> 
            <asp:Label ID="Label7" runat="server" Text="Вартість замовлення: " Font-Size="Large"></asp:Label>
            <br/>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="ДАЛІ" Height="40px" Width="100px" OnClick="Button1_Click" OnClientClick="hide()"/>&emsp;
            <asp:Button ID="Button2" runat="server" Text="НАЗАД" Height="40px" Width="100px" OnClick="Button2_Click" OnClientClick="hide()"/>
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
