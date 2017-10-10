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

        public Prototype_Cache(Collection<Miembro> miembros)
        {
            prototype = new Prototype_Miembros(miembros);
        }

        // public Prototype_Cache() { }

        public void cargarPrototipo()
        {
            // aquí en teoría se carga el prototipo, pero se está cargando en Controlador_Sesion
            //prototype.setAsistencia(DAO.getMiembros());
        }
        
        public Prototype_Clonable getPrototipo()
        {
            return (Prototype_Miembros) this.prototype.clonable(); ;
        }
        
    }
}
