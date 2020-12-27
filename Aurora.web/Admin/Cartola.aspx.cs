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
using DevExpress.Web.ASPxGridView;
using Aurora.Clases.Base;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base.Encriptacion;
using Aurora.Web.UI;
namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador, Perfil.Usuario })]
    public partial class Cartola : Autenticada
    {
        protected override  void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            try
            {
            
                    //decimal total = 0;
                    lblExcepcion.Visible = false;
                    InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"]));
                    //lblano1.Text = QString["ANO"];
                    //lblMes1.Text = ((Mes)Convert.ToInt16(QString["MES"])).ToString();
                    lblParcela.Text = prop.NombrePropiedad;
                    lblPropietario.Text = prop.NombreCompleto;
                    lblRut.Text = prop.Rut;
                    lblSocio.Text = prop.EsSocio ? "SI" : "NO";
                    lblSaldoFavor.Text = "$ "+ prop.SaldoCuentaCte.ToString("0,0.00");
                    DataTable resultado= Aurora.Clases.Negocio.Propietario.Cartola(Convert.ToInt16(Convert.ToInt16(QString["IDPROPIEDAD"])));
                    gridVar.DataSource = resultado;
                    gridVar.DataBind();
                   
                    //gridEsp.DataSource = resultado.Tables[1];
                    //gridEsp.DataBind();
                    //tblEsp.Visible = ((DataTable)gridEsp.DataSource).Rows.Count > 0;
                    //btnExportE.Visible = tblEsp.Visible;
                    
                    decimal total,pendiente,variable,fijo, especial = 0;
                    
                    pendiente=prop.DeudaPendiente;
                    variable =  Aurora.Clases.Negocio.Propietario.DeudaCuentasVariables(Convert.ToInt16(QString["IDPROPIEDAD"]));
                    fijo =  Aurora.Clases.Negocio.Propietario.DeudaCuentasFijas(Convert.ToInt16(QString["IDPROPIEDAD"]));
                    //especial = Convert.ToDecimal(resultado.Tables[2].Rows[0].ItemArray[0]);
                   
                    lblDeudaInicial.Text = "$ " + pendiente.ToString("0,0.00");
                    lblDeudaCF.Text = "$ " + fijo.ToString("0,0.00");
                    lblDeudaCV.Text = "$ " + variable.ToString("0,0.00");
                    //lblCE.Text = "$ " + especial.ToString("0,0.00");

                    total = pendiente + variable + fijo + especial;
                    lbltotal.Text = total.ToString("0,0.00");
                        
            }
          
            catch (Exception ex)
            {
                lblExcepcion.Text = ex.Message;
                lblExcepcion.Visible = true;
            }
        }

        protected void gridVar_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableDataCellEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            decimal monto = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "COSTO")is DBNull?0:grid.GetRowValues(e.VisibleIndex, "COSTO"));
            decimal montoCancelado = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GVMONTOCANCELADO"));
            int mes = Convert.ToInt16(grid.GetRowValues(e.VisibleIndex, "MES"));
            int ano = Convert.ToInt16(grid.GetRowValues(e.VisibleIndex, "ANO"));
            InfoNomina nom = Aurora.Clases.Negocio.Nomina.BuscarNomina(mes, ano);
            //bool YaEstaCerrada = false;
            //if (nom!= null) YaEstaCerrada = (nom.FechaCierre != Convert.ToDateTime("01-01-1900"));
            if ((monto - montoCancelado) > 0)
            {
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }
            if (monto < 0)
            {
                e.Cell.ForeColor = System.Drawing.Color.Red;
                e.Cell.Font.Strikeout = true;
            }
          }

        protected void gridEsp_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            decimal cuota = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCECUOTA"));
            decimal montoCancelado = Convert.ToDecimal(grid.GetRowValues(e.VisibleIndex, "GCEMONTO"));
           //bool YaEstaCerrada = (Nomina.BuscarNomina(DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year).FechaCierre != Convert.ToDateTime("01-01-1900"));
            if (cuota - montoCancelado > 0)
            {
                e.Cell.ForeColor = System.Drawing.Color.Red;
            }
          
        }

        protected void btnExportVyF_Click(object sender, EventArgs e)
        {
            gridExporterFyV.WriteXlsToResponse("CartolaVyF" + Convert.ToInt16(QString["IDPROPIEDAD"]), true);  
        }

        protected void btnExportE_Click(object sender, EventArgs e)
        {
            gridExporterE.WriteXlsToResponse("CartolaE" + Convert.ToInt16(QString["IDPROPIEDAD"]), true);  

        }

        

       
    }
}
