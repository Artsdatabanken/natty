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
    
    public partial class RødlisteKlassifisering
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RødlisteKlassifisering()
        {
            this.Beskrivelsesvariabel = new HashSet<Beskrivelsesvariabel>();
            this.KartleggingsKode = new HashSet<KartleggingsKode>();
        }
    
        public int Id { get; set; }
    
        public virtual RødlisteVurderingsenhet RødlisteVurderingsenhet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Beskrivelsesvariabel> Beskrivelsesvariabel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KartleggingsKode> KartleggingsKode { get; set; }
        public virtual NaturområdeTypeKode NaturområdeTypeKode { get; set; }
    }
}
