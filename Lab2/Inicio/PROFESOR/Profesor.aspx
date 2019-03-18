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
            <div style="width: 296px; height: 125px;">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="TareasProfesor.aspx">Tareas</asp:HyperLink>
                <br />
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
            </div>
            
        </div>
        <div>
            <asp:Button ID="Button2" runat="server" Text="Cerrar sesión" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
