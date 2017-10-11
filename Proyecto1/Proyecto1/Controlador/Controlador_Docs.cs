using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Controlador
{
    class Controlador_Docs
    {
        private Strategy_Docs strategy;
        private const int pdf = 0;
        private const int word = 1;

        public Controlador_Docs() { }

        public void crearActa(Sesion sesion)
        {
            strategy.crearActa(sesion);
        }

        public void crearAgenda(object puntos, int tipo)
        {
            strategy.crearAgenda(puntos);
        }

        public void setDocumento(int tipo)
        {
            strategy = null;
            switch (tipo)
            {
                case pdf:
                    //strategy
                    strategy = new Strategy_PDF();
                    break;
                case word:
                    strategy = new Strategy_DOCX();
                    break;
            }
        }
    }
}
