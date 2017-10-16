﻿using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;       // No olvidar.
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
        private Controlador_Docs controlador_docs;
        private Controlador_Correo controlador_correo;
        private Azure_DAO controlador_dao;
        private Xls_DAO xls;

        public Gestor(Consejo consejo)
        {
            this.consejo = consejo;
            this.controlador_dao = new Azure_DAO();
            this.controlador_sesion = new Controlador_Sesion();
            this.controlador_solicitudes = new Controlador_Solicitudes();
            this.controlador_docs = new Controlador_Docs();
            this.controlador_correo = new Controlador_Correo();
            this.xls = new Xls_DAO();
            this.controlador_correos = new Controlador_Correo();
        }

        public Gestor()
        {
            //this.controlador_dao = new Azure_DAO();
            this.consejo = new Consejo();
            this.controlador_sesion = new Controlador_Sesion();
            this.controlador_solicitudes = new Controlador_Solicitudes();
            this.controlador_docs = new Controlador_Docs();
            this.controlador_correo = new Controlador_Correo();
            this.xls = new Xls_DAO();
            this.controlador_correos = new Controlador_Correo();
        }

        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            this.controlador_sesion.nuevaSesion(num, fecha, lugar);
            this.controlador_sesion.setMiembros(this.consejo.Miembros);
            this.controlador_solicitudes.setSolicitudes(this.consejo.Solicitudes);
            this.controlador_dao.nuevaSesion(num, fecha, lugar, false);
        }

        public bool cerrarSesion()
        {
            Sesion sesionActual = this.controlador_sesion.getSesion();
            bool existe = false;

            foreach(Sesion s in this.consejo.Sesiones)
            {
                if(s.Numero == sesionActual.Numero)
                {
                    existe = true;
                    break;
                }
            }

            if((sesionActual != null) && !existe)
            {
                this.consejo.Sesiones.Add(sesionActual);
                //return true;
            }
            return this.controlador_sesion.cerrarSesion();
            // ahora hagan lo que quieran con sesionActual
            
        }

        public void cargarDatos()
        {
            this.consejo = this.controlador_dao.cargarDatos();
            foreach(Sesion sesion in this.consejo.Sesiones)
            {
                if (sesion.Estado == false)
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
            //this.controlador_sesion.setMiembros(miembros);
            this.controlador_dao.actualizarMiembros(miembros);
        }


        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            PuntoAgenda punto = new PuntoAgenda(this.controlador_dao.getNextIDPunto() , nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_solicitudes.agregarSolicitud(punto);
            this.controlador_dao.agregarSolicitud(punto); 
        }

        public void agregarSolicitud(int id, string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            PuntoAgenda punto = new PuntoAgenda(id, nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_solicitudes.agregarSolicitud(punto);
            this.controlador_dao.agregarSolicitud(punto); 
        }

        public void agregarPuntoAgenda(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            int id = this.controlador_dao.getNextIDPunto();
            PuntoAgenda punto = new PuntoAgenda(id, nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_sesion.agregarPuntoAgenda(punto);
            this.controlador_dao.agregarSolicitud(punto); 
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
            this.controlador_dao.eliminarSolicitud(punto.Id_punto);
        }

        public void eliminarPuntoAgenda(int id)
        {
            this.controlador_sesion.eliminarPuntoAgenda(id);
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
            this.controlador_dao.aceptarSolicitud(this.controlador_sesion.getSesion().Numero,punto.Id_punto);
        }

        public Sesion getSesion()
        {
            return this.controlador_sesion.getSesion();
        }

        public Sesion getSesion(string numero)
        {
            foreach(Sesion s in this.consejo.Sesiones)
            {
                if (s.Numero == numero)
                    return s;
            }
            return null;
        }

        public void crearAgenda(string sesion)
        {
            this.controlador_docs.setDocumento(0);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.controlador_docs.crearAgenda(this.getSesion(sesion), path);
            //Object o = this.controlador_docs.crearActa(this.controlador_sesion.getSesion());
            //this.controlador_dao.escribirActa(o);
        }
        public void crearActa(int tipo, string path)
        {
            this.controlador_docs.setDocumento(tipo);
            //Object o = this.controlador_sesion.getSesion();
            this.controlador_docs.crearActa(this.controlador_sesion.getSesion(), path);
            //this.controlador_dao.escribirAgenda(o);
        }

        public void crearActa(string sesion)
        {
            this.controlador_docs.setDocumento(1);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.controlador_docs.crearActa(this.getSesion(sesion), path);
            //Object o = this.controlador_docs.crearActa(this.controlador_sesion.getSesion());
            //this.controlador_dao.escribirActa(o);
        }

        public void modificarAsistencia(string correoMiembro, bool estado)
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

        public bool hayQuorum()
        {
            return this.controlador_sesion.hayQuorum();
        }

        public Collection<PuntoAgenda> getAllPuntosAgenda()
        {
            Collection<PuntoAgenda> puntos = new Collection<PuntoAgenda>();

            foreach (Sesion sesion in this.consejo.Sesiones)
                foreach (PuntoAgenda punto in sesion.Agenda)
                    puntos.Add(punto);
            return puntos;
        }

        public Collection<string> getAllNumeroSesiones()
        {
            Collection<string> numeros = new Collection<string>();

            foreach (Sesion sesion in this.consejo.Sesiones)
                numeros.Add(sesion.Numero);

            if (this.controlador_sesion.getSesion() != null)
                numeros.Add(this.controlador_sesion.getSesion().Numero);

            return numeros;
        }

        public void enviarNotificacion(string numeroSesion, DateTime fecha, string correo)
        {
            this.controlador_correo.enviarNotificaciones(numeroSesion, fecha, correo);
        }

        public void enviarAgenda(string numeroSesion, DateTime fecha, string correo, string agenda)
        {
            this.controlador_correo.enviarAgenda(numeroSesion, fecha, correo, agenda);
        }
        
        
    }
}
