using System;
using System.Collections.Generic;
using System.Text;
using Aurora.Clases.Base.Enums;
namespace Aurora.Clases.Base
{
    [Serializable()]
   public class InfoMensaje
   {
       private string mensaje;
       private TipoMensaje tipoMensaje = TipoMensaje.Particular;
       private TipoValidacion tipoVal;
       private int codigoMensaje = -1;
       public InfoMensaje(string mensaje, TipoValidacion tipoValidacion)
       {
           this.mensaje = mensaje;
           this.tipoVal = tipoValidacion;
       }
       public InfoMensaje(string mensaje, TipoValidacion tipoValidacion, int codigomensaje)
       {
           this.mensaje = mensaje;
           this.tipoVal = tipoValidacion;
           this.codigoMensaje = codigomensaje;
       }

       public string Mensaje
       {
           get { return this.mensaje; }
       }
       public TipoMensaje TipoDeMensaje
       {
           get { return this.tipoMensaje; }
           set {tipoMensaje = value; }
       }
       public TipoValidacion TipoDAuroraidacion
       {
           get { return this.tipoVal; }
       }
       public int CodigoMensaje
       {
           get { return this.codigoMensaje; }
           set { codigoMensaje = value; }
       }
  }
  
}
