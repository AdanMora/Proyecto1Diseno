using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Proyecto1.Modelo
{
    public class Sesion
    {
        private int numero;
        private DateTime fecha;
        private TimeSpan hora;
        private string lugar;
        private bool estado;
        private Collection<Miembro> miembrosAsistencia = new Collection<Miembro>();
        private Collection<PuntoAgenda> Agenda = new Collection<PuntoAgenda>();

        public int Numero
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
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public TimeSpan Hora
        {
            get
            {
                return hora;
            }

            set
            {
                hora = value;
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

        public Collection<Miembro> MiembrosAsistencia
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

        internal Collection<PuntoAgenda> Agenda1
        {
            get
            {
                return Agenda;
            }

            set
            {
                Agenda = value;
            }
        }

        public Sesion(){}

        public Sesion(int num,DateTime fecha,TimeSpan hora,string lugar,bool estado)
        {
            this.numero = num;
            this.fecha = fecha;
            this.hora = hora;
            this.lugar = lugar;
            this.estado = estado;
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
