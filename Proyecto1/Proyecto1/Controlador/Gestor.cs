using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Controlador
{
    public class Gestor
    {
        private Consejo consejo;
        private Controlador_Sesion controlador_sesion;
        private Controlador_Solicitudes controlador_solicitudes;
        private Azure_DAO controlador_dao;

        public Gestor(Consejo consejo)
        {
            this.consejo = consejo;
            //this.setControladores();
        }

        public Gestor()
        {
            this.controlador_dao = new Azure_DAO();
            this.controlador_sesion = new Controlador_Sesion();
            this.controlador_solicitudes = new Controlador_Solicitudes();
        }

        private void nuevaSesion(String num, DateTime fecha, string lugar)
        {
            this.controlador_sesion.nuevaSesion(num,fecha,lugar);
            this.controlador_sesion.setMiembros(this.consejo.Miembros);
            this.controlador_solicitudes.setSolicitudes(this.consejo.Solicitudes);
            // Acá creamos/instanciamos los controladores
            // Controlador de sesion:

        }

        private void cargarDatos()
        {
            this.consejo = this.controlador_dao.cargarDatos();
        }


    }
}
