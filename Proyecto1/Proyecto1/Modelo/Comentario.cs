using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Modelo
{
    public class Comentario
    {
        private string txtcomentario;
        private Miembro miembro;

        public Comentario() { }

        public Comentario(string txtcomentario, Miembro miembro)
        {
            this.txtcomentario = txtcomentario;
            this.miembro = miembro;
        }


        public string Txtcomentario
        {
            get
            {
                return txtcomentario;
            }

            set
            {
                txtcomentario = value;
            }
        }

        public Miembro Miembro
        {
            get
            {
                return miembro;
            }

            set
            {
                miembro = value;
            }
        }

        public string toString()
        {
            return "Comentario: " + this.txtcomentario +
                    "\nMiembro que realizo el comentario\n" +
                    this.miembro.toString()+
                "\n----------------------------------";
        }

    }
}
