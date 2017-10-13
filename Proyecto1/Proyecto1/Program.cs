using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1.Vista;
using Proyecto1.Controlador;

namespace Proyecto1
{

    static class Program 
    {
        
        static void Main()
        {                       
            bool band = true;
            if(band == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
                     

        }
        
    }
}
