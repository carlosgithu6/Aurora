using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public class InfoCambioMedidor
    {
     public int IdPropiedad;
     public int CodigoCV;
     public DateTime CMfechaCambio=DateTime.Now ;
     public decimal CMLectura=0;
     public string CMMotivo;
    }
}
