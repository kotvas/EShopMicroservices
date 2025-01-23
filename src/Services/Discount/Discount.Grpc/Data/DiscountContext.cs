using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "IPhone X", Description = "IPhone Description", Amount = 199 },
                new Coupon { Id = 2, ProductName = "Samsung 10", Description = "Samsung Description", Amount = 109 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}