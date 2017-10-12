using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Proyecto1.Controlador;

namespace Proyecto1.Modelo
{
    public class Sesion
    {
        private String numero;
        private DateTime fechaHora;
        private string lugar;
        private bool estado;
        private Prototype_Miembros miembrosAsistencia;
        private Collection<PuntoAgenda> agenda = new Collection<PuntoAgenda>();

        public Sesion(String num, DateTime fecha, string lugar, bool estado)
        {
            this.numero = num;
            this.fechaHora = fecha;
            this.lugar = lugar;
            this.estado = estado; // False -> Abierto , !False -> Cerrado
        }



        public String Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fechaHora;
            }

            set
            {
                fechaHora = value;
            }
        }

        public string Lugar
        {
            get
            {
                return lugar;
            }

            set
            {
                lugar = value;
            }
        }

        public bool Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        internal Collection<PuntoAgenda> Agenda
        {
            get
            {
                return agenda;
            }

            set
            {
                agenda = value;
            }
        }

        internal Prototype_Miembros MiembrosAsistencia
        {
            get
            {
                return miembrosAsistencia;
            }

            set
            {
                miembrosAsistencia = value;
            }
        }

        public Sesion(){}

        public string toString()
        {
            return "Numero: " + this.numero +
                "\nFecha: " + this.fechaHora +
                "\nLugar: " + this.lugar +
                "\nEstado: " + this.estado +
                "\n#########################################";
        }
    }
}
