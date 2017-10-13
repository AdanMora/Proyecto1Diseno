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

        public PuntoAgenda getPuntoAgenda(int id)
        {
            PuntoAgenda solicitud = null;
            foreach (PuntoAgenda s in this.sesionActual.Agenda)
            {
                if (s.Id_punto == id)
                {
                    solicitud = s;
                    break;
                }
            }
            return solicitud;
        }

        public void agregarPuntoAgenda(PuntoAgenda punto)
        {
            this.sesionActual.agregarPuntoAgenda(punto);
        }

        public PuntoAgenda agregarVotacion(int id, int aFavor, int enContra, int blanco)
        {
            PuntoAgenda temp = null;
            foreach(PuntoAgenda punto in this.sesionActual.Agenda)
            {
                if(punto.Id_punto == id)
                {
                    punto.Votacion[0] = punto.Votacion[0] + aFavor;
                    punto.Votacion[1] = punto.Votacion[1] + enContra;
                    punto.Votacion[2] = punto.Votacion[2] + blanco;
                    temp = punto;
                }
            }
            return temp;
        }

        public Miembro getMiembro(string correo)
        {
            Miembro miembro = null;
            foreach(Miembro m in this.sesionActual.MiembrosAsistencia.Asistencia)
            {
                if((m.Correo[0] == correo) || (m.Correo[1] == correo))
                {
                    miembro = m;
                    break;
                }
            }
            return miembro;
        }

        public void agregarComentario(int idPunto, Comentario comentario)
        {
            foreach(PuntoAgenda punto in this.sesionActual.Agenda)
            {
                if(punto.Id_punto == idPunto)
                {
                    punto.Comentarios.Add(comentario);
                    break;
                }
            }
        }

        public void modificarAsistencia(string correoMiembro, char estado)
        {
            int n = this.sesionActual.MiembrosAsistencia.Asistencia.Count;
            for(int i = 0; i < n; i++)
            {
                if(this.sesionActual.MiembrosAsistencia.Asistencia.ElementAt(i).Correo[0] == correoMiembro)
                {
                    this.sesionActual.MiembrosAsistencia.ListaAsistencia[i] = estado;
                    break;
                }
            }
        }

        public Sesion getSesion()
        {
            return this.sesionActual;
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

        

        public void cerrarSesion()
        {

        }
    }
}
