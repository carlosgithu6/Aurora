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
    [Perfil(new Perfil[] { Perfil.Administrador,Perfil.Usuario })]
    public partial class AdminPropietarios : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            GridPropietarios.DataSource = Aurora.Clases.Negocio.Propietario.Listar(false,true);
            GridPropietarios.DataBind();
        }

        protected void GridPropietarios_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
           
        }

        protected void GridPropietarios_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Aurora.Clases.Negocio.Propietario.Eliminar(Convert.ToInt16(e.Values["IDPROPIEDAD"]));
            Page_Load(this, null);
            e.Cancel = true;
        }

        protected void GridPropietarios_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void GridPropietarios_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string rut = e.NewValues["RUT"].ToString().Replace(".", "").Replace(",", "");
            InfoPropietario infoPropietario = new InfoPropietario();

            if (Adicional.ValidaRut(rut))
            {
                infoPropietario.Rut = rut;
                infoPropietario.Nombres = Adicional.Verificar_Valor(e.NewValues["NOMBRES"].ToString(), 100, false);
                infoPropietario.Apellido1 = Adicional.Verificar_Valor(e.NewValues["APPATERNO"].ToString(), 100, false);
                infoPropietario.Apellido2 = Adicional.Verificar_Valor(e.NewValues["APMATERNO"].ToString(), 100, false);
                infoPropietario.EsSocio = Convert.ToBoolean(e.NewValues["SOCIO"]);
                if (infoPropietario.EsSocio)
                {
                    infoPropietario.FechaIngresoSocio = DateTime.Now;                  
                }
                else
                {
                    infoPropietario.FechaIngresoSocio = DateTime.MinValue;
                }
                infoPropietario.FechaSalidaSocio = DateTime.MinValue;
                infoPropietario.DireccionContacto = Adicional.Verificar_Valor(e.NewValues["DIRECCIONCONTACTO"].ToString(), 250, false);
                infoPropietario.Telefono = Adicional.Verificar_Valor(e.NewValues["TELEFONO"].ToString(), 25, false);
                infoPropietario.Sector = Adicional.Verificar_Valor(e.NewValues["SECTOR"].ToString(), 50, false);
                infoPropietario.LetraParcela = Adicional.Verificar_Valor(e.NewValues["LETRAPARCELA"].ToString(), 50, false);
                infoPropietario.NumeroParcela = Convert.ToInt16(e.NewValues["NUMEROPARCELA"]);
                infoPropietario.NumeroCasas = Convert.ToInt16(e.NewValues["NUMEROCASAS"]);

                if (e.NewValues["MAIL"] != null)
                {
                    infoPropietario.Mail = Adicional.Verificar_Valor(e.NewValues["MAIL"].ToString(), 100, false);
                }
                else infoPropietario.Mail = "-";

                infoPropietario.FechaCreacion = DateTime.Now;
                infoPropietario.FechaActualizacion = DateTime.Now;
                Aurora.Clases.Negocio.Propietario.Crear(infoPropietario);
            }
            else
            {
                throw new Exception("Rut Inválido");
            }
            Page_Load(this, null);
            e.Cancel = true; 
        }

        protected void GridPropietarios_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void GridPropietarios_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int propiedad = Convert.ToInt16(Session["EDITPROP"]);
            string rut = e.NewValues["RUT"].ToString().TrimStart().TrimEnd();
            InfoPropietario infoPropietario = new InfoPropietario();

            if (Adicional.ValidaRut(rut))
            {
                infoPropietario.IdPropiedad = propiedad;
                infoPropietario.Rut = rut;
                infoPropietario.Nombres = Adicional.Verificar_Valor(e.NewValues["NOMBRES"].ToString(), 100, false);
                infoPropietario.Apellido1 = Adicional.Verificar_Valor(e.NewValues["APPATERNO"].ToString(), 100, false);
                infoPropietario.Apellido2 = Adicional.Verificar_Valor(e.NewValues["APMATERNO"].ToString(), 100, false);
                bool auxEraSocio = Convert.ToBoolean(e.OldValues["SOCIO"]);
                infoPropietario.EsSocio = Convert.ToBoolean(e.NewValues["SOCIO"]);
                if (auxEraSocio && !infoPropietario.EsSocio)
                {
                    infoPropietario.FechaSalidaSocio = DateTime.Now;
                }
                if (!auxEraSocio && infoPropietario.EsSocio)
                {
                    infoPropietario.FechaIngresoSocio = DateTime.Now;
                }
                infoPropietario.DireccionContacto = Adicional.Verificar_Valor(e.NewValues["DIRECCIONCONTACTO"].ToString(), 250, false);
                infoPropietario.Telefono = Adicional.Verificar_Valor(e.NewValues["TELEFONO"].ToString(), 25, false);
                infoPropietario.Sector = Adicional.Verificar_Valor(e.NewValues["SECTOR"].ToString(), 50, false);
                infoPropietario.LetraParcela = Adicional.Verificar_Valor(e.NewValues["LETRAPARCELA"].ToString(), 50, false);
                infoPropietario.NumeroParcela = Convert.ToInt16(e.NewValues["NUMEROPARCELA"]);
                infoPropietario.NumeroCasas = Convert.ToInt16(e.NewValues["NUMEROCASAS"]);

                if (e.NewValues["MAIL"] != null)
                {
                    infoPropietario.Mail = Adicional.Verificar_Valor(e.NewValues["MAIL"].ToString(), 100, false);
                }
                else infoPropietario.Mail = "-";

                infoPropietario.FechaCreacion = DateTime.Now;
                infoPropietario.FechaActualizacion = DateTime.Now;
                infoPropietario.PropiedadActiva = Convert.ToBoolean(e.NewValues["ACTIVA"]);
                Aurora.Clases.Negocio.Propietario.Modificar(infoPropietario);
            }
            else
            {
                throw new Exception("Rut Inválido");
            }
            Page_Load(this, null);
            e.Cancel = true; 
        }

        protected void GridPropietarios_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            foreach (DevExpress.Web.ASPxGridView.GridViewColumn col in GridPropietarios.Columns)
            {
                col.Visible = true;
            }
            Session.Add("EDITPROP", e.EditingKeyValue.ToString());      
           
        }

        protected void GridPropietarios_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            foreach (DevExpress.Web.ASPxGridView.GridViewColumn col in GridPropietarios.Columns)
            {
                col.Visible = false;
            }
            Session.Remove("EDITPROP");
            GridPropietarios.Columns["RUT"].Visible = true;
            GridPropietarios.Columns["NOMBRES"].Visible = true;
            GridPropietarios.Columns["APPATERNO"].Visible = true;
            GridPropietarios.Columns["APMATERNO"].Visible = true;
            GridPropietarios.Columns["SOCIO"].Visible = true;
            GridPropietarios.Columns["TELEFONO"].Visible = true;
            GridPropietarios.Columns["OPCIONES"].Visible = true;
            GridPropietarios.Columns["OPCIONES"].VisibleIndex = 16;
          
        }

        protected void GridPropietarios_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            object f = GridPropietarios.GetRowValues(e.VisibleIndex, "IDPROPIEDAD");
            Dictionary<string,string> valores = new Dictionary<string,string>();
            valores.Add("IDPROPIEDAD", f.ToString());
            QueryString QS = new QueryString(valores);
            if (e.ButtonID == "CEspeciales")
            {
                Response.RedirectLocation = "CespPropietario.aspx?" + QS.QSEncriptada;
            }
            else if (e.ButtonID == "CCorriente")
            {
                Response.RedirectLocation = "CuentaCorriente.aspx?" + QS.QSEncriptada;
            }
            else if (e.ButtonID == "CFijas")
            {
                Response.RedirectLocation = "CuentasFijasPropietario.aspx?" + QS.QSEncriptada;
            }
            else if (e.ButtonID == "CVariables")
            {
                Response.RedirectLocation = "CuentasVarPropietario.aspx?" + QS.QSEncriptada;
            }
            else if (e.ButtonID == "Regenerar")
            {
               Aurora.Clases.Negocio.Propietario.RegenerarNominaActual((int)f);
            }
            else if (e.ButtonID == "Cartola")
            {
                Response.RedirectLocation = "Cartola.aspx?" + QS.QSEncriptada;
            }
        }

        protected void GridPropietarios_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            foreach (DevExpress.Web.ASPxGridView.GridViewColumn col in GridPropietarios.Columns)
            {
                col.Visible = true;
            }            
        }

        protected void btnXlsExport_Click(object sender, EventArgs e)
        {          
             gridExporter.WriteXlsToResponse("Propietarios", true);           
        }

   }
}
