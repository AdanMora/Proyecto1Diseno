using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Controlador
{
    interface Strategy_Docs
    {
        void crearAgenda(object sesion,string path);
        void crearActa(Sesion puntos, string path);
    }
}
