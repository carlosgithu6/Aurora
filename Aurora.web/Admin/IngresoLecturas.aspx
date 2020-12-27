<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="IngresoLecturas.aspx.cs" Inherits="Aurora.Web.Admin.IngresoLecturas" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">


        .style5
        {
            width: 85%;
            height: 43px;
        }
        .style6
        {
            width: 6px;
        }
        .style7
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
function Uploader_OnUploadStart() {
    btnUpload.SetText("Subiendo Archivo...");
    btnUpload.SetEnabled(false);
}
function Uploader_OnUploadComplete(args) {
    btnUpload.SetEnabled(true);
    btnUpload.SetText("Subir Archivo");
}

</script>
 <br/>
 <br/>
 <br/>
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" 
        BackColor="#E2E8C9" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" EnableDefaultAppearance="False" 
        HeaderText="Seleccione mes, año y tipo de cuenta" 
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
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
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
                    <ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7" colspan="2">
                <dxe:ASPxComboBox ID="lstTipoCV" runat="server" ClientInstanceName="lstTipoCV" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" ImageFolder="~/App_Themes/Office2003 Olive/{0}/" 
                    ValueType="System.String">
                    <ButtonStyle Width="13px">
                    </ButtonStyle>
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
                <dxe:ASPxButton ID="btnBuscar" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" OnClick="btnBuscarNomina_Click" 
                    Text="Comenzar a ingresar">
                </dxe:ASPxButton>
            </td>
            <td>
                <dxe:ASPxButton ID="btnPlantilla" runat="server" 
                    CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                    CssPostfix="Office2003_Olive" OnClick="btnPlantilla_Click" 
                    Text="Descargar Plantilla">
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

    <br />
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" BackColor="#E2E8C9" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" EnableDefaultAppearance="False" 
        HeaderText="Subir lecturas masivamente" Height="123px" 
        ImageFolder="~/App_Themes/Office2003 Olive/{0}/" Width="531px">
        <topedge>
            <backgroundimage HorizontalPosition="left" 
                imageurl="~/App_Themes/Office2003 Olive/Web/rpTopEdge.png" repeat="RepeatX" 
                verticalposition="top" />
        </topedge>
        <bottomrightcorner height="9px" 
            url="~/App_Themes/Office2003 Olive/Web/rpBottomRightCorner.png" width="9px" />
        <contentpaddings padding="2px" PaddingBottom="10px" PaddingTop="10px" />
        <noheadertoprightcorner height="9px" 
            url="~/App_Themes/Office2003 Olive/Web/rpNoHeaderTopRightCorner.png" 
            width="9px" />
        <headerrightedge>
            <backgroundimage HorizontalPosition="left" 
                imageurl="~/App_Themes/Office2003 Olive/Web/rpHeader.png" repeat="RepeatX" 
                verticalposition="top" />
        </headerrightedge>
        <border bordercolor="#758D5E" borderstyle="Solid" borderwidth="1px" />
        <headerleftedge>
            <backgroundimage HorizontalPosition="left" 
                imageurl="~/App_Themes/Office2003 Olive/Web/rpHeader.png" repeat="RepeatX" 
                verticalposition="top" />
        </headerleftedge>
        <HeaderStyle BackColor="#B5C48F">
        <Paddings Padding="0px" PaddingBottom="7px" PaddingLeft="2px" 
            PaddingRight="2px" />
        <BorderBottom BorderColor="#758D5E" BorderStyle="Solid" BorderWidth="1px" />
        </HeaderStyle>
        <toprightcorner height="9px" 
            url="~/App_Themes/Office2003 Olive/Web/rpTopRightCorner.png" width="9px" />
        <HeaderContent>
            <BackgroundImage HorizontalPosition="left" 
                ImageUrl="~/App_Themes/Office2003 Olive/Web/rpHeader.png" Repeat="RepeatX" 
                VerticalPosition="top" />
        </HeaderContent>
        <DisabledStyle ForeColor="Gray">
        </DisabledStyle>
        <noheadertopedge backcolor="#E2E8C9">
        </noheadertopedge>
        <noheadertopleftcorner height="9px" 
            url="~/App_Themes/Office2003 Olive/Web/rpNoHeaderTopLeftCorner.png" 
            width="9px" />
        <PanelCollection>
            <dxp:PanelContent runat="server">
                <table class="style1">
                    <tr>
                        <td colspan="3">
                            <dxe:ASPxLabel ID="lblUpload" runat="server" 
                                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                                Font-Bold="True" 
                                Text="Seleccione el archivo &quot;.csv&quot;  con las lecturas">
                            </dxe:ASPxLabel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                        <td>
                            <dxe:ASPxButton ID="btnUpload0" runat="server" CausesValidation="False" 
                                ClientInstanceName="btnUpload" 
                                CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
                                CssPostfix="Office2003_Olive" OnClick="btnUpload0_Click" Text="Upload" 
                                Width="100px">
                            </dxe:ASPxButton>
                        </td>
                        <td>
                            <dxe:ASPxCheckBox ID="ckbUpdate" runat="server" Text="Actualizar" 
                                ToolTip="Elimina todas las lecturas y reprocesa el archivo">
                            </dxe:ASPxCheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <dxe:ASPxLabel ID="lblMensaje" runat="server" EncodeHtml="False" 
                                Font-Bold="True" ForeColor="#6666FF">
                            </dxe:ASPxLabel>
                            <dxe:ASPxLabel ID="lblError" runat="server" EncodeHtml="False" Font-Bold="True" 
                                ForeColor="#FF3300">
                            </dxe:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </dxp:PanelContent>
        </PanelCollection>
        <topleftcorner height="9px" 
            url="~/App_Themes/Office2003 Olive/Web/rpTopLeftCorner.png" width="9px" />
        <bottomleftcorner height="9px" 
            url="~/App_Themes/Office2003 Olive/Web/rpBottomLeftCorner.png" width="9px" />
    </dxrp:ASPxRoundPanel>

