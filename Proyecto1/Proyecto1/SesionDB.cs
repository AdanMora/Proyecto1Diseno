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
    
    public partial class SesionDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SesionDB()
        {
            this.DocXSesionDBs = new HashSet<DocXSesionDB>();
            this.Miembros_SesionDB = new HashSet<Miembros_SesionDB>();
            this.PuntosXSesionDBs = new HashSet<PuntosXSesionDB>();
            this.SesionesXConsejoDBs = new HashSet<SesionesXConsejoDB>();
        }
    
        public string numero { get; set; }
        public System.DateTime fecha { get; set; }
        public string lugar { get; set; }
        public bool estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocXSesionDB> DocXSesionDBs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembros_SesionDB> Miembros_SesionDB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PuntosXSesionDB> PuntosXSesionDBs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SesionesXConsejoDB> SesionesXConsejoDBs { get; set; }
    }
}
