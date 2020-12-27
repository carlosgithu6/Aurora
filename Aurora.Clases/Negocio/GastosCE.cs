using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Negocio
{
    public class GastosCE
    {
        //public static InfoGastosCE Crear(InfoGastosCE infoGastosCE)
        //{
        //    InfoGastosCE cuenta = Buscar(infoGastosCE.IdGastoCE);
        //    if (cuenta == null)
        //    {
        //        return Datos.GastosCE.Crear(infoGastosCE);
        //    }
        //    else
        //    {
        //        throw new Exception(" Ya existe el Gasto !");
        //    }
        //}

        public static void Modificar(InfoGastosCE infoGastosCE)
        {
            Datos.GastosCE.Modificar(infoGastosCE);
        }
        public static void Pagar(InfoGastosCE infoGastosCE)
        {
            if (infoGastosCE.GCEMontoCancelado > infoGastosCE.GCEMontoCuota)
            {
                throw new Exception("El monto que se intenta pagar es mayor.");
            }
            if (infoGastosCE.GCEMontoCancelado <= 0)
            {
                throw new Exception("El monto que se intenta pagar no es válido.");
            }

            InfoPropietario prop = Propietario.Buscar(infoGastosCE.IdPropiedad);
            if (infoGastosCE.DescontarCte)
            {
                if (prop.SaldoCuentaCte >= infoGastosCE.GCEMontoCancelado)
                {
                    infoGastosCE.FormadePago = FormaPago.DesdeCCte;
                    Propietario.AbonarACuentaCorriente(prop, -infoGastosCE.GCEMontoCancelado,true);                   
                }
                else
                    throw new Exception("No tiene sufiente fondo en la cuenta corriente, haga primero un abono si desea pagar por esta vía.");
            }
            if (infoGastosCE.FormadePago == FormaPago.Indefinido)
                throw new Exception("Debe especificar la forma de pago.");

           Datos.GastosCE.Modificar(infoGastosCE);
        }
        //public static InfoGastosCE Buscar(int Codigo)
        //{
        //    return Datos.GastosCE.Buscar(Codigo);
        //}

        public static DataTable Listar()
        {
            return Datos.GastosCE.Listar();
        }
        public static DataTable Listar(int IdPropiedad)
        {
            return Datos.GastosCE.Listar(IdPropiedad);
        }
        public static void Eliminar(int codigo)
        {
            Datos.GastosCE.Eliminar(codigo);
        }

        public static DataTable ListarGEByIdGasto(string rut)
        {
            return Datos.GastosCE.ListarGEByIdGasto(rut);
        }
        public static List<InfoGastosCE> BuscarLista(int idPropiedad, int mes, int ano)
        {
            return Datos.GastosCE.BuscarLista(idPropiedad, mes, ano);
        }
        //public static DataTable GetForEstadoCuenta(int idPropiedad, int mes, int ano,ref Int32 total)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("CESPECIAL");
        //        List<InfoGastosCE> datos = BuscarLista(idPropiedad, mes, ano);
        //        foreach (InfoGastosCE cuenta in datos)
        //        {
        //            total += Convert.ToInt32(cuenta.GCEMontoCuota);
        //            DataRow dr = dt.NewRow();
        //            dr["CESPECIAL"] = cuenta.GetHtml();
        //            dt.Rows.Add(dr);
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al generar la nota de cobro. Debe chequear que ha ingresado las lecturas correspondientes" + ex.Message);
        //    }
        //}

        public static String GetForEstadoCuenta(int idPropiedad, int mes, int ano, ref Int32 total)
        {
            try
            {
                StringBuilder result = new StringBuilder("<table style=\"border-color:#000000; azimuth:center;font-size:xx-small; border-spacing:inherit ;border-collapse:collapse; border-style:solid; width:100%; border-width:1px; margin-left: auto; margin-right: auto\"><tr><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><b>CONCEPTO</b></td><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><b>SALDO PENDIENTE</b></td><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><b>CUOTAS PACTADAS</b></td><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><b>CUOTA ACTUAL</b></td><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><b>TOTAL A PAGAR</b></td></tr>");
                List<InfoGastosCE> datos = BuscarLista(idPropiedad, mes, ano);
                int count = 0;
                foreach (InfoGastosCE cuenta in datos)
                {
                    total += Convert.ToInt32(cuenta.GCEMontoCuota);
                    
                    result.Append(cuenta.GetHtmlRow());
                    count++;
                    
                }
                result.Append("</table>");
                if (count > 0) return result.ToString();
                else return String.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar la nota de cobro. Debe chequear que ha ingresado las lecturas correspondientes" + ex.Message);
            }
        }

        public static List<InfoGastosCE> GetForExcel(int idPropiedad, int mes, int ano)
        {
            try
            {
                List<InfoGastosCE> datos = BuscarLista(idPropiedad, mes, ano);
                return datos;
            }
            catch (Exception ex1)
            {
                throw new Exception("Error datos para el Excel CE. Debe chequear que ha ingresado las lecturas correspondientes " + ex1.Message);
            }
        }

    }
}



