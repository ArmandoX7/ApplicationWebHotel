<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmAgregarEmpleado.aspx.cs" Inherits="AplicacionWebHotel.Vista.Gerente.frmAgregarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/index.css" rel="stylesheet" />
    <link href="../../Css/nav.css" rel="stylesheet" />
    <link href="../../Css/template.css" rel="stylesheet" />
    <link href="../../Css/header.css" rel="stylesheet" />    
    <link href="../../Css/footer.css" rel="stylesheet" />
    <link href="../../Css/form.css" rel="stylesheet" />
     <link href="../../Recursos/Librerias/Jquery/jquery-ui.css" rel="stylesheet" />
    <script src="../../Recursos/Librerias/Jquery/external/jquery/jquery.js"></script>
    <script src="../../Recursos/Librerias/Jquery/jquery-ui.js"></script>
    <script src="../../Js/funciones.js"></script>
    <script src="../../Js/Ajax3.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">


    
        <table align="center" class="auto-style1">
            <tr>
                <td colspan="2" style="text-align: center">AGREGAR EMPLEADO</td>
            </tr>
            <tr>
                <td class="auto-style2">Identificación:</td>
                <td>
                    <asp:TextBox ID="txtIdentificacion" runat="server" Width="268px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Nombre Completo</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtNombre" runat="server" Width="268px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Correo:</td>
                <td>
                    <asp:TextBox ID="txtCorreo" runat="server" Width="270px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Cargo:</td>
                <td>
                    <asp:DropDownList ID="cbCargo" runat="server" Height="30px" Width="276px">
                        <asp:ListItem>Gerente</asp:ListItem>
                        <asp:ListItem>Recepcionista</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Foto:</td>
                <td>
                    <asp:FileUpload ID="fileFoto" runat="server" Width="279px" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                </td>
            </tr>
        </table>
    
  
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
   </asp:Content>
