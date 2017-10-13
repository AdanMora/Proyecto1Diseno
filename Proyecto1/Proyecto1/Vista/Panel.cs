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

namespace Proyecto1.Vista
{
    public partial class Panel : Form
    {
        Gestor d = new Gestor();
        
        public Panel()
        {
            InitializeComponent();
            d.nuevaSesion("1", DateTime.Now, "CIC");                                            
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            string res = "";
            Xls_DAO xls = new Xls_DAO();
            Collection<Miembro> listaMiembros = new Collection<Miembro>();
            using (OpenFileDialog opf1 = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook|*.xls", ValidateNames = true })
            {
                if (opf1.ShowDialog() == DialogResult.OK)
                {
                    //g.actualizarMiembros(opf1.FileName);
                    //listaMiembros = g.Consejo.Miembros;
                    foreach (Miembro m in listaMiembros)
                    {
                        res = res + m.toString();
                    }
                    textBox1.Text = res;
                }
            }                                       
        }

        
        private void button2_Click(object sender, EventArgs e)
        {                        
            d.enviarNotificacion(DateTime.Now, "1");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            d.crearActa("Prueba2","Otra prueba de la\ncreación de docs");
        }

        private void generaAgenda_Click(object sender, EventArgs e)
        {
            d.crearAgenda("p1", "Agenda de prueba\npara la funcionalidad de generar la agenda");
        }
    }
}
