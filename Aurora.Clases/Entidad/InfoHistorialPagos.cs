using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
 
        public class InfoHistorialPagoCuenta
        {
            public List<InfoPago> Pagos = new List<InfoPago>();
        }
        public class InfoPago
        {
            public int NumMovimiento;
            public int IdPropiedad;
            public int Mes;
            public int Ano;
            public int CFCodigo;
            public decimal SubMontoCancelado;
            public FormaPago FormadePago;
            public DateTime FechaPago;
        }
    
}
