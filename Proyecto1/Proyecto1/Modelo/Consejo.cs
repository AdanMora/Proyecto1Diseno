using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Proyecto1.Modelo
{
    class Consejo
    {
        private ArrayList miembros = new ArrayList();
        private ArrayList sesiones = new ArrayList();
        private ArrayList solicitudes = new ArrayList();
        

        public Consejo() { }

        public void agregarMiembro(string nombre,string correo1,string correo2,char tipo)
        {
            Miembro nuevo = new Miembro(nombre, correo1, correo2, tipo);
            this.miembros.Add(nuevo);
        }

        

        public string miembrosToString()
        {
            string resultado = "";
            for (int i = 0;i<this.miembros.Count;i++)
            {
                Miembro m = (Miembro) this.miembros[i];
                m.toString();
            }            
            return resultado;
        }
    }
}
