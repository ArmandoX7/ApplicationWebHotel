<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaPrincipal.Master" AutoEventWireup="true" CodeBehind="frmInicioSesion.aspx.cs" Inherits="AplicacionWebHotel.Vista.frmInicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 60%;
        }
        .auto-style2 {
            width: 264px;
        }
        .auto-style3 {
            width: 264px;
            height: 32px;
        }
        .auto-style4 {
            height: 32px;
        }
    </style>

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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">

    <table align="center" class="auto-style1">
        <tr>
            <td colspan="2" style="text-align: center">INICIAR SESIÓN</td>
        </tr>
        <tr>
            <td class="auto-style2">Usuario:</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="300px" required="required" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Password:</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtPassword" runat="server" Width="300px" required="required" TextMode="Password" Height="22px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnIniciarSesion" runat="server" Text="Ingresar" />
            </td>
        </tr>
    </table>

</asp:Content>
