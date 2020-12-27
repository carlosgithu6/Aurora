using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Aurora.Clases.Datos
{
    [Serializable]
    internal abstract class BaseDatos
    {
        static string cn = string.Empty;
        protected static string StringConexion()
        {
            if (String.IsNullOrEmpty(cn))
            {
                return ObtenerString();
            }
            else return cn;

        }
        private static string ObtenerString()
        {
            AppSettingsReader appSettReader = new AppSettingsReader();
            return cn = appSettReader.GetValue("strCon", typeof(string)).ToString();
        }
       
    }
       
    }
