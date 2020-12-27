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
using Aurora.Clases.Base.Enums;
using Aurora.Web.UI;

namespace Aurora.Web
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador,Perfil.Usuario})]
    public partial class Administracion : Autenticada
    {
        protected override   void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
        }
    }
}
