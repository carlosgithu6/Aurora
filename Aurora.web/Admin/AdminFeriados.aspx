<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="AdminFeriados.aspx.cs" Inherits="Aurora.Web.Admin.AdminFeriados" Title="Administración de días feriados" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
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
.dxgvControl_Office2003_Olive
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

.dxgvTitlePanel_Office2003_Olive
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
.dxgvFilterRow_Office2003_Olive 
{
	background: #cfd9a3;	
}
.dxgvCommandColumn_Office2003_Olive
{
	padding: 2px 2px 2px 2px;
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
.dxgvFooter_Office2003_Olive
{	
	background-color: #bdcb85;
	white-space:nowrap;
}
        .style5
        {
            color: Black;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            font-size: 9pt;
            line-height: normal;
            font-family: Tahoma;
            border-left-width: 0px;
            border-top-width: 0px;
        }
        .style6
        {
            cursor: default;
            color: Black;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            font-size: 9pt;
            line-height: normal;
            font-family: Tahoma;
            border-left-width: 0px;
            border-right-width: 0px;
            border-top-width: 0px;
        }
        .style7
        {
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #a4b26d;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #a4b26d;
            padding: 2px;
        }
        .style8
        {
            text-align: Left;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #a4b26d;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #a4b26d;
            padding: 2px;
        }
        .style9
        {
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #a4b26d;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #a4b26d;
            padding: 2px;
        }
        .style10
        {
            overflow: hidden;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #cdd6a7;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #cdd6a7;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 2px;
            padding-bottom: 5px;
        }
        .style11
        {
            text-align: Left;
            overflow: hidden;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #cdd6a7;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #cdd6a7;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 2px;
            padding-bottom: 5px;
        }
        .style12
        {
            white-space: nowrap;
            overflow: hidden;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0;
            border-right: 1px solid #cdd6a7;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0;
            border-bottom: 1px solid #cdd6a7;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 2px;
            padding-bottom: 5px;
        }
        .style13
        {
            border-right: 1px solid #a4b26d;
            border-bottom: 1px solid #a4b26d;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 3px;
            padding-bottom: 5px;
        }
        .style14
        {
            text-align: Left;
            border-right: 1px solid #a4b26d;
            border-bottom: 1px solid #a4b26d;
            padding-left: 6px;
            padding-right: 6px;
            padding-top: 3px;
            padding-bottom: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dxwgv:ASPxGridView ID="gridFeriados"   
         ClientInstanceName="GridUF" runat="server" AutoGenerateColumns="False" 
         CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" CssPostfix="Office2003_Olive" 
         KeyFieldName="FERIADO" onrowinserted="gridFeriados_RowInserted" 
         onrowinserting="gridFeriados_RowInserting" Width="850px" 
        onrowdeleted="gridFeriados_RowDeleted" 
        onrowdeleting="gridFeriados_RowDeleting" >
        <SettingsBehavior ConfirmDelete="True" AllowFocusedRow="True" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="True" PopupEditFormWidth="500px" />
        <SettingsCustomizationWindow Enabled="false"  />
        <ClientSideEvents CustomizationWindowCloseUp="function(s, e) { UpdateCustomizationWindowValue(); }" />
        <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
               CssPostfix="Office2003_Olive">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
            <LoadingPanel ImageSpacing="10px">
            </LoadingPanel>
        </Styles>
        <SettingsText CommandDelete="Eliminar" CommandNew="Nuevo" 
             ConfirmDelete="Está seguro que desea eliminar el registro" 
             GroupPanel="&lt;b&gt;Arrastre una columna aquí para agrupar por ella&lt;/b&gt;" 
             PopupEditFormCaption="Nuevo/Edición" Title="DÍAS FERIADOS (MM/DD/AAAA)" 
             CustomizationWindowCaption="Seleccione Columna" />
        <TotalSummary>
            <dxwgv:ASPxSummaryItem FieldName="RUT" ShowInColumn="RUT" 
                 ShowInGroupFooterColumn="RUT" SummaryType="Count" Tag="Cantidad" />
        </TotalSummary>
        <Columns>
            <dxwgv:GridViewDataDateColumn Caption="FECHA" FieldName="FERIADO" 
                VisibleIndex="0">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesDateEdit>
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" 
                 VisibleIndex="1" AllowDragDrop="False">
                <EditButton>
                    <Image Url="~/Imagenes/Files-text.ico" Height="24px" Width="24px" />
                </EditButton>
                <NewButton Visible="True">
                    <Image Url="~/Imagenes/edit_add.ico" Height="24px" Width="24px" />
                </NewButton>
                <DeleteButton Visible="True">
                    <Image Url="~/Imagenes/edit_remove.ico" Height="24px" Width="24px" />
                </DeleteButton>
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
        <SettingsPager>
            <Summary AllPagesText="Páginas: {0} - {1} ({2}Meses)" 
                 Text="Página {0} of {1} ({2} Meses)" Visible="False" />
        </SettingsPager>
        <SettingsDetail AllowOnlyOneMasterRowExpanded="True">
        </SettingsDetail>
        <Templates>
            <DetailRow>
                <div id="detalle">
                </div>
            </DetailRow>
        </Templates>
        <Settings ShowFilterRow="True" ShowFooter="True" 
             ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
</asp:Content>
