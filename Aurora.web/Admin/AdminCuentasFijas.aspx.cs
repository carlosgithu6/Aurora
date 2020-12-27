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
namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador})]
    public partial class AdminCuentasFijas : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            CargarCuentasFijas();
        }
        private void CargarCuentasFijas()
        {
            GridCFijas.DataSource = Aurora.Clases.Negocio.CuentaFija.Listar(false);
            GridCFijas.DataBind();
        }

        protected void GridCFijas_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void GridCFijas_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            InfoCuentaFija infoCuentaFija = new InfoCuentaFija();
            infoCuentaFija.Descripcion = Adicional.Verificar_Valor(e.NewValues["DESCRIPCION"].ToString(), 50, false);
            infoCuentaFija.FechaCambioTarifa = DateTime.Now;
            infoCuentaFija.FechaCreacion = DateTime.Now;
            infoCuentaFija.FechaFinVigencia =  DateTime.Now;
            infoCuentaFija.FechaInicioVigencia = DateTime.Now;
            //if (infoCuentaFija.FechaInicioVigencia >= infoCuentaFija.FechaFinVigencia)
            //{
            //    throw new Exception("La fecha de inicio debe ser inferior a la fecha de fin de vigencia.");
            //}
            infoCuentaFija.Tarifa = Convert.ToDecimal(e.NewValues["TARIFAACTUAL"]);
            infoCuentaFija.Tipo = (TipoCuentaFija)e.NewValues["TIPOCUENTA"];
            Aurora.Clases.Negocio.CuentaFija.Crear(infoCuentaFija);
            e.Cancel = true; 
        }

        protected void GridCFijas_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Add("EDITCOD", e.EditingKeyValue.ToString());
            GridCFijas.Columns["CODIGO"].Visible = false;
        }

        protected void GridCFijas_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Remove("EDITCOD");
            GridCFijas.Columns["CODIGO"].Visible = false;
            GridCFijas.Columns["OPCIONES"].VisibleIndex  =10;
        }

        protected void GridCFijas_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void GridCFijas_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            InfoCuentaFija infoCuentaFija = new InfoCuentaFija();
            infoCuentaFija.Codigo = Convert.ToInt16(e.Keys[0].ToString());
            infoCuentaFija.Descripcion = Adicional.Verificar_Valor(e.NewValues["DESCRIPCION"].ToString(), 50, false);
            decimal tarifaNueva = Convert.ToDecimal(e.NewValues["TARIFAACTUAL"]);
            decimal tarifaVieja = Convert.ToDecimal(e.OldValues["TARIFAACTUAL"]);
            if (tarifaNueva != tarifaVieja)
            {
                Tarifas tarifas = new Tarifas();
                tarifas.Codigo = infoCuentaFija.Codigo;
                tarifas.TarifaAnterior = tarifaVieja;
                tarifas.TarifaNueva = tarifaNueva;
                Aurora.Clases.Negocio.CuentaFija.CrearHistorico(tarifas);
            }
            infoCuentaFija.FechaCambioTarifa = DateTime.Now;
            infoCuentaFija.FechaCreacion = DateTime.Now;
            infoCuentaFija.FechaFinVigencia = DateTime.Now; //Convert.ToDateTime(e.NewValues["FECHAFIN"]);
            infoCuentaFija.FechaInicioVigencia = DateTime.Now; //Convert.ToDateTime(e.NewValues["FECHAINICIO"]);
            //if (infoCuentaFija.FechaInicioVigencia >= infoCuentaFija.FechaFinVigencia)
            //{
            //    throw new Exception("La fecha de inicio debe ser inferior a la fecha de fin de vigencia.");
            //}
            infoCuentaFija.Tarifa = Convert.ToDecimal(e.NewValues["TARIFAACTUAL"]);
            infoCuentaFija.Tipo = (TipoCuentaFija)e.NewValues["TIPOCUENTA"];
            Aurora.Clases.Negocio.CuentaFija.Modificar(infoCuentaFija);
            e.Cancel = true; 
        }

        protected void GridCFijas_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
        
        }

        protected void GridCFijas_PageIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void GridCFijas_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            GridCFijas.Columns["CODIGO"].Visible = false;
   
        }

        protected void GridCFijas_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Aurora.Clases.Negocio.CuentaFija.Eliminar(int.Parse(e.Values["CODIGO"].ToString()));
            e.Cancel = true;
            CargarCuentasFijas(); 
        }
       
    }
}
