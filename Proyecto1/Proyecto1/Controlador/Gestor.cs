using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;      
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
        //private Controlador_Docs controlador_docs;
        //private Azure_DAO controlador_dao;
        private Xls_DAO xls;
        private Controlador_Correo controlador_correos;

        public Gestor()
        {
            this.consejo = new Consejo();
            this.controlador_sesion = new Controlador_Sesion();
            this.controlador_solicitudes = new Controlador_Solicitudes();            
            this.xls = new Xls_DAO();
            this.controlador_correos = new Controlador_Correo();
        }

        public Consejo Consejo
        {
            get
            {
                return consejo;
            }

            set
            {
                consejo = value;
            }
        }

        internal Controlador_Sesion Controlador_sesion
        {
            get
            {
                return controlador_sesion;
            }

            set
            {
                controlador_sesion = value;
            }
        }

        internal Controlador_Solicitudes Controlador_solicitudes
        {
            get
            {
                return controlador_solicitudes;
            }

            set
            {
                controlador_solicitudes = value;
            }
        }
        /*
        public Azure_DAO Controlador_dao
        {
            get
            {
                return controlador_dao;
            }

            set
            {
                controlador_dao = value;
            }
        }*/

        internal Xls_DAO Xls
        {
            get
            {
                return xls;
            }

            set
            {
                xls = value;
            }
        }

        public Gestor(Consejo consejo)
        {
            this.consejo = consejo;
            //this.setControladores();
        }

        
        public void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            this.controlador_sesion.nuevaSesion(num,fecha,lugar);
            this.controlador_sesion.setMiembros(this.consejo.Miembros);
            this.controlador_solicitudes.setSolicitudes(this.consejo.Solicitudes);
        }

        public void cargarDatos()
        {
            //this.consejo = this.controlador_dao.cargarDatos();
        }

        public void actualizarMiembros(String path)
        {
            Collection<Miembro> miembros = this.xls.cargaXls(path);
            this.consejo.Miembros = miembros;
            this.controlador_sesion.setMiembros(miembros);
            //this.controlador_dao.actualizarMiembros(miembros);
        }


        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, int aFavor, int enContra, int blanco, char tipo)
        {
            PuntoAgenda punto = new PuntoAgenda(1, nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            this.controlador_solicitudes.agregarSolicitud(punto);
            //this.controlador_dao.agregarSolicitud(punto); 
        }

        public void eliminarSolicitud(int id)
        {
            PuntoAgenda punto = this.controlador_solicitudes.getSolicitud(id);
            if(punto != null)
            {
                punto = this.controlador_sesion.getPuntoAgenda(id);
            }
            //this.controlador_dao.eliminarSolicitud(punto);
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
            //this.controlador_dao.aceptarSolicitud(punto);
        }

        public void enviarNotificacion(DateTime fecha,string numeroSesion)
        {
            
        }

        public void crearActa(string ruta,string puntosAgenda)
        {                        
            string path = @"C:\Users\Fauricio\Desktop\"+ruta+".doc";
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(puntosAgenda);
                    fs.Write(info, 0, info.Length);
                }
                MessageBox.Show("Doc creado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doc no creado");
            }
        }

        public void crearAgenda(string ruta, string puntosAgenda)
        {            
            try
            {
                FileStream fs = new FileStream(@"C:\Users\Fauricio\Desktop\Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                doc.Add(new Paragraph(puntosAgenda));
                doc.Close();
                MessageBox.Show("Pdf creado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pdf no creado");
            }          
        }

        public void crearActa(int tipo)
        {
            //this.controlador_docs.setDocumento(tipo);
            //Object o = this.controlador_docs.crearActa(this.controlador_sesion.getSesion());
            //this.controlador_dao.escribirActa(o);
        }

        public void crearAgenda(int tipo)
        {
            //this.controlador_docs.setDocumento(tipo);
            //Object o = this.controlador_docs.crearAgenda(this.controlador_sesion.getSesion());
            //this.controlador_dao.escribirAgenda(o);
        }
    }
}
