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
    [Perfil(new Perfil[] { Perfil.Administrador})]
    public partial class CartolaIngresoMensual : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            try
            {
                lblExcepcion.Visible = false;
                if (!Page.IsPostBack)
                {
                    AppSettingsReader appSettReader = new AppSettingsReader();
                    int anobase = Convert.ToInt16(appSettReader.GetValue("ano1", typeof(int)));
                    UI.Utiles.LlenarCombox(ref lstAnos, UI.Utiles.Anos(anobase));

                }
                if (IsCallback)
                {
                    System.Threading.Thread.Sleep(500);
                }
            
                if (Mes != 0 || Ano != 0)
                    Cargar();
            }

            catch (Exception ex)
            {
                lblExcepcion.Text = ex.Message;
                lblExcepcion.Visible = true;
            }
        }

        protected void btnBuscarNomina_Click(object sender, EventArgs e)
        {
            try
            {
                lblExcepcion.Visible = false;
                Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
                Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
                Desde = Convert.ToDateTime(DateDesde.Value);
                Hasta = Convert.ToDateTime(DateHasta.Value);
                if (Desde > Hasta) throw new Exception("La fecha DESDE debe ser menor que la fecha HASTA");
                Cargar();
            }
            catch (Exception ex)
            {
                lblExcepcion.Text = ex.Message;
                lblExcepcion.Visible = true;
            }
        }
        private void Cargar()
        {
            gridVar.DataSource = Aurora.Clases.Negocio.Nomina.BuscarIngresosRealesPorFechasPago(Desde, Hasta);
            gridVar.DataBind();
           // grid_a_Pagar.DataSource = Aurora.Clases.Negocio.Nomina.BuscarTotalAPagar(Mes, Ano);
            //grid_a_Pagar.DataBind();
            grid_NotasCobros.DataSource = Aurora.Clases.Negocio.Nomina.GetForExcel(Mes, Ano);
            grid_NotasCobros.DataBind();
            btnXlsExport.Visible = true;
            btnXlsNotasCobro.Visible = true;
            grid_NotasCobros.Visible = true;
            gridVar.Visible = true;
        }
        private int Mes
        {
            get
            {
                return ViewState["mes"] == null ? 0 : Convert.ToInt16(ViewState["mes"]);
            }
            set
            {
                ViewState["mes"] = value;
            }
        }
        private int Ano
        {
            get
            {
                return ViewState["ano"] == null ? 0 : Convert.ToInt16(ViewState["ano"]);
            }
            set
            {
                ViewState["ano"] = value;
            }
        }
        private DateTime Desde
        {
            get
            {
                return ViewState["desde"] == null ? DateTime.MinValue : Convert.ToDateTime(ViewState["desde"]);
            }
            set
            {
                ViewState["desde"] = value;
            }
        }

        private DateTime Hasta
        {
            get
            {
                return ViewState["hasta"] == null ? DateTime.MaxValue : Convert.ToDateTime(ViewState["hasta"]);
            }
            set
            {
                ViewState["hasta"] = value;
            }
        }
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExporter.WriteXlsToResponse("IngresoReales" + Desde.Year + "" + Desde.Month + "" + Desde.Day + "A" + Hasta.Year + "" + Hasta.Month + "" + Hasta.Day, true);  
        }

        

        protected void btnXlsNotasCobro_Click(object sender, EventArgs e)
        {
            gridExporter1.WriteXlsToResponse("Notas_de_Cobro" + Ano.ToString() + "-" + Mes.ToString(), true); 
        }

        
      
       
    }
}
