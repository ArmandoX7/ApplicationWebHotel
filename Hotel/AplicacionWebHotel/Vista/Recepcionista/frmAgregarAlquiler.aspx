<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="frmAgregarAlquiler.aspx.cs" Inherits="AplicacionWebHotel.Vista.Recepcionista.frmAgregarAlquiler" %>
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
                <td class="auto-style2" colspan="2" style="text-align: center">AGREGAR ALQUILER</td>
            </tr>
            <tr>
                <td class="auto-style3">Identificación Cliente:</td>
                <td>
                    <asp:TextBox ID="txtIdentificacion" runat="server" Width="265px" required="required" 
                        TextMode="Number"></asp:TextBox>
                    <div id="mensaje"> </div>
                    <asp:HiddenField ID="txtIdCliente" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Nombre:</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="265px" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Correo:</td>
                <td>
                    <asp:TextBox ID="txtCorreo" runat="server" Width="265px" Enabled="False" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Seleccione Piso:</td>
                <td>
                    <asp:DropDownList ID="cbPiso" runat="server" Height="26px" Width="269px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Seleccione Tipo Habitación:</td>
                <td>
                    <asp:DropDownList ID="cbTipo" runat="server" Height="26px" Width="269px" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Seleccione habitación:</td>
                <td>
                     
                    <asp:DropDownList ID="cbHabitacion" runat="server" Height="26px" Width="269px">
                    </asp:DropDownList>
                        
                </td>
            </tr>
             <tr>
                <td class="auto-style2" colspan="2" style="text-align: center">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                 </td>
            </tr>
        </table>
    <p>

    </p>
          <asp:Label ID="lblMensaje" runat="server"></asp:Label>
   

</asp:Content>
