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

        public Miembro() { }

        public Miembro(string nomb,string correo1,string correo2,char tipo)
        {
            this.nombre = nomb;
            this.correo[0] = correo1;
            this.correo[1] = correo2;
            this.tipoMiembro = tipo;
        }        

        public void setNombre(string nomb)
        {
            this.nombre = nomb;
        }

        public void setCorreo1(string correo)
        {
            this.correo[1] = correo;
        }

        public void setCorreo2(string correo)
        {
            this.correo[2] = correo;
        }

        public void setTipoMiembro(char tipo)
        {
            this.tipoMiembro = tipo;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public string getCorreo1()
        {
            return this.correo[0];
        }

        public string getCorreo2()
        {
            return this.correo[1];
        }

        public char getTipoMiembro()
        {
            return this.tipoMiembro;
        }

        public string toString()
        {
            return "Nombre: " + this.nombre +
                "\nCorreo 1: " + this.correo[0] +
                "\nCorreo 2: " + this.correo[1] +
                "\nTipo de miembro: " + this.tipoMiembro +
                "\n#########################################";
        }
    }
}
