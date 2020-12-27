using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Negocio
{
    public sealed class Usuario
    {
        public static InfoUsuario IngresoSistema(string strRut, string strPass)
        {
            InfoUsuario _objUsuario;
            byte[] _bytTemp = null;
            _objUsuario = Datos.Usuario.Buscar(strRut);

            if (_objUsuario != null && !_objUsuario.Eliminado)
            {
                _bytTemp = Convert.FromBase64String(strPass);
                if (Aurora.Clases.Base.Encriptacion.MiRijndael.Desencriptar(_bytTemp) == Aurora.Clases.Base.Encriptacion.MiRijndael.Desencriptar(Convert.FromBase64String(_objUsuario.Password)))
                {
                    return _objUsuario;
                }
                else
                    return null;
            }
            else
            {
                return null;
            }

        }
      
        public static InfoUsuario Crear(InfoUsuario objUsuario)
        {
            InfoUsuario usr = Buscar(objUsuario.Rut);
            if (usr == null)
            {
                return Datos.Usuario.Crear(objUsuario);
            }
            else
            {
                if (usr.Eliminado)
                {
                    usr.Eliminado = false;
                    Datos.Usuario.Modificar(usr);
                    return Buscar(objUsuario.Rut);
                }
                else
                {
                    throw new Exception(" Ya existe el usuario!");
                }
            }
        }
        public static void Modificar(InfoUsuario objUsuario,bool cambiarPass)
        {
            if (!cambiarPass)
                Datos.Usuario.Modificar(objUsuario);
            else
                Datos.Usuario.CambiarPass(objUsuario);
        }
        public static InfoUsuario Buscar(string strRut)
        {
            return Datos.Usuario.Buscar(strRut);
        }
        public static DataTable ListarTodos()
        {
            return Datos.Usuario.ListarTodosDataTable();
        }
        public static void Eliminar(string rut)
        {
            Datos.Usuario.Eliminar(rut);
        }


    }
}
