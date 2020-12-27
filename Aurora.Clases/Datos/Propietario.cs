using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aurora.Clases.Entidad;
namespace Aurora.Clases.Datos
{
    internal class Propietario : BaseDatos
    {
        public static InfoPropietario Crear(InfoPropietario infoProp)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOCREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", 0).Direction = ParameterDirection.InputOutput;
                cd.Parameters.AddWithValue("@RUT", infoProp.Rut);
                cd.Parameters.AddWithValue("@NOMBRES", infoProp.Nombres);
                cd.Parameters.AddWithValue("@APPATERNO", infoProp.Apellido1);
                cd.Parameters.AddWithValue("@APMATERNO", infoProp.Apellido2);
                cd.Parameters.AddWithValue("@SOCIO", infoProp.EsSocio);
                if (infoProp.FechaIngresoSocio == DateTime.MinValue)
                {
                    cd.Parameters.AddWithValue("@FECHAINGRESOSOCIO", DBNull.Value);
                }
                else
                {
                    cd.Parameters.AddWithValue("@FECHAINGRESOSOCIO", infoProp.FechaIngresoSocio);
                }
                if (infoProp.FechaSalidaSocio == DateTime.MinValue)
                {
                    cd.Parameters.AddWithValue("@FECHASALIDASOCIO", DBNull.Value);
                }
                else
                {
                    cd.Parameters.AddWithValue("@FECHASALIDASOCIO", infoProp.FechaSalidaSocio);
                }
                cd.Parameters.AddWithValue("@DIRECCIONCONTACTO", infoProp.DireccionContacto);
                cd.Parameters.AddWithValue("@MAIL", infoProp.Mail);
                cd.Parameters.AddWithValue("@TELEFONO", infoProp.Telefono);
                cd.Parameters.AddWithValue("@SECTOR", infoProp.Sector);
                cd.Parameters.AddWithValue("@LETRAPARCELA", infoProp.LetraParcela);
                cd.Parameters.AddWithValue("@NUMEROPARCELA", infoProp.NumeroParcela);
                cd.Parameters.AddWithValue("@TAMANOHECT", infoProp.TamanoHectareas);
                cd.Parameters.AddWithValue("@NUMEROCASAS", infoProp.NumeroCasas);
                cd.ExecuteNonQuery();
                return Buscar(Convert.ToInt16(cd.Parameters["@IDPROPIEDAD"].Value));
            }

        }
        public static InfoPropietario Modificar(InfoPropietario infoProp)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOMODIFICAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoProp.IdPropiedad);
                cd.Parameters.AddWithValue("@RUT", infoProp.Rut);
                cd.Parameters.AddWithValue("@NOMBRES", infoProp.Nombres);
                cd.Parameters.AddWithValue("@APPATERNO", infoProp.Apellido1);
                cd.Parameters.AddWithValue("@APMATERNO", infoProp.Apellido2);
                cd.Parameters.AddWithValue("@SOCIO", infoProp.EsSocio);
                if (infoProp.FechaIngresoSocio == DateTime.MinValue)
                {
                    cd.Parameters.AddWithValue("@FECHAINGRESOSOCIO", DBNull.Value);
                }
                else
                {
                    cd.Parameters.AddWithValue("@FECHAINGRESOSOCIO", infoProp.FechaIngresoSocio);
                }
                if (infoProp.FechaSalidaSocio == DateTime.MinValue)
                {
                    cd.Parameters.AddWithValue("@FECHASALIDASOCIO", DBNull.Value);
                }
                else
                {
                    cd.Parameters.AddWithValue("@FECHASALIDASOCIO", infoProp.FechaSalidaSocio);
                }
                cd.Parameters.AddWithValue("@DIRECCIONCONTACTO", infoProp.DireccionContacto);
                cd.Parameters.AddWithValue("@MAIL", infoProp.Mail);
                cd.Parameters.AddWithValue("@TELEFONO", infoProp.Telefono);
                cd.Parameters.AddWithValue("@SECTOR", infoProp.Sector);
                cd.Parameters.AddWithValue("@LETRAPARCELA", infoProp.LetraParcela);
                cd.Parameters.AddWithValue("@NUMEROPARCELA", infoProp.NumeroParcela);
                cd.Parameters.AddWithValue("@TAMANOHECT", infoProp.TamanoHectareas);
                cd.Parameters.AddWithValue("@NUMEROCASAS", infoProp.NumeroCasas);
                cd.Parameters.AddWithValue("@FECHACREACION", infoProp.FechaCreacion);
                cd.Parameters.AddWithValue("@ELIMINADO", infoProp.Eliminado);
                cd.Parameters.AddWithValue("@ACTIVA", infoProp.PropiedadActiva);
                cd.ExecuteNonQuery();
            }
            return Buscar(infoProp.IdPropiedad);
        }
        public static InfoPropietario Buscar(int idPropiedad)
        {
            InfoPropietario _result = null;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (objReader.Read())
                {
                    _result = new InfoPropietario();
                    _result.IdPropiedad = Convert.ToInt16(objReader["IDPROPIEDAD"]);
                    _result.Rut = objReader["RUT"].ToString();
                    _result.Nombres = objReader["NOMBRES"].ToString();
                    _result.Apellido1 = objReader["APPATERNO"].ToString();
                    _result.Apellido2 = objReader["APMATERNO"].ToString();
                    _result.EsSocio = Convert.ToBoolean(objReader["SOCIO"].ToString());
                    _result.FechaIngresoSocio = objReader["FECHAINGRESOSOCIO"] != DBNull.Value ? Convert.ToDateTime(objReader["FECHAINGRESOSOCIO"]) : DateTime.MinValue;
                    _result.FechaSalidaSocio = objReader["FECHASALIDASOCIO"] != DBNull.Value ? Convert.ToDateTime(objReader["FECHASALIDASOCIO"]) : DateTime.MinValue;
                    _result.DireccionContacto = objReader["DIRECCIONCONTACTO"].ToString();
                    _result.Mail = objReader["MAIL"].ToString();
                    _result.Telefono = objReader["TELEFONO"].ToString();
                    _result.Sector = objReader["SECTOR"].ToString();
                    _result.LetraParcela = objReader["LETRAPARCELA"].ToString();
                    _result.NumeroParcela = Convert.ToInt16(objReader["NUMEROPARCELA"]);
                    _result.TamanoHectareas = Convert.ToInt16(objReader["TAMANOHECT"]);
                    _result.NumeroCasas = Convert.ToInt16(objReader["NUMEROCASAS"]);
                    _result.FechaCreacion = Convert.ToDateTime(objReader["FECHACREACION"]);
                    _result.FechaActualizacion = Convert.ToDateTime(objReader["FECHAACTUALIZACION"]);
                    _result.Eliminado = Convert.ToBoolean(objReader["ELIMINADO"]);
                    _result.PropiedadActiva = Convert.ToBoolean(objReader["ACTIVA"]);
                    _result.SaldoCuentaCte = Convert.ToDecimal(objReader["SALDOCTE"]);
                    _result.DeudaInical = Convert.ToDecimal(objReader["DEUDAINICIAL"]);
                    _result.DeudaPendiente = Convert.ToDecimal(objReader["DEUDAPENDIENTE"]);

                }
                return _result;
            }
        }
        public static void Eliminar(int idPropiedad)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOELIMINAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.ExecuteNonQuery();
            }
        }
        public static DataTable Listar(bool eliminados, bool activos)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOLISTAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ELIMINADO", eliminados);
                cd.Parameters.AddWithValue("@ACTIVO", activos);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static List<InfoItem> List(bool eliminados, bool activos)
        {
            List<InfoItem> result = new List<InfoItem>();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOLISTARESPECIAL, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ELIMINADO", eliminados);
                cd.Parameters.AddWithValue("@ACTIVO", activos);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader.Read())
                {
                    InfoItem item = new InfoItem();
                    item.Text = objReader["PROPIEDAD"].ToString();
                    item.Value = (int)objReader["IDPROPIEDAD"];
                    result.Add(item);
                }
                return result;
            }
        }
        public static DataTable ListarDeudaInicial(bool eliminados)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOLISTARDEUDA, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ELIMINADO", eliminados);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static DataTable BuscarCuentasFijas(InfoPropietario infoProp)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOCUENTAFIJABUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoProp.IdPropiedad);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static DataTable BuscarCuentasVariables(InfoPropietario infoProp)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOCUENTAVARIABLEBUSCAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoProp.IdPropiedad);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

        public static void AbonarACuentaCorriente(InfoPropietario infoProp, decimal monto)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOABONAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoProp.IdPropiedad);
                cd.Parameters.AddWithValue("@MONTO", monto);
                cd.ExecuteNonQuery();
            }
        }
        public static void PagarDeuda(InfoPropietario infoProp, decimal monto, bool descontarCte)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOPAGARDEUDA, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoProp.IdPropiedad);
                cd.Parameters.AddWithValue("@MONTO", monto);
                cd.Parameters.AddWithValue("@DESCONTAR", descontarCte);
                cd.ExecuteNonQuery();
            }
        }
        public static void PonerDeudaInicial(InfoPropietario infoProp, decimal monto)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOSETDEUDAINICIAL, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", infoProp.IdPropiedad);
                cd.Parameters.AddWithValue("@MONTO", monto);
                cd.ExecuteNonQuery();
            }
        }

   

        public static List<InfoGastosCFDeuda> DeudasCuentasFijas(int idPropiedad)
        {
            List<InfoGastosCFDeuda> result = new List<InfoGastosCFDeuda>();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.GASTOSCFBUSCARTODASDEUDA, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);

                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader.Read())
                {
                    InfoGastosCFDeuda item = new InfoGastosCFDeuda();
                    item.Ano = (int)objReader["ANO"];
                    item.IdPropiedad = (int)objReader["IDPROPIEDAD"];
                    item.Mes = (int)objReader["MES"];
                    item.Deuda = (objReader["DEUDA"] is DBNull || Convert.ToDecimal(objReader["DEUDA"]) < 0) ? (decimal)0 : Convert.ToDecimal(objReader["DEUDA"]);
                    item.CFCodigo = (int)objReader["CFCODIGO"];
                    result.Add(item);
                }
                return result;
            }
        }

        public static List<InfoGastosCVDeuda> DeudasCuentasVariables(int idPropiedad)
        {
            List<InfoGastosCVDeuda> result = new List<InfoGastosCVDeuda>();
            List<InfoGastosCV> notascobroCV = GastosCV.BuscarListaGastosCVTodoPropiedad(idPropiedad);
            foreach (InfoGastosCV igv in notascobroCV)
            {
                decimal deuda = (igv.getCostoTotal() /*igv.GVMontoFijo*/ - igv.GVMontoCancelado);
                if (deuda > 2)//cinco pesos.
                {
                    InfoGastosCVDeuda igcvd = new InfoGastosCVDeuda();
                    igcvd.Ano = igv.Ano;
                    igcvd.Mes = igv.Mes;
                    igcvd.CTVCodigo = igv.CTVCodigo;
                    igcvd.CTVTipo = igv.Tipo;
                    igcvd.Deuda = deuda;
                    igcvd.IdPropiedad = igv.IdPropiedad;
                    result.Add(igcvd);
                }
            }

            return result;
        }
        //public static List<InfoGastosCVDeuda> DeudasCuentasVariables(int idPropiedad)
        //{
        //    List<InfoGastosCVDeuda> result = new List<InfoGastosCVDeuda>();
        //    using (SqlConnection cn = new SqlConnection(StringConexion()))
        //    {
        //        cn.Open();
        //        SqlCommand cd = new SqlCommand(PA.GASTOSCVBUSCARTODASDEUDA, cn);
        //        cd.CommandType = CommandType.StoredProcedure;
        //        cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
        //        SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //        while (objReader.Read())
        //        {
        //            InfoGastosCVDeuda item = new InfoGastosCVDeuda();
        //            item.Ano = (int)objReader["ANO"];
        //            item.IdPropiedad = (int)objReader["IDPROPIEDAD"];
        //            item.Mes = (int)objReader["MES"];
        //            item.Deuda = (objReader["DEUDA"] is DBNull || Convert.ToDecimal(objReader["DEUDA"]) < 0) ? (decimal)0 : Convert.ToDecimal(objReader["DEUDA"]);
        //            item.CTVCodigo = (int)objReader["CTVCODIGO"];
        //            result.Add(item);
        //        }
        //        return result;
        //    }
        //}
        public static DataTable ListarMorosos(bool eliminados, bool activos)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOLISTARMOROSOS, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@ELIMINADO", eliminados);
                cd.Parameters.AddWithValue("@ACTIVO", activos);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static void PagarDeudaDeCuentas(int IdPropiedad, decimal DeudaCFija, decimal DeudaCVariable)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOPAGARDEUDASCUENTAS, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", IdPropiedad);
                cd.Parameters.AddWithValue("@MONTOCUENTAFIJA", DeudaCFija);
                cd.Parameters.AddWithValue("@MONTOCUENTAVAR", DeudaCVariable);
                cd.ExecuteNonQuery();
            }
        }
        public static decimal DeudaCuentasFijas(int idPropiedad)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIODEUDASFIJAS, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);

                return Convert.ToDecimal(cd.ExecuteScalar());
            }
        }
        public static decimal DeudaCuentasVariables(int idPropiedad)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIODEUDASVARIABLES, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);

                return Convert.ToDecimal(cd.ExecuteScalar());
            }
        }

        public static decimal BuscarDeudaFijaPorTipo(int idPropiedad, int codigo)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIODEUDASFIJASPORTIPO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@TIPO", codigo);
                return Convert.ToDecimal(cd.ExecuteScalar());
            }
        }
        public static decimal BuscarDeudaVarPorTipo(int idPropiedad, int codigo)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIODEUDASVARIABLESPORTIPO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@TIPO", codigo);
                return Convert.ToDecimal(cd.ExecuteScalar());
            }
        }

        public static DateTime BuscarPrimeraFechaDeudaVarPorTipo(int idPropiedad, int codigo)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOFECHACORTEDEUDASVARIABLESPORTIPO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@TIPO", codigo);
                Object res = cd.ExecuteScalar();
                DateTime result = res is DBNull ? DateTime.MinValue : Convert.ToDateTime(res);
                return result;
            }
        }
        public static DateTime BuscarFechaCorteDeudaFijaPorTipo(int idPropiedad, int codigo)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOFECHACORTEFECHACORTEDEUDASFIJASPORTIPO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.Parameters.AddWithValue("@TIPO", codigo);
                return Convert.ToDateTime(cd.ExecuteScalar());
            }
        }
        public static void EliminarUltimoAbono(int idPropiedad)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOELIMINARULTIMOABONO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.ExecuteNonQuery();
            }
        }
        private static DataSet Cartola(int IdPropiedad)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOCARTOLA, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", IdPropiedad);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(ds);
            }
            return ds;
        }
        internal static void PonerDeudasACero(int idPropiedad)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIODEUDASACERO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idPropiedad);
                cd.ExecuteNonQuery();
            }
        }
        public static DateTime ProximoDiaHabil(DateTime dia)
        {
            DateTime _result = DateTime.MinValue; ;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();

                string sql = "SELECT dbo.ProximoDiaHabil('" + dia.Month + "/" + dia.Day + "/" + dia.Year + "')";
                SqlCommand cd = new SqlCommand(sql, cn);
                cd.CommandType = CommandType.Text;
                _result = (DateTime)cd.ExecuteScalar();

                return _result;
            }
        }
        public static DataTable PropietariosSinConLectaraActualEnLuzOAgua(int mes, int ano, int sinLectura)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOSSINLECTURAACTUALENLUZOAGUA, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@mes", mes);
                cd.Parameters.AddWithValue("@ano", ano);
                cd.Parameters.AddWithValue("@sin", sinLectura);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static DataTable MailEnviados(int mes, int ano)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOBUSCARMAILENVIADOS, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@mes", mes);
                cd.Parameters.AddWithValue("@ano", ano);
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }
        public static int RegistrarMail(int idprop, int mes, int ano)
        {
            int result = 0;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOMAILENVIOCREAR, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idprop);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);

                result = Convert.ToInt16(cd.ExecuteScalar());
            }
            return result;
        }
        public static void BorrarMail(int idprop, int mes, int ano)
        {

            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOBORRARMAIL, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idprop);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.ExecuteNonQuery();

            }

        }
        public static List<InfoPagoSimple> BuscarPagos(int idprop, int mes, int ano)
        {
            List<InfoPagoSimple> result = new List<InfoPagoSimple>();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOBUSCARPAGO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idprop);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (objReader.Read())
                {
                    InfoPagoSimple item = new InfoPagoSimple();
                    item.ano = ano;
                    item.idpropiedad = idprop;
                    item.mes = mes;
                    item.submonto = Convert.ToDecimal(objReader["SUBMONTOCANCELADO"]);
                    item.concepto = (string)objReader["CONCEPTO"];
                    item.fechaPago = (DateTime)objReader["FECHAPAGO"];
                    item.formaPago = (FormaPago)objReader["FORMAPAGO"];

                    result.Add(item);
                }
                return result;
            }
        }
        public static void SellarRecibo(int idpropiedad, int mes, int ano, int folio)
        {
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOSELLARRECIBO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idpropiedad);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@FOLIO", folio);
                cd.ExecuteNonQuery();

            }
        }
        public static DataTable ListarConsumo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOLISTARCONSUMO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cd);
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable Cartola_for_Excel(int id_propiedad)
        {
            DataSet ds = Cartola(id_propiedad);
            List<InfoGastosCV> listaCV = new List<InfoGastosCV>();
            List<InfoGastosCF> listaCF = new List<InfoGastosCF>();
            DataTable dt0 = ds.Tables[0];
            foreach (DataRow dr in dt0.Rows)
            {
                if (Convert.ToString(dr["TIPO"]) == "V")
                { 
                    InfoGastosCV igv = new InfoGastosCV();
                    igv.IdPropiedad = id_propiedad;
                    igv.Mes = Convert.ToInt16(dr["MES"]);
                    igv.Ano = Convert.ToInt16(dr["ANO"]);
                    igv.CTVCodigo = Convert.ToInt16(dr["CODIGO"]);
                    igv=GastosCV.Buscar(igv);
                    if (igv != null)
                        listaCV.Add(igv);
                 
                }
                if (Convert.ToString(dr["TIPO"]) == "F")
                {
                    InfoGastosCF igf = new InfoGastosCF();
                    igf.IdPropiedad = id_propiedad;
                    igf.Mes = Convert.ToInt16(dr["MES"]);
                    igf.Ano = Convert.ToInt16(dr["ANO"]);
                    igf.CFCodigo = (Convert.ToInt16(dr["CODIGO"]));
                    igf = GastosCF.Buscar(igf);
                    igf.GCFMonto = Convert.ToInt32((igf.GCFMonto * UF.Buscar(igf.Mes, igf.Ano).UF)); 
                    if (igf != null)
                        listaCF.Add(igf);
                                      
                }
            }


            DataTable dt = new DataTable();
            dt.Columns.Add("MES", typeof(int));
            dt.Columns.Add("ANO", typeof(int));
            dt.Columns.Add("CTVDESCRIPCION", typeof(String));
            dt.Columns.Add("COSTO", typeof(int));
            dt.Columns.Add("GVMONTOCANCELADO", typeof(int));
            dt.Columns.Add("FECHAPAGO", typeof(DateTime));
            dt.Columns.Add("FORMAPAGO", typeof(FormaPago));

            foreach (InfoGastosCV item in listaCV)
            {
                DataRow dr = dt.NewRow();
                dr["MES"] = item.Mes;
                dr["ANO"] = item.Ano;
                dr["CTVDESCRIPCION"] = Negocio.CuentaVariable.Buscar(item.CTVCodigo).CtvDescripcion;
                dr["COSTO"] = item.getCostoTotal();// +item.GVMontoFijo;
                dr["GVMONTOCANCELADO"] = item.GVMontoCancelado;
                dr["FECHAPAGO"] = item.FechaPago;
                dr["FORMAPAGO"] = item.FormadePago;
                dt.Rows.Add(dr);
            }

           
            foreach (InfoGastosCF item in listaCF)
            {
                DataRow dr = dt.NewRow();
                dr["MES"] = item.Mes;
                dr["ANO"] = item.Ano;
                dr["CTVDESCRIPCION"] = Negocio.CuentaFija.Buscar(item.CFCodigo).Descripcion;//(TipoCuentaFija)item.TipoCuenta;
                dr["COSTO"] = item.GCFMonto;
                dr["GVMONTOCANCELADO"] = item.GCFMontoCancelado;
                dr["FECHAPAGO"] = item.FechaPago;
                dr["FORMAPAGO"] = item.FormadePago;
                dt.Rows.Add(dr);
            }
            return dt;
        }



        public static Dictionary<int,InfoPagoSimple> BuscarPagos(int idprop, int mes, int ano, int codigo)
        {
            Dictionary<int, InfoPagoSimple> result = new Dictionary<int, InfoPagoSimple>();
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.PROPIETARIOBUSCARPAGOCTAVARIABLE, cn);
                cd.CommandType = CommandType.StoredProcedure;
                cd.Parameters.AddWithValue("@IDPROPIEDAD", idprop);
                cd.Parameters.AddWithValue("@MES", mes);
                cd.Parameters.AddWithValue("@ANO", ano);
                cd.Parameters.AddWithValue("@CODIGO", codigo);
                SqlDataReader objReader = cd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            
                while (objReader.Read())
                {
                    InfoPagoSimple item = new InfoPagoSimple();
                    item.ano = ano;
                    item.idpropiedad = idprop;
                    item.mes = mes;
                    item.submonto = Convert.ToDecimal(objReader["SUBMONTOCANCELADO"]);
                    item.concepto = (string)objReader["CONCEPTO"];
                    item.fechaPago = (DateTime)objReader["FECHAPAGO"];
                    item.formaPago = (FormaPago)objReader["FORMAPAGO"];
                    item.numpago = Convert.ToInt32(objReader["NUMMOV"]);
                    if (!result.ContainsKey(item.numpago))
                    {
                        result.Add(item.numpago, item);
                    }
                    
                }
                return result;
            }
        }
    }
}
