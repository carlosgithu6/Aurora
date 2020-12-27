using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Datos
{
    class GastosCF: BaseDatos
    {
        //listo
        public static InfoGastosCF Crear(InfoGastosCF infoGastosCF)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFCREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastosCF.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastosCF.Mes);
                cd.Parameters.AddWithValue("@ANO ", infoGastosCF.Ano);
                cd.Parameters.AddWithValue("@CFCODIGO", infoGastosCF.CFCodigo);
                cd.Parameters.AddWithValue("@GCFMONTO", infoGastosCF.GCFMonto);
                cd.Parameters.AddWithValue("@GCFMONTOCANCELADO", infoGastosCF.GCFMontoCancelado);
  
                cd.ExecuteNonQuery();
            }
            return Buscar(infoGastosCF);
        }
        //listo
        public static InfoGastosCF Buscar(InfoGastosCF infoGastosCF)
        {
            InfoGastosCF _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastosCF.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastosCF.Mes);
                cd.Parameters.AddWithValue("@ANO", infoGastosCF.Ano);
                cd.Parameters.AddWithValue("@CFCODIGO", infoGastosCF.CFCodigo);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoGastosCF();
                    _result.IdPropiedad =Convert.ToInt16(objReader["IDPROPIEDAD"]);
                    _result.Mes = (int)objReader["MES"];
                    _result.Ano = (int)objReader["ANO"];
                    _result.GCFMonto = Convert.ToDecimal(objReader["GCFMONTO"]);
                    _result.GCFMontoCancelado = Convert.ToDecimal(objReader["GCFMONTOCANCELADO"]);
                    _result.CFCodigo = (int)objReader["CFCODIGO"];
                    _result.FechaPago = (DateTime)objReader["FECHAPAGO"];
                    _result.FormadePago = (FormaPago)objReader["FORMAPAGO"];
                    _result.TipoCuenta = (int)objReader["TIPOCUENTA"];
                    _result.Descripcion = Convert.ToString(objReader["DESCRIPCION"]);
                }
                objReader.NextResult();
                while (objReader.Read())
                {
                    InfoPago pago = new InfoPago();
                    pago.NumMovimiento = (int) objReader["NUMMOV"];
                    pago.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                    pago.Mes = (int)objReader["MES"];
                    pago.Ano = (int)objReader["ANO"];
                    pago.SubMontoCancelado = Convert.ToDecimal(objReader["SUBMONTOCANCELADO"]);
                    pago.CFCodigo = (int)objReader["CFCODIGO"];
                    pago.FechaPago = (DateTime)objReader["FECHAPAGO"];
                    pago.FormadePago = (FormaPago)objReader["FORMAPAGO"];
                    _result.Pagos.Pagos.Add(pago);
                }
                return _result;
            }
        }
        public static List<InfoGastosCF> BuscarLista(int idPropiedad, int mes, int ano)
        {
            List<InfoGastosCF> result = new List<InfoGastosCF>();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFBYPROMESANO, cn);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader.Read())
                {
                    InfoGastosCF item = new InfoGastosCF();
                    item.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                    item.Mes = (int)objReader["MES"];
                    item.Ano = (int)objReader["ANO"];
                    item.GCFMonto = Convert.ToDecimal(objReader["GCFMONTO"]);
                    item.GCFMontoCancelado = Convert.ToDecimal(objReader["GCFMONTOCANCELADO"]);
                    item.CFCodigo = (int)objReader["CFCODIGO"];
                    item.TipoCuenta = (int)objReader["TIPOCUENTA"];
                    item.Descripcion = Convert.ToString(objReader["DESCRIPCION"]);
                    item.FechaPago = (objReader["FECHAPAGO"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(objReader["FECHAPAGO"]);
                    result.Add(item);
                }
                using (SqlConnection cn2 = new SqlConnection(StringConexion()))
                {
                    cn2.Open();
                    SqlCommand cd2 = new SqlCommand(PA.GASTOSCFBYPROMESANOINACTIVOS, cn2);
                    cd2.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                    cd2.Parameters.AddWithValue("@MES", mes);
                    cd2.Parameters.AddWithValue("@ANO", ano);
                    cd2.CommandType = CommandType.StoredProcedure;
                    SqlDataReader objReader2 = cd2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (objReader2.Read())
                    {
                        InfoGastosCF item = new InfoGastosCF();
                        item.IdPropiedad = Convert.ToInt16(objReader2["IDPROPIEDAD"]);
                        item.Mes = (int)objReader2["MES"];
                        item.Ano = (int)objReader2["ANO"];
                        item.GCFMonto = Convert.ToDecimal(objReader2["GCFMONTO"]);
                        item.GCFMontoCancelado = Convert.ToDecimal(objReader2["GCFMONTOCANCELADO"]);
                        item.CFCodigo = (int)objReader2["CFCODIGO"];
                        item.FechaPago = (objReader2["FECHAPAGO"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(objReader2["FECHAPAGO"]);

                        if (item.GCFMontoCancelado != item.GCFMonto && !ExisteCuentaEnLista(result,item)) result.Add(item);
                    }
                }
                return result;
            }
        }
        private static bool ExisteCuentaEnLista(List<InfoGastosCF> list, InfoGastosCF cuenta)
        {
            foreach (InfoGastosCF item in list)
            {
                if (item.IdPropiedad == cuenta.IdPropiedad &&
                    item.CFCodigo == cuenta.CFCodigo &&
                    item.Mes == cuenta.Mes &&
                    item.Ano == cuenta.Ano) return true;
            }
            return false;
        }
        //listo
        public static DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFLISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        //listo
        public static InfoGastosCF Modificar(InfoGastosCF infoGastosCF)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastosCF.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastosCF.Mes);
                cd.Parameters.AddWithValue("@ANO", infoGastosCF.Ano);
                cd.Parameters.AddWithValue("@CFCODIGO", infoGastosCF.CFCodigo);
                cd.Parameters.AddWithValue("@GCFMONTO", infoGastosCF.GCFMonto);
                cd.Parameters.AddWithValue("@GCFMONTOCANCELADO", infoGastosCF.GCFMontoCancelado);
                cd.Parameters.AddWithValue("@FORMAPAGO", (int)infoGastosCF.FormadePago);
                cd.Parameters.AddWithValue("@FECHAPAGO", infoGastosCF.FechaPago);
               
                cd.ExecuteNonQuery();
            }
            return Buscar(infoGastosCF);
        }
        //Listo
        public static void Eliminar(InfoGastosCF infoGastosCF)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastosCF.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastosCF.Mes);
                cd.Parameters.AddWithValue("@ANO ", infoGastosCF.Ano);
                cd.Parameters.AddWithValue("@CFCODIGO", infoGastosCF.CFCodigo);
                cd.ExecuteNonQuery();
            }
        }
        //listo
        public static DataTable Buscar(int idPropiedad, int mes, int ano)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFBYPROMESANO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarDetallePagos(int idPropiedad, int mes, int ano,int codigo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFBYPROMESANODETALLE, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CFCODIGO", codigo);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        
        public static DataTable BuscarDeuda(int idPropiedad, int mes, int ano)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFBUSCARDEUDA, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static void EliminarDetalle(int NumMov)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFELIMINARDETALLE, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@NUMMOV", NumMov);
                cd.ExecuteNonQuery();
            }
        }



        public static List<InfoGastosCF> BuscarListaHistoria(int idPropiedad,int anod,int mesd, int anoh,int mesh)
        {
            List<InfoGastosCF> result = new List<InfoGastosCF>();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand("GastosFijoPropietariosBuscarHistoria", cn);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@ANOD ", anod);
                cd.Parameters.AddWithValue("@MESD", mesd);
                cd.Parameters.AddWithValue("@ANOH ", anoh);
                cd.Parameters.AddWithValue("@MESH", mesh);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader.Read())
                {
                    InfoGastosCF item = new InfoGastosCF();
                    item.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                    item.Mes = (int)objReader["MES"];
                    item.Ano = (int)objReader["ANO"];
                    item.GCFMonto = Convert.ToDecimal(objReader["GCFMONTO"]);
                    item.GCFMontoCancelado = Convert.ToDecimal(objReader["GCFMONTOCANCELADO"]);
                    item.CFCodigo = (int)objReader["CFCODIGO"];
                    item.TipoCuenta = (int)objReader["TIPOCUENTA"];
                    item.Descripcion = Convert.ToString(objReader["DESCRIPCION"]);
                    item.FechaPago = (objReader["FECHAPAGO"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(objReader["FECHAPAGO"]);
                    result.Add(item);
                }
                using (SqlConnection cn2 = new SqlConnection(StringConexion()))
                {
                    cn2.Open();
                    SqlCommand cd2 = new SqlCommand("GastosFijoPropietariosBuscarInactivosHistoria", cn2);
                    cd2.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                    cd2.Parameters.AddWithValue("@ANOD ", anod);
                    cd2.Parameters.AddWithValue("@MESD", mesd);
                    cd2.Parameters.AddWithValue("@ANOH ", anoh);
                    cd2.Parameters.AddWithValue("@MESH", mesh);
                    cd2.CommandType = CommandType.StoredProcedure;
                    SqlDataReader objReader2 = cd2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (objReader2.Read())
                    {
                        InfoGastosCF item = new InfoGastosCF();
                        item.IdPropiedad = Convert.ToInt16(objReader2["IDPROPIEDAD"]);
                        item.Mes = (int)objReader2["MES"];
                        item.Ano = (int)objReader2["ANO"];
                        item.GCFMonto = Convert.ToDecimal(objReader2["GCFMONTO"]);
                        item.GCFMontoCancelado = Convert.ToDecimal(objReader2["GCFMONTOCANCELADO"]);
                        item.CFCodigo = (int)objReader2["CFCODIGO"];
                        item.FechaPago = (objReader2["FECHAPAGO"] is DBNull) ? DateTime.MinValue : Convert.ToDateTime(objReader2["FECHAPAGO"]);

                        if (item.GCFMontoCancelado != item.GCFMonto && !ExisteCuentaEnLista(result, item)) result.Add(item);
                    }
                }
                return result;
            }
        }
    }
}
