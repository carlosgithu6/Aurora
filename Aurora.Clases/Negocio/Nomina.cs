using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Negocio
{
   public class Nomina
   {
      
       public static bool GenerarNomina(int mes, int ano)
       {
           DataTable propietarios;
          
           try
           {
               if (Aurora.Clases.Negocio.Nomina.BuscarNomina(mes, ano) == null)
               {
                   if (!EstaAnteriorCerrada(mes,ano)) throw new ExcepcionNomina("Debe cerrar la nómina anterior.",new DateTime(DateTime.Now.AddMonths(-1).Year,DateTime.Now.AddMonths(-1).Month,1));
                   propietarios = Propietario.Listar(false, true);
                   if (UF.Buscar(mes, ano) == null) throw new ExcepcionNomina("Debe crearse la UF correspondiente a esta nómina.", new DateTime(ano, mes, 1));
                   foreach (DataRow prop in propietarios.Rows)
                   {
                       Datos.Nomina.GenerarNomina(Convert.ToInt16(prop["IDPROPIEDAD"]), mes, ano);
                   }
                   PonerNominaActiva(mes, ano);
                   return true;
               }
               throw new Exception("La nomona que se quiere crear ya existe");
           }
           catch (ExcepcionNomina ex)
           {
               throw ex;
           }
           catch (Exception ex1)
           {
               throw ex1;
           }
       }
       public static InfoNomina BuscarNomina(int mes, int ano)
       {
           return Datos.Nomina.BuscarNomina(mes, ano);
       }
       public static InfoNomina BuscarNomina_ID(int id_nomina)
       {
           return Datos.Nomina.BuscarNomina_ID(id_nomina);
       }
       public static InfoNomina BuscarNominaAbierta()
       {
           return Datos.Nomina.BuscarNominaAbierta();
       }
       public static bool ExisteNominaActual()
       {
           return Datos.Nomina.ExisteNominaActual();
       }
       static void PonerNominaActiva(int mes, int ano)
       {
           Datos.Nomina.PonerNominaActiva(mes, ano);
       }
       public static void CerrarNominaActiva(int mes, int ano)
       {
           DataTable propietarios;
           propietarios = Propietario.Listar(false, true);

           try
           {
              
               foreach (DataRow prop in propietarios.Rows)
               {
                   Propietario.ActualizarDeudasAcumuladas(Convert.ToInt16(prop["IDPROPIEDAD"]));
               }
               Datos.Nomina.CerrarNominaActiva(mes, ano);
           }
           catch (Exception ex1)
           {
               throw ex1;
           }
       }
       public static bool EstaAnteriorCerrada(int mes, int ano)
       {
           DateTime dt = new DateTime(ano, mes, 25);
           InfoNomina nomina = BuscarNomina(dt.AddMonths(-1).Month, dt.AddMonths(-1).Year);
           if (nomina == null) return true;
           return (nomina.FechaCierre != DateTime.MinValue);
          
       }
       public static bool EstaCerrada(int mes, int ano)
       {
           InfoNomina nomina = BuscarNomina(mes, ano);
           return (nomina.FechaCierre == DateTime.MinValue ? false : true);

       }
       public static Mes NominaACrear()
       {
           return ((Mes)DateTime.Now.AddMonths(-1).Month);
       }
  
       public static bool HayQueCerrarNominaActual()
       {
           InfoNomina nominaAnterior = BuscarNomina(DateTime.Now.AddMonths(-2).Month, DateTime.Now.AddMonths(-2).Year);
           InfoNomina nominaActual = BuscarNomina(DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year);
           return ((nominaAnterior != null && nominaAnterior.FechaCierre == Convert.ToDateTime("01-01-1900")) || (nominaActual != null && nominaActual.FechaCierre == Convert.ToDateTime("01-01-1900")));           
       }
     
       public static DataTable BuscarIngresosRealesPorFechasPago(DateTime desde, DateTime hasta)
       {
           DataTable dt = Datos.Nomina.BuscarIngresosRealesPorFechasPago(desde, hasta);
          
           foreach (DataRow row in dt.Rows)
           {
                InfoCuentaVariable ifv = Negocio.CuentaVariable.Buscar(Convert.ToInt32(row["CODIGOCUENTA"]));
                if (Convert.ToString(row["TIPO"])=="V" && ifv != null && ifv.CtvTipo==TipoCuentaVariable.Agua)
                 {

                         Int32 INGRESO_200M3 = 0;
                         Int32 INGRESO_201_300M3 = 0;
                         Int32 INGRESO_301_500M3 = 0;
                         Int32 INGRESO_501M3_MAS = 0;
                       
                         InfoGastoCVConPagos igvp = GastosCV.BuscarGastoCVconPagos(Convert.ToInt32(row["IDPROPIEDAD"]), Convert.ToInt32(row["MES"]), Convert.ToInt32(row["ANO"]),ifv.CtvCodigo);
                         Int32[,] matrix = igvp.GetMatrizDistribucion();
                         int indexfila = igvp.GetIndexFilaSegunNumPago(ref matrix, Convert.ToInt32(row["NUMMOV1"]));

                         try { INGRESO_200M3 = matrix[indexfila, 1]; }
                         catch (Exception) { INGRESO_200M3 = 0; }

                         try { INGRESO_201_300M3 = matrix[indexfila, 2]; }
                         catch (Exception) { INGRESO_201_300M3 = 0; }

                         try { INGRESO_301_500M3 = matrix[indexfila, 3]; }
                         catch (Exception) { INGRESO_301_500M3 = 0; }

                         try { INGRESO_501M3_MAS = matrix[indexfila, 4]; }
                         catch (Exception) { INGRESO_501M3_MAS = 0; }
                     
                 
                         row["INGRESO_200M3"] = INGRESO_200M3;
                         row["INGRESO_201_300M3"] = INGRESO_201_300M3;
                         row["INGRESO_301_500M3"] = INGRESO_301_500M3;
                         row["INGRESO_501M3_MAS"] = INGRESO_501M3_MAS;
                     
                   }
              
           }
           dt.Columns.Remove("TIPO");
           dt.Columns.Remove("CODIGOCUENTA");
           dt.Columns.Remove("NUMMOV1");

           dt.AcceptChanges();
           return dt;
           
       }



       public static DataTable GetForExcel(int mes, int ano)
       {
           DataTable dt = new DataTable();
           dt.Columns.Add("ID", typeof(int));
           dt.Columns.Add("MES", typeof(int));
           dt.Columns.Add("ANO", typeof(int));
           dt.Columns.Add("RUT", typeof(String));
           dt.Columns.Add("SOCIO", typeof(String));
           dt.Columns.Add("NOMBRE", typeof(String));
           dt.Columns.Add("CONCEPTO", typeof(String));
           dt.Columns.Add("MONTO", typeof(Decimal));
           dt.Columns.Add("CARGO MES HASTA 200 M3", typeof(Decimal));
           dt.Columns.Add("PROVISION SOBRECONSUMO", typeof(Decimal));
           dt.Columns.Add("DEUDA", typeof(Decimal));

          DataTable props = Aurora.Clases.Negocio.Propietario.Listar(false,true);

           foreach (DataRow prop in props.Rows)
           {
               int idPropiedad = Convert.ToInt16(prop["IDPROPIEDAD"]);
               string rut = Convert.ToString(prop["RUT"]);
               List<InfoGastosCV> listaCV = Aurora.Clases.Negocio.GastosCV.GetForExcel(idPropiedad, mes, ano);
               foreach (InfoGastosCV item in listaCV)
               {
                   DataRow dr = dt.NewRow();
                   dr["ID"] = item.IdPropiedad;
                   dr["RUT"] = rut;
                   dr["NOMBRE"] = Propietario.Buscar(item.IdPropiedad).NombreCompleto;
                   dr["SOCIO"] = Propietario.Buscar(item.IdPropiedad).EsSocio == true ? "SI" : "NO";
                   dr["CONCEPTO"] = (TipoCuentaVariable)item.Tipo;
                   dr["MONTO"] = Convert.ToInt64(item.getCostoTotal());
                   dr["MES"] = mes;
                   dr["ANO"] = ano;
                   dr["DEUDA"] = Convert.ToInt64(item.Deuda);
                   if (item.Tipo == TipoCuentaVariable.Agua)
                   {
                       if (item.Anterior_a_Corte)
                       {
                           dr["CARGO MES HASTA 200 M3"] = Convert.ToInt64(item.getCostoTotal());
                           dr["PROVISION SOBRECONSUMO"] = 0;
                       }
                       else
                       {
                           if (item.Consumo == 0)
                           {
                               dr["CARGO MES HASTA 200 M3"] = Convert.ToInt64(item.getProvision()[TipoTramo.cero].getMonto());
                           }
                           else
                           {
                               dr["CARGO MES HASTA 200 M3"]= Convert.ToInt64(item.getProvision()[TipoTramo.hasta_200].getMonto());
                               dr["PROVISION SOBRECONSUMO"]= Convert.ToInt64(item.getProvisionSinHasta200());
                           }
                          
                       }
                    }
                       dt.Rows.Add(dr);
               }

               List<InfoGastosCF> listaCF = Aurora.Clases.Negocio.GastosCF.GetForExcel(idPropiedad, mes, ano);
               foreach (InfoGastosCF item in listaCF)
               {
                   DataRow dr = dt.NewRow();
                   dr["ID"] = item.IdPropiedad;
                   dr["RUT"] = rut;
                   dr["NOMBRE"] = Propietario.Buscar(item.IdPropiedad).NombreCompleto;
                   dr["SOCIO"] = Propietario.Buscar(item.IdPropiedad).EsSocio == true ? "SI" : "NO";
                   if (item.TipoCuenta <= 3)
                   {
                       dr["CONCEPTO"] = ((TipoCuentaFija)item.CFCodigo).ToString();
                   }
                   else
                   {
                       dr["CONCEPTO"] = item.Descripcion;
                   }
                   
                   dr["MONTO"] = Convert.ToInt32(item.GCFMonto * UF.Buscar(mes, ano).UF);
                   dr["MES"] = mes;
                   dr["ANO"] = ano;
                   dr["DEUDA"] = item.Deuda;
                   dt.Rows.Add(dr);
               }
               List<InfoGastosCE> listaCE = Aurora.Clases.Negocio.GastosCE.GetForExcel(idPropiedad, mes, ano);
               foreach (InfoGastosCE item in listaCE)
               {
                   DataRow dr = dt.NewRow();
                   dr["ID"] = item.IdPropiedad;
                   dr["RUT"] = rut;
                   dr["NOMBRE"] = Propietario.Buscar(item.IdPropiedad).NombreCompleto;
                   dr["SOCIO"] = Propietario.Buscar(item.IdPropiedad).EsSocio == true ? "SI" : "NO";
                   dr["CONCEPTO"] = item.DescripcionCuenta;
                   dr["MONTO"] = item.GCEMontoCuota;
                   dr["MES"] = mes;
                   dr["ANO"] = ano;
                   dr["DEUDA"] = item.Deuda;
                   dt.Rows.Add(dr);
               }
           }
           return dt;
       }

       public static DataTable Listar()
       {
           return Aurora.Clases.Datos.Nomina.Listar();
       }
       public static void ActualizarMsg(int Id, string msg)
       {
           Aurora.Clases.Datos.Nomina.ActualizarMsg(Id, msg);
       }
       public static String BuscarMsg(int mes, int ano)
       {
           return Aurora.Clases.Datos.Nomina.BuscarMsg(mes, ano);
       }
   }
   public class ExcepcionNomina:Exception
   {
       public ExcepcionNomina(DateTime fechaApertura): base()
       {
           FechaNomina = fechaApertura;
       }
       public ExcepcionNomina()
           : base()
       {
           
       }
       public ExcepcionNomina(string mensaje, DateTime fechaApertura)
           : base(mensaje)
       {
           FechaNomina = fechaApertura;
       }
       public DateTime FechaNomina;
   }
}
