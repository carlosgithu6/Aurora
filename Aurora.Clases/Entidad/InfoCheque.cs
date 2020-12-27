using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public class InfoCheque
    {
        public string NumCheque;
        public int IdPropiedad;
        public string DescPropiedad;
        public int IdBanco;
        public decimal Monto;
        public DateTime FechaRecepcion;
        public DateTime FechaCobro;
        public EstadoCheque Estado;
    }
    public enum EstadoCheque
    {
        EnCartera=1,
        Cobrado =2,
        Rechazado =3
    }
}
