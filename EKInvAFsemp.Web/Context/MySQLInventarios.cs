using EKInvAFsemp.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EKInvAFsemp.Web.Context
{
    public class MySQLInventarios:DbContext
    {
        public MySQLInventarios() : base("name=MySQLInventarios")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Usuarios>  usuarios { get; set; }
        public DbSet<Marcas> Marcas { get; set; }

        public DbSet<Tipos> Tipos { get; set; }
    }
}