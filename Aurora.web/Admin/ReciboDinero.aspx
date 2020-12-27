<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReciboDinero.aspx.cs" Inherits="Aurora.Web.Admin.ReciboDinero" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3.Export, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView.Export" tagprefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Recibo de Dinero</title>
    </head>
<body>
    <form id="form1" runat="server">
   
     <dxe:ASPxLabel ID="lblNotaCobro" runat="server" EncodeHtml="False">
     </dxe:ASPxLabel>
   
   
     <br />
     <br />
     <asp:Table ID="tblNota" runat="server" Font-Size="Small" ForeColor="Black" 
         Width="100%" Height="100%"  BorderColor=Black>
         <asp:TableRow runat="server"  Width="95%">
             <asp:TableCell runat="server" runat="server" ID="Celda" BorderColor=Black></asp:TableCell>
         </asp:TableRow>
         
     </asp:Table>


     <table align="center">
        <tr>
        <td colspan="3">
            <asp:Label ID="lblEmailOK" runat="server" visible="False" ForeColor="#009933"></asp:Label>
            <asp:Label ID="lblEmailFail" runat="server" visible="False" ForeColor="#FF3300"></asp:Label>
        </td>
        </tr>
         <tr align="center">
             <td>
                 <input onclick="JavaScript:history.back()" style="background-color: Green" 
                     type="button" value="Volver" />
             </td>
             <td>
                 <asp:Button ID="btnEnviarMail" runat="server" onclick="btnEnviarMail_Click" 
                     style="background-color: Green" Text="Enviar eMail y Guardar Pdf" 
                     ToolTip="Se envía por email y guarda el PDF, no se podrá emitir nuevamente el recibo" />
             </td>
             <td>
                 
                 &nbsp;</td>
         </tr>
     </table> 
</form>
</body>
</html>
