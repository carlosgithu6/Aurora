using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Datos
{
    class CuentaVariable:BaseDatos 
    {

        public static InfoCuentaVariable Crear(InfoCuentaVariable infoCuenta, int Rut)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLECREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CTVTIPO", infoCuenta.CtvTipo );
                cd.Parameters.AddWithValue("@CTVPRECIO", infoCuenta.CtvPrecio) ;
                cd.Parameters.AddWithValue("@CTVDESCRIPCION", infoCuenta.CtvDescripcion );
                cd.Parameters.AddWithValue("@CTVUNIDADMEDIDA", infoCuenta.CtvUnidadMedida );
                cd.Parameters.AddWithValue("@Rut", Rut);
               cd.ExecuteNonQuery();
            }
            return Buscar(infoCuenta.CtvCodigo);
        }

        public static InfoCuentaVariable Buscar(int codigo)
        {
            InfoCuentaVariable _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLEBUSCAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CODIGO", codigo);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoCuentaVariable();
                    _result.CtvCodigo = (int)objReader["CtvCodigo"];
                    _result.CtvDescripcion = objReader["CtvDescripcion"].ToString();
                    _result.CtvTipo = (TipoCuentaVariable)Enum.Parse(typeof(TipoCuentaVariable), objReader["CtvTipo"].ToString());
                    _result.CtvPrecio = Convert.ToDecimal(objReader["CtvPrecio"]);
                    _result.CtvUnidadMedida = (UnidadMedida)Enum.Parse(typeof(UnidadMedida), objReader["CtvUnidadMedida"].ToString()); 
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
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLELISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ELIMINADO", eliminados);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static InfoCuentaVariable Modificar(InfoCuentaVariable infoCuenta, int rut)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLEMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CTVCODIGO", infoCuenta.CtvCodigo);
                cd.Parameters.AddWithValue("@CTVTIPO", infoCuenta.CtvTipo);
                cd.Parameters.AddWithValue("@CTVPRECIO", infoCuenta.CtvPrecio );
                cd.Parameters.AddWithValue("@CTVUNIDADMEDIDA", infoCuenta.CtvUnidadMedida);
                cd.Parameters.AddWithValue("@CTVDESCRIPCION", infoCuenta.CtvDescripcion );
                cd.Parameters.AddWithValue("@Rut", rut);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoCuenta.CtvCodigo);
        }
        public static void Eliminar(int codigo)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLEELIMINAR , cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CODIGO", codigo);
                cd.ExecuteNonQuery();
            }
        }

        public static DataTable ListarCambiosdePrecios(int ctvcodigo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLELISTARHISTORICO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CTVCODIGO", ctvcodigo);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static DataTable ListadoIngresoCV(int mes, int ano,int codigo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVBYMESANOTIPO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", codigo);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

        public static void AsociarPropietario(InfoCuentaVarPropietario Asociacion)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLEASOCIARPROPIETARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;

                cd.Parameters.AddWithValue("@IDPROPIEDAD", Asociacion.IdPropiedad);
                cd.Parameters.AddWithValue("@IDCUENTAVARIABLE", Asociacion.IdCuentaVar);
                cd.Parameters.AddWithValue("@TARIFAESPECIAL", Asociacion.TarifaEspecial);
                cd.Parameters.AddWithValue("@MEDIDOR", Asociacion.NumeroMedidor);
                cd.ExecuteNonQuery();
            }
        }
        public static void ModificarAsocionPropietario(InfoCuentaVarPropietario Asociacion)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLEMODIFTARIFAPROPIETARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;

                cd.Parameters.AddWithValue("@IDPROPIEDAD", Asociacion.IdPropiedad);
                cd.Parameters.AddWithValue("@IDCUENTAVARIABLE", Asociacion.IdCuentaVar);
                cd.Parameters.AddWithValue("@TARIFAESPECIAL", Asociacion.TarifaEspecial);
                cd.Parameters.AddWithValue("@MEDIDOR", Asociacion.NumeroMedidor);
                cd.ExecuteNonQuery();
            }
        }
        public static void DesasociarPropietario(InfoCuentaVarPropietario Asociacion)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLEDESASOCIARPROPIETARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", Asociacion.IdPropiedad);
                cd.Parameters.AddWithValue("@IDCUENTAVARIABLE", Asociacion.IdCuentaVar);
                cd.ExecuteNonQuery();
            }
        }
        public static List<InfoCuentaVariable> Lista(bool eliminados)
        {
            List<InfoCuentaVariable> result = new List<InfoCuentaVariable>();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLELISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ELIMINADO", eliminados);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader.Read())
                {
                    InfoCuentaVariable item = new InfoCuentaVariable();
                    item.CtvCodigo = (int)objReader["CTVCODIGO"];
                    item.CtvDescripcion = objReader["CTVDESCRIPCION"].ToString();
                    item.CtvTipo = (TipoCuentaVariable)((int)objReader["CTVTIPO"]);
                    item.CtvPrecio = Convert.ToDecimal(objReader["CTVPRECIO"]);
                    item.CtvUnidadMedida = (UnidadMedida)(objReader["CTVUNIDADMEDIDA"]);
                    item.FechaCreacion = Convert.ToDateTime(objReader["FECHACREACION"]);
                    item.FechaModificacion = Convert.ToDateTime(objReader["FECHAMODIFICACION"]);
                    item.Eliminado = Convert.ToBoolean(objReader["ELIMINADO"]);
                    result.Add(item);
                }
                return result;
            }

        }
        public static bool ExisteAsociacion(InfoCuentaVarPropietario Asociacion)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLEPROPIETARIOEXISTE, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", Asociacion.IdPropiedad);
                cd.Parameters.AddWithValue("@IDCUENTAVARIABLE", Asociacion.IdCuentaVar);
                cd.Parameters.AddWithValue("@Existe", 0).Direction = ParameterDirection.InputOutput;
                cd.ExecuteNonQuery();
                return Convert.ToBoolean(cd.Parameters["@Existe"].Value);
            }
        }
        public static void ActualizarDeudaPropietario(int idPropietario,int cvCodigo ,decimal deuda)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAVARIABLEMODIFDEUDAPROPIETARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropietario);
                cd.Parameters.AddWithValue("@CTVCODIGO", cvCodigo);
                cd.Parameters.AddWithValue("@DEUDA", deuda);
                cd.ExecuteNonQuery();
            }
         }
        public static DataTable ListadoIngresoCVforCSV(int mes, int ano, int codigo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVBYMESANOTIPOFORCSV, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", codigo);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

      
   }
}
