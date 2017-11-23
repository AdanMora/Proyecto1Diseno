using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Vista;
using Proyecto1.Modelo;
using System.Collections.ObjectModel;

namespace Proyecto1.Controlador
{
    public class DTO_GUI
    {
        Gestor gestor = new Gestor();
        GUI gui;

        public DTO_GUI(GUI gui)
        {
            this.gui = gui;
        }

        public void setConsejo(Consejo consejo)
        {
            this.gestor = new Gestor(consejo);
            this.gestor.cargarDatos();
        }

        public bool nuevaSesion()
        {
            if (gestor.getAllNumeroSesiones().Contains(gui.s_NumeroSesionGet))
            {
                return false;
            } else
            {
                gestor.nuevaSesion(gui.s_NumeroSesionGet, gui.dt_fechaHora, gui.tb_LugarSesion);
            return true;
            }
            
        }

        public void setMiembros()
        {
            foreach (Miembro m in gestor.getMiembrosConsejo())
            {
                gui.dg_listaMiembrosGet.Rows.Add(m.Nombre, m.Correo[0], m.Correo[1], m.TipoMiembro.ToString());
            }
        }

        public void setElementos()
        {
            foreach (String m in gestor.getAllNumeroSesiones())
            {
                gui.dg_listaMiembrosGet.Rows.Add(m,"","","");
            }
        }

        public bool cerrarSesion()
        {
            return this.gestor.cerrarSesion();

        }

        public void cargarDatos()
        {
            this.gestor.cargarDatos();
        }

        public void actualizarMiembros(String path)
        {
            gestor.actualizarMiembros(path);
            this.cargarMiembrosPrevioSecretaria();
        }


        public void agregarSolicitud(string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            this.gestor.agregarSolicitud(nombre, resultando, considerandos, seAcuerda, tipo);

        }

        public void agregarSolicitud(int id, string nombre, string resultando, string considerandos, string seAcuerda, char tipo)
        {
            //PuntoAgenda punto = new PuntoAgenda(id, nombre, resultando, considerandos, seAcuerda, 0, 0, 0, tipo);
            //this.controlador_solicitudes.agregarSolicitud(punto);
            //this.controlador_dao.agregarSolicitud(punto); 
            //this.gestor.agregarSolicitud(id,nombre, resultando, considerandos, seAcuerda, tipo);
        }

        public bool agregarComentario()
        {
            // int idPunto, string correoMiembro, int idComentario, string txt
            bool resultado = false;
            if((this.gui.cb_miembros.SelectedItem != null) && (this.gui.tb_Comentario.Text != "") && (this.gui.dg_AgendaDuranteGet.SelectedRows.Count > 0))
            {
                // (int idPunto, string correoMiembro, int idComentario, string txt)
                int id = int.Parse(this.gui.dg_AgendaDuranteGet.SelectedRows[0].Cells["IDPunto"].Value.ToString());
                this.gestor.agregarComentario(id, this.gui.cb_miembros.Text, this.gui.tb_Comentario.Text );
                resultado = true;
                this.gui.tb_Comentario.Text = "";
            }

            return resultado;
        }


        public void crearAgenda(int tipo)
        {
            //this.controlador_docs.setDocumento(tipo);
            //Object o = this.controlador_docs.crearAgenda(this.controlador_sesion.getSesion());
            //this.controlador_dao.escribirAgenda(o);
        }

        public void modificarAsistencia(string correoMiembro, char estado)
        {
            //this.controlador_sesion.modificarAsistencia(correoMiembro, estado);
        }

        public Collection<PuntoAgenda> getSolicitudes()
        {
            return this.gestor.getSolicitudes();
        }

        public void getConsejo()
        {
            //return this.consejo;
        }

        public Collection<PuntoAgenda> getPuntosAgenda()
        {
            return this.gestor.getPuntosAgenda();
        }

        public Prototype_Miembros getAsistencia()
        {
            return this.gestor.getAsistencia();
        }

