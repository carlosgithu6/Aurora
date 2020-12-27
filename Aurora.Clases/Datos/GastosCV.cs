using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;

namespace Aurora.Clases.Datos
{
    class GastosCV: BaseDatos
    {
        public static InfoGastosCV Crear(InfoGastosCV infoGastosCV)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVCREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastosCV.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastosCV.Mes);
                cd.Parameters.AddWithValue("@ANO", infoGastosCV.Ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", infoGastosCV.CTVCodigo);
                cd.Parameters.AddWithValue("@GVCLECTURACATUAL", infoGastosCV.GVLecturaActual);
                cd.Parameters.AddWithValue("@GVFECHAVTO", infoGastosCV.GVFechaVto);
                cd.Parameters.AddWithValue("@GVMONTOCANCELADO", infoGastosCV.GVMontoCancelado);
                cd.Parameters.AddWithValue("@MONTOFIJO", infoGastosCV.GVMontoFijo);
                cd.Parameters.AddWithValue("@FECHAPAGO", infoGastosCV.FechaPago);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoGastosCV);
        }

        public static InfoGastosCV Buscar(InfoGastosCV infoGastoCV)
        {
            InfoGastosCV _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastoCV.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastoCV.Mes);
                cd.Parameters.AddWithValue("@ANO", infoGastoCV.Ano);
                cd.Parameters.AddWithValue("@CODIGO", infoGastoCV.CTVCodigo);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoGastosCV();
                    _result.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                    _result.CTVCodigo = ((int)objReader["CTVCODIGO"]);
                    _result.Tipo = (TipoCuentaVariable)Convert.ToInt16(objReader["CTVTIPO"]);
                    _result.Ano = (int)objReader["ANO"];

                    _result.DescontarCte = Convert.ToBoolean(objReader["DESCONTAR"]);
                    _result.Deuda = 0;
                    _result.FechaPago = Convert.ToDateTime(objReader["FECHAPAGO"]);
                    _result.FormadePago = (FormaPago)Convert.ToInt16(objReader["FORMAPAGO"]);
                    _result.GVFechaVto = Convert.ToDateTime(objReader["FECHAPAGO"]);
                    _result.GVLecturaActual = objReader["GVCLECTURACATUAL"] is DBNull ? 0 : Convert.ToDecimal(objReader["GVCLECTURACATUAL"]);
                    _result.GVLecturaAnterior = objReader["GVLECTURAANTERIOR"] is DBNull ? 0 : Convert.ToDecimal(objReader["GVLECTURAANTERIOR"]);
                    _result.GVMontoCancelado = Convert.ToDecimal(objReader["GVMONTOCANCELADO"]);
                    _result.GVMontoFijo = Convert.ToDecimal(objReader["MONTOFIJO"]);
                    _result.LecturaCM = objReader["LECTURACM"] is DBNull ? 0 : Convert.ToDecimal(objReader["LECTURACM"]);
                    _result.Mes = Convert.ToInt16(objReader["MES"]);
                    _result.Trifasico = Convert.ToBoolean(objReader["TRIFASICO"]);
                    _result.PrecioU = Convert.ToDecimal(objReader["PRECIOUNITARIO"]);
                    _result.Medidor = objReader["MEDIDOR"] is DBNull ? String.Empty : Convert.ToString(objReader["MEDIDOR"]);
                    _result.GVFechaLectura = (objReader["FECHALEC"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(objReader["FECHALEC"]));
                    _result.Consumo = objReader["CONSUMO"] is DBNull ? 0 : Convert.ToDecimal(objReader["CONSUMO"]);
                    InfoNomina nomina = Datos.Nomina.BuscarNomina(_result.Mes, _result.Ano);
                    _result.setCostoTotal(objReader["COSTO"] is DBNull ? 0 : Convert.ToDecimal(objReader["COSTO"]), (nomina == null) ? 1 : nomina.id);
                    
                }
                return _result;
            }
        }
        public static DataTable Buscar(int idPropiedad, int mes, int ano,int codigo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVBUSCAR, cn);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CODIGO", codigo);
               
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;          
        }
        public static List<InfoGastosCV> BuscarListaGastosCVTodoPropiedad(int idPropiedad)
        {
            {
                List<InfoGastosCV> result = new List<InfoGastosCV>();
              
                using (SqlConnection cn = new SqlConnection(StringConexion()))
                {
                    cn.Open();
                    SqlCommand cd = new SqlCommand(PA.GASTOSCVBUSCARTODO, cn);
                    cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                    cd.Parameters.AddWithValue("@CODIGO", -1);
                    cd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (objReader.Read())
                    {
                        InfoGastosCV item = new InfoGastosCV();
                        try
                        {
                            item.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                            item.CTVCodigo = ((int)objReader["CTVCODIGO"]);
                            item.Tipo = (TipoCuentaVariable)Convert.ToInt16(objReader["CTVTIPO"]);
                            item.Ano = (int)objReader["ANO"];

                            item.DescontarCte = Convert.ToBoolean(objReader["DESCONTAR"]);
                            item.Deuda = 0;
                            item.FechaPago = Convert.ToDateTime(objReader["FECHAPAGO"]);
                            item.FormadePago = (FormaPago)Convert.ToInt16(objReader["FORMAPAGO"]);
                            item.GVFechaVto = Convert.ToDateTime(objReader["FECHAPAGO"]);
                            item.GVLecturaActual = objReader["GVCLECTURACATUAL"] is DBNull ? 0 : Convert.ToDecimal(objReader["GVCLECTURACATUAL"]);
                            item.GVLecturaAnterior = objReader["GVLECTURAANTERIOR"] is DBNull ? 0 : Convert.ToDecimal(objReader["GVLECTURAANTERIOR"]); 
                            item.GVMontoCancelado = Convert.ToDecimal(objReader["GVMONTOCANCELADO"]);
                            item.GVMontoFijo = Convert.ToDecimal(objReader["MONTOFIJO"]);
                            item.LecturaCM = objReader["LECTURACM"] is DBNull ? 0 : Convert.ToDecimal(objReader["LECTURACM"]);
                            item.Mes = Convert.ToInt16(objReader["MES"]);
                            item.Trifasico = Convert.ToBoolean(objReader["TRIFASICO"]);
                            item.PrecioU = Convert.ToDecimal(objReader["PRECIOUNITARIO"]);
                            item.Medidor = objReader["MEDIDOR"] is DBNull ? String.Empty : Convert.ToString(objReader["MEDIDOR"]);
                            item.GVFechaLectura = (objReader["FECHALEC"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(objReader["FECHALEC"]));
                            item.Consumo = objReader["CONSUMO"] is DBNull ? 0 : Convert.ToDecimal(objReader["CONSUMO"]); 
                            InfoNomina nomina = Datos.Nomina.BuscarNomina(item.Mes, item.Ano);
                            item.setCostoTotal(objReader["COSTO"] is DBNull ? 0 : Convert.ToDecimal(objReader["COSTO"]), (nomina == null) ? 1 : nomina.id);
                            result.Add(item);
                        }
                        
                        catch (Exception ez)
                        {
                            throw new Exception("Revisar lectura de la propiedad:" + item.IdPropiedad + " para la cuenta " + Datos.CuentaVariable.Buscar(item.CTVCodigo).CtvDescripcion+ "  " + ez.Message );
                        }
                    }
                }
                #region Segunda Parte Lista
                using (SqlConnection cn2 = new SqlConnection(StringConexion()))
                {
                    cn2.Open();
                    SqlCommand cd2 = new SqlCommand(PA.GASTOSCVBUSCARINACTIVOS, cn2);
                    cd2.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                    cd2.CommandType = CommandType.StoredProcedure;
                    SqlDataReader objReader2 = cd2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (objReader2.Read())
                    {
                        InfoGastosCV item = new InfoGastosCV();

                        item.Ano = (int)objReader2["ANO"];

                        item.CTVCodigo = ((int)objReader2["CTVCODIGO"]);
                        item.Tipo = (TipoCuentaVariable)Convert.ToInt16(objReader2["CTVTIPO"]);

                        item.IdPropiedad = Convert.ToInt16(objReader2["IDPROPIEDAD"]);
                        item.Mes = Convert.ToInt16(objReader2["MES"]);
                        item.PrecioU = Convert.ToDecimal(objReader2["PRECIO"]);
                        item.flag = true;
                        InfoNomina nom = Datos.Nomina.BuscarNomina(item.Mes, item.Ano);
                        item.setCostoTotal(objReader2["DEUDA"] is DBNull ? 0 : Convert.ToDecimal(objReader2["DEUDA"]), (nom == null) ? 1 : nom.id);
                        item.Deuda = item.getCostoTotal();
                        if (item.Deuda > 0 && !ExisteCuentaEnLista(result, item)) result.Add(item);
                    }
                }

                #endregion
                return result;
            }
        }
        public static List<InfoGastosCV> BuscarLista(int idPropiedad, int mes, int ano)
        {
            List<InfoGastosCV> result = new List<InfoGastosCV>();
            InfoNomina nomina = Datos.Nomina.BuscarNomina(mes, ano);
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVBUSCAR, cn);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CODIGO",-1);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
               
                while (objReader.Read())
                {
                    InfoGastosCV item = new InfoGastosCV();
                    try
                    {
                        item.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                        item.CTVCodigo = ((int)objReader["CTVCODIGO"]);
                        item.Tipo = (TipoCuentaVariable)Convert.ToInt16(objReader["CTVTIPO"]);
                        item.Ano = (int)objReader["ANO"];
                    
                        item.DescontarCte = Convert.ToBoolean(objReader["DESCONTAR"]);
                        item.Deuda = 0;
                        item.FechaPago = Convert.ToDateTime(objReader["FECHAPAGO"]);
                        item.FormadePago = (FormaPago)Convert.ToInt16(objReader["FORMAPAGO"]);
                        item.GVFechaVto = Convert.ToDateTime(objReader["FECHAPAGO"]);
                        item.GVLecturaActual = Convert.ToDecimal(objReader["GVCLECTURACATUAL"]);
                        item.GVLecturaAnterior = Convert.ToDecimal(objReader["GVLECTURAANTERIOR"]);
                        item.GVMontoCancelado = Convert.ToDecimal(objReader["GVMONTOCANCELADO"]);
                        item.GVMontoFijo = Convert.ToDecimal(objReader["MONTOFIJO"]);
                        item.LecturaCM = objReader["LECTURACM"] is DBNull ? 0 : Convert.ToDecimal(objReader["LECTURACM"]);
                        item.Mes = Convert.ToInt16(objReader["MES"]);
                        item.Trifasico = Convert.ToBoolean(objReader["TRIFASICO"]);
                        item.PrecioU = Convert.ToDecimal(objReader["PRECIOUNITARIO"]);
                        item.Medidor = objReader["MEDIDOR"] is DBNull ? String.Empty : Convert.ToString(objReader["MEDIDOR"]);
                        item.GVFechaLectura = (objReader["FECHALEC"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(objReader["FECHALEC"]));
                        item.Consumo = Convert.ToDecimal(objReader["CONSUMO"]);
                        item.setCostoTotal( Convert.ToDecimal(objReader["COSTO"]),(nomina==null)?1:nomina.id);
                        result.Add(item);
                    }
                    catch (Exception ez)
                    {
                        throw new Exception("Revisar lectura de la propiedad:" + item.IdPropiedad+" para la cuenta "+ Datos.CuentaVariable.Buscar(item.CTVCodigo).CtvDescripcion+ "   " + ez.InnerException.Source);
                    }
                }
            }
         #region Segunda Parte Lista
            using (SqlConnection cn2 = new SqlConnection(StringConexion()))
            {
                cn2.Open();
                SqlCommand cd2 = new SqlCommand(PA.GASTOSCVBUSCARINACTIVOS, cn2);
                cd2.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd2.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader2 = cd2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader2.Read())
                {
                    InfoGastosCV item = new InfoGastosCV();
                    
                    item.Ano = (int)objReader2["ANO"];
                   
                    item.CTVCodigo = ((int)objReader2["CTVCODIGO"]);
                    item.Tipo = (TipoCuentaVariable)Convert.ToInt16(objReader2["CTVTIPO"]);
                   
                    item.IdPropiedad = Convert.ToInt16(objReader2["IDPROPIEDAD"]);
                    item.Mes = Convert.ToInt16(objReader2["MES"]);
                    item.PrecioU = Convert.ToDecimal(objReader2["PRECIO"]);
                    item.flag = true;
                    InfoNomina nom = Datos.Nomina.BuscarNomina(item.Mes, item.Ano);
                    item.setCostoTotal(objReader2["DEUDA"] is DBNull ? 0 : Convert.ToDecimal(objReader2["DEUDA"]),(nom==null)?1: nom.id);
                    item.Deuda = item.getCostoTotal(); 
                    if (item.Deuda > 0 && !ExisteCuentaEnLista(result,item)) result.Add(item);                  
                 }
            }
               
                #endregion
                return result;
           }
        private static bool ExisteCuentaEnLista(List<InfoGastosCV> list, InfoGastosCV cuenta)
        {
            foreach (InfoGastosCV  item in list)
            {
                if (item.IdPropiedad == cuenta.IdPropiedad && 
                    item.CTVCodigo == cuenta.CTVCodigo &&
                    item.Mes == cuenta.Mes &&
                    item.Ano == cuenta.Ano ) return true;
            }
            return false;
        }
        public static DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVLISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

        public static InfoGastosCV Modificar(InfoGastosCV infoGastosCV)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastosCV.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastosCV.Mes);
                cd.Parameters.AddWithValue("@ANO", infoGastosCV.Ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", infoGastosCV.CTVCodigo);
                cd.Parameters.AddWithValue("@GVCLECTURACATUAL", infoGastosCV.GVLecturaActual);
                cd.Parameters.AddWithValue("@FORMAPAGO", (int)infoGastosCV.FormadePago);
                cd.Parameters.AddWithValue("@GVMONTOCANCELADO", infoGastosCV.GVMontoCancelado);
                cd.Parameters.AddWithValue("@MONTOFIJO", infoGastosCV.GVMontoFijo);
                cd.Parameters.AddWithValue("@FECHAPAGO", infoGastosCV.FechaPago);
                cd.Parameters.AddWithValue("@TRIFASICO", infoGastosCV.Trifasico);
                cd.Parameters.AddWithValue("@FACTOR", infoGastosCV.Factor);
                cd.Parameters.AddWithValue("@FECHALEC", infoGastosCV.GVFechaLectura);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoGastosCV);
        }
        public static InfoGastosCV Pagar(InfoGastosCV infoGastosCV)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVPAGAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastosCV.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastosCV.Mes);
                cd.Parameters.AddWithValue("@ANO", infoGastosCV.Ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", infoGastosCV.CTVCodigo);
                 cd.Parameters.AddWithValue("@FORMAPAGO", (int)infoGastosCV.FormadePago);
                cd.Parameters.AddWithValue("@GVMONTOCANCELADO", infoGastosCV.GVMontoCancelado);
                cd.Parameters.AddWithValue("@MONTOFIJO", infoGastosCV.GVMontoFijo);
                cd.Parameters.AddWithValue("@FECHAPAGO", infoGastosCV.FechaPago);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoGastosCV);
        }

        public static void Eliminar(InfoGastosCV infoGastoCV)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoGastoCV.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", infoGastoCV.Mes);
                cd.Parameters.AddWithValue("@ANO", infoGastoCV.Ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", infoGastoCV.CTVCodigo);
                cd.ExecuteNonQuery();
            }
        }

        public static DataTable ListarGVByIdGasto(string rut,int mes, int ano)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVBYIDGASTO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@RUT", rut);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static void PonerPrimeraLectura(InfoGastosCV gastoV)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVSETPRIMERALECTURA, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", gastoV.IdPropiedad);
                cd.Parameters.AddWithValue("@MES", gastoV.Mes);
                cd.Parameters.AddWithValue("@ANO", gastoV.Ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", gastoV.CTVCodigo);
                cd.Parameters.AddWithValue("@PRIMERALECTURA", gastoV.GVLecturaActual);
                cd.Parameters.AddWithValue("@FECHALEC", gastoV.GVFechaLectura);
                cd.ExecuteNonQuery();
            }
        }
        public static DataTable BuscarDetallePagos(int idPropiedad, int mes, int ano, int codigo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVBUSCARDETALLES, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", codigo);
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
                SqlCommand cd = new SqlCommand(PA.GASTOSCVELIMINARDETALLE, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@NUMMOV", NumMov);
                cd.ExecuteNonQuery();
            }
        }
        public static void BorrarLecturas(int mes, int ano, int codigo)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {

                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVBORRARLECTURAANOMESCOGIDO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", codigo);
                cd.ExecuteNonQuery();
            }
        }
        public static void ActualizarLecturaActual(int mes, int ano, int codigo,int propiedad,decimal lecturaActual, DateTime fechalectura)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVACTUALIZARLECTURAANOMESCOGIDOPROP, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CTVCODIGO", codigo);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", propiedad);
                cd.Parameters.AddWithValue("@LECTURAACTUAL", lecturaActual);
                cd.Parameters.AddWithValue("@FECHALEC", fechalectura);
                cd.Parameters.AddWithValue("@FECHAVTO", DateTime.Now.AddMonths(1));
                cd.ExecuteNonQuery();
            }
        }
        public static decimal LecturaAnterior(int idprop,int mesactual,int ano,int codigo)
        {
            decimal _result = 0;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();

                string sql = "SELECT dbo.LecturaAnterior(" + idprop.ToString() + "," + mesactual.ToString() + "," + ano.ToString() +","+ codigo.ToString()+ ")";
                SqlCommand cd = new SqlCommand(sql, cn);
                cd.CommandType = CommandType.Text;
                _result = (decimal)cd.ExecuteScalar();

                return _result;
            }
        }



        public static InfoGastoCVConPagos BuscarGastoCVconPagos(int idPropiedad, int mes, int ano, int codigo)
        {
          //if (((TipoCuentaVariable)codigo) != TipoCuentaVariable.Agua) throw new Exception("Intenta buscar el pago para una categoria diferente de agua.");
            InfoGastoCVConPagos result = new InfoGastoCVConPagos();
            InfoNomina nomina = Datos.Nomina.BuscarNomina(mes, ano);
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCVBUSCAR, cn);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CODIGO", codigo);//este codigo es el ID de la cuenta, no su tipo...
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (objReader.Read())
                {
                    
                    try
                    {
                        result.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                        result.CTVCodigo = ((int)objReader["CTVCODIGO"]);
                        result.Tipo = (TipoCuentaVariable)Convert.ToInt16(objReader["CTVTIPO"]);
                        result.Ano = (int)objReader["ANO"];

                        result.DescontarCte = Convert.ToBoolean(objReader["DESCONTAR"]);
                        result.Deuda = 0;
                        result.FechaPago = Convert.ToDateTime(objReader["FECHAPAGO"]);
                        result.FormadePago = (FormaPago)Convert.ToInt16(objReader["FORMAPAGO"]);
                        result.GVFechaVto = Convert.ToDateTime(objReader["FECHAPAGO"]);
                        result.GVLecturaActual = Convert.ToDecimal(objReader["GVCLECTURACATUAL"]);
                        result.GVLecturaAnterior = Convert.ToDecimal(objReader["GVLECTURAANTERIOR"]);
                        result.GVMontoCancelado = Convert.ToDecimal(objReader["GVMONTOCANCELADO"]);
                        result.GVMontoFijo = Convert.ToDecimal(objReader["MONTOFIJO"]);
                        result.LecturaCM = objReader["LECTURACM"] is DBNull ? 0 : Convert.ToDecimal(objReader["LECTURACM"]);
                        result.Mes = Convert.ToInt16(objReader["MES"]);
                        result.Trifasico = Convert.ToBoolean(objReader["TRIFASICO"]);
                        result.PrecioU = Convert.ToDecimal(objReader["PRECIOUNITARIO"]);
                        result.Medidor = objReader["MEDIDOR"] is DBNull ? String.Empty : Convert.ToString(objReader["MEDIDOR"]);
                        result.GVFechaLectura = (objReader["FECHALEC"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(objReader["FECHALEC"]));
                        result.Consumo = Convert.ToDecimal(objReader["CONSUMO"]);
                        result.setCostoTotal(Convert.ToDecimal(objReader["COSTO"]), (nomina == null) ? 1 : nomina.id);
                        result.pagosReales = Negocio.Propietario.BuscarPagos(result.IdPropiedad, result.Mes, result.Ano, result.CTVCodigo);
                        result.SetIngresosPorTramoParaCadaPago();//se distribuyen los ingresos por tramo.
                        
                    }
                    catch (Exception ez)
                    {
                        throw new Exception("Revisar lectura de la propiedad:" + result.IdPropiedad + " para la cuenta " + Datos.CuentaVariable.Buscar(result.CTVCodigo).CtvDescripcion + "   " + ez.InnerException.Source);
                    }
                }
            }
           
            return result;
        }




        public static List<InfoGastosCV> BuscarListaHistoria(int idPropiedad, int anod, int mesd, int anoh, int mesh)
        {
            List<InfoGastosCV> result = new List<InfoGastosCV>();
          
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand("usp_SelectGASTOSCVHistoria", cn);
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@CODIGO", -1);
                cd.Parameters.AddWithValue("@ANOD ", anod);
                cd.Parameters.AddWithValue("@MESD", mesd);
                cd.Parameters.AddWithValue("@ANOH ", anoh);
                cd.Parameters.AddWithValue("@MESH", mesh);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (objReader.Read())
                {
                    InfoGastosCV item = new InfoGastosCV();
                    try
                    {
                        item.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                        item.CTVCodigo = ((int)objReader["CTVCODIGO"]);
                        item.Tipo = (TipoCuentaVariable)Convert.ToInt16(objReader["CTVTIPO"]);
                        item.Ano = (int)objReader["ANO"];

                        item.DescontarCte = Convert.ToBoolean(objReader["DESCONTAR"]);
                        item.Deuda = 0;
                        item.FechaPago = Convert.ToDateTime(objReader["FECHAPAGO"]);
                        item.FormadePago = (FormaPago)Convert.ToInt16(objReader["FORMAPAGO"]);
                        item.GVFechaVto = Convert.ToDateTime(objReader["FECHAPAGO"]);
                        item.GVLecturaActual = Convert.ToDecimal(objReader["GVCLECTURACATUAL"]);
                        item.GVLecturaAnterior = Convert.ToDecimal(objReader["GVLECTURAANTERIOR"]);
                        item.GVMontoCancelado = Convert.ToDecimal(objReader["GVMONTOCANCELADO"]);
                        item.GVMontoFijo = Convert.ToDecimal(objReader["MONTOFIJO"]);
                        item.LecturaCM = objReader["LECTURACM"] is DBNull ? 0 : Convert.ToDecimal(objReader["LECTURACM"]);
                        item.Mes = Convert.ToInt16(objReader["MES"]);
                        item.Trifasico = Convert.ToBoolean(objReader["TRIFASICO"]);
                        item.PrecioU = Convert.ToDecimal(objReader["PRECIOUNITARIO"]);
                        item.Medidor = objReader["MEDIDOR"] is DBNull ? String.Empty : Convert.ToString(objReader["MEDIDOR"]);
                        item.GVFechaLectura = (objReader["FECHALEC"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(objReader["FECHALEC"]));
                        item.Consumo = Convert.ToDecimal(objReader["CONSUMO"]);
                        InfoNomina nomina = Datos.Nomina.BuscarNomina(item.Mes, item.Ano);
                        item.setCostoTotal(Convert.ToDecimal(objReader["COSTO"]), (nomina == null) ? 1 : nomina.id);
                        result.Add(item);
                    }
                    catch (Exception ez)
                    {
                        throw new Exception("Revisar lectura de la propiedad:" + item.IdPropiedad + " para la cuenta " + Datos.CuentaVariable.Buscar(item.CTVCodigo).CtvDescripcion + "   " + ez.InnerException.Source);
                    }
                }
            }
            #region Segunda Parte Lista
            using (SqlConnection cn2 = new SqlConnection(StringConexion()))
            {
                cn2.Open();
                SqlCommand cd2 = new SqlCommand(PA.GASTOSCVBUSCARINACTIVOS, cn2);
                cd2.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd2.CommandType = CommandType.StoredProcedure;
                SqlDataReader objReader2 = cd2.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader2.Read())
                {
                    InfoGastosCV item = new InfoGastosCV();

                    item.Ano = (int)objReader2["ANO"];

                    item.CTVCodigo = ((int)objReader2["CTVCODIGO"]);
                    item.Tipo = (TipoCuentaVariable)Convert.ToInt16(objReader2["CTVTIPO"]);

                    item.IdPropiedad = Convert.ToInt16(objReader2["IDPROPIEDAD"]);
                    item.Mes = Convert.ToInt16(objReader2["MES"]);
                    item.PrecioU = Convert.ToDecimal(objReader2["PRECIO"]);
                    item.flag = true;
                    InfoNomina nom = Datos.Nomina.BuscarNomina(item.Mes, item.Ano);
                    item.setCostoTotal(objReader2["DEUDA"] is DBNull ? 0 : Convert.ToDecimal(objReader2["DEUDA"]), (nom == null) ? 1 : nom.id);
                    item.Deuda = item.getCostoTotal();
                    if (item.Deuda > 0 && !ExisteCuentaEnLista(result, item)) result.Add(item);
                }
            }

            #endregion
            return result;
        }

    }
}

	