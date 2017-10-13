﻿using System;
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

namespace Proyecto1.Controlador
{
    class Controlador_Correo
    {
        public void enviarNotificaciones()
        {
            string encabezado = "Sesión Ordinaria <#>-<Anno>";
            string cuerpo = "Buenas días:\n\n" +
                "Estimados (as) Profesores (as):\n\n" +
                "A solicitud de la Dirección, me permito informarles que el próximo lunes 25 de setiembre se realizará la Sesión Ordinaria 21-2017, se solicita que si\n" +
                "tienen algún punto que consideren que debe ser valorado por la Dirección para incluirse en la agenda, lo hagan llegar a más tardar el miércoles 20\n" +
                "de setiembre durante la mañana.\n\n" +
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

                MailMessage mail = new MailMessage("grupoadfafe@gmail.com", "fauriciocr@gmail.com", encabezado, cuerpo);
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

        public void enviarAgenda()
        {

        }
    }
}
