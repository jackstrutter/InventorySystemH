﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SOPORTEE.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class inventoryContext : DbContext
    {
        public inventoryContext()
            : base("name=inventoryContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<appUsers> appUsers { get; set; }
        public virtual DbSet<assignments> assignments { get; set; }
        public virtual DbSet<brands> brands { get; set; }
        public virtual DbSet<companies> companies { get; set; }
        public virtual DbSet<computers> computers { get; set; }
        public virtual DbSet<degrees> degrees { get; set; }
        public virtual DbSet<devices> devices { get; set; }
        public virtual DbSet<deviceTypes> deviceTypes { get; set; }
        public virtual DbSet<locations> locations { get; set; }
        public virtual DbSet<models> models { get; set; }
        public virtual DbSet<operatingSystems> operatingSystems { get; set; }
        public virtual DbSet<processors> processors { get; set; }
        public virtual DbSet<proyects> proyects { get; set; }
        public virtual DbSet<states> states { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<userTypes> userTypes { get; set; }
    }
}
