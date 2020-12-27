using System;
using System.Collections;
using System.Collections.Generic;
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
using DevExpress.Web.ASPxGridView;
using Aurora.Clases.Base;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base.Encriptacion;
using Aurora.Web.UI;
namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador})]
    public partial class CuentasFijasPropietario : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                GridViewDataComboBoxColumn combo = GridCFijas.Columns["TIPOCUENTA"] as GridViewDataComboBoxColumn;
                combo.PropertiesComboBox.ValueType = typeof(int);
                foreach (int i in Enum.GetValues(typeof(TipoCuentaFija)))
                {
                    combo.PropertiesComboBox.Items.Add(Enum.GetName(typeof(TipoCuentaFija), i), i);
                }
                GridViewDataComboBoxColumn combo2 = GridCFijas.Columns["IDCUENTAFIJA"] as GridViewDataComboBoxColumn;
                
                combo2.PropertiesComboBox.ValueType = typeof(int);
                List<InfoCuentaFija> listaCF = Aurora.Clases.Negocio.CuentaFija.Lista(false);
                foreach (InfoCuentaFija cf in listaCF)
                {
                    combo2.PropertiesComboBox.Items.Add(cf.Descripcion,cf.Codigo.ToString());
                }
                InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"]));
                GridCFijas.SettingsText.Title = "CUENTAS FIJAS ASOCIADAS A: " + prop.NombreCompleto + "  (" + prop.NombrePropiedad + ")";
  
                CargarCuentasFijas();
            }
        }
        private void CargarCuentasFijas()
        {
            InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"]));
            GridCFijas.DataSource = Aurora.Clases.Negocio.Propietario.BuscarCuentasFijas(prop);
            GridCFijas.DataBind();
        }

        protected void GridCFijas_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void GridCFijas_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            InfoCuentaFijaPropietario asociacion = new InfoCuentaFijaPropietario();
            
            asociacion.IdCuentaFija = Convert.ToInt16(e.NewValues["IDCUENTAFIJA"]);
            asociacion.IdPropiedad = Convert.ToInt16(QString["IDPROPIEDAD"]);
            if (e.NewValues["TARIFA"] != null)
                asociacion.TarifaEspecial = Convert.ToDecimal(e.NewValues["TARIFA"]);
            else
                asociacion.TarifaEspecial = -1;
            Aurora.Clases.Negocio.CuentaFija.AsociarPropietario(asociacion);
           
            e.Cancel = true;
        }

        protected void GridCFijas_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            foreach (DevExpress.Web.ASPxGridView.GridViewColumn col in GridCFijas.Columns)
            {
                col.Visible = false;
            }
            GridCFijas.Columns["IDCUENTAFIJA"].Visible = true;
            GridCFijas.Columns["TARIFA"].Visible=true;
            
        }

        protected void GridCFijas_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            CargarCuentasFijas();
            GridCFijas.Columns["TIPOCUENTA"].Visible = true;
            GridCFijas.Columns["IDCUENTAFIJA"].Visible = true;
            GridCFijas.Columns["DESCRIPCION"].Visible = false;
            GridCFijas.Columns["TARIFA"].Visible = true;
            GridCFijas.Columns["FECHACREACION"].Visible = true;
            GridCFijas.Columns["FECHAACTUALIZACION"].Visible = true;
            GridCFijas.Columns["OPCIONES"].Visible = true;

            GridCFijas.Columns["OPCIONES"].VisibleIndex = 20;
            GridCFijas.Columns["IDCUENTAFIJA"].VisibleIndex = 1;
            GridCFijas.Columns["TIPOCUENTA"].VisibleIndex = 2;
           
            GridCFijas.Columns["TARIFA"].VisibleIndex = 3;
            GridCFijas.Columns["FECHACREACION"].VisibleIndex = 4;
            GridCFijas.Columns["FECHAACTUALIZACION"].VisibleIndex = 5;
          
        }

        protected void GridCFijas_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }

        protected void GridCFijas_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            InfoCuentaFijaPropietario asociacion = new InfoCuentaFijaPropietario();
            asociacion.IdCuentaFija = Convert.ToInt16(e.Values["IDCUENTAFIJA"]);
            asociacion.IdPropiedad = Convert.ToInt16(QString["IDPROPIEDAD"]);
            Aurora.Clases.Negocio.CuentaFija.DesasociarPropietario(asociacion);
            CargarCuentasFijas();
            e.Cancel = true;
        }

        protected void GridCFijas_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void GridCFijas_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            InfoCuentaFijaPropietario asociacion = new InfoCuentaFijaPropietario();

            asociacion.IdCuentaFija = Convert.ToInt16(e.NewValues["IDCUENTAFIJA"]);
            asociacion.IdPropiedad = Convert.ToInt16(QString["IDPROPIEDAD"]);
            if (e.NewValues["TARIFA"] != null)
                asociacion.TarifaEspecial = Convert.ToDecimal(e.NewValues["TARIFA"]);
            else
                asociacion.TarifaEspecial = -1;
            Aurora.Clases.Negocio.CuentaFija.ModificarAsocionPropietario(asociacion);
            e.Cancel = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin/AdminPropietarios.aspx");
        }
              
    }
}
