using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using System.Threading;
using System.Web.SessionState;

namespace Aurora.Web
{
    public class Global : System.Web.HttpApplication
    {
        public override void Init()
        {
            base.Init();
            this.PostAuthenticateRequest += new System.EventHandler(this.PostGlobal_AuthenticateRequest);
        }
        protected void Application_Start(object sender, EventArgs e)
        {
           
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        private void PostGlobal_AuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = Context.Request.Cookies[cookieName];
                if (authCookie == null)
                {
                    return;
                }
                FormsAuthenticationTicket authTicket = null;
                try
                {
                    authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
                if (authTicket == null)
                {
                    return;
                }
                GenericIdentity identidad = new GenericIdentity(authTicket.Name, "Forms");
                string[] roles = new string[1];
                roles[0] = authTicket.UserData;
                GenericPrincipal genericPrincipal = new GenericPrincipal(identidad, roles);
                System.Web.HttpContext.Current.User = genericPrincipal;
                Thread.CurrentPrincipal = genericPrincipal;
            }
            catch (Exception exc)
            {
                string mensaje = (exc.InnerException == null) ? exc.Message + "------II-----" + exc.StackTrace : exc.StackTrace + "-------" + exc.InnerException.StackTrace;
            }
        }
    }
}