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
    [Perfil(new Perfil[] { Perfil.Administrador, Perfil.Usuario })]
    public partial class EstadodeCuenta : Autenticada
    {
        protected override  void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            try
            {
                if (!Page.IsPostBack)
                {
                    Int32 total = 0;
                    lblExcepcion.Visible = false;
                    InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"]));
                    lblano.Text = QString["ANO"];
                    lblMes.Text = ((Mes)Convert.ToInt16(QString["MES"])).ToString();
                    lblParcela.Text = prop.NombrePropiedad;
                    lblPropietario.Text = prop.NombreCompleto;
                    lblRut.Text = prop.Rut;
                    lblSocio.Text = prop.EsSocio ? "SI" : "NO";
                    lblSaldoFavor.Text = "$ "+ prop.SaldoCuentaCte.ToString("0,0.00");
                    gridVar.DataSource = Aurora.Clases.Negocio.GastosCV.GetForEstadoCuenta(Convert.ToInt16(QString["IDPROPIEDAD"]), Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"]), ref total);
                    gridVar.DataBind();
                    tblVar.Visible = ((DataTable)gridVar.DataSource).Rows.Count > 0;
                    GridFija.DataSource = Aurora.Clases.Negocio.GastosCF.GetForEstadoCuenta(Convert.ToInt16(QString["IDPROPIEDAD"]), Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"]), ref total); 
                    GridFija.DataBind();
                    tblFija.Visible = ((DataTable)GridFija.DataSource).Rows.Count > 0;
                    GridEspeciales.DataSource = Aurora.Clases.Negocio.GastosCE.GetForEstadoCuenta(Convert.ToInt16(QString["IDPROPIEDAD"]), Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"]), ref total); 
                    GridEspeciales.DataBind();
                    tblEsp.Visible = ((DataTable)GridEspeciales.DataSource).Rows.Count > 0;
                    lblTotal.Text = "$ " + ((int)total).ToString("0,0.00");
                    lblDeudaInicial.Text = "$ " + ((int)prop.DeudaPendiente).ToString("0,0.00");
                    lblTotalaPagar.Text = "$ " + ((int)(prop.DeudaPendiente + total)).ToString("0,0.00");
                    lblUF.Text = "$ " + Aurora.Clases.Negocio.UF.Buscar(Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"])).UF.ToString("0,0.00");
                    //lblConBomberos.Text = "$ " + Convert.ToInt32(((((int)(prop.DeudaPendiente + total)) + (((decimal)0.25) * Aurora.Clases.Negocio.UF.Buscar(Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"])).UF)))).ToString("0,0.00");
                }
            }
            catch (Exception ex)
            {
                lblExcepcion.Text = ex.Message;
                lblExcepcion.Visible = true;
            }
        }

       
    }
}
