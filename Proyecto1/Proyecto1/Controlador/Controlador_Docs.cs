﻿using Proyecto1.Modelo;
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
        private const int xml = 2;

        public Controlador_Docs() { }

        public void crearActa(Sesion sesion,string path)
        {
            strategy.crearActa(sesion,path);
        }

        public byte[] crearAgenda(Sesion sesion, string path)
        {
            return strategy.crearAgenda(sesion,path);
        }

        public void creaAcuerdo(PuntoAgenda punto, string destinatario, string path)
        {
            strategy.crearAcuerdo(punto, destinatario, path);
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
                case xml:
                    strategy = new Strategy_XML();
                    break;
            }
        }
        
    }
}
