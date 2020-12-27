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
    public partial class AdminUF :Autenticada
    {
      
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            CargarUFs();
        }
        private void CargarUFs()
        {
            GridUF.DataSource = Aurora.Clases.Negocio.UF.Listar();
            GridUF.DataBind();  
        }
        protected void GridUF_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            int mes = Convert.ToInt16(e.Values["MES"]);
            int ano = Convert.ToInt16(e.Values["ANO"]);
            Aurora.Clases.Negocio.UF.Eliminar(mes, ano);
            CargarUFs();
            e.Cancel = true;
        }

        protected void GridUF_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
           
          
        }

        protected void GridUF_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
         
            
        }

        protected void GridUF_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            int mes = Convert.ToInt16(e.NewValues["MES"]);
            int ano = Convert.ToInt16(e.NewValues["ANO"]);
            decimal valor = Convert.ToDecimal(e.NewValues["UF"]);
            InfoUF uf =  new InfoUF();
            uf.Mes =  mes;
            uf.Ano = ano;
            uf.UF = valor;
            Aurora.Clases.Negocio.UF.Crear(uf);
            e.Cancel = true;
        }

        protected void GridUF_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
       
        }

        protected void GridUF_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int mes = Convert.ToInt16(e.NewValues["MES"]);
            int ano = Convert.ToInt16(e.NewValues["ANO"]);
            decimal valor = Convert.ToDecimal(e.NewValues["UF"]);
            InfoUF uf = new InfoUF();
            uf.Mes = mes;
            uf.Ano = ano;
            uf.UF = valor;
            Aurora.Clases.Negocio.UF.Modificar(uf);
            e.Cancel = true;
        }

        protected void GridUF_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs e)
        {
            if (e.CommandCellType == DevExpress.Web.ASPxGridView.GridViewTableCommandCellType.Data)
            {
                if (!(Convert.ToInt16(GridUF.GetDataRow(e.VisibleIndex)["ANO"]) == DateTime.Now.Year && Convert.ToInt16(GridUF.GetDataRow(e.VisibleIndex)["MES"]) == DateTime.Now.Month))
                {
                    if (e.Cell.Controls.Count > 0)
                    {
                        e.Cell.Controls[0].Visible = false;  // oculto el boton de editar.     
                        e.Cell.Controls[2].Visible = false; // oculto el boton de eliminar.     
                    }
                }

            }
        }

        
    }
}
