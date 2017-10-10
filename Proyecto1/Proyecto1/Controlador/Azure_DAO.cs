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
            
            foreach (sp_Solicitudes_Result solicitudBD in db.sp_Solicitudes1(1).ToList())
            {
                consejo.Solicitudes.Add(new PuntoAgenda(Decimal.ToInt32(solicitudBD.id_Punto), solicitudBD.nombre, solicitudBD.resultandos, solicitudBD.considerandos, solicitudBD.seAcuerda,0,0,0, 'A'));
            }

            //foreach (sp_Agenda_Result solicitudBD in db.sp_Agenda(1).ToList())
            //{
            //    consejo.Solicitudes.Add(new PuntoAgenda(Decimal.ToInt32(solicitudBD.id_Punto), solicitudBD.nombre, solicitudBD.resultandos, solicitudBD.considerandos, solicitudBD.seAcuerda, 0, 0, 0, 'A'));
            //}


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
