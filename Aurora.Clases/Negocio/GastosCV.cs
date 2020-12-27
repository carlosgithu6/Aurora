using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

using Aurora.Clases.Entidad;

namespace Aurora.Clases.Negocio
{
    public class GastosCV
    {
        
        public static InfoGastosCV Crear(InfoGastosCV infoGastosCV)
        {
            InfoGastosCV cuenta = Buscar(infoGastosCV);
            if (cuenta == null)
            {
                return Datos.GastosCV.Crear(infoGastosCV);
            }
            else
            {
                    throw new Exception(" Ya existe el Gasto !");
            }
        }
      
        public static void Modificar(InfoGastosCV infoGastoCV)
        {
            if (infoGastoCV.Tipo == TipoCuentaVariable.RecuperacionGastos)
            {
                if (infoGastoCV.GVLecturaActual != 0 || infoGastoCV.GVLecturaAnterior != 0)
                {
                    throw new Exception("La recuperación de gastos no necesita ingreso de lecturas.");
                }
            }
            else
            {
                if (infoGastoCV.GVLecturaActual < infoGastoCV.GVLecturaAnterior) throw new Exception("La lectura actual debe ser mayor o igual que la anterior");
                if (infoGastoCV.GVLecturaActual < 0) throw new Exception("La lectura actual no puede ser menor a cero");
//                if (infoGastoCV.GVLecturaActual == 0) throw new Exception("La lectura actual no puede ser igual a cero");
              //  if (infoGastoCV.GVLecturaAnterior == 0) throw new Exception("La lectura anterior no puede ser igual a cero");
                if (infoGastoCV.Factor == 0 && infoGastoCV.Trifasico) throw new Exception("Debe especificar el valor del factor trifásico");
                if (!infoGastoCV.Trifasico && infoGastoCV.Factor != 0) throw new Exception("Si desea indicar un factor trifásico debe seleccionar la el check de trifásico");
            }
            Datos.GastosCV.Modificar(infoGastoCV);         
        }
        public static void Pagar(InfoGastosCV infoGastoCV)
        {
            if (infoGastoCV.FormadePago == FormaPago.Indefinido)
                throw new Exception("Debe especificar la forma de pago.");
            InfoGastosCV infoGastoTest = Buscar(infoGastoCV);
            if (Convert.ToInt64((infoGastoTest.GVMontoCancelado + infoGastoCV.GVMontoCancelado)) > Convert.ToInt64(infoGastoCV.getCostoTotal())) throw new Exception("Está intentando pagar una cantidad mayor. Debe pagar $" + (infoGastoCV.getCostoTotal() - infoGastoTest.GVMontoCancelado).ToString());
            if (infoGastoCV.FormadePago == FormaPago.DesdeCCte && !infoGastoCV.DescontarCte) throw new Exception("Hay inconsistencia en la forma de pago. Debe marcar el check 'Descontar CCte.'");
            if (infoGastoCV.GVMontoCancelado <= 0 && (!infoGastoCV.DescontarCte || infoGastoCV.FormadePago != FormaPago.DesdeCCte))
            {
                throw new Exception("El monto que se intenta pagar no es válido.");
            }
          
            if (infoGastoCV.GVMontoCancelado > 0 && infoGastoCV.FormadePago == FormaPago.DesdeCCte && infoGastoCV.DescontarCte) throw new Exception("Cuando el pago se realiza desde cuenta corriente se cancela el total del pago, no es necesario especificar el monto.");

            if (Convert.ToInt64(infoGastoCV.GVMontoCancelado) > Convert.ToInt64(infoGastoCV.getCostoTotal()))
            {
                throw new Exception("El monto que se intenta pagar es mayor.");
            }
            InfoPropietario prop = Propietario.Buscar(infoGastoCV.IdPropiedad);
            if (infoGastoCV.DescontarCte)
            {
                if (infoGastoCV.FormadePago != FormaPago.DesdeCCte) throw new Exception("Hay inconsistencia en la forma de pago. Debe seleccionar 'Desde CCte.'");
                if (prop.SaldoCuentaCte >= infoGastoCV.getCostoTotal())
                {
                    infoGastoCV.FormadePago = FormaPago.DesdeCCte;
                    Propietario.AbonarACuentaCorriente(prop, -infoGastoCV.getCostoTotal(), true);
                    infoGastoCV.GVMontoCancelado = infoGastoCV.getCostoTotal();
                }
                else
                    throw new Exception("No tiene sufiente fondo en la cuenta corriente, haga primero un abono si desea pagar por esta vía.");
            }
            if (infoGastoCV.FormadePago == FormaPago.ChequeFecha)
            {
                if (infoGastoCV.FechaCheque == DateTime.MinValue) throw new Exception("Debe especificar la fecha del cheque");
                infoGastoCV.FechaPago = infoGastoCV.FechaCheque;
            }
            else 
                if (infoGastoCV.FechaPago == new DateTime(1900, 1, 1)) infoGastoCV.FechaPago = DateTime.Now;
            Datos.GastosCV.Pagar(infoGastoCV);
            Propietario.ActualizarDeudasAcumuladas(infoGastoCV.IdPropiedad);
        }
        public static InfoGastosCV Buscar(InfoGastosCV infoGastoCV)
        {
            return Datos.GastosCV.Buscar(infoGastoCV);
        }
        public static DataTable Buscar(int idPropiedad, int mes, int ano, int codigo)
        {
            DataTable dt = Datos.GastosCV.Buscar(idPropiedad, mes, ano,-1);
            foreach (DataRow dr in dt.Rows)
            {
                //if ((DateTime)dr["FECHAPAGO"] == new DateTime(1900, 1, 1)) dr["FECHAPAGO"] = null;
                if (((TipoCuentaVariable)Convert.ToInt16(dr["CTVTIPO"]))!= TipoCuentaVariable.RecuperacionGastos)
                {
                    if (dr["GVCLECTURACATUAL"] is DBNull)  throw new Exception("Falta ingresar la lectura actual");

                    if (dr["GVLECTURAANTERIOR"] is DBNull) throw new Exception("Falta ingresar la lectura anterior");
                   // if (Convert.ToDecimal(dr["GVCLECTURACATUAL"]) < Convert.ToDecimal(dr["GVLECTURAANTERIOR"])) throw new FaltaIngresoLecturaExcepciones();
                }
                else
                {
                    if (dr["COSTO"] is DBNull) throw new Exception("Debe ingresar la recuperación de gastos");
                }

            }
            ////se actualiza el costo desde la provision.
            foreach (DataRow dr in dt.Rows)
            {
                InfoGastosCV igcv = new InfoGastosCV();
                igcv.IdPropiedad = idPropiedad;
                igcv.Mes = mes;
                igcv.Ano = ano;
                igcv.CTVCodigo = (int)dr["CTVCODIGO"];
                igcv = Buscar(igcv);
                igcv.setCostoTotal(Convert.ToDecimal(dr["COSTO"]), Nomina.BuscarNomina(mes, ano).id);


                dr["COSTO"] = igcv.getCostoTotal();
            }
            dt.AcceptChanges();
            return dt;
        }
        public static List<InfoGastosCV> BuscarLista(int idPropiedad, int mes, int ano)
        {
            return Datos.GastosCV.BuscarLista(idPropiedad, mes, ano);
        }
        public static List<InfoGastosCV> BuscarListaHistoria(int idPropiedad, int anod, int mesd, int anoh, int mesh)
        {
            return Datos.GastosCV.BuscarListaHistoria(idPropiedad,anod,mesd,anoh,mesh);
        }
   
