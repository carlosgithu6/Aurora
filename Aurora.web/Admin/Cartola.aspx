<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cartola.aspx.cs" Inherits="Aurora.Web.Admin.Cartola" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3.Export, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CARTOLA</title>
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
        .style8
        {
            width: 100%;
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
                </span>
            </td>
        </tr>
        <tr>
            <td class="style3">
                CARTOLA</td>
            <td class="style5">
                Histórica</td>
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
                Cartola de cuentas fijas y variables</td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <dxwgv:ASPxGridView ID="gridVar" runat="server" AutoGenerateColumns="False" 
                    onhtmldatacellprepared="gridVar_HtmlDataCellPrepared">
                    <Styles>
                        <Table Font-Names="Verdana" Font-Size="X-Small">
                        </Table>
                    </Styles>
                    <SettingsText GroupPanel="Arraste la columna hasta aquípara agrupar por ella" />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="COSTO" ShowInColumn="MONTO A PAGAR" 
                            SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="GVMONTOCANCELADO" 
                            ShowInColumn="MONTO CANCELADO" SummaryType="Sum" />
                    </TotalSummary>
                    <Columns>
                        <dxwgv:GridViewCommandColumn VisibleIndex="0">
                            <ClearFilterButton Visible="True">
                            </ClearFilterButton>
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="MES" ReadOnly="True" 
                            VisibleIndex="1" Caption="MES">
                            <PropertiesTextEdit EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="ANO" FieldName="ANO" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="TIPO CUENTA" FieldName="CTVDESCRIPCION" 
                            VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="MONTO A PAGAR" FieldName="COSTO" 
                            VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="MONTO CANCELADO" 
                            FieldName="GVMONTOCANCELADO" VisibleIndex="5">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataDateColumn Caption="FECHA DE PAGO" FieldName="FECHAPAGO" 
                            VisibleIndex="5">
                            <PropertiesDateEdit DisplayFormatString="">
                            </PropertiesDateEdit>
                        </dxwgv:GridViewDataDateColumn>
                       <dxwgv:GridViewDataComboBoxColumn Caption="FORMA DE &lt;Br/&gt;PAGO" 
                            FieldName="FORMAPAGO" VisibleIndex="5">
                            <PropertiesComboBox ValueType="System.String">
                                <Items>
                                    
<dxe:ListEditItem Text="Sin Pago" Value="100" />
                                    
<dxe:ListEditItem Text="Efectivo" Value="0" />
                                    
<dxe:ListEditItem Text="Cheque a Fecha" Value="1" />
                                    
<dxe:ListEditItem Text="Vale Vista" Value="2" />
                                    
<dxe:ListEditItem Text="Desde Cta Cte" Value="3" />
                                    
<dxe:ListEditItem Text="Mixto" Value="4" />
                                
                            </Items>
                            
</PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                    </Columns>
                    <SettingsPager PageSize="50">
                    </SettingsPager>
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" 
                        ShowFooter="True" />
                </dxwgv:ASPxGridView>
            </td>
        </tr>
        </table>
                    <br />
                    <table class="style8">
                        <tr>
                            <td style="text-align: center">
                                <dxe:ASPxButton ID="btnExportVyF" runat="server" Text="Exportar a XLS" 
                                    onclick="btnExportVyF_Click">
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                    </table>
       <hr />
        <table style="width:80%;" align="center" id="tblFija" runat="server">
        <tr>
            <td class="style2" align="center">
                &nbsp;</td>
        </tr>
        </table>
        
          <hr />
     <%--   <table style="width:80%;" align="center" id="tblEsp" runat="server">
        <tr>
            <td class="style6" align="center" style="font-family: Verdana">
                Cartola de cuentas especiales</td>
        </tr>
        <tr>
            <td class="style2" align="center">
  <%--              <dxwgv:ASPxGridView ID="gridEsp" runat="server" AutoGenerateColumns="False" 
                    onhtmldatacellprepared="gridEsp_HtmlDataCellPrepared">
                    <Styles>
                        <Table Font-Names="Verdana" Font-Size="X-Small">
                        </Table>
                    </Styles>
                    <SettingsText GroupPanel="Arraste la columna hasta aquí para agrupar por ella" />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="COT" />
                    </TotalSummary>
                    <Columns>
                        <dxwgv:GridViewCommandColumn VisibleIndex="0">
                            <ClearFilterButton Visible="True">
                            </ClearFilterButton>
                        </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewDataTextColumn FieldName="MES" ReadOnly="True" 
                            VisibleIndex="1" Caption="MES">
                            <PropertiesTextEdit EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="ANO" FieldName="ANO" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="TIPO CUENTA" FieldName="CTEDESCRIPCION" 
                            VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="NUMERO CUOTA" FieldName="NUMEROCUOTA" 
                            VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="CUOTA" FieldName="GCECUOTA" 
                            VisibleIndex="5">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="MONTO CANCELADO" 
                            FieldName="GCEMONTO" VisibleIndex="6">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataDateColumn Caption="FECHA DE PAGO" FieldName="FECHAPAGO" 
                            VisibleIndex="7">
                            <PropertiesDateEdit DisplayFormatString="">
                            </PropertiesDateEdit>
                        </dxwgv:GridViewDataDateColumn>
                    </Columns>
                    <SettingsPager PageSize="50">
                    </SettingsPager>
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" 
                        ShowFooter="True" ShowGroupFooter="VisibleAlways" />
                    <GroupSummary >
                    <dxwgv:ASPxSummaryItem  SummaryType="Sum" FieldName="COSTO" ShowInColumn="COSTO"/>
                    </GroupSummary>
                </dxwgv:ASPxGridView>--%>
            </td>
        </tr>
         
        </table>
                    <br />
                    
                       <%--<table class="style8">
                        <tr>
                            <td style="text-align: center">
                                <dxe:ASPxButton ID="btnExportE" runat="server" Text="Exportar a XLS" 
                                    onclick="btnExportE_Click">
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                    </table>--%>
                    <table align="center">
        <tr>
            <td class="style2" align="right" 
                style="font-family: Verdana; font-size: small;" width="80%">
                <b>&nbsp; </b>
                <br>
                  <b>Deuda Inicial Pendiente:&nbsp; </b>
                <dxe:ASPxLabel ID="lblDeudaInicial" runat="server">
                </dxe:ASPxLabel>
                 <br>
                 <b>Deuda en Cuentas Fijas&nbsp; :&nbsp; </b>
                <dxe:ASPxLabel ID="lblDeudaCF" runat="server">
                </dxe:ASPxLabel>
                 <br />
                <b>Deuda en Cuentas Variables:&nbsp;&nbsp;&nbsp;&nbsp; </b>
                <dxe:ASPxLabel ID="lblDeudaCV" runat="server">
                </dxe:ASPxLabel>
                 &nbsp;<br>
                  <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                <br/>
                 <b>Deudas total(suma):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                <dxe:ASPxLabel ID="lbltotal" runat="server">
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
<tr>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
</tr>
</table>
    
        <br />
                 <dxwgv:ASPxGridViewExporter ID="gridExporterFyV" runat="server"  
                     GridViewID="gridVar" >
                 </dxwgv:ASPxGridViewExporter>
    
                 <dxwgv:ASPxGridViewExporter ID="gridExporterE" runat="server"  
                     GridViewID="gridEsp" >
                 </dxwgv:ASPxGridViewExporter>
    
</form>
</body>
</html>
