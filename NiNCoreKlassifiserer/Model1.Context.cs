﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NiNCore_norskEntities : DbContext
    {
        public NiNCore_norskEntities()
            : base("name=NiNCore_norskEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Beskrivelsesvariabel> Beskrivelsesvariabel { get; set; }
        public virtual DbSet<Dataleveranse> Dataleveranse { get; set; }
        public virtual DbSet<Dokument> Dokument { get; set; }
        public virtual DbSet<EgendefinertVariabel> EgendefinertVariabel { get; set; }
        public virtual DbSet<EgendefinertVariabelDefinisjon> EgendefinertVariabelDefinisjon { get; set; }
        public virtual DbSet<KartlagtOmråde> KartlagtOmråde { get; set; }
        public virtual DbSet<Kontakt> Kontakt { get; set; }
        public virtual DbSet<Naturnivå> Naturnivå { get; set; }
        public virtual DbSet<Naturområde> Naturområde { get; set; }
        public virtual DbSet<NaturområdeType> NaturområdeType { get; set; }
        public virtual DbSet<Område> Område { get; set; }
        public virtual DbSet<Områdekart> Områdekart { get; set; }
        public virtual DbSet<OmrådekartType> OmrådekartType { get; set; }
        public virtual DbSet<OmrådeType> OmrådeType { get; set; }
        public virtual DbSet<Rutenett> Rutenett { get; set; }
        public virtual DbSet<Rutenettkart> Rutenettkart { get; set; }
        public virtual DbSet<RutenettkartType> RutenettkartType { get; set; }
        public virtual DbSet<Rutenettype> Rutenettype { get; set; }
        public virtual DbSet<Standardvariabel> Standardvariabel { get; set; }
    }
}