using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
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
    public partial class CartolaContabilidad : Autenticada
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
                    UI.Utiles.LlenarCombox(ref lstAnosD, UI.Utiles.Anos(anobase));
                    UI.Utiles.LlenarCombox(ref lstAnosH, UI.Utiles.Anos(anobase));
                }
                if (IsCallback)
                {
                    System.Threading.Thread.Sleep(500);
                }

                if (Desde != DateTime.MinValue && Hasta != DateTime.MaxValue)
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
                AnoD = Convert.ToInt32(lstAnosD.Value);
                MesD = Convert.ToInt32(lstMesD.Value);

                AnoH = Convert.ToInt32(lstAnosH.Value);
                MesH = Convert.ToInt32(lstMesH.Value);

                Desde = new DateTime(AnoD, MesD, 1);
                Hasta = new DateTime(AnoH, MesH, 1);
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
            List<InfoGastosCF> gf = new List<InfoGastosCF>();
            List<InfoGastosCV> gv = new List<InfoGastosCV>();
            List<InfoItem> props = Aurora.Clases.Negocio.Propietario.List(false, true);
            int cant = 0;
            try
            {
                for (int i = 0; i < props.Count;i++ )
                {
                    InfoItem ii = props[i];
                    gf.AddRange(Aurora.Clases.Negocio.GastosCF.BuscarListaHistoria(ii.Value, Desde.Year, Desde.Month, Hasta.Year, Hasta.Month));
                    gv.AddRange(Aurora.Clases.Negocio.GastosCV.BuscarListaHistoria(ii.Value, Desde.Year, Desde.Month, Hasta.Year, Hasta.Month));
                }
                DataTable dtable = new DataTable();
                dtable.Columns.Add("ID PROPIEDAD");
                dtable.Columns.Add("AÑO");
                dtable.Columns.Add("MES");
                dtable.Columns.Add("PROPIEDAD");
                dtable.Columns.Add("PROPIETARIO");
                dtable.Columns.Add("CUENTA");
                dtable.Columns.Add("APAGAR");
                dtable.Columns.Add("PAGADO");
                dtable.Columns.Add("DEUDA");
                dtable.Columns.Add("FECHAPAGO");
                #region for para cuenta gastos fijos
                for (int i = 0; i < gf.Count;i++)
                {
                    InfoGastosCF igf = gf[i];
                    InfoPropietario p = Aurora.Clases.Negocio.Propietario.Buscar(igf.IdPropiedad);
                    Int32 Apagar = Convert.ToInt32(igf.GCFMonto * Aurora.Clases.Negocio.UF.Buscar(igf.Mes, igf.Ano).UF);
                    Int32 Deuda = Apagar - Convert.ToInt32(igf.GCFMontoCancelado);
                    DataRow dr = dtable.NewRow();
                    dr["ID PROPIEDAD"] = igf.IdPropiedad;
                    dr["AÑO"] = igf.Ano;
                    dr["MES"] = igf.Mes;
                    dr["CUENTA"] = Aurora.Clases.Negocio.CuentaFija.Buscar(igf.CFCodigo).Descripcion;
                    dr["PROPIEDAD"] = p.NombrePropiedad;
                    dr["PROPIETARIO"] = p.NombreCompleto;
                    dr["APAGAR"] = Apagar;
                    dr["PAGADO"] = Convert.ToInt32(igf.GCFMontoCancelado);
                    dr["DEUDA"] = Deuda;// Convert.ToInt32(Convert.ToDecimal(dr["APAGAR"]) - igf.GCFMontoCancelado);
                    dr["FECHAPAGO"] = (igf.FechaPago == DateTime.MinValue || igf.FechaPago == new DateTime(1900,1,1)) ? "-" : igf.FechaPago.ToString("dd/MM/yyyy");
                    dtable.Rows.Add(dr);
               
                }
                #endregion
                #region for para cuentas variables
                for (int i = 0; i < gv.Count; i++)
                {
                    InfoGastosCV igv = gv[i];
                    InfoPropietario ip = Aurora.Clases.Negocio.Propietario.Buscar(igv.IdPropiedad);
                    Int32 Apagar = Convert.ToInt32(igv.getCostoTotal());
                    Int32 Deuda = Apagar - Convert.ToInt32(igv.GVMontoCancelado);
                   
                    DataRow dr = dtable.NewRow();
                    dr["ID PROPIEDAD"] = igv.IdPropiedad;
                    dr["AÑO"] = igv.Ano;
                    dr["MES"] = igv.Mes;
                    dr["CUENTA"] = Aurora.Clases.Negocio.CuentaVariable.Buscar(igv.CTVCodigo).CtvDescripcion;
                    dr["PROPIEDAD"] = ip.NombrePropiedad;
                    dr["PROPIETARIO"] = ip.NombreCompleto;
                    dr["APAGAR"] = Apagar;
                    dr["PAGADO"] = Convert.ToInt32(igv.GVMontoCancelado);
                    dr["DEUDA"] = Deuda;
                    dr["FECHAPAGO"] = (igv.FechaPago == DateTime.MinValue || igv.FechaPago == new DateTime(1900, 1, 1)) ? "-" : igv.FechaPago.ToString("dd/MM/yyyy");
                    dtable.Rows.Add(dr);
                  }
               
                #endregion

                gridpagos.DataSource = dtable;
                gridpagos.DataBind();
                gridExporter1.WriteXlsToResponse("Deudas_Vigentes" + lstAnosD.Value + "" + lstMesD.Value + "A" + lstAnosH.Value + "" + lstMesH.Value, true);
            }
            catch(Exception F)
            {
                int k = cant;
                throw F;
            }
        }

        private int MesD
        {
            get
            {
                return ViewState["mesd"] == null ? 0 : Convert.ToInt16(ViewState["mesd"]);
            }
            set
            {
                ViewState["mesd"] = value;
            }
        }
        private int AnoD
        {
            get
            {
                return ViewState["anod"] == null ? 0 : Convert.ToInt16(ViewState["anod"]);
            }
            set
            {
                ViewState["anod"] = value;
            }
        }
      //------------------------------------------
        private int MesH
        {
            get
            {
                return ViewState["mesh"] == null ? 0 : Convert.ToInt16(ViewState["mesh"]);
            }
            set
            {
                ViewState["mesh"] = value;
            }
        }
        private int AnoH
        {
            get
            {
                return ViewState["anoh"] == null ? 0 : Convert.ToInt16(ViewState["anoh"]);
            }
            set
            {
                ViewState["anoh"] = value;
            }
        }

        //---------------------------------------
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

       
      

        

       


       
       
    }
}
