<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEjemploPdf.aspx.cs" Inherits="AplicacionWebHotel.Vista.Recepcionista.frmEjemploPdf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnCrear" runat="server" OnClick="btnCrear_Click" Text="Crear PDF" />
        <asp:Button ID="btnCrearTabla" runat="server" OnClick="btnCrearTabla_Click" Text="Crear Tabla" />
    
    </div>
    </form>
</body>
</html>
