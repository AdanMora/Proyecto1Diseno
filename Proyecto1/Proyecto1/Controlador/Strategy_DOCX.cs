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
            try
            {                             
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("\t\t\tActa Sesión Ordinaria - " + puntos.Numero.ToString());
                        sw.WriteLine("\nFecha: " + puntos.Fecha.ToString());
                        sw.WriteLine("\nLugar: " + puntos.Lugar.ToString());
                        sw.WriteLine("\n0.Aprobación de la agenda.");
                        foreach (PuntoAgenda p in puntos.Agenda)
                        {
                            if (p.Tipo == 'V')
                            {
                                sw.WriteLine(p.Id_punto + "." + p.Considerandos + ",asunto de tramite,solicitante: " + p.Nombre);
                            }
                            else
                            {
                                sw.WriteLine(p.Id_punto + "." + p.Considerandos + ",asunto de fondo,solicitante: " + p.Nombre);
                            }
                            sw.WriteLine("Se acuerda: " + p.SeAcuerda);
                            sw.WriteLine("Resultados de la votación" + "\nA favor:" + p.Votacion[0] + "\nEn contra:" + p.Votacion[0] + "\nEn blanco:" + p.Votacion[2]);
                            sw.WriteLine("Lista de comentarios:\n");
                            foreach (Comentario c in p.Comentarios)
                            {
                                if(c != null)
                                    sw.WriteLine("+" + c.Txtcomentario);
                            }
                        }
                    }
                    Console.Write("Acta creada");
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
