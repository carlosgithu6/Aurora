<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="CuentaCorriente.aspx.cs" Inherits="Aurora.Web.Admin.CuentaCorriente" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dxpc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

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
.dxgvCommandColumn_Office2003_Olive
{
	padding: 2px 2px 2px 2px;
}
.dxgvFooter_Office2003_Olive
{	
	background-color: #bdcb85;
	white-space:nowrap;
}
        .style8
        {
            width: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
<br/>
<br/>


  <br />
    <br />
    
       <asp:Substitution ID="Substitution1" runat="server" />
    
       <dxrp:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" BackColor="#E2E8C9" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" EnableDefaultAppearance="False" 
        HeaderText="Datos del propietario" 
        ImageFolder="~/App_Themes/Office2003 Olive/{0}/" Visible="False" Width="500px">
           <BottomRightCorner Height="3px" 
               Url="~/Images/ASPxRoundPanel/1841755099/BottomRightCorner.png" 
               Width="3px" />
           <ContentPaddings Padding="2px" PaddingBottom="10px" PaddingTop="10px" />
           <NoHeaderTopRightCorner Height="3px" 
               Url="~/Images/ASPxRoundPanel/1841755099/NoHeaderTopRightCorner.png" 
               Width="3px" />
           <Border BorderColor="#758D5E" BorderStyle="Solid" BorderWidth="0px" />
           <HeaderStyle BackColor="#B5C48F">
           <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px" 
               PaddingRight="2px" />
           <BorderBottom BorderStyle="None" />
           </HeaderStyle>
           <TopRightCorner Height="3px" 
               Url="~/Images/ASPxRoundPanel/1841755099/TopRightCorner.png" Width="3px" />
           <DisabledStyle ForeColor="Gray">
           </DisabledStyle>
           <NoHeaderTopEdge BackColor="#E2E8C9">
           </NoHeaderTopEdge>
           <NoHeaderTopLeftCorner Height="3px" 
               Url="~/Images/ASPxRoundPanel/1841755099/NoHeaderTopLeftCorner.png" 
               Width="3px" />
           <PanelCollection>
<dxp:PanelContent runat="server">
    <table align="center" cellpadding="0" cellspacing="2" class="style5" 
        width="100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <dxe:ASPxLabel ID="lblFecha" runat="server" Font-Bold="True">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td align="left">
                Rut</td>
            <td align="left">
                <dxe:ASPxLabel ID="lblRut" runat="server">
                </dxe:ASPxLabel>
            </td>
            <td align="left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left">
                Nombre</td>
            <td align="left">
                <dxe:ASPxLabel ID="lblNombre" runat="server">
                </dxe:ASPxLabel>
            </td>
            <td align="left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left">
                Propiedad</td>
            <td align="left">
                <dxe:ASPxLabel ID="lblPropiedad" runat="server">
                </dxe:ASPxLabel>
            </td>
            <td align="left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left">
                Socio</td>
            <td align="left">
                <dxe:ASPxLabel ID="lblSocio" runat="server">
                </dxe:ASPxLabel>
            </td>
            <td align="left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
               </dxp:PanelContent>
</PanelCollection>
           <TopLeftCorner Height="3px" 
               Url="~/Images/ASPxRoundPanel/1841755099/TopLeftCorner.png" Width="3px" />
           <BottomLeftCorner Height="3px" 
               Url="~/Images/ASPxRoundPanel/1841755099/BottomLeftCorner.png" 
               Width="3px" />
    </dxrp:ASPxRoundPanel>
    
       <br />
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
            <td class="style7" colspan="2">
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7" colspan="2">
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <dxe:ASPxButton ID="btnBuscarNomina" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" OnClick="btnBuscarNomina_Click" 
                    Text="Buscar nómina" ValidationGroup="AA">
                </dxe:ASPxButton>
            </td>
            <td class="style7">
                <dxe:ASPxButton ID="btnOpcionMultipago" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" OnClick="btnOpcionMultipago_Click" 
                    Text="Multipago" ValidationGroup="AA">
                </dxe:ASPxButton>
            </td>
            <td>
                <dxe:ASPxButton ID="ASPxButton1" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" OnClick="ASPxButton1_Click" ValidationGroup="AA">
                    <Image Height="24px" Url="~/Imagenes/frameprint.png" Width="24px" />
                </dxe:ASPxButton>
            </td>
            <td>
                <dxe:ASPxButton ID="btnRecibo" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" OnClick="btnRecibo_Click" ValidationGroup="AA">
                    <Image Height="24px" Url="~/Imagenes/billete.png" Width="24px" />
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


       <dxpc:ASPxPopupControl ID="ASPxPopupControl1" runat="server" 
        ClientInstanceName="popupControl" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" EnableHotTrack="False" 
        HeaderText="Fecha de cheque" 
        ImageFolder="~/App_Themes/Office2003 Olive/{0}/" PopupHorizontalAlign="Center" 
        PopupVerticalAlign="Middle" AllowDragging="True" Height="143px" 
        Width="251px" PopupHorizontalOffset="500" PopupVerticalOffset="500">
           <SizeGripImage Height="16px" Width="16px" />
           <ContentCollection>
<dxpc:PopupControlContentControl runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <dxe:ASPxDateEdit ID="ASPxDateEdit1" runat="server" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" ImageFolder="~/App_Themes/Office2003 Olive/{0}/">
        <ButtonStyle Width="13px">
        </ButtonStyle>
    </dxe:ASPxDateEdit>
    <br />
 
          <table style="border:none">
                        <tr>
                            <td>
                                <dxe:ASPxButton ID="btnOK" runat="server" AutoPostBack="False" 
                                    Text="Guardar Fecha" Width="110px" OnClick="btnOK_Click">
                                </dxe:ASPxButton>
                            </td>
                            <td>
                                <dxe:ASPxButton ID="btnCancel" runat="server" AutoPostBack="False" ClientInstanceName="btnCancel"
                                    Text="Cancelar" Width="80px" >
                                    <ClientSideEvents Click="function(s, e) {
	                                        popupControl.Hide();
}" />
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    </ContentTemplate>
    </asp:UpdatePanel>
    </dxpc:PopupControlContentControl>
