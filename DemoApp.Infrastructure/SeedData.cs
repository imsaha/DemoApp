using DemoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Department>().HasData(
                    new Department()
                    {
                        Id = 1,
                        Name = "Accounts",
                    },
                    new Department()
                    {
                        Id = 2,
                        Name = "Human resource",
                    },
                    new Department()
                    {
                        Id = 3,
                        Name = "Document control",
                    },
                    new Department()
                    {
                        Id = 4,
                        Name = "IT",
                    },
                    new Department()
                    {
                        Id = 5,
                        Name = "Security",
                    }
                );
        }
    }
}
