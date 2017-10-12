using System;
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
        Consejo cargarDatos();

        void actualizarMiembros(Collection<Miembro> m);

        void nuevaSesion(Sesion s);

        void cerrarSesion(int numeroSesion);

        void guardarDoc(int numeroSesion, String nombre, byte[] contenido, char tipo);

        void agregarSolicitud(PuntoAgenda p);

        void eliminarSolicitud(PuntoAgenda p);

        void aceptarSolicitud(PuntoAgenda p);

        void agregarVotacion(int aFavor, int enContra, int abstenciones);

        void agregarComentario(Comentario c, PuntoAgenda p);

        void modificarAsistencia(Miembro m, char estado);

        int getUltimoIDPunto();

        int getUltimoIDComentario();

    }
}