</ContentCollection>
           <CloseButtonImage Height="12px" Width="13px" />
           <HeaderStyle>
           <Paddings PaddingRight="6px" />
           </HeaderStyle>
    </dxpc:ASPxPopupControl>


       <dxpc:ASPxPopupControl ID="MultipagoControl" runat="server" 
        ClientInstanceName="popupMultipago" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" EnableHotTrack="False" 
        HeaderText="Multipago de cuentas" 
        ImageFolder="~/App_Themes/Office2003 Olive/{0}/" PopupHorizontalAlign="Center" 
        PopupVerticalAlign="Middle" AllowDragging="True" Height="280px" 
        Width="500px" PopupHorizontalOffset="500" PopupVerticalOffset="500" 
        PopupAction="None">
           <SizeGripImage Height="16px" Width="16px" />
           <ContentCollection>
<dxpc:PopupControlContentControl runat="server">
    <table class="style8">
        <tr>
            <td>
                Monto a Cancelar
            </td>
            <td>
                <dxe:ASPxTextBox ID="txtMontoApagar" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" Width="170px">
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                        <RegularExpression ErrorText="Solo Dígitos" 
                            ValidationExpression="^[0-9]\d{0,9}(\,\d{1,3})?%?$" />
                    </ValidationSettings>
                </dxe:ASPxTextBox>
            </td>
            <td>
                <dxe:ASPxButton ID="btnPagar" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" OnClick="ASPxButton2_Click" Text="Verificar Distribución" 
                    ValidationGroup="AA">
                </dxe:ASPxButton>
            </td>
            <td>
                <dxe:ASPxButton ID="BtnConfirmarPago" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive"  Text="Confirmar Pago" 
                    ValidationGroup="AA" OnClick="BtnConfirmarPago_Click">
                </dxe:ASPxButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <dxe:ASPxLabel ID="lblFormaPago" runat="server" Text="Forma de pago" 
                    Visible="False">
                </dxe:ASPxLabel>
                <dxe:ASPxComboBox ID="cb_formaPago" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" ImageFolder="~/App_Themes/Office2003 Olive/{0}/" 
                    ValueType="System.String" Visible="False" SelectedIndex="4">
                    <Items>
                        <dxe:ListEditItem Text="Efectivo" Value="0" />
                        <dxe:ListEditItem Text="Cheque a fecha" Value="1" />
                        <dxe:ListEditItem Text="Vale Vista" Value="2" />
                        <dxe:ListEditItem Text="Deuda Castigada" Value="4" />
                        <dxe:ListEditItem Text="Transferencia" Value="10" />
                    </Items>
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
            <td colspan="2">
                <dxe:ASPxLabel ID="lblFechaPago" runat="server" Text="Fecha de Pago" 
                    Visible="False">
                </dxe:ASPxLabel>
                <dxe:ASPxDateEdit ID="dt_fechaCheque" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" ImageFolder="~/App_Themes/Office2003 Olive/{0}/" 
                    Visible="False">
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxDateEdit>
            </td>
        </tr>
    </table>

    <br />
    <dxe:ASPxLabel ID="lblError" runat="server" ForeColor="#FF3300" Visible="False">
    </dxe:ASPxLabel>
    <dxe:ASPxLabel ID="lblResultado" runat="server" ForeColor="#009933" 
        Visible="False">
    </dxe:ASPxLabel>

