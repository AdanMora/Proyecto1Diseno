using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Proyecto1.Modelo
{
    class PuntoAgenda
    {
        private string resultado;
        private string considerandos;
        private string seAcuerda;
        private int[] votacion = new int[3];
        private char tipo;
        private Collection<string> adjuntos = new Collection<string>();
        private Collection<Comentario> comentarios = new Collection<Comentario>();


        public PuntoAgenda() { }
        public PuntoAgenda(string nombre, string resultado, string considerandos, string seAcuerda, Collection<Comentario> comentarios,
            Collection<string> adjuntos, int aFavor, int enContra, int blanco, char tipo)
        {
            this.nombre = nombre;
            this.resultado = resultado;
            this.considerandos = considerandos;
            this.seAcuerda = seAcuerda;
            this.adjuntos = adjuntos;
            this.comentarios = comentarios;
            this.votacion[0] = aFavor;
            this.votacion[1] = enContra;
            this.votacion[2] = blanco;
            this.tipo = tipo;
        }

        private string nombre { get; set; }

        public string Resultado
        {
            get
            {
                return resultado;
            }

            set
            {
                resultado = value;
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

        public Collection<string> Adjuntos
        {
            get
            {
                return adjuntos;
            }

            set
            {
                adjuntos = value;
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
        
        public string toString()
        {
            return "Nombre: " + this.nombre +
                    "\nResultado: " + this.resultado +
                    "\nConsiderandos: " + this.considerandos +
                    "\nSeAcuerda: " + this.seAcuerda +
                    "\nAdjuntos: "+ this.adjuntos +
                    "\nVotos a favor: "+ this.votacion[0] +
                    "\nVotos en contra: " + this.votacion[1] +
                    "\nVotos en blanco: " + this.votacion[2] +
                    "\nTipo" + this.tipo + 
                    "\n#########################################";
        }

    }
}
