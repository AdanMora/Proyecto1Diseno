using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Vista;
using Proyecto1.Controlador;
using Proyecto1.Modelo;
using System.Collections.ObjectModel;

namespace Proyecto1.Controlador
{
    class DTO_consola
    {
        string linea = "\n===================================================\n";
        Gestor m = new Gestor();
        public DTO_consola()
        {            
            m.nuevaSesion("2", DateTime.Now, "CIC");           
        }
        

        public void actualizarMiembros()
        {            
            m.actualizarMiembros(@"C:\\Users\\Fauricio\\Desktop\\Miembros.xlsx");
            Console.WriteLine("Administración de consejos.\n\n Lista de miembros\n");

            foreach (Miembro nuevo in m.getMiembrosConsejo())
            {
                Console.WriteLine(nuevo.Nombre);
            }
        }

        public void envioNotificacion()
        {
            Console.WriteLine(linea);
            Console.WriteLine("\nEnvío de notificaciones\n\n");
            foreach (Miembro temp in m.getMiembrosConsejo())
            {                
                m.enviarNotificacion("1", DateTime.Now,temp.Correo[0]);
                
            }
        }

        public void agregarSolicitud()
        {            
            string punto = "";
            char tipo = ' ';
            for(int cont=1;cont<21;cont++)
            {
                if (cont % 2 == 1)
                {
                    punto = "Solicitud de punto Informativo";
                    tipo = 'I';
                }else
                {
                    punto = "Solicitud de punto que requiere votación";
                    tipo = 'V';
                }
                m.agregarSolicitud(cont,m.getMiembrosConsejo().ElementAt(cont).Nombre,"",punto,"",tipo);                
            }
        }

        public void verSolicitudes()
        {
            Console.WriteLine(linea);
            Console.WriteLine("\nListado con la solicitud de puntos para la agenda:\n");            
            foreach (PuntoAgenda p in m.getSolicitudes())
            {
                Console.WriteLine(p.toString());
            }
        }

        public void verPuntosAgenda()
        {
            Console.WriteLine(linea);
            Console.WriteLine("\nListado con los puntos a incluir en este consejo:\n");

            foreach (PuntoAgenda p in m.getPuntosAgenda())
            {
                Console.WriteLine(p.toString());
            }
        }

        public void aceptarSolicitud()
        {
            Console.WriteLine(linea);
            for(int i = 1; i <= 10; i++)
            {
                m.aceptarSolicitud(i);                
                m.agregarComentario(i, m.getMiembrosConsejo().ElementAt(i).Correo[0],i, "");
                Console.WriteLine("Solicitud aceptada para agrearse a la agenda");
            }
        }
       
        public void eliminaSolicitud()
        {
            Console.WriteLine("");
            for(int i = 11; i < 21; i++)
            {
                m.eliminarSolicitud(i);
                Console.WriteLine("Solicitud eliminada");
            }
        }

        public void generarAgenda()
        {
            m.crearAgenda(0,@"C:\\Users\\Fauricio\\Desktop\\");
        }
    }
}
