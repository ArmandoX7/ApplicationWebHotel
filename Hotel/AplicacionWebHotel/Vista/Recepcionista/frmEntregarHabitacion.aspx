<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmEntregarHabitacion.aspx.cs" Inherits="AplicacionWebHotel.Vista.Recepcionista.frmEntregarHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

    <table align="center" class="tituloTabla">
        <tr>
            <td colspan="2" style="text-align: center" >ENTREGA DE HABITACIÓN</td>
        </tr>
        <tr>
            <td >Habitación:</td>
            <td >
                <asp:TextBox ID="txtHabitacion" runat="server" Width="268px" TextMode="Number" placeholder="Número de Habitación" required="required"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="imgConsultarAlquiler" runat="server" Height="25px" ImageUrl="~/Recursos/Imagenes/consultar.png" OnClick="imgConsultarAlquiler_Click" Width="33px" BorderStyle="Ridge" ToolTip="Clic para Buscar" />
            </td>
        </tr>
        <tr>
            <td >Cliente:</td>
            <td >
                <asp:TextBox ID="txtNombre" runat="server" Width="267px" ReadOnly="True" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >Fecha Ingreso:</td>
            <td>
                <asp:TextBox ID="txtFechaIngreso" runat="server" Width="268px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >FechaSalida:</td>
            <td>
                <asp:TextBox ID="txtFechaSalida" runat="server" Width="268px" required="required" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >Días:</td>
            <td >
                <asp:TextBox ID="txtDias" runat="server" Width="268px" ReadOnly="True" Enabled="False" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >Costo:</td>
            <td >
                <asp:TextBox ID="txtCosto" runat="server" Width="268px"  TextMode="Number" required="required" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Observaciones:</td>
            <td>
                <asp:TextBox ID="txtObservaciones" runat="server" Rows="5" TextMode="MultiLine" 
                    placeholder="Ingrese aquí observaciones si se requiere" Width="264px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnEntregar" runat="server" Text="Entregar" OnClick="btnEntregar_Click" />
            </td>
        </tr>
    </table>
    <br />
    <p style="text-align:center">
        <asp:Label ID="lblMensaje" runat="server">           
        </asp:Label>
    </p>
</asp:Content>
