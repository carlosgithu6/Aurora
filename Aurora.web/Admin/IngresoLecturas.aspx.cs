using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Text;
using System.IO;
using Aurora.Clases.Base;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base.Encriptacion;
using Aurora.Web.UI;
using System.Globalization;


namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador,Perfil.Usuario })]
    public partial class IngresoLecturas : Autenticada
    {
        string UploadDirectory = "~/Admin/UploadControl/";
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                AppSettingsReader appSettReader = new AppSettingsReader();
                int anobase = Convert.ToInt16(appSettReader.GetValue("ano1", typeof(int)));
                UI.Utiles.LlenarCombox(ref lstAnos, UI.Utiles.Anos(anobase));
                List<InfoCuentaVariable> lista = Aurora.Clases.Negocio.CuentaVariable.Lista(false);
                foreach (InfoCuentaVariable item in lista)
                {
                    lstTipoCV.Items.Add(item.CtvDescripcion,item.CtvCodigo);
                }
            }
           
            if (IsCallback)
            {
                System.Threading.Thread.Sleep(500);
            }
            if (Mes != 0 && Ano != 0 && Convert.ToInt16((lstTipoCV.SelectedItem.Value)) != 0)
            {
                CargarGrilla(Mes, Ano, Convert.ToInt16((lstTipoCV.SelectedItem.Value)));
            }
        }
        protected void Grilla_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            
        }

        protected void Grilla_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                InfoGastosCV gasto = new InfoGastosCV();
                gasto.IdPropiedad = Convert.ToInt16(e.NewValues["IDPROPIEDAD"]);
                gasto.Mes = Mes;
                gasto.Ano = Ano;
                gasto.CTVCodigo = Convert.ToInt16(e.NewValues["CTVCODIGO"]);
                string tipo = e.NewValues["CTVTIPO"].ToString();
                switch (tipo)
                {
                    case "Agua": { gasto.Tipo = TipoCuentaVariable.Agua; break; }
                    case "Luz": { gasto.Tipo = TipoCuentaVariable.Electricidad; break; }
                    case "Recuperación Gastos": { gasto.Tipo = TipoCuentaVariable.RecuperacionGastos; break; }
                    case "Otro": { gasto.Tipo = TipoCuentaVariable.Otro; break; }
                }
    
                gasto.GVFechaLectura = Convert.ToDateTime(e.NewValues["FECHALEC"]);
                gasto.GVLecturaActual = Convert.ToDecimal(e.NewValues["GVCLECTURACATUAL"]);
                gasto.GVLecturaAnterior = Convert.ToDecimal(e.NewValues["LECTURAANTERIOR"]);
                if (e.OldValues["LECTURAANTERIOR"] is System.DBNull || Convert.ToDecimal(e.OldValues["LECTURAANTERIOR"]) == 0)
                {
                    Aurora.Clases.Negocio.GastosCV.PonerPrimeraLectura(gasto.GVLecturaAnterior, gasto.IdPropiedad, gasto.CTVCodigo, gasto.GVLecturaActual,gasto.GVFechaLectura);
                }
                gasto.GVMontoCancelado = Convert.ToDecimal(e.NewValues["GVMONTOCANCELADO"]);
                gasto.GVMontoFijo = Convert.ToDecimal(e.NewValues["MONTOFIJO"]);
                gasto.GVFechaVto = DateTime.Now.AddMonths(1);
                int codigo = Convert.ToInt16(e.NewValues["CTVCODIGO"]);
                if (Aurora.Clases.Negocio.CuentaVariable.Buscar(codigo).CtvTipo == TipoCuentaVariable.Electricidad)
                {
                    gasto.Trifasico = Convert.ToBoolean(e.NewValues["TRIFASICO"]);
                    gasto.Factor = Convert.ToDecimal(e.NewValues["FACTOR"]);
                }
                else
                    gasto.Trifasico = false;
                Aurora.Clases.Negocio.GastosCV.Modificar(gasto);
                btnBuscarNomina_Click(null, null);
                e.Cancel = true;
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        private int Mes
        {
            get
            {
                return ViewState["mes"] == null ? 0 : Convert.ToInt16(ViewState["mes"]);
            }
            set
            {
                ViewState["mes"] = value;
            }
        }
        private int Ano
        {
            get
            {
                return ViewState["ano"] == null ? 0 : Convert.ToInt16(ViewState["ano"]);
            }
            set
            {
                ViewState["ano"] = value;
            }
        }
        private TipoCuentaVariable tipoCuentaVariable
        {
            get
            {
                return ViewState["TipoCuentaVariable"] == null ? (TipoCuentaVariable) 0: (TipoCuentaVariable)(ViewState["TipoCuentaVariable"]);
            }
            set
            {
                ViewState["TipoCuentaVariable"] = value;
            }
        }

        protected void btnBuscarNomina_Click(object sender, EventArgs e)
        {
            Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
            Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
            int codigo = Convert.ToInt16((lstTipoCV.SelectedItem.Value));
            lblError.Text = "";
            lblMensaje.Text = "";
            CargarGrilla(Mes, Ano, codigo);
        }

        void CargarGrilla(int mes, int ano, int codigo)
        {
            DevExpress.Web.ASPxGridView.GridViewColumn col1 = Grilla.Columns["TRIFASICO"];
            Grilla.Columns.Remove(col1);
            DevExpress.Web.ASPxGridView.GridViewColumn col2 = Grilla.Columns["FACTOR"];
            Grilla.Columns.Remove(col2);
           
            DataTable dt = Aurora.Clases.Negocio.CuentaVariable.ListadoIngresoCV(mes, ano, codigo);
            //if ((TipoCuentaVariable)codigo != TipoCuentaVariable.Luz)
            if (Aurora.Clases.Negocio.CuentaVariable.Buscar(codigo).CtvTipo != TipoCuentaVariable.Electricidad)
            {
                dt.Columns.Remove("TRIFASICO");
                dt.Columns.Remove("FACTOR");
                DevExpress.Web.ASPxGridView.GridViewColumn col = Grilla.Columns["TRIFASICO"];
                Grilla.Columns.Remove(col);
                DevExpress.Web.ASPxGridView.GridViewColumn col3 = Grilla.Columns["FACTOR"];
                Grilla.Columns.Remove(col3);
            }
            else
            {
                DevExpress.Web.ASPxGridView.GridViewDataCheckColumn col = new DevExpress.Web.ASPxGridView.GridViewDataCheckColumn();
                col.Name = "TRIFASICO";
                col.FieldName = "TRIFASICO";
                Grilla.Columns.Add(col);

                DevExpress.Web.ASPxGridView.GridViewDataTextColumn colt = new DevExpress.Web.ASPxGridView.GridViewDataTextColumn();
                colt.Name = "FACTOR";
                colt.FieldName = "FACTOR";
                Grilla.Columns.Add(colt);
            }
            Grilla.Columns["Opciones"].Visible = true;
            Grilla.DataSource = dt;
            Grilla.DataBind();
            if (Mes != 0 && Ano != 0)
            {
                InfoNomina nomina = Aurora.Clases.Negocio.Nomina.BuscarNomina(Mes, Ano);
                if (nomina != null && nomina.FechaCierre != DateTime.MinValue)
                {
                    Grilla.Columns["Opciones"].Visible = false;
                }
            }
        }

        protected void Grilla_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Grilla.Columns["CTVCODIGO"].Visible = true;
        }

        protected void Grilla_CancelRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Grilla.Columns["CTVCODIGO"].Visible = false;
        }

        protected void btnPlantilla_Click(object sender, EventArgs e)
        {
            Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
            Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
            int codigo = Convert.ToInt16((lstTipoCV.SelectedItem.Value));

            if (Mes != 0 && Ano != 0 && Convert.ToInt16((lstTipoCV.SelectedItem.Value)) != 0)
            {
                CargarPlantilla(Mes, Ano, Convert.ToInt16((lstTipoCV.SelectedItem.Value)));
            }
            
        }



        void CargarPlantilla(int mes, int ano, int codigo)
        {   
           AppSettingsReader appSettReader = new AppSettingsReader();
           string sep = appSettReader.GetValue("separadorCSV", typeof(string)).ToString();
           if (Mes != 0 && Ano != 0)
            {
               // InfoNomina nomina = Aurora.Clases.Negocio.Nomina.BuscarNomina(Mes, Ano);
                //if (nomina != null /*&& nomina.FechaCierre == DateTime.MinValue*/) // si la nomina existe y no esta cerrada.
                //{
                //   // DataTable dt = Aurora.Clases.Negocio.CuentaVariable.ListadoIngresoCV(mes, ano, codigo);
                    DataTable dt = Aurora.Clases.Negocio.CuentaVariable.ListadoIngresoCVforCSV(mes, ano, codigo);
                   
                    DataView dv = dt.DefaultView;
                    StringBuilder tmpCSV = new StringBuilder();
                    string tmpLinea = "";

                    tmpCSV.Append("IDPROPIEDAD" + sep + "NOMBRE" + sep + "NUMERO" + sep + "LETRA" + sep + "SECTOR" + sep + "LECTURA ANTERIOR" + sep+ "LECTURA ACTUAL" + sep + "FECHA LECTURA");
                    tmpCSV.Append("\r\n");
                    foreach (DataRowView drv in dv)
                    {
                        
                        tmpLinea = "";
                        //Creamos la linea ...
                        tmpLinea += drv["IDPROPIEDAD"].ToString() + sep;
                        tmpLinea += drv["NOMBRES"].ToString() + " " + drv["APPATERNO"].ToString() + " " + drv["APMATERNO"].ToString() + sep;
                        tmpLinea += drv["NUMEROPARCELA"].ToString() + sep;
                        tmpLinea += drv["LETRAPARCELA"].ToString() + sep;
                        tmpLinea += drv["SECTOR"].ToString() + sep; 
                        tmpLinea += drv["LECTURAANTERIOR"].ToString() + sep;
                        tmpLinea += "<lectura>".ToString() + sep; //LECTURA ACTUAL
                        tmpLinea += "<fecha lectura>".ToString(); //fecha lectura

                        //Añadimos la linea al fichero ...
                        tmpCSV.Append(tmpLinea + "\r\n");
                    }
                    try
                    {
                        //string csvFile = codigo.ToString()+"_"+Aurora.Clases.Negocio.CuentaVariable.Buscar(codigo).CtvDescripcion.Replace(" ","") + "_" + ano.ToString() + "_" + mes.ToString() + ".csv";
                        //string csvFile = ano.ToString() + "_" + mes.ToString() + "_" + Aurora.Clases.Negocio.CuentaVariable.Buscar(codigo).CtvDescripcion.Replace(" ", "") + "_" + codigo.ToString()+ ".csv";
                        string csvFile = "ANO" + "_" + "MES" + "_" + Aurora.Clases.Negocio.CuentaVariable.Buscar(codigo).CtvDescripcion.Replace(" ", "") + "_" + codigo.ToString() + ".csv"; 
                        string csvFilePath = Server.MapPath("~") + "/Admin/csvPlantillas/" + csvFile;
                        using (StreamWriter sw = new StreamWriter(@csvFilePath, false, System.Text.Encoding.ASCII))
                        {
                            sw.Write(tmpCSV.ToString());
                            sw.Close();
                        }

                        //Preparamos el response ...
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + csvFile);
                        Response.ContentType = "application/vnd.csv";
                        Response.Charset = "ASCII";
                        Response.ContentEncoding = System.Text.Encoding.ASCII;

                        //Cargamos el archivo en memoria ...
                        byte[] MyData = (byte[])System.IO.File.ReadAllBytes(csvFilePath);
                        Response.BinaryWrite(MyData);

                        //Eliminamos el archivo ...
                        System.IO.File.Delete(csvFilePath);

                        //Terminamos el response ..
                        Response.End();

                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "CSV", "alert('Error al exportar el fichero')", true);
                    }
                        
                //}
                //else
                //{
                //    ClientScript.RegisterClientScriptBlock(this.GetType(), "CSV", "alert('Plantilla no disponible')", true);
                //}
            }
        }

        protected void btnUpload0_Click(object sender, EventArgs e)
        {
            StringBuilder error = new StringBuilder();
            try
            {
                lblMensaje.Text = "";
                lblError.Text = "";
                String filename = FileUpload1.FileName.ToLower();
                String[] splitname = filename.Split('_');
                int mes = 0;
                int ano = 0;
                int codigo = 0;

               

                if (!filename.EndsWith("csv") || splitname.Length!=4) throw new Exception(" Nombre de Archivo inválido, debe ser un csv y cumplir con el formato del nombre<br>");

                if ((!int.TryParse(splitname[1], out mes) && (mes < 1 || mes > 12)))
                {
                    error.Append("El archivo tiene problema en el nombre. MES\n");
                }

                if ((!int.TryParse(splitname[0], out ano) /*&& (ano < 2018)*/))
                {
                    error.Append("El archivo tiene problema en el nombre. AÑO\n");
                }

                if ((!int.TryParse(splitname[3].Split('.')[0], out codigo) && (Aurora.Clases.Negocio.CuentaVariable.Buscar(codigo) != null)))
                {
                    error.Append("El archivo tiene problema en el nombre. Código de cuenta no existe o es inválido");
                }

                if (error.Length == 0)
                { // si no hay errores en el nombre del archivo...
                    
                    InfoNomina nomina = Aurora.Clases.Negocio.Nomina.BuscarNomina(mes, ano);
                    if (nomina != null && nomina.FechaCierre == DateTime.MinValue) // si la nomina existe y no esta cerrada.
                    {
                        if (ckbUpdate.Checked)
                        {
                            Aurora.Clases.Negocio.GastosCV.BorrarLecturas(mes, ano, codigo);
                        }
                        SalvarArchivo(FileUpload1, mes, ano, codigo);
                    }
                    else
                    {
                        error.Append("El archivo representa una nómina que no existe o no se puede modificar por estar cerrada.");
                    }
                

                }
                if (error.Length > 0) lblError.Text = error.ToString();
            }
           
            catch (Exception ee)
            {
                lblError.Text = ee.Message;
            }
        }

        string SalvarArchivo(FileUpload uploadedFile,int mes, int ano, int codigo)
        {
      
            int CantidadProcesadas = 0;
            int CantidadMalas = 0;
            StringBuilder error = new StringBuilder();
            try
            {
                if (!uploadedFile.HasFile)
                    return string.Empty;

                string fileName = Path.Combine(MapPath(UploadDirectory), uploadedFile.FileName);
                uploadedFile.SaveAs(fileName);

                Aurora.Clases.Negocio.GastosCV.ActualizarLecturasFromCSV(fileName, ano, mes, codigo, ref CantidadProcesadas, ref CantidadMalas, ref error);

                if (error.Length > 0)
                {
                    lblError.Text = "En la inserción se detectaron algunos problemas:<br>" + error.ToString();
                    lblMensaje.Text = "Se procesaron correctamente:" + CantidadProcesadas + " lineas. <br> No se procesaron " + CantidadMalas + "<br>";
                }
                else
                {
                    lblMensaje.Text = "Se procesaron correctamente:" + CantidadProcesadas + " lineas.";
                }
                return fileName;
            }
            catch (Exception ee)
            {
               
                lblError.Text = ee.Message;
                return string.Empty;
            }

        }
      
       
    }
}