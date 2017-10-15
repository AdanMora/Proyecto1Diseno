using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Vista;
using Proyecto1.Modelo;
using System.Collections.ObjectModel;

namespace Proyecto1.Controlador
{
    public class DTO_GUI
    {
        Gestor gestor = new Gestor();
        GUI gui;

        public DTO_GUI(GUI gui)
        {
            this.gui = gui;
            gestor.cargarDatos();
        }

        public bool nuevaSesion()
        {
            if (gestor.getAllNumeroSesiones().Contains(gui.s_NumeroSesionGet))
            {
                return false;
            } else
            {
                gestor.nuevaSesion(gui.s_NumeroSesionGet, gui.dt_fechaHora, gui.tb_LugarSesion);
            return true;
            }
            
        }

        public void setMiembros()
        {
            foreach (Miembro m in gestor.getMiembrosConsejo())
            {
                gui.dg_listaMiembrosGet.Rows.Add(m.Nombre, m.Correo[0], m.Correo[1], m.TipoMiembro.ToString());
            }
        }

        public void setElementos()
        {
            foreach (String m in gestor.getAllNumeroSesiones())
            {
                gui.dg_listaMiembrosGet.Rows.Add(m,"","","");
            }
        }

        public void cerrarSesion()
        {
            ////Sesion sesionActual = this.controlador_sesion.getSesion();
            ////sesionActual.Estado = true;
            ////this.consejo.Sesiones.Add(sesionActual);

            ////this.controlador_sesion.cerrarSesion();
            // //ahora hagan lo que quieran con sesionActual

        }

        public void cargarDatos()
        {
            //this.consejo = this.controlador_dao.cargarDatos();
            //foreach (Sesion sesion in this.consejo.Sesiones)
            //{
            //    if (!sesion.Estado)
            //    {
            //        this.controlador_sesion.setSesion(sesion);
            //        this.controlador_sesion.setMiembros(this.consejo.Miembros);
            //        this.controlador_solicitudes.setSolicitudes(this.consejo.Solicitudes);
            //        break;
            //    }
            //}
        }

        public void actualizarMiembros(String path)
        {
            gestor.actualizarMiembros(path);
        }


        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            //PuntoAgenda punto = new PuntoAgenda(this.controlador_dao.getNextIDPunto(), nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            //this.controlador_solicitudes.agregarSolicitud(punto);
            //this.controlador_dao.agregarSolicitud(punto); 
        }

        public void agregarSolicitud(int id, string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            //PuntoAgenda punto = new PuntoAgenda(id, nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            //this.controlador_solicitudes.agregarSolicitud(punto);
            //this.controlador_dao.agregarSolicitud(punto); 
        }

        public void agregarComentario(int idPunto, string correoMiembro, int idComentario, string txt)
        {
            //this.controlador_sesion.agregarComentario(idPunto, correoMiembro, idComentario, txt);
        }

        public void agregarComentario(int idPunto, string correoMiembro, string txt)
        {
            //this.controlador_sesion.agregarComentario(idPunto, correoMiembro, this.controlador_dao.getNextIDComentario(), txt);
        }

        public void eliminarSolicitud(int id)
        {
            //PuntoAgenda punto = this.controlador_solicitudes.eliminarSolicitud(id);
            //this.controlador_dao.eliminarSolicitud(punto.Id_punto);
        }

        public void aceptarSolicitud(int id)
        {
            //PuntoAgenda solicitud = this.controlador_solicitudes.getSolicitud(id);
            //this.controlador_solicitudes.removerSolicitud(solicitud);
            //this.controlador_sesion.agregarPuntoAgenda(solicitud);
        }

        public void agregarVotacion(int id, int aFavor, int enContra, int blanco)
        {
            //PuntoAgenda punto = this.controlador_sesion.agregarVotacion(id, aFavor, enContra, blanco);
            //this.controlador_dao.aceptarSolicitud(this.controlador_sesion.getSesion().Numero,punto.Id_punto);
        }

        public void crearActa(int tipo)
        {
            //this.controlador_docs.setDocumento(tipo);
            //Object o = this.controlador_docs.crearActa(this.controlador_sesion.getSesion());
            //this.controlador_dao.escribirActa(o);
        }

        public void crearAgenda(int tipo)
        {
            //this.controlador_docs.setDocumento(tipo);
            //Object o = this.controlador_docs.crearAgenda(this.controlador_sesion.getSesion());
            //this.controlador_dao.escribirAgenda(o);
        }

        public void modificarAsistencia(string correoMiembro, char estado)
        {
            //this.controlador_sesion.modificarAsistencia(correoMiembro, estado);
        }

        public void getSolicitudes()
        {
            //return this.controlador_solicitudes.getSolicitudes();
        }

        public void getConsejo()
        {
            //return this.consejo;
        }

        public void getPuntosAgenda()
        {
            //return this.controlador_sesion.getPuntosAgenda();
        }

        public void getAsistencia()
        {
            //return this.controlador_sesion.getAsistencia();
        }

        public void getMiembrosConsejo()
        {
            //return this.consejo.Miembros;
        }

        public void getComentarios(int idPunto)
        {
            //return this.controlador_sesion.getComentarios(idPunto);
        }

        public bool haySesion()
        {
            return gestor.haySesion();
        }

        public void cambiarPosicionPunto(int idPunto, int idPosicion)
        {
            //this.controlador_sesion.cambiarPosicionPunto(idPunto, idPosicion);
        }

        public void hayQuorum()
        {
            //return this.controlador_sesion.hayQuorum();
        }

        public void getAllPuntosAgenda()
        {
            //Collection<PuntoAgenda> puntos = new Collection<PuntoAgenda>();

            //foreach (Sesion sesion in this.consejo.Sesiones)
            //    foreach (PuntoAgenda punto in sesion.Agenda)
            //        puntos.Add(punto);
            //return puntos;
        }

        public void getAllNumeroSesiones()
        {
            //Collection<string> numeros = new Collection<string>();

            //foreach (Sesion sesion in this.consejo.Sesiones)
            //    numeros.Add(sesion.Numero);

            //return numeros;
        }
    }
}
