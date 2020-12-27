<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="ActualizaGastosMensuales.aspx.cs"
    Inherits="Aurora.Web.Admin.ActualizaGastosMensuales" Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>

<%@ Register Assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style5
        {
            width: 100%;
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
    <br/>
    <br/>
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="200px" 
        BackColor="#E2E8C9" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" EnableDefaultAppearance="False" 
        HeaderText="Seleccione mes y año" 
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
                </dxe:ASPxComboBox>
            </td>
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
                    Text="Buscar nómina">
                </dxe:ASPxButton>
            </td>
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
    <br/>
    <dxwgv:ASPxGridView ID="GridCFijas" ClientInstanceName="GridCFijas" runat="server"
        AutoGenerateColumns="False" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css"
        CssPostfix="Office2003_Olive" KeyFieldName="RUT" Width="850px" 
        OnBeforePerformDataSelect="GridCFijas_BeforePerformDataSelect" 
        ondetailrowexpandedchanged="GridCFijas_DetailRowExpandedChanged">
        <SettingsBehavior ConfirmDelete="True" AllowFocusedRow="True" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" PopupEditFormWidth="500px" />
        <SettingsCustomizationWindow Enabled="false" />
        <Templates>
            <DetailRow>
                <dxwgv:ASPxGridView ID="ASPxGridViewFijos" runat="server" AutoGenerateColumns="False"
                    ClientInstanceName="GridCFijas" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css"
                    CssPostfix="Office2003_Olive" KeyFieldName="CFCODIGO" Width="450px" 
                    OnBeforePerformDataSelect="ASPxGridViewFijos_BeforePerformDataSelect" 
                    onrowupdated="ASPxGridViewFijos_RowUpdated" 
                    onrowupdating="ASPxGridViewFijos_RowUpdating" 
                    oncancelrowediting="ASPxGridViewFijos_CancelRowEditing" 
                    onstartrowediting="ASPxGridViewFijos_StartRowEditing">
                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
                    <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" PopupEditFormWidth="500px" />
                    <SettingsCustomizationWindow Enabled="false" />
                    <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />
                    <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" CssPostfix="Office2003_Olive">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                        <LoadingPanel ImageSpacing="10px">
                        </LoadingPanel>
                    </Styles>
                    <SettingsText Title="Gastos Fijos" CommandDelete="Eliminar" CommandEdit="Editar"
                        CommandNew="Nuevo" ConfirmDelete="Está seguro que desea eliminar el registro" />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="IDGASTOCF" ShowInColumn="IDGASTOCF" ShowInGroupFooterColumn="IDGASTOCF"
                            SummaryType="Count" Tag="Cantidad" />
                    </TotalSummary>
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="RUT" FieldName="RUT" ReadOnly="True" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="ANO" FieldName="ANO" ReadOnly="True" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="MES" FieldName="MES" ReadOnly="True" 
                            Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataComboBoxColumn Caption="TIPO DE &lt;br/&gt;CUENTA FIJA" 
                            FieldName="CFCODIGO" ReadOnly="True" ToolTip="CFCODIGO" VisibleIndex="2">
                            <PropertiesComboBox ValueType="System.String">
                                <Items>
                                    <dxe:ListEditItem Text="Caminos" Value="1" />
                                    <dxe:ListEditItem Text="Seguridad" Value="2" />
                                    <dxe:ListEditItem Text="Gasto Común" Value="3" />
                                    <dxe:ListEditItem Text="Otro" Value="4" />
                                </Items>
                            </PropertiesComboBox>
                        </dxwgv:GridViewDataComboBoxColumn>
                        <dxwgv:GridViewDataTextColumn Caption="MONTO" FieldName="GCFMONTO" ReadOnly="True"
                            VisibleIndex="3" Width="100px">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="CANCELADO" FieldName="GCFMONTOCANCELADO"
                            VisibleIndex="4" Width="100px">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="FECHA DE&lt;br/&gt;PAGO" 
                            FieldName="FECHAPAGO" ReadOnly="False"
                            VisibleIndex="3" Width="100px">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" VisibleIndex="4"
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
                    <SettingsDetail AllowOnlyOneMasterRowExpanded="True" IsDetailGrid="True" />
                    <Settings ShowFilterRow="False" ShowFooter="True" ShowGroupPanel="False" ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
                <br />
                
                <dxwgv:ASPxGridView ID="ASPxGridViewVariables" runat="server"
                    ClientInstanceName="GridCFijas" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css"
                    CssPostfix="Office2003_Olive" Width="750px" 
                    OnBeforePerformDataSelect="ASPxGridViewVariables_BeforePerformDataSelect" 
                    KeyFieldName="CTVTIPO">
                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
                    <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" PopupEditFormWidth="500px" />
                    <SettingsCustomizationWindow Enabled="false" />
                    <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />
                    <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" CssPostfix="Office2003_Olive">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                        <LoadingPanel ImageSpacing="10px">
                        </LoadingPanel>
                    </Styles>
                    <SettingsText Title="Gastos Variables" CommandDelete="Eliminar" CommandEdit="Editar"
                        CommandNew="Nuevo" ConfirmDelete="Está seguro que desea eliminar el registro" />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="IDGASTOCV" ShowInColumn="IDGASTOCV" ShowInGroupFooterColumn="IDGASTOCV"
                            SummaryType="Count" Tag="Cantidad" />
                    </TotalSummary>
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
                        <Summary AllPagesText="Páginas: {0} - {1} ({2}Gastos)" Text="Página {0} of {1} ({2} Gatos)"
                            Visible="False" />
                    </SettingsPager>
                    <SettingsDetail AllowOnlyOneMasterRowExpanded="True" IsDetailGrid="True" />
                    <Settings ShowFilterRow="False" ShowFooter="True" ShowGroupPanel="False" ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
                <br />
                <dxwgv:ASPxGridView ID="ASPxGridViewEspeciales" runat="server" AutoGenerateColumns="False"
                    ClientInstanceName="GridCFijas" CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css"
                    CssPostfix="Office2003_Olive" KeyFieldName="IDGASTOCE" Width="600px" 
                    OnBeforePerformDataSelect="ASPxGridViewEspeciales_BeforePerformDataSelect" 
                    Visible="False">
                    <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
                    <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" PopupEditFormWidth="500px" />
                    <SettingsCustomizationWindow Enabled="false" />
                    <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />
                    <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" CssPostfix="Office2003_Olive">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                        <LoadingPanel ImageSpacing="10px">
                        </LoadingPanel>
                    </Styles>
                    <SettingsText Title="Gastos Especiales" CommandDelete="Eliminar" CommandEdit="Editar"
                        CommandNew="Nuevo" ConfirmDelete="Está seguro que desea eliminar el registro" />
                    <TotalSummary>
                        <dxwgv:ASPxSummaryItem FieldName="IDGASTOCE" ShowInColumn="IDGASTOCE" ShowInGroupFooterColumn="IDGASTOCE"
                            SummaryType="Count" Tag="Cantidad" />
                    </TotalSummary>
                    <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="IDGASTO" FieldName="IDGASTO" ReadOnly="True"
                            ToolTip="IDGASTO" Visible="False" VisibleIndex="0">
                        </dxwgv:GridViewDataTextColumn>
                          <dxwgv:GridViewDataTextColumn Caption="IDGASTOCE" FieldName="IDGASTOCE" ReadOnly="True"
                            ToolTip="IDGASTO" Visible="False" VisibleIndex="1">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Concepto" FieldName="GADESCRIPCION" ReadOnly="True"
                            VisibleIndex="0" Width="100px">
                        </dxwgv:GridViewDataTextColumn>
                          <dxwgv:GridViewDataTextColumn Caption="Cuota" FieldName="GCECUOTA" ReadOnly="True"
                            VisibleIndex="2" Width="100px">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Total" FieldName="GCEMONTO" ReadOnly="True"
                            VisibleIndex="2" Width="100px">
                        </dxwgv:GridViewDataTextColumn>
                        <dxwgv:GridViewDataTextColumn Caption="Pagado" FieldName="GCEMONTOCANCELADO" ReadOnly="True"
                            VisibleIndex="3" Width="100px">
                        </dxwgv:GridViewDataTextColumn>
                         <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" VisibleIndex="7"
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
                    <SettingsDetail AllowOnlyOneMasterRowExpanded="True" IsDetailGrid="True" />
                    <Settings ShowFilterRow="False" ShowFooter="True" ShowGroupPanel="False" ShowTitlePanel="True" />
                </dxwgv:ASPxGridView>
            </DetailRow>
        </Templates>
        <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />
        <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" CssPostfix="Office2003_Olive">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
            <LoadingPanel ImageSpacing="10px">
            </LoadingPanel>
        </Styles>
        <SettingsText GroupPanel="&lt;b&gt;Arrastre una columna aquí para agrupar por ella&lt;/b&gt;"
            PopupEditFormCaption="Nuevo/Edición" Title="Resumen de Gastos Mensuales Por Propietario"
            CustomizationWindowCaption="Seleccione Columna" />
        <TotalSummary>
            <dxwgv:ASPxSummaryItem FieldName="IdGasto" ShowInColumn="IdGasto" ShowInGroupFooterColumn="IdGasto"
                SummaryType="Count" Tag="Cantidad" />
        </TotalSummary>
        <Columns>
            <dxwgv:GridViewDataTextColumn Caption="RUT" FieldName="RUT" VisibleIndex="0"
                ReadOnly="True" ToolTip="RUT del propietario">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="NOMBRES" FieldName="NOMBRES" VisibleIndex="2"
                ReadOnly="True" Width="100px">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="APELLIDO&lt;BR/&gt;PATERNO" 
                FieldName="APPATERNO" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="APELLIDO&lt;BR/&gt;MATERNO" 
                FieldName="APMATERNO" VisibleIndex="4"
                ReadOnly="False">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="SOCIO" FieldName="SOCIO" 
                ToolTip="Indica si es socio o no." VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="SECTOR" FieldName="SECTOR" 
                VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="LETRA&lt;br/&gt;PARCELA" 
                FieldName="LETRAPARCELA" VisibleIndex="7">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="NUMERO&lt;br/&gt;PARCELA" 
                FieldName="NUMEROPARCELA" VisibleIndex="8">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="TOTAL" FieldName="GATOTAL" 
                ReadOnly="True" VisibleIndex="3" Width="100px">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="PAGADO" FieldName="GAPAGADO" 
                VisibleIndex="9" Width="100px">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataCheckColumn Caption="Tiene Cambio Medidor" FieldName="GATIENECAMBIO"
                VisibleIndex="10" ReadOnly="True" Width="100px">
            </dxwgv:GridViewDataCheckColumn>
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
            <Summary AllPagesText="Páginas: {0} - {1} ({2}Propietarios)" Text="Página {0} of {1} ({2} Propietarios)"
                Visible="False" />
        </SettingsPager>
        <SettingsDetail AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True"></SettingsDetail>
        <Settings ShowGroupPanel="True" ShowFilterRow="True" ShowFooter="True" ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
</asp:Content>
