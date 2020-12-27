
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Negocio
{
    public class CuentaVariable
    {
        public static InfoCuentaVariable Crear(InfoCuentaVariable infoCuentaVariable, int rut)
        {
            InfoCuentaVariable cuenta = Buscar(infoCuentaVariable.CtvCodigo);
            if (cuenta == null)
            {
                return Datos.CuentaVariable.Crear(infoCuentaVariable,rut);
            }
            else
            {
                if (cuenta.Eliminado)
                {
                    cuenta = infoCuentaVariable;
                    cuenta.Eliminado = false;
                    Datos.CuentaVariable.Modificar(infoCuentaVariable,rut);
                    return Buscar(cuenta.CtvCodigo);
                }
                else
                {
                    throw new Exception(" Ya existe la cuenta!");
                }
            }
        }
        public static void Modificar(InfoCuentaVariable infoCuenta, int rut)
        {
            Datos.CuentaVariable.Modificar(infoCuenta,rut);
        }
        public static InfoCuentaVariable Buscar(int Codigo)
        {
            return Datos.CuentaVariable.Buscar(Codigo);
        }

        public static DataTable Listar(bool eliminados)
        {
            return Datos.CuentaVariable.Listar(eliminados);
        }
        public static void Eliminar(int codigo)
        {
            Datos.CuentaVariable .Eliminar(codigo);
        }
        public static DataTable ListarHistoricoCambioPrecios(int codigo)
        {
            return Datos.CuentaVariable.ListarCambiosdePrecios(codigo);
        }
        public static DataTable ListadoIngresoCV(int mes, int ano, int codigo)
        {
            return Datos.CuentaVariable.ListadoIngresoCV(mes, ano, codigo);
        }
        public static List<InfoCuentaVariable> Lista(bool eliminados)
        {
            return Datos.CuentaVariable.Lista(eliminados);
        }
        public static void AsociarPropietario(InfoCuentaVarPropietario Asociacion)
        {
            if (!Datos.CuentaVariable.ExisteAsociacion(Asociacion))
                Datos.CuentaVariable.AsociarPropietario(Asociacion);
            else
                throw new Exception("El propietario ya tiene asignada esta cuenta fija");
        }
        public static void DesasociarPropietario(InfoCuentaVarPropietario Asociacion)
        {
            Datos.CuentaVariable.DesasociarPropietario(Asociacion);
        }
        public static void ModificarAsocionPropietario(InfoCuentaVarPropietario Asociacion)
        {
            if (Datos.CuentaVariable.ExisteAsociacion(Asociacion))
                Datos.CuentaVariable.ModificarAsocionPropietario(Asociacion);
            else
                throw new Exception("Esta cuenta no está asociada al propietario");

        }
        public static void ActualizarDeudaPropietario(int idPropietario, int cvCodigo, decimal deuda)
        {
            Datos.CuentaVariable.ActualizarDeudaPropietario(idPropietario, cvCodigo, deuda);
        }
        public static DataTable ListadoIngresoCVforCSV(int mes, int ano, int codigo)
        {
            return Datos.CuentaVariable.ListadoIngresoCVforCSV(mes, ano, codigo);
        }
        
    }
}



