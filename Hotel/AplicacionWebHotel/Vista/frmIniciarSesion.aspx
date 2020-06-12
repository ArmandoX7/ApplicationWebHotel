<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmIniciarSesion.aspx.cs" Inherits="AplicacionWebHotel.Vista.frmIniciarSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/index.css" rel="stylesheet" />
    <link href="../Css/nav.css" rel="stylesheet" />
    <link href="../Css/template.css" rel="stylesheet" />
    <link href="../Css/header.css" rel="stylesheet" />    
    <link href="../Css/footer.css" rel="stylesheet" />
    <link href="../Css/form.css" rel="stylesheet" />
    <link href="../Recursos/Librerias/Jquery/jquery-ui.css" rel="stylesheet" />
    <script src="../Recursos/Librerias/Jquery/external/jquery/jquery.js"></script>
    <script src="../Recursos/Librerias/Jquery/jquery-ui.js"></script>
    <script src="../Js/funciones.js"></script>
    
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <div id="inicioSesion">
        <table align="center">
            <tr>
                <td colspan="2" style="text-align: center">INICIO DE SESIÓN</td>
            </tr>
            <tr>
                <td>Usuario:</td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" required="required"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contraseña:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="required"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar" OnClick="btnIniciarSesion_Click" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <p style="text-align:center">
        <asp:Label ID="lblMensaje" runat="server">           
        </asp:Label>
    </p>
</asp:Content>
