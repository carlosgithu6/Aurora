<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="CambioMedidor.aspx.cs" Inherits="Aurora.Web.Admin.CambioMedidor"  %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
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
        .style5
        {
            color: Black;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            font-size: 9pt;
            line-height: normal;
            font-family: Tahoma;
            border-left-width: 0px;
            border-top-width: 0px;
        }
        .style6
        {
            cursor: default;
            color: Black;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            font-size: 9pt;
            line-height: normal;
            font-family: Tahoma;
            border-left-width: 0px;
            border-right-width: 0px;
            border-top-width: 0px;
        }
        .style7
        {
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #a4b26d;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #a4b26d;
            padding: 2px;
        }
        .style8
        {
            text-align: Left;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #a4b26d;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #a4b26d;
            padding: 2px;
        }
        .style9
        {
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #a4b26d;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #a4b26d;
            padding: 2px;
        }
        .style10
        {
            overflow: hidden;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #cdd6a7;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #cdd6a7;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 2px;
            padding-bottom: 5px;
        }
        .style11
        {
            text-align: Left;
            overflow: hidden;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #cdd6a7;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #cdd6a7;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 2px;
            padding-bottom: 5px;
        }
        .style12
        {
            white-space: nowrap;
            overflow: hidden;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #cdd6a7;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #cdd6a7;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 2px;
            padding-bottom: 5px;
        }
        .style13
        {
            border-right: 1px solid #a4b26d;
            border-bottom: 1px solid #a4b26d;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 3px;
            padding-bottom: 5px;
        }
        .style14
        {
            text-align: Left;
            border-right: 1px solid #a4b26d;
            border-bottom: 1px solid #a4b26d;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 3px;
            padding-bottom: 5px;
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
         KeyFieldName="RUT" Width="850px" 
        oncustombuttoncallback="GridPropietarios_CustomButtonCallback" >
         <SettingsBehavior ConfirmDelete="True" AllowFocusedRow="True" />
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
             PopupEditFormCaption="Nuevo/Edición" Title="SELECCIONE EL PROPIETARIO PARA ESPECIFICAR  EL CAMBIO DE MEDIDOR" 
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
             <PropertiesTextEdit DisplayFormatString="dd-MM-yyyy">
<ValidationSettings><RequiredField 
                     IsRequired="True" />
                 </ValidationSettings>
             
</PropertiesTextEdit>
             <CellStyle Font-Size="Small">
             </CellStyle>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Apellido M." FieldName="APMATERNO" 
                 UnboundType="String" VisibleIndex="3"><PropertiesTextEdit>
<ValidationSettings><RequiredField 
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
                 <EditButton>
                     <Image Url="~/Imagenes/Files-text.ico" Height="24px" Width="24px" />
                 </EditButton>
                 <NewButton>
                     <Image Url="~/Imagenes/edit_add.ico" Height="24px" Width="24px" />
                 </NewButton>
                 <DeleteButton>
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
                    <CustomButtons>
                        <dxwgv:GridViewCommandColumnCustomButton ID="CCorriente" 
                            Text="Especificar cambio de medidor">
                            <Image Url="~/Imagenes/ktimer.ico" Height="24px" Width="24px" />
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
         <Settings ShowGroupPanel="True" ShowFooter="True" 
             ShowTitlePanel="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
        <SettingsCustomizationWindow Enabled="True"  />
         <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />

     </dxwgv:ASPxGridView>
</asp:Content>
