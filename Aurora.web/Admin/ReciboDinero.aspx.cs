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
using Aurora.Clases.Base;
using Aurora.Clases.Base.Enums;
using Aurora.Clases.Entidad;
using Aurora.Clases.Base.Encriptacion;
using Aurora.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Net;
using System.Net.Mail;

using System.IO;

namespace Aurora.Web.Admin
{
    [BasadaEnRoles(true)]
    [Perfil(new Perfil[] { Perfil.Administrador, Perfil.Usuario })]
    public partial class ReciboDinero : Autenticada
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.Page_Load(sender, e);
                string path = Server.MapPath("~") + @"\Templates\";
                Celda.Text = Aurora.Clases.Negocio.Propietario.GetRecibo(Convert.ToInt16(QString["IDPROPIEDAD"]), Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"]), path);
                
                if (Celda.Text == "No se encontraron pagos realizados o ya fue emitido el recibo")
                {
                    btnEnviarMail.Visible = false;

                }
                lblEmailFail.Visible = false;
                lblEmailOK.Visible = false;
            }
            catch (Exception ee)
            {
                lblEmailFail.Visible = true;
                lblEmailFail.Text = ee.Message;
                btnEnviarMail.Visible = false;

            }
        }

        public static void SendPDFEmail(String recibo, Mes mesi, int ano, InfoPropietario prop, string smtpserver, string username, string pass, int port, bool enableSsl,string Imgpath)
        {
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        StringReader sr = new StringReader(recibo);
                        Document pdf = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        
                        
                        iTextSharp.text.Image sello = iTextSharp.text.Image.GetInstance(Imgpath);
                        sello.SetAbsolutePosition(200, 630);
                        sello.Alignment = iTextSharp.text.Image.UNDERLYING;
                        
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            PdfWriter pdfw = PdfWriter.GetInstance(pdf, memoryStream);
                            pdf.Open();
                            pdf.Add(sello);
                            XMLWorkerHelper.GetInstance().ParseXHtml(pdfw, pdf, sr);
                            pdf.Close();
                            byte[] bytes = memoryStream.ToArray();
                            memoryStream.Close();
                            if (prop.Mail == String.Empty || prop.Mail == null || !Aurora.Web.UI.Utiles.ComprobarFormatoEmail(prop.Mail)) throw new Exception("El propietario no tiene email asignado o este es inválido");
                            MailMessage mm = new MailMessage();
                            foreach (var address in prop.Mail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                mm.To.Add(address);
                            }
                            mm.From = new MailAddress(username);
                            mm.Subject = "Recibo de Dinero de:" + ((Mes)mesi).ToString() + "/" + ano.ToString();
                            mm.Body = "";
                            mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "ReciboDinero_" + prop.IdPropiedad.ToString() + "_" + ((Mes)mesi).ToString() + "_" + ano.ToString() +"-"+ DateTime.Now.Ticks.ToString()+".pdf"));
                            mm.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = smtpserver;
                            smtp.EnableSsl =  enableSsl;
                            NetworkCredential NetworkCred = new NetworkCredential();
                            NetworkCred.UserName = username;
                            NetworkCred.Password = pass;
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = NetworkCred;
                            smtp.Port = port;
                            smtp.Send(mm);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        public  void GuadarPdf(InfoPropietario prop,int folio)
        {
            try
            {
                string Initpath = Server.MapPath("~") + @"\Templates\";
                String topdf = "";
                topdf = Aurora.Clases.Negocio.Propietario.GetRecibo(Convert.ToInt16(QString["IDPROPIEDAD"]), Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"]), Initpath);
                topdf = topdf.Replace("Folio:", "Folio: " + folio.ToString());
                StringReader sr = new StringReader(topdf);
                Document pdf = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                AppSettingsReader appSettReader = new AppSettingsReader();
                string recibosFolder= Convert.ToString(appSettReader.GetValue("recibosFolder", typeof(string)));
                recibosFolder+=QString["MES"]+"-"+ QString["ANO"];
                if (!Directory.Exists(recibosFolder)) 
                {
                    Directory.CreateDirectory(recibosFolder);
                }
                PdfWriter pdfw = PdfWriter.GetInstance(pdf, new FileStream(recibosFolder + "\\ReciboDinero_" + prop.IdPropiedad.ToString() + "_" + QString["MES"] + "_" + QString["ANO"]+ "-" + DateTime.Now.Ticks.ToString()+".pdf", FileMode.OpenOrCreate));
                string Imgpath = Server.MapPath("~") + @"\Imagenes\pagado.jpg";
                iTextSharp.text.Image sello = iTextSharp.text.Image.GetInstance(Imgpath);
                sello.SetAbsolutePosition(200, 630);
                sello.Alignment = iTextSharp.text.Image.UNDERLYING;
                pdf.Open();
                pdf.Add(sello);
                XMLWorkerHelper.GetInstance().ParseXHtml(pdfw, pdf, sr);
                pdf.Close();
                pdfw.Close();
                lblEmailOK.Text = "PDF generado con éxito.";
                lblEmailOK.Visible = true;
            }
            catch (Exception ex)
            {
                lblEmailFail.Text = "Se presentó problemas al generar PDF: " + ex.Message;
                lblEmailFail.Visible = true;
            }
        }
        protected void btnEnviarMail_Click(object sender, EventArgs e)
        {
            try
            {
                string Initpath = Server.MapPath("~") + @"\Templates\";
                string Imgpath = Server.MapPath("~") + @"\Imagenes\pagado.jpg";
                int folio = Aurora.Clases.Negocio.Folio.GetFolio();
                string topdf = Aurora.Clases.Negocio.Propietario.GetRecibo(Convert.ToInt16(QString["IDPROPIEDAD"]), Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"]), Initpath);
                topdf = topdf.Replace("Folio:", "Folio: "+folio.ToString());
                InfoPropietario prop = Aurora.Clases.Negocio.Propietario.Buscar(Convert.ToInt16(QString["IDPROPIEDAD"]));
                AppSettingsReader appSettReader = new AppSettingsReader();
                string smtp= Convert.ToString(appSettReader.GetValue("smtp", typeof(string)));
                string usernameMail = Convert.ToString(appSettReader.GetValue("usernameMail", typeof(string)));
                string passwordMail = Convert.ToString(appSettReader.GetValue("passwordMail", typeof(string)));
                int port = Convert.ToInt16(appSettReader.GetValue("port", typeof(int)));
                bool enableSsl = Convert.ToBoolean(appSettReader.GetValue("enableSsl", typeof(int)));
               
                SendPDFEmail(topdf, (Mes)Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"]), prop, smtp, usernameMail, passwordMail, port, enableSsl, Imgpath);
                GuadarPdf(prop,folio);
                Aurora.Clases.Negocio.Propietario.SellarRecibo(prop.IdPropiedad,Convert.ToInt16(QString["MES"]), Convert.ToInt16(QString["ANO"]),folio);
                
                lblEmailOK.Text = "Recibo de dinero enviado y guardado con éxito.";
                lblEmailOK.Visible = true;
            }
            catch (Exception ee)
            {
                lblEmailFail.Text = ee.Message;
                lblEmailFail.Visible = true;
            }
        }

       
    }
}
