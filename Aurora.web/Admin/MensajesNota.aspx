<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="MensajesNota.aspx.cs" Inherits="Aurora.Web.MensajesNota" Title="Administrar Mensajes de Notas de cobro " %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <dxwgv:ASPxGridView ID="Gridmsg" runat="server" AutoGenerateColumns="False" 
        ClientInstanceName="Gridmsg" KeyFieldName="ID" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" onrowupdated="Gridmsg_RowUpdated" 
        onrowupdating="Gridmsg_RowUpdating" onstartrowediting="Gridmsg_StartRowEditing">
        <SettingsEditing Mode="PopupEditForm" />
        <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
            CssPostfix="Office2003_Olive">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
            <LoadingPanel ImageSpacing="10px">
            </LoadingPanel>
        </Styles>
        <SettingsText Title="Actualizar Mensajes de notas de cobro" />
        <Columns>
            <dxwgv:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" 
                VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="AÑO" FieldName="ANO" ReadOnly="True" 
                VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="MES" FieldName="MES" Name="MES" 
                ReadOnly="True" VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataMemoColumn Caption="MSG" FieldName="MSG" VisibleIndex="2">
                <PropertiesMemoEdit Height="50px" Rows="10" Width="300px">
                </PropertiesMemoEdit>
            </dxwgv:GridViewDataMemoColumn>
            <dxwgv:GridViewCommandColumn VisibleIndex="3" ButtonType="Image" 
                Caption="Opciones">
                <EditButton Visible="True">
                    <Image Height="24px" Url="~/Imagenes/Files-text.ico" Width="24px" />
                </EditButton>
                <CancelButton>
                    <Image Height="24px" Url="~/Imagenes/cross_circle_frame.png" Width="24px" />
                </CancelButton>
                <UpdateButton>
                    <Image Height="24px" Url="~/Imagenes/disk.png" Width="24px" />
                </UpdateButton>
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
        <SettingsPager PageSize="24">
        </SettingsPager>
        <Settings ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
</asp:Content>
