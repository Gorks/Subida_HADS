<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Importar.aspx.cs" Inherits="Inicio.PROFESOR.Importar" %>

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
            <asp:Label ID="Label1" runat="server" Text="Importar asignatura"></asp:Label>
            <br />
            <br />
            <br />
            <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-SalaberriaConnectionString %>" SelectCommand="SELECT GruposClase.codigoasig FROM GruposClase, ProfesoresGrupo WHERE ProfesoresGrupo.email = @param1 AND GruposClase.codigo = ProfesoresGrupo.codigogrupo">
                <SelectParameters>
                    <asp:SessionParameter Name="param1" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="IMPORTAR" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="ERROR" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/PROFESOR/Profesor.aspx">Volver a Profesor</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cerrar Sesión" />
&nbsp;&nbsp;
            <br />
            <br />
        </div>
    </form>
</body>
</html>
