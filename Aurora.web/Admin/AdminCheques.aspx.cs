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
using Aurora.Clases.Base;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base.Encriptacion;
using DevExpress.Web.ASPxGridView;
using Aurora.Web.UI;
namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador,Perfil.Usuario })]
    public partial class AdminCheques : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            List<InfoItem> lista = Aurora.Clases.Negocio.Propietario.List(false, true);
            GridViewDataComboBoxColumn combo = GridPropietarios.Columns["PROPIEDAD"] as GridViewDataComboBoxColumn;
            foreach (InfoItem item in lista)
            {
                combo.PropertiesComboBox.Items.Add(item.Text, item.Value);
            }
            cargarGrilla();
        }
        private void cargarGrilla()
        {
            GridPropietarios.DataSource = Aurora.Clases.Negocio.Cheque.ListarCheques();
            GridPropietarios.DataBind();
        }
        protected void GridPropietarios_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
           
        }

        protected void GridPropietarios_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Aurora.Clases.Negocio.Cheque.Eliminar(e.Values["NUMCHEQUE"].ToString(), Convert.ToInt16(e.Values["IDPROPIEDAD"]), Convert.ToInt16(e.Values["BANCO"]));
            cargarGrilla();
            e.Cancel = true;
        }

        protected void GridPropietarios_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void GridPropietarios_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            InfoCheque infoCheque = new InfoCheque();
            infoCheque.IdPropiedad = Convert.ToInt16(e.NewValues["PROPIEDAD"]);
            infoCheque.Estado = (EstadoCheque)(int)e.NewValues["ESTADO"];
            infoCheque.FechaCobro = (Convert.ToDateTime(e.NewValues["FECHACOBRO"]) == Convert.ToDateTime("01-01-0001 00:00:00")) ? Convert.ToDateTime("01-01-1900 00:00:00") : Convert.ToDateTime(e.NewValues["FECHACOBRO"]);
            infoCheque.FechaRecepcion = Convert.ToDateTime(e.NewValues["FECHARECEP"]);
            infoCheque.IdBanco = Convert.ToInt16(e.NewValues["BANCO"]);
            infoCheque.Monto = Convert.ToDecimal(e.NewValues["MONTO"]);
            infoCheque.NumCheque = e.NewValues["NUMCHEQUE"].ToString();
            Aurora.Clases.Negocio.Cheque.Crear(infoCheque);
            cargarGrilla();
            e.Cancel = true; 
        }

        protected void GridPropietarios_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void GridPropietarios_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            if (Convert.ToInt16(e.OldValues["BANCO"]) != Convert.ToInt16(e.NewValues["BANCO"])) throw new Exception("El banco no puede cambiar. Es parte de la identificación del cheque");
           // if (e.OldValues["PROPIEDAD"].ToString() != e.NewValues["PROPIEDAD"].ToString()) throw new Exception("La propiedad no puede cambiar. Es parte de la identificación del cheque");
            if (e.OldValues["NUMCHEQUE"].ToString() != e.NewValues["NUMCHEQUE"].ToString()) throw new Exception("El número del cheque no puede cambiar. Es parte de la indentificación del mismo");

            InfoCheque infoCheque = new InfoCheque();
            infoCheque.IdPropiedad = Convert.ToInt16(e.OldValues["IDPROPIEDAD"]);
            infoCheque.Estado = (EstadoCheque)(int)e.NewValues["ESTADO"];
            infoCheque.FechaCobro = (Convert.ToDateTime(e.NewValues["FECHACOBRO"]) == Convert.ToDateTime("01-01-0001 00:00:00")) ? Convert.ToDateTime("01-01-1900 00:00:00") : Convert.ToDateTime(e.NewValues["FECHACOBRO"]);
            infoCheque.FechaRecepcion = Convert.ToDateTime(e.NewValues["FECHARECEP"]);
            infoCheque.IdBanco = Convert.ToInt16(e.OldValues["BANCO"]);
            infoCheque.Monto = Convert.ToDecimal(e.NewValues["MONTO"]);
            infoCheque.NumCheque = e.OldValues["NUMCHEQUE"].ToString();
            Aurora.Clases.Negocio.Cheque.Modificar(infoCheque);
            cargarGrilla();
            e.Cancel = true;
        }

        protected void GridPropietarios_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            foreach (DevExpress.Web.ASPxGridView.GridViewColumn col in GridPropietarios.Columns)
            {
                col.Visible = true;
            }
        }

       

         protected void GridPropietarios_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            foreach (DevExpress.Web.ASPxGridView.GridViewColumn col in GridPropietarios.Columns)
            {
                col.Visible = true;
            }            
        }

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {          
             gridExporter.WriteXlsToResponse("Cheques", true);           
        }

        protected void GridPropietarios_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            GridPropietarios.Columns["IDPROPIEDAD"].Visible = false;
        }

   }
}
