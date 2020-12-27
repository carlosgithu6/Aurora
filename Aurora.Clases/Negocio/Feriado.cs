using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Negocio
{
    public class Feriado
    {
        public static DataTable ListarFeriados()
        {
            return Datos.Feriado.ListarFeriados();
        }
        public static void Eliminar(DateTime feriado)
        {
            Datos.Feriado.Eliminar(feriado);
        }
        public static InfoFeriado Buscar(DateTime feriado)
        {
          return  Datos.Feriado.Buscar(feriado);
        }
        public static void Crear(InfoFeriado feriado)
        {
            if (Buscar(feriado.Feriado) == null)
            {
                Datos.Feriado.Crear(feriado);
            }
            else
                throw new Exception("El feriado ya está registrado");
        }
    }
}
