﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrossSell_App.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PAL_DigitalPicEntities : DbContext
    {
        public PAL_DigitalPicEntities()
            : base("name=PAL_DigitalPicEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CrossSell> CrossSells { get; set; }
        public virtual DbSet<Metadata> Metadatas { get; set; }
        public virtual DbSet<Objective> Objectives { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<Portfolio_Type> Portfolio_Type { get; set; }
        public virtual DbSet<Questioner> Questioners { get; set; }
        public virtual DbSet<Portfolio_Agile_Lab> Portfolio_Agile_Lab { get; set; }
        public virtual DbSet<UserAccess> UserAccesses { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}