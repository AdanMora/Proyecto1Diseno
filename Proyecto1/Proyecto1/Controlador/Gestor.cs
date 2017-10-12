using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;       // No olvidar.
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;

namespace Proyecto1.Controlador
{
    public class Gestor
    {
        private Consejo consejo;
        private Controlador_Sesion controlador_sesion;
        private Controlador_Solicitudes controlador_solicitudes;
        

        public Gestor(Consejo consejo)
        {
            this.consejo = consejo;
            this.setControladores();
        }

        public Gestor()
        {
            // this.consejo = load();
            this.setControladores();
        }

        private void setControladores()
        {
            // Acá creamos/instanciamos los controladores
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

        public void crearActa(string nombre,string puntosAgenda)
        {            
            string path = @"C:\Users\Fauricio\Desktop\"+nombre+".doc";
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void crearAgenda(string nombre, string puntosAgenda)
        {
            string path = @"C:\Users\Fauricio\Desktop\" + nombre + ".pdf";
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
