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

namespace Proyecto1.Vista
{
    public partial class GUI : Form
    {
        DTO_GUI controladorDTO;

        public GUI()
        {
            controladorDTO = new DTO_GUI(this);
            InitializeComponent();
            //***//
            dg_ListaMiembros.Columns.Add("NombreMiembro", "Nombre");
            dg_ListaMiembros.Columns.Add("Correo1Miembro", "Correo 1");
            dg_ListaMiembros.Columns.Add("Correo2Miembro", "Correo 2");
            dg_ListaMiembros.Columns.Add("TipoMiembro", "Tipo de Miembro");
            //***//
            dg_Solicitudes.Columns.Add("NombreSol", "Nombre");
            dg_Solicitudes.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_Solicitudes.Columns.Add("ResultandosSol", "Resultandos");
            dg_Solicitudes.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_Solicitudes.Columns.Add("TipoSol", "Tipo");
            //***//
            //***//
            dg_AgendaDurante.Columns.Add("NombreSol", "Nombre");
            dg_AgendaDurante.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_AgendaDurante.Columns.Add("ResultandosSol", "Resultandos");
            dg_AgendaDurante.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_AgendaDurante.Columns.Add("TipoSol", "Tipo");
            //***//
            dg_AgendaPC.Columns.Add("NombreSol", "Nombre");
            dg_AgendaPC.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_AgendaPC.Columns.Add("ResultandosSol", "Resultandos");
            dg_AgendaPC.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_AgendaPC.Columns.Add("TipoSol", "Tipo");
            //***//
            dg_AgendaPrevio.Columns.Add("NombreSol", "Nombre");
            dg_AgendaPrevio.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_AgendaPrevio.Columns.Add("ResultandosSol", "Resultandos");
            dg_AgendaPrevio.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_AgendaPrevio.Columns.Add("TipoSol", "Tipo");
            //***//
            dg_PuntosAgendaFinal.Columns.Add("NombreSol", "Nombre");
            dg_PuntosAgendaFinal.Columns.Add("ConsiderandosSol", "Considerandos");
            dg_PuntosAgendaFinal.Columns.Add("ResultandosSol", "Resultandos");
            dg_PuntosAgendaFinal.Columns.Add("SeAcuerda", "Se acuerda que");
            dg_PuntosAgendaFinal.Columns.Add("TipoSol", "Tipo");
            //***//

            if (controladorDTO.haySesion())
            {
                btn_CrearSesion.Enabled = false;
            }
            
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

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

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

        }

        private void tab_Solicitudes_Click(object sender, EventArgs e)
        {

        }

        private void tab_PrevioSec_Click(object sender, EventArgs e)
        {
            if (controladorDTO.haySesion())
            {
                btn_CrearSesion.Enabled = false;
            } else
            {
                btn_CrearSesion.Enabled = true;
            }
        }
    }
}
