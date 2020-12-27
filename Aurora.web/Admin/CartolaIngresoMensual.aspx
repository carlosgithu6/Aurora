<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="CartolaIngresoMensual.aspx.cs" Inherits="Aurora.Web.Admin.CartolaIngresoMensual"  %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3.Export, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style5
        {
            width: 100%;
        }
        .style6
        {
            color: #006600;
        }
        .style7
        {
            color: #006600;
            font-weight: bold;
        }
    </style>

 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br/>
     <table width ="85%" cellspacing="0"  border="1" align="center">
     <tr>
     <td valign="top">
         <table style="width:550px; font-family: Verdana;" align="center">
        <tr>
            <td align="center">
                <span class="style6">ASOCIACIÓN DE PROPIETARIOS LA AURORA.<br />
                Obterner notas de cobros e ingresos reales por rango de fechas de pago.</span><br 
                    class="style5" />
                <span class="style5">
                <dxe:ASPxLabel ID="lblExcepcion" runat="server" Font-Size="Large" 
                    ForeColor="#CC0000" Visible="False">
                </dxe:ASPxLabel>
                </span>
            </td>
        </tr>
         <tr>
            <td align="center">
             <dxrp:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" 
        HeaderText="Seleccione mes y año para notas de cobro" Height="143px" 
        Width="441px">
                 <HeaderStyle Font-Bold="True" ForeColor="#339933" />
        <PanelCollection>
<dxp:PanelContent ID="PanelContent1" runat="server">
    <table align="center" class="style5">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <dxe:ASPxComboBox ID="lstMes" runat="server" ClientInstanceName="lstMes" 
                    ValueType="System.String">
                    <Items>
                        <dxe:ListEditItem Text="Enero" Value="1" />
                        <dxe:ListEditItem Text="Febrero" Value="2" />
                        <dxe:ListEditItem Text="Marzo" Value="3" />
                        <dxe:ListEditItem Text="Abril" Value="4" />
                        <dxe:ListEditItem Text="Mayo" Value="5" />
                        <dxe:ListEditItem Text="Junio" Value="6" />
                        <dxe:ListEditItem Text="Julio" Value="7" />
                        <dxe:ListEditItem Text="Agosto" Value="8" />
                        <dxe:ListEditItem Text="Septiembre" Value="9" />
                        <dxe:ListEditItem Text="Octubre" Value="10" />
                        <dxe:ListEditItem Text="Noviembre" Value="11" />
                        <dxe:ListEditItem Text="Diciembre" Value="12" />
                    </Items>
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <dxe:ASPxComboBox ID="lstAnos" runat="server" ClientInstanceName="lstAnos" 
                    ValueType="System.String">
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
            <table class="style5">
            <tr>
                    <td colspan="2" class="style7">
                        Rango de fecha de pago para&nbsp; ingresos reales</td>
                    
                </tr>
                <tr>
                    <td class="style7">
                        DESDE</td>
                    <td class="style7">
                        HASTA</td>
                </tr>
                <tr>
                    <td>
                        <dxe:ASPxDateEdit ID="DateDesde" runat="server">
                            <ValidationSettings CausesValidation="True" ValidationGroup="AA">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dxe:ASPxDateEdit>
                    </td>
                    <td>
                        <dxe:ASPxDateEdit ID="DateHasta" runat="server">
                            <ValidationSettings CausesValidation="True" ValidationGroup="AA">
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dxe:ASPxDateEdit>
                    </td>
                </tr>
    </table>
    <br />
    <dxe:ASPxButton ID="btnBuscarNomina" runat="server" 
        OnClick="btnBuscarNomina_Click" Text="Buscar" ValidationGroup="AA">
    </dxe:ASPxButton>
    <br />
            </dxp:PanelContent>
