<%@ Page  Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmListarHabitacionesPorRango.aspx.cs" Inherits="AplicacionWebHotel.Vista.Gerente.frmListarHabitacionesPorRango" %>
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
            width: 60%;
        }
        .auto-style2 {
            width: 117px;
        }
        .auto-style3 {
            width: 85px;
        }
        .auto-style4 {
            width: 101px;
        }
        .auto-style5 {
            width: 59px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContenido" runat="server">

    <table align="center">
        <tr>
            <td class="auto-style2">Fecha Inicial:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtFechaInicial" runat="server" required="required"></asp:TextBox>
            </td>
            <td class="auto-style3">Fecha Final</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtFechaFinal" runat="server" required="required"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
            </td>
        </tr>
    </table>
    <br />
     <p style="text-align: center">
    <asp:GridView ID="tablaHabitaciones" runat="server" CellPadding="4" Font-Size="Medium" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
         </asp:GridView>
         </p>
    <p style="text-align: center">
        <asp:ImageButton ID="imgExportarCsv" runat="server" ImageUrl="~/Recursos/Imagenes/csv.png" Width="50px" AlternateText="Exportar a CSV" OnClick="imgExportarCsv_Click" />
        </p>

</asp:Content>