<BR/>
<BR/>

    <dxwgv:ASPxGridView ID="Grilla" runat="server" 
        AutoGenerateColumns="False" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" KeyFieldName="CLAVE" 
        onrowupdated="Grilla_RowUpdated" onrowupdating="Grilla_RowUpdating" 
        oncancelrowediting="Grilla_CancelRowEditing" 
        onstartrowediting="Grilla_StartRowEditing">
        <SettingsBehavior AllowDragDrop="False" AllowGroup="False" />
        <SettingsEditing Mode="Inline" />
        <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
            CssPostfix="Office2003_Olive">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
            <LoadingPanel ImageSpacing="10px">
            </LoadingPanel>
        </Styles>
        <SettingsText Title="INGRESO DE LECTURAS DE CUENTAS VARIABLES" />
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0" Caption="Opciones" Visible="True">
                <EditButton Text="Editar" Visible="True">
                </EditButton>
                <CancelButton Text="Cancelar">
                </CancelButton>
                <UpdateButton Text="Actualizar">
                </UpdateButton>
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn Caption="CLAVE" FieldName="CLAVE" Visible="False" 
                VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="IDPROPIEDAD" FieldName="IDPROPIEDAD" VisibleIndex="1" 
                ReadOnly="True">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="TIPO" FieldName="CTVTIPO" 
                ReadOnly="True" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="LECTURAANTERIOR" 
                FieldName="LECTURAANTERIOR" VisibleIndex="3">
                <PropertiesTextEdit>
                    
<ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                
</PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="GVCLECTURACATUAL" 
                FieldName="GVCLECTURACATUAL" VisibleIndex="4">
                <PropertiesTextEdit>
                    
<ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                
</PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataDateColumn Caption="FECHALEC" FieldName="FECHALEC" 
                UnboundType="DateTime" VisibleIndex="6">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewDataTextColumn Caption="CONSUMO" FieldName="CONSUMO" 
                VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="MONTOFIJO" FieldName="MONTOFIJO" 
                VisibleIndex="7">
                <PropertiesTextEdit>
                    
<ValidationSettings>
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                
</PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="NOMBRES" FieldName="NOMBRES" 
                ReadOnly="True" VisibleIndex="8">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="APPATERNO" FieldName="APPATERNO" 
                ReadOnly="True" VisibleIndex="9">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="APMATERNO" FieldName="APMATERNO" 
                ReadOnly="True" VisibleIndex="10">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="MES" FieldName="MES" VisibleIndex="15" 
                ReadOnly="True">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="ANO" FieldName="ANO" VisibleIndex="13" 
                ReadOnly="True">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="SECTOR" FieldName="SECTOR" 
                ReadOnly="True" VisibleIndex="14">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="LETRA" FieldName="LETRAPARCELA" 
                ReadOnly="True" VisibleIndex="11">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="NUMERO" FieldName="NUMEROPARCELA" 
                ReadOnly="True" VisibleIndex="12">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="CTVCODIGO" FieldName="CTVCODIGO" 
                ReadOnly="True" VisibleIndex="18">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="FACTOR TRIFASICO" FieldName="FACTOR" 
                VisibleIndex="17">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataCheckColumn Caption="TRIFASICO" FieldName="TRIFASICO" 
                VisibleIndex="16">
            </dxwgv:GridViewDataCheckColumn>
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
        <SettingsCookies Enabled="True" />
        <SettingsPager PageSize="50">
        </SettingsPager>
        <Settings ShowTitlePanel="True" ShowFilterRow="True" />
    </dxwgv:ASPxGridView>

 
     </asp:Content>
