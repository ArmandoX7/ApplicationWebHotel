<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReportesGerente.aspx.cs" Inherits="AplicacionWebHotel.Vista.Gerente.frmReportesGerente" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
        
         <br />
        
         
        <br /><br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="rVistaGerente" runat="server" Font-Names="Verdana" Font-Size="8pt" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="539px" Height="268px">
            <ServerReport ReportPath="~Vista/Gerente/ReporteVistaCantidadHabitaciones.rdlc" DisplayName="ReporteHabitaciones" />
            <LocalReport ReportPath="Vista\Gerente\ReporteVistaCantidadHabitaciones.rdlc" DisplayName="ReporteHabitaciones" 
                ReportEmbeddedResource="AplicacionWebHotel.Vista.Gerente.reporteVistaCantidadHabitaciones.rdlc">
               
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
               
            </LocalReport>
        </rsweb:ReportViewer>
        
         
        
         <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="AplicacionWebHotel.HotelDataSetTableAdapters.VistaEmpleadosCargoTableAdapter" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AplicacionWebHotel.HotelDataSetTableAdapters.VistaCantidadHabitacionesPorTipoTableAdapter" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
        
         
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HotelConnectionString2 %>" 
            SelectCommand="SELECT * FROM [VistaCantidadHabitacionesPorTipo]"></asp:SqlDataSource>
    </form>
    
</body>
</html>