</PanelCollection>
    </dxrp:ASPxRoundPanel>
            </td>
        </tr>
        </table>
    
    <br/>
   


    <br/>
    <table style="width:80%;" align="center" id="tblVar" runat="server">
        <tr>
            <td class="style6" align="center" style="font-family: Verdana">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" align="center">
                <br />
                <br />
                <dxwgv:ASPxGridView ID="gridVar" runat="server" 
                    KeyFieldName="NUMMOV" Visible="False">
                    <Styles>
                        <Table Font-Names="Verdana" Font-Size="X-Small">
                        </Table>
                        <HeaderPanel Font-Bold="False">
                        </HeaderPanel>
                        <TitlePanel Font-Bold="True">
                        </TitlePanel>
                    </Styles>
                    <SettingsText Title="Ingresos Reales" />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="INGRESO" 
                            SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="INGRESO_200M3" SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="INGRESO_201_300M3" SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="INGRESO_301_500M3" SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="INGRESO_501M3_MAS" SummaryType="Sum" />
                    </TotalSummary>
                    <SettingsPager PageSize="50">
                    </SettingsPager>
                    <Settings ShowFooter="True" ShowTitlePanel="True" ShowFilterBar="Visible" 
                        ShowFilterRow="True" />
                    <GroupSummary>
                        <dxwgv:ASPxSummaryItem DisplayFormat="{0:c}" FieldName="INGRESO" 
                            SummaryType="Sum"  />
                        <dxwgv:ASPxSummaryItem FieldName="NUMMOV" 
                            SummaryType="Count" />
                        <dxwgv:ASPxSummaryItem FieldName="INGRESO_200M3" ShowInColumn="INGRESO_200M3" 
                            SummaryType="Sum" />
                    </GroupSummary>
                </dxwgv:ASPxGridView>
                <br />
                 <dxe:ASPxButton ID="btnXlsExport" runat="server" Text="Exportar a XLS" UseSubmitBehavior="False"
                     OnClick="btnXlsExport_Click" Visible="False">
                 </dxe:ASPxButton>
                <br />
                <br />
                <br />
                <br />
                <dxwgv:ASPxGridView ID="grid_NotasCobros" runat="server" Visible="False">
                    <SettingsBehavior AllowDragDrop="False" AllowGroup="False" />
                    <Styles>
                        <Table Font-Names="Verdana" Font-Size="X-Small">
                        </Table>
                        <Header Font-Bold="False">
                        </Header>
                        <TitlePanel Font-Bold="True">
                        </TitlePanel>
                    </Styles>
                    <SettingsText Title="Notas de Cobro" />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="MONTO" ShowInColumn="MONTO" 
                            SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="DEUDA" ShowInColumn="DEUDA" 
                            SummaryType="Sum" />
                    </TotalSummary>
                    <SettingsPager PageSize="50">
                    </SettingsPager>
                    <Settings 
                        ShowFooter="True" ShowGroupFooter="VisibleIfExpanded" 
                        showgroupedcolumns="True" ShowTitlePanel="True" ShowFilterBar="Visible" 
                        ShowFilterRow="True" />
                    <GroupSummary>
                        <dxwgv:ASPxSummaryItem DisplayFormat="c" FieldName="INGRESO" 
                            ShowInGroupFooterColumn="INGRESO" SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="NUMMOV" ShowInGroupFooterColumn="NUM MOV." 
                            SummaryType="Count" />
                    </GroupSummary>
                </dxwgv:ASPxGridView>
                <br />
                 <dxe:ASPxButton ID="btnXlsNotasCobro" runat="server" 
                    Text="Exportar a XLS" UseSubmitBehavior="False"
                     OnClick="btnXlsNotasCobro_Click" Visible="False">
                 </dxe:ASPxButton>
                 <dxwgv:ASPxGridViewExporter ID="gridExporter1" runat="server"  
                     GridViewID="grid_NotasCobros" >
                 </dxwgv:ASPxGridViewExporter>
                <br />
&nbsp;</td>
        </tr>
        </table>
       <hr />
        <table style="width:80%;" align="center" id="tblFija" runat="server">
        <tr>
            <td class="style2" align="center">
                     <table cellpadding="0" cellspacing="10" >
         <tr>
            
             <td >
                 <dxwgv:ASPxGridViewExporter ID="gridExporter" runat="server"  
                     GridViewID="gridVar" >
                 </dxwgv:ASPxGridViewExporter>
             </td>
            
         </tr>
     </table></td>
        </tr>
        </table>
        
          <hr />
        <table align="center">
        <tr>
            <td class="style2" align="right" 
                style="font-family: Verdana; font-size: small;" width="80%">
                &nbsp;</td>
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
 </asp:Content>
