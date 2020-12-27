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
using System.Collections.Generic;


namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador })]
    public partial class AdminCambioMedidores :Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
            if (!IsPostBack)
            {
                GridMedidores.SettingsText.Title = "CAMBIOS DE MEDIDORES DE: " + Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"])).NombreCompleto;
                GridViewDataComboBoxColumn combo = GridMedidores.Columns["CTVCODIGO"] as GridViewDataComboBoxColumn;
                List<InfoCuentaVariable> lista = Aurora.Clases.Negocio.CuentaVariable.Lista(false);
                foreach (InfoCuentaVariable item in lista)
                {
                    combo.PropertiesComboBox.Items.Add(item.CtvDescripcion, item.CtvCodigo);
                }
            }
            CargarGrilla();            
        }
        void CargarGrilla()
        {
            GridMedidores.DataSource = Aurora.Clases.Negocio.CambioMedidor.Listar(Convert.ToInt16(QString["IDPROPIEDAD"]));
            GridMedidores.DataBind();
        }

        protected void GridMedidores_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void GridMedidores_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            InfoCambioMedidor cambMed = new InfoCambioMedidor();
            cambMed.IdPropiedad = Convert.ToInt16(QString["IDPROPIEDAD"]);
            cambMed.CodigoCV = Convert.ToInt16(e.NewValues["CTVCODIGO"]);
            cambMed.CMfechaCambio = Convert.ToDateTime(e.NewValues["CMFECHACAMBIO"]);
            cambMed.CMLectura = Convert.ToDecimal(e.NewValues["CMLECTURA"]);
            if (e.NewValues["CMMOTIVO"] != null)
            {
                cambMed.CMMotivo = Adicional.Verificar_Valor(e.NewValues["CMMOTIVO"].ToString(), 50, false);
            }
            else
                cambMed.CMMotivo = "";
            Aurora.Clases.Negocio.CambioMedidor.Crear(cambMed);
            e.Cancel = true;
        }

       protected void GridMedidores_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "Borrar")
            {   
                InfoCambioMedidor cambMed = new InfoCambioMedidor();
                cambMed.IdPropiedad = Convert.ToInt16(GridMedidores.GetDataRow(e.VisibleIndex)["IDPROPIEDAD"]);
                cambMed.CodigoCV = Convert.ToInt16(GridMedidores.GetDataRow(e.VisibleIndex)["CTVCODIGO"]);
                cambMed.CMfechaCambio = Convert.ToDateTime(GridMedidores.GetDataRow(e.VisibleIndex)["CMFECHACAMBIO"]);
                cambMed.CMLectura = Convert.ToDecimal(GridMedidores.GetDataRow(e.VisibleIndex)["CMLECTURA"]);
                cambMed.CMMotivo = GridMedidores.GetDataRow(e.VisibleIndex)["CMMOTIVO"].ToString();
                Aurora.Clases.Negocio.CambioMedidor.Eliminar(cambMed);
                CargarGrilla();
            }
        }

        //protected void GridMedidores_RowDeleting1(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        //{
        //    //InfoCambioMedidor cambMed = new InfoCambioMedidor();
        //    //cambMed.IdPropiedad = Convert.ToInt16(QString["IDPROPIEDAD"]);
        //    //cambMed.CodigoCV = Convert.ToInt16(e.Values["CTVCODIGO"]);
        //    //cambMed.CMfechaCambio = Convert.ToDateTime(e.Values["CMFECHACAMBIO"]);
        //    //cambMed.CMLectura = Convert.ToDecimal(e.Values["CMLECTURA"]);
        //    //cambMed.CMMotivo = Adicional.Verificar_Valor(e.Values["CMMOTIVO"].ToString(), 50, false);
        //    //Aurora.Clases.Negocio.CambioMedidor.Eliminar(cambMed);
        //    //CargarGrilla();
        //    //e.Cancel = true;
        //}

        //protected void GridMedidores_RowDeleted1(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        //{

        //}

        //protected void GridMedidores_RowInserted1(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        //{

        //}

        //protected void GridMedidores_RowInserting1(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        //{
        //    InfoCambioMedidor cambMed = new InfoCambioMedidor();
        //    cambMed.IdPropiedad = Convert.ToInt16(QString["IDPROPIEDAD"]);
        //    cambMed.CodigoCV = Convert.ToInt16(e.NewValues["CTVCODIGO"]);
        //    cambMed.CMfechaCambio = DateTime.Now;
        //    cambMed.CMLectura = Convert.ToDecimal(e.NewValues["CMLECTURA"]);
        //    if (e.NewValues["CMMOTIVO"] != null)
        //    {
        //        cambMed.CMMotivo = Adicional.Verificar_Valor(e.NewValues["CMMOTIVO"].ToString(), 50, false);
        //    }
        //    else
        //        cambMed.CMMotivo = "";
        //    Aurora.Clases.Negocio.CambioMedidor.Crear(cambMed);
        //    e.Cancel = true;
        //}
   }
}
