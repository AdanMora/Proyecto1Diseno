using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Controlador
{
    class Controlador_Solicitudes
    {
        private Collection<PuntoAgenda> solicitudes;

        public Controlador_Solicitudes() { }

        public void setSolicitudes(Collection<PuntoAgenda> solicitudes)
        {
            this.solicitudes = solicitudes;
        }

        public void agregarSolicitud(PuntoAgenda solicitud)
        {
            //PuntoAgenda solicitud = new PuntoAgenda(id_punto, nombre, resultando, considerandos, seAcuerda, aFavor, enContra, blanco, tipo);
            this.solicitudes.Add(solicitud);
            //return solicitud;

        }

        public PuntoAgenda getSolicitud(int id)
        {
            PuntoAgenda solicitud = null;
            foreach(PuntoAgenda s in this.solicitudes)
            {
                if(s.Id_punto == id)
                {
                    solicitud = s;
                    break;
                }
            }
            return solicitud;
        }

        public void eliminarSolicitud(int id)
        {
            foreach (PuntoAgenda s in this.solicitudes)
            {
                if (s.Id_punto == id)
                {
                    this.solicitudes.Remove(s);
                    break;
                }
            }
        }

        public Collection<PuntoAgenda> getSolicitudes()
        {
            return this.solicitudes;
        }

        public void removerSolicitud(PuntoAgenda solicitud)
        {
            this.solicitudes.Remove(solicitud);
        }
    }
}
