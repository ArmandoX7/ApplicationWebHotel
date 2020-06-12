<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmContactenos.aspx.cs" Inherits="AplicacionWebHotel.Vista.frmContactenos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Css/estilos.css" rel="stylesheet" />
    <link href="../Css/footer.css" rel="stylesheet" />
    <link href="../Css/form.css" rel="stylesheet" />
    <link href="../Css/header.css" rel="stylesheet" />
    <link href="../Css/index.css" rel="stylesheet" />
    <link href="../Css/nav.css" rel="stylesheet" />
    <link href="../Css/template.css" rel="stylesheet" />
    <link href="../Recursos/Librerias/Jquery/jquery-ui.css" rel="stylesheet" />
    <script src="../Recursos/Librerias/Jquery/external/jquery/jquery.js"></script>
    <script src="../Recursos/Librerias/Jquery/jquery-ui.js"></script>
    <script src="../Js/funciones.js"></script>
     <style type="text/css">
         .auto-style1 {
             width: 60%;
         }
         .auto-style2 {
         }
         .auto-style3 {
         }
         .auto-style4 {
             width: 229px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">

    <table align="center" class="auto-style1">
        <tr>
            <td class="auto-style2" colspan="2" style="text-align: center">REGISTRE SU COMENTARIO</td>
        </tr>
        <tr>
            <td class="auto-style4">Nombre:</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="256px" required="required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Correo:</td>
            <td>
                <asp:TextBox ID="txtCorreo" runat="server" Width="256px" TextMode="Email" required="required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Comentario:</td>
            <td>
                <asp:TextBox ID="txtComentario" runat="server" Height="51px" TextMode="MultiLine" Width="258px" required="required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Operación:</td>
            <td>
                <asp:TextBox ID="txtOperacion" runat="server" Enabled="False" Width="256px" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Ingrese Resultado Operación:</td>
            <td>
                <asp:TextBox ID="txtResultado" runat="server" Width="256px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2" style="text-align: center">
                <asp:Button ID="btnRegistrarComentario" runat="server" Text="Registrar" OnClick="btnRegistrarComentario_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblMensaje" runat="server" style="text-align: center"></asp:Label>
    <br />

</asp:Content>
