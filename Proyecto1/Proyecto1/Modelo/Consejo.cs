using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Proyecto1.Modelo
{
    class Consejo
    {
        private Collection<Miembro> miembros = new Collection<Miembro>();
        private Collection<Sesion> seciones = new Collection<Sesion>();
        private Collection<PuntoAgenda> solicitudes = new Collection<PuntoAgenda>();                

        public Consejo() { }

        public Consejo(Collection<Miembro> miembros, Collection<Sesion> seciones, Collection<PuntoAgenda> solicitudes)
        {
            this.miembros = miembros;
            this.seciones = seciones;
            this.solicitudes = solicitudes;
        }

        public Collection<Miembro> Miembros
        {
            get
            {
                return miembros;
            }

            set
            {
                miembros = value;
            }
        }

        public Collection<Miembro> Miembros1
        {
            get
            {
                return miembros;
            }

            set
            {
                miembros = value;
            }
        }

        public Collection<Sesion> Seciones
        {
            get
            {
                return seciones;
            }

            set
            {
                seciones = value;
            }
        }

        internal Collection<PuntoAgenda> Solicitudes
        {
            get
            {
                return solicitudes;
            }

            set
            {
                solicitudes = value;
            }
        }               
    }
}
