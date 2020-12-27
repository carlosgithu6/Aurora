using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Base;
using Aurora.Clases.Entidad;

namespace Aurora.Web.UI
{
   public  class Autenticada: Base
    {

       //InfoUsuario _objUsuario;
       /// <summary>
       /// Obtiene la querystring Encriptada.
       /// </summary>
        protected string QScrypt;
        
        
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (Session == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Session.Abandon();
                Response.Redirect("~/Default.aspx");
            }
            if (Usuario == null)
            {
                Session.Abandon();
                Response.Redirect("~/Default.aspx");
            }
            ValidaAcceso();         
        }
     
       private void ValidaAcceso()
       {
           BasadaEnRolesAttribute basadaRoles = (BasadaEnRolesAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(BasadaEnRolesAttribute), true);
           PerfilAttribute perfilPagina = (PerfilAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(PerfilAttribute), true);
           if (basadaRoles == null || perfilPagina == null)
               throw new Exception("Los atributos de la clase no se han definido en esta página.");
           if (!String.IsNullOrEmpty(this.Request.Url.Query))
           {
               string page = this.Request.Url.AbsoluteUri.Substring(0, this.Request.Url.AbsoluteUri.IndexOf("?"));
               QScrypt = Request.Url.Query.Remove(0, 1);
               try
               {
                   this.QString = new QueryString(QScrypt, true);
               }
               catch (Exception)
               {
                   Session.Abandon();
                   Response.Redirect("~/Default.aspx");
               }
           }
           int count = 0;
           foreach (Perfil perfil in perfilPagina.Value)
           {
               if (((GenericPrincipal)HttpContext.Current.User).IsInRole(((int)perfil).ToString()))
               {
                   count++;     
               }
           }

           if (basadaRoles.Value && count == 0)
           {
               throw new Exception("No tiene permiso para consultar la página");
           }
        
      }

       public InfoUsuario Usuario
       {
           get
           {
               if (HttpContext.Current.User.Identity.IsAuthenticated && Session["USUARIO"]!=null)
                   return (InfoUsuario)Session["USUARIO"];
               Session.Abandon();
               return null;
           }
           set
           {
               Session["USUARIO"] = value; 
           }
       }
   }
}
