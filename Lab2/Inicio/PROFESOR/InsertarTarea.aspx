<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="Inicio.PROFESOR.InsertarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 445px; width: 580px;">
            <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Asignatura"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-SalaberriaConnectionString %>" SelectCommand="SELECT GruposClase.codigoasig FROM GruposClase, ProfesoresGrupo WHERE ProfesoresGrupo.email = @param1 AND GruposClase.codigo = ProfesoresGrupo.codigogrupo">
                <SelectParameters>
                    <asp:SessionParameter Name="param1" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Horas Estimadas"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Tipo Tarea"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>Laboratorio</asp:ListItem>
                <asp:ListItem>Test</asp:ListItem>
                <asp:ListItem>Examen</asp:ListItem>
                <asp:ListItem>Proyecto</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Añadir tarea" />
            <br />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-SalaberriaConnectionString %>" InsertCommand="INSERT INTO TareasGenericas(Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea) VALUES (@param1, @param2, @param3, @param4, 0, @param5)" SelectCommand="SELECT * From TareasGenericas" OnSelecting="SqlDataSource2_Selecting">
                <InsertParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="param1"  />
                    <asp:ControlParameter ControlID="TextBox2" Name="param2" />
                    <asp:ControlParameter ControlID="DropDownList1" Name="param3"/>
                    <asp:ControlParameter ControlID="TextBox3" Name="param4"  />
                    <asp:ControlParameter ControlID="DropDownList2" Name="param5" />
                </InsertParameters>
            </asp:SqlDataSource>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/PROFESOR/TareasProfesor.aspx">Volver a tareas</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cerrar sesión" />
        </div>
    </form>
</body>
</html>
