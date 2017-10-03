using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Modelo
{
    public class Comentario
    {
        private string comentario;
        private Miembro miembro;
        public Comentario() { }

        public Comentario(string coment,Miembro miembro) {
            this.comentario = coment;
            this.miembro = miembro;
        }

        public void setComentario(string coment)
        {
            this.comentario = coment;
        }

        public void setMiembro(Miembro miembro)
        {
            this.miembro = miembro;
        }

        public string getComentario()
        {
            return comentario;
        }

        public Miembro getMiembro()
        {
            return this.miembro;
        }

        public string toString()
        {
            return "Comentario: " + this.comentario +
                    "\nMiembro que realizo el comentario\n" +
                    this.miembro.toString()+
                "\n----------------------------------";
        }

    }
}
