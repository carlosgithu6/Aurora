using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Negocio
{
    public class Cheque
    {
        public static DataTable ListarCheques()
        {
            return Datos.Cheque.ListarCheques();
        }
        public static void Eliminar(string NumCheque,int IdPropiedad, int Banco)
        {
             Datos.Cheque.Eliminar(NumCheque, IdPropiedad, Banco);
        }
        public static InfoCheque Buscar (string NumCheque,int IdPropiedad, int Banco)
        {
          return  Datos.Cheque.Buscar(NumCheque, IdPropiedad,Banco);
        }
        public static void Crear(InfoCheque infoCheque)
        {
            if (Buscar(infoCheque.NumCheque, infoCheque.IdPropiedad, infoCheque.IdBanco) == null)
            {
                if (infoCheque.FechaCobro < infoCheque.FechaRecepcion && infoCheque.FechaCobro != Convert.ToDateTime("01-01-1900 00:00:00")) throw new Exception("La fecha de cobro debe ser posterior a la de recepción");
                if (infoCheque.Monto <= 0) throw new Exception("El monto especificado debe ser mayor que cero");
                if (infoCheque.Estado != EstadoCheque.Cobrado && infoCheque.FechaCobro != Convert.ToDateTime("01-01-1900 00:00:00")) throw new Exception("Si el cheque no está cobrado no debe especificar fecha de cobro");
                if (infoCheque.Estado == EstadoCheque.Cobrado && infoCheque.FechaCobro == Convert.ToDateTime("01-01-1900 00:00:00")) throw new Exception("Si el cheque  está cobrado  debe especificar una fecha de cobro");
                Datos.Cheque.Crear(infoCheque);
            }
            else
                throw new Exception(" El cheque ya existe");
        }
        public static void Modificar(InfoCheque infoCheque)
        {
            if (Buscar(infoCheque.NumCheque, infoCheque.IdPropiedad, infoCheque.IdBanco) != null)
            {
                if (infoCheque.FechaCobro < infoCheque.FechaRecepcion && infoCheque.FechaCobro != Convert.ToDateTime("01-01-1900 00:00:00")) throw new Exception("La fecha de cobro debe ser posterior a la de recepción");
                if (infoCheque.Monto <= 0) throw new Exception("El monto especificado debe ser mayor que cero");
                if (infoCheque.Estado != EstadoCheque.Cobrado && infoCheque.FechaCobro != Convert.ToDateTime("01-01-1900 00:00:00")) throw new Exception("Si el cheque no está cobrado no debe especificar fecha de cobro");
                if (infoCheque.Estado == EstadoCheque.Cobrado && infoCheque.FechaCobro == Convert.ToDateTime("01-01-1900 00:00:00")) throw new Exception("Si el cheque  está cobrado  debe especificar una fecha de cobro");
                Datos.Cheque.Modificar(infoCheque);
            }
            else throw new Exception(" El cheque no existe");
        }
    }
}
