using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;

namespace Proyecto1.Controlador
{
    public class Azure_DAO : Controlador_DAO
    {
        private Proyecto1DB db;

        public Azure_DAO() {
            this.db = new Proyecto1DB();

        }

        public Consejo cargarDatos()
        {
            Consejo consejo = new Consejo();
            consejo.Miembros = obtenerMiembros();
            consejo.Sesiones = obtenerSesiones();
            consejo.Solicitudes = obtenerSolicitudes();

            return consejo;
        }

        private Collection<Miembro> obtenerMiembros()
        {
            Collection<Miembro> miembros = new Collection<Miembro>();
            List<sp_MiembrosXConsejo_Result> listaMiembrosxConsejo = db.sp_MiembrosXConsejo().ToList();

            if (listaMiembrosxConsejo.Any())
            {
                foreach (sp_MiembrosXConsejo_Result mBD in listaMiembrosxConsejo)
                {
                    miembros.Add(new Miembro(mBD.nombre, mBD.correo1, mBD.correo2, mBD.tipoMiembro.First()));
                }
            }

            return miembros;
        }

        private Collection<Sesion> obtenerSesiones()
        {
            Collection<Sesion> sesiones = new Collection<Sesion>();
            List<sp_SesionesxConsejo_Result> listaSesionesxConsejo = db.sp_SesionesxConsejo().ToList();

            if (listaSesionesxConsejo.Any())
        {
            foreach (sp_SesionesxConsejo_Result sesionesBD in listaSesionesxConsejo)
            {
                Sesion s = new Sesion(sesionesBD.numero, sesionesBD.fecha, sesionesBD.lugar, sesionesBD.estado);
                s.MiembrosAsistencia = obtenerMiembrosSesion(s.Numero);
                s.Agenda = obtenerAgendaSesion(s.Numero, s.MiembrosAsistencia.Asistencia);
                sesiones.Add(s);
            }
        }
            return sesiones;
        }

        private Collection<PuntoAgenda> obtenerSolicitudes()
        {
            Collection<PuntoAgenda> solicitudes = new Collection<PuntoAgenda>();
            List<sp_Solicitudes1_Result> listaSolicitudes = db.sp_Solicitudes1().ToList();

            if (listaSolicitudes.Any())
            {
                foreach (sp_Solicitudes1_Result solicitudDB in listaSolicitudes)
                {
                    solicitudes.Add(new PuntoAgenda(Decimal.ToInt32(solicitudDB.id_Punto), solicitudDB.nombre, solicitudDB.resultandos, solicitudDB.considerandos, solicitudDB.seAcuerda, 0, 0, 0, solicitudDB.tipoPunto.First()));
                }
            }

            return solicitudes;
            
        }

        private Collection<PuntoAgenda> obtenerAgendaSesion(String numSesion, Collection<Miembro> miembros)
        {
            Collection<PuntoAgenda> agendaSesion = new Collection<PuntoAgenda>();
            List<sp_Agenda_Result> listaAgenda = db.sp_Agenda(numSesion).ToList();

            if (listaAgenda.Any())
            {
                foreach (sp_Agenda_Result agendaDB in listaAgenda)
                {
                    PuntoAgenda p = new PuntoAgenda(Decimal.ToInt32(agendaDB.id_Punto), agendaDB.nombre, agendaDB.resultandos, agendaDB.considerandos, agendaDB.seAcuerda, Decimal.ToInt32(agendaDB.votosAFavor.Value), Decimal.ToInt32(agendaDB.votosEnContra.Value), Decimal.ToInt32(agendaDB.votosAbstenciones.Value), agendaDB.tipoPunto.First());
                    p.Comentarios = obtenerComentarios(p.Id_punto, miembros);
                    agendaSesion.Add(p);
                }
            }

            return agendaSesion;
        }

        private Collection<Comentario> obtenerComentarios(int idPunto, Collection<Miembro> miembros)
        {
            Collection<Comentario> comentarios = new Collection<Comentario>();
            List<sp_ComentariosXPunto_Result> listaComentariosXPunto = db.sp_ComentariosXPunto(idPunto).ToList();

            if (listaComentariosXPunto.Any())
            {
                foreach (sp_ComentariosXPunto_Result comentariosDB in listaComentariosXPunto)
                {
                    foreach (Miembro m in miembros)
                    {
                        if (m.Correo[0] == comentariosDB.correo1)
                        {
                            comentarios.Add(new Comentario(Decimal.ToInt32(comentariosDB.id_Comentario), comentariosDB.contenido, m));
                        }
                    }
                }
            }

            return comentarios;
        }

        private Prototype_Miembros obtenerMiembrosSesion(string numSesion)
        {
            Collection<Miembro> miembrosSesion = new Collection<Miembro>();
            Prototype_Miembros miembrosPrototype;
            List < sp_MiembrosXSesion1_Result > listaMiembrosXSesion = db.sp_MiembrosXSesion1(numSesion).ToList();

            if (listaMiembrosXSesion.Any())
            {
                foreach (sp_MiembrosXSesion1_Result miembrosSesionDB in listaMiembrosXSesion)
                {
                    Miembro m = new Miembro(miembrosSesionDB.nombre, miembrosSesionDB.correo1, miembrosSesionDB.correo2, miembrosSesionDB.tipoMiembro.First());
                    miembrosSesion.Add(m);
                }

                miembrosPrototype = new Prototype_Miembros(miembrosSesion);

                foreach (sp_MiembrosXSesion1_Result miembrosSesionDB in listaMiembrosXSesion)
                {
                    for (int i = 0; i < miembrosSesion.Count; i++)
                    {
                        if (miembrosSesion.ElementAt(i).Correo[0] == miembrosSesionDB.correo1)
                        {
                            miembrosPrototype.ListaAsistencia.SetValue(miembrosSesionDB.estadoAsistencia.First(), i);
                        }
                    }
                }

                return miembrosPrototype;

            }

            return null;
        }

