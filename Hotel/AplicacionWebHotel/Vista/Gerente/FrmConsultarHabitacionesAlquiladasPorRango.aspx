<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="FrmConsultarHabitacionesAlquiladasPorRango.aspx.cs" Inherits="AplicacionWebHotel.Vista.Gerente.FrmConsultarHabitacionesAlquiladasPorRango" %>
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
    <style type="text/css">
        .auto-style1 {
            width: 70%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">
    <table align="center" class="auto-style1">
        <tr>
            <td>Fecha Inicial:</td>
            <td>
                <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox>
            </td>
            <td>Fecha Final:</td>
            <td>
                <asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
            </td>
        </tr>
    </table>
    <br />
    <p style="text-align: center">
    <asp:GridView ID="tablaHabitaciones" runat="server"></asp:GridView>
    </p>
</asp:Content>
