<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmReportesRecepcionista.aspx.cs" Inherits="AplicacionWebHotel.Vista.Recepcionista.frmReportesRecepcionista" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="924px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <ServerReport ReportPath="~/Vista/Recepcionista/Report1.rdlc" />
        <LocalReport DisplayName="Reporte1" ReportPath="Vista\Recepcionista\Report1.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
</rsweb:ReportViewer>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HotelConnectionString %>" SelectCommand="SELECT * FROM [VistaHabitacionesAlquiladas]"></asp:SqlDataSource>

</asp:Content>