        public void actualizarMiembros(Collection<Miembro> miembros)
        {
            db.sp_nuevaActualizacion();
            foreach (Miembro m in miembros)
            {
                db.sp_ActualizarMiembro(m.Correo[0], m.Correo[1], m.Nombre, m.TipoMiembro.ToString());
            }
            db.SaveChanges();
        }

        public void nuevaSesion(string numero, DateTime fecha, string lugar)
        {
            db.sp_NuevaSesion(numero, fecha, lugar);
            db.SaveChanges();
        }

        public void cerrarSesion(String numeroSesion)
        {
            foreach (SesionDB s in db.SesionDBs.ToList())
            {
                if (s.numero == numeroSesion)
                {
                    s.estado = true;
                }
            }
            db.SaveChanges();
        }

        public void guardarDocSesion(string numeroSesion, string nombre, byte[] contenido, char tipo)
        {
            db.DocXSesionDBs.Add(new DocXSesionDB
            {
                contenido = contenido,
                nombreArchivo = nombre,
                sesion = numeroSesion,
                tipo = tipo.ToString()
            });

            db.SaveChanges();
        }

        public void guardarAdjunto(int id_Punto, string nombre, string extension, byte[] contenido)
        {
            db.AdjuntosXPuntoDBs.Add(new AdjuntosXPuntoDB
            { contenido = contenido,
              nombreArchivo = nombre,
              extension = extension,
              punto = id_Punto
            });

            db.SaveChanges();
        }

        public void agregarSolicitud(PuntoAgenda p)
        {
            db.Punto_AgendaDB.Add(new Punto_AgendaDB
            {
                nombre = p.Nombre,
                considerandos = p.Considerandos,
                resultandos = p.Resultando,
                seAcuerda = p.SeAcuerda,
                votosAFavor = 0,
                votosEnContra = 0,
                votosAbstenciones = 0,
                tipoPunto = p.Tipo.ToString()
            });

            db.Solicitudes_PuntosDB.Add(new Solicitudes_PuntosDB
            {
                id_Consejo = Decimal.ToInt32(db.sp_ConsejoActual().First().Value),
                punto = p.Id_punto
            });

            db.SaveChanges();
        }

        public void eliminarSolicitud(int id_Punto)
        {
            foreach (Punto_AgendaDB p in db.Punto_AgendaDB.ToList())
            {
                if (p.id_Punto == id_Punto)
                {
                    db.Punto_AgendaDB.Remove(p);
                }
            }
            db.SaveChanges();
        }

        public void aceptarSolicitud(string sesion, int id_Punto)
        {
            db.sp_AceptarSolicitud(sesion, id_Punto);
            db.SaveChanges();
        }

        public void agregarVotacion(int id_Punto, int aFavor, int enContra, int abstenciones)
        {
            foreach (Punto_AgendaDB p in db.Punto_AgendaDB.ToList())
            {
                if (p.id_Punto == id_Punto){
                    p.votosAFavor = aFavor;
                    p.votosEnContra = enContra;
                    p.votosAbstenciones = abstenciones;
                }
            }
            db.SaveChanges();
        }

        public void agregarComentario(int id_Punto, string correoMiembro, int idComentario, string txt)
        {
            db.ComentariosDBs.Add(new ComentariosDB
            {
                miembro = correoMiembro,
                contenido = txt
            });

            db.ComentariosXPuntoDBs.Add(new ComentariosXPuntoDB
            {
                punto = id_Punto,
                comentario = idComentario
            });
            db.SaveChanges();
        }

        public void modificarAsistencia(String numeroSesion, String miembro, char estado)
        {
            foreach (Miembros_SesionDB m in db.Miembros_SesionDB.ToList())
            {
                if ((m.miembro == miembro) && (m.sesion == numeroSesion))
                {
                    m.estadoAsistencia = estado.ToString();
                }
            }
            db.SaveChanges();
        }

        public int getNextIDPunto()
        {
            return Decimal.ToInt32(db.sp_NextIDPunto().First().Value);

        }

        public int getNextIDComentario()
        {
            return Decimal.ToInt32(db.sp_NextIDComentario().First().Value);
        }        

        public byte[] getDocSesion(string sesion, char tipo)
        {
            foreach (DocXSesionDB d in db.DocXSesionDBs.ToList())
            {
                if ((d.sesion == sesion) && (d.tipo[0] == tipo))
                {
                    return d.contenido;
                }
            }
            return null;
        }

        public Collection<Object[]> getAdjuntosPunto(int id_Punto)
        {
            Collection<Object[]> tuplaAdjunto = new Collection<object[]>();

            foreach (AdjuntosXPuntoDB d in db.AdjuntosXPuntoDBs.ToList())
            {
                if (d.punto == id_Punto)
                {
                    tuplaAdjunto.Add(new object[] { d.nombreArchivo, d.extension, d.contenido });
                }
            }
            return tuplaAdjunto;
        }

        public void moverPuntoAgenda(string numeroSesion, int nuevaPos, int viejaPos)
        {
            db.sp_MoverPuntoAgenda(numeroSesion, nuevaPos, viejaPos);
            db.SaveChanges();
        }
    }
}