        public void getMiembrosConsejo()
        {
            //return this.consejo.Miembros;
        }

        public void getComentarios(int idPunto)
        {
            //return this.controlador_sesion.getComentarios(idPunto);
        }

        public bool haySesion()
        {
            return gestor.haySesion();
        }

        

        public bool hayQuorum()
        {
            return this.gestor.hayQuorum();
        }

        public void getAllPuntosAgenda()
        {
            //Collection<PuntoAgenda> puntos = new Collection<PuntoAgenda>();

            //foreach (Sesion sesion in this.consejo.Sesiones)
            //    foreach (PuntoAgenda punto in sesion.Agenda)
            //        puntos.Add(punto);
            //return puntos;
        }

        public void getAllNumeroSesiones()
        {
            //Collection<string> numeros = new Collection<string>();

            //foreach (Sesion sesion in this.consejo.Sesiones)
            //    numeros.Add(sesion.Numero);

            //return numeros;
        }

        public void cargarMiembrosPrevioSecretaria()
        {
            Collection<Miembro> miembros;
            Console.WriteLine(haySesion());
            if (this.haySesion())
            {
                Console.WriteLine("hay sesion");
                miembros = this.gestor.getAsistencia().Asistencia;
                this.gui.btn_CrearSesion.Enabled = false;
            }
            else
            {
                miembros = this.gestor.getMiembrosConsejo();
                this.gui.btn_CrearSesion.Enabled = true;
            }
            this.gui.dg_listaMiembrosGet.Rows.Clear();
            foreach (Miembro m in miembros)
            {
                //dg_ListaMiembros
                //Console.WriteLine(m.Nombre);
                string tipo = "";
                switch (m.TipoMiembro)
                {
                    case 'A':
                        tipo = "Administrativo";
                        break;
                    case 'E':
                        tipo = "Estudiante";
                        break;
                    case 'P':
                        tipo = "Profesor";
                        break;
                }
                this.gui.dg_listaMiembrosGet.Rows.Add(m.Nombre,m.Correo[0],m.Correo[1],tipo);
            }
        }

        public void cargarSolicitudesPrevias()
        {
            Collection<PuntoAgenda> solicitudes = this.getSolicitudes();
            string tipo = "";
            this.gui.dg_Solicitudes.Rows.Clear();
            foreach (PuntoAgenda s in solicitudes)
            {
                switch (s.Tipo)
                {
                    case 'M':
                        tipo = "Moción";
                        break;
                    case 'I':
                        tipo = "Informativo";
                        break;
                    case 'T':
                        tipo = "Transacción";
                        break;
                }
                this.gui.dg_SolicitudesGet.Rows.Add(s.Id_punto.ToString(),s.Nombre, s.Considerandos, s.Resultando, s.SeAcuerda, tipo);
            }
        }

        public void cargarPuntosPrevios()
        {
            Collection<PuntoAgenda> puntos = this.getPuntosAgenda();
            Console.WriteLine(puntos.Count);
            string tipo = "";
            this.gui.dg_AgendaPrevioGet.Rows.Clear();
            foreach (PuntoAgenda s in puntos)
            {
                switch (s.Tipo)
                {
                    case 'M':
                        tipo = "Moción";
                        break;
                    case 'I':
                        tipo = "Informativo";
                        break;
                    case 'T':
                        tipo = "Transacción";
                        break;
                }
                this.gui.dg_AgendaPrevioGet.Rows.Add(s.Id_punto.ToString(), s.Nombre, s.Considerandos, s.Resultando, s.SeAcuerda, tipo);
            }
        }

