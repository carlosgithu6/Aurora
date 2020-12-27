using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Aurora.Clases.Entidad;

namespace Aurora.Clases.Negocio
{
    public class CuentaFija
    {
        public static InfoCuentaFija Crear(InfoCuentaFija infoCuenta)
        {
            InfoCuentaFija cuenta = Buscar(infoCuenta.Codigo);
            if (cuenta == null)
            {
                return Datos.CuentaFija.Crear(infoCuenta);
            }
            else
            {
                if (cuenta.Eliminado)
                {
                    cuenta = infoCuenta;
                    cuenta.Eliminado = false;
                    Datos.CuentaFija.Modificar(cuenta);
                    return Buscar(cuenta.Codigo);
                }
                else
                {
                    throw new Exception(" Ya existe la cuenta!");
                }
            }
        }
        public static void Modificar(InfoCuentaFija infoCuenta)
        {
            Datos.CuentaFija.Modificar(infoCuenta);
        }
        public static InfoCuentaFija Buscar(int Codigo)
        {
            return Datos.CuentaFija.Buscar(Codigo);
        }
        public static DataTable Listar(bool eliminados)
        {
            return Datos.CuentaFija.Listar(eliminados);
        }
        public static List<InfoCuentaFija> Lista(bool eliminados)
        {
           return Datos.CuentaFija.Lista(eliminados);
        }
        public static void Eliminar(int codigo)
        {
            try
            {
                Datos.CuentaFija.Eliminar(codigo);
            }
            catch (Exception)
            {
                throw new Exception("No se puede eliminar esta cuenta fija, está asociada a propietarios");
            }
        }
        public static void CrearHistorico(Tarifas tarifas)
        {
            Datos.CuentaFija.CrearHistorico(tarifas);
        }
        //private static bool ValidarAsociacionCuentasFijasParaRecuperacionOtrosGastos(InfoCuentaFijaPropietario Asociacion)
        //{ 
        //    //si el propietario tiene asociada una cuenta del tipo 1,2 o 3 entonces no se le puede asociar una 4 
        //    // y la 4 sola puede ser 1.
        //     DataTable dt = Negocio.Propietario.BuscarCuentasFijas(Negocio.Propietario.Buscar(Asociacion.IdPropiedad));
        //     DataRow[] rows = dt.Select(("TIPOCUENTA =4"));
        //     if (rows.Length > 0) throw new Exception("Si un propietario tiene asignada una cuenta  de recuperación de otros gastos. Por ejemplo Cuota Social, no se le puede asignar ningún otro tipo de cuenta fija");

        //    if (Negocio.CuentaFija.Buscar(Asociacion.IdCuentaFija).Tipo == TipoCuentaFija.RecuperacionOtrosGastos)
        //    {
        //         if (dt.Rows.Count > 0) throw new Exception("Si un propietario tiene al menos una cuenta fija asociada entonces no se le puede asignar la de recuperación de otros gastos. Por ejemplo Cuota Social");
        //    }
        //    return true;
        //}
        public static void AsociarPropietario(InfoCuentaFijaPropietario Asociacion)
        {
               if (!Datos.CuentaFija.ExisteAsociacion(Asociacion) )//&&
                    //ValidarAsociacionCuentasFijasParaRecuperacionOtrosGastos(Asociacion))
                Datos.CuentaFija.AsociarPropietario(Asociacion);
            else
                throw new Exception("El propietario ya tiene asignada esta cuenta fija");

        }
        public static void DesasociarPropietario(InfoCuentaFijaPropietario Asociacion)
        {
            Datos.CuentaFija.DesasociarPropietario(Asociacion);
        }
        public static void ModificarAsocionPropietario(InfoCuentaFijaPropietario Asociacion)
        {
            if (Datos.CuentaFija.ExisteAsociacion(Asociacion))
                Datos.CuentaFija.ModificarAsocionPropietario(Asociacion);
            else
                throw new Exception("Esta cuenta no está asociada al propietario");

        }
        public static void ActualizarDeudaPropietario(int idPropietario,int idCuentaFija ,decimal deuda)
        {
            try
            {
                Datos.CuentaFija.ActualizarDeudaPropietario(idPropietario, idCuentaFija, deuda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
