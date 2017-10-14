using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1.Vista;
using Proyecto1.Controlador;
using Proyecto1.Modelo;
using System.Collections.ObjectModel;

namespace Proyecto1
{

    static class Program 
    {
        
        static void Main()
        {                       
            bool band = false;
            if(band == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }else
            {
                DTO_consola terminal = new DTO_consola();
                terminal.actualizarMiembros();
                terminal.envioNotificacion();
                Console.ReadKey();               
            }
                     

        }
        
    }
}