        public void cargarDuranteSesion()
        {
            Collection<Miembro> miembros = this.gestor.getAsistencia().Asistencia;
            char[] asistencia = this.gestor.getAsistencia().ListaAsistencia;

            int n = asistencia.Count();
            Console.WriteLine(n);
            this.gui.clb_Asistencia.Items.Clear();
            this.gui.cb_miembros.Items.Clear();
            for(int i = 0; i < n; i++)
            {
                bool presente = false;
                if (asistencia[i] == 'P')
                    presente = true;

                this.gui.clb_Asistencia.Items.Add(miembros.ElementAt(i).Nombre, presente);
                this.gui.cb_miembros.Items.Add(miembros.ElementAt(i).Correo[0]);
            }

            Collection<PuntoAgenda> puntos = this.getPuntosAgenda();
            string tipo = "";
            this.gui.dg_AgendaDuranteGet.Rows.Clear();
            foreach (PuntoAgenda s in puntos)
            {
                switch (s.Tipo)
                {
                    case 'M':
                        tipo = "Moción";
                        break;
                    case 'I':
                        tipo = "Informativo";
                        break;
                    case 'T':
                        tipo = "Transacción";
                        break;
                }
                this.gui.dg_AgendaDuranteGet.Rows.Add(s.Id_punto.ToString(), s.Nombre, s.Considerandos, s.Resultando, s.SeAcuerda, tipo);
            }
        }

        public void cargarDuranteSesionPC()
        {
            Collection<PuntoAgenda> puntos = this.getPuntosAgenda();
            string tipo = "";
            this.gui.dg_AgendaPCGet.Rows.Clear();
            foreach (PuntoAgenda s in puntos)
            {
                switch (s.Tipo)
                {
                    case 'M':
                        tipo = "Moción";
                        break;
                    case 'I':
                        tipo = "Informativo";
                        break;
                    case 'T':
                        tipo = "Transacción";
                        break;
                }
                this.gui.dg_AgendaPCGet.Rows.Add(s.Id_punto.ToString(), s.Nombre, s.Considerandos, s.Resultando, s.SeAcuerda, tipo);
            }

            this.gui.comboBox1.Items.Clear();
            foreach(string s in this.gestor.getAllNumeroSesiones())
            {
                this.gui.comboBox1.Items.Add(s);
            }
        }

        public void cargarSesionFinalizada()
        {
            Collection<PuntoAgenda> puntos = this.gestor.getAllPuntosAgenda();
            string tipo = "";
            this.gui.dg_PuntosAgendaFinalGet.Rows.Clear();
            foreach (PuntoAgenda s in puntos)
            {
                switch (s.Tipo)
                {
                    case 'M':
                        tipo = "Moción";
                        break;
                    case 'I':
                        tipo = "Informativo";
                        break;
                    case 'T':
                        tipo = "Transacción";
                        break;
                }
                this.gui.dg_PuntosAgendaFinalGet.Rows.Add(s.Id_punto.ToString(), s.Nombre, s.Considerandos, s.Resultando, s.SeAcuerda, tipo);
            }
        }

        public void modificarAsistencia()
        {
            Collection<Miembro> miembros = this.gestor.getAsistencia().Asistencia;
            //char[] asistencia = this.gestor.getAsistencia().ListaAsistencia;
            int n = this.gui.clb_Asistencia.Items.Count;
            for(int i = 0; i < n; i++)
            {
                this.gestor.modificarAsistencia(miembros.ElementAt(i).Correo[0],this.gui.clb_Asistencia.GetItemChecked(i));
            }
            Console.WriteLine(this.gestor.getAsistencia().ListaAsistencia[0]);
        }

        public void simularSolicitudes()
        {
            String p = "solicitud/punto";
            int cont = 0;
            String b, r, c, s;

            while (cont < 20)
            {
                b = p + cont.ToString();
                r = "resultando " + cont.ToString();
                c = "considerando " + cont.ToString();
                s = "seAcuerda " + cont.ToString();
                this.agregarSolicitud(b, r, c, s, 'I');
                cont++;
            }
        }

        public bool eliminarSolicitud()
        {
            bool eliminar = false;
            if(this.gui.dg_SolicitudesGet.SelectedRows.Count > 0)
            {
                this.gestor.eliminarSolicitud(int.Parse(this.gui.dg_SolicitudesGet.SelectedRows[0].Cells["IDSol"].Value.ToString()));
                this.cargarSolicitudesPrevias();
                eliminar = true;
            }
            return eliminar;
        }

