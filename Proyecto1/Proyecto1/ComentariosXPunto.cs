//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto1
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComentariosXPunto
    {
        public decimal id_ComentariosXPunto { get; set; }
        public Nullable<decimal> comentario { get; set; }
        public Nullable<decimal> punto { get; set; }
    
        public virtual Comentario Comentario1 { get; set; }
        public virtual Punto_Agenda Punto_Agenda { get; set; }
    }
}
