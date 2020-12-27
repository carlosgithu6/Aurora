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

namespace Aurora.Web
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador })]
    public partial class MensajesNota : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            CargarMensajes();
        }

        private void CargarMensajes()
        {

            Gridmsg.DataSource = Aurora.Clases.Negocio.Nomina.Listar();
            Gridmsg.DataBind();
        }

        protected void Gridmsg_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            Gridmsg.Columns["ID"].Visible = false;
        }

        protected void Gridmsg_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
           int id = Convert.ToInt16(e.NewValues["ID"]);
           string msg = Adicional.Verificar_Valor(e.NewValues["MSG"].ToString(), 200, false);

           Aurora.Clases.Negocio.Nomina.ActualizarMsg(id, msg);
           Gridmsg.Columns["ID"].Visible = false;
           e.Cancel = true;     
        }

        protected void Gridmsg_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Gridmsg.Columns["ID"].Visible = true; 
        }
    }
}
