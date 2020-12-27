<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="AdminPropietarios.aspx.cs" Inherits="Aurora.Web.Admin.AdminPropietarios"  %>
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
        oncustombuttoncallback="GridPropietarios_CustomButtonCallback" 
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
             PopupEditFormCaption="Nuevo/Edición" Title="LISTADO DE PROPIETARIOS" 
             CustomizationWindowCaption="Seleccione Columna" />
         <TotalSummary>
             <dxwgv:ASPxSummaryItem FieldName="RUT" ShowInColumn="RUT" 
                 ShowInGroupFooterColumn="RUT" SummaryType="Count" Tag="Cantidad" />
         </TotalSummary>
         <Columns>
             
             <dxwgv:GridViewDataTextColumn Caption="IDPROPIEDAD" FieldName="IDPROPIEDAD" 
                 ReadOnly="True" Visible="False" VisibleIndex="0">
             </dxwgv:GridViewDataTextColumn>
             
<dxwgv:GridViewDataTextColumn Caption="RUT" FieldName="RUT" VisibleIndex="0" 
                 UnboundType="String">
             <PropertiesTextEdit>
                 <ValidationSettings>
                     <RequiredField IsRequired="True" />
                 </ValidationSettings>
             </PropertiesTextEdit>
             <CellStyle Font-Size="Small">
             </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Nombres" FieldName="NOMBRES" 
                 VisibleIndex="1" UnboundType="String">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
             <CellStyle Font-Size="Small">
             </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             
             <dxwgv:GridViewDataTextColumn Caption="Apellido P." FieldName="APPATERNO" 
                 VisibleIndex="2" UnboundType="String">
             <PropertiesTextEdit DisplayFormatString="dd-MM-yyyy"><ValidationSettings><RequiredField 
                     IsRequired="True" />
                 </ValidationSettings>
             </PropertiesTextEdit>
             <CellStyle Font-Size="Small">
             </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Apellido M." FieldName="APMATERNO" 
                 UnboundType="String" VisibleIndex="3"><PropertiesTextEdit><ValidationSettings><RequiredField 
                         IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataCheckColumn Caption="Socio" FieldName="SOCIO" 
                 VisibleIndex="4">
                 <PropertiesCheckEdit DisplayTextChecked="Si" DisplayTextUnchecked="No">
                 </PropertiesCheckEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataCheckColumn>
             <dxwgv:GridViewDataTextColumn Caption="Fecha de &lt;br/&gt;ingreso socio" 
                 FieldName="FECHAINGRESOSOCIO" ReadOnly="True" VisibleIndex="5" 
                 Visible="False">
                 <PropertiesTextEdit DisplayFormatString="dd-MM-yyyy" NullDisplayText="-">
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Fecha de &lt;br/&gt;salida socio" 
                 FieldName="FECHASALIDASOCIO" ReadOnly="True" VisibleIndex="6" 
                 Visible="False">
                 <PropertiesTextEdit DisplayFormatString="dd-MM-yyyy" NullDisplayText="-">
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Dirección" FieldName="DIRECCIONCONTACTO" 
                 UnboundType="String" VisibleIndex="7" Visible="False">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Correo" FieldName="MAIL" 
                 UnboundType="String" VisibleIndex="8" Visible="False">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RegularExpression ValidationExpression="^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25}(($)|( *;+ *$)|( *;+ *(?=[a-zA-Z0-9_\-\.]))))*$" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Teléfono" FieldName="TELEFONO" 
                 UnboundType="String" VisibleIndex="9">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Sector" FieldName="SECTOR" 
                 UnboundType="String" VisibleIndex="10" Visible="False">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Letra" FieldName="LETRAPARCELA" 
                 UnboundType="String" VisibleIndex="11" Visible="False">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Número" FieldName="NUMEROPARCELA" 
                 UnboundType="Integer" VisibleIndex="12" Visible="False">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Héctareas" FieldName="TAMANOHECT" 
                 UnboundType="Integer" VisibleIndex="13" Visible="False">
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Casas" FieldName="NUMEROCASAS" 
                 UnboundType="Integer" VisibleIndex="14" Visible="False">
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataCheckColumn Caption="Activa" FieldName="ACTIVA" 
                 Visible="False" VisibleIndex="7">
             </dxwgv:GridViewDataCheckColumn>
             <dxwgv:GridViewDataDateColumn Caption="Fecha de &lt;br/&gt;actualización" 
                 FieldName="FECHAACTUALIZACION" ReadOnly="True" VisibleIndex="15" 
                 Visible="False">
                 <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy">
                 </PropertiesDateEdit>
                 <CellStyle Font-Size="Small">
                 </CellStyle>
             </dxwgv:GridViewDataDateColumn>
             <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" 
                 VisibleIndex="16" AllowDragDrop="True" Name="OPCIONES">
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
                     <Image Url="~/Imagenes/disk.png" />
                 </UpdateButton>
                 <ClearFilterButton Text="Limpiar Filtros" Visible="True">
                     <Image AlternateText="Limpiar filtros" Url="~/Imagenes/escobachica.jpg" 
                         Height="24px" Width="24px" />
                 </ClearFilterButton>
                    <CustomButtons>
                        <dxwgv:GridViewCommandColumnCustomButton ID="CFijas" 
                            Text="Cuentas Fijas Asignadas">
                            <Image Height="24px" Url="~/Imagenes/dinero.png" Width="24px" />
                        </dxwgv:GridViewCommandColumnCustomButton>
                        <dxwgv:GridViewCommandColumnCustomButton ID="CVariables" 
                            Text="Cuentas Variables Asignadas">
                            <Image Height="24px" Url="~/Imagenes/variables.PNG" Width="24px" />
                        </dxwgv:GridViewCommandColumnCustomButton>
                    <dxwgv:GridViewCommandColumnCustomButton Text="Cuentas especiales" ID="CEspeciales" 
                            Visibility="Invisible">
                        <Image AlternateText="Asignar Cuentas Especiales" 
                            Url="~/Imagenes/billete.png" Height="24px" Width="24px" />
                    </dxwgv:GridViewCommandColumnCustomButton>
                        <dxwgv:GridViewCommandColumnCustomButton ID="CCorriente" 
                            Text="Cuenta Corriente">
                            <Image Url="~/Imagenes/kwallet.png" Height="24px" Width="24px" />
                        </dxwgv:GridViewCommandColumnCustomButton>
                        <dxwgv:GridViewCommandColumnCustomButton ID="Regenerar" 
                            Text="Regenerar Nomina Actual">
                            <Image Height="24px" Url="~/Imagenes/regenerar.png" Width="24px" />
                        </dxwgv:GridViewCommandColumnCustomButton>
                        <dxwgv:GridViewCommandColumnCustomButton ID="Cartola">
                            <Image Height="24px" Url="~/Imagenes/Cartola.png" Width="24px" />
                        </dxwgv:GridViewCommandColumnCustomButton>
                </CustomButtons>
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