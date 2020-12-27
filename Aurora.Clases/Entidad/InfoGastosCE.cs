using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public class InfoGastosCE
    {
       public int IdPropiedad;
       public int Ano;
       public int Mes;
       public int CteCodigo=0;
	   public decimal GCEMontoCuota=0;
	   public decimal GCEMontoCancelado =0;
	   public DateTime FechaPago=DateTime.Today ;
       public FormaPago FormadePago = FormaPago.Indefinido;
       public bool DescontarCte = false;
       public decimal Deuda = 0;
       public decimal SaldoPendiente = 0;
       public int CantidadCuotas = 0;
       public int NumCuotasPagadas = 0;
       public int CuotaActual = 0;
       public string DescripcionCuenta = string.Empty;

       public string GetHtmlRow()
       {


           StringBuilder Table = new StringBuilder("<tr><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><@TIPO></td><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"><@PENDIENTE></div></td><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"><@PACTADAS></div></td><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><div align=\"right\"><@ACTUAL></div></td><td style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><@TOTAL></td></tr>");
           Table.Replace("<@TIPO>", DescripcionCuenta).Replace("<@PENDIENTE>", SaldoPendiente.ToString("0,00")).Replace("<@PACTADAS>", CantidadCuotas.ToString()).Replace("<@ACTUAL>", CuotaActual.ToString()).Replace("<@TOTAL>", GCEMontoCuota.ToString("0,0.00"));
           return Table.ToString();
       }

    }
}
