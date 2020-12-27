<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadodeCuenta.aspx.cs" Inherits="Aurora.Web.Admin.EstadodeCuenta" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>NOTA DE COBRO</title>
    <style type="text/css">
        .style2
        {
        }
        .style3
        {
            width: 172px;
            font-weight: bold;
            font-size: small;
        }
        .style5
        {
            font-size: small;
        }
        .style6
        {
            font-size: small;
            font-weight: bold;
        }
        .style7
        {
            height: 653px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width ="85%" cellspacing="0"  border="1" align="center">
     <tr>
     <td class="style7" valign="top">
         <table style="width:550px; font-family: Verdana;" align="center">
        <tr>
            <td align="center" colspan="2">
                <span class="style6">ASOCIACIÓN DE PROPIETARIOS LA AURORA</span><br 
                    class="style5" />
                <span class="style5">
                <dxe:ASPxLabel ID="lblExcepcion" runat="server" Font-Size="Large" 
                    ForeColor="#CC0000" Visible="False">
                </dxe:ASPxLabel>
                <br />
                <b>NOTA DE COBRO DE RECUPERACIÓN DE GASTOS</b></span></td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="lblMes" runat="server"></asp:Label>
&nbsp;/&nbsp;<asp:Label ID="lblano" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
    
    <table style="width:550px; font-family: Verdana;" align="center">
        <tr>
            <td class="style5">
                Propietario:</td>
            <td class="style5">
                <asp:Label ID="lblPropietario" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Rut:</td>
            <td class="style5">
                <asp:Label ID="lblRut" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Parcela:</td>
            <td class="style5">
                <asp:Label ID="lblParcela" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Asociado</td>
            <td class="style5">
                <asp:Label ID="lblSocio" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Saldo a favor</td>
            <td class="style5">
                <asp:Label ID="lblSaldoFavor" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br/>
    <br/>
    <br/>
    <table style="width:80%;" align="center" id="tblVar" runat="server">
        <tr>
            <td class="style6" align="center" style="font-family: Verdana">
                Cuentas Variables</td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <dxwgv:ASPxGridView ID="gridVar" runat="server" AutoGenerateColumns="False">
                    <Styles>
                        <Table Font-Names="Verdana" Font-Size="X-Small">
                        </Table>
                    </Styles>
                    <Columns>
                        <dxwgv:GridViewDataTextColumn FieldName="CVARIABLE" ReadOnly="True" 
                            VisibleIndex="0">
                            <PropertiesTextEdit EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager Mode="ShowAllRecords">
                    </SettingsPager>
                    <Settings ShowColumnHeaders="False" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        </table>
       <hr />
        <table style="width:80%;" align="center" id="tblFija" runat="server">
        <tr>
            <td class="style6" align="center" style="font-family: Verdana">
                Cuentas Fijas</td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <dxwgv:ASPxGridView ID="GridFija" runat="server" AutoGenerateColumns="False">
                    <Styles>
                        <Table Font-Names="Verdana" Font-Size="X-Small">
                        </Table>
                    </Styles>
                    <Columns>
                        <dxwgv:GridViewDataTextColumn FieldName="CFIJA" ReadOnly="True" 
                            VisibleIndex="0">
                            <PropertiesTextEdit EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager Mode="ShowAllRecords">
                    </SettingsPager>
                    <Settings ShowColumnHeaders="False" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        </table>
        
          <hr />
        <table style="width:80%;" align="center" id="tblEsp" runat="server">
        <tr>
            <td class="style6" align="center" style="font-family: Verdana">
                Cuentas Especiales</td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <dxwgv:ASPxGridView ID="GridEspeciales" runat="server" 
                    AutoGenerateColumns="False">
                    <Styles>
                        <Table Font-Names="Verdana" Font-Size="X-Small">
                        </Table>
                    </Styles>
                    <Columns>
                        <dxwgv:GridViewDataTextColumn FieldName="CESPECIAL" ReadOnly="True" 
                            VisibleIndex="0">
                            <PropertiesTextEdit EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager Mode="ShowAllRecords">
                    </SettingsPager>
                    <Settings ShowColumnHeaders="False" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
         
        </table>
        <table align="center">
        <tr>
            <td class="style2" align="right" 
                style="font-family: Verdana; font-size: small;" width="80%">
                <b>A Pagar:&nbsp; </b>
                <dxe:ASPxLabel ID="lblTotal" runat="server">
                </dxe:ASPxLabel>
                <br>
                  <b>Deuda Inicial Pendiente:&nbsp; </b>
                <dxe:ASPxLabel ID="lblDeudaInicial" runat="server">
                </dxe:ASPxLabel>
                 <br>
                 <b>Total Pagar:&nbsp; </b>
                <dxe:ASPxLabel ID="lblTotalaPagar" runat="server">
                </dxe:ASPxLabel>
                <%-- <br>
                 
                 <b>Total con donación mensual a bomberos (00,25 UF):&nbsp; </b>
                <dxe:ASPxLabel ID="lblConBomberos" runat="server">
                </dxe:ASPxLabel>--%>
                 <br>
                  <b>Valor UF:&nbsp; </b>
                <dxe:ASPxLabel ID="lblUF" runat="server">
                </dxe:ASPxLabel>
            </td>
        </tr>
        </table>
     </td>
     </tr>
    </table>

<table border="0" cellpadding="0" cellspacing="0" align="center" style="width: 164px"> 
<tr>
    <td>
        <input id="Button1" type="button" value="Volver" 
            onclick="JavaScript:history.back()" style="background-color: #339933"/>
    </td>
    <td>
        <input id="Button2" type="button" value="Imprimir" 
            onclick="JavaScript:print()" style="background-color: #339933"/>
    </td>
</tr>
</table>
    
</form>
</body>
</html>
