using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.BespokedBikes.Persistence.Employees
{
    public class EmployeeConfiguration
           : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);  

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.TerminationDate)
                .IsRequired(false);

            builder.Property(p => p.Manager)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(p => new { p.FirstName, p.LastName}).IsUnique();

            builder.HasData(
                new Employee() { Id = 1, FirstName = "Jessica", LastName = "Turner", Address = "814 Willow Creek Rd, Raleigh, NC 27609", Phone = "(919) 507-2334", StartDate = new DateTime(2025, 01,10), TerminationDate=null, Manager= "Michael Anderson" },
                new Employee() { Id = 2, FirstName = "David", LastName = "Morales", Address = "2234 Summit View Dr, Denver, CO 80237", Phone = "(303) 679-4412", StartDate = new DateTime(2025, 01, 10), TerminationDate = null, Manager = "Laura Mitchell" },
                new Employee() { Id = 3, FirstName = "Kimberly", LastName = "Ross", Address = "56 Baywood Ct, San Jose, CA 95125", Phone = "(408) 931-7785", StartDate = new DateTime(2025, 01, 10), TerminationDate = null, Manager = "Michael Anderson" },
                new Employee() { Id = 4, FirstName = "Ethan", LastName = "Phillips", Address = "122 Maple Grove Ave, Chicago, IL 60657", Phone = "(312) 945-2279", StartDate = new DateTime(2025, 01, 10), TerminationDate = null, Manager = "Laura Mitchell" },
                new Employee() { Id = 5, FirstName = "Amanda", LastName = "Scott", Address = "490 Cedar Springs Ln, Tampa, FL 33618", Phone = "(813) 504-9820", StartDate = new DateTime(2025, 01, 10), TerminationDate = null, Manager = "Michael Anderson" });
        }
    }
}
