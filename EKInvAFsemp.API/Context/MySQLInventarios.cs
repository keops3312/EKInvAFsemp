using EKInvAFsemp.Common.Classes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EKInvAFsemp.API.Context
{
    public class MySQLInventarios : DbContext
    {
        public MySQLInventarios() : base("name=MySQLInventarios")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        public DbSet<Marcas> Marcas { get; set; }


    }
}