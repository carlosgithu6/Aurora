using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.Clases.Entidad
{
    public class InfoPropietario
    {
       public int IdPropiedad;
       public  string Rut;
       public  string  Nombres;
       public  string  Apellido1;
       public  string  Apellido2;
       public  bool EsSocio;
       public  DateTime FechaIngresoSocio;
       public  DateTime FechaSalidaSocio; 
       public  string  DireccionContacto;
       public string Mail;
       public  string  Telefono;
       public  string Sector;
       public  string LetraParcela;
       public  int NumeroParcela;
       public  int TamanoHectareas;
       public  int NumeroCasas;
       public  DateTime FechaCreacion;
       public  DateTime FechaActualizacion;
       public  bool Eliminado;
       public  bool PropiedadActiva;
       public decimal SaldoCuentaCte;
       public decimal DeudaInical;
       public decimal DeudaPendiente;

       public  string NombreCompleto
       {
           get { return (Nombres + " " + Apellido1 + " " + Apellido2); }
       }
       public string NombrePropiedad
       {
           get { return ("Parcela: " + NumeroParcela.ToString() + " " + LetraParcela + " " + Sector); }
       }
    }
}
