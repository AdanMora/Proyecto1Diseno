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

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());

            Collection<Miembro> miembros = new Collection<Miembro>();

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

            gui.ShowDialog();
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(gui);*/

            //gestor.cargarDatos();

            //Console.WriteLine(gestor.haySesion());

            /*gestor.nuevaSesion("2", DateTime.Now, "CHANTE");
            

            while (cont < 20)
            {
                gestor.agregarSolicitud(cont, p + cont.ToString(), a, a, a, 'A');
                cont++;
            }

            cont = 0;
            while (cont < 8)
            {
                gestor.aceptarSolicitud(cont);
                gestor.agregarComentario(cont, miembro + cont.ToString() + correo, cont, a);
                cont++;
            }
            while(cont < 20)
            {
                gestor.eliminarSolicitud(cont);
                cont++;
            }

            Console.WriteLine(gestor.getPuntosAgenda().ElementAt(0).Nombre);
            gestor.cambiarPosicionPunto(1,5);
            Console.WriteLine(gestor.getPuntosAgenda().ElementAt(0).Nombre);
            Console.WriteLine(gestor.getPuntosAgenda().ElementAt(4).Nombre);

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
            Console.ReadKey();*/
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
            Console.ReadKey();            
        }
    }
}
