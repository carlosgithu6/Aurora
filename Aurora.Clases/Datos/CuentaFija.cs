using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Datos
{
    internal class CuentaFija:BaseDatos
    {
        public static InfoCuentaFija Crear(InfoCuentaFija infoCuenta)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJACREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@DESCRIPCION", infoCuenta.Descripcion);
                cd.Parameters.AddWithValue("@TIPOCUENTA", infoCuenta.Tipo);
                cd.Parameters.AddWithValue("@TARIFAACTUAL", infoCuenta.Tarifa);
                cd.Parameters.AddWithValue("@FECHAINICIO", infoCuenta.FechaInicioVigencia);
                cd.Parameters.AddWithValue("@FECHAFIN", infoCuenta.FechaFinVigencia);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoCuenta.Codigo);
        }
        public static InfoCuentaFija Buscar(int codigo)
        {
            InfoCuentaFija _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJABUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CODIGO", codigo);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoCuentaFija();
                    _result.Codigo = (int)objReader["CODIGO"];
                    _result.Descripcion = objReader["DESCRIPCION"].ToString();
                    _result.Tipo = (TipoCuentaFija)objReader["TIPOCUENTA"];
                    _result.Tarifa = Convert.ToDecimal(objReader["TARIFAACTUAL"]);
                    _result.FechaInicioVigencia = Convert.ToDateTime(objReader["FECHAINICIO"]);
                    _result.FechaFinVigencia = Convert.ToDateTime(objReader["FECHAFIN"]);
                    _result.FechaCambioTarifa = Convert.ToDateTime(objReader["FECHAULTIMOCAMBIOTARIFA"]);
                    _result.FechaCreacion = Convert.ToDateTime(objReader["FECHACREACION"]);
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
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJALISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ELIMINADO", eliminados);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static InfoCuentaFija Modificar(InfoCuentaFija infoCuenta)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJAMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CODIGO", infoCuenta.Codigo);
                cd.Parameters.AddWithValue("@DESCRIPCION", infoCuenta.Descripcion);
                cd.Parameters.AddWithValue("@TIPOCUENTA", infoCuenta.Tipo);
                cd.Parameters.AddWithValue("@TARIFAACTUAL", infoCuenta.Tarifa);
                cd.Parameters.AddWithValue("@FECHAINICIO", infoCuenta.FechaInicioVigencia);
                cd.Parameters.AddWithValue("@FECHAFIN", infoCuenta.FechaFinVigencia);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoCuenta.Codigo);
        }
        public static void Eliminar(int codigo)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJAELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CODIGO", codigo);
                cd.ExecuteNonQuery();
            }
        }
        public static void CrearHistorico(Tarifas tarifas)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJACREARHISTORICO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@CODIGO", tarifas.Codigo);
                cd.Parameters.AddWithValue("@TARIFAANTERIOR", tarifas.TarifaAnterior);
                cd.Parameters.AddWithValue("@TARIFANUEVA", tarifas.TarifaNueva);
                cd.ExecuteNonQuery();
            }
        }
        public static void AsociarPropietario(InfoCuentaFijaPropietario Asociacion)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJAASOCIARPROPIETARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;

                cd.Parameters.AddWithValue("@IDPROPIEDAD", Asociacion.IdPropiedad);
                cd.Parameters.AddWithValue("@IDCUENTAFIJA", Asociacion.IdCuentaFija);
                cd.Parameters.AddWithValue("@TARIFAESPECIAL", Asociacion.TarifaEspecial);
                cd.ExecuteNonQuery();
            }
        }
        public static void ModificarAsocionPropietario(InfoCuentaFijaPropietario Asociacion)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJAMODIFTARIFAPROPIETARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;

                cd.Parameters.AddWithValue("@IDPROPIEDAD", Asociacion.IdPropiedad);
                cd.Parameters.AddWithValue("@IDCUENTAFIJA", Asociacion.IdCuentaFija);
                cd.Parameters.AddWithValue("@TARIFAESPECIAL", Asociacion.TarifaEspecial);
                cd.ExecuteNonQuery();
            }
        }
        public static void DesasociarPropietario(InfoCuentaFijaPropietario Asociacion)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJADESASOCIARPROPIETARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", Asociacion.IdPropiedad);
                cd.Parameters.AddWithValue("@IDCUENTAFIJA", Asociacion.IdCuentaFija);
                cd.ExecuteNonQuery();
            }
        }
        public static List<InfoCuentaFija> Lista(bool eliminados)
        {
            List<InfoCuentaFija> result = new List<InfoCuentaFija>();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJALISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ELIMINADO", eliminados);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader.Read())
                {
                     InfoCuentaFija item = new InfoCuentaFija();
                    item.Codigo = (int)objReader["CODIGO"];
                    item.Descripcion = objReader["DESCRIPCION"].ToString();
                    item.Tipo = (TipoCuentaFija)objReader["TIPOCUENTA"];
                    item.Tarifa = Convert.ToDecimal(objReader["TARIFAACTUAL"]);
                    item.FechaInicioVigencia = Convert.ToDateTime(objReader["FECHAINICIO"]);
                    item.FechaFinVigencia = Convert.ToDateTime(objReader["FECHAFIN"]);
                    item.FechaCambioTarifa = Convert.ToDateTime(objReader["FECHAULTIMOCAMBIOTARIFA"]);
                    item.FechaCreacion = Convert.ToDateTime(objReader["FECHACREACION"]);
                    item.Eliminado = Convert.ToBoolean(objReader["ELIMINADO"]);
                    result.Add(item);       
                }
                return result;
            }
           
        }
        public static bool ExisteAsociacion(InfoCuentaFijaPropietario Asociacion)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJAPROPIETARIOEXISTE, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", Asociacion.IdPropiedad);
                cd.Parameters.AddWithValue("@IDCUENTAFIJA", Asociacion.IdCuentaFija);
                cd.Parameters.AddWithValue("@Existe", 0).Direction= ParameterDirection.InputOutput;
                cd.ExecuteNonQuery();
                return Convert.ToBoolean(cd.Parameters["@Existe"].Value);
            }
        }
        public static void ActualizarDeudaPropietario(int idPropietario,int idCuentaFija, decimal deuda)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.CUENTAFIJAMODIFTARIFADEUDAPROPIETARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropietario);
                cd.Parameters.AddWithValue("@IDCUENTAFIJA", idCuentaFija);
                cd.Parameters.AddWithValue("@DEUDA", deuda);
                cd.ExecuteNonQuery();
            }
        }
    }
}
