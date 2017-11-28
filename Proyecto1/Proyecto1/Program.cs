using Proyecto1.Controlador;
using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1.Vista;
using System.IO;

namespace Proyecto1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Gestor g = new Gestor();
            g.cargarDatos();
            Console.WriteLine("\nConsejo - Carga de datos");
            Console.WriteLine("\nMiembros");
            foreach (Miembro m in g.getConsejo().Miembros)
            {
                Console.WriteLine(m.toString());
            }

            Console.WriteLine("\nSolicitudes");
            foreach (PuntoAgenda p in g.getConsejo().Solicitudes)
            {
                Console.WriteLine(p.toString());
            }

            Console.WriteLine("\nSesiones");
            foreach (Sesion s in g.getConsejo().Sesiones)
            {
                Console.WriteLine(s.toString());

                foreach (PuntoAgenda p in s.Agenda)
                {
                    Console.WriteLine(p.toString());

                    foreach (Comentario c in p.Comentarios)
                    {
                        Console.WriteLine(c.toString());
                    }
                }
            }

            Console.WriteLine("\nSesion Actual");

            Console.WriteLine(g.getSesion().toString());

            for (int i = 0; i < g.getSesion().MiembrosAsistencia.Asistencia.Count; i++)
            {
                Console.WriteLine(g.getSesion().MiembrosAsistencia.Asistencia.ElementAt(i).toString());

                Console.WriteLine("||||||||" + g.getSesion().MiembrosAsistencia.ListaAsistencia.ElementAt(i) + "||||||||");
            }

            /*g.cerrarSesion();

            g.nuevaSesion("prueba", DateTime.Today, "IC");

            g.aceptarSolicitud(g.getSolicitudes().First().Id_punto);

            g.agregarPuntoAgenda("Punto P1", "Resultado P1", "Considerando P1", "Se acuerda P1", 'T');

            g.agregarPuntoAgenda("Punto P2", "Resultado P2", "Considerando P2", "Se acuerda P2", 'M');

            g.agregarPuntoAgenda("Punto P3", "Resultado P3", "Considerando P3", "Se acuerda P3", 'T');

            */
            //g.cambiarPosicionPunto(4, 1);

            //g.agregarComentario(6, g.getConsejo().Miembros.First().Correo[0], "Otro comentario de prueba c:");

            //g.agregarVotacion(7, 23, 3, 5);

            //foreach (Miembro m in g.getSesion().MiembrosAsistencia.Asistencia)
            //{
            //    g.modificarAsistencia(m.Correo[0], false);
            //}

            //g.modificarAsistencia(g.getConsejo().Miembros.First().Correo[0], true);



            /*
            g.crearActa(2, "C:\\Users\\Fauricio\\Desktop");
            Console.WriteLine("Crea Acta.xml");
            g.crearAgenda(g.getSesion().Numero, "C:\\Users\\Fauricio\\Desktop");
            Console.WriteLine("Crea Agenda");
            g.crearActa(1, "C:\\Users\\Fauricio\\Desktop");
            Console.WriteLine("Crea Acta.doc");
            g.obtenerAgenda(g.getSesion(), "C:\\Users\\Fauricio\\Desktop\\cakephp_ex1");
            Console.WriteLine("Envío notificación consejo");
            */
            //g.enviarNotificacion(g.getSesion().Numero, DateTime.Now, "fauriciocr@gmail.com", @"C:\Users\Fauricio\Desktop\MEMO_JUSTIFICACION_DE_AUSENCIAS_AL_CONSEJO.doc");
            //g.enviarAgenda(g.getSesion().Numero, DateTime.Now, "fauriciocr@gmail.com", @"C:\Users\Fauricio\Desktop\Agenda Sesión Ordinaria-prueba.pdf");

            foreach (string s in g.getAllNumeroSesiones())
            {
                Console.WriteLine(s);
            }

            Console.Read();


            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GUI());

            /*Collection<Miembro> miembros = new Collection<Miembro>();

            String miembro = "miembro";
            int cont = 0;
            String correo = "@gmail.com";

            while(cont < 50)
            {
                miembros.Add(new Miembro(miembro + cont.ToString(), miembro + cont.ToString() + correo, miembro + cont.ToString() + cont.ToString() + correo, 'E'));
                cont++;
            }


            Collection<Sesion> sesiones = new Collection<Sesion>();
            Collection<PuntoAgenda> solicitudes = new Collection<PuntoAgenda>();

            String p = "solicitud/punto";
            String a = "asd";
            cont = 0;
            String b;
            while(cont < 20)
            {
                b = a + cont.ToString();
                solicitudes.Add(new PuntoAgenda(cont, p+cont.ToString(), b, b, b, 0, 0, 0, 'A'));
                cont++;
            }

            
            Sesion sesion = new Sesion("1", DateTime.Now, "plaza", false);
            Prototype_Cache proto = new Prototype_Cache();
            proto.cargarPrototipo(miembros);
            sesion.MiembrosAsistencia = (Prototype_Miembros)proto.getPrototipo();

            sesiones.Add(new Sesion("0", DateTime.Now, "ñacas", true));
            sesiones.Add(sesion);
            Consejo consejo = new Consejo(miembros, sesiones, solicitudes);
            //Gestor gestor = new Gestor(consejo);

            GUI gui = new GUI(consejo);
            //gui.setConsejo(consejo);

            gui.ShowDialog();*/

            //gestor.agregarSolicitud("solicitud999",a,a,a,'S');
            //gestor.eliminarSolicitud(999);
            //gestor.aceptarSolicitud(999);
            //Console.WriteLine(gestor.getPuntosAgenda().Count);
            //Console.WriteLine(gestor.getConsejo().Solicitudes.Count);

            //gestor.agregarVotacion(0,30,25,5);
            //Console.WriteLine(gestor.getPuntosAgenda()[0].Votacion[0]);
            //gestor.agregarComentario(0,"miembro0@gmail.com",450,"Comentario by ivan");

            //gestor.modificarAsistencia("miembro0@gmail.com", 'Z');

            //Console.WriteLine(gestor.getAsistencia().ListaAsistencia[0]);
            //gestor.getConsejo().Miembros.ElementAt(0).Nombre = "ivan";
            //Console.WriteLine(gestor.getMiembrosConsejo().ElementAt(0).Nombre);
            //Console.WriteLine(gestor.getAsistencia().Asistencia.ElementAt(0).Nombre);
            /*
            DTO_consola temp = new DTO_consola();
            temp.nuevaSesion();
            temp.actualizarMiembros();
            temp.envioNotificacion();
            temp.agregarSolicitud();            
            temp.aceptarSolicitud();
            temp.agregarSolicitudPresidente();
            temp.moficarAgenda();
            temp.verSolicitudes();
            temp.eliminaSolicitud();
            temp.verSolicitudes();
            temp.verPuntosAgenda();
            temp.generarAgenda();
            temp.enviarAgenda();
            Console.WriteLine("Ejecución del consejo");
            temp.controlAsistencia();
            temp.verAsistencia();
            temp.crearActa();  
            temp.controlAsistencia();
            temp.realizarVotacion();        
            Console.ReadKey(); */
        }
    }
}