        public bool aceptarSolicitud()
        {
            bool aceptar = false;
            if (this.gui.dg_SolicitudesGet.SelectedRows.Count > 0)
            {
                this.gestor.aceptarSolicitud(int.Parse(this.gui.dg_SolicitudesGet.SelectedRows[0].Cells["IDSol"].Value.ToString()));
                this.cargarSolicitudesPrevias();
                aceptar = true;
            }
            return aceptar;
        }

        public bool cambiarPosicionPunto(int posActual, int posNueva)
        {
            bool cambio = false;

            int len = this.gestor.getPuntosAgenda().Count;
            

            if((posActual <= len) && (posNueva <= len))
            {
                this.gestor.cambiarPosicionPunto(posActual, posNueva);
                cambio = true;
            }
            
            return cambio;
        }

        public bool eliminarPuntoAgenda()
        {
            bool aceptar = false;
            if (this.gui.dg_AgendaPrevioGet.SelectedRows.Count > 0)
            {
                this.gestor.eliminarPuntoAgenda(int.Parse(this.gui.dg_AgendaPrevioGet.SelectedRows[0].Cells["IDPunto"].Value.ToString()));
                this.cargarPuntosPrevios();
                aceptar = true;
            }
            return aceptar;
        }

        public bool agregarPuntoAgenda(string nombre, string cons, string res, string acu)
        {
            bool agrego = false;

            
            if ((nombre != "") && (cons != "") && (res != "") && (acu != ""))
            {
                this.gestor.agregarPuntoAgenda(nombre, res, cons, acu, 'I');
                agrego = true;
            }
            return agrego;
        }

        public bool agregarVotacion()
        {
            int favor = int.Parse(this.gui.s_aFavor.Value.ToString());
            int contra = int.Parse(this.gui.s_enContra.Value.ToString());
            int blanco = int.Parse(this.gui.s_abstenciones.Value.ToString());

            int n = this.gestor.getAsistencia().ListaAsistencia.Count();

            bool agrego = false;
            if ((favor + contra + blanco == n) && (this.gui.dg_AgendaDuranteGet.SelectedRows.Count > 0) && (this.hayQuorum()))
            {
                int id = int.Parse(this.gui.dg_AgendaDuranteGet.SelectedRows[0].Cells["IDPunto"].Value.ToString());
                this.gestor.agregarVotacion(id,favor,contra,blanco);
                agrego = true;
                this.gui.s_aFavor.Value = 0;
                this.gui.s_enContra.Value = 0;
                this.gui.s_abstenciones.Value = 0;
            }
            return agrego;
            //PuntoAgenda punto = this.controlador_sesion.agregarVotacion(id, aFavor, enContra, blanco);
            //this.controlador_dao.aceptarSolicitud(this.controlador_sesion.getSesion().Numero,punto.Id_punto);
        }

        public bool generarActa()
        {
            //string path = this.gui.textBox1.Text;
            string sesion = this.gui.comboBox1.Text;
            if(sesion != "")
            {
                this.gestor.crearActa(sesion);
                return true;
            }
            return false;
        }

        public bool generarAgenda()
        {
            //string path = this.gui.textBox1.Text;
            string sesion = this.gui.comboBox1.Text;
            if (sesion != "")
            {
                this.gestor.crearAgenda(sesion);
                return true;
            }
            return false;
        }

        public void enviarNotificaciones()
        {
            
            this.gestor.enviarNotificacion(this.gestor.getSesion().Numero, this.gestor.getSesion().Fecha, "grupoadfafe@gmail.com");
        }

        public void enviarAgenda(string archivo)
        {
            this.gestor.enviarAgenda(this.gestor.getSesion().Numero, this.gestor.getSesion().Fecha, "grupoadfafe@gmail.com", archivo);
        }
    }
}
