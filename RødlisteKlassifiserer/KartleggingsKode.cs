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
    
    public partial class KartleggingsKode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KartleggingsKode()
        {
            this.RødlisteKlassifisering = new HashSet<RødlisteKlassifisering>();
        }
    
        public int Id { get; set; }
        public Nullable<short> verdi { get; set; }
        public string nivå { get; set; }
        public string navn { get; set; }
    
        public virtual NaturområdeTypeKode NaturområdeTypeKode { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RødlisteKlassifisering> RødlisteKlassifisering { get; set; }
    }
}
