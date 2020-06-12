<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaPrincipal.Master" AutoEventWireup="true" CodeBehind="frmAgregarEmpleado2.aspx.cs" Inherits="AplicacionWebHotel.Vista.Gerente.frmAgregarEmpleado2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/estilos.css" rel="stylesheet" />
    <link href="../../Css/footer.css" rel="stylesheet" />
    <link href="../../Css/form.css" rel="stylesheet" />
    <link href="../../Css/header.css" rel="stylesheet" />
    <link href="../../Css/index.css" rel="stylesheet" />
    <link href="../../Css/nav.css" rel="stylesheet" />
    <link href="../../Css/template.css" rel="stylesheet" />
    <script src="../../Recursos/Librerias/jquery/external/jquery/jquery.js"></script>
    <script src="../../Recursos/Librerias/jquery/jquery-ui.js"></script>
    <link href="../../Recursos/Librerias/jquery/jquery-ui.css" rel="stylesheet" />
    <script src="../../Js/funciones.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <table aling="center" class="auto-style1">
            <tr>
                <td colspan="2" style="text-align:center">AGREGAR EMPLEADO</td>
            </tr>
            <tr>
                <td class="auto-style2">Identificacion:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtIdentificacion" runat="server" Width="223px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Nombre Completo</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtNombre" runat="server" Width="228px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Correo</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Cargo</td>
                <td class="auto-style7">
                    <asp:DropDownList ID="cbCargo" runat="server">
                        <asp:ListItem>Gerente</asp:ListItem>
                        <asp:ListItem>Recepcionista</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Foto</td>
                <td class="auto-style7">
                    <asp:FileUpload ID="fileFoto" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</asp:Content>
