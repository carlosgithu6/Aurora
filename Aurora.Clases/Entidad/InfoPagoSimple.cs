using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public class InfoPagoSimple
    {
        public string concepto;
        public decimal submonto;
        public DateTime fechaPago;
        public int mes;
        public int ano;
        public int idpropiedad;
        public FormaPago formaPago;
        public int numpago;
    }
   
}
