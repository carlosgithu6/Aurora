<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="AdminHistCambioPrecio.aspx.cs"
    Inherits="Aurora.Web.Admin.AdminHistCambioPrecio" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
    <br />
    <br />
         <dxwgv:ASPxGridView ID="GridGrupos" ClientInstanceName="GridGrupos" runat="server"
        AutoGenerateColumns="True" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css"
        CssPostfix="Office2003_Olive" KeyFieldName="CTVCODIGO" 
        >
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
            PopupEditFormCaption="Nuevo/Edición" 
                 Title="HISTÓRICO DE CAMBIOS DE TARIFA EN CUENTAS VARIABLES" 
                 CustomizationWindowCaption="Seleccione Columna" />
        <TotalSummary>
            <dxwgv:ASPxSummaryItem FieldName="CTVCODIGO" ShowInColumn="CTVCODIGO" ShowInGroupFooterColumn="CTVCODIGO"
                SummaryType="Count" Tag="Cantidad" />
        </TotalSummary>
        <SettingsPager>
            <Summary AllPagesText="Páginas: {0} - {1} ({2}Usuarios)" Text="Página {0} of {1} ({2} Usuarios)" />
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
    
    </div>
    <asp:Button ID="Button1" runat="server" Text="Volver" onclick="Button1_Click" style="padding: 0px; margin: 0px; background-color: #339933" />
  
    
  </asp:Content>
