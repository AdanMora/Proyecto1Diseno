using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1.Controlador;
using Proyecto1.Vista;
using Proyecto1.Modelo;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        Azure_DAO dao = new Azure_DAO();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    System.IO.StreamReader sr = new
            //    System.IO.StreamReader(openFileDialog1.FileName);
            //    dao.guardarArchivo(System.IO.File.ReadAllBytes(openFileDialog1.FileName));

            //    sr.Close();

            //}

            //Consejo c = dao.cargarDatos();
            //foreach (Sesion s in c.Sesiones)
            //{
            //    listBox1.Items.Add(s.toString());
            //    foreach (Miembro m in s.MiembrosAsistencia.Asistencia)
            //    {
            //        listBox1.Items.Add(m.toString());
            //    }
            //    listBox1.Items.Add(s.MiembrosAsistencia.ListaAsistencia.ToString());

            //    foreach (PuntoAgenda p in s.Agenda)
            //    {
            //        listBox1.Items.Add(p.toString());
            //        foreach (Comentario co in p.Comentarios)
            //        {
            //            listBox1.Items.Add(co.toString());

            //        }
            //    }
            //}
            //foreach (PuntoAgenda s in c.Solicitudes)
            //{
            //    listBox1.Items.Add(s.toString());
            //}

            listBox1.Items.Add(dao.getUltimoIDPunto());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.ShowDialog();
            System.IO.File.WriteAllBytes(saveFileDialog1.FileName, dao.cargarArchivo());
        }

        private void panel_Click(object sender, EventArgs e)
        {
            Vista.Panel p = new Vista.Panel();
            p.Show();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
