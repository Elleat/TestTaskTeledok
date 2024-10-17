using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskTeledokCore.Models;
using TestTaskTeledokCore.ModelsTest;

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

/* ТЕСТОВОЕ
 * public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogSettings> BlogSettings { get; set; }
        public DbSet <Post> posts { get; set; }
        public DbSet<Tag> tags { get; set; }
        modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new BlogSettingsConfiguration());
            modelBuilder.ApplyConfiguration(new PostsConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
        public class BlogConfiguration : IEntityTypeConfiguration<Blog>
        {
            public void Configure(EntityTypeBuilder<Blog> builder)
            {
                builder.HasKey(x => x.Id);
                builder.HasOne(x => x.BlogSettings)
                    .WithOne(x => x.Blog)
                    .HasForeignKey<BlogSettings>(x => x.Blogid);
                builder.HasMany(x => x.Posts)
                    .WithOne(x => x.Blog)
                    .HasForeignKey(x => x.BlogId);
            }
        }

        public class BlogSettingsConfiguration : IEntityTypeConfiguration<BlogSettings>
        {
            public void Configure(EntityTypeBuilder<BlogSettings> builder)
            {
                builder.HasKey(x=>x.Id);
            }
        }
        public class PostsConfiguration : IEntityTypeConfiguration<Post>
        {
                public void Configure(EntityTypeBuilder<Post> builder)
            {
                builder.HasKey(x=>x.Id);
                builder.HasMany(x=>x.Tags)
                    .WithMany(x => x.Posts);
            }
        }
        public class TagConfiguration : IEntityTypeConfiguration<Tag>
        {
            public void Configure(EntityTypeBuilder<Tag> builder)
            {
                builder.HasKey(x=>x.Id);
            }
        }


        // ТЕСТОВОЕ */
