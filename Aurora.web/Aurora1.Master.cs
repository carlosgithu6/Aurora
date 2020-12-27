using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;

namespace Aurora.Web
{
    public partial class Aurora1 : System.Web.UI.MasterPage
    {
        public InfoUsuario _objCacheUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USUARIO"] != null)
                _objCacheUsuario = (InfoUsuario)Session["USUARIO"];
            else Response.Redirect("~/default.aspx");
            this.lblFecha.Text = "Chile, " + String.Format("{0:D}", DateTime.Now);

            if (!this.IsPostBack)
            {
                CargarMenu(_objCacheUsuario.Perfil);
                lblNombre.Text = _objCacheUsuario.NombreCompleto;
            }
        }
        private void CargarMenu(Perfil perfil)
        {
            switch (perfil)
            {
                case Perfil.Administrador:
                    XmlDataSource1.DataFile = "~/XMLMenu/Administrador.xml";
                    break;
                case Perfil.Usuario:
                    XmlDataSource1.DataFile = "~/XMLMenu/Usuario.xml";
                    break;

            }
            MenuPrincipal1.DataBind();
        }
        protected void btnSalir_Click(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("../Default.aspx");
        }

        protected void btnPassword_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Escritorio/Cambiopass.aspx");
        }
    }
}
