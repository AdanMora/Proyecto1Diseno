﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Modelo;
using Proyecto1.Controlador;
using System.Collections.ObjectModel;

namespace Proyecto1.Controlador
{
    public interface Controlador_DAO
    {
        Consejo cargarDatos(); // Listo a medias

        void actualizarMiembros(Collection<Miembro> m); // Falta

        void nuevaSesion(string numero, DateTime fecha, string lugar); // Listo

        void cerrarSesion(String numeroSesion); // Listo

        void guardarDocSesion(string numeroSesion, String nombre, byte[] contenido, char tipo); // Falta

        void guardarAdjunto(int id_Punto, string nombre, string extension, byte[] contenido); // Falta

        void agregarSolicitud(PuntoAgenda p); // Listo

        void eliminarSolicitud(int id_Punto); // Listo

        void aceptarSolicitud(string sesion, int id_Punto); // Listo

        void agregarVotacion(int id_Punto, int aFavor, int enContra, int abstenciones); // Listo

        void agregarComentario(int id_Punto, string correoMiembro, int idComentario, string txt); // Listo

        void modificarAsistencia(String numeroSesion, String miembro, char estado); // Listo

        int getNextIDPunto(); // Listo

        int getNextIDComentario(); //Listo

        object[] getDocSesion(string sesion, char tipo); // Falta

        Collection<Object[]> getAdjuntosPunto(int id_Punto); // Falta

        void moverPuntoAgenda(string numeroSesion, int nuevaPos, int viejaPos);

        void iniciarSesion(string numSesion);

    }
}
