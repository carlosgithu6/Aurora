using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Datos
{
    internal class Nomina:BaseDatos
    {
        public static void GenerarNomina(int idPropiedad, int mes, int ano)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINACREARDEUSUARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);

                cd.ExecuteNonQuery();
            }
        }
        public static bool ExisteNominaActual()
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINAEXISTEACTUAL, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@Existe",0).Direction =ParameterDirection.InputOutput;
                cd.ExecuteNonQuery();
                return Convert.ToBoolean(cd.Parameters["@Existe"].Value);
            }
        }
       
        public static void PonerNominaActiva(int mes, int ano)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINAACTIVAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);

                cd.ExecuteNonQuery();
            }
        }
        
        public static void CerrarNominaActiva(int mes, int ano)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINACERRAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);

                cd.ExecuteNonQuery();
            }
        }
        public static InfoNomina BuscarNomina(int Mes, int Ano)
        {
            InfoNomina _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINABUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", Mes);
                cd.Parameters.AddWithValue("@ANO", Ano);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                   
                    _result = new InfoNomina();
                    _result.FechaApertura = Convert.ToDateTime(objReader["FECHAAPERTURA"]);
                    _result.FechaCierre = (objReader["FECHACIERRE"] is DBNull)?DateTime.MinValue:Convert.ToDateTime(objReader["FECHACIERRE"]);
                    _result.id = Convert.ToInt32(objReader["ID"]);
                    _result.ano = Ano;
                    _result.mes = Mes;
                }
                return _result;
            }
        }
        public static InfoNomina BuscarNomina_ID(int id_nomina)
        {
            InfoNomina _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINABUSCAR_ID, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ID", id_nomina);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {

                    _result = new InfoNomina();
                    _result.FechaApertura = Convert.ToDateTime(objReader["FECHAAPERTURA"]);
                    _result.FechaCierre = (objReader["FECHACIERRE"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(objReader["FECHACIERRE"]);
                    _result.id = id_nomina;
                    _result.ano = Convert.ToInt16(objReader["ANO"]);
                    _result.mes = Convert.ToInt16(objReader["MES"]);
                }
                return _result;
            }
        }
      
        public static InfoNomina BuscarNominaAbierta()
        {
            InfoNomina _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINABUSCARABIERTA, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoNomina();
                    _result.FechaApertura = Convert.ToDateTime(objReader["FECHAAPERTURA"]);
                    _result.FechaCierre = (objReader["FECHACIERRE"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(objReader["FECHACIERRE"]);
                    _result.ano = Convert.ToInt16(objReader["ANO"]);
                    _result.mes = Convert.ToInt16(objReader["MES"]);
                }
                return _result;
            }
        }
        public static DataTable BuscarIngresosReales(int mes, int ano)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINABUSCARINGRESOSREALES, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }


        public static DataTable BuscarIngresosRealesPorFechasPago(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINABUSCARINGRESOSREALESPORFECHASPAGOS, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@DESDE", desde);
                cd.Parameters.AddWithValue("@HASTA", hasta);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
                dt.Columns.Add("INGRESO_200M3");
                dt.Columns.Add("INGRESO_201_300M3");
                dt.Columns.Add("INGRESO_301_500M3");
                dt.Columns.Add("INGRESO_501M3_MAS");
                
                dt.AcceptChanges();
            }
            return dt;
        }

        public static DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINALISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

      
        public static void ActualizarMsg(int Id, string msg)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINAACTUALIZARMSG, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ID", Id);
                cd.Parameters.AddWithValue("@MSG", msg);
                cd.ExecuteNonQuery();
            }
        }

        public static String BuscarMsg(int mes, int ano)
        {
            String _result = String.Empty;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.NOMINABUSCARMSG, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    if (objReader["MSG"] is DBNull)
                        _result  = String.Empty;
                    else
                        _result = Convert.ToString(objReader["MSG"]);
                }
                return _result;
            }
        }

       
    }
}