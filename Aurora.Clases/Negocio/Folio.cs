using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Negocio
{
    public class Folio
    {
        public static int GetFolio()
        {
            return Datos.Folio.getFolio();
        }
    }
}
