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
    public partial class GenerarNomina :Autenticada
    {
      
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                AppSettingsReader appSettReader = new AppSettingsReader();
                int anobase = Convert.ToInt16(appSettReader.GetValue("ano1", typeof(int)));
                UI.Utiles.LlenarCombox(ref lstAnos, UI.Utiles.Anos(anobase));
                btnNomina.Text = "Crear nómina del mes y año seleccionado";
                btnCerrarNomina.Text = "Cerrar nómina del mes y año seleccionado";

            }
        }
       
        protected void btnNomina_Click(object sender, EventArgs e)
        {
            try
            {
                Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
                Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
                InfoNomina nom = Aurora.Clases.Negocio.Nomina.BuscarNomina(Mes,Ano);
                if (nom==null)
                {
                    Aurora.Clases.Negocio.Nomina.GenerarNomina(Mes,Ano);
                    lblMensaje.Text = "¡Generación exitosa!";
                }
                else
                {
                    lblMensaje.Text = "La nomina ya existe";
                    if (nom.FechaCierre != DateTime.MinValue) lblMensaje.Text += " y está cerrada";
                }
            }
            catch (Aurora.Clases.Negocio.ExcepcionNomina exx)
            {
                lblMensaje.Text = exx.Message;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "A ocurrido un error generando la nómina." + ex.Message;
            }
           
        }

        protected void btnCerrarNomina_Click(object sender, EventArgs e)
        {
            try
            {
                Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
                Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);

                if (!Aurora.Clases.Negocio.Nomina.EstaCerrada(Mes, Ano))
                {
                    Aurora.Clases.Negocio.Nomina.CerrarNominaActiva(Mes,Ano);
                    lblMensaje.Text = "¡Cierre exitoso!";
                }
                else
                {
                    lblMensaje.Text = "La nomina ya está cerrada";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "A ocurrido un error cerrando la nómina." + ex.Message;
            }
            
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
    
 
             
    }
}
