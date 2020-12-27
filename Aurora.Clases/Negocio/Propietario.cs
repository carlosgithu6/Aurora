using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Negocio
{
   public class Propietario
   {
       public static InfoPropietario Crear(InfoPropietario infoProp)
       {
           InfoPropietario Prop = Buscar(infoProp.IdPropiedad);
           if (Prop == null)
           {
               Prop = Datos.Propietario.Crear(infoProp);
               
               List<InfoCuentaFija> listaCuentasF = CuentaFija.Lista(false);
               foreach (InfoCuentaFija cuenta in listaCuentasF)
               {
                   InfoCuentaFijaPropietario asoc = new InfoCuentaFijaPropietario();
                   asoc.TarifaEspecial = -1;
                   asoc.IdPropiedad = Prop.IdPropiedad;
                   asoc.IdCuentaFija = cuenta.Codigo;
                   CuentaFija.AsociarPropietario(asoc);
               }

               List<InfoCuentaVariable> listaCuentasV = CuentaVariable.Lista(false);
               foreach (InfoCuentaVariable cuenta in listaCuentasV)
               {
                   InfoCuentaVarPropietario asoc = new InfoCuentaVarPropietario();
                   asoc.TarifaEspecial = -1;
                   asoc.IdPropiedad = Prop.IdPropiedad;
                   asoc.IdCuentaVar = cuenta.CtvCodigo;
                   CuentaVariable.AsociarPropietario(asoc);
               }
               return Prop;
           }
           else
           {
               if (Prop.Eliminado)
               {
                   Prop = infoProp;
                   Prop.Eliminado = false;
                   Datos.Propietario.Modificar(Prop);
                   return Buscar(infoProp.IdPropiedad);
               }
               else
               {
                   throw new Exception(" Ya existe el propietario!");
               }
           }
       }
       public static void Modificar(InfoPropietario infoProp)
       {
           Datos.Propietario.Modificar(infoProp);
       }
       public static InfoPropietario Buscar(int idPropiedad)
       {
           return Datos.Propietario.Buscar(idPropiedad);
       }
       public static DataTable Listar(bool eliminados,bool activos)
       {
           return Datos.Propietario.Listar(eliminados, activos);
       }
       public static List<InfoItem> List(bool eliminados, bool activos)
       {
           return Datos.Propietario.List(eliminados, activos);
       }
       public static DataTable ListarDeudaInicial(bool eliminados)
       {
          return Datos.Propietario.ListarDeudaInicial(eliminados);
       }
       public static void Eliminar(int idPropiedad)
       {
           Datos.Propietario.Eliminar(idPropiedad);
       }
       public static DataTable BuscarCuentasFijas(InfoPropietario infoProp)
       {
          return Datos.Propietario.BuscarCuentasFijas(infoProp);
       }
       public static DataTable BuscarCuentasVariables(InfoPropietario infoProp)
       {
           return Datos.Propietario.BuscarCuentasVariables(infoProp);
       }
       public static void AbonarACuentaCorriente(InfoPropietario infoProp, decimal monto,bool pagando)
       {
           if (monto < 0 && !pagando) throw new Exception("Error. Intenta realizar un abono negativo a su cuenta. Los abonos deben ser positivos.");
               Datos.Propietario.AbonarACuentaCorriente(infoProp, monto);
           
              
       }
       public static void PagarDeuda(InfoPropietario infoProp, decimal monto, bool descontarCte)
       {
           if (infoProp.DeudaPendiente < monto)
               throw new Exception("Está intentando pagar más de lo que realmente debe.");
           if(monto>=0)
               Datos.Propietario.PagarDeuda(infoProp, monto, descontarCte);
           else
               throw new Exception("Error. Intenta pagar deuda con un monto menor que cero.");

       }
       public static void PonerDeudaInicial(InfoPropietario infoProp, decimal monto)
       {
           if(monto>0)
            Datos.Propietario.PonerDeudaInicial(infoProp, monto);
       }
 
       public static void ActualizarDeudasAcumuladas(int idPropiedad)
       {
           try
           {
               PonerDeudasACero(idPropiedad);// esto garantiza que no se pongan deudas de más!!!!!
               List<InfoGastosCFDeuda> deudasFijas = Datos.Propietario.DeudasCuentasFijas(idPropiedad);
               List<InfoGastosCVDeuda> deudasVariables = Datos.Propietario.DeudasCuentasVariables(idPropiedad);
               foreach (InfoGastosCFDeuda item in deudasFijas)
               {
                   CuentaFija.ActualizarDeudaPropietario(item.IdPropiedad, item.CFCodigo, item.Deuda);
               }
               foreach (InfoGastosCVDeuda item in deudasVariables)
               {
                   CuentaVariable.ActualizarDeudaPropietario(item.IdPropiedad, item.CTVCodigo, item.Deuda);
               }
           }
           catch (Exception excepcion)
           {
               throw excepcion;
           }
       }
       public static void PagarDeudaDeCuentas(int IdPropiedad,decimal DeudaCFija, decimal DeudaCVariable)
       {
           decimal suma1 = DeudaCuentasFijas(IdPropiedad);
           decimal suma2 = DeudaCuentasVariables(IdPropiedad);
           if (DeudaCFija != 0 && suma1 != DeudaCFija) throw new Exception("Debe pagar las deudas de cuentas  Fijas completamente");
           if (DeudaCVariable != 0 && suma2 != DeudaCVariable) throw new Exception("Debe pagar las deudas de cuentas  variables completamente");
     
           Datos.Propietario.PagarDeudaDeCuentas(IdPropiedad, DeudaCFija, DeudaCVariable);   
     
       }
       public static DataTable ListarMorosos(bool eliminados, bool activos)
       {
           return Datos.Propietario.ListarMorosos(eliminados, activos);
       }
       public static int DeudaCuentasFijas(int idPropiedad)
       {
           return (int)Datos.Propietario.DeudaCuentasFijas(idPropiedad);
       }
       public static int DeudaCuentasVariables(int idPropiedad)
       {
           return (int)Datos.Propietario.DeudaCuentasVariables(idPropiedad);
       }
       public static int BuscarDeudaFijaPorTipo(int idPropiedad, int codigo)
       {
           return (int)Datos.Propietario.BuscarDeudaFijaPorTipo(idPropiedad, codigo);
       }
       public static decimal BuscarDeudaVarPorTipo(int idPropiedad, int codigo)
       {
           return Datos.Propietario.BuscarDeudaVarPorTipo(idPropiedad,codigo);
       }
       public static DateTime BuscarFechaCorteDeudaVarPorTipo(int idPropiedad, int codigo)
       {
           DateTime primeraFechaDeuda = Datos.Propietario.BuscarPrimeraFechaDeudaVarPorTipo(idPropiedad, codigo);

           DateTime mesActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
   
           
           if (primeraFechaDeuda != DateTime.MinValue && mesActual.Subtract(primeraFechaDeuda).Days >= 90)
           {
               return Datos.Propietario.ProximoDiaHabil(mesActual);
              
           }

            return DateTime.MinValue;       
        
       }
       public static DateTime BuscarFechaCorteDeudaFijaPorTipo(int idPropiedad, int codigo)
       {
           return Datos.Propietario.BuscarFechaCorteDeudaFijaPorTipo(idPropiedad, codigo);
       }
       public static void RegenerarNominaActual(int idPropiedad)
       {
           InfoNomina nomina = Aurora.Clases.Negocio.Nomina.BuscarNominaAbierta();
           if (nomina == null)  throw new Exception("No puede regenerar la nómina actual para el propietario ya que esta no ha sido generada.");
           if (nomina.FechaCierre != DateTime.MinValue) throw new Exception("No puede regenerar la nómina actual ya que la misma está cerrada.");
             Aurora.Clases.Datos.Nomina.GenerarNomina(idPropiedad,nomina.mes,nomina.ano );
       }
       public static void EliminarUltimoAbono(int idPropiedad)
       {
           Datos.Propietario.EliminarUltimoAbono(idPropiedad);     
       }
       public static bool TieneCuentaFija(InfoPropietario prop, int codCuenta)
       {  
           DataTable dt = BuscarCuentasFijas(prop);
           DataRow[] rows = dt.Select(("IDCUENTAFIJA =" +codCuenta.ToString()));
           if (rows.Length == 0) return false;
           return true;
           
       }
       public static bool TieneCuentaVariable(InfoPropietario prop, int codCuenta)
       {
           DataTable dt = BuscarCuentasVariables(prop);
           DataRow[] rows = dt.Select(("CTVCODIGO =" + codCuenta.ToString()));
           if (rows.Length == 0) return false;
           return true;
       }
       public static DataTable Cartola(int IdPropiedad)
       {
           return Datos.Propietario.Cartola_for_Excel(IdPropiedad);
       }
       private static void PonerDeudasACero(int idPropiedad)
       {
           Datos.Propietario.PonerDeudasACero(idPropiedad);
       }


       public static String GetNotadeCobro(int idpropiedad, int mes, int ano, string path)
       {
           #region template nota cobro
          
           string notaTemplatePath = path + "NotaCobroTemplate.txt";

           FileStream fs = new FileStream(notaTemplatePath, FileMode.Open, FileAccess.Read,
                                             FileShare.ReadWrite | FileShare.Delete);
           string content = String.Empty;

           using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
           {
               content = sr.ReadToEnd();
           }

           StringBuilder notacobro = new StringBuilder(content);

           
           #endregion  template nota cobro

           InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(idpropiedad);
           Int32 total = 0;
           decimal tarifa = 0;
           Base.Enums.Mes enumes = (Aurora.Clases.Base.Enums.Mes) mes;
           notacobro.Replace("<@SALDOCTACTE>", "$ " + prop.SaldoCuentaCte.ToString("0,0.00"));
           notacobro.Replace("<@MES>", enumes.ToString().ToUpper());
           notacobro.Replace("<@ANO>", ano.ToString());
           notacobro.Replace("<@CODIGOASOCIADO>", prop.IdPropiedad.ToString());
           notacobro.Replace("<@NOMBRE>", prop.NombreCompleto);
           notacobro.Replace("<@RUT>", prop.Rut);
           notacobro.Replace("<@PARCELA>", prop.NombrePropiedad);
           notacobro.Replace("<@EMAIL>", prop.Mail);
           notacobro.Replace("<@ESSOCIO>", prop.EsSocio ? "SI" : "NO");
           notacobro.Replace("<@CUENTASVARIABLES>", Aurora.Clases.Negocio.GastosCV.GetForEstadoCuenta(prop.IdPropiedad, mes, ano, ref total, path, ref tarifa));
           notacobro.Replace("<@CUENTASFIJAS>", Aurora.Clases.Negocio.GastosCF.GetForEstadoCuenta(prop.IdPropiedad, mes, ano, ref total));
           total += (int)prop.DeudaPendiente;
           notacobro.Replace("<@DEUDAINICIAL>", prop.DeudaPendiente.ToString("0,0.00"));
           notacobro.Replace("<@CUENTASFIJASOTROSGASTOS>", Aurora.Clases.Negocio.GastosCF.GetForEstadoCuentaOtrosGastos(prop.IdPropiedad, mes, ano, ref total));
           notacobro.Replace("<@CUENTASESPECIALES>", Aurora.Clases.Negocio.GastosCE.GetForEstadoCuenta(prop.IdPropiedad, mes, ano, ref total));
           notacobro.Replace("<@tramo1>", (tarifa).ToString("0,0.00"));
           notacobro.Replace("<@tramo2>", (tarifa*(decimal)1.25).ToString("0,0.00"));
           notacobro.Replace("<@tramo3>", (tarifa * (decimal)1.5).ToString("0,0.00"));
           notacobro.Replace("<@tramo4>", (tarifa * (decimal)2).ToString("0,0.00")); 
           notacobro.Replace("<@tramo0>", (tarifa * (decimal)10).ToString("0,0.00")); 

           //******Calculo de la fecha de vencimiento******//
           DateTime dia = new DateTime(ano, mes, 25);
           DateTime dia2 = dia.AddMonths(1);
           DateTime habil = Aurora.Clases.Negocio.Propietario.ProximoDiaHabil(dia2);
           //************************//
           notacobro.Replace("<@FECHAVENC>", habil.Day+"/"+habil.Month+"/"+habil.Year);
           notacobro.Replace("<@MONTOTAL>", total.ToString("0,0.00"));
           if (Clases.Negocio.Propietario.DeudaCuentasFijas(prop.IdPropiedad) == 0 || Clases.Negocio.Propietario.DeudaCuentasVariables(prop.IdPropiedad) == 0)
               notacobro.Replace("<tr align=\"center\"><td colspan=\"4\" style=\"border-color:#FFFFFF; font-size:14px\"><strong>Le solicitamos acercarse a la administración a los efectos de regularizar su deuda</strong></td></tr>"  , "");
           String msg = Nomina.BuscarMsg(mes,ano);
           if (msg != String.Empty){
               
               String row = "<tr><td colspan=\"4\" style=\"border-color:#FFFFFF; font-size:16px\">";
               row += "<strong>"+msg+"</strong>";
               row += "</td></tr>";
               notacobro.Replace("<@MENSAJE>", row);
           }
           else notacobro.Replace("<@MENSAJE>",String.Empty);

           return notacobro.ToString();

       }
       public static DateTime ProximoDiaHabil(DateTime dia) {
           return Datos.Propietario.ProximoDiaHabil(dia);
       }
       public static DataTable PropietariosSinConLectaraActualEnLuzOAgua(int mes, int ano, int sinLectura)
       {
           return Datos.Propietario.PropietariosSinConLectaraActualEnLuzOAgua(mes, ano, sinLectura);
       }

       public static DataTable MailEnviados(int mes, int ano)
       {
           return Datos.Propietario.MailEnviados( mes, ano);
       }

       public static int RegistrarMail(int idprop,int mes, int ano)
       {
           return Datos.Propietario.RegistrarMail(idprop, mes, ano);
       }
       public static void BorrarMail(int idprop, int mes, int ano)
       {
           Datos.Propietario.BorrarMail( idprop, mes, ano);
       }
       public static List<InfoPagoSimple> BuscarPagos(int idprop, int mes, int ano)
       {
          return  Datos.Propietario.BuscarPagos(idprop, mes, ano);
       }
       public static Dictionary<int, InfoPagoSimple> BuscarPagos(int idprop, int mes, int ano, int codigo)
       {
           return Datos.Propietario.BuscarPagos(idprop, mes, ano, codigo);
       }
       public static String GetRecibo(int idpropiedad,int mes, int ano,string path)
       {
           StringBuilder recibo = new StringBuilder();
           decimal total = getTotalCuentas(idpropiedad, mes, ano);
           List<InfoPagoSimple> pagos = Datos.Propietario.BuscarPagos(idpropiedad, mes, ano);
           if (pagos.Count > 0)
           {
               #region template recibo

               string reciboTemplatePath = path + "Recibo.txt";

               FileStream fs = new FileStream(reciboTemplatePath, FileMode.Open, FileAccess.Read,
                                                 FileShare.ReadWrite | FileShare.Delete);
               string content = String.Empty;

               using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
               {
                   content = sr.ReadToEnd();
               }

               recibo.Append(content);

               #endregion  template nota cobro

               InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(idpropiedad);
               Base.Enums.Mes enumes = (Aurora.Clases.Base.Enums.Mes)mes;
               recibo.Replace("<@PROPIETARIO>", prop.NombreCompleto);
               recibo.Replace("<@PARCELA>", prop.NumeroParcela.ToString());
               recibo.Replace("<@SECTOR>", prop.Sector);
               recibo.Replace("<@LETRA>", prop.LetraParcela);



               StringBuilder tabla = new StringBuilder("<table cellspacing='3'>");
               tabla.Append("<tr><td><u><b><i>Concepto</i></b></u></td><td><u><b><i>Monto</i></b></u></td><td><u><b><i>Fecha de Pago</i></b></u></td><td><u><b><i>Forma de Pago</i></b></u></td></tr>");
               decimal monto = 0;
               foreach (InfoPagoSimple item in pagos)
               {
                   StringBuilder row = new StringBuilder("<tr><td>$C</td><td>$M</td><td>$F</td><td>$P</td></tr>");
                   row.Replace("$C", item.concepto);
                   row.Replace("$M", Math.Round(item.submonto, 0).ToString("0,0.00"));
                   row.Replace("$F", item.fechaPago.Day + "-" + item.fechaPago.Month.ToString() + "-" + item.fechaPago.Year.ToString());
                   row.Replace("$P", item.formaPago.ToString());
                   tabla.Append(row.ToString());
                   monto += item.submonto;
               }
               tabla.Append("</table>");
               recibo.Replace("<@CONCEPTOS>", tabla.ToString());
               recibo.Replace("<@MONTO>", Math.Round(monto, 0).ToString("0,0.00"));
               recibo.Replace("<@MONTOLETRA>", Negocio.NumeroToTexto.ToText((int)Math.Round(monto,0)));
               recibo.Replace("<@MES>", enumes.ToString()).Replace("<@ANO>", ano.ToString());
               if (Math.Round(total,0)>0)
                   recibo.Replace("<@PARCIAL>", "(Pago Parcial)");
               else recibo.Replace("<@PARCIAL>", "");
           }
           else
           {
               recibo.Append("No se encontraron pagos realizados o ya fue emitido el recibo");
           }
           return recibo.ToString();

       }

       public static void SellarRecibo(int idpropiedad, int mes, int ano,int folio)
       {
           Aurora.Clases.Datos.Propietario.SellarRecibo(idpropiedad, mes, ano,folio);
       }
       static public decimal getTotalCuentas(int idprop,int mes, int ano)
       {
           Decimal total = 0;
           List<InfoGastosCF> listaCF = Aurora.Clases.Negocio.GastosCF.BuscarLista(idprop, mes, ano);
           List<InfoGastosCV> listaCV = Aurora.Clases.Negocio.GastosCV.BuscarLista(idprop, mes, ano);
           foreach (InfoGastosCF item in listaCF)
           {  
               decimal uf = UF.Buscar(item.Mes, item.Ano).UF;
               decimal costo = Math.Round(item.GCFMonto * uf, 0);
               if (costo > item.GCFMontoCancelado)
               {
                   total = total + costo - item.GCFMontoCancelado;
               }
           }
           foreach (InfoGastosCV item in listaCV)
           {
               if (!item.flag && item.getCostoTotal() > item.GVMontoCancelado) //no es un item que sea pasado
               {
                   total = total + item.getCostoTotal() - item.GVMontoCancelado;                   
               }
           }
           return total;
       }
       public static DataTable ListarConsumo()
       {
           return Datos.Propietario.ListarConsumo();
       }
   }
}
