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
using Aurora.Web.UI;
namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador,Perfil.Usuario })]
    public partial class AdminPropietariosMorosos : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            GridPropietarios.DataSource = Aurora.Clases.Negocio.Propietario.ListarMorosos(false,true);
            GridPropietarios.DataBind();
        }

        protected void GridPropietarios_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
                       
        }

        protected void GridPropietarios_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            decimal deudaCfija = (e.NewValues["DeudaFija"]is DBNull)? 0:Convert.ToDecimal(e.NewValues["DeudaFija"]);
            decimal deudaCVar = (e.NewValues["DeudaVar"] is DBNull) ? 0:Convert.ToDecimal(e.NewValues["DeudaVar"]);
            Aurora.Clases.Negocio.Propietario.PagarDeudaDeCuentas(Convert.ToInt16(e.NewValues["IDPROPIEDAD"]), deudaCfija, deudaCVar);
            e.Cancel = true;
        }

        protected void GridPropietarios_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void GridPropietarios_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            
            GridPropietarios.Columns["IDPROPIEDAD"].Visible = true;
            GridPropietarios.Columns["RUT"].Visible = true;
            GridPropietarios.Columns["NOMBRES"].Visible = true;
            GridPropietarios.Columns["APPATERNO"].Visible = true;
            GridPropietarios.Columns["APMATERNO"].Visible = true;
            GridPropietarios.Columns["SOCIO"].Visible = true;
            GridPropietarios.Columns["TELEFONO"].Visible = true;
            GridPropietarios.Columns["DeudaFija"].Visible = true;
            GridPropietarios.Columns["DeudaVar"].Visible = true;
            GridPropietarios.Columns["OPCIONES"].Visible = true;
            GridPropietarios.Columns["OPCIONES"].VisibleIndex = 16;
        }

        protected void GridPropietarios_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {

            foreach (DevExpress.Web.ASPxGridView.GridViewColumn col in GridPropietarios.Columns)
            {
                col.Visible = false;
            }
           
            GridPropietarios.Columns["RUT"].Visible = true;
            GridPropietarios.Columns["NOMBRES"].Visible = true;
            GridPropietarios.Columns["APPATERNO"].Visible = true;
            GridPropietarios.Columns["APMATERNO"].Visible = true;
            GridPropietarios.Columns["SOCIO"].Visible = true;
            GridPropietarios.Columns["TELEFONO"].Visible = true;
            GridPropietarios.Columns["DeudaFija"].Visible = true;
            GridPropietarios.Columns["DeudaVar"].Visible = true;
            GridPropietarios.Columns["OPCIONES"].Visible = true;
            GridPropietarios.Columns["OPCIONES"].VisibleIndex = 16;
   
        }

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExporter.WriteXlsToResponse("PropietariosMorosos", true);   
        }

      

   }
}
