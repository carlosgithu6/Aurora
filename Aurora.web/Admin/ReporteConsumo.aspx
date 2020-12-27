<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="ReporteConsumo.aspx.cs" Inherits="Aurora.Web.Admin.ReporteConsumo"  %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3.Export, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
.dxgvControl_Office2003_Olive,
.dxgvDisabled_Office2003_Olive
{
	border: solid 1px #a4b26d;
	font: 9pt Tahoma;
	background-color: White;
	color: Black;
	cursor: default;
}
.dxgvControl_Office2003_Olive
{
	border: solid 1px #a4b26d;
	font: 9pt Tahoma;
	background-color: White;
	color: Black;
	cursor: default;
}

.dxgvTitlePanel_Office2003_Olive,
.dxgvTable_Office2003_Olive caption
{
	color: White;
	font-weight:bold;
	padding:3px;
	text-align:center;	
	border-bottom: solid 1px #a4b26d;
	background: #6d834d url('../App_Themes/Office2003%20Olive/GridView/gvTitleBack.gif') repeat-x center top;
        }

.dxgvTitlePanel_Office2003_Olive
{
	color: White;
	font-weight:bold;
	padding:3px;
	text-align:center;	
	border-bottom: solid 1px #a4b26d;
	background: #6d834d url('../App_Themes/Office2003%20Olive/GridView/gvTitleBack.gif') repeat-x center top;
        }
.dxgvGroupPanel_Office2003_Olive
{
	white-space:nowrap;	
	background: #cfd9a3;
	border-bottom: solid 1px #a4b26d;
	padding: 7px 4px 8px 6px;
}
.dxgvGroupPanel_Office2003_Olive
{
	white-space:nowrap;	
	background: #cfd9a3;
	border-bottom: solid 1px #a4b26d;
	padding: 7px 4px 8px 6px;
}

.dxgvTable_Office2003_Olive
{
	background-color: transparent;
	border:0;
	border-collapse: separate !important;
	overflow:hidden;
	font: 9pt Tahoma;
	color: Black;
}

.dxgvTable_Office2003_Olive
{
	background-color: transparent;
	border:0;
	border-collapse: separate !important;
	overflow:hidden;
	font: 9pt Tahoma;
	color: Black;
}

.dxgvHeader_Office2003_Olive {
	cursor:pointer;
	white-space:nowrap;
	padding:  4px 6px 5px 6px;
	border: solid 1px #a4b26d;
	background: #b8c692 url('../App_Themes/Office2003%20Olive/GridView/gvGradient.gif') repeat-x center top;
	overflow:hidden;
	-moz-user-select: none;
    font-weight: normal;
    text-align: left;
}

.dxgvHeader_Office2003_Olive {
	cursor:pointer;
	white-space:nowrap;
	padding:  4px 6px 5px 6px;
	border: solid 1px #a4b26d;
	background: #b8c692 url('../App_Themes/Office2003%20Olive/GridView/gvGradient.gif') repeat-x center top;
	overflow:hidden;
	-moz-user-select: none;
    font-weight: normal;
    text-align: left;
}
.dxgvFilterRow_Office2003_Olive 
{
	background: #cfd9a3;	
}
.dxgvFilterRow_Office2003_Olive 
{
	background: #cfd9a3;	
}
.dxgvCommandColumn_Office2003_Olive
{
	padding: 2px 2px 2px 2px;
}
.dxgvCommandColumn_Office2003_Olive
{
	padding: 2px 2px 2px 2px;
}
.dxgvFooter_Office2003_Olive
{	
	background-color: #bdcb85;
	white-space:nowrap;
}
.dxgvFooter_Office2003_Olive
{	
	background-color: #bdcb85;
	white-space:nowrap;
}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
<br/>
<script language="javascript" type="text/javascript">
function UpdateCustomizationWindowValue() {
    var element = document.getElementById("btnCustWindow");
    if(element == null) return;
    element.value = (GridPropietarios.IsCustomizationWindowVisible() ? "Ocultar" : "Mostrar") + " ventana de selección de columnas";
}
function ShowHideCustomizationWindow() {
    if(GridPropietarios.IsCustomizationWindowVisible())
        GridPropietarios.HideCustomizationWindow();
    else GridPropietarios.ShowCustomizationWindow();        
    UpdateCustomizationWindowValue();
}
</script>
<input id="btnCustWindow" type="button" value="Mostrar ventana de selección de columnas" 
        onclick="ShowHideCustomizationWindow();" 
        style="padding: 0px; margin: 0px; background-color: #339933"/><br /><br />

