using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Modelo;

namespace Proyecto1.Controlador
{
    class Prototype_Miembros : Prototype_Clonable
    {
        private Collection<Miembro> asistencia;

        public Prototype_Miembros(Collection<Miembro> miembros)
        {
            this.asistencia = miembros;
        }

        public Prototype_Miembros(){}

        public Collection<Miembro> clonable()
        {
            Collection<Miembro> temp = new Collection<Miembro>();
            foreach(Miembro m in this.asistencia)
            {
                temp.Add(new Miembro(m.Nombre, m.Correo[0], m.Correo[1], m.TipoMiembro));
            }
            return temp;
        }

        public void setAsistencia(Collection<Miembro> miembros)
        {
            this.asistencia = miembros;
        }
    }
}
