using Proyecto1.Modelo;
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
            this.controlador_correo = new Controlador_Correo();
        }

        public Gestor()
        {
            this.controlador_dao = new Azure_DAO();
            this.consejo = new Consejo();
            this.controlador_sesion = new Controlador_Sesion();
            this.controlador_solicitudes = new Controlador_Solicitudes();
            this.controlador_docs = new Controlador_Docs();
            this.controlador_correo = new Controlador_Correo();
            this.xls = new Xls_DAO();
            this.controlador_correo = new Controlador_Correo();
        }

        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            this.controlador_sesion.nuevaSesion(num, fecha, lugar);
            this.controlador_solicitudes.setSolicitudes(this.consejo.Solicitudes);
            this.controlador_dao.nuevaSesion(num, fecha, lugar);
        }

        public bool cerrarSesion()
        {
            Sesion sesionActual = this.controlador_sesion.getSesion();
            bool existe = false;

            foreach (Sesion s in this.consejo.Sesiones)
            {
                if (s.Numero == sesionActual.Numero)
                {
                    existe = true;
                    break;
                }
            }

            if ((sesionActual != null) && !existe)
            {
                this.consejo.Sesiones.Add(sesionActual);
                //return true;
            }

            controlador_dao.cerrarSesion(controlador_sesion.getSesion().Numero);

            return this.controlador_sesion.cerrarSesion();
            // ahora hagan lo que quieran con sesionActual

        }

        public void cargarDatos()
        {
            this.consejo = this.controlador_dao.cargarDatos();
            foreach (Sesion sesion in this.consejo.Sesiones)
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
            this.controlador_sesion.setMiembros(miembros);
            this.controlador_dao.actualizarMiembros(miembros);
        }


        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            PuntoAgenda punto = new PuntoAgenda(this.controlador_dao.getNextIDPunto(), nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_solicitudes.agregarSolicitud(punto);
            this.controlador_dao.agregarSolicitud(punto);
        }

        public void agregarPuntoAgenda(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            int id = this.controlador_dao.getNextIDPunto();
            PuntoAgenda punto = new PuntoAgenda(id, nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_sesion.agregarPuntoAgenda(punto);
            this.controlador_dao.agregarSolicitud(punto);
            controlador_dao.aceptarSolicitud(controlador_sesion.getSesion().Numero, punto.Id_punto);
        }

        public void agregarComentario(int idPunto, string correoMiembro, string txt)
        {
            this.controlador_sesion.agregarComentario(idPunto, correoMiembro, this.controlador_dao.getNextIDComentario(), txt);
            this.controlador_dao.agregarComentario(idPunto, correoMiembro, this.controlador_dao.getNextIDComentario(), txt);
        }

        public void eliminarSolicitud(int id)
        {
            this.controlador_solicitudes.eliminarSolicitud(id);
            this.controlador_dao.eliminarSolicitud(id);
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
            this.controlador_dao.aceptarSolicitud(this.controlador_sesion.getSesion().Numero, id);
        }

        public void agregarVotacion(int id, int aFavor, int enContra, int blanco)
        {
            this.controlador_sesion.agregarVotacion(id, aFavor, enContra, blanco);
            this.controlador_dao.agregarVotacion(id, aFavor, enContra, blanco);
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

        public void crearAgenda(string sesion,string path)
        {
            this.controlador_docs.setDocumento(0);            
            byte[] tira = this.controlador_docs.crearAgenda(this.controlador_sesion.getSesion(), path);
            this.controlador_dao.guardarDocSesion(this.controlador_sesion.getSesion().Numero, "Agenda Sesión Ordinaria - " + this.controlador_sesion.getSesion().Numero, tira, 'A');
        }
        public void crearActa(int tipo, string path)
        {
            this.controlador_docs.setDocumento(tipo);
            this.controlador_docs.crearActa(this.controlador_sesion.getSesion(), path);
        }

        public void modificarAsistencia(string correoMiembro, bool estado)
        {
            char estadoChar = 'A';
            this.controlador_sesion.modificarAsistencia(correoMiembro, estado);
            if (estado)
                estadoChar = 'P';
            controlador_dao.modificarAsistencia(controlador_sesion.getSesion().Numero, correoMiembro, estadoChar);
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

        public void cambiarPosicionPunto(int posicionNueva, int posicionVieja)
        {
            this.controlador_sesion.cambiarPosicionPunto(posicionNueva - 1, posicionVieja - 1);
            controlador_dao.moverPuntoAgenda(controlador_sesion.getSesion().Numero, posicionNueva, posicionVieja);
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

        public void obtenerAgenda(Sesion sesion,string path)
        {
            byte[] resultado = (byte[])this.controlador_dao.getDocSesion(sesion.Numero,'A')[1];
            File.WriteAllBytes(path + "\\Agenda Sesión Ordinaria-" + sesion.Numero + ".pdf", resultado);
        }

        public void asociarActa(string numSesion, string path, string nombreArchivo)
        {
            byte[] contenido = File.ReadAllBytes(path);
            controlador_dao.guardarDocSesion(numSesion, nombreArchivo, contenido, 'B');
        }

        public void obtenerActa(string numSesion, string path)
        {
            object[] resultado = this.controlador_dao.getDocSesion(numSesion, 'B');
            File.WriteAllBytes(path + "\\" + (string)resultado[0] + ".pdf", (byte[])resultado[1]);
        }

        public void asociarAdjunto(int idPunto, string path, string nombreArchivo)
        {

        }

        public Collection<String> getAdjuntos(int idPunto)
        {
            Collection<String> adjuntos = new Collection<string>();
            Collection<Object[]> resultado = controlador_dao.getAdjuntosPunto(idPunto);

            foreach (object[] adjunto in resultado)
            {

            }

            return adjuntos;
        }

        public void obtenerAdjunto(int idPunto, string nombreAdjunto)
        {

        }
    }
}
