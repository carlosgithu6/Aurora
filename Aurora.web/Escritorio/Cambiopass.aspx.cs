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
using Aurora.Clases.Base.Encriptacion;
using Aurora.Clases.Base.Enums;
using Aurora.Web.UI;
using Aurora.Clases.Base;

using Aurora.Clases.Entidad;


namespace Aurora.Web.Escritorio
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador })]
    public partial class Cambiopass : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
           
        }

        protected void ChangePassword1_ChangingPassword(object sender, LoginCancelEventArgs e)
        {
            try
            {
                string _strPassword = string.Empty;
                _strPassword = MiRijndael.Desencriptar(Convert.FromBase64String(Usuario.Password));
                if (this.ChangePassword1.CurrentPassword == _strPassword)
                {
                    Usuario.Password = Convert.ToBase64String(MiRijndael.Encriptar(ChangePassword1.NewPassword));
                    Aurora.Clases.Negocio.Usuario.Modificar(Usuario,true);
                    ChangePassword1.Visible = false;
                    lblmensajepass.Text = "¡Su contraseña fue cambiada con éxito!";

                }
                else
                {
                    lblmensajepass.Text = "Contraseña incorrecta";
                }
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ChangePassword1_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Escritorio/Administracion.aspx");
        }
    }
}
