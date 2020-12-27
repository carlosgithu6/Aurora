<%@ Page Language="C#" MasterPageFile="~/Aurora1.Master" AutoEventWireup="true" CodeBehind="CartolaContabilidad.aspx.cs" Inherits="Aurora.Web.Admin.CartolaContabilidad"  %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v8.3, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.3.Export, Version=8.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dxwgv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style5
        {
            width: 100%;
        }
        .style6
        {
            color: #006600;
        }
        .style7
        {
            color: #006600;
            font-weight: bold;
        }
    </style>

 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br/>
     <table width ="85%" cellspacing="0"  border="1" align="center">
     <tr>
     <td valign="top">
         <table style="width:550px; font-family: Verdana;" align="center">
        <tr>
            <td align="center">
                <span class="style6">ASOCIACIÓN DE PROPIETARIOS LA AURORA.<br />
                Archivo de deudas vigentes para contabilidad</span><br 
                    class="style5" />
                <span class="style5">
                <dxe:ASPxLabel ID="lblExcepcion" runat="server" Font-Size="Large" 
                    ForeColor="#CC0000" Visible="False">
                </dxe:ASPxLabel>
                </span>
            </td>
        </tr>
         </table>
    


    <br/>
    <table style="width:80%;" align="center" id="tblVar" runat="server">
        <tr>
            <td class="style6" align="center" style="font-family: Verdana">
             <dxrp:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" 
        HeaderText="Seleccione mes y año" Height="143px" 
        Width="441px">
                 <HeaderStyle Font-Bold="True" ForeColor="#339933" />
        <PanelCollection>
<dxp:PanelContent ID="PanelContent2" runat="server">
    <table align="center" class="style5">
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                DESDE</td>
            <td class="style7">
                HASTA</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <dxe:ASPxComboBox ID="lstMesD" runat="server" ClientInstanceName="lstMes" 
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
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
            <td>
                <dxe:ASPxComboBox ID="lstMesH" runat="server" ClientInstanceName="lstMes" 
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
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                <dxe:ASPxComboBox ID="lstAnosD" runat="server" ClientInstanceName="lstAnos" 
                    ValueType="System.String">
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
            <td>
                <dxe:ASPxComboBox ID="lstAnosH" runat="server" ClientInstanceName="lstAnos" 
                    ValueType="System.String">
                    <ValidationSettings ValidationGroup="AA">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style7" colspan="2">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <dxe:ASPxButton ID="btnBuscarNomina0" runat="server" 
        OnClick="btnBuscarNomina_Click" Text="Descargar Excel" 
        ValidationGroup="AA">
    </dxe:ASPxButton>
    <br />
            </dxp:PanelContent>
</PanelCollection>
    </dxrp:ASPxRoundPanel>
            </td>
        </tr>
        <tr>
            <td class="style2" align="center">
              
                 <dxwgv:ASPxGridView ID="gridpagos" runat="server" Visible="False"  >
                 </dxwgv:ASPxGridView>
                 <br/>
                
                 <dxwgv:ASPxGridViewExporter ID="gridExporter1" runat="server"  
                     GridViewID="gridpagos">
                 </dxwgv:ASPxGridViewExporter>
           <br/>
</td>
        </tr>
        </table>
        <table align="center">
        <tr>
            <td class="style2" align="right" 
                style="font-family: Verdana; font-size: small;" width="80%">
                &nbsp;</td>
        </tr>
        </table>
     </td>
     </tr>
    </table>

<table border="0" cellpadding="0" cellspacing="0" align="center" style="width: 164px"> 
<tr>
    <td>
        <input id="Button1" type="button" value="Volver" 
            onclick="JavaScript:history.back()" style="background-color: #339933"/>
    </td>
    <td>
        &nbsp;</td>
</tr>
</table> 
 </asp:Content>
