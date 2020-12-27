
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Negocio
{
    public class GastosResumen
    {
        public static InfoGastosResumen Crear(InfoGastosResumen infoGastosResumen)
        {
            InfoGastosResumen infoGastos = Buscar(infoGastosResumen.IdGasto);
            if (infoGastos == null)
            {
                return Datos.GastosResumen.Crear(infoGastosResumen);
            }
         
                else
                {
                    throw new Exception(" Ya existe el Resumen de Gatos!");
                }
         }

        public static void Modificar(InfoGastosResumen infoGasto)
        {
            Datos.GastosResumen.Modificar(infoGasto);
        }

        public static InfoGastosResumen Buscar(int Codigo)
        {
            return Datos.GastosResumen.Buscar(Codigo);
        }

        public static DataTable Listar()
        {
            return Datos.GastosResumen.Listar();
        }
        public static DataTable Listar(int mes, int ano)
        {
            return Datos.GastosResumen.Listar(mes,ano);
        }
        public static void Eliminar(int codigo)
        {
            Datos.GastosResumen.Eliminar(codigo);
        }


    }
}
