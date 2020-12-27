using System;
using System.Collections.Generic;
using System.Text;
using Aurora.Clases.Base.Enums;
namespace Aurora.Clases.Base
{
    [Serializable()]
    public class InfoValidacion
    {
        
        private  List<InfoMensaje> mensajes= new List<InfoMensaje>();
 
        public void AgregarMensaje(InfoMensaje infoMensaje)
        {
            mensajes.Add(infoMensaje);
        }
        public void LimpiarMensajes()
        {
            mensajes.Clear();
        }

       public  List<InfoMensaje> Mensajes
       {
           get
           {
               return mensajes;
           }
      }
        public bool Estado
       {
            get
            {
                foreach (InfoMensaje mensaje in mensajes)
                {
                    if (mensaje.TipoDAuroraidacion ==  TipoValidacion.Error)
                        return false;  
                }
                return true;
            }
       }
    }
    
   
}
