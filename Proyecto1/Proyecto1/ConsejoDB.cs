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
    
    public partial class ConsejoDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConsejoDB()
        {
            this.Miembros_ConsejoDB = new HashSet<Miembros_ConsejoDB>();
            this.SesionesXConsejoDBs = new HashSet<SesionesXConsejoDB>();
            this.Solicitudes_PuntosDB = new HashSet<Solicitudes_PuntosDB>();
        }
    
        public decimal id_Consejo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembros_ConsejoDB> Miembros_ConsejoDB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SesionesXConsejoDB> SesionesXConsejoDBs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitudes_PuntosDB> Solicitudes_PuntosDB { get; set; }
    }
}
