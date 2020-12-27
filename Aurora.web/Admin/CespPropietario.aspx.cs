using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Aurora.Clases.Base;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base.Encriptacion;
using Aurora.Web.UI;
using DevExpress.Web.ASPxGridView;
using System.Collections.Generic;

namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] {Perfil.Administrador})]
    public partial class CespPropietario : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                GridViewDataComboBoxColumn combo = GridGrupos.Columns["CTECODIGO"] as GridViewDataComboBoxColumn;
                combo.PropertiesComboBox.ValueType = typeof(int);
                DataTable cuentasespeciales = Aurora.Clases.Negocio.CuentaEspecial.Listar(false); 

                foreach (DataRow myrow in cuentasespeciales.Rows)
                {
                    combo.PropertiesComboBox.Items.Add(myrow["CTEDESCRIPCION"].ToString(), myrow["CTECODIGO"].ToString(), "");
                }
                GridGrupos.SettingsText.Title = "CUENTAS ESPECIALES DE: " + Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"])).NombreCompleto;  
                GridGrupos.ExpandAll();
                BindGrilla();
            }
            if (Page.IsCallback)
            {
                BindGrilla();
            }

        }

        private void BindGrilla()
        {
            GridGrupos.DataSource = Aurora.Clases.Negocio.CtePropietario.Listar(Convert.ToInt16(QString["IDPROPIEDAD"]));
            GridGrupos.DataBind();

        }

       

        protected void GridGrupos_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }

        protected void GridGrupos_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Aurora.Clases.Negocio.CtePropietario.Eliminar(int.Parse(e.Values["IDCUENTAESPECIALPROP"].ToString()));
            BindGrilla();
            e.Cancel = true;    
        }

        protected void GridGrupos_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
          

        }

        protected void GridGrupos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            InfoCtePropietario infoCtePropietario = new InfoCtePropietario();

            infoCtePropietario.CteCodigo = int.Parse(e.NewValues["CTECODIGO"].ToString());
            infoCtePropietario.CepFechaInicio = DateTime.Parse(e.NewValues["CEPFECHAINICIO"].ToString());
            infoCtePropietario.CepNumeroCuotas = Convert.ToInt32(Adicional.Verificar_Valor(e.NewValues["CEPNUMEROCUOTAS"].ToString(), 50, false));
            infoCtePropietario.IdPropiedad = Convert.ToInt16(QString["IDPROPIEDAD"]);
            Aurora.Clases.Negocio.CtePropietario.Crear(infoCtePropietario);
            BindGrilla();
            e.Cancel = true;
        }

        protected void GridGrupos_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void GridGrupos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            InfoCtePropietario infoCtePropietario = new InfoCtePropietario();

            infoCtePropietario.CteCodigo = int.Parse(e.NewValues["CTECODIGO"].ToString());
            infoCtePropietario.CepFechaInicio = DateTime.Parse(e.NewValues["CEPFECHAINICIO"].ToString());
            infoCtePropietario.CepNumeroCuotas = Convert.ToInt32(Adicional.Verificar_Valor(e.NewValues["CEPNUMEROCUOTAS"].ToString(), 50, false));
            infoCtePropietario.IdPropiedad = Convert.ToInt16(QString["IDPROPIEDAD"]);
            infoCtePropietario.IdCtePropietario = int.Parse(Session["IDCUENTAESPECIALPROP"].ToString());
            Aurora.Clases.Negocio.CtePropietario.Modificar(infoCtePropietario);
            BindGrilla();
     
            e.Cancel = true;


        }

        protected void GridGrupos_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Add("IDCUENTAESPECIALPROP", e.EditingKeyValue.ToString());
            GridGrupos.Columns["IDCUENTAESPECIALPROP"].Visible = false;
            GridGrupos.Columns["FECHACREACION"].Visible = false;
            GridGrupos.Columns["FECHAMODIFICACION"].Visible = false;


        }

        protected void GridGrupos_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Remove("IDCUENTAESPECIALPROP");
            GridGrupos.Columns["IDCUENTAESPECIALPROP"].Visible = false;
            GridGrupos.Columns["FECHACREACION"].Visible = true;
            GridGrupos.Columns["FECHAMODIFICACION"].Visible = true;
            GridGrupos.Columns["OPCIONES"].VisibleIndex = 10;

        }

       
        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin/AdminPropietarios.aspx");
        }

        protected void GridGrupos_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            GridGrupos.Columns["FECHACREACION"].Visible = false;
            GridGrupos.Columns["FECHAMODIFICACION"].Visible = false;
            GridGrupos.Columns["IDCUENTAESPECIALPROP"].Visible = false;
        }
   }
}
