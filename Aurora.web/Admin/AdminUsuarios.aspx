<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="Aurora.Web.Admin.AdminUsuarios" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
<br/>
<br/>
       <dxwgv:ASPxGridView ID="GridGrupos"   
         ClientInstanceName="GridGrupos" runat="server" AutoGenerateColumns="False" 
         CssFilePath="~/App_Themes/Office2003 Olive/{0}/styles.css" CssPostfix="Office2003_Olive" 
         KeyFieldName="RUT"  onrowdeleted="GridGrupos_RowDeleted" 
         onrowdeleting="GridGrupos_RowDeleting" onrowinserted="GridGrupos_RowInserted" 
         onrowinserting="GridGrupos_RowInserting" onrowupdated="GridGrupos_RowUpdated" 
         onrowupdating="GridGrupos_RowUpdating" Width="850px" 
         onhtmlcommandcellprepared="GridGrupos_HtmlCommandCellPrepared" 
    oncancelrowediting="GridGrupos_CancelRowEditing" 
    onstartrowediting="GridGrupos_StartRowEditing" >
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
         <SettingsText CommandDelete="Eliminar" CommandEdit="Editar" CommandNew="Nuevo" 
             ConfirmDelete="Está seguro que desea eliminar el registro" 
             GroupPanel="&lt;b&gt;Arrastre una columna aquí para agrupar por ella&lt;/b&gt;" 
             PopupEditFormCaption="Nuevo/Edición" Title="USUARIOS DEL SISTEMA" 
             CustomizationWindowCaption="Seleccione Columna" />
         <TotalSummary>
             <dxwgv:ASPxSummaryItem FieldName="RUT" ShowInColumn="RUT" 
                 ShowInGroupFooterColumn="RUT" SummaryType="Count" Tag="Cantidad" />
         </TotalSummary>
         <Columns>
<dxwgv:GridViewDataTextColumn FieldName="RUT" Caption="RUT" VisibleIndex="0">
    <PropertiesTextEdit>
        <ValidationSettings>
            <RequiredField IsRequired="True" />
        </ValidationSettings>
    </PropertiesTextEdit>
</dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Nombres" FieldName="NOMBRES" 
                 VisibleIndex="0">
                 <PropertiesTextEdit>
                     
<ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 
</PropertiesTextEdit>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Apellido P." FieldName="APPATERNO" 
                 VisibleIndex="2">
                 <PropertiesTextEdit>
                     


<ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 


</PropertiesTextEdit>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Apellido M." FieldName="APMATERNO" 
                 VisibleIndex="3">
                 <PropertiesTextEdit>
                     

<ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 

</PropertiesTextEdit>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Dirección" FieldName="DIRECCION" 
                 VisibleIndex="4">
                 <PropertiesTextEdit>
                     

<ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 

</PropertiesTextEdit>
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Teléfono" FieldName="TELEFONO" 
                 VisibleIndex="5">
                 <PropertiesTextEdit>
                     <ValidationSettings>
                         <RequiredField IsRequired="True" />
                     </ValidationSettings>
                 </PropertiesTextEdit>
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataTextColumn Caption="Correo" FieldName="EMAIL" 
                 VisibleIndex="6">
                 <propertiestextedit><validationsettings><requiredfield isrequired="True"></requiredfield><RegularExpression 
                     ErrorText="Error de formato" 
                     ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                 </validationsettings></propertiestextedit>
                 <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
             </dxwgv:GridViewDataTextColumn>
             <dxwgv:GridViewDataComboBoxColumn Caption="Rol" FieldName="IDPERFIL" 
                 VisibleIndex="7">
                 <PropertiesComboBox ValueType="System.String">
                     
                     




                 

<Items>
                         


                         


                         

                 <dxe:ListEditItem Text="Administrador" Value="0" /><dxe:ListEditItem Text="Usuario" Value="1" /></Items><ValidationSettings>
                         
                     <RequiredField IsRequired="True" /></ValidationSettings></PropertiesComboBox>
             </dxwgv:GridViewDataComboBoxColumn>
             <dxwgv:GridViewDataDateColumn Caption="Fecha de&lt;br/&gt;creación" 
                 FieldName="FECHACREACION" VisibleIndex="8">
                 <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy">
                 </PropertiesDateEdit>
             </dxwgv:GridViewDataDateColumn>
             <dxwgv:GridViewDataDateColumn Caption="Fecha de&lt;br/&gt;actualización" FieldName="FECHAACTUALIZACION" 
                 VisibleIndex="9">
                 <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy">
                 </PropertiesDateEdit>
             </dxwgv:GridViewDataDateColumn>
             <dxwgv:GridViewCommandColumn ButtonType="Image" Caption="Opciones" 
                 VisibleIndex="10" AllowDragDrop="False">
                 <EditButton Visible="True">
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
             <Summary AllPagesText="Páginas: {0} - {1} ({2}Usuarios)" 
                 Text="Página {0} of {1} ({2} Usuarios)" />
         </SettingsPager>
         <SettingsDetail AllowOnlyOneMasterRowExpanded="True">
          </SettingsDetail>
           <Templates>
             <DetailRow>
                <div id="detalle">
                </div>    
             </DetailRow>
            </Templates>
         <Settings ShowGroupPanel="True" ShowFilterRow="True" ShowFooter="True" 
             ShowTitlePanel="True" />
     </dxwgv:ASPxGridView>
</asp:Content>
