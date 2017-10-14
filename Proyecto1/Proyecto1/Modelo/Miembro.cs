using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Proyecto1.Modelo
{
    public class Miembro
    {
        private string nombre;
        private string[] correo= new string[2];
        private char tipoMiembro;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string[] Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public char TipoMiembro
        {
            get
            {
                return tipoMiembro;
            }

            set
            {
                tipoMiembro = value;
            }
        }

        public Miembro() { }

        public Miembro(string nomb,string correo1,string correo2,char tipo)
        {
            this.nombre = nomb;
            this.correo[0] = correo1;
            this.correo[1] = correo2;
            this.tipoMiembro = tipo;
        }        

       

        public string toString()
        {
            string res = "Nombre: " + this.nombre +
                " \n Correo 1: " + this.correo[0] +
                " \n Correo 2: " + this.correo[1] +
                " \n Tipo de miembro: " + this.tipoMiembro +
                " \n #########################################";

            return res;
        }
    }
}
