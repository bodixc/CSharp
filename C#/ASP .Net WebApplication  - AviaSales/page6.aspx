<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page6.aspx.cs" Inherits="SPS_Lab5.page6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#33ccbb;">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="<b>Підтвердження " ForeColor="Black"></asp:Label>
        <div id="div" onmousemove="hide_div()">
            <script type="text/javascript">
                function hide_div() {
                    if (document.getElementById('Label1').style.color != 'black') {
                        document.getElementById('div').style.display = 'none';
                    }
                }
            </script>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="" Height="40px" Width="140px" OnClick="Button1_Click"/>&emsp;
            <script type="text/javascript">
                function hide() {
                    document.getElementById('Button1').style.display = 'none';
                    document.getElementById('Button2').style.display = 'none';
                }
            </script>
            <asp:Button ID="Button2" runat="server" Text="НАЗАД" Height="40px" Width="100px" OnClick="Button2_Click"/>
        </div>
        <br/>
        <asp:Button ID="Button3" runat="server" Text="НА ГОЛОВНУ" Visible="false" OnClick="Button3_Click"/>
        <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="" Visible="false"></asp:Label>
    </form>
</body>
</html>
