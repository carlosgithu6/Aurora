<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="Cambiopass.aspx.cs" Inherits="Aurora.Web.Escritorio.Cambiopass" Title="Untitled Page" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
<br />
<br />
                  <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="450px" 
                      BackColor="#ECFEDA" CssFilePath="~/App_Themes/GreenLeaf/{0}/styles.css" 
                      CssPostfix="GreenLeaf" HeaderText="CAMBIO DE CONTRASEÑA" 
                      View="GroupBox">
                      <BottomRightCorner Height="16px" 
                          Url="~/App_Themes/GreenLeaf/Web/rpBottomRightCorner.png" Width="16px" />
                      <ContentPaddings Padding="0px" />
                      <Border BorderColor="#94C43A" BorderStyle="Solid" BorderWidth="2px" />
                      <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="Medium">
                      <Border BorderColor="#94C43A" BorderStyle="Solid" BorderWidth="1px" />
                      </HeaderStyle>
                      <PanelCollection>
<dxp:PanelContent runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" 
        CancelButtonImageUrl="~/Imagenes/button_cancel.ico" CancelButtonText="Cancelar" 
        CancelButtonType="Image" 
        ChangePasswordButtonImageUrl="~/Imagenes/button_ok.ico" 
        ChangePasswordButtonText="Cambiar contraseña" ChangePasswordButtonType="Image" 
        ChangePasswordTitleText="" 
        ConfirmNewPasswordLabelText="Confirme la nueva contraseña:" 
        ConfirmPasswordCompareErrorMessage="Las contraseñas ingresadas no coinciden" 
        ConfirmPasswordRequiredErrorMessage="La nueva contraseña es requerida." 
        OnChangedPassword="ChangePassword1_ChangedPassword" 
        PasswordLabelText="Constraseña:" 
        PasswordRequiredErrorMessage="Debe ingresar contraseña" 
        SuccessText="Tu contraseña ha sido cambiada" 
        SuccessTitleText="Cambio de contraseña completado" Font-Names="Verdana" 
        Font-Size="Small" OnCancelButtonClick="ChangePassword1_CancelButtonClick" 
        OnChangingPassword="ChangePassword1_ChangingPassword">
        <CancelButtonStyle Height="24px" />
        <ChangePasswordButtonStyle Height="24px" Width="24px" />
        <TextBoxStyle Font-Bold="True" />
    </asp:ChangePassword>
    <dxe:ASPxLabel ID="lblmensajepass" runat="server" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive">
    </dxe:ASPxLabel>
    <br />
 </dxp:PanelContent>
</PanelCollection>
                      <TopLeftCorner Height="16px" 
                          Url="~/App_Themes/GreenLeaf/Web/rpTopLeftCorner.png" Width="16px" />
                  </dxrp:ASPxRoundPanel>
            
</asp:Content>
