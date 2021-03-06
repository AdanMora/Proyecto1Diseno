﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Proyecto1.Modelo
{
    public class Consejo
    {
        private Collection<Miembro> miembros = new Collection<Miembro>();
        private Collection<Sesion> sesiones = new Collection<Sesion>();
        private Collection<PuntoAgenda> solicitudes = new Collection<PuntoAgenda>();                

        public Consejo() { }

        public Consejo(Collection<Miembro> miembros, Collection<Sesion> seciones, Collection<PuntoAgenda> solicitudes)
        {
            this.miembros = miembros;
            this.sesiones = seciones;
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

        public Collection<Sesion> Sesiones
        {
            get
            {
                return sesiones;
            }

            set
            {
                sesiones = value;
            }
        }

        public Collection<PuntoAgenda> Solicitudes
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
