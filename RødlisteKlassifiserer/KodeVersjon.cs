//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RødlisteKlassifiserer
{
    using System;
    using System.Collections.Generic;
    
    public partial class KodeVersjon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KodeVersjon()
        {
            this.NaturområdeTypeKode = new HashSet<NaturområdeTypeKode>();
            this.Beskrivelsesvariabel = new HashSet<Beskrivelsesvariabel>();
        }
    
        public int Id { get; set; }
        public string verdi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NaturområdeTypeKode> NaturområdeTypeKode { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Beskrivelsesvariabel> Beskrivelsesvariabel { get; set; }
    }
}
