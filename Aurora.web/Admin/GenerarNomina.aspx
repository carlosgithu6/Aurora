<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="GenerarNomina.aspx.cs" Inherits="Aurora.Web.Admin.GenerarNomina" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
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
.dxgvCommandColumn_Office2003_Olive
{
	padding: 2px 2px 2px 2px;
}
.dxgvFooter_Office2003_Olive
{	
	background-color: #bdcb85;
	white-space:nowrap;
}
        
        .style5
        {
            width: 85%;
            height: 43px;
        }
        .style6
        {
            width: 5px;
        }
        .style7
        {
            width: 153px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br/>
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" 
        BackColor="#E2E8C9" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" EnableDefaultAppearance="False" 
        HeaderText="Seleccione mes y año" 
        ImageFolder="~/App_Themes/Office2003 Olive/{0}/" Height="143px" 
        Width="341px">
        <TopEdge>
            <BackgroundImage HorizontalPosition="left" 
                ImageUrl="~/App_Themes/Office2003 Olive/Web/rpTopEdge.png" Repeat="RepeatX" 
                VerticalPosition="top" />
        </TopEdge>
        <BottomRightCorner Height="9px" 
            Url="~/App_Themes/Office2003 Olive/Web/rpBottomRightCorner.png" Width="9px" />
        <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
        <NoHeaderTopRightCorner Height="9px" 
            Url="~/App_Themes/Office2003 Olive/Web/rpNoHeaderTopRightCorner.png" 
            Width="9px" />
        <HeaderRightEdge>
            <BackgroundImage HorizontalPosition="left" 
                ImageUrl="~/App_Themes/Office2003 Olive/Web/rpHeader.png" Repeat="RepeatX" 
                VerticalPosition="top" />
        </HeaderRightEdge>
        <Border BorderColor="#758D5E" BorderStyle="Solid" BorderWidth="1px" />
        <HeaderLeftEdge>
            <BackgroundImage HorizontalPosition="left" 
                ImageUrl="~/App_Themes/Office2003 Olive/Web/rpHeader.png" Repeat="RepeatX" 
                VerticalPosition="top" />
        </HeaderLeftEdge>
        <HeaderStyle BackColor="#B5C48F">
        <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px" 
            PaddingRight="2px" />
        <BorderBottom BorderColor="#758D5E" BorderStyle="Solid" BorderWidth="1px" />
        </HeaderStyle>
        <TopRightCorner Height="9px" 
            Url="~/App_Themes/Office2003 Olive/Web/rpTopRightCorner.png" Width="9px" />
        <HeaderContent>
            <BackgroundImage HorizontalPosition="left" 
                ImageUrl="~/App_Themes/Office2003 Olive/Web/rpHeader.png" Repeat="RepeatX" 
                VerticalPosition="top" />
        </HeaderContent>
        <DisabledStyle ForeColor="Gray">
        </DisabledStyle>
        <NoHeaderTopEdge BackColor="#E2E8C9">
        </NoHeaderTopEdge>
        <NoHeaderTopLeftCorner Height="9px" 
            Url="~/App_Themes/Office2003 Olive/Web/rpNoHeaderTopLeftCorner.png" 
            Width="9px" />
        <PanelCollection>
<dxp:PanelContent runat="server">
    <table align="center" class="style5">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <dxe:ASPxComboBox ID="lstMes" runat="server" ClientInstanceName="lstMes" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" ImageFolder="~/App_Themes/Office2003 Olive/{0}/" 
                    ValueType="System.String">
                    <Items>
                        <dxe:ListEditItem Text="Enero" Value="1" />
                        <dxe:ListEditItem Text="Febrero" Value="2" />
                        <dxe:ListEditItem Text="Marzo" Value="3" />
                        <dxe:ListEditItem Text="Abril" Value="4" />
                        <dxe:ListEditItem Text="Mayo" Value="5" />
                        <dxe:ListEditItem Text="Junio" Value="6" />
                        <dxe:ListEditItem Text="Julio" Value="7" />
                        <dxe:ListEditItem Text="Agosto" Value="8" />
                        <dxe:ListEditItem Text="Septiembre" Value="9" />
                        <dxe:ListEditItem Text="Octubre" Value="10" />
                        <dxe:ListEditItem Text="Noviembre" Value="11" />
                        <dxe:ListEditItem Text="Diciembre" Value="12" />
                    </Items>
                    <buttonstyle width="13px">
                    </buttonstyle>
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <dxe:ASPxComboBox ID="lstAnos" runat="server" ClientInstanceName=lstAnos
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" ImageFolder="~/App_Themes/Office2003 Olive/{0}/" 
                    ValueType="System.String">
                    <buttonstyle width="13px">
                    </buttonstyle>
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
            </dxp:PanelContent>
</PanelCollection>
        <TopLeftCorner Height="9px" 
            Url="~/App_Themes/Office2003 Olive/Web/rpTopLeftCorner.png" Width="9px" />
        <BottomLeftCorner Height="9px" 
            Url="~/App_Themes/Office2003 Olive/Web/rpBottomLeftCorner.png" Width="9px" />
    </dxrp:ASPxRoundPanel>


    <dxe:ASPxButton ID="btnNomina" runat="server" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" onclick="btnNomina_Click" 
        ValidationGroup="AA">
    </dxe:ASPxButton>
<br/>
   
    <dxe:ASPxButton ID="btnCerrarNomina" runat="server" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" onclick="btnCerrarNomina_Click" 
        ClientInstanceName="btnCerrarNomina" ValidationGroup="AA">
        <ClientSideEvents Click="function(s, e) {
	confirm(&quot;Está seguro?&quot;)
}" />
    </dxe:ASPxButton>
    <br />
    <dxe:ASPxLabel ID="lblMensaje" runat="server" Text="">
    </dxe:ASPxLabel>
 
</asp:Content>
