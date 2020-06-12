<%@ Page Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmAgregarHabitacion.aspx.cs" Inherits="AplicacionWebHotel.Vista.Gerente.frmAgregarHabitacion" %>
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
                <td colspan="2" style="text-align: center">AGREGAR HABITACIÓN</td>
            </tr>
            <tr>
                <td class="auto-style2">Número Habitación:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtNumero" runat="server" Width="272px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Piso:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="cbPiso" runat="server" style="width:275px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Descripción:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtDescripcion" runat="server" Height="69px" TextMode="MultiLine" Width="270px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Tipo Habitación:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="cbTipo" runat="server" style="width:275px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                </td>
            </tr>
        </table>
    
   
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
   

</asp:Content>