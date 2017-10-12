using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Controlador
{
    class Prototype_Cache
    {
        Prototype_Clonable prototype;

        public Prototype_Cache() { }

        public void cargarPrototipo(Collection<Miembro> miembros)
        {
            prototype = new Prototype_Miembros(miembros);
        }

        public Prototype_Clonable getPrototipo()
        {
            return (Prototype_Miembros) this.prototype.clonable(); ;
        }
        
    }
}
