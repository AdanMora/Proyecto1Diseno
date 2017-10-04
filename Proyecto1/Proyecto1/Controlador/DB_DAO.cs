using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Proyecto1.Controlador
{
    public class DB_DAO
    {
        Proyecto1DB db = new Proyecto1DB();

        public DB_DAO() {
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
    }
}
