
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Negocio
{
    public class CuentaEspecial
    {
        public static InfoCuentaEspecial Crear(InfoCuentaEspecial infoCuentaEspecial)
        {
            InfoCuentaEspecial cuenta = Buscar(infoCuentaEspecial.CteCodigo);
            if (cuenta == null)
            {
                return Datos.CuentaEspecial.Crear(infoCuentaEspecial);
            }
            else
            {
                if (cuenta.Eliminado)
                {
                    cuenta = infoCuentaEspecial;
                    cuenta.Eliminado = false;
                    Datos.CuentaEspecial.Modificar(infoCuentaEspecial);
                    return Buscar(cuenta.CteCodigo);
                }
                else
                {
                    throw new Exception(" Ya existe la cuenta!");
                }
            }
        }
        public static void Modificar(InfoCuentaEspecial infoCuenta)
        {
            Datos.CuentaEspecial.Modificar(infoCuenta);
        }
        public static InfoCuentaEspecial Buscar(int Codigo)
        {
            return Datos.CuentaEspecial.Buscar(Codigo);
        }

        public static DataTable Listar(bool eliminados)
        {
            return Datos.CuentaEspecial.Listar(eliminados);
        }
        public static void Eliminar(int codigo)
        {
            Datos.CuentaEspecial.Eliminar(codigo);
        }

     
    }
}



