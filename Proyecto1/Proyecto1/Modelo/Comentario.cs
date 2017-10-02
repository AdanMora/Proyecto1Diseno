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
        public Comentario() { }

        public Comentario(string coment) {
            this.comentario = coment;
        }

        public void setComentario(string coment)
        {
            this.comentario = coment;
        }

        public string getComentario()
        {
            return comentario;
        }

    }
}
