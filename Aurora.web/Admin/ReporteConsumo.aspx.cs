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
    public partial class ReporteConsumo : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (Session["ReporteConsumo"] == null)
                Session["ReporteConsumo"] = Aurora.Clases.Negocio.Propietario.ListarConsumo();

            GridPropietarios.DataSource = (DataTable)Session["ReporteConsumo"];
            GridPropietarios.DataBind();
           
        }


        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExporter.WriteXlsToResponse("InformeConsumo", true);   
        }

      

   }
}
