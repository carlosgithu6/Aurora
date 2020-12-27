using System;
using System.Collections.Generic;
using System.Text;
using Aurora.Clases.Base.Enums;
namespace Aurora.Web.UI
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PerfilAttribute : System.Attribute
    {
        Perfil [] perfil ;
        public PerfilAttribute(Perfil[] perfil)
        {
            this.perfil = perfil;
        }

        public Perfil[] Value
        {
            get { return this.perfil; }
        }
    }
}
