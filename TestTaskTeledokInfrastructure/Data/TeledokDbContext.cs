using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskTeledokCore.Models;

namespace TestTaskTeledokInfrastructure.Data
{
    public class TeledokDbContext : DbContext
    {
        public TeledokDbContext(DbContextOptions<TeledokDbContext> options) : base(options)
        {
        }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Founders> Founders { get; set; }
        public DbSet<ClientsFounders> ClientsFounders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientsConfiguration());
            modelBuilder.ApplyConfiguration(new FoundersConfiguration());
            modelBuilder.ApplyConfiguration(new ClientsFoundersConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public class ClientsConfiguration : IEntityTypeConfiguration<Clients>
        {
            public void Configure(EntityTypeBuilder<Clients> builder) 
            {
                builder.HasKey(c => c.ИНН);
                builder.HasOne(c => c.Учредители)
                    .WithOne(c => c.Компании)
                    .HasForeignKey<ClientsFounders>(c => c.ИНН_Компании);
            }
        }

        public class FoundersConfiguration : IEntityTypeConfiguration<Founders> 
        {
            public void Configure(EntityTypeBuilder<Founders> builder) 
            {
                builder.HasKey (f => f.ИНН);
                builder.HasOne(f => f.Компании)
                    .WithOne(f => f.Учредители)
                    .HasForeignKey<ClientsFounders>(f => f.ИНН_Учредителя);
            }
        }

        public class ClientsFoundersConfiguration : IEntityTypeConfiguration<ClientsFounders>
        {
            public void Configure(EntityTypeBuilder<ClientsFounders> builder)
            {
                builder.HasKey(cf => cf.ИНН_Компании);
                builder.HasKey(cf => cf.ИНН_Учредителя);
            }
        }
    }
}
