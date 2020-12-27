using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{ 
public class InfoCtePropietario
    {
        public int IdPropiedad ;
        public int CteCodigo = 0;
        public int CepNumeroCuotas = 0;
        public DateTime CepFechaInicio;
        public DateTime FechaCreacion;
        public DateTime FechaModificacion;
        public bool Eliminado;
        public int IdCtePropietario;
        public decimal DeudaAcumulada;
    }

}
