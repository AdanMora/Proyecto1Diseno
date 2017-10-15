﻿using System;
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

        public void crearAgenda(object sesion, string path)
        {
            //Crea el con la sesion
            Sesion n = (Sesion)sesion;
            FileStream fs = new FileStream(path + "Agenda Sesión Ordinaria-"+n.Numero.ToString()+".pdf", FileMode.Create, FileAccess.Write, FileShare.None);            
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);                            
            doc.Open();
            doc.Add(new Paragraph("\t\t\tAgenda Sesión Ordinaria - " + n.Numero.ToString()));
            doc.Add(new Paragraph("\nFecha: "+n.Fecha.ToString()));
            doc.Add(new Paragraph("\nLugar: " + n.Lugar.ToString()));
            doc.Add(new Paragraph("\n\t\t\tAgenda"));
            doc.Add(new Paragraph("\n0.Aprobación de la agenda."));
            foreach (PuntoAgenda p in n.Agenda)
            {
                Collection<Comentario> c = p.Comentarios;
                if (p.Tipo == 'V')
                {
                    doc.Add(new Paragraph(p.Id_punto+ "." + p.Considerandos+",asunto de tramite,solicitante: "+p.Nombre));
                    
                }
                else
                {
                    doc.Add(new Paragraph(p.Id_punto + "." + p.Considerandos+ ",asunto de fondo,solicitante: " + p.Nombre));
                }           
                
            }
            doc.Close();                        
        }
    }
}

