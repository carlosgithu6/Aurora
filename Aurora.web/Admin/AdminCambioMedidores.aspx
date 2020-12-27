<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="AdminCambioMedidores.aspx.cs" Inherits="Aurora.Web.Admin.AdminCambioMedidores"  %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dxwgv:ASPxGridView ID="GridMedidores"   runat="server" ClientInstanceName="GridMedidores"
        AutoGenerateColumns="False" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css"
        CssPostfix="Office2003_Olive" KeyFieldName="CMFECHACAMBIO" OnRowDeleted="GridGrupos_RowDeleted1"
        OnRowDeleting="GridGrupos_RowDeleting1"  OnRowInserted="GridGrupos_RowInserted"
        OnRowInserting="GridGrupos_RowInserting"  Width="850px" 
        onrowupdated="GridMedidores_RowUpdated" 
        onrowupdating="GridMedidores_RowUpdating">
        <SettingsBehavior ConfirmDelete="true"  />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" PopupEditFormWidth="500px" />
        <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" CssPostfix="Office2003_Olive">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
            <LoadingPanel ImageSpacing="10px">
            </LoadingPanel>
        </Styles>
        <SettingsText CommandDelete="Eliminar" CommandNew="Nuevo" ConfirmDelete="Está seguro que desea eliminar el registro"
            PopupEditFormCaption="Nuevo/Edición" Title="CUENTAS ESPECIALES" />
         <Columns>
            <dxwgv:GridViewDataComboBoxColumn Caption="TIPO CUENTA" FieldName="CTVCODIGO" 
                 VisibleIndex="0">
                <PropertiesComboBox ValueType="System.String">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dxwgv:GridViewDataComboBoxColumn>
            <dxwgv:GridViewDataDateColumn Caption="FECHA CAMBIO" FieldName="CMFECHACAMBIO" 
                VisibleIndex="1">
           
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewDataTextColumn Caption="LECTURA" FieldName="CMLECTURA" 
                VisibleIndex="2">
               
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="MOTIVO" FieldName="CMMOTIVO" 
                VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" VisibleIndex="4"
                AllowDragDrop="False" Name="OPCIONES">
                <EditButton Visible="True">
                    <Image Url="~/Imagenes/Files-text.ico" />
                </EditButton>
                <NewButton Visible="True">
                    <Image Url="~/Imagenes/edit_add.ico" />
                </NewButton>
                <DeleteButton Visible="True">
                    <Image Url="~/Imagenes/edit_remove.ico" />
                </DeleteButton>
                <CancelButton>
                    <Image Url="~/Imagenes/cross_circle_frame.png" />
                </CancelButton>
                <UpdateButton>
                    <Image Url="~/Imagenes/disk.png" />
                </UpdateButton>
                <ClearFilterButton Text="Limpiar Filtros" Visible="True">
                    <Image AlternateText="Limpiar filtros" Url="~/Imagenes/escobachica.jpg" />
                </ClearFilterButton>
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
        <SettingsDetail ShowDetailButtons="False" />
       <Settings ShowFooter="True" ShowTitlePanel="True" ShowFilterRow="True" 
            ShowGroupPanel="True" />
    </dxwgv:ASPxGridView>
</asp:Content>
