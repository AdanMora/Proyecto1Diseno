﻿using System;
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
                    string nombre = tab.Rows[j][0].ToString();
                    string correo1 = tab.Rows[j][1].ToString();
                    string correo2 = tab.Rows[j][2].ToString();
                    char tipo = tab.Rows[j][3].ToString().First();
                    if (nombre=="" || (correo1=="" && correo2=="") || tipo==' ')
                    {
                        band = true;
                    }else
                    {
                        if (correo1 == "")
                        {
                            correo1 = "Nulo";
                        }
                        else
                        {
                            correo2 = "Nulo";
                        }
                    }
                    Miembro nuevo = new Miembro();
                    listaMiembro.Add(nuevo);
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
