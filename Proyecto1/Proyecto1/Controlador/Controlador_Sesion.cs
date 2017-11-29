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
        private Sesion sesionActual = null;
        private Prototype_Cache prototype;

        public Controlador_Sesion()
        {
            this.prototype = new Prototype_Cache();
        }

        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            this.sesionActual = new Sesion(num, fecha, lugar, null);
            this.sesionActual.MiembrosAsistencia = (Prototype_Miembros)this.prototype.getPrototipo();
        }

        public bool cerrarSesion()
        {
            if(this.sesionActual != null)
            {
                this.sesionActual.Estado = true;
                this.sesionActual = null;
                return true;
            }
            return false;
            
        }

        public void eliminarPuntoAgenda(int id)
        {
            foreach(PuntoAgenda punto in this.sesionActual.Agenda)
            {
                if(punto.Id_punto == id)
                {
                    this.sesionActual.Agenda.Remove(punto);
                    break;
                }
            }
        }

        public void setMiembros(Collection<Miembro> miembros)
        {
            this.prototype.cargarPrototipo(miembros);
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

        public void agregarVotacion(int id, int aFavor, int enContra, int blanco)
        {
            foreach(PuntoAgenda punto in this.sesionActual.Agenda)
            {
                if(punto.Id_punto == id)
                {
                    punto.Votacion[0] = aFavor;
                    punto.Votacion[1] = enContra;
                    punto.Votacion[2] = blanco;
                }
            }
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

        public void agregarComentario(int idPunto, string correoMiembro, int idComentario, string txt)
        {
            Comentario comentario = null;
            foreach(Miembro m in this.sesionActual.MiembrosAsistencia.Asistencia)
            {
                if(m.Correo[0] == correoMiembro)
                {
                    comentario = new Comentario(idComentario, txt, m);
                    break;
                }
            }

            foreach(PuntoAgenda punto in this.sesionActual.Agenda)
            {
                if(punto.Id_punto == idPunto)
                {
                    punto.Comentarios.Add(comentario);
                    break;
                }
            }
        }

        public void modificarAsistencia(string correoMiembro, bool estado)
        {
            int n = this.sesionActual.MiembrosAsistencia.Asistencia.Count;
            char e = ' ';
            for(int i = 0; i < n; i++)
            {
                if (this.sesionActual.MiembrosAsistencia.Asistencia.ElementAt(i).Correo[0] == correoMiembro)
                {
                    if (estado)
                        e = 'P';
                    else e = 'A';
                    this.sesionActual.MiembrosAsistencia.ListaAsistencia[i] = e;
                    break;
                }        
            }
        }

        public Collection<Comentario> getComentarios(int idPunto)
        {
            foreach(PuntoAgenda punto in this.sesionActual.Agenda)
            {
                if(punto.Id_punto == idPunto)
                {
                    return punto.Comentarios;
                }
            }
            return null;
        }

        public Sesion getSesion()
        {
            return this.sesionActual;
        }

        public void setSesion(Sesion sesion)
        {
            this.sesionActual = sesion ;
        }

        public bool haySesion()
        {
            bool hay = true;
            if (this.sesionActual == null || sesionActual.Estado == false)
                hay = false;
            return hay;
        }

        public Collection<PuntoAgenda> getPuntosAgenda()
        {
            return this.sesionActual.Agenda;
        }

        public Prototype_Miembros getAsistencia()
        {
            return this.sesionActual.MiembrosAsistencia;
        }

        public void cambiarPosicionPunto(int posicionNueva, int posicionVieja)
        {
            PuntoAgenda puntoPosVieja = this.sesionActual.Agenda.ElementAt(posicionVieja);
            this.sesionActual.Agenda.RemoveAt(posicionVieja);
            this.sesionActual.Agenda.Insert(posicionNueva, puntoPosVieja);

        }

        public bool hayQuorum()
        {
            char[] asistencia = this.sesionActual.MiembrosAsistencia.ListaAsistencia;
            int n = asistencia.Count();
            int cont = 0;
            for(int i = 0; i < n; i++)
            {
                if(asistencia[i] == 'P')
                {
                    cont++;
                }
            }
            return(cont >= 26);
        }

    }
}