        public static String GetForEstadoCuenta(int idPropiedad, int mes, int ano, ref Int32 total,string templatePath, ref decimal tarifa)
        {
            try
            {
                StringBuilder result = new StringBuilder();

                List<InfoGastosCV> datos = BuscarLista(idPropiedad, mes, ano);
                foreach (InfoGastosCV cuenta in datos)
                {
                    total += Convert.ToInt32(cuenta.getCostoTotal());
                    cuenta.Deuda = Propietario.BuscarDeudaVarPorTipo(idPropiedad, cuenta.CTVCodigo);
                    total += Convert.ToInt32(cuenta.Deuda);
                    cuenta.FechaCorte = Propietario.BuscarFechaCorteDeudaVarPorTipo(idPropiedad, cuenta.CTVCodigo);
                    result.Append("<br/>");
                    result.Append(cuenta.GetHtml(templatePath,ref tarifa));
                    result.Append("<br/>");
                   
                }
                return result.ToString();
            }
            catch (Exception ex1)
            {
                throw new Exception("Error al generar la nota de cobro. Debe chequear que ha ingresado las lecturas correspondientes " + ex1.Message);
            }
        }

        public static List<InfoGastosCV> GetForExcel(int idPropiedad, int mes, int ano)
        {
            try
            {
                List<InfoGastosCV> datos = BuscarLista(idPropiedad, mes, ano);
                foreach (InfoGastosCV cuenta in datos)
                {
                        cuenta.Deuda = Propietario.BuscarDeudaVarPorTipo(idPropiedad, cuenta.CTVCodigo);
                        cuenta.FechaCorte = Propietario.BuscarFechaCorteDeudaVarPorTipo(idPropiedad, cuenta.CTVCodigo);
                }
                return datos;
            }
            catch (Exception ex1)
            {
                throw new Exception("Error datos para el Excel." + ex1.Message);
            }
        }
        public static DataTable Listar()
        {
            return Datos.GastosCV.Listar();
        }
        public static void Eliminar(InfoGastosCV infoGastoCV)
        {
            Datos.GastosCV.Eliminar(infoGastoCV);
        }
        public static DataTable ListarGVByRUTyFecha(string rut,int mes,int ano)
        {
            return Datos.GastosCV.ListarGVByIdGasto(rut,mes,ano);
        }

