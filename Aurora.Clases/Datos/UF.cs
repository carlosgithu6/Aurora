using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Datos
{
    internal class UF:BaseDatos
    {
        public static InfoUF Crear(InfoUF uf)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.UFCREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", uf.Mes);
                cd.Parameters.AddWithValue("@ANO", uf.Ano);
                cd.Parameters.AddWithValue("@UF", uf.UF);
                cd.ExecuteNonQuery();
            }
            return Buscar(uf.Mes,uf.Ano);
        }
        public static InfoUF Modificar(InfoUF uf)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.UFMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", uf.Mes);
                cd.Parameters.AddWithValue("@ANO", uf.Ano);
                cd.Parameters.AddWithValue("@UF", uf.UF);
                cd.ExecuteNonQuery();
            }
            return Buscar(uf.Mes, uf.Ano);
        }
        public static void Eliminar(int mes, int ano)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.UFELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.ExecuteNonQuery();
            }
        }
        public static InfoUF Buscar(int mes, int ano)
        {
            InfoUF result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.UFBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                SqlDataReader reader = cd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    result = new InfoUF();
                    result.IdUF = Convert.ToInt16(reader["IDUF"]);
                    result.Ano = Convert.ToInt16(reader["ANO"]);
                    result.Mes = Convert.ToInt16(reader["MES"]);
                    result.UF  = Convert.ToDecimal(reader["UF"]);
                }
                return result;
            }
        }
        public static DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.UFLISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
