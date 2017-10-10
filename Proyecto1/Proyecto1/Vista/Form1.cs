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
            
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                dao.guardarArchivo(System.IO.File.ReadAllBytes(openFileDialog1.FileName));
                
                sr.Close();

            }
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
    }
}
