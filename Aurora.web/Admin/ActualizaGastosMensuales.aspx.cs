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
using DevExpress.Web.ASPxGridView;
using Aurora.Clases.Negocio;
using Aurora.Clases.Entidad;

namespace Aurora.Web.Admin
{
    public partial class ActualizaGastosMensuales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !IsCallback)
            {
                AppSettingsReader appSettReader = new AppSettingsReader();
                int anobase = Convert.ToInt16(appSettReader.GetValue("ano1", typeof(int)));
                UI.Utiles.LlenarCombox(ref lstAnos, UI.Utiles.Anos(anobase));
            }
            if (IsCallback)
            {
                System.Threading.Thread.Sleep(500);
            }
            BuscarNomina(Mes, Ano);
        }

      
        protected void ASPxGridViewVariables_BeforePerformDataSelect(object sender, EventArgs e)
        {
            if (ViewState["actV"] == null || ViewState["actV"].ToString() == "S")
            {
                ASPxGridView aSPxGridViewV= (ASPxGridView)sender;
                aSPxGridViewV.DataSource = GastosCV.ListarGVByRUTyFecha(aSPxGridViewV.GetMasterRowKeyValue().ToString(), Mes, Ano);
                ViewState["actV"] = "N";
                aSPxGridViewV.DataBind();
            }
        }

        protected void ASPxGridViewEspeciales_BeforePerformDataSelect(object sender, EventArgs e)
        {
            if (ViewState["actE"] == null || ViewState["actE"].ToString() == "S")
            {
                ASPxGridView aSPxGridViewE= (ASPxGridView)sender;
              //  aSPxGridViewE.DataSource = GastosCE.ListarGEByIdGasto(aSPxGridViewE.GetMasterRowKeyValue().ToString());
                //DevuelveTablaFijos();
                ViewState["actE"] = "N";
                aSPxGridViewE.DataBind();
            }
        
        }

        protected void ASPxGridViewFijos_BeforePerformDataSelect(object sender, EventArgs e)
        {
            if ( ViewState["act"]==null || ViewState["act"].ToString() == "S"  )
            {
                ASPxGridView aSPxGridViewF = (ASPxGridView)sender;
                aSPxGridViewF.DataSource = GastosCF.Buscar(Convert.ToInt16(aSPxGridViewF.GetMasterRowKeyValue()),Mes,Ano);
                ViewState["act"] = "N";
                aSPxGridViewF.DataBind();
            }
         
         }

        protected void GridCFijas_BeforePerformDataSelect(object sender, EventArgs e)
        {
        }
      

        protected void GridCFijas_DetailRowExpandedChanged(object sender, ASPxGridViewDetailRowEventArgs e)
        {
            if (e.Expanded)
            {
                ViewState["act"] = "S";
                ViewState["actE"] = "S";
                ViewState["actV"] = "S";
         
            }
        }

        protected void btnBuscarNomina_Click(object sender, EventArgs e)
        {
            Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
            Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
            BuscarNomina(Mes, Ano);    
        }
        void BuscarNomina(int mes, int ano)
        {
            DataTable tabla = GastosResumen.Listar(mes,ano);
            GridCFijas.DataSource = tabla;
            GridCFijas.DataBind(); 
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

        protected void ASPxGridViewFijos_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            ASPxGridView grid = (sender as ASPxGridView);
            cargarGastosFijos(ref grid, Convert.ToInt16(e.NewValues["IDPROPIEDAD"]), Mes, Ano);

        }

        protected void ASPxGridViewFijos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            InfoGastosCF infoGastoCF= new InfoGastosCF();
            infoGastoCF.IdPropiedad = Convert.ToInt16(e.NewValues["IDPROPIEDAD"]);
            infoGastoCF.Mes = int.Parse(e.NewValues["MES"].ToString());
            infoGastoCF.Ano = int.Parse(e.NewValues["ANO"].ToString());
            
            infoGastoCF.GCFMontoCancelado = Convert.ToDecimal(e.NewValues["GCFMONTOCANCELADO"]);
            Aurora.Clases.Negocio.GastosCF.Modificar(infoGastoCF);
            e.Cancel=true;
        }

        protected void ASPxGridViewFijos_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ASPxGridView grid =(sender as ASPxGridView);
            grid.Columns["RUT"].Visible = true;
            grid.Columns["ANO"].Visible = true;
            grid.Columns["MES"].Visible = true;
        }

        protected void ASPxGridViewFijos_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ASPxGridView grid = (sender as ASPxGridView);
            grid.Columns["RUT"].Visible = false;
            grid.Columns["ANO"].Visible = false;
            grid.Columns["MES"].Visible = false;                     
        }
        void cargarGastosFijos(ref ASPxGridView grilla,  int idPropiedad,int mes, int ano)
        {
            grilla.DataSource = GastosCF.Buscar(idPropiedad, mes, ano);
            grilla.DataBind();
        }
    }
}
