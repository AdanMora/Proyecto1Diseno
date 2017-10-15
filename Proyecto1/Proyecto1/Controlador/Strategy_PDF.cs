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
            /* Crea el con la sesion
            FileStream fs = new FileStream("Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);            
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph("Hello World"));
            doc.Close();*/
            Collection<PuntoAgenda> puntos = new Collection<PuntoAgenda>();
            puntos = 
            foreach (PuntoAgenda p)
            {

            }
        }
    }
}
