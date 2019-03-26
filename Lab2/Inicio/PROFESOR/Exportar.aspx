<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exportar.aspx.cs" Inherits="Inicio.PROFESOR.Exportar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Exportar Tareas"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Seleccionar asignatura a exportar:"></asp:Label>
            <br />
            <br />
            <br />
            <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-SalaberriaConnectionString %>" SelectCommand="SELECT GruposClase.codigoasig FROM GruposClase, ProfesoresGrupo WHERE ProfesoresGrupo.email = @param1 AND GruposClase.codigo = ProfesoresGrupo.codigogrupo">
                <SelectParameters>
                    <asp:SessionParameter Name="param1" SessionField="Email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="CodigoTarea" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" />
                    <asp:BoundField DataField="Explotacion" HeaderText="Explotacion" />
                    <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Exportar" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Mensaje error"></asp:Label>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/PROFESOR/Profesor.aspx">Volver a Profesor</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cerrar Sesión" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
