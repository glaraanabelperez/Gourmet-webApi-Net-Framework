using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Domain;

namespace Data
{
    public partial class GourmetContext : DbContext
    {
        public GourmetContext()
            : base("name=GourmetConnection")
        {
        }

        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Meals> Meals { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Companies>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Companies>()
                .Property(e => e.direction)
                .IsUnicode(false);

            modelBuilder.Entity<Companies>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Companies>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Companies)
                .HasForeignKey(e => e.idCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Meals>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Meals>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Meals>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Meals>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Meals>()
                .HasMany(e => e.Menus)
                .WithRequired(e => e.Meals)
                .HasForeignKey(e => e.idMeal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menus>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Menus>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Menus)
                .HasForeignKey(e => e.idMenu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.deliveryAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.direction)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.idUser)
                .WillCascadeOnDelete(false);
        }
    }
}
