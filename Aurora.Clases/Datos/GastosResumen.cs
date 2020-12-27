
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Datos
{
    class GastosResumen : BaseDatos
    {
        public static InfoGastosResumen Crear(InfoGastosResumen infoGatosResumen)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSRESUMENCREAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@GAFECHA", infoGatosResumen.GaFecha );
                cd.Parameters.AddWithValue("@GAPROPIETARIO", infoGatosResumen.GaPropietario );
                cd.Parameters.AddWithValue("@GATOTAL", infoGatosResumen.GaTotal);
                cd.Parameters.AddWithValue("@GAPAGADO", infoGatosResumen.GaPagado);
                cd.Parameters.AddWithValue("@GATIENECAMBIO", infoGatosResumen.GaTieneCambio );
     
                cd.ExecuteNonQuery();
            }
            return Buscar(infoGatosResumen.IdGasto );
        }

        public static InfoGastosResumen Buscar(int codigo)
        {
            InfoGastosResumen _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSRESUMENBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IdGasto", codigo);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoGastosResumen();
                    _result.GaFecha = Convert.ToDateTime(objReader["GaFecha"]);
                    _result.GaPagado = (decimal)objReader["GaPagado"];
                    _result.GaPropietario = objReader["GaPropietario"].ToString();
                    _result.GaTieneCambio = (bool)objReader["GaTieneCambio"];
                    _result.GaTotal = (decimal)objReader["GaTotal"];
                    _result.IdGasto = (int)objReader["IdGasto"];

                }
                return _result;
            }
        }
        public static DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSRESUMENLISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static DataTable Listar(int mes,int ano)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSRESUMENLISTARMESANO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

        public static InfoGastosResumen Modificar(InfoGastosResumen infoGatosResumen)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSRESUMENMODIFICAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@GAFECHA", infoGatosResumen.GaFecha);
                cd.Parameters.AddWithValue("@GAPROPIETARIO", infoGatosResumen.GaPropietario);
                cd.Parameters.AddWithValue("@GATOTAL", infoGatosResumen.GaTotal);
                cd.Parameters.AddWithValue("@GAPAGADO", infoGatosResumen.GaPagado);
                cd.Parameters.AddWithValue("@GATIENECAMBIO", infoGatosResumen.GaTieneCambio);
                cd.Parameters.AddWithValue("@IdGASTO", infoGatosResumen.IdGasto);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoGatosResumen.IdGasto );
        }
      
        public static void Eliminar(int idGastosResumen)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSRESUMENELIMINAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IdGastosResumen", idGastosResumen);
                cd.ExecuteNonQuery();
            }
        }

    }
}



