using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public class InfoGastosResumen
    {
        public DateTime GaFecha=DateTime.Today ;
        public string GaPropietario="";
        public decimal GaTotal=0;
        public decimal GaPagado=0;
        public bool GaTieneCambio=false;
        public int IdGasto;
    }
}
