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
    
    public partial class SesionesXConsejoDB
    {
        public decimal id_SesionesXConsejo { get; set; }
        public Nullable<decimal> id_Consejo { get; set; }
        public string sesion { get; set; }
    
        public virtual ConsejoDB ConsejoDB { get; set; }
        public virtual SesionDB SesionDB { get; set; }
    }
}
