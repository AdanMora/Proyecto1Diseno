using Proyecto1.Controlador;
using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1.Vista;

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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());

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

        }
    }
}
