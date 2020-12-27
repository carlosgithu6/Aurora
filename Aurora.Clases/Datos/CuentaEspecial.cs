using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Datos
{
    class CuentaEspecial : BaseDatos
    {

        public static InfoCuentaEspecial Crear(InfoCuentaEspecial infoCuenta)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAESPECIALCREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CTEPRECIO", infoCuenta.CtePrecio );
                cd.Parameters.AddWithValue("@CTEDESCRIPCION", infoCuenta.CteDescripcion );
                cd.ExecuteNonQuery();
            }
            return Buscar(infoCuenta.CteCodigo);
        }

        public static InfoCuentaEspecial Buscar(int codigo)
        {
            InfoCuentaEspecial _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAESPECIALBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CODIGO", codigo);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoCuentaEspecial();
                    _result.CteCodigo = (int)objReader["CTECodigo"];
                    _result.CteDescripcion = objReader["CTEDescripcion"].ToString();
                    _result.CtePrecio = Convert.ToDecimal(objReader["CTEPrecio"]);
                    _result.FechaCreacion = Convert.ToDateTime(objReader["FechaCreacion"]);
                    _result.FechaModificacion = Convert.ToDateTime(objReader["FechaModificacion"]);
                    _result.Eliminado = Convert.ToBoolean(objReader["ELIMINADO"]);
                }
                return _result;
            }
        }
        public static DataTable Listar(bool eliminados)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAESPECIALLISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ELIMINADO", eliminados);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static InfoCuentaEspecial Modificar(InfoCuentaEspecial infoCuenta)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAESPECIALMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CTECODIGO", infoCuenta.CteCodigo);
                cd.Parameters.AddWithValue("@CTEPRECIO", infoCuenta.CtePrecio);
                cd.Parameters.AddWithValue("@CTEDESCRIPCION", infoCuenta.CteDescripcion);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoCuenta.CteCodigo);
        }
        public static void Eliminar(int codigo)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAESPECIALELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CODIGO", codigo);
                cd.ExecuteNonQuery();
            }
        }

   

    }
}

