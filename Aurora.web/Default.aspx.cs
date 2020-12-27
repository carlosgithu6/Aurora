using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Base.Encriptacion;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base;
using Aurora.Web.UI;
namespace Aurora.Web
{
    [BasadaEnRoles(false)]
    public partial class _Default : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
               Login Login1 = (sender as Login);
                /*Validar RUT en cuanto a formato*/
                string _strRut;
                string _strPassword;
                _strRut = Login1.UserName.Replace(".", "").Replace(",", "");
                _strPassword = Convert.ToBase64String(MiRijndael.Encriptar(this.Login1.Password));
                InfoUsuario _objUsuario;
                if (Adicional.ValidaRut(_strRut))
                {
                    Session["RUT"] = _strRut.Substring(0,_strRut.Length-2) ;
                    e.Authenticated = ((_objUsuario = Aurora.Clases.Negocio.Usuario.IngresoSistema(_strRut, _strPassword)) != null);
                    if (e.Authenticated)
                    {
                        //Uss.Cideu.Negocio.VisitaSitio.Crear(_objUsuario.IdUsuario, DateTime.Now.ToShortTimeString());
                        string Pagina = string.Empty;
                        switch (_objUsuario.Perfil )
                        {
                            
                            case Perfil.Administrador:
                                {
                                    this.Usuario = _objUsuario;
                                    Pagina = "Escritorio/Administracion.aspx";
                                    break;
                                }
                            default:
                                {
                                    this.Usuario = _objUsuario;
                                    Pagina = "Escritorio/Administracion.aspx";
                                    break;
                                }
                        }

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, this.Login1.UserName, DateTime.Now, DateTime.Now.AddMinutes(60), false, ((int)_objUsuario.Perfil).ToString());
                        string ticketCrypt = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketCrypt);
                        Response.Cookies.Clear();
                        Response.Cookies.Add(authCookie);
                        Response.Redirect(Pagina);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();

                    }
                    else
                    {
                        this.Login1.FailureText = "Error de Autenticación.";
                    }
                }
                else
                {
                    this.Login1.FailureText = "Rut Incorrecto.";
                }
            }
        
    }
}
