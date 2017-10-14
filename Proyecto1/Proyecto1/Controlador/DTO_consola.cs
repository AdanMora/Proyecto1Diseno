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
        Gestor m = new Gestor();
        public DTO_consola()
        {            
            m.nuevaSesion("2", DateTime.Now, "CIC");           
        }
        

        public void actualizarMiembros()
        {            
            m.actualizarMiembros(@"C:\\Users\\Fauricio\\Desktop\\Miembros.xlsx");
            Console.WriteLine("Administración de consejos.\n\n Lista de miembros\n");

            foreach (Miembro nuevo in m.Consejo.Miembros)
            {
                Console.WriteLine(nuevo.Nombre);
            }
        }

        public void envioNotificacion()
        {
            Console.WriteLine("\n\n Envío de notificaciones\n\n");
            foreach (Miembro temp in m.Consejo.Miembros)
            {                
                m.Controlador_correos.enviarNotificaciones("1", DateTime.Now,temp.Correo[0]);
            }
        }
       
    }
}
