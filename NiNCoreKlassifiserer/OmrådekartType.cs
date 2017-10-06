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
    
    public partial class OmrådekartType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OmrådekartType()
        {
            this.Dokument = new HashSet<Dokument>();
            this.Områdekart = new HashSet<Områdekart>();
        }
    
        public int id { get; set; }
        public System.Guid doc_guid { get; set; }
        public string navn { get; set; }
        public string koderegister { get; set; }
        public string kodeversjon { get; set; }
        public string kode { get; set; }
        public string minimumsverdi { get; set; }
        public string maksimumsverdi { get; set; }
        public string beskrivelse { get; set; }
        public System.DateTime etablert { get; set; }
        public int eier_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dokument> Dokument { get; set; }
        public virtual Kontakt Kontakt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Områdekart> Områdekart { get; set; }
    }
}
