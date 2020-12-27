using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Datos
{
    class CtePropietario : BaseDatos
    {

        public static InfoCtePropietario Crear(InfoCtePropietario infoCuenta)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CTEPROPIETARIOCREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoCuenta.IdPropiedad );
                cd.Parameters.AddWithValue("@CTECODIGO", infoCuenta.CteCodigo );
                cd.Parameters.AddWithValue("@CEPNUMEROCUOTAS", infoCuenta.CepNumeroCuotas );
                cd.Parameters.AddWithValue("@CEPFECHAINICIO", infoCuenta.CepFechaInicio );
    
                cd.ExecuteNonQuery();
            }
            return Buscar(infoCuenta.CteCodigo);
        }

        public static InfoCtePropietario Buscar(int codigo)
        {
            InfoCtePropietario _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CTEPROPIETARIOBUSCAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDCUENTAESPECIALPROP", codigo);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoCtePropietario();
                    _result.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                    _result.CteCodigo = (int)objReader["CteCodigo"];
                    _result.CepNumeroCuotas = (int)objReader["CEPNUMEROCUOTAS"];
                    _result.FechaCreacion = Convert.ToDateTime(objReader["FECHACREACION"]);
                    _result.FechaModificacion = Convert.ToDateTime(objReader["FECHAMODIFICACION"]);
                    _result.CepFechaInicio = Convert.ToDateTime(objReader["CEPFECHAINICIO"]);
                    _result.IdCtePropietario = (int)objReader["IDCUENTAESPECIALPROP"];
                    _result.DeudaAcumulada = Convert.ToDecimal(objReader["DEUDAACUMULADA"]);

                }
                return _result;
            }
        }
        public static DataTable Listar(int IdPropiedad)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CTEPROPIETARIOLISTAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", IdPropiedad);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

        public static InfoCtePropietario Modificar(InfoCtePropietario infoCuenta)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CTEPROPIETARIOMODIFICAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CEPNUMEROCUOTAS", infoCuenta.CepNumeroCuotas );
                cd.Parameters.AddWithValue("@CEPFECHAINICIO", infoCuenta.CepFechaInicio );
                cd.Parameters.AddWithValue("@IDCUENTAESPECIALPROP", infoCuenta.IdCtePropietario);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoCuenta.CteCodigo);
        }
        public static void Eliminar(int idCtePropietario)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CTEPROPIETARIOELIMINAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDCUENTAESPECIALPROP", idCtePropietario);
                cd.ExecuteNonQuery();
            }
        }
    }
}


