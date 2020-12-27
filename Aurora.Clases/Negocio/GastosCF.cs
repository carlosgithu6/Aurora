using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Negocio
{
    public class GastosCF
    {
        public static InfoGastosCF Crear(InfoGastosCF infoGastosCF)
        {
            InfoGastosCF cuenta = Buscar(infoGastosCF);
            if (cuenta == null)
            {
                return Datos.GastosCF.Crear(infoGastosCF);
            }
            else
            {
                throw new Exception(" Ya existe el Gasto !");
            }
        }

        public static void Modificar(InfoGastosCF infoGastosCF)
        {
            if (infoGastosCF.FormadePago == FormaPago.Indefinido)
                throw new Exception("Debe especificar la forma de pago.");
            InfoGastosCF infoGastoTest = Buscar(infoGastosCF);
            if (Convert.ToInt64((infoGastoTest.GCFMontoCancelado + infoGastosCF.GCFMontoCancelado)) > Convert.ToInt64(infoGastosCF.GCFMonto)) throw new Exception("Está intentando pagar una cantidad mayor. Debe pagar $" + (infoGastosCF.GCFMonto - infoGastoTest.GCFMontoCancelado).ToString());
            if (infoGastosCF.FormadePago == FormaPago.DesdeCCte && !infoGastosCF.DescontarCte) throw new Exception("Hay inconsistencia en la forma de pago. Debe marcar el check 'Descontar CCte.'");
            if (infoGastosCF.GCFMontoCancelado <= 0 && (!infoGastosCF.DescontarCte || infoGastosCF.FormadePago != FormaPago.DesdeCCte))
            {
                throw new Exception("El monto que se intenta pagar no es válido.");
            }
            //if (infoGastosCF.GCFMontoCancelado <= 0 )
            //{
            //    throw new Exception("El monto que se intenta pagar no es válido.");
            //}
            if (infoGastosCF.GCFMontoCancelado > 0 && infoGastosCF.FormadePago == FormaPago.DesdeCCte && infoGastosCF.DescontarCte) throw new Exception("Cuando el pago se realiza desde cuenta corriente se cancela el total del pago, no es necesario especificar el monto.");
            InfoPropietario prop = Propietario.Buscar(infoGastosCF.IdPropiedad);
            
            if (infoGastosCF.DescontarCte)
            {
                if (infoGastosCF.FormadePago != FormaPago.DesdeCCte) throw new Exception("Hay inconsistencia en la forma de pago. Debe seleccionar 'Desde CCte.'");
                if (prop.SaldoCuentaCte >= infoGastosCF.GCFMonto)
                {
                    infoGastosCF.FormadePago = FormaPago.DesdeCCte;
                    Propietario.AbonarACuentaCorriente(prop, -infoGastosCF.GCFMonto,true);
                    infoGastosCF.GCFMontoCancelado = infoGastosCF.GCFMonto;
                }
                else 
                throw new Exception("No tiene sufiente fondo en la cuenta corriente, haga primero un abono si desea pagar por esta vía.");

            }
           if (infoGastosCF.FormadePago == FormaPago.ChequeFecha)
            {
                if (infoGastosCF.FechaCheque == DateTime.MinValue) throw new Exception("Debe especificar la fecha del cheque");
                infoGastosCF.FechaPago = infoGastosCF.FechaCheque;
            }
            Datos.GastosCF.Modificar(infoGastosCF);
            Propietario.ActualizarDeudasAcumuladas(infoGastosCF.IdPropiedad);
        }
        public static InfoGastosCF Buscar(InfoGastosCF infoGastosCF)
        {
            return Datos.GastosCF.Buscar(infoGastosCF);
        }

        public static DataTable Listar()
        {
            return Datos.GastosCF.Listar();
        }
        public static void Eliminar(InfoGastosCF infoGastosCF)
        {
            Datos.GastosCF.Eliminar(infoGastosCF);
        }
        public static DataTable Buscar(int idPropiedad, int mes, int ano )
        {
            DataTable dt = new DataTable();
            dt = Datos.GastosCF.Buscar(idPropiedad, mes, ano);
            foreach (DataRow dr in dt.Rows)
            {
                dr["GCFMONTO"] =Math.Round(Convert.ToDecimal(dr["GCFMONTO"]) * UF.Buscar(mes, ano).UF,0);
            }
            dt.AcceptChanges();
            return dt;
        }
        public static DataTable BuscarDetallePagos (int idPropiedad, int mes, int ano,int codigo)
        {
            DataTable dt = new DataTable();
            dt = Datos.GastosCF.BuscarDetallePagos(idPropiedad, mes, ano, codigo);
            return dt;
        }
        public static DataTable BuscarDeuda(int idPropiedad, int mes, int ano)
        {
            return null;
        }
        public static List<InfoGastosCF> BuscarLista(int idPropiedad, int mes, int ano)
        {
            return Datos.GastosCF.BuscarLista(idPropiedad, mes, ano);
        }

        public static List<InfoGastosCF> BuscarListaHistoria(int idPropiedad,int anod,int mesd, int anoh,int mesh)
        {
            return Datos.GastosCF.BuscarListaHistoria(idPropiedad,  anod, mesd,  anoh, mesh);
        }
        //public static DataTable GetForEstadoCuenta(int idPropiedad, int mes, int ano, ref Int32 total)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("CFIJA");
        //        List<InfoGastosCF> datos = BuscarLista(idPropiedad, mes, ano);
        //        foreach (InfoGastosCF cuenta in datos)
        //        {
        //            DataRow dr = dt.NewRow();
        //            total +=Convert.ToInt32(cuenta.GCFMonto*UF.Buscar(mes,ano).UF);
        //            cuenta.Deuda = Propietario.BuscarDeudaFijaPorTipo(idPropiedad, cuenta.CFCodigo);
        //            total += Convert.ToInt32(cuenta.Deuda);
        //            cuenta.ValorUF = UF.Buscar(mes, ano).UF;
        //            dr["CFIJA"] = cuenta.GetHtml();
        //            dt.Rows.Add(dr);
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al generar la nota de cobro. Debe chequear que ha ingresado las lecturas correspondientes"+ex.Message);
        //    }
        //}


        public static String GetForEstadoCuenta(int idPropiedad, int mes, int ano, ref Int32 total)
        {
            try
            {
                String headTable = "<table style=\"border-color:#000000; azimuth:center;font-size:xx-small; border-spacing:inherit ;border-collapse:collapse; border-style:solid; width:100%; border-width:1px; margin-left: auto; margin-right: auto\">" +
               "<tr>" +
               "<td width='27%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>CONCEPTO</strong></td>" +
			   "<td></td>" +
               "<td width='10%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>VALOR (UF)</strong></td>" +
               "<td width='10%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>CARGO MES</strong></td>" +
               "<td width='10%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>RECUP. GASTO IMPAGO</strong></td>" +
               "<td width='10%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>TOTAL A PAGAR <@MES></strong></td>" +
               "</tr>";


                String footTable = "<tr border='0'>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\">VALOR UF A <@MES> <@ANO>  $<@UF> </td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "</tr>"+
                                   "</table>";
               // StringBuilder Row = new StringBuilder("<tr align=\"center\">" +
               //"<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\">Deuda Inicial</td>" +
               //"<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
               //"<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"></div></td>" +
               //"<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"></div></td>" +
               //"<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"></div></td>" +
               //"<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"><@DEUDAINICIAL></div></td>" +
               //"</tr>");
               //// StringBuilder table = new StringBuilder(headTable);
                StringBuilder result = new StringBuilder(headTable);
                List<InfoGastosCF> datos = BuscarLista(idPropiedad, mes, ano);
                int count = 0 ;
                    foreach (InfoGastosCF cuenta in datos)
                    {
                        if (cuenta.TipoCuenta == 1 || cuenta.TipoCuenta == 2 || cuenta.TipoCuenta == 3)
                        {
                            total += Convert.ToInt32(cuenta.GCFMonto * UF.Buscar(mes, ano).UF);
                            cuenta.Deuda = Propietario.BuscarDeudaFijaPorTipo(idPropiedad, cuenta.CFCodigo);
                            total += Convert.ToInt32(cuenta.Deuda);
                            cuenta.ValorUF = UF.Buscar(mes, ano).UF;

                            result.Append(cuenta.GetHtmlTableRow());
                            count++;
                        }
                    }
                     //InfoPropietario prop =  Propietario.Buscar(idPropiedad);
                     //if ((int)prop.DeudaPendiente>0)
                     //{
                     //    Row.Replace("<@DEUDAINICIAL>", ((int)prop.DeudaPendiente).ToString("0,0"));
                     //    result.Append(Row);
                     //    total += (int)prop.DeudaPendiente;
                     //}

                    if (count > 0)
                    {
                        result.Append(footTable);
                        result.Replace("<@MES>", ((Base.Enums.Mes)mes).ToString().ToUpper());
                        result.Replace("<@ANO>", ano.ToString());
                        result.Replace("<@UF>", Negocio.UF.Buscar(mes, ano).UF.ToString("0,0.00"));
                        return result.ToString();
                    }
                    else return String.Empty;

               
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar la nota de cobro. Debe chequear que ha ingresado las lecturas correspondientes" + ex.Message);
            }
        }

        


        public static String GetForEstadoCuentaOtrosGastos(int idPropiedad, int mes, int ano, ref Int32 total)
        {
            try
            {
                String headTable = "<table style=\"border-color:#000000; azimuth:center;font-size:xx-small; border-spacing:inherit ;border-collapse:collapse; border-style:solid; width:100%; border-width:1px; margin-left: auto; margin-right: auto\">" +
               "<tr>" +
               "<td width='27%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>CONCEPTO RECUPERACION DE OTROS GASTOS</strong></td>" +
               "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
               "<td width='10%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>VALOR (UF)</strong></td>" +
               "<td width='10%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>CARGO MES</strong></td>" +
               "<td width='10%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>RECUP. GASTO IMPAGO</strong></td>" +
               "<td width='10%' style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>TOTAL A PAGAR <@MES></strong></td>" +
               "</tr>";


                String footTable = "<tr border='0' align='center'>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\">VALOR UF A <@MES> <@ANO>  $<@UF> </td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
                                   "</tr>" +
                                   "</table>";

                StringBuilder table = new StringBuilder(headTable);
                StringBuilder result = new StringBuilder(headTable);

                
                List<InfoGastosCF> datos = BuscarLista(idPropiedad, mes, ano);
                
                int count = 0;
                foreach (InfoGastosCF cuenta in datos)
                {   
                    if (cuenta.TipoCuenta == (int)TipoCuentaFija.RecuperacionOtrosGastos)
                    {
                        total += Convert.ToInt32(cuenta.GCFMonto * UF.Buscar(mes, ano).UF);
                        //cuenta.Deuda = Propietario.DeudaCuentasFijas(idPropiedad);//Se ponen todas las deudas de cuentas fijas
                        cuenta.Deuda = Propietario.BuscarDeudaFijaPorTipo(idPropiedad, cuenta.CFCodigo);
                        total += Convert.ToInt32(cuenta.Deuda);
                        cuenta.ValorUF = UF.Buscar(mes, ano).UF;

                        result.Append(cuenta.GetHtmlTableRow());
                        count++;
                    }
                }

                if (count == 1)
                {
                    result.Append(footTable);
                    result.Replace("<@MES>", ((Base.Enums.Mes)mes).ToString().ToUpper());
                    result.Replace("<@ANO>", ano.ToString());
                    result.Replace("<@UF>", Negocio.UF.Buscar(mes, ano).UF.ToString("0,0.00"));

                    return result.ToString();
                }
                else
                    return String.Empty;
             
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar la nota de cobro. Debe chequear que ha ingresado las lecturas correspondientes" + ex.Message);
            }
        }
        public static void EliminarDetalle(int NumMov)
        {
            Datos.GastosCF.EliminarDetalle(NumMov);
        }

        public static List<InfoGastosCF> GetForExcel(int idPropiedad, int mes, int ano)
        {
            try
            {
                List<InfoGastosCF> datos = BuscarLista(idPropiedad, mes, ano);
                foreach (InfoGastosCF cuenta in datos)
                {
                    //  total += Convert.ToInt32(cuenta.GCFMonto * UF.Buscar(mes, ano).UF);
                    cuenta.Deuda = Propietario.BuscarDeudaFijaPorTipo(idPropiedad, cuenta.CFCodigo);
                    // total += Convert.ToInt32(cuenta.Deuda);
                    cuenta.ValorUF = UF.Buscar(mes, ano).UF;
                }
                return datos;
            }
            catch (Exception ex1)
            {
                throw new Exception("Error datos para el Excel CF. Debe chequear que ha ingresado las lecturas correspondientes " + ex1.Message);
            }
        }
    }
}