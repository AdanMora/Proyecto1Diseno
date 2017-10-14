using Proyecto1.Controlador;
using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(new Form1());*/

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

            String p = "punto";
            String a = "a";
            cont = 0;

            while(cont < 20)
            {
                solicitudes.Add(new PuntoAgenda(cont, p+cont.ToString(), a, a, a, 0, 0, 0, 'A'));
                cont++;
            }

            Consejo consejo = new Consejo(miembros,sesiones,solicitudes);
            Gestor gestor = new Gestor(consejo);
            gestor.nuevaSesion("1", DateTime.Now, "CHANTE");
            Console.WriteLine("Yas...");
            Console.ReadKey();
        }
    }
}
