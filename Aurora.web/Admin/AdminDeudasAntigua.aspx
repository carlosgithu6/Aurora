<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="AdminDeudasAntigua.aspx.cs" Inherits="Aurora.Web.Admin.AdminDeudasAntigua" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <br/>
    <dxwgv:ASPxGridView ID="Grilla" runat="server" AutoGenerateColumns="False" 
        ClientInstanceName="Grilla" 
        CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
        CssPostfix="Office2003_Olive" KeyFieldName="IDPROPIEDAD" 
        oncancelrowediting="Grilla_CancelRowEditing" ondatabound="Grilla_DataBound" 
        onrowupdated="Grilla_RowUpdated1" onrowupdating="Grilla_RowUpdating1" 
        onstartrowediting="Grilla_StartRowEditing" 
        oncustombuttoncallback="Grilla_CustomButtonCallback">
        <SettingsEditing Mode="Inline" />
        <ClientSideEvents CustomButtonClick="function(s, e)
         {   if (e.buttonID == 'ElimAbono')
              {
                          if (confirm('¿Está seguro que quiere deshacer el último abono?'))
                                {
                                    e.processOnServer = true;
                                    s.PerformCallback(e.visibleIndex.toString());                                   
                                }
                                else
                                {
                                    e.processOnServer = false;
                                }
               }
                    else
                           {
                              e.processOnServer = true;
                              s.PerformCallback(e.visibleIndex.toString());
                           }
              }
       
" />
        <Styles CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" 
            CssPostfix="Office2003_Olive">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
            <LoadingPanel ImageSpacing="10px">
            </LoadingPanel>
        </Styles>
        <SettingsText GroupPanel="&lt;b&gt;Arrastre una columna hasta aquí para agrupar por ella&lt;/b&gt;" 
            Title="ADMINISTRAR DEUDAS ANTERIORES Y SALDO EN CUENTA CORRIENTE" />
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0" Caption="OPCIONES" Width="150px">
                <EditButton Text="Editar" Visible="True">
                </EditButton>
                <UpdateButton Text="Actualizar">
                </UpdateButton>
                <ClearFilterButton Visible="True">
                    <Image Url="~/Imagenes/escobachica.jpg" />
                </ClearFilterButton>
                <CustomButtons>
                    <dxwgv:GridViewCommandColumnCustomButton ID="ElimAbono" Text="Atrás abono">
                        <Image Url="~/Imagenes/1uparrow.ico" />
                    </dxwgv:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn Caption="IDPROPIEDAD" FieldName="IDPROPIEDAD" 
                ReadOnly="True" Visible="False" VisibleIndex="0">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="PROPIEDAD" FieldName="PROPIEDAD" 
                ReadOnly="True" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="RUT" FieldName="RUT" ReadOnly="True" 
                VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="NOMBRES" FieldName="NOMBRES" 
                ReadOnly="True" VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="APPATERNO" FieldName="APPATERNO" 
                ReadOnly="True" VisibleIndex="4">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="APMATERNO" FieldName="APMATERNO" 
                ReadOnly="True" VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataCheckColumn Caption="SOCIO" FieldName="SOCIO" 
                ReadOnly="True" VisibleIndex="6">
            </dxwgv:GridViewDataCheckColumn>
            <dxwgv:GridViewDataTextColumn Caption="SALDOCTE" FieldName="SALDOCTE" 
                ReadOnly="True" UnboundType="Decimal" VisibleIndex="7">
                <PropertiesTextEdit EncodeHtml="False">
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="ABONO A CTE." FieldName="ABONO" 
                Visible="False" VisibleIndex="9">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="DEUDA INICIAL" FieldName="DEUDAINICIAL" 
                ReadOnly="True" UnboundType="Decimal" VisibleIndex="8">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="DEUDA INICIAL&lt;BR/&gt; PENDIENTE" 
                FieldName="DEUDAPENDIENTE" ReadOnly="True" UnboundType="Decimal" 
                VisibleIndex="9">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataCheckColumn Caption="DESCONTAR&lt;br/&gt;DESDE CTE." 
                FieldName="DESCONTARCTE" Visible="False" VisibleIndex="10">
            </dxwgv:GridViewDataCheckColumn>
            <dxwgv:GridViewDataTextColumn Caption="AMORTIZAR DEUDA" 
                FieldName="AMORTIZARDEUDA" Visible="False" VisibleIndex="9">
            </dxwgv:GridViewDataTextColumn>
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
        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowGroupPanel="True" 
            ShowTitlePanel="True" />
    </dxwgv:ASPxGridView>
 <br/>
 <br/>
 
  

 
     </asp:Content>
