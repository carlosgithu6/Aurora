using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Datos
{
    public class HistorialPagoCuenta
    {
        public List<Pago> Pagos = new List<Pago>();
    }
    public class Pago
    {
        public int NumMovimiento;
        public int IdPropiedad;
        public int Mes;
        public int Ano;
        public int CFCodigo;
    }
}
