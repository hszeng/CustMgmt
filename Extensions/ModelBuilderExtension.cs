using CustMgmt.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CustMgmt.Extentions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Customers

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = new Guid("73D5B5F5-3008-49B7-B0D6-CC337F1A3330"),
                    Name = "Customer 1",  
                    Email = "Customer1@xxx.com",
                    Address = "Customer 1 Address",
                    Status = Helpers.Enums.CustomerStatus.Current,
                    CreatedAt =  DateTime.Parse("2022-11-21 10:23:33.887")
                },
                new Customer
                {
                    Id = new Guid("8D04A48E-BE4E-468E-8CE2-3AC0A0C79549"),
                    Name = "Customer 2",                 
                    Email = "Customer2@xxx.com",
                    Address = "Customer 2 Address",
                    Status = Helpers.Enums.CustomerStatus.Current,
                    CreatedAt = DateTime.Parse("2022-11-21 10:23:33.817")
                },
                new Customer
                {
                    Id = new Guid("7406B13E-A793-4B12-84CB-7FE2A694B9AA"),
                    Name = "Customer 3",                
                    Email = "Customer3@xxx.com",
                    Address = "Customer 3 Address",
                    Status = Helpers.Enums.CustomerStatus.NoneActive,
                    CreatedAt = DateTime.Parse("2022-11-21 10:13:33.887")
                },
                new Customer
                {
                    Id = new Guid("84556ABD-1A6C-4D20-A8A7-271DD4393B2E"),
                    Name = "Customer 4",                 
                    Email = "Customer4@xxx.com",
                    Address = "Customer 4 Address",
                    Status = Helpers.Enums.CustomerStatus.Prospective,
                    CreatedAt = DateTime.Parse("2022-11-21 10:24:33.887")
                },
                new Customer
                {
                    Id = new Guid("2029DB57-C15C-4C0C-80A0-C811B7995CB4"),
                    Name = "Customer 5",
                    Email = "Customer5@xxx.com",
                    Address = "Customer 5 Address",
                    Status = Helpers.Enums.CustomerStatus.Current,
                    CreatedAt = DateTime.Parse("2022-11-21 11:23:33.887")
                },
                new Customer
                {
                    Id = new Guid("5F978CF6-DF6D-47A9-8EF2-D2723CC29CC8"),
                    Name = "Customer 6",
                    Email = "Customer6@xxx.com",
                    Address = "Customer 6 Address",
                    Status = Helpers.Enums.CustomerStatus.Prospective,
                    CreatedAt = DateTime.Parse("2022-11-21 10:23:23.887")
                },
                new Customer
                {
                    Id = new Guid("90EE3976-D672-4411-AE1C-3267BAA940EB"),
                    Name = "Customer 7",
                    Email = "Customer7@xxx.com",
                    Address = "Customer 7 Address",
                    Status = Helpers.Enums.CustomerStatus.NoneActive,
                    CreatedAt = DateTime.Parse("2022-11-21 10:23:53.887")
                },
                new Customer
                {
                    Id = new Guid("4633A79C-9F4A-48D5-AE5A-70945FB8583C"),
                    Name = "Customer 8",
                    Email = "Customer8@xxx.com",
                    Address = "Customer 8 Address",
                    Status = Helpers.Enums.CustomerStatus.Prospective,
                    CreatedAt = DateTime.Parse("2022-11-21 10:23:33.817")
                });

            // Notes
            modelBuilder.Entity<Note>().HasData(
                new Note
                {
                    Id = new Guid("7D8EBDA9-2634-4C0F-9469-0695D6132153"),
                    Content = "Content of Note 1",
                    CustomerId = new Guid("73D5B5F5-3008-49B7-B0D6-CC337F1A3330"),
                    CreatedAt = DateTime.Parse("2022-11-21 10:23:33.001")
                },
                new Note
                {
                    Id = new Guid("1ED47697-AA7D-48C2-AA39-305D0E13B3AA"),
                    Content = "Content of Note 2",
                    CustomerId = new Guid("73D5B5F5-3008-49B7-B0D6-CC337F1A3330"),
                    CreatedAt = DateTime.Parse("2022-11-21 10:23:33.002")
                },
                new Note
                {
                    Id = new Guid("5F82C852-375D-4926-A3B7-84B63FC1BFAE"),
                    Content = "Content of Note 3",
                    CustomerId = new Guid("8D04A48E-BE4E-468E-8CE2-3AC0A0C79549"),
                    CreatedAt = DateTime.Parse("2022-11-21 10:23:33.003")
                },
                new Note
                {
                    Id = new Guid("418A5B20-460B-4604-BE17-2B0809E19ACD"),
                    Content = "Content of Note 4",
                    CustomerId = new Guid("8D04A48E-BE4E-468E-8CE2-3AC0A0C79549"),
                    CreatedAt = DateTime.Parse("2022-11-21 10:23:33.011")
                });
        }
    }
}