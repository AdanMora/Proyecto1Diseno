using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Modelo;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Proyecto1.Controlador;

namespace Proyecto1.Controlador
{
    class Strategy_PDF : Strategy_Docs
    {
        public void crearActa(Sesion puntos, string path)
        {
            // throw new NotImplementedException();
        }

        public byte[] crearAgenda(Sesion n, string path)
        {
            //Crea el con la sesion     
            Console.WriteLine("Entro a crear agenda");
            FileStream fs = new FileStream(path + "\\Agenda Sesión Ordinaria-"+n.Numero+".pdf", FileMode.Create, FileAccess.Write, FileShare.None);            
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);                            
            doc.Open();
            doc.Add(new Paragraph("\t\t\tAgenda Sesión Ordinaria - " + n.Numero));
            doc.Add(new Paragraph("\nFecha: "+n.Fecha.ToString()));
            doc.Add(new Paragraph("\nLugar: " + n.Lugar));
            doc.Add(new Paragraph("\n\t\t\tAgenda"));
            foreach (PuntoAgenda p in n.Agenda)
            {              
                if (p.Tipo == 'V')
                {
                    doc.Add(new Paragraph(p.Id_punto+ "." + p.Considerandos+",asunto de tramite,solicitante: "+p.Nombre));
                    
                }
                else
                {
                    doc.Add(new Paragraph(p.Id_punto + "." + p.Considerandos+ ",asunto de fondo,solicitante: " + p.Nombre));
                }           
                
            }
            //string tira = doc.g;
            //Console.WriteLine(tira);
            //byte[] result = PdfWriter.GetISOBytes(tira);
            
            doc.Close();
            
            byte[] result = File.ReadAllBytes(path + "\\Agenda Sesión Ordinaria-" + n.Numero + ".pdf");
            return result;
        }


                

        public void crearAcuerdo(PuntoAgenda punto, string destinatario, string path)
        {
            //Crea el con la sesion            
            FileStream fs = new FileStream(path + "Acuerdo" + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph("\n\t\t\tAcuerdo"));
            doc.Add(new Paragraph("\nDestinatario: " + destinatario));
            doc.Add(new Paragraph("\nNombre: " + punto.Nombre));
            doc.Add(new Paragraph("\nConsiderandos: " + punto.Considerandos));
            doc.Add(new Paragraph("\nSe acuerda: " + punto.SeAcuerda));
            doc.Add(new Paragraph("\nVotación: " + "\n+A favor:" + punto.Votacion[0] + "\n+En contra:" + punto.Votacion[1] + "\n+En blanco:" + punto.Votacion[2]));
            doc.Add(new Paragraph("\nComentarios\n"));
            foreach (Comentario c in punto.Comentarios)
            {
                doc.Add(new Paragraph("\nMiembro: " + c.Miembro.Nombre+"\nComentario:"+c.Txtcomentario));
            }
            doc.Close();
        }
    }
}

