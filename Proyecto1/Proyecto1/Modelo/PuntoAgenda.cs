using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Proyecto1.Modelo
{
    public class PuntoAgenda
    {
        private string nombre;
        private int id_punto;
        private string resultando;
        private string considerandos;
        private string seAcuerda;
        private int[] votacion = new int[3];
        private char tipo;
        private Collection<Comentario> comentarios = new Collection<Comentario>();


        public PuntoAgenda() { }
        public PuntoAgenda(int id_punto, string nombre, string resultando, string considerandos, string seAcuerda, int aFavor, int enContra, int blanco, char tipo)
        {
            this.id_punto = id_punto;
            this.nombre = nombre;
            this.resultando = resultando;
            this.considerandos = considerandos;
            this.seAcuerda = seAcuerda;
            this.votacion[0] = aFavor;
            this.votacion[1] = enContra;
            this.votacion[2] = blanco;
            this.tipo = tipo;
        }

        public int Id_punto
        {
            get
            {
                return id_punto;
            }

            set
            {
                id_punto = value;
            }
        }

        public string Resultando
        {
            get
            {
                return resultando;
            }

            set
            {
                resultando = value;
            }
        }

        public string Considerandos
        {
            get
            {
                return considerandos;
            }

            set
            {
                considerandos = value;
            }
        }

        public string SeAcuerda
        {
            get
            {
                return seAcuerda;
            }

            set
            {
                seAcuerda = value;
            }
        }

        public int[] Votacion
        {
            get
            {
                return votacion;
            }

            set
            {
                votacion = value;
            }
        }

        public char Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public Collection<Comentario> Comentarios
        {
            get
            {
                return comentarios;
            }

            set
            {
                comentarios = value;
            }
        }

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

        public string toString()
        {
            return "ID: " + this.id_punto + 
                    "\nNombre: " + this.nombre +
                    "\nResultado: " + this.resultando +
                    "\nConsiderandos: " + this.considerandos +
                    "\nSeAcuerda: " + this.seAcuerda +
                    "\nVotos a favor: "+ this.votacion[0] +
                    "\nVotos en contra: " + this.votacion[1] +
                    "\nVotos en blanco: " + this.votacion[2] +
                    "\nTipo: " + this.tipo + 
                    "\n#########################################";
        }

    }
}
