using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
namespace Aurora.Clases.Entidad
{
    public class InfoGastosCV
    {
        public int IdPropiedad;
        public int Mes;
        public int Ano;
        public int CTVCodigo = 0;
        public TipoCuentaVariable Tipo;
        public decimal GVMontoFijo = 0;
        public decimal GVMontoCancelado = 0;
        public decimal GVLecturaAnterior = 0;
        public decimal GVLecturaActual = 0;
        public DateTime GVFechaVto;
        public DateTime GVFechaLectura;
        public DateTime FechaPago = DateTime.Today;
        public bool DescontarCte = false;
        public decimal LecturaCM = 0;
        public FormaPago FormadePago = FormaPago.Indefinido;
        private decimal CostoTotal = 0;
        public bool Trifasico = false;
        public decimal Deuda = 0;
        public decimal PrecioU = 0;
        public decimal Factor = 0;
        public DateTime FechaCheque = DateTime.MinValue;
        public DateTime FechaCorte = DateTime.MinValue;
        public decimal Consumo = 0;
        public String Medidor;
        public bool Anterior_a_Corte = false;
        public string GetHtml(string pathTemplate, ref decimal tarifa)
        {

            // decimal consumo = ((GVLecturaActual+LecturaCM)-GVLecturaAnterior);


            if (Tipo == TipoCuentaVariable.Electricidad)
            {
                #region Electricidad

                string luzTemplatePath = pathTemplate + "LuzTemplate.txt";

                FileStream fs = new FileStream(luzTemplatePath, FileMode.Open, FileAccess.Read,
                                                  FileShare.ReadWrite | FileShare.Delete);
                string content = String.Empty;

                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    content = sr.ReadToEnd();
                }
                StringBuilder tableToReplace = new StringBuilder(content);
                tableToReplace.Replace("<@TIPO>", Tipo.ToString())
               .Replace("<@MED>", Medidor)
               .Replace("<@LACT>", GVLecturaActual.ToString("0,0"))
               .Replace("<@LANT>", GVLecturaAnterior.ToString("0,0"))
               .Replace("<@CONSUMO>", Consumo.ToString("0,0"))
               .Replace("<@FECHALEC>", GVFechaLectura.ToString("dd/MM/yyyy"))
               .Replace("<@PUNITARIO>", PrecioU.ToString("0,0.00"))
               .Replace("<@MONTOFIJO>", GVMontoFijo.ToString("0,0"))
               .Replace("<@DEUDA>", Deuda.ToString("0,0"))
               .Replace("<@TOTAL>", (CostoTotal + Deuda).ToString("0,0"));
                decimal cargomes = 0;
                if (Consumo <= 100) { cargomes = CostoTotal; }
                else { cargomes = CostoTotal - GVMontoFijo; }


                tableToReplace.Replace("<@CARGOMES>", cargomes.ToString("0,0"));
                if (FechaCorte == DateTime.MinValue)
                {
                    tableToReplace.Replace("<td width=\"12%\" style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>FECHA<br/>CORTE</strong></td>", String.Empty);
                    tableToReplace.Replace("<td style=\" border-width:1px; border-style:solid; border-color:#000000;margin-left: auto; margin-right: auto\"><@FECHACORTE></td>", String.Empty);
                }
                else
                    tableToReplace.Replace("<@FECHACORTE>", FechaCorte.ToString("dd/MM/yyyy"));
                return tableToReplace.ToString();

                #endregion
            }
            else
                if (Tipo == TipoCuentaVariable.Agua)
                {

                    provisionar(Consumo, PrecioU);

                    #region Agua
                    string aguaTemplatePath = pathTemplate + "AguaTemplate.txt";

                    FileStream fs = new FileStream(aguaTemplatePath, FileMode.Open, FileAccess.Read,
                                                      FileShare.ReadWrite | FileShare.Delete);
                    string content = String.Empty;

                    using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                    {
                        content = sr.ReadToEnd();
                    }

                    StringBuilder tableToReplace = new StringBuilder(content);
                    tableToReplace.Replace("<@TIPO>", Tipo.ToString())
                   .Replace("<@MED>", Medidor)
                   .Replace("<@LACT>", GVLecturaActual.ToString("0,0"))
                   .Replace("<@LANT>", GVLecturaAnterior.ToString("0,0"))
                   .Replace("<@CONSUMO>", Consumo.ToString("0,0"))
                   .Replace("<@FECHALEC>", GVFechaLectura.ToString("dd/MM/yyyy"))
                   .Replace("<@PUNITARIO>", PrecioU.ToString("0,0.00"))
                   .Replace("<@MONTOFIJO>", GVMontoFijo.ToString("0,0"))
                   .Replace("<@DEUDA>", Deuda.ToString("0,0"));

                    if (Anterior_a_Corte)
                    {
                        tableToReplace.Replace("<@MONTOCARGO200>", getCostoTotal().ToString("0,0"));
                        tableToReplace.Replace("<@CARGOPROVISION>", "0");
                        tableToReplace.Replace("<@TOTAL>", (getCostoTotal() + Deuda).ToString("0,0"));
                        tableToReplace.Replace("CARGO MES HASTA 200 M3 ", "CARGO MES");
                    }
                    else
                    {
                        if (Consumo == 0)
                        {
                            tableToReplace.Replace("<@MONTOCARGO200>", provision[TipoTramo.cero].getMonto().ToString("0,0"));
                            tableToReplace.Replace("<@CARGOPROVISION>", "");
                        }
                        else
                        {
                            tableToReplace.Replace("<@MONTOCARGO200>", provision[TipoTramo.hasta_200].getMonto().ToString("0,0"));
                            tableToReplace.Replace("<@CARGOPROVISION>", getProvisionSinHasta200().ToString("0,0"));
                        }
                        tableToReplace.Replace("<@TOTAL>", (getTotalProvision() + Deuda).ToString("0,0"));
                    }
                    tarifa = PrecioU;
                    decimal cargomes = CostoTotal - GVMontoFijo;
                    tableToReplace.Replace("<@CARGOMES>", cargomes.ToString("0,0"));

                    if (FechaCorte == DateTime.MinValue)
                    {
                        tableToReplace.Replace("<td width=\"12%\" style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>FECHA<br/>CORTE</strong></td>", String.Empty);
                        tableToReplace.Replace("<td style=\" border-width:1px; border-style:solid; border-color:#000000;margin-left: auto; margin-right: auto\"><@FECHACORTE></td>", String.Empty);
                    }
                    else
                        tableToReplace.Replace("<@FECHACORTE>", FechaCorte.ToString("dd/MM/yyyy"));
                    return tableToReplace.ToString();

                    #endregion
                }
                else
                {
                    #region otro sin Lectura
                    string aguaTemplatePath = pathTemplate + "OtrosTemplate.txt";

                    FileStream fs = new FileStream(aguaTemplatePath, FileMode.Open, FileAccess.Read,
                                                      FileShare.ReadWrite | FileShare.Delete);
                    string content = String.Empty;

                    using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                    {
                        content = sr.ReadToEnd();
                    }

                    StringBuilder tableToReplace = new StringBuilder(content);
                    tableToReplace.Replace("<@TIPO>", Negocio.CuentaVariable.Buscar(CTVCodigo).CtvDescripcion)
                   .Replace("<@MED>", Medidor)
                   .Replace("<@LACT>", GVLecturaActual.ToString("0,0"))
                   .Replace("<@LANT>", GVLecturaAnterior.ToString("0,0"))
                   .Replace("<@CONSUMO>", Consumo.ToString("0,0"))
                   .Replace("<@FECHALEC>", GVFechaLectura.ToString("dd/MM/yyyy"))
                   .Replace("<@PUNITARIO>", PrecioU.ToString("0,0.00"))
                   .Replace("<@MONTOFIJO>", GVMontoFijo.ToString("0,0"))
                   .Replace("<@DEUDA>", flag ? CostoTotal.ToString("0,0") : Deuda.ToString("0,0"))
                   .Replace("<@TOTAL>", (CostoTotal + Deuda).ToString("0,0"));
                    decimal cargomes = CostoTotal - GVMontoFijo;
                    tableToReplace.Replace("<@CARGOMES>", flag ? "" : cargomes.ToString("0,0"));
                    tableToReplace.Replace("(M3)", "");
                    tableToReplace.Replace("(UF)", "($)");
                    if (FechaCorte == DateTime.MinValue)
                    {
                        tableToReplace.Replace("<td width=\"12%\" style=\" border-width:1px; border-style:solid; border-color:#000000; margin-left: auto; margin-right: auto\"><strong>FECHA<br/>CORTE</strong></td>", String.Empty);
                        tableToReplace.Replace("<td style=\" border-width:1px; border-style:solid; border-color:#000000;margin-left: auto; margin-right: auto\"><@FECHACORTE></td>", String.Empty);
                    }
                    else
                        tableToReplace.Replace("<@FECHACORTE>", FechaCorte.ToString("dd/MM/yyyy"));
                    return tableToReplace.ToString();

                    #endregion
                    //StringBuilder table = new StringBuilder("<table width='550px' border='1' cellspacing='0' cellpadding='0'><tr><td width='90'><b><@TIPO></b></td><td width='107' align='center'>Valor Consumo<br/></td><td width='58'>Monto Fijo </td><td width='40'>Deuda</td><td width='39'>Total</td></tr><tr><td></td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td><@CONSUMO101></td><td><@MONTOFIJO></td><td><@DEUDA></td><td><@TOTAL></td></tr></table>");
                    //table.Replace("<@TIPO>", Tipo.ToString() + "(P.Unitario)" + PrecioU.ToString("0,0")+ "<br/>" +( (flag)? "-INACTIVA-" : "")).Replace("<@LACT>", GVLecturaActual.ToString("0,0")).Replace("<@LANT>", GVLecturaAnterior.ToString("0,0")).Replace("<@CONSUMO>", consumo.ToString("0,0")).Replace("<@CONSUMO100>", (consumo <= 100 && (TipoCuentaVariable)CTVCodigo == TipoCuentaVariable.Electricidad) ? CostoTotal.ToString("0,0") : "").Replace("<@CONSUMO101>", (consumo > 100) ? (CostoTotal - GVMontoFijo).ToString("0,0") : "").Replace("<@MONTOFIJO>", GVMontoFijo.ToString("0,0")).Replace("<@DEUDA>", Deuda.ToString("0,0")).Replace("<@TOTAL>", (CostoTotal + Deuda).ToString("0,0")).Replace("<@CONSUMO100>", (consumo <= 100) ? (100 * PrecioU).ToString("0,0") : "");
                    //return table.ToString();
                }
        }
        /// <summary>
        /// Este flag indica que es una cuenta que fue desactivada..
        /// </summary>
        public bool flag = false;
        private Dictionary<TipoTramo, ProvisionSobreConsumo> provision = new Dictionary<TipoTramo, ProvisionSobreConsumo>();
        public Dictionary<TipoTramo, ProvisionSobreConsumo> getProvision() { return provision; }
        private void provisionar(decimal consumo, decimal tarifa)
        {
            if (Tipo == TipoCuentaVariable.Agua)
            {
                provision.Clear();
                if (consumo > 500)
                {
                    provision.Add(TipoTramo.mas_de_500, new ProvisionSobreConsumo(TipoTramo.mas_de_500, consumo - 500, tarifa * (decimal)2.0));
                    provision.Add(TipoTramo.de_301_a_500, new ProvisionSobreConsumo(TipoTramo.de_301_a_500, 200, tarifa * (decimal)1.5));
                    provision.Add(TipoTramo.de_201_a_300, new ProvisionSobreConsumo(TipoTramo.de_201_a_300, 100, tarifa * (decimal)1.25));
                    provision.Add(TipoTramo.hasta_200, new ProvisionSobreConsumo(TipoTramo.hasta_200, 200, tarifa));
                    return;
                }
                if (consumo > 300)
                {
                    provision.Add(TipoTramo.de_301_a_500, new ProvisionSobreConsumo(TipoTramo.de_301_a_500, consumo - 300, tarifa * (decimal)1.5));
                    provision.Add(TipoTramo.de_201_a_300, new ProvisionSobreConsumo(TipoTramo.de_201_a_300, 100, tarifa * (decimal)1.25));
                    provision.Add(TipoTramo.hasta_200, new ProvisionSobreConsumo(TipoTramo.hasta_200, 200, tarifa));
                    return;
                }
                if (consumo > 200)
                {
                    provision.Add(TipoTramo.de_201_a_300, new ProvisionSobreConsumo(TipoTramo.de_201_a_300, consumo - 200, tarifa * (decimal)1.25));
                    provision.Add(TipoTramo.hasta_200, new ProvisionSobreConsumo(TipoTramo.hasta_200, 200, tarifa));
                    return;
                }
                if (consumo <= 200 && consumo > 0)
                {
                    provision.Add(TipoTramo.hasta_200, new ProvisionSobreConsumo(TipoTramo.hasta_200, consumo, tarifa));
                    return;
                }
                if (consumo == 0)
                {
                    provision.Add(TipoTramo.cero, new ProvisionSobreConsumo(TipoTramo.cero, 10, tarifa));
                    return;
                }
            }
            return;
        }
        public decimal getTotalProvision()
        {
            decimal total = 0;
            foreach (KeyValuePair<TipoTramo, ProvisionSobreConsumo> prov in provision)
            {
                total += prov.Value.getMonto();
            }
            return total;
        }
        public decimal getProvisionSinHasta200()
        {
            return (getTotalProvision() - provision[TipoTramo.hasta_200].getMonto());
        }
        public decimal getCostoTotal()
        {
            return CostoTotal;
        }
        public void setCostoTotal(decimal valor, int id_nomina)
        {
            AppSettingsReader appSettReader = new AppSettingsReader();
            int num_nomina_corte = (int)appSettReader.GetValue("NOMINA_de_CORTE", typeof(int));

            InfoNomina nomina_actual = Negocio.Nomina.BuscarNomina_ID(id_nomina);

            InfoNomina nomina_corte = Negocio.Nomina.BuscarNomina_ID(num_nomina_corte);

            if (Tipo == TipoCuentaVariable.Agua && nomina_actual.id > nomina_corte.id)//si la nomina correspondiente es mas nueva que la de corte
            {
                provisionar(this.Consumo, PrecioU);
                CostoTotal = getTotalProvision();
                Anterior_a_Corte = false;
            }
            else
            {
                CostoTotal = valor;
                Anterior_a_Corte = true;
            }
        }
    }



    public class InfoGastoCVConPagos : InfoGastosCV
    {
        public Int32 IngresoRealTotal;
        public Int32 IngresoRealhasta_200 = 0;
        public Int32 IngresoRealde_201_a_300 = 0;
        public Int32 IngresoRealde_301_a_500 = 0;
        public Int32 IngresoRealmas_de_500 = 0;
        public Int32 IngresoRealCero = 0;
        Int32[,] MatrizDistribucion;
        InfoPagoSimple[] pagos;
        ProvisionSobreConsumo[] provisiones;
        public Dictionary<int, InfoPagoSimple> pagosReales= new Dictionary<int, InfoPagoSimple>();


        public Int32 totalPagado()
        {
            Int32 total = 0;
            foreach (KeyValuePair<int, InfoPagoSimple> pago in pagosReales)
            {
                total = total + Convert.ToInt32(pagosReales[pago.Key].submonto);
            }
            return total;
        }
        void setPagos()
        {
            int i = 0;
            foreach (KeyValuePair<int, InfoPagoSimple> p in pagosReales)
            {
                pagos[i] = pagosReales[p.Key];
                i++;
            }
           
        }
        void setProvisiones()
        {
            int i = getProvision().Count-1;
            foreach (KeyValuePair<TipoTramo, ProvisionSobreConsumo> p in getProvision())
            {
                provisiones[i] = getProvision()[p.Key];
                i--;
            }
            
        }
        public Int32[,] GetMatrizDistribucion()
        {
            if (MatrizDistribucion == null) 
               throw new Exception("La Matriz no se ha creado aun");
            return MatrizDistribucion;
        }
        public int GetIndexFilaSegunNumPago(ref Int32[,] matrix,int numpago)
        {
            int index = 0;
            while (index < pagos.Length)
            {
                if (matrix[index,0] == numpago)
                {
                   
                    return index;
                }
                index++;
            }

            return -1;
        }
        void SetNumerosdePago(ref Int32[,] matrix)
        {
            //el la columna 0 estan los mnumeros de pago.
            for (int i = 0; i <= pagos.Length-1; i++)
            {
                matrix[i,0] = pagos[i].numpago;
               
            }
        }
        public void SetIngresosPorTramoParaCadaPago()
        {
            pagos = new InfoPagoSimple[pagosReales.Count];
            setPagos();
            provisiones = new ProvisionSobreConsumo[getProvision().Count];
            setProvisiones();
            MatrizDistribucion = new Int32[ pagosReales.Count,getProvision().Count+1];//se agrega una columna para poner el nunmero del pago.
            SetNumerosdePago(ref MatrizDistribucion);
            for (int i = 0; i < pagos.Length; i++)
            {
               Int32 pagoi = Convert.ToInt32(pagos[i].submonto);
                for (int j = 1; j <= provisiones.Length; j++)//la j=1 porque la j=0 tiene el numero del pago
                {
                    if (!EstaCubiertoTramo(j) && !EstaDistribuidoPago(i))
                    {
                        Int32 loQueFaltaPorCubrir = Convert.ToInt32(provisiones[j-1].getMonto())-CantidadTramoCubierto(j);//se le resta 1 al indice para que calse
                      
                        if (pagoi <= loQueFaltaPorCubrir)
                        {
                            MatrizDistribucion[i, j] = pagoi;
                            break;
                        }
                        else 
                        {
                            MatrizDistribucion[i, j] = loQueFaltaPorCubrir;
                            pagoi = pagoi - loQueFaltaPorCubrir;                            
                        }
                    }
                    if (pagoi <= 0) break;
                }
            }
        }
        bool EstaCubiertoTramo(int columna)
        {
            Int32 sum = 0;
            for (int i = 0; i < pagos.Length; i++)
            {
                sum += MatrizDistribucion[i,columna];
            }

            return (sum == provisiones[columna-1].getMonto());
            
        }
        Int32 CantidadTramoCubierto(int columna)
        {
            Int32 sum = 0;
            for (int i = 0; i < pagos.Length; i++)
            {
                sum += MatrizDistribucion[i,columna];
            }

            return sum;
        }

        bool EstaDistribuidoPago(int fila)
        {
            Int32 sum = 0;
            for (int j = 1; j <= provisiones.Length; j++)
            {
                sum += MatrizDistribucion[fila,j];
            }
            return (sum == pagos[fila].submonto);
            
        }

    }

    public enum TipoTramo
    {
        hasta_200 = 1,
        de_201_a_300 = 2,
        de_301_a_500 = 3,
        mas_de_500 = 4,
        cero = 5
    }

    public class ProvisionSobreConsumo
    {
        private TipoTramo Tramo;
        private decimal Consumo;
        private decimal TarifaAplicada;
        private decimal Monto;
        public ProvisionSobreConsumo(TipoTramo tramo, decimal consumo, decimal tarifaApp)
        {
            Tramo = tramo;
            Consumo = consumo;
            TarifaAplicada = tarifaApp;
            Monto = Consumo * TarifaAplicada;
        }
        public TipoTramo getTramo() { return Tramo; }
        public decimal getConsumo() { return Consumo; }
        public decimal getTarifaAplicada() { return TarifaAplicada; }
        public decimal getMonto() { return Monto; }
        //private Int32 pagado = 0;
        //public bool isfull()
        //{
        //    return (pagado == Convert.ToInt32(getMonto()));
        //}
        ////retorna lo que falta por pagar
        //public Int32 AgregarPago(Int32 pago)
        //{
        //    if ((pagado + pago) <= getMonto())
        //    {
        //        pagado += pago;
        //        return (Convert.ToInt32(getMonto()) - pagado);
        //    }
        //    pagado = pagado + FaltaPorPagar();
        //    return (Convert.ToInt32(getMonto())-pagado);
        //}
        //public Int32 FaltaPorPagar()
        //{
        //    return Convert.ToInt32(getMonto()) - pagado;
        //}
    }
    
}
