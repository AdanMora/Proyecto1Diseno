using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Proyecto1.Modelo
{
    class PuntoAgenda
    {
        private string nombre { get; set; }
        private string resultado;
        private string considerandos;
        private string seAcuerda;
        private ArrayList adjuntos = new ArrayList();
        private int[] votacion = new int[3];
        private char tipo;
        private ArrayList comentarios = new ArrayList();        
        

        public PuntoAgenda() { }
        public PuntoAgenda(string nombre,string resultado,string considerandos,string seAcuerda,ArrayList adjuntos,
            int aFavor,int enContra,int blanco,char tipo)
        {
            this.nombre = nombre;
            this.resultado = resultado;
            this.considerandos = considerandos;
            this.seAcuerda = seAcuerda;
            this.adjuntos = adjuntos;
            this.votacion[0] = aFavor;
            this.votacion[1] = enContra;
            this.votacion[2] = blanco;
            this.tipo = tipo;                        
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void setResultado(string resultado)
        {
            this.resultado = resultado;
        }

        public void setConsiderandos(string considerandos)
        {
            this.considerandos = considerandos;
        }

        public void setSeAcuerda(string seAcuerda)
        {
            this.seAcuerda = seAcuerda;
        }

        public void setAdjuntos(ArrayList adjuntos)
        {
            this.adjuntos = adjuntos;
        }

        public void setAFavor(int aFavor)
        {
            this.votacion[0] = aFavor;
        }

        public void setEnContra(int enContra)
        {
            this.votacion[1] = enContra;
        }

        public void setEnBlanco(int enBlanco)
        {
            this.votacion[2] = enBlanco;
        }

        public void setTipo(char tipo)
        {
            this.tipo = tipo;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public string getResultado()
        {
            return this.resultado;
        }

        public string getConsiderandos()
        {
            return this.considerandos;
        }

        public string getSeAcuerda()
        {
            return this.seAcuerda;
        }

        public ArrayList getAdjuntos()
        {
            return this.adjuntos;
        }

        public int getAFavor()
        {
            return this.votacion[0];
        }

        public int getEnContra()
        {
            return this.votacion[1];
        }

        public int getEnBlanco()
        {
            return this.votacion[2];
        }

        public char getTipo()
        {
            return this.tipo;
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
