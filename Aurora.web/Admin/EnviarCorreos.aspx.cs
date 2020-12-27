using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Aurora.Clases.Base;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base.Encriptacion;
using Aurora.Web.UI;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.IO;
namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador,Perfil.Usuario })]
    public partial class EnviarCorreos : Autenticada
    {
       
      
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack)
            {
                AppSettingsReader appSettReader = new AppSettingsReader();
                int anobase = Convert.ToInt16(appSettReader.GetValue("ano1", typeof(int)));
                UI.Utiles.LlenarCombox(ref lstAnos, UI.Utiles.Anos(anobase));
               
            }
           
            //if (IsCallback)
            //{
            //    System.Threading.Thread.Sleep(500);
            //}
            if (Mes != 0 && Ano != 0)
            {
                CargarGrilla(Mes, Ano);
            }
            //if (!IsPostBack && !IsCallback)
            //{
            //    progress = 0;
            //}
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
       

        protected void btnBuscarNomina_Click(object sender, EventArgs e)
        {
            Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
            Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
           
            CargarGrilla(Mes, Ano);
        }

        void CargarGrilla(int mes, int ano)
        {
            DataTable dt = Aurora.Clases.Negocio.Propietario.PropietariosSinConLectaraActualEnLuzOAgua(mes, ano,1);
            gridNoMail.DataSource = dt;
            gridNoMail.DataBind();
            gridNoMail.Visible = dt.Rows.Count > 0;
            btnExport.Visible = gridNoMail.Visible;

            DataTable dt2 = Aurora.Clases.Negocio.Propietario.MailEnviados(mes, ano);

            gridMailEnviados.DataSource = dt2;
            gridMailEnviados.DataBind();
            gridMailEnviados.Visible = dt2.Rows.Count > 0;
            btnExportEnviados.Visible = gridMailEnviados.Visible;

            btnComenzarEnvio.Visible = true;
        }

        protected void btnExportE_Click(object sender, EventArgs e)
        {
            gridExporter.WriteXlsToResponse("NoMail-" + Mes+"-"+Ano, true);  

        }

     
       
        protected void btnComenzarEnvio_Click(object sender, EventArgs e)
        {
          
            DataTable dt2 = Aurora.Clases.Negocio.Propietario.PropietariosSinConLectaraActualEnLuzOAgua(Mes, Ano, 0);
            StringBuilder sb = new StringBuilder();
            AppSettingsReader appSettReader = new AppSettingsReader();
            string Initpath = Server.MapPath("~") + @"\Templates\";
            string smtp = Convert.ToString(appSettReader.GetValue("smtp", typeof(string)));
            string usernameMail = Convert.ToString(appSettReader.GetValue("usernameMail", typeof(string)));
            string passwordMail = Convert.ToString(appSettReader.GetValue("passwordMail", typeof(string)));
            bool enableSsl = Convert.ToBoolean(appSettReader.GetValue("enableSsl", typeof(int)));
            int port = Convert.ToInt16(appSettReader.GetValue("port", typeof(int)));
            int i = dt2.Rows.Count;
            int k = 0;
            sb.Append("Se enviaron <X> correos de: " + i.ToString());
           
            foreach (DataRow row in dt2.Rows)
            {
                InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(row["IDPROPIEDAD"]));
                
                try
                {
                               
                    if (Aurora.Clases.Negocio.Propietario.RegistrarMail(prop.IdPropiedad, Mes, Ano) == 1)//quiere decir que se insertó el registro o sea que se va a enviar...
                    {
                       // System.Threading.Thread.Sleep(500);
                        string topdf = Aurora.Clases.Negocio.Propietario.GetNotadeCobro(Convert.ToInt16(row["IDPROPIEDAD"]), Mes, Ano, Initpath);
                        EstadodeCuenta.SendPDFEmail(topdf, (Mes)Mes, Ano, prop, smtp, usernameMail, passwordMail, port, enableSsl);
                        sb.Append(row["IDPROPIEDAD"].ToString() + ": se envío con exito \n");
                        k++;
                    }
                }
                catch (Exception ee)
                {
                    Aurora.Clases.Negocio.Propietario.BorrarMail(prop.IdPropiedad, Mes, Ano);
                    sb.Append(row["IDPROPIEDAD"].ToString() + ": falló envío: " + ee.Message + "\n");
                   
                }

            }
           
            lblresult.Text = sb.ToString().Replace("<X>",k.ToString());
         }

        protected void btnExportEnviados_Click(object sender, EventArgs e)
        {
            gridExporter0.WriteXlsToResponse("MailsEnviados-" + Mes + "-" + Ano, true); 
        }


        public void GuadarPdf(int idprop)
        {
            try
            {
                string Initpath = Server.MapPath("~") + @"\Templates\";
                String topdf = "";
                topdf = Aurora.Clases.Negocio.Propietario.GetNotadeCobro(idprop,Mes, Ano, Initpath);
                StringReader sr = new StringReader(topdf);
                Document pdf = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                AppSettingsReader appSettReader = new AppSettingsReader();
                string NotasCobroAuroges = Convert.ToString(appSettReader.GetValue("NotasFolder", typeof(string)));
                NotasCobroAuroges += Mes.ToString()+ "-" + Ano.ToString();
                if (!Directory.Exists(NotasCobroAuroges))
                {
                    Directory.CreateDirectory(NotasCobroAuroges);
                }
                PdfWriter pdfw = PdfWriter.GetInstance(pdf, new FileStream(NotasCobroAuroges + "\\NotaCobro_" + idprop.ToString() + "_" + Mes.ToString() + "_" + Ano.ToString() + ".pdf", FileMode.OpenOrCreate));

                pdf.Open();

                XMLWorkerHelper.GetInstance().ParseXHtml(pdfw, pdf, sr);
                pdf.Close();
                pdfw.Close();

            }
            catch (Exception ex)
            {
                lblresult.Text = "Se presentó problemas al generar PDF: " + ex.Message;
                lblresult.Visible = true;
            }
        }


        protected void btnGuardarNotas_Click(object sender, EventArgs e)
        {
           
            StringBuilder sb_errors = new StringBuilder("No se generaron las siguientes Notas de cobro:<br>");
            Mes = Convert.ToInt16(lstMes.SelectedItem.Value);
            Ano = Convert.ToInt16(lstAnos.SelectedItem.Value);
            int cantidadGen = 0;
            int cantidadErr = 0;
            try
            {
                System.Collections.Generic.List<InfoItem> lt = Aurora.Clases.Negocio.Propietario.List(false, true);
              
                foreach (InfoItem item in lt)
                {
                    try
                    {
                        GuadarPdf(item.Value);
                        cantidadGen++;
                    }
                    catch (Exception)
                    {
                        cantidadErr++;
                        sb_errors.Append(item.Value + ";");
                    }
                }
            }
            catch (Exception ee)
            {
                lblresult.Text = ee.Message;
            }
            lblresult.Text = "Se generaron " + cantidadGen + " notas de cobros <br>";
            if (cantidadErr > 0)
                lblresult.Text += sb_errors.ToString();
        }
    }
}