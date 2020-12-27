using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;


namespace Aurora.Clases.Negocio
{
    public class CambioMedidor
    {
        public static InfoCambioMedidor Crear(InfoCambioMedidor infoCambioMedidor)
        {
            InfoNomina nomina = null;
            nomina = Nomina.BuscarNomina(infoCambioMedidor.CMfechaCambio.Month, infoCambioMedidor.CMfechaCambio.Year);
            if (nomina != null && nomina.FechaCierre != DateTime.MinValue) throw new Exception("La está tratando de cambiar el medidor en una nomina que está cerrada");
            if (infoCambioMedidor.CMfechaCambio > DateTime.Now) throw new Exception("No puede ingresar el cambio de un medidor en una fecha posterior a la actual");
            InfoPropietario prop = Propietario.Buscar(infoCambioMedidor.IdPropiedad);
            if (!Propietario.TieneCuentaVariable(prop, infoCambioMedidor.CodigoCV)) throw new Exception("El propietario no tiene asignada esta cuenta");
            InfoCambioMedidor cuenta = Buscar(infoCambioMedidor);
            if (cuenta == null)
            {
                return Datos.CambioMedidor.Crear(infoCambioMedidor);
            }
            else
            {
                throw new Exception("Ya existe el Cambio de Medidor!");
            }
        }

        public static void Modificar(InfoCambioMedidor infoCambioMedidor)
        {
            Datos.CambioMedidor.Modificar(infoCambioMedidor);
        }

        public static InfoCambioMedidor Buscar(InfoCambioMedidor infoCambioMedidor)
        {
            return Datos.CambioMedidor.Buscar(infoCambioMedidor);
        }

        public static DataTable Listar()
        {
            return Datos.CambioMedidor.Listar();
        }
        public static DataTable Listar(int IdPropiedad)
        {
            return Datos.CambioMedidor.Listar(IdPropiedad);
        }
        public static void Eliminar(InfoCambioMedidor infoCambioMedidor)
        {
            Datos.CambioMedidor.Eliminar(infoCambioMedidor);
        }

    }
}
