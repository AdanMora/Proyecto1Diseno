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
    
    public partial class AdjuntosXPuntoDB
    {
        public decimal id_Adjunto { get; set; }
        public Nullable<decimal> punto { get; set; }
        public string nombreArchivo { get; set; }
        public string extension { get; set; }
        public byte[] contenido { get; set; }
    
        public virtual Punto_AgendaDB Punto_AgendaDB { get; set; }
    }
}