</dxpc:PopupControlContentControl>
</ContentCollection>
           <CloseButtonImage Height="12px" Width="13px" />
           <HeaderStyle>
           <Paddings PaddingRight="6px" />
           </HeaderStyle>
    </dxpc:ASPxPopupControl>


       <br />
                <dxwgv:ASPxGridView ID="ASPxGridViewFijos" runat="server" AutoGenerateColumns="False"
                    ClientInstanceName="GridCFijas" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css"
                    CssPostfix="Office2003_Olive" KeyFieldName="CFCODIGO" Width="450px" 
                    onrowupdated="ASPxGridViewFijos_RowUpdated" 
                    onrowupdating="ASPxGridViewFijos_RowUpdating" 
                    oncancelrowediting="ASPxGridViewFijos_CancelRowEditing" 
                    onstartrowediting="ASPxGridViewFijos_StartRowEditing" 
        Visible="False" 
        onhtmldatacellprepared="ASPxGridViewFijos_HtmlDataCellPrepared" 
        onhtmlrowprepared="ASPxGridViewFijos_HtmlRowPrepared" 
        onhtmlcommandcellprepared="ASPxGridViewFijos_HtmlCommandCellPrepared">
                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" 
                        AllowDragDrop="False" />
                    <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" 
                        PopupEditFormWidth="500px" />
                    <SettingsCustomizationWindow Enabled="false" />
                    <Templates>
                        <DetailRow>
                            <dxwgv:ASPxGridView ID="ASPxGridDetalle" runat="server" 
                                AutoGenerateColumns="False" CssFilePath="~/App_Themes/Youthful/{0}/styles.css" 
                                CssPostfix="Youthful" KeyFieldName="NUMMOV" 
                                onbeforeperformdataselect="ASPxGridDetalle_BeforePerformDataSelect" 
                                onrowdeleted="ASPxGridDetalle_RowDeleted" 
                                onrowdeleting="ASPxGridDetalle_RowDeleting">
                                <Styles CssFilePath="~/App_Themes/Youthful/{0}/styles.css" 
                                    CssPostfix="Youthful">
                                    <Header ImageSpacing="5px" SortingImageSpacing="5px">
                                    </Header>
                                    <LoadingPanel ImageSpacing="10px">
                                    </LoadingPanel>
                                </Styles>
                                <SettingsText CommandDelete="Eliminar" 
                                    ConfirmDelete="¿Seguro desea eliminar el pago?" />
                                <TotalSummary>
                                    <dxwgv:ASPxSummaryItem FieldName="SUBMONTOCANCELADO" SummaryType="Sum" />
                                </TotalSummary>
                                <Columns>
                                    <dxwgv:GridViewDataTextColumn Caption="NUM MOV." FieldName="NUMMOV" 
                                        VisibleIndex="0">
                                    </dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="SUBMONTO" FieldName="SUBMONTOCANCELADO" 
                                        UnboundType="Decimal" VisibleIndex="1">
                                    </dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataComboBoxColumn Caption="FORMA DE PAGO" FieldName="FORMAPAGO" 
                                        VisibleIndex="2">
                                        <PropertiesComboBox ValueType="System.String">
                                            <Items>
                                                <dxe:ListEditItem Text="Indefinido" Value="100" />
                                                <dxe:ListEditItem Text="Efectivo" Value="0" />
                                                <dxe:ListEditItem Text="Cheque a Fecha" Value="1" />
                                                <dxe:ListEditItem Text="Vale Vista" Value="2" />
                                                <dxe:ListEditItem Text="Desde CCte" Value="3" />
                                                <dxe:ListEditItem Text="Deuda Castigada" Value="4" />
                                                <dxe:ListEditItem Text="Mixto" Value="5" />
                                                <dxe:ListEditItem Text="Transferencia" Value="10" />
                                            </Items>
                                        </PropertiesComboBox>
                                    </dxwgv:GridViewDataComboBoxColumn>
                                    <dxwgv:GridViewDataDateColumn Caption="FECHA PAGO" FieldName="FECHAPAGO" 
                                        VisibleIndex="3">
                                        <PropertiesDateEdit DisplayFormatString="">
                                        </PropertiesDateEdit>
                                    </dxwgv:GridViewDataDateColumn>
                                    <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" 
                                        VisibleIndex="4">
                                        <DeleteButton Visible="True">
                                            <Image Url="~/Imagenes/boton_delete.gif" Height="24px" Width="24px" />
                                        </DeleteButton>
                                        <ClearFilterButton Visible="True">
                                        </ClearFilterButton>
                                    </dxwgv:GridViewCommandColumn>
                                </Columns>
                                <SettingsLoadingPanel Text="" />
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
                                <SettingsPager Visible="False">
                                </SettingsPager>
                                <SettingsDetail IsDetailGrid="True" />
                                <Settings ShowFooter="True" />
                            </dxwgv:ASPxGridView>
                        </DetailRow>
                    </Templates>
                    <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />
                    <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                        CssPostfix="Office2003_Olive">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                        <LoadingPanel ImageSpacing="10px">
                        </LoadingPanel>
                    </Styles>
                    <SettingsText Title="CARGOS  POR CUENTAS FIJAS" CommandDelete="Eliminar" CommandEdit="Editar"
                        CommandNew="Nuevo" 
                        ConfirmDelete="Está seguro que desea eliminar el registro" />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="GCFMONTO" ShowInGroupFooterColumn="MONTO" 
                            SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="GCFMONTOCANCELADO" 
                            ShowInGroupFooterColumn="CANCELADO" SummaryType="Sum" />
                    </TotalSummary>
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="IDPROPIEDAD" 
                            FieldName="IDPROPIEDAD" ReadOnly="True" Visible="False" VisibleIndex="0" 
                            SortIndex="0" SortOrder="Ascending">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="ANO" 
                            FieldName="ANO" ReadOnly="True" Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="MES" 
                            FieldName="MES" ReadOnly="True" Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="TIPO DE &lt;br/&gt;CUENTA FIJA" 
                            FieldName="CFCODIGO" ReadOnly="True" ToolTip="CFCODIGO" VisibleIndex="2">
                            <PropertiesComboBox ValueType="System.String">
                                <Items>
                                   <%-- <dxe:ListEditItem Text="Caminos" Value="1" />
                                    <dxe:ListEditItem Text="Seguridad" Value="2" />
                                    <dxe:ListEditItem Text="Gasto Común" Value="3" />
                                    <dxe:ListEditItem Text="Otro" Value="4" />
                                    <dxe:ListEditItem Text="Recuperación otros Gastos" Value="13" />
