using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public class InfoGastosCVDeuda
    {
       public int IdPropiedad;
       public int Mes;
       public int Ano;
       public int CTVCodigo=0;
       public TipoCuentaVariable CTVTipo;
       public decimal Deuda;
     }
}
