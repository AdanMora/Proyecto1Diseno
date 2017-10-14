﻿using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;      
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Proyecto1.Controlador
{
    public class Gestor
    {
        private Consejo consejo;
        private Controlador_Sesion controlador_sesion;
        private Controlador_Solicitudes controlador_solicitudes;
        //private Controlador_Docs controlador_docs;
        //private Azure_DAO controlador_dao;
        private Xls_DAO xls;
        private Controlador_Correo controlador_correos;

        public Gestor()
        {
            this.consejo = new Consejo();
            this.controlador_sesion = new Controlador_Sesion();
            this.controlador_solicitudes = new Controlador_Solicitudes();            
            this.xls = new Xls_DAO();
            this.controlador_correos = new Controlador_Correo();
        }

        public Consejo Consejo
        {
            get
            {
                return consejo;
            }

            set
            {
                consejo = value;
            }
        }

        internal Controlador_Sesion Controlador_sesion
        {
            get
            {
                return controlador_sesion;
            }

            set
            {
                controlador_sesion = value;
            }
        }

        internal Controlador_Solicitudes Controlador_solicitudes
        {
            get
            {
                return controlador_solicitudes;
            }

            set
            {
                controlador_solicitudes = value;
            }
        }
        /*
        public Azure_DAO Controlador_dao
        {
            get
            {
                return controlador_dao;
            }

            set
            {
                controlador_dao = value;
            }
        }*/

        internal Xls_DAO Xls
        {
            get
            {
                return xls;
            }

            set
            {
                xls = value;
            }
        }

        internal Controlador_Correo Controlador_correos
        {
            get
            {
                return controlador_correos;
            }

            set
            {
                controlador_correos = value;
            }
        }

        public Gestor(Consejo consejo)
        {
            this.consejo = consejo;
            this.controlador_dao = new Azure_DAO();
            this.controlador_sesion = new Controlador_Sesion();
            this.controlador_solicitudes = new Controlador_Solicitudes();
            this.controlador_docs = new Controlador_Docs();
            this.xls = new Xls_DAO();
            //this.setControladores();
        }

        
        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            if (!this.haySesion())
            {
                this.controlador_sesion.nuevaSesion(num, fecha, lugar);
                this.controlador_sesion.setMiembros(this.consejo.Miembros);
                this.controlador_solicitudes.setSolicitudes(this.consejo.Solicitudes);
                //this.controlador_dao.nuevaSesion(num, fecha, lugar, false);
            }
        }

        public void cerrarSesion()
        {
            Sesion sesionActual = this.controlador_sesion.getSesion();
            
        }

        public void cargarDatos()
        {
            //this.consejo = this.controlador_dao.cargarDatos();
            foreach(Sesion sesion in this.consejo.Sesiones)
            {
                if (!sesion.Estado)
                {
                    this.controlador_sesion.setSesion(sesion);
                    this.controlador_sesion.setMiembros(this.consejo.Miembros);
                    this.controlador_solicitudes.setSolicitudes(this.consejo.Solicitudes);
                    break;
                }
            }
        }

        public void actualizarMiembros(String path)
        {
            Collection<Miembro> miembros = this.xls.cargaXls(path);            
            this.consejo.Miembros = miembros;
            this.controlador_sesion.setMiembros(miembros);
            //this.controlador_dao.actualizarMiembros(miembros);
        }


        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            PuntoAgenda punto = new PuntoAgenda(this.controlador_dao.getNextIDPunto() , nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_solicitudes.agregarSolicitud(punto);
            //this.controlador_dao.agregarSolicitud(punto); 
        }

        public void agregarSolicitud(int id, string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            PuntoAgenda punto = new PuntoAgenda(id, nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_solicitudes.agregarSolicitud(punto);
            //this.controlador_dao.agregarSolicitud(punto); 
        }

        public void agregarComentario(int idPunto, string correoMiembro, int idComentario, string txt)
        {
            this.controlador_sesion.agregarComentario(idPunto, correoMiembro, idComentario, txt);
        }

        public void agregarComentario(int idPunto, string correoMiembro, string txt)
        {
            this.controlador_sesion.agregarComentario(idPunto, correoMiembro, this.controlador_dao.getNextIDComentario(), txt);
        }

        public void eliminarSolicitud(int id)
        {
            PuntoAgenda punto = this.controlador_solicitudes.eliminarSolicitud(id);
            //this.controlador_dao.eliminarSolicitud(punto.Id_punto);
        }

        public void aceptarSolicitud(int id)
        {
            PuntoAgenda solicitud = this.controlador_solicitudes.getSolicitud(id);
            this.controlador_solicitudes.removerSolicitud(solicitud);
            this.controlador_sesion.agregarPuntoAgenda(solicitud);
        }

        public void agregarVotacion(int id, int aFavor, int enContra, int blanco)
        {
            PuntoAgenda punto = this.controlador_sesion.agregarVotacion(id, aFavor, enContra, blanco);
            //this.controlador_dao.aceptarSolicitud(this.controlador_sesion.getSesion().Numero,punto.Id_punto);
        }

        public void crearActa(int tipo)
        {
            this.controlador_docs.setDocumento(tipo);
            //Object o = this.controlador_docs.crearActa(this.controlador_sesion.getSesion());
            //this.controlador_dao.escribirActa(o);
        }

        public void crearAgenda(int tipo)
        {
            this.controlador_docs.setDocumento(tipo);
            //Object o = this.controlador_docs.crearAgenda(this.controlador_sesion.getSesion());
            //this.controlador_dao.escribirAgenda(o);
        }

        public void modificarAsistencia(string correoMiembro, char estado)
        {
            this.controlador_sesion.modificarAsistencia(correoMiembro, estado);
        }

        public Collection<PuntoAgenda> getSolicitudes()
        {
            return this.controlador_solicitudes.getSolicitudes();
        }

        public Consejo getConsejo()
        {
            return this.consejo;
        }

        public Collection<PuntoAgenda> getPuntosAgenda()
        {
            return this.controlador_sesion.getPuntosAgenda();
        }

        public Prototype_Miembros getAsistencia()
        {
            return this.controlador_sesion.getAsistencia();
        }

        public Collection<Miembro> getMiembrosConsejo()
        {
            return this.consejo.Miembros;
        }

        public Collection<Comentario> getComentarios(int idPunto)
        {
            return this.controlador_sesion.getComentarios(idPunto);
        }

        public bool haySesion()
        {
            return this.controlador_sesion.haySesion();
        }

        public void cambiarPosicionPunto(int idPunto, int idPosicion)
        {
            this.controlador_sesion.cambiarPosicionPunto(idPunto, idPosicion);
        }


    }
}
