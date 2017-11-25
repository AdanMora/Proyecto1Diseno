using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Modelo;
using System.Xml;

namespace Proyecto1.Controlador
{
    class Strategy_XML : Strategy_Docs
    {
        public void crearActa(Sesion sesion, string path)
        {
            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement("Sesión");

            XmlElement numero = xml.CreateElement("Número");
            numero.SetAttribute("Número", sesion.Numero);
            root.AppendChild(numero);

            XmlElement FechaHora = xml.CreateElement("FechaHora");
            FechaHora.SetAttribute("Fecha", sesion.Fecha.Date.ToString("MM/dd/yyyy"));
            FechaHora.SetAttribute("Hora", sesion.Fecha.Date.ToString("hh:mm tt"));
            root.AppendChild(FechaHora);

            XmlElement lugar = xml.CreateElement("Lugar");
            lugar.SetAttribute("Lugar", sesion.Lugar);
            root.AppendChild(lugar);

            XmlElement agenda = xml.CreateElement("Agenda");

            foreach (PuntoAgenda p in sesion.Agenda)
            {
                XmlElement punto = xml.CreateElement("Punto");

                XmlElement desc = xml.CreateElement("Descripción");

                XmlElement nombre = xml.CreateElement("Nombre");
                nombre.SetAttribute("Nombre", p.Nombre);
                desc.AppendChild(nombre);

                XmlElement res = xml.CreateElement("Resultados");
                res.SetAttribute("Resultados", p.Resultando);
                desc.AppendChild(res);

                XmlElement consi = xml.CreateElement("Considerandos");
                consi.SetAttribute("Considerandos", p.Considerandos);
                desc.AppendChild(consi);

                XmlElement acurd = xml.CreateElement("SeAcuerda");
                acurd.SetAttribute("SeAcuerda", p.SeAcuerda);
                desc.AppendChild(acurd);

                punto.AppendChild(desc);

                XmlElement votacion = xml.CreateElement("Votación");
                votacion.SetAttribute("VotosAFavor", p.Votacion[0].ToString());
                votacion.SetAttribute("VotosEnContra", p.Votacion[1].ToString());
                votacion.SetAttribute("Abstenciones", p.Votacion[2].ToString());
                punto.AppendChild(votacion);

                XmlElement comentarios = xml.CreateElement("Comentarios");
                punto.AppendChild(comentarios);

                if (p.Comentarios.Any())
                {
                    foreach (Comentario c in p.Comentarios)
                    {
                        XmlElement comentario = xml.CreateElement("Comentario");

                        XmlElement miembro = xml.CreateElement("Miembro");
                        miembro.SetAttribute("Nombre", c.Miembro.Nombre);
                        comentario.AppendChild(miembro);

                        XmlElement cont = xml.CreateElement("Contenido");
                        cont.SetAttribute("Comentario", c.Txtcomentario);
                        comentario.AppendChild(cont);

                        comentarios.AppendChild(comentario);
                    }
                }

                agenda.AppendChild(punto);
            }

            XmlElement asistencia = xml.CreateElement("Asistencia");

            for (int i = 0; i < sesion.MiembrosAsistencia.Asistencia.Count; i++)
            {
                XmlElement estadoMiembro = xml.CreateElement("Miembro");
                estadoMiembro.SetAttribute("Nombre", sesion.MiembrosAsistencia.Asistencia.ElementAt(i).Nombre);
                if (sesion.MiembrosAsistencia.ListaAsistencia.ElementAt(i) == 'P')
                {
                    estadoMiembro.SetAttribute("Estado", "Presente");
                } else
                {
                    estadoMiembro.SetAttribute("Estado", "Ausente");
                }
                
                asistencia.AppendChild(estadoMiembro);
            }

            root.AppendChild(agenda);
            root.AppendChild(asistencia);
            xml.AppendChild(root);

            xml.Save(path + "\\Sesion_" + sesion.Numero + ".xml");
        }

        public void crearAcuerdo(PuntoAgenda punto, string destinatario, string path)
        {
            throw new NotImplementedException();
        }

        public byte[] crearAgenda(Sesion sesion, string path)
        {
            throw new NotImplementedException();
        }
    }
}
