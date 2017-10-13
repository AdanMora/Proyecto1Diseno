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
using System.Collections.ObjectModel;
using Proyecto1.Modelo;

namespace Proyecto1.Controlador
{
    class Xls_DAO
    {
        private DataSet result;

        public Xls_DAO() { }

        public Collection<Miembro> cargaXls(string path)
        {
            bool band = false;
            Collection<Miembro> listaMiembro = new Collection<Miembro>();                           
            FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);
            IExcelDataReader reader;
            reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
            reader.IsFirstRowAsColumnNames = true;
            result = reader.AsDataSet();                    
            foreach (DataTable tab in result.Tables)
            {                
                int lim = tab.Rows.Count;
                for (int j = 0; j < lim; j++)
                {
                    string nombre = "";
                    string correo1 = "";
                    string correo2 = "";
                    char tipo = ' ';
                    Miembro m;
                    if (tab.Rows[j][0].ToString()!="" )
                    {
                        nombre = tab.Rows[j][0].ToString();
                        tipo = tab.Rows[j][3].ToString().First();
                        if (tab.Rows[j][1].ToString()!="" || tab.Rows[j][2].ToString()!="")
                        {
                            if (tab.Rows[j][1].ToString() == "")
                            {
                                correo1 = "nulo";
                                correo2 = tab.Rows[j][2].ToString();
                            }
                            else
                            {
                                if (tab.Rows[j][2].ToString() == "")
                                {
                                    correo1 = tab.Rows[j][1].ToString();
                                    correo2 = "nulo";
                                }
                                else
                                {
                                    correo1 = tab.Rows[j][1].ToString();
                                    correo2 = tab.Rows[j][2].ToString();
                                }
                                
                            }
                        }
                        else
                        {
                            band = true;
                        }
                    }                                        
                    else
                    {
                        band = true;
                    }                    
                }
                if (band == true)
                {
                    listaMiembro.Clear();
                }
            }
            reader.Close();                
            return listaMiembro;
        }

    }
}
