<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aurora.Web._Default" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SISTEMA DE GESTIÓN DE COBRANZAS "LA AURORA"</title>
</head>
<body>
    <form id="form1" runat="server">
    <div >
    <br/>
    <br/>
    <br/>
    <table cellpadding="0" cellspacing="0" align = "center" 
            
            style="height: 466px; width: 529px; background-image: url('Imagenes/Aurora3.jpg'); background-repeat: no-repeat;"  >
    <tr>
            <td align="center" >
                  <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="200px" 
                      BackColor="#ECFEDA" CssFilePath="~/App_Themes/GreenLeaf/{0}/styles.css" 
                      CssPostfix="GreenLeaf" HeaderText="LA AURORA" 
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
    <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" 
        LoginButtonImageUrl="~/Imagenes/button_ok.ico" LoginButtonType="Image" 
        PasswordLabelText="Contraseña:" TitleText="Entrar a AuroGes" 
        UserNameLabelText="RUT:" UserNameRequiredErrorMessage="*" 
        Font-Bold="True" Font-Names="Verdana" Font-Size="Small" 
        OnAuthenticate="Login1_Authenticate">
        <LoginButtonStyle Height="24px" Width="24px" />
    </asp:Login>
 </dxp:PanelContent>
</PanelCollection>
                      <TopLeftCorner Height="16px" 
                          Url="~/App_Themes/GreenLeaf/Web/rpTopLeftCorner.png" Width="16px" />
                  </dxrp:ASPxRoundPanel>
            </td>
    </tr>
    </table>   
    </div>
    </form>
</body>
</html>
