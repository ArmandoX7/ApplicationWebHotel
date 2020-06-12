<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmActualizarDescripcion.aspx.cs" Inherits="AplicacionWebHotel.Vista.Gerente.frmActualizarDescripcion" %>
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
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">

    <table align="center" class="auto-style1">
        <tr>
            <td colspan="2" style="text-align: center">ACTUALIZAR DESCRIPCIÓN HABITACIÓN</td>
        </tr>
        <tr>
            <td style="width:30%">Habitación:</td>
            <td style="width:70%">
                <asp:TextBox ID="txtNHabita" runat="server" Width="266px" TextMode="Number" required="required"></asp:TextBox>
                <div id="mensaje"></div>
            </td>
        </tr>
        <tr>
            <td>Descripción:</td>
            <td>
                <asp:TextBox ID="txtDHabita" runat="server" Rows="10" TextMode="MultiLine" Width="264px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            </td>
        </tr>
    </table>
    <br />
    <p style="text-align:center">
        <asp:Label ID="lblMensaje" runat="server">           
        </asp:Label>
    </p>
</asp:Content>
