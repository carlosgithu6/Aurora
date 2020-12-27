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
using DevExpress.Web.ASPxGridView;
//using DevExpress.Export;

using System.Collections.Generic;
using Aurora.Clases.Negocio;


namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] {Perfil.Administrador,Perfil.Usuario})]
    public partial class CuentaCorriente : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                AppSettingsReader appSettReader = new AppSettingsReader();
                int anobase = Convert.ToInt16(appSettReader.GetValue("ano1", typeof(int)));
                UI.Utiles.LlenarCombox(ref lstAnos, UI.Utiles.Anos(anobase));
                GridViewDataComboBoxColumn combo = ASPxGridVar.Columns["CTVCODIGO"] as GridViewDataComboBoxColumn;
                combo.PropertiesComboBox.ValueType = typeof(int);
                List<InfoCuentaVariable> lista = Aurora.Clases.Negocio.CuentaVariable.Lista(false);
                
                foreach (InfoCuentaVariable item in lista)
                {
                    combo.PropertiesComboBox.Items.Add(item.CtvDescripcion, item.CtvCodigo);
                }
                //------

                GridViewDataComboBoxColumn combo2 = ASPxGridViewFijos.Columns["CFCODIGO"] as GridViewDataComboBoxColumn;
                combo2.PropertiesComboBox.ValueType = typeof(int);
                List<InfoCuentaFija> lista2 = Aurora.Clases.Negocio.CuentaFija.Lista(false);

                foreach (InfoCuentaFija item in lista2)
                {
                    combo2.PropertiesComboBox.Items.Add(item.Descripcion, item.Codigo);
                }  
            }
            if (IsCallback)
            {
                System.Threading.Thread.Sleep(500);
            }
            if(Mes!=0 || Ano!=0)
              BuscarNomina(Mes, Ano);
            CargarDatosGenerales();
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
       
        private int IdPropiedad
        {
            get {
                return ViewState["IDPROPIEDAD"] == null ? -1 : Convert.ToInt16(ViewState["IDPROPIEDAD"]);
            }
            set { ViewState["IDPROPIEDAD"] = value; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin/AdminPropietarios.aspx");
        }

        protected void btnBuscarNomina_Click(object sender, EventArgs e)
        {
            try
            {
                Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
                Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
                IdPropiedad = Convert.ToInt16(QString["IDPROPIEDAD"]);
                BuscarNomina(Mes, Ano);
            }
            catch (Exception ee)
            {
                lblMensaje.Visible = true;

                lblMensaje.Text = ee.Message;
            }
        }
        void BuscarNomina(int mes, int ano)
        {
            lblMensaje.Visible = false;
            CargarDatosGenerales();
            CargarGastosFijos();
            CargarGastosVariables();
            CargarGastosEspeciales();
        }
        void CargarDatosGenerales()
        {
            InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"]));
            lblFecha.Text = Mes.ToString() + "/" + Ano.ToString();
            lblRut.Text = prop.Rut;
            lblSocio.Text = (prop.EsSocio) ? "Si" : "No";
            lblPropiedad.Text = prop.Sector + "/" + prop.LetraParcela + "/" + prop.NumeroParcela;
            lblNombre.Text = prop.NombreCompleto;
            ASPxRoundPanel2.Visible = true;           
        }
        void CargarGastosFijos()
        {
            ASPxGridViewFijos.DataSource = GastosCF.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano);
            ASPxGridViewFijos.DataBind();
            ASPxGridViewFijos.Visible = ((DataTable)ASPxGridViewFijos.DataSource).Rows.Count > 0;
        }
        void CargarGastosVariables()
        {
            try
            {
                ASPxGridVar.DataSource = GastosCV.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano,-1);
                ASPxGridVar.DataBind();
                ASPxGridVar.Visible = ((DataTable)ASPxGridVar.DataSource).Rows.Count > 0;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.Visible = true;
            }
        }
        void CargarGastosEspeciales()
        {
            try
            {
                ASPxGridViewCEspeciales.DataSource = GastosCE.Listar(Convert.ToInt16(QString["IDPROPIEDAD"]));
                ASPxGridViewCEspeciales.DataBind();
                ASPxGridViewCEspeciales.Visible = ((DataTable)ASPxGridViewCEspeciales.DataSource).Rows.Count > 0; 
               
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.Visible = true;
            }
        }
        protected void ASPxGridViewFijos_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ASPxGridView grid = (sender as ASPxGridView);
            grid.Columns["IDPROPIEDAD"].Visible = false;
            grid.Columns["ANO"].Visible = false;
            grid.Columns["MES"].Visible = false;
            grid.Columns["DESCONTAR"].Visible = false;
            grid.Columns["FORMAPAGO"].Visible = false;
        }

        protected void ASPxGridViewFijos_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ASPxGridView grid = (sender as ASPxGridView);
            grid.Columns["IDPROPIEDAD"].Visible = true;
            grid.Columns["ANO"].Visible = true;
            grid.Columns["MES"].Visible = true;
            grid.Columns["DESCONTAR CTE"].Visible = true;
            grid.Columns["FORMAPAGO"].Visible = true;
        }

        protected void ASPxGridViewFijos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            InfoGastosCF infoGastoCF = new InfoGastosCF();
            infoGastoCF.IdPropiedad =Convert.ToInt16(e.NewValues["IDPROPIEDAD"]);
            infoGastoCF.Mes = int.Parse(e.NewValues["MES"].ToString());
            infoGastoCF.Ano = int.Parse(e.NewValues["ANO"].ToString());
            infoGastoCF.CFCodigo = int.Parse(e.NewValues["CFCODIGO"].ToString());
            infoGastoCF.GCFMonto = Convert.ToDecimal(e.NewValues["GCFMONTO"]);
            infoGastoCF.GCFMontoCancelado = Convert.ToDecimal(e.NewValues["GCFMONTOCANCELADO"]);
            infoGastoCF.FechaPago = (e.NewValues["FECHAPAGO"]==null)? DateTime.Now : Convert.ToDateTime(e.NewValues["FECHAPAGO"]);
            infoGastoCF.FormadePago = (FormaPago)e.NewValues["FORMAPAGO"];
            infoGastoCF.DescontarCte = Convert.ToBoolean(e.NewValues["DESCONTAR"]);
            infoGastoCF.FechaCheque = (Session["FECHACHEQUE"] == null) ? DateTime.MinValue : Convert.ToDateTime(Session["FECHACHEQUE"]);
            Aurora.Clases.Negocio.GastosCF.Modificar(infoGastoCF);
            e.Cancel = true;
        }

        protected void ASPxGridViewFijos_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void ASPxGridViewFijos_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
          
        }

        protected void ASPxGridViewFijos_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            decimal monto = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCFMONTO"));
            decimal montoCancelado = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCFMONTOCANCELADO"));
           
            if ((monto - montoCancelado) > 0)
            {
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }               
        }

        protected void ASPxGridViewFijos_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            decimal monto = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCFMONTO"));
            decimal montoCancelado = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCFMONTOCANCELADO"));
           
            try
            {
               // bool YaEstaCerrada = (Nomina.BuscarNomina(DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year).FechaCierre != Convert.ToDateTime("01-01-1900"));
                bool YaEstaCerrada = (Nomina.BuscarNomina(Mes, Ano).FechaCierre != Convert.ToDateTime("01-01-1900"));
                if (monto == montoCancelado)// || YaEstaCerrada)
                {
                    e.Cell.Controls[0].Visible = false;
                }
               
            }
            catch (Exception)
            {
                lblMensaje.Text = "Debe generar primero la nómina";
                lblMensaje.Visible = true;
            }
        }

        protected void GridVariables_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
    
        }



        protected void ASPxGridVar_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            InfoGastosCV infoGasto = new InfoGastosCV();
            
            infoGasto.IdPropiedad = Convert.ToInt16(e.NewValues["IDPROPIEDAD"]);
            infoGasto.Mes = int.Parse(e.NewValues["MES"].ToString());
            infoGasto.Ano = int.Parse(e.NewValues["ANO"].ToString());
            infoGasto.CTVCodigo = int.Parse(e.NewValues["CTVCODIGO"].ToString());
            infoGasto.GVLecturaActual = Convert.ToDecimal(e.OldValues["GVCLECTURACATUAL"]);
            infoGasto.GVLecturaAnterior = Convert.ToDecimal(e.OldValues["GVLECTURAANTERIOR"]);
            infoGasto.GVMontoFijo = Convert.ToDecimal(e.NewValues["MONTOFIJO"]);
            infoGasto.GVMontoCancelado=Convert.ToDecimal(e.NewValues["GVMONTOCANCELADO"]);
            infoGasto.FormadePago = (FormaPago)e.NewValues["FORMAPAGO"];
            infoGasto.FechaPago =  (e.NewValues["FECHAPAGO"] == null) ? DateTime.Now : Convert.ToDateTime(e.NewValues["FECHAPAGO"]);
            infoGasto.DescontarCte = Convert.ToBoolean(e.NewValues["DESCONTAR"]);
            infoGasto.GVFechaVto = Convert.ToDateTime(e.NewValues["GVFECHAVTO"]);
            infoGasto.LecturaCM = Convert.ToDecimal(e.NewValues["LECTURACM"]);
            InfoNomina nomina = Aurora.Clases.Negocio.Nomina.BuscarNomina(infoGasto.Mes, infoGasto.Ano);
            infoGasto.setCostoTotal(Convert.ToDecimal(e.NewValues["COSTO"]),nomina.id);
            infoGasto.FechaCheque = (Session["FECHACHEQUE"] == null) ? DateTime.MinValue : Convert.ToDateTime(Session["FECHACHEQUE"]);
            Aurora.Clases.Negocio.GastosCV.Pagar(infoGasto);
            e.Cancel = true;
        }

        protected void ASPxGridVar_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void ASPxGridVar_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ASPxGridView grid = (sender as ASPxGridView);
            grid.Columns["IDPROPIEDAD"].Visible = true;
            grid.Columns["ANO"].Visible = true;
            grid.Columns["MES"].Visible = true;
            grid.Columns["DESCONTAR"].Visible = true;
            grid.Columns["FORMAPAGO"].Visible = true;
        }

        protected void ASPxGridVar_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ASPxGridView grid = (sender as ASPxGridView);
            grid.Columns["IDPROPIEDAD"].Visible = false;
            grid.Columns["ANO"].Visible = false;
            grid.Columns["MES"].Visible = false;
            grid.Columns["DESCONTAR"].Visible = false;
            grid.Columns["FORMAPAGO"].Visible = false;
        }

        protected void ASPxGridVar_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            decimal monto = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "COSTO"));
            decimal montoCancelado = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GVMONTOCANCELADO"));
            //bool YaEstaCerrada = (Nomina.BuscarNomina(DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year).FechaCierre != Convert.ToDateTime("01-01-1900"));
            bool YaEstaCerrada = (Nomina.BuscarNomina(Mes, Ano).FechaCierre != Convert.ToDateTime("01-01-1900"));
            decimal lecturaactual = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GVCLECTURACATUAL"));
            int tipo = Convert.ToInt16(grid.GetRowValues(e.VisibleIndex, "CTVTIPO"));
            if (monto == montoCancelado)// || YaEstaCerrada)
            {
                e.Cell.Controls[0].Visible = false;
            }
            //if (lecturaactual == decimal.Zero && !YaEstaCerrada && ((TipoCuentaVariable)tipo != TipoCuentaVariable.RecuperacionGastos))
            //{
            //    e.Cell.Controls[0].Visible = false;
            //}
        }

        protected void ASPxGridVar_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            decimal monto = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "COSTO"));
            decimal montoCancelado = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GVMONTOCANCELADO"));
            decimal lecturaactual = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GVCLECTURACATUAL"));
            int tipo = Convert.ToInt16(grid.GetRowValues(e.VisibleIndex, "CTVTIPO"));
            if ((monto - montoCancelado) > 0 || (monto == 0 && montoCancelado == 0 && lecturaactual==0))
            {
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }
            //if (lecturaactual == decimal.Zero && ((TipoCuentaVariable)tipo != TipoCuentaVariable.RecuperacionGastos))
            //{
            //    e.Cell.Font.Strikeout = true;
            //}
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
                Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
                Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
                Dictionary<string, string> valores = new Dictionary<string, string>();
                valores.Add("IDPROPIEDAD", QString["IDPROPIEDAD"]);
                valores.Add("MES", Mes.ToString());
                valores.Add("ANO", Ano.ToString());
                QueryString qs = new QueryString(valores);
                Response.Redirect("EstadodeCuenta.aspx?" + qs.QSEncriptada);           
        }

        protected void ASPxGridViewCEspeciales_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ASPxGridView grid = (sender as ASPxGridView);
            grid.Columns["IDPROPIEDAD"].Visible = true;
            //grid.Columns["ANO"].Visible = true;
            //grid.Columns["MES"].Visible = true;
           // grid.Columns["SALDOCTE"].Visible = true;
            grid.Columns["DESCONTAR"].Visible = true;
            grid.Columns["CTECODIGO"].Visible = true;
            grid.Columns["LLAVE"].Visible = true; 
            
        }

        protected void ASPxGridViewCEspeciales_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            ASPxGridView grid = (sender as ASPxGridView);
            grid.Columns["IDPROPIEDAD"].Visible = false;
            //grid.Columns["ANO"].Visible = false;
            //grid.Columns["MES"].Visible = false;
           //grid.Columns["SALDOCTE"].Visible = false;
            grid.Columns["DESCONTAR"].Visible = false;
            grid.Columns["CTECODIGO"].Visible = false;
            grid.Columns["LLAVE"].Visible = false;
        }

        protected void ASPxGridViewCEspeciales_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void ASPxGridViewCEspeciales_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            InfoGastosCE infoGE = new InfoGastosCE();
            infoGE.IdPropiedad = Convert.ToInt16(e.NewValues["IDPROPIEDAD"]);
            infoGE.Mes = int.Parse(e.NewValues["MES"].ToString());
            infoGE.Ano = int.Parse(e.NewValues["ANO"].ToString());
            infoGE.CteCodigo = int.Parse(e.NewValues["CTECODIGO"].ToString());
            infoGE.GCEMontoCuota = Convert.ToDecimal(e.NewValues["GCECUOTA"]);
            infoGE.GCEMontoCancelado = Convert.ToDecimal(e.NewValues["GCEMONTO"]);
            infoGE.FormadePago = (FormaPago)e.NewValues["FORMAPAGO"];
            infoGE.FechaPago = DateTime.Now;
            infoGE.DescontarCte = Convert.ToBoolean(e.NewValues["DESCONTAR"]);
            Aurora.Clases.Negocio.GastosCE.Pagar(infoGE);
            e.Cancel = true;
        }

        protected void ASPxGridViewCEspeciales_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            decimal cuota = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCECUOTA"));
            decimal montoCancelado = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCEMONTO"));
           // bool YaEstaCerrada = (Nomina.BuscarNomina(DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year).FechaCierre != Convert.ToDateTime("01-01-1900"));
            bool YaEstaCerrada = (Nomina.BuscarNomina(Mes, Ano).FechaCierre != DateTime.MinValue);
            if (cuota == montoCancelado )//|| YaEstaCerrada)
            {
                  e.Cell.Controls[0].Visible = false;
            }
        }

        protected void ASPxGridViewCEspeciales_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            decimal couta = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCECUOTA"));
            decimal montoCancelado = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCEMONTO"));
            if ((couta - montoCancelado) > 0)
            {
                e.Cell.ForeColor = System.Drawing.Color.Red;
            } 
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ASPxPopupControl1.ShowOnPageLoad = false;
            Session.Add("FECHACHEQUE", ASPxDateEdit1.Value);
            MultipagoControl.ShowOnPageLoad = false;
        }

        protected void ASPxGridDetalle_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detail = (sender as ASPxGridView);
            int cod = (int)detail.GetMasterRowFieldValues("CFCODIGO");
            detail.DataSource = GastosCF.BuscarDetallePagos(IdPropiedad, Mes, Ano,cod);
        }

        protected void ASPxGridDetalle_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Aurora.Clases.Negocio.GastosCF.EliminarDetalle(int.Parse(e.Values["NUMMOV"].ToString()));
            if ((FormaPago)e.Values["FORMAPAGO"] == FormaPago.DesdeCCte)
            {
                InfoPropietario prop= new InfoPropietario();
                prop.IdPropiedad = IdPropiedad;
                Propietario.AbonarACuentaCorriente(prop, Convert.ToDecimal(e.Values["SUBMONTOCANCELADO"]), true);
            }
            e.Cancel = true;           
        }

        protected void ASPxGridDetalle_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }

      

        protected void ASPxGridDetalle2_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }

        protected void ASPxGridDetalle2_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
         Aurora.Clases.Negocio.GastosCV.EliminarDetalle(int.Parse(e.Values["NUMMOV"].ToString()));
            if ((FormaPago)e.Values["FORMAPAGO"] == FormaPago.DesdeCCte)
            {
                InfoPropietario prop= new InfoPropietario();
                prop.IdPropiedad = IdPropiedad;
                Propietario.AbonarACuentaCorriente(prop, Convert.ToDecimal(e.Values["SUBMONTOCANCELADO"]), true);
            }
            e.Cancel = true;           
        }
        
        protected void ASPxGridDetalle2_BeforePerformDataSelect(object sender, EventArgs e)
        {
            ASPxGridView detail = (sender as ASPxGridView);
            int cod = (int)detail.GetMasterRowFieldValues("CTVCODIGO");
            detail.DataSource = GastosCV.BuscarDetallePagos(IdPropiedad, Mes, Ano, cod);
        }

        protected void btnOpcionMultipago_Click(object sender, EventArgs e)
        {
            
            MultipagoControl.ShowOnPageLoad = true;
            btnBuscarNomina_Click(null, null);
            txtMontoApagar.Text = Convert.ToInt64(Aurora.Clases.Negocio.Propietario.getTotalCuentas(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano)).ToString();
            

        }

        //private decimal getTotalCuentas()
        //{
        //    Decimal total = 0;
        //    List<InfoGastosCF> listaCF = Aurora.Clases.Negocio.GastosCF.BuscarLista(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano);
        //    List<InfoGastosCV> listaCV = Aurora.Clases.Negocio.GastosCV.BuscarLista(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano);
        //    foreach (InfoGastosCF item in listaCF)
        //    {
        //        decimal uf = UF.Buscar(Mes, Ano).UF;
        //        decimal costo = Math.Round(item.GCFMonto * uf, 0);
        //        if (costo > item.GCFMontoCancelado)
        //        {
        //             total = total + costo-item.GCFMontoCancelado;
        //        }
        //    }
        //    foreach (InfoGastosCV item in listaCV)
        //    {
        //        if (!item.flag && item.CostoTotal > item.GVMontoCancelado) //no es un item que sea pasado
        //        {
        //           total = total + item.CostoTotal-item.GVMontoCancelado;
        //        }
        //    }
        //    return total;
        //}

        

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //distribucion del pago....
                decimal total = Aurora.Clases.Negocio.Propietario.getTotalCuentas(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano);
                List<InfoGastosCF> listaCF = Aurora.Clases.Negocio.GastosCF.BuscarLista(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano);
                List<InfoGastosCV> listaCV = Aurora.Clases.Negocio.GastosCV.BuscarLista(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano);

                decimal montoPagado = Convert.ToDecimal(txtMontoApagar.Text);
                lblError.Visible = false;
                lblResultado.Visible = false;
               
                if (Convert.ToInt64(montoPagado) <= Convert.ToInt64(total))
                {
                    Table tablaDatos = new Table();
                    tablaDatos.Width = new System.Web.UI.WebControls.Unit(90, System.Web.UI.WebControls.UnitType.Percentage);
                    tablaDatos.BorderWidth = 1;
                    tablaDatos.BorderColor = System.Drawing.Color.Coral;

                    TableRow header = new TableRow();
                    header.CssClass = "dxgvHeader_Office2003_Olive";

                    header.Cells.Add(new TableCell());
                    header.Cells.Add(new TableCell());
                    header.Cells.Add(new TableCell());
                    header.Cells.Add(new TableCell());
                    header.Cells.Add(new TableCell());
                    header.Cells[0].Text = "Cuenta";
                    header.Cells[1].Text = "Monto a Pagar";
                    header.Cells[2].Text = "% S/Total";
                    header.Cells[3].Text = "Distrib. Pago";
                    tablaDatos.Rows.Add(header);
                    foreach (InfoGastosCF item in listaCF)
                    {
                        decimal uf = UF.Buscar(Mes, Ano).UF;
                        decimal costo = Math.Round(item.GCFMonto * uf, 0);

                        if (costo > item.GCFMontoCancelado)
                        {
                            TableRow row = new TableRow();

                            TableCell nomCuenta = new TableCell();
                            nomCuenta.HorizontalAlign = HorizontalAlign.Left;
                            nomCuenta.Text = item.Descripcion ;
                            row.Cells.Add(nomCuenta);

                    
                            TableCell MontoCuenta = new TableCell();
                            MontoCuenta.HorizontalAlign = HorizontalAlign.Right;
                            MontoCuenta.Text = Convert.ToInt64((costo - item.GCFMontoCancelado)).ToString();
                            row.Cells.Add(MontoCuenta);

                            decimal porcentaje = ((costo - item.GCFMontoCancelado) / total);

                            TableCell Porcentaje = new TableCell();
                            Porcentaje.HorizontalAlign = HorizontalAlign.Right;
                            Porcentaje.Text =((100 * porcentaje)).ToString("0.0") + "%";
                            row.Cells.Add(Porcentaje);

                            TableCell MontoEquivalente = new TableCell();
                            MontoEquivalente.HorizontalAlign = HorizontalAlign.Right;
                            MontoEquivalente.Text = Convert.ToInt64((montoPagado * porcentaje)).ToString();
                            row.Cells.Add(MontoEquivalente);

                            tablaDatos.Controls.Add(row);
                        }
                    }
                    foreach (InfoGastosCV item in listaCV)
                    {
                        if (!item.flag && item.getCostoTotal() > item.GVMontoCancelado) //no es un item que sea pasado
                        {
                            TableRow row = new TableRow();

                            TableCell nomCuenta = new TableCell();
                            nomCuenta.HorizontalAlign = HorizontalAlign.Left;
                            nomCuenta.Text = Aurora.Clases.Negocio.CuentaVariable.Buscar(item.CTVCodigo).CtvDescripcion ;
                            row.Cells.Add(nomCuenta);


                            TableCell MontoCuenta = new TableCell();
                            MontoCuenta.HorizontalAlign = HorizontalAlign.Right;
                            decimal porcentaje;
                            MontoCuenta.Text = Convert.ToInt64((item.getCostoTotal() - item.GVMontoCancelado)).ToString();
                            porcentaje = (((item.getCostoTotal() - item.GVMontoCancelado) / total));
                            row.Cells.Add(MontoCuenta);

                           

                            TableCell Porcentaje = new TableCell();
                            Porcentaje.HorizontalAlign = HorizontalAlign.Right;
                            Porcentaje.Text =((100 * porcentaje)).ToString("0.0") + "%";
                            row.Cells.Add(Porcentaje);

                            TableCell MontoEquivalente = new TableCell();
                            MontoEquivalente.HorizontalAlign = HorizontalAlign.Right;
                            MontoEquivalente.Text = Convert.ToInt64((montoPagado * porcentaje)).ToString();
                            row.Cells.Add(MontoEquivalente);

                            tablaDatos.Controls.Add(row);
                        }
                    }

                    /*Totalizadores*/
                    TableRow rowT = new TableRow();

                    TableCell Total = new TableCell();
                    Total.Text = "TOTAL";
                    rowT.Cells.Add(Total);

                    TableCell TotalMontoCuenta = new TableCell();
                    TotalMontoCuenta.Text = Convert.ToInt64(total).ToString();
                    rowT.Cells.Add(TotalMontoCuenta);

                    tablaDatos.Controls.Add(rowT);
                    /*Fin Totalizadores*/
                    tablaDatos.Visible = true;
                    MultipagoControl.Controls.Add(tablaDatos);
                    cb_formaPago.Visible = true;
                    dt_fechaCheque.Visible = true;
                    lblFechaPago.Visible = true;
                    lblFormaPago.Visible = true;
                   
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "El monto que se quiere pagar supera el total";
                }
            }
            catch (Exception ee)
            {
                lblError.Visible = true;
                lblError.Text = ee.Message;
            }
        }

        protected void BtnConfirmarPago_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal total = Aurora.Clases.Negocio.Propietario.getTotalCuentas(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano);

                decimal montoPagado = Convert.ToDecimal(txtMontoApagar.Text);
               if (Convert.ToInt64(montoPagado) <= Convert.ToInt64(total))
                {
                    List<InfoGastosCF> listaCF = Aurora.Clases.Negocio.GastosCF.BuscarLista(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano);
                    List<InfoGastosCV> listaCV = Aurora.Clases.Negocio.GastosCV.BuscarLista(Convert.ToInt16(QString["IDPROPIEDAD"]), Mes, Ano);
                    
                    foreach (InfoGastosCF item in listaCF)
                    {
                        decimal uf = UF.Buscar(Mes, Ano).UF;
                        decimal costo = Math.Round(item.GCFMonto * uf, 0);
                        if (costo > item.GCFMontoCancelado)
                        {
                            item.GCFMontoCancelado =Convert.ToInt64(montoPagado * (costo - item.GCFMontoCancelado) / total);
                            item.GCFMonto = costo;
                            item.FormadePago = (FormaPago)(Convert.ToInt16(cb_formaPago.SelectedItem.Value));
                            item.FechaPago = Convert.ToDateTime(dt_fechaCheque.Value);
                            item.FechaCheque = item.FechaPago;
                            Aurora.Clases.Negocio.GastosCF.Modificar(item);
                        }
                    }
                    foreach (InfoGastosCV item in listaCV)
                    {
                         if (!item.flag && item.getCostoTotal() > item.GVMontoCancelado) //no es un item que sea pasado
                            {
                                decimal porcentaje = ((item.getCostoTotal() - item.GVMontoCancelado) / total);
                                item.GVMontoCancelado = Math.Round((montoPagado * porcentaje), 0);
                                item.FormadePago = (FormaPago)(Convert.ToInt16(cb_formaPago.SelectedItem.Value));
                                item.FechaPago = Convert.ToDateTime(dt_fechaCheque.Value);
                                item.FechaCheque = item.FechaPago;
                                Aurora.Clases.Negocio.GastosCV.Pagar(item);
                            }
                        
                       
                    }
                    lblResultado.Visible = true;
                    lblResultado.Text="El pago distribuido se realizó con éxito";
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "El monto que se quiere pagar supera el total";

                }
            }
            catch (Exception ee)
            {
                lblError.Visible = true;
                lblError.Text = ee.Message;
            }
        }

        protected void btnRecibo_Click(object sender, EventArgs e)
        {
            Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
            Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
            Dictionary<string, string> valores = new Dictionary<string, string>();
            valores.Add("IDPROPIEDAD", QString["IDPROPIEDAD"]);
            valores.Add("MES", Mes.ToString());
            valores.Add("ANO", Ano.ToString());
            QueryString qs = new QueryString(valores);
            Response.Redirect("ReciboDinero.aspx?" + qs.QSEncriptada);          
        }
        
        }


   }

