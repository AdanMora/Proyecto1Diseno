using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1.Controlador;
using System.Globalization;
using Proyecto1.Modelo;

namespace Proyecto1.Vista
{
    public partial class GUI : Form
    {
        DTO_GUI controladorDTO;

        public GUI()
        {
            controladorDTO = new DTO_GUI(this);
            //controladorDTO.setConsejo(c);
            controladorDTO.cargarDatos();
            InitializeComponent();
            //***//
            dg_ListaMiembros.Columns.Add("NombreMiembro", "Nombre");
            dg_ListaMiembros.Columns.Add("Correo1Miembro", "Correo 1");
            dg_ListaMiembros.Columns.Add("Correo2Miembro", "Correo 2");
            dg_ListaMiembros.Columns.Add("TipoMiembro", "Tipo de Miembro");
            //***//
            dg_Solicitudes.Columns.Add("IDSol", "ID");
            dg_Solicitudes.Columns.Add("NombreSol", "Nombre");
            dg_Solicitudes.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_Solicitudes.Columns.Add("ResultandosSol", "Resultandos");
            dg_Solicitudes.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_Solicitudes.Columns.Add("TipoSol", "Tipo");
            //***//
            //***//
            dg_AgendaDurante.Columns.Add("IDPunto", "ID");
            dg_AgendaDurante.Columns.Add("NombreSol", "Nombre");
            dg_AgendaDurante.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_AgendaDurante.Columns.Add("ResultandosSol", "Resultandos");
            dg_AgendaDurante.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_AgendaDurante.Columns.Add("TipoSol", "Tipo");
            //***//
            dg_AgendaPC.Columns.Add("IDSol", "ID");
            dg_AgendaPC.Columns.Add("NombreSol", "Nombre");
            dg_AgendaPC.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_AgendaPC.Columns.Add("ResultandosSol", "Resultandos");
            dg_AgendaPC.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_AgendaPC.Columns.Add("TipoSol", "Tipo");
            //***//
            dg_AgendaPrevio.Columns.Add("IDPunto", "ID");
            dg_AgendaPrevio.Columns.Add("NombreSol", "Nombre");
            dg_AgendaPrevio.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_AgendaPrevio.Columns.Add("ResultandosSol", "Resultandos");
            dg_AgendaPrevio.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_AgendaPrevio.Columns.Add("TipoSol", "Tipo");
            //***//
            dg_PuntosAgendaFinal.Columns.Add("IDPunto", "ID");
            dg_PuntosAgendaFinal.Columns.Add("NombreSol", "Nombre");
            dg_PuntosAgendaFinal.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_PuntosAgendaFinal.Columns.Add("ResultandosSol", "Resultandos");
            dg_PuntosAgendaFinal.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_PuntosAgendaFinal.Columns.Add("TipoSol", "Tipo");
            //***//
            this.cargarDatosPrevioSecretaria();            
        }

        public String s_NumeroSesionGet
        {
            get { return s_numeroSesion.Value + "-" + DateTime.Today.Year; }
        }

        public int s_NumeroSesionSet
        {
            set { s_numeroSesion.Value = value; }
        }

        public String tb_LugarSesion
        {
            get { return tb_lugarSesion.Text; }
            set { tb_lugarSesion.Text = value; }
        }


        public DateTime dt_fechaHora
        {
            get { return dt_FechaHora.Value; }
            set { dt_FechaHora.Value = value; }
        }

        public DataGridView dg_listaMiembrosGet
        {
            get { return dg_ListaMiembros; }
        }

        public DataGridView dg_SolicitudesGet
        {
            get { return dg_Solicitudes; }
        }

        public DataGridView dg_AgendaDuranteGet
        {
            get { return dg_AgendaDurante; }
        }

        public DataGridView dg_AgendaPrevioGet
        {
            get { return dg_AgendaPrevio; }
        }

        public DataGridView dg_AgendaPCGet
        {
            get { return dg_AgendaPC; }
        }

