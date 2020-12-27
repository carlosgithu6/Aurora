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
    [Perfil(new Perfil[] { Perfil.Administrador })]
    public partial class AdminFeriados : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            CargarFeriados();
        }
        private void CargarFeriados()
        {
            gridFeriados.DataSource = Aurora.Clases.Negocio.Feriado.ListarFeriados();
            gridFeriados.DataBind();
        }

        protected void gridFeriados_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            DateTime feriado = Convert.ToDateTime(e.NewValues["FERIADO"]);
            InfoFeriado infoFeriado = new InfoFeriado(feriado);
            Aurora.Clases.Negocio.Feriado.Crear(infoFeriado);
            e.Cancel = true;
        }

        protected void gridFeriados_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void gridFeriados_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }

        protected void gridFeriados_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            DateTime Feriado = Convert.ToDateTime(e.Values["FERIADO"]);
           
            Aurora.Clases.Negocio.Feriado.Eliminar(Feriado);
            CargarFeriados();
            e.Cancel = true;
        }

       

    }
}
