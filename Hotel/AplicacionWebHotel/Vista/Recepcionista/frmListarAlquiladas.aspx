<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmListarAlquiladas.aspx.cs" Inherits="AplicacionWebHotel.Vista.Recepcionista.frmListarAlquiladas" ValidateRequest = "false" %>
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
   
    <h3 style="text-align:center">LISTA DE HABITACIONES QUE SE ENCUENTRAN ALQUILADAS </h3>
    <br />
    <asp:HiddenField ID="grillaOculta" runat="server" />
    <asp:GridView ID="tablaAlquiladas" runat="server" HorizontalAlign="Center">
        <HeaderStyle BackColor="#CCFFFF" />
    </asp:GridView>
    <p style="text-align: center">
        <asp:ImageButton ID="imgExportarPdf" runat="server" ImageUrl="~/Recursos/Imagenes/pdf.png"  Width="40px" OnClick="imgExportarPdf_Click" />
        <asp:Button ID="btnExportar" runat="server" OnClick="btnExportar_Click" Text="Exportar" />
    &nbsp;<asp:ImageButton ID="imgExportarCsv" runat="server" Height="38px" ImageUrl="~/Recursos/Imagenes/csv.png" Width="40px" OnClick="imgExportarCsv_Click" />
    </p>
     
</asp:Content>
