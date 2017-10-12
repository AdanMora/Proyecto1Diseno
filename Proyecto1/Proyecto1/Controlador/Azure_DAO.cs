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
            //MiembrosDB m = new MiembrosDB
            //{
            //    nombre = "Adan",
            //    correo1 = "correo1Adan",
            //    correo2 = null,
            //    tipoMiembro = "A"
            //};
            //db.MiembrosDBs.Add(m);
            //SesionDB s = new SesionDB
            //{
            //    numero = "2",
            //    fecha = DateTime.Today,
            //    lugar = "CIC",
            //    estado = true
            //};
            //db.SesionDBs.Add(s);
            //foreach (MiembrosDB x in db.MiembrosDBs.ToList())
            //{
            //    Console.WriteLine(x.ToString());
            //    Console.Read();
            //    db.MiembrosDBs.Remove(x);
            //}

            //db.SaveChanges();


        }

        public void guardarArchivo(byte[] archivo)
        {
            DocXSesionDB doc = new DocXSesionDB
            {
                nombreArchivo = "ejemplo",
                sesion = "1",
                contenido = archivo,
                tipo = "A"
            };
            db.DocXSesionDBs.Add(doc);
            db.SaveChanges();
        }

        public byte[] cargarArchivo()
        {
            foreach (DocXSesionDB d in db.DocXSesionDBs.ToList())
            {
                if (d.sesion == "1")
                {
                    return d.contenido;

                }
            }
            return null;
        }

        public Consejo cargarDatos()
        {
            Consejo consejo = new Consejo();

            if (db.sp_MiembrosXConsejo(1).ToList().Any()) {
                foreach (sp_MiembrosXConsejo_Result mBD in db.sp_MiembrosXConsejo(1).ToList())
                {
                    consejo.Miembros.Add(new Miembro(mBD.nombre, mBD.correo1, mBD.correo2, mBD.tipoMiembro.First()));
                }
            }

            if (db.sp_Solicitudes1(1).ToList().Any())
            {
                foreach (sp_Solicitudes_Result solicitudBD in db.sp_Solicitudes1(1).ToList())
                {
                    consejo.Solicitudes.Add(new PuntoAgenda(Decimal.ToInt32(solicitudBD.id_Punto), solicitudBD.nombre, solicitudBD.resultandos, solicitudBD.considerandos, solicitudBD.seAcuerda, 0, 0, 0, 'A'));
                }
            }

            if (db.sp_SesionesxConsejo(1).ToList().Any())
            {
                foreach (sp_SesionesxConsejo_Result sesionesBD in db.sp_SesionesxConsejo(1).ToList())
                {
                    consejo.Sesiones.Add(new Sesion(sesionesBD.numero, sesionesBD.fecha, sesionesBD.lugar, sesionesBD.estado));
                }

                foreach (Sesion s in consejo.Sesiones)
                {
                    if (db.sp_Agenda1(s.Numero).ToList().Any())
                    {
                        foreach (sp_Agenda1_Result agendaBD in db.sp_Agenda1(s.Numero).ToList())
                        {
                            PuntoAgenda p = new PuntoAgenda(Decimal.ToInt32(agendaBD.id_Punto), agendaBD.nombre, agendaBD.resultandos, agendaBD.considerandos, agendaBD.seAcuerda, Decimal.ToInt32(agendaBD.votosAFavor), Decimal.ToInt32(agendaBD.votosEnContra), Decimal.ToInt32(agendaBD.votosAbstenciones), agendaBD.tipoPunto.First());

                            if (db.sp_ComentariosXPunto1(p.Id_punto).ToList().Any())
                            {
                                foreach (sp_ComentariosXPunto1_Result comentariosDB in db.sp_ComentariosXPunto1(p.Id_punto))
                                {
                                    foreach (Miembro m in consejo.Miembros)
                                    {
                                        if (m.Correo[0] == comentariosDB.correo1)
                                        {
                                            p.Comentarios.Add(new Comentario(Decimal.ToInt32(comentariosDB.id_Comentario), comentariosDB.contenido, m));
                                        }
                                    }
                                }
                            }
                            s.Agenda.Add(p);
                        }
                    }
                    if (db.sp_MiembrosXSesion(s.Numero).ToList().Any())
                    {
                        Collection<Miembro> miembros = new Collection<Miembro>();
                        foreach (sp_MiembrosXSesion_Result mSesionDB in db.sp_MiembrosXSesion(s.Numero)) {
                            miembros.Add(new Miembro(mSesionDB.nombre, mSesionDB.correo1, mSesionDB.correo2, mSesionDB.tipoMiembro.First()));
                            s.MiembrosAsistencia = new Prototype_Miembros(miembros);
                        }

                        int i = 0;
                        foreach (sp_MiembrosXSesion_Result mSesionDB in db.sp_MiembrosXSesion(s.Numero))
                        {
                            s.MiembrosAsistencia.ListaAsistencia[i] = mSesionDB.estadoAsistencia.First();
                            i++;
                        }
                    }

                }

            }


            return consejo;
        }

        public void actualizarMiembros(Collection<Miembro> miembros)
        {
            foreach (Miembro m in miembros)
            {
                db.sp_nuevaActualizacion();
                db.sp_ActualizarMiembro(m.Correo[0], m.Correo[1], m.Nombre, m.TipoMiembro.ToString());
            }
            db.SaveChanges();
        }

        public void nuevaSesion(string numero, DateTime fecha, string lugar, bool estado)
        {
            db.sp_NuevaSesion(numero, fecha, lugar, estado);
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
                id_Consejo = 1,
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

        public void agregarComentario(int id_Punto, Comentario c)
        {
            db.ComentariosDBs.Add(new ComentariosDB
            {
                miembro = c.Miembro.Correo[0],
                contenido = c.Txtcomentario
            });

            db.ComentariosXPuntoDBs.Add(new ComentariosXPuntoDB
            {
                punto = id_Punto,
                comentario = c.Id_Comentario
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
    }
}
