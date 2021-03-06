//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NiNCoreKlassifiserer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kontakt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kontakt()
        {
            this.Beskrivelsesvariabel = new HashSet<Beskrivelsesvariabel>();
            this.Dataleveranse = new HashSet<Dataleveranse>();
            this.Dokument = new HashSet<Dokument>();
            this.KartlagtOmråde = new HashSet<KartlagtOmråde>();
            this.Naturområde = new HashSet<Naturområde>();
            this.NaturområdeType = new HashSet<NaturområdeType>();
            this.OmrådekartType = new HashSet<OmrådekartType>();
            this.RutenettkartType = new HashSet<RutenettkartType>();
        }
    
        public int id { get; set; }
        public string firmanavn { get; set; }
        public string kontaktperson { get; set; }
        public string epost { get; set; }
        public string telefon { get; set; }
        public string hjemmeside { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Beskrivelsesvariabel> Beskrivelsesvariabel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dataleveranse> Dataleveranse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dokument> Dokument { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KartlagtOmråde> KartlagtOmråde { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Naturområde> Naturområde { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NaturområdeType> NaturområdeType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OmrådekartType> OmrådekartType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RutenettkartType> RutenettkartType { get; set; }
    }
}
