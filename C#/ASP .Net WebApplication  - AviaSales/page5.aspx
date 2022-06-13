<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page5.aspx.cs" Inherits="SPS_Lab5.page5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#33ccbb;">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="<b>ІСНУЮЧІ ЗАМОВЛЕННЯ" ForeColor="Black"></asp:Label>
        <div id="div" onmousemove="hide_div()">
            <script type="text/javascript">
                function hide_div() {
                    if (document.getElementById('Label1').style.color != 'black') {
                        document.getElementById('div').style.display = 'none';
                    }
                }
            </script>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource" BackColor="White" BorderColor="Black" BorderStyle="Double" >
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Mail" HeaderText="Mail" SortExpression="Mail" />
                    <asp:BoundField DataField="Passport" HeaderText="Passport" SortExpression="Passport" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="Auto" HeaderText="Auto" SortExpression="Auto" />
                    <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                    <asp:BoundField DataField="FinishDate" HeaderText="FinishDate" SortExpression="FinishDate" />
                    <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" />
                    <asp:BoundField DataField="Cost" HeaderText="Cost" SortExpression="Cost" />
                    <asp:BoundField DataField="OrderNumber" HeaderText="OrderNumber" SortExpression="OrderNumber" />
                    <asp:TemplateField HeaderText="Select">   
                    <ItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true"/>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                </Columns>
            </asp:GridView>
            <asp:Label ID="Label2" runat="server" ForeColor="#FF2000"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:WebRentConnectionString %>" SelectCommand="SELECT * FROM [Auto_Rent] WHERE([Name] = @Name);" ProviderName="<%$ ConnectionStrings:WebRentConnectionString.ProviderName %>">
                <SelectParameters>
                    <asp:QueryStringParameter Name="Name" QueryStringField="Name" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br/>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="True">Припинити</asp:ListItem>
                <asp:ListItem>Продовжити</asp:ListItem>
            </asp:RadioButtonList>&emsp;
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="120px" Visible="false">
                <asp:ListItem>1 день</asp:ListItem>
                <asp:ListItem>3 дні</asp:ListItem>
                <asp:ListItem>1 тиждень</asp:ListItem>
                <asp:ListItem>2 тижні</asp:ListItem>
            </asp:DropDownList>
            <br/>
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
        <asp:Button ID="Button3" runat="server" Text="НА ГОЛОВНУ" Visible="false" OnClick="Button2_Click"/>
    </form>
</body>
</html>
