using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Datos
{
    internal class Feriado:BaseDatos
    {
        public static DataTable ListarFeriados()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.FERIADOLISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static void Eliminar(DateTime feriado)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.FERIADOELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@FERIADO", feriado);
                cd.ExecuteNonQuery();
            }
        }
        public static InfoFeriado Buscar(DateTime feriado )
        {
            InfoFeriado _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.FERIADOBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@FERIADO", feriado);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoFeriado();
                    _result.Feriado = Convert.ToDateTime(objReader["FERIADO"].ToString());
                }
                return _result;
            }
        }
        public static void Crear(InfoFeriado infoFeriado)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.FERIADOCREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@FERIADO", infoFeriado.Feriado);
                cd.ExecuteNonQuery();
            }
        }
        
    }
}
