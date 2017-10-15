using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Modelo;
using System.IO;

namespace Proyecto1.Controlador
{
    class Strategy_DOCX : Strategy_Docs
    {
        public void crearActa(Sesion puntos, string path)
        {
            // throw new NotImplementedException();
            String line;
            try
            {
                
                StreamReader sr = new StreamReader(path+"Sample.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void crearAgenda(object sesion, string path)
        {
            // Crea el DOCX
        }
    }
}
