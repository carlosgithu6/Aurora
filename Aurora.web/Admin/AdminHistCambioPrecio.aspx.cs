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
using System.Xml.Linq;
using Aurora.Clases.Base;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base.Encriptacion;

namespace Aurora.Web.Admin
{
    public partial class AdminHistCambioPrecio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GridGrupos.DataSource = Aurora.Clases.Negocio.CuentaVariable.ListarHistoricoCambioPrecios(int.Parse(Request.Params["cta"]));
            GridGrupos.DataBind();
        }

 
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin/AdminCuentasVariables.aspx");
      
        }
    }
}
