using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Datos
{
    class GastosCE : BaseDatos
    {
        //public static InfoGastosCE Crear(InfoGastosCE infoGastosCE)
        //{
        //    using (SqlConnection cn = new SqlConnection(StringConexion()))
        //    {
        //        cn.Open();
        //        SqlCommand cd = new SqlCommand(PA.GASTOSCECREAR, cn);
        //        cd.CommandType = CommandType.StoredProcedure;
        //        cd.Parameters.AddWithValue("@IDGASTO", infoGastosCE.IdGasto);
        //        cd.Parameters.AddWithValue("@CTECODIGO", infoGastosCE.CteCodigo);
        //        cd.Parameters.AddWithValue("@GCECUOTA", infoGastosCE.GCECuota);
        //        cd.Parameters.AddWithValue("@GCEMONTO ", infoGastosCE.GCEMonto);
        //        cd.Parameters.AddWithValue("@GCEMONTOCANCELADO", infoGastosCE.GCEMontoCancelado);


        //        cd.ExecuteNonQuery();
        //    }
           
        //}

        //public static InfoGastosCE Buscar(int codigo)
        //{
        //    InfoGastosCE _result = null;
        //    using (SqlConnection cn = new SqlConnection(StringConexion()))
        //    {
        //        cn.Open();
        //        SqlCommand cd = new SqlCommand(PA.GASTOSCEBUSCAR, cn);
        //        cd.CommandType = CommandType.StoredProcedure;
        //        cd.Parameters.AddWithValue("@IdGastoCE", codigo);
        //        SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //        if (objReader.Read())
        //        {
        //            _result = new InfoGastosCE();
        //            _result.CteCodigo = (int)objReader["CteCodigo"];
        //            _result.GCECuota = (short)objReader["GCECuota"];
        //            _result.GCEMonto =(decimal) objReader["GCEMonto"];
        //            _result.GCEMontoCancelado = (decimal)objReader["GCEMontoCancelado"];
        //            _result.IdGastoCE = (int)objReader["IdGastoCE"];
        //            _result.IdGasto = (int)objReader["IdGasto"];
        //            _result.FechaPago = (DateTime)objReader["FechaPago"];

        //        }
        //        return _result;
        //    }
        //}
        public static DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCELISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

        public static void Modificar(InfoGastosCE infoGastosCE)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCEMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastosCE.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastosCE.Mes);
                cd.Parameters.AddWithValue("@ANO", infoGastosCE.Ano);
                cd.Parameters.AddWithValue("@CTECODIGO", infoGastosCE.CteCodigo);
                cd.Parameters.AddWithValue("@GCEMONTO", infoGastosCE.GCEMontoCancelado);
                cd.Parameters.AddWithValue("@FECHAPAGO", infoGastosCE.FechaPago);
                cd.Parameters.AddWithValue("@FORMAPAGO", (int)infoGastosCE.FormadePago);
                cd.ExecuteNonQuery();
            }          
        }

        public static void Eliminar(int idGastosCE)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCEELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IdGastoCE", idGastosCE);
                cd.ExecuteNonQuery();
            }
        }

        public static DataTable ListarGEByIdGasto(string rut)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCEBYIDGASTO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@RUT", rut);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static DataTable Listar(int IdPropiedad)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCEBYPROPIETARIO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", IdPropiedad);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static List<InfoGastosCE> BuscarLista(int idPropiedad, int mes, int ano)
        {
            List<InfoGastosCE> result = new List<InfoGastosCE>();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCEPROPIETARIOBUSCAR, cn);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader.Read())
                {
                    InfoGastosCE item = new InfoGastosCE();
                    item.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                    item.Mes = (int)objReader["MES"];
                    item.Ano = (int)objReader["ANO"];
                    item.GCEMontoCuota = Convert.ToDecimal(objReader["GCECUOTA"]);
                    item.GCEMontoCancelado = Convert.ToDecimal(objReader["GCEMONTO"]);
                    item.DescripcionCuenta = objReader["CTEDESCRIPCION"].ToString();
                    item.CantidadCuotas = (int)objReader["CANTIDADCUOTAS"];
                    item.SaldoPendiente = Convert.ToDecimal(objReader["SALDOPENDIENTE"]);
                    item.CuotaActual = (int)objReader["NUMEROCUOTA"];
                    result.Add(item);
                }
                return result;
            }
        }
    }
}
