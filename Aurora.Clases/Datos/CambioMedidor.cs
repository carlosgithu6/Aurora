using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Datos
{
    class CambioMedidor: BaseDatos
    {
        //listo
        public static InfoCambioMedidor Crear(InfoCambioMedidor infoCambioMedidor)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CAMBIOMEDIDORCREAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoCambioMedidor.IdPropiedad);
                cd.Parameters.AddWithValue("@CTVCODIGO", infoCambioMedidor.CodigoCV);
                cd.Parameters.AddWithValue("@CMFECHACAMBIO", infoCambioMedidor.CMfechaCambio);
                cd.Parameters.AddWithValue("@CMLECTURA ", infoCambioMedidor.CMLectura);
                cd.Parameters.AddWithValue("@CMMOTIVO ", infoCambioMedidor.CMMotivo);
             
               cd.ExecuteNonQuery();
            }
            return Buscar(infoCambioMedidor);
        }
        //listo
        public static InfoCambioMedidor Buscar(InfoCambioMedidor infoCambioMedidor)
        {
            InfoCambioMedidor _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CAMBIOMEDIDORBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD",infoCambioMedidor.IdPropiedad);
                cd.Parameters.AddWithValue("@CTVCODIGO", infoCambioMedidor.CodigoCV);
                cd.Parameters.AddWithValue("@CMFECHACAMBIO",infoCambioMedidor.CMfechaCambio);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoCambioMedidor();
                    _result.CMLectura = (decimal)objReader["CMLectura"];
                    _result.CMfechaCambio = Convert.ToDateTime(objReader["CMfechaCambio"]);
                    _result.CMMotivo =objReader["CMMotivo"].ToString();
                    _result.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                    _result.CodigoCV =Convert.ToInt16(objReader["CTVCODIGO"]);
        
                }
                return _result;
            }
        }
        //listo
        public static DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CAMBIOMEDIDORLISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        //listo
        public static DataTable Listar(int IdPropiedad)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CAMBIOMEDIDORMODIFICARBUSCARPORPROPIEDAD, cn);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", IdPropiedad);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        //listo
        public static InfoCambioMedidor Modificar(InfoCambioMedidor infoCambioMedidor)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoCambioMedidor.IdPropiedad);
                cd.Parameters.AddWithValue("@CTVCODIGO", infoCambioMedidor.CodigoCV);
                cd.Parameters.AddWithValue("@CMFECHACAMBIO", infoCambioMedidor.CMfechaCambio);
                cd.Parameters.AddWithValue("@CMLECTURA", infoCambioMedidor.CMLectura);
                cd.Parameters.AddWithValue("@CMMOTIVO", infoCambioMedidor.CMMotivo);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoCambioMedidor);
        }
        //listo
        public static void Eliminar(InfoCambioMedidor infoCambioMedidor)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CAMBIOMEDIDORELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoCambioMedidor.IdPropiedad);
                cd.Parameters.AddWithValue("@CTVCODIGO", infoCambioMedidor.CodigoCV);
                cd.Parameters.AddWithValue("@CMFECHACAMBIO", infoCambioMedidor.CMfechaCambio);
                cd.ExecuteNonQuery();
            }
        }




    }
}

	