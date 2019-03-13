<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasProfesor.aspx.cs" Inherits="Inicio.TareasProfesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 494px">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-SalaberriaConnectionString %>" SelectCommand="SELECT GruposClase.codigoasig FROM GruposClase, ProfesoresGrupo WHERE ProfesoresGrupo.email = @param1 AND GruposClase.codigo = ProfesoresGrupo.codigogrupo">
                <SelectParameters>
                    <asp:SessionParameter Name="param1" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig">
            </asp:DropDownList>
            <br />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS18-SalaberriaConnectionString %>" DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea]) VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea)" SelectCommand="SELECT [Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea] FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea WHERE [Codigo] = @Codigo">
                <DeleteParameters>
                    <asp:Parameter Name="Codigo" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Codigo" Type="String" />
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="CodAsig" Type="String" />
                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                    <asp:Parameter Name="Explotacion" Type="Boolean" />
                    <asp:Parameter Name="TipoTarea" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="CodAsig" Type="String" />
                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                    <asp:Parameter Name="Explotacion" Type="Boolean" />
                    <asp:Parameter Name="TipoTarea" Type="String" />
                    <asp:Parameter Name="Codigo" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insertar nueva tarea" Width="243px" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="SqlDataSource2" style="margin-right: 6px">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                    <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                    <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                    <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
