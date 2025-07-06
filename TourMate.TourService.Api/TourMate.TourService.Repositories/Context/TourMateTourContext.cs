using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TourMate.TourService.Repositories.Models;

namespace TourMate.TourService.Repositories.Context;

public partial class TourMateTourContext : DbContext
{
    public TourMateTourContext()
    {
    }

    public TourMateTourContext(DbContextOptions<TourMateTourContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Invoice");

            entity.Property(e => e.AreaId).HasColumnName("areaId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("customerPhone");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.InvoiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("invoiceId");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PeopleAmount)
                .HasMaxLength(255)
                .HasColumnName("peopleAmount");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TourDesc).HasColumnName("tourDesc");
            entity.Property(e => e.TourGuideId).HasColumnName("tourGuideId");
            entity.Property(e => e.TourName)
                .HasMaxLength(255)
                .HasColumnName("tourName");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tour");

            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ServiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("serviceId");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(255)
                .HasColumnName("serviceName");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.TourDesc).HasColumnName("tourDesc");
            entity.Property(e => e.TourGuideId).HasColumnName("tourGuideId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
