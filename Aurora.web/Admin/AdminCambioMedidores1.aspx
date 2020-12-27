<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="AdminCambioMedidores1.aspx.cs" Inherits="Aurora.Web.Admin.AdminCambioMedidores"  %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  
    <dxwgv:ASPxGridView ID="GridMedidores" runat="server" 
        AutoGenerateColumns="False" ClientInstanceName="GridMedidores" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" KeyFieldName="CMFECHACAMBIO" 
        oncustombuttoncallback="GridMedidores_CustomButtonCallback" 
        onrowinserted="GridMedidores_RowInserted" 
        onrowinserting="GridMedidores_RowInserting">
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="500px" />
        <ClientSideEvents CustomButtonClick="function(s, e) {
	 if (e.buttonID == 'Borrar')
                          {
   
                                if (confirm('¿Está seguro que desea eliminar el registro?'))
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
        <SettingsText ConfirmDelete="¿Esta seguro que quiere eliminar el registro?" />
        <Columns>
            <dxwgv:GridViewDataComboBoxColumn Caption="TIPO" FieldName="CTVCODIGO" 
                VisibleIndex="0">
                <PropertiesComboBox ValueType="System.String">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
            </dxwgv:GridViewDataComboBoxColumn>
            <dxwgv:GridViewDataDateColumn Caption="FECHA DE CAMBIO" 
                FieldName="CMFECHACAMBIO" UnboundType="DateTime" VisibleIndex="1">
                <PropertiesDateEdit DisplayFormatString="">
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesDateEdit>
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewDataTextColumn Caption="LECTURA" FieldName="CMLECTURA" 
                VisibleIndex="2">
                <PropertiesTextEdit>
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="MOTIVO" FieldName="CMMOTIVO" 
                VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="OPCIONES" 
                VisibleIndex="4">
                <NewButton Visible="True">
                    <Image Url="~/Imagenes/edit_add.ico" Height="24px" Width="24px" />
                </NewButton>
                <CancelButton>
                    <Image Url="~/Imagenes/cross_circle_frame.png" Height="24px" Width="24px" />
                </CancelButton>
                <UpdateButton>
                    <Image Url="~/Imagenes/disk.png" Height="24px" Width="24px" />
                </UpdateButton>
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
                <CustomButtons>
                    <dxwgv:GridViewCommandColumnCustomButton ID="Borrar" Text="Borrar">
                        <Image Url="~/Imagenes/edit_remove.ico" Height="24px" Width="24px" />
                    </dxwgv:GridViewCommandColumnCustomButton>
                </CustomButtons>
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
        <Settings ShowTitlePanel="True" />
        <SettingsCustomizationWindow PopupHorizontalOffset="200" 
            PopupVerticalOffset="200" />
    </dxwgv:ASPxGridView>
    
  
</asp:Content>
