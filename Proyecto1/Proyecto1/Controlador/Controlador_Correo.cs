using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;       
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Proyecto1.Modelo;

namespace Proyecto1.Controlador
{
    class Controlador_Correo
    {
        public void enviarNotificaciones(string numeroSesion,DateTime diaConsejo,string destinatario)
        {
            
            string encabezado = "Sesión Ordinaria "+numeroSesion+" - "+ diaConsejo.Year;
            string cuerpo = "Buenas días:\n\n" +
                "Estimados (as) Profesores (as):\n\n" +
                "A solicitud de la Dirección, me permito informarles que el próximo "+ diaConsejo +" se realizará la "+encabezado+", se solicita que si\n" +
                "tienen algún punto que consideren que debe ser valorado por la Dirección para incluirse en la agenda, lo hagan llegar a más tardar el "+ diaConsejo.AddDays(-5) + "\n" +
                "durante la mañana.\n\n" +
                "Adjunto formulario de solicitud de puntos para consejos, el formulario para justificación de ausencia al Consejo y el formulario de mociones de \nfondo.\n\n" +
                "Cualquier consulta con mucho gusto.\n\n" +
                "Saludos;";
            string memo = @"C:\Users\Fauricio\Desktop\MEMO_JUSTIFICACION_DE_AUSENCIAS_AL_CONSEJO.doc";
            string punto = @"C:\Users\Fauricio\Desktop\MACHOTE_OFICIO_SOLICITUD_DE_PUNTOS_de_propuesta_base.docx";
            try
            {
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

                MailMessage mail = new MailMessage("grupoadfafe@gmail.com", destinatario, encabezado, cuerpo);
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.Attachments.Add(data);
                mail.Attachments.Add(data1);
                client.Send(mail);
                Console.WriteLine("Correo Enviado");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo");
            }
        }

        public void enviarAgenda(string numeroSesion, DateTime diaConsejo,string destinatario,string pathAgenda)
        {
            string encabezado = "Agenda Sesión Ordinaria " + numeroSesion + " - " + diaConsejo.Year;
            string cuerpo = encabezado +
                "\nFecha: " + diaConsejo +
                "\nAgenda\n";            
            try
            {
                Attachment data = new Attachment(pathAgenda, MediaTypeNames.Application.Octet);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("grupoadfafe@gmail.com", "Grupoadfafe.");

                MailMessage mail = new MailMessage("grupoadfafe@gmail.com", destinatario, encabezado, cuerpo);
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.Attachments.Add(data);
                client.Send(mail);
                Console.WriteLine("Correo Enviado");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo");
            }
        }
    }
}
