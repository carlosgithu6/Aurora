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
    public partial class CambioMedidor : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            GridPropietarios.DataSource = Aurora.Clases.Negocio.Propietario.Listar(false,true);
            GridPropietarios.DataBind();
        }

        protected void GridPropietarios_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            object f = GridPropietarios.GetRowValues(e.VisibleIndex, "IDPROPIEDAD");
            Dictionary<string,string> valores = new Dictionary<string,string>();
            valores.Add("IDPROPIEDAD", f.ToString());
            QueryString QS = new QueryString(valores);
            Response.RedirectLocation = "AdminCambioMedidores1.aspx?" + QS.QSEncriptada;
        }

   }
}
