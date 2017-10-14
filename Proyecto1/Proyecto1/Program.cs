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
                Gestor m = new Gestor();
                m.nuevaSesion("2", DateTime.Now, "CIC");
                Xls_DAO xls = new Xls_DAO();
                Collection<Miembro> listaMiembros = new Collection<Miembro>();
                listaMiembros= m.Xls.cargaXls(@"C:\\Users\\Fauricio\\Desktop\\Miembros.xlsx");
                //m.actualizarMiembros();
                Console.WriteLine("Administración de consejos.\n\n Lista de miembros");
                
                foreach (Miembro nuevo in listaMiembros)
                {                    
                    Console.WriteLine(nuevo.Nombre);
                }                
                Console.ReadKey();

            }
                     

        }
        
    }
}

