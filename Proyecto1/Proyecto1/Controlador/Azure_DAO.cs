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

            if (db.sp_MiembrosXConsejo(1).ToList().Count != 0) {
                foreach (sp_MiembrosXConsejo_Result mBD in db.sp_MiembrosXConsejo(1).ToList())
                {
                    consejo.Miembros.Add(new Miembro(mBD.nombre, mBD.correo1, mBD.correo2, mBD.tipoMiembro.First()));
                }
            }

            if (db.sp_Solicitudes1(1).ToList().Count != 0)
            {
                foreach (sp_Solicitudes_Result solicitudBD in db.sp_Solicitudes1(1).ToList())
                {
                    consejo.Solicitudes.Add(new PuntoAgenda(Decimal.ToInt32(solicitudBD.id_Punto), solicitudBD.nombre, solicitudBD.resultandos, solicitudBD.considerandos, solicitudBD.seAcuerda, 0, 0, 0, 'A'));
                }
            }

            if (db.sp_SesionesxConsejo(1).ToList().Count != 0)
            {
                foreach (sp_SesionesxConsejo_Result sesionesBD in db.sp_SesionesxConsejo(1).ToList())
                {
                    consejo.Sesiones.Add(new Sesion(sesionesBD.numero, sesionesBD.fecha, sesionesBD.lugar, sesionesBD.estado));
                }

                foreach (Sesion s in consejo.Sesiones)
                {
                    if (db.sp_Agenda1(s.Numero).ToList().Count != 0)
                    {
                        foreach (sp_Agenda1_Result agendaBD in db.sp_Agenda1(s.Numero).ToList())
                        {
                            PuntoAgenda p = new PuntoAgenda(Decimal.ToInt32(agendaBD.id_Punto), agendaBD.nombre, agendaBD.resultandos, agendaBD.considerandos, agendaBD.seAcuerda, (int)agendaBD.votosAFavor, (int)agendaBD.votosEnContra, (int)agendaBD.votosAbstenciones, agendaBD.tipoPunto.First());

                            if (db.sp_ComentariosXPunto1(p.Id_punto).ToList().Count != 0)
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
                    if (db.sp_MiembrosXSesion(s.Numero).ToList().Count != 0)
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

        public void actualizarMiembros(Collection<Miembro> m)
        {
            throw new NotImplementedException();
        }

        public void nuevaSesion(Sesion s)
        {
            throw new NotImplementedException();
        }

        public void cerrarSesion(int numeroSesion)
        {
            throw new NotImplementedException();
        }

        public void guardarDoc(int numeroSesion, string nombre, byte[] contenido, char tipo)
        {
            throw new NotImplementedException();
        }

        public void agregarSolicitud(PuntoAgenda p)
        {
            throw new NotImplementedException();
        }

        public void agregarPuntoToAgenda(PuntoAgenda p)
        {
            throw new NotImplementedException();
        }

        public void eliminarSolicitud(PuntoAgenda p)
        {
            throw new NotImplementedException();
        }

        public void aceptarSolicitud(PuntoAgenda p)
        {
            throw new NotImplementedException();
        }

        public void agregarVotacion(int aFavor, int enContra, int abstenciones)
        {
            throw new NotImplementedException();
        }

        public void agregarComentario(Comentario c, PuntoAgenda p)
        {
            throw new NotImplementedException();
        }

        public void modificarAsistencia(Miembro m, char estado)
        {
            throw new NotImplementedException();
        }
    }
}
