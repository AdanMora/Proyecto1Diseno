﻿using System;
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
        Gestor g = new Gestor();
        public DTO_consola()
        {            
            g.nuevaSesion("2", DateTime.Now, "CIC");           
        }
        

        public void actualizarMiembros()
        {            
            g.actualizarMiembros(@"C:\\Users\\Fauricio\\Desktop\\Miembros.xlsx");
            Console.WriteLine("Administración de consejos.\n\n Lista de miembros\n");

            foreach (Miembro nuevo in g.getMiembrosConsejo())
            {
                Console.WriteLine(nuevo.Nombre);
            }
        }

        public void envioNotificacion()
        {
            Console.WriteLine(linea);
            Console.WriteLine("\nEnvío de notificaciones\n\n");
            foreach (Miembro temp in g.getMiembrosConsejo())
            {                
                g.enviarNotificacion("1", DateTime.Now,temp.Correo[0]);
                
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
                g.agregarSolicitud(cont,g.getMiembrosConsejo().ElementAt(cont).Nombre,"",punto,"",tipo);                
            }
        }

        public void verSolicitudes()
        {
            Console.WriteLine(linea);
            Console.WriteLine("\nListado con la solicitud de puntos para la agenda:\n");            
            foreach (PuntoAgenda p in g.getSolicitudes())
            {
                Console.WriteLine(p.toString());
            }
        }

        public void verPuntosAgenda()
        {
            Console.WriteLine(linea);
            Console.WriteLine("\nListado con los puntos a incluir en este consejo:\n");

            foreach (PuntoAgenda p in g.getPuntosAgenda())
            {
                Console.WriteLine(p.toString());
            }
        }

        public void aceptarSolicitud()
        {
            Console.WriteLine(linea);
            for(int i = 1; i <= 10; i++)
            {
                g.aceptarSolicitud(i);                
                g.agregarComentario(i, g.getMiembrosConsejo().ElementAt(i).Correo[0],i, "");
                Console.WriteLine("Solicitud aceptada para agrearse a la agenda");
            }
        }
       
        public void eliminaSolicitud()
        {
            Console.WriteLine("");
            for(int i = 11; i < 21; i++)
            {
                g.eliminarSolicitud(i);
                Console.WriteLine("Solicitud eliminada");
            }
        }

        public void generarAgenda()
        {
            g.crearAgenda(0,@"C:\\Users\\Fauricio\\Desktop\\");
        }

        public void enviarAgenda()
        {
            foreach(Miembro n in g.getMiembrosConsejo())
            {
                g.enviarAgenda(n.Correo[0], @"C:\\Users\\Fauricio\\Desktop\\Agenda Sesión Ordinaria-2.pdf");
            }
        }

        public void controlAsistencia()
        {
            Console.WriteLine("Control de asistencia");
            //char[] listaAsist = g.getAsistencia().ListaAsistencia;
            //int lim = listaAsist.Count();
            foreach (Miembro m in g.getMiembrosConsejo())
            {
                g.modificarAsistencia(m.Correo[0], 'P');
                Console.WriteLine(m.Nombre);
            }
        }

        public void verAsistencia()
        {
            Console.WriteLine("Lista de asistencia");
            foreach (Miembro m in g.getAsistencia().Asistencia)
            {
                Console.WriteLine(m.Nombre);
            }
        }
    }
}
