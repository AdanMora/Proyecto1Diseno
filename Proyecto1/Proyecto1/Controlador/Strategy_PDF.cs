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
        public void crearActa(Sesion puntos)
        {
            // throw new NotImplementedException();
        }

        public void crearAgenda(object sesion)
        {
            //Crea el con la sesion
            Sesion n = (Sesion)sesion;
            FileStream fs = new FileStream(@"C:\\Users\\Fauricio\\Desktop\\Agenda Sesión Ordinaria-"+n.Numero.ToString()+".pdf", FileMode.Create, FileAccess.Write, FileShare.None);            
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            
            doc.Open();            
            foreach (PuntoAgenda p in n.Agenda)
            {                
                doc.Add(new Paragraph(p.toString()));
            }
            doc.Close();                        
        }
    }
}
