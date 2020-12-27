using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public class InfoCuentaVariable
    {
        public int CtvCodigo = 0;
        public decimal CtvPrecio = 0;
        public String CtvDescripcion = String.Empty;
        public TipoCuentaVariable CtvTipo;
        public UnidadMedida CtvUnidadMedida;
        public DateTime FechaCreacion;
        public DateTime FechaModificacion;
        public bool Eliminado;
       
    }

    public class InfoHistoricoCuentaVariable
    {
        public int Codigo = 0;
        public Dictionary<DateTime, Tarifas> Historico;
    }
   
  
    public enum TipoCuentaVariable
    {
        Electricidad =4,
        Agua = 1,
        Otro =0,
        RecuperacionGastos=12,
     
      
    }

    public enum UnidadMedida
    {
        KwattPorHora = 1,
        MetroCubico = 2,
        Pesos =3      
    }

}



