using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel;
using Proyecto1.Controlador;
using Proyecto1.Modelo;
using System.Collections.ObjectModel;
/*
using System.Net;      
using System.Net.Mail;
using System.Net.Mime;*/

namespace Proyecto1.Vista
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = "";
            Xls_DAO xls = new Xls_DAO();
            Collection<Miembro> listaMiembros = new Collection<Miembro>();
            using (OpenFileDialog opf = new OpenFileDialog() { Filter = "Excel Workbook|*.xls|Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    listaMiembros = xls.cargaXls(opf.FileName);

                    foreach (Miembro m in listaMiembros)
                    {
                        res = res + m.toString();
                    }
                    textBox1.Text = res;
                }
            }                                       
        }

        Gestor g = new Gestor();
        private void button2_Click(object sender, EventArgs e)
        {                        
            g.enviarNotificacion(DateTime.Now, "1");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            g.crearActa("Prueba2","Otra prueba de la\ncreación de docs");
        }

        private void generaAgenda_Click(object sender, EventArgs e)
        {
            g.crearAgenda("p1", "Agenda de prueba\npara la funcionalidad de generar la agenda");
        }
    }
}
