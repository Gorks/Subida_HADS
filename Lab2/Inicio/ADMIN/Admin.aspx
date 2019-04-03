<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Inicio.ADMIN.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 459px">
    <form id="form1" runat="server">
        <div style="height: 462px">
            <asp:Label ID="Label1" runat="server" Text="ADMINISTRADOR"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" AutoGenerateEditButton="True" DataKeyNames="email" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="email" HeaderText="email" ReadOnly="True" SortExpression="email" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="apellidos" HeaderText="apellidos" SortExpression="apellidos" />
                    <asp:BoundField DataField="numconfir" HeaderText="numconfir" SortExpression="numconfir" />
                    <asp:CheckBoxField DataField="confirmado" HeaderText="confirmado" SortExpression="confirmado" />
                    <asp:BoundField DataField="tipo" HeaderText="tipo" SortExpression="tipo" />
                    <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass" />
                    <asp:BoundField DataField="codpass" HeaderText="codpass" SortExpression="codpass" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-SalaberriaConnectionString %>" DeleteCommand="DELETE FROM [Usuarios] WHERE [email] = @email" InsertCommand="INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [numconfir], [confirmado], [tipo], [pass], [codpass]) VALUES (@email, @nombre, @apellidos, @numconfir, @confirmado, @tipo, @pass, @codpass)" SelectCommand="SELECT * FROM [Usuarios]" UpdateCommand="UPDATE [Usuarios] SET [nombre] = @nombre, [apellidos] = @apellidos, [numconfir] = @numconfir, [confirmado] = @confirmado, [tipo] = @tipo, [pass] = @pass, [codpass] = @codpass WHERE [email] = @email">
                <DeleteParameters>
                    <asp:Parameter Name="email" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="apellidos" Type="String" />
                    <asp:Parameter Name="numconfir" Type="Int32" />
                    <asp:Parameter Name="confirmado" Type="Boolean" />
                    <asp:Parameter Name="tipo" Type="String" />
                    <asp:Parameter Name="pass" Type="String" />
                    <asp:Parameter Name="codpass" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="nombre" Type="String" />
                    <asp:Parameter Name="apellidos" Type="String" />
                    <asp:Parameter Name="numconfir" Type="Int32" />
                    <asp:Parameter Name="confirmado" Type="Boolean" />
                    <asp:Parameter Name="tipo" Type="String" />
                    <asp:Parameter Name="pass" Type="String" />
                    <asp:Parameter Name="codpass" Type="Int32" />
                    <asp:Parameter Name="email" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cerrar Sesión" />
        </div>
    </form>
</body>
</html>
