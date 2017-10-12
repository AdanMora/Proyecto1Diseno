using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;       // No olvidar.
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Proyecto1.Controlador
{
    public class Gestor
    {
        private Consejo consejo;
        private Controlador_Sesion controlador_sesion;
        private Controlador_Solicitudes controlador_solicitudes;
        private Azure_DAO controlador_dao;
        private Xls_DAO xls;

        public Gestor(Consejo consejo)
        {
            this.consejo = consejo;
            //this.setControladores();
        }

        public Gestor()
        {
            this.controlador_dao = new Azure_DAO();
            this.controlador_sesion = new Controlador_Sesion();
            this.controlador_solicitudes = new Controlador_Solicitudes();
            this.xls = new Xls_DAO();
        }

        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            this.controlador_sesion.nuevaSesion(num,fecha,lugar);
            this.controlador_sesion.setMiembros(this.consejo.Miembros);
            this.controlador_solicitudes.setSolicitudes(this.consejo.Solicitudes);
        }

        public void cargarDatos()
        {
            this.consejo = this.controlador_dao.cargarDatos();
        }

        public void actualizarMiembros(String path)
        {
            Collection<Miembro> miembros = this.xls.cargaXls(path);
            this.consejo.Miembros = miembros;
            this.controlador_sesion.setMiembros(miembros);
            this.controlador_dao.actualizarMiembros(miembros);
        }


        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, int aFavor, int enContra, int blanco, char tipo)
        {
            PuntoAgenda punto = new PuntoAgenda(this.controlador_dao.getUltimoIDPunto(), nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_solicitudes.agregarSolicitud(punto);
            this.controlador_dao.agregarSolicitud(punto); 
        }

        public void eliminarSolicitud(int id)
        {
            PuntoAgenda punto = this.controlador_solicitudes.getSolicitud(id);
            if(punto != null)
            {
                punto = this.controlador_sesion.getPuntoAgenda(id);
            }
            this.controlador_dao.eliminarSolicitud(punto);
        }

        public void aceptarSolicitud(int id)
        {
            PuntoAgenda solicitud = this.controlador_solicitudes.getSolicitud(id);
            this.controlador_solicitudes.removerSolicitud(solicitud);
            this.controlador_sesion.agregarPuntoAgenda(solicitud);
        }

        public void agregarVotacion(int id, int aFavor, int enContra, int blanco)
        {
            PuntoAgenda punto = this.controlador_sesion.agregarVotacion(id, aFavor, enContra, blanco);
            this.controlador_dao.aceptarSolicitud(punto);
        }

        public void enviarNotificacion(DateTime fecha,string numeroSesion)
        {
            string encabezado = "Sesión Ordinaria <#>-<Anno>";
            string cuerpo = "A solicitud de la Dirección, me permito informarles que el próximo lunes <FECHA> se realizará la Sesión Ordinaria <#>-<Anno>, se solicita que si tienen \nalgún punto que consideren que debe ser valorado por la Dirección para incluirse en la agenda, lo hagan llegar a más tardar el < FECHA > durante la mañana.\nAdjunto formulario de solicitud de puntos para consejos, el formulario para justificación de ausencia al Consejo y el formulario de mociones de fondo.";
            string memo = @"C:\Users\Fauricio\Desktop\MEMO_JUSTIFICACION_DE_AUSENCIAS_AL_CONSEJO.doc";
            string punto = @"C:\Users\Fauricio\Desktop\MACHOTE_OFICIO_SOLICITUD_DE_PUNTOS_de_propuesta_base.docx";
            try
            {
                string filename = @"C:\Users\Fauricio\Desktop\MEMO_JUSTIFICACION_DE_AUSENCIAS_AL_CONSEJO.doc";
                Attachment data = new Attachment(punto, MediaTypeNames.Application.Octet);                
                Attachment data1 = new Attachment(memo, MediaTypeNames.Application.Octet);
                                
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("grupoadfafe@gmail.com", "Grupoadfafe.");

                MailMessage mail = new MailMessage("grupoadfafe@gmail.com", "fauriciocr@gmail.com", encabezado,cuerpo);
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.Attachments.Add(data);
                mail.Attachments.Add(data1);
                client.Send(mail);
                MessageBox.Show("Correo Enviado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo");
            }
        }

        public void crearActa(string ruta,string puntosAgenda)
        {                        
            string path = @"C:\Users\Fauricio\Desktop\"+ruta+".doc";
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(puntosAgenda);
                    fs.Write(info, 0, info.Length);
                }
                MessageBox.Show("Doc creado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doc no creado");
            }
        }

        public void crearAgenda(string ruta, string puntosAgenda)
        {            
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Fauricio\Desktop\Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                doc.Add(new Paragraph(puntosAgenda));
                doc.Close();
                MessageBox.Show("Pdf creado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pdf no creado");
            }          
        }
    }
}
