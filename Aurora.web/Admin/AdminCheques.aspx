<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="AdminCheques.aspx.cs" Inherits="Aurora.Web.Admin.AdminCheques"  %>
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
         KeyFieldName="IDPROPIEDAD"  onrowdeleted="GridPropietarios_RowDeleted" 
         onrowdeleting="GridPropietarios_RowDeleting" onrowinserted="GridPropietarios_RowInserted" 
         onrowinserting="GridPropietarios_RowInserting" onrowupdated="GridPropietarios_RowUpdated" 
         onrowupdating="GridPropietarios_RowUpdating" Width="850px" 
        oncancelrowediting="GridPropietarios_CancelRowEditing" 
        onstartrowediting="GridPropietarios_StartRowEditing" 
        oninitnewrow="GridPropietarios_InitNewRow" >
         <SettingsBehavior ConfirmDelete="True" AllowFocusedRow="True" />
         <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" 
            PopupEditFormWidth="500px" />
         <SettingsCustomizationWindow Enabled="false"  />
         <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" 
         CustomButtonClick="function(s, e) 
                        {
                          if (e.buttonID == 'Regenerar')
                          {
   
                                if (confirm('¿Está seguro que quiere regenerar la nómina para este propietario?'))
                                {
                                    e.processOnServer = true;
                                    s.PerformCallback(e.visibleIndex.toString());
                                   
                                }
                                else
                                {
                                    e.processOnServer = false;
                                }
                           }
                           else
                           {
                              e.processOnServer = true;
                              s.PerformCallback(e.visibleIndex.toString());
                           }
                         }" />

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
             PopupEditFormCaption="Nuevo/Edición" Title="LISTADO DE CHEQUES" 
             CustomizationWindowCaption="Seleccione Columna" />
         <TotalSummary>
             <dxwgv:ASPxSummaryItem FieldName="RUT" ShowInColumn="RUT" 
                 ShowInGroupFooterColumn="RUT" SummaryType="Count" Tag="Cantidad" />
         </TotalSummary>
         <Columns>
             
<dxwgv:GridViewDataTextColumn Caption="NÚMERO DE CHEQUE" FieldName="NUMCHEQUE" VisibleIndex="0" 
                 UnboundType="String">
             <PropertiesTextEdit>
                 <ValidationSettings>
                     <RequiredField IsRequired="True" />
                 </ValidationSettings>
             </PropertiesTextEdit>
             <CellStyle Font-Size="Small">
             </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataComboBoxColumn Caption="BANCO" FieldName="BANCO" 
                 VisibleIndex="1">
                 <PropertiesComboBox ValueType="System.String">
                     <Items>
                         <dxe:ListEditItem Text="Banco Santander" Value="1" />
                         <dxe:ListEditItem Text="Banco Santander Banefe" Value="2" />
                         <dxe:ListEditItem Text="Banco BBVA" Value="3" />
                         <dxe:ListEditItem Text="Banco BICE" Value="4" />
                         <dxe:ListEditItem Text="Banco Itau" Value="5" />
                         <dxe:ListEditItem Text="Banco de Chile / Edwards-Citi" Value="6" />
                         <dxe:ListEditItem Text="Corpbanca" Value="7" />
                         <dxe:ListEditItem Text="Banco Créditos e Inversiones" Value="8" />
                         <dxe:ListEditItem Text="Banco del Desarrollo" Value="9" />
                         <dxe:ListEditItem Text="Banco Estado" Value="10" />
                         <dxe:ListEditItem Text="Banco Falabella" Value="11" />
                         <dxe:ListEditItem Text="Banco Security" Value="12" />
                         <dxe:ListEditItem Text="Scotiabank" Value="13" />
                         <dxe:ListEditItem Text="RaboBank" Value="14" />
                         <dxe:ListEditItem Text="Otro Banco" Value="15" />
                     </Items>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesComboBox>
             </dxwgv:GridViewDataComboBoxColumn>
             <dxwgv:GridViewDataTextColumn Caption="MONTO" FieldName="MONTO" 
                 VisibleIndex="2">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataDateColumn Caption="FECHA RECEPCIÓN" FieldName="FECHARECEP" 
                 VisibleIndex="3">
                 <PropertiesDateEdit DisplayFormatString="">
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesDateEdit>
             </dxwgv:GridViewDataDateColumn>
             <dxwgv:GridViewDataDateColumn Caption="FECHA COBRO" FieldName="FECHACOBRO" 
                 VisibleIndex="4">
                 <PropertiesDateEdit DisplayFormatString="">
                 </PropertiesDateEdit>
             </dxwgv:GridViewDataDateColumn>
             <dxwgv:GridViewDataComboBoxColumn Caption="ESTADO" FieldName="ESTADO" 
                 VisibleIndex="5">
                 <PropertiesComboBox ValueType="System.String">
                     <Items>
                         <dxe:ListEditItem Text="En Cartera" Value="1" />
                         <dxe:ListEditItem Text="Cobrado" Value="2" />
                         <dxe:ListEditItem Text="Rechazado" Value="3" />
                     </Items>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesComboBox>
             </dxwgv:GridViewDataComboBoxColumn>
             <dxwgv:GridViewDataComboBoxColumn Caption="PROPIEDAD" FieldName="PROPIEDAD" 
                 VisibleIndex="6">
                 <PropertiesComboBox ValueType="System.String">
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesComboBox>
             </dxwgv:GridViewDataComboBoxColumn>
             <dxwgv:GridViewDataTextColumn Caption="IDPROPIEDAD" FieldName="IDPROPIEDAD" 
                 ReadOnly="True" Visible="False" VisibleIndex="7">
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" 
                 VisibleIndex="7" AllowDragDrop="True" Name="OPCIONES">
                 <EditButton Visible="True">
                     <Image Url="~/Imagenes/Files-text.ico" Height="24px" Width="24px" />
                 </EditButton>
                 <NewButton Visible="True">
                     <Image Url="~/Imagenes/edit_add.ico" Height="24px" Width="24px" />
                 </NewButton>
                 <DeleteButton Visible="True">
                     <Image Url="~/Imagenes/edit_remove.ico" Height="24px" Width="24px" />
                 </DeleteButton>
                 <CancelButton>
                     <Image Url="~/Imagenes/cross_circle_frame.png" Height="24px" Width="24px" />
                 </CancelButton>
                 <UpdateButton>
                     <Image Url="~/Imagenes/disk.png" Height="24px" Width="24px" />
                 </UpdateButton>
                 <ClearFilterButton Text="Limpiar Filtros" Visible="True">
                     <Image AlternateText="Limpiar filtros" Url="~/Imagenes/escobachica.jpg" 
                         Height="24px" Width="24px" />
                 </ClearFilterButton>
                 <CellStyle Wrap="False">
                 </CellStyle>
             </dxwgv:GridViewCommandColumn>
             
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
         <SettingsCookies Enabled="True" />
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
         <Settings ShowGroupPanel="True" ShowFilterRow="True" ShowFooter="True" 
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
