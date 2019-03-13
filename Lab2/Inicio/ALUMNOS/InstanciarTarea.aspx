<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="Inicio.ALUMNOS.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 490px">
    <form id="form1" runat="server">
        <div style="height: 58px">
            Instanciar Tarea Genérica<br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ALUMNOS/TareasAlumno.aspx">Página anterior</asp:HyperLink>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tarea"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="HorasEst"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Horas Reales"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Requerido insertar" ForeColor="Maroon" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Crear Tarea" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="CodTarea" HeaderText="CodTarea" />
                <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" />
                <asp:BoundField DataField="HReales" HeaderText="HReales" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
