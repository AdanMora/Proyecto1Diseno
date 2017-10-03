using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Proyecto1.Modelo
{
    public class Sesion
    {
        private int numero;
        private DateTime fecha;
        private TimeSpan hora;
        private string lugar;
        private bool estado;
        private ArrayList miembrosAsistencia = new ArrayList();
        private ArrayList Agenda = new ArrayList();

        public Sesion(){}

        public Sesion(int num,DateTime fecha,TimeSpan hora,string lugar,bool estado)
        {
            this.numero = num;
            this.fecha = fecha;
            this.hora = hora;
            this.lugar = lugar;
            this.estado = estado;
        }

        public void setNumero(int num)
        {
            this.numero = num;
        }

        public void setFecha(DateTime fecha)
        {            
            this.fecha = fecha;
        }
        public void setHora(TimeSpan hora)
        {
            this.hora = hora;
        }

        public void setLugar(string lugar)
        { 
            this.lugar = lugar;
        }

        public void setEstado(bool estado)
        {
            this.estado = estado;
        }

        public int getNumero()
        {
            return this.numero;
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }
        public TimeSpan getHora()
        {
            return this.hora;
        }

        public string getLugar()
        {
            return this.lugar;
        }

        public bool getEstado()
        {
            return this.estado;
        }

        public string toString()
        {
            return "Numero: " + this.numero +
                "\nFecha: " + this.fecha +
                "\nHora: " + this.hora +
                "\nLugar: " + this.lugar +
                "\nEstado: " + this.estado +
                "\n#########################################";
        }
    }
}
