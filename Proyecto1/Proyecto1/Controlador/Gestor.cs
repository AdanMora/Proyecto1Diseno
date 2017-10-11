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
        private Controlador_DAO controlador_dao;

        public Gestor(Consejo consejo)
        {
            this.consejo = consejo;
            this.setControladores();
        }

        public Gestor(){}

        private void setControladores()
        {
            // Acá creamos/instanciamos los controladores
        }

        private void cargarDatos()
        {
            this.consejo = this.controlador_dao.cargarDatos();
        }


    }
}
