using System;
using System.Collections.Generic;
using System.Text;

namespace Aurora.Web.UI
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BasadaEnRolesAttribute:System.Attribute 
    {
        private bool _blnBasadaRoles = false;

		public BasadaEnRolesAttribute(bool blnEsBasadaRoles)
		{
			_blnBasadaRoles = blnEsBasadaRoles;
		}

		public bool Value
		{
			get { return this._blnBasadaRoles; }
		}
    }
}
