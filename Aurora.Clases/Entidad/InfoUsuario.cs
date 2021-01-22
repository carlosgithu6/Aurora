using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aurora.Clases.Base.Enums;
namespace Aurora.Clases.Entidad
{
    //representa un usuario que utiliza el sistema
    [Serializable]
    public class InfoUsuario
    {
        public string Rut;
        public string Nombres;
        public string ApePaterno;
        public string ApeMaterno;
        public string Direccion;
        public string Telefono;
        public string Password;
        public Perfil Perfil;
      
        public string Email;
        public DateTime FechaCreacion;
        public DateTime FechaActualizacion;
      
        public bool Eliminado=false;
        public InfoUsuario()
        { }
        public InfoUsuario(string strRut, string strNombres, string strApePaterno, string strApeMaterno, string strPassword,
            Perfil enuRol, string strEmail, string strDireccion,string strTelefono,DateTime datFechaCreacion, DateTime datFechaActualizacion)
        {
            Rut = strRut;
            Nombres = strNombres;
            ApePaterno = strApePaterno;
            ApeMaterno = strApeMaterno;
            Password = strPassword;
            Perfil = enuRol;
            Email = strEmail;
            Telefono = strTelefono;
            Direccion = strDireccion;
            FechaCreacion = datFechaCreacion;
            FechaActualizacion = datFechaActualizacion;
        }
        public string NombreCompleto
        {
            get { return this.Nombres + " " + this.ApePaterno + " " + this.ApeMaterno; }
        }
    }
}
