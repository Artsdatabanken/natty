//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Forms_dev3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Naturnivå
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Naturnivå()
        {
            this.RødlisteVurderingsenhet = new HashSet<RødlisteVurderingsenhet>();
        }
    
        public int Id { get; set; }
        public string verdi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RødlisteVurderingsenhet> RødlisteVurderingsenhet { get; set; }
    }
}
