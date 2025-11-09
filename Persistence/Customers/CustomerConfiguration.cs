using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.BespokedBikes.Persistence.Customers
{
    public class CustomerConfiguration 
        : IEntityTypeConfiguration<Customer>
    {       

        public void Configure(EntityTypeBuilder<Customer> builder)
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

            builder.HasData(
                new Customer() { Id = 1, FirstName = "Jason", LastName = "Miller", Address = "1427 Oakwood Dr, Dallas, TX 75214", Phone = "(214) 582-9173", StartDate = new DateTime(2025, 01, 08) },
                new Customer() { Id = 2, FirstName = "Emily", LastName = "Carter", Address = "983 Ridge Ave, Columbus, OH 43215", Phone = "(614) 392-6019", StartDate = new DateTime(2025, 01, 03) },
                new Customer() { Id = 3, FirstName = "Daniel", LastName = "Ramirez", Address = "410 Sunset Blvd, Los Angeles, CA 90028", Phone = "(323) 709-8814", StartDate = new DateTime(2025, 01, 12) },
                new Customer() { Id = 4, FirstName = "Sarah", LastName = "Bennett", Address = "2291 Elmhurst Rd, Buffalo, NY 14221", Phone = "(716) 314-0972", StartDate = new DateTime(2025, 01, 17) },
                new Customer() { Id = 5, FirstName = "Robert", LastName = "Hughes", Address = "58 Meadow Ln, Lexington, KY 40502", Phone = "(859) 712-6605", StartDate = new DateTime(2025, 01, 15) },
                new Customer() { Id = 6, FirstName = "Ashley", LastName = "Wilson", Address = "1914 Crestview Ct, Austin, TX 78745", Phone = "(512) 344-7029", StartDate = new DateTime(2025, 01, 15) },
                new Customer() { Id = 7, FirstName = "Brian", LastName = "Thompson", Address = "773 Forest Dr, Charlotte, NC 28211", Phone = "(704) 293-1784", StartDate = new DateTime(2025, 01, 15) },
                new Customer() { Id = 8, FirstName = "Olivia", LastName = "Martinez", Address = "315 Willow Way, Phoenix, AZ 85016", Phone = "(602) 845-2906", StartDate = new DateTime(2025, 01, 15) },
                new Customer() { Id = 9, FirstName = "Anthony", LastName = "White", Address = "9042 Ashbrook St, Detroit, MI 48219", Phone = "(313) 471-8801", StartDate = new DateTime(2025, 01, 15) },
                new Customer() { Id = 10, FirstName = "Megan", LastName = "Lewis", Address = "46 Evergreen Pl, Portland, OR 97210", Phone = "(503) 301-4590", StartDate = new DateTime(2025, 01, 10) },
                new Customer() { Id = 11, FirstName = "Christopher", LastName = "Nguyen", Address = "225 Harbor Point Rd, Tampa, FL 33602", Phone = "(813) 977-5623", StartDate = new DateTime(2025, 01, 15) },
                new Customer() { Id = 12, FirstName = "Lauren", LastName = "Adams", Address = "138 Hillcrest Ave, Nashville, TN 37212", Phone = "(615) 271-4958", StartDate = new DateTime(2025, 01, 15) },
                new Customer() { Id = 13, FirstName = "Matthew", LastName = "Clark", Address = "22 Park Blvd, San Diego, CA 92101", Phone = "(619) 740-1156", StartDate = new DateTime(2025, 01, 10) },
                new Customer() { Id = 14, FirstName = "Alexis", LastName = "Rivera", Address = "277 Pineview Dr, Chicago, IL 60614", Phone = "(312) 573-4420", StartDate = new DateTime(2025, 01, 10) },
                new Customer() { Id = 15, FirstName = "Joshua", LastName = "Brooks", Address = "108 Walnut Ct, Pittsburgh, PA 15206", Phone = "(412) 382-0983", StartDate = new DateTime(2025, 01, 10) },
                new Customer() { Id = 16, FirstName = "Madison", LastName = "Flores", Address = "33 Birchwood Ln, Denver, CO 80209", Phone = "(303) 544-6701", StartDate = new DateTime(2025, 01, 08) },
                new Customer() { Id = 17, FirstName = "Brandon", LastName = "Evans", Address = "507 Sunset Cir, Atlanta, GA 30306", Phone = "(404) 328-9110", StartDate = new DateTime(2025, 01, 05) },
                new Customer() { Id = 18, FirstName = "Natalie", LastName = "Jenkins", Address = "199 Coral Reef Rd, Miami, FL 33157", Phone = "(305) 817-2448", StartDate = new DateTime(2025, 01, 10) },
                new Customer() { Id = 19, FirstName = "Ryan", LastName = "Cooper", Address = "612 Northview Blvd, Minneapolis, MN 55405", Phone = "(612) 775-3124", StartDate = new DateTime(2025, 01, 03) },
                new Customer() { Id = 20, FirstName = "Chloe", LastName = "Peterson", Address = "385 Cedar Ridge Rd, Seattle, WA 98115", Phone = "(206) 674-0038", StartDate = new DateTime(2025, 01, 04) });
                
        }
    }
}
