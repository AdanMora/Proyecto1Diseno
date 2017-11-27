using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Modelo;
using System.IO;


namespace Proyecto1.Controlador
{
    class Strategy_DOCX : Strategy_Docs
    {
        public void crearActa(Sesion puntos, string path)
        {
            // throw new NotImplementedException();   
            path = path + "\\Acta Sesión Ordinaria - " + puntos.Numero + ".doc";
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.CreateNew);
                using (StreamWriter wr = new StreamWriter(fs, Encoding.Default))
                {
                    wr.Write("\t\t\tActa Sesión Ordinaria - " + puntos.Numero);

                    wr.Write("\n\n\tFecha: " + puntos.Fecha.ToString());
                    wr.Write("\n\tLugar: " + puntos.Lugar.ToString());
                    wr.Write("\n");
                    foreach (PuntoAgenda p in puntos.Agenda)
                    {
                        if (p.Tipo == 'V')
                        {
                            wr.Write("\n");
                            wr.Write("\n" + p.Id_punto + "." + p.Considerandos + ",asunto de tramite,solicitante: " + p.Nombre);                            
                        }
                        else
                        {
                            wr.Write("\n");
                            wr.Write("\n" + p.Id_punto + "." + p.Considerandos + ",asunto de fondo,solicitante: " + p.Nombre);                            
                        }
                        wr.Write("\n\n\tSe acuerda: " + p.SeAcuerda);
                        wr.Write("\n\n\tResultados de la votación" + "\n\tA favor:" + p.Votacion[0] + "\n\tEn contra:" + p.Votacion[0] + "\n\tEn blanco:" + p.Votacion[2]);
                        wr.Write("\n\n\tLista de comentarios:\n");
                        foreach (Comentario c in p.Comentarios)
                        {
                            if (c != null)
                                wr.Write("\n\t+" + c.Txtcomentario);
                        }
                    }
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }            
        }
        public byte[] crearAgenda(Sesion sesion, string path)
        {
            // Crea el DOCX           
            return null;
        }

        public void crearAcuerdo(PuntoAgenda punto, string destinatario, string path)
        {

        }
    }
}
