using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.BespokedBikes.Persistence.Sales
{
    public class SaleConfiguration
           : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Date)
                .IsRequired();

            builder.HasOne(p => p.Customer);

            builder.Navigation(p => p.Customer)
                .IsRequired()
                .AutoInclude();

            builder.HasOne(p => p.Employee);

            builder.Navigation(p => p.Employee)
                .IsRequired()
                .AutoInclude();

            builder.HasOne(p => p.Product);

            builder.Navigation(p => p.Product)
                .IsRequired()
                .AutoInclude();

            builder.Property(p => p.TotalPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            // Note: Uses anonomous types to seed foreign keys
            builder.HasData(
                new
                {
                    Id = 1,
                    Date = DateTime.Parse("2025-01-01"),
                    CustomerId = 1,
                    EmployeeId = 1,
                    ProductId = 1,
                    UnitPrice = 1525m,
                    Quantity = 1,
                    TotalPrice = 1525m
                },
                new
                {
                    Id = 2,
                    Date = DateTime.Parse("2025-01-02"),
                    CustomerId = 2,
                    EmployeeId = 2,
                    ProductId = 2,
                    UnitPrice = 2725m,
                    Quantity = 2,
                    TotalPrice = 5450m
                },

                // 50 additional seeded sale rows (randomized within requested ranges).
                new { Id = 3, Date = DateTime.Parse("2025-01-05"), CustomerId = 3, EmployeeId = 1, ProductId = 3, UnitPrice = 1125m, Quantity = 1, TotalPrice = 1125m },
                new { Id = 4, Date = DateTime.Parse("2025-01-12"), CustomerId = 4, EmployeeId = 2, ProductId = 4, UnitPrice = 2050m, Quantity = 2, TotalPrice = 4100m },
                new { Id = 5, Date = DateTime.Parse("2025-01-20"), CustomerId = 5, EmployeeId = 3, ProductId = 5, UnitPrice = 2650m, Quantity = 1, TotalPrice = 2650m },
                new { Id = 6, Date = DateTime.Parse("2025-02-03"), CustomerId = 6, EmployeeId = 4, ProductId = 6, UnitPrice = 3450m, Quantity = 1, TotalPrice = 3450m },
                new { Id = 7, Date = DateTime.Parse("2025-02-08"), CustomerId = 7, EmployeeId = 5, ProductId = 7, UnitPrice = 1750m, Quantity = 2, TotalPrice = 3500m },
                new { Id = 8, Date = DateTime.Parse("2025-02-14"), CustomerId = 8, EmployeeId = 1, ProductId = 8, UnitPrice = 940m, Quantity = 3, TotalPrice = 2820m },
                new { Id = 9, Date = DateTime.Parse("2025-02-22"), CustomerId = 9, EmployeeId = 2, ProductId = 9, UnitPrice = 5950m, Quantity = 1, TotalPrice = 5950m },
                new { Id = 10, Date = DateTime.Parse("2025-03-01"), CustomerId = 10, EmployeeId = 3, ProductId = 10, UnitPrice = 4500m, Quantity = 2, TotalPrice = 9000m },
                new { Id = 11, Date = DateTime.Parse("2025-03-07"), CustomerId = 11, EmployeeId = 4, ProductId = 1, UnitPrice = 1525m, Quantity = 2, TotalPrice = 3050m },
                new { Id = 12, Date = DateTime.Parse("2025-03-15"), CustomerId = 12, EmployeeId = 5, ProductId = 2, UnitPrice = 2725m, Quantity = 1, TotalPrice = 2725m },
                new { Id = 13, Date = DateTime.Parse("2025-03-21"), CustomerId = 13, EmployeeId = 1, ProductId = 3, UnitPrice = 1125m, Quantity = 4, TotalPrice = 4500m },
                new { Id = 14, Date = DateTime.Parse("2025-04-02"), CustomerId = 14, EmployeeId = 2, ProductId = 4, UnitPrice = 2050m, Quantity = 1, TotalPrice = 2050m },
                new { Id = 15, Date = DateTime.Parse("2025-04-12"), CustomerId = 15, EmployeeId = 3, ProductId = 5, UnitPrice = 2650m, Quantity = 3, TotalPrice = 7950m },
                new { Id = 16, Date = DateTime.Parse("2025-04-18"), CustomerId = 16, EmployeeId = 4, ProductId = 6, UnitPrice = 3450m, Quantity = 2, TotalPrice = 6900m },
                new { Id = 17, Date = DateTime.Parse("2025-04-25"), CustomerId = 17, EmployeeId = 5, ProductId = 7, UnitPrice = 1750m, Quantity = 1, TotalPrice = 1750m },
                new { Id = 18, Date = DateTime.Parse("2025-05-03"), CustomerId = 18, EmployeeId = 1, ProductId = 8, UnitPrice = 940m, Quantity = 5, TotalPrice = 4700m },
                new { Id = 19, Date = DateTime.Parse("2025-05-09"), CustomerId = 19, EmployeeId = 2, ProductId = 9, UnitPrice = 5950m, Quantity = 1, TotalPrice = 5950m },
                new { Id = 20, Date = DateTime.Parse("2025-05-16"), CustomerId = 20, EmployeeId = 3, ProductId = 10, UnitPrice = 4500m, Quantity = 1, TotalPrice = 4500m },
                new { Id = 21, Date = DateTime.Parse("2025-05-22"), CustomerId = 1, EmployeeId = 4, ProductId = 1, UnitPrice = 1525m, Quantity = 3, TotalPrice = 4575m },
                new { Id = 22, Date = DateTime.Parse("2025-06-01"), CustomerId = 2, EmployeeId = 5, ProductId = 2, UnitPrice = 2725m, Quantity = 2, TotalPrice = 5450m },
                new { Id = 23, Date = DateTime.Parse("2025-06-07"), CustomerId = 3, EmployeeId = 1, ProductId = 3, UnitPrice = 1125m, Quantity = 6, TotalPrice = 6750m },
                new { Id = 24, Date = DateTime.Parse("2025-06-13"), CustomerId = 4, EmployeeId = 2, ProductId = 4, UnitPrice = 2050m, Quantity = 2, TotalPrice = 4100m },
                new { Id = 25, Date = DateTime.Parse("2025-06-21"), CustomerId = 5, EmployeeId = 3, ProductId = 5, UnitPrice = 2650m, Quantity = 4, TotalPrice = 10600m },
                new { Id = 26, Date = DateTime.Parse("2025-06-28"), CustomerId = 6, EmployeeId = 4, ProductId = 6, UnitPrice = 3450m, Quantity = 1, TotalPrice = 3450m },
                new { Id = 27, Date = DateTime.Parse("2025-07-02"), CustomerId = 7, EmployeeId = 5, ProductId = 7, UnitPrice = 1750m, Quantity = 2, TotalPrice = 3500m },
                new { Id = 28, Date = DateTime.Parse("2025-07-09"), CustomerId = 8, EmployeeId = 1, ProductId = 8, UnitPrice = 940m, Quantity = 2, TotalPrice = 1880m },
                new { Id = 29, Date = DateTime.Parse("2025-07-14"), CustomerId = 9, EmployeeId = 2, ProductId = 9, UnitPrice = 5950m, Quantity = 3, TotalPrice = 17850m },
                new { Id = 30, Date = DateTime.Parse("2025-07-20"), CustomerId = 10, EmployeeId = 3, ProductId = 10, UnitPrice = 4500m, Quantity = 1, TotalPrice = 4500m },
                new { Id = 31, Date = DateTime.Parse("2025-07-26"), CustomerId = 11, EmployeeId = 4, ProductId = 1, UnitPrice = 1525m, Quantity = 5, TotalPrice = 7625m },
                new { Id = 32, Date = DateTime.Parse("2025-08-03"), CustomerId = 12, EmployeeId = 5, ProductId = 2, UnitPrice = 2725m, Quantity = 1, TotalPrice = 2725m },
                new { Id = 33, Date = DateTime.Parse("2025-08-10"), CustomerId = 13, EmployeeId = 1, ProductId = 3, UnitPrice = 1125m, Quantity = 2, TotalPrice = 2250m },
                new { Id = 34, Date = DateTime.Parse("2025-08-16"), CustomerId = 14, EmployeeId = 2, ProductId = 4, UnitPrice = 2050m, Quantity = 3, TotalPrice = 6150m },
                new { Id = 35, Date = DateTime.Parse("2025-08-22"), CustomerId = 15, EmployeeId = 3, ProductId = 5, UnitPrice = 2650m, Quantity = 2, TotalPrice = 5300m },
                new { Id = 36, Date = DateTime.Parse("2025-08-29"), CustomerId = 16, EmployeeId = 4, ProductId = 6, UnitPrice = 3450m, Quantity = 3, TotalPrice = 10350m },
                new { Id = 37, Date = DateTime.Parse("2025-09-04"), CustomerId = 17, EmployeeId = 5, ProductId = 7, UnitPrice = 1750m, Quantity = 4, TotalPrice = 7000m },
                new { Id = 38, Date = DateTime.Parse("2025-09-11"), CustomerId = 18, EmployeeId = 1, ProductId = 8, UnitPrice = 940m, Quantity = 1, TotalPrice = 940m },
                new { Id = 39, Date = DateTime.Parse("2025-09-18"), CustomerId = 19, EmployeeId = 2, ProductId = 9, UnitPrice = 5950m, Quantity = 2, TotalPrice = 11900m },
                new { Id = 40, Date = DateTime.Parse("2025-09-25"), CustomerId = 20, EmployeeId = 3, ProductId = 10, UnitPrice = 4500m, Quantity = 4, TotalPrice = 18000m },
                new { Id = 41, Date = DateTime.Parse("2025-10-02"), CustomerId = 1, EmployeeId = 4, ProductId = 1, UnitPrice = 1525m, Quantity = 2, TotalPrice = 3050m },
                new { Id = 42, Date = DateTime.Parse("2025-10-08"), CustomerId = 2, EmployeeId = 5, ProductId = 2, UnitPrice = 2725m, Quantity = 3, TotalPrice = 8175m },
                new { Id = 43, Date = DateTime.Parse("2025-10-14"), CustomerId = 3, EmployeeId = 1, ProductId = 3, UnitPrice = 1125m, Quantity = 5, TotalPrice = 5625m },
                new { Id = 44, Date = DateTime.Parse("2025-10-20"), CustomerId = 4, EmployeeId = 2, ProductId = 4, UnitPrice = 2050m, Quantity = 2, TotalPrice = 4100m },
                new { Id = 45, Date = DateTime.Parse("2025-10-26"), CustomerId = 5, EmployeeId = 3, ProductId = 5, UnitPrice = 2650m, Quantity = 1, TotalPrice = 2650m },
                new { Id = 46, Date = DateTime.Parse("2025-10-30"), CustomerId = 6, EmployeeId = 4, ProductId = 6, UnitPrice = 3450m, Quantity = 2, TotalPrice = 6900m },
                new { Id = 47, Date = DateTime.Parse("2025-11-01"), CustomerId = 7, EmployeeId = 5, ProductId = 7, UnitPrice = 1750m, Quantity = 1, TotalPrice = 1750m },
                new { Id = 48, Date = DateTime.Parse("2025-11-02"), CustomerId = 8, EmployeeId = 1, ProductId = 8, UnitPrice = 940m, Quantity = 4, TotalPrice = 3760m },
                new { Id = 49, Date = DateTime.Parse("2025-11-03"), CustomerId = 9, EmployeeId = 2, ProductId = 9, UnitPrice = 5950m, Quantity = 1, TotalPrice = 5950m },
                new { Id = 50, Date = DateTime.Parse("2025-11-04"), CustomerId = 10, EmployeeId = 3, ProductId = 10, UnitPrice = 4500m, Quantity = 2, TotalPrice = 9000m },
                new { Id = 51, Date = DateTime.Parse("2025-11-05"), CustomerId = 11, EmployeeId = 4, ProductId = 1, UnitPrice = 1525m, Quantity = 1, TotalPrice = 1525m },
                new { Id = 52, Date = DateTime.Parse("2025-11-05"), CustomerId = 12, EmployeeId = 5, ProductId = 2, UnitPrice = 2725m, Quantity = 1, TotalPrice = 2725m }
            );
        }
    }
}
