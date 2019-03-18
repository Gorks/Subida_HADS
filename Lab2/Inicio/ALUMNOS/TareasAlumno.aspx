<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="Inicio.TareasAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 442px">
    <form id="form1" runat="server">
        <div style="margin-left: 25px">
            <br />
            <br />
            <br />
            <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-left: 102px">
                <Columns>
                    <asp:CommandField SelectText="Instanciar" ShowSelectButton="True" />
                    <asp:BoundField DataField="Codigo" HeaderText="Código" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Desc." />
                    <asp:BoundField DataField="HEstimadas" HeaderText="Horas" />
                    <asp:BoundField DataField="TipoTarea" HeaderText="Tipo" />
                </Columns>
            </asp:GridView>
        </div>
                <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ALUMNOS/Alumnos.aspx">Volver a menú</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cerrar sesión" />
        </div>
    </form>
</body>
</html>
