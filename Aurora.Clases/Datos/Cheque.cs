using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Datos
{
    internal  class Cheque:BaseDatos
    {
       public static DataTable ListarCheques()
       {
           DataTable dt = new DataTable();
           using (SqlConnection cn = new SqlConnection(StringConexion()))
           {
               cn.Open();
               SqlCommand cd = new SqlCommand(PA.CHEQUESLISTAR, cn);
               cd.CommandType = CommandType.StoredProcedure;
               SqlDataAdapter da = new SqlDataAdapter(cd);
               da.Fill(dt);
           }
           return dt;
       }
       public static void Eliminar(string NumCheque, int IdPropiedad, int Banco)
       {
           using (SqlConnection cn = new SqlConnection(StringConexion()))
           {
               cn.Open();
               SqlCommand cd = new SqlCommand(PA.CHEQUESELIMINAR, cn);
               cd.CommandType = CommandType.StoredProcedure;
               cd.Parameters.AddWithValue("@NUMCHEQUE", NumCheque);
               cd.Parameters.AddWithValue("@IDPROPIEDAD", IdPropiedad);
               cd.Parameters.AddWithValue("@BANCO", Banco);
               cd.ExecuteNonQuery();
           }
       }
       public static InfoCheque Buscar(string NumCheque, int IdPropiedad, int Banco)
       {
           InfoCheque _result = null;
           using (SqlConnection cn = new SqlConnection(StringConexion()))
           {
               cn.Open();
               SqlCommand cd = new SqlCommand(PA.CHEQUESBUSCAR, cn);
               cd.CommandType = CommandType.StoredProcedure;
               cd.Parameters.AddWithValue("@NUMCHEQUE", NumCheque);
               cd.Parameters.AddWithValue("@IDPROPIEDAD", IdPropiedad);
               cd.Parameters.AddWithValue("@BANCO", Banco);
               SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
               if (objReader.Read())
               {
                   _result = new InfoCheque();
                   _result.DescPropiedad = objReader["PROPIEDAD"].ToString();
                   _result.Estado = (EstadoCheque)objReader["ESTADO"];
                   _result.IdBanco = (int)objReader["BANCO"];
                   _result.FechaRecepcion = Convert.ToDateTime(objReader["FECHARECEP"]);
                   _result.FechaCobro = Convert.ToDateTime(objReader["FECHACOBRO"]);
                   _result.IdPropiedad = (int)objReader["IDPROPIEDAD"];
                   _result.Monto = Convert.ToDecimal(objReader["MONTO"]);
                   _result.NumCheque = objReader["NUMCHEQUE"].ToString();                  
               }
               return _result;
           }
       }
       public static void Crear(InfoCheque infoCheque)
       {
           using (SqlConnection cn = new SqlConnection(StringConexion()))
           {
               cn.Open();
               SqlCommand cd = new SqlCommand(PA.CHEQUESCREAR, cn);
               cd.CommandType = CommandType.StoredProcedure;
               cd.Parameters.AddWithValue("@NUMCHEQUE", infoCheque.NumCheque);
               cd.Parameters.AddWithValue("@IDPROPIEDAD", infoCheque.IdPropiedad);
               cd.Parameters.AddWithValue("@BANCO", infoCheque.IdBanco);
               cd.Parameters.AddWithValue("@MONTO", infoCheque.Monto);
               cd.Parameters.AddWithValue("@FECHARECEP", infoCheque.FechaRecepcion);
               cd.Parameters.AddWithValue("@FECHACOBRO", infoCheque.FechaCobro);
               cd.Parameters.AddWithValue("@ESTADO", infoCheque.Estado);
               cd.ExecuteNonQuery();
           }
       }
       public static void Modificar(InfoCheque infoCheque)
       {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CHEQUESMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@NUMCHEQUE", infoCheque.NumCheque);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoCheque.IdPropiedad);
                cd.Parameters.AddWithValue("@BANCO", infoCheque.IdBanco);
                cd.Parameters.AddWithValue("@MONTO", infoCheque.Monto);
                cd.Parameters.AddWithValue("@FECHARECEP", infoCheque.FechaRecepcion);
                cd.Parameters.AddWithValue("@FECHACOBRO", infoCheque.FechaCobro);
                cd.Parameters.AddWithValue("@ESTADO", infoCheque.Estado);
                cd.ExecuteNonQuery();
            }
       }
    }
}
