using System;
using System.Collections.Generic;
using System.Text;


namespace Aurora.Web.UI
{
    public  class Base: System.Web.UI.Page
    {
        protected string FormatoCompleto = "0,0.00";
        protected string FormatoCompleto6 = "0,0.000000";
        protected string FormatoCompletoNeg = "0,0.00;(0,0.00)";
        protected string FormatoCompletoNeg6 = "0,0.000000;(0,0.000000)";

        protected string FormatoSimple = "0.00";
        protected string FormatoSimple6 = "0.000000";
        protected string FormatoSimpleNeg = "0.00;(0.00)";
        protected string FormatoSimpleNeg6 = "0.000000;(0.000000)";
        protected string FormatoSimpleMiles = "0,00";
        protected string PathRelativo = string.Empty;
        protected QueryString QString; 
        protected virtual void Page_Load(object sender, EventArgs e)
        {
           
            //PathRelativo = Application["PATHRELATIVO"].ToString();
            Response.Expires = -15;
            Response.ExpiresAbsolute = DateTime.Now.AddMinutes(-15);
            Response.AddHeader("pragma", "no-cache");
            Response.AddHeader("cache-control", "private");
            Response.CacheControl = "private";
            
        }
     }
}
