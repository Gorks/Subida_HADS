<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="Inicio.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 475px">
            <div style="width: 296px; height: 152px;">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="TareasProfesor.aspx">Tareas</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/PROFESOR/Importar.aspx">Importar</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/PROFESOR/Exportar.aspx">Exportar</asp:HyperLink>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
            </div>
            <div style="border: thin solid #000000; height: 77px; margin-left: 365px; background-color: #FFFF00;">
                GESTIÓN WEB DE TAREAS Y DEDICACIÓN&nbsp;&nbsp;<br />
                <br />
                PROFESOR<br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <br />
&nbsp;
                <br />
            </div>
            
        </div>
        <div style="height: 322px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="Label2" runat="server" Text="Usuarios Logueados:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Profesores"></asp:Label>
                    &nbsp;
                    <asp:Label ID="LabelProfesores" runat="server" Text="Label"></asp:Label>
                    &nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Alumnos"></asp:Label>
                    &nbsp;
                    <asp:Label ID="LabelAlumnos" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:ListBox ID="ListBoxProfesores" runat="server"></asp:ListBox>
                    <asp:ListBox ID="ListBoxAlumnos" runat="server"></asp:ListBox>
                    <asp:Timer ID="Timer1" runat="server" Interval="2000">
                    </asp:Timer>
                    <br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <br />
        <div style="width: 919px">
            <asp:Button ID="Button2" runat="server" Text="Cerrar sesión" OnClick="Button2_Click" />
        </div>
        </div>
    </form>
</body>
</html>
