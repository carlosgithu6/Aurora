<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="AdminCuentasVariables.aspx.cs"
    Inherits="Aurora.Web.Admin.AdminCuentasVariables" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
      <dxwgv:ASPxGridView ID="GridGrupos" ClientInstanceName="GridGrupos" runat="server"
        AutoGenerateColumns="False" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css"
        CssPostfix="Office2003_Olive" KeyFieldName="CTVCODIGO" OnRowDeleted="GridGrupos_RowDeleted"
        OnRowDeleting="GridGrupos_RowDeleting" OnRowInserted="GridGrupos_RowInserted"
        OnRowInserting="GridGrupos_RowInserting" OnRowUpdated="GridGrupos_RowUpdated"  
        OnRowUpdating="GridGrupos_RowUpdating" Width="850px" 
        OnCancelRowEditing="GridGrupos_CancelRowEditing" 
        OnStartRowEditing="GridGrupos_StartRowEditing" 
        oncustombuttoncallback="GridGrupos_CustomButtonCallback" 
        oninitnewrow="GridGrupos_InitNewRow" >
        
        <SettingsBehavior ConfirmDelete="True" AllowFocusedRow="True" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" PopupEditFormWidth="500px" />
        <SettingsCustomizationWindow Enabled="false" />
        <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />
        <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" CssPostfix="Office2003_Olive">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
            <LoadingPanel ImageSpacing="10px">
            </LoadingPanel>
        </Styles>
        <SettingsText CommandDelete="Eliminar" CommandEdit="Editar" CommandNew="Nuevo" ConfirmDelete="Está seguro que desea eliminar el registro"
            GroupPanel="&lt;b&gt;Arrastre una columna aquí para agrupar por ella&lt;/b&gt;"
            PopupEditFormCaption="Nuevo/Edición" Title="CUENTAS VARIABLES" CustomizationWindowCaption="Seleccione Columna" />
        <TotalSummary>
            <dxwgv:ASPxSummaryItem FieldName="CTVCODIGO" ShowInColumn="CTVCODIGO" ShowInGroupFooterColumn="CTVCODIGO"
                SummaryType="Count" Tag="Cantidad" />
        </TotalSummary>
        <Columns>
            <dxwgv:GridViewDataTextColumn Caption="Codigo" FieldName="CTVCODIGO" VisibleIndex="0" Name="CTVCODIGO"
                 ReadOnly="True">
                <PropertiesTextEdit>
                    <ValidationSettings>
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Descripcion" FieldName="CTVDESCRIPCION" VisibleIndex="1" >
                <PropertiesTextEdit>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                 
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataComboBoxColumn Name="CTVUNIDADMEDIDA" FieldName="CTVUNIDADMEDIDA" Caption="Unidad de Medida" VisibleIndex="2">
<PropertiesComboBox ValueType="System.String">
    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
</PropertiesComboBox>
            </dxwgv:GridViewDataComboBoxColumn>
            <dxwgv:GridViewDataComboBoxColumn Name="CTVTIPO" FieldName="CTVTIPO" Caption="Tipo Cuenta" VisibleIndex="3">
<PropertiesComboBox ValueType="System.String">
 <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
</PropertiesComboBox>
            </dxwgv:GridViewDataComboBoxColumn>
             <dxwgv:GridViewDataTextColumn  Caption="Precio" FieldName="CTVPRECIO" 
                VisibleIndex="4" 
                PropertiesTextEdit-ValidationSettings-ErrorText="Valor Debe ser Numerico" 
                PropertiesTextEdit-ValidationSettings-RegularExpression-ErrorText="Valor Debe ser Numerico" 
                PropertiesTextEdit-ValidationSettings-RequiredField-ErrorText="Valor Debe ser Numerico" 
                UnboundType="Decimal">
              <PropertiesTextEdit>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" ErrorText="Valor Numerico" />
                        <RegularExpression ErrorText="Valor Numerico"  /> 
                    </ValidationSettings>
                </PropertiesTextEdit>
               </dxwgv:GridViewDataTextColumn>
            
<dxwgv:GridViewDataDateColumn Caption="Fecha de&lt;br/&gt;creación" FieldName="FECHACREACION" ReadOnly="true"
                VisibleIndex="5">
                <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy" >
                </PropertiesDateEdit>
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewDataDateColumn Caption="Fecha de&lt;br/&gt;actualización" FieldName="FECHAMODIFICACION" ReadOnly="true"
                VisibleIndex="6">
                <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy" >
                </PropertiesDateEdit>
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" VisibleIndex="7"
                AllowDragDrop="False">
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
                <CustomButtons>
                    <dxwgv:GridViewCommandColumnCustomButton Text="Histórico de cambios de tarifa">
                        <Image AlternateText="Historico de Cambios de Precio" 
                            Url="~/Imagenes/viewmag.ico" Height="24px" Width="24px" />
                    </dxwgv:GridViewCommandColumnCustomButton>
                </CustomButtons>
                <CellStyle Wrap="False">
                </CellStyle>
            </dxwgv:GridViewCommandColumn>
        </Columns>
        <Images ImageFolder="~/App_Themes/Office2003 Olive/{0}/">
            <CollapsedButton Height="12px" Url="~/App_Themes/Office2003 Olive/GridView/gvCollapsedButton.png"
                Width="11px" />
            <ExpandedButton Height="12px" Url="~/App_Themes/Office2003 Olive/GridView/gvExpandedButton.png"
                Width="11px" />
            <DetailCollapsedButton Height="12px" Url="~/App_Themes/Office2003 Olive/GridView/gvCollapsedButton.png"
                Width="11px" />
            <DetailExpandedButton Height="12px" Url="~/App_Themes/Office2003 Olive/GridView/gvExpandedButton.png"
                Width="11px" />
            <FilterRowButton Height="13px" Width="13px" />
        </Images>
        <SettingsPager>
            <Summary AllPagesText="Páginas: {0} - {1} ({2}Cuentas)" Text="Página {0} of {1} ({2} Cuentas)" />
        </SettingsPager>
        <SettingsDetail AllowOnlyOneMasterRowExpanded="True"></SettingsDetail>
        <Templates>
            <DetailRow>
                <div id="detalle">
                </div>
            </DetailRow>
        </Templates>
        <Settings ShowGroupPanel="True" ShowFilterRow="True" ShowFooter="True" ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
        
    
</asp:Content>
