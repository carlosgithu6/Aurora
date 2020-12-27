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
    [Perfil(new Perfil[] { Perfil.Administrador })]
    
    public partial class AdminCuentasEspeciales : Autenticada
    {
         protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
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
            GridGrupos.DataSource = Aurora.Clases.Negocio.CuentaEspecial.Listar(false);
            GridGrupos.DataBind();

        }

        protected void GridGrupos_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs e)
        {

        }

        protected void GridGrupos_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }

        protected void GridGrupos_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Aurora.Clases.Negocio.CuentaEspecial.Eliminar(int.Parse(e.Values["CTECODIGO"].ToString()));
            e.Cancel = true;
            BindGrilla();

        }

        protected void GridGrupos_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void GridGrupos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            InfoCuentaEspecial infoCuentaEspecial = new InfoCuentaEspecial();

            infoCuentaEspecial.CteDescripcion = Adicional.Verificar_Valor(e.NewValues["CTEDESCRIPCION"].ToString(), 50, false);
            infoCuentaEspecial.CtePrecio = Convert.ToDecimal(Adicional.Verificar_Valor(e.NewValues["CTEPRECIO"].ToString(), 50, false));

            Aurora.Clases.Negocio.CuentaEspecial.Crear(infoCuentaEspecial);
            BindGrilla();
            e.Cancel = true;


        }

        protected void GridGrupos_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void GridGrupos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            InfoCuentaEspecial infoCuentaEspecial = new InfoCuentaEspecial();

            infoCuentaEspecial.CteCodigo = int.Parse(e.Keys[0].ToString());
            infoCuentaEspecial.CteDescripcion = Adicional.Verificar_Valor(e.NewValues["CTEDESCRIPCION"].ToString(), 50, false);
            infoCuentaEspecial.CtePrecio = Convert.ToDecimal(Adicional.Verificar_Valor(e.NewValues["CTEPRECIO"].ToString(), 50, false));

            Aurora.Clases.Negocio.CuentaEspecial.Modificar(infoCuentaEspecial);
            BindGrilla();
            e.Cancel = true;


        }

        protected void GridGrupos_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Add("EDITCUENTA", e.EditingKeyValue.ToString());
            GridGrupos.Columns["CTECODIGO"].Visible = false;
            GridGrupos.Columns["FECHACREACION"].Visible = false;
            GridGrupos.Columns["FECHAMODIFICACION"].Visible = false;

        }

        protected void GridGrupos_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Remove("EDITCUENTA");
            GridGrupos.Columns["CTECODIGO"].Visible = false;
            GridGrupos.Columns["FECHACREACION"].Visible = true;
            GridGrupos.Columns["FECHAMODIFICACION"].Visible = true;

        }

        protected void GridGrupos_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {


        }
        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

        protected void GridGrupos_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {

        }

        protected void GridGrupos_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {

        }
    
        protected void ASPxButtonclose_Click(object sender, EventArgs e)
        {

        }

        protected void GridGrupos_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
           
            GridGrupos.Columns["FECHACREACION"].Visible = false;
            GridGrupos.Columns["FECHAMODIFICACION"].Visible = false;
            GridGrupos.Columns["CTECODIGO"].Visible = false;
          
        }

        protected void GridGrupos_BeforeColumnSortingGrouping(object sender, ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
       }



    }
}
