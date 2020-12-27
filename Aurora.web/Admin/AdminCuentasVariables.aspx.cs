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
    public partial class AdminCuentasVariables : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                GridViewDataComboBoxColumn combo = GridGrupos.Columns["CTVTIPO"] as GridViewDataComboBoxColumn;
                combo.PropertiesComboBox.ValueType = typeof(int);
                foreach (int i in Enum.GetValues(typeof(TipoCuentaVariable)))
                {
                    combo.PropertiesComboBox.Items.Add(Enum.GetName(typeof(TipoCuentaVariable), i), i);
                }

                combo = GridGrupos.Columns["CTVUNIDADMEDIDA"] as GridViewDataComboBoxColumn;
                combo.PropertiesComboBox.ValueType = typeof(int);
                foreach (int i in Enum.GetValues(typeof(UnidadMedida)))
                {
                    combo.PropertiesComboBox.Items.Add(Enum.GetName(typeof(UnidadMedida), i), i);
                }

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
            GridGrupos.DataSource = Aurora.Clases.Negocio.CuentaVariable.Listar(false);
            GridGrupos.DataBind();
        }

        protected void GridGrupos_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }

        protected void GridGrupos_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Aurora.Clases.Negocio.CuentaVariable.Eliminar(int.Parse(e.Values["CTVCODIGO"].ToString()));
            e.Cancel = true;
            BindGrilla();

        }

        protected void GridGrupos_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void GridGrupos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            InfoCuentaVariable infoCuentaVariable = new InfoCuentaVariable();

            infoCuentaVariable.CtvDescripcion = Adicional.Verificar_Valor(e.NewValues["CTVDESCRIPCION"].ToString(), 50, false);
            infoCuentaVariable.CtvPrecio = Convert.ToDecimal(Adicional.Verificar_Valor(e.NewValues["CTVPRECIO"].ToString(), 50, false));
            infoCuentaVariable.CtvTipo = (TipoCuentaVariable)Enum.Parse(typeof(TipoCuentaVariable), e.NewValues["CTVTIPO"].ToString());
            infoCuentaVariable.CtvUnidadMedida = (UnidadMedida)Enum.Parse(typeof(UnidadMedida), e.NewValues["CTVUNIDADMEDIDA"].ToString());

            Aurora.Clases.Negocio.CuentaVariable.Crear(infoCuentaVariable, int.Parse(Usuario.Rut.Substring(0,Usuario.Rut.Length-2)));
            BindGrilla();
            e.Cancel = true;
         

        }

        protected void GridGrupos_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void GridGrupos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
        
            InfoCuentaVariable infoCuentaVariable = new InfoCuentaVariable();
            infoCuentaVariable.CtvCodigo = int.Parse(e.Keys[0].ToString());
            infoCuentaVariable.CtvDescripcion = Adicional.Verificar_Valor(e.NewValues["CTVDESCRIPCION"].ToString(), 50, false);
            infoCuentaVariable.CtvPrecio = Convert.ToDecimal(Adicional.Verificar_Valor(e.NewValues["CTVPRECIO"].ToString(), 50, false));
            infoCuentaVariable.CtvTipo = (TipoCuentaVariable)Enum.Parse(typeof(TipoCuentaVariable), e.NewValues["CTVTIPO"].ToString());
            infoCuentaVariable.CtvUnidadMedida = (UnidadMedida)Enum.Parse(typeof(UnidadMedida), e.NewValues["CTVUNIDADMEDIDA"].ToString());

            Aurora.Clases.Negocio.CuentaVariable.Modificar(infoCuentaVariable,int.Parse(Usuario.Rut.Substring(0, Usuario.Rut.Length - 2)));
            BindGrilla();
            e.Cancel = true;
          

        }

        protected void GridGrupos_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Add("EDITCUENTA", e.EditingKeyValue.ToString());
            GridGrupos.Columns["CTVCODIGO"].Visible = false;
            GridGrupos.Columns["FECHACREACION"].Visible = false;
            GridGrupos.Columns["FECHAMODIFICACION"].Visible = false;
        }

        protected void GridGrupos_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Remove("EDITCUENTA");
            GridGrupos.Columns["CTVCODIGO"].Visible = true;
            GridGrupos.Columns["FECHACREACION"].Visible = true;
            GridGrupos.Columns["FECHAMODIFICACION"].Visible = true;
        }

        void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

      

        protected void GridGrupos_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            object  f= GridGrupos.GetRowValues(e.VisibleIndex, "CTVCODIGO");

            Response.RedirectLocation = "AdminHistCambioPrecio.aspx?cta=" + f.ToString ();
        }

         protected void GridGrupos_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            GridGrupos.Columns["FECHACREACION"].Visible = false;
            GridGrupos.Columns["FECHAMODIFICACION"].Visible = false;
            GridGrupos.Columns["CTVCODIGO"].Visible = false;         
        }        

    }
}
