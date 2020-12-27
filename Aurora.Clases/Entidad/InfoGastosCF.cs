using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public class InfoGastosCF
    {
       public int IdPropiedad;
       public int Mes;
       public int Ano;
       public int CFCodigo=0;
	   public decimal GCFMonto=0;
	   public decimal GCFMontoCancelado =0;
       public int TipoCuenta = 0;
       public FormaPago FormadePago = FormaPago.Indefinido;
	   public DateTime FechaPago = DateTime.Today;
       public bool DescontarCte = false;
       public decimal Deuda = 0;
       public decimal ValorUF = 0;
       public bool Flag = false;
       public DateTime FechaCheque = DateTime.MinValue;
       public InfoHistorialPagoCuenta Pagos =new InfoHistorialPagoCuenta();
       public String Descripcion;
       public string GetHtmlTableRow()
       {
           String Row = "<tr align=\"center\">" +
               "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><@TIPO></td>" +
               "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"></td>" +
               "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"><@COUTA></div></td>" +
               "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"><@CARGO></div></td>" +
               "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"><@DEUDA></div></td>" +
               "<td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"><@TOTALAPAGAR></div></td>" +
               "</tr>";
           StringBuilder tableRow = new StringBuilder(Row);
           if (TipoCuenta <= 3)
           {
               tableRow.Replace("<@TIPO>", ((TipoCuentaFija)CFCodigo).ToString());
           }
           else
           {
               tableRow.Replace("<@TIPO>", Descripcion);
           }
           tableRow.Replace("<@COUTA>", GCFMonto.ToString("0.00")).Replace("<@CARGO>", Convert.ToInt32((ValorUF * GCFMonto)).ToString("0,0")).Replace("<@DEUDA>", Deuda.ToString("0,0")).Replace("<@TOTALAPAGAR>", Convert.ToInt32((Deuda + (ValorUF * GCFMonto))).ToString("0,0")).Replace("<@MONTO>", GCFMonto.ToString("0,0.00"));
           return tableRow.ToString();
       }
   }
    public enum FormaPago
    {
        Efectivo =0,
        ChequeFecha =1,
        ValeVista =2,
        DesdeCCte =3,
        Deuda=4,
        Transferencia=10,
        Indefinido =100
    }
    
}
