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
    internal class Usuario : BaseDatos
    {

        public static InfoUsuario Crear(InfoUsuario infoUsuario)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.USUARIOCREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@RUT", infoUsuario.Rut);
                cd.Parameters.AddWithValue("@NOMBRES", infoUsuario.Nombres);
                cd.Parameters.AddWithValue("@APPATERNO", infoUsuario.ApePaterno);
                cd.Parameters.AddWithValue("@APMATERNO", infoUsuario.ApeMaterno);
                cd.Parameters.AddWithValue("@DIRECCION", infoUsuario.Direccion);
                cd.Parameters.AddWithValue("@TELEFONO", infoUsuario.Telefono);
                cd.Parameters.AddWithValue("@PASSWORD", infoUsuario.Password);
                cd.Parameters.AddWithValue("@IDPERFIL", infoUsuario.Perfil);
                cd.Parameters.AddWithValue("@EMAIL", infoUsuario.Email);
                cd.ExecuteNonQuery();

            }
            return Buscar(infoUsuario.Rut);
        }

        public static InfoUsuario Modificar(InfoUsuario infoUsuario)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.USUARIOSMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@RUT", infoUsuario.Rut);
                cd.Parameters.AddWithValue("@NOMBRES", infoUsuario.Nombres);
                cd.Parameters.AddWithValue("@APPATERNO", infoUsuario.ApePaterno);
                cd.Parameters.AddWithValue("@APMATERNO", infoUsuario.ApeMaterno);
                cd.Parameters.AddWithValue("@DIRECCION", infoUsuario.Direccion);
                cd.Parameters.AddWithValue("@TELEFONO", infoUsuario.Telefono);
                cd.Parameters.AddWithValue("@IDPERFIL", infoUsuario.Perfil);
                cd.Parameters.AddWithValue("@EMAIL", infoUsuario.Email);
                cd.Parameters.AddWithValue("@ELIMINADO", infoUsuario.Eliminado);
                cd.ExecuteNonQuery();

            }
            return Buscar(infoUsuario.Rut);
        }
        public static InfoUsuario CambiarPass(InfoUsuario infoUsuario)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.USUARIOCAMBIARPASS, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@RUT", infoUsuario.Rut);
                cd.Parameters.AddWithValue("@PASSWORD", infoUsuario.Password);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoUsuario.Rut);
        }
        public static InfoUsuario Buscar(string strRut)
        {
            InfoUsuario _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.USUARIOBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@RUT", strRut);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoUsuario(objReader["RUT"].ToString(), objReader["NOMBRES"].ToString(), objReader["APPATERNO"].ToString(),
                       objReader["APMATERNO"].ToString(), objReader["PASSWORD"].ToString(), (Perfil)objReader["IDPERFIL"],
                       objReader["EMAIL"].ToString(),objReader["DIRECCION"].ToString(),objReader["TELEFONO"].ToString(),Convert.ToDateTime(objReader["FECHACREACION"]), Convert.ToDateTime(objReader["FECHAACTUALIZACION"]));
                    _result.Eliminado = Convert.ToBoolean(objReader["ELIMINADO"]);
                }
            }
            return _result;
        }
        public static DataTable ListarTodosDataTable()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.USUARIOSLISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static void Eliminar(string rut)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.USUARIOELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@RUT", rut);
                cd.ExecuteNonQuery();
            }
        }
    }
}
