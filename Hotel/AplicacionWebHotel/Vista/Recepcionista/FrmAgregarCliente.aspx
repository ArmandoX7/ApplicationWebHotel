<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Vista/paginaMaestra.Master" CodeBehind="FrmAgregarCliente.aspx.cs" Inherits="AplicacionWebHotel.Vista.Recepcionista.FrmAgregarCliente" %>
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
               
                <td colspan="2" style="text-align: center">AGREGAR CLIENTE</td>
                  </>
            </tr>
            <tr>
                <td class="auto-style2">Identificacion</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtIdentificacion" runat="server" Width="256px" TextMode="Number" Required="required"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Nombre</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtNombre" runat="server" Width="256px" Required="required"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Correo</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtCorreo" runat="server" Width="256px" Required="required" TextMode="Email"></asp:TextBox>
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