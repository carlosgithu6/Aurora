using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public  class InfoCuentaFija
    {
       public int Codigo = 0;
       public string Descripcion = string.Empty;
       public TipoCuentaFija Tipo;
       public decimal Tarifa;
       public DateTime FechaInicioVigencia;
       public DateTime FechaFinVigencia;
       public DateTime FechaCambioTarifa;
       public DateTime FechaCreacion;
       public bool Eliminado;
    }
    public class InfoHistoricoCuentaFija
    {
       public int Codigo = 0;
       public  Dictionary<DateTime, Tarifas> Historico;        
    }
    public struct Tarifas
    {
        public int Codigo;
        public decimal TarifaAnterior;
        public decimal TarifaNueva;       
    }
    public enum TipoCuentaFija
    {
        Camino=1,
        Seguridad=2,
        GastoComun=3,
        RecuperacionOtrosGastos=4, 
        Inversion=5
    }
}
