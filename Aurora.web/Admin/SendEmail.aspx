<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="Aurora.Web.Admin.SendEmail" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3.Export, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallbackPanel" tagprefix="dxcp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCallback" tagprefix="dxcb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


        .style5
        {
            width: 85%;
            height: 43px;
        }
        .style6
        {
        }
        .style7
        {
        }
    .dxgvControl,
.dxgvDisabled
{
	border: Solid 1px #9F9F9F;
	font: 11px Tahoma;
	background-color: #F2F2F2;
	color: Black;
	cursor: default;
}
.dxgvGroupPanel
{
	white-space: nowrap;
	font-size: 9pt;
	
	background-color: #EDEDED;
	color: #8D8D8D;
	border-bottom: Solid 1px #9F9F9F;
	padding: 7px 4px 8px 6px;
}

.dxgvTable
{
	background-color: White;
	border: 0;
	border-collapse: separate!important;
	overflow: hidden;
	font: 9pt Tahoma;
	color: Black;
}

.dxgvHeader {
	cursor: pointer;
	white-space: nowrap;
	padding: 4px 6px 5px 6px;
	border: Solid 1px #9F9F9F;
	background-color: #DCDCDC;
	overflow: hidden;
	-moz-user-select: none;
	font-weight: normal;
	text-align: left;	
}
.dxgvFilterRow 
{
	background-color: #E7E7E7;
}
.dxgvCommandColumn
{
	padding: 2px 2px 2px 2px;
}
.dxeTextBox, .dxeMemo
{
    background-color: white;
    border: solid 1px #9f9f9f;
}

.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}

.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}
.dxeButtonEditButton,
.dxeSpinIncButton, .dxeSpinDecButton, .dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{
    padding: 0px 2px 0px 3p  background-repeat: repeat-x;
    background-position: top;    
    background-color: #e6e6e6;
}
.dxeButtonEditButton, .dxeCalendarButton,
.dxeSpinIncButton, .dxeSpinDecButton,
.dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
	cursor: hand;
} 
.dxgvFooter
{
	background-color: #D7D7D7;
	white-space: nowrap;
}
.dxgvControl .dxpControl, .dxgvDisabled .dxpControl
{
	padding-top: 4px;    
}

.dxpControl
{
	font: 9pt Tahoma;
	color: black;
	padding: 5px 2px 5px 2px;
}
.dxpSummary
{
	font: 9pt Tahoma;
	color: black;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
	padding: 1px 4px 0px 4px;
}
.dxpDisabled
{
	color: #acacac;
	border-color: #808080;
	cursor: default;
}

.dxpDisabledButton
{
	font: 9pt Tahoma;
	color: black;
	text-decoration: none;
}
.dxpButton
{
	font: 9pt Tahoma;
	color: #394EA2;
	text-decoration: underline;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
}
.dxpCurrentPageNumber
{
	font: 9pt Tahoma;
	color: black;
	font-weight: bold;
	text-decoration: none;
	padding: 1px 3px 0px 3px;
}
.dxpPageNumber
{
	font: 9pt Tahoma;
	color: #394EA2;
	text-decoration: underline;
	text-align: center;
	vertical-align: middle;
	padding: 1px 5px 0px 5px;
}
        #textAreaResult
        {
            width: 408px;
            height: 157px;
        }
        #Select1
        {
            width: 391px;
        }
        #SelectResult
        {
            width: 392px;
            height: 220px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <br/>
 <br/>
 <br/>
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" 
        BackColor="#E2E8C9" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" EnableDefaultAppearance="False" 
        HeaderText="Seleccione mes y año de la nómina a enviar masivamente" 
        ImageFolder="~/App_Themes/Office2003 Olive/{0}/">
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
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
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
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                <dxe:ASPxButton ID="btnValidar" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" OnClick="btnBuscarNomina_Click" 
                    Text="Validar Envíos">
                </dxe:ASPxButton>
            </td>
            <td class="style6">
                <dxe:ASPxButton ID="btnGuardarNotas" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" OnClick="btnGuardarNotas_Click" 
                    Text="Guardar Notas de Cobro">
                </dxe:ASPxButton>
            </td>
        </tr>
    </table>
            </dxp:PanelContent>
</PanelCollection>
        <TopLeftCorner Height="9px" 
            Url="~/App_Themes/Office2003 Olive/Web/rpTopLeftCorner.png" Width="9px" />
        <BottomLeftCorner Height="9px" 
            Url="~/App_Themes/Office2003 Olive/Web/rpBottomLeftCorner.png" Width="9px" />
    </dxrp:ASPxRoundPanel>

<BR/>
<BR/>

    <br />
    <br />
                <dxwgv:ASPxGridView ID="gridNoMail" runat="server" Visible="False">
                    <Styles>
                        <Table Font-Names="Verdana" Font-Size="X-Small">
                        </Table>
                    </Styles>
                    <SettingsText Title="Estos propietarios no serán incluidos en el envío masivo pues no se han completado las lecturas de luz o agua.&lt;br/&gt; Para estos se deben enviar los correos  individalmente desde la nota de cobro." />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="COSTO" ShowInColumn="MONTO A PAGAR" 
                            SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="GVMONTOCANCELADO" 
                            ShowInColumn="MONTO CANCELADO" SummaryType="Sum" />
                    </TotalSummary>
                    <Settings ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
            
 
     <br />
                                <dxe:ASPxButton ID="btnExport" runat="server" Text="Exportar a XLS" 
                                    onclick="btnExportE_Click" Visible="False">
                                </dxe:ASPxButton>
                            <input id="idCorreos" type="hidden" runat="server"/>
                            <br />
                <dxwgv:ASPxGridView ID="gridMailEnviados" runat="server" 
        Visible="False">
                    <Styles>
                        <Table Font-Names="Verdana" Font-Size="X-Small">
                        </Table>
                    </Styles>
                    <SettingsText Title="A estos propietarios ya se le envió el correo." />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="COSTO" ShowInColumn="MONTO A PAGAR" 
                            SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="GVMONTOCANCELADO" 
                            ShowInColumn="MONTO CANCELADO" SummaryType="Sum" />
                    </TotalSummary>
                    <Settings ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
            
 
     <br />
                                <dxe:ASPxButton ID="btnExportEnviados" 
        runat="server" Text="Exportar a XLS" 
                                    onclick="btnExportEnviados_Click" 
        Visible="False">
                                </dxe:ASPxButton>
                            <br />
                            <br />
 
            <dxe:ASPxButton ID="btnComenzarEnvio" 
        runat="server" Text="Comenzar Envíos de correos" 
        onclick="btnComenzarEnvio_Click" Visible="False">
                <ClientSideEvents Click="function(s, e) {

}

" />
                                </dxe:ASPxButton>
    <br />
                    <asp:Label ID="lblresult" runat="server"></asp:Label>
                    <br />
                    <br />
    
    <br />
 
            
 
     <br />
    
                 <dxwgv:ASPxGridViewExporter ID="gridExporter" runat="server"  
                     GridViewID="gridNoMail" >
                 </dxwgv:ASPxGridViewExporter>
    
 
     <br />
    
                 <dxwgv:ASPxGridViewExporter ID="gridExporter0" runat="server"  
                     GridViewID="gridMailEnviados" >
                 </dxwgv:ASPxGridViewExporter>
    
 
     </asp:Content>