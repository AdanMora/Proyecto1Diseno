﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.Vista
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
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

        public Collection<string[]> dg_listaMiembrosSetValues
        {
            set { dg_ListaMiembros.DataSource = value; }
        }

        public int dg_listaMiembrosGetSelected
        {
            get { return dg_ListaMiembros.CurrentRow.Index; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        }
    }
}