        public static void PonerPrimeraLectura(decimal priLectura, int idPropiedad, int codigo,decimal lecturaActual,DateTime fechaLectura)
        {
            if (priLectura <= lecturaActual)
            {
                DateTime tiempoPasado = DateTime.Now.AddMonths(-2);
                InfoGastosCV gastoV = new InfoGastosCV();
                gastoV.IdPropiedad = idPropiedad;
                gastoV.Mes = tiempoPasado.Month;
                gastoV.Ano = tiempoPasado.Year;
                gastoV.CTVCodigo = codigo;
                gastoV.GVLecturaActual = priLectura;
                gastoV.FechaPago = tiempoPasado;
                gastoV.GVMontoCancelado = 0;
                gastoV.GVMontoFijo = 0;
                gastoV.GVFechaVto = DateTime.Now;
                gastoV.GVLecturaAnterior = 0;
                gastoV.GVFechaLectura = fechaLectura;
                Datos.GastosCV.PonerPrimeraLectura(gastoV);
            }
            else
                throw new Exception("La lectura actual debe ser mayor o igual que la anterior");

        }

        public static DataTable BuscarDetallePagos(int idPropiedad, int mes, int ano, int codigo)
        {
            DataTable dt = new DataTable();
            dt = Datos.GastosCV.BuscarDetallePagos(idPropiedad, mes, ano, codigo);
            return dt;
        }
        public static void EliminarDetalle(int NumMov)
        {
            Datos.GastosCV.EliminarDetalle(NumMov);
        }
        public static void BorrarLecturas(int mes, int ano, int codigo)
        {
            Datos.GastosCV.BorrarLecturas(mes, ano, codigo);
        }

        public static decimal LecturaAnterior(int idprop, int mesactual, int ano, int codigo)
        {
            return Datos.GastosCV.LecturaAnterior(idprop, mesactual, ano, codigo);
        }

