using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class StorageDBContext : IdentityDbContext<AppUser>
    {
        public StorageDBContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ProductShop> ProductShops { get; set; }
        public DbSet<ShopType> ShopTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Products
            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsRequired();

            //Shop
            modelBuilder.Entity<Shop>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Shop>()
                .Property(e => e.Address)
                .HasMaxLength(200)
                .IsRequired();


            modelBuilder.Entity<Shop>()
                .HasOne(e => e.Type)
                .WithMany(e => e.Shops)
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.Restrict);



            //ProductShops

            modelBuilder.Entity<ProductShop>()
                .Property(e => e.BarCode)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<ProductShop>()
                .Property(e => e.Price)
                .HasMaxLength(5)
                .IsRequired();

            modelBuilder.Entity<ProductShop>()
                .HasOne(e => e.Shop)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.ShopId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductShop>()
                .HasOne(e => e.Product)
                .WithMany(e => e.Shops)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            //ShopType

            modelBuilder.Entity<ShopType>()
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Seed();
        }
    }
}
