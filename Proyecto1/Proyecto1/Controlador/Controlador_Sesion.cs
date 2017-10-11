using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Controlador
{
    class Controlador_Sesion
    {
        private Sesion sesionActual;

        public Controlador_Sesion() { }

        public void setSesion(Sesion sesion)
        {
            this.sesionActual = sesion;
        }

        public void cargarListaMiembros()
        {

        }

        public void registrarAsistencia(Collection<Miembro> m, Sesion s)
        {

        }

        public void registrarSolicitud(PuntoAgenda p)
        {

        }

        public void registrarPuntoAgenda(PuntoAgenda p)
        {

        }

        public void cerrarSesion()
        {

        }
    }
}
