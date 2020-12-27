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
    public partial class AdminUsuarios : Autenticada
    {
        protected override  void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            GridGrupos.DataSource = Aurora.Clases.Negocio.Usuario.ListarTodos();
            GridGrupos.DataBind();
        }

        protected void GridGrupos_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs e)
        {
            
        }

        protected void GridGrupos_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {

        }

        protected void GridGrupos_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Aurora.Clases.Negocio.Usuario.Eliminar(e.Values["RUT"].ToString());
            GridGrupos.DataSource = Aurora.Clases.Negocio.Usuario.ListarTodos();
            GridGrupos.DataBind();
            e.Cancel = true;
        }

        protected void GridGrupos_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {

        }

        protected void GridGrupos_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string rut = e.NewValues["RUT"].ToString().Replace(".", "").Replace(",", "");
            InfoUsuario infoUsuario = new InfoUsuario();

            if (Adicional.ValidaRut(rut))
            {

                infoUsuario.Rut = rut;
                infoUsuario.Nombres = Adicional.Verificar_Valor(e.NewValues["NOMBRES"].ToString(), 100, false);
                infoUsuario.ApePaterno = Adicional.Verificar_Valor(e.NewValues["APPATERNO"].ToString(), 100, false);
                infoUsuario.ApeMaterno = Adicional.Verificar_Valor(e.NewValues["APMATERNO"].ToString(), 100, false);
                infoUsuario.Perfil = (Perfil)e.NewValues["IDPERFIL"];
                infoUsuario.Direccion = Adicional.Verificar_Valor(e.NewValues["DIRECCION"].ToString(), 250, false);
                infoUsuario.Telefono = Adicional.Verificar_Valor(e.NewValues["TELEFONO"].ToString(), 25, false);
                infoUsuario.Password = Convert.ToBase64String(MiRijndael.Encriptar(rut.Substring(0, 4)));
                if (e.NewValues["EMAIL"] != null)
                {
                    infoUsuario.Email = Adicional.Verificar_Valor(e.NewValues["EMAIL"].ToString(), 100, false);
                }
                else infoUsuario.Email = "-";

                infoUsuario.FechaCreacion = DateTime.Now;
                infoUsuario.FechaActualizacion = DateTime.Now;
                Aurora.Clases.Negocio.Usuario.Crear(infoUsuario);
             }
            else
            {
                throw new Exception("Rut Inválido");
            }
            e.Cancel = true;     
        }

        protected void GridGrupos_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

        }

        protected void GridGrupos_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string rut = Session["EDITRUT"].ToString();
            

            InfoUsuario infoUsuario = new InfoUsuario();

            if (Adicional.ValidaRut(rut))
            {

                infoUsuario.Rut = rut;
                infoUsuario.Nombres = Adicional.Verificar_Valor(e.NewValues["NOMBRES"].ToString(), 100, false);
                infoUsuario.ApePaterno = Adicional.Verificar_Valor(e.NewValues["APPATERNO"].ToString(), 100, false);
                infoUsuario.ApeMaterno = Adicional.Verificar_Valor(e.NewValues["APMATERNO"].ToString(), 100, false);
                infoUsuario.Perfil = (Perfil)e.NewValues["IDPERFIL"];
                infoUsuario.Direccion = Adicional.Verificar_Valor(e.NewValues["DIRECCION"].ToString(), 250, false);
                infoUsuario.Telefono = Adicional.Verificar_Valor(e.NewValues["TELEFONO"].ToString(), 250, false);
                if (e.NewValues["EMAIL"] != null)
                {
                    infoUsuario.Email = Adicional.Verificar_Valor(e.NewValues["EMAIL"].ToString(), 100, false);
                }
                else infoUsuario.Email = "-";

                infoUsuario.FechaActualizacion = DateTime.Now;
                Aurora.Clases.Negocio.Usuario.Modificar(infoUsuario,false);
            }
            else
            {
              
                throw new Exception("Rut Inválido");
            }
           
            e.Cancel = true;     
        }

        protected void GridGrupos_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Add("EDITRUT",e.EditingKeyValue.ToString());
            GridGrupos.Columns["RUT"].Visible = false;
        }

        protected void GridGrupos_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Remove("EDITRUT");
            GridGrupos.Columns["RUT"].Visible = true;
        }
        
    }
}
