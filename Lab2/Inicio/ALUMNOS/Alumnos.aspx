<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="Inicio.Alumnos" %>

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
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="TareasAlumno.aspx">Tareas</asp:HyperLink>
                <br />
                <br />
            </div>
            <div style="border: thin solid #000000; height: 77px; margin-left: 365px; background-color: #FFFF00;">
                GESTIÓN WEB DE TAREAS Y DEDICACIÓN&nbsp;&nbsp;<br />
                <br />
                ALUMNO<br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <br />
&nbsp;
            </div>
            
        </div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                <div style="height: 156px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label2" runat="server" Text="Usuarios Logueados:"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="Profesores"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="LabelProfesores" runat="server" Text="Label"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label4" runat="server" Text="Alumnos"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:Label ID="LabelAlumnos" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:ListBox ID="ListBoxProfesores" runat="server"></asp:ListBox>
                            <asp:ListBox ID="ListBoxAlumnos" runat="server"></asp:ListBox>
                            <br />
                            <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick">
                            </asp:Timer>
                            <br />
                            <br />
                            <br />
                        </ContentTemplate>

                    </asp:UpdatePanel>

&nbsp;&nbsp;
            &nbsp;
            &nbsp;&nbsp;
            &nbsp;&nbsp;
            <br />
&nbsp;
                <div style="width: 895px">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cerrar sesión" />
                    <br />
        </div>

        </div>
    </form>
</body>
</html>
