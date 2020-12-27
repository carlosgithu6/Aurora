
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Negocio
{
    public class CtePropietario
    {
        public static InfoCtePropietario Crear(InfoCtePropietario infoCtePropietario)
        {
            InfoCtePropietario cuenta = Buscar(infoCtePropietario.IdCtePropietario);
            if (cuenta == null)
            {
                return Datos.CtePropietario.Crear(infoCtePropietario);
            }
            else
            {
                if (cuenta.Eliminado)
                {
                    cuenta = infoCtePropietario;
                    cuenta.Eliminado = false;
                    Datos.CtePropietario.Modificar(infoCtePropietario);
                    return Buscar(cuenta.IdCtePropietario);
                }
                else
                {
                    throw new Exception(" Ya existe la cuenta!");
                }
            }
        }

        public static void Modificar(InfoCtePropietario infoCuenta)
        {
            Datos.CtePropietario.Modificar(infoCuenta);
        }

        public static InfoCtePropietario Buscar(int Codigo)
        {
            return Datos.CtePropietario.Buscar(Codigo);
        }

        public static DataTable Listar(int  idPropiedad)
        {
            return Datos.CtePropietario.Listar(idPropiedad);
        }
        public static void Eliminar(int codigo)
        {
            Datos.CtePropietario.Eliminar(codigo);
        }


    }
}

