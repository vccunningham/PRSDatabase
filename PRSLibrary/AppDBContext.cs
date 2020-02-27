﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PRSLibrary;

namespace PRSLibrary {
    public class AppDbContext : DbContext {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseLazyLoadingProxies();
                var connStr = @"server=localhost\sqlexpress;database=PRSDb;trusted_connection=true;";
                builder.UseSqlServer(connStr);

            }
        }



        protected override void OnModelCreating(ModelBuilder model) {
            
            model.Entity<Product>(e => {
                e.ToTable("Products");
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.PartNbr).IsUnique();
                e.Property(x => x.PartNbr).HasMaxLength(30).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Price).HasColumnType("decimal(11,2)");
                e.Property(x => x.Unit).HasMaxLength(30);
                e.Property(x => x.PhotoPath).HasMaxLength(255).IsRequired();
                //e.HasOne(x => x.VendorId);
            });

            model.Entity<Vendor>(e => {
                e.ToTable("Vendors");
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Code).IsUnique();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Address).HasMaxLength(30).IsRequired();
                e.Property(x => x.City).HasMaxLength(30).IsRequired();
                e.Property(x => x.State).HasMaxLength(2).IsRequired();
                e.Property(x => x.ZipCode).HasMaxLength(5).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(255);
            });

            model.Entity<User>(e => {
                e.ToTable("Users");
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Username).IsUnique();
                e.Property(x => x.Password).HasMaxLength(30).IsRequired();
                e.Property(x => x.Firstname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Lastname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(255);
                e.Property(x => x.IsReviewer);
                e.Property(x => x.IsAdmin);
            });

            model.Entity<Request>(e => {
                e.ToTable("Requests");
                e.HasKey(x => x.Id);
                e.Property(x => x.Description).HasMaxLength(80).IsRequired();
                e.Property(x => x.Justification).HasMaxLength(80).IsRequired();
                e.Property(x => x.RejectionReason).HasMaxLength(80).IsRequired();
                e.Property(x => x.DeliveryMode).HasMaxLength(20).IsRequired();


            });

            model.Entity<RequestLine>(e => {
                e.ToTable("RequestLine");
                e.HasKey(x => x.Id);
                e.Property(x => x.ProductId).IsRequired();
                e.Property(x => x.RequestId).IsRequired();
                e.Property(x => x.Quantity).IsRequired();
            });
        }


    }

    
}