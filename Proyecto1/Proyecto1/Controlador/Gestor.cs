﻿using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Controlador
{
    public class Gestor
    {
        private Consejo consejo;
        private Controlador_Sesion controlador_sesion;
        private Controlador_Solicitudes controlador_solicitudes;
        private Azure_DAO controlador_dao;
        private Xls_DAO xls;

        public Gestor(Consejo consejo)
        {
            this.consejo = consejo;
            //this.setControladores();
        }

        public Gestor()
        {
            this.controlador_dao = new Azure_DAO();
            this.controlador_sesion = new Controlador_Sesion();
            this.controlador_solicitudes = new Controlador_Solicitudes();
            this.xls = new Xls_DAO();
        }

        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            this.controlador_sesion.nuevaSesion(num,fecha,lugar);
            this.controlador_sesion.setMiembros(this.consejo.Miembros);
            this.controlador_solicitudes.setSolicitudes(this.consejo.Solicitudes);
        }

        public void cargarDatos()
        {
            this.consejo = this.controlador_dao.cargarDatos();
        }

        public void actualizarMiembros(String path)
        {
            Collection<Miembro> miembros = this.xls.cargaXls(path);
            this.consejo.Miembros = miembros;
            this.controlador_sesion.setMiembros(miembros);
            this.controlador_dao.actualizarMiembros(miembros);
        }


        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, int aFavor, int enContra, int blanco, char tipo)
        {
            PuntoAgenda punto = new PuntoAgenda(this.controlador_dao.getUltimoIDPunto(), nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_solicitudes.agregarSolicitud(punto);
            this.controlador_dao.agregarSolicitud(punto); 
        }

        public void eliminarSolicitud(int id)
        {
            PuntoAgenda punto = this.controlador_solicitudes.getSolicitud(id);
            if(punto != null)
            {
                punto = this.controlador_sesion.getPuntoAgenda(id);
            }
            this.controlador_dao.eliminarSolicitud(punto);
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
            this.controlador_dao.aceptarSolicitud(punto);
        }

        public void agregarComentario(int idMiembro, string txtcomentario)
        {
            Miembro m = this.controlador_sesion.getMiembro(idMiembro);
            // Estamos agregando un comentario
        }
    }
}
