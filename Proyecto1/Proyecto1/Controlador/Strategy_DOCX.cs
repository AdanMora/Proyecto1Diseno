using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Modelo;

namespace Proyecto1.Controlador
{
    class Strategy_DOCX : Strategy_Docs
    {
        public void crearActa(Sesion puntos, string path)
        {
            // throw new NotImplementedException();
        }

        public void crearAgenda(object sesion, string path)
        {
            // Crea el DOCX
        }
    }
}