        //dg_PuntosAgendaFinal
        public DataGridView dg_PuntosAgendaFinalGet
        {
            get { return dg_PuntosAgendaFinal; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                sr.Close();

                controladorDTO.actualizarMiembros(openFileDialog1.FileName);
                
            }
        }

        private void btn__Click(object sender, EventArgs e)
        {
            this.controladorDTO.simularSolicitudes();
            MessageBox.Show("Se ha simulado las solicitudes");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_Notificar_Click(object sender, EventArgs e)
        {
            if (controladorDTO.haySesion())
            {
                //controladorDTO.
            }
            else
            {
                MessageBox.Show("No hay una sesión abierta", "Notificar Miembros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_MoverPunto_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clb_Asistencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_IniciarSesion_Click(object sender, EventArgs e)
        {
            bool q = this.controladorDTO.hayQuorum();
            if (q)
                MessageBox.Show("Si hay quorum");
            else MessageBox.Show("No hay quorum");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            bool msg = this.controladorDTO.agregarVotacion();
            if (msg)
                MessageBox.Show("Se modificó la votación correctamente");
            else MessageBox.Show("Hubo un error, pudo ser la falta de quorum o la cantidad de votos no coincide o no seleccionó ningun punto");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            bool msg = this.controladorDTO.cerrarSesion();
            if (msg)
                MessageBox.Show("Se cerro la sesión correctamente");
            else MessageBox.Show("Hubo un error, quizás no había ninguna sesión por cerrar");

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void btn_CrearSesion_Click(object sender, EventArgs e)
        {
            if (tb_LugarSesion.Any() == false)
            {
                MessageBox.Show("Falta el lugar donde se llevará acabo la reunión...", "Crear Sesión", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } else if ((MessageBox.Show("Está seguro en crear la sesión: " + s_numeroSesion.Value + "-" + DateTime.Today.Year + "\nLugar: " + tb_LugarSesion + "\nFecha y Hora: " + String.Format("{0:f}", dt_FechaHora.Value), "Crear Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (controladorDTO.nuevaSesion())
                {
                    MessageBox.Show("Sesión creada", "Crear Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btn_CrearSesion.Enabled = false;
                } else
                {
                    MessageBox.Show("El número de sesión no está disponible...", "Crear Sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            controladorDTO.setElementos();
            controladorDTO.cargarMiembrosPrevioSecretaria();
        }

        private void tab_Solicitudes_Click(object sender, EventArgs e)
        {
            // Gestion Solicitudes
            this.controladorDTO.cargarSolicitudesPrevias();
        }

        private void tab_PrevioSec_Click(object sender, EventArgs e)
        {
            Console.WriteLine("cambio");
            // Previo Secretaria 
            if (controladorDTO.haySesion())
            {
                btn_CrearSesion.Enabled = false;
            } else
            {
                btn_CrearSesion.Enabled = true;
            }
        }

        private void tab_DuranteSec_Click(object sender, EventArgs e)
        {
            // Durante sesion(secretaria)
            this.controladorDTO.cargarDuranteSesion();
        }

        private void tab_PrevioPC_Click(object sender, EventArgs e)
        {
            // Gestion de la agenda(previo)
            this.controladorDTO.cargarPuntosPrevios();
        }

        private void tab_DurantePC_Click(object sender, EventArgs e)
        {
            // Durante sesion(PC)
            this.controladorDTO.cargarDuranteSesionPC();
        }

        private void tab_SesionTerminada_Click(object sender, EventArgs e)
        {
            // Sesion terminada
            this.controladorDTO.cargarSesionFinalizada();
        }

        private void cargarDatosPrevioSecretaria()
        {
            this.controladorDTO.cargarMiembrosPrevioSecretaria();
        }

        private void btn_RechazarSolicitud_Click(object sender, EventArgs e)
        {
            bool msg = this.controladorDTO.eliminarSolicitud();
            if (msg)
                MessageBox.Show("Se eliminó correctamente");
            else
                MessageBox.Show("Seleccione una solicitud para eliminar");
        }

        private void btn_AgregarAgenda_Click(object sender, EventArgs e)
        {
            bool msg = this.controladorDTO.aceptarSolicitud();
            if (msg)
                MessageBox.Show("Se agregó a la agenda correctamente");
            else
                MessageBox.Show("Seleccione una solicitud para agregar");
        }

        private void btn_MoverPuntoPrevio_Click(object sender, EventArgs e)
        {
            int posActual = int.Parse(this.s_PosActualPrevio.Value.ToString());
            int posNueva = int.Parse(this.s_PosFinalPrevio.Value.ToString());
            bool msg = this.controladorDTO.cambiarPosicionPunto(posActual, posNueva);
            if (msg)
            {
                MessageBox.Show("Se cambió correctamente");
                this.controladorDTO.cargarPuntosPrevios();
            }
            else
                MessageBox.Show("Seleccione un punto o error en la cantidad de puntos");
        }

        private void btn_AgregarPuntoPrevio_Click(object sender, EventArgs e)
        {
            string nombre = this.tb_NombrePrevio.Text;
            string cons = this.rtb_ConsiderandosPrevio.Text;
            string res = this.rtb_ResultandosPrevio.Text;
            string acu = this.rtb_seAcuerdaPrevio.Text;
            bool msg = this.controladorDTO.agregarPuntoAgenda(nombre, cons, res, acu);
            if (msg)
            {
                MessageBox.Show("Se agregó correctamente");
                this.tb_NombrePrevio.Text = "";
                this.rtb_ConsiderandosPrevio.Text = "";
                this.rtb_ResultandosPrevio.Text = "";
                this.rtb_seAcuerdaPrevio.Text = "";
                this.controladorDTO.cargarPuntosPrevios();
            }
            else
                MessageBox.Show("Campos incompletos");
        }

        private void btn_EliminarPunto_Click(object sender, EventArgs e)
        {
            bool msg = this.controladorDTO.eliminarPuntoAgenda();
            if (msg)
                MessageBox.Show("Se eliminó correctamente");
            else
                MessageBox.Show("Seleccione un punto para eliminar");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.controladorDTO.modificarAsistencia();
        }

        private void btn_RegComentario_Click(object sender, EventArgs e)
        {
            bool msg = this.controladorDTO.agregarComentario();
            if (msg)
                MessageBox.Show("Se agregó el comentario correctamente");
            else
                MessageBox.Show("Hubo un error, campos incompletos o no seleccionó el punto");
        }

        private void btn_MoverPuntoDurante_Click(object sender, EventArgs e)
        {
            int posActual = int.Parse(this.s_PosActualDurante.Value.ToString());
            int posNueva = int.Parse(this.PosFinalDurante.Value.ToString());
            if (this.controladorDTO.cambiarPosicionPunto(posActual, posNueva))
            {
                MessageBox.Show("Se cambió correctamente");
                this.controladorDTO.cargarDuranteSesionPC();
            }
            else MessageBox.Show("Hubo un error en el cambio, quizás no seleccionó un punto");
            
        }

        private void btn_AgregarPuntoDurante_Click(object sender, EventArgs e)
        {
            string nombre = this.tb_nombreDurante.Text;
            string cons = this.rtb_ConsiderandosDurante.Text;
            string res = this.rtb_resultandosDurante.Text;
            string acu = this.rtb_SeAcuerdaDurante.Text;
            bool msg = this.controladorDTO.agregarPuntoAgenda(nombre, cons, res, acu);
            if (msg)
            {
                MessageBox.Show("Se agregó correctamente");
                this.tb_NombrePrevio.Text = "";
                this.rtb_ConsiderandosDurante.Text = "";
                this.rtb_resultandosDurante.Text = "";
                this.rtb_SeAcuerdaDurante.Text = "";
                this.controladorDTO.cargarDuranteSesionPC();
            }
            else
                MessageBox.Show("Campos incompletos");
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            this.controladorDTO.generarActa();
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.controladorDTO.generarAgenda();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.controladorDTO.enviarNotificaciones();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Enviar Agenda
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                sr.Close();

                controladorDTO.enviarAgenda(openFileDialog1.FileName);

            }
        }
    }
}
