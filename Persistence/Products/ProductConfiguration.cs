using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.BespokedBikes.Persistence.Products
{
    public class ProductConfiguration
           : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Manufacturer)
                .IsRequired()
                .HasMaxLength(50);  

            builder.Property(p => p.Style)
                .IsRequired()
                .HasMaxLength(50);  

            builder.Property(p => p.PurchasePrice)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(p => p.SalePrice)  
                .IsRequired()
                .HasPrecision(10, 2);    

            builder.Property(p => p.QuantityOnHand)
                .IsRequired();

            builder.Property(p => p.CommissionPercentage)
                .IsRequired();

            // Unique index to prevent duplicate products
            builder.HasIndex(p => new { p.Name, p.Manufacturer, p.Style }).IsUnique();

            builder.HasData(
                new Product() { Id = 1, Name = "Storm Runner X", Manufacturer="Trek", Style="Mountain", PurchasePrice = 1250m, SalePrice=1525m, QuantityOnHand=50, CommissionPercentage=15 },
                new Product() { Id = 2, Name = "AeroPulse 3", Manufacturer = "Specialized", Style = "Road", PurchasePrice = 2450m, SalePrice = 2725m, QuantityOnHand = 50, CommissionPercentage = 20},
                new Product() { Id = 3, Name = "CityCruise 500", Manufacturer = "Giant", Style = "Hybrid", PurchasePrice = 890m, SalePrice = 1125m, QuantityOnHand = 50, CommissionPercentage = 10 },
                new Product() { Id = 4, Name = "TrailEdge Pro", Manufacturer = "Cannondale", Style = "Mountain", PurchasePrice = 1780m, SalePrice = 2050m, QuantityOnHand = 50, CommissionPercentage = 15 },
                new Product() { Id = 5, Name = "VoltRunner", Manufacturer = "Rad Power Bikes", Style = "Electric", PurchasePrice = 2300m, SalePrice = 2650m, QuantityOnHand = 50, CommissionPercentage = 20 },
                new Product() { Id = 6, Name = "WindFlash CX", Manufacturer = "Scott", Style = "Cyclocross", PurchasePrice = 3100m, SalePrice = 3450m, QuantityOnHand = 50, CommissionPercentage = 25 },
                new Product() { Id = 7, Name = "Horizon Trail", Manufacturer = "Kona", Style = "Gravel", PurchasePrice = 1480m, SalePrice = 1750m, QuantityOnHand = 50, CommissionPercentage = 15 },
                new Product() { Id = 8, Name = "MetroLux", Manufacturer = "Electra", Style = "Cruiser", PurchasePrice = 720m, SalePrice = 940m, QuantityOnHand = 50, CommissionPercentage = 10 },
                new Product() { Id = 9, Name = "AeroStrike TT", Manufacturer = "Cervelo", Style = "Triathlon", PurchasePrice = 5600m, SalePrice = 5950m, QuantityOnHand = 50, CommissionPercentage = 30 },
                new Product() { Id = 10, Name = "Ridge Falcon", Manufacturer = "Santa Cruz", Style = "Mountain", PurchasePrice = 4200m, SalePrice = 4500m, QuantityOnHand = 50, CommissionPercentage = 25 });
        }
    }
}