        static public void ActualizarLecturasFromCSV(String filename,int ano,int mes,int codigo, ref int CantidadProcesadas, ref int CantidadMalas, ref StringBuilder error)
        {
            TextReader reader = new StreamReader(filename);
            CantidadProcesadas = 0;
            AppSettingsReader appSettReader = new AppSettingsReader();
            string sep = appSettReader.GetValue("separadorCSV", typeof(string)).ToString();
            
            try
            {
                String line = "";
                line = reader.ReadLine();//sacar los nombres de columnas
                if (line.Split(sep[0])[0].ToUpper() != "IDPROPIEDAD") error.Append("En la primera linea el primer elemento debe ser 'IDPROPIEDAD'<br>");
                if (line.Split(sep[0])[5].ToUpper() != "LECTURA ANTERIOR") error.Append("En la primera linea el sexto elemento debe ser 'LECTURA ANTERIOR'<br>");
                if (line.Split(sep[0])[6].ToUpper() != "LECTURA ACTUAL") error.Append("En la primera linea el séptimo elemento debe ser 'LECTURA ACTUAL'<br>");
                if (line.Split(sep[0])[7].ToUpper() != "FECHA LECTURA") error.Append("En la primera linea el octavo elemento debe ser 'FECHA LECTURA'<br>");
                
                int i = 1;
                while ((line = reader.ReadLine())!=null)
                {
                    i++;
                    int idprop;
               //     decimal lectAnterior;
                    decimal lectActual;
                    DateTime fechLec;
                  //  bool HayErrorLecturaAnterior = false;
                    if (line != "" && line.Split(sep[0]).Length == 8)
                    {
                        string[] arr = line.Split(sep[0]);
                        arr[6] = arr[6] == "" ? 0.ToString() : arr[6];
                        if (int.TryParse(arr[0], out idprop) /*&& decimal.TryParse(arr[5], out lectAnterior)*/&& decimal.TryParse(arr[6], out lectActual) && DateTime.TryParse(arr[7], out fechLec))
                        {
                            try
                            {

                                if (LecturaAnterior(idprop, mes, ano, codigo) == 0)
                                {
                                    CantidadMalas++;
                                    error.Append("Linea:" + i.ToString() + " -> IDPROPIEDAD: " + idprop + " -> Debe poner a mano la lectura anterior.<br>");

                                }
                                //if (lectAnterior == 0)
                                //{
                                //    Aurora.Clases.Negocio.GastosCV.PonerPrimeraLectura(lectAnterior, idprop, codigo, lectActual, fechLec);
                                //}
                              
                                if (lectActual >= LecturaAnterior(idprop, mes, ano, codigo))
                                {
                                    Datos.GastosCV.ActualizarLecturaActual(mes, ano, codigo, idprop, lectActual, fechLec);
                                    CantidadProcesadas++;
                                }
                                else
                                {
                                    CantidadMalas++;
                                    error.Append("Linea:" + i.ToString() + " -> IDPROPIEDAD: " + idprop + " -> La lectura actual es menor que la anterior.<br>");
                                }
                                
                            }
                            catch (Exception e)
                            {
                                CantidadMalas++;
                                error.Append("Linea:" + i.ToString() + " -> IDPROPIEDAD: " + idprop + " -> No se pudieron actualizar los datos. Revisar lectura anterior y lectura actual<br>" + e.Message);
                            }
                        }
                        else
                        {
                           CantidadMalas++;
                           error.Append("Linea:" + i.ToString() + " ->  tiene problemas en idpropiedad ó lectura actual ó fecha de lectura.<br>");
                        }
                     }
                    else
                    {
                       CantidadMalas++;
                       error.Append("Linea:" + i.ToString() + " no cumple con el formato correcto.<br>");
                    }
                 }
                reader.Close();
              
            }
            catch (Exception e)
            {
                reader.Close();
                throw e;
            }
        }



        public static InfoGastoCVConPagos BuscarGastoCVconPagos(int idPropiedad, int mes, int ano, int codigo)
        {
            return Datos.GastosCV.BuscarGastoCVconPagos(idPropiedad, mes, ano, codigo);
        }
    
    }
}



