<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Coordinador.aspx.cs" Inherits="Inicio.COORDINADOR.Coordinador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-SalaberriaConnectionString %>" SelectCommand="SELECT * FROM [Asignaturas]"></asp:SqlDataSource>
       

            <br />
            <asp:Label ID="Label1" runat="server" Text="Tiempo medio de la asignatura seleccionada:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
            <br />
       
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/PROFESOR/Profesor.aspx">Volver a Profesor</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cerrar Sesión" />
        </div>
    </form>
</body>
</html>
