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
        private char[] listaAsistencia;

        public Prototype_Miembros(Collection<Miembro> miembros)
        {
            this.asistencia = miembros;
            int n = miembros.Count;
            this.listaAsistencia = new char[n];
            for(int i = 0; i < n; i++)
            {
                this.listaAsistencia[i] = 'A';
            }
        }

        // public Prototype_Miembros(){}

        public Prototype_Clonable clonable()
        {
            return (Prototype_Miembros)this.MemberwiseClone();
        }

        public void setAsistencia(Collection<Miembro> miembros)
        {
            this.asistencia = miembros;
        }
    }
}
