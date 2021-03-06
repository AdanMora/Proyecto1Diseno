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
        }
        
        public void nuevaSesion()
        {
            g.nuevaSesion("1", DateTime.Now, "CIC");
        }

        public void actualizarMiembros()
        {            
            g.actualizarMiembros(@"C:\\Users\\Adán\\Desktop\\Miembros.xlsx");
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
            g.enviarNotificacion("1", DateTime.Now,"fariciocr@gmail.com", @"C:\Users\Fauricio\Desktop\MEMO_JUSTIFICACION_DE_AUSENCIAS_AL_CONSEJO.doc");
                
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
                //agregarSolicitud(cont,g.getMiembrosConsejo().ElementAt(cont).Nombre,"",punto,"",tipo);                
            }
        }

        public void agregarSolicitudPresidente()
        {
            //agregarSolicitud(21, g.getMiembrosConsejo().ElementAt(21).Nombre, "", "Aprovación de la Agenda", "", 'V');
            g.aceptarSolicitud(21);
            Console.WriteLine("\nEl presidente agregó un nuevo punto en la agenda.\n");
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
                //agregarComentario(i, g.getMiembrosConsejo().ElementAt(i).Correo[0],i, "");
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
            //g.crearAgenda(0,@"C:\\Users\\Fauricio\\Desktop\\");
        }

        public void enviarAgenda()
        {
            foreach(Miembro n in g.getMiembrosConsejo())
            {
                //g.enviarAgenda(n.Correo[0], @"C:\\Users\\Fauricio\\Desktop\\Agenda Sesión Ordinaria-2.pdf");
            }
        }

        public void controlAsistencia()
        {
            Console.WriteLine("Control de asistencia");
            //char[] listaAsist = g.getAsistencia().ListaAsistencia;
            //int lim = listaAsist.Count();
            foreach (Miembro m in g.getAsistencia().Asistencia)
            {
                g.modificarAsistencia(m.Correo[0],true);                
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
        
        
        public void crearActa()
        {
            //g.crearActa(1, "C:\\Users\\Fauricio\\Desktop\\Acta Sesión ordinaria.doc");
        }

        public void realizarVotacion()
        {
            Console.WriteLine(linea);
            Console.WriteLine("Simulación de proceso de votación");
            foreach(PuntoAgenda p in g.getPuntosAgenda())
            {
                /*
                if (g.hayQuorum())
                {
                    Console.WriteLine("Hay quorum");
                }
                else
                {
                    Console.WriteLine("No hay quorum");
                }*/
                g.agregarVotacion(p.Id_punto, 40, 5, 0);
            }
        }

        public void moficarAgenda()
        {
            g.cambiarPosicionPunto(11,1);
            Console.WriteLine("\nEl presidente reorganiza los puntos dentro de la agenda.\n");
        }
    }
}
