//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagementSystem.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBLIBRARYEntities : DbContext
    {
        public DBLIBRARYEntities()
            : base("name=DBLIBRARYEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<authors> authors { get; set; }
        public virtual DbSet<books> books { get; set; }
        public virtual DbSet<cases> cases { get; set; }
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<events> events { get; set; }
        public virtual DbSet<members> members { get; set; }
        public virtual DbSet<penalties> penalties { get; set; }
        public virtual DbSet<personnels> personnels { get; set; }
    }
}
