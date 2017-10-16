using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Modelo;

namespace Proyecto1.Controlador
{
    public class Prototype_Miembros : Prototype_Clonable
    {
        private Collection<Miembro> asistencia;
        private char[] listaAsistencia;

        public Prototype_Miembros(Collection<Miembro> miembros)
        {
            this.asistencia = new Collection<Miembro>();
            int n = miembros.Count;
            this.listaAsistencia = new char[n];
            for(int i = 0; i < n; i++)
            {
                Miembro m = miembros.ElementAt(i);
                this.asistencia.Add(new Miembro(m.Nombre, m.Correo[0], m.Correo[1], m.TipoMiembro));
                this.listaAsistencia[i] = 'P';
            }
        }

        public Collection<Miembro> Asistencia
        {
            get
            {
                return asistencia;
            }

            set
            {
                asistencia = value;
            }
        }

        public char[] ListaAsistencia
        {
            get
            {
                return listaAsistencia;
            }

            set
            {
                listaAsistencia = value;
            }
        }



        // public Prototype_Miembros(){}

        public Prototype_Clonable clonable()
        {
            return (Prototype_Miembros)this.MemberwiseClone();
        }

    }
}