<br/>
    <dxwgv:ASPxGridView ID="GridPropietarios"   
         ClientInstanceName="GridPropietarios" runat="server" AutoGenerateColumns="False" 
         CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" CssPostfix="Office2003_Olive" 
         KeyFieldName="ID" Width="850px" >
         <SettingsBehavior ConfirmDelete="True" AllowFocusedRow="True" 
             AllowGroup="False" SortMode="Custom" />
         <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" 
            PopupEditFormWidth="500px" />
         <SettingsCustomizationWindow Enabled="false"  />
         <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />

         <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
               CssPostfix="Office2003_Olive">
             <Header ImageSpacing="5px" SortingImageSpacing="5px">
             </Header>
             <LoadingPanel ImageSpacing="10px">
             </LoadingPanel>
         </Styles>
         <SettingsText CommandDelete="Eliminar" CommandEdit="Editar" CommandNew="Nuevo" 
             ConfirmDelete="Está seguro que desea eliminar el registro" 
             GroupPanel="&lt;b&gt;Arrastre una columna aquí para agrupar por ella&lt;/b&gt;" 
             PopupEditFormCaption="Nuevo/Edición" Title="Informe de consumo" 
             CustomizationWindowCaption="Seleccione Columna" />
     
         <TotalSummary>
             <dxwgv:ASPxSummaryItem FieldName="CONSUMO" ShowInColumn="Consumo" 
                 ShowInGroupFooterColumn="Consumo" SummaryType="Sum" />
         </TotalSummary>
     
         <Columns>
             
             <dxwgv:GridViewCommandColumn VisibleIndex="0">
                 <ClearFilterButton Visible="True">
                 </ClearFilterButton>
             </dxwgv:GridViewCommandColumn>
             
<dxwgv:GridViewDataTextColumn Caption="Id" FieldName="ID" VisibleIndex="0" Visible="False">
             </dxwgv:GridViewDataTextColumn>
             
             <dxwgv:GridViewDataTextColumn Caption="IdPropiedad" FieldName="IDPROPIEDAD" 
                 ReadOnly="True" VisibleIndex="1">
             </dxwgv:GridViewDataTextColumn>
             
             <dxwgv:GridViewDataTextColumn Caption="Cuenta" 
                 FieldName="CUENTA" VisibleIndex="2">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             
             <dxwgv:GridViewDataTextColumn Caption="Mes" FieldName="MES" 
                 VisibleIndex="3">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Año" FieldName="ANO" VisibleIndex="4">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Nombres" FieldName="NOMBRE" 
                 VisibleIndex="5" UnboundType="String" ReadOnly="True">
             </dxwgv:GridViewDataTextColumn>
             
             <dxwgv:GridViewDataTextColumn Caption="Sector" FieldName="SECTOR" 
                 UnboundType="String" VisibleIndex="9" ReadOnly="True">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Letra" FieldName="LETRAPARCELA" 
                 UnboundType="String" VisibleIndex="10" ReadOnly="True">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Número" FieldName="NUMEROPARCELA" 
                 UnboundType="Integer" VisibleIndex="11" ReadOnly="True">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Lectura Anterior" 
                 FieldName="LECTURAANTERIOR" VisibleIndex="6">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Lectura Actual" 
                 FieldName="GVCLECTURACATUAL" VisibleIndex="7">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Consumo" 
                 FieldName="CONSUMO" VisibleIndex="8">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Tarifa" FieldName="TARIFAAPLICADA" 
                 VisibleIndex="12">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Número Medidor" FieldName="MEDIDOR" 
                 VisibleIndex="13">
             </dxwgv:GridViewDataTextColumn>
             
        </Columns>
        
         <Images ImageFolder="~/App_Themes/Office2003 Olive/{0}/">
             <CollapsedButton Height="12px" 
                 Url="~/App_Themes/Office2003 Olive/GridView/gvCollapsedButton.png" 
                 Width="11px" />
             <ExpandedButton Height="12px" 
                 Url="~/App_Themes/Office2003 Olive/GridView/gvExpandedButton.png" 
                 Width="11px" />
             <DetailCollapsedButton Height="12px" 
                 Url="~/App_Themes/Office2003 Olive/GridView/gvCollapsedButton.png" 
                 Width="11px" />
             <DetailExpandedButton Height="12px" 
                 Url="~/App_Themes/Office2003 Olive/GridView/gvExpandedButton.png" 
                 Width="11px" />
             <FilterRowButton Height="13px" Width="13px" />
         </Images>
         <SettingsPager PageSize="50">
             <Summary AllPagesText="Páginas: {0} - {1} ({2}Propietarios)" 
                 Text="Página {0} of {1} ({2} Propietarios)" Visible="False" />
         </SettingsPager>
         <SettingsDetail AllowOnlyOneMasterRowExpanded="True">
          </SettingsDetail>
           <Templates>
             <DetailRow>
                <div id="detalle">
                </div>    
             </DetailRow>
            </Templates>
         <Settings ShowFilterRow="True" ShowFooter="True" 
             ShowTitlePanel="True" ShowFilterRowMenu="True" />
        <SettingsCustomizationWindow Enabled="True"  />
         <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />

     </dxwgv:ASPxGridView>
       <table cellpadding="0" cellspacing="0" width="100%" >
    <tr>
        <td align="center">
         <table cellpadding="0" cellspacing="10" >
         <tr>
            
             <td >
                 <dxwgv:ASPxGridViewExporter ID="gridExporter" runat="server"  GridViewID="GridPropietarios" >
                 </dxwgv:ASPxGridViewExporter>
                 <dxe:ASPxButton ID="btnXlsExport" runat="server" Text="Exportar a XLS" UseSubmitBehavior="False"
                     OnClick="btnXlsExport_Click" 
                     CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                     CssPostfix="Office2003_Olive">
                 </dxe:ASPxButton>
             </td>
            
         </tr>
     </table>
</asp:Content>
