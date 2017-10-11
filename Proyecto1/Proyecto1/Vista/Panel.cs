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
using GoEmail;

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

        private void button2_Click(object sender, EventArgs e)
        {

            EnviarEmail m = new EnviarEmail();
            bool exito = m.EnviarMail("fauriciocr@gmail.com", "Encabezado", "mensj", "", "grupoadfafe@gmail.com", "Grupoadfafe.");
            if (exito == true)
            {
                MessageBox.Show("Correo Enviado");
            }
            else
            {
                MessageBox.Show("El correo no fue enviado");
            }
        }
    }
}
