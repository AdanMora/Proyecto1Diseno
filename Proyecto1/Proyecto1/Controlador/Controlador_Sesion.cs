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
        private Prototype_Cache prototype;

        public Controlador_Sesion()
        {
            this.prototype = new Prototype_Cache();
        }

        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            this.sesionActual = new Sesion(num, fecha, lugar, false);
        }

        public void setMiembros(Collection<Miembro> miembros)
        {
            this.prototype.cargarPrototipo(miembros);
            this.sesionActual.MiembrosAsistencia = (Prototype_Miembros)this.prototype.getPrototipo();
        }

        public void cargarListaMiembros()
        {

        }

        public void registrarAsistencia()
        {

        }

        public void registrarSolicitud()
        {

        }

        public void registrarPuntoAgenda()
        {

        }

        public void cerrarSesion()
        {

        }
    }
}