--%>                                </Items>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="MONTO($)" FieldName="GCFMONTO" ReadOnly="True"
                            VisibleIndex="3" Width="100px">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="CANCELADO($)" FieldName="GCFMONTOCANCELADO"
                            VisibleIndex="4" Width="100px" UnboundType="Decimal">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataDateColumn Caption="FECHA DE&lt;br/&gt;PAGO" 
                            FieldName="FECHAPAGO" UnboundType="DateTime" VisibleIndex="2" Width="100px">
                            <PropertiesDateEdit DisplayFormatString="">
                            </PropertiesDateEdit>
                        </dxwgv:GridViewDataDateColumn>
                        <dxwgv:GridViewDataTextColumn Caption="SALDOCTE" FieldName="SALDOCTE" 
                            VisibleIndex="4">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="DESCONTAR CTE" UnboundType="Boolean" 
                            VisibleIndex="6" FieldName="DESCONTAR" Visible="False">
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="FORMA DE &lt;Br/&gt;PAGO" 
                            FieldName="FORMAPAGO" VisibleIndex="5" Visible="False">
                            <PropertiesComboBox ValueType="System.String">
                                
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 var item = s.GetSelectedItem();
     if(item.value==1){
         popupControl.Show()
     }
     else
      popupControl.Hide()
}" />
                                
                            <Items>
                                    
                                    
                                    
                                    
                                    
                                <dxe:ListEditItem Text="Indefinido" Value="100" /><dxe:ListEditItem Text="Efectivo" Value="0" /><dxe:ListEditItem Text="Cheque a Fecha" Value="1" /><dxe:ListEditItem Text="Vale Vista" Value="2" /><dxe:ListEditItem Text="Desde Cta Cte" Value="3" />
                                <dxe:ListEditItem Text="Deuda Castigada" Value="4" />
                                <dxe:ListEditItem Text="Mixto" Value="5" />
                                <dxe:ListEditItem Text="Transferencia" Value="10" />
                                </Items></PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" VisibleIndex="5"
                            AllowDragDrop="False">
                            <EditButton Visible="True">
                                <Image Url="~/Imagenes/Files-text.ico" Height="24px" Width="24px" />
                            </EditButton>
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
                        <Summary AllPagesText="Páginas: {0} - {1} ({2}Gastos)" Text="Página {0} of {1} ({2} Gastos)"
                            Visible="False" />
                    </SettingsPager>
                    <SettingsDetail ShowDetailRow="True" />
                    <Settings ShowFilterRow="False" ShowFooter="True" ShowGroupPanel="False" 
                        ShowTitlePanel="True" ShowGroupFooter="VisibleAlways" />
                </dxwgv:ASPxGridView>
    
       <br />
       <br />
       
    <br />
    <dxe:ASPxLabel ID="lblMensaje" runat="server" Font-Size="Large" 
        ForeColor="#FF5050" Visible="False">
    </dxe:ASPxLabel>
    <br />
       <dxwgv:ASPxGridView ID="ASPxGridVar" runat="server" 
        AutoGenerateColumns="False" ClientInstanceName="ASPxGridVar" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" EnableCallbackCompression="True" 
        KeyFieldName="CTVCODIGO" onrowupdated="ASPxGridVar_RowUpdated" 
        onrowupdating="ASPxGridVar_RowUpdating" 
        onstartrowediting="ASPxGridVar_StartRowEditing" 
        oncancelrowediting="ASPxGridVar_CancelRowEditing" 
        onhtmlcommandcellprepared="ASPxGridVar_HtmlCommandCellPrepared" 
        onhtmldatacellprepared="ASPxGridVar_HtmlDataCellPrepared" Visible="False">
           <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" 
               PopupEditFormWidth="500px" />
           <Templates>
               <DetailRow>
                   <dxwgv:ASPxGridView ID="ASPxGridDetalle2" runat="server" 
                       AutoGenerateColumns="False" CssFilePath="~/App_Themes/Youthful/{0}/styles.css" 
                       CssPostfix="Youthful" KeyFieldName="NUMMOV" 
                       onbeforeperformdataselect="ASPxGridDetalle2_BeforePerformDataSelect" 
                       onrowdeleted="ASPxGridDetalle2_RowDeleted" 
                       onrowdeleting="ASPxGridDetalle2_RowDeleting">
                       <Styles CssFilePath="~/App_Themes/Youthful/{0}/styles.css" 
                           CssPostfix="Youthful">
                           <Header ImageSpacing="5px" SortingImageSpacing="5px">
                           </Header>
                           <LoadingPanel ImageSpacing="10px">
                           </LoadingPanel>
                       </Styles>
                       <SettingsText CommandDelete="Eliminar" 
                           ConfirmDelete="¿Seguro desea eliminar el pago?" />
                       <TotalSummary>
                           <dxwgv:ASPxSummaryItem FieldName="SUBMONTOCANCELADO" SummaryType="Sum" />
                       </TotalSummary>
                       <Columns>
                           <dxwgv:GridViewDataTextColumn Caption="NUM MOV." FieldName="NUMMOV" 
                               VisibleIndex="0">
                           </dxwgv:GridViewDataTextColumn>
                           <dxwgv:GridViewDataTextColumn Caption="SUBMONTO" FieldName="SUBMONTOCANCELADO" 
                               UnboundType="Decimal" VisibleIndex="1">
                           </dxwgv:GridViewDataTextColumn>
                           <dxwgv:GridViewDataComboBoxColumn Caption="FORMA DE PAGO" FieldName="FORMAPAGO" 
                               VisibleIndex="2">
                               <PropertiesComboBox ValueType="System.String"><Items><dxe:ListEditItem Text="Indefinido" Value="100" /><dxe:ListEditItem Text="Efectivo" Value="0" /><dxe:ListEditItem Text="Cheque a Fecha" Value="1" /><dxe:ListEditItem Text="Vale Vista" Value="2" /><dxe:ListEditItem Text="Desde CCte" Value="3" />
                                   <dxe:ListEditItem Text="Deuda Castigada" Value="4" />
                                   <dxe:ListEditItem Text="Mixto" Value="5" />
                                   <dxe:ListEditItem Text="Transferencia" Value="10" />
                                   </Items></PropertiesComboBox>
                           </dxwgv:GridViewDataComboBoxColumn>
                           <dxwgv:GridViewDataDateColumn Caption="FECHA PAGO" FieldName="FECHAPAGO" 
                               VisibleIndex="3">
                               <PropertiesDateEdit DisplayFormatString=""></PropertiesDateEdit>
                           </dxwgv:GridViewDataDateColumn>
                           <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" 
                               VisibleIndex="4">
                               <DeleteButton Visible="True">
                                   <Image Url="~/Imagenes/boton_delete.gif" Height="24px" Width="24px" />
                               </DeleteButton>
                               <ClearFilterButton Visible="True">
                               </ClearFilterButton>
                           </dxwgv:GridViewCommandColumn>
                       </Columns>
                       <SettingsLoadingPanel Text="" />
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
                       <SettingsPager Visible="False">
                       </SettingsPager>
                       <SettingsDetail IsDetailGrid="True" />
                       <Settings ShowFooter="True" />
                   </dxwgv:ASPxGridView>
               </DetailRow>
           </Templates>
           <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
               CssPostfix="Office2003_Olive">
               <Header ImageSpacing="5px" SortingImageSpacing="5px">
               </Header>
               <LoadingPanel ImageSpacing="10px">
               </LoadingPanel>
           </Styles>
           <SettingsText CommandDelete="Eliminar" CommandEdit="Editar" 
               CommandUpdate="Actualizar" ConfirmDelete="Seguro desea eliminar?" 
               Title="CARGOS POR CUENTAS VARIABLES" />
           <TotalSummary>
               <dxwgv:ASPxSummaryItem FieldName="GVMONTOCANCELADO" 
                   ShowInColumn="GVMONTOCANCELADO" SummaryType="Sum" />
               <dxwgv:ASPxSummaryItem FieldName="COSTO" ShowInColumn="COSTO" 
                   SummaryType="Sum" />
           </TotalSummary>
           <Columns>
               <dxwgv:GridViewDataTextColumn Caption="IDPROPIEDAD" FieldName="IDPROPIEDAD" 
                   Visible="False" VisibleIndex="0" ReadOnly="True">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataTextColumn Caption="MES" FieldName="MES" Visible="False" 
                   VisibleIndex="0" ReadOnly="True">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataTextColumn Caption="ANO" FieldName="ANO" Visible="False" 
                   VisibleIndex="0" ReadOnly="True">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataComboBoxColumn Caption="TIPO" FieldName="CTVCODIGO" 
                   VisibleIndex="0" ReadOnly="True">
                   <PropertiesComboBox ValueType="System.String">
                   </PropertiesComboBox>
               </dxwgv:GridViewDataComboBoxColumn>
               <dxwgv:GridViewDataTextColumn Caption="LECTURA ACTUAL" 
                   FieldName="GVCLECTURACATUAL" VisibleIndex="1" ReadOnly="True">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataTextColumn Caption="LECTURA ANTERIOR" 
                   FieldName="GVLECTURAANTERIOR" VisibleIndex="2" ReadOnly="True">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataTextColumn Caption="MONTO CANCELADO" 
                   FieldName="GVMONTOCANCELADO" VisibleIndex="3">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataTextColumn Caption="MONTO FIJO" FieldName="MONTOFIJO" 
                   VisibleIndex="4" ReadOnly="True">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataDateColumn Caption="FECHA DE PAGO" FieldName="FECHAPAGO" 
                   UnboundType="DateTime" VisibleIndex="8">
                   <PropertiesDateEdit DisplayFormatString="">
                   </PropertiesDateEdit>
               </dxwgv:GridViewDataDateColumn>
               <dxwgv:GridViewDataTextColumn Caption="PRECIO &lt;br/&gt;UNITARIO" 
                   FieldName="PRECIOUNITARIO" VisibleIndex="5" ReadOnly="True">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataTextColumn Caption="TOTAL A PAGAR" FieldName="COSTO" 
                   VisibleIndex="6" ReadOnly="True">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataCheckColumn Caption="DESCONTAR CTE" FieldName="DESCONTAR" 
                   Visible="False" VisibleIndex="8">
               </dxwgv:GridViewDataCheckColumn>
               <dxwgv:GridViewDataTextColumn Caption="SALDO CTE" FieldName="SALDOCTE" 
                   ReadOnly="True" VisibleIndex="9">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataComboBoxColumn Caption="FORMA DE &lt;Br/&gt;PAGO" 
                            FieldName="FORMAPAGO" VisibleIndex="5" Visible="False">
                            <PropertiesComboBox ValueType="System.String">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
	 var item = s.GetSelectedItem();
     if(item.value==1){
         popupControl.Show()
     }
     else
      popupControl.Hide()
}" />
                                <Items>
                                    <dxe:ListEditItem Text="Indefinido" Value="100" />
                                    <dxe:ListEditItem Text="Efectivo" Value="0" />
                                    <dxe:ListEditItem Text="Cheque a Fecha" Value="1" />
                                    <dxe:ListEditItem Text="Vale Vista" Value="2" />
                                    <dxe:ListEditItem Text="Desde Cta Cte" Value="3" />
                                    <dxe:ListEditItem Text="Deuda Castigada" Value="4" />
                                    <dxe:ListEditItem Text="Mixto" Value="5" />
                                    <dxe:ListEditItem Text="Transferencia" Value="10" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
               <dxwgv:GridViewDataTextColumn Caption="LECTURA &lt;BR/&gt; CAMBIO MEDIDOR" FieldName="LECTURACM" 
                   VisibleIndex="7" ReadOnly="True">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewDataTextColumn Caption="CTVTIPO" FieldName="CTVTIPO" 
                   Visible="False" VisibleIndex="11">
               </dxwgv:GridViewDataTextColumn>
               <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" 
                   VisibleIndex="10">
                   <EditButton Visible="True">
                       <Image Url="~/Imagenes/Files-text.ico" Height="24px" Width="24px" />
                   </EditButton>
                   <CancelButton>
                       <Image Url="~/Imagenes/cross_circle_frame.png" Height="24px" Width="24px" />
                   </CancelButton>
                   <UpdateButton>
                       <Image Url="~/Imagenes/disk.png" Height="24px" Width="24px" />
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
           <SettingsDetail ShowDetailRow="True" />
           <Settings ShowTitlePanel="True" ShowFooter="True" 
               ShowGroupFooter="VisibleAlways" />
    </dxwgv:ASPxGridView>
       <br />
    <br />
    <br />
                <dxwgv:ASPxGridView ID="ASPxGridViewCEspeciales" runat="server" AutoGenerateColumns="False"
                    ClientInstanceName="GridCEspeciales" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css"
                    CssPostfix="Office2003_Olive" KeyFieldName="LLAVE" Width="450px" 
                    onrowupdated="ASPxGridViewCEspeciales_RowUpdated" 
                    onrowupdating="ASPxGridViewCEspeciales_RowUpdating" 
                    oncancelrowediting="ASPxGridViewCEspeciales_CancelRowEditing" 
                    onstartrowediting="ASPxGridViewCEspeciales_StartRowEditing" 
        Visible="False" 
        onhtmldatacellprepared="ASPxGridViewCEspeciales_HtmlDataCellPrepared" 
        
        onhtmlcommandcellprepared="ASPxGridViewCEspeciales_HtmlCommandCellPrepared">
                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
                    <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" 
                        PopupEditFormWidth="500px" />
                    <SettingsCustomizationWindow Enabled="false" />
                    <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />
                    <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                        CssPostfix="Office2003_Olive">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                        <LoadingPanel ImageSpacing="10px">
                        </LoadingPanel>
                    </Styles>
                    <SettingsText Title="PAGO DE CUOTAS DE CUENTAS ESPECIALES" CommandEdit="Editar"
                        CommandNew="Nuevo" 
                        ConfirmDelete="Está seguro que desea eliminar el registro" 
                        grouppanel="Arraste la columna del tipo de cuenta aqui para agrupar por ella" />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="GCFMONTO" ShowInGroupFooterColumn="MONTO" 
                            SummaryType="Sum" />
                        <dxwgv:ASPxSummaryItem FieldName="GCFMONTOCANCELADO" 
                            ShowInGroupFooterColumn="CANCELADO" SummaryType="Sum" />
                    </TotalSummary>
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="LLAVE" FieldName="LLAVE" Visible="False" 
                            VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="IDPROPIEDAD" 
                            FieldName="IDPROPIEDAD" ReadOnly="True" Visible="False" VisibleIndex="0" 
                            SortIndex="0" SortOrder="Ascending">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Nº CUOTA " FieldName="NUMEROCUOTA" 
                            VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="ANO" 
                            FieldName="ANO" ReadOnly="True" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="MES" 
                            FieldName="MES" ReadOnly="True" VisibleIndex="2">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="TIPO DE &lt;br/&gt;CUENTA" 
                            FieldName="CTEDESCRIPCION" VisibleIndex="3">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="COD. CUENTA" 
                            FieldName="CTECODIGO" ReadOnly="True" VisibleIndex="4" Visible="False">
                            <PropertiesComboBox ValueType="System.String">
                                <Items>
                                    <dxe:ListEditItem Text="Caminos" Value="1" />
                                    <dxe:ListEditItem Text="Seguridad" Value="2" />
                                    <dxe:ListEditItem Text="Gasto Común" Value="3" />
                                    <dxe:ListEditItem Text="Otro" Value="4" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="MONTO COUTA($)" FieldName="GCECUOTA" ReadOnly="True"
                            VisibleIndex="4" Width="100px">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="CANCELADO($)" FieldName="GCEMONTO"
                            VisibleIndex="5" Width="100px" UnboundType="Decimal">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataDateColumn Caption="FECHA DE&lt;br/&gt;PAGO" 
                            FieldName="FECHAPAGO" UnboundType="DateTime" VisibleIndex="6" 
                            Width="100px">
                            <PropertiesDateEdit DisplayFormatString="">
                            </PropertiesDateEdit>
                        </dxwgv:GridViewDataDateColumn>
                        <dxwgv:GridViewDataTextColumn Caption="SALDOCTE" FieldName="SALDOCTE" 
                            VisibleIndex="7">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataCheckColumn Caption="DESCONTAR DE Cte." 
                            FieldName="DESCONTAR" VisibleIndex="8">
                        </dxwgv:GridViewDataCheckColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="FORMA DE &lt;Br/&gt;PAGO" 
                            FieldName="FORMAPAGO" VisibleIndex="9">
                            <PropertiesComboBox ValueType="System.String">
                                
                            <Items>
                                    
                                    
                                    
                                    
                                    
                                <dxe:ListEditItem Text="Indefinido" Value="100" /><dxe:ListEditItem Text="Efectivo" Value="0" /><dxe:ListEditItem Text="Cheque a Fecha" Value="1" /><dxe:ListEditItem Text="Vale Vista" Value="2" /><dxe:ListEditItem Text="Desde Cta Cte" Value="3" />
                                <dxe:ListEditItem Text="Deuda Castigada" Value="4" />
                                <dxe:ListEditItem Text="Mixto" Value="5" />
                                <dxe:ListEditItem Text="Transferencia" Value="10" />
                                </Items></PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" VisibleIndex="10"
                            AllowDragDrop="False">
                            <EditButton Visible="True">
                                <Image Url="~/Imagenes/Files-text.ico" Height="24px" Width="24px" />
                            </EditButton>
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
                    <SettingsPager pagesize="24">
                        <Summary AllPagesText="Páginas: {0} - {1} ({2}Gastos)" Text="Página {0} of {1} ({2} Gastos)"
                            Visible="False" />
                    </SettingsPager>
                    <SettingsDetail AllowOnlyOneMasterRowExpanded="True" 
                        ShowDetailButtons="False" />
                    <Settings ShowFilterRow="False" ShowFooter="True" ShowGroupPanel="True" 
                        ShowTitlePanel="True" ShowGroupFooter="VisibleAlways" />
                </dxwgv:ASPxGridView>
    
       <asp:Button ID="Button1" runat="server" Text="Volver" onclick="Button1_Click"  style="padding: 0px; margin: 0px; background-color: #339933" />

</asp:Content>
