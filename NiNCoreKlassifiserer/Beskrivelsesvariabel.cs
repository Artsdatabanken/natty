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
    
    public partial class Beskrivelsesvariabel
    {
        public int id { get; set; }
        public Nullable<int> naturområde_id { get; set; }
        public Nullable<int> naturområdetype_id { get; set; }
        public string tematiskId { get; set; }
        public string kode { get; set; }
        public Nullable<int> kartlegger_id { get; set; }
        public Nullable<System.DateTime> kartlagt { get; set; }
        public string trinn { get; set; }
        public string beskrivelse { get; set; }
        public string opprinneligKode { get; set; }
        public int totalklassifikasjonskvalitet { get; set; }
        public Nullable<System.Guid> localId { get; set; }
    
        public virtual Kontakt Kontakt { get; set; }
        public virtual Naturområde Naturområde { get; set; }
        public virtual NaturområdeType NaturområdeType { get; set; }
    }
}
