﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCDiyethane.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_DIYETEntities : DbContext
    {
        public DB_DIYETEntities()
            : base("name=DB_DIYETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLDIYETLER> TBLDIYETLER { get; set; }
        public virtual DbSet<TBLILETISIM> TBLILETISIM { get; set; }
        public virtual DbSet<TBLKATEGORI> TBLKATEGORI { get; set; }
        public virtual DbSet<TBLPERSONEL> TBLPERSONEL { get; set; }
        public virtual DbSet<TBLUYELER> TBLUYELER { get; set; }
        public virtual DbSet<TBLYAZAR> TBLYAZAR { get; set; }
    }
}