//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hyvinvointisovellus
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tyontekijat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tyontekijat()
        {
            this.Hymynaama = new HashSet<Hymynaama>();
            this.Palaute = new HashSet<Palaute>();
        }
    
        public int TyontekijaID { get; set; }
        public string Etuimi { get; set; }
        public string Sukunimi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hymynaama> Hymynaama { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Palaute> Palaute { get; set; }
    }
}
