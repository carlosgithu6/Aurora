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
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using Aurora.Clases.Base;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base.Encriptacion;
using Aurora.Web.UI;

namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador,Perfil.Usuario })]
    public partial class AdminDeudasAntigua : Autenticada
    {
        int etapaInicial;
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                AppSettingsReader appSettReader = new AppSettingsReader();
                etapaInicial = Convert.ToInt16(appSettReader.GetValue("etapaInicial", typeof(int)));
               
            }
            CargarGrilla();

            
        }
         
        void CargarGrilla()
        {
            Grilla.DataSource = Aurora.Clases.Negocio.Propietario.ListarDeudaInicial(false);
            Grilla.DataBind();
            
        }

        protected void Grilla_RowUpdated1(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void Grilla_RowUpdating1(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(e.OldValues["IDPROPIEDAD"]));
            decimal montoAbono = Convert.ToDecimal(e.NewValues["ABONO"]);
            decimal montoPagoDeuda = Convert.ToDecimal(e.NewValues["AMORTIZARDEUDA"]);
            decimal DeudaInicial = Convert.ToDecimal(e.NewValues["DEUDAINICIAL"]);
            bool descontarCte = Convert.ToBoolean(e.NewValues["DESCONTARCTE"]);
            Aurora.Clases.Negocio.Propietario.AbonarACuentaCorriente(prop, montoAbono,false);
            Aurora.Clases.Negocio.Propietario.PagarDeuda(prop, montoPagoDeuda,descontarCte);
            if (Convert.ToDecimal(e.OldValues["DEUDAINICIAL"])==(decimal)0)
              Aurora.Clases.Negocio.Propietario.PonerDeudaInicial(prop, DeudaInicial);
            CargarGrilla();
            e.Cancel = true;
        }

        protected void Grilla_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Grilla.Columns["ABONO"].Visible = true;
            Grilla.Columns["AMORTIZARDEUDA"].Visible = true;
            Grilla.Columns["IDPROPIEDAD"].Visible = true;
            Grilla.Columns["DESCONTARCTE"].Visible = true;            
        }

        protected void Grilla_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Grilla.Columns["ABONO"].Visible = false;
            Grilla.Columns["AMORTIZARDEUDA"].Visible = false;
            Grilla.Columns["IDPROPIEDAD"].Visible = false;
            Grilla.Columns["DESCONTARCTE"].Visible = false;
        }

        protected void Grilla_DataBound(object sender, EventArgs e)
        {
            ((sender as ASPxGridView).Columns["DEUDAINICIAL"] as GridViewDataTextColumn).ReadOnly = (etapaInicial == 1);
        }

        protected void Grilla_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "ElimAbono")
            {
              object f = Grilla.GetRowValues(e.VisibleIndex, "IDPROPIEDAD");
              Aurora.Clases.Negocio.Propietario.EliminarUltimoAbono(Convert.ToInt16(f));
            }
            CargarGrilla();
        }

       
    }